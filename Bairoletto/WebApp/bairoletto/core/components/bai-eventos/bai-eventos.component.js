(function () {
    'use strict';

    angular
        .module('app.core')
        .component('baiEventos', {
            templateUrl: '/bairoletto/core/components/bai-eventos/bai-eventos.component.html',
            controller: BaiEventosController,
            bindings: {
                baiEventos: '<'
            }
        });

    function BaiEventosController() {
        var vm = this;
        vm.open = false;

        this.$onChanges = function (changes) {
            mostrarEventos(vm.baiEventos);
        }

        function mostrarEventos(eve) {
            _.forEach(eve, function (x) {
                switch (x.tipo) {
                    case 'confirmacion':
                        x.icono = 'fa-thumbs-o-up';
                        x.color = 'primary';
                        break;
                    case 'agenda':
                        x.icono = 'fa-calendar';
                        x.proxima_accion = x.nombre;
                        break;
                    case 'cancelacion':
                        x.icono = 'fa-times';
                        x.color = 'danger';
                        break;
                    case 'en_transito':
                        x.icono = 'fa-truck';
                        x.color = 'warning';
                        break;
                    case 'recepcion':
                        x.icono = 'fa-check';
                        x.color = 'success';
                        break;
                    case 'comentario':
                        x.icono = 'fa-comment-o';
                        break;
                }
            })
        }

    }

})();