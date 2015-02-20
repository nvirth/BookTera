
var cachedPagesNumbers = {};

$(function () {
    pagingInit();
});

function pagingInit() {

    // Activating paging - init

    $(".paging-div:not(.paging-deactive)").bind("click", pagingBookBlocks);
    $(".paging-edge:not(.paging-deactive)").bind("click", pagingBookBlocks);

    // Empty the cahce
    cachedPagesNumbers = {};

    // Place the requested page into the cache

    var actualPageNumber = parseInt($(".paging-actual").first().text().trim(), 10);
    cachedPagesNumbers[actualPageNumber] = 1;
}

function pagingBookBlocks(/*plusData*/) {

    var actualPageNumber = parseInt($(".paging-actual").first().text().trim(), 10);

    var pageNumber;
    if ($(this).hasClass("paging-previous"))
        pageNumber = actualPageNumber - 1;
    else if ($(this).hasClass("paging-next"))
        pageNumber = actualPageNumber + 1;
    else
        pageNumber = $(this).text().trim();

    // If already exist, we don't need any ajax request
    if (cachedPagesNumbers[pageNumber] == 1) {

        // Check if the cached content really exist
        var $cached = $(".books-paged#paging-" + pageNumber);
        if ($cached.length !== 0) {
            pagingAjaxSuccess($cached, pageNumber, actualPageNumber);
        } else {
            // Perheps an ajax request sent already. We're waiting 1 sec, after that we'll remove the cache
            setTimeout("removeFromCacheIf(" + pageNumber + ")", 1000);
        }
        return;
    }
    cachedPagesNumbers[pageNumber] = 1;

    var controller = $("#pagingControllerName").val();
    var action = $("#pagingActionName").val();

    var formData = $("FORM").not("#searchBoxForm").not("#loginBoxForm").not("#logoutForm").serialize();
    var formDataPost = formData === "" ? "" : "&" + formData;

    var queryStringData = getQueryString();
    var queryStringDataPost = queryStringData === "" ? "" : "&" + queryStringData;

    var ajaxPostData = "isPaging=true&pageNumber=" + pageNumber + queryStringDataPost + formDataPost;

    //if (typeof (plusData) !== "undefined")
    //    ajaxPostData += "&" + plusData;

    $.ajax({
        url: "/" + controller + "/" + action,
        type: "POST",
        dataType: "html",
        data: ajaxPostData,
        success: function (data) {
            var $data = $($.parseHTML(data)).filter('*');
            pagingAjaxSuccess($data, pageNumber, actualPageNumber);
        }
    });
}

function removeFromCacheIf(pageNumberIn) {
    var $cached = $(".books-paged#paging-" + pageNumberIn);
    if ($cached.length === 0) {
        cachedPagesNumbers[pageNumberIn] = 0;
        console.log("Remove from cache: " + pageNumberIn);
    }
};

function pagingAjaxSuccess($data, pageNumber, actualPageNumber) {
    var $dataSingle = $data.first().hide().appendTo($(".block-of-paged-books"));
    $dataSingle.stop(false, true);
    $(".books-paged#paging-" + actualPageNumber).fadeOut(DEFAULT_FADING_DURATION_HALF, function () {
        $dataSingle.fadeIn(DEFAULT_FADING_DURATION_HALF);
    });

    rebindPaging(pageNumber);
}

function rebindPaging(pageNumber) {

    // Activate

    $(".paging-actual").removeClass("paging-actual"); // old actual, it was p-deactive too
    $(".paging-deactive").removeClass("paging-deactive").bind("click", pagingBookBlocks);

    // Deactivate

    $(".paging-div").each(function () {
        var value = $(this).text().trim();
        if (value == pageNumber)
            $(this).addClass("paging-actual").addClass("paging-deactive").unbind("click");
    });

    var isFirst = $(".paging-actual").prev().length == 0;
    if (isFirst)
        $(".paging-previous").addClass("paging-deactive").unbind("click");

    var isLast = $(".paging-actual").next().length == 0;
    if (isLast)
        $(".paging-next").addClass("paging-deactive").unbind("click");
}
