(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('LoginController', LoginController);

    function LoginController(authService) {
        var vm = this;

        var options = {
            container: 'hiw-login-container',
            language: 'es'
        };

        // Put the authService on $scope to access
        // the login method in the view
        authService.login(options);
    }
})();
