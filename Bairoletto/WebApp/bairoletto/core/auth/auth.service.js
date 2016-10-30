(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('authService', authService);

    function authService($rootScope, lock, authManager, $window) {
        var service = {
            userProfile: userProfile,
            login: login,
            logout: logout,
            registerAuthenticationListener: registerAuthenticationListener
        };

        return service;

        var userProfile = JSON.parse(localStorage.getItem('profile')) || {};

        function login() {
            lock.show();
        }

        // Logging out just requires removing the user's
        // id_token and profile
        function logout() {
            localStorage.removeItem('id_token');
            localStorage.removeItem('profile');
            authManager.unauthenticate();
            userProfile = {};
        }

        // Set up the logic for when a user authenticates
        // This method is called from app.run.js
        function registerAuthenticationListener() {
            lock.on('authenticated', function (authResult) {
                localStorage.setItem('id_token', authResult.idToken);
                authManager.authenticate();

                lock.getProfile(authResult.idToken, function (error, profile) {
                    if (error) {
                        console.log(error);
                    }
                    if (typeof profile.app_metadata.planta_elaboracion_id !== 'undefined')
                        $window.location.href = "/bairoletto/fabrica/fabrica.html#";

                    if (typeof profile.app_metadata.punto_venta_id !== 'undefined')
                        $window.location.href = "/bairoletto/puntoventa/puntoventa.html#";

                    localStorage.setItem('profile', JSON.stringify(profile));
                    $rootScope.$broadcast('userProfileSet', profile);
                });
            });
        }

    }
})();