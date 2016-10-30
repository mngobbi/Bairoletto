(function () {
    'use strict';

    angular
        .module('app.core')
        .component('baiPanelInside', {
            templateUrl: '/bairoletto/core/layout/bai-panel-inside/bai-panel-inside.component.html',
            controller: BaiPanelInsideController,
            transclude: {
                'info': '?baiInfo'
            },
            bindings: {
                baiMainColor: '<',
                baiOpenedColor: '<',
                baiOpen: '<',
                baiOnClick: '&'
            }
        });

    function BaiPanelInsideController() {
        var vm = this;
        vm.open = open;

        vm.opened_subtitle_style = {
            'border-top': '1px solid ' + vm.baiOpenedColor
        }
        vm.opened_icon_style = {
            'color': vm.baiOpenedColor
        }

        function open() {
            vm.baiOnClick();
        }
    }

})();