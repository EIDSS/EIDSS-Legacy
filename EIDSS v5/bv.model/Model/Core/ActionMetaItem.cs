using System;
using System.Collections.Generic;
using bv.common.Enums;
using bv.model.BLToolkit;
using System.Linq;

[assembly: CLSCompliant(true)]


namespace bv.model.Model.Core
{
    public struct ActResult
    {
        public IObject obj;
        public bool result;

        public ActResult(bool res, IObject o = null)
        {
            obj = o;
            result = res;
        }

        public static implicit operator ActResult(bool res)
        {
            return new ActResult { result = res };
        }
    }

    [CLSCompliant(true)]
    public class ActionMetaItem
    {
        public class VisualItem
        {
            public ActionsAlignment Alignment { get; protected set; }
            public ActionsPanelType PanelType { get; protected set; }
            public ActionsAppType AppType { get; protected set; }
            public string CaptionId { get; protected set; }
            public string IconId { get; protected set; }
            public string TooltipId { get; protected set; }
            public string CaptionIdReadOnly { get; protected set; }
            public string IconIdReadOnly { get; protected set; }
            public string TooltipIdReadOnly { get; protected set; }

            public VisualItem(VisualItem item)
            {
                CaptionId = item.CaptionId;
                IconId = item.IconId;
                TooltipId = item.TooltipId;
                CaptionIdReadOnly = item.CaptionIdReadOnly;
                IconIdReadOnly = item.IconIdReadOnly;
                TooltipIdReadOnly = item.TooltipIdReadOnly;
                Alignment = item.Alignment;
                PanelType = item.PanelType;
                AppType = item.AppType;
            }

            public VisualItem
                (
                    string caption,
                    string icon,
                    string tooltip,
                    string captionReadonly,
                    string iconReadonly,
                    string tooltipReadonly,
                    ActionsAlignment align,
                    ActionsPanelType panel,
                    ActionsAppType app
                )
            {
                CaptionId = caption;
                IconId = icon;
                TooltipId = tooltip;
                CaptionIdReadOnly = captionReadonly;
                IconIdReadOnly = iconReadonly;
                TooltipIdReadOnly = tooltipReadonly;
                Alignment = align;
                PanelType = panel;
                AppType = app;
            }
        }
        private VisualItem m_visual;

        public string Name { get; protected set; }
        public ActionTypes ActionType { get; protected set; }
        public bool IsExtended { get; protected set; }
        public bool IsWebJScript { get; protected set; }
        public string RelatedLists { get; protected set; }
        public string Container { get; protected set; }
        public string Permission { get; protected set; }
        public Func<bool> PermissionPredicate { get; protected set; }

        public ActionsAlignment Alignment { get { return m_visual == null ? ActionsAlignment.Left : m_visual.Alignment; } }
        public ActionsPanelType PanelType { get { return m_visual == null ? ActionsPanelType.Main : m_visual.PanelType; } }
        public ActionsAppType AppType { get { return m_visual == null ? ActionsAppType.All : m_visual.AppType; } }
        public string CaptionId(IObject c, IObjectPermissions p)
        {
            return m_visual == null ? "" : (IsReadOnly(c, p) ? (!string.IsNullOrEmpty(m_visual.CaptionIdReadOnly) ? m_visual.CaptionIdReadOnly : m_visual.CaptionId) : m_visual.CaptionId);
        }
        public string IconId(IObject c, IObjectPermissions p)
        {
            return m_visual == null ? "" : (IsReadOnly(c, p) ? (!string.IsNullOrEmpty(m_visual.IconIdReadOnly) ? m_visual.IconIdReadOnly : m_visual.IconId) : m_visual.IconId);
        }
        public string TooltipId(IObject c, IObjectPermissions p)
        {
            return m_visual == null ? "" : (IsReadOnly(c, p) ? (!string.IsNullOrEmpty(m_visual.TooltipIdReadOnly) ? m_visual.TooltipIdReadOnly : m_visual.TooltipId) : m_visual.TooltipId);
        }

        public bool IsNeedClose { get { return ForceClose || (ActionType == ActionTypes.Cancel || ActionType == ActionTypes.Ok || ActionType == ActionTypes.Close); } }

        /// <summary>
        /// Если true, то это действие закрывает форму
        /// </summary>
        public bool ForceClose { get; private set; }

