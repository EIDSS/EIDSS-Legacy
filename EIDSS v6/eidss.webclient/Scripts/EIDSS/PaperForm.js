var paperForm = {
    OpenInNewWindow: function(actionName,arrForRename) {
        if (!paperForm.IsMandatoryFieldsValid()) {
            bvDialog.showError(EIDSS.BvMessages.ErrAllMandatoryFieldsRequired);
            return;
        }
        var url = paperForm.GetReportPath(actionName, arrForRename);
        var dt = new Date();
        
        var now = dt.getHours() + "_" + dt.getMinutes() + "_" + dt.getSeconds() + "_" + dt.getMilliseconds();
        var win = window.open(url + "&IsOpenInNewWindow=true", "temp" + now, "width=840,height=670,menubar=yes,toolbar=yes,location=yes,status=yes,scrollbars=auto,resizable=yes");
        win.focus();
    },

    ShowSaveDialog: function (actionName, arrForRename) {
        if (!paperForm.IsMandatoryFieldsValid()) {
            bvDialog.showError(EIDSS.BvMessages.ErrAllMandatoryFieldsRequired);
            return;
        }
        var url = paperForm.GetReportPath(actionName, arrForRename);
        detailPage.openReport(url);
    },

    GetReportPath: function (actionName, arrForRename) {
        var url = "/" + GetSiteLanguage() + "/Report/" + actionName + "?" + paperForm.GetSerializedForm(arrForRename);
        return url;
    },

    GetSerializedForm: function (arrForRename) {
        var serializedForm = $("form").formSerialize();
        if ((arrForRename != null) && (arrForRename.length > 0)) {
            for (var i = 0; i < arrForRename.length; i++) {
                var originalName = arrForRename[i];
                var kendoName = originalName.replace(".", "_");
                serializedForm = serializedForm.replace(kendoName, originalName);
            }
        }
        return serializedForm;
    },

    CheckItemsCount: function (cbName) {
        var combobox = comboBoxFacade.getControlData(cbName);
    },

    IsMandatoryFieldsValid: function () {
        var isValid = true;
        //return isValid;
        $(".requiredField").each(function (index) {
            var ctrl = $(this)[0];
            if ((ctrl.id != null) && (ctrl.id != "")) {
                var combobox = comboBoxFacade.getControlData(ctrl.id);
                //var datePicker = datePickerFacade.getControlData(ctrl.id);
                if ((ctrl.value == null) || (ctrl.value == "") || (combobox != null && combobox.text() == "")) {
                    isValid = false;
                    return false;
                }
                //if ((combobox && !combobox.value()) ||
                //    (datePicker && !datePicker.value() )||
                //    (ctrl && !ctrl.value())
                //    ) {
                //    isValid = false;
                //    return false;
                //}
            }
            //var combobox = comboBoxFacade.getControlData($(this).get_id);//$(this).data("kendoComboBox");//
            //var textbox = $(this).data("tTextBox");//
            //var datePicker = datePickerFacade.getControlData($(this).get_id);//$(this).data("tDatePicker");//
            //if ((combobox && !combobox.value()) ||
            //    (textbox && !textbox.value()) ||
            //    (datePicker && !datePicker.value())) {
            //    isValid = false;
            //    return false;
            //}
            
            //if (!combobox && !datePicker && !textbox && !$(this).val()) {
            //    isValid = false;
            //    return false;
            //}
        });
        return isValid;
    },

    OnStartDateChanged: function(e) {
        paperForm.OnDateChanged(e, true);
    },
    OnEndDateChanged: function(e) {
        paperForm.OnDateChanged(e, false);
    },
    
    OnStartDateChangedEx: function (e) {
        paperForm.OnDateChanged(e, true, true);
    },
    OnEndDateChangedEx: function (e) {
        paperForm.OnDateChanged(e, false, true);
    },


    OnDateChanged: function(e, isStartDateChanged, specialRules) {
        if (specialRules == null) specialRules = false;

        var sd = $('#StartDate').data('kendoDatePicker');
        var ed = $('#EndDate').data('kendoDatePicker');
        if (sd == null || ed == null) return;
        var startDate = sd.value();
        var endDate = ed.value();
        if (startDate == null || endDate == null) return;
        
        if (specialRules == true) {
            if (isStartDateChanged && (startDate > endDate)) {
                ed.value(startDate);
            } else if (!isStartDateChanged && (endDate < startDate)) {
                sd.value(endDate);
            }
        } else {
            if (endDate.value() < startDate.value()) {
                if (isStartDateChanged) {
                    startDate.value(endDate.value());
                } else {
                    endDate.value(startDate.value());
                }
            }
        }
    },

    OnMonthChanged: function() {
        var startMonth = $('#StartMonth').data('kendoComboBox');
        var endMonth = $('#EndMonth').data('kendoComboBox');
        if (startMonth != null &&
            endMonth != null) {
            if (startMonth.value() == null || startMonth.value() == "") {
                endMonth.value(null);
                endMonth.enable(false);
                return;
            }
            endMonth.enable(true);
            if (endMonth.value() != null &&
                endMonth.value() != "" &&
                parseInt(endMonth.value()) < parseInt(startMonth.value())) {
                endMonth.value(startMonth.value());
            }
        }
    },
    OnMonthChanged1: function (e) {
        //if (e.previousValue == e.value) {
        //    return;
        //}
        var startMonth = $('#StartMonth').data('kendoComboBox');
        var endMonth = $('#EndMonth').data('kendoComboBox');
        if (startMonth != null &&
            endMonth != null) {
            if (startMonth.value() == null || startMonth.value() == "") {
                endMonth.value(null);
                endMonth.enable(false);
                return;
            }
            endMonth.enable(true);
            if (endMonth.value() != null &&
                endMonth.value() != "" &&
                parseInt(endMonth.value()) < parseInt(startMonth.value())) {
                endMonth.value(startMonth.value());
            }
            else if ((endMonth.value() == null ||
                endMonth.value() == "")){
                endMonth.value(startMonth.value());
            }
        }
    },

    OnStartYearChanged: function(e) {
        paperForm.OnYearChanged(e, true);
    },
    OnEndYearChanged: function(e) {
        paperForm.OnYearChanged(e, false);
    },
    //rule year2>year1
    OnYearChanged: function(e, isStartChanged) {
        //if (e.oldValue == e.newValue) {
        //    return;
        //}
        var year1 = $('#YearModel_Year1').data().kendoNumericTextBox;
        var year2 = $('#YearModel_Year2').data().kendoNumericTextBox;
        if (year1 != null && year2 != null) {
            if (e.sender == year1  && year1._value >= year2._value) {
               year1.value(year2._value - 1);
            }
            if (e.sender == year2 && year1._value >= year2._value) {
                year2.value(year1._value + 1);
            }
        }
    },

    OnVetStartYearChanged: function(e) {
        paperForm.OnVetYearChanged(true);

    },
    OnVetEndYearChanged: function(e) {
        paperForm.OnVetYearChanged(false);

    },

    OnVetYearChanged: function(isStartChanged) {
        var startYear = $('#StartYear').val();
        var endYear = $('#EndYear').val();
        if ((startYear == null || endYear == null)) return;
        var startYearInt = parseInt(startYear);
        var endYearInt = parseInt(endYear);
        if (startYearInt > 0 && endYearInt > 0) {
            if (isStartChanged && (endYearInt <= startYearInt)) {
                numericTextBoxFacade.setValueById("EndYear", startYearInt);
                //$('#EndYear').val(startYearInt);
                paperForm.OnVetMonthChangedInternal();
            }
            if (!isStartChanged && (endYearInt <= startYearInt)) {
                numericTextBoxFacade.setValueById("StartYear", endYearInt);
                //$('#StartYear').val(endYearInt);
                paperForm.OnVetMonthChangedInternal();
            }
        }
    },

    OnVetMonthChanged: function(e) {
        var startYear = $('#StartYear').val();
        var endYear = $('#EndYear').val();
        if ((startYear == null || endYear == null)) return;
        var startYearInt = parseInt(startYear);
        var endYearInt = parseInt(endYear);
        if (startYearInt == endYearInt) {
            paperForm.OnVetMonthChangedInternal();
        }
    },

    OnVetMonthChangedInternal: function () {
        var startMonth = $('#StartMonth').val();
        var endMonth = $('#EndMonth').val();
        if ((startMonth == null || endMonth == null)) return;
        var startMonthInt = parseInt(startMonth);
        var endMonthInt = parseInt(endMonth);

        if (startMonthInt > endMonthInt) {
            comboBoxFacade.setValueById("EndMonth", startMonthInt);
        }
    },

    OnRegionChanged: function(e) {
        paperForm.OnRegionInternalChanged(e, '#Address_RayonId', '#Address_SettlementId');
        paperForm.ShowHideFormNo1OrganizationOrAddress();
    },
    OnTransportCHERegionChanged: function (e) {
        paperForm.OnTransportCHERegionInternalChanged(e, '#Address_RayonId');
    },

    OnRegionMultiselectChanged: function (e) {
        paperForm.OnRegionMultiselectInternalChanged(e, '#RayonList');
    },
    
    OnRayonChanged: function (e) {
        paperForm.OnRayonInternalChanged(e, '#Address_RegionId', '#Address_SettlementId');
    },
    
    OnFormNo1OrganizationChanged: function (e) {
        paperForm.ShowHideFormNo1OrganizationOrAddress(e);
    },

    OnComparativeTwoYearsOrganizationChanged: function (e) {
        paperForm.ShowHideFormNo1OrganizationOrAddress(e);
    },

    OnRegion1Changed: function(e) {
        paperForm.OnRegionInternalChanged(e, '#Address1_RayonId');
        paperForm.ShowHideComparativeOrganizationOrAddress();
    },
    OnRegion2Changed: function(e) {
        paperForm.OnRegionInternalChanged(e, '#Address2_RayonId');
        paperForm.ShowHideComparativeOrganizationOrAddress();
    },
    OnRayon1Changed: function(e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },
    OnRayon2Changed: function(e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },
    OnComparativeOrganizationChanged: function(e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },

    OnTransportCHERegionInternalChanged: function (e, rayonComboboxName) {
        if (e.sender == null) {
            return;
        }
        var regionId = e.sender._selectedValue;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetTransportCHERayons?RegionId=" + regionId;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, rayonComboboxName);
    },
    OnRegionInternalChanged: function (e, rayonComboboxName, settlementComboboxName) {
        if (e.sender == null) {
            return;
        }
//        if (e.previousValue == e.value) {
//            return;
//        }
        //     var regionId = $('#' + e.sender._optionID).data('kendoComboBox').value();
        var regionId = e.sender._selectedValue;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetRayons?RegionId=" + regionId;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, rayonComboboxName);
        if (settlementComboboxName != null) {
            var childCombobox = $(settlementComboboxName).data('kendoComboBox');
            if (childCombobox != null) {
                childCombobox.value(null);
                childCombobox.enable(false);
            }
        }
    },
    
    OnRegionMultiselectInternalChanged: function (e, rayonDropdownName) {
        if (e.sender == null) return;
        
        var regions = e.sender.value();
        if (regions == null || regions == '') return;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetRayonsList?RegionsSelected=" + regions;

        paperForm.OnParentDropdownChanged(e, getDataSourceUrl, rayonDropdownName);
    },
    
    OnRayonInternalChanged: function (e, regionComboboxName, settlementComboboxName) {
        if (e.sender == null) {
            return;
        }
        //        if (e.previousValue == e.value) {
        //            return;
        //        }
        //     var regionId = $('#' + e.sender._optionID).data('kendoComboBox').value();
        var cb = $("#Address_RegionId").data('kendoComboBox');
        var regionId = cb != null ? cb.value() : "0";
        var rayonId = e.sender._selectedValue;
        
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetSettlements?RayonId=" + rayonId + "&RegionId=" + regionId;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, settlementComboboxName);
    },

    ShowHideComparativeOrganizationOrAddress: function(e) {
        var organization = $('#OrganizationCHE').data('kendoComboBox');
        var region1 = $('#Address1_RegionId').data('kendoComboBox');
        var rayon1 = $('#Address1_RayonId').data('kendoComboBox');
        var region2 = $('#Address2_RegionId').data('kendoComboBox');
        var rayon2 = $('#Address2_RayonId').data('kendoComboBox');
        if (organization != null
            && region1 != null && rayon1 != null
            && region2 != null && rayon2 != null) {

            if (parseInt(organization.value()) > 0) {
                region1.enable(false);
                rayon1.enable(false);
                region2.enable(false);
                rayon2.enable(false);

            } else {
                region1.enable();
              //  rayon1.enable();
                region2.enable();
             //   rayon2.enable();

            }
            if (parseInt(region1.value()) > 0 || parseInt(region2.value()) > 0) {
                organization.enable(false);

            } else {
                organization.enable();
            }

        }
    },
    ShowHideFormNo1OrganizationOrAddress: function(e) {
        var organization = $('#OrganizationCHE').data('kendoComboBox');
        var region = $('#Address_RegionId').data('kendoComboBox');
        var rayon = $('#Address_RayonId').data('kendoComboBox');
        if (organization != null && region != null && rayon != null) {

            if (parseInt(organization.value()) > 0) {
                region.enable(false);
                rayon.enable(false);
            } else {
                region.enable();
             //   rayon.enable();
            }

            if (parseInt(region.value()) > 0 ) {
                organization.enable(false);
            } else {
                organization.enable();
            }
        }
    },
    
    OnPeriodTypeChanged: function() {
        var periodTypeIndex = $('#PeriodType').data('kendoComboBox').value();
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetReportingPeriodList?PeriodType=" + periodTypeIndex;

        paperForm.OnParentDropdownChanged(null, getDataSourceUrl, '#Period');
    },
    
    OnParentDropdownChanged: function (e, getDataSourceUrl, childDropdownName) {
        //        if (e.previousValue == e.value) {
        //            return;
        //        }
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {

            },
            success: function (data) {
                paperForm.UpdateChildchildDropdownName(data, childDropdownName);
            }
        });
    },

    OnParentComboboxChanged: function(e, getDataSourceUrl, childComboboxName) {
//        if (e.previousValue == e.value) {
//            return;
//        }
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {
                
            },
            success: function(data) {
                paperForm.UpdateChildCombobox(data, childComboboxName);
            }
        });
    },

    UpdateChildCombobox: function(dataSource, childComboboxName) {
        var childCombobox = $(childComboboxName).data('kendoComboBox');
        if (childCombobox != null) {
            if (!dataSource) {
                childCombobox.value(null);
                childCombobox.enable(false);
                return;
            }
            childCombobox.setDataSource(dataSource);
            if(dataSource.length>0)
                childCombobox.value(dataSource[0].Value);
            else
                childCombobox.value(null);
            childCombobox.enable();
        }
    },
    
    UpdateChildchildDropdownName: function (dataSource, childDropdownName) {
        var childDropdown = $(childDropdownName).data('kendoDropDownList');
        if (childDropdown != null) {
            if (!dataSource) {
                childDropdown.setDataSource(null);
                childDropdown.value(null);
                childDropdown.enable(false);
                return;
            }
            childDropdown.setDataSource(dataSource);
            childDropdown.value(null);
            childDropdown.enable();
        }
    },
    
    OnYearForQuarterChanged: function (e) {
        var year = $('#Year').val();
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetQuartersList?Year=" + year;
        paperForm.OnParentDropdownChanged(e, getDataSourceUrl, "#QuarterList");
    },
    
    OnReportSourceChanged: function (e) {
        var val = $('#cbReportSource').val();
        if (val == null) return;
        var caseid = $('#CaseId');
        var sessionId = $('#SessionId');
        caseid.removeClass("requiredField");
        if (val == "1") {
            caseid.removeAttr('disabled', 'disabled');
            caseid.addClass("requiredField");
            sessionId.attr('disabled', 'disabled');
            sessionId.removeClass("requiredField");
            sessionId.val('');
        } else if (val == "2") {
            caseid.attr('disabled', 'disabled');
            caseid.removeClass("requiredField");
            caseid.val('');
            sessionId.removeAttr('disabled', 'disabled');
            sessionId.addClass("requiredField");
        } else {
            caseid.attr('disabled', 'disabled');
            sessionId.attr('disabled', 'disabled');
            caseid.removeClass("requiredField");
            sessionId.removeClass("requiredField");
            caseid.val('');
            sessionId.val('');
        }
    },
};