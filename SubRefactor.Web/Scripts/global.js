$(document).ready(function () {
    $(".tipTip").tipTip({ defaultPosition: "top" });
    
    //Feedback modal
    var uvOptions = {};
    (function () {
        var uv = document.createElement('script'); uv.type = 'text/javascript'; uv.async = true;
        uv.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'widget.uservoice.com/G2ORVCNwtmYT2Wt2qf8w.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(uv, s);
    })();
});