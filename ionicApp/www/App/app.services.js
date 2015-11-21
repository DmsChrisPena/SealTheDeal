(function() {

	angular.module('SealApp')
		.factory('authService', ['$window', '$q', authService])
		.factory('sealService', ['$window', '$q', '$http', sealService]);

	function authService($window, $q) {
        var service = {};

        service.request = request;

        function request(config) {
            config.headers = config.headers || {};
            if ($window.sessionStorage.getItem('token')) {
                config.headers.Authorization = 'Bearer ' + $window.sessionStorage.getItem('token');
            }

            return config || $q.when(config);
        }

        return service;
    }

	function sealService($window, $q, $http) {
		var service = {};

		service.login = login;
        service.isLoggedIn = isLoggedIn;
        service.isManager = isManager;
        service.isClerk = isClerk;
        service.isCustomer = isCustomer;
        service.logout = logout;
        service.register = register;

        function login(username, password) {
            var deferred = $q.defer();

            $http({
                url: '/Token',
                method: 'POST',
                data: 'username=' + username + '&password=' + password + '&grant_type=password',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                $window.sessionStorage.setItem('token', data.access_token);
                if (data.isManager == "true") $window.sessionStorage.setItem('isManager', data.isManager);
                if (data.isClerk == "true") $window.sessionStorage.setItem('isClerk', data.isClerk);
                if (data.isCustomer == "true") $window.sessionStorage.setItem('isCustomer', data.isCustomer);
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }
        function isLoggedIn() {
            return $window.sessionStorage.getItem('token');
        }
        function isManager() {
            return $window.sessionStorage.getItem('isManager');
        }
        function isClerk() {
            return $window.sessionStorage.getItem('isClerk');
        }
        function isCustomer() {
            return $window.sessionStorage.getItem('isCustomer');
        }
        function logout() {
            $window.sessionStorage.removeItem('token');
            $window.sessionStorage.removeItem('isManager');
            $window.sessionStorage.removeItem('isClerk');
            $window.sessionStorage.removeItem('isCustomer');
        }
        function register(email, password, confirmPassword) {
            var deferred = $q.defer();

            $http({
                url: '/api/Account/Register',
                method: 'POST',
                data: { 'email': email, 'password': password, 'confirmPassword': confirmPassword }
            }).success(function (data) {
                deferred.resolve();
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }

		return service;
	}

})();