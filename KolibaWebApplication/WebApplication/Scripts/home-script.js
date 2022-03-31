$(document).ready(() => {
    /* SignIn.cshtml */

    $("#signin-form").submit((e) => {
        //e.preventDefault();

        //var actionUrl = "http://localhost:49693/api/signin";
        //var actionUrl = "http://localhost:49693/home/signinuser";


        if ($("#username").val().trim() === "" || $("#password").val().trim() === "") {
            e.preventDefault();
            alert("Fill all fields before signing in..");
            return
        }

        //var data = {
        //    FirstName: "",
        //    LastName: "",
        //    Username: $("#username").val(),
        //    Password: $("#password").val(),
        //}        

        //$.ajax({
        //    type: "POST",
        //    url: actionUrl,
        //    dataType: 'json',
        //    data: data,

        //    success: (result) => {

        //        alert("Succesfuly signed in!");
        //        window.location.href = "Index";

        //        document.getElementById("signin-form").reset();
        //    },
        //    error: (jqXHR, textStatus, errorThrown) => {
        //        alert("Sign in failed. [" + jqXHR.status + " - " + jqXHR.responseText + "]");
        //        //alert("Sign in failed. [" + textStatus + " - " + errorThrown + "]");
        //        //error: function(xhr, status, error) {
        //        //    var err = eval("(" + xhr.responseText + ")");
        //        //    alert(err.Message);
        //        //}
        //    }
        //})
    })

    /* Register.cshtml */

    //$(document).ajaxStart(function () {
    //    $("#wait").css("display", "block");
    //});
    //$(document).ajaxComplete(function () {
    //    $("#wait").css("display", "none");
    //});

    $("#register-form").submit((e) => {
        e.preventDefault();

        var actionUrl = "http://localhost:49693/api/register"

        var data = {
            FirstName : $("#firstname").val().trim(),
            LastName : $("#lastname").val().trim(),
            Username : $("#username").val().trim(),
            Password : $("#password").val().trim(),
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
                window.location.href = "SignIn";

                document.getElementById("register-form").reset();
            },
            error: (jqXHR, textStatus, errorThrown) => {
                alert("Register failed. [" + jqXHR.status + " - " + jqXHR.statusText + "]");
            }
        })
    });

    // DETAILS BTN
    $(".btn-order-details").click((e) => {
        const id = $(e.currentTarget).data('idval');
        const sumprice = $(e.currentTarget).data('sumprice');

        var getUrl = "http://localhost:49693/api/orders/" + id;

        $.get(getUrl, (data, status) => {
            const orderId = $("#order-id");
            const meals = $("#meals");
            const drinks = $("#drinks");
            const price = $("#price");

            let orderIdData = data.Id;
            let drinksData = data.OrderedDrinks;
            let mealsData = data.OrderedMeals;

            meals.empty();
            drinks.empty();

            orderId.text("Order ID: " + orderIdData);

            mealsData.forEach((meal) => {
                let p = document.createElement("p");
                p.classList.add("meal");

                //p.innerText = "Burek(400g)";
                p.innerText = `${meal.Name} - ${meal.Quantity}g`;

                meals.append(p);
            })

            drinksData.forEach((drink) => {
                let p = document.createElement("p");
                p.classList.add("drink");

                p.innerText = `${drink.Name} - ${drink.Quantity}kom`;

                drinks.append(p);
            })

            price.text("Cena: " + sumprice + "din");

            $(".modal").css("display", "block");
        })
    })

    $(".close").click(() => {
        $(".modal").css("display", "none");
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
    else
    {
        return "";
    }
}

