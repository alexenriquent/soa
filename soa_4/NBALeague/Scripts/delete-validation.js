$(document).ready(function () {
    $('#delete-form').validate({
        rules: {
            value: {
                required: true
            }
        },
        messages: {
            value: {
                required: "The field is required.",
            }
        }
    })

    $("#delete-value").val("");
    $("#delete-attribute").change(function () {
        $("#delete-value").val("");
        $("#delete-form").validate().resetForm();
    });
});