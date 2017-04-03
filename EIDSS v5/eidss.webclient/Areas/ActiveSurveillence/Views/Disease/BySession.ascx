<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsSessionDisease.AsSessionDiseaseGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<AsSessionDisease.AsSessionDiseaseGridModel, AsSessionDisease.AsSessionDiseaseGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false)
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>
                    <a href="javascript:<%=String.Format("addNewItem('{0}', '{1}', '{2}', 300);", 
                        Url.Action("SessionDetails", "Disease", new RouteValueDictionary { { "area", "ActiveSurveillence" }, 
                        { "key", ViewData["root"] }, { "name", ViewData["name"] }, {"idfAsSessionDisease", "0"} }),ViewData["name"], Translator.GetMessageString("titleAddDisease"))%>" 
                        class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span>
                    </a>   
                    
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                <%
            })
        )   
        .Resizable(resizing => resizing.Columns(false))            
        .HtmlAttributes(new {@class="smallheight"})
        .Render();%> 
