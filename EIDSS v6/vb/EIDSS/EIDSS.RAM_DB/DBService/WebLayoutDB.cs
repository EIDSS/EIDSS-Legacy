using System;
using System.Data;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.Model.Core;
using eidss.avr.db.DBService.DataSource;
using eidss.model.AVR.Db;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.DBService
{
    public class WebLayoutDB : Layout_DB
    {
        public long m_QueryID = -1;

        public long FolderID { get; set; }

        public AvrTreeElement layout { get; set; }

        public WebLayoutDB()
        {
        }

        protected override void PrepareLayoutBeforePost(LayoutDetailDataSet.LayoutDataTable layoutTable)
        {
            var layoutRow = (LayoutDetailDataSet.LayoutRow)layoutTable.Rows[0];

            if (m_IsNewObject)
            {
                if (FolderID < 0)
                {
                    layoutRow.SetidflLayoutFolderNull();
                }
                else
                {
                    layoutRow.idflLayoutFolder = FolderID;
                }
            }

            if (!layoutRow.IsstrPivotGridSettingsNull())
            {
                layoutRow.blbPivotGridSettings = BinaryCompressor.ZipString(layoutRow.strPivotGridSettings);
            }

            if (layout != null)
            {
                layoutRow.strDefaultLayoutName = layout.DefaultName;
                layoutRow.strDescription = layout.Description;
                layoutRow.strLayoutName = layout.NationalName;
            }

            m_IsNewObject = false;
        }

        public void PostLayoutWebInDB(IDbTransaction transaction, DataSet dataSet)
        {
            if (m_QueryID < 0)
            {
                throw new AvrDbException("Query ID is not set when Layout Post");
            }

            LayoutDetailDataSet.LayoutSearchFieldDataTable layoutSearchFieldData;
            LayoutDetailDataSet.LayoutDataTable layoutTable = GetLayoutTableFromDataSet(dataSet, out layoutSearchFieldData);

            PrepareLayoutBeforePost(layoutTable);

            var layoutRow = (LayoutDetailDataSet.LayoutRow)layoutTable.Rows[0];

            using (IDbCommand cmd = CreateSPCommand("spAsLayoutPost", transaction))
            {
                AddCommandParams(cmd, layoutTable, layoutRow);
                //cmd.ExecuteNonQuery();
                ExecCommand(cmd, cmd.Connection, transaction);
            }

            LookupCache.NotifyChange("Layout", transaction, ID);
        }

        private void AddCommandParams
            (IDbCommand cmd,
                LayoutDetailDataSet.LayoutDataTable layoutTable,
                LayoutDetailDataSet.LayoutRow layoutRow)
        {
            Utils.CheckNotNull(cmd, "cmd");
            Utils.CheckNotNull(layoutTable, "layoutTable");
            Utils.CheckNotNull(layoutRow, "layoutRow");

            AddAndCheckParam(cmd, "@strLanguage", ModelUserContext.CurrentLanguage);
            AddAndCheckParam(cmd, layoutTable.blnApplyPivotGridFilterColumn, layoutRow.blnApplyPivotGridFilter ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnReadOnlyColumn, layoutRow.blnReadOnly ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShareLayoutColumn, layoutRow.blnShareLayout ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowColGrandTotalsColumn, layoutRow.blnShowColGrandTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowColsTotalsColumn, layoutRow.blnShowColsTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowForSingleTotalsColumn, layoutRow.blnShowForSingleTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowRowGrandTotalsColumn, layoutRow.blnShowRowGrandTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnShowRowsTotalsColumn, layoutRow.blnShowRowsTotals ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.idflLayoutColumn, layoutRow.idflLayout);
            AddAndCheckParam(cmd, layoutTable.idflLayoutFolderColumn,
                layoutRow.IsidflLayoutFolderNull() ? DBNull.Value : (object)layoutRow.idflLayoutFolder);
            //AddAndCheckParam(cmd, layoutTable.idflMapNameColumn, layoutRow.idflMapName);
            AddAndCheckParam(cmd, layoutTable.idflDescriptionColumn, layoutRow.idflDescription);
            AddAndCheckParam(cmd, layoutTable.idflQueryColumn, m_QueryID);
            AddAndCheckParam(cmd, layoutTable.idfsDefaultGroupDateColumn, layoutRow.idfsDefaultGroupDate);

            EidssUserContext.CheckUserLoggedIn();
            layoutRow.idfPerson = (long) EidssUserContext.User.EmployeeID;
            AddAndCheckParam(cmd, layoutTable.idfPersonColumn, layoutRow.idfPerson);

            AddAndCheckParam(cmd, layoutTable.blbPivotGridSettingsColumn, layoutRow.blbPivotGridSettings);
            AddAndCheckParam(cmd, layoutTable.strDefaultLayoutNameColumn, layoutRow.strDefaultLayoutName);
            AddAndCheckParam(cmd, layoutTable.strDescriptionColumn, layoutRow.strDescription);
            AddAndCheckParam(cmd, layoutTable.strLayoutNameColumn, layoutRow.strLayoutName);

            AddAndCheckParam(cmd, layoutTable.blnShowMissedValuesInPivotGridColumn, layoutRow.blnShowMissedValuesInPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.intPivotGridXmlVersionColumn, (int)PivotGridXmlVersion.Version6);
            AddAndCheckParam(cmd, layoutTable.blnCompactPivotGridColumn, layoutRow.blnCompactPivotGrid ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnFreezeRowHeadersColumn, layoutRow.blnFreezeRowHeaders ? 1 : 0);
            AddAndCheckParam(cmd, layoutTable.blnUseArchivedDataColumn, layoutRow.blnUseArchivedData ? 1 : 0);
        }

        private static LayoutDetailDataSet.LayoutDataTable GetLayoutTableFromDataSet
            (DataSet dataSet, out LayoutDetailDataSet.LayoutSearchFieldDataTable searchFieldData)
        {
            Utils.CheckNotNull(dataSet, "dataSet");
            if (!(dataSet is LayoutDetailDataSet))
            {
                throw new ArgumentException(string.Format("dataset must be of type {0}", typeof(LayoutDetailDataSet)));
            }
            var layoutDataSet = (LayoutDetailDataSet)dataSet;
            LayoutDetailDataSet.LayoutDataTable layoutTable = layoutDataSet.Layout;
            if (layoutTable.Count == 0)
            {
                throw new AvrDbException("Table Layout doesn't contains any row");
            }
            searchFieldData = layoutDataSet.LayoutSearchField;
            return layoutTable;
        }
    }
}