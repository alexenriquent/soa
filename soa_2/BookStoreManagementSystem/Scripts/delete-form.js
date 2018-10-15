$.fn.clearErrors = function () {
    $(this).each(function () {
        $(this).find(".field-validation-error").empty();
    });
};

$(function () {
    $("#index-textbox").val("");
    $("#attribute").change(function () {
        $("#index-message, #id-message, #year-message").clearErrors();
        $("#index-textbox, #id-textbox, #year-textbox").val("");
        var selectedValue = $(this).val();
        if (selectedValue == "index") {
            $("#index, #index-message").show();
            $("#id, #id-message, #year, #year-message").hide();
        } else if (selectedValue == "id") {
            $("#id, #id-message").show();
            $("#index, #index-message, #year, #year-message").hide();
        } else if (selectedValue == "year") {
            $("#year, #year-message").show();
            $("#index, #index-message, #id, #id-message").hide();
        }
    });
});