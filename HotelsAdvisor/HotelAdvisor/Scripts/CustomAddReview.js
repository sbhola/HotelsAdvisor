var ratingService = 0;
var ratingLocation = 0;
var ratingCleanliness = 0;
var ratingRooms = 0;
var ratingValue = 0;

$('.custom-star-rating-hotels-value span').click(function () {

    ratingValue = ($(this).attr('id'));
    var result = ratingValue.substring(0, ratingValue.length - 1);
    document.getElementById("review-rating-value").value = result;
    if (result == 5) {
        document.getElementById("1v").style.color = "#d58512";
        document.getElementById("2v").style.color = "#d58512";
        document.getElementById("3v").style.color = "#d58512";
        document.getElementById("4v").style.color = "#d58512";
        document.getElementById("5v").style.color = "#d58512";
    }

    if (result == 4) {
        document.getElementById("1v").style.color = "#d58512";
        document.getElementById("2v").style.color = "#d58512";
        document.getElementById("3v").style.color = "#d58512";
        document.getElementById("4v").style.color = "#d58512";
        document.getElementById("5v").style.color = "Black";
    }

    if (result == 3) {
        document.getElementById("1v").style.color = "#d58512";
        document.getElementById("2v").style.color = "#d58512";
        document.getElementById("3v").style.color = "#d58512";
        document.getElementById("4v").style.color = "Black";
        document.getElementById("5v").style.color = "Black";
    }
    if (result == 2) {
        document.getElementById("1v").style.color = "#d58512";
        document.getElementById("2v").style.color = "#d58512";
        document.getElementById("3v").style.color = "Black";
        document.getElementById("4v").style.color = "Black";
        document.getElementById("5v").style.color = "Black";
    }

    if (result == 1) {
        document.getElementById("1v").style.color = "#d58512";
        document.getElementById("2v").style.color = "Black";
        document.getElementById("3v").style.color = "Black";
        document.getElementById("4v").style.color = "Black";
        document.getElementById("5v").style.color = "Black";
    }

});


$('.custom-star-rating-hotels-cleanliness span').click(function () {

    ratingCleanliness = ($(this).attr('id'));
    var result = ratingCleanliness.substring(0, ratingCleanliness.length - 1);
    document.getElementById("review-rating-cleanliness").value = result;
    if (result == 5) {
        document.getElementById("1c").style.color = "#d58512";
        document.getElementById("2c").style.color = "#d58512";
        document.getElementById("3c").style.color = "#d58512";
        document.getElementById("4c").style.color = "#d58512";
        document.getElementById("5c").style.color = "#d58512";
    }

    if (result == 4) {
        document.getElementById("1c").style.color = "#d58512";
        document.getElementById("2c").style.color = "#d58512";
        document.getElementById("3c").style.color = "#d58512";
        document.getElementById("4c").style.color = "#d58512";
        document.getElementById("5c").style.color = "Black";
    }

    if (result == 3) {
        document.getElementById("1c").style.color = "#d58512";
        document.getElementById("2c").style.color = "#d58512";
        document.getElementById("3c").style.color = "#d58512";
        document.getElementById("4c").style.color = "Black";
        document.getElementById("5c").style.color = "Black";
    }
    if (result == 2) {
        document.getElementById("1c").style.color = "#d58512";
        document.getElementById("2c").style.color = "#d58512";
        document.getElementById("3c").style.color = "Black";
        document.getElementById("4c").style.color = "Black";
        document.getElementById("5c").style.color = "Black";
    }

    if (result == 1) {
        document.getElementById("1c").style.color = "#d58512";
        document.getElementById("2c").style.color = "Black";
        document.getElementById("3c").style.color = "Black";
        document.getElementById("4c").style.color = "Black";
        document.getElementById("5c").style.color = "Black";
    }

});


$('.custom-star-rating-hotels-rooms span').click(function () {

    ratingRooms = ($(this).attr('id'));
    var result = ratingRooms.substring(0, ratingRooms.length - 1);
    document.getElementById("review-rating-room").value = result;
    if (result == 5) {
        document.getElementById("1r").style.color = "#d58512";
        document.getElementById("2r").style.color = "#d58512";
        document.getElementById("3r").style.color = "#d58512";
        document.getElementById("4r").style.color = "#d58512";
        document.getElementById("5r").style.color = "#d58512";
    }

    if (result == 4) {
        document.getElementById("1r").style.color = "#d58512";
        document.getElementById("2r").style.color = "#d58512";
        document.getElementById("3r").style.color = "#d58512";
        document.getElementById("4r").style.color = "#d58512";
        document.getElementById("5r").style.color = "Black";
    }

    if (result == 3) {
        document.getElementById("1r").style.color = "#d58512";
        document.getElementById("2r").style.color = "#d58512";
        document.getElementById("3r").style.color = "#d58512";
        document.getElementById("4r").style.color = "Black";
        document.getElementById("5r").style.color = "Black";
    }
    if (result == 2) {
        document.getElementById("1r").style.color = "#d58512";
        document.getElementById("2r").style.color = "#d58512";
        document.getElementById("3r").style.color = "Black";
        document.getElementById("4r").style.color = "Black";
        document.getElementById("5r").style.color = "Black";
    }

    if (result == 1) {
        document.getElementById("1r").style.color = "#d58512";
        document.getElementById("2r").style.color = "Black";
        document.getElementById("3r").style.color = "Black";
        document.getElementById("4r").style.color = "Black";
        document.getElementById("5r").style.color = "Black";
    }

});

