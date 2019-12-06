// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

var anzahlmerkmale = 1;
function addMerkmal() {
    //var element_id = "merkmale_div_" + anzahlmerkmale;
    document.getElementById('merkmale_div_' + anzahlmerkmale).insertAdjacentHTML("afterend",
        '<div class="row" id="merkmale_div_' + (anzahlmerkmale+1) + '">' +
            '<div class= "col-md-6" >' +
                '<div class="form-group">' +
                    '<input placeholder="Bezeichnung" class="form-control" type="text" data-val="true" data-val-required="The Bezeichnung field is required." id="merkmalBezeichnungen_'+ anzahlmerkmale + '__Bezeichnung" name = "merkmalBezeichnungen[' + anzahlmerkmale + '].Bezeichnung" value >' +
                    '<span class="text-danger field-validation-valid" data-valmsg-for="merkmalBezeichnungen[' + anzahlmerkmale + '].Bezeichnung" data-valmsg-replace="true"></span>' +
                '</div>' +
            '</div >' +
            '<div class="col-md-6">' +
                '<div class="form-group">' +
                    '<input placeholder="Wert" class="form-control" type="text" data-val="true" data-val-required="The Wert field is required." id="merkmale' + anzahlmerkmale + '__Wert" name = "merkmale[' + anzahlmerkmale + '].Wert" value/>' +
                    '<span class="text-danger field-validation-valid" data-valmsg-for="merkmale[' + anzahlmerkmale + '].Wert" data-valmsg-replace="true""></span>' +
                '</div>' +
            '</div>' + 
        '</div>');
    anzahlmerkmale++;
};

var anzahlfarben = 1;
function addFarbe() {
    /*var childs = document.getElementById('datalist_farben').childNodes;
    var options;
    childs.forEach(function (child) {
        options += '<option value="' + child.value + '"></option>'
    });*/

    document.getElementById('farben_div_' + anzahlfarben).insertAdjacentHTML("afterend",
        '<div class= "col-md-6" id="farben_div_' + (anzahlfarben+1) + '">' +
        '<div class="form-group">' +
        '<input placeholder="Farbe" class="form-control" list="datalist_farben" type="text" id="farben_' + anzahlfarben + '__Bezeichnung" name = "farben[' + anzahlfarben + '].Wert" value/>' + 
                    /*'<datalist id="datalist_farben">' +
                        options + 
                    '</datalist>' +
                '</input>' +*/
            '</div>' +
        '</div>');
    anzahlfarben++;
};