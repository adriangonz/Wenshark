/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl ($scope) {
	$scope.search = function (query) {
	    window.location.href = "/#/search/" + query;	
	}

	$scope.playlist = [];

	$scope.play = function (song) {
		$scope.playlist.push(song);
		console.log('Anyado a la playlist: ');
		console.log(song);
	}
}

//Controller for the search
function SearchCtrl ($scope, $routeParams, $http) {
	$scope.query = $routeParams.query;
	$scope.loading = true;
	$http
		.get('/api/search?name=' + $scope.query)
		.success(function (data) {
			console.log(data);
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
		        console.log(data);
		    } else {
		        console.log("No hay nada");
		    }
		});
    }
}

function SignInCtrl($scope, $routeParams, $http) {
    $scope.user = {
        username: '',
        passw: ''
    }
    $scope.signin = function () {
        console.log($scope.user);
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
	$scope.uploading = false;
	$scope.uploadOK = false;
	$scope.upload = function () {
		$scope.uploading = true;
		//We upload the songs with the data
		var formdata = new FormData();
		for(var i = 0; i < $scope.songsToUpload.length; i++) {
			formdata.append("file-" + i, $scope.songsToUpload[i].file);
			formdata.append("name-" + i, $scope.songsToUpload[i].name);
			formdata.append("album-" + i, 2);
			formdata.append("artist-" + i, 1);
		}

		$.ajax({
			url: '/api/song',
			type: 'POST',
			data: formdata,
			processData: false,
			contentType: false,
			success: function (res) {
				$scope.uploading = false;
				$scope.songsToUpload = [];
				$scope.selected = null;
				$('<div data-alert class="alert-box">' + 
					'<span>Todo ha ido bien :)</span>' + 
	  				'<a href="#" class="close">&times;</a>' + 
				'</div>').insertBefore('.uploader');
				$scope.$apply();
			},
			error: function (res) {
				alert('500: Error interno');
				$scope.uploading = false;
				$scope.$apply();
			}
		});
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