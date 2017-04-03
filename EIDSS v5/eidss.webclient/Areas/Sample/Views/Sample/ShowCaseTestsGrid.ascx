<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.CaseTest.CaseTestGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<script type="text/javascript">
    $(window).load(function () {
        var showSearch = '<%=ViewData["ShowSearch"]%>';
        if (showSearch.toLowerCase() != "true") {
            $("#ToolBarSearchPanel").hide();
        }
    }); 

    function onCaseTestSelect(e, name) {
        var id_val = $('#' + name + ' tr.t-state-selected td.gridId').find("[name='ItemKey']").attr("value");
        var status_val = $('#' + name + ' tr.t-state-selected td.gridHidden').find("[name='idfsTestStatus']").attr("value");
        var NonLab_val = $('#' + name + ' tr.t-state-selected td.gridHidden').find("[name='blnNonLaboratoryTest']").attr("value");
        var gridId = name.substring(0, name.lastIndexOf('_')) + '_CaseTestValidations';
        var this_gridId = name.substring(0, name.lastIndexOf('_')) + '_CaseTests';

        var detailButton = $("#" + this_gridId + " input.bvButton");
        if (id_val == null) {
            DisableGridButton(detailButton);
        }
        else {
            EnableGridButton(this_gridId, detailButton);
        }

        if (status_val == "10001001" || status_val == "10001006") { // completed or amended
            EnableToolBarAddButton(gridId);
        }
        else {
            DisableToolBarAddButton(gridId);
        }
        if (NonLab_val == "true") {
            EnableToolBarDeleteButton(this_gridId);
            EnableToolBarEditButton(this_gridId);
        }
        else {
            DisableToolBarDeleteButton(this_gridId);
            DisableToolBarEditButton(this_gridId);
        }
    }

    function onSearchSample() {
        var path = GetUrlPrefixLanguage() + 'LabSample/CaseTestItemPicker?key=' + '<%=Model.ListKey%>' + '&name=' + '<%=(string)ViewData["CaseTestsName"]%>' + '&id=0';
        SearchSampleAndAddTest('<%=ViewData["root"]%>', 'tbSampleSearchText', 'ErrFieldSampleIDNotFound', path);
    }
</script>
          
<%Html.BvGrid<CaseTest.CaseTestGridModel, CaseTest.CaseTestGridModelList>((string)ViewData["CaseTestsName"], Model, "detailsGrid",
@"function(e){
    var path = GetUrlPrefixLanguage() + 'LabSample/CaseTestItemPicker?key=" + Model.ListKey + "&name=" + (string)ViewData["CaseTestsName"] + @"&id='
    OpenGridEditWindow(e, path, 630, 460, EIDSS.BvMessages['titleTestResultDetails']);
}",
"function(e) { onCaseTestSelect(e, '" + (string)ViewData["CaseTestsName"] + "'); }",
(bool)ViewData["IsReadOnly"], true, true, !(bool)ViewData["IsReadOnly"], false, (string)ViewData["ExcludeColumns"], null, "bvGridOnDeleteAndApplyChanges")
.ToolBar(toolBar =>
    toolBar.Template(() =>
    {
        %>
        <div class="tToolBarSearchPanel" id="ToolBarSearchPanel">     
            <table>
                <tr>
                    <td class="fillAll">
                        <% =Html.Label(Translator.GetMessageString("titleSampleSearchforTests"))%>  
                    </td>
                    <td>
                        <% =Html.TextBox("tbSampleSearchText", "", new { @class = "searchText large" })%> 
                    </td>
                    <td>
                        <a href="javascript:<%=String.Format("onSearchSample()")%>" 
                            class='t-grid-action t-button t-button-icon t-state-enabled searchButton'><span><%=Translator.GetMessageString("Search")%></span>
                        </a>   
                    </td>
                </tr>
            </table>                                                                                                                                 
        </div>  
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
        <a href="javascript:<%=String.Format("showTestDetails('{0}','{1}');", 
            Url.Action("ShowTestDetailFlexibleForm", "FFPresenter", new RouteValueDictionary { { "area", "FlexForms" }, { "root", ViewData["root"] }, {"key", "*editkey*"}, { "name", ViewData["CaseTestsName"] } }),
            ViewData["CaseTestsName"] )%>" class='t-grid-action t-button t-button-icon t-state-disabled'><span><%=Translator.GetMessageString("titleTestDetails")%></span></a>     
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'><span><%=Translator.GetMessageString("btEditResult")%></span></a>     
        <a href='#' class='t-grid-action t-button t-button-icon t-grid-add'><span><%=Translator.GetMessageString("btAddResult")%></span></a>     

        <%--<input class="t-grid-action t-button t-button-icon t-state-disabled bvButton" value='<%=Translator.GetMessageString("titleTestDetails")%>' type="button" disabled="disabled" onclick="<%=String.Format("showTestDetails('{0}','{1}');", 
            Url.Action("ShowTestDetailFlexibleForm", "FFPresenter", new RouteValueDictionary { { "area", "FlexForms" }, { "root", ViewData["root"] }, {"key", "*editkey*"}, { "name", ViewData["CaseTestsName"] } }),
            ViewData["CaseTestsName"] )%>" />  --%>   
        <%
    })
).Render();
%>
        
