using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using bv.common.Core;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using EIDSS.RAM.Components.DataTransactions;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM_DB.Components;
using bv.common.db.Core;
using ReflectionHelper = EIDSS.RAM_DB.Common.ReflectionHelper;

namespace EIDSS.RAM.Components
{
    public partial class RamPivotReportGrid : XRPivotGrid
    {
        private readonly IDataTransactionStrategy m_DataTransactionStrategy;

        public RamPivotReportGrid()
        {
            InitializeComponent();
            m_DataTransactionStrategy = new DataTransactionStrategy();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Clear();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        internal void Clear()
        {
            using (BeginTransaction())
            {
                Fields.ClearAndDispose();
                DataSource = null;
            }
        }

        internal void CreateReportGridFrom(RamPivotGrid sourceGrid)
        {
            Utils.CheckNotNull(sourceGrid, "sourceGrid");

            using (BeginTransaction())
            {
                DataSource = null;
                Fields.Clear();

                var fieldList = new List<XRPivotGridField>();
                try
                {
                    foreach (WinPivotGridField field in sourceGrid.RamFields)
                    {
                        fieldList.Add(field);
                        WinPivotGridField newField = ReflectionHelper.CreateAndCopyProperties(field);
                        Fields.Add(newField);
                    }
                    // datasource of report is set equal to datasource of pivot while copy properties
                    ReflectionHelper.CopyCommonProperties(sourceGrid, this, new List<string> {"Width", "Height", "Size"});
                    
                    CopyWidth(sourceGrid);

                    OptionsView.RowTotalsLocation = DevExpress.XtraPivotGrid.PivotRowTotalsLocation.Far;

                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsView, OptionsView, new List<string> { "TotalsLocation" });
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsData, OptionsData);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsDataField, OptionsDataField);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsLayout, OptionsLayout);
                    ReflectionHelper.CopyCommonProperties(sourceGrid.OptionsPrint, OptionsPrint);
                }
                catch (Exception ex)
                {
                    throw new RamException("Cannot import source from pivotGrid to report", ex);
                }

                Prefilter.CriteriaString = sourceGrid.CriteriaString;
                Appearance.Cell.TextOptions.HAlignment = HorzAlignment.Near;
                fieldList.Sort((x, y) => Comparer<int>.Default.Compare(x.AreaIndex, y.AreaIndex));
                foreach (XRPivotGridField field in fieldList)
                {
                    XRPivotGridField reportField = Fields[field.FieldName];
                    reportField.AreaIndex = field.AreaIndex;
                }
            }
        }

        

        private void CopyWidth(RamPivotGrid sourceGrid)
        {
            int width = sourceGrid.RowAreaFields.Sum(field => field.Width) +
                        sourceGrid.DataAreaFields.Sum(field => field.Width);
            if(width <  2*sourceGrid.Fields.DefaultFieldWidth)
            {
                width = 2 * sourceGrid.Fields.DefaultFieldWidth;
            }
            Width = width;
        }

        internal DataTransaction BeginTransaction()
        {
            return m_DataTransactionStrategy.BeginTransaction(Data);
        }

       
    }
}