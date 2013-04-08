/* Routes for angularjs */

angular.module('wenshark', [])
	.config(function ($routeProvider) {
		$routeProvider
			.when('/search/:query', {controller: SearchCtrl, templateUrl: '/Assets/partials/search.html'});
	});