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


    //-------------------- DropDawnListRole -------------------------
    $("body").on("change", "select[name='user-role-select']", function (e) {
        var data = {
            userId: $(this).attr("data-user-id"),
            roleId: $(this).val()
        };
            jQuery.ajax("Admin", {
                type: "POST",
                dataType: "text",
                data: data,
                success: function (result) {
                    alert(result);
                    if ("True" == result) {
                    }
                }
        });
        e.stopPropagation();
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