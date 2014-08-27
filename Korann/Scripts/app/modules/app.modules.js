(function () {
    'use strict';

    angular.module('korann.api.internal', []);

    angular.module('korann.api', ['korann.api.internal']);
    
    angular.module('korann.settings', []);
})();