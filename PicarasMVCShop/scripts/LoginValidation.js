$("#login").on("click",
    function () {
        var message ='<div class="alert alert-danger" role="alert" style="margin-top:10px; width:50%;"> ' +
            '<span class= "glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>' +
            '<span class="sr-only">Error:</span>' +
            "Usuario o Contraseña incorrectos" +
            "</div>";
        var user = $(".userName").val();
        var pass = $(".password-user").val();
        $.ajax({
            url: "http://localhost:52241/Login/LoginPage",
            type: "POST",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { UserName: user, Password: pass},
            success: function(v) {
                if (!v) {
                    $(".alert-danger").remove();
                    $(".validationLogin").append(message);
                } else {
                    document.location.href = "/";
                }
            },
            error: function(e) {

            }
        });
    });
