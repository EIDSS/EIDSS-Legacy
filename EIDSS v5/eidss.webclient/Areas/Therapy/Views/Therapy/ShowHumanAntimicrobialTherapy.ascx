<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AntimicrobialTherapy.AntimicrobialTherapyGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<AntimicrobialTherapy.AntimicrobialTherapyGridModel, AntimicrobialTherapy.AntimicrobialTherapyGridModelList>((string)ViewData["AntimicrobialTherapyName"], Model, "detailsGrid",
    @"function(e){
    var url = '../HumanCase/HumanAntimicrobialTherapyPicker?key=" + Model.ListKey + "&name=" + (string)ViewData["AntimicrobialTherapyName"] + @"&id=';
    OpenGridEditWindow(e, url, 430, 170, EIDSS.BvMessages['titleAntibiotic']);
    }", null, 
    (bool)ViewData["IsReadOnly"])
    .ToolBar(toolBar =>
            toolBar.Template(() =>
            {
                %>                            
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Remove")%></span></a>
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'><span><%=Translator.GetMessageString("Edit")%></span></a>
                <a href='#' class='t-grid-action t-button t-button-icon t-grid-add'><span><%=Translator.GetMessageString("Add")%></span></a>      
                <%
            })
        ).Render();
    %>
