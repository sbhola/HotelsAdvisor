/**
 * Created by dpingale on 6/16/2014.
 */
$(window).load(function(){
    $('.sub-menu-wrap').hide();
    $("tr.hidden-table").hide();

//backend listing dropdown adjustment
    var $backendlist = $('.backend-list ul li');
    //alert($backendlist.length);
    $('.backend-list').removeClass('cols3, cols2, cols1');
    if($backendlist.length > 2) {

        $('.backend-list').addClass('cols3');
    }
    else if($backendlist.length > 1) {
        $('.backend-list').addClass('cols2');
    }
    else {
        $('.backend-list').addClass('col1');
    }
//backend listing dropdown adjustment

});

$(document).ready(function () {
    $('.sub-menu-wrap').hide();
    $("tr.hidden-table").hide();

//    header top nav sub menu wrap
    $(function() {
        $('.nav-wlc > li').click(function(e) {
            e.stopPropagation();
            var $el = $('.sub-menu-wrap',this);
            $('.nav-wlc > li > div').not($el).slideUp();
            $el.stop(true, true).slideToggle(400);
        });
        $('.nav-wlc > li > div > ul > li').click(function(e) {
            e.stopImmediatePropagation();
        });
    });


//    header top nav hide dropdown
    $(document).on('click', function (e) {
        if ($(e.target).hasClass('.nav-wlc > li') || $(e.target).attr('class') === 'sub-menu-wrap') {
        }
        else {
            $('.sub-menu-wrap').hide();
        }
    });

    //datepickers
    $('#wlcdp1').datepicker();
    $('#wlcdp2').datepicker();
    $('#wlcdp3').datepicker();
    $('#wlcdp4').datepicker();
    $('#wlcdp5').datepicker();
    $('#wlcdp6').datepicker();
    $('#wlcdp7').datepicker();
    $('#wlcdp8').datepicker();

//    dates and rates table
    $(".dates-rates-content table .wlc-icon-plus").on("click", function () {
        if ($(this).parents('tr').hasClass('active')) {
            $(this).parents('tr').next("tr.hidden-table").hide(300);
            $(this).removeClass('wlc-icon-minus');
            $(this).parents('tr').removeClass('active');
        } else {
            $(this).parents('tr').next("tr.hidden-table").show(300);
            $(this).addClass('wlc-icon-minus');
            $(this).parents('tr').addClass('active');
        }
        $(this).parents('tr').sibling().next("tr.hidden-table").hide();
    });

//    top nav search tabs
    $('#wlcSearchTabs a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    });

});
//document end







