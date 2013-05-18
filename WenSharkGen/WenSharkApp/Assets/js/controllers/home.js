/* Controller for '/' home page */

function HomeCtrl($scope, $http) {
	//Load the content
	$scope.loading = true;
	$scope.popularSongs = null;
	$http
	.get('/api/song?popular')
	.success(function (data) {
		$scope.popularSongs = data;
		$loading = false;
	})
	.error(function() {
		$loading = false;
	});
}