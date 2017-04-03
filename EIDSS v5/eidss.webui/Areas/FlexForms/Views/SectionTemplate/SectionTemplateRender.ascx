<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webui.Areas.FlexForms.Models.FlexNodes.FlexNode>" %>
<table border="0"  class="ffsection">
    <tr>
        <td><%=Model.GetSectionTemplate().NationalName%></td>        
    </tr>
    <tr>
        <td>
           <%
            if (Model.ChildListCount > 0)
            {
                foreach (var node in Model.ChildList)
                {
                    Html.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/FlexNodeRender.ascx", node);
                }
            }
            %>
            <p />
        </td>
    </tr>
</table>



