(function() {
    angular.module('SealApp').config(['$httpProvider', '$locationProvider', '$urlRouterProvider', '$stateProvider', ionicConfig]);

    function ionicConfig($httpProvider, $locationProvider, $urlRouterProvider, $stateProvider) {
    $httpProvider.interceptors.push('authService');
    $locationProvider.html5Mode(true);

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
  }
})();