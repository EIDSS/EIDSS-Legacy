using System;
using System.Data;
using System.Xml.Serialization;
using bv.common.Core;


namespace eidss.model.Avr.View
{
    [Serializable]
    public class AvrViewBand : BaseBand, IAvrViewItem
    {
        [XmlIgnore]
        private long m_ID;

        private string m_DisplayText;
        private string m_DisplayNamePivot;

        private bool m_Visible;
        private bool m_Freeze;
        private int m_Order;

        #region Constructors
        // .ctor for serializer
        public AvrViewBand()
        {
            m_Visible = true;
        }

        public AvrViewBand(long searchFieldId, string searchFieldName, string displayText, int columnWidth, int? precision = null)
        {
            LayoutSearchFieldId = searchFieldId;
            LayoutSearchFieldName = searchFieldName;
            LayoutChildSearchFieldId = searchFieldId;
            LayoutChildSearchFieldName = searchFieldName;
            m_DisplayText = displayText;
            ColumnWidth = columnWidth;
            m_Visible = true;
            Precision = precision;
        }

        // this constructor creates object from database
        public AvrViewBand(DataRow row, DataSet ds, string tableBands, string tableColumns)
        {
            m_ID = (long) row["idfViewBand"];
            m_ViewID = (long) row["idfView"];
            UniquePath = (string)row["UniquePath"];
            OriginalName = (string)row["strOriginalName"];
            object ids = row["idfLayoutSearchField"];
            if (!Utils.IsEmpty(ids))
            {
                LayoutSearchFieldId = (long)ids;
            }
            ids = row["strDisplayName"];
            if (!Utils.IsEmpty(ids))
            {
                m_DisplayText = (string) ids;
            }
            m_Visible = (bool) row["blnVisible"];
            m_Freeze = (bool) row["blnFreeze"];
            ids = row["intOrder"];
            if (!Utils.IsEmpty(ids))
            {
                m_Order = (int) ids;
            }
            else
            {
                m_Order = 0;
            }

            DataRow[] drChild = ds.Tables[tableBands].Select(string.Format("idfParentViewBand = {0}", row["idfViewBand"]), "intOrder",
                DataViewRowState.CurrentRows);
            if (drChild.Length > 0)
            {
                foreach (DataRow r in drChild)
                {
                    Bands.Add(new AvrViewBand(r, ds, tableBands, tableColumns) { Owner = this });
                }
            }
            DataRow[] drChildCols = ds.Tables[tableColumns].Select(string.Format("idfViewBand = {0}", row["idfViewBand"]), "intOrder",
                DataViewRowState.CurrentRows);
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

        public bool IsRowArea { get; set; }

        public bool IsAdministrativeUnit { get; set; }

        [XmlIgnore]
        public int MapDisplayOrder { get; set; }

        public int? Precision { get; set; }

        public int ColumnWidth { get; set; }
       

        [XmlIgnore]
        public long ID
        {
            get { return m_ID; }
            set
            {
                m_ID = value;
            }
        }


        public long LayoutSearchFieldId { get; set; }

        public string LayoutSearchFieldName { get; set; }

        public string UniquePath { get;  set; }

        [XmlIgnore]
        public long LayoutChildSearchFieldId { get; set; }

        [XmlIgnore]
        public string LayoutChildSearchFieldName { get; set; }

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

        [XmlIgnore]
        public int Order_ForUse
        {
            get{
                return Order > 0 ? Order : Order_Pivot + 1000;
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
        public bool IsSelfChanged
        {
            get { return m_IsChanged | m_ToDelete | IsOrderChanged | m_ID <= 0; }
        }
        #endregion

        #region Functions

        public void SetUnchanged()
        {
            m_IsChanged = false;
            foreach (AvrViewBand band in Bands)
            {
                band.SetUnchanged();
            }
            foreach (AvrViewColumn col in Columns)
            {
                col.SetUnchanged();
            }
        }

        public void SavePivotSettings(int order, string displName)
        {
            Order_Pivot = order;
            m_DisplayNamePivot = displName;
        }

        public void SavePivotSettings(int order, AvrViewBand pivotBand)
        {
            Utils.CheckNotNull(pivotBand, "pivotBand");
            Order_Pivot = order;
            m_DisplayNamePivot = Utils.IsEmpty(pivotBand.DisplayText) ? "" : pivotBand.DisplayText;
            int i = 0;
            foreach (AvrViewBand band in Bands)
            {
                AvrViewBand childBand = pivotBand.Bands.Find(b => b.UniquePath == band.UniquePath);
                // todo: [ivan] check this condition
                if (childBand != null)
                {
                    band.SavePivotSettings(i++, childBand);
                }
            }
            foreach (AvrViewColumn col in Columns)
            {
                AvrViewColumn pivotCol = pivotBand.Columns.Find(c => c.UniquePath == col.UniquePath);
                if (pivotCol != null) // not aggregate column
                {
                    col.SavePivotSettings(i++, pivotCol);
                }
            }
        }

        public override void ResetToPivot()
        {
            DisplayText = m_DisplayNamePivot;
            Order = 0;
            IsVisible = true;
            IsFreezed = false;
            base.ResetToPivot();
        }

        public override bool IsDiffFromPivot()
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
            if (IsFreezed)
            {
                return true;
            }
            return base.IsDiffFromPivot();
        }

        public void FillBandsFullPaths(string path)
        {
            FullPath = (path.Length == 0 ? " " : path + "->") + Utils.Str(m_DisplayText);
            foreach (AvrViewBand band in Bands)
            {
                band.FillBandsFullPaths(FullPath);
            }
        }

        public new void SetPivotVisible()
        {
            m_Visible = true;
            ((BaseBand)this).SetPivotVisible();
        }

        public bool Delete()
        {
            //delete all child columns and bands
            for (int i = 0; i < Columns.Count; i++)
            {
                if (!Columns[i].Delete())
                    Columns.RemoveAt(i--);
            }
            for (int j = 0; j < Bands.Count; j++)
            {
                if (!Bands[j].Delete())
                    Bands.RemoveAt(j--);
            }
            if (m_ID <= 0)
            {
                return false;
            }
            m_ToDelete = true;
            return true;
        }

        public override string ToString()
        {
            return string.Format("({0}) | ({1})", UniquePath, DisplayText);
        }

        #endregion
    }
}