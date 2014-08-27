(function () {
    'use strict';

    angular.module("korann.api.internal")
        .factory('utils', function () {

            // #region initialization

            var root = "/api/";

            // #region public functions

            return {
                createApiUrl: _createApiUrl
            };

            // #region private functions

            function _createApiUrl(url, args) {
                args = args || [];
                var result = root + url + (args.length > 0 ? '?' : '');
                angular.forEach(args, function (arg) {
                    result += arg.name + '=' + arg.value + '&';
                });
                return result;
            }
        });
})();