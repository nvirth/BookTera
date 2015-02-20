$(function () {
    var $buyButtons = $("[name=buy-user-group]");
    $buyButtons.bind("click", function () {
        var $clickedButton = $(this);
        var $newTr = $clickedButton.parent("TD").parent("TR");
        var id = $clickedButton.siblings("[name=user-group-id]").val();
        $.ajax({
            url: "/Profile/LevelUp",
            type: "POST",
            data: "toUserGroup=" + id,
            dataType: "json",
            success: function (data) {
                if (data) {
                    var $oldTr = $(".users-group");
                    var $oldTd = $oldTr.children(".user-group-name");
                    
                    $oldTr.removeClass("users-group");
                    $oldTd.css("background-color", COLOR_GOOD_GREEN);
                    $oldTd.animateBgColorTransparent(function () {
                        $buyButtons.attr("disabled", "disabled"); // Az animáció idejére kikapcsoljuk a gombokat
                        var $newTd = $newTr.children(".user-group-name");
                        $newTd.animateBgColorGreen( function () {
                            $newTr.addClass("users-group");
                            $buyButtons.removeAttr("disabled"); // Az animáció végén visszakapcsoljuk a gombokat
                        });
                    });
                } else {
                    $newTr.flashRedThenTransparent();
                }
            }
        });
    });
});