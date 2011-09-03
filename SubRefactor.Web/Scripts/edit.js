$(document).ready(function () {
    
    $("#edit, #preview, #download").button();    

    $("#edit").click(function () {
        $.ajax({
            type: "POST",
            dataType: "object",
            url: "Edit",
            data: $("#edited-quotes-form").serialize(),
            complete: function () {
                $("#confirmationMessage")
				.text("Subtitle successfully edited.")
				.addClass("ui-state-highlight")
                .fadeIn();
                setTimeout(function () {
                    $("#confirmationMessage").fadeOut();
                }, 3000);
                $(".continue").fadeIn();
            }
        });
    });
});