(function () {
    'use strict';

    angular
        .module('app.puntoventa')
        .run(run);

    function run(editableOptions) {

        // xeditable config
        editableOptions.theme = 'bs3';
        
    }

})();