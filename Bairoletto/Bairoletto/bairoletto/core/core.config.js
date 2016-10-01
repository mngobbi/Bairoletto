(function () {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    function config($animateProvider, toastrConfig, $httpProvider, lockProvider, jwtOptionsProvider, jwtInterceptorProvide) {

        //Animate config
        $animateProvider.classNameFilter(/animate-|ui-select-/);

        // Toastr config
        angular.extend(toastrConfig, {
            closeButton: true,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            preventOpenDuplicates: true,
        });


        // Auth0 config
        lockProvider.init({
            clientID: 'i8qGVLFoLgZl4vwdts6LZOKCsuGIC7DS',
            domain: 'cjtodorovic.auth0.com'
        });

        jwtOptionsProvider.config({
            tokenGetter: function () {
                return localStorage.getItem('id_token');
            }
        });

        $httpProvider.interceptors.push('jwtInterceptor');

    }

})();