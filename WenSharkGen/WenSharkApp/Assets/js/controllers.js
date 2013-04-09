/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl ($scope) {
	$scope.search = function (query) {
		window.location.href = "/#/search/" + query;	
	}
}

//Controller for the search
function SearchCtrl ($scope, $routeParams, $http) {
	$scope.query = $routeParams.query;
	$scope.loading = true;
	$http
		.get('/api/search?name=' + $scope.query)
		.success(function (data) {
			$scope.songs = data.songs;
			$scope.albums = data.albums;
			$scope.artists = data.artists;

			$(document).foundation('section', function () {
				$scope.loading = false;
			});
		});
	
	$scope.dummyArr = [];
	for(var i = 0; i < 10; i++) {
		var dummy = {
			name: 'Test song - ' + i,
			fname: 'song_file.mp3',
			id: '900' + i,
			album: {
				id: '0',
				name: 'Album wapo'
			},
			artist: {
				id: '0',
				name: 'Artista wapo'
			}
		};
		$scope.dummyArr.push(dummy);
	}
	
}