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
		$scope.user = data;

		$scope.loading = false;
	})
	.error(function() {
		$location.path('error');
	});

	$http
        .get('/api/timeline?userId=' + $routeParams.id)
        .success(function (data) {
            $scope.publications = data.publications;
            for(var i = 0; i < $scope.publications.length; i++){
            	$scope.publications[i].Item = $scope.getFullItem($scope.publications[i].Item, data);
            }
        })
        .error(function (data) {
            console.log('500: Error interno');
        });

    $scope.getFullItem = function(item, data) {

    	switch(item.Type) {
    	case "Song":
    		for(var j = 0; j < data.songs.length; j++) {
    			if(data.songs[j].Id == item.Id)
    				return data.songs[j];
    		}
    		break;
    	case "Album":
    		for(var j = 0; j < data.albums.length; j++) {
    			if(data.albums[j].Id == item.Id)
    				return data.albums[j];
    		}
    		break;
    	case "Artist":
    		for(var j = 0; j < data.artists.length; j++) {
    			if(data.artists[j].Id == item.Id)
    				return data.artists[j];
    		}
    		break;
    	}
    	return {};
    }

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
			$('#nameIdLoggin').html($scope.user.Name);
			$.cookie("name", $scope.user.Name);
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
		$scope.imageChosen = false;
		$('.img-edit').addClass('active');
		oldImage = $scope.user.Image;
	}

	$scope.chooseImage = function() {
		$('#input-image').click();
	}

	$scope.imageToUpload = null;
	$scope.imageChosen = false;
	$('#input-image').change(function (e) {
		var file = $('#input-image')[0].files;

		if(file.length > 0) 
			file = file[0];
		else
			return;

		var reader = new FileReader();
		reader.onload = function (e) {
			$scope.imageURL = e.target.result;
			console.log("URL: " + $scope.imageURL);
		}
		reader.readAsDataURL(file);

		$scope.imageToUpload = file;
		$scope.imageChosen = true;
		
		$scope.$apply();
	});

	$scope.cancelEditImage = function() {
		if(!$scope.isEditable) return;

		$scope.editingImage = false;
		$scope.imageToUpload = null;
		$scope.imageChosen = false;
		$scope.imageURL = '';
		$('.img-edit').removeClass('active');
	}

	$scope.submitEditImage = function() {
		if(!$scope.isEditable) return;

		var id = $scope.user.Id,
			file = $scope.imageToUpload;

		var formdata = new FormData();
		formdata.append('image', file);

		$.ajax({
			url: '/api/user?id=' + id,
			type: 'POST',
			data: formdata,
			processData: false,
			contentType: false,
			success: function (res) {
				$('<div data-alert class="alert-box">' + 
					'<span>Tu imagen se ha actualizado :)</span>' + 
	  				'<a href="#" class="close">&times;</a>' + 
				'</div>').insertAfter('.profile-name');
				$scope.editingImage = false;
				$scope.imageToUpload = null;
				$scope.imageChosen = false;
				$scope.imageURL = '';
				console.log(res);
				$scope.user.Image = res;
				$('.img-edit').removeClass('active');
				$scope.$apply();
			},
			error: function (res) {
				alert('Ha habido un error');
				$scope.editingImage = false;
				$scope.imageToUpload = null;
				$scope.imageChosen = false;
				$scope.imageURL = '';
				$('.img-edit').removeClass('active');
				$scope.$apply();
			}
		});
	}
}