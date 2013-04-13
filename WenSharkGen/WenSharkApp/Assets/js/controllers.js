/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl ($scope, $timeout) {
	$scope.search = function (query) {
	    window.location.href = "/#/search/" + query;	
	}

	if ($.cookie("name")) {
	    $scope.hideUserName = false;
	    $('#nameIdLoggin').html($.cookie("name"));
	    //console.log($.cookie("name"));
	} else {
	    $scope.hideUserName = true;
	}


	$scope.Logout = function () {
	    //Borrar estas cookies
	    $.cookie("id", null);
	    $.cookie("name", null);
	    $.ajax({
	        url: '/api/user',
	        type: 'GET',
	        data: 'logout',
	        processData: false,
	        contentType: false,
	        success: function (res) {
	            $('#nameIdLoggin').html("Tu Nombre");
	            $('#idSignInLi').css("display", 'inline');
	            $('#idSignUpLi').css('display', 'inline');
	            $('#idNameLi').css('display', 'none');
	            $('#idLiUpload').css('display', 'none');
	            $('#dropDownUserMenu').removeClass('open');
	            $('#dropDownUserMenu').css("left", "-9999px");
	            //console.log($scope.hideUserName);
	        },
	        error: function (res) {
	            alert('500: Error interno');
	        }
	    });
	}

	// Player

    // Pasa un tiempo en segundos a un string con el formato %M:%S
	$scope.secondsToSongString = function (seconds) {
		if(! typeof seconds === "number"){
			return "";
		}

		var iMinutes = Math.floor(seconds / 60);
		var iSeconds = Math.floor(seconds - iMinutes * 60);

		var sSeconds = iSeconds < 10 ? "0" + iSeconds : "" + iSeconds;
		var sMinutes = iMinutes < 10 ? "0" + iMinutes : "" + iMinutes;

		return sMinutes + ":" + sSeconds;
	}

	$scope.createSong = function (song_obj) {
		var song = {
			Name: song_obj.Name,
			Album: song_obj.Album,
			Artist: song_obj.Artist,
			Id: song_obj.Id,
			order: $scope.playlist.length,

			isPlaying: false,
			_howl: null,
			loaded: function(){
				return this._howl != null;
			},
			load: function() {
				this._howl = new Howl({
					urls: [song_obj.src],
					buffer: true,
					onend: function(){
						$scope.nextSong();
					},
					onload: function(){
						song.timeTotal = $scope.secondsToSongString(this._duration);
					}
				});
			},
			play: function(){
				if(!this.loaded()){
					this.load();
				}
				this._howl.play();	
				this.isPlaying = true;	
			},
			pause: function(){
				this._howl.pause();
				this.isPlaying = false;
			},
			stop: function(){
				this._howl.stop();
				this.isPlaying = false;
				this._howl = null;
			},
			timeElapsed: "00:00",
			timeTotal: "00:00",
			percElapsed: 0,
			scrubPos: -7,
		};

		return song;
	}

	$scope.addToPlaylist = function (song) {
		var n_song = $scope.createSong(song);
		window.pruebas = n_song._howl;
		$scope.playlist.push(n_song);

		if($scope.current == null)
			$scope.current = n_song;
	}

	$scope.getNextSong = function () {
		var curr_order = $scope.current.order,
			next = curr_order + 1;

		if(next >= $scope.playlist.length)
			return null;

		return $scope.playlist[next];
	}

	$scope.getPrevSong = function () {
		var curr_order = $scope.current.order,
			prev = curr_order - 1;

		if(prev < 0)
			return null;

		return $scope.playlist[prev];
	}

	$scope.rmFromPlaylist = function (song) {
		if($scope.current.order == song.order)
			$scope.current = $scope.getNextSong();

		$scope.playlist.splice(song.order, 1);

		//We reset the order index of the next
		for(var i = song.order; i < $scope.playlist.length; i++)
			$scope.playlist[i].order--;
	}

	$scope.play = function (song) {
		var playing = $scope.current.isPlaying;
		if($scope.current.loaded()){
			$scope.current.stop();
		}
		$scope.current = song;
		if(playing){
			$scope.current.play();
		} else {
			$scope.current.load();
		}

		var urlToPlay = '/api/song/file&id=' + song.Id;
	}

	$scope.playSong = function () {
		console.log("play");
		if($scope.current != null) {
			if(!$scope.current.isPlaying) {
				$scope.current.play();
			}		
		}
	}

	$scope.pauseSong = function () {
		console.log("pause");
		if($scope.current != null) {
			if($scope.current.isPlaying) {
				$scope.current.pause();
			}		
		} 
	}

	$scope.nextSong = function () {
		var next = $scope.getNextSong();
		if(next != null){
			var playing = $scope.current.isPlaying;
			if($scope.current.loaded()){
				$scope.current.stop();
			}
			$scope.current = next;
			if(playing){
				$scope.current.play();
			} else {
				$scope.current.load();
			}
		}
	}

	$scope.updateTime = function () {
		var curr_seconds = $scope.current._howl.pos();
		$scope.current.timeElapsed = $scope.secondsToSongString(curr_seconds);
		var elapsed_perc = (curr_seconds /  $scope.current._howl._duration);
		$scope.current.percElapsed = elapsed_perc * 100;
		$scope.current.scrubPos = $("#click_control").width() * elapsed_perc - 7;
	}

	$scope.utOnTimeout = function () {
		if($scope.current != null && $scope.current.isPlaying){
    		$scope.updateTime();
    	}
    	utTimeout = $timeout($scope.utOnTimeout, 500);
	}
	var utTimeout = $timeout($scope.utOnTimeout, 500);

	$scope.playlist = [];
	$scope.current = null;
/*
	var song1 = {
		Name: "Shop",
		Album: {
			Image: "/Assets/img/50x50.Img.gif",
			Name: "Test Album"
		},
		Artist: {
			Name: "Test Artist"
		},
		Id: 1,
		src: "/Assets/songs/test.mp3"
	};

	var song2 = {
		Name: "Cant",
		Album: {
			Image: "/Assets/img/50x50.Img.gif",
			Name: "Test Album"
		},
		Artist: {
			Name: "Test Artist"
		},
		Id: 1,
		src: "/Assets/songs/test2.mp3"
	};

	$scope.addToPlaylist(song1);
	$scope.addToPlaylist(song2);*/
}

