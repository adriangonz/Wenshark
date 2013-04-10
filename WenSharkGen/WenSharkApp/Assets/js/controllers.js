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
}

function SignUpCtrl($scope, $routeParams, $http) {
    $scope.user = {
        name : '',
        username : '',
        passw : '',
        confPass: '',
        email : ''
    }
    $scope.signup = function () {
        $http
		.post('/api/signup', JSON.stringify($scope.user))
		.success(function (data) {
		    if (data) {

		    } else {

		    }
		});
    }
}


//Controller for the upload
function UploadCtrl ($scope) {
	$scope.songsToUpload = [];
	$scope.selected = null;
	$scope.select = function (song) {
		if($scope.selected != null)
			$('#upl-song-' + $scope.selected.id).removeClass('active');

		$scope.selected = song;
		$('#upl-song-' + song.id).addClass('active');
	};
	for(var i = 0; i < 5; i++) {
		var dummy = {
			id : i,
			name : 'ola ke ase ' + i,
			file : 'olakease_' + i + '.mp3',
			album : {
				name: ''
			},
			artist : {
				name: ''
			}
		}

		$scope.songsToUpload.push(dummy);
	}
}