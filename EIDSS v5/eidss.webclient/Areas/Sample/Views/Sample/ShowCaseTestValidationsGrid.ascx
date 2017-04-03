<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.CaseTestValidation.CaseTestValidationGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>


<script type="text/javascript">
    function onCaseTestValidationSelect(name) {
        var isnew_val = $('#' + name + ' tr.t-state-selected td.gridHidden').find("[name='IsNew']").attr("value");
        if (isnew_val == "true") {
            EnableToolBarEditButton(name);
            EnableToolBarDeleteButton(name);
        }
        else {
            //DisableToolBarEditButton(name);
            EnableToolBarEditButton(name);
            DisableToolBarDeleteButton(name);
        }
    }
</script>
       
<%Html.BvGrid<CaseTestValidation.CaseTestValidationGridModel, CaseTestValidation.CaseTestValidationGridModelList>((string)ViewData["CaseTestValidationsName"], Model, "detailsGrid",
@"function(e){
    var name = '" + (string)ViewData["CaseTestValidationsName"] + @"';
    var gridId = name.substring(0, name.lastIndexOf('_')) + '_CaseTests';
    var id_test = $('#' + gridId + ' tr.t-state-selected td.gridId').find(""[name='ItemKey']"").attr(""value"");
    var path = GetUrlPrefixLanguage() + 'LabSample/CaseTestValidationItemPicker?key=" + Model.ListKey + "&name=" + (string)ViewData["CaseTestValidationsName"] + @"&id_test=' + id_test + '&id='
    OpenGridEditWindow(e, path, 630, 480, EIDSS.BvMessages['titleResultSummary']);
}",
"function(e) { onCaseTestValidationSelect('" + (string)ViewData["CaseTestValidationsName"] + "'); }",
(bool)ViewData["IsReadOnly"], true, false, !(bool)ViewData["IsReadOnly"], true, null,
"function(e) { bvGridOnDataBound(e, 'true'); onCaseTestValidationSelect('" + (string)ViewData["CaseTestValidationsName"] + "'); }"
)
.ToolBar(toolBar =>
    toolBar.Template(() =>
    {
        %>
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'><span><%=Translator.GetMessageString("Edit")%></span></a>
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-add'><span><%=Translator.GetMessageString("strNew")%></span></a>       
        <%
    }))
.Render();
%>
       