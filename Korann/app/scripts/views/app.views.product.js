(function (app) {
    'use strict';

    app.controller("productViewCtrl",
        ['$scope', 'api', '$state',
        function ($scope, api, $state) {

            // #region model
            
            // #region initialization

            api.Products.get($state.params.id).then(function (result) {
                $scope.model = result;
            });

            // #region public functions

            // #region private functions
        }]);
})(app);