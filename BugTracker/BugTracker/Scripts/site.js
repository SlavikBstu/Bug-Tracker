var isValidCaptcha = false;
var setHeightRightSidebar = function () {
    $("#right-sidebar").outerHeight($(window).height() - $(".navbar .navbar-fixed-top").outerHeight(true));
}




$(document).ready(function () {
    $("#registrationForm").submit(function () {
        if (!isValidCaptcha) event.preventDefault();
    });


    $("#CaptchaInputText").blur(function () {
        var dataSend = new Object();
        dataSend.userInput = $(this).val();
        dataSend.token = $("#CaptchaDeText").val();
        $.ajax("CheckCaptcha", {
            type: "Post",
            dataType: "text",
            contentType: "text/plain",
            data: dataSend, 
            success: function (data) {
                if (data === "valid") {
                    isValidCaptcha = true;
                    $("#captcha_val_result").text("");
                    return;
                }
                $("#captcha_val_result").text(data);
            }
        })
    });

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