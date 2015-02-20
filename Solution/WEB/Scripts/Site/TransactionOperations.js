
// -- TRANSACTION OPERATIONS

function sendOrder(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/SendOrder", "Rendelés leadva!");
}
function sendExchangeOffer(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/SendExchangeOffer", "Csere ajánlat elküldve!");
}
function finalizeOrderWithoutExchange(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/FinalizeOrderWithoutExchange", "Rendelés csere nélkül elküldve!");
}
function finalizeOrderAcceptExchange(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/FinalizeOrderAcceptExchange", "Csere ajánlat elfogadva!");
}
function finalizeOrderDenyExchange(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/FinalizeOrderDenyExchange", "Csere ajánlat elutasítva!");
}
function closeOrderSuccessful(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/CloseOrderSuccessful", "Rendelés sikeresként lezárva!");
}
function closeOrderUnsuccessful(clickedButton) {
    sendOrderChanges(clickedButton, "/Transaction/CloseOrderUnsuccessful", "Rendelés sikertelenként lezárva!");
}

// -- HELPERS

function sendOrderChanges(clickedButton, url, successMessage) {
    var $clickedButton = $(clickedButton);
    var userOrderId = $clickedButton.siblings("[name=user-order-id]").val();
    $.ajax({
        url: url,
        type: "POST",
        data: "userOrderId=" + userOrderId,
        dataType: "json",
        success: function (data) {
            var $fieldset = $clickedButton.parent("DIV").parent("FIELDSET");
            if (data) {
                closeFieldset($fieldset, $clickedButton, successMessage);
            } else {
                $fieldset.flashRedThenTransparent();
            }
        }
    });
}
function closeFieldset($fieldset, $clickedButton, message) {
    //$fieldset.animateBgColorGreen();
    $fieldset.flashGreenThenTransparent();
    var $otherButtons = $("INPUT[type=button]", $fieldset).not($clickedButton);
    $otherButtons.remove();

    $("INPUT[type=text]", $fieldset).attr("disabled", "disabled");
    $clickedButton.attr("disabled", "disabled").val(message);

    //$otherButtons.fadeOut(DEFAULT_ANIMATION_DURATION, function () {
    //    $otherButtons.remove();
    //});
}