/**
 * Created by stripathi on 6/6/14.
 */
$(document).ready(function() {

    //bootstrap tooltip
    $('a[rel=tooltip]').tooltip();

    //* Price Slider script
    $(".priceSliderBox").show();
    $('#sl5').slider();
    $('#sl6').slider();
    $('.ffsItemDtlWrap').hide();

    $('#btn').on('click', function(e) {
        $(this).children('div.popover_data').fadeIn('fast');
        e.stopPropagation();
        return false;
    });

    $('body, .dropdown').on('click', function() {
        $('div.popover_data').fadeOut('fast');
    });

    //panel height on ready
    $(".panel.right, .panel.left").css("height", $(".ffsSrchResult").css("height"));

    //panel height on window resize


    //panel click switch inbound and outbound
    $('.ffsSrchResult').delegate('.panel', 'click', function() {

//        $('.ffsSrchItemsWrap .ffsSrchItem').removeClass('active').children('.ffsItemDtlWrap').hide();
        if ($('.ffsSrchItem').hasClass('actDetails')) {
            $('.ffsSrchItem.actDetails').children('.ffsItemDtlWrap').hide();
            $('.ffsSrchItem.actDetails').removeClass('actDetails');
            $('.showDetLink a.active').removeClass('active');
        }

        $(".panel.right, .panel.left").css("height", $(".ffsSrchResult").css("height"));

        if ($(this).parent().hasClass('closed')) {
//            $(this).fadeOut('slow');

            $(this).parent().removeClass('closed');
            $(this).parent().siblings('div').addClass('closed');

            $('.ffsResultWrap').css({"opacity": "0"});

            $(this).parent().switchClass("span2", "span10", 800, "easeInOutCubic");
            $(this).parent().siblings('div').switchClass("span10", "span2", 800, "easeInOutCubic");

            $(this).parent().children('div.panel').delay(600).fadeOut('slow');
            $(this).parent().siblings('div').children('div.panel').delay(600).fadeIn('slow');

            setTimeout(function() {
                $('.ffsResultWrap').css({"opacity": "1"});
            }, 1000);
        }
    });

// ----------------- For Stickey flight info --------------------------

    var length = $('.side-by-side').height() - $('.stickey').height() + $('.ffsFilterSort').offset().top;

    $(window).scroll(function() {
        $('.ffsFlightCard.stickey').width($('.ffsFlightCard').parent().width());
        var scroll = $(this).scrollTop();
        var height = $('.stickey').height() + 'px';

        if (scroll < $('.ffsFilterSort').offset().top) {
            $('.stickey').parent().fadeOut('fast');
            $('.stickey').css({
                'position': 'absolute',
                'top': '0'
            });

        } else if (scroll > length) {
            $('.stickey').parent().fadeOut('fast');
            $('.stickey').css({
                'position': 'absolute',
                'bottom': '0',
                'top': 'auto'
            });

        } else {
            $('.stickey').parent().fadeIn('fast');
            $('.stickey').css({
                'z-index': '99999',
                'position': 'fixed',
                'top': '0',
                'height': '78px'

            });
        }
    });


// ----------------------------- new function written -------------------------------------

    $('a.togglesfilters').click(function() {
        $('.showmapviewfilters').toggle(600);
        $(this).text(function(i, text) {
            return text === "show filters" ? "hide filters" : "show filters";
        });
    });

    /*---------- Searchlist Box -------------*/
    $('.searchlistOption').click(function() {
        $(this).toggleClass('searchlist-down');
        $(this).next(".searchlistbox").toggle();

    });

    // stop dropdown close when clicked on content
    $(".ffsFilters .dropdown-menu").on("click", function(e) {
        e.stopPropagation();
    });


    $('.ffsSrchResult').delegate('.ffsSrchItemsWrap .ffsSrchItem', 'click', function() {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            //$(this).children('.ffsItemDtlWrap').slideUp('fast');
        }
        else {
            $(this).parent().parent().children().find('.ffsSrchItem').removeClass('active');
            //$(this).parent().parent().find('.ffsItemDtlWrap').slideUp('fast');
            $(this).addClass('active');
            //$(this).children('.ffsItemDtlWrap').slideDown('fast');

            var parent_class = $(this).parents().parents().parents().attr('class');
            switch (parent_class) {
                case "ffsBoarding span10":
                    $('.ffsFlightCard .left_flight').transition({
                        perspective: '100px',
                        rotateX: '360deg'
                    }, function() {
                        $('.ffsFlightCard .left_flight').removeAttr('style');
                    });
                    var end_val = $(this).children().find('input.num_cost').val();
                    var st_val = $('#rs').html();
                    createCountUp(st_val, end_val);
                    break;
                case "ffsDeparture span10":
                    $('.ffsFlightCard .right_flight').transition({
                        perspective: '100px',
                        rotateX: '360deg'
                    }, function() {
                        $('.ffsFlightCard .right_flight').removeAttr('style');
                    });
                    break;

                case "span6 ffsBoarding":
                    $('.ffsFlightCard .left_flight').transition({
                        perspective: '100px',
                        rotateX: '360deg'
                    }, function() {
                        $('.ffsFlightCard .left_flight').removeAttr('style');
                    });
                    var end_val = $(this).children().find('input.num_cost').val();
                    var st_val = $('#rs').html();
                    createCountUp(st_val, end_val);
                    break;
                case "span6 ffsDeparture":
                    $('.ffsFlightCard .right_flight').transition({
                        perspective: '100px',
                        rotateX: '360deg'
                    }, function() {
                        $('.ffsFlightCard .right_flight').removeAttr('style');
                    });
                    break;
            }

            if ($(this).parents('.span10').hasClass('ffsBoarding')) {

                if ($('.ffsSrchItem').hasClass('actDetails')) {
                    $('.ffsSrchItem.actDetails').children('.ffsItemDtlWrap').hide();
                    $('.ffsSrchItem.actDetails').removeClass('actDetails');
                    $('.showDetLink a.active').removeClass('active');
                    $(".panel.right, .panel.left").css("height", $(".ffsResultWrap").css("height"));
                }

                if ($('.panel.right').parent().hasClass('closed')) {

                    $('.panel.right').parent().removeClass('closed');
                    $('.panel.right').parent().siblings('div').addClass('closed');

                    $('.ffsResultWrap').css({"opacity": "0"});

                    $('.panel.right').parent().switchClass("span2", "span10", 800, "easeInOutCubic");
                    $('.panel.right').parent().siblings('div').switchClass("span10", "span2", 800, "easeInOutCubic");

                    $('.panel.right').parent().children('div.panel').delay(600).fadeOut('slow');
                    $('.panel.right').parent().siblings('div').children('div.panel').delay(600).fadeIn('slow');

                    setTimeout(function() {
                        $('.ffsResultWrap').css({"opacity": "1"});
                    }, 1000);
                }
            }
        }
    });

    /* show/hide details */
    $('.ffsSrchResult').delegate('.ffsSrchItemsWrap .ffsSrchItem .showDetLink a', 'click', function(f) {
        f.stopPropagation();
        $(this).parents('.ffsResultWrap').find('.ffsSrchItem').removeClass('actDetails');
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');

            $(this).parents('.ffsResultWrap').find('.ffsSrchItem').removeClass('actDetails');
            $(this).parents('.ffsSrchItem').children('.ffsItemDtlWrap').slideUp('fast');

            //adjust left panel height
            setTimeout(function() {
                $(".panel").css("height", $(".ffsSrchResult").css("height"));
            }, 300);
        }
        else {
            $(this).parents('.ffsResultWrap').find('.showDetLink a').removeClass('active');
            $(this).parents('.ffsResultWrap').find('.ffsItemDtlWrap').slideUp('fast');

            $(this).addClass('active');
            $(this).parents('.ffsSrchItem').addClass('actDetails');
            $(this).parents('.ffsSrchItem').children('.ffsItemDtlWrap').slideDown('fast');

            //adjust left panel height
            setTimeout(function() {
                $(".panel").css("height", $(".ffsSrchResult").css("height"));
            }, 300);
        }
        return false;
    });

