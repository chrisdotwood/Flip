/// <reference path="../../angular.js"/>

angular.module("flipApp")
    .service("authenticationService", ['$http', '$httpParamSerializer', '$q', function ($http, $httpParamSerializer, $q) {
        var _isAuthenticated = false;
        var _token = "";

        return {
            isAuthenticated: function () {
                return _isAuthenticated;
            },

            getToken: function() {
                return _token;
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
                    _token = response.data.access_token;

                    _isAuthenticated = true;

                    defer.resolve();
                }, function error(message) {
                    defer.reject("Authentication failure: " + message);
                });

                return defer.promise;
            },

            logOut: function () {
                _isAuthenticated = false;
                _token = "";
            }
        }
    }]);