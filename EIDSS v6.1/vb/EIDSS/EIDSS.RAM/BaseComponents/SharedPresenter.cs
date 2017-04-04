using System;
using System.Collections.Generic;
using System.Data;
using bv.common.Core;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.avr.BaseComponents.Views;
using eidss.avr.ChartForm;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataTableCopier;
using eidss.avr.db.Interfaces;
using eidss.avr.LayoutForm;
using eidss.avr.MainForm;
using eidss.avr.MapForm;
using eidss.avr.PivotComponents;
using eidss.avr.PivotForm;
using eidss.avr.QueryBuilder;
using eidss.avr.QueryLayoutTree;
using eidss.avr.ViewForm;
using eidss.model.Avr.Commands.Models;
using eidss.model.AVR.SourceData;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using StructureMap;

namespace eidss.avr.BaseComponents
{
    public class SharedPresenter : IDisposable
    {
        private readonly SharedModel m_SharedModel;
        private readonly IContextKeeper m_ContextKeeper;
        private readonly Dictionary<IBaseAvrView, BaseAvrPresenter> m_ChildPresenters;
        private IContainer m_Container;

        public SharedPresenter(IContainer container, IPostable parentForm)
        {
            Utils.CheckNotNull(parentForm, "parentForm");
            Utils.CheckNotNull(container, "container");

            m_Container = container;
            m_SharedModel = new SharedModel(parentForm, new ExportDialogStrategy());
            m_ContextKeeper = new ContextKeeper();
            m_ChildPresenters = new Dictionary<IBaseAvrView, BaseAvrPresenter>();

            TableCopier = new AvrDataTableCopier();
        }

        public void Dispose()
        {
            m_ChildPresenters.Clear();
            DisposeTableCopier();
            m_SharedModel.Dispose();
        }

        public IContextKeeper ContextKeeper
        {
            get { return m_ContextKeeper; }
        }

        public SharedModel SharedModel
        {
            get { return m_SharedModel; }
        }

        public AvrDataTableCopier TableCopier { get; private set; }

        public bool IsQueryResultNull { get; private set; }

        public BaseAvrPresenter this[IBaseAvrView view]
        {
            get
            {
                Utils.CheckNotNull(view, "view");
                if (!m_ChildPresenters.ContainsKey(view))
                {
                    RegisterPresenterFor(view);
                }
                return m_ChildPresenters[view];
            }
        }

        public void UnregisterView(IBaseAvrView view)
        {
            Utils.CheckNotNull(view, "view");
            if (m_ChildPresenters.ContainsKey(view))
            {
                m_ChildPresenters.Remove(view);
            }
        }

        public void SetQueryResult(CachedQueryResult result)
        {
            DisposeTableCopier();
            if (result != null)
            {
                IsQueryResultNull = false;

                TableCopier = new AvrDataTableCopier(result);
            }
            else
            {
                IsQueryResultNull = true;
                TableCopier = new AvrDataTableCopier();
            }
        }

        public AvrDataTable GetQueryResultCopy(string filter)
        {
            CheckQueryResultAndTableCopier();

            AvrDataTable copy = TableCopier.GetCopy(filter);

            return copy;
        }

        public AvrDataTable GetQueryResultClone()
        {
            CheckQueryResultAndTableCopier();

            return TableCopier.GetClone();
        }

        private void CheckQueryResultAndTableCopier()
        {
            if (IsQueryResultNull)
            {
                throw new InvalidOperationException("Canot create copy of QueryResult because it is null");
            }
            if (TableCopier == null)
            {
                throw new AvrException("SharedModel.TableCopier is not initialized");
            }
        }

        public void BindAggregateFunctionsInternal(LookUpEdit lookUp, AggregateFunctionTarget target)
        {
            lookUp.DataBindings.Clear();

            lookUp.Properties.Columns.Clear();
            var info = new LookUpColumnInfo(AggrFunctionLookupHelper.ColumnName,
                EidssMessages.Get("colCaption", "Caption"),
                200, FormatType.None, "", true, HorzAlignment.Near);
            lookUp.Properties.Columns.AddRange(new[] {info});
            lookUp.Properties.PopupWidth = lookUp.Width;
            lookUp.Properties.NullText = string.Empty;

            lookUp.Properties.DataSource = AggrFunctionLookupHelper.GetLookupTable(target);
            lookUp.Properties.ValueMember = AggrFunctionLookupHelper.ColumnId;
            lookUp.Properties.DisplayMember = AggrFunctionLookupHelper.ColumnName;

            lookUp.EditValue = DBNull.Value;
            lookUp.Enabled = false;
        }

