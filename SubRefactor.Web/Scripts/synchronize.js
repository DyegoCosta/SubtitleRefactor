$(document).ready(function () {

    $(function () {
        $("#slider-range-min").slider({
            range: "min",
            value: 0,
            min: -10000,
            max: 10000,
            slide: function (event, ui) {
                $("#Delay").val(ui.value);
            }
        });
        $("#Delay").val($("#slider-range-min").slider("value"));
        $("#Delay").change(function () {
            $("#slider-range-min").slider("value", this.value);
        });
    });

    $("#Synchronize").button();
});