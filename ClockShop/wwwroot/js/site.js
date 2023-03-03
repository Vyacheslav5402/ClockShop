function showMore(currentPage, totalPages) {
    debugger;
    if (currentPage > 0) {
        var asd = totalPages - currentPage

    }
    $.ajax({
        
        url: '/clock/index?isAjax=true&skipItems=0&currentPage='+asd ,
        success: function (result) {
            debugger;

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
    console.log(1);


}