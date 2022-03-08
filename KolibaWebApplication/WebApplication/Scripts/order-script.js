$(document).ready(() => {

    $("#btn-naruci").click(() => {
        if (confirm("Potvrdi narudzbinu.")) {

            const url = "http://localhost:49693/orders/createOrder";
            $.get(url);
            //$.get(url, (result) => {
            //    alert(result);
            //})
            window.location.href = "../Home/Index";
            //alert("Uspesno kreirana narudzbina");
        }
        else {
            return
        }
    })

})