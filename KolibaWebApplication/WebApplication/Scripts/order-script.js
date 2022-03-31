$(document).ready(() => {

    $("#btn-naruci").click(() => {
        if (confirm("Potvrdi narudzbinu.")) {
            var url = "http://localhost:49693/orders/createOrder/";

            const dostava = $("#dostava").val();
            if (dostava === "Ne") {
                url += "?delivery=No";
            }
            else {
                url += "?delivery=Yes";
            }

            $.get(url);

            window.location.href = "../Home/Index";
        }
        else {
            return
        }
    })

    // TO DO, odradi brisanje itema iz narudzbine

    $(".delete-meal").click((e) => {
        const mealName = $(e.currentTarget).data('mealname');

        var actionUrl = "http://localhost:49693/orders/removemeal?mealName=" + mealName;

        $.get(actionUrl);

        var millisecondsToWait = 100;
        setTimeout(function () {
            window.location.href = "/Orders/Index";
        }, millisecondsToWait);

    })

    $(".delete-drink").click((e) => {
        const drinkName = $(e.currentTarget).data('drinkname');

        var actionUrl = "http://localhost:49693/orders/removedrink?drinkName=" + drinkName;

        $.get(actionUrl);

        var millisecondsToWait = 100;
        setTimeout(function () {
            window.location.href = "/Orders/Index";
        }, millisecondsToWait);
    })


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

    $(".shipping-area,.shipping-truck").on('dragover', function (e) {
        $(".shipping-area").css({
            "background-color": "#303030"
            //background-color: #303030;
        });
        $(".shipping-truck").css({
            "transform": "skewX(-10deg)"
            //transform: skewX(-10deg);
        });
    });

    $(".shipping-area,.shipping-truck").on('dragleave', function (e) {
        $(".shipping-area").css({
            "background-color": "#232323"
            //background-color: #303030;
        });
        $(".shipping-truck").css({
            "transform": "skewX(0deg)"
            //transform: skewX(-10deg);
        });
    });
})

function allowDrop(ev) {
    ev.preventDefault();


}

function drag(ev) {
    var id = $(ev.currentTarget).data("id");
    ev.dataTransfer.setData("text", id);
    console.log("ID = " + id);
}

function dropFunction(ev) {
    if (confirm("Potvrdi dostavljanje.")) {
        ev.preventDefault();

        var id = ev.dataTransfer.getData("text");

        var patchUrl = "http://localhost:49693/api/updateorder/" + id;


        $.ajax({
            method: "PATCH",
            url: patchUrl,

            success: (response, textStatus, jqXhr) => {
                //alert(jqXhr.responseText);
            },
            error: (jqXHR, textStatus, errorThrown) => {
                alert("The following error occured: " + textStatus, errorThrown);
            },
            complete: () => {
                console.log("Patch completed!");
            }
        })

        var element = $(`#${id}`);

        element.attr('draggable', false);

        element.children('td')[0].style = "font-size:1.9rem; font-weight:bold; color:greenyellow";
        element.children('td')[3].innerHTML = 'Yes';
        element.children('td')[3].style = 'text-align:center; color:greenyellow';

        $("#table-delivered").append(element);

    }

    
    // REMOVE STYLES
    $(".shipping-area").css({
        "background-color": "#232323"
    });
    $(".shipping-truck").css({
        "transform": "skewX(0deg)"
    });
}