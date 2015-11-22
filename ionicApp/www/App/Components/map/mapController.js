(function() {

	angular.module('SealApp').controller('MapController', ['sealService', '$scope', '$ionicLoading', MapController]);

	function MapController(sealService, $scope, $ionicLoading) {
		// Variables
		var vm = this;
		$scope.center = {};
		$scope.paths = {};
		$ionicLoading.show({
			template: 'Finding location...<br /> <ion-spinner icon="ripple" style="stroke: white;"></ion-spinner>'
		});

		// Functions
		$scope.findLocation = findLocation;


		function findLocation() {

			sealService.findGeolocation().then(geolocationSuccess, geolocationFail);

			function geolocationSuccess(data) {
				$ionicLoading.hide();

				$scope.center = {
					lat: data.coords.latitude,
					lng: data.coords.longitude,
					zoom: 10
				};

				$scope.markers = {
					marker: {
						draggable: false,
						message: "Hello Chris!",
						lat:  data.coords.latitude,
						lng:  data.coords.longitude,
						focus: true,
						icon: {}
					}
				};
				$scope.paths = {
					circle: {
						type: 'circle',
						radius: 16093.44,
						miles: 10,
						color: '#00B8D4',
						weight: 4,
						latlngs: $scope.markers.marker,
						clickable: false,
					}
				};
			}

			function geolocationFail(data) {
				console.log(data);
			}
		}

		$scope.findLocation();
	}

})();