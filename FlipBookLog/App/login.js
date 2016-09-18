﻿angular.module("flipApp")
    .controller("loginController", ["$scope", "$window", "$location", "authenticationService", function ($scope, $window, $location, authenticationService) {
        $scope.password = "";
        $scope.email = "";
        $scope.redirect = $location.search().redirect;

        $scope.submit = function () {
            authenticationService.authenticate($scope.email, $scope.password)
                .then(function success() {
                    // TODO redirect to url param if present
                    if ($location.search().redirect != undefined) {
                        $window.location.href = $location.search().redirect;
                    } else {
                        $window.location.href = "/Home";
                    }
                }, function error() {
                    alert("error");
                });
        };

    }]);