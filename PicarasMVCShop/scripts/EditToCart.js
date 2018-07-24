$(".edit-to-cart").on("click", function () {
    var pc = $(this).attr("id");
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Item/GetQuantity",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { ProductCode: pc},
        success: function (d) {
            $("#quantity-edit option").remove();
            for (var i = 0; i < d; i++) {
                $("#quantity-edit").append($('<option>',
                    {
                        value: i + 1,
                        text: i + 1
                    }));
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus);
        }
    });
});
