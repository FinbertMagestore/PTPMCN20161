function setLocation(url) {
    window.location.href = url;
}

/**
    Confirm before delete data, using post method for security
**/
function deleteConfirm(confirmMsg, postUrl) {
    if (confirm(confirmMsg)) {
        $.post(postUrl, function (data) {
            //reload after delete            
            window.location.href = window.location.href;
        });
    }
    return false;
}