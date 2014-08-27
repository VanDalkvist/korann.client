(function () {
    'use strict';

    angular.module("korann.api.internal")
        .provider('apiProxy', function () {

            this.$get = ['$http', 'utils', function ($http, utils) {
                
                // #region public functions

                return {
                    get: _get,
                    put: _put,
                    delete: _delete,
                    post: _post
                };

                // #region private functions

                function _get(url, args) {
                    return $http.get(utils.createApiUrl(url, args)).then(_successCallback);
                }

                function _post(url, args, data) {
                    return $http.post(utils.createApiUrl(url, args), data).then(_successCallback);
                }

                function _delete(url, args) {
                    return $http["delete"](utils.createApiUrl(url, args)).then(_successCallback);
                }

                function _put(url, args, data) {
                    return $http.put(utils.createApiUrl(url, args), data).then(_successCallback);
                }

                function _successCallback(response) {
                    return response.data;
                }
            }];
        });
})();