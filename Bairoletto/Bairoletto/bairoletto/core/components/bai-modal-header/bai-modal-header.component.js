(function () {
    'use strict';

    angular
        .module('app.core')
        .component('baiModalHeader', {
            templateUrl: '/bairoletto/core/components/bai-modal-header/bai-modal-header.component.html',
            controller: ModalHeaderController,
            bindings: {
                baiTitle: '<',
                baiOnClick: '&',
            }
        });

    function ModalHeaderController() {
        var vm = this;
        vm.close = close;

        function close () {
            vm.baiOnClick();
        }
    }

})();