$(".finish-shopping").on("click",
    function() {
        var payment = $("input[name=Payment]:checked").val();
        console.log(payment);

    });