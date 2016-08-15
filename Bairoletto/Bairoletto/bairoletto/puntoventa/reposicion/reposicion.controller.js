(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .controller('ReposicionController', ReposicionController);

    function ReposicionController($uibModal) {
        var vm = this;
        vm.ordenes_reposicion = [];

        vm.nueva = nuevaOrden;

        activate();

        function activate() { }

        function nuevaOrden() {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/puntoventa/reposicion/reposicion-crear.html',
                controller: 'CrearReposicionController',
                controllerAs: 'nueva',
                size: 'lg'
            });

            modalInstance.result.then(function (nueva_orden) {
                vm.ordenes_reposicion.push(nueva_orden);
                console.log(nueva_orden);
            });
        }
    }
})();
