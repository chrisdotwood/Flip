/// <reference path="../../angular.js"/>

angular.module("flipApp")
    .factory("authenticationService", ['$http', '$httpParamSerializer', '$q', function ($http, $httpParamSerializer, $q) {
        return {
            isAuthenticated: function () {
                if (localStorage["isAuthenticated"] == undefined) {
                    return false;
                } else return localStorage["isAuthenticated"];
            },

            getToken: function () {
                return localStorage["token"];
            },

            authenticate: function (username, password) {
                var defer = $q.defer();

                var tokenRequest = {
                    'grant_type': 'password',
                    'username': username,
                    'password': password
                };

                $http.post("/token", $httpParamSerializer(tokenRequest), {
                    headers: { "content-type": "application/x-www-form-urlencoded" }
                }).then(function success(response) {
                    localStorage["token"] = response.data.access_token;

                    localStorage["isAuthenticated"] = true;

                    defer.resolve();
                }, function error(message) {
                    defer.reject("Authentication failure: " + message);
                });

                return defer.promise;
            },

            logOut: function () {
                localStorage["isAuthenticated"] = false;
                localStorage["token"] = "";
            }
        }
    }]);