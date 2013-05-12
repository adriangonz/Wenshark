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
		if($scope.editingImage) return;

		$scope.editingName = true;
		oldName = $scope.user.Name;

		$('.name-txt').attr('contenteditable', 'true');
	}

	$scope.cancelEditName = function() {
		if(!$scope.isEditable) return;

		$scope.editingName = false;
		$('.name-txt').attr('contenteditable', 'false');
		$('.name-txt').html(oldName);
	}

	$scope.submitEditName = function() {
		if(!$scope.isEditable) return;

		var id = $scope.user.Id,
			name = $('.name-txt').html();
		$http
		.post('/api/user?id=' + id + '&name=' + name)
		.success(function (data) {
			$('<div data-alert class="alert-box">' + 
				'<span>Tu nombre se ha actualizado :)</span>' + 
  				'<a href="#" class="close">&times;</a>' + 
			'</div>').insertAfter('.profile-name');
			$scope.editingName = false;
			$('.name-txt').attr('contenteditable', 'false');
		})
		.error(function() {
			alert('Ha habido un error');
		});
	}

	//Editing the image
	var oldImage = '';
	$scope.editImage = function() {
		if(!$scope.isEditable) return;
		if($scope.editingName) return;

		$scope.editingImage = true;
		$('.img-edit').addClass('active');
		oldImage = $scope.user.Image;
	}

	$scope.cancelEditImage = function() {
		if(!$scope.isEditable) return;

		$scope.editingImage = false;
		$('.img-edit').removeClass('active');
		$scope.user.Image = oldImage;
	}

	$scope.submitEditImage = function() {
		if(!$scope.isEditable) return;

		var id = $scope.user.Id,
			image = $scope.user.Image;

		$http
		.post('/api/user?id=' + id + '&image=' + image)
		.success(function (data) {
			$('<div data-alert class="alert-box">' + 
				'<span>Tu imagen se ha actualizado :)</span>' + 
  				'<a href="#" class="close">&times;</a>' + 
			'</div>').insertAfter('.profile-name');
			$scope.editingImage = false;
			$('.img-edit').removeClass('active');
		})
		.error(function() {
			alert('Ha habido un error');
		});
	}
}