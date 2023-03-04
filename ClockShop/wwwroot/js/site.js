function showMore(currentPage, totalPages) {
    if (totalPages == 0) {
        totalPages = 2
    }

    if (currentPage > 0) {
        var asd = totalPages - currentPage + 1;
    }

    $.ajax({
        
        url: '/clock/index?isAjax=true&skipItems=0&currentPage='+asd,
        success: function (result) {
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
function pageNavigation(idPage) {

    $.ajax({

        url: '/clock/pageNavigation?currentPage=' + idPage,
        success: function (result) {
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