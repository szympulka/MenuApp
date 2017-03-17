var inputNumber = 4;
function AddComponent() {
    
    $('#AddComponent').append('<input name="Components['+inputNumber+'].Name" type="text" />');
    inputNumber++;
}
$(document).ready(function ()
{
    $('#Title').on('blur', function () {
        var title = $('#Title').val();
        checkRecipeTitleExist(title);
    });
});
