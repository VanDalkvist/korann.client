(function (app) {
    'use strict';

    // 
    app.controller("headerCtrl",
        ['$scope', 'api', '$state',
        function ($scope, api, $state) {

            // #region model

            // #region initialization

            var currentState = $state.current.name;

            // #region public functions

            $scope.isCurrent = _isCurrent;
            $scope.onClick = _onClick;

            // #region private functions

            function _isCurrent(state) {
                return state === currentState || state === $state.current.parent;
            }

            function _onClick(state) {
                currentState = state;
            }
        }]);
})(app);