var inputNumber = 3
function AddComponent() {
    
    $('#AddComponent').append('<input name="RecipeComponents['+inputNumber+']" type="text" />');
    inputNumber++;
}
$(document).ready(function ()
{
    $('#Title').on('blur', function () {
        var title = $('#Title').val();
        checkRecipeTitleExist(title);
    });
});
