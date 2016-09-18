var app = angular.module("flipApp", ["ngRoute"]);

app.controller("flipController", ['$scope', '$http', '$httpParamSerializer', 'authenticationService', function ($scope, $http, $httpParamSerializer, authenticationService) {
    $scope.title = "Flip - Reading Log";
    $scope.filter;

    // TODO Authenticate correctly
    authenticationService.authenticate("test1@user.com", "Password@123")
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

app.config(function ($httpProvider, $locationProvider) {
    $httpProvider.interceptors.push('authenticationInterceptorService');
    $locationProvider.html5Mode({ enabled: true, requireBase: false });
});

var serviceBase = 'http://localhost:53477';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});