(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .controller('EnviarReposicionController', EnviarReposicionController);

    function EnviarReposicionController($uibModalInstance, toastr, camionService, reposicionService, reposicion) {

        var vm = this;
        vm.title = 'Enviar orden de reposición';

        vm.camiones = [];
        vm.camion = null;
        vm.reposicion = reposicion;

        vm.enviar = enviar;
        vm.cerrar = cerrar;

        activate();

        function activate() {
            vm.prom_cam = camionService.get().then(function (data) {
                vm.camiones = _.filter(data, {'estado': 'disponible' });
            }, function (error) { })
        }

        function enviar() {
            if (vm.camion !== null) {
                vm.cargando = true;
                reposicionService.enviar(vm.reposicion.id, vm.camion, vm.comentario).then(function (data) {
                    vm.cargando = false;
                    toastr.success('Orden de reposición enviada correctamente');
                    $uibModalInstance.close(data);
                }, function (error) {
                    vm.cargando = false;
                })
            } else
                toastr.warning('Debe seleccionar un camión');
        }

        function cerrar() {
            $uibModalInstance.dismiss();
        }
    }
})();
