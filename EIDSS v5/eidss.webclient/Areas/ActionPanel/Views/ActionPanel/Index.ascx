<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webclient.Areas.ActionPanel.Models.ActionPanelModel>" %>
<%@ Import Namespace="bv.model.Model.Core" %>
<%@ Import Namespace="bv.model.Helpers" %>
<%@ Import Namespace="bv.common.Enums" %>
<%@ Import Namespace="eidss.webclient.Areas.ActionPanel.Models" %>


<table width="100%">
<tr>

<%
    var permissions = (Model.Obj == null) ? Model.Accessor as IObjectPermissions : Model.Obj.GetPermissions();
    
    var avaliableActionsSource = Model.Actions.Where(c => 
        c.PanelType.Equals(Model.PanelType)
        &&
            c.IsVisible(Model.Obj, permissions)
        //&& 
        //    (c.ActionType != ActionTypes.Action || c.IsEnable(Model.Obj, permissions))
        //perm!!&&
        //perm!!c.CheckPermission(permissions, Model.Obj == null ? false : Model.Obj.ReadOnly)
            //perm!!&&
            //perm!!!(c.ActionType == ActionTypes.Ok && permissions != null && permissions.IsReadOnlyForEdit)
        //perm!!&&
            //perm!!c.IsActionVisibleForWeb(Model.Obj)
        &&
        (c.ActionType != ActionTypes.Select && c.ActionType != ActionTypes.SelectAll && c.ActionType != ActionTypes.Container)
        &&
        (c.AppType == ActionsAppType.All || c.AppType == ActionsAppType.Web)
        );

    var avaliableActions = avaliableActionsSource.ToList();
    //var avaliableActions = new List<ActionMetaItem>();
    //foreach (var a in avaliableActionsSource)
    //{
    //    avaliableActions.Add(new ActionMetaItem(a));
    //}
        
    //foreach (var c in avaliableActions)
    //{
        /*
        if (c.ActionType == ActionTypes.Cancel && permissions != null && permissions.IsReadOnlyForEdit)
        {
            c.Name = "Ok";
            c.CaptionId = "strOK_Id";
        }
        if (c.ActionType == ActionTypes.Edit && permissions != null && !permissions.CanUpdate)
        {
            c.ActionType = ActionTypes.View;
            c.CaptionId = "strView_Id";
            c.IconId = "View1";
        }
        */
        //perm!!if (permissions != null && !permissions.CanUpdate)
        //perm!!{
        //perm!!    c.ReadOnly = true;
            /*c.ActionType = c.ActionTypeReadOnly;
            if (!string.IsNullOrEmpty(c.CaptionIdReadOnly))
                c.CaptionId = c.CaptionIdReadOnly;
            if (!string.IsNullOrEmpty(c.IconIdReadOnly))
                c.IconId = c.IconIdReadOnly;
            if (!string.IsNullOrEmpty(c.TooltipIdReadOnly))
                c.TooltipId = c.TooltipIdReadOnly;*/
        //perm!!}
        
    //}
        
    
    //определяем те действия, которые должны отображаться слева
    var actionsLeft = avaliableActions.Where(c => c.Alignment.Equals(ActionsAlignment.Left));
    //определяем те действия, которые должны отображаться справа
    var actionsRight = avaliableActions.Where(c => c.Alignment.Equals(ActionsAlignment.Right));
    //каждое из них помещаем в своем столбце
    %>
    <td align="left"><%Html.RenderPartial("ActionsCollection", new ActionsCollectionModel(actionsLeft, Model.PanelType, Model.Accessor, Model.Obj));%></td>
    <td align="right"><%Html.RenderPartial("ActionsCollection", new ActionsCollectionModel(actionsRight, Model.PanelType, Model.Accessor, Model.Obj));%></td> 
</tr>
</table>