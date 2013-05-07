angular.module('wenshark')
.directive('uiValidateEquals', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {

            function validateEqual(myValue, otherValue) {
                if (myValue === otherValue) {
                    ctrl.$setValidity('equal', true);
                    return myValue;
                } else {
                    ctrl.$setValidity('equal', false);
                    return undefined;
                }
            }

            scope.$watch(attrs.uiValidateEquals, function (otherModelValue) {
                validateEqual(ctrl.$viewValue, otherModelValue);
            });

            ctrl.$parsers.unshift(function (viewValue) {
                return validateEqual(viewValue, scope.$eval(attrs.uiValidateEquals));
            });

            ctrl.$formatters.unshift(function (modelValue) {
                return validateEqual(modelValue, scope.$eval(attrs.uiValidateEquals));
            });
        }
    };
})
.directive('wsSong', function() {
    return {
        restrict: 'A',
        template: 
            '<span class="song-img small-2 columns left">' + 
                '<img src="{{song.Album.Image}}" width="50" />' + 
            '</span>' + 
            '<span class="song-name small-5 columns left">' +
                '<p class="name">{{song.Name}}</p>' + 
                '<p class="subname"><a href="#/artist/{{song.Artist.Id}}">{{song.Artist.Name}}</a> · ' + 
                '<a href="#/album/{{song.Album.Id}}">{{song.Album.Name}}</a></p>' + 
            '</span>' + 
            '<span class="song-controls small-5 columns right">' + 
                '<ul class="button-group">' + 
                    '<li ng-hide="isFavorited(song)"><button class="tiny" ng-click="addToFavorites(song)"><span class="foundicon-star"></span></button></li>' +
                    '<li ng-show="isFavorited(song)"><a class="tiny" ng-click="removeFromFavorites(song)"><span class="foundicon-star"></span></button></li>' +
                    '<li><button class="tiny" ng-click="addToPlaylist(song)"><span class="foundicon-plus"></span></button></li>' + 
                    '<li><button class="tiny" ng-click="addToPlaylistAndPlay(song)"><span class="tiny play"></span></button></li>' +
                '</ul>' + 
            '</span>'
    }
})
.directive('wsAlbum', function() {
    return {
        restrict: 'A',
        template: 
            '<span class="small-2 columns left">' +
                '<img src="{{album.Image}}" width="50" />' + 
            '</span>' + 
            '<span class="small-6 columns left">' + 
                '<a href="#/album/{{album.Id}}">' + 
                    '<p class="name">{{album.Name}}</p>' + 
                '</a>' + 
            '</span>'
    }
})
.directive('wsArtist', function() {
    return {
        restrict: 'A',
        template: 
            '<span class="small-2 columns left">' +
                '<img src="{{artist.Image}}" width="50" />' + 
            '</span>' + 
            '<span class="small-6 columns left">' + 
                '<a href="#/artist/{{artist.Id}}">' + 
                    '<p class="name">{{artist.Name}}</p>' + 
                '</a>' + 
            '</span>'
    }
})
.directive('wsGenre', function() {
    return {
        restrict: 'A',
        template:
            '<span class="radius label">{{genre.Name}}</span>'
    }
});