var setHeightRightSidebar = function () {
    $("#right-sidebar").outerHeight($(window).height() - $(".navbar .navbar-fixed-top").outerHeight(true));
};

$(document).ready(function () {

    $('.scrollup').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 600);
        return false;
    });

    $('.scrolldown').click(function () {
        $('html, body').animate({ scrollTop: $(document).outerHeight(true) }, 600);
        return false;
    });

    setHeightRightSidebar();

    $("#menu_gear").click(function () {
        $("#right-sidebar").toggleClass("moveHide moveShow");
    });

});


//-------------------- button top/bottom
$(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
        $('.scrollup, .scrolldown').fadeIn();
    } else {
        $('.scrollup, .scrolldown').fadeOut();
    }
});

$(window).resize(function () {
    setHeightRightSidebar();
});