/* Controllers for AngularJS */

//Main controller of the app
function MainCtrl($scope, $timeout, $http, $location) {
    
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
	$scope.debug = function (string) {
	    console.log(string);
	}
	$scope.playlists = [];

	$scope.loadPlayListPanel = function () {
	    $('#playListBar').css('display', 'inline');
	    $('.wenshark-contenido').css('margin-left', '170px');
	    $scope.loadingPlayList = true;
	    $http
            .get('/api/playlist')
            .success(function (data) {
                //console.log(data);
                $scope.playlists = data;
                $scope.loadingPlayList = false;
            })
            .error(function (data) {
                console.log('500: Error interno');
            });
	}

	$scope.getUserId = function() {
		return $.cookie('id');
	}

	if ($scope.IsLogged()){
	    $scope.hideUserName = false;
	    $scope.loadPlayListPanel();
	    $('#nameIdLoggin').html($.cookie("name"));	    
	}else{
		$scope.hideUserName = true;
	}

	$http
		.get('/api/favorites')
		.success(function (data){
			$scope.favorites = data.songs;
		})
		.error(function (data){
			console.log("ERROR: " + data);	
		});


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
	            $('#playListBar').css('display', 'none');
	            $('.wenshark-contenido').css('margin-left', '0');
	            //console.log($scope.hideUserName);
	            $location.path('/');
	        },
	        error: function (res) {
	            console.log('500: Error interno');
	            $location.path('/');
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

	$scope.addNewPlublication = function (song){
	    $scope.itemClickedToPublish = song.Id;
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

    $scope.addListToPlaylist = function (songs) {
    	if(songs.length != 0){
			var n_song = $scope.createSong(songs[0]);

			$scope.playlist.push(n_song);

			for(var i = 1; i < songs.length; i++){
				$scope.playlist.push($scope.createSong(songs[i]));
			}

			if($scope.current == null) {
				$scope.current = n_song;
				$scope.current.play();
			}
		}
	}

	$scope.addListToPlaylistAndPlay = function (songs) {
		if(songs.length != 0) {
			var n_song = $scope.createSong(songs[0]);

			$scope.playlist.push(n_song);

			for(var i = 1; i < songs.length; i++){
				$scope.playlist.push($scope.createSong(songs[i]));
			}

			if($scope.current != null && $scope.current.isPlaying)
				$scope.current.stop();

			$scope.current = n_song;
			$scope.current.play();
		}
	}

	$scope.addToFavorites = function (song) {
		var i = -1;
		for(i = 0; i < $scope.favorites.length; i++){
			if($scope.favorites[i].Id == song.Id){
				break;
			}
		}
		if($scope.favorites.length == 0 || i == $scope.favorites.length){
			$http
				.get('/api/favorites?add&song_id=' + song.Id)
				.success(function (data) {
					$scope.favorites.push(song);
					console.log($scope.favorites.length);
				});
		}
	}

	$scope.removeFromFavorites = function (song) {
		var i;
		for(i = 0; i < $scope.favorites.length; i++){
			if($scope.favorites[i].Id == song.Id){
				break;
			}
		}
		if($scope.favorites.length > 0 && i != $scope.favorites.length){
			$http
				.get('/api/favorites?remove&song_id=' + song.Id)
				.success(function (data) {
					$scope.favorites.splice(i,1);
					console.log($scope.favorites.length);
				});
		}
	}



	$scope.isFavorited = function (song) {
		if(typeof $scope.favorites === "undefined")
			return false;
		var i = -1;
		for(i = 0; i < $scope.favorites.length; i++){
			if($scope.favorites[i].Id == song.Id){
				break;
			}
		}
		return i != $scope.favorites.length;
		//return false;
	}
}

//Controller for the search
function SearchCtrl ($scope, $routeParams, $http) {
	$scope.query = $routeParams.query;
	$scope.loading = true;

	$scope.showMore = {}
	$scope.PAGESIZE = 5;

	$scope.addMoreSearch = function (type,list) {

	    $http
            .get('/api/search?name=' + $scope.query + '&offset=' + list.length + '&' + type + '=')
            .success(function (data) {
                if (data.length < $scope.PAGESIZE) {
                    console.log("No hay más páginas");
                    $scope.showMore[type] = false;
                }
                list.push.apply(list,data);
                console.log(list);
            })
            .error(function(data){
                alert("PUMM!!!!");
            })
	    }

	$http
		.get('/api/search?name=' + $scope.query)
		.success(function (data) {
		    $scope.songs = data.songs;
		    $scope.songsF = data.songs;
		    $scope.albumsF = $scope.albums = data.albums;
			$scope.artistsF = $scope.artists = data.artists;
			$scope.users = data.users;
			console.log(data.users);
			if ($scope.songs.length == $scope.PAGESIZE) {
			    $scope.showMore["song"] = true;
			}
			if ($scope.artists.length == $scope.PAGESIZE) {
			    $scope.showMore["artist"] = true;
			}
			if ($scope.albums.length == $scope.PAGESIZE) {
			    $scope.showMore["album"] = true;
			}
			if ($scope.users.length == $scope.PAGESIZE) {
			    $scope.showMore["user"] = true;
			}

			$(document).foundation('section', function () {
				$scope.loading = false;
			});
		})
		.error(function(data) {
		    $scope.songs = [];
		    $scope.songsF = [];
		    $scope.albumsF = $scope.albums = [];
		    $scope.artistsF = $scope.artists = [];
			$scope.users = [];
			
			$(document).foundation('section', function () {
				$scope.loading = false;
			});
		});
	$scope.songsF = [];
	$('#filtroCancionesId').bind('input', function (e) {
	    $scope.songsF = [];
	    var text = $('#filtroCancionesId')[0].value.toLowerCase();
	    if (text != "") {
	        for (var i = 0; i < $scope.songs.length; i++) {
	            var songName = $scope.songs[i].Name.toLowerCase();
	            if (songName.indexOf(text) != -1) {
	                $scope.songsF.push($scope.songs[i]);
	            }
	        }
	    } else {
	        $scope.songsF = $scope.songs;
	    }
	});
	$scope.artistsF = [];
	$('#filtroArtistasId').bind('input', function (e) {
	    $scope.artistsF = [];
	    var text = $('#filtroArtistasId')[0].value.toLowerCase();
	    if (text != "") {
	        for (var i = 0; i < $scope.artists.length; i++) {
	            var artistName = $scope.artists[i].Name.toLowerCase();
	            if (artistName.indexOf(text) != -1) {
	                $scope.artistsF.push($scope.artists[i]);
	            }
	        }
	    } else {
	        $scope.artistsF = $scope.artists;
	    }
	});
	$scope.albumsF = [];
	$('#filtroAlbumesId').bind('input', function (e) {
	    $scope.albumsF = [];
	    var text = $('#filtroAlbumesId')[0].value.toLowerCase();
	    if (text != "") {
	        for (var i = 0; i < $scope.albums.length; i++) {
	            var albumName = $scope.albums[i].Name.toLowerCase();
	            if (albumName.indexOf(text) != -1) {
	                $scope.albumsF.push($scope.albums[i]);
	            }
	        }
	    } else {
	        $scope.albumsF = $scope.albums;
	    }
	});

	$scope.seguirPersona = function (idDest) {
	    console.log("Seguir Persona " + idDest);
	    var idActual = $.cookie("id");

	    $http
		.get('/api/user?addFollower=' + idDest)
		.success(function (data) {
		    for (var i = 0; i < $scope.users.length; i++) {
		        if ($scope.users[i].Id == idDest) {
		            $scope.users[i].Follow = true;
		            break;
		        }
		    }
		})
		.error(function (data) {
		    console.log("PUM");
		});

	}

	$scope.dejarseguirPersona = function (idDest) {
	    console.log("Dejar de seguir persona " + idDest);
	    var idActual = $.cookie("id");

	    $http
		.get('/api/user?removeFollower=' + idDest)
		.success(function (data) {
		    for (var i = 0; i < $scope.users.length; i++) {
		        if ($scope.users[i].Id == idDest) {
		            $scope.users[i].Follow = false;
		            break;
		        }
		    }
		})
		.error(function (data) {
		    console.log("PUM");
		});
	}


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
                    console.log(data);
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
    $scope.loginOauthGoogle = function () {
        loginGoogle($scope);
    }
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
                $scope.loadPlayListPanel();
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
			for (var i = 0; i < $scope.songsToUpload.length; i++) {
				formdata.append("file-" + i, $scope.songsToUpload[i].file);
				formdata.append("name-" + i, $scope.songsToUpload[i].name);
				formdata.append("album-" + i, $scope.songsToUpload[i].album.name);
				formdata.append("artist-" + i, $scope.songsToUpload[i].artist.name);
			}

			$.ajax({
				url: '/api/song',
				type: 'POST',
				data: formdata,
				processData: false,
				contentType: false,
				success: function (data,status) {
					//Look for errors on the response
					//(each file creates one response)
				    for(var i = 0; i < data.length; i++) {
				    	if(data[i].StatusCode == 500) {
				    		//If we find an error, stop everything
				    		alert('500: Error interno');
							$scope.uploading = false;
							$scope.$apply();
							return;
				    	}
				    }
				    //If there is no error, everything is fine
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
					console.log('500: Error interno');
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
			    var url = filesToAdd[i].name;
			    var songFile = filesToAdd[i];
			    ID3.loadTags(url, function () {
			        var endDate = new Date().getTime();
			        var tags = ID3.getAllTags(url);
			        var songName = url;
			        if (tags.title) { songName = tags.title; }
			        var picturAlbum = "";
			        if (tags.picture) { picturAlbum = "data:" + tags.picture.format + ";base64," + Base64.encodeBytes(tags.picture.data); }
			        $scope.songsToUpload.push({
			            id: size + i,
			            name: songName,
			            file: songFile,
			            album: {
			                name: tags.album,
			                picture: (picturAlbum)
			            },
			            artist: {
			                name: tags.artist
			            },
			            genre: {
			                name: tags.genre
			            }
			        });
			    },
                {
                    tags: ["artist", "title", "album", "year", "comment", "track", "genre", "lyrics", "picture"],
                    dataReader: FileAPIReader(filesToAdd[i])
                });
				
			};
			$scope.$apply();
			//console.log($scope.songsToUpload);
		});


		

	}
}

