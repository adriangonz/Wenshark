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
        require: 'ngModel',
        scope: {
            ngModel: '='
        },
        template: 
            '<span class="song-img small-1 columns left">' + 
                '<img src="{{ngModel.Album.Image}}" width="50" height="50" />' + 
            '</span>' + 
            '<span class="song-name small-6 columns left">' +
                '<p class="name">{{ngModel.Name}}</p>' + 
                '<p class="subname"><a href="#/artist/{{ngModel.Artist.Id}}">{{ngModel.Artist.Name}}</a> · ' + 
                '<a href="#/album/{{ngModel.Album.Id}}">{{ngModel.Album.Name}}</a></p>' + 
            '</span>' + 
            '<span class="song-controls small-5 columns right">' + 
                '<ul class="button-group">' + 
                    '<li><button class="tiny" ng-click"addToPlaylist(ngModel)"><span class="foundicon-plus"></span></button></li>' + 
                    '<li><button class="tiny" ng-click"addToPlaylistAndPlay(ngModel)"><span class="tiny play"></span></button></li>' +
                '</ul>' + 
            '</span>'
    }
})
.directive('wsAlbum', function() {
    return {
        restrict: 'A',
        require: 'ngModel',
        scope: {
            ngModel: '='
        },
        template: 
            '<span class="small-1 columns left">' +
                '<img src="{{ngModel.Image}}" width="50" height="50" />' + 
            '</span>' + 
            '<span class="small-6 columns left">' + 
                '<a href="#/album/{{ngModel.Id}}">' + 
                    '<p class="name">{{ngModel.Name}}</p>' + 
                '</a>' + 
            '</span>'
    }
})
.directive('wsArtist', function() {
    return {
        restrict: 'A',
        require: 'ngModel',
        scope: {
            ngModel: '='
        },
        template: 
            '<span class="small-1 columns left">' +
                '<img src="{{ngModel.Image}}" width="50" height="50" />' + 
            '</span>' + 
            '<span class="small-6 columns left">' + 
                '<a href="#/artist/{{ngModel.Id}}">' + 
                    '<p class="name">{{ngModel.Name}}</p>' + 
                '</a>' + 
            '</span>'
    }
});