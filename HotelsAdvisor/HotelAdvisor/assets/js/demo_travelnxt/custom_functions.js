$(document).ready (function () {
	$('body').on('touchstart', '.dropdown, .dropdown-menu, .advance_search_container', function (e) { e.stopPropagation(); });

		$('.advance_filter_tab > span').click(function(){
			$(this).addClass('active').siblings('span').removeClass('active');
			var this_id = $(this).prop('id');
			
			$('#search_data .advance_filter').hide();
			$('#search_data .advance_filter#tab_'+this_id).show();
		})


	$('.datepick').datepicker().on('changeDate', function(ev){
		$('.datepick').datepicker('hide');
	});
	$('.calender_icon').click(function(){
		$('.datepick').datepicker('hide');
		$(this).prev('.datepick').datepicker('show');
	});

	$('.search_icon').click(function(){
		$('.advance_search_container').toggle('fast');
	});

	$('.hide_adv_search').on("click",function(){
		$('.advance_search_container').slideUp('slow');
	});
	$('.add_pref').click(function(){
		$('.searchlistbox').toggle();
	});
	
	$('.dropdown-toggle').click(function(){
		$('.advance_search_container').slideUp('slow');
	});

	// ----------------- For Full page slider ----------------------	
	$("#fullpage_carousel").responsiveSlides({
		auto: true,
		pager: false,
		nav: true,
		speed: 1000,
		namespace: "callbacks",
	});
	
	// ----------------- For page Scroll ----------------------
	$('#page_up').click(function(){
		$('html,body').animate({
			scrollTop: $('#page2').offset().top
		}, 1500, "easeInOutQuint");  
	});
			
	// ----------------- For Align the second page contents ----------------------

	var page_height = $('.page#page2').height();
	var add_wrapper = parseInt($('.add_wrapper').height() / 2);
	$('#page2 > .container').css({
		"margin-top": add_wrapper,
		"margin-bottom": add_wrapper,
	});
	$(window).resize(function(){
		var page_height = $('.page#page2').height();
		var add_wrapper = parseInt($('.add_wrapper').height() / 2);
		$('#page2 > .container').css({
			"margin-top": add_wrapper,
			"margin-bottom": add_wrapper,
		});
	});
	
	
	
      var owl = $("#owl-demo");
      owl.owlCarousel({
        navigation : true,
        singleItem : true,
        transitionStyle : "fade"
      });
      $("#transitionType").change(function(){
        var newValue = $(this).val();
        owl.data("owlCarousel").transitionTypes(newValue);
        owl.trigger("owl.next");
      });

			$("#search_data").mCustomScrollbar({
				advanced:{
					updateOnContentResize: true
				}
			});
			$('.dropdown-toggle').dropdown();

});