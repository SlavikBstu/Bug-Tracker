var isValidCaptcha = false;

$(document).ready(function () {
    $("a[href*='captcha.org']").remove();
    $("#ExampleCaptcha_CaptchaIconsDiv").addClass("captcha-icons");
    $("#registrationForm").submit(function () {
        if (!isValidCaptcha) return false;
    });

    $("#CaptchaCode").blur(function (event) {

        // get client-side Captcha object instance
        var captchaObj = $("#CaptchaCode").get(0).Captcha;

        // gather data required for Captcha validation
        var params = {};
        params.CaptchaId = captchaObj.Id;
        params.InstanceId = captchaObj.InstanceId;
        params.UserInput = $("#CaptchaCode").val();

        // make asynchronous Captcha validation request
        $.ajax("CheckCaptcha", {
            type: "POST",
            dataType: "text",
            data: params,
            success: function (result) {
                if ("True" == result) {
                    isValidCaptcha = true;
                    $('#status').text('');
                } else {
                    $('#status').attr('class', 'field-validation-error');
                    $('#status').text('Неверный код');
                    // always change Captcha code if validation fails
                    captchaObj.ReloadImage();
                    isValidCaptcha = false;
                }
            }
        });
        event.preventDefault();
    });
});