using System;
using bv.common.Enums;
using bv.model.Model.Core;

namespace bv.model.Helpers
{
    /*
    /// <summary>
    /// 
    /// </summary>
    public static class ActionsHelper
    {
        /// <summary>
        /// Проверяет, доступно ли указанное действие в контексте доступных полномочий
        /// </summary>
        /// <param name="action"></param>
        /// <param name="permissions"></param>
        /// <param name="readOnly"> </param>
        /// <returns></returns>
        public static bool CheckPermission(this ActionMetaItem action, IObjectPermissions permissions, bool readOnly)
        {
            var result = true;

            if (permissions != null)
            {
                #region Проверка полномочий

                ActionTypes type = action.ActionMethod == ActionTypes.Unknown ? action.ActionType : action.ActionMethod;
                switch (type)
                {
                    case ActionTypes.Group:
                        result = !readOnly;
                        break;


                    case ActionTypes.Action:
                    case ActionTypes.Custom:
                        if (action.PermissionPredicate == null)
                        {
                            if (String.IsNullOrEmpty(action.Permission))
                                result = permissions.CanExecute(action.Name); //!readOnly &&
                            else
                                result = permissions.CanExecute(action.Permission);//!readOnly && 
                        }
                        else
                        {
                            result = !readOnly && action.PermissionPredicate();
                        }
                        break;

                    case ActionTypes.Create:
                        result = permissions.CanInsert; // !readOnly  && &&!permissions.IsReadOnlyForEdit
                        break;
                    case ActionTypes.ShowForm:
                        //TODO неизвестно, что проверять
                        break;

                    case ActionTypes.Ok:
                        result = permissions.CanInsert || permissions.CanUpdate || readOnly;
                        break;

                    case ActionTypes.Cancel:
                        result = !readOnly;
                        break;

                    case ActionTypes.Delete:
                        result =  permissions.CanDelete;// !readOnly &&&& !permissions.IsReadOnlyForEdit
                        break;

                    case ActionTypes.Refresh:
                        //result = permissions.CanSelect;
                        break;

                    case ActionTypes.Edit:
                        //result = permissions.CanUpdate;
                        break;

                    case ActionTypes.Save:
                        result = !readOnly && !permissions.IsReadOnlyForEdit && permissions.CanUpdate;
                        break;
                }

                #endregion
            }
            else
            {
                switch (action.ActionType)
                {

                    case ActionTypes.Group:
                        result = !readOnly;
                        break;
                    case ActionTypes.Create:
                        result = !readOnly;
                        break;

                    case ActionTypes.Cancel:
                        result = !readOnly;
                        break;

                    case ActionTypes.Delete:
                        result = !readOnly;
                        break;

                    case ActionTypes.Edit:
                        break;

                    case ActionTypes.Save:
                        result = !readOnly;
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionTypes"></param>
        /// <returns></returns>
        public static bool IsRefreshAction(ActionTypes actionTypes)
        {
            return actionTypes.Equals(ActionTypes.Refresh);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionTypes"></param>
        /// <returns></returns>
        public static bool IsSaveAction(ActionTypes actionTypes)
        {
            return actionTypes.Equals(ActionTypes.Save);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionTypes"></param>
        /// <returns></returns>
        public static bool IsOKAction(ActionTypes actionTypes)
        {
            return actionTypes.Equals(ActionTypes.Ok);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionTypes"></param>
        /// <returns></returns>
        public static bool IsSubmitAction(ActionTypes actionTypes)
        {
            return IsSaveAction(actionTypes) || IsOKAction(actionTypes);
        }
    }
    */
}
