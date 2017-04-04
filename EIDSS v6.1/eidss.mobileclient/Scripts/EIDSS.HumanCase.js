function onCancelHumanCaseEdit() {
    CloseHumanCase();
}

function onSaveHumanCase() {
    SaveHumanCase(false);
}

function onSaveAndCloseHumanCase() {
    SaveHumanCase(true);
}

function SaveHumanCase(closeCaseAfterSave) {
    var contentData = $("#tabs-1 form").serialize(true);
    contentData = EscapeHtmlGtLtOnly(contentData);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/HumanCase/Details";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: contentData,
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            var err = false;
            for (var att in data.Values) {
                if (data.Values[att].typeName == "ErrorMessage") {
                    err = true;
                }
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                if (closeCaseAfterSave) {
                    CloseHumanCase();
                }
                else {
                    var href = $("#scontent ul.ui-tabs-nav li.ui-state-active a").attr("href");
                    location.href = href;
                }
            }
        }
    });
}

function CloseHumanCase() {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/HumanModule";
    document.location.href = url;
}

function OnDateOfBirthChanged(controlIdPrefix) {
    var intPatientAge = $("#" + controlIdPrefix + "intPatientAgeFromCase");
    var cbAgeType = $("#" + controlIdPrefix + "HumanAgeType");
    var dateBox = $("#" + controlIdPrefix + "datDateofBirth");
    if (dateBox.length > 0) { // for mobile safari        
        if (dateBox.val()) {
            DisableControl(intPatientAge);
            DisableControl(cbAgeType);
            var dateOfBirth = dateBox.val();
            $.ajax({
                url: systemUrl,
                cache: false,
                dataType: "json",
                type: "GET",
                data: {
                    key: controlIdPrefix + "datDateofBirth",
                    value: dateBox.val()
                },
                success: function (data) {
                    if (IsSessionExpired(data)) {
                        return;
                    }
                    ApplyChanges(data);
                    dateBox.val(dateOfBirth);
                }
            });      
        }
        else{
            EnableControl(intPatientAge);
            EnableControl(cbAgeType);
        }
    }
    else { // for android
        var cbDays = $("#" + controlIdPrefix + "datDateofBirth_Day");
        var cbMonthes = $("#" + controlIdPrefix + "datDateofBirth_Month");
        var cbYears = $("#" + controlIdPrefix + "datDateofBirth_Year");
        if (cbDays.val() != 0 || cbMonthes.val() != 0 || cbYears.val() != 0) {
            DisableControl(intPatientAge);
            DisableControl(cbAgeType);
        }
        else {
            EnableControl(intPatientAge);
            EnableControl(cbAgeType);
        }
    }
}