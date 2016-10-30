(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .controller('AprobarReposicionController', AprobarReposicionController);

    function AprobarReposicionController($uibModalInstance, toastr, productoService, reposicionService, reposicion) {

        var vm = this;
        vm.title = 'Aprobar orden de reposición';
        vm.datepicker = {
            opened: false
        };
        vm.date_options = {
            minDate: new Date(moment().startOf('d'))
        };
        vm.productos = [];
        vm.reposicion = reposicion;

        vm.open = open;
        vm.aprobar = aprobar;
        vm.cerrar = cerrar;

        activate();

        function activate() {
            vm.prom_prod = productoService.get().then(function (data) {
                vm.productos = data;
                _.forEach(vm.reposicion.productos, function (p) {
                    var prod = _.find(vm.productos, { 'id': p.producto.id });
                    p.stock_fabrica = prod.stock;
                })
            }, function (error) { })
        }

        function open() {
            vm.datepicker.opened = true;
        }

        function aprobar() {
            vm.cargando = true;
            reposicionService.aprobar(vm.reposicion.id, vm.fecha_estimada, vm.comentario).then(function (data) {
                vm.cargando = false;
                toastr.success('Orden de reposición aprobada correctamente');
                $uibModalInstance.close(data);
            }, function (error) {
                vm.cargando = false;
            })
        }

        function cerrar() {
            $uibModalInstance.dismiss();
        }
    }
})();
