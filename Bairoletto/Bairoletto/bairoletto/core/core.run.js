(function () {
    'use strict';

    angular
        .module('app.core')
        .run(run);

    function run(editableOptions) {

        // xeditable config
        editableOptions.theme = 'bs3';
        
    }

})();