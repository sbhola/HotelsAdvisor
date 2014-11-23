$("#1").click(function () {
    var element;
    element = document.getElementById("alertmsg");
    element.innerHTML = "";
});

$("#2").click(function () {
    var element;
    element = document.getElementById("alertmsg");
    element.innerHTML = "";
});

$("#3").click(function () {
    var element;
    element = document.getElementById("alertmsg");
    element.innerHTML = "";
});

$("#4").click(function () {
    var element;
    element = document.getElementById("alertmsg");
    element.innerHTML = "";
});

$("#5").click(function () {
    var element;
    element = document.getElementById("alertmsg");
    element.innerHTML = "";
});


function validation() {
    var val = document.getElementById("review-rating").value;
    var element;
    if (val == "0") {

        element = document.getElementById("alertmsg");
        element.innerHTML = "Rating is Required";
        return false;
    }
    else {
        element = document.getElementById("alertmsg");
        element.innerHTML = "";
        //$("#frmAddReview").submit();
        return true;
    }
}