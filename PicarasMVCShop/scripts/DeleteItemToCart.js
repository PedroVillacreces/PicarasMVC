$(".remove-to-cart").on("click", function () {
    alert("¿Confirma que desea borrar el producto de cesta de compra?")
    var quantity = $("#Sizes").val();
    var size = $("#Quantity").val();
    var codeProduct = $("#ProductCode").val();
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Shopping/RemoveToCart",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { Size: "XL", Quantity: 3, ProductCode: 3 },
        success: function (d) {
            if (d == "Borrado") {
                document.location.href = '/Shopping';
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
   