$('.txtSearch').each(function () {
    $(this).keypress(function (e) {
        var p = e.which;
        if (p == 13) {
            var text = $(this).val();
            if (text.trim() != '') {
                var url = '/Client/Post?Keyword=' + text;
                window.open(url, "_self");
                return false;
            }
        }
    });
});

function quicksearchLeft() {
    var text = $('.left-content .txtSearch').val();
    var url = '/tim-kiem?keyword=' + text;
    window.open(url);
}

function quicksearchRight() {
    var text = $('.right-content .txtSearch').val();
    var url = '/tim-kiem?keyword=' + text;
    window.open(url);
}

function quicksearch() {
    var text = $('.txtSearch').val();
    var url = '/tim-kiem?keyword=' + text;
    window.open(url);
}
