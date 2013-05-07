
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
        console.log("pene");
        console.log(playlist);
        alert("Aqui hay que hacer un ajax para pedir las canciones y llamar a addListToPlaylist(canciones) -> esta en la rama de martin... ");
    }
}