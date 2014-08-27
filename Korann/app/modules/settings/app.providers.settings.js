(function () {
    'use strict';

    angular.module('korann.settings')
        .provider('settings', function () {

            var appMode;

            var configBuilder = {};

            this.config = function (mode, callback) {
                configBuilder[mode] = callback;
            };

            this.mode = function (mode) {
                return configBuilder[mode];
            };

            this.$get = function () {

                // #region initialization

                // #region public functions

                return {
                    mode: appMode
                };

                // #region private functions
            };
        });
})();