(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('productoService', productoService);

    function productoService($http) {
        var service = {
            get: getProductos,
            getById: getProducto
        };

        return service;

        function getProductos(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/productos?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/productos').then(dataSuccess).catch(dataError);
        }
        function getProducto(prod_id) {
            return $http.get('/api/productos/' + prod_id).then(dataSuccess).catch(dataError);
        }

        function dataSuccess(result) {
            return result.data;
        }
        function dataError(e) {
            var errorMessage = 'Se ha producido un error'
            if (typeof e.data !== 'undefined')
                errorMessage = e.data.Message;
            console.log(newMessage);
            return $q.reject(e);
        }
    }
})();