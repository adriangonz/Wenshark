//Controller for the artist page
function ArtistCtrl($scope, $routeParams, $http, $location) {
	$scope.loading = true;

	$http
	.get('/api/artist?id=' + $routeParams.id)
	.success(function (data) {
		$scope.artist = data;

		$(document).foundation('section', function () {
			$scope.loading = false;
		});
	})
	.error(function() {
		$location.path('error');
	});
}
