// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

var anzahlmerkmale = 1;
function duplicate() {
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
}