// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Load money to wallet
function LoadMoney() {

    var money = prompt("Type the money you want to load", "10");
    var wallet = document.getElementById("wallet");

    if (money != null) {

        $.ajax({
            method: "POST",
            url: "/Home/LoadMoney",
            data: { moneyValue: money }
        })
            .done(function (newWallet) {
                alert(newWallet + " TL added to your wallet");
                wallet.innerText = "Wallet: " + newWallet + " TL";
            });

    }
    else {

    }

}