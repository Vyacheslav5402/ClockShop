function sortIsShopingCart(id, currentPage) {
    var actionUrl = '/clock/index?shoppingCart=true&id=' + id + '&currentPage=' + currentPage;
    console.log(actionUrl);

    $.ajax({
        url: actionUrl,
        success: function (result) {
            console.log(result);
            $('#indexTable').html(result);
        },
        beforeSend: function () {
            $('.lds-roller').show();
        },
        complete: function () {
            $('.lds-roller').hide();
        }
    });
}

function shopingCart(id) {
    var actionUrl = '/clock/buy?shoppingCart=true&id=' + id;
    console.log(actionUrl);

    $.ajax({
        url: actionUrl,
        success: function (result) {
            console.log(result);
            $('#buyTable').html(result);
        },
        beforeSend: function () {
            $('.lds-roller').show();
        },
        complete: function () {
            $('.lds-roller').hide();
        }
    });
}