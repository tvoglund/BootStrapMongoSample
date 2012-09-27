function activeMenuItem(id) {

    //dynamically get menu here
    var h = {};
    h[''] = 'homeId';
    h['#'] = 'homeId';
    h['#contact'] = 'aboutId';
    h['#about'] = 'aboutId';

    var selectedItemId = "#" + h[id];

    $(selectedItemId).addClass("active");
    for (var k in h) {
        if (h.hasOwnProperty(k)) {
            var deSelectThisId = k + "Id";
            if (deSelectThisId == "Id" || deSelectThisId == "#Id") {
                deSelectThisId = "#homeId";
            }
            if (deSelectThisId != selectedItemId) {
                $(deSelectThisId).removeClass("active");
            }
        }
    }

}