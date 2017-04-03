using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.common.Core;
using bv.common.db.Core;
using eidss.model.Resources;

namespace EIDSS.RAM.Presenters
{
    public class SharedPresenter : IDisposable
    {
        private readonly SharedModel m_SharedModel;
        private readonly IContextKeeper m_ContextKeeper;
        private readonly Dictionary<IView, BaseRamPresenter> m_ChildPresenters;
        public const string VirtualCountryFieldName = "sflVirtualCountry_idfLayoutSearchField_-1";

        public SharedPresenter(IPostable parentForm)
        {
            Utils.CheckNotNull(parentForm, "parentForm");

            m_SharedModel = new SharedModel(parentForm);
            m_ContextKeeper = new ContextKeeper();
            m_ChildPresenters = new Dictionary<IView, BaseRamPresenter>();
        }

        public IContextKeeper ContextKeeper
        {
            get { return m_ContextKeeper; }
        }

        public SharedModel SharedModel
        {
            get { return m_SharedModel; }
        }

        public bool IsQueryResultNull
        {
            get { return SharedModel.QueryResult == null; }
        }

        public BaseRamPresenter this[IView view]
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

        public void UnregisterView(IView view)
        {
            Utils.CheckNotNull(view, "view");
            if (m_ChildPresenters.ContainsKey(view))
            {
                m_ChildPresenters.Remove(view);
            }
        }

      
       

        public DataTable GetQueryResultClone()
        {
            if (IsQueryResultNull)
            {
                throw new InvalidOperationException("Canot create copy of QueryResult because it is null");
            }
            return SharedModel.QueryResult.Clone();
        }

        public DataTable GetQueryResultCopy()
        {
            if (IsQueryResultNull)
            {
                throw new InvalidOperationException("Canot create copy of QueryResult because it is null");
            }
            //return SharedModel.QueryResult.Copy();
            if (SharedModel.TableCopier == null)
            {
                throw new RamException("SharedModel.TableCopier is not initialized");
            }
            
            return SharedModel.TableCopier.GetCopy();
        }

        public void BindDenominatorComboBox(ComboBoxEventArgs e)
        {
            LookUpEdit cbDenominator = e.ComboBox;
            LayoutDetailDataSet.AggregateRow selectedRow = e.SelectedRow;
            DataView dataView = SharedModel.GetDenominatorDataView();

            string fieldAlias;
            if ((selectedRow == null) ||
                (selectedRow.IsidfDenominatorQuerySearchFieldNull()) ||
                (selectedRow.IsDenominatorSearchFieldAliasNull()))
            {
                fieldAlias = null;
            }
            else
            {
                fieldAlias = RamPivotGridHelper.CreateFieldName(selectedRow.DenominatorSearchFieldAlias,
                                                                selectedRow.idfDenominatorQuerySearchField);
            }
            BindComboBox(cbDenominator, dataView, fieldAlias);
        }

        public void BindAdmUnitComboBox(ComboBoxEventArgs e)
        {
            LookUpEdit cbAdmUnit = e.ComboBox;
            LayoutDetailDataSet.AggregateRow selectedRow = e.SelectedRow;
            DataView dataView = SharedModel.GetAvailableMapFieldView(e.IsMap);

            var fieldAlias = GetSelectedAdmFieldAlias(dataView, selectedRow);

            BindComboBox(cbAdmUnit, dataView, fieldAlias);
        }

        public static string GetSelectedAdmFieldAlias(DataView dataView, LayoutDetailDataSet.AggregateRow selectedRow)
        {
            string fieldAlias = null;
            if (dataView != null)
            {
                if (selectedRow == null || selectedRow.IsidfUnitQuerySearchFieldNull() || selectedRow.IsUnitSearchFieldAliasNull())
                {
                    
                    string oldFilter = dataView.RowFilter;
                    dataView.RowFilter = string.Format("Alias = '{0}'", VirtualCountryFieldName);
                    if (dataView.Count > 0)
                    {
                        fieldAlias = VirtualCountryFieldName;
                    }
                    dataView.RowFilter = oldFilter;
                }
                else
                {
                    fieldAlias = RamPivotGridHelper.CreateFieldName(selectedRow.UnitSearchFieldAlias, selectedRow.idfUnitQuerySearchField);
                }
            }
            return fieldAlias;
        }

