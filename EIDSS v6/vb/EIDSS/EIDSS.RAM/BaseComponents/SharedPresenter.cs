using System;
using System.Collections.Generic;
using System.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.avr.BaseComponents.Views;
using eidss.avr.ChartForm;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
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
using eidss.model.Avr.Pivot;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;

namespace eidss.avr.BaseComponents
{
    public class SharedPresenter : IDisposable
    {
        private readonly SharedModel m_SharedModel;
        private readonly IContextKeeper m_ContextKeeper;
        private readonly Dictionary<IBaseAvrView, BaseAvrPresenter> m_ChildPresenters;

        public SharedPresenter(IPostable parentForm)
        {
            Utils.CheckNotNull(parentForm, "parentForm");

            m_SharedModel = new SharedModel(parentForm, new ExportDialogStrategy());
            m_ContextKeeper = new ContextKeeper();
            m_ChildPresenters = new Dictionary<IBaseAvrView, BaseAvrPresenter>();

            TableCopier = DataTableCopierFactory.CreateEmptyDataTableCopier();
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

        public IDataTableCopier TableCopier { get; private set; }

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

        public void SetQueryResult(DataTable result)
        {
            DisposeTableCopier();
            if (result != null)
            {
                IsQueryResultNull = false;
                foreach (DataColumn column in result.Columns)
                {
                    column.ReadOnly = false;
                }
                TableCopier = DataTableCopierFactory.CreateDataTableCopier(result);
            }
            else
            {
                IsQueryResultNull = true;
                TableCopier = DataTableCopierFactory.CreateEmptyDataTableCopier();
            }

            TableCopier.ForceStart();
        }

        public DataTable GetQueryResultCopy()
        {
            CheckQueryResultAndTableCopier();

            DataTable copy = TableCopier.GetCopy();
            if (TableCopier.IsOutOfMemory)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw new AvrException("Could not get datasource copy for layout because of out of memory");
                }
                ErrorForm.ShowErrorDirect(EidssMessages.Get("msgInsufficientMemory", "Insufficient memory. Try to close and reopen AVR."));
            }

            return copy;
        }

        public DataTable GetQueryResultClone()
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

        public void BindAggregateFunctionsInternal(LookUpEdit lookUp, bool forPivot, bool forView)
        {
            lookUp.DataBindings.Clear();

            lookUp.Properties.Columns.Clear();
            var info = new LookUpColumnInfo(AggrFunctionLookupHelper.ColumnName,
                EidssMessages.Get("colCaption", "Caption"),
                200, FormatType.None, "", true, HorzAlignment.Near);
            lookUp.Properties.Columns.AddRange(new[] {info});
            lookUp.Properties.PopupWidth = lookUp.Width;
            lookUp.Properties.NullText = string.Empty;

            lookUp.Properties.DataSource = AggrFunctionLookupHelper.GetLookupTable(forPivot, forView);
            lookUp.Properties.ValueMember = AggrFunctionLookupHelper.ColumnId;
            lookUp.Properties.DisplayMember = AggrFunctionLookupHelper.ColumnName;

            lookUp.EditValue = DBNull.Value;
            lookUp.Enabled = false;
        }

        public static string GetSelectedAdministrativeFieldAlias(DataView dataView, IAvrPivotGridField field)
        {
            string fieldAlias = null;
            if (dataView != null)
            {
                if (field == null || string.IsNullOrEmpty(field.UnitSearchFieldAlias) || !field.UnitLayoutSearchFieldId.HasValue)
                {
                    string oldFilter = dataView.RowFilter;
                    dataView.RowFilter = string.Format("Alias = '{0}'", AvrPivotGridFieldHelper.VirtualCountryFieldName);
                    if (dataView.Count > 0)
                    {
                        fieldAlias = AvrPivotGridFieldHelper.VirtualCountryFieldName;
                    }
                    dataView.RowFilter = oldFilter;
                }
                else
                {
                    fieldAlias = AvrPivotGridFieldHelper.CreateFieldName(field.UnitSearchFieldAlias, field.UnitLayoutSearchFieldId.Value);
                }
            }
            return fieldAlias;
        }

        internal static void BindComboBox(LookUpEdit combo, DataView dataView, string fieldAlias)
        {
            combo.DataBindings.Clear();

            combo.Properties.Columns.Clear();
            var info = new LookUpColumnInfo("Caption", EidssMessages.Get("colCaption", "Caption"),
                200, FormatType.None, "", true, HorzAlignment.Near);
            combo.Properties.Columns.AddRange(new[] {info});
            combo.Properties.PopupWidth = combo.Width;
            combo.Properties.NullText = string.Empty;

            combo.Properties.DataSource = dataView;
            combo.Properties.ValueMember = "Alias";
            combo.Properties.DisplayMember = "Caption";

            string oldSort = dataView.Sort;
            dataView.Sort = "Alias";
            if (!Utils.IsEmpty(fieldAlias))
            {
                int index = dataView.Find(fieldAlias);
                if (index != -1)
                {
                    combo.EditValue = dataView[index]["Alias"];
                    return;
                }
            }
            if (!string.IsNullOrEmpty(oldSort))
            {
                dataView.Sort = oldSort;
            }
            combo.EditValue = (dataView.Count > 0)
                ? dataView[0]["Alias"]
                : DBNull.Value;
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