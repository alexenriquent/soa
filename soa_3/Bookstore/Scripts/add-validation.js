$(document).ready(function () {
    $('#add-form').validate({
        rules: {
            id: {
                required: true,
                digits: true
            },
            name: {
                required: true
            },
            author: {
                required: true
            },
            year: {
                required: true,
                digits: true,
                range: [1000, 9999]
            },
            price: {
                required: true,
                number: true,
                min: 0
            },
            stock: {
                required: true,
                digits: true,
                min: 0
            }
        },
        messages: {
            id: {
                required: "The field ID is required.",
                digits: "The field ID must be a string of digits."
            },
            name: {
                required: "The field Name is required."
            },
            author: {
                required: "The field Author is required."
            },
            year: {
                required: "The field Year is required.",
                digits: "The field Year must be an integer.",
                range: "The field Year must be a 4-digit integer."
            },
            price: {
                required: "The field Price is required.",
                number: "The field Price must be a number.",
                min: "The field Price cannot be negative"
            },
            stock: {
                required: "The field Stock is required.",
                digits: "The field Stock must be an integer.",
                min: "The field Stock cannot be negative"
            }
        }
    })

    $("#cancel").click(function () {
        $("#form").validate().resetForm();
    });
});