/* Routes for angularjs */

angular.module('wenshark', [])
	.config(function ($routeProvider) {
		$routeProvider
			.when('/search/:query', {controller: SearchCtrl, templateUrl: '/Assets/partials/search.html'})
			.when('/', {controller:MainCtrl, templateUrl: '/Assets/partials/main.html'});
	});