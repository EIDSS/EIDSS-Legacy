function gridItemAdded(gridname) {    
    //(link, container) {    
    refreshGrid(gridname);    
    //   reloadGrid(link, container);
    if ($('#Message').data('tWindow'))
        $('#Message').data('tWindow').close();
}

function refreshGrid(name) {
    $('#' + name).data('tGrid').ajaxRequest();
}

function addNewItem(link, name, title, height) {
    if (!title) {
        title = EIDSS.BvMessages['titleAddItem'];
        if (!title) title = 'Add';
    }
    if (!height) height = 480;
    ShowMessageWindow(getFullUrlByGridName(link, name), 600, height, title, false);    
}

function showClinicalSigns(link, gridname, title) {    
    if (!title) title = 'Species epidemiological and clinical investigation';
    ShowMessageWindow(getFullUrlByGridName(link, gridname), 950, 650, title, true);   
}

function showTestDetails(link, gridname) {
    var title = EIDSS.BvMessages['titleTestDetails'];
    if (!title) title = 'Test Details';
    if (getSelectedId(gridname) != null) {
        ShowMessageWindow(getFullUrlByGridName(link, gridname), 600, 650, title, true);
    }
}


function getFullUrlByGridName(link, name) {   
    return link.replace('*editkey*', getSelectedId(name));
 }


function editGridItem(link, name, title, height) {
    if (!title) {
        title = EIDSS.BvMessages['titleEditItem'];
        if (!title) title = 'Edit';
    }
    if (!height) height = 480;
    ShowMessageWindow(getFullUrlByGridName(link, name), 600, height, title, false);    

}


function deleteGridItem(link, name, refresher, container) {
    ShowEidssDialogDeletePrompt(function () { doActualDelete(getFullUrlByGridName(link, name), refresher, container); });
}

function doActualDelete(link, refresher, container) {
    $.ajax({
        url: getFullUrlByGridName(link, name),
        cache: false,
        dataType: "json",
        type: "get",
        success: function (data) {
            if (data == 'ok')
                parent.gridItemAdded(name); //(refresher, container);
            else
                ShowEidssErrorNotification(data, null);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            ShowEidssErrorNotification(jqXHR.status, null);
        }
    });
}



function cancelItemAdding() {
    $('#Message').data('tWindow').close(); 
    }

function reloadGrid(link, container) {
    $.ajax({
        url: link.replace('&amp;', '&'),
        cache: false,
        //dataType: "json",
        type: "GET",
        success: function (data) {            
            $("#" + container).html(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            ShowEidssErrorNotification(jqXHR.status,null);
        }
    });
}

function getSelectedId(name) {    
    var key = $("#" + name + " tr.t-state-selected").find("[name='ItemKey']").attr("value");    
    return key;
}

function addNewItemInNewWindow(link, name) {
    var title = EIDSS.BvMessages['titleAddItem'];
    if (!title) title = 'Add';    
    var wintitle = title.replace(" ", "") + name;
    OpenPopup(getFullUrlByGridName(link, name), wintitle, null, null, true);

}

var openedItems = {};

function editGridItemInNewWindow(link, name) {
    var title = EIDSS.BvMessages['titleEditItem'];
    if (!title) title = 'Edit';

    var id = getSelectedId(name);
    if (!id)
        return;

    var wintitle = title.replace(" ", "") + name + id;    
    OpenPopup(getFullUrlByGridName(link, name), wintitle, null, null, true);    
}
