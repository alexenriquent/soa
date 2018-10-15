$(document).ready(function () {
    $('#get-form').validate({
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

    $("#get-value").val("");
    $("#get-attribute").change(function () {
        $("#get-value").val("");
        $("#get-form").validate().resetForm();
    });
});