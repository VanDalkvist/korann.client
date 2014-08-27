(function (app) {
    app.directive("category", function () {
        return {
            restrict: 'E',
            scope: {
                model: "=model"
            },
            templateUrl: 'Partials/widgets/app.widgets.category.html'
        };
    });
})(app);