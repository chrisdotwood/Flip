describe('Login Controller', function () {
    beforeEach(module('flipApp'));

    var $controller;
    var $scope;
    var $q;
    var deferred;
    var $window;
    var $location;
    var _authenticationService;

    beforeEach(inject(function (_$controller_, _$rootScope_, _$q_, _$location_, authenticationService) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
        $q = _$q_;
        $location = _$location_;

        deferred = $q.defer();

        $window = {
            location: {
                href: ""
            }
        };

        $scope = _$rootScope_.$new();

        // Setup the fields on the form
        $scope.email = "test.user@domain.com";
        $scope.password = "Password@123";

        _authenticationService = authenticationService;
        spyOn(_authenticationService, "authenticate").and.returnValue(deferred.promise);

        $controller('loginController', { $scope: $scope, $window: $window, $location: $location, authenticationService: _authenticationService });

    }));

    it("submit should call redirect to /Home if there is no other parameter specified", function () {
        $location.path = "";

        // Setup the data that the controller will return
        deferred.resolve({});

        // Submit the form
        $scope.submit();

        $scope.$apply();

        expect($window.location.href).toBe("/Home");
    });

    it("submit should call redirect to location supplied if there is a redirect parameter", function () {
        spyOn($location, "search").and.returnValue({ redirect: "/Success" });

        // Setup the data that the controller will return
        deferred.resolve({});

        // Submit the form
        $scope.submit();

        $scope.$apply();

        expect($window.location.href).toBe("/Success");
    });

});
