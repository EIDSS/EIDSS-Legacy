var farm = (function () {
    var formNumber = "V04";
    var bShowPickerAutomatically = "false";

    return {
        initInlinePicker: function (btnShowPickerId, isSearchButtonReadOnly, isShowPickerAutomatically, pickerWrapId) {
            bShowPickerAutomatically = isShowPickerAutomatically;
            var btnShowPicker = $("#" + btnShowPickerId);
            if (isSearchButtonReadOnly.toString().toLowerCase() == 'true') {
                btnShowPicker.attr('disabled', 'disabled');
            } else {
                btnShowPicker.removeAttr('disabled');
            }

            $("#" + pickerWrapId + ":has(.requiredField)").addClass('requiredField');

            if (isShowPickerAutomatically.toString().toLowerCase() == 'true') {
                farm.showSearchPicker();
            }
        },

        showSearchPicker: function () {
            var pickerUrl = bvUrls.getFarmPickerUrl();
            var title = EIDSS.BvMessages['titleSelectFarm'];
            searchPicker.show(pickerUrl, title, formNumber);
        },
        

        onSearchPickerSelectSuccess: function (name) {
            bvGrid.reloadById(name);
            if ($("input[type='hidden'][name='Address']").length > 0) {
                var id = $("input[type='hidden'][name='Address']")[0].value;
                comboBoxFacade.reloadReferenceComboBox2WithoutClearValue("Address_" + id + "_*", 'Region');
                comboBoxFacade.reloadReferenceComboBox2WithoutClearValue("Address_" + id + "_*", 'Rayon');
                comboBoxFacade.reloadReferenceComboBox2WithoutClearValue("Address_" + id + "_*", 'Settlement');
            }
        },
        
        onSearchPickerSelect: function () {
            var selectedItemId = searchPicker.getSelectedIds();
            if (selectedItemId) {
                var idfarm = $("input[type='hidden'][name$='idfRootFarm']");
                var idfarmEditing = idfarm.val();
                if (idfarmEditing != selectedItemId) {
                    var asFarms = $("input[type='hidden'][name$='ASFarms']");
                    if (asFarms.length > 0) {
                        var asFarmsList = asFarms.val();
                        var arrFarmsList = asFarmsList.split(',');
                        for (var i = 0; i < arrFarmsList.length; i++) {
                            if (arrFarmsList[i].length > 0) {
                                var arrFarm = arrFarmsList[i].split('=');
                                var idFarmRoot = arrFarm[0];
                                var idFarm = arrFarm[1];
                                if (idFarmRoot == selectedItemId) {
                                    var asFKey = $("input[type='hidden'][name$='ASFKey']").val();
                                    var asFName = $("input[type='hidden'][name$='ASFName']").val();
                                    var asFdetails = $("input[type='hidden'][name$='ASFdetails']").val();
                                    searchPicker.closePicker();
                                    if (asFdetails == "true") {
                                        asSession.RedirectToFarmDetails(idFarm, asFKey, asFName);
                                    } else {
                                        asSession.RedirectToFarmSummary(idFarm, asFKey, asFName);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                    
                    idfarm.val(selectedItemId);
                    formRefresher.setOnChangedSuccess(farm.onSearchPickerSelectSuccess, 'FarmTree');
                    formRefresher.onFieldChanged(idfarm.attr('name'), selectedItemId);
                }
                searchPicker.closePicker();
            } else {
                searchPicker.closePicker();
            }
        },
        
        closePicker: function (showInInternalWindow, propertyName) {
            searchPicker.closePicker(showInInternalWindow, propertyName);
            if (bShowPickerAutomatically.toString().toLowerCase() == 'true') {
                detailPage.close();
            }
        },

    };
})();