function TitleCheck(data){
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