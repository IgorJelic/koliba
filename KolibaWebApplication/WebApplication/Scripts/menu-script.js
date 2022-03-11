$(document).ready(() => {

    $(".btn-add-meal").click((e) => {
        const id = $(e.currentTarget).data('idval');
        var input = $(e.currentTarget).parent().children('span').children('input');

        const quantity = input.val();
        //alert('ID = ' + id + " Quantity = " + quantity);

        if (quantity === "0") {
            alert("Odaberite kolicinu!");
            return
        }

        var actionUrl = "http://localhost:49693/api/meals/" + id;

        //var calculatedQuantity = parseFloat(quantity) / 1000;

        $.getJSON(actionUrl, (result) => {
            var meal = {
                Id: result.Id,
                Name: result.Name,
                Price: result.Price,
                Quantity: result.Quantity
            };

            meal.Quantity = quantity;
            var oldPrice = meal.Price;
            meal.Price = oldPrice * quantity / 1000;
            //alert("id: " + meal.Id + " name: " + meal.Name + " price: " + meal.Price + " quantity: " + meal.Quantity);

            var postUrl = "http://localhost:49693/orders/addmeal";

            $.post(postUrl, meal, (data, status, xhr) => {
                input.val(0);
                //alert('Posted meal ' + JSON.stringify(meal));
            });

            window.location.href = "Index";
        })

    })

    $(".btn-add-drink").click((e) => {
        const id = $(e.currentTarget).data('idval');
        var input = $(e.currentTarget).parent().children('span').children('input');

        const quantity = input.val();

        if (quantity === "0") {
            alert("Odaberite kolicinu!");
            return
        }

        var actionUrl = "http://localhost:49693/api/drinks/" + id;

        $.getJSON(actionUrl, (result) => {
            var drink = {
                Id: result.Id,
                Name: result.Name,
                Price: result.Price,
                Quantity: result.Quantity
            };

            drink.Quantity = quantity;
            var oldPrice = drink.Price;
            drink.Price = oldPrice * quantity;

            //alert("id: " + drink.Id + " name: " + drink.Name + " price: " + drink.Price + " quantity: " + drink.Quantity);

            var postUrl = "http://localhost:49693/orders/adddrink";

            $.post(postUrl, drink, (data, status, xhr) => {
                input.val(0);
                //alert('Posted drink ' + JSON.stringify(drink));
            });

            window.location.href = "Index";
        })

    })

})