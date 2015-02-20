
// Init all AutoComplete widgets on the site
$(function () {

    // SearchBox (on layout)
    var searchBoxAutoCompleteCache = {};
    createAutoComplete(
        searchBoxAutoCompleteCache,             // cache
        "#searchBoxText",					    // itemSelector
        "../Search/ProductGroupAutoComplete",	// sourceUrl
        "searchBoxText",					    // dataFieldName
        "",                                     // additionalData
        "../Product/Details?friendlyUrl=",	    // redirectUrl
        false                                   // autoFocus
    );

    // Registration -> I'm an author
    if (($("#registration-auto-completes-on").length != 0) && ($("#AuthorName").length != 0)) {
        var registrationAuthorNameAutoCompleteCache = {};
        createAutoComplete(
            registrationAuthorNameAutoCompleteCache,    // cache
            "#AuthorName",				        	    // itemSelector
            "../Search/AuthorAutoComplete",     	    // sourceUrl
            "authorName"        					    // dataFieldName
        );
    }

    // Registration -> I'm a publisher
    if (($("#registration-auto-completes-on").length != 0) && ($("#PublisherName").length != 0)) {
        var registrationPublisherNameAutoCompleteCache = {};
        createAutoComplete(
            registrationPublisherNameAutoCompleteCache,     // cache
            "#PublisherName",                               // itemSelector
            "../Search/PublisherAutoComplete",              // sourceUrl
            "publisherName"        					        // dataFieldName
        );
    }

    // ProductUpload -> AuthorNames
    if (($("#product-upload-auto-completes-on").length != 0) && ($("#ProductGroup_AuthorNames").length != 0)) {
        var productUploadAuthorNamesAutoCompleteCache = {};
        createMultipleValueAutoComplete(
            productUploadAuthorNamesAutoCompleteCache,      // cache
            "#ProductGroup_AuthorNames",                    // itemSelector
            "../Search/AuthorAutoComplete",                 // sourceUrl
            "authorName",        					        // dataFieldName
            "&withPlainValue=true"                          // additionalData
        );
    }

    // ProductUpload -> PublisherName
    if (($("#product-upload-auto-completes-on").length != 0) && ($("#ProductGroup_PublisherName").length != 0)) {
        var productUploadPublisherNameAutoCompleteCache = {};
        createAutoComplete(
            productUploadPublisherNameAutoCompleteCache,      // cache
            "#ProductGroup_PublisherName",                    // itemSelector
            "../Search/PublisherAutoComplete",                // sourceUrl
            "publisherName",        					      // dataFieldName
            "&withPlainValue=true"                            // additionalData
        );
    }

});

function createAutoComplete(cache, itemSelector, sourceUrl, dataFieldName, additionalData, redirectUrl, autoFocus, delay, minLength) {

    // Set default values

    if (typeof (dataFieldName) === 'undefined') dataFieldName = "value";
    if (typeof (additionalData) === 'undefined') additionalData = "";
    if (typeof (autoFocus) === 'undefined') autoFocus = false;
    if (typeof (delay) === 'undefined') delay = 200;
    if (typeof (minLength) === 'undefined') minLength = 2;

    $(itemSelector).autocomplete({
        //------------------------------------
        source: function (request, response) {

            // If already cached
            if (request.term in cache) {
                response(cache[request.term]);
                return;
            }

            // If not cached
            $.ajax({
                url: sourceUrl,
                type: "POST",
                dataType: "json",
                data: dataFieldName + "=" + request.term + additionalData,
                success: function (data) {
                    cache[request.term] = data;
                    response(data);
                }
            });
        },
        //------------------------------------
        select: function (event, ui) {
            event.preventDefault();
            $(itemSelector).val(ui.item.label);
            if (redirectUrl)
                window.location.href = redirectUrl + ui.item.value;

            return false;
        },
        autoFocus: autoFocus,
        delay: delay,
        minLength: minLength
    })
    .data("ui-autocomplete")._renderItem = function (ul, item) {
        var itemLabel = "<font size=\"1\">" + item.label + "</font>";

        return $("<li>")
        .append("<a>" + itemLabel + "</a>")
        .appendTo(ul);
    };
}

function createMultipleValueAutoComplete(cache, itemSelector, sourceUrl, dataFieldName, additionalData, minLength) {
    $(itemSelector)
    // don't navigate away from the field on tab when selecting an item
    .bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
        $(this).data("ui-autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    .autocomplete({
        source: function (request, response) {
            var requestTermLast = request.term.split(/,\s*/).pop();

            // If already cached
            if (requestTermLast in cache) {
                response(cache[requestTermLast]);
                return;
            }

            // If not cached
            $.ajax({
                url: sourceUrl,
                type: "POST",
                dataType: "json",
                data: dataFieldName + "=" + requestTermLast + additionalData,
                success: function (data) {
                    cache[requestTermLast] = data;
                    response(data);
                }
            });
        },
        search: function () {
            // custom minLength
            var term = this.value.split(/,\s*/).pop();
            if (term.length < minLength) {
                return false;
            }
            return true;
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var terms = this.value.split(/,\s*/);
            // remove the current input
            terms.pop();
            // add the selected item
            terms.push(ui.item.value);
            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join(", ");
            return false;
        }
    })
    .data("ui-autocomplete")._renderItem = function (ul, item) {
        var itemLabel = "<font size=\"1\">" + item.label + "</font>";

        return $("<li>")
        .append("<a>" + itemLabel + "</a>")
        .appendTo(ul);
    };
}