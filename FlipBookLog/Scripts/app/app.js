/// <reference path="../angular.js"/>

angular.module("flipApp", ["ngRoute"])
    .controller("flipController", ['$scope', '$http', '$httpParamSerializer', function ($scope, $http, $httpParamSerializer) {
        $scope.title = "Flip - Reading Log";
        $scope.filter;


        var tokenRequest = {
            'grant_type': 'password',
            'username': 'Taiseer',
            'password': 'SuperPass2342342342342'
        };

        var bearerToken = "";

        $http.post("/token", $httpParamSerializer(tokenRequest), {
                headers: { "content-type": "application/x-www-form-urlencoded" }
            }
        ).success(function(data) {
            bearerToken = data.access_token;

            $http.get("/api/Orders", {
                headers: {
                    "content-type": "application/json",
                    "authorization": "bearer " + bearerToken
                }
            }).success(function (data) {
                $scope.orders = data;
            }).error(function (data) {
                alert("Error getting orders: " + data);
            });


        }).error(function(data) {
            alert("error");
        });
    }]);