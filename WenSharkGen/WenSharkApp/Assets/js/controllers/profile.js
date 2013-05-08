// Controller for managing the user's profile

function ProfileCtrl($scope, $routeParams, $http, $location) {
	$scope.loading = true;

	//Redirect if not logged
	if (!$scope.IsLogged()) $location.path('error');

	//Check if same user (to enable editing)
	if ($scope.getUserId() == $routeParams.id)
		$scope.isEditable = true;
	else
		$scope.isEditable = false;

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

	$scope.editingName = false;
	var oldName = '';
	//Some functions for editing
	$scope.editName = function () {
		if(!$scope.isEditable) return;

		$scope.editingName = true;
		oldName = $scope.user.Name;

		$('.name-txt').attr('contenteditable', 'true');
	}

	$scope.cancelEdit = function() {
		$scope.editingName = false;
		$('.name-txt').attr('contenteditable', 'false');
		$('.name-txt').html(oldName);
	}

	$scope.submitEdit = function() {
		
	}
}