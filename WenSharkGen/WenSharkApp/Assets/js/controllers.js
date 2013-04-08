/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl ($scope) {
	
}

//Controller for the search
function SearchCtrl ($scope, $routeParams) {
	$scope.query = $routeParams.query;

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