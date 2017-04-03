<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.ContactedCasePerson.ContactedCasePersonGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<ContactedCasePerson.ContactedCasePersonGridModel, ContactedCasePerson.ContactedCasePersonGridModelList>
    ((string)ViewData["ContactedCasePersonGridName"], Model, "detailsGrid",
    @"function(e){
        var url = '../HumanCase/HumanContactedCasePersonPicker?key=" + Model.ListKey + "&name=" + (string)ViewData["ContactedCasePersonGridName"] + @"&id=';
        var title = EIDSS.BvMessages['titleContactInformation'];
        OpenGridEditWindow(e, url, 830, 470, title);
        }", null, (bool)ViewData["IsReadOnly"], true, false, !(bool)ViewData["IsReadOnly"], false, (string)ViewData["ExcludeColumns"], sample: (bv.model.Model.Core.IObject)ViewData["Parent"])
        .ToolBar(toolBar =>
            toolBar.Template(() =>
            {
                %>                            
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("btRemoveContact")%></span></a>
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'><span><%=Translator.GetMessageString("btEditContact")%></span></a>
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-add'><span><%=Translator.GetMessageString("btAddContact")%></span></a>       
                <a href="javascript:<%=String.Format("var gridName='{0}'; var rootKey = '{1}'; ShowPatientPicker('onContactedPersonPatientPickerSelect', gridName, rootKey);", 
                    ViewData["ContactedCasePersonGridName"], Model.ListKey)%>" class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("btSelectContact")%></span></a> 
                <%
            })
        )
        .Render();
    %>
       