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
            .when('/login', {
                controller: 'LoginController',
                controllerAs: 'log',
                templateUrl: '/bairoletto/login/login.html'
            });
    }

})();