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

    //$(window).click((e) => {
    //    if (e.target.id !== "modal") {
    //        $(".modal").css("display", "none");
    //    }
    //})
})

