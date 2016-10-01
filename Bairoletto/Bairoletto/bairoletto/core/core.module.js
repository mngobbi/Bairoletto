(function () {
    'use strict';

    angular.module('app.core', [
        // Angular modules
        'ngRoute',
        'ngAnimate',
        'ngMessages',
        'ngSanitize',

        // 3rd Party Modules
        'auth0.lock', 
        'angular-jwt',
        'angularMoment',
        'cgBusy',
        'ui.bootstrap',
        'ui.select',
        'toastr',
        'xeditable'
    ]);
})();