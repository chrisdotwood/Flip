angular.module("flipApp")
    .controller("reviewController", ["$scope", "$http", function ($scope, $http) {
        $scope.title = "Review";
        $scope.filter;

        $http.get("/api/Orders", {
            headers: {
                "content-type": "application/json"
            }
        }).then(function success(response) {
            $scope.orders = response.data;
        }, function error(response) {
            if (!response.dontReport) {
                alert("Error getting orders: " + response.data.message);
            }
        });

    }]);