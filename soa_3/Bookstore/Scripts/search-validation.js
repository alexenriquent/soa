$(document).ready(function () {
    $('#search-form').validate({
        rules: {
            value: {
                required: true,
                digits: true
            }
        },
        messages: {
            value: {
                required: "The field ID is required.",
                digits: "The field ID must be a string of digits."
            }
        }
    })

    $("#value").val("");
    $("#attribute").change(function () {
        $("#value").val("");
        $("#search-form").validate().resetForm();
        var selectedValue = $(this).val();
        if (selectedValue == "id") {
            $('#value').rules('add', {
                required: true,
                digits: true,
                messages: {
                    required: "The field ID is required.",
                    digits: "The field ID must be a string of degits."
                }
            });
            $("#value").rules("remove", "range");
        } else if (selectedValue == "name") {
            $('#value').rules('add', {
                required: true,
                messages: {
                    required: "The field Name is required."
                }
            });
            $("#value").rules("remove", "digits range");
        } else if (selectedValue == "author") {
            $('#value').rules('add', {
                required: true,
                messages: {
                    required: "The field Author is required."
                }
            });
            $("#value").rules("remove", "digits range");
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