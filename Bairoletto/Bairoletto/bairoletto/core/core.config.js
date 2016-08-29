(function () {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    function config($animateProvider, toastrConfig) {

        $animateProvider.classNameFilter(/animate-|ui-select-/);

        // Toastr config
        angular.extend(toastrConfig, {
            closeButton: true,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            preventOpenDuplicates: true,
        });

    }

})();