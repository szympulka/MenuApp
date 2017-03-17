function HideContainer() {
    $(".Container").css({
        "background-color": "rgba(205,205,205,0.6)",
        "height": screen.height,
        "pointer-events": "none"
    });
};

function AnswerTheQuestion(Id) {
    var urlAnswer = "ShowDetailsQuestion/" + Id;
    returnDataJson(urlAnswer).then(function (val) {
        console.log(LoadData(val));
    });

    HideContainer();
    var panel = $(".PopupPanel");
    panel.removeAttr("style");
    panel.css({
        "height": screen.height - 300,
        "width": screen.width - 300
    });
};
function LoadData(val) {
    $("#date").html("<b>" + val.DateQuestion + "</b>");
    $("#userQuestion").html(val.Question);
    $("#TitleQuestion").html(val.Title);

}
