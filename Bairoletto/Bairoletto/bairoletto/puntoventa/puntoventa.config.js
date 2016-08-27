(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .config(config);

    function config($routeProvider) {
       
        $routeProvider
            .when('/reposiciones', {
                templateUrl: '/bairoletto/puntoventa/reposicion/reposicion.html',
                controller: 'ReposicionController',
                controllerAs: 'repos'
            })
    }

})();