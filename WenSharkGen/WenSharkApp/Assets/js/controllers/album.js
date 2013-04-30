//Controller for the artist page
function AlbumCtrl($scope, $routeParams, $http) {
	var id = $routeParams.id;
	console.log('Entras en album ' + id + ' o k ase');

	songs = []
	for(var i = 0; i < 10; i++) {
		songs.push({
			Name: 'Song-' + i,
			Id: i,
			Album: {
				Id: i,
				Name: 'Album-' + i,
				Image: 'album-img-' + i
			},
			Artist: {
				Id: i,
				Name: 'Artist-' + i
			}
		});
	};

	genres = []
	for(var i = 0; i < 10; i++) {
		genres.push({
			Name: 'Genero-' + i
		})
	}

	$scope.album = {
		Id: id,
		Name: 'Album name',
		Img: 'album-img-' + id,
		Artist: {
			Id: 90,
			Name: 'Artista del album'
		},
		Songs: songs,
		Genres: genres
	}

	$(document).foundation('section');
}