        public static string GetSelectedAdministrativeFieldAlias(DataView dataView, IAvrPivotGridField field)
        {
            string fieldAlias = null;
            if (dataView != null && dataView.Count > 0)
            {
                if (field != null &&
                    !string.IsNullOrEmpty(field.UnitSearchFieldAlias) &&
                    field.UnitLayoutSearchFieldId.HasValue &&
                    field.UnitLayoutSearchFieldId.Value != -1)
                {
                    fieldAlias = AvrPivotGridFieldHelper.CreateFieldName(field.UnitSearchFieldAlias, field.UnitLayoutSearchFieldId.Value);
                }

                if (fieldAlias == null &&
                    field != null &&
                    field.UnitLayoutSearchFieldId.HasValue &&
                    field.UnitLayoutSearchFieldId.Value == -1)
                {
                    string oldFilter = dataView.RowFilter;
                    dataView.RowFilter = string.Format("Alias = '{0}'", AvrPivotGridFieldHelper.VirtualCountryFieldName);
                    if (dataView.Count > 0)
                    {
                        fieldAlias = AvrPivotGridFieldHelper.VirtualCountryFieldName;
                    }
                    dataView.RowFilter = oldFilter;
                }
                if (fieldAlias == null)
                {
                    fieldAlias = Utils.Str(dataView[0]["Alias"]);
                }
            }
            return fieldAlias;
        }

        public bool TryGetStartUpParameter(string key, out object value)
        {
            value = null;
            Dictionary<string, object> parameters = SharedModel.StartUpParameters;
            if ((parameters != null) && (parameters.ContainsKey(key)))
            {
                value = parameters[key];
                return true;
            }
            return false;
        }

        private void RegisterPresenterFor(IBaseAvrView view)
        {
            BaseAvrPresenter avrPresenter;
            if (view is IMapView)
            {
                avrPresenter = new MapPresenter(this, (IMapView) view);
            }
            else if (view is IChartView)
            {
                avrPresenter = new ChartPresenter(this, (IChartView) view);
            }
            else if (view is IPivotDetailView)
            {
                avrPresenter = new PivotDetailPresenter(this, (IPivotDetailView) view);
            }
            else if (view is ILayoutDetailView)
            {
                avrPresenter = new LayoutDetailPresenter(this, (ILayoutDetailView) view);
            }
            else if (view is IAvrPivotGridView)
            {
                avrPresenter = new AvrPivotGridPresenter(this, (IAvrPivotGridView) view);
            }
            else if (view is IAvrMainFormView)
            {
                avrPresenter = new AvrMainFormPresenter(this, (IAvrMainFormView) view);
            }
            else if (view is IQueryLayoutTreeView)
            {
                avrPresenter = new QueryLayoutTreePresenter(this, (IQueryLayoutTreeView) view);
            }
            else if (view is IPivotInfoDetailView)
            {
                avrPresenter = new PivotInfoPresenter(this, (IPivotInfoDetailView) view);
            }
            else if (view is IViewDetailView)
            {
                avrPresenter = new ViewDetailPresenter(this, (IViewDetailView) view);
            }

            else if (view is IQueryDetailView)
            {
                avrPresenter = new QueryDetailPresenter(this, (IQueryDetailView) view);
            }
            else
            {
                throw new NotSupportedException(string.Format("Not supported view {0}", view));
            }

            view.SendCommand += View_SendCommand;
            m_ChildPresenters.Add(view, avrPresenter);
        }

        private void View_SendCommand(object sender, CommandEventArgs e)
        {
            Utils.CheckNotNull(e, "e");
            Utils.CheckNotNull(e.Command, "e.Command");

            foreach (BaseAvrPresenter value in m_ChildPresenters.Values)
            {
                value.Process(e.Command);
            }
        }

        private void DisposeTableCopier()
        {
            if (TableCopier != null)
            {
                TableCopier.Dispose();
                TableCopier = null;
            }
        }
    }
}