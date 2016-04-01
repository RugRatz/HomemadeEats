// This JS file is SPECIFIC to just the Create modal as it targets that div item

$(document).ready(function () {

    // Access the Create button with jquery like this
    var createMealTypeLinkBtn = $("a[id='createMealTypeLinkBtn']");

    // Add html attributes to "a" tag createMealTypeLinkBtn 
    // Access the modal dialog using the ID (CreateMealTypeModalDialog) of the modal dialog
    createMealTypeLinkBtn.attr({ "href": "#CreateMealTypeModalDialog", "data-toggle": "modal", "data-backdrop": "static" });

    // Reset all values when the modal shows up
    // This DOESN'T WORK - probably need to do it with $('#CreateMealTypeModalDialog').on('hidden.bs.modal'...
    //createMealTypeLinkBtn.on('show.bs.modal', function () {
    //    alert("Modal show called");
    //    document.getElementById('CreateMealTypeModalDialogForm').reset();
    //    $('#mealTypeDropdown').focus();
    //    alert("reset modal!");
    //});

    //$('.btn-file :file').on('fileselect', function (event, numFiles, label) {
    //    //alert('onFileselect');
    //    var input = $(this).parents('.input-group').find(':text'),
    //        log = numFiles > 0 ? label : 'Upload an image.';
    //    //alert('input text ' + input.text);
    //    //alert('log ' + log);
    //    //alert("input: " + input);
    //    //alert(label);
    //});

});

$('#CreateMealTypeModalDialog').on('hidden.bs.modal', function () {
    //alert("hidding modal dialog");

    // reset the form by targetting the id of the form (CreateMealTypeModalDialogForm)
    $(this).find('#CreateMealTypeModalDialogForm')[0].reset();
});

// This is just for debugging
$('#createMealTypeLinkBtn').click(function () {
    //alert("createMealTypeLinkBtn has been clicked");
});

// This is for the Browse button & for setting the text field to the image selected
$(document).on('change', '.btn-file :file', function () {
    alert('onChange');
    var input = $(this),
        //numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val(); //.replace(/\\/g, '/').replace(/.*\//, '');
    //input.trigger('fileselect', [numFiles, label]);
    alert("label on change " + label);
    $("input[id='uploadImageBrowseReadonlyField']").val(label);
});

// logic for displaying the extra text box when user selects option "Other" in the dropdown
// Access the dropdown for the meal type by targetting the ID of the <select> tag like this
$('#mealTypeDropdown').change(
    function () {
        $('#mealTypeTxtBox').val($(this).val());
        alert("Dropdown option changed");
        if ($(this).val() == "Other") {
            //alert("Dropdown option is Other");
            $('#mealTypeTxtBox').removeClass('hidden');
            //$('#mealTypeTxtBox').fadeIn("3000");  //has no effect & doesn't work
            $('#mealTypeTxtBox').val("");
        }
        else {
            $('#mealTypeTxtBox').addClass('hidden');//.fadeOut("3000");
            //$('#mealTypeTxtBox').fadeOut("3000"); //doesn't work
        }
    }
);