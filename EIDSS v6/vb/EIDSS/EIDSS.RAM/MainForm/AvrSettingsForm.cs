using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Objects;
using bv.common.Resources;
using bv.common.win;
using bv.winclient.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS;
using eidss.avr.db.DBService;
using EIDSS.Core;
using eidss.model.Enums;
using BaseReferenceType = bv.common.db.BaseReferenceType;

namespace eidss.avr.MainForm
{
    public partial class AvrSettingsForm : BaseDetailList
    {
        private AvrSettings_DB m_AvrSettingsDbService;

        public AvrSettingsForm()
        {
            InitializeComponent();
            m_AvrSettingsDbService = new AvrSettings_DB();
            DbService = m_AvrSettingsDbService;
            AuditObject = new AuditObject((long) EIDSSAuditObject.daoAvrSetting, (long) AuditTable.tasSearchFieldList);
            PermissionObject = EIDSSPermissionObject.AccessToAVRAdministration;
            PrecisionView.FocusedRowChanged += FocusedRowChanged;
            FunctionsView.FocusedRowChanged += FocusedRowChanged;
        }

        private void FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView != null)
            {
                if (e.PrevFocusedRowHandle != GridControl.InvalidRowHandle)
                {
                    if (((gridView == PrecisionView) && !IsPrecisionRowValid(e.PrevFocusedRowHandle))
                        || ((gridView == FunctionsView) && !IsFunctionRowValid(e.PrevFocusedRowHandle, true)))
                    {
                        gridView.FocusedRowHandle = e.PrevFocusedRowHandle;
                    }
                }
            }
        }

        private DataView m_SearchFieldsView;

        protected override void DefineBinding()
        {
            LookupBinder.BindBaseLookup(cbSearchObject, baseDataSet,
                AvrSettings_DB.TableSearchObject + ".idfsSearchObject",
                BaseReferenceType.rftSearchObject, false);
            m_SearchFieldsView = new DataView(baseDataSet.Tables[AvrSettings_DB.TableSearchField]);
            FunctionsGrid.DataSource = m_SearchFieldsView;
            PrecisionGrid.DataSource = baseDataSet.Tables[AvrSettings_DB.TablePrecision];
            LookupBinder.BindBaseRepositoryLookup(cbFunction, BaseReferenceType.rftAggregateFunction, false);
            var view = (DataView)cbFunction.DataSource;
            
            //LookupBinder.RemoveEmptyRow(view);

            // note [Ivan]: I know, tha it's not good idea to get another lokup for filtering original one
            // but i don't want to touch binding before GAT
            DataView aggrView = LookupCache.Get(LookupTables.AggregateFunction.ToString());
            aggrView.RowFilter = "blnPivotGridFunction=1 ";
            var idList = new List<object>();
            foreach (DataRowView row in aggrView)
            {
                idList.Add(row["idfAggregateFunction"]);
            }
            for (int i = view.Count - 1; i >= 0; i--)
            {
                if (!idList.Contains(view[i]["idfsReference"]))
                {
                    view[i].Delete();
                }
            }

            eventManager.AttachDataHandler(AvrSettings_DB.TableSearchObject + ".idfsSearchObject", SearchObjectChanged);
            eventManager.Cascade(AvrSettings_DB.TableSearchObject + ".idfsSearchObject");
            cbSearchObject.EditValueChanging += SearchObjectChanging;
        }

        private void SearchObjectChanging(object sender, ChangingEventArgs e)
        {
            if (!ValidateFunctionsView())
            {
                e.Cancel = true;
            }
        }

        private void SearchObjectChanged(object sender, DataFieldChangeEventArgs e)
        {
            object searchObject;
            if (e.Value == DBNull.Value)
            {
                searchObject = 0;
            }
            else
            {
                searchObject = e.Value;
            }

            m_SearchFieldsView.RowFilter = string.Format("idfsSearchObject = {0}", searchObject);
        }

        public override bool ValidateData()
        {
            return ValidateFunctionsView() && ValidatePrecisionView();
        }

        private bool ValidatePrecisionView()
        {
            for (int i = 0; i < PrecisionView.DataRowCount; i++)
            {
                if (!IsPrecisionRowValid(i))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateFunctionsView()
        {
            for (int i = 0; i < FunctionsView.DataRowCount; i++)
            {
                if (!IsFunctionRowValid(i, true))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsPrecisionRowValid(int rowHandle = -1, bool showError = true)
        {
            return ValidateMandatoryCell(rowHandle, colPrecision, showError);
        }

        private bool IsFunctionRowValid(int rowHandle, bool showError)
        {
            return ValidateMandatoryCell(rowHandle, colFunction, showError);
        }

        private bool ValidateMandatoryCell(int rowHandle, GridColumn col, bool showError)
        {
            DataRow row = (rowHandle >= 0) ? col.View.GetDataRow(rowHandle) : col.View.GetFocusedDataRow();
            if (row != null && Utils.IsEmpty(row[col.FieldName]))
            {
                if (showError)
                {
                    col.View.FocusedRowHandle = rowHandle;
                    col.View.FocusedColumn = col;
                    BringUpCurrentTab(col.View.GridControl);
                    string msg = string.Format(BvMessages.Get("ErrMandatoryFieldRequired"), col.Caption);
                    ErrorForm.ShowWarningDirect(msg);
                    col.View.ShowEditor();
                }
                return false;
            }
            return true;
        }

        public override bool HasChanges()
        {
            baseDataSet.Tables[AvrSettings_DB.TableSearchObject].AcceptChanges();
            return base.HasChanges();
        }
    }
}