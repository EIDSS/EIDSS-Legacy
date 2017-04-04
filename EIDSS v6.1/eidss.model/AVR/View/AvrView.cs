using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;
using bv.common.Core;
using eidss.model.WindowsService.Serialization;

namespace eidss.model.Avr.View
{
    [Serializable]
    public class AvrView : BaseBand
    {
        public const int DefaultFieldWidth = 100;
        private string m_ChartXAxisViewColumn;
        private string m_MapAdminUnitViewColumn;
        private long? m_GlobalView;
        private int? m_GisLayerPosition;
        private string m_ChartLocalSettingsXml;
        private byte[] m_ChartLocalSettingsZip;
        private string m_GisLayerLocalSettingsXml;
        private byte[] m_GisLayerLocalSettingsZip;
        private string m_GisMapLocalSettingsXml;
        private byte[] m_GisMapLocalSettingsZip;
        private string m_ViewSettingsXml;
        private byte[] m_ViewSettingsZip;

        #region Constructors
        // .ctor for serializer
        public AvrView()
        {
        }

        // .ctor for Pivot 
        public AvrView(long layoutID, string layoutName, long queryID)
        {
            m_ViewID = layoutID;
            LayoutName = layoutName;
            QueryID = queryID;
        }

        // this constructor creates object from database
        public delegate string UncompressFunction(byte[] arg);

        public AvrView(DataSet ds, string tableView, string tableBands, string tableColumns)
        {
            var row = ds.Tables[tableView].Rows[0];
            m_ViewID = (long) row["idflLayout"];
            QueryID = (long) row["idflQuery"];
            object ids = row["ChartXAxisViewColumn"];
            if (!Utils.IsEmpty(ids))
            {
                m_ChartXAxisViewColumn = (string)ids;
            }
            ids = row["MapAdminUnitViewColumn"];
            if (!Utils.IsEmpty(ids))
            {
                m_MapAdminUnitViewColumn = (string)ids;
            }
            ids = row["idfGlobalView"];
            if (!Utils.IsEmpty(ids))
            {
                m_GlobalView = (long?) ids;
            }
            ids = row["intGisLayerPosition"];
            if (!Utils.IsEmpty(ids))
            {
                m_GisLayerPosition = (int?) ids;
            }
            var readOnly = row["blnReadOnly"];
            IsReadOnly = readOnly is bool && (bool) readOnly;
            ids = row["blbChartLocalSettings"];
            if (!Utils.IsEmpty(ids))
            {
                ChartLocalSettingsZip = (byte[]) ids;
            }
            ids = row["blbGisLayerLocalSettings"];
            if (!Utils.IsEmpty(ids))
            {
                GisLayerLocalSettingsZip = (byte[]) ids;
            }
            ids = row["blbGisMapLocalSettings"];
            if (!Utils.IsEmpty(ids))
            {
                GisMapLocalSettingsZip = (byte[]) ids;
            }
            ids = row["blbViewSettings"];
            if (!Utils.IsEmpty(ids))
            {
                ViewSettingsZip = (byte[]) ids;
            }

            if (m_ChartLocalSettingsZip != null)
            {
                m_ChartLocalSettingsXml = BinaryCompressor.UnzipString(m_ChartLocalSettingsZip);
            }
            if (m_GisLayerLocalSettingsZip != null)
            {
                m_GisLayerLocalSettingsXml = BinaryCompressor.UnzipString(m_GisLayerLocalSettingsZip);
            }
            if (m_GisMapLocalSettingsZip != null)
            {
                m_GisMapLocalSettingsXml = BinaryCompressor.UnzipString(m_GisMapLocalSettingsZip);
            }
            if (m_ViewSettingsZip != null)
            {
                m_ViewSettingsXml = BinaryCompressor.UnzipString(m_ViewSettingsZip);
            }
            

            DataRow[] drTop = ds.Tables[tableBands].Select("idfParentViewBand is null", "intOrder", DataViewRowState.CurrentRows);
            foreach (DataRow r in drTop)
            {
                Bands.Add(new AvrViewBand(r, ds, tableBands, tableColumns) { Owner = this });
            }
            DataRow[] drChildCols = ds.Tables[tableColumns].Select("idfViewBand is null", "intOrder", DataViewRowState.CurrentRows);
            if (drChildCols.Length > 0)
            {
                foreach (DataRow r in drChildCols)
                {
                    AddColumn(r);
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Current layout ID, the same as View ID. Dont use setter of this field directly, use ViewID instead! 
        /// Setter should be used in serialization only
        /// </summary>
        public long LayoutID
        {
            get { return m_ViewID; }
            set { m_ViewID = value; }
        }

        public long QueryID { get; set; }
        public string LayoutName { get; set; }

        public string ChartXAxisViewColumn
        {
            get { return m_ChartXAxisViewColumn; }
            set
            {
                if (m_ChartXAxisViewColumn != value)
                {
                    SetChanges();
                    m_ChartXAxisViewColumn = value;
                }
            }
        }
        public void SetChartXAxisViewColumn(string value)
        {
            m_ChartXAxisViewColumn = value;
        }

        public string MapAdminUnitViewColumn
        {
            get { return m_MapAdminUnitViewColumn; }
            set
            {
                if (m_MapAdminUnitViewColumn != value)
                {
                    SetChanges();
                    m_MapAdminUnitViewColumn = value;
                }
            }
        }
        public void SetMapAdminUnitViewColumn(string value)
        {
            m_MapAdminUnitViewColumn = value;
        }


        public long? GlobalView
        {
            get { return m_GlobalView; }
            set
            {
                if (m_GlobalView != value)
                {
                    SetChanges();
                    m_GlobalView = value;
                }
            }
        }

        public int? GisLayerPosition
        {
            get { return m_GisLayerPosition; }
            set
            {
                if (m_GisLayerPosition != value)
                {
                    SetChanges();
                    m_GisLayerPosition = value;
                }
            }
        }

        public string ChartLocalSettingsXml
        {
            get { return m_ChartLocalSettingsXml; }
            set
            {
                if (m_ChartLocalSettingsXml != value)
                {
                    SetChanges();
                    m_ChartLocalSettingsXml = value;
                    m_ChartLocalSettingsZip = null;
                }
            }
        }

        public byte[] ChartLocalSettingsZip
        {
            get { return m_ChartLocalSettingsZip; }
            set
            {
                m_ChartLocalSettingsZip = value;
                //m_ChartLocalSettingsXml = null;
            }
        }

        public string GisLayerLocalSettingsXml
        {
            get { return m_GisLayerLocalSettingsXml; }
            set
            {
                if (m_GisLayerLocalSettingsXml != value)
                {
                    SetChanges();
                    m_GisLayerLocalSettingsXml = value;
                    m_GisLayerLocalSettingsZip = null;
                }
            }
        }

        public byte[] GisLayerLocalSettingsZip
        {
            get { return m_GisLayerLocalSettingsZip; }
            set
            {
                m_GisLayerLocalSettingsZip = value;
                //m_GisLayerLocalSettingsXml = null;
            }
        }

        public string GisMapLocalSettingsXml
        {
            get { return m_GisMapLocalSettingsXml; }
            set
            {
                if (m_GisMapLocalSettingsXml != value)
                {
                    SetChanges();
                    m_GisMapLocalSettingsXml = value;
                    m_GisMapLocalSettingsZip = null;
                }
            }
        }

        public byte[] GisMapLocalSettingsZip
        {
            get { return m_GisMapLocalSettingsZip; }
            set
            {
                m_GisMapLocalSettingsZip = value;
                //m_GisMapLocalSettingsXml = null;
            }
        }

        public string ViewSettingsXml
        {
            get { return m_ViewSettingsXml; }
            set
            {
                if (m_ViewSettingsXml != value)
                {
                    SetChanges();
                    m_ViewSettingsXml = value;
                    m_ViewSettingsZip = null;
                }
            }
        }

        public byte[] ViewSettingsZip
        {
            get { return m_ViewSettingsZip; }
            set
            {
                m_ViewSettingsZip = value;
                //m_ViewSettingsXml = null;
            }
        }

        public string TotalSuffix { get; set; }

        public string GrandTotalSuffix { get; set; }

        [XmlIgnore]
        public bool IsReadOnly { get; set; }

        public bool IsSelfChanged
        {
            get { return m_IsChanged | m_IsNew; }
        }

        public object GridViewSettings { get; set; }

        // used only from web
        public string SelectedColBand { get; set; }
        public BaseBand SelectedBand
        {
            get
            {
                BaseBand band = GetCurrentBand(SelectedColBand);
                if (band != null)
                {
                    return band;
                }
                return this;
            }
        }
        public string ChartType { get; set; }

        #endregion

        #region Functions

        public void SetUnchanged()
        {
            m_IsChanged = false;
        }

        // compare obj to pivotView: delete deleted, add added, preserve old settings for all other;
        //  saves merged view in object
        //  returns false if no previous settings were preserved 
        public void AdjustToNew(AvrView pivotView)
        {
            //sometimes avr service sends bands or columns as invisible - this is wrong, repaire this
            pivotView.SetPivotVisible();

            // set default xAxis for chart as last column from Row Area
            if (String.IsNullOrEmpty(ChartXAxisViewColumn) ||
                pivotView.GetVisibleRowAdminColumns(true, null, false).Count(col => col.UniquePath == ChartXAxisViewColumn) == 0
               )
                SetChartXAxisViewColumn(pivotView.LastRowAreaColumn());

            // set default adm unit for map

            // get row + administrative columns
            List<AvrViewColumn> visibleRowAColumns = pivotView.GetVisibleRowAdminColumns(true, true, false);

            if (visibleRowAColumns.Count > 0 &&
                (String.IsNullOrEmpty(MapAdminUnitViewColumn) ||
                 visibleRowAColumns.Count(col => col.UniquePath == MapAdminUnitViewColumn) == 0
                )
               )
                // set default value
                SetMapAdminUnitViewColumn(visibleRowAColumns.Find(col => col.MapDisplayOrder == visibleRowAColumns.Max(c => c.MapDisplayOrder)).UniquePath);
            else if (!String.IsNullOrEmpty(MapAdminUnitViewColumn) && visibleRowAColumns.Count(col => col.UniquePath == MapAdminUnitViewColumn) > 0)
                SetMapAdminUnitViewColumn(visibleRowAColumns.Find(col => col.UniquePath == MapAdminUnitViewColumn).UniquePath);
            else
                SetMapAdminUnitViewColumn(String.Empty);


            LayoutName = pivotView.LayoutName;
            GlobalView = pivotView.GlobalView;
            GrandTotalSuffix = pivotView.GrandTotalSuffix;
            TotalSuffix = pivotView.TotalSuffix;
            QueryID = pivotView.QueryID;

            AdjustToNew((BaseBand)pivotView);
        }

        public override bool IsDiffFromPivot()
        {
            if (!String.IsNullOrEmpty(m_MapAdminUnitViewColumn) && m_MapAdminUnitViewColumn != GetDefaultMapAdminUnitViewColumn())
                return true;

            if (!String.IsNullOrEmpty(m_ChartXAxisViewColumn) && m_ChartXAxisViewColumn != LastRowAreaColumn())
                return true;

            return base.IsDiffFromPivot();
        }

        public override void ResetToPivot()
        {
            m_MapAdminUnitViewColumn = GetDefaultMapAdminUnitViewColumn();
            m_ChartXAxisViewColumn = LastRowAreaColumn();
            base.ResetToPivot();
        }

        public void setColumnsTypes(DataTable viewData)
        {
            var num = viewData.Columns.GetEnumerator();
            while (num.MoveNext())
            {
                var col = num.Current as DataColumn;
                if (col != null)
                {
                    AvrViewColumn avrCol = GetColumnByOriginalName(col.ColumnName);
                    if (avrCol != null)
                    {
                        avrCol.FieldType = col.DataType;
                    }
                }
            }
            SetAggrColumnsType();
        }

        #region Chart/Map combos functions
        // get nonrow numeric columns
        public List<AvrViewColumn> GetVisibleNotRowColumns(bool insertEmpty)
        {
            List<AvrViewColumn> result;
            if (insertEmpty)
            {
                var empty = new AvrViewColumn { FieldType = typeof(string) };
                result = new List<AvrViewColumn> { empty };
            }
            else
            {
                result = new List<AvrViewColumn>();
            }

            result.AddRange(GetVisibleRowAdminColumns(false, null, false).FindAll(x => x.FieldType.IsNumeric()));
            return result;//.OrderBy(c => c.Order_ForUse).ToList(); don't order here, because Order_ForUse have sense only inside band
        }

        public string GradientColumn
        {
            get
            {
                var ret = GetVisibleNotRowColumns(false).FirstOrDefault(c => c.IsMapGradientSeries);
                if (ret == null)
                    return String.Empty;
                return ret.UniquePath;
            }
        }

        public List<AvrViewColumn> GetMapAdminUnitList()
        {
            return GetVisibleRowAdminColumns(true, true, true);
        }
        public static IEnumerable<AvrViewColumn> GetMapAdminUnitList(AvrView view)
        {
            return view.GetMapAdminUnitList();
        }

        public List<AvrViewColumn> GetMapDefGradientList()
        {
            return GetVisibleNotRowColumns(true);
        }
        public static IEnumerable<AvrViewColumn> GetMapDefGradientList(AvrView view)
        {
            return view.GetMapDefGradientList();
        }

        // used from Web and Desktop to fill combos "Chart Series" and "Map Diagram Series"
        public List<AvrViewColumn> GetMapDefChartList()
        {
            return GetVisibleNotRowColumns(false);
        }
        // used from Web to fill combos "Chart Series" and "Map Diagram Series"
        public static IEnumerable<AvrViewColumn> GetMapDefChartListWeb(AvrView view)
        {
            List<AvrViewColumn> list = view.GetMapDefChartList();
            list.Insert(0, AvrViewColumn.GetSelectAll());
            return list;
        }

        public List<AvrViewColumn> GetChartXAxisList()
        {
            return GetVisibleRowAdminColumns(true, null, true);
        }
        public static IEnumerable<AvrViewColumn> GetChartXAxisList(AvrView view)
        {
            return view.GetChartXAxisList();
        }

        public List<AvrViewColumn> GetVisibleRowAdminColumns(bool? isRow, bool? isAdministrative, bool insertEmpty)
        {
            return GetVisibleRowAdminColumns("", isRow, isAdministrative, insertEmpty);
        }

        private String GetDefaultMapAdminUnitViewColumn()
        {
            // get row + administrative columns
            List<AvrViewColumn> visibleRowAColumns = GetVisibleRowAdminColumns(true, true, false);
            return visibleRowAColumns.Find(col => col.MapDisplayOrder == visibleRowAColumns.Max(c => c.MapDisplayOrder)).UniquePath;
        }
        #endregion

        public void FillBandsFullPaths()
        {
            FullPath = "";
            foreach (AvrViewBand band in Bands)
            {
                band.FillBandsFullPaths("");
            }
        }

        public void SaveColumnsDefs(string col, string defName)
        {
            if (col != null && col.Length == 0)
            {
                col = null;
            }
            switch (defName)
            {
                case "ChartXAxisViewColumn":
                    ChartXAxisViewColumn = col;
                    break;
                case "MapAdminUnitViewColumn":
                    MapAdminUnitViewColumn = col;
                    break;
            }
        }

        // used only from web
        public bool SetTempOrders(string source, string destination, bool isDropBefore)
        {
            var colSource = GetColumnByOriginalName(source);
            bool ret = false;
            if (colSource != null)
            {
                int i = 1;

                foreach (var col in colSource.Owner.Columns.Where(c => c.UniquePath != source).OrderBy(c => c.Order_ForUse))
                {
                    if (isDropBefore && col.UniquePath == destination)
                    {
                        if (colSource.Order_Temp != i)
                        {
                            colSource.Order_Temp = i;
                            ret = true;
                        }
                        i++;
                    }

                    if (col.Order_Temp != i)
                    {
                        col.Order_Temp = i;
                        ret = true;
                    }
                    i++;

                    if (!isDropBefore && col.UniquePath == destination)
                    {
                        if (colSource.Order_Temp != i)
                        {
                            colSource.Order_Temp = i;
                            ret = true;
                        }
                        i++;
                    }
                }
            }
            else
            {
                var bandSource = GetBandByOriginalName(source);
                if (bandSource != null)
                {
                    int i = 1;
                    foreach (var col in bandSource.Owner.Bands.Where(c => c.UniquePath != source).OrderBy(c => c.Order_ForUse))
                    {
                        if (isDropBefore && col.UniquePath == destination)
                        {
                            if (bandSource.Order_Temp != i)
                            {
                                bandSource.Order_Temp = i;
                                ret = true;
                            }
                            i++;
                        }

                        if (col.Order_Temp != i)
                        {
                            col.Order_Temp = i;
                            ret = true;
                        }
                        i++;

                        if (!isDropBefore && col.UniquePath == destination)
                        {
                            if (bandSource.Order_Temp != i)
                            {
                                bandSource.Order_Temp = i;
                                ret = true;
                            }
                            i++;
                        }
                    }
                }
            }
            return ret;
        }

        public void Delete()
        {
            m_ToDelete = true;
        }

        public List<AvrViewColumn> GetAllViewColumns()
        {
            List<AvrViewColumn> viewColumns = (Bands.Count == 0)
                ? Columns
                : GetAllBandColumns(Bands);

            return viewColumns;
        }

        private static List<AvrViewColumn> GetAllBandColumns(IEnumerable<AvrViewBand> avrViewBands)
        {
            var colums = new List<AvrViewColumn>();
            foreach (AvrViewBand band in avrViewBands)
            {
                colums.AddRange(band.Columns.Count == 0
                    ? GetAllBandColumns(band.Bands)
                    : band.Columns);
            }
            return colums;
        }



        public void AssignOwnerAndUniquePath()
        {
            AssignOwnerAndUniquePath(this);
        }

        private static void AssignOwnerAndUniquePath(BaseBand owner)
        {
            foreach (AvrViewBand band in owner.Bands)
            {
                band.Owner = owner;
                band.UniquePath = CalculateUniquePath(band);
                AssignOwnerAndUniquePath(band);
            }
            foreach (AvrViewColumn column in owner.Columns)
            {
                column.Owner = owner;
                column.UniquePath = CalculateUniquePath(column);
            }
        }

        private static string CalculateUniquePath(IAvrViewItem band)
        {
            string combinedName = GetCombinedName(band.LayoutSearchFieldId, band.LayoutSearchFieldName);
            string encodedText = BinarySerializer.MD5FromString(band.DisplayText);

            var owner = band.Owner as AvrViewBand;
            string prefix = owner == null
                ? String.Empty
                : String.Format("{0}>>", owner.UniquePath);

            string uniquePath = String.Format("{0}{1}{2}", prefix, combinedName, encodedText);
            return uniquePath;
        }

        private static string GetCombinedName(long fieldId, string fieldAlias)
        {
            string combinedName = String.IsNullOrEmpty(fieldAlias) ? String.Empty : String.Format("{0}_{1}__", fieldAlias, fieldId);
            return combinedName;
        }

        #endregion
    }
}