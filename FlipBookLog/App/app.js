var app = angular.module("flipApp", ["ngRoute"]);

app.controller("flipController", ['$scope', '$http', '$httpParamSerializer', 'authenticationService', function ($scope, $http, $httpParamSerializer, authenticationService) {
    $scope.title = "Flip - Reading Log";
}]);

app.config(function ($httpProvider, $locationProvider) {
    $httpProvider.interceptors.push('authenticationInterceptorService');
    $locationProvider.html5Mode({ enabled: true, requireBase: false });
});

var serviceBase = 'http://localhost:53477';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});