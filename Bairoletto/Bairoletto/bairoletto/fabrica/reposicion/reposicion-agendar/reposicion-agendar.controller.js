(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .controller('AgendarReposicionController', AgendarReposicionController);

    function AgendarReposicionController($uibModalInstance, toastr, reposicionService, reposicion) {
        
        var vm = this;
        vm.title = 'Agendar orden de reposición';
        vm.datepicker = {
            opened: false
        };
        vm.date_options = {
            minDate: new Date(moment().startOf('d'))
        };

        vm.open = open;
        vm.agendar = agendar;
        vm.cerrar = cerrar;

        activate();

        function activate() {
            if (typeof reposicion.fecha_entrega_estimada !== 'undefined')
                vm.fecha_estimada = new Date(reposicion.fecha_entrega_estimada);
        }

        function open() {
            vm.datepicker.opened = true;
        }

        function agendar() {
            vm.cargando = true;
            reposicionService.agendar(reposicion.id, vm.fecha_estimada, vm.comentario).then(function (data) {
                vm.cargando = false;
                toastr.success('Orden de reposición agendada correctamente');
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
