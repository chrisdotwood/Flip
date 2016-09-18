'use strict';

angular.module("flipApp").factory('authenticationInterceptorService', ['$q', '$injector', '$window', "$location", function ($q, $injector, $window, $location) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authService = $injector.get('authenticationService');

        if (authService.isAuthenticated()) {
            config.headers.Authorization = 'Bearer ' + authService.getToken();
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('authenticationService');
            //var authData = localStorageService.get('authorizationData');

            //if (authData) {
            //    if (authData.useRefreshTokens) {
            //        $location.path('/refresh');
            //        return $q.reject(rejection);
            //    }
            //}
            authService.logOut();

            rejection.dontReport = true;

            $window.location.href = "/Login?redirect=" + $location.url();
        }
        
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);