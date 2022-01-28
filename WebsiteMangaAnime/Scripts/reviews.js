function ShowReviews() {
    var item = document.getElementById('reviews');
    if (item.style.display === 'none') {
        $("#reviews").fadeIn(1000);
    }
    else {
        $("#reviews").fadeOut(1000);
    }
}