// ----------------------------- new function written -------------------------------------

    $('.taxFeesCnt a').click(function() {
        if ($(this).parent('.taxFeesCnt').hasClass('active')) {
            $(this).parent('.taxFeesCnt').removeClass('active');
            $('.taxFeesCnt .taxCnt').slideUp();
        }
        else {
            $(this).parent('.taxFeesCnt').addClass('active');
            $('.taxFeesCnt .taxCnt').slideDown();
        }
        return false;
    });

});

// set countUp options
var options = {
    useEasing: true, // toggle easing
    useGrouping: true // 1,000,000 vs 1000000
};

var useOnComplete = false;
var useEasing = true;
var useGrouping = true;

function createCountUp(st_val, end_val) {
    startVal = Number(st_val.replace(',', '').replace(' ', ''));
    endVal = Number(end_val.replace(',', '').replace(' ', ''));
    var decimals = 2;

    demo = new countUp("rs", startVal, endVal, decimals, 0.5);

    if (useOnComplete) {
        demo.start(methodToCallOnComplete);
    } else {
        demo.start();
    }
}


var is_touch_device = 'ontouchstart' in document.documentElement;
if (is_touch_device) {
    $('.ffsSrchItem .ffsItemInfo').addClass('touchDevice');
}


//$(window).resize(function(){
//    $(".panel.right, .panel.left").css("height", $(".ffsResultWrap").css("height"));
//});

//function search_height(){
//    var ht = $('.ffsSrchResult').height();
//    $('.panel').css({"height":ht - 20+"px"});
//}

