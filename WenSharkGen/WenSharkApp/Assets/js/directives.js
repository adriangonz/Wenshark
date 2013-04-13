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
});
/*
.directive('dndList', function() {
    return {
        restrict: 'A',
        link: function(scope, element, attrs) {
            // variables used for dnd
            var toUpdate;
            var startIndex = -1;
     
            // watch the model, so we always know what element
            // is at a specific position
            scope.$watch(attrs.dndList, function(value) {
                toUpdate = value;
            },true);
     
            // use jquery to make the element sortable (dnd). This is called
            // when the element is rendered
            $(element[0]).sortable({
                items:'li',
                zIndex: 10000,
                start:function (event, ui) {
                    //To the chuplin
                },
                stop:function (event, ui) {
                    //Mas to the chuplin
                },
                axis:'x'
            })
        }
    }
});*/