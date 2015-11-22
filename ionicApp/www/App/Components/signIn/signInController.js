(function() {

	angular.module('SealApp').controller('SignInController', ['sealService', '$location', SignInController]);

	function SignInController(sealService, $location) {
	    var vm = this;
	    
	    vm.login = login;
	    vm.isLoggedIn = isLoggedIn;
	    vm.isManager = isManager;
	    vm.isClerk = isClerk;
	    vm.isCustomer = isCustomer;
	    vm.logout = logout;

	    function login() {
	        vm.isLoading = true;
	        sealService.login(vm.username, vm.password).then(successLogin, failLogin);
	    }
	    function isLoggedIn() {
	        return loginService.isLoggedIn();
	    }
	    function isManager() {
	        return loginService.isManager();
	    }
	    function isClerk() {
	        return loginService.isClerk();
	    }
	    function isCustomer() {
	        return loginService.isCustomer();
	    }
	    function logout() {
	        loginService.logout();
	        $location.path('/');
	    }

	    function successLogin(data) {
	        $location.path('/');
	    }
	    function failLogin(data) {
	        
	    }
	}

})();