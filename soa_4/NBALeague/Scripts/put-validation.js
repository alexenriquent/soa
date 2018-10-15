$(document).ready(function () {

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var check = false;
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#put-form').validate({
        rules: {
            id: {
                required: true
            },
            firstname: {
                required: true
            },
            lastname: {
                required: true
            },
            team: {
                required: true
            },
            dob: {
                required: true,
                regex: /^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$/
            }
        },
        messages: {
            id: {
                required: "The field is required."
            },
            firstname: {
                required: "The field is required."
            },
            lastname: {
                required: "The field is required."
            },
            team: {
                required: "The field is required."
            },
            dob: {
                required: "The field is required.",
                regex: "Date of birth (yyyy-mm-dd) must be valid."
            }
        }
    })
});