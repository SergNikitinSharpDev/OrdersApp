$(document).ready(function () {
    $("#processOrdersBtn").click(processOrders);
});

function processOrders() {
    var selectedOrders = [];
    $.each($("input[name=select]:checked"), function () {
        selectedOrders.push($(this).val());
    });
    $.ajax({
        method: "POST",
        url: "/processOrders",
        data: { selectedOrdersIds: selectedOrders },
        success: function (data) {
            orders(data.Data);
        },
        error: errorHandler("#shipmentResult")
    });
}

function orders(model) {
    $.ajax({
        method: "POST",
        url: "/orders",
        data: { model },
        success: function (data) {
            $("#ordersResult").val(data.Json);
        },
        error: errorHandler("#ordersResult")
    });
}

function errorHandler(textAreaId) {
    return function (jqXHR) {
        $(textAreaId).val('Response: ' + jqXHR.status + '. ' + jqXHR.responseText);
    };
}