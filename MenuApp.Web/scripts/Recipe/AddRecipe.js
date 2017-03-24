function TitleCheck(data) {

    var titleInfo = $('#TitleInfo');
    titleInfo.css('display','');
    if (data == "True") {       
        titleInfo.removeClass();
        titleInfo.addClass("TitleInfoOk");
    } else {
        titleInfo.removeClass();
        titleInfo.addClass("TitleInfoWrong");
    }
}
$(document).ready(function () {

    var script = document.createElement('script');
    script.src = 'https://www.promisejs.org/polyfills/promise-6.1.0.js';
    document.head.appendChild(script);
});