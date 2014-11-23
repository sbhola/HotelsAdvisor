// JavaScript Document

/*--------------All Common Scripts ---------------*/

$(document).ready (function () {
	
	$('.view-seat-map').click(function(){
		$(this).parents('.row-fluid').next().children().find('.seat-map').slideToggle('slow');
	})
	
	
$('body').delegate('a.seats','click',function(){
	$(this).parents('div').next('div.seatmap').slideToggle();
})
	
/*---------- Searchlist Box -------------*/
$('.searchlistOption').click (function () {	
			$(this).toggleClass('searchlist-down');
			$(this).next(".searchlistbox").toggle();
			
	});
	/*-------------Car Matrix View Popup Scripts Start  ------*/
	
	$(".policydetails").hide();
	$(".emailitineary").hide();
	$(".goback").hide();
	$(".matrix tr td", this).click(function(){
		$(".matrix tr td").removeClass("activeVH");
		$(this).addClass("activeVH");
		//$(".policydetails").hide();
		//$(".emailitineary").hide();
		//$(".goback").hide();
		//$(this).next(".positionR").appendTo(".pop_detls").css ({"position": "relative" });
		//$(".pop_detls").fadeIn("fast");
		//$(".pop_detls").css ({"position": "absolute" });
		//$(".cancellationpolicy").hide();
		//$(".matrix_view").appendTo(this,".positionR");
		$(".pop_detls").fadeIn("fast");
		//$(".pop_detls").css ({"position": "absolute" });
		/* Scroll Bar Script for all popups */
		$(function() {
			
				// the element we want to apply the jScrollPane
				var $el = $('#jp-container').jScrollPane({
					verticalGutter 	: -16
				}),
						
				// the extension functions and options 	
					extensionPlugin = {
						
						extPluginOpts : {
							// speed for the fadeOut animation
							mouseLeaveFadeSpeed	: 500,
							// scrollbar fades out after hovertimeout_t milliseconds
							hovertimeout_t : 1000,
							// if set to false, the scrollbar will be shown on mouseenter and hidden on mouseleave
							// if set to true, the same will happen, but the scrollbar will be also hidden on mouseenter after "hovertimeout_t" ms
							// also, it will be shown when we start to scroll and hidden when stopping
							useTimeout : true,
							// the extension only applies for devices with width > deviceWidth
							deviceWidth : 980
						},
						hovertimeout	: null, // timeout to hide the scrollbar
						isScrollbarHover: false,// true if the mouse is over the scrollbar
						elementtimeout	: null,	// avoids showing the scrollbar when moving from inside the element to outside, passing over the scrollbar
						isScrolling		: false,// true if scrolling
						addHoverFunc	: function() {
							
							// run only if the window has a width bigger than deviceWidth
							if( $(window).width() <= this.extPluginOpts.deviceWidth ) return false;
							
							var instance = this;
							
							// functions to show / hide the scrollbar
							$.fn.jspmouseenter 	= $.fn.show;
							$.fn.jspmouseleave 	= $.fn.fadeOut;
							
							// hide the jScrollPane vertical bar
							var $vBar = this.getContentPane().siblings('.jspVerticalBar').hide();
							
							/*
							 * mouseenter / mouseleave events on the main element
							 * also scrollstart / scrollstop - @James Padolsey : http://james.padolsey.com/javascript/special-scroll-events-for-jquery/
							 */
							$el.bind('mouseenter.jsp',function() {
								
								// show the scrollbar
								$vBar.stop( true, true ).jspmouseenter();
								
								if( !instance.extPluginOpts.useTimeout ) return false;
								
								// hide the scrollbar after hovertimeout_t ms
								clearTimeout( instance.hovertimeout );
								instance.hovertimeout 	= setTimeout(function() {
									// if scrolling at the moment don't hide it
									if( !instance.isScrolling )
										$vBar.stop( true, true ).jspmouseleave( instance.extPluginOpts.mouseLeaveFadeSpeed || 0 );
								}, instance.extPluginOpts.hovertimeout_t );
								
								
							}).bind('mouseleave.jsp',function() {
								
								// hide the scrollbar
								if( !instance.extPluginOpts.useTimeout )
									$vBar.stop( true, true ).jspmouseleave( instance.extPluginOpts.mouseLeaveFadeSpeed || 0 );
								else {
								clearTimeout( instance.elementtimeout );
								if( !instance.isScrolling )
										$vBar.stop( true, true ).jspmouseleave( instance.extPluginOpts.mouseLeaveFadeSpeed || 0 );
								}
								
							});
							
							if( this.extPluginOpts.useTimeout ) {
								
								$el.bind('scrollstart.jsp', function() {
								
									// when scrolling show the scrollbar
								clearTimeout( instance.hovertimeout );
								instance.isScrolling	= true;
								$vBar.stop( true, true ).jspmouseenter();
								
							}).bind('scrollstop.jsp', function() {
								
									// when stop scrolling hide the scrollbar (if not hovering it at the moment)
								clearTimeout( instance.hovertimeout );
								instance.isScrolling	= false;
								instance.hovertimeout 	= setTimeout(function() {
									if( !instance.isScrollbarHover )
											$vBar.stop( true, true ).jspmouseleave( instance.extPluginOpts.mouseLeaveFadeSpeed || 0 );
									}, instance.extPluginOpts.hovertimeout_t );
								
							});
							
								// wrap the scrollbar
								// we need this to be able to add the mouseenter / mouseleave events to the scrollbar
							var $vBarWrapper	= $('<div/>').css({
								position	: 'absolute',
								left		: $vBar.css('left'),
								top			: $vBar.css('top'),
								right		: $vBar.css('right'),
								bottom		: $vBar.css('bottom'),
								width		: $vBar.width(),
								height		: $vBar.height()
							}).bind('mouseenter.jsp',function() {
								
								clearTimeout( instance.hovertimeout );
								clearTimeout( instance.elementtimeout );
								
								instance.isScrollbarHover	= true;
								
									// show the scrollbar after 100 ms.
									// avoids showing the scrollbar when moving from inside the element to outside, passing over the scrollbar								
								instance.elementtimeout	= setTimeout(function() {
									$vBar.stop( true, true ).jspmouseenter();
								}, 100 );	
								
							}).bind('mouseleave.jsp',function() {
								
									// hide the scrollbar after hovertimeout_t
								clearTimeout( instance.hovertimeout );
								instance.isScrollbarHover	= false;
								instance.hovertimeout = setTimeout(function() {
										// if scrolling at the moment don't hide it
									if( !instance.isScrolling )
											$vBar.stop( true, true ).jspmouseleave( instance.extPluginOpts.mouseLeaveFadeSpeed || 0 );
									}, instance.extPluginOpts.hovertimeout_t );
								
							});
							
							$vBar.wrap( $vBarWrapper );
							
						}
						
						}
						
					},
					
					// the jScrollPane instance
					jspapi 			= $el.data('jsp');
					
				// extend the jScollPane by merging	
				$.extend( true, jspapi, extensionPlugin );
				jspapi.addHoverFunc();
			
			});
			 
	});
	$(".cancellationpolicylnk").click(function(){
		 //var s = $('div'), w = $(s.find('div')[0]).width();
		//$(".car_details").animate({width: 0, overflow: 'hidden', whiteSpace: 'nowrap'}).fadeOut();
		//$(".policydetails").fadeIn("slow");
		//$('.car_details', this).stop(true).animate({ 'left': 0, 'opacity': '0.7' }, { queue: false, duration: 300 }).hide();
		//$(".car_details").fadeOut("fast");
		 $('.car_details').stop(true).animate({ 'height': 0}, { queue: false, duration: 300 }).fadeOut("Slow");
		$(".goback").fadeIn("fast");
		//$(".policydetails").fadeOut("slide", { direction: "left" }, 100);		
		//$(".policydetails").show().animate({"right":"-1000px"}, "slow");
		$(".policydetails").fadeIn("slow");
		$(".emailitineary").fadeOut("fast");
	});
	
	$(".close_btn").click(function(){
		//alert ("hi");
		$(".pop_detls").fadeOut("fast");
		$(".matrix tr td").removeClass("activeVH");
		//$(".modal").fadeOut("fast")
		//$(".modal").fadeIn("slow");
		//$(".popover").css('display', 'none');
		//$(".mailitinerary").hide();
		
	});
	$(".goback").click(function(){
		
		$(this).hide();
		//$(".policydetails").fadeOut("slide", { direction: "left" }, 100);		
		$(".policydetails").fadeOut("slow");
		$(".emailitineary").fadeOut("fast");
		//$(".car_details").fadeIn("Slow");
		$('.car_details').stop(true).animate({ 'height': 300}, { queue: false, duration: 300 }).fadeIn("Slow");
	});
	
	$(".emailitinearylnk").click (function(){
		$('.car_details').stop(true).animate({ 'height': 0}, { queue: false, duration: 300 }).fadeOut("Slow");
		$('.policydetails').stop(true).animate({ 'height': 0}, { queue: false, duration: 300 }).fadeOut("Slow");
		$(".goback").fadeIn("fast");
		$(".emailitineary").fadeIn("slow");
		
	});
	

/*-------------Car Matrix MultiDropdown Script End    ------*/
	//$("a").tooltip({
//                  'selector': '',
//                  'placement': 'top'
//                });

	
/* Flight Booking Script - Home Page -------*/

$(".flightdeals").hover(
	 
		  function () {
			  
			//$('.fromto_price', this).css('background-color','#000', 'opacity','0.7');
			$(".flightdeals_booking",this).show();
			
			var center = $("div.fromto_price",this).outerHeight(true) / 2; // get the center
			var margin = center - $("div.flightdeals_action",this).height() / 2;
			
			var centerW = $("div.flightdeals_action",this).outerWidth(true) / 2; // get the center
			var marginW = centerW - $("div.flightdeals_action",this).width() / 2;

			$("div.flightdeals_action",this).css({
    		'margin-top': margin,
			'margin-left': marginW,
			//'margin-left': 70,
			'z-index':1000000
			});
			$(".flightdeals_action",this).show();
			
			  	
		  },
		  function () {
			
			//$(".flightdeals_booking",this).show();
			$('.fromto_price', this).css('background-color','');
			$(".flightdeals_booking").hide();
			$(".flightdeals_action",this).hide();

		  }
	  );
	  
	   /* Delete Trip Script */
	  //$(".flightdeals_action").click (function(){
//		  window.alert("Successfully Booked ")
//	  });

/* Flight Booking Script - Home Page END -------*/

/*--////////////////////////Calender Script ////////////////////---*/
//$(function(){
//			window.prettyPrint && prettyPrint();
//			$('#dp1').datepicker({
//				format: 'mm-dd-yyyy'
//			});
//			$('#DOB').data({date: '01-01-1970'});
//			$("#DOB").datepicker({
//				format: "dd-mm-yyyy",
//				viewMode: "years", 
//				minViewMode: "dates",
//				//setStartDate: '+1d'
//				//autoclose: true,
//				
//			});
//			$('#dp2').datepicker();
//			$('#dp3').datepicker();
//			//$('#dp4').datepicker();
//			$('#dp6').datepicker();
//			$('#dp7').datepicker();
//			$('#dpYears').datepicker();
//			$('#dpMonths').datepicker();
//			
//			
//			var startDate = new Date(1950,1,1);
//			var endDate = new Date(2012,1,25);
//			$('#dp4').datepicker()
//				.on('changeDate', function(ev){
//					if (ev.date.valueOf() > endDate.valueOf()){
//						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
//					} else {
//						$('#alert').hide();
//						startDate = new Date(ev.date);
//						$('#startDate').text($('#dp4').data('date'));
//					}
//					$('#dp4').datepicker('hide');
//				});
//			$('#dp5').datepicker()
//				.on('changeDate', function(ev){
//					if (ev.date.valueOf() < startDate.valueOf()){
//						$('#alert').show().find('strong').text('The end date can not be less then the start date');
//					} else {
//						$('#alert').hide();
//						endDate = new Date(ev.date);
//						$('#endDate').text($('#dp5').data('date'));
//					}
//					$('#dp5').datepicker('hide');
//				});
//				
//			$('#dp6').datepicker()
//				.on('changeDate', function(ev){
//					if (ev.date.valueOf() > endDate.valueOf()){
//						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
//					} else {
//						$('#alert').hide();
//						startDate = new Date(ev.date);
//						$('#startDate').text($('#dp6').data('date'));
//					}
//					$('#dp6').datepicker('hide');
//				});
//				
//			$('#dp7').datepicker()
//				.on('changeDate', function(ev){
//					if (ev.date.valueOf() > endDate.valueOf()){
//						$('#alert').show().find('strong').text('The start date can not be greater then the end date');
//					} else {
//						$('#alert').hide();
//						startDate = new Date(ev.date);
//						$('#startDate').text($('#dp7').data('date'));
//					}
//					$('#dp7').datepicker('hide');
//				});
//				
//		});

		
/*//////////-------Custome Scroll Bar Script -----///////////*/	
			
	//$(".modifysearcbox").hide ()
	$('a.toggles').click(function() {
    $('a.toggles i').toggleClass('icon-chevron-down icon-chevron-up');
	//$(this).next(".modifysearcbox").toggle();
	$('.modifysearcbox').toggle(600); 
	});	
	
	
	$('a.togglesfilters').click(function() {
    $('.showmapviewfilters').toggle(600); 	
	$(this).text(function(i, text){
          return text === "show filters" ? "hide filters" : "show filters";
      });
	});	
	
/*//////////////////////////////////////////////////////////////////*/


/*////////////////////--- Accordion Script for activities page  ---///////////////////////////*/
$('.accordionbox').on('show hide', function(e){
	console.log($(e.target).siblings('.accordion-heading'))
    $(e.target).siblings('.accordion-heading').find('.accordion-toggle i',this).toggleClass('icon-chevron-down icon-chevron-right', 200);
});

$('#accordionActivity .accordion_title span').click(function(e){
	if(!($(this).closest('.panel').hasClass('active'))){
		$('#accordionActivity .panel').removeClass('active');
		$('#accordionActivity .panel').find('.icon-chevron-right').removeClass('icon-chevron-down');
		$(this).closest('.panel').addClass('active');
		$('#accordionActivity .panel.active').find('.icon-chevron-right').addClass('icon-chevron-down');
		$('#accordionActivity .panel-collapse.in').collapse('hide');
	}
	else{
		$('#accordionActivity .panel').removeClass('active');
		$('#accordionActivity .panel').find('.icon-chevron-right').removeClass('icon-chevron-down');
	}
});


/* ------------Add Passanger Details ------------*/
$("#addpassanger").click(function(){		
		$(".pop_passangeradd").fadeIn("fast");
		$(".user_edit_info").fadeOut("fast");
		$('.taskButton').show();
		$('.bgActive').toggleClass('bgActive');
	});
	$(".cancel").click(function(){		
		$(".pop_passangeradd").fadeOut("fast");
		
	});
	
	$(".canceladd").click(function(){	
		//alert ("hi");	
			$(".pop_passangeradd").fadeOut("fast");
			
		});
		$('.btn-cancel').click (function () {
		$('.user_edit_info').hide();
		$('.taskButton').show();
		$('.bgActive').toggleClass('bgActive');
	});
	$('.editInfo').click (function () {
		$('.bgActive').removeClass('bgActive');
		$('.user_edit_info').hide();
		$('.pop_passangeradd').hide();
		$('.taskButton').show();
		$(this).closest('tr').addClass('bgActive');		
		$(this).closest('tr').next('.user_edit_info').show();
		 $(this).closest('.taskButton').hide();
		
	});
	$('.delInfo').click (function() {
		$(this).closest('tr').hide();
	});

/*--/////////////Recent Search Script Start------------//*/
 $(".rs_itemrow").hover(
		  function () {
			$('.container-inside', this).css('background-color','');
			$(".ico-rs-delete",this).show();
			
			var center = $("div.container-inside",this).outerHeight(true) / 2; // get the center
			var margin = center - $("div.rs_itemrow_action",this).height() / 2;

			$("div.rs_itemrow_action",this).css({
    		'margin-top': margin
			});
			
			
			  	
		  },
		  function () {
			
			//$(".ico-rs-delete",this).show();
			$('.container-inside', this).css('background-color','');
			$(".ico-rs-delete").hide();

		  }
	  );
	  
	   /* Delete Trip Script */
	  $(".ico-rs-delete").click (function(){
		 $(this).closest(".rs_itemrow").remove();
		 //if(n<=0) {
//				alert (n);
//				$(".ico-recent-search-day").remove();
//			}
//			else  if(n>=2){
//				$(this).closest(".ico-recent-search-day").show();
//			}
			
		  //$(this).parent(".rs_itemrow").hide();
		  //$(".rs_itemrow_box",this).hide();
	  });
	  
	/*--/////////////Recent Search Script End------------//*/  

/*--/////////////Recent Search Script Start------------//*/
/*------Empty Cart Script --*/
	//$(".emptycart").hide();
	$(".emptycart_link").click (function () {
		$(".container-fluid").remove();
		$(".emptycart").show();
	});
	
	 $(".tc_itemrow").hover(
		  function () {
			//$(this).css('background-color','#fefcce');
			$(".rs_icon_delete",this).show();
			
			var center = $("div.container-inside",this).outerHeight(true) / 2; // get the center
			var margin = center - $("div.rs_itemrow_action",this).height() / 2;

			$("div.rs_itemrow_action",this).css({
    		'margin-top': margin
			});
			
			
			  	
		  },
		  function () {
			
			//$(".ico-rs-delete",this).show();
			//$('.rs_itemrow_details', this).css('background-color','');
			$(".rs_icon_delete").hide();

		  }
	  );
	  
	   /* Delete Trip Script */
	  $(".rs_icon_delete").click (function(){
		$(this).closest(".tc_itemrow").remove();
		
	  });
	
	

/*--/////////////Recent Search Script End------------//*/


//<!-- Calender Control Script Dparture and Returning Time Start-->
//var ddm ={format: "dd MM yyyy"};
	//var hhi ={format: "hh:ii"};
	//alert (ddm);
	//alert (hhi);
//	$(".form_datetime").datetimepicker({
	 //format: "dd MM yyyy                                             hh:ii"
	 //format: "dd MM yyyy - hh:ii"
	// });
//<!-- Calender Control Script Dparture and Returning Time End-->
	 $('.unblockmenu').click(function(event){
		 event.stopPropagation();
	 });	 
	 

//<!-- Add New Car Rental Company --->
	$(".addrentalcomp").hide();
	$("#addnew").click (function() {
		$(".addrentalcomp").show();
	});
	
	/* Delete Rental Company */
	$(".deleteretalcomp").click (function() {
		$(this).hide();
	});
	
	
//<!-- Remove Room Details on Home page Hotel Search Section Script Start-->
	$(".remove_roomdetails").click (function() {
		//alert ("hi");
			$(this).closest(".close_roomdetails").remove();
		}); 
//<!-- Remove Room Details on Home page Hotel Search Section Script End-->
/*----------Custom Vertical scrollBar --------------*/

$('.scroll-pane-air').jScrollPane();
$('.scroll-pane-amenities').jScrollPane();
$('.scroll-pane-class').jScrollPane();
$('.scroll-pane-matrixview').jScrollPane();
$('.scroll-pane-activities').jScrollPane();

$('.scroll-pane-car').jScrollPane();

$('.scroll-pane-location').jScrollPane();

$('.scroll-pane-agency').jScrollPane();

$('.scroll-pane-policy').jScrollPane();

$('.scroll-pane-carmatrix').jScrollPane();

$('.scroll-pane-flightmatrix').jScrollPane();

$('.scroll-pane-filtermap').jScrollPane();

/*//////////////Custom Vertical scrollBar END/////////////////*/


/* Message popover for why we ask - checkout passengers */
$('.redress_number_help a').popover({ 
  
   html : true,
   content: function() {
   return $('.msg_whyweaskss').html();
  }
  
});



/* Delete Information */
/* Toggle Commission */
//$(".icon_commissionplus").toggle(function () {
//	function () { /*show*/ },
//    function () { /*hide*/ }
//	
//});
$(".icon_commissionplus").toggle(
  function () {
    $(this).removeClass("icon_commissionplus");
	$(this).addClass("icon_commissionminus");
	//$(this).text("Commission on")
  },
  function () {
    $(this).removeClass("icon_commissionminus");
	$(this).addClass("icon_commissionplus");
	//$(this).text("Commission off")
  }
);


//Tooltip Example
	$('.tooltiplink').tooltip()

//    $('.accordionbox').on('show hide', function(e){
//        console.log($(e.target).siblings('.accordion-heading'))
//        $(e.target).siblings('.accordion-heading').find('.accordion_title i',this).toggleClass('icon-chevron-down icon-chevron-right', 200);
//    });


    /*////All Scripts End Here --/////////*/
});
