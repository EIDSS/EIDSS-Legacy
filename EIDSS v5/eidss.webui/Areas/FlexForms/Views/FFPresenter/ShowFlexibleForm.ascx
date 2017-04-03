<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webui.Areas.FlexForms.Models.FFPresenterModel>" %>

    <%
        //var formkey = String.Format("idfsFormTemplate_{0}_idfObservation_{1}",
        //                            Model.CurrentTemplate.idfsFormTemplate,
        //                            Model.CurrentObservation.HasValue ? Model.CurrentObservation.Value : 0); %>
                    
    <%
    foreach (var node in Model.TemplateFlexNode.ChildList)
    {
        Html.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/FlexNodeRender.ascx", node);
        %><p/><%
    }
    %>