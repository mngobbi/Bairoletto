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

        vm.reposicionDetalle = reposicionDetalle;
        vm.nueva = nuevaOrden;

        activate();

        function activate() {
            vm.prom = reposicionService.get(pv_id).then(function (data) {
                data = _.orderBy(data, 'fecha_solicitud', 'desc');
                vm.ordenes_reposicion_proceso = _.filter(data, function (x) {
                    return x.estado == 'nueva' || x.estado == 'confirmada' || x.estado == 'en_transito';
                });
            }, function () { })
        }

        function reposicionDetalle(r) {
            if (!r.all_data && !r.loading) {
                r.loading = true;
                reposicionService.getById(r.id).then(function (data) {
                    r.loading = false;
                    r = _.mergeWith(r, data, function (objValue, srcValue) {
                        if (_.isArray(objValue)) {
                            return objValue = srcValue;
                        }
                    });
                    r.all_data = true;
                }, function () {
                    r.loading = false;
                })
            }
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
    }
})();
