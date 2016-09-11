/// <reference path="../angular.js"/>

var app = angular.module("flipApp", ["ngRoute"]);

app.controller("flipController", ['$scope', '$http', '$httpParamSerializer', 'authenticationService', function ($scope, $http, $httpParamSerializer, authenticationService) {
    $scope.title = "Flip - Reading Log";
    $scope.filter;

    // TODO Authenticate correctly
    authenticationService.authenticate("anyUsernameWillDo", "SoTooThePassword")
        .then(function () {
            $http.get("/api/Orders", {
                headers: {
                    "content-type": "application/json"
                }
            }).success(function (data) {
                $scope.orders = data;
            }).error(function (data) {
                alert("Error getting orders: " + data);
            });
        });

}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authenticationInterceptorService');
});

var serviceBase = 'http://localhost:53477';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});