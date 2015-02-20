$(function () {

    // Author & Publisher - RadioButtons & TextBoxes

    $("INPUT[name=authorPublisher]:radio").change(function () {
        if (this.value == "Neither") {
            deactivateTextBox("#AuthorName");
            deactivateTextBox("#PublisherName");
        }
        else if (this.value == "Author") {
            activateTextBox("#AuthorName");
            deactivateTextBox("#PublisherName");
        } else {
            deactivateTextBox("#AuthorName");
            activateTextBox("#PublisherName");
        }
    });
});

function activateTextBox(itemSelector) {
    $(itemSelector).removeAttr("disabled");
}

function deactivateTextBox(itemSelector) {
    $(itemSelector).attr("disabled", "disabled");
    $(itemSelector).val("");
}