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
  }
})();