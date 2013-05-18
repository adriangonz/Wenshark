//Controller for the artist page
function AlbumCtrl($scope, $routeParams, $http, $location) {
	$scope.loading = true;

	$http
	.get('/api/album?id=' + $routeParams.id)
	.success(function (data) {
		$scope.album = data;

		$(document).foundation('section', function () {
			$scope.loading = false;
		});
	})
	.error(function(error) {
		console.log(error);
		$location.path('error');
	});
}
