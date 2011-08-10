$(document).ready(function () {

    $("#Translator").change(function () {
        if ($(this).val() != null && $(this).val() != "") {
            listLanguages($(this).val());
        }
        else {
            $("#FromLanguage :gt(0)").remove();
            $("#ToLanguage :gt(0)").remove();
        }
    });

    function listLanguages(translator) {
        $("#FromLanguage :gt(0)").remove();
        $("#ToLanguage :gt(0)").remove();
        $.getJSON('../Subtitle/ListLanguagesByTranslator/' + translator, listLanguagesCallBack);
    }

    function listLanguagesCallBack(json) {
        $(json).each(function () {
            $("#FromLanguage").append("<option value='" + this.Value + "'>" + this.Key + "</option>");
            $("#ToLanguage").append("<option value='" + this.Value + "'>" + this.Key + "</option>");
        });
    }

    $("#translate").button();

    $("#translate").click(function () {
        $("#dialog-form").dialog({
            autoOpen: true,
            height: 200,
            width: 370,
            modal: true,
            dialogClass: "dialog",
            buttons: {
                "Send": function () {
                    var bValid = true;
                    $("#email").removeClass("ui-state-error");
                    bValid = checkEmail();
                    if (bValid) {
                        var email = $("#email").val();
                        $.ajax({
                            type: "POST",
                            dataType: "object;string",
                            url: "../Subtitle/Translate",
                            data: $("#translate-form").serialize() + "&email=" + email,
                            complete: function () {
                                $("#confirmationMessage")
				                    .text("Processing your translation request, when it's done it will be send to your email address.")
				                    .addClass("ui-state-highlight")
                                    .fadeIn();
                                    
                                setTimeout(function () {
                                        $("#confirmationMessage").fadeOut();
                                    }, 4000);                                
                            }
                        });
                    }
                }
            }
        });
    });

    function checkEmail() {
        var emailInput = $("#email");
        var regexp = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

        if (!(regexp.test(emailInput.val()))) {
            emailInput.addClass("ui-state-error");
            updateTips("Invalid email");
            return false;
        } else {
            return true;
        }
    }

    function updateTips(t) {
        $(".validateTips")
				.text(t)
				.addClass("ui-state-highlight");

        setTimeout(function () {
            $(".validateTips").removeClass("ui-state-highlight");
        }, 1500);
    }
});