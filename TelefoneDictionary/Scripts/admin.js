(function ($) {
    var groupName = document.getElementById("groupName");
    var groupMenu = document.getElementById("groupMenu");

    var recordName = document.getElementById("recordName");
    var recordMenu = document.getElementById("recordMenu");

    recordMenu.onclick = function () {
        recordMenu.style.display = 'block';
    }
    recordName.onclick = function () {
        if (recordMenu.style.display === 'none') {
            recordMenu.style.display = 'block';
        } else {
            recordMenu.style.display = 'none';
        }
    }

    groupMenu.onclick = function () {
        groupMenu.style.display = 'block';
    }
    groupName.onclick = function() {
        if (groupMenu.style.display === 'none') {
            groupMenu.style.display = 'block';
        } else {
            groupMenu.style.display = 'none';
        }
    }

    $('.add').click(function (e) {
        e.stopPropagation();
        if ($(this).hasClass('active')) {
            $('.dialog').fadeOut(200);
            $(this).removeClass('active');
        } else {
            $('.dialog').delay(300).fadeIn(200);
            $(this).addClass('active');
        }
    });

    $('.glyphicon-remove').click(function () {
        $("div#pop-up").css('display', 'none');
    });

    $('.radio > .button').click(function () {
        $('.radio').find('.button.active').removeClass('active');
        $(this).addClass('active');
    });

    function closeMenu() {
        $('.dialog').fadeOut(200);
        $('.add').removeClass('active');
    }

    $(document.body).click(function (e) {
        closeMenu();
    });

    $(".dialog").click(function (e) {
        e.stopPropagation();
    });

    $('.trigger').mouseleave(function (e) {
        clearTimeout(timer);
    });

    $('#record_details').click(function () {
        window.location.href = "/Record/RecordList/?groupPK=" + currentGroupPK;
    });

})(jQuery);