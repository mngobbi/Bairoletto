(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('camionService', camionService);

    function camionService($http, $q, toastr) {
        var service = {
            get: getCamiones,
        };

        return service;

        function getCamiones(cam_id) {
            if (typeof cam_id !== 'undefined')
                return $http.get('/api/camiones/' + cam_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/camiones').then(dataSuccess).catch(dataError);
        }

        function dataSuccess(result) {
            return result.data;
        }
        function dataError(e) {
            var errorMessage = 'Se ha producido un error';
            toastr.error(errorMessage);
            return $q.reject(e);
        }
    }
})();