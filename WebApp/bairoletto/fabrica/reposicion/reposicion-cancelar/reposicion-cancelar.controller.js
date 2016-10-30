(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .controller('CancelarReposicionController', CancelarReposicionController);

    function CancelarReposicionController($uibModalInstance, toastr, reposicionService, reposicion) {

        var vm = this;
        vm.title = 'Cancelar orden de reposición';
        vm.causas = [
            { id: 'sin_stock', value: 'Sin stock' },
            { id: 'solicitud_incorrecta', value: 'Solicitud incorrecta' },
            { id: 'otro', value: 'Otro' }
        ];
        vm.causa = null;

        vm.open = open;
        vm.cancelar = cancelar;
        vm.cerrar = cerrar;

        function open() {
            vm.datepicker.opened = true;
        }

        function cancelar() {
            if (vm.causa !== null) {
                vm.cargando = true;
                reposicionService.cancelar(reposicion.id, vm.causa, vm.comentario).then(function (data) {
                    vm.cargando = false;
                    toastr.success('Orden de reposición cancelada correctamente');
                    $uibModalInstance.close(data);
                }, function () {
                    vm.cargando = false;
                })
            } else
                toastr.warning('Debe seleccionar una causa de cancelación');
        }

        function cerrar() {
            $uibModalInstance.dismiss();
        }
    }
})();
