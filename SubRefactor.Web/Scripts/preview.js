$(document).ready(function () {
    $("#originalSubtitle").scroll(function () {
        $("#editedSubtitle").scrollTop($("#originalSubtitle").scrollTop());
    });
    $("#editedSubtitle").scroll(function () {
        $("#originalSubtitle").scrollTop($("#editedSubtitle").scrollTop());
    });
    
    $("#back").button();
    $("#download").button();
});