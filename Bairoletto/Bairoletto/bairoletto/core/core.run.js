(function () {
    'use strict';

    angular
        .module('app.core')
        .run(run);

    function run(amMoment, editableOptions) {

        // angular-moment config
        amMoment.changeLocale('es');

        // xeditable config
        editableOptions.theme = 'bs3';
        
    }

})();