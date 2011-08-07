$(document).ready(function () {

    $(function () {
        $("#slider-range-min").slider({
            range: "min",
            value: 0,
            min: -100000,
            max: 100000,
            slide: function (event, ui) {
                $("#milliseconds").val(ui.value);
                $("#seconds").html(ui.value / 1000);
                $("#minutes").html($("#seconds").html() / 60);
            }
        });
        $("#milliseconds").val($("#slider-range-min").slider("value"));
        $("#milliseconds").change(function () {
            $("#seconds").html(this.value / 1000);
            $("#minutes").html($("#seconds").html() / 60);
            $("#slider-range-min").slider("value", this.value);
        });
    });

    $("#Synchronize").button();
});