<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsSessionAction.AsSessionActionGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<AsSessionAction.AsSessionActionGridModel, AsSessionAction.AsSessionActionGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false)
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a> 

                    <a href="javascript:<%=String.Format("editGridItem('{0}','{1}', '{2}');", 
                        Url.Action("Details", "Action", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, { "idfAsAction", "*editkey*" } }),
                        ViewData["name"],
                        Translator.GetMessageString("Edit"))%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("Edit")%></span></a> 

                    <a href="javascript:<%=String.Format("addNewItem('{0}', '{1}');", 
                        Url.Action("Details", "Action", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, {"idfAsAction", "0"} }),ViewData["name"])%>" 
                        class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span></a>      
                <%
            })
        )                
        .Render(); %> 


