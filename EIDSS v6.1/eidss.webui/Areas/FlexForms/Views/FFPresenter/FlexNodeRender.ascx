<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webui.Areas.FlexForms.Models.FlexNodes.FlexNode>" %>

<%

    //var args = new RouteValueDictionary {{"flexNode", Model}};
    var args = new RouteValueDictionary { { "area", "FlexForms" }, { "flexNode", Model } };
    
    if (Model.IsParameter())
    {
        Html.RenderAction("ParameterTemplateRender", "ParameterTemplate", args);
    }
    else if (Model.IsSection())
    {
        Html.RenderAction("SectionTemplateRender", "SectionTemplate", args);
    }
    else if (Model.IsLabel())
    {
        Html.RenderAction("LabelRender", "Label", args);
    }

%>