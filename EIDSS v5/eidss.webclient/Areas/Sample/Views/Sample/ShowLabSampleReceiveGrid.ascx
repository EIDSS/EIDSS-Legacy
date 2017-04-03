<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.LabSampleReceiveItem.LabSampleReceiveItemGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<script type="text/javascript">
    function onSelect(e, name) {
        var h = $("#samplegrid_selecteditem");
        var b = $("#idAccession");

        var acc = $('#' + name + ' tr.t-state-selected').find("[name='idfsAccessionCondition']").attr("value");
        if (acc != "") {
            b.attr("disabled", "disabled");
            b.addClass('t-state-disabled');
        }
        else {
            b.removeAttr("disabled");
            b.removeClass('t-state-disabled');
        }
        var val = $('#' + name + ' tr.t-state-selected td.gridId').find("[name='ItemKey']").attr("value");
        h.val(val);
    }
    function onAccession(name, listkey) {
        $("#idAccession").attr("disabled", "disabled");
        var h = $("#samplegrid_selecteditem");
        var url = GetUrlPrefixLanguage() + "LabSample/SetAccession";
        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            dataType: "json",
            data: {
                idfId: listkey,
                idfMaterial: h.val()
            },
            success: function (data) {
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });
        $('#' + name).data('tGrid').ajaxRequest();
    }

    function setAccession() {
        var key = '<%=Model.ListKey%>';
        var name = '<%=(string)ViewData["SampleName"]%>';
        var h = $("#samplegrid_selecteditem");
        var path = GetUrlPrefixLanguage() + 'LabSample/LabSampleReceiveItemPicker?key=' + key + '&accession=1&name=' + name + '&id=' + h.val();
        ShowMessageWindow(path, 630, 520, EIDSS.BvMessages['titleAccessionDetails'], false);

        var b = $("#idAccession");
        b.attr("disabled", "disabled");
        b.addClass('t-state-disabled');
    }
</script>
    
<input name="samplegrid_selecteditem" id="samplegrid_selecteditem" type="hidden" />
<%Html.BvGrid<LabSampleReceiveItem.LabSampleReceiveItemGridModel, LabSampleReceiveItem.LabSampleReceiveItemGridModelList>((string)ViewData["SampleName"], Model, "detailsGrid", 
@"function(e){
    var path = GetUrlPrefixLanguage() + 'LabSample/LabSampleReceiveItemPicker?key=" + Model.ListKey + "&accession=0&name=" + (string)ViewData["SampleName"] + @"&id='
    OpenGridEditWindow(e, path, 630, 520, EIDSS.BvMessages['titleAccessionDetails']);
}",
"function(e) { onSelect(e, '" + (string)ViewData["SampleName"] + "'); }",
(bool)ViewData["IsReadOnly"], true, true, true, false, (string)ViewData["ExcludeColumns"], "function(e) { bvGridOnDataBound(e, 'false'); onSelect(e, '" + (string)ViewData["SampleName"] + "'); }")
.ToolBar(toolBar =>
    toolBar.Template(() =>
    {
        %>
        <div class="tToolBarSearchPanel">     
            <table>
                <tr>
                    <td class="fillAll">
                        <% =Html.Label(Translator.GetMessageString("titleSampleSearch"))%>  
                    </td>
                    <td>
                        <% =Html.TextBox("tbSampleSearchText", "", new { @class = "searchText large" })%> 
                    </td>
                    <td>
                        <input class="t-button t-button-icon bvButton searchButton" value='<%=Translator.GetMessageString("Search")%>' type="button" onclick="SearchLineInGrid('<%=(string)ViewData["SampleName"]%>', '2', 'tbSampleSearchText', 'ErrLocalFieldSampleIDNotFound');" />  
                    </td>
                </tr>
            </table>                                                                                                                                 
        </div>     
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>  
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'><span><%=Translator.GetMessageString("Edit")%></span></a>  
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-add'><span><%=Translator.GetMessageString("strNew")%></span></a>       
        <input id="idAccession" class="t-button t-button-icon t-state-disabled bvButton" name="idAccession" type="button" value='<%=Translator.GetMessageString("Accession")%>' onclick="setAccession();" disabled="disabled" />
        <%
    })
).Render();
%>

