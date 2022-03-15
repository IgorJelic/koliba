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

    // TO DO, odradi brisanje itema iz narudzbine



    $(".btn-order-details").click((e) => {
        const id = $(e.currentTarget).data('idval');

        var getUrl = "http://localhost:49693/api/orders/" + id;

        $.get(getUrl, (data, status) => {
            alert("Data: " + JSON.stringify(data) + "\nStatus: " + status);
        })
    })

    $("#myBtn").click(() => {
        $(".modal").css("display", "block");
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

