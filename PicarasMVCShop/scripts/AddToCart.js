$(".add-to-cart").on("click", function () {
    var quantity = $("#Quantity").val();
    var size = $("#Sizes").val();
    var productCode = $("#Id").val();
    var codeProduct = $("#ProductCode").val();
        $.ajax({
            type: "POST",
            url: "http://localhost:52241/Shopping/AddtoCart",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { Size: size, Quantity: quantity, ProductCode: productCode },
            success: function (d) {
                $("#item-counter").val(d);
                sessionStorage.setItem("counter", d);
                var counter = sessionStorage.getItem("counter");
                $("#item-counter").text(d);
                document.location.href = "/";
            },
            error: function(xhr, textStatus, errorThrown) {
                console.log(textStatus);
            }
        });
});