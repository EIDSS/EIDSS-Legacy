var paperForm = {
    OpenInNewWindow: function (actionName, arrForRename) {
        if (!paperForm.IsMandatoryFieldsValid()) {
            bvDialog.showError(EIDSS.BvMessages.ErrAllMandatoryFieldsRequired);
            return;
        }
        if (!paperForm.ValidateForm()) return;
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
        if (!paperForm.ValidateForm()) return;
        var url = paperForm.GetReportPath(actionName, arrForRename);
        detailPage.openReport(url);
    },

    GetReportPath: function (actionName, arrForRename) {
        var url = "/" + GetSiteLanguage() + "/Report/" + actionName + "?" + paperForm.GetSerializedForm(arrForRename);
        return url;
    },

    ValidateForm: function () {
        var form = paperForm.GetSerializedForm(null);
        var urlValidate = "/" + GetSiteLanguage() + "/Report/Validate";
        var result = true;
        $.ajax({
            url: urlValidate,
            async: false,
            dataType: "json",
            type: "POST",
            data: form,
            success: function (data) {
                if (data.message != null && data.message != "") {
                    bvDialog.showError(data.message);
                }
                result = data.isSuccess;
            }
        });
        return result;
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

    OnStartDateChanged: function (e) {
        paperForm.OnDateChanged(e, true);
    },
    OnEndDateChanged: function (e) {
        paperForm.OnDateChanged(e, false);
    },

    OnStartDateChangedEx: function (e) {
        paperForm.OnDateChanged(e, true, true);
    },
    OnEndDateChangedEx: function (e) {
        paperForm.OnDateChanged(e, false, true);
    },

    OnDateChanged: function (e, isStartDateChanged, specialRules) {
        if (specialRules == null) specialRules = false;

        var sd = $('#StartDate').data('kendoDatePicker');
        var ed = $('#EndDate').data('kendoDatePicker');
        if (sd == null || ed == null) return;
        var startDate = sd.value();
        var endDate = ed.value();
        if (startDate == null || endDate == null) return;
        var message = sd.element[0].getAttribute("validationMessage");
        if (message != undefined && message != '') {
            if (startDate >= endDate) {
                bvDialog.showError(eval('EIDSS.BvMessages.' + message));
                if (isStartDateChanged) {
                    var oldStartDate = $('#StartDate').data('previous');
                    if (oldStartDate != undefined)
                        sd.value(oldStartDate);
                    else
                        sd.value('');
                } else {
                    var oldEndDate = $('#EndDate').data('previous');
                    if (oldEndDate != undefined)
                        ed.value(oldEndDate);
                    else
                        ed.value('');
                }
            } else {
                if (isStartDateChanged)
                    $('#StartDate').data('previous', startDate);
                else
                    $('#EndDate').data('previous', endDate);

            }
            return;
        }

        if (specialRules == true) {
            if (isStartDateChanged && (startDate > endDate))
                ed.value(startDate);
            else if (!isStartDateChanged && (endDate < startDate))
                sd.value(endDate);
        } else {
            if (endDate < startDate) {
                if (isStartDateChanged)
                    startDate.value(endDate);
                else
                    endDate.value(startDate);
            }
        }

    },

    OnMonthChangedYearsAZ: function (e) {
        var startYear = $('#StartYear').val();
        var endYear = $('#EndYear').val();
        if (startYear != null && endYear != null) {
            var startYearInt = parseInt(startYear);
            var endYearInt = parseInt(endYear);

            if (startYearInt > 0 && endYearInt > 0 && startYearInt == endYearInt)
                paperForm.OnMonthChangedAZInternal(e);
            else
                paperForm.OnMonthChangedAZInternal(e, "years");
        } else
            paperForm.OnMonthChangedAZInternal(e);
    },

    OnMonthChangedAZ: function (e) {
        paperForm.OnMonthChangedAZInternal(e);
    },

    OnMonthChangedAZInternal: function (e, years) {
        var startMonth = $('#StartMonth').data('kendoComboBox');
        var endMonth = $('#EndMonth').data('kendoComboBox');
        var thisMonth, otherMonth;
        if (startMonth != null && endMonth != null) {
            if (e.sender == startMonth) {
                thisMonth = startMonth;
                otherMonth = endMonth;
            } else {
                thisMonth = endMonth;
                otherMonth = startMonth;
            }

            if (thisMonth.value() == null || thisMonth.value() == "") {
                otherMonth.value(null);
                return;
            }
            if (otherMonth.value() == null || otherMonth.value() == "") {
                otherMonth.value(thisMonth.value());
                return;
            }

            if (years != "years" && parseInt(endMonth.value()) < parseInt(startMonth.value())) {
                if (e.sender == startMonth || e.sender == endMonth)
                    otherMonth.value(thisMonth.value());
                else {
                    thisMonth.value(null);
                    otherMonth.value(null);
                }
            }
        }
    },
    OnMonthChangedKZ: function () {
        var startMonth = $('#StartMonth').data('kendoComboBox');
        var endMonth = $('#EndMonth').data('kendoComboBox');
        if (startMonth != null && endMonth != null) {
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
    OnIQMonthSelect: function (e) {
        var startMonth = $('#StartMonth').data('kendoDropDownList');
        var selected = this.dataItem(e.item.index());
        if (selected.Value == null ||
            selected.Value == "" ||
            parseInt(selected.Value) < parseInt(startMonth.value())) {
            e.preventDefault();
        }
    },
    OnIQMonthChanged: function (e) {
        var startMonth = $('#StartMonth').data('kendoDropDownList');
        var endMonth = $('#EndMonth').data('kendoDropDownList');
        if (startMonth != null && endMonth != null) {
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
            } else if ((endMonth.value() == null ||
                endMonth.value() == "")) {
                endMonth.value(startMonth.value());
            }
        }
    },

    IQValidateYears: function (e) {
        if (!paperForm.ValidateYears(e))
            bvDialog.showError(EIDSS.BvMessages.msgComparativeReportIQCorrectYear);
    },

    THValidateYears: function (e) {
        if (!paperForm.ValidateYears(e))
            bvDialog.showError(EIDSS.BvMessages.msgComparativeReportTHCorrectYear);
    },
    //rule year2>year1
    findStartYearControl: function () {
        var names = ["#StartYear", "#YearModel_StartYear", "#Year1", "#YearModel_Year1"];
        for (var i = 0; i < names.length; i++) {
            if ($(names[i]) != null && $(names[i]).data() != null)
                return $(names[i]).data().kendoNumericTextBox;
        }
        return null;
    },
    findEndYearControl: function () {
        var names = ["#EndYear", "#YearModel_EndYear", "#Year2", "#YearModel_Year2"];
        for (var i = 0; i < names.length; i++) {
            if ($(names[i]) != null && $(names[i]).data() != null)
                return $(names[i]).data().kendoNumericTextBox;
        }
        return null;
    },

    findYearControl: function () {
        var names = ["#Year"];
        for (var i = 0; i < names.length; i++) {
            if ($(names[i]) != null && $(names[i]).data() != null)
                return $(names[i]).data().kendoNumericTextBox;
        }
        return null;
    },

    //shall return true if year 1 < year 2
    ValidateYears: function (e) {
        var year1 = paperForm.findStartYearControl();
        var year2 = paperForm.findEndYearControl();
        var year1Old = document.getElementById('StartYearOld');
        var year2Old = document.getElementById('EndYearOld');
        var reverseValidation = (year1.element[0].getAttribute("reverse") == "1");
        var result = false;
        if (year1 != null && year2 != null) {
            if (reverseValidation)
                result = year1._value != null && year2._value != null && year1._value > year2._value;
            else
                result = year1._value != null && year2._value != null && year1._value < year2._value;

            if (e.sender == year1 && (year1._value == null || result == false)) {
                if (year1Old != null && year1Old.value != null && year1Old.value != "") {
                    year1.value(parseInt(year1Old.value));
                } else
                    year1.value(!reverseValidation ? year2._value - 1 : year2._value + 1);
            }
            if (e.sender == year2 && (year2._value == null || result == false)) {
                if (year2Old != null && year2Old.value != null && year2Old.value != "") {
                    year2.value(parseInt(year2Old.value));
                } else
                    year2.value(!reverseValidation ? year1._value + 1 : year2._value - 1);
            }
            if (e.sender == year1 && year1Old != null)
                year1Old.value = year1._value;
            if (e.sender == year2 && year2Old != null)
                year2Old.value = year2._value;
        }
        if (!result) {
            var message = year1.element[0].getAttribute("validationMessage");
            if (message != undefined && message != '') {
                bvDialog.showError(eval('EIDSS.BvMessages.' + message));
            }
        }
        return result;
    },
    OnVetYearChanged: function (e) {
        var startYear = $('#StartYear').val();
        var endYear = $('#EndYear').val();
        if ((startYear == null || endYear == null)) return;
        var startYearInt = parseInt(startYear);
        var endYearInt = parseInt(endYear);
        if (startYearInt > 0 && endYearInt > 0) {
            if (e.sender._value == startYear) {
                if (endYearInt <= startYearInt)
                    numericTextBoxFacade.setValueById("EndYear", startYearInt);
                paperForm.OnYearMonthChanged(e);
            } else {
                if (endYearInt <= startYearInt)
                    numericTextBoxFacade.setValueById("StartYear", endYearInt);
                paperForm.OnYearMonthChanged(e);
            }
        }
    },

    OnYearMonthChanged: function (e) {
        var startYear = $('#StartYear').val();
        var endYear = $('#EndYear').val();
        if ((startYear == null || endYear == null)) return;
        var startYearInt = parseInt(startYear);
        var endYearInt = parseInt(endYear);
        if (startYearInt == endYearInt)
            paperForm.OnMonthChangedAZInternal(e);
        else
            paperForm.OnMonthChangedAZInternal(e, "years");
    },

    OnRegionChanged: function (e) {
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

    OnRegion1Changed: function (e) {
        paperForm.OnRegionInternalChanged(e, '#Address1_RayonId');
        paperForm.ShowHideComparativeOrganizationOrAddress();
    },
    OnRegion2Changed: function (e) {
        paperForm.OnRegionInternalChanged(e, '#Address2_RayonId');
        paperForm.ShowHideComparativeOrganizationOrAddress();
    },
    OnRayon1Changed: function (e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },
    OnRayon2Changed: function (e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },
    OnComparativeOrganizationChanged: function (e) {
        paperForm.ShowHideComparativeOrganizationOrAddress(e);
    },

    OnTransportCHERegionInternalChanged: function (e, rayonComboboxName) {
        if (e.sender == null) {
            return;
        }
        var regionId = e.sender._selectedValue;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetTransportCHERayons?RegionId=" + regionId;

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, rayonComboboxName, false);
    },

    OnYearCustomChanged: function (e) {
        var year = $('#Year').val();
        var weeksFilterName = '#WeeksFilter_WeekId';
        var weeksFilter = $(weeksFilterName);
        if (weeksFilter != null) {
            var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetWeeks?year=" + year;
            paperForm.OnParentComboboxChanged(e, getDataSourceUrl, weeksFilterName, false);
        }
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

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, rayonComboboxName, false);
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

        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, settlementComboboxName, false);
    },

    ShowHideComparativeOrganizationOrAddress: function (e) {
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
    ShowHideFormNo1OrganizationOrAddress: function (e) {
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

            if (parseInt(region.value()) > 0) {
                organization.enable(false);
            } else {
                organization.enable();
            }
        }
    },

    OnPeriodTypeChanged: function () {
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
                paperForm.UpdateChildDropdown(data, childDropdownName);
            }
        });
    },

    OnParentComboboxChanged: function (e, getDataSourceUrl, childComboboxName, clearChildData) {
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
                paperForm.UpdateChildCombobox(data, childComboboxName, clearChildData);
            }
        });
    },

    UpdateChildCombobox: function (dataSource, childComboboxName, clearValue) {
        var childCombobox = $(childComboboxName).data('kendoComboBox');
        if (childCombobox != null) {
            if (!dataSource) {
                childCombobox.value(null);
                childCombobox.enable(false);
                return;
            }
            childCombobox.setDataSource(dataSource);
            if (childCombobox.selectedIndex < 0) {
                if (dataSource.length > 0 && !clearValue)
                    childCombobox.value(dataSource[0].Value);
                else
                    childCombobox.value(null);
            }
            childCombobox.enable();
        }
    },

    UpdateChildDropdown: function (dataSource, childDropdownName) {
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

    SetThaiYear: function (yearElem, lang) {
        var thaiYarShift = 543;
        var minThaiYear = 2550;
        var minYear = 2000;
        if (yearElem != null && yearElem != "undefined") {
            var curLang = yearElem.element[0].getAttribute("lang");
            if (curLang != null) {
                yearElem.element[0].setAttribute("lang", lang);
                if (curLang == 'th' && lang != 'th') {
                    yearElem.options.max = yearElem.options.max - thaiYarShift;
                    yearElem.options.min = minYear;
                    yearElem.value(yearElem._value - thaiYarShift);
                } else if (curLang != 'th' && lang == 'th') {
                    yearElem.options.max = yearElem.options.max + thaiYarShift;
                    yearElem.options.min = minThaiYear;
                    yearElem.value(yearElem._value + thaiYarShift);
                }

            }
        }

    },
    SetThaiDate: function (dateElem, lang) {
        if (dateElem != null) {
            var curLang = dateElem.element[0].getAttribute("lang");
            if (curLang != null) {
                dateElem.element[0].setAttribute("lang", lang);
                var saveVal = dateElem.value();
                if (curLang == 'th' && lang != 'th') {
                    dateElem.value(null);
                    kendo.forceThaiDate = false;
                    kendo.forceGrigDate = true;
                    dateElem.clearInit();
                    dateElem.value(saveVal);
                    //todo: switch date control to grigorian calendar
                } else if (curLang != 'th' && lang == 'th') {
                    dateElem.value(null);
                    kendo.forceThaiDate = true;
                    kendo.forceGrigDate = false;
                    dateElem.clearInit();
                    dateElem.value(saveVal);
                    //todo: switch date control to Thai calendar
                }
            }
        }

    },
    findStarDateControl: function () {
        var name = "#StartDate";
        if ($(name) != null && $(name).data('kendoDatePicker') != null)
            return $(name).data('kendoDatePicker');
        return null;
    },
    findEndDateControl: function () {
        var name = "#EndDate";
        if ($(name) != null && $(name).data('kendoDatePicker') != null)
            return $(name).data('kendoDatePicker');
        return null;

    },
    OnLanguageChanged: function (e) {
        var lang = e.sender._selectedValue;
        var yearCtl = paperForm.findStartYearControl();
        if (yearCtl != null)
            paperForm.SetThaiYear(yearCtl, lang);
        yearCtl = paperForm.findEndYearControl();
        if (yearCtl != null)
            paperForm.SetThaiYear(yearCtl, lang);
        yearCtl = paperForm.findYearControl();
        if (yearCtl != null)
            paperForm.SetThaiYear(yearCtl, lang);
        var dateCtl = paperForm.findStarDateControl();
        if (dateCtl != null)
            paperForm.SetThaiDate(dateCtl, lang);
        dateCtl = paperForm.findEndDateControl();
        if (dateCtl != null)
            paperForm.SetThaiDate(dateCtl, lang);
    },
    OnThaiProvinceChanged: function (e) {
        paperForm.OnThaiProvinceInternalChanged(e, '#District_DistrictId');
    },

    OnThaiProvinceInternalChanged: function (e, districtComboboxName) {
        if (e.sender == null) {
            return;
        }
        var provinceId = e.sender._selectedValue;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetDistricts?ProvinceId=" + provinceId;
        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, districtComboboxName, true);
    },
    OnThaiRegionChanged: function (e) {
        var zone = $('#ZoneFilter_CheckedItems').data('kendoDropDownList');
        var region = $('#RegionFilter_CheckedItems')[0];
        var province = $('#ProvinceFilter_CheckedItems').data('kendoDropDownList');
        if (region.value != null && region.value != '') {
            bvCheckedComboBox.onClearCheckedComboBox("ZoneFilter_CheckedItems");
            if (province != null)
                bvCheckedComboBox.onClearCheckedComboBox("ProvinceFilter_CheckedItems");
        }
        paperForm.setThaiZoneRegionProvinceEnabled(zone, $('#RegionFilter_CheckedItems').data('kendoDropDownList'), province);
    },
    OnThaiZoneChanged: function (e) {
        var zone = $('#ZoneFilter_CheckedItems')[0];
        var region = $('#RegionFilter_CheckedItems').data('kendoDropDownList');
        var province = $('#ProvinceFilter_CheckedItems').data('kendoDropDownList');
        if (zone.value != null && zone.value != '') {
            bvCheckedComboBox.onClearCheckedComboBox("RegionFilter_CheckedItems");
            if (province != null)
                bvCheckedComboBox.onClearCheckedComboBox("ProvinceFilter_CheckedItems");
        }
        paperForm.setThaiZoneRegionProvinceEnabled($('#ZoneFilter_CheckedItems').data('kendoDropDownList'), region, province);
    },
    OnThaiMultipleProvinceChanged: function (e) {
        var zone = $('#ZoneFilter_CheckedItems').data('kendoDropDownList');
        var region = $('#RegionFilter_CheckedItems').data('kendoDropDownList');
        var province = $('#ProvinceFilter_CheckedItems')[0];
        if (province.value != null && province.value != '') {
            bvCheckedComboBox.onClearCheckedComboBox("RegionFilter_CheckedItems");
            bvCheckedComboBox.onClearCheckedComboBox("ZoneFilter_CheckedItems");
        }
        paperForm.setThaiZoneRegionProvinceEnabled(zone, region, $('#ProvinceFilter_CheckedItems').data('kendoDropDownList'));
    },
    setThaiZoneRegionProvinceEnabled: function (zone, region, province) {
        if (zone != null)
            zone.enable((region == null || region.value() == null || region.value() == '')
                && (province == null || province.value() == null || province.value() == ''));
        if (region != null)
            region.enable((zone == null || zone.value() == null || zone.value() == '')
                && (province == null || province.value() == null || province.value() == ''));
        if (province != null)
            province.enable((region == null || region.value() == null || region.value() == '')
                && (zone == null || zone.value() == null || zone.value() == ''));
    },
    onCounterCheckedComboBoxClick: function (e, controlId, currentCheckBoxId) {
        var checkBox = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='" + currentCheckBoxId + "']")[0];
        var chk = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='" + currentCheckBoxId + "']")[0].checked;
        if (currentCheckBoxId == "chb1") {
            checkBox.checked = true;
        } else if (chk == true) {
            var items = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id!='" + currentCheckBoxId + "']");
            for (var i = 1; i < items.length; i++) {
                items[i].checked = false;
            }
        }
        bvCheckedComboBox.onCheckedComboBoxClick(e, controlId, currentCheckBoxId);
    },
    bindCounterCheckedComboBoxClickEvent: function (controlId, selectedIndexes) {
        bvCheckedComboBox.bindCheckedComboBoxClickEventInternal(controlId, selectedIndexes, paperForm.onCounterCheckedComboBoxClick);
    },

    OnYearForMonthChanged: function (e) {
        var year = e.sender.value();
        var version = e.sender.element[0].getAttribute("version");
        var monthCtl = e.sender.element[0].getAttribute("month");
        var required = e.sender.element[0].className.indexOf('requiredField') >= 0;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetMonthList?Year=" + year + "&Version=" + version + "&IsMonthMandatory=" + required;
        paperForm.OnParentComboboxChanged(e, getDataSourceUrl, '#' + monthCtl, true);
    },
    assignmentLabDiagnosticCaseIdChanged: function (e) {
        var caseIdCtl = $('#CaseId');
        var validateBtn = $('#btValidate');
        //var sentToCtl = $('#SentTo').data('kendoComboBox');
        var enabled = (caseIdCtl != null && caseIdCtl.val().trim() != '');
        //if(enabled)
        //    validateBtn.removeAttr('disabled');
        //else
        //    validateBtn.attr('disabled', 'disabled');
        validateBtn.enable(enabled);
        //sentToCtl.enable(enabled);
        paperForm.UpdateChildCombobox(null, '#SentTo', true);
    },
    assignmentLabDiagnosticValidate: function () {
        var caseIdCtl = $('#CaseId');
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/ValidateAssignmentLabDiagnostic?caseId=" + caseIdCtl.val().trim();
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {
            },
            success: function (data) {
                if (data.message != null && data.message !== "")
                    bvDialog.showError(eval('EIDSS.BvMessages.' + data.message));
                else
                    paperForm.UpdateChildCombobox(data.data, '#SentTo', true);
            }
        });
    },
    OnActionsSelect: function () {
        paperForm.OnActionsChange(true);
    },
    OnActionsDeselect: function () {
        paperForm.OnActionsChange(false);
    },
    OnSurveillanceTypeChange: function (sType) {
        var actionData = $('#ActionMethodId').data('kendoComboBox');
        var action = $('#ActionMethodId_input');
        actionData.enable(sType === 'action');
        actionData.value(null);
        if (sType === 'action') {
            action.addClass("requiredField");
            comboBoxFacade.addClass(actionData, "requiredField");
        } else {
            action.removeClass("requiredField");
            comboBoxFacade.removeClass(actionData, "requiredField");
        }
        var diagnosisData = $('#DiagnosisId').data('kendoComboBox');
        diagnosisData.value(null);
        paperForm.OnVetSummaryDiagnosisChange(null);
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/VetSummarySetSurveillanceType";
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {
                type: sType
            },
            success: function (data) {
                paperForm.UpdateChildCombobox(data.diagnosisList, '#DiagnosisId', true);
            }
        });

    },
    OnVetSummaryDiagnosisChange: function (e) {
        bvCheckedComboBox.onClearCheckedComboBox('SpeciesType_CheckedItems');
        paperForm.UpdateChildDropdown(null, '#SpeciesType_CheckedItems', true);
        if (e == null || e.sender == null) {
            return;
        }
        var diagnosisId = e.sender._selectedValue;
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/GetVetSummarySpecies?DiagnosisId=" + diagnosisId;
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {
            },
            success: function (data) {
                paperForm.UpdateChildDropdown(data.data, '#SpeciesType_CheckedItems', true);
            }
        });
    },
    sampleIdChanged_az: function (e) {
        var sampleIdCtl = $('#SampleId');
        var searchBtn = $('#btnSearch');
        var enabled = (sampleIdCtl != null && sampleIdCtl.val().trim() !== "");
        searchBtn.enable(enabled);
        paperForm.UpdateChildCombobox(null, '#LabDepartmentId', true);
    },
    searchLabTestingResult: function () {
        var sampleIdCtl = $('#SampleId');
        var getDataSourceUrl = "/" + GetSiteLanguage() + "/Report/SearchLabSample?SampleId=" + sampleIdCtl.val().trim();
        $.ajax({
            url: getDataSourceUrl,
            cache: false,
            dataType: "json",
            type: "GET",
            data: {
            },
            success: function (data) {
                if (data.message != null && data.message !== "")
                    bvDialog.showError(eval('EIDSS.BvMessages.' + data.message));
                else
                    paperForm.UpdateChildCombobox(data.data, '#LabDepartmentId', true);
            }
        });
    },



};