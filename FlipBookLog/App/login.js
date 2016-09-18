angular.module("flipApp")
    .controller("loginController", ['$scope', '$http', '$httpParamSerializer', 'authenticationService', function ($scope, $http, $httpParamSerializer, authenticationService) {
        $scope.password = "";
        $scope.email = "";

        $scope.submit = function () {
            authenticationService.authenticate($scope.email, $scope.password)
                .then(function success() {
                    alert("success");
                }, function error() {
                    alert("error");
                });
        };

    }]);