        private List<Func<IObject, IObjectPermissions, bool, bool>> m_visiblePredicates = new List<Func<IObject, IObjectPermissions, bool, bool>>();
        private List<Func<IObject, IObjectPermissions, bool, bool>> m_enablePredicates = new List<Func<IObject, IObjectPermissions, bool, bool>>();
        private List<Func<IObject, IObjectPermissions, bool, bool>> m_readonlyPredicates = new List<Func<IObject, IObjectPermissions, bool, bool>>();
        private List<Func<DbManagerProxy, IObject, List<object>, ActResult>> m_actionFuncs = new List<Func<DbManagerProxy, IObject, List<object>, ActResult>>();
        private List<object> m_actionPars = new List<object>();
        public List<object> Parameters { get { return m_actionPars; } }

        public bool IsVisible(IObject c, IObjectPermissions p)
        {
            bool ret = m_visual != null;
            m_visiblePredicates.ForEach(i => { ret = i(c, p, ret); });
            return ret;
        }
        public ActionMetaItem AddVisiblePredicate(Func<IObject, IObjectPermissions, bool, bool> predicate)
        {
            m_visiblePredicates.Add(predicate);
            return this;
        }
        public static bool DefaultDeleteGroupItemVisiblePredicate(IObject o, IObjectPermissions p, bool bPrev)
        {
            if(p == null && o != null)
                p = o.GetPermissions();
            return o != null && !o.ReadOnly && p != null && p.CanUpdate;
        }

        public bool DefaultVisiblePredicate(IObject o, IObjectPermissions p, bool bPrev)
        {
            if (m_visual == null) return false;
            bool rdonly = IsReadOnly(o, p);
            
            var result = true;

            if (p != null)
            {
                #region Проверка полномочий
                switch (ActionType)
                {
                    case ActionTypes.Action:
                        if (PermissionPredicate == null)
                        {
                            if (string.IsNullOrEmpty(Permission))
                                result = p.CanExecute(Name);
                            else
                                result = p.CanExecute(Permission);
                        }
                        else
                        {
                            result = !rdonly && PermissionPredicate();
                        }
                        break;

                    case ActionTypes.Create:
                        result = !rdonly && p.CanInsert;
                        break;

                    case ActionTypes.Ok:
                        result = !rdonly && (p.CanInsert || p.CanUpdate);
                        break;

                    case ActionTypes.Delete:
                        result = !rdonly && p.CanDelete;
                        break;

                    case ActionTypes.Save:
                        result = !rdonly && p.CanUpdate;
                        break;
                }

                #endregion
            }
            else
            {
                switch (ActionType)
                {
                    case ActionTypes.Create:
                        result = !rdonly;
                        break;
                    case ActionTypes.Ok:
                        result = !rdonly;
                        break;
                    case ActionTypes.Delete:
                        result = !rdonly;
                        break;
                    case ActionTypes.Save:
                        result = !rdonly;
                        break;
                }
            }
            
            return result;
        }

        public bool IsEnable(IObject c, IObjectPermissions p)
        {
            bool ret = true;
            m_enablePredicates.ForEach(i => { ret = i(c, p, ret); });
            return ret;
        }
        public ActionMetaItem AddEnablePredicate(Func<IObject, IObjectPermissions, bool, bool> predicate)
        {
            m_enablePredicates.Add(predicate);
            return this;
        }
        internal bool DefaultEnablePredicate(IObject o, IObjectPermissions p, bool bPrev)
        {
            bool ret = true;
            switch (ActionType)
            {
                case ActionTypes.Edit:
                    ret = (o != null);
                    break;
                case ActionTypes.View:
                    ret = (o != null);
                    break;
                case ActionTypes.Delete:
                    ret = (o != null);
                    break;
                case ActionTypes.Select:
                    ret = (o != null);
                    break;
            }
            return ret;
        }

        public bool IsReadOnly(IObject c, IObjectPermissions p)
        {
            bool ret = false;
            m_readonlyPredicates.ForEach(i => { ret = i(c, p, ret); });
            return ret;
        }
        public ActionMetaItem AddReadOnlyPredicate(Func<IObject, IObjectPermissions, bool, bool> predicate)
        {
            m_readonlyPredicates.Add(predicate);
            return this;
        }
        internal bool DefaultReadOnlyPredicate(IObject o, IObjectPermissions p, bool bPrev)
        {
            bool ret = false;
            if (o != null)
            {
                ret = o.ReadOnly;
            }
            if (p != null)
            {
                switch (ActionType)
                {
                    case ActionTypes.Edit:
                        ret |= !p.CanUpdate;
                        break;
                    case ActionTypes.View:
                        ret |= p.CanUpdate;
                        break;
                    case ActionTypes.Delete:
                        ret |= !p.CanDelete;
                        break;
                    case ActionTypes.Create:
                        ret |= !p.CanInsert;
                        break;
                }
            }
            return ret;
        }


