function onCancelSpeciesEdit(idfCase) {
    CloseSpecies(idfCase);
}

function onClinicalSignsClick(idfCase, name) {
    var selectedId = GetSelectGridItemId("HerdsList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/ClinicalSigns?rootKey=" + idfCase + "&name=" + name + "&idfSpecies=" + selectedId;
    document.location.href = postUrl;
}

function onSaveAndCloseSpecies(params) {
    var idfCase = params[0];
    var name = params[1];
    var isNew = params[2];
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Herd/SpeciesDetails";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: {
            rootKey: idfCase,
            name: name,
            isNew: isNew,
            formData: contentData
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            if (data) {
                ShowEidssErrorNotification(data, function () { });
            }
            else {
                CloseSpecies(idfCase);
            }
        }
    });
}

function CloseSpecies(idfCase) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/HerdDetails?id=" + idfCase;
    document.location.href = url;
}

function onEditSpeciesClick(idfCase, name) {
    var selectedId = GetSelectGridItemId("HerdsList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Herd/SpeciesDetails?rootKey=" + idfCase + "&name=" + name + "&idfSpecies=" + selectedId;
    document.location.href=postUrl;
}

function onRemoveSpeciesClick(idfCase, name) {
    var params = [idfCase, name];
    ShowEidssDialogDeletePrompt(RemoveSpeciesFromCase, params);
}

function RemoveSpeciesFromCase(params) {
    var idfCase = params[0];
    var name = params[1];
    var selectedId = GetSelectGridItemId("HerdsList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/RemoveSpecies";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: {
            rootKey: idfCase,            
            speciesId: selectedId
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            var url = "/" + lang + "/VetCase/HerdDetails?id=" + idfCase;
            document.location.href = url;
        }
    });
}