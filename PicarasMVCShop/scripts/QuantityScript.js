$("#Sizes").change(function() {
    var size = $("#Sizes").val();
    var pc = $("#pc").val();
    $.ajax({
        type: "POST",
        url: "http://localhost:52241/Item/GetQuantityBySize",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: { pc: pc, size: size },
        success: function (d) {
            $("#Quantity option").remove();
            $("#Id").val(d.Id);
            for (var i = 0; i < d.Quantity; i++) {
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