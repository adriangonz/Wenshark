function sharePublicationCtrl($scope, $routeParams, $http) {
    $scope.sharing = false;
    $scope.share = function () {
        $scope.sharing = true;
        var data = { description: $scope.publication.text, item: $scope.publication.item }
        $http
           .post('/api/Publication', JSON.stringify(data))
           .success(function (data) {
               $scope.sharing = false;
               console.log(data);
           })
           .error(function (data) {
               console.log("Error compartiendo");
                $scope.sharing = false;
           });
    }
}