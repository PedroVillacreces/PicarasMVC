$(".edit-to-cart").on("click", function () {
    var quantity = $("#Sizes").val();
    var size = $("#Quantity").val();
    var codeProduct = $("#ProductCode").val();
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Shopping/EditToCart",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { Size: "XL", Quantity: 2, ProductCode: 3 },
        success: function (d) {
            if (d === "Editado") {
                document.location.href = "/Shopping";
            }
            else {
                alert("Error al borrar el artículo, inténtelo de nuevo");
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus);
        }
    });
});
