// Controller for managing the user's profile

function ProfileCtrl($scope, $routeParams, $http, $location) {
	$scope.loading = true;

	//Redirect if not logged
	if (!$scope.IsLogged()) $location.path('error');

	//Check if same user (to enable editing)
	if ($scope.getUserId() == $routeParams.id)
		$scope.editable = true;
	else
		$scope.editable = false;

	//Load the info
	$http
	.get('/api/user?id=' + $routeParams.id)
	.success(function (data) {
		console.log(data);
		$scope.user = data;

		$scope.loading = false;
	})
	.error(function() {
		$location.path('error');
	});
}