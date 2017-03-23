$(document).ready(function () {
    var heightBestPanel = $('.category-menu-items').height();

    $('.best-recipes-left').css({ 'height': heightBestPanel, 'margin-top': -heightBestPanel });
    $('.best-recipes-right').css({ 'height': heightBestPanel, 'margin-top': -heightBestPanel });

    $('.DayName').css({
        "padding-left": 70,
        "padding-top": -(screen.width * 0.8) - screen.width
    });


    $('.MenuShow span:first-child img').click(function () {
        var divOnClick = $('#' + this.alt);
        var height = $('.category-menu-items').offset().top;
        if (divOnClick.hasClass('helpClass'))
        {
            hideBestMenuPanel(divOnClick);
        }
        else {
            moveDiv(divOnClick, height);
        }

    });

});
var moveDiv = function (divOnClick, heightTop) {
    var marginLeftSize = divOnClick.position().left - ($(window).width() - $('.category-menu-items').outerWidth()) / 2;
    var marginRightSize = divOnClick.offset().top - heightTop +divOnClick.height();
    divOnClick.css({ 'margin-top': -marginRightSize, 'margin-left': -marginLeftSize });
    divOnClick.addClass('helpClass');
    setTimeout(
        function () {
            showBestMenuPanel();
        }, 1950);

};

var showBestMenuPanel = function ()
{
    $('.best-recipes-left').addClass('hide-best-recipes-left');
    $('.best-recipes-right').addClass('hide-best-recipes-right');
}
var hideBestMenuPanel = function (divOnClick)
{
    $('.best-recipes-left').removeClass('hide-best-recipes-left');;
    $('.best-recipes-right').removeClass('hide-best-recipes-right');
    divOnClick.css({ 'margin-top': '0px', 'margin-left': '0px' });
    divOnClick.removeClass('asd');
    $('.best-recipes').remove();
    divOnClick.removeClass('helpClass');
}
 
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

