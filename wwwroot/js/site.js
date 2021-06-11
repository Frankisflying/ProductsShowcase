$(function () {
    console.log("document is ready");
    var id;
    $(document).on("click", ".edit-product-button", function () {
        console.log("You just clicked button number " + $(this).val());

        // store the product Id number
        var productID = $(this).val();

        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: "/product/ShowDetailsJSON",
            success: function (data) {
                console.log(data);
                document.getElementById("modal-id").innerHTML = data.id;
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);
                id = data.id;
            }
        })
    });

    $("#save-button").click(function () {
        // get the values from the input fields and create a json object to submit to the controller.
        var Product = {
            "Id": id,
            "Name": $("#modal-input-name").val(),
            "Price": $("#modal-input-price").val(),
            "Description": $("#modal-input-description").val()
        };

        console.log("saved...");
        console.log(Product);

        $.ajax({
            type: 'json',
            data: Product,
            url: '/product/ProcessEditReturnPartial',
            success: function (data) {
                console.log(data);
                $("#card-number-" + Product.Id).html(data).hide().fadeIn(2000);
            }
        })
    })
});