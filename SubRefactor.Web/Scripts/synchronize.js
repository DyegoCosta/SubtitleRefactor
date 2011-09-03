$(document).ready(function () {

    $(function () {
        $("#slider-range-min").slider({
            range: "min",
            value: 0,
            min: -10000,
            max: 10000,
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

    $("#synchronize").click(function () {
        var milliseconds = $("#milliseconds").val();
        $.ajax({
            type: "POST",
            dataType: 'int',
            url: "Synchronize",
            data: 'milliseconds=' + milliseconds,
            complete: function () {
                $("#confirmationMessage")
				.text("Subtitle time line successfully updated.")
				.addClass("ui-state-highlight")
                .fadeIn();
                setTimeout(function () {
                    $("#confirmationMessage").fadeOut();
                }, 4000);
                $(".continue").fadeIn();
            }
        });
    });

    $("#synchronize, #preview, #download").button();
});