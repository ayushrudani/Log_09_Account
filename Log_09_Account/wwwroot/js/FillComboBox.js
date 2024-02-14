/***********************************************************
 * Fill State Dropdown By Country
 * @param {number} CountryID Required for Filter.
 * @param {string} comboboxSelector Required for filling combobox on this selector.
 ***********************************************************/
function Fn_FillStateDropdownByCountryID(CountryID, comboboxSelector, DataValueField, DataTextField) {
    //Set Input Here
    url = "/CommonFillMethods/FillStateDropdownByCountryID?CountryID=" + CountryID;

    if (CountryID !== "") {

        Fn_CommonAjax_FillCombobox(url, comboboxSelector, DataValueField, DataTextField);

        //Fix Common Code -----------------------------
        //$(comboboxSelector).empty();
        //$(comboboxSelector).append($("<option></option>").val("").html("--"));
        //$.ajax(
        //    {
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        url: url,
        //        data: {},
        //        dataType: "json",
        //        success: function (Result) {
        //            $.each(Result,
        //                function (key, value) {
        //                    $(comboboxSelector).append($("<option></option>").val(value.itemValue)
        //                        .html(value.itemText));
        //                });
        //            $(comboboxSelector).trigger('change');
        //        },
        //        error: function (r) {
        //            alert("Error while loading combobox.");
        //        }
        //    });
        //--------------------------------------------
    } else {
        $(comboboxSelector).empty();
        $(comboboxSelector).append($("<option></option>").val("").html("--"));
        $(comboboxSelector).trigger('change');
        //alert('Please select valid Country.');
    }
}


/***********************************************************
 * Fill City Dropdown By State
 * @param {number} StateID Required for Filter.
 * @param {string} comboboxSelector Required for filling combobox on this selector.
 ***********************************************************/
function Fn_FillCityDropdownByStateID(StateID, comboboxSelector) {
    //Set Input Here
    url = "/CommonFillMethods/FillCityDropdownByStateID?StateID=" + StateID;

    if (StateID !== "") {

        Fn_CommonAjax_FillCombobox(url, comboboxSelector, "stateID", "stateName");

        //Fix Common Code -----------------------------
        //$(comboboxSelector).empty();
        //$(comboboxSelector).append($("<option></option>").val("").html("--"));
        //$.ajax(
        //    {
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        url: url,
        //        data: {},
        //        dataType: "json",
        //        success: function (Result) {
        //            $.each(Result,
        //                function (key, value) {
        //                    $(comboboxSelector).append($("<option></option>").val(value.itemValue)
        //                        .html(value.itemText));
        //                });
        //        },
        //        error: function (r) {
        //            alert("Error while loading combobox.");
        //        }
        //    });
        //--------------------------------------------
    } else {
        $(comboboxSelector).empty();
        $(comboboxSelector).append($("<option></option>").val("").html("--"));
        //alert('Please select valid State.');
    }
}


function Fn_CommonAjax_FillCombobox(url, comboboxSelector, DataValueField, DataTextField) {
    $(comboboxSelector).empty();
    $(comboboxSelector).append($("<option></option>").val("").html("--"));
    $.ajax(
        {
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: url,
            data: {},
            dataType: "json",
            success: function (Result) {
                $.each(Result,
                    function (key, value) {
                        $(comboboxSelector).append($("<option></option>").val(value[DataValueField])
                            .html(value[DataTextField]));
                    });
            },
            error: function (r) {
                alert("Error while loading combobox.");
            }
        });
}