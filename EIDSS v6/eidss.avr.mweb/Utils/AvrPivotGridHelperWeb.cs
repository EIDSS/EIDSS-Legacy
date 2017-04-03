using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DevExpress.Data.Filtering;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.ASPxPivotGrid.Data;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace eidss.avr.mweb.Utils
{
    public class AvrPivotGridHelperWeb : IAvrPivotGridView
    {
        //private PivotGridCells m_Cells;
        private readonly PivotGridFieldCollectionBase m_BaseFields;
        private readonly List<IAvrPivotGridField> m_DataAreaFields;
        private readonly List<IAvrPivotGridField> m_ColumnAreaFields;
        private readonly List<IAvrPivotGridField> m_RowAreaFields;
        public event EventHandler<CommandEventArgs> SendCommand;

        public AvrPivotGridHelperWeb(ASPxPivotGrid pivotGrid)
        {
            DisplayTextHandler = new DisplayTextHandler();
            m_BaseFields = pivotGrid.Fields;

            m_DataAreaFields = new List<IAvrPivotGridField>();
            foreach (PivotGridField field in pivotGrid.GetFieldsByArea(PivotArea.DataArea))
            {
                //todo: change this initialization
                if (field is IAvrPivotGridField)
                {
                    m_DataAreaFields.Add((IAvrPivotGridField) field);
                }
            }

            m_ColumnAreaFields = new List<IAvrPivotGridField>();
            foreach (PivotGridField field in pivotGrid.GetFieldsByArea(PivotArea.ColumnArea))
            {
                //todo: change this initialization
                if (field is IAvrPivotGridField)
                {
                    m_ColumnAreaFields.Add((IAvrPivotGridField) field);
                }
            }

            m_RowAreaFields = new List<IAvrPivotGridField>();
            foreach (PivotGridField field in pivotGrid.GetFieldsByArea(PivotArea.RowArea))
            {
                //todo: change this initialization
                if (field is IAvrPivotGridField)
                {
                    m_RowAreaFields.Add((IAvrPivotGridField) field);
                }
            }

            DataSource = new AvrPivotGridData(pivotGrid.DataSource as DataTable);

            PivotWebData = pivotGrid.Data;

            WebPivotGrid = pivotGrid;
        }

        public bool LayoutRestoring { get; set; }

        public IAvrPivotGridField GenderField { get; set; }

        public IAvrPivotGridField AgeGroupField { get; set; }

        public PivotGridFieldCollectionBase BaseFields
        {
            get { return m_BaseFields; }
        }

        public List<IAvrPivotGridField> DataAreaFields
        {
            get { return m_DataAreaFields; }
        }

        public List<IAvrPivotGridField> ColumnAreaFields
        {
            get { return m_ColumnAreaFields; }
        }

        public List<IAvrPivotGridField> RowAreaFields
        {
            get { return m_RowAreaFields; }
        }

        public void ClearCacheDataRowColumnAreaFields()
        {
            throw new NotImplementedException(
                "There is no need to re-create list of data, column, or row areafields on the web because it's automatically recreated each postback");
        }

        public CriteriaOperator Criteria { get; set; }

        public string CriteriaString { get; set; }

        public DisplayTextHandler DisplayTextHandler { get; set; }

        public PivotGridCells Cells
        {
            get { return null /*m_Cells*/; }
        }

        public PivotGridViewInfoData PivotData { get; set; }

        public PivotGridWebData PivotWebData { get; set; }

        public AvrPivotGridData DataSource { get; set; } //probably no need

        public void SetDataSourceAndCreateFields(DataTable value)
        {
            DataSource = new AvrPivotGridData(value);
        }

        public Dictionary<string, CustomSummaryType> NameSummaryTypeDictionary { get; set; }

        public ASPxPivotGrid WebPivotGrid { get; set; }

        public void RestoreLayoutFromStream(Stream stream)
        {
        }

        public void SaveLayoutToStream(Stream stream)
        {
        }

        public IDisposable BeginTransaction()
        {
            throw new NotImplementedException();
        }
    }
}