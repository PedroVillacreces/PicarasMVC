$(".category").on("click", function() {
        $.ajax({
            type: "GET",
            url: "http://localhost:52241/Categories/Index",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { Size: "XL", Quantity: 3, ProductCode : 3 },
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