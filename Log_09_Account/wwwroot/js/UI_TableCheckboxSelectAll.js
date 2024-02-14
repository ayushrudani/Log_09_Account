//Initialize Checkbox Select-All functionality
$(document).on("click", ".check-all", function () {
    //console.log('.check-all clicked');

    var parent = $(this).parents(".js-table-checkbox");
    var chkAll = this;
    var chkRows = $(parent).find(".check-row");
    chkRows.each(function () {
        $(this)[0].checked = chkAll.checked;
    });

    var chkdata = "";

    chkRows.each(function () {
        if ($(this).is(':checked')) {
            chkdata = chkdata + "," + $(this).attr('id');
        }
    });

    chkdata = chkdata.substring(1);
    // Update Value to Target
    var target = $(chkAll).attr("data-target");
    var targetArray = target.split(",");
    for (var i = 0; i < targetArray.length; i++) {
        $(targetArray[i]).val(chkdata).trigger('change');
    }

});


$(document).on("click", ".check-row", function () {
    var parent = $(this).parents(".js-table-checkbox");
    var chkAll = $(parent).find(".check-all");

    var chkRows = $(parent).find(".check-row");

    var vCheckAll = true;
    chkRows.each(function () {
        if (!$(this).is(":checked")) {
            vCheckAll = false;
        }
    });

    chkAll.prop('checked', vCheckAll);

    var chkdata = "";

    chkRows.each(function () {
        if ($(this).is(':checked')) {
            chkdata = chkdata + "," + $(this).attr('id');
        }
    });
    chkdata = chkdata.substring(1);

    // Update Value to Target
    var target = $(chkAll).attr("data-target");
    var targetArray = target.split(",");
    for (var i = 0; i < targetArray.length; i++) {
        $(targetArray[i]).val(chkdata).trigger('change');
    }
});


//Check IF CheckList IsNull
$(document).on("click", ".btn-checkList-submit", function () {
    var CheckedList = $(this).parents("form").find('[name="CheckedList"]').attr("value");

    if (CheckedList == "") {
        bootbox.alert("Please <b>check atleat one</b> record from List.");
    } else {
        var itemCount = CheckedList.split(',').length;
        var id = $(this).attr("id");

        if ($(this).attr("data-callback") == "true") {
            OnCheckedSuccess(id, itemCount);
        } else {
            $("#" + id).parent("form").submit();
        }
    }
});





