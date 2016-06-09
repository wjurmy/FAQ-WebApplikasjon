

var TestAngularJSApp = angular.module("FaqAngularJSApp",['ui.bootstrap','ngRoute']);

TestAngularJSApp.controller('LandingPageController', LandingPageController);
TestAngularJSApp.controller('FaqController', FaqController);

var configSection = function($routeProvider) {
    $routeProvider.
        when('/faq', {
            templateUrl: 'Views/faq.cshtml',
            controller: FaqController
        })
        .when('/addNew', {
            templateUrl: 'Views/addNewQuestion.cshtml',
            controller: FaqController
        })
        .when('/subqs', {
            templateUrl: 'Views/subQuestions.cshtml',
            controller: FaqController
        })
        .when('/info', {
            templateUrl: 'Views/info.cshtml',
            controller: FaqController
        });
};

configSection.$inject = ['$routeProvider'];

TestAngularJSApp.config(configSection);