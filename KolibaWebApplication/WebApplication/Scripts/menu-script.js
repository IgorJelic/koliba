$(document).ready(() => {

    $(".btn-add-meal").click((e) => {
        const id = $(e.currentTarget).data('idval');
        //const quantity = $(`#${id}`).val; OVDE NASTAVI
        var input = $(e.currentTarget).parent().children('span').children('input');
        //var span = td.children('span');
        //var input = span.children('input');

        const quantity = input.val();
        //alert('ID = ' + id + " Quantity = " + quantity);

        var actionUrl = "http://localhost:49693/api/meals/" + id;

        var calculatedQuantity = parseFloat(quantity) / 1000;

        $.getJSON(actionUrl, (result) => {
            var meal = {
                Id: result.Id,
                Name: result.Name,
                Price: result.Price,
                Quantity: result.Quantity
            };

            meal.Quantity = calculatedQuantity * 1000;
            var oldPrice = meal.Price;
            meal.Price = oldPrice * calculatedQuantity;
            alert("id: " + meal.Id + " name: " + meal.Name + " price: " + meal.Price + " quantity: " + meal.Quantity);

            var postUrl = "http://localhost:49693/orders/addmeal";

            $.post(postUrl, meal, (data, status, xhr) => {
                alert('Posted ' + JSON.stringify(meal));
            });
        })

    })

    $(".btn-add-drink").click((e) => {
        const id = $(e.currentTarget).data('idval');
        //alert(id);

    })

})