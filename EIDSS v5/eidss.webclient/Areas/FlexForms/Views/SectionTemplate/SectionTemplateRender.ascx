<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Model.FlexibleForms.FlexNodes.FlexNode>" %>
<table class="bordered">
    <tr>
        <td class="sectionName">
            <%=Model.GetSectionTemplate().NationalName%>
        </td>        
    </tr>    
    <%
    if (Model.ChildListCount > 0)
    {
        foreach (var node in Model.ChildList)
        {%>       
            <tr>
                <td>
                    <%Html.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/FlexNodeRender.ascx", node);%>
                </td>
            </tr>
        <%
        }
    }
    %>                  
</table>



