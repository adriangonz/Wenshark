
function NewPlaylistCtrl($scope, $routeParams, $http) {
    $scope.createPlaylist = function () {
        $scope.creatingPlaylist = true;

    }
    $scope.newPlaylistName = "";
    $scope.submitPlaylist = function () {
        var name = $scope.newPlaylistName;
        var songs = [];
        for (var i=0; i<$scope.playlist.length; i++) {
            songs.push($scope.playlist[i].Id);
        }
        
        var data = { name: name, songs: songs }

        $scope.creatingPlaylist = false;
        $scope.newPlaylistName = "";

        $http
       .put('/api/playlist', JSON.stringify(data))
       .success(function (data) {
           console.log("Playlist " + name + " created");
           console.log($scope.playlists);
           $scope.playlists.push(data);
       })
       .error(function (data) {
           console.log("Error creatin playlist");
       });
    }

    $scope.playPlayList = function (playlist) {
        console.log(playlist);
        $http
        .get('/api/playlist/' + playlist.Id)
        .success(function (data) {
            console.log(data);
            addListToPlaylistAndPlay(playlist.Song);
        })
        .error(function (data) {
            console.log(data);
        });
    }
}