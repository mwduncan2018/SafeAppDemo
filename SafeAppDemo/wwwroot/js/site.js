// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

'use strict';


$(document).ready(function () {

    setTimeout(function () {

        var secret = document.createElement("span");
        var message = document.createTextNode(" (Safe App Demo!)");
        secret.appendChild(message);
        secret.id = "secretMessage";

        var copyright = document.querySelector("#copyright");
        copyright.appendChild(secret);

    }, 10000);

});