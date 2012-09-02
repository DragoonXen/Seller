var MOUSE_BUTTON_MIDDLE = 1;
$(function () {
    $(".approve_link").click(function (e) {
        e = e || window.Event || window.event;
        if (e && e.button == MOUSE_BUTTON_MIDDLE) return true;
        var control = $(this);
        var url = this.href;
        $.post(this.href, function (result) {
            if (result == 'True') {
                var state = (control.attr("text") == "Approve");

                control.attr("href", url.substring(0, url.lastIndexOf("=") + 1) + (!state));

                control.html(state ? "Disapprove" : "Approve");

                control.closest("tr").attr("class", state ? "approved" : "notApproved");
            }
        });
        return false;
    });
});