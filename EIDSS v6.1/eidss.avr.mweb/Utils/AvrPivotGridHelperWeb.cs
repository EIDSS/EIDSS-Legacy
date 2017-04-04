using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.ASPxPivotGrid.Data;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace eidss.avr.mweb.Utils
{
    public class AvrPivotGridHelperWeb : IAvrBasePivotGridView
    {
        //private PivotGridCells m_Cells;
        private readonly PivotGridFieldCollectionBase m_BaseFields;
        private readonly List<IAvrPivotGridField> m_DataAreaFields;
        private readonly List<IAvrPivotGridField> m_ColumnAreaFields;
        private readonly List<IAvrPivotGridField> m_RowAreaFields;

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
            var fields = RowAreaFields;
            fields.AddRange(ColumnAreaFields);
            GenderField = AvrPivotGridHelper.GetGenderField(fields);
            AgeGroupField = AvrPivotGridHelper.GetAgeGroupField(fields);

            PivotWebData = pivotGrid.Data;

            WebPivotGrid = pivotGrid;
        }

        public bool LayoutRestoring { get; set; }

        public IAvrPivotGridField GenderField { get; private set; }

        public IAvrPivotGridField AgeGroupField { get; private set; }

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

        public bool SingleSearchObject { get; set; }

        public DisplayTextHandler DisplayTextHandler { get; set; }

        public PivotGridViewInfoData PivotData { get; set; }

        public PivotGridWebData PivotWebData { get; set; }

        public ASPxPivotGrid WebPivotGrid { get; set; }
    }
}