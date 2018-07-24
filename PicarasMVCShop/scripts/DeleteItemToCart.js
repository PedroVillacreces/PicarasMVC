$(".remove-to-cart").on("click", function () {
    confirm("¿Confirma que desea borrar el producto de cesta de compra?");
    var id1 = $(this).closest("tr");
    var qa = id1.children(".qa").text();
    var size = id1.children(".size").text();
    var pc = id1.children(".pc").children(".remove-to-cart").attr("id");
    //
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Shopping/RemoveToCart",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { Size: size, Quantity: qa, ProductCode: pc },
        success: function (d) {
            if (d === "Borrado") {                
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
   