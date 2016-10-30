(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .controller('RecibirReposicionController', RecibirReposicionController);

    function RecibirReposicionController($uibModalInstance, toastr, reposicionService, reposicion) {

        var vm = this;
        vm.title = 'Marcar recepción';

        vm.marcar = marcar;
        vm.cerrar = cerrar;

        function marcar() {
            vm.cargando = true;
            vm.prom_repo = reposicionService.recepcion(reposicion.id, vm.comentario).then(function (data) {
                toastr.success('La orden ha sido marcada como entregada');
                vm.cargando = false;
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
