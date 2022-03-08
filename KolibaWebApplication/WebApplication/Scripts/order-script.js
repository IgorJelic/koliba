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