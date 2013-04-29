//Controller for the search
function PlayListCtrl($scope, $routeParams, $http) {
    $scope.query = $routeParams.query;
    $scope.loading = true;
}