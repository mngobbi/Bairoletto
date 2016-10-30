(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('camionService', camionService);

    function camionService($http) {
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
            var errorMessage = 'Se ha producido un error'
            if (typeof e.data !== 'undefined')
                errorMessage = e.data.Message;
            console.log(newMessage);
            return $q.reject(e);
        }
    }
})();