$(function () {

    // Category - DropDownList

    var classDropDown = ".category-list";
    var classHidden = classDropDown + "-hidden";

    $.ajax({
        type: "POST",
        url: "/Category/GetCategoryListJson",
        dataType: "json",
        data: "selectedId=" + $(classHidden).val(),
        success: function (data) {
            $(classDropDown).fillSelect(data);
        }
    });
    
    // Submit Button - Ajax

    $("#btnDetailedSearch").bind("click", function () {
        $.ajax({
            type: "POST",
            url: "/Search/Detailed",
            dataType: "html",
            data: $("#detailedSearch").serialize(),
            success: function (data) {
                var $dataHtml = $($.parseHTML(data)).filter('*');
                $(".detailed-search-results").html($dataHtml).hide().slideDown(DEFAULT_TOGGLE_DURATION);

                // Init/ReInit paging
                pagingInit();
            }
        });
    });
});