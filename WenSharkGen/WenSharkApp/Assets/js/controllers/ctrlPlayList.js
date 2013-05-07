//Controller for the search
function PlayListCtrl($scope, $routeParams, $http) {
    $scope.query = $routeParams.query;
    $scope.loading = true;
    $http
		.get('/api/playlist?id=' + $scope.query)
		.success(function (data) {
		    console.log(data);
		    $scope.id = data.Id;
		    $scope.songs = data.Song;
		    $scope.listName = data.Name;
		    $scope.loading = false;
		})
		.error(function (data) {
		    console.log("Error");
		});

    $scope.startEdit = function () {
        $scope.editing = true;
    }

    $scope.editPlaylist = function () {
        $('#inputNewName').attr('disabled', 'disabled');
        $http
        .post('/api/playlist', JSON.stringify({ id: $scope.id, name: $scope.newName }))
        .success(function () {
            $scope.listName = $scope.newName;
            for (var i = 0; i < $scope.playlists.length; i++) {
                if ($scope.playlists[i].Id == $scope.id) {
                    $scope.playlists[i].Name = $scope.newName;
                    break;
                }
            }
            $scope.editing = false;
            $("#inputNewName").removeAttr('disabled');

        })
        .error(function (data) {
            $("#inputNewName").removeAttr('disabled');

            console.log("Error Modificanco Playlist");
            console.log(data);
        });
            
    }

    $scope.playPlaylist = function () {
        addToPlayListAndPlay($scope.songs);
    }
}