$(document).ready(function () {


    $('.DayName').css({
        "padding-left": 70,
        "padding-top": -(screen.width * 0.8) - screen.width
    });

});
function burger(x) {

    var dayName = $('.DayName')
    x.classList.toggle("change");
    var burgermenu = $('.burger-menu');
    burgermenu.toggle("slow");

    if ($('.DayName').hasClass('hide_panel'))
    {
        $('.DayName').removeClass('hide_panel');
        $('.DayName').addClass('show_panel');
    }
    else
    {
        $('.DayName').addClass('hide_panel');
        $('.DayName').removeClass('show_panel');
    }
    
}
