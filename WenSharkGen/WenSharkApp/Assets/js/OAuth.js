﻿
var GOAUTHURL = 'https://accounts.google.com/o/oauth2/auth?';
var GVALIDURL = 'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
var GSCOPE = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email";
var GCLIENTID = '86668688312.apps.googleusercontent.com';
//var GREDIRECT = 'http://wenshark.azurewebsites.net/Assets/partials/loading.html';
var GREDIRECT = 'http://localhost:5749/Assets/partials/loading.html';
var GTYPE = 'token';
var G_url = GOAUTHURL + 'scope=' + GSCOPE + '&client_id=' + GCLIENTID + '&redirect_uri=' + GREDIRECT + '&response_type=' + GTYPE;
var acToken;
var tokenType;
var expiresIn;
var user;
var loggedIn = false;

function loginGoogle($scope) {
    var win = window.open(G_url, "windowname1", 'width=800, height=600');
    
    var pollTimer = window.setInterval(function () {
        //console.log(win.document.URL);
        if (win.document.URL.indexOf(GREDIRECT) != -1) {
            window.clearInterval(pollTimer);
            var url = win.document.URL;
            acToken = gup(url, 'access_token');
            tokenType = gup(url, 'token_type');
            expiresIn = gup(url, 'expires_in');
            win.close();
            validateToken(acToken,$scope);
        }
    }, 500);
}

function validateToken(token,$scope) {
    angular.element($("#formSignIn")).scope().tryingLoginOrSignUp = true;
    angular.element($("#formSignUp")).scope().tryingToSignUp = true;
    $.ajax({
        url: '/api/user?token=' + token,
        success: function (data) {
            //Mariconadas
            $('#dropDownSignUp').removeClass('open');
            $('#dropDownSignUp').css("left", "-9999px");
            $('#dropDownSignIn').removeClass('open');
            $('#dropDownSignIn').css("left", "-9999px");
            $('#nameIdLoggin').html(data.name);
            $('#idSignInLi').css("display", 'none');
            $('#idSignUpLi').css('display', 'none');
            $('#idNameLi').css('display', 'inline');
            $('#idLiUpload').css('display', 'inline');
            

            angular.element($("#formSignIn")).scope().tryingLoginOrSignUp = false;
            angular.element($("#formSignUp")).scope().tryingToSignUp = false;
            console.log("loegado");
            //Cookies
            $.cookie("id", data.id);
            $.cookie("name", data.name);
            $scope.loadPlayListPanel();

        }
    });
}

function getUserInfo() {
    $.ajax({
        url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
        data: null,
        success: function (resp) {
            user = resp;
            console.log(user);
            /*$('#uName').text('Welcome ' + user.name);
            $('#uMail').text(user.email);
            $('#imgHolder').attr('src', user.picture);*/
        },
        dataType: "jsonp"
    });
}

//credits: http://www.netlobo.com/url_query_string_javascript.html
function gup(url, name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\#&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    if (results == null)
        return "";
    else
        return results[1];
}

