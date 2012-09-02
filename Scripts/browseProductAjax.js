var MOUSE_BUTTON_MIDDLE = 1;
var lastBrowsed = -1;
$(function () {
    $(".product_name").click(function (e) {
        e = e || window.Event || window.event;
        if (e && e.button == MOUSE_BUTTON_MIDDLE) return true;
        var recordId = $(this).attr("data-id");
        if (recordId == lastBrowsed) return false;
        if (recordId != '') {
            lastBrowsed = recordId;
            $.post("/Products/BrowseProduct", { "id": recordId },
                    function (htmlData) {
                        var productBrowse = $("#productBrowse").fadeTo(300, 0.01, function () {
                            productBrowse.html(htmlData);
                            productBrowse.fadeTo(300, 1, function () {
                                $('html,body').animate({ scrollTop: $(this).offset().top }, 300);
                            });
                        });

                    });
        }
        return false;
    });
});