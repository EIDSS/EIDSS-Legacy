<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Model.FlexibleForms.FlexNodes.FlexNode>" %>

<%

    //var args = new RouteValueDictionary {{"flexNode", Model}};
    var args = new RouteValueDictionary { { "area", "FlexForms" }, { "flexNode", Model } };
    
    if (Model.IsParameter())
    {
        Html.RenderAction("ParameterTemplateRender", "ParameterTemplate", args);
    }
    else if (Model.IsSection())
    {
        var section = Model.GetSectionTemplate();
        Html.RenderAction(section.blnGrid ? "SectionTemplateTableRender" : "SectionTemplateRender", "SectionTemplate", args);
    }
    else if (Model.IsLabel())
    {
        Html.RenderAction("LabelRender", "Label", args);
    }

%>