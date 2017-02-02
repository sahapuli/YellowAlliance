/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/

$(document).ready(function () {
    $('#btnlogin').click(function (e) {
        e.preventDefault();
        login();
    });

});  // End of Document Ready function

//this function will do a post call into the login controller passing the userid and password
//note I didn't make the password field a real password field as this is a test and it doesn't matter
//what you type in 
function login() {
    var uri = "api/Auth/Login"
    var loginData = {
        UserID: $("#username").val(),
        Password: $("#password").val()
    };

    var testpost = $.post(uri, { "": JSON.stringify(loginData) })
            .success(function (data) {
                //user has successfully logged on 
                msgbox(0, "Logout On Completed!", "You has successfully Logged On!");
                //window.location.href = "\index.html";
            })

            .error(function (jqXHR, textStatus, errorThrown) {
                 msgbox(-1, "Login Failed!", 'Error Occurred: ' + jqXHR.responseText);
            });

}

//this function will logout the person
function logout() {
    var uri = "api/Auth/Logout";
    $.getJSON(uri, function (data) {
        if (data.hasOwnProperty('Message')) {
            msgbox(-1, "Logout Failed!", "Error Occurred: " + data.Message);
        } else {
            //user has successfully logged out 
            msgbox(0, "Logout Completed!", "You has successfully Logged Off!");
        }

    }) // End Json Call 
        .error(function (jqXHR, textStatus, errorThrown) {
            msgbox(-1, "Logout Failed!", 'Error Occurred: ' + jqXHR.responseText);
    });
}