$(document).ready(function () {

    $('#purchase-form').validate({
        rules: {
            budget: {
                required: true,
                number: true,
                min: 0
            },
            "key[0]": {
                required: true,
                digits: true
            },
            "value[0]": {
                required: true,
                digits: true,
                min: 0
            }  
        },
        messages: {
            budget: {
                required: "The field Budget is required.",
                number: "The field Budget must be a number.",
                min: "The field Budget cannot be negative"
            },
            "key[0]": {
                required: "The field Book Number is required.",
                digits: "The field Book Number must be an integer."
            },
            "value[0]": {
                required: "The field Amount is required.",
                digits: "The field Amount must be an integer.",
                min: "The field Amount cannot be negative"
            }
        }
    })
});