function TimelineCtrl($scope, $timeout, $http) {
	$scope.publications = [];

	$http
        .get('/api/timeline')
        .success(function (data) {
            $scope.publications = data.publications;
            for(var i = 0; i < $scope.publications.length; i++){
            	$scope.publications[i].Item = $scope.getFullItem($scope.publications[i].Item, data);
            }
        })
        .error(function (data) {
            console.log('500: Error interno');
        });

    $scope.getFullItem = function(item, data) {

    	switch(item.Type) {
    	case "Song":
    		for(var j = 0; j < data.songs.length; j++) {
    			if(data.songs[j].Id == item.Id)
    				return data.songs[j];
    		}
    		break;
    	case "Album":
    		for(var j = 0; j < data.albums.length; j++) {
    			if(data.albums[j].Id == item.Id)
    				return data.albums[j];
    		}
    		break;
    	case "Artist":
    		for(var j = 0; j < data.artists.length; j++) {
    			if(data.artists[j].Id == item.Id)
    				return data.artists[j];
    		}
    		break;
    	}
    	return {};
    }

    $scope.updateTimeline = function () {
		$http
        .get('/api/timeline')
        .success(function (data) {
            $scope.publications = data.publications;
            for(var i = 0; i < $scope.publications.length; i++){
            	$scope.publications[i].Item = $scope.getFullItem($scope.publications[i].Item, data);
            }
        })
        .error(function (data) {
            console.log('500: Error interno');
        });
	}

	$scope.utOnTimeout = function () {
    	$scope.updateTimeline();
    	utTimeout = $timeout($scope.utOnTimeout, 5000);
	}
	var utTimeout = $timeout($scope.utOnTimeout, 5000);

}