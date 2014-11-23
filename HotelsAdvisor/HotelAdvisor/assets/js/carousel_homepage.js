<!----------Carousel Scripts ------------------->
<!---------HomePage Carousel Top  -->
var currentPagen =0;
$('#destinationCarousel').carousel({
    interval: 7000
    })
$('#hotelcarousel-nav a').click(function(q){
q.preventDefault();
clickedPagen = $(this).attr('data-to')-1;
currentPagen = clickedPagen-1;
$('#destinationCarousel').carousel(clickedPagen);
});
var pagesn = $("#hotelcarousel-nav a");
var pagesCountn = pagesn.length;
$('#destinationCarousel').on('slide', function(evt) {$(pagesn).removeClass("current");currentPagen++;currentPagen=(currentPagen%pagesCountn);$(pagesn[currentPagen]).addClass("current");});	

/*----HomePage Carousel Bottom  -----*/

var currentPage =0;
$('#allDealsCarousel').carousel({
    interval: 7000
    })
$('#carousel-nav_deals a').click(function(q){
q.preventDefault();
clickedPage = $(this).attr('data-to')-1;
currentPage = clickedPage-1;
$('#allDealsCarousel').carousel(clickedPage);
});
var pages = $("#carousel-nav_deals a");
var pagesCount = pages.length;
$('#allDealsCarousel').on('slide', function(evt) {$(pages).removeClass("active");currentPage++;currentPage=(currentPage%pagesCount);$(pages[currentPage]).addClass("active");});

$('#myTab button').click(function (e) {
	alert ("sel");
  e.preventDefault();
  $(this).tab('show');
})
<!---------HomePage Carousel Top END -->
