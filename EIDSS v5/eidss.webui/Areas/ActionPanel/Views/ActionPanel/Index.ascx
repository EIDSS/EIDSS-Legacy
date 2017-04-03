<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webui.Areas.ActionPanel.Models.ActionPanelModel>" %>
<%@ Import Namespace="bv.model.Model.Core" %>
<%@ Import Namespace="bv.model.Helpers" %>
<%@ Import Namespace="bv.common.Enums" %>
<%@ Import Namespace="eidss.webui.Areas.ActionPanel.Models" %>


<table width="100%">
<tr>

<%
    var permissions = Model.Accessor as IObjectPermissions;
    
    var avaliableActions = Model.Actions.Where(c => 
        c.PanelType.Equals(Model.PanelType)
        &&
        (c.IsVisible)
        &&
        c.CheckPermission(permissions)
        );
    
    //определяем те действия, которые должны отображаться слева
    var actionsLeft = avaliableActions.Where(c => c.Alignment.Equals(ActionsAlignment.Left));
    //определяем те действия, которые должны отображаться справа
    var actionsRight = avaliableActions.Where(c => c.Alignment.Equals(ActionsAlignment.Right));
    //каждое из них помещаем в своем столбце
    %>
    <td align="left"><%Html.RenderPartial("ActionsCollection", new ActionsCollectionModel(actionsLeft, Model.PanelType, Model.ObjectSelectList));%></td>
    <td align="right"><%Html.RenderPartial("ActionsCollection", new ActionsCollectionModel(actionsRight, Model.PanelType, Model.ObjectSelectList));%></td> 
</tr>
</table>