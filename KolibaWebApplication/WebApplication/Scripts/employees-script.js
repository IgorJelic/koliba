$(document).ready(() => {

    $("#add-new-employee").click(() => {

        $(".modal-employee").toggleClass("hidden-custom");
    })

    $(".close").click(() => {
        $(".modal-employee").toggleClass("hidden-custom");
    })

    $("#employee-form").submit((e) => {
        e.preventDefault();

        var actionUrl = "http://localhost:49693/api/addsalesman"

        var data = {
            FirstName: $("#firstname").val().trim(),
            LastName: $("#lastname").val().trim(),
            Username: $("#username").val().trim(),
            Password: $("#password").val().trim(),
        }

        var errMsg = validateUser(data);

        if (errMsg !== "") {
            alert(errMsg);
            return
        }

        $.ajax({
            type: "POST",
            url: actionUrl,
            dataType: 'json',
            data: data,

            success: (result) => {

                alert("Registration done.");
                window.location.href = "Index";

            },
            error: (jqXHR, textStatus, errorThrown) => {
                alert("Register failed. [" + jqXHR.status + " - " + jqXHR.statusText + " - " + jqXHR.responseText + "]");
                document.getElementById("employee-form").reset();

            }

        })
    })

    $(".btn-delete-employee").click((e) => {
        const id = $(e.currentTarget).data('idval');
        var actionUrl = "http://localhost:49693/api/removesalesman/" + id;


        $.ajax({
            type: "DELETE",
            url: actionUrl,

            success: (result) => {

                alert("Employee fired!");
                window.location.href = "Index";
            },
            error: (jqXHR, textStatus, errorThrown) => {
                alert("Removal failed. [" + jqXHR.status + " - " + jqXHR.responseText + "]");
            }
        })
    })
})

function validateUser(user) {
    if (user.FirstName.trim() === "") {
        return "Enter your FirstName.";
    }
    else if (user.LastName.trim() === "") {
        return "Enter your LastName.";
    }
    else if (user.Username.trim() === "") {
        return "Enter your Username.";
    }
    else if (user.Password.trim() === "") {
        return "Enter your FirstName.";
    }
    else if (user.Password.length < 6) {
        return "Password must be at least 6 characters long.";
    }
    else {
        return "";
    }
}
