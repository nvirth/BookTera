$(function () {

    // ProductGroup - DropDownList

    var productGroupDropDownClass = ".product-group-list";
    var productGroupHiddenClass = productGroupDropDownClass + "-hidden";
    var $productGroupDropDown = $(productGroupDropDownClass);

    $.ajax({
        type: "POST",
        url: "/Sell/GetProductGroupListJson",
        dataType: "json",
        data: "selectedId=" + $(productGroupHiddenClass).val(),
        success: function (data) {
            $productGroupDropDown.fillSelect(data);
        }
    });

    // Category - DropDownList

    var categoryDropDownClass = ".category-list";
    var categoryHiddenClass = categoryDropDownClass + "-hidden";

    $.ajax({
        type: "POST",
        url: "/Category/GetCategoryListJson",
        dataType: "json",
        data: "selectedId=" + $(categoryHiddenClass).val(),
        success: function (data) {
            $(categoryDropDownClass).fillSelect(data);
        }
    });

    // ProductGroup - Select existing ID or create new

    $productGroupDropDown.bind("change", function () {
        var $productGroupDataDiv = $productGroupDropDown.parent("DIV").siblings(".product-upload-product-group-datas");
        var $selectedOption = $productGroupDropDown.children(":selected");
        var $productGroupNameHidden = $productGroupDropDown.siblings(".product-group-name-hidden");

        var selectedOptionValue = $selectedOption.val();
        var isNotInList = selectedOptionValue === "-1";
        var isAtChoose = selectedOptionValue === "";
        if (isNotInList || isAtChoose) {
            $productGroupDataDiv.fadeIn(DEFAULT_TOGGLE_DURATION);
            $productGroupNameHidden.val("");
        } else {
            $productGroupDataDiv.fadeOut(DEFAULT_TOGGLE_DURATION);
            $productGroupNameHidden.val($selectedOption.text().trim());

            // Ha volt beírva adat, azt töröljük

            $("INPUT", $productGroupDataDiv).val("");
            $("TEXTAREA", $productGroupDataDiv).val("");
            var $categoryIdSelect = $("SELECT", $productGroupDataDiv);
            $categoryIdSelect.val("");
            $categoryIdSelect.children().first().prop('selected', true);
        }
    });
});