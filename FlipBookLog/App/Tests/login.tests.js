describe('PasswordController', function () {
    beforeEach(module('flipApp'));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));

    describe("Double function", function () {
        it("doubles a parameter", function () {

            var $scope = {};
            var controller = $controller('loginController', { $scope: $scope, $window: {}, $location: {}, authenticationService: {} });

            expect($scope.double(2)).toEqual(4);
            expect($scope.double(-4)).toEqual(-8);
            expect($scope.double(0)).toEqual(0);
        });
    });

    describe('$scope.grade', function () {
        it('sets the strength to "strong" if the password length is >8 chars', function () {
            var $scope = {};
            var controller = $controller('loginController', { $scope: $scope });
            $scope.password = 'longerthaneightchars';
            $scope.grade();
            expect($scope.strength).toEqual('strong');
        });
    });
});
