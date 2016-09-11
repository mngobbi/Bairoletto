(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .component('baiReposicionDetalle', {
            templateUrl: '/bairoletto/puntoventa/reposicion/reposicion-detalle/reposicion-detalle.component.html',
            controller: ['reposicionService', BaiReposicionDetalleController],
            bindings: {
                baiClass: '<',
                baiData: '<',
                baiTitle: '<',
                baiIcon: '<'
            },
            transclude: {
                'extraData': 'baiData',
                'actions': '?baiActions'
            }
        });

    function BaiReposicionDetalleController(reposicionService) {
        var vm = this;

        vm.reposicionDetalle = reposicionDetalle;

        this.$onChanges = function (changes) {
            
        }

        function reposicionDetalle() {
            if (!vm.baiData.all_data && !vm.baiData.loading) {
                vm.baiData.loading = true;
                reposicionService.getById(vm.baiData.id).then(function (data) {
                    vm.baiData.loading = false;
                    vm.baiData = _.mergeWith(vm.baiData, data, function (objValue, srcValue) {
                        if (_.isArray(objValue)) {
                            return objValue = srcValue;
                        }
                    });
                    vm.baiData.all_data = true;
                }, function () {
                    vm.baiData.loading = false;
                })
            }
        }

    }

})();