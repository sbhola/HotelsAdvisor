// JavaScript Document

/*--------------All Common Scripts ---------------*/

$(document).ready (function () {


$(window).resize(function(){

if($(window).width() < 1030){
	$('.full-page-view > .side-by-side').removeClass('span9').addClass('span12').css({"margin-left":"0px"});
}else{
	$('.full-page-view > .side-by-side').removeClass('span12').addClass('span9').css({"margin-left":"2.12766%"});
}

	
});





/* Default screen hide */
$(".itineraryHotel").css('display', 'block');
$("#shadow_inset").css('display', 'none');
//$(".close_tab").css('display', 'block');
/*---------- Legend box -------------*/

//$(".title_legends_mapview").css({"visibility": "hidden"});
$("#link").css({"visibility": "visible"});

$("#showhideFilterSearch").toggle(function() {	
    $(".legends_holder_mapview").animate({
        //'left': '-=475px'
		'left': '-=29%'
    }, 500);
   $(this).toggleClass("closed");
  
  $(".title_legends_mapview").css({"visibility": "visible"});
  $('.mapTabView > .span8').removeClass('span8').addClass('span12 > marginTminus25');
  $('.mapTabView').addClass('marginLeft38');
  //$('.mapTabView > .span12').addClass('marginLeft38 > marginTminus21');
  //$('.span4').removeClass('span4').addClass('span1');
  //$('.span4').css('display', 'none');
   
}, function() {
    $(".legends_holder_mapview").animate({
        //'left': '+=475px'
		'left': '+=29%'
    }, 500);
    $(this).toggleClass("closed");	
	//$(".title_legends_mapview").css({"visibility": "hidden"});
	$("#link").css({"visibility": "visible"});
	$('.mapTabView > .span12').removeClass('span12 > marginTminus25').addClass('span8');
	 $('.mapTabView').removeClass('marginLeft38');
	//$('.mapTabView > .span8').removeClass('marginLeft38 > marginTminus21');
	//$('.mapTabView < .span4').css('display', 'none');
});

/*---------- Legend box -------------*/

$('#carousel-nav a').click(function(q){
    q.preventDefault();
    targetSlide = $(this).attr('data-to')-1;
    $('#my-carousel').carousel(targetSlide);
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
       /* Reset All Checked Item */
	   $('.resetallchecked').click(function () {
		   //$(this).find ('.checked').removeClass("checked");
		  // $(this).find ('span').removeClass("icon-ok");
		   //alert ("done");
		   //$(this).find("span").toggleClass("icon-ok");
		   	$(".icon-ok").removeClass("icon-ok");
			//$(".icon-ok").css("opacity", 0.3);
	   });
      /* To check whether an item is checked use the hasClass method */
      //alert($("#chkB").hasClass("checked"));
	  
	  $('.smallMapView').click(function(e) {     
         //alert ('smallMapView');		
		 $('.container-fluid').attr('class', function() {
			return $(this).attr('class').replace('container-fluid', 'container');
		});
		
		//$('.filter_Boxinner').css("width", + '80%');
      });
      /* Single Select - allow only one selection */  
      /* Toggle checked state and icon and also remove any other selections */  
       $('.fullMapView').click(function (e) {
		  //alert ("fullMapView");		   
            $('.container').attr('class', function() {
			return $(this).attr('class').replace('container', 'container-fluid');
		});
		
		//$('.filter_Boxinner').css("width", + '58%');
 });
 
 
	
	var count = 8;
	
	$(".pam").click(function() {
		//$(this).removeClass('activeitembg');
		count++;
		$("#counter").html("&nbsp;" +count );
		//$(this, '.activeitembg').removeClass('activeitembg');
		//alert ("click");
		//$(".scroll-pane-filtermap > div").addClass('activeitembg');
		//$(this).children('.activeitembg').removeClass('activeitembg');
		//$(this).addClass('activeitembg').siblings().removeClass('activeitembg')
		
		
	});	
	
	$(".selectItem").click (function () {
		$('.activeitembg').removeClass('activeitembg');
		$(this).addClass("activeitembg");
		//$(this).find('div span').toggleClass('item_selected item_unselected ', 200);
		//$(this).find('div span').is ('item_selected').toggleClass('item_unselected');
		//alert ("ji");
		if( $('span').is('.item_unselected') ) {
			// it's visible, do something
			//$(this).next('item_unselected').replace('item_selected')
			//$(this).find('span').addClass('item_selected')
			//return $(this).attr('class').replace('item_unselected', 'item_selected');
		}
		else {
			// it's not visible so do something else
		}
	});


$(".tabSelectionMap").click (function () {
		$(".itineraryHotel").css('display', 'none');
		$("#shadow_inset").css('display', 'block');
		$('.searchHotellist').find('li').removeClass('active');
		$('.tabSelectionMap').addClass('active')
		//alert ("myMap");
	});
	$(".tabSelectionHotel ul li a").click (function () {		
		$(".itineraryHotel").css('display', 'block');
		$("#shadow_inset").css('display', 'none');
		$(this,'.active').removeClass('active');
		$('.item').addClass('active');		
		$('.item').next('li').removeClass('active')
	}); 
	
   
   
  ////* Price Slider script *////
	 
	 $(".priceRange").click (function () {
		 $(".priceSliderBox").show();
	 }); 
 //////* Resolution Script /////////////*
 
 
 	 $(".lowResolution").hide();
	 $(window).resize(function(){
     //console.log('resize called');
     var width = $(window).width();
     if(width <= 768 ){
         $(".highResolution").css('display', 'none');
		 $(".lowResolution").show();		 
		 //$('.mapview_category').attr('class', function() {
//			return $(this).attr('class').replace('pull-right', 'pull-left');
//		});	
		 //$('.resp600searchbox > .span7').removeClass('span7').addClass('span4');
		
		
     }
	 
     else{
        
		 $(".lowResolution").hide();
		 $(".highResolution").css('display', 'block');
		// $('.mapview_category').attr('class', function() {
//			return $(this).attr('class').replace('pull-left', 'pull-right');
//		});
		
     }
	 
	 
   })
   .resize();
 
    /* Fixing Issue for Ipad / IOS */
	
	$('.dropdown-menu').on('touchstart.dropdown.data-api', function (e) { 
		e.stopPropagation(); 
	});
   
/*////All Scripts End Here --/////////*/
});
