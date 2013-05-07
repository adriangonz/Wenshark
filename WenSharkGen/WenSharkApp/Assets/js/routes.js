/* Routes for angularjs */

angular.module('wenshark', [])
	.config(['$routeProvider', function ($routeProvider) {
		$routeProvider
			.when('/search/:query', {controller: SearchCtrl, templateUrl: '/Assets/partials/search.html'})
			.when('/artist/:id', {controller: ArtistCtrl, templateUrl: '/Assets/partials/artist.html'})
			.when('/album/:id', {controller: AlbumCtrl, templateUrl: '/Assets/partials/album.html'})
			.when('/error', {templateUrl: '/Assets/partials/error.html'})
			.when('/', {templateUrl: '/Assets/partials/main.html'})
			.when('/upload', { controller: UploadCtrl, templateUrl: '/Assets/partials/upload.html' })
            .when('/playlist/:query', { controller: PlayListCtrl, templateUrl: '/Assets/partials/playListPage.html' })
            .when('/accestoken', { templateUrl: '/Assets/partials/loading.html' })//Para que Oauth no rediriga a error
            .when('/user', {})//borrar
			.otherwise({redirectTo: '/error'});
	}]);