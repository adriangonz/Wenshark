//Controller for the artist page
function ArtistCtrl($scope, $routeParams, $http) {
	var id = $routeParams.id;
	console.log('Entras en artista ' + id + ' o k ase');

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

	$scope.artist = {
		Id: id,
		Name: 'Artist name',
		Image: 'artist-pic.gif',
		Bio: 'Artist bio',
		Songs: songs,
		Albums: [],
		Genres: genres
	};

	$(document).foundation('section');
}
