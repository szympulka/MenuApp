var removeField = false;

$(document).ready(function () {

    addPromisejs();
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
        if (divOnClick.hasClass('helpClass')) {
            hideBestMenuPanel(divOnClick);
            removeBestRecipe();
          
        }
        else {
            downloadBestRecipes(document.title, this.alt);
            moveDiv(divOnClick, height);
   
        }

    });
    $('.find_box input').on("keyup", function () {
        if (this.value) {
            if (!removeField)
            {
                createFindField();
                removeField = true;
            }
            showFindField(this.value);
        }
        else {
            hidePanel();
        }
    });
});
var moveDiv = function (divOnClick, heightTop) {
    var marginLeftSize = divOnClick.position().left - ($(window).width() - $('.category-menu-items').outerWidth()) / 2;
    var marginRightSize = divOnClick.offset().top - heightTop + divOnClick.height();
    divOnClick.css({ 'margin-top': -marginRightSize, 'margin-left': -marginLeftSize });
    divOnClick.addClass('helpClass');
    setTimeout(
        function () {
            showBestMenuPanel();
        }, 1950);

};

var showBestMenuPanel = function () {
    $('.best-recipes-left').addClass('hide-best-recipes-left');
    $('.best-recipes-right').addClass('hide-best-recipes-right');
}
var hideBestMenuPanel = function (divOnClick) {
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

    if ($('.DayName').hasClass('hide_panel')) {
        $('.DayName').removeClass('hide_panel');
        $('.DayName').addClass('show_panel');
    }
    else {
        $('.DayName').addClass('hide_panel');
        $('.DayName').removeClass('show_panel');
    }

}

var addPromisejs = function () {
    var script = document.createElement('script');
    script.src = 'https://www.promisejs.org/polyfills/promise-6.1.0.js';
    document.head.appendChild(script);
}

var showBestRecipe = function (recipe, p) {
    var recipeObject;

    if (p == 0) {
        recipeObject = '#First';
    }
    if (p == 1) {
        recipeObject = "#Second";
    }
    else if (p == 2) {
        recipeObject = "#Third";
    }
    else if (p == 3) {
        recipeObject = "#Fourth";
    }

    setTimeout(
        function () {
            $(recipeObject + ' .descriptionRecipe').text(recipe.ShortDescription)
            $(recipeObject + ' .titleRecipe').text(recipe.Title)
            $(recipeObject + ' .unlikesRecipe').text('DisLikes:' + recipe.RecipeDisLikes)
            $(recipeObject + ' .countCommentRecipe').text('Comments:' + recipe.CountComments)
            $(recipeObject + ' .likesRecipe').text('Likes:' + recipe.RecipeLikes)
            // $(recipeObject + ' .dateAddedRecipe').text(recipe.DateAdded)

        }, 3000);
}
var removeBestRecipe = function () {
    $('.descriptionRecipe').empty()
    $('.titleRecipe').empty()
    $('.unlikesRecipe').empty()
    $('.countCommentRecipe').empty()
    $('.likesRecipe').empty()
    $('.dateAddedRecipe').empty()

}

var downloadBestRecipes = function (title, category) {
    var url = "Recipe/BestFourRecipes/" + title + '/' + category;
    returnDataJson(url).then(function (val) {
        setTimeout(
            function () {
                for (var p in val) {

                    showBestRecipe(val[p], p)

                }
            }, 4150);
    });

}

var showFindField = function (value) {
    $('.find_result').removeAttr('style');
    $('.recipe_result').empty();
    $('.category_result').empty();
    $('.category_result').append('<div style="width:75%;">chucucucuucucuuu</div>')
    findRecipes(value);
    findCategories(value);

}

var hidePanel = function () {
    $('.recipe_result').empty();
    $('.category_result').empty();
    $('.find_result').css('display', 'none');
    removeField == false;
    removeFindField();
}
var findRecipes = function (value) {

    var url = "Recipe/FindRecipesByAjax/" + value;
    returnDataJson(url).then(function (val) {
        for (var p in val) {
            $('.recipe_result').append('<div class="ajaxResult">' + val[p].Title + '</div>');

      //      console.log(val[p].Title);
        }
    });
}
var findCategories = function (value) {
    var url = "Recipe/FindCategoryByAjax/" + value;
    returnDataJson(url).then(function (val) {
        for (var p in val)
            $('.category_result').append('<div class="ajaxResultCategory">' + val[p].Cuisine + '</div>');
    //    console.log(val[p].Cuisine);
    });
}
var createFindField = function () {
    $('.find_section').after('<div class="find_result_panel"><div class="recipe_result"></div> <div class="category_result"></div></div>');
    //<div class="find_result_panel">
    //    <div class="recipe_result">
    //    </div>
    //    <div class="category_result">
    //    </div>
    //</div>
}
var removeFindField = function ()
{
    $('.find_result_panel').remove();
}