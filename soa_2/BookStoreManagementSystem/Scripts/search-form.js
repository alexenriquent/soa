$.fn.clearErrors = function () {
    $(this).each(function () {
        $(this).find(".field-validation-error").empty();
    });
};

$(function () {
    $("#attribute").change(function () {
        $("#id-message, #name-message, #author-message, #year-message").clearErrors();
        $("#id-textbox, #name-textbox, #author-textbox, #year-textbox").val("");
        var selectedValue = $(this).val();
        if (selectedValue == "id") {
            $("#id, #id-message").show();
            $("#name, #name-message, #author, #author-message, #year, #year-message").hide();
        } else if (selectedValue == "name") {
            $("#name, #name-message").show();
            $("#id, #id-message, #author, #author-message, #year, #year-message").hide();
        } else if (selectedValue == "author") {
            $("#author, #author-message").show();
            $("#id, #id-message, #name, #name-message, #year, #year-message").hide();
        } else if (selectedValue == "year") {
            $("#year, #year-message").show();
            $("#id, #id-message, #name, #name-message, #author, #author-message").hide();
        }
    });
});