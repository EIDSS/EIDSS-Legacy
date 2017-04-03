<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webclient.Areas.ActionPanel.Models.ActionsCollectionModel>" %>

<%@ Import Namespace="bv.common.Resources" %>

<%@ Import Namespace="bv.model.Helpers" %>

<%@ Import Namespace="bv.common.Enums" %>

<%@ Import Namespace="bv.model.Model.Core" %>

<%
    var permissions = (Model.Obj == null) ? Model.Accessor as IObjectPermissions : Model.Obj.GetPermissions();
    
    foreach (var action in Model.Collection)
    {
        //добавляем кнопку
        //TODO заменить на телериковские кнопки с картинками
        //TODO непонятно какой телериковский контрол использовать для отображения групп
        //TODO вынести код для кнопки в Extender к другим контролам

        var buttonName = String.Format("b{0}Panel_{1}", Model.PanelType, action.Name);
        //var buttonType = ActionsHelper.IsSubmitAction(action.ActionType) ? "submit" : "button";
        var buttonType = action.ActionType == ActionTypes.Ok || action.ActionType == ActionTypes.Save ? "submit" : "button";
        var actionName = String.Empty;
        var actionArgs = String.Empty;

        const string actionMask = "javascript:{0}('{1}');";

        var IconId = action.IconId(Model.Obj, permissions);
        var imageUrl = 
            IconId.Length > 0 ?
            String.Format("{0}{1}.png", ResolveUrl("~/Content/Images/ActionsPanelButtons/"), IconId) : String.Empty;

        #region Определение текущего контроллера

        //имеется ввиду не ActionsPanel, а его носитель
        
        var controllerName = ViewBag.CurrentController;

        //var filePath = Request.CurrentExecutionFilePath;
        //int pos = filePath.IndexOf("/", 1);
        //var controllerName = filePath.Substring(1, pos - 1);
        
        #endregion

        if (!Model.IsListForm() && action.ActionType == ActionTypes.Action && !action.IsEnable(Model.Obj, permissions))
            continue;

        switch (action.ActionType)
        {
            case ActionTypes.Action:
                actionName = action.IsWebJScript ? action.Name : "ActionEdit";
                actionArgs = Url.Action(action.Name, controllerName, new { area = String.Empty });
                break;
            case ActionTypes.Refresh:
                actionName = "ActionRefresh";
                break;
            case ActionTypes.Close:
                actionName = "ActionClose";
                actionArgs = Url.Action("Home", "Account", new {area = String.Empty}); //ResolveUrl("~/Views/Home/Index.cshtml");
                break;
            case ActionTypes.Create:
                actionName = Model.IsListForm() ? "ActionCreateListForm" : "ActionCreate";
                actionArgs = Url.Action("Details", controllerName, new { area = String.Empty });
                break;
            case ActionTypes.Edit:
                actionName = "ActionEdit";
                actionArgs = Url.Action("Details", controllerName, new { area = String.Empty });
                break;
            case ActionTypes.View:
                actionName = "ActionEdit";
                actionArgs = Url.Action("Details", controllerName, new { area = String.Empty });
                break;
            //case ActionTypes.Search:
            //    actionName = "DisplaySearchPanel";                
            //    break;
            case ActionTypes.Cancel:
                actionName = "ActionCancel";
                if (action.Name == "Ok")
                {
                    actionName = "ActionCancelWithoutQuestion";
                }
                break;
            case ActionTypes.Ok:
                actionName = "ActionOK";
                break;
            case ActionTypes.Save:
                actionName = "ActionSave";
                break;
            case ActionTypes.Report:
                //TODO сделать показ отчётов
                break;
            case ActionTypes.Delete:
                if (Model.IsListForm())
                {
                    actionName = "ActionDeleteList";
                    actionArgs = Url.Action("DeleteListObject", "System", new { area = String.Empty, accessor = Model.Accessor.GetType().FullName });
                }
                else
                {
                    actionName = "ActionDeleteObject";
                    actionArgs = Url.Action("DeleteObject", "System", new { area = String.Empty, accessor = Model.Accessor.GetType().FullName, id = Model.Obj.Key.ToString() });
                }
                break;  
                    
        }
%>        
        <button id="<%= buttonName%>" type="<%=buttonType%>" onclick="<%=String.Format(actionMask, actionName, actionArgs) %>" >
            <% if (imageUrl.Length > 0)
               { %>
                <img src="<%= imageUrl %>" alt="" />
                <%} %>
            <%=BvMessages.Get(action.CaptionId(Model.Obj, permissions))%>
        </button>        
    <%
    }
    %>    
        
