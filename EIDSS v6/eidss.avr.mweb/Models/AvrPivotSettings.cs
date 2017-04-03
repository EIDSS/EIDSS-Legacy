using System.Collections.Generic;
using System.Data;
using System.Linq;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Utils;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Pivot;

namespace eidss.avr.mweb.Models
{
    public class AvrPivotSettings
    {
        public AvrPivotSettings(long queryId, long layoutId)
        {
            LayoutId = layoutId;
            QueryId = queryId;
            HasChanges = false;
        }
        public long LayoutId { get; set; }
        public long QueryId { get; set; }
        public bool HasChanges { get; set; }
        public WebPivotGridField SelectedField { get; set; }
        public WebPivotGridField UpdatedField { get; set; }
        public bool CanDeleteSelectedField()
        {
            return AvrPivotGridHelper.EnableDeleteField(SelectedField, Fields);
        }

        public Dictionary<string, WebPivotGridField> FieldsDictionary { get; set; }
        private List<WebPivotGridField> m_Fields;
        public void AddField(WebPivotGridField field)
        {
            Fields.Add(field);
            FieldsDictionary.Add(field.FieldName, field);
            
        }
        public void DeleteField(WebPivotGridField field)
        {
            
            FieldsDictionary.Remove(field.FieldName);
            Fields.Remove(field);
        }

        public List<WebPivotGridField> Fields
        {
            get { return m_Fields ?? (m_Fields = new List<WebPivotGridField>()); }
            set
            {
                m_Fields = value;
                if (FieldsDictionary == null)
                    FieldsDictionary = new Dictionary<string, WebPivotGridField>();
                else
                    FieldsDictionary.Clear();
                if (m_Fields != null)
                {
                    foreach (var field in m_Fields)
                    {
                        FieldsDictionary.Add(field.FieldName, field);
                    }
                }
            }
        }
        public long DefaultGroupInterval { get; set; }
        public bool UpdateGroupInterval { get; set; }
        
        public bool ShowColumnTotals { get; set; }
        public bool ShowColumnGrandTotals { get; set; }
        public bool ShowRowTotals { get; set; }
        public bool ShowRowGrandTotals { get; set; }
        public bool ShowTotalsForSingleValues { get; set; }
        public bool ShowDataInPivot { get; set; }
        public bool ApplyFilter { get; set; }
        public string FilterCriteriaString { get; set; }

        public bool ShowMissedValues { get; set; }
        public bool ShowMissedValuesSaved { get; set; }
        public bool CompactLayout { get; set; }
        public bool FreezeRowHeaders { get; set; }
        public bool UseArchiveData { get; set; }
        public bool IsPublished { get; set; }
        public LayoutDetailDataSet LayoutDataset { get; set; }
        public Dictionary<long, string> Intervals { get; set; }
        public DataView AggregateFuncions { get; set; }
        public static bool IsPopulationAggregateFunction(IAvrPivotGridField field)
        {
            return field != null && (field.AggregateFunctionId == (long)CustomSummaryType.Pop10000 ||
                                             field.AggregateFunctionId == (long)CustomSummaryType.Pop100000 ||
                                             field.AggregateFunctionId == (long)CustomSummaryType.PopGender100000);
        }

        public static bool IsGenderAggregateFunction(IAvrPivotGridField field)
        {
            return field != null && (field.AggregateFunctionId == (long)CustomSummaryType.PopGender100000);
        }
        public bool IsPopulationAggregateFunction()
        {
            return IsPopulationAggregateFunction(SelectedField);
        }

        public bool IsGenderAggregateFunction()
        {
            return IsGenderAggregateFunction(SelectedField);
        }

    }
}
