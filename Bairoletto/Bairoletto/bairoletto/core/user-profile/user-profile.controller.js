(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('UserProfile', UserProfile);

    function UserProfile() {
        var vm = this;

        // Dbería ser el resultado de una API
        vm.fabricas = [{
            id: 1,
            titulo: 'Planta de elaboración',
            codigo: 'BAI_FAB_01',
            nombre: 'Planta 01 - Parque Industrial Roca',
            fecha_alta: new Date(2007, 1, 1).toISOString(),
            direccion: 'Independencia 1607, Parque Industrial',
            telefono: '(0298) 4356229',
            ciudad: 'General Roca',
            provincia: 'Rio Negro',
            pais: 'Argentina'
        }];
        vm.puntos_venta = [
            {
                id: 1,
                titulo: 'Sucursal',
                codigo: 'BAI_SUC_01',
                nombre: 'Bairoletto Empanadas Sureñas',
                direccion: 'San Juan casi Villegas',
                telefono: '4432100',
                ciudad: 'General Roca',
                provincia: 'Rio Negro',
                pais: 'Argentina'
            },
            {
                id: 2,
                titulo: 'Sucursal',
                codigo: 'BAI_SUC_02',
                nombre: 'Bairoletto Empanadas Sureñas',
                direccion: 'Gral. Manuel Belgrano 2000, 8300',
                telefono: '0299 448-9600',
                ciudad: 'Neuquen',
                provincia: 'Neuquen',
                pais: 'Argentina'
            },
            {
                id: 3,
                titulo: 'Sucursal',
                codigo: 'BAI_SUC_03',
                nombre: 'Bairoletto Empanadas Sureñas',
                direccion: 'Gral. San Martín 252, 8324',
                telefono: '0299 478-4600',
                ciudad: 'Cipolletti',
                provincia: 'Rio Negro',
                pais: 'Argentina'
            }
        ]

        activate();

        function activate() {
            vm.user_profile = JSON.parse(localStorage.getItem('profile')) || {};

            if (typeof vm.user_profile.planta_elaboracion_id !== 'undefined') 
                vm.user_profile.entidad = _.find(vm.fabricas, { 'id': vm.user_profile.planta_elaboracion_id });

            if (typeof vm.user_profile.punto_venta_id !== 'undefined')
                vm.user_profile.entidad = _.find(vm.puntos_venta, { 'id': vm.user_profile.punto_venta_id });
            
        }
    }
})();
