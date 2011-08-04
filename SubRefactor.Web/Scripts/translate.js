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

});

function listLanguages(translator) {
    $("#FromLanguage :gt(0)").remove();
    $("#ToLanguage :gt(0)").remove();
    $.getJSON('@Url.Content("~/Views/Subtitle/ListLanguagesByTranslator")/' + translator, listLanguagesCallBack);
}

function listLanguagesCallBack(json) {
    $(json).each(function () {
        $("#FromLanguage").append("<option value='" + this.Value + "'>" + this.Key + "</option>");
        $("#ToLanguage").append("<option value='" + this.Value + "'>" + this.Key + "</option>");
    });
}