var InitMain = function () {
    return {
        //main function to initiate the module
        init: function () {
            UI_DateTime_Pickers.init();
            //UI_Data_Mask.init();
            UI_Select2.init();
            //UI_TinyMCE.init();

            //Other small function
            $('form').each(function () {
                $(this).attr('autocomplete', 'off');
            });
        }
    };

}();

$(document).ready(function () {
    InitMain.init();
});

$(document).ajaxStart(function () {

    funBlockUI();

}).ajaxStop(function () {

    funUnblockUI();

    InitMain.init();



    //For validating Form in Modal
    $.validator.unobtrusive.parse($("form"));


    //if (typeof fn_redirectToLogout !== 'undefined' && $.isFunction(fn_redirectToLogout)) {
    if (typeof fn_redirectToLogout !== 'undefined') {
        //execute it

        // similar behavior as an HTTP redirect
        //window.location.replace("http://stackoverflow.com");

        // similar behavior as clicking on a link
        //window.location.href = "http://stackoverflow.com";
    }

});