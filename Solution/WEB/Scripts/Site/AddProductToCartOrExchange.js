//$(function() {
//	var $cartButtons = $("INPUT[type=button].cart");
//	$cartButtons.bind("click"/*,...*/);
//});
		
function addToCartOrExchange(clickedButton) {
    var $clickedButton = $(clickedButton);
    var productId = $clickedButton.siblings("[name=product-id]").val();
    var postData = "productID=" + productId;

    var isExchange = $clickedButton.attr("name") == "add-to-exchange-cart";
    if (isExchange) {
        var userOrderId = $clickedButton.siblings("[name=user-order-id]").val();
        postData += "&userOrderID=" + userOrderId;
    }

    $.ajax({
        url: isExchange ? "/Sell/AddToExchange" : "/Buy/AddToCart",
        type: "POST",
        dataType: "json",
        data: postData,
        success: function(data) {
            var $bookBlock = $clickedButton.parent().parent();
            if (data) {
                var $quantityDiv = $clickedButton.siblings("DIV.quantity").first(); // BookBlock
                if ($quantityDiv.length === 0) {                                    // BookRow
                    $quantityDiv = $clickedButton.parent().siblings(".book-row-2nd-column").first().children("DIV.quantity").first();
                }
                
                var oldQuantityString = $quantityDiv.text().trim().split(" ");
                if (oldQuantityString[1] === "db") {
                    var oldQuantity = parseInt(oldQuantityString[0], 10);
                    var newQuantity = oldQuantity - 1;
                    $quantityDiv.text(newQuantity + " db");
                    if (newQuantity === 0) {
                        $bookBlock.flashGreenThenTransparent();
                        $bookBlock.animate({ "-webkit-border-radius": "20px","-moz-border-radius": "20px", "border-radius": "20px" }, DEFAULT_ANIMATION_DURATION);
                        $clickedButton.remove();
                    }
                }
                
                if (newQuantity !== 0) { // ===0 ág már kezelve
                    $bookBlock.flashGreenThenBack();
                }
            } else {
                $bookBlock.flashRedThenBack();
            }
        }
    });
}