$("#Sizes").change(function() {
    var size = $("#Sizes").val();
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Item/GetQuantity",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { size: size },
        success: function (d) {
            $("#Quantity option").remove();
            for (var i = 0; i < d; i++) {
                $("#Quantity").append($('<option>',
                    {
                        value: i + 1,
                        text: i + 1
                    }));
            }
        },
        error: function(xhr, textStatus, errorThrown) {
            console.log(textStatus);
        }
    });

});