(function() {
  angular.module('SealApp').config(['$stateProvider', '$urlRouterProvider', ionicConfig]);

  function ionicConfig($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
      .state('signIn', {
        url: '/',
        templateUrl: 'App/Components/signIn/signInView.html',
        controller: 'SignInController as vm'
      })
      .state('signUp', {
        url: '/signUp',
        templateUrl: 'App/Components/signUp/signUpView.html',
        controller: 'SignUpController as vm'
      })
      .state('map', {
        url: '/map',
        templateUrl: 'App/Components/map/mapView.html',
        controller: 'MapController as vm'
      })
      .state('deals', {
        url: '/deals',
        templateUrl: 'App/Components/deals/dealsView.html',
        controller: 'DealsController as vm'
      })
      .state('history', {
        url: '/history',
        templateUrl: 'App/Components/history/historyView.html'
      })
      .state('settings', {
        url: '/settings',
        templateUrl: 'App/Components/settings/settingsView.html'
      })
  }
})();