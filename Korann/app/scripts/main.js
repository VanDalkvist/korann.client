(function () {
    'use strict';

    var app = angular.module("korann", ['ui.router', 'korann.api', 'korann.settings']);

    window.app = app;

    app.config(['$locationProvider', function ($locationProvider) {
        // configure html5 to get links working
        // If you don't do this, you URLs will be base.com/#/home rather than base.com/home
        //$locationProvider.html5Mode(true).hashPrefix('!'); // todo: investigate routing without '#'
    }]);

    app.config(['$stateProvider', '$urlRouterProvider', 'settingsProvider',
        function ($stateProvider, $urlRouterProvider, settingsProvider) {

            // #region initialization

            var options = { Construction: 'Construction', Production: 'Production' };

            settingsProvider.config(options.Construction, _configConstructionMode);
            settingsProvider.config(options.Production, _configDeployMode);

            settingsProvider.mode(options.Construction)($stateProvider, $urlRouterProvider);
        }]);

    app.config(['apiProvider',
        function (apiProvider) {

            // #region initialization

            apiProvider.config("Categories", "categories/");
            apiProvider.config("Products", "products/");
        }]);

    // #region private functions

    function _configConstructionMode($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider.state("main", {
            url: "/",
            templateUrl: "app/views/layouts/app.layouts.construction.html"
        });
    }

    function _configDeployMode($stateProvider, $urlRouterProvider) {
        var builder = {
            Layout: _viewBuilder('layouts'),
            Page: _viewBuilder('pages'),
            Widget: _viewBuilder('widgets'),
            Panel: _viewBuilder('panels'),
            View: _viewBuilder('views')
        };

        // for any unmatched url, redirect to /home
        $urlRouterProvider.otherwise("/home");

        $stateProvider.state("main", {
            url: "^",
            abstract: true,
            templateUrl: "app/views/layouts/app.layouts.main.html"
        });

        $stateProvider.state("home", {
            url: "/home",
            parent: "main",
            views: {
                "current@main": builder.Page("dashboard")
            }
        });

        $stateProvider.state("kora", {
            url: "/kora",
            parent: "main",
            views: {
                "current@main": builder.Page("kora"),
                "left@main": builder.Panel("categories")
            }
        });

        $stateProvider.state("category", {
            url: "/category/{category}",
            parent: "kora",
            views: {
                "current@main": builder.Page("kora"),
                "left@main": builder.Panel("categories")
            }
        });

        $stateProvider.state("product", {
            url: "/product/{id}",
            parent: "kora",
            views: {
                "current@main": builder.View("product", "View")
            }
        });
    }

    function _viewBuilder(type) {
        return function (viewName, suffix) {
            return {
                controller: viewName + (suffix || '') + "Ctrl",
                templateUrl: "app/views/" + type + "/app." + type + "." + viewName + ".html"
            };
        };
    }
})();