        public static string GetSelectedDateFieldAlias(LayoutDetailDataSet.AggregateRow selectedRow)
        {
            string dateFullFieldName = (selectedRow == null) || (selectedRow.IsidfDateQuerySearchFieldNull() ||
                                                                 selectedRow.IsDateSearchFieldAliasNull())
                                           ? null
                                           : RamPivotGridHelper.CreateFieldName(selectedRow.DateSearchFieldAlias,
                                                                                selectedRow.idfDateQuerySearchField);
            return dateFullFieldName;
        }

      

        public void BindStatDateComboBox(ComboBoxEventArgs e)
        {
            LookUpEdit cbStatDate = e.ComboBox;
            LayoutDetailDataSet.AggregateRow selectedRow = e.SelectedRow;
            DataView dataView = SharedModel.GetStatDateDataView();

            string fieldAlias = GetSelectedDateFieldAlias(selectedRow);
            BindComboBox(cbStatDate, dataView, fieldAlias);
        }

        private static void BindComboBox(LookUpEdit combo, DataView dataView, string fieldAlias)
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

        internal static void SetBlackLookAndFeel(Control control)
        {
            PropertyInfo propertyInfo = control.GetType().GetProperty("LookAndFeel");
            if (propertyInfo != null)
            {
                object value = propertyInfo.GetValue(control, null);
                var lookAndFeel = value as UserLookAndFeel;
                if (lookAndFeel != null)
                {
                    lookAndFeel.UseDefaultLookAndFeel = false;
                    lookAndFeel.UseWindowsXPTheme = false;
                    lookAndFeel.SetStyle(LookAndFeelStyle.Skin, false, false, "Black");
                }
            }
            foreach (Control child in control.Controls)
            {
                SetBlackLookAndFeel(child);
            }
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

        private void RegisterPresenterFor(IView view)
        {
            BaseRamPresenter ramPresenter;
            if (view is IMapView)
            {
                ramPresenter = new MapPresenter(this, view as IMapView);
            }
            else if (view is IChartView)
            {
                ramPresenter = new ChartPresenter(this, view as IChartView);
            }
            else if (view is IPivotView)
            {
                ramPresenter = new PivotPresenter(this, view as IPivotView);
            }
            else if (view is ILayoutInfoView)
            {
                ramPresenter = new LayoutInfoPresenter(this, view as ILayoutInfoView);
            }
            else if (view is IQueryInfoView)
            {
                ramPresenter = new QueryInfoPresenter(this, view as IQueryInfoView);
            }
            else if (view is ILayoutDetailView)
            {
                ramPresenter = new LayoutDetailPresenter(this, view as ILayoutDetailView);
            }
            else if (view is IRamPivotGridView)
            {
                ramPresenter = new RamPivotGridPresenter(this, view as IRamPivotGridView);
            }
            else if (view is IRamFormView)
            {
                ramPresenter = new RamFormPresenter(this, view as IRamFormView);
            }
            else if (view is IPivotReportView)
            {
                ramPresenter = new PivotReportPresenter(this, view as IPivotReportView);
            }
            else
            {
                throw new NotSupportedException(string.Format("Not supported view {0}", view));
            }

            view.SendCommand += View_SendCommand;
            m_ChildPresenters.Add(view, ramPresenter);
        }

        private void View_SendCommand(object sender, CommandEventArgs e)
        {
            Utils.CheckNotNull(e, "e");
            Utils.CheckNotNull(e.Command, "e.Command");

            foreach (BaseRamPresenter value in m_ChildPresenters.Values)
            {
                value.Process(e.Command);
            }
        }

        public void Dispose()
        {
            m_ChildPresenters.Clear();
            m_SharedModel.Dispose();
        }
    }
}