        public ActionMetaItem AddFirstUIFunc(Func<DbManagerProxy, IObject, List<object>, ActResult> f, List<object> pars)
        {
            m_actionFuncs.Insert(0, f);
            if (pars != null)
                m_actionPars.AddRange(pars);
            return this;
        }
        public ActionMetaItem AddSecondUIFunc(Func<DbManagerProxy, IObject, List<object>, ActResult> f, List<object> pars)
        {
            m_actionFuncs.Insert(2, f);
            if (pars != null)
                m_actionPars.AddRange(pars);
            return this;
        }
        public ActResult RunAction(DbManagerProxy manager, IObject c, List<object> pars = null)
        {
            var ret = new ActResult { obj = c, result = true };
            for (int i = 0; i < m_actionFuncs.Count; i++)
            {
                ret = m_actionFuncs[i](manager, ret.obj, pars ?? m_actionPars);
                if (!ret.result)
                    break;
            }
            return ret;
        }

        public bool IsCreate { get { return ActionType == ActionTypes.Create; } }

        /// <summary>
        /// Проверяет наличие указанного значения среди параметров
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasParameterValue(object value)
        {
            var result = false;
            if (value == null)
            {
                result = Parameters.Count(p => p == null) > 0;
            }
            else
            {
                foreach (var parameter in Parameters)
                {
                    if (parameter == null) continue;
                    long par;
                    long val;
                    if (Int64.TryParse(parameter.ToString(), out par) && Int64.TryParse(value.ToString(), out val))
                    {
                        result = val == par;
                        if (result) break;
                    }
                    else
                    {
                        result = value == parameter;
                        if (result) break;
                    }
                }
            }
            return result;
        }

        public ActionMetaItem(ActionMetaItem item)
        {
            Name = item.Name;
            ActionType = item.ActionType;
            IsExtended = item.IsExtended;
            RelatedLists = item.RelatedLists;
            Container = item.Container;
            m_actionFuncs.AddRange(item.m_actionFuncs);
            m_visual = item.m_visual != null ? new VisualItem(item.m_visual) : null;
            IsWebJScript = item.IsWebJScript;
            Permission = item.Permission;
            PermissionPredicate = item.PermissionPredicate;
            m_enablePredicates.AddRange(item.m_enablePredicates);
            m_readonlyPredicates.AddRange(item.m_readonlyPredicates);
            m_visiblePredicates.AddRange(item.m_visiblePredicates);
            ForceClose = item.ForceClose;
        }

        public ActionMetaItem(
            string name,
            ActionTypes type,
            bool extended,
            string related,
            string container,
            Func<DbManagerProxy, IObject, List<object>, ActResult> first_func,
            Func<DbManagerProxy, IObject, List<object>, ActResult> second_func,
            VisualItem visual,
            bool isWebJScript = false,
            string permission = null,
            Func<bool> permissionPredicate = null,
            Func<IObject, IObjectPermissions, bool, bool> enablePredicate = null,
            Func<IObject, IObjectPermissions, bool, bool> rdonlyPredicate = null,
            Func<IObject, IObjectPermissions, bool, bool> visiblePredicate = null,
            bool forceClose = false
            )
        {
            Name = name;
            ActionType = type;
            IsExtended = extended;
            RelatedLists = related;
            Container = container;
            if (first_func != null)
                m_actionFuncs.Add(first_func);
            if (second_func != null)
                m_actionFuncs.Add(second_func);
            m_visual = visual;
            IsWebJScript = isWebJScript;
            Permission = permission;
            PermissionPredicate = permissionPredicate;
            m_enablePredicates.Add(enablePredicate ?? DefaultEnablePredicate);
            m_readonlyPredicates.Add(rdonlyPredicate ?? DefaultReadOnlyPredicate);
            m_visiblePredicates.Add(visiblePredicate ?? DefaultVisiblePredicate);
            ForceClose = forceClose;
        }
    }

