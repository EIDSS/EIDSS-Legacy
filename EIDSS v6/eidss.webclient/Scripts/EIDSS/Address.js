var address = (function () {
    function onCountryChangedSuccess(e) {
        var id = comboBoxFacade.getIdByE(e);
        var newId = id.substring(0, id.lastIndexOf("_") + 1) + "strForeignAddress";
        if ($("#" + newId).length > 0) {
            if ($("#" + newId)[0].classList[0] == "invisible") {
                $(".foreignAddressFieldInvisible").removeClass("invisible");
            } else {
                $(".foreignAddressFieldInvisible").addClass("invisible");
            }
        }
        comboBoxFacade.reloadReferenceComboBox(e, 'Region');
    }

    function onGeoLocationTypeChangedSuccess(e) {
        var val = e.e.sender.value();
        if (e.oldVal == 10036001 && val != 10036001 ||
            e.oldVal != 10036001 && val == 10036001) {
            comboBoxFacade.reloadReferenceComboBox(e.e, 'Region');
        }
    }

    function onRegionChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Rayon');
    }

    function onRayonChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Settlement');
    }

    function onSettlementChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Street');
        comboBoxFacade.reloadReferenceComboBox(e, 'PostCode');
        //address.setStreetAndPostCode(objectId);
    }

    return {
        onCountryChanged: function(e) {
            formRefresher.setOnChangedSuccess(onCountryChangedSuccess, e);
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

        onRegionChanged: function (e) {
            formRefresher.setOnChangedSuccess(onRegionChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onRayonChanged: function(e) {
            formRefresher.setOnChangedSuccess(onRayonChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onSettlementChanged: function(e) {
            formRefresher.setOnChangedSuccess(onSettlementChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

};
})();