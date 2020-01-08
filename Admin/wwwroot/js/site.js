// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// SLUG GENERATOR \\
// Campaign Seo URL Generator
$("#title").keyup(function () {
    var text = window.$(this).val();

    var trMap = {
        çÇ: "c",
        ğĞ: "g",
        şŞ: "s",
        üÜ: "u",
        ıİ: "i",
        öÖ: "o"
    };
    for (var key in trMap) {
        if (trMap.hasOwnProperty(key)) {
            text = text.replace(new RegExp("[" + key + "]", "g"), trMap[key]);
        }
    }
    text = text
        .replace(/[^-a-zA-Z0-9\s]+/gi, "") // remove non-alphanumeric chars
        .replace(/\s/gi, "-") // convert spaces to dashes
        .replace(/[-]+/gi, "-") // trim repeated dashes
        .toLowerCase(); // lower all chars

    window.$("#slug").val(text);
});