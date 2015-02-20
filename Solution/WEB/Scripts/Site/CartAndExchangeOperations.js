
// -- CART (NORMAL & EXCHANGE) OPERATIONS

function modifyQuantityInCartOrExchange(clickedButton) {
    var $clickedButton = $(clickedButton);
    var $quantityDiv = $clickedButton.parent("DIV");
    var $bookBlock = $quantityDiv.parent("DIV").parent("DIV.book-block");
    var $newQuantityInput = $clickedButton.siblings("INPUT[name=quantity]");
    var newQuantityValue = parseInt($newQuantityInput.val(), 10);
    var $oldQuantityHidden = $clickedButton.siblings("INPUT[name=old-quantity]");
    var oldQuantityValue = parseInt($oldQuantityHidden.val(), 10);
    var productInOrderId = $clickedButton.parent("DIV").siblings("[name=product-in-order-id]").val();
    var isExchange = $clickedButton.attr("name") == "modify-exchange-quantity";

    if (newQuantityValue == 0) { // Ha a művelet valójában törlés
        var $removeButton = $quantityDiv.siblings("INPUT[name=" + (isExchange ? "remove-from-exchange" : "remove-from-cart") + "]");
        removeFromCartOrExchange($removeButton);
        return;
    } else if (newQuantityValue == oldQuantityValue) { // Ha nem is volt módosítás
        $bookBlock.flashGreenThenBack();
        return;
    }

    $.ajax({
        url: isExchange ? "/Sell/ModifyExchangeProductsQuantity" : "/Buy/ModifyProductsQuantity",
        type: "POST",
        data: "productInOrderId=" + productInOrderId + "&newQuantity=" + newQuantityValue,
        dataType: "json",
        success: function (data) {
            if (data) {
                $oldQuantityHidden.val(newQuantityValue);
                $bookBlock.flashGreenThenBack(function () {
                    refreshCartsSummary($bookBlock, oldQuantityValue, newQuantityValue);
                });
            } else {
                $bookBlock.flashRedThenBack(function () {
                    $newQuantityInput.val(oldQuantityValue);
                });
            }
        }
    });
}
function removeFromCartOrExchange(clickedButton) {
    var $clickedButton = $(clickedButton);
    var productInOrderId = $clickedButton.siblings("[name=product-in-order-id]").val();
    var isExchange = $clickedButton.attr("name") == "remove-from-exchange";

    $.ajax({
        url: isExchange ? "/Sell/RemoveFromExchangeCart" : "/Buy/RemoveFromCart",
        type: "POST",
        data: "productInOrderId=" + productInOrderId,
        dataType: "json",
        success: function (data) {
            var $fieldset = $clickedButton.parent("DIV").parent("DIV").parent("FIELDSET");
            var $bookBlock = $clickedButton.parent("DIV").parent("DIV.book-block");
            var $reminderBookBlocks = $bookBlock.siblings("DIV.book-block");
            
            if (data) {
                $bookBlock.animateBgColorGreen(function () {
                    $bookBlock.fadeOut(DEFAULT_ANIMATION_DURATION, function () {
                        if ($reminderBookBlocks.length == 0) { // Töröljük a teljes kosarat, kiürült
                            //$fieldset.remove();
                            if (!isExchange) {
                                var $mainDiv = $("DIV#main");
                                var $allFieldsets = $mainDiv.children("FIELDSET");
                                handleCartsBecomeEmpty($allFieldsets, $mainDiv);
                            } else {
                                var $sendExchangeButton = $fieldset.siblings("DIV.order-buttons").children("[name=send-exchange-offer-button]");
                                $sendExchangeButton.attr("disabled", "disabled");
                            }
                            $fieldset.remove();
                        } else {
                            if (!isExchange) {
                                var $oldQuantity = $bookBlock.children("DIV.text-block").children("DIV.quantity").children("INPUT[name=old-quantity]");
                                var oldQuantityValue = parseInt($oldQuantity.val(), 10);
                                refreshCartsSummary($bookBlock, oldQuantityValue, 0);
                            }
                            $bookBlock.remove();
                        }
                        //$bookBlock.remove();
                    });
                });
            } else {
                $fieldset.flashRedThenTransparent();
            }
        }
    });
}
function deleteCart(clickedButton) {
    var $clickedButton = $(clickedButton);
    var userOrderId = $clickedButton.siblings("[name=user-order-id]").val();
    $.ajax({
        url: "/Buy/DeleteCart",
        type: "POST",
        data: "userOrderId=" + userOrderId,
        dataType: "json",
        success: function (data) {
            var $mainDiv = $("DIV#main");
            var $allFieldsets = $mainDiv.children("FIELDSET");
            var $fieldset = $clickedButton.parent("DIV").parent("FIELDSET");

            if (data) {
                $fieldset.animateBgColorGreen(function () {
                    $fieldset.fadeOut(DEFAULT_ANIMATION_DURATION, function () {
                        $fieldset.remove();
                        handleCartsBecomeEmpty($allFieldsets, $mainDiv);
                    });
                });
            } else {
                $fieldset.flashRedThenTransparent();
            }
        }
    });
}
function deleteAllCarts() {
    $.ajax({
        url: "/Buy/DeleteAllCarts",
        type: "POST",
        dataType: "json",
        success: function (data) {
            var $mainDiv = $("DIV#main");
            var $dataToRemove = $mainDiv.children().not("H2");
            var isFirst = true;

            if (data) {
                $mainDiv.flashGreenThenTransparent(function () {
                    $dataToRemove.fadeOut(DEFAULT_ANIMATION_DURATION, function () {
                        $dataToRemove.remove();
                        if (isFirst) {
                            $mainDiv.append("Minden kosarad töröltük. ");
                            isFirst = false;
                        }
                    });
                });
            } else {
                $mainDiv.flashRedThenTransparent();
            }
        }
    });
}

// -- HELPERS

function refreshCartsSummary($bookBlock, oldQuantityValue, newQuantityValue) {
    var $cartSummaryDivs = $bookBlock.siblings("DIV.transaction-summary").children("DIV");

    var $price = $bookBlock.children().children("DIV.price");
    var $sum = $cartSummaryDivs.children("SPAN.transaction-sum-price");
    var $fee = $cartSummaryDivs.children("SPAN.transaction-fee");
    var $feePercent = $fee.siblings(".transaction-fee-percent");

    var priceValue = parseInt($price.text().replace("Ft", "").replace(/\s/g, ""), 10);
    var sumValue = parseInt($sum.text().replace("Ft", "").replace(/\s/g, ""), 10);
    var feeValue = parseInt($fee.text().replace("Ft", "").replace(/\s/g, ""), 10);
    var feePercentValue = parseInt($feePercent.val(), 10);

    sumValue -= feeValue;                                           // Levonjuk a régi fee-t
    sumValue -= priceValue * oldQuantityValue;                      // Levonjuk a módosított könyv hozzájárulását
    sumValue += priceValue * newQuantityValue;                      // Hozzáadjuk a módosított hozzájárulást
    feeValue = parseInt(sumValue * feePercentValue / 100.0, 10);    // Kiszámoljuk az új fee-t
    sumValue += feeValue;                                           // Hozzáadjuk az új fee-t

    $sum.html(toThousandSeparated(sumValue) + " Ft");
    $fee.html(toThousandSeparated(feeValue) + " Ft");
}
function handleCartsBecomeEmpty($allFieldsets, $mainDiv) {
    if ($allFieldsets.length == 2) { // A most törölt még beletartozik
        $("DIV.delete-all-carts-button").remove();
    }
    else if ($allFieldsets.length == 1) {
        $mainDiv.append("Minden kosarad töröltük. ");
    }
}