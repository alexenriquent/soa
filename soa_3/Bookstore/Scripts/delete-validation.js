$(document).ready(function () {
    $('#delete-form').validate({
        rules: {
            value: {
                required: true,
                digits: true
            }
        },
        messages: {
            value: {
                required: "The field Index is required.",
                digits: "The field Index must be an integer."
            }
        }
    })

    $("#value").val("");
    $("#attribute").change(function () {
        $("#value").val("");
        $("#delete-form").validate().resetForm();
        var selectedValue = $(this).val();
        if (selectedValue == "index") {
            $('#value').rules('add', {
                required: true,
                digits: true,
                messages: {
                    required: "The field Index is required.",
                    digits: "The field Index must be an integer."
                }
            });
            $("#value").rules("remove", "range");
        } else if (selectedValue == "id") {
            $('#value').rules('add', {
                required: true,
                digits: true,
                messages: {
                    required: "The field ID is required.",
                    digits: "The field ID must be a string of degits."
                }
            });
            $("#value").rules("remove", "range");
        } else if (selectedValue == "year") {
            $('#value').rules('add', {
                required: true,
                digits: true,
                range: [1000, 9999],
                messages: {
                    required: "The field Year is required.",
                    digits: "The field Year must be an integer.",
                    range: "The field Year must be a 4-digit integer."
                }
            });
        }
    });
});