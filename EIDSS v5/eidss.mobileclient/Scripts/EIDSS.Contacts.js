function onCancelContactEdit(idfCase) {
    CloseContactedCasePerson(idfCase);
}

function onSaveAndCloseContactedCasePerson(idfCase) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/ContactedCasePerson/SaveContactedCasePerson";
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
                CloseContactedCasePerson(idfCase);                
            }
        }
    });
}

function CloseContactedCasePerson(idfCase) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/ContactList?id=" + idfCase;
    document.location.href = url;
}

function onEditContactClick(idfCase) {
    var selectedId = GetSelectGridItemId("ContactsList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/ContactedCasePerson/ContactDetails?rootKey=" + idfCase + "&contactedCasePersonId=" + selectedId + "&getFromSession=false";
    document.location.href=postUrl;
}

function onRemoveContactClick(idfCase) {
    ShowEidssDialogDeletePrompt(RemoveContactFromCase, idfCase);
}

function RemoveContactFromCase(idfCase) {
    var selectedId = GetSelectGridItemId("ContactsList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/ContactedCasePerson/RemoveContactedCasePerson";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: {
            rootKey: idfCase,
            contactedCasePersonId: selectedId
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            var url = "/" + lang + "/HumanCase/ContactList?id=" + idfCase;
            document.location.href = url;
        }
    });
}

function onPatientSelected(idfCase, patientId) {    
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/ContactedCasePerson/SetSelectedPatient";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: {
            root: idfCase,
            selectedId: patientId
        },
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
                var contactedCasePersonId = data.Values[''].value;
                postUrl = "/" + lang + "/ContactedCasePerson/ContactDetails?rootKey=" + idfCase + "&contactedCasePersonId=" + contactedCasePersonId + "&getFromSession=true";
                document.location.href = postUrl;
            }
        }
    });
}

function StoreContactAndOpenPatientsList(idfCase, contactedCasePersonId) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/ContactedCasePerson/StoreContactDetails";
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
                var path = "/" + lang + "/ContactedCasePerson/PatientsList?rootKey=" + idfCase + "&contactedCasePersonId=" + contactedCasePersonId;
                document.location.href = path;
            }
        }
    });
}