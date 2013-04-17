/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl ($scope, $timeout) {
	$scope.search = function (query) {
	    window.location.href = "/#/search/" + query;	
	}

	$scope.IsLogged = function () {
		if ($.cookie("name")) {
		   return true;
		} else {
		    return false;
		}
	}

	if ($scope.IsLogged()){
		 $scope.hideUserName = false;
	    $('#nameIdLoggin').html($.cookie("name"));
	    //console.log($.cookie("name"));
	}else{
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
		if(! (typeof seconds === "number")){
			return "00:00";
		}

		var iMinutes = Math.floor(seconds / 60);
		var iSeconds = Math.floor(seconds - iMinutes * 60);

		var sSeconds = iSeconds < 10 ? "0" + iSeconds : "" + iSeconds;
		var sMinutes = iMinutes < 10 ? "0" + iMinutes : "" + iMinutes;

		return sMinutes + ":" + sSeconds;
	}

	$scope.createSong = function (song_obj) {
		//Parche porque Howler reconoce el tipo en funcion de la extension
		song_obj.src = '/api/song?file&id=' + song_obj.Id;
		switch(song_obj.Mime) {
			case 'audio/mp3':
				song_obj.src += '#.mp3';
				break;
			case 'audio/ogg':
				song_obj.src += '#.ogg';
				break;
			case 'audio/wav':
				song_obj.src += '#.wav';
				break;
		}
		var song = {
			Name: song_obj.Name,
			Album: song_obj.Album,
			Artist: song_obj.Artist,
			Id: song_obj.Id,

			isPlaying: false,
			_howl: null,
			loaded: function(){
				return this._howl != null;
			},
			load: function() {
				this._howl = new Howl({
					urls: [song_obj.src],
					buffer: true,
					loop: true,
					onend: function() {
						$scope.nextSong();
					},
					onload: function(){
						song.timeTotal = $scope.secondsToSongString(this._duration);
						song.duration = this._duration;
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
			duration: 0,
			pos: function(pos){
				if(this.loaded()){
					if(typeof pos === "undefined"){
						return this._howl.pos();
					} else {
						this._howl.pos(pos);
					}
				}	
			},
			timeElapsed: "00:00",
			timeTotal: "00:00",
			percElapsed: 0
		};

		return song;
	}

	$scope.addToPlaylist = function (song) {
		var n_song = $scope.createSong(song);

		$scope.playlist.push(n_song);

		if($scope.current == null) {
			$scope.current = n_song;
			$scope.current.play();
		}
	}

	$scope.addToPlaylistAndPlay = function (song) {
		var n_song = $scope.createSong(song);

		$scope.playlist.push(n_song);

		if($scope.current != null && $scope.current.isPlaying)
			$scope.current.stop();

		$scope.current = n_song;
		$scope.current.play();
	}

	$scope.getNextSong = function () {
		$scope.current_pos ++;

		if($scope.current_pos >= $scope.playlist.length){
			return null;
		}

		return $scope.playlist[$scope.current_pos];
	}

	$scope.getPrevSong = function () {
		$scope.current_pos = Math.max($scope.current_pos - 1, 0);
		return $scope.playlist[$scope.current_pos];
	}

	$scope.rmFromPlaylist = function (song) {
		for(var i = 0; i < $scope.playlist.length; i++){
			if($scope.playlist[i].Id == song.Id){
				$scope.playlist.splice(i, 1);
				break;
			}
		}

		if(i < $scope.current_pos){
			$scope.current_pos--;
		}

		if($scope.current.Id == song.Id){
			$scope.nextSong();
		}
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
		$scope.changeSong(next);
	}

	$scope.prevSong = function () {
		var prev = $scope.getPrevSong();
		$scope.changeSong(prev);
	}

	$scope.changeSong = function (song) {
		var playing = false;
		if($scope.current != null){
			playing = $scope.current.isPlaying;
			if($scope.current.loaded()){
				$scope.current.stop();
				$scope.current = null;
			}
		}
		if(song != null){
			for(var i = 0; i < $scope.playlist.length; i++){
				if($scope.playlist[i].Id == song.Id){
					$scope.current_pos = i;
					break;
				}
			}

			$scope.current = song;
			if(playing){
				$scope.current.play();
			} else {
				$scope.current.load();
			}
			$scope.updateTime();
		}
	}

	$scope.updateTime = function () {
		var curr_seconds = $scope.current.pos();
		if(typeof curr_seconds === "undefined"){ // No se que pasa, pero la cancion no termina
			$scope.nextSong();
			return;
		}
		$scope.current.timeElapsed = $scope.secondsToSongString(curr_seconds);
		$scope.current.percElapsed = (curr_seconds / $scope.current.duration) * 100;
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
	$scope.current_pos = 0;
	var sortableEle;

	// Para poder moverse por la cancion
	$scope.playAt = function (pos) {
		if($scope.current.loaded()){
			$scope.current.pos($scope.current.duration * pos);
		}
	}

	$("#clickControl").click(function(e){
		var relX = e.pageX - $(this).offset().left;
		$scope.playAt(relX / $(this).width());
	});

	/* Reordenar las canciones */

	$scope.dragStart = function(e, ui) {
        ui.item.data('start', ui.item.index());
    }
    $scope.dragEnd = function(e, ui) {
        var start = ui.item.data('start'),
            end = ui.item.index();

        if(start == $scope.current_pos){
        	$scope.current_pos = end;
        } else {
	        if(start < $scope.current_pos){
	        	$scope.current_pos--
	        }

	        if(end <= $scope.current_pos){
	        	$scope.current_pos++
	        }
	    }

        $scope.playlist.splice(end, 0, 
            $scope.playlist.splice(start, 1)[0]);
        
        $scope.$apply();
    }
        
    $scope.sortableEle = $('#sortable').sortable({
        start: $scope.dragStart,
        update: $scope.dragEnd
    });

/* Pruebas en local 
	var song1 = {
		Name: "1",
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
		Name: "2",
		Album: {
			Image: "/Assets/img/50x50.Img.gif",
			Name: "Test Album"
		},
		Artist: {
			Name: "Test Artist"
		},
		Id: 2,
		src: "/Assets/songs/test2.mp3"
	};
	$scope.addToPlaylist(song1);
	$scope.addToPlaylist(song2);    */
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
    $scope.tryingToSignUp = false;
    $scope.signup = function () {
    	$scope.tryingToSignUp = true;
        if ($scope.user.passw != '' && $scope.user.passw == $scope.user.confPass) {
            $http
		    .post('/api/user', JSON.stringify($scope.user))
		    .success(function (data) {
		        $('#dropDownSignUp').removeClass('open');
		        $('#dropDownSignUp').css("left", "-9999px");
		        $('#modalSignUp').foundation('reveal', 'open');//esta linea hay que ponerla en el succes
		        $scope.tryingToSignUp = false;
		    })
            .error(function (data, status) {
            	$scope.tryingToSignUp = false;
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
    $scope.tryingLoginOrSignUp = false;
    $scope.hideUserName = true;
    $scope.signin = function () {
        $scope.tryingLoginOrSignUp = true;
        if ($scope.userlogin.username != '' && $scope.userlogin.passw != '') {
            $http
            .get('/api/user?user='+$scope.userlogin.username+'&pass='+$scope.userlogin.passw)
            .success(function (data) {
                $('#dropDownSignIn').removeClass('open');
                $('#dropDownSignIn').css("left", "-9999px");
                $.cookie("id", data.id);
                $.cookie("name", data.name);
                $scope.hideUserName = false;
                $('#nameIdLoggin').html(data.name);
                $('#idSignInLi').css("display", 'none');
                $('#idSignUpLi').css('display', 'none');
                $('#idNameLi').css('display', 'inline');
                $('#idLiUpload').css('display', 'inline');
                $scope.tryingLoginOrSignUp = false;
            })
            .error(function (data) {
            	$scope.tryingLoginOrSignUp = false;
            });
        }
    }
}

//Controller for the upload
function UploadCtrl ($scope) {
	if (!$scope.IsLogged()){
		window.location.href = "/#/error";
	}else{
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
				formdata.append("album-" + i, 5);
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
}