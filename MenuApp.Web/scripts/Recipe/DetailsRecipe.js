
function Like(id) {
    var Likes = $("#RecipeLikes :first-child");
    if (Likes.attr('class') == "Likes") {
        var valuep = Likes.text();
        valuep++;
        Likes.replaceWith("<div id=\"RecipeLikes\" class=\"UnLikes\">" + valuep+ "</div>");
        $.post("\"../../../LikeRecipe/\"", { Id: id });

    }
    else {
        var valuen = Likes.text();
        valuen --;
        Likes.replaceWith("<div id=\"RecipeLikes\" class=\"Likes\">" + valuen + "</div>");
        $.post("\"Recipe/RemoveLikeRecipe/\"", { Id: id });

    }
};