$(".finish-shopping").on("click",
    function () {
        var payment = $("input[name=Payment]:checked").val();
        switch (payment) {
            case "onsite":
                $("#onsitePayment").modal("show");
                break;
            case "bankTransfer":
                $("#bankPayment").modal("show");
                break;
        default:
        }

    });