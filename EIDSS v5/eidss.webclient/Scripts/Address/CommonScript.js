function ShowAddressPicker(idfGeoLocation) {
    var url = '../System/AddressPicker?idfGeoLocation=' + idfGeoLocation;
    ShowMessageWindow(url, 430, 300, "", false);        
}

function onAddressPickerAddressChanged(idfGeoLocation, ObjectIdent) {    
    var street = $("#" + ObjectIdent + "Street").data("tComboBox").$input[0];
    var postCode = $("#" + ObjectIdent + "PostCode").data("tComboBox").$input[0];
    var building = $("#" + ObjectIdent + "strBuilding");
    var apartment = $("#" + ObjectIdent + "strApartment");
    var house = $("#" + ObjectIdent + "strHouse");    
    var needSetStreetAndPostCode = $("#needSetStreetAndPostCode");
    needSetStreetAndPostCode[0].value = true;
    $.ajax({
        url: "../System/SetAddress",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            idfGeoLocation: idfGeoLocation,
            strStreetName: street.value,
            strPostCode: postCode.value,
            strBuilding: building.val(),
            strApartment: apartment.val(),
            strHouse: house.val()
        },
        success: function (data) {            
            ApplyChanges(data);
            CloseMessageWindow();
        },
        error: function () {
            CloseMessageWindow();
        }
    });
}

