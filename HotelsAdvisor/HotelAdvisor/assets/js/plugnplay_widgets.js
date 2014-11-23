// JavaScript Document

/*--------------All Plug n play Scripts ---------------*/



$(function(){
    $('a, button').click(function() {
		//alert ("hi");
        $(this).toggleClass('active');
    });
	$(".plugnplaytabs_Infolist li a").click(function() {
		$('.returndate').css ('visibility', 'visible');
	});
});
 $('.air-sub-tab li a span').click(function() {
	
	$('.air-sub-tab li a span').removeClass('highlight-text');
    $(this).addClass('highlight-text'); 
	$('.returndate').css ('visibility', 'visible');
});

$('.plugnplaylist li a').click(function() {
	
	//$('.air-sub-tab li a span').removeClass('highlight-text');
    //$(this).addClass('highlight-text'); 
	$('.returndate').css ('visibility', 'visible');
	$('.separator_plygnplay').css('display', 'block');
	$('.trip-oneway').css('display', 'block');
});

$('.onewaytrip ').click (function() {
	   $('.returndate').css ('visibility', 'hidden');
		$('.separator_plygnplay').css('display', 'none');
		$('.trip-oneway').css('display', 'none');
	   
   });

/* Multi select - allow multiple selections */
      /* Allow click without closing menu */
      /* Toggle checked state and icon */
      $('.multicheck').click(function(e) {     
         $(this).toggleClass("checked"); 
         $(this).find("span").toggleClass("icon-ok"); 
         return false;
      });
      /* Single Select - allow only one selection */  
      /* Toggle checked state and icon and also remove any other selections */  
       $('.singlecheck').click(function (e) {
		  //alert ("hi");		  
			$(this).parent().siblings().children().removeClass("checked");
			$(this).parent().siblings().children().find("span").removeClass("icon-ok");
			//$(this).addClass ("checked");
			$(this).find("span").addClass("icon-ok");
		
            return false;
        });
   
$('.dropdown-menu').on('touchstart.dropdown.data-api', function (e) { 
		e.stopPropagation(); 
	});