//Controller for the search
function SearchCtrl ($scope, $routeParams, $http) {
	$scope.query = $routeParams.query;
	$scope.loading = true;
	$http
		.get('/api/search?name=' + $scope.query)
		.success(function (data) {
			//console.log(data);
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
        if ($scope.user.passw != '' && $scope.user.passw == $scope.user.confPass) {
            $http
		    .post('/api/user', JSON.stringify($scope.user))
		    .success(function (data) {
		        $('#dropDownSignUp').removeClass('open');
		        $('#dropDownSignUp').css("left", "-9999px");
		        $('#modalSignUp').foundation('reveal', 'open');//esta linea hay que ponerla en el succes
		        /*if (data) {
		            console.log(data);
		        } else {
		            console.log("No hay nada");
		        }*/
		    })
            .error(function (data, status) {
                if (status == 409) {
                    $('#usernameSignUp').removeClass('ng-valid');
                    $('#usernameSignUp').addClass('ng-invalid');
                } else {
                    alert(data);
                }
            });
        }
    }
}

function SignInCtrl($scope, $routeParams, $http) {
    $scope.userlogin = {
        username: '',
        passw: ''
    }
    
    $scope.hideUserName = true;
    $scope.signin = function () {
        
        if ($scope.userlogin.username != '' && $scope.userlogin.passw != '') {
            $http
            .get('/api/user?user='+$scope.userlogin.username+'&pass='+$scope.userlogin.passw)
            .success(function (data) {
                $('#dropDownSignIn').removeClass('open');
                $('#dropDownSignIn').css("left", "-9999px");
                //console.log("loggeado");
                //console.log(data);
                $.cookie("id", data.id);
                $.cookie("name", data.name);
                $scope.hideUserName = false;
                $('#nameIdLoggin').html(data.name);
                $('#idSignInLi').css("display", 'none');
                $('#idSignUpLi').css('display', 'none');
                $('#idNameLi').css('display', 'inline');
                $('#idLiUpload').css('display', 'inline');
                //console.log($scope.hideUserName);
            })
            .error(function (data) {
            });
        }
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
		//console.log($scope.songsToUpload);
	});
}