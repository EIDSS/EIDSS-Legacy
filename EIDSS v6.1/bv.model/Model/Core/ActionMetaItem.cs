using System;
using System.Collections.Generic;
using bv.common.Enums;
using bv.model.BLToolkit;
using System.Linq;
using System.Collections;

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
        protected List<ActionMetaItem> ChildrenInternal { get; set; }
        public Func<IObject, IEnumerable<ActionMetaItem>> ChildrenDynamic { get; protected set; }
        public bool IsSingle { get; protected set; }

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

        /// <summary>
        /// Если true, то это действие применяется к строке
        /// </summary>
        public bool OnRow { get; private set; }

        public string MethodName { get; protected set; }


        private List<Func<IObject, IObject, IObjectPermissions, bool, bool>> m_visiblePredicates = new List<Func<IObject, IObject, IObjectPermissions, bool, bool>>();
        private List<Func<IObject, IObjectPermissions, bool, bool>> m_enablePredicates = new List<Func<IObject, IObjectPermissions, bool, bool>>();
        private List<Func<IObject, IObjectPermissions, bool, bool>> m_readonlyPredicates = new List<Func<IObject, IObjectPermissions, bool, bool>>();
        private List<Func<DbManagerProxy, IObject, List<object>, ActResult>> m_actionFuncs = new List<Func<DbManagerProxy, IObject, List<object>, ActResult>>();
        private List<object> m_actionPars = new List<object>();
        private bool m_bFirstUI;
        private bool m_bLastUI;
        public bool IsFirstUI { get { return m_bFirstUI; } }
        private Func<DbManagerProxy, IObject, List<object>, ActResult> m_FirstUIFunc;
        public Func<DbManagerProxy, IObject, List<object>, ActResult> FirstUIFunc { get { return m_FirstUIFunc; }}
        public List<object> Parameters { get { return m_actionPars; } }

        public bool IsVisible(IObject c, IObjectPermissions p)
        {
            bool ret = m_visual != null;
            m_visiblePredicates.ForEach(i => { ret = i(c, c, p, ret); });
            return ret;
        }
        private bool IsVisible(IObject c, IObject a, IObjectPermissions p)
        {
            bool ret = m_visual != null;
            m_visiblePredicates.ForEach(i => { ret = i(c, a, p, ret); });
            return ret;
        }
        public bool IsVisible(IList<IObject> objs, IObjectPermissions p)
        {
            return (!IsSingle || (IsSingle && objs.Count == 1)) 
                && objs.Aggregate(new Tuple<bool, IObject>(true, null), (b, o) => new Tuple<bool, IObject>(b.Item1 && IsVisible(o, b.Item2, p) && DefaultVisiblePredicate(o, b.Item2, p, true), o)).Item1;
        }


        public ActionMetaItem AddVisiblePredicate(Func<IObject, IObject, IObjectPermissions, bool, bool> predicate)
        {
            m_visiblePredicates.Add(predicate);
            return this;
        }
        public static bool DefaultDeleteGroupItemVisiblePredicate(IObject o, IObject a, IObjectPermissions p, bool bPrev)
        {
            if(p == null && o != null)
                p = o.GetPermissions();
            return o != null && !o.ReadOnly && p != null && p.CanUpdate;
        }

        public bool DefaultVisiblePredicate(IObject o, IObject a, IObjectPermissions p, bool bPrev)
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
                            result = p.CanExecute(String.IsNullOrEmpty(Permission) ? Name : Permission);
                        }
                        else
                        {
                            result = !rdonly && PermissionPredicate();
                        }
                        break;

                    case ActionTypes.Create:
                        result = /*!rdonly &&*/ p.CanInsert;
                        break;

                    case ActionTypes.Ok:
                        result = !rdonly && (p.CanInsert || p.CanUpdate);
                        break;

                    case ActionTypes.Delete:
                        result = /*!rdonly &&*/ p.CanDelete;
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
                    ret = (o != null && !o.Key.Equals(PredefinedObjectId.FakeListObject));
                    break;
                case ActionTypes.View:
                    ret = (o != null && !o.Key.Equals(PredefinedObjectId.FakeListObject));
                    break;
                case ActionTypes.Delete:
                    ret = (o != null) && o.IsValidObject && !o.Key.Equals(PredefinedObjectId.FakeListObject) && !IsReadOnly(o, p);
                    break;
                case ActionTypes.Select:
                    ret = (o != null && !o.Key.Equals(PredefinedObjectId.FakeListObject));
                    break;
                case ActionTypes.Create:
                    ret = !IsReadOnly(o, p);
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
                if (o.Environment != null)
                    ret = o.Environment.ReadOnly;
                ret |= o.ReadOnly;
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
            if (m_actionFuncs.Count == 0 || m_actionFuncs[0].Method != f.Method)
            {
                m_bFirstUI = true;
                m_FirstUIFunc = f;
                m_actionFuncs.Insert(0, f);
                if (pars != null)
                    m_actionPars.AddRange(pars);
            }
            return this;
        }
        public ActionMetaItem AddSecondUIFunc(Func<DbManagerProxy, IObject, List<object>, ActResult> f, List<object> pars)
        {
            if (m_actionFuncs.Count < 3 || m_actionFuncs[2].Method != f.Method)
            {
                m_bLastUI = true;
                m_actionFuncs.Insert(2, f);
                if (pars != null)
                    m_actionPars.AddRange(pars);
            }
            return this;
        }

        public ActResult RunAction(DbManagerProxy manager, List<IObject> cc, List<object> pars = null)
        {
            var actual_pars = new List<object>(pars ?? m_actionPars);
            actual_pars.Insert(0, cc);

            /*long actionIdent;
            if (long.TryParse(Name, out actionIdent))
            {
                actual_pars.Insert(0, actionIdent);
            }*/

            for (int j = 0; j < cc.Count; j++)
            {
                var ret = new ActResult { obj = cc[j], result = true };

                for (int i = 0; i < m_actionFuncs.Count; i++)
                {
                    if (m_bFirstUI && i == 0 && j > 0)
                        continue;

                    if (m_bLastUI && i == m_actionFuncs.Count - 1 && j < cc.Count - 1)
                        continue;

                    ret = m_actionFuncs[i](manager, ret.obj, actual_pars);

                    if (!ret.result)
                        return ret;
                }
            }
            return true;
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

        public List<ActionMetaItem> Children(IObject o)
        { 
            return ChildrenDynamic != null
                ? new List<ActionMetaItem>(ChildrenDynamic(o))
                : ChildrenInternal;
        }
        public List<ActionMetaItem> Children(IList<IObject> objs)
        {
            var ret = Children(objs[0]);
            for (int i = 1; i < objs.Count; i++)
                ret = ret.Intersect(Children(objs[i]), new ActionMetaItemNameComparer()).ToList();
            return ret;
        }
        private class ActionMetaItemNameComparer : IEqualityComparer<ActionMetaItem>
        {
            public bool Equals(ActionMetaItem x, ActionMetaItem y)
            {
                return x.Name.CompareTo(y.Name) == 0;
            }

            public int GetHashCode(ActionMetaItem obj)
            {
                return obj.Name.GetHashCode();
            }
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
            OnRow = item.OnRow;
            MethodName = item.MethodName;
            ChildrenInternal = new List<ActionMetaItem>(item.ChildrenInternal.Select(c => new ActionMetaItem(c)));
            ChildrenDynamic = item.ChildrenDynamic;
            IsSingle = item.IsSingle;
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
            Func<IObject, IObject, IObjectPermissions, bool, bool> visiblePredicate = null,
            bool forceClose = false,
            bool onRow = false,
            string methodName = null,
            bool isSingle = false,
            IEnumerable<ActionMetaItem> childsActions = null,
            Func<IObject, IEnumerable<ActionMetaItem>> childDynamic = null
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
            OnRow = onRow;
            MethodName = methodName ?? name;
            ChildrenInternal = childsActions == null ? new List<ActionMetaItem>() : new List<ActionMetaItem>(childsActions);
            ChildrenDynamic = childDynamic;
            IsSingle = isSingle;
        }
    }

}
