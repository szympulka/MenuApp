$(document).ready(function () {

    var script = document.createElement('script');
    script.src = 'https://www.promisejs.org/polyfills/promise-6.1.0.js';
    document.head.appendChild(script);

    if (document.cookie.indexOf("AddIp=True") == -1) {
        document.cookie = "AddIp=True;";
        var browser = checkBrowser();
        var url = "Home/AddIp/";
        $.post(url + browser);
    }
});

function returnDataJson(urlAnswer) {

    var wait = new Promise(function (resolve, reject) {
        $.ajax({
            type: 'get',
            dateType: 'json',
            url: urlAnswer,
            success: function (val) {
                resolve(val);
            },
            error: function () {
                alert("coś nie śmiga");
            }
        });
    });
    return wait;
}

function checkRecipeTitleExist(title) {
    var Url = "CheckRecipeTitleExist/" + title;
    $.ajax({
        type: 'POST',
        url: Url,
        dataType: 'json',
        success: function (data) {
            TitleCheck(data);
        },
        error: function (data) {
            TitleCheck(data);
        }
    });

}
function checkBrowser() {
    if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
        return "Opera";
    }
    else if (navigator.userAgent.indexOf("Chrome") != -1) {
        return "Chrome";
    }
    else if (navigator.userAgent.indexOf("Safari") != -1) {
        return "Safari";
    }
    else if (navigator.userAgent.indexOf("Firefox") != -1) {
        return "Firefox";
    }
    else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
    {
        return "IE";
    }
    else {
        return "unknown";
    }
}