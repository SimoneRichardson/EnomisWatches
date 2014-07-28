//loading the Dom into jQuery
$(document).ready(function () {
    //here is where we put our code
    //selecting anything with the class of 
    //'cart', when it is clicked,
    //run a function
    $('.cart').on('click', function () {
        //When we click run this code
        //getting the id from data-id
        var id = $(this).data('id');
        //put our cart div into a variable
        var cartDiv = $(this);
        //MAKE A REQUEST TO ADD to cart
        $.get('/Cart/Add/' + id, function (data) {
            //replace the html of the cart
            //that was clicked, with the string
            //returned from our GET
            cartDiv.html(data);
        });

    });
    //adding a comment, bind a submit event to the addItem form
    $('.addItem form').on('submit', function (event) {
        alert('working');
        //stop the form from submitting normally
        event.preventDefault();
        //put this (the form into a variable
        var theForm = $(this);
        //do the Ajax Post, use the serialize
        //Command to make a string of data
        $.post('/Cart/Add', $(this).serialize(), function (data) {
            //display contents of data
            //in an alert box
            theForm.parent().prepend(data);

        });//closes the $.post()
    });//closes the on submit()
});//closes document.ready()