(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .controller('CrearReposicionController', CrearReposicionController);

    function CrearReposicionController($uibModalInstance, toastr, productoService, reposicionService, pv_id) {

        var vm = this;
        vm.title = 'Crear nueva orden de reposición';
        vm.datepicker = {
            opened: false
        };
        vm.date_options = {
            minDate: new Date(moment().startOf('d'))
        };
        vm.productos = [];
        vm.productos_seleccionados = [];

        vm.open = open;
        vm.crear = crear;
        vm.cerrar = cerrar;

        activate();

        function activate() {
            vm.prom_prod = productoService.get(pv_id).then(function (data) {
                vm.productos = data;
            }, function (error) { })
        }

        function open() {
            vm.datepicker.opened = true;
        }

        function crear() {
            _.remove(vm.productos_seleccionados, function (x) {
                return typeof x.cantidad_solicitada === 'undefined' || x.cantidad_solicitada == null;
            })
            var productos = _.map(vm.productos_seleccionados, function (x) {
                return { producto_id: x.producto.id, cantidad_solicitada: x.cantidad_solicitada, precio_unitario: x.producto.precio_costo };
            })

            if (vm.productos_seleccionados.length == 0)
                toastr.warning('Debe seleccionar al menos un producto');
            else {
                vm.cargando = true;
                vm.prom_repo = reposicionService.crear(pv_id, vm.fecha_deseada, productos, vm.comentario).then(function (data) {
                    toastr.success('Orden enviada correctamente');
                    vm.cargando = false;
                    $uibModalInstance.close(data);
                }, function (error) {
                    vm.cargando = false;
                })
            }
        }

        function cerrar() {
            $uibModalInstance.dismiss();
        }
    }
})();
