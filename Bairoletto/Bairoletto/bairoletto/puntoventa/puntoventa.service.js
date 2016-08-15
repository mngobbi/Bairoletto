(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .factory('puntoventaService', puntoventaService);

    function puntoventaService($http, $q) {
        var service = {
            reposiciones: {
                get: getReposiciones,
                crear: crearReposicion
            },
            productos: {
                get: getProductos
            }
        };

        return service;

        function getReposiciones() {
            var id_sucursal = 1;
            return $http.get('/api/puntosventa/' + id_sucursal + '/reposciones')
                .then(dataSuccess)
                .catch(dataError);;
        }

        function crearReposicion(fecha_deseada, productos, comentario) {
            var obj = {
                planta_elaboracion_id: 1,
                punto_venta_id: 1,
                fecha_entrega_deseada: fecha_deseada,
                comentario: comentario,
                productos: productos
            }

            return $http.post('/api/reposiciones', obj)
                .then(dataSuccess)
                .catch(dataError);
        }

        function getProductos() {
            var id_sucursal = 1;
            return $http.get('/api/puntosventa/' + id_sucursal + '/productos')
                .then(dataSuccess)
                .catch(dataError);;
        }

        function dataSuccess(result) {
            return result.data;
        }

        function dataError(e) {
            var newMessage = 'Se ha producido un error'
            if (e.data && e.data.description) {
                newMessage = newMessage + '\n' + e.data.description;
            }
            e.data.description = newMessage;
            logger.error(newMessage);
            return $q.reject(e);
        }
        
    }
})();