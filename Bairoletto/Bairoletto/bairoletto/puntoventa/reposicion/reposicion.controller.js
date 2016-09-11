(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .controller('ReposicionController', ReposicionController);

    function ReposicionController($uibModal, reposicionService) {

        var pv_id = 2;

        var vm = this;
        vm.ordenes_reposicion_proceso = [];
        vm.ordenes_reposicion_finalizadas = [];

        vm.nueva = nuevaOrden;
        vm.recepcion = marcarRecepcion;

        activate();

        function activate() {
            vm.prom = reposicionService.get(pv_id).then(function (data) {
                data = _.orderBy(data, 'fecha_solicitud', 'desc');
                vm.ordenes_reposicion_proceso = _.filter(data, function (x) {
                    return x.estado == 'nueva' || x.estado == 'confirmada' || x.estado == 'en_transito';
                });
                vm.ordenes_reposicion_finalizadas = _.filter(data, function (x) {
                    return x.estado == 'entregada' || x.estado == 'cancelada';
                });
            }, function () { })
        }

        function nuevaOrden() {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/puntoventa/reposicion/reposicion-crear/reposicion-crear.html',
                controller: 'CrearReposicionController',
                controllerAs: 'nueva',
                size: 'lg'
            });

            modalInstance.result.then(function (nueva_orden) {
                vm.ordenes_reposicion_proceso.unshift(nueva_orden);
            });
        }

        function marcarRecepcion(r) {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/puntoventa/reposicion/reposicion-recepcion/reposicion-recepcion.html',
                controller: 'RecibirReposicionController',
                controllerAs: 'recepcion',
                resolve: {
                    reposicion: function () {
                        return r;
                    }
                }
            });

            modalInstance.result.then(function (orden_entregada) {
                _.remove(vm.ordenes_reposicion_proceso, function (x) {
                    return x.id == orden_entregada.id;
                });

                vm.ordenes_reposicion_finalizadas.unshift(orden_entregada)
            });
        }
    }
})();
