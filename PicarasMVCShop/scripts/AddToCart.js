﻿$(".add-to-cart").on("click", function () {
    var quantity = $("#Sizes").val();
    var size = $("#Quantity").val();
    var codeProduct = $("#ProductCode").val();
        $.ajax({
            type: "POST",
            url: "http://localhost:52241/Shopping/AddtoCart",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { Size: "XL", Quantity: 3, ProductCode : 3 },
            success: function (d) {
               
            },
            error: function(xhr, textStatus, errorThrown) {
                console.log(textStatus);
            }
        });
});