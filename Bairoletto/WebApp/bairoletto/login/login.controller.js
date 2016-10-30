(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('LoginController', LoginController);

    function LoginController(authService) {
        var vm = this;

        // Put the authService on $scope to access
        // the login method in the view
        vm.authService = authService;
    }
})();
