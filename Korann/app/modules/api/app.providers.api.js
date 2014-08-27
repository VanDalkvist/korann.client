(function () {
    'use strict';

    angular.module("korann.api")
        .provider('api', function () {

            var services = {};

            this.config = function (serviceName, apiPath) {
                services[serviceName] = apiPath;
            };

            this.$get = ['apiProxy', function (apiProxy) {

                // #region initialization

                var operations = {
                    get: function (path) {
                        return function (id) {
                            var args = [{ name: 'id', value: id }];
                            return apiProxy.get(path, args);
                        };
                    },
                    getAll: function (path) {
                        return function () {
                            return apiProxy.get(path);
                        };
                    },
                    getByCategory: function (path) {
                        return function (category) {
                            var args = [{ name: 'category', value: category }];
                            return apiProxy.get(path, args);
                        };
                    }
                };

                var builder = {};

                for (var name in services) {
                    builder[name] = {};
                    for (var key in operations) {
                        builder[name][key] = operations[key](services[name]);
                    }
                }

                // #region public functions

                return builder;

                // #region private functions
            }];
        });
})();