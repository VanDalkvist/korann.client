(function (app) {
    'use strict';

    // 
    app.controller("koraCtrl",
        ['$scope', 'api', '$state',
        function ($scope, api, $state) {

            // #region model

            $scope.model = {};

            // #region initialization

            var promise;
            if (!$state.params.category)
                promise = api.Products.getAll();
            else {
                promise = api.Products.getByCategory($state.params.category);
            }

            promise.then(function (result) {
                $scope.model.products = result;
            });

            // #region public functions

            // #region private functions
        }]);
})(app);