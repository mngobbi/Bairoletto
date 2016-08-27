(function () {
    'use strict';

    angular
        .module('app.fabrica')
        .config(config);

    function config($routeProvider) {

        $routeProvider
            .when('/reposiciones', {
                templateUrl: '/bairoletto/fabrica/reposicion/reposicion.html',
                controller: 'ReposicionController',
                controllerAs: 'repos'
            })
    }

})();