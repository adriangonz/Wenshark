//Controller for the search
function PlayListCtrl($scope, $routeParams, $http) {
    $scope.query = $routeParams.query;
    $scope.loading = true;
    $http
		.get('/api/playlist?id=' + $scope.query)
		.success(function (data) {
		    $scope.songs = data.songs;
		    $scope.listName = data.name;
		    $scope.loading = false;
		    /*$scope.songs = data.songs;
		    $scope.albums = data.albums;
		    $scope.artists = data.artists;

		    $(document).foundation('section', function () {
		        $scope.loading = false;
		    });*/
		})
		.error(function (data) {
		    console.log("Error");
		    /*$scope.songs = [];
		    $scope.albums = [];
		    $scope.artists = [];

		    $(document).foundation('section', function () {
		        $scope.loading = false;
		    });*/
		});
}