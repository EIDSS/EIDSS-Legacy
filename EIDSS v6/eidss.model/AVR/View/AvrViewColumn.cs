using System;
using System.Data;
using System.Linq;
using System.Xml.Serialization;
using bv.common.Core;

namespace eidss.model.Avr.View
{
    [Serializable]
    public class AvrViewColumn : IAvrViewItem
    {
        private long m_ID;
        [XmlIgnore] private long m_ViewID;
        private long? m_GisReferenceTypeID;
        private long? m_AggregateFunction;
        private bool m_ChartSeries;
        private bool m_MapDiagramSeries;
        private bool m_MapGradientSeries;
        private string m_SourceViewColumn;
        private string m_DenominatorViewColumn;
        private string m_PrecisionString;

        private string m_DisplayText;
        private string m_DisplayNamePivot;

        private bool m_Aggregate;
        private bool m_Visible;
        private bool m_Freeze;
        private int? m_SortOrder;
        private bool m_SortAscending;
        private int m_Order;
        private string m_ColumnFilter;
        private int m_ColumnWidth;

        private bool m_IsChanged;
        private bool m_ToDelete;
        [XmlIgnore] private Type m_FieldType;

        #region Constructors

        public AvrViewColumn()
            : this(-1, string.Empty, string.Empty, AvrView.DefaultFieldWidth)
        {
        }

        public AvrViewColumn(long searchFieldId, string searchFieldName, string displayText, int columnWidth, int? precision = null)
        {
            LayoutSearchFieldId = searchFieldId;
            LayoutSearchFieldName = searchFieldName;
            m_DisplayText = displayText;
            ColumnWidth = columnWidth;
            Precision = precision;

            m_ID = -1;
            m_Visible = true;
            m_IsChanged = false;
            m_ToDelete = false;
            m_SortAscending = true;
            FieldType = typeof (string);
        }

        // this constructor creates object from database
        public AvrViewColumn(DataRow row)
        {
            m_ID = (long) row["idfViewColumn"];
            m_ViewID = (long) row["idfView"];
            UniquePath = (string) row["UniquePath"];
            OriginalName = (string) row["strOriginalName"];
            object ids = row["idfLayoutSearchField"];
            if (!Utils.IsEmpty(ids))
            {
                LayoutSearchFieldId = (long) ids;
            }
            ids = row["strDisplayName"];
            if (!Utils.IsEmpty(ids))
            {
                m_DisplayText = (string) ids;
            }
            m_Aggregate = (bool) row["blnAggregateColumn"];
            ids = row["idfsAggregateFunction"];
            if (!Utils.IsEmpty(ids))
            {
                m_AggregateFunction = (long?) ids;
            }
            ids = row["intPrecision"];
            if (!Utils.IsEmpty(ids))
            {
                Precision = (int?) ids;
            }
            m_ChartSeries = (bool) row["blnChartSeries"];
            m_MapDiagramSeries = (bool) row["blnMapDiagramSeries"];
            m_MapGradientSeries = (bool) row["blnMapGradientSeries"];
            ids = row["SourceViewColumn"];
            if (!Utils.IsEmpty(ids))
            {
                m_SourceViewColumn = (string) ids;
            }
            ids = row["DenominatorViewColumn"];
            if (!Utils.IsEmpty(ids))
            {
                m_DenominatorViewColumn = (string) ids;
            }
            m_Visible = (bool) row["blnVisible"];
            m_Freeze = (bool) row["blnFreeze"];
            ids = row["intSortOrder"];
            if (!Utils.IsEmpty(ids))
            {
                m_SortOrder = (int?) ids;
            }
            m_SortAscending = (bool) row["blnSortAscending"];
            ids = row["intOrder"];
            if (!Utils.IsEmpty(ids))
            {
                m_Order = (int) ids;
            }
            else
            {
                m_Order = 0;
            }
            ids = row["strColumnFilter"];
            if (!Utils.IsEmpty(ids))
            {
                m_ColumnFilter = (string) ids;
            }
            ids = row["intColumnWidth"];
            if (!Utils.IsEmpty(ids))
            {
                m_ColumnWidth = (int) ids;
            }
            m_IsChanged = false;
            m_ToDelete = false;
        }

        #endregion

        #region Properties

        public long ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        [XmlIgnore]
        public long ViewID
        {
            get { return m_ViewID; }
            set { m_ViewID = value; }
        }

        [XmlIgnore]
        public BaseBand Owner { get; set; }
        
        public long? GisReferenceTypeId
        {
            get { return m_GisReferenceTypeID; }
            set { m_GisReferenceTypeID = value; }
        }
        public long LayoutSearchFieldId { get; set; }

        public string LayoutSearchFieldName { get; set; }

        [XmlIgnore]
        public Type FieldType
        {
            get { return m_FieldType; }
            set
            {
                m_FieldType = value;
                FieldTypeName = value.AssemblyQualifiedName;
            }
        }

        public string FieldTypeName
        {
            get
            {
                return FieldType == null
                    ? null
                    : FieldType.AssemblyQualifiedName;
            }
            set { m_FieldType = Type.GetType(value); }
        }

        public string UniquePath { get; set; }

        [XmlIgnore]
        public string OriginalName
        {
            get { return m_DisplayNamePivot; }
            set
            {
                if (m_DisplayNamePivot != value)
                {
                    m_DisplayNamePivot = value;
                }
            }
        }

        public string DisplayText
        {
            get { return m_DisplayText; }
            set
            {
                if (m_DisplayText != value)
                {
                    SetChanges();
                    m_DisplayText = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsAggregate
        {
            get { return m_Aggregate; }
            set
            {
                if (m_Aggregate != value)
                {
                    SetChanges();
                    m_Aggregate = value;
                }
            }
        }

        [XmlIgnore]
        public long? AggregateFunction
        {
            get { return m_AggregateFunction; }
            set
            {
                if (m_AggregateFunction != value)
                {
                    SetChanges();
                    m_AggregateFunction = value;
                }
            }
        }

        public int? Precision { get; set; }

        public int? SetPrecision
        {
            set
            {
                if (Precision != value)
                {
                    SetChanges();
                    Precision = value;
                }
            }
        }

        [XmlIgnore]
        public string Precision_
        {
            get { return (Precision.HasValue && Precision.Value != -1) ? Precision.ToString() : string.Empty; }
        }

        [XmlIgnore]
        public string PrecisionStringWeb
        {
            get
            {
                if (m_PrecisionString == null)
                {
                    if (FieldType.IsNumeric() && Precision_.Length > 0)
                        m_PrecisionString = "N" + Precision_;
                    else
                        m_PrecisionString = Precision_;
                }
                return m_PrecisionString;
            }
            set { m_PrecisionString = value; }
        }

        [XmlIgnore]
        public bool IsChartSeries
        {
            get { return m_ChartSeries; }
            set
            {
                if (m_ChartSeries != value)
                {
                    SetChanges();
                    m_ChartSeries = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsMapDiagramSeries
        {
            get { return m_MapDiagramSeries; }
            set
            {
                if (m_MapDiagramSeries != value)
                {
                    SetChanges();
                    m_MapDiagramSeries = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsMapGradientSeries
        {
            get { return m_MapGradientSeries; }
            set
            {
                if (m_MapGradientSeries != value)
                {
                    SetChanges();
                    m_MapGradientSeries = value;
                }
            }
        }

        [XmlIgnore]
        public string SourceViewColumn
        {
            get { return m_SourceViewColumn; }
            set
            {
                if (m_SourceViewColumn != value)
                {
                    SetChanges();
                    m_SourceViewColumn = value;
                }
            }
        }

        [XmlIgnore]
        public string DenominatorViewColumn
        {
            get { return m_DenominatorViewColumn; }
            set
            {
                if (m_DenominatorViewColumn != value)
                {
                    SetChanges();
                    m_DenominatorViewColumn = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsVisible
        {
            get { return m_Visible; }
            set
            {
                if (m_Visible != value)
                {
                    SetChanges();
                    m_Visible = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsFreezed
        {
            get { return m_Freeze; }
            set
            {
                if (m_Freeze != value)
                {
                    SetChanges();
                    m_Freeze = value;
                }
            }
        }

        [XmlIgnore]
        public int? SortOrder
        {
            get { return m_SortOrder; }
            set
            {
                if (m_SortOrder != value && (m_SortOrder != null || value != -1))
                {
                    SetChanges();
                    m_SortOrder = value;
                }
            }
        }

        [XmlIgnore]
        public bool IsSortAscending
        {
            get { return m_SortAscending; }
            set
            {
                if (m_SortAscending != value)
                {
                    SetChanges();
                    m_SortAscending = value;
                }
            }
        }

        [XmlIgnore]
        public int Order
        {
            get { return m_Order; }
            set
            {
                if (m_Order != value)
                {
                    SetChanges();
                    m_Order = value;
                }
            }
        }

        [XmlIgnore]
        public int Order_Pivot { get; set; }

        // used only from web
        [XmlIgnore]
        public int? Order_Temp { get; set; }

        [XmlIgnore]
        public int Order_ForUse
        {
            get { return Order > 0 ? Order : Order_Pivot + 1000; }
        }

        [XmlIgnore]
        public bool IsOrderChanged { get; set; }

        [XmlIgnore]
        public string ColumnFilter
        {
            get { return m_ColumnFilter; }
            set
            {
                if (Utils.Str(m_ColumnFilter) != value)
                {
                    SetChanges();
                    m_ColumnFilter = value;
                }
            }
        }

        public int ColumnWidth
        {
            get { return m_ColumnWidth; }
            set
            {
                //SetChanges();
                m_ColumnWidth = value;
            }
        }

        [XmlIgnore]
        public int ColumnWidth_Pivot { get; set; }

        public bool IsRowArea { get; set; }

        public bool IsAdministrativeUnit { get; set; }

        [XmlIgnore]
        public int MapDisplayOrder { get; set; }

        public string FullPath { get; set; }

        // this property is used when asking if to save
        public bool IsChanged
        {
            get { return m_IsChanged | m_ToDelete | IsOrderChanged; }
        }

        // this property is used when saving
        public bool IsSelfChanged
        {
            get { return m_IsChanged | m_ToDelete | IsOrderChanged | m_ID <= 0 | (!IsAggregate && ColumnWidth != ColumnWidth_Pivot); }
        }

        #endregion

        #region Functions

        public void SetChanges()
        {
            m_IsChanged = true;
        }

        public void SetUnchanged()
        {
            m_IsChanged = false;
        }

        public void SavePivotSettings(int order, AvrViewColumn pivotCol)
        {
            Order_Pivot = order;
            m_DisplayNamePivot = pivotCol.DisplayText;
            IsRowArea = pivotCol.IsRowArea;
            IsAdministrativeUnit = pivotCol.IsAdministrativeUnit;
            Precision = pivotCol.Precision;
            ColumnWidth_Pivot = pivotCol.ColumnWidth;
            LayoutSearchFieldName = pivotCol.LayoutSearchFieldName;
            FieldType = pivotCol.FieldType;
            GisReferenceTypeId = pivotCol.GisReferenceTypeId;
        }

        public void ResetToPivot()
        {
            DisplayText = m_DisplayNamePivot;
            Order = 0;
            IsVisible = true;
            IsFreezed = false;
            SortOrder = null;
            IsSortAscending = true;
            ColumnFilter = "";
            ColumnWidth = ColumnWidth_Pivot;
        }

        public bool IsDiffFromPivot()
        {
            if (DisplayText != m_DisplayNamePivot)
            {
                return true;
            }
            if (Order != 0)
            {
                return true;
            }
            if (!IsVisible)
            {
                return true;
            }
            if (SortOrder != null)
            {
                return true;
            }
            if (!IsSortAscending)
            {
                return true;
            }
            if (!string.IsNullOrEmpty(ColumnFilter))
            {
                return true;
            }
            return false;
        }

        public bool IsToDelete
        {
            get { return m_ToDelete; }
        }

        public bool Delete()
        {
            if (m_ID <= 0)
            {
                return false;
            }
            m_ToDelete = true;
            return true;
        }

        public bool ExistsIn(string[] orNames)
        {
            return orNames.Any(t => UniquePath == t);
        }

        public void SetPivotVisible()
        {
            m_Visible = true;
        }

        public bool getRatio()
        {
            bool ratio = false;
            switch (AggregateFunction)
            {
                case (long) ViewAggregateFunction.CumulativePercent:
                case (long) ViewAggregateFunction.PercentOfColumn:
                case (long) ViewAggregateFunction.PercentOfRow:
                    if (SourceViewColumn == null || SourceViewColumn == "")
                    {
                        ratio = true;
                    }
                    break;
                case (long) ViewAggregateFunction.Proportion:
                    if (SourceViewColumn == null || DenominatorViewColumn == null || SourceViewColumn == "" || DenominatorViewColumn == "")
                    {
                        ratio = true;
                    }
                    break;
                case (long) ViewAggregateFunction.Ratio:
                    if (SourceViewColumn == null || DenominatorViewColumn == null || SourceViewColumn == "" || DenominatorViewColumn == "")
                    {
                        ratio = true;
                    }
                    else if (Owner.GetColumnByOriginalName(SourceViewColumn).FieldType == typeof (int) &&
                             Owner.GetColumnByOriginalName(DenominatorViewColumn).FieldType == typeof (int))
                    {
                        ratio = true;
                    }
                    break;
            }
            return ratio;
        }

        public void setAggrColumnTypeWeb()
        {
            if (getRatio())
            {
                FieldType = typeof (string);
            }
            else
            {
                switch (AggregateFunction)
                {
                    case (long) ViewAggregateFunction.CumulativePercent:
                    case (long) ViewAggregateFunction.PercentOfColumn:
                    case (long) ViewAggregateFunction.PercentOfRow:
                        FieldType = typeof (double);
                        PrecisionStringWeb = "P" + Precision_;
                        break;
                    case (long) ViewAggregateFunction.Proportion:
                        FieldType = typeof (double);
                        PrecisionStringWeb = "N" + Precision_;
                        break;
                    case (long) ViewAggregateFunction.Ratio:
                        FieldType = typeof (string);
                        break;
                    case (long) ViewAggregateFunction.MaxOfRow:
                    case (long) ViewAggregateFunction.MinOfRow:
                        AvrViewColumn neibN =
                            Owner.GetAllColumns().ToList().Find(n => !n.IsToDelete && n.IsVisible && !n.IsAggregate && n.FieldType.IsNumeric());
                        AvrViewColumn neibD =
                            Owner.GetAllColumns().ToList().Find(n => !n.IsToDelete && n.IsVisible && !n.IsAggregate && n.FieldType == typeof(DateTime));
                        if (neibN != null || neibD != null)
                        {
                            if (neibN != null)
                            {
                                FieldType = typeof (double);
                                PrecisionStringWeb = "N" + Precision_;
                            }
                            else
                            {
                                FieldType = typeof (DateTime);
                                PrecisionStringWeb = "d";
                            }
                        }
                        break;
                    default:
                        FieldType = typeof (string);
                        break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("({0}) | ({1})", UniquePath, DisplayText);
        }

        #endregion
    }
}