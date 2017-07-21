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
            dataType: "json",
            data: data,
            success: function (resultJson) {
                var stateLabel = $("#state-label");
                if (resultJson.Error)
                    stateLabel.text("Ошибка при изменении роли")
                        .addClass("label-danger").removeClass("label-success");
                else
                    stateLabel.text("Роль успешно изменена")
                        .addClass("label-success").removeClass("label-danger");
                var f = function (m) { alert(m); $(this).hide() };
                stateLabel.show("fast", function () {
                    var self = this;
                    function f() { $(self).hide(); };
                    setTimeout(f, 1000);
                });
                return;
            }
        });
        e.stopPropagation();
    });

    $('.btn-file').each(function () {
        var self = this;
        $('input[type=file]', this).change(function () {
            // remove existing file info
            $(self).next().remove();
            // get value
            var infoFiles = '';
            //var value = $(this).val();
            var inputFiles = this.files; // return object FileList
            if (inputFiles.length > 1)
                infoFiles = "Число файлов: " + inputFiles.length;
            else
                infoFiles = (inputFiles[0]).name;
            // append file info
            $('<span><i class="fa fa-file-image-o"></i> ' + infoFiles + '</span>').insertAfter(self);
        });
    });

    //========================== selected row of right sidebar ======================================
    var selectedRowLeftSidebar = $("#activeRowsidebar");
    if (selectedRowLeftSidebar != null) 
        $("#right-sidebar #rightSidebar_" + selectedRowLeftSidebar.val()).addClass("active");
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