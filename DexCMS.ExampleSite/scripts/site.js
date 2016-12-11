$(function () {
    $('#sidemenu').dexCMSSideMenu();

    $('#sidemenu').dexCMSHighlightNav();

    $('#top').dexCMSHighlightNav();

    $('.touch #top > ul > li').click(function () {
        var $link = $(this);
        if ($link.hasClass('open')) {
            $('#top > ul > li.open').removeClass('open');
        } else {
            $('#top > ul > li.open').removeClass('open');
            $link.addClass('open');
        }
    });
});
