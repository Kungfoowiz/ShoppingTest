



// Json. 
var Shop = {

    "A_quantity": "0",
    "A_price": "5",
    "A_offerMinimumQty": "3",
    "A_offerPrice": "13",

    "B_quantity": "0",
    "B_price": "3",
    "B_offerMinimumQty": "2",
    "B_offerPrice": "4.5",

    "C_quantity": "0",
    "C_price": "2",
    "C_offerMinimumQty": "0",
    "C_offerPrice": "0",

    "D_quantity": "0",
    "D_price": "1.5",
    "D_offerMinimumQty": "0",
    "D_offerPrice": "0",

};

var products = $("ol.products");
var cartCount = 0;

products.on("click", "i", function () {
    var $this = $(this);
    var li;

    if ($this.hasClass("glyphicon-plus")) {
        cartCount++;
        $this.removeClass("glyphicon-plus")
            .addClass("glyphicon-minus")
            .attr("title", "Remove from cart")
            .html("Remove from cart");

        li = $("<li>" + $this.parents("section:first").find("h1").html() + "</li>").data;
        $("big-cart ul").append(li);
    }

    else {
        cartCount--;
        $this.removeClass("glyphicon-minus")
            .addClass("glyphicon-plus")
            .attr("title", "Add to cart")
            .html("Add to cart");

        $(".big-cart ul li").filter(function () {
            return $(this).data("item") === $this[0];
        }).remove();
    }


    $(".mini-cart span").html(cartCount);
    $(".big-cart h1").html(cartCount);


});