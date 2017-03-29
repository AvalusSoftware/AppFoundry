var APF_DisableEvents = false;
var APF_OriginalElementsHeightArray = [];
var APF_OriginalDocumentHeight = 0;
var APF_DialogClosing = false;

var APF_OriginalDialogElementsHeightArray = [];
var APF_OriginalDialogDocumentHeightArray = [];

function APFResetDialogHeight() {
    APF_OriginalDialogElementsHeightArray = [];
    APF_OriginalDialogDocumentHeightArray = [];

    $(".obj-DialogVerticalFill").each(function() {
        APF_OriginalDialogElementsHeightArray.push($(this).outerHeight(true));
        APF_OriginalDialogDocumentHeightArray.push($(this).closest(".TopMostPanel").outerHeight(true));
    });
}

function APFUpdateDialogElementsHeight() {
    var currentIndex = 0;
    $(".obj-DialogVerticalFill").each(function() {
        var currentDialogHeight = $(this).closest(".ui-dialog-content").innerHeight();
        if (currentDialogHeight > APF_OriginalDialogDocumentHeightArray[currentIndex]) {
            var newHeight = APF_OriginalDialogElementsHeightArray[currentIndex] + currentDialogHeight - APF_OriginalDialogDocumentHeightArray[currentIndex]-5;
            $(this).height(newHeight);
        }
        currentIndex++;
    });
}


function APFResetWindowHeight() {
    APF_OriginalElementsHeightArray = [];

    $(".obj-WindowVerticalFill").css("height", "");
    $(".obj-WindowVerticalFill").each(function() {
        APF_OriginalElementsHeightArray.push($(this).outerHeight(true));
    });
    APF_OriginalDocumentHeight = $("body").outerHeight(true);
}

function APFUpdateWindowElementsHeight() {
    var currentWindowHeight = $(window).innerHeight();
    if (currentWindowHeight > APF_OriginalDocumentHeight) {
        var currentIndex = 0;
        $(".obj-WindowVerticalFill").each(function() {
            var newHeight = APF_OriginalElementsHeightArray[currentIndex] + currentWindowHeight - APF_OriginalDocumentHeight - 5;
            $(this).height(newHeight);
            currentIndex++;
        });
    }
}

function APFProcessEvent(eventType, id) {
    if (!APF_DisableEvents) {
        $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id)
            .success(APFProcessEventResults)
            .error(APFRedirectToLogin);
    }
}

function APFRedirectToLogin() {
    window.location.reload();
}

function APFProcessEvent(eventType, id, value) {
    if (!APF_DisableEvents) {
        $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id + "?value=" + encodeURIComponent(value))
            .success(APFProcessEventResults)
            .error(APFRedirectToLogin);
    }
}

function APFProcessDateValueChangedEvent(eventType, id, date) {
    if (!APF_DisableEvents) {
        if (date != null) {
            var year = date.getUTCFullYear();
            var month = date.getUTCMonth() + 1;
            var day = date.getUTCDate();
            $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id + "?value=" + encodeURIComponent(year + "-" + month + "-" + day))
                .success(APFProcessEventResults)
                .error(APFRedirectToLogin);
        } else {
            $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id)
                .success(APFProcessEventResults)
                .error(APFRedirectToLogin);
        }
    }
}

function APFProcessTimeValueChangedEvent(eventType, id, timePicker) {
    if (!APF_DisableEvents) {
        if (timePicker.val()!==""&&timePicker.timepicker("getTime")!==null)
        {
            var hour = timePicker.timepicker("getHour");
            var minute = timePicker.timepicker("getMinute");
            $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id + "?value=" + encodeURIComponent(hour + "-" + minute))
                .success(APFProcessEventResults)
                .error(APFRedirectToLogin);
        } else {
            $.getJSON(window.rootUrl + "Home/ProcessEvent/" + eventType + "/" + id)
                .success(APFProcessEventResults)
                .error(APFRedirectToLogin);
        }
    }
}

function APFProcessEventResults(data) {
    $.each(data, function(index, val) {
        $(val.ID).replaceWith(val.HTML);
    });

    APFResetWindowHeight();
    APFUpdateWindowElementsHeight();

}

function APFUploadFiles(id) {
    $("#" + id).fileupload({
        dataType: "json",
        url: window.rootUrl + "Home/UploadFiles/" + id + "/",
        done: function(e, data) {
            APFProcessEventResults(data.result);
        }
    });
}

function APFDownloadFile(id) {
    window.location = window.rootUrl + "Home/DownloadFile/" + id + "/";
}