var address = (function () {
    function onCountryChangedSuccess(e, data) {
        if (data != null) {
            var id = comboBoxFacade.getIdByE(e);
            address.onForeignCountryChanged(id, data);
            /*
            var sysCountry = $("#SystemCountry").val();
            var itemData = data.Values[id];
            if (itemData != undefined) {
                var curCountry = itemData.value;
                if (sysCountry == curCountry) {
                    //$(".foreignAddressFieldInvisible").removeClass("invisible");
                    $("#" + id + "").closest("table").find(".foreignAddressFieldInvisible").removeClass("invisible");
                } else {
                    //$(".foreignAddressFieldInvisible").addClass("invisible");
                    $("#" + id + "").closest("table").find(".foreignAddressFieldInvisible").addClass("invisible");
                }
            }
            */
            /*
            var newId = id.substring(0, id.lastIndexOf("_") + 1) + "strForeignAddress";
            var itemData = data.Values[newId];
            if (itemData != undefined) {
                if (itemData.invisible) {
                    $(".foreignAddressFieldInvisible").removeClass("invisible");
                } else {
                    $(".foreignAddressFieldInvisible").addClass("invisible");
                }
            } else {
                if ($("#" + newId).length > 0) {
                    if ($("#" + newId)[0].classList[0] == "invisible") {
                        $(".foreignAddressFieldInvisible").removeClass("invisible");
                    } else {
                        $(".foreignAddressFieldInvisible").addClass("invisible");
                    }
                }
            }
            */
            }
        /*var id = comboBoxFacade.getIdByE(e);
        var newId = id.substring(0, id.lastIndexOf("_") + 1) + "strForeignAddress";
        if ($("#" + newId).length > 0) {
            if ($("#" + newId)[0].classList[0] == "invisible") {
                $(".foreignAddressFieldInvisible").removeClass("invisible");
            } else {
                $(".foreignAddressFieldInvisible").addClass("invisible");
            }
        }*/

        /*comboBoxFacade.reloadReferenceComboBox(e, 'Region');*/
    }

    function onGeoLocationTypeChangedSuccess(e) {
        var val = e.e.sender.value();
        /*if (e.oldVal == 10036001 && val != 10036001 ||
            e.oldVal != 10036001 && val == 10036001) {
            comboBoxFacade.reloadReferenceComboBox(e.e, 'Region');
        }*/
        address.toggleMapButton(val);
    }

    /*function onRegionChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Rayon');
    }*/

    /*function onRayonChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Settlement');
    }*/

    /*function onSettlementChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Street');
        comboBoxFacade.reloadReferenceComboBox(e, 'PostCode');
        //address.setStreetAndPostCode(objectId);
    }*/

    return {
        onForeignCountryChanged: function(id, data){
            var sysCountry = $("#SystemCountry").val();
            var itemData = data.Values[id];
            if (itemData != undefined) {
                var curCountry = itemData.value;
                if (sysCountry == curCountry || curCountry == "") {
                    $("#" + id + "").closest("table").find(".foreignAddressFieldInvisible").removeClass("invisible");
                } else {
                    $("#" + id + "").closest("table").find(".foreignAddressFieldInvisible").addClass("invisible");
                }
            }
        },

        onCountryChanged: function(e) {
            formRefresher.setOnChangedSuccessAfterUpdate(onCountryChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onGeoLocationTypeChanged: function (e) {
            var newE = {
                'e': e,
                'oldVal': e.sender.value()
            };
            formRefresher.setOnChangedSuccess(onGeoLocationTypeChangedSuccess, newE);
            bvComboBox.onChanged.call(this, e);
        },
        
        toggleMapButton: function(val) {
            if (val == 10036003) { // ExactPoint
                $("#buttonCoordinatesPicker").removeClass("invisible");
            } else {
                $("#buttonCoordinatesPicker").addClass("invisible");
            }
        },

        /*onRegionChanged: function (e) {
            formRefresher.setOnChangedSuccess(onRegionChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },*/

        /*onRayonChanged: function(e) {
            formRefresher.setOnChangedSuccess(onRayonChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },*/

        /*onSettlementChanged: function(e) {
            formRefresher.setOnChangedSuccess(onSettlementChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },*/

};
})();