function sharePublicationCtrl($scope, $routeParams, $http) {
    $scope.sharing = false;
    $scope.publication = {}
    $scope.share = function () {
        $scope.sharing = true;
        
        $scope.publication.item = $scope.itemClickedToPublish;
        if (!$scope.publication.text) {
            $scope.publication.text = "";
        }
        var data = { description: $scope.publication.text, item: $scope.publication.item }
        $http
           .post('/api/Publication', JSON.stringify(data))
           .success(function (data) {
               $scope.sharing = false;
               $('#modalNewPublication').foundation('reveal', 'close');
           })
           .error(function (data) {
               console.log("Error compartiendo");
               $scope.sharing = false;
               $('#modalNewPublication').foundation('reveal', 'close');
           });
    }
}