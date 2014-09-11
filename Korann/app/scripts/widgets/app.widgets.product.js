(function (app) {
    app.directive("product", function () {
        return {
            restrict: 'E',
            scope: {
                model: "="
            },
            templateUrl: 'Partials/widgets/app.widgets.product.html'
        };
    });
})(app);