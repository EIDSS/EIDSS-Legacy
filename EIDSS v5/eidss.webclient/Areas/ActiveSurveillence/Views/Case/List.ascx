<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsSessionCase.AsSessionCaseGridModelList>" %>
<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<AsSessionCase.AsSessionCaseGridModel, AsSessionCase.AsSessionCaseGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false)
    .ToolBar(toolBar =>                                                                
        toolBar.Template(() =>
        {
            %>    
                <a href="javascript:<%=String.Format("editGridItemInNewWindow('{0}','{1}');", 
                    Url.Action("Details", "VetCase", new RouteValueDictionary { { "area", null }, { "type", "Lvstck" }, { "id", "*editkey*" } }),
                    ViewData["name"] )%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("btViewDetails")%></span>
                </a>
            <%
        })
    )
    .Groupable()
    .Render();%> 