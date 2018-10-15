$(function () {
    $("#index-textbox").val("");
    $("#attribute").change(function () {
        $("#index-textbox, #id-textbox, #year-textbox").val("");
        $("#delete-form").validate().resetForm();
        var selectedValue = $(this).val();
        if (selectedValue == "index") {
            $("#index").show();
            $("#id, #year").hide();
        } else if (selectedValue == "id") {
            $("#id").show();
            $("#index, #year").hide();
        } else if (selectedValue == "year") {
            $("#year").show();
            $("#index, #id").hide();
        }
    });
});