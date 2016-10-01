(function () {
    'use strict';

    angular
        .module('app.core')
        .run(run);

    function run($rootScope, amMoment, editableOptions, authService, authManager) {

        // angular-moment config
        amMoment.changeLocale('es');

        // xeditable config
        editableOptions.theme = 'bs3';

        // Auth0 config
        // Put the authService on $rootScope so its methods can be accessed from the nav bar
        $rootScope.authService = authService;

        authService.registerAuthenticationListener();

        // Use the authManager from angular-jwt to check for the user's authentication state when the page is refreshed and maintain authentication
        authManager.checkAuthOnRefresh();

        // Listen for 401 unauthorized requests and redirect the user to the login page
        authManager.redirectWhenUnauthenticated();
       
    }

})();