    /*
    [CLSCompliant(true)]
    public class ActionMetaItem
    {
        private string m_CaptionId;
        private string m_IconId;
        private string m_TooltipId;
        private ActionTypes m_ActionType;

        public bool ReadOnly { get; set; }
        public string Name { get; set; }
        public string CaptionId { get { return ReadOnly && !string.IsNullOrEmpty(CaptionIdReadOnly) ? CaptionIdReadOnly : m_CaptionId;  } protected set { m_CaptionId = value; } }
        public string IconId { get { return ReadOnly && !string.IsNullOrEmpty(IconIdReadOnly) ? IconIdReadOnly : m_IconId; } protected set { m_IconId = value; } }
        public string TooltipId { get { return ReadOnly && !string.IsNullOrEmpty(TooltipIdReadOnly) ? TooltipIdReadOnly : m_TooltipId; } protected set { m_TooltipId = value; } }
        public string CaptionIdReadOnly { get; set; }
        public string IconIdReadOnly { get; set; }
        public string TooltipIdReadOnly { get; protected set; }
        public ActionsAlignment Alignment { get; protected set; }
        public ActionsPanelType PanelType { get; protected set; }
        public ActionsAppType AppType { get; protected set; }
        public bool IsExtended { get; protected set; }
        public bool IsVisible { get; protected set; }
        public bool IsNeedClose { get; protected set; }
        public bool IsNeedValidation { get; set; }
        public Func<DbManagerProxy, IObject, List<object>, bool> ActionFunction { get; set; }
        public Func<DbManagerProxy, List<object>, IObject> CreateFunction { get; protected set; }
        public Func<ActionMetaItem, IObject, bool> EnabledFunction { get; protected set; }

        public bool IsAction { get { return ActionFunction != null; } }
        public bool IsCreate { get { return CreateFunction != null; } }
        public ActionTypes ActionType { get { return ReadOnly ? ActionTypeReadOnly : m_ActionType; } protected set { m_ActionType = value; } }
        public ActionTypes ActionTypeReadOnly { get; set; }
        public ActionTypes ActionMethod { get; set; }
        public string Permission { get; protected set; }
        public Func<bool> PermissionPredicate { get; protected set; }

        /// <summary>
        /// Связанное действие
        /// </summary>
        public ActionMetaItem ActionLinked { get; protected set; }

        /// <summary>
        /// Название типа потомка BasePanel, которую нужно создать, если ActionType = ShowForm
        /// </summary>
        public string BasePanelTypeName { get; set; } //TODO внести в конструктор? (+protected set)

        /// <summary>
        /// Если задан, то действия с одной группой упаковываются в выпадающий список
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// Список параметров, которые могут быть связаны с произвольным действием
        /// </summary>
        public List<object> Parameters { get; set; }

        /// <summary>
        /// Проверяет наличие указанного значения среди параметров
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasParameterValue(object value)
        {
            var result = false;
            if (value == null)
            {
                result = Parameters.Count(p => p == null) > 0;
            }
            else
            {
                foreach (var parameter in Parameters)
                {
                    if (parameter == null) continue;
                    long par;
                    long val;
                    if (Int64.TryParse(parameter.ToString(), out par) && Int64.TryParse(value.ToString(), out val))
                    {
                        result = val == par;
                        if (result) break;
                    }
                    else
                    {
                        result = value == parameter;
                        if (result) break;
                    }
                }
            }
            return result;
        }

        public string RelatedLists {get; protected set;}

        /// <summary>
        /// 
        /// </summary>
        public ActionMetaItem()
        {
            InitRoutines();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <param name="tooltip"></param>
        /// <param name="captionReadonly"></param>
        /// <param name="iconReadonly"></param>
        /// <param name="tooltipReadonly"></param>
        /// <param name="permission"> </param>
        /// <param name="permissionPredicate"> </param>
        /// <param name="align"></param>
        /// <param name="panel"></param>
        /// <param name="app"></param>
        /// <param name="extended"></param>
        /// <param name="visible"></param>
        /// <param name="close"></param>
        /// <param name="action"></param>
        /// <param name="create"></param>
        /// <param name="enabled"></param>
        /// <param name="actionType"></param>
        /// <param name="actionTypeReadonly"></param>
        /// <param name="actionMethod"></param>
        /// <param name="groupCode"></param>
        /// <param name="relatedLists"> </param>
        public ActionMetaItem(
            string name,
            string caption,
            string icon,
            string tooltip,
            string captionReadonly,
            string iconReadonly,
            string tooltipReadonly,
            string permission,
            Func<bool> permissionPredicate,
            ActionsAlignment align,
            ActionsPanelType panel,
            ActionsAppType app,
            bool extended,
            bool visible,
            bool close,
            Func<DbManagerProxy, IObject, List<object>, bool> action,
            Func<DbManagerProxy, List<object>, IObject> create,
            Func<ActionMetaItem, IObject, bool> enabled,
            ActionTypes actionType,
            ActionTypes actionTypeReadonly,
            ActionTypes actionMethod,
            string groupCode,
            string relatedLists = null
            )
        {
            Name = name;
            CaptionId = caption;
            IconId = icon;
            TooltipId = tooltip;
            CaptionIdReadOnly = captionReadonly;
            IconIdReadOnly = iconReadonly;
            TooltipIdReadOnly = tooltipReadonly;
            Permission = permission;
            PermissionPredicate = permissionPredicate;
            Alignment = align;
            PanelType = panel;
            AppType = app;
            IsExtended = extended;
            IsVisible = visible;
            IsNeedClose = close;
            ActionFunction = action;
            CreateFunction = create;
            EnabledFunction = enabled;
            ActionType = actionType;
            ActionTypeReadOnly = actionTypeReadonly;
            ActionMethod = actionMethod;
            GroupCode = groupCode;
            RelatedLists = relatedLists;

            InitRoutines();
        }

        public ActionMetaItem(ActionMetaItem other)
        {
            Name = other.Name;
            CaptionId = other.CaptionId;
            IconId = other.IconId;
            TooltipId = other.TooltipId;
            CaptionIdReadOnly = other.CaptionIdReadOnly;
            IconIdReadOnly = other.IconIdReadOnly;
            TooltipIdReadOnly = other.TooltipIdReadOnly;
            Permission = other.Permission;
            PermissionPredicate = other.PermissionPredicate;
            Alignment = other.Alignment;
            PanelType = other.PanelType;
            AppType = other.AppType;
            IsExtended = other.IsExtended;
            IsVisible = other.IsVisible;
            IsNeedClose = other.IsNeedClose;
            ActionFunction = other.ActionFunction;
            CreateFunction = other.CreateFunction;
            EnabledFunction = other.EnabledFunction;
            ActionType = other.ActionType;
            ActionTypeReadOnly = other.ActionTypeReadOnly;
            ActionMethod = other.ActionMethod;
            GroupCode = other.GroupCode;
            RelatedLists = other.RelatedLists;

            InitRoutines();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitRoutines()
        {
            Parameters = new List<object>();
        }


        public bool RunActionFunction(DbManagerProxy manager, IObject c, List<object> pars = null)
        {
            if (ActionFunction != null)
                return ActionFunction(manager, c, pars);
            throw new ArgumentNullException();
        }

        public bool IsActionEnabled(IObject c)
        {
            if (EnabledFunction != null)
                return EnabledFunction(this, c);
            return c == null || !c.ReadOnly;
        }

        public bool IsActionVisibleForWeb(IObject c)
        {
            if (c == null) return true;
            if (EnabledFunction != null)
                return EnabledFunction(this, c);
            return !c.ReadOnly;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObject RunCreateFunction(DbManagerProxy manager)
        {
            if (CreateFunction != null)
                return CreateFunction(manager, null);
            throw new ArgumentNullException();
        }
        public IObject RunCreateFunction(DbManagerProxy manager, int? haCode)
        {
            if (CreateFunction != null)
                return CreateFunction(manager, new List<object> { haCode });
            throw new ArgumentNullException();
        }
        public IObject RunCreateFunction(DbManagerProxy manager, List<object> pars)
        {
            if (CreateFunction != null)
                return CreateFunction(manager, pars);
            throw new ArgumentNullException();
        }
        public static bool IsListItemActionEnabled(ActionMetaItem action, IObject bo)
        {
            switch(action.ActionType)
            {
                case ActionTypes.Create:
                case ActionTypes.Save:
                    return !action.ReadOnly;
                case ActionTypes.Edit:
                    return bo != null && !bo.ReadOnly;
                case ActionTypes.View:
                    return bo != null;
                case ActionTypes.Delete:
                    if (action.ReadOnly)
                        return false;
                    return ( bo != null && !bo.ReadOnly);
                default:
                    return true;
            }
        }
    }
    */
}
