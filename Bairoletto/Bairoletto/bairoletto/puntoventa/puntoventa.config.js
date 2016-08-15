(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .config(config);

    function config(toastrConfig, $routeProvider) {

        // Toastr config
        angular.extend(toastrConfig, {
            closeButton: true,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: true,
            preventOpenDuplicates: true,
        });

        // Route config
        //$routeProvider
        //    .when('/reposiciones', {
        //        templateUrl: '/bairoletto/reposicion/reposicion.html',
        //        controller: 'ReposicionController',
        //        controllerAs: 'repos'
        //    })
    }

})();