(function() {

	angular.module('SealApp').factory('sealService', ['$q', sealService]);

	function sealService($q) {
		var service = {};

		service.findGeolocation = findGeolocation;

		function findGeolocation() {
			var deferred = $q.defer();
			navigator.geolocation.getCurrentPosition(success, fail);

			function success(position) {
				deferred.resolve(position);
			}

			function fail(data) {
				deferred.reject("We could not find your location... Try again.");
			}

			return deferred.promise;
		}

		return service;
	}

})();