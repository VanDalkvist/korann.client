(function (app) {
    'use strict';

    // 
    app.controller("categoriesCtrl",
        ['$scope', 'api', '$state',
        function ($scope, api, $state) {

            // #region model

            $scope.model = {};

            // #region initialization

            _refresh();
            var currentCategory = $state.params.category || '';

            // #region public functions

            $scope.refresh = _refresh;
            $scope.isCurrent = _isCurrent;

            // #region private functions

            function _refresh() {
                api.Categories.getAll().then(function (result) {
                    $scope.model.categories = result;
                });
            }
            
            function _isCurrent(category) {
                return category === currentCategory;
            }
        }]);
})(app);