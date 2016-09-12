(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .controller('ReposicionController', ReposicionController);

    function ReposicionController($q, $uibModal, reposicionService) {
        var vm = this;

        vm.panel_nuevas = {
            loading: false,
            open: false,
            raw_data: [],
            data: [],
            total: 0,
        };
        vm.panel_aprobadas = {
            loading: false,
            open: false,
            raw_data: [],
            data: [],
            total: 0,
        };
        vm.panel_en_transito = {
            loading: false,
            open: false,
            raw_data: [],
            data: [],
            total: 0,
        };
        vm.panel_finalizadas = {
            loading: false,
            open: false,
            canceladas_data: [],
            entregadas_data: [],
            total: 0,
        };

        vm.abrirPanel = abrirPanel;
        vm.reposicionDetalle = reposicionDetalle;
        vm.reposicionAprobar = reposicionAprobar;
        vm.reposicionEnviar = reposicionEnviar;
        vm.reposicionCancelar = reposicionCancelar;

        activate();

        function activate() {
            promNuevas();
            promAprobadas();
            promEnTransito();
            promFinalizadas();
        }

        function promNuevas() {
            vm.panel_nuevas.loading = true;
            vm.prom_panel_nuevas = reposicionService.nuevas().then(function (data) {
                vm.panel_nuevas.total = data.length;
                vm.panel_nuevas.raw_data = data;
                vm.panel_nuevas.data = armarArrayPuntosVenta(data);
                vm.panel_nuevas.loading = false;           
            }, function () {
                vm.panel_nuevas.loading = false;
            })
        }
        function promAprobadas() {
            vm.panel_aprobadas.loading = true;
            vm.prom_panel_aprobadas = reposicionService.aprobadas().then(function (data) {
                vm.panel_aprobadas.total = data.length;
                vm.panel_aprobadas.raw_data = data;
                vm.panel_aprobadas.data = armarArrayPuntosVenta(data);
                vm.panel_aprobadas.loading = false;
            }, function () {
                vm.panel_aprobadas.loading = false;
            })
        }
        function promEnTransito() {
            vm.panel_en_transito.loading = true;
            vm.prom_panel_en_transito = reposicionService.entransito().then(function (data) {
                vm.panel_en_transito.total = data.length;
                vm.panel_en_transito.raw_data = data;
                vm.panel_en_transito.data = armarArrayPuntosVenta(data);
                vm.panel_en_transito.loading = false;
            }, function () {
                vm.panel_en_transito.loading = false;
            })
        }
        function promFinalizadas() {
            vm.panel_finalizadas.loading = true;
            vm.prom_panel_finalizadas = $q.all([
                reposicionService.entregadas(),
                reposicionService.canceladas()
            ]).then(function (data) {
                vm.panel_finalizadas.total = data[0].length + data[1].length;
                vm.panel_finalizadas.entregadas_data = data[0];
                vm.panel_finalizadas.canceladas_data = data[1];
                vm.panel_finalizadas.loading = false;

                vm.panel_finalizadas.canceladas_data = _.orderBy(vm.panel_finalizadas.canceladas_data, 'fecha_procesada', 'desc');
                vm.panel_finalizadas.entregadas_data = _.orderBy(vm.panel_finalizadas.entregadas_data, 'fecha_entrega', 'desc');
            }, function () {
                vm.panel_finalizadas.loading = false;
            })
        }

        function armarArrayPuntosVenta(data) {
            var puntos_venta = [];
            var aux = _.groupBy(data, function (x) {
                return x.punto_venta.id;
            })
            _.forIn(aux, function (value, key) {
                var pv = value[0].punto_venta;
                pv.reposiciones = value;
                puntos_venta.push(pv);
            })
            return puntos_venta;
        }

        function abrirPanel(panel) {
            switch (panel) {
                case 'nuevas':
                    vm.panel_nuevas.open = !vm.panel_nuevas.open;
                    vm.panel_aprobadas.open = false;
                    break;
                case 'aprobadas':
                    vm.panel_aprobadas.open = !vm.panel_aprobadas.open
                    vm.panel_nuevas.open = false;
                    break;
                case 'en_transito':
                    vm.panel_en_transito.open = !vm.panel_en_transito.open;
                    vm.panel_finalizadas.open = false;
                    break;
                case 'finalizadas':
                    vm.panel_finalizadas.open = !vm.panel_finalizadas.open;
                    vm.panel_en_transito.open = false;
                    break;
            }
        }

        function reposicionDetalle(r) {
            if (!r.all_data && !r.loading) {
                r.loading = true;
                reposicionService.getById(r.id).then(function (data) {
                    r.loading = false;
                    r.productos = data.productos;
                    r.all_data = true;
                }, function () {
                    r.loading = false;
                })
            }
        }

        function reposicionAprobar(r) {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/fabrica/reposicion/reposicion-aprobar/reposicion-aprobar.html',
                controller: 'AprobarReposicionController',
                controllerAs: 'aprobar',
                resolve: {
                    reposicion: function () {
                        return r;
                    }
                }
            });

            modalInstance.result.then(function (orden_aprobada) {
                //Eliminar del panel nuevas
                _.remove(vm.panel_nuevas.raw_data, function (x) {
                    return x.id == orden_aprobada.id;
                });
                vm.panel_nuevas.total = vm.panel_nuevas.raw_data.length;
                vm.panel_nuevas.data = armarArrayPuntosVenta(vm.panel_nuevas.raw_data);

                //Agregar al panel aprobadas
                vm.panel_aprobadas.raw_data.push(orden_aprobada);
                vm.panel_aprobadas.total = vm.panel_aprobadas.raw_data.length;
                vm.panel_aprobadas.data = armarArrayPuntosVenta(vm.panel_aprobadas.raw_data);              
            });
        }
        function reposicionEnviar(r) {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/fabrica/reposicion/reposicion-enviar/reposicion-enviar.html',
                controller: 'EnviarReposicionController',
                controllerAs: 'enviar',
                resolve: {
                    reposicion: function () {
                        return r;
                    }
                }
            });

            modalInstance.result.then(function (orden_enviada) {
                //Eliminar del panel aprobadas
                _.remove(vm.panel_aprobadas.raw_data, function (x) {
                    return x.id == orden_enviada.id;
                });
                vm.panel_aprobadas.total = vm.panel_aprobadas.raw_data.length;
                vm.panel_aprobadas.data = armarArrayPuntosVenta(vm.panel_aprobadas.raw_data);

                //Agregar al panel en transito
                vm.panel_en_transito.raw_data.push(orden_enviada);
                vm.panel_en_transito.total = vm.panel_en_transito.raw_data.length;
                vm.panel_en_transito.data = armarArrayPuntosVenta(vm.panel_en_transito.raw_data);
            });
        }
        function reposicionCancelar(r, panel) {
            var modalInstance = $uibModal.open({
                templateUrl: '/bairoletto/fabrica/reposicion/reposicion-cancelar/reposicion-cancelar.html',
                controller: 'CancelarReposicionController',
                controllerAs: 'cancelar',
                resolve: {
                    reposicion: function () {
                        return r;
                    }
                }
            });

            modalInstance.result.then(function (orden_cancelada) {

                //Eliminar del panel
                if (panel == 'nuevas') {
                    _.remove(vm.panel_nuevas.raw_data, function (x) {
                        return x.id == orden_cancelada.id;
                    });
                    vm.panel_nuevas.total = vm.panel_nuevas.raw_data.length;
                    vm.panel_nuevas.data = armarArrayPuntosVenta(vm.panel_nuevas.raw_data);
                }
                if (panel == 'aprobadas') {
                    _.remove(vm.panel_aprobadas.raw_data, function (x) {
                        return x.id == orden_cancelada.id;
                    });
                    vm.panel_aprobadas.total = vm.panel_aprobadas.raw_data.length;
                    vm.panel_aprobadas.data = armarArrayPuntosVenta(vm.panel_aprobadas.raw_data);
                }
                if (panel == 'en_transito') {
                    _.remove(vm.panel_en_transito.raw_data, function (x) {
                        return x.id == orden_cancelada.id;
                    });
                    vm.panel_en_transito.total = vm.panel_en_transito.raw_data.length;
                    vm.panel_en_transito.data = armarArrayPuntosVenta(vm.panel_en_transito.raw_data);
                }
                
                //Agregar al panel finalizadas canceladas
                vm.panel_finalizadas.canceladas_data.push(orden_cancelada);
                vm.panel_finalizadas.total += 1;
                vm.panel_finalizadas.canceladas_data = _.orderBy(vm.panel_finalizadas.canceladas_data, 'fecha_procesada', 'desc');
            });
        }
    }
})();