$('.custom-star-rating-hotels-location span').click(function () {

    ratingLocation = ($(this).attr('id'));
    var result = ratingLocation.substring(0, ratingLocation.length - 1);
    document.getElementById("review-rating-location").value = result;
    if (result == 5) {
        document.getElementById("1l").style.color = "#d58512";
        document.getElementById("2l").style.color = "#d58512";
        document.getElementById("3l").style.color = "#d58512";
        document.getElementById("4l").style.color = "#d58512";
        document.getElementById("5l").style.color = "#d58512";
    }

    if (result == 4) {
        document.getElementById("1l").style.color = "#d58512";
        document.getElementById("2l").style.color = "#d58512";
        document.getElementById("3l").style.color = "#d58512";
        document.getElementById("4l").style.color = "#d58512";
        document.getElementById("5l").style.color = "Black";
    }

    if (result == 3) {
        document.getElementById("1l").style.color = "#d58512";
        document.getElementById("2l").style.color = "#d58512";
        document.getElementById("3l").style.color = "#d58512";
        document.getElementById("4l").style.color = "Black";
        document.getElementById("5l").style.color = "Black";
    }
    if (result == 2) {
        document.getElementById("1l").style.color = "#d58512";
        document.getElementById("2l").style.color = "#d58512";
        document.getElementById("3l").style.color = "Black";
        document.getElementById("4l").style.color = "Black";
        document.getElementById("5l").style.color = "Black";
    }

    if (result == 1) {
        document.getElementById("1l").style.color = "#d58512";
        document.getElementById("2l").style.color = "Black";
        document.getElementById("3l").style.color = "Black";
        document.getElementById("4l").style.color = "Black";
        document.getElementById("5l").style.color = "Black";
    }

});

$('.custom-star-rating-hotels-service span').click(function () {

    ratingService = ($(this).attr('id'));
    var result = ratingService.substring(0, ratingService.length - 1);
    document.getElementById("review-rating-service").value = result;
    if (result == 5) {
        document.getElementById("1s").style.color = "#d58512";
        document.getElementById("2s").style.color = "#d58512";
        document.getElementById("3s").style.color = "#d58512";
        document.getElementById("4s").style.color = "#d58512";
        document.getElementById("5s").style.color = "#d58512";
    }

    if (result == 4) {
        document.getElementById("1s").style.color = "#d58512";
        document.getElementById("2s").style.color = "#d58512";
        document.getElementById("3s").style.color = "#d58512";
        document.getElementById("4s").style.color = "#d58512";
        document.getElementById("5s").style.color = "Black";
    }

    if (result == 3) {
        document.getElementById("1s").style.color = "#d58512";
        document.getElementById("2s").style.color = "#d58512";
        document.getElementById("3s").style.color = "#d58512";
        document.getElementById("4s").style.color = "Black";
        document.getElementById("5s").style.color = "Black";
    }
    if (result == 2) {
        document.getElementById("1s").style.color = "#d58512";
        document.getElementById("2s").style.color = "#d58512";
        document.getElementById("3s").style.color = "Black";
        document.getElementById("4s").style.color = "Black";
        document.getElementById("5s").style.color = "Black";
    }

    if (result == 1) {
        document.getElementById("1s").style.color = "#d58512";
        document.getElementById("2s").style.color = "Black";
        document.getElementById("3s").style.color = "Black";
        document.getElementById("4s").style.color = "Black";
        document.getElementById("5s").style.color = "Black";
    }

});


//var rating = 0;
$('.custom-star-rating span').click(function () {

    var rating = ($(this).attr('id'));
    document.getElementById("review-rating").value = rating;
    if (rating == 5) {
        document.getElementById("1").style.color = "#d58512";
        document.getElementById("2").style.color = "#d58512";
        document.getElementById("3").style.color = "#d58512";
        document.getElementById("4").style.color = "#d58512";
        document.getElementById("5").style.color = "#d58512";
    }

    if (rating == 4) {
        document.getElementById("1").style.color = "#d58512";
        document.getElementById("2").style.color = "#d58512";
        document.getElementById("3").style.color = "#d58512";
        document.getElementById("4").style.color = "#d58512";
        document.getElementById("5").style.color = "Black";
    }

    if (rating == 3) {
        document.getElementById("1").style.color = "#d58512";
        document.getElementById("2").style.color = "#d58512";
        document.getElementById("3").style.color = "#d58512";
        document.getElementById("4").style.color = "Black";
        document.getElementById("5").style.color = "Black";
    }
    if (rating == 2) {
        document.getElementById("1").style.color = "#d58512";
        document.getElementById("2").style.color = "#d58512";
        document.getElementById("3").style.color = "Black";
        document.getElementById("4").style.color = "Black";
        document.getElementById("5").style.color = "Black";
    }

    if (rating == 1) {
        document.getElementById("1").style.color = "#d58512";
        document.getElementById("2").style.color = "Black";
        document.getElementById("3").style.color = "Black";
        document.getElementById("4").style.color = "Black";
        document.getElementById("5").style.color = "Black";
    }
    
    //if(rating==0) {
    //    document.getElementById("alertmsg").innerHTML = "Overall Rating is Required";
    //    return false;
    //}
});