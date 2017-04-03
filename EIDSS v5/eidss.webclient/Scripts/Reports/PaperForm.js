var paperForm = {
    OpenInNewWindow: function(actionName) {
        if (!paperForm.IsMandatoryFieldsValid()) {
            ShowEidssErrorNotification(EIDSS.BvMessages.ErrAllMandatoryFieldsRequired);
            return;
        }
        var url = paperForm.GetReportPath(actionName);
        var win = window.open(url + "&IsOpenInNewWindow=true", "temp", "width=840,height=670,menubar=yes,toolbar=yes,location=yes,status=yes,scrollbars=auto,resizable=yes");
        win.focus();
    },

    ShowSaveDialog: function(actionName) {
        if (!paperForm.IsMandatoryFieldsValid()) {
            ShowEidssErrorNotification(EIDSS.BvMessages.ErrAllMandatoryFieldsRequired);
            return;
        }
        var url = paperForm.GetReportPath(actionName);
        window.location = url;
    },

    GetReportPath: function(actionName) {
        var url = "/" + GetSiteLanguage() + "/Report/" + actionName + "?" + paperForm.GetSerializedForm();
        return url;
    },

    GetSerializedForm: function() {
        var serializedForm = $("form").serialize();
        return serializedForm;
    },

    IsMandatoryFieldsValid: function() {
        var isValid = true;
        $(".requiredField").each(function(index) {
            var combobox = $(this).data("tComboBox");
            var textbox = $(this).data("tTextBox");
            var datePicker = $(this).data("tDatePicker");
            if ((combobox && !combobox.value()) ||
                (textbox && !textbox.value()) ||
                (datePicker && !datePicker.value())) {
                isValid = false;
                return false;
            }
            if (!combobox && !datePicker && !textbox && !$(this).val()) {
                isValid = false;
                return false;
            }
        });
        return isValid;
    },

    OnStartDateChanged: function(e) {
        paperForm.OnDateChanged(e, true);
    },
    OnEndDateChanged: function(e) {
        paperForm.OnDateChanged(e, false);
    },
    OnDateChanged: function(e, isStartDateChanged) {
        if (e.previousValue == e.value) {
            return;
        }
        var startDate = $('#StartDate').data('tDatePicker');
        var endDate = $('#EndDate').data('tDatePicker');
        if (startDate != null &&
            endDate != null &&
            endDate.value() < startDate.value()) {
            if (isStartDateChanged) {
                startDate.value(endDate.value());
            } else {

                endDate.value(startDate.value());
            }
        }
    },

    OnMonthChanged: function(e) {
        if (e.previousValue == e.value) {
            return;
        }
        var startMonth = $('#StartMonth').data('tComboBox');
        var endMonth = $('#EndMonth').data('tComboBox');
        if (startMonth != null &&
            endMonth != null &&
            endMonth.value() != null &&
            endMonth.value() != "" &&
            parseInt(endMonth.value()) < parseInt(startMonth.value())) {

            endMonth.value(startMonth.value());
        }
    },

    OnStartYearChanged: function(e) {
        paperForm.OnYearChanged(e, true);
    },
    OnEndYearChanged: function(e) {
        paperForm.OnYearChanged(e, false);
    },

    OnYearChanged: function(e, isStartChanged) {
        if (e.oldValue == e.newValue) {
            return;
        }
        var startYear = $('#YearModel_Year1').data('tTextBox');
        var endYear = $('#YearModel_Year2').data('tTextBox');
        if (startYear != null && endYear != null) {
            if (isStartChanged && parseInt(endYear.value()) <= parseInt(e.newValue)) {
                endYear.value(parseInt(e.newValue) + 1);
            }
            if (!isStartChanged && e.newValue <= startYear.value()) {
                startYear.value(parseInt(e.newValue) - 1);
            }
        }
    },

    OnVetStartYearChanged: function(e) {
        paperForm.OnVetYearChanged(e, true);

    },
    OnVetEndYearChanged: function(e) {
        paperForm.OnVetYearChanged(e, false);

    },

    OnVetYearChanged: function(e, isStartChanged) {
        if (e.oldValue == e.newValue) {
            return;
        }
        var startYear = $('#StartYear').data('tTextBox');
        var endYear = $('#EndYear').data('tTextBox');
        if (startYear != null && endYear != null) {
            if (isStartChanged && parseInt(endYear.value()) <= parseInt(e.newValue)) {
                endYear.value(parseInt(e.newValue));
                paperForm.OnVetMonthChangedInternal();
            }
            if (!isStartChanged && e.newValue <= startYear.value()) {
                startYear.value(parseInt(e.newValue));
                paperForm.OnVetMonthChangedInternal();
            }
        }
    },

    OnVetMonthChanged: function(e) {
        if (e.previousValue == e.value) {
            return;
        }
        var startYear = $('#StartYear').data('tTextBox');
        var endYear = $('#EndYear').data('tTextBox');

        if (startYear != null &&
            endYear != null &&
            startYear.value() != null &&
            endYear.value() != null &&
            parseInt(endYear.value()) == parseInt(startYear.value())) {

            paperForm.OnVetMonthChangedInternal();
        }

    },

    OnVetMonthChangedInternal: function() {
        var startMonth = $('#StartMonth').data('tComboBox');
        var endMonth = $('#EndMonth').data('tComboBox');

        if (startMonth != null &&
            endMonth != null &&
            endMonth.value() != null &&
            endMonth.value() != "" &&
            parseInt(endMonth.value()) < parseInt(startMonth.value())) {

            endMonth.value(startMonth.value());
        }
    },

    OnRegionChanged: function(e) {
        paperForm.OnRegionInternalChanged(e, '#Address_RayonId');
        paperForm.ShowHideFormNo1OrganizationOrAddress();
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

    OnRegionInternalChanged: function(e, childComboboxName) {
        if (e.previousValue == e.value) {
            return;
        }
        var regionId = $('#' + e.target.id).data('tComboBox').value();
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetRayons?RegionId=" + regionId;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, childComboboxName);
    },

    ShowHideComparativeOrganizationOrAddress: function(e) {
        var organization = $('#OrganizationCHE').data('tComboBox');
        var region1 = $('#Address1_RegionId').data('tComboBox');
        var rayon1 = $('#Address1_RayonId').data('tComboBox');
        var region2 = $('#Address2_RegionId').data('tComboBox');
        var rayon2 = $('#Address2_RayonId').data('tComboBox');
        if (organization != null
            && region1 != null && rayon1 != null
            && region2 != null && rayon2 != null) {

            if (parseInt(organization.value()) > 0) {
                region1.disable();
                rayon1.disable();
                region2.disable();
                rayon2.disable();

            } else {
                region1.enable();
              //  rayon1.enable();
                region2.enable();
             //   rayon2.enable();

            }
            if (parseInt(region1.value()) > 0 || parseInt(region2.value()) > 0) {
                organization.disable();

            } else {
                organization.enable();
            }

        }
    },
    ShowHideFormNo1OrganizationOrAddress: function(e) {
        var organization = $('#OrganizationCHE').data('tComboBox');
        var region = $('#Address_RegionId').data('tComboBox');
        var rayon = $('#Address_RayonId').data('tComboBox');
        if (organization != null && region != null && rayon != null) {

            if (parseInt(organization.value()) > 0) {
                region.disable();
                rayon.disable();
            } else {
                region.enable();
             //   rayon.enable();
            }

            if (parseInt(region.value()) > 0 ) {
                organization.disable();
            } else {
                organization.enable();
            }
        }
    },
    OnPeriodTypeChanged: function(e) {
        if (e.previousValue == e.value) {
            return;
        }
        var childComboboxName = '#Period';
        var periodIndex = $(childComboboxName).data('tComboBox').value();
        var periodTypeIndex = $('#' + e.target.id).data('tComboBox').value();
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetReportingPeriodList?PeriodType=" + periodTypeIndex + '&Period=' + periodIndex;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, childComboboxName);
    },

    OnParentComboboxChanged: function(e, getDataSourceUrl, childComboboxName) {
        if (e.previousValue == e.value) {
            return;
        }
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
        var childCombobox = $(childComboboxName).data('tComboBox');
        if (!dataSource) {
            childCombobox.value(null);
            childCombobox.disable();
            return;
        }
        childCombobox.dataBind(dataSource);
        childCombobox.enable();
    }
};