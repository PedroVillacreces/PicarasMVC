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
            $(".hidden-id").remove();
            $(".items-edit").append(
            '<input class="hidden-id" type="hidden" id=' + pc + '>');
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

$(".save-edit").on("click", function () {
    var pc = $("#quantity-edit").val();
    var id = $(".hidden-id").attr("id");
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Shopping/EditToCart",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { quantity: pc, id: id},
        success: function (d) {
            if (d === "Editado") {
                document.location.href = "/Shopping";
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus);
        }
    });
});
