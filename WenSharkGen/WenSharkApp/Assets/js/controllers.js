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
	$scope.addFileToUpload = function () {
		$('.hidden-file-input').click();
	}

	//Add some handlers for adding files to view
	$('.hidden-file-input').change(function (e) {
		var filesToAdd = $('.hidden-file-input')[0].files;
		var size = $scope.songsToUpload.length;

		for (var i = 0; i < filesToAdd.length; i++) {
			$scope.songsToUpload.push( {
				id: size + i,
				name: filesToAdd[i].name,
				file: filesToAdd[i],
				album : {
					name: ''
				},
				artist : {
					name: ''
				}
			});
		};
		$scope.$apply();
		console.log($scope.songsToUpload);
	});
}