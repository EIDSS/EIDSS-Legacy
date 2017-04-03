using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using bv.common.Core;

namespace eidss.model.Avr.View
{
    [Serializable]
    public  class BaseBand : IDisposable
    {
        public BaseBand()
        {
            Bands = new List<AvrViewBand>();
            Columns = new List<AvrViewColumn>();
            m_IsChanged = false;
            m_IsNew = false;
            m_ToDelete = false;
        }

        #region Properties

        public List<AvrViewBand> Bands { get; protected set; }

        public List<AvrViewColumn> Columns { get; protected set; }

        protected long m_ViewID;
        protected bool m_IsChanged;
        protected bool m_IsNew;
        protected bool m_ToDelete;

        public string FullPath { get; set; }

        [XmlIgnore]
        public long ViewID
        {
            get { return m_ViewID; }
            set
            {
                m_ViewID = value;
                foreach (AvrViewBand band in Bands)
                {
                    band.ViewID = m_ViewID;
                }
                foreach (AvrViewColumn col in Columns)
                {
                    col.ViewID = m_ViewID;
                }
            }
        }

        [XmlIgnore]
        public BaseBand Owner { get; set; }

        public bool IsNew
        {
            get
            {
                return m_IsNew;
            }
        }
        public bool IsChanged
        {
            get
            {
                bool bChanged = m_IsChanged | m_ToDelete | IsOrderChanged;
                if (bChanged)
                {
                    return true;
                }
                foreach (AvrViewBand band in Bands)
                {
                    bChanged |= band.IsChanged;
                    if (bChanged)
                    {
                        return true;
                    }
                }
                foreach (AvrViewColumn col in Columns)
                {
                    bChanged |= col.IsChanged;
                    if (bChanged)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // used only from web
        [XmlIgnore]
        public bool IsOrderChanged { get; set; }

        // used only from web
        [XmlIgnore]
        public int? Order_Temp { get; set; }

        public void SetChanges()
        {
            m_IsChanged = true;
        }

        public void SetNew()
        {
            m_IsNew = true;
        }

        public void SetNotNew()
        {
            m_IsNew = false;
        }

        public bool IsToDelete
        {
            get { return m_ToDelete; }
        }

        #endregion

        #region Functions

        protected void AdjustToNew(BaseBand pivotBand)
        {
            //delete deleted in pivot bands, save pivot properties if bands preserved in pivot
            for (int i = 0; i < Bands.Count; i++)
            {
                if (pivotBand.Bands.Exists(b => b.UniquePath == Bands[i].UniquePath))
                {
                    // save pivot properties if bands preserved in pivot
                    AvrViewBand nBand = pivotBand.Bands.Single(b => b.UniquePath == Bands[i].UniquePath);
                    Bands[i].SavePivotSettings(pivotBand.Bands.IndexOf(nBand), nBand);
                    Bands[i].AdjustToNew(nBand);
                }
                else
                {
                    //delete deleted in pivot bands and count remained bands
                    if (!Bands[i].Delete())
                    {
                        Bands.RemoveAt(i--);
                    }
                }
            }
            //delete deleted in pivot columns, save pivot properties if columns preserved in pivot
            for (int i = 0; i < Columns.Count; i++)
            {
                if (pivotBand.Columns.Exists(c => c.UniquePath == Columns[i].UniquePath))
                {
                    // save pivot properties if columns were preserved in pivot
                    AvrViewColumn newCol = pivotBand.Columns.Single(c => c.UniquePath == Columns[i].UniquePath);
                    Columns[i].SavePivotSettings(pivotBand.Columns.IndexOf(newCol), newCol);
                }
                else
                {
                    //delete deleted in pivot columns and count remained columns
                    if (!Columns[i].IsAggregate)
                    {
                        if (!Columns[i].Delete())
                            Columns.RemoveAt(i--);
                    }
                    // delete aggregate column if its references died
                    /*else if (
                        (Columns[i].SourceViewColumn != null && pivotBand.GetColumnByOriginalName( Columns[i].SourceViewColumn ) == null) ||
                        (Columns[i].DenominatorViewColumn != null && pivotBand.GetColumnByOriginalName( Columns[i].DenominatorViewColumn == null ))
                        )
                    {
                        if (!Columns[i].Delete())
                            Columns.RemoveAt(i--);
                    }*/
                }
            }
            // add new pivot bands
            for (int i = 0; i < pivotBand.Bands.Count; i++)
            {
                if (!Bands.Exists(b => b.UniquePath == pivotBand.Bands[i].UniquePath))
                {
                    pivotBand.Bands[i].OriginalName = pivotBand.Bands[i].DisplayText;
                    AddBand(i, pivotBand.Bands[i]);
                }
            }
            // add new pivot columns
            for (int i = 0; i < pivotBand.Columns.Count; i++)
            {
                if (!Columns.Exists(c => c.UniquePath == pivotBand.Columns[i].UniquePath))
                {
                    pivotBand.Columns[i].OriginalName = pivotBand.Columns[i].DisplayText;
                    pivotBand.Columns[i].SavePivotSettings(i, pivotBand.Columns[i]);
                    pivotBand.Columns[i].SetUnchanged();
                    AddColumn(pivotBand.Columns[i]);
                }
            }
            // set default order for aggregate columns as last in band
            int maxNotAggr = Columns.Count(c => !c.IsAggregate);
            foreach (AvrViewColumn cCol in Columns.FindAll(c => c.IsAggregate))
            {
                cCol.Order_Pivot = maxNotAggr++;
            }
        }

        #region Sorting

        public void ClearSorting()
        {
            foreach (AvrViewBand band in Bands)
            {
                band.ClearSorting();
            }
            foreach (AvrViewColumn col in Columns)
            {
                col.SortOrder = null;
                col.IsSortAscending = true;
            }
        }

        public List<AvrViewColumn> GetSortColumns()
        {
            var ret = new List<AvrViewColumn>();
            Bands.FindAll(x => !x.IsToDelete).ForEach(b => b.GetSortColumns(ref ret));
            ret.AddRange(Columns.FindAll(x => !x.IsToDelete && x.SortOrder != null));
            return ret;
        }

        private void GetSortColumns(ref List<AvrViewColumn> list)
        {
            foreach (AvrViewBand band in Bands.FindAll(x => !x.IsToDelete))
            {
                band.GetSortColumns(ref list);
            }
            list.AddRange(Columns.FindAll(x => !x.IsToDelete && x.SortOrder != null));
        }

        public string GetSortExpression()
        {
            string ret = "";
            var list = GetSortColumns();
            list.Sort((f1, f2) => f1.SortOrder.Value.CompareTo(f2.SortOrder.Value));
            list.ForEach(col => ret += (ret.Length > 0 ? ", " : "") + col.UniquePath + (col.IsSortAscending ? " ASC" : " DESC"));
            return ret;
        }

        #endregion

        public string GetFilterExpression(bool erase = false)
        {
            string ret = "";
            Columns.FindAll(x => !x.IsToDelete && x.ColumnFilter != null && x.ColumnFilter.Length > 0).ForEach(col => ret += (ret.Length > 0 ? " AND " : "") + "(" + col.ColumnFilter + ")");
            Bands.FindAll(x => !x.IsToDelete).ForEach(b => { string temp = b.GetFilterExpression(); if (temp.Length > 0) ret += (ret.Length > 2 ? " AND " : "") + "(" + temp + ")"; });
            if (erase)
            {
                ret = Regex.Replace(ret, "(=\\s?\\d+)L","$1");
            }
            return ret;
        }

        public void AddBand(int order, AvrViewBand band)
        {
            band.ViewID = m_ViewID;
            band.SavePivotSettings(order, band);
            band.SetUnchanged();
            band.Owner = this;
            Bands.Add(band);
        }

        // column from database
        public void AddColumn(DataRow row)
        {
            var col = new AvrViewColumn(row) {Owner = this};
            Columns.Add(col);
        }

        // column from pivot
        public void AddColumn(AvrViewColumn col)
        {
            col.ViewID = ViewID;
            col.Owner = this;
            Columns.Add(col);
        }

        public AvrViewColumn AddAggregateColumn()
        {
            string colName = Resources.EidssMessages.Get("AggregateColumn", "Aggregate Column");
            string colFieldName = "AggregateColumn" + DateTime.Now.TimeOfDay;
            var newCol = new AvrViewColumn(-1, colFieldName, colName, AvrView.DefaultFieldWidth)
            {
                IsAggregate = true,
                Order_Pivot = Columns.Count,
                OriginalName = colName,
                UniquePath = colFieldName,
            };

            if (this is AvrView && Bands.Count > 0)
            {
                return null;
                //can't understand, what for is this?
                string bFieldName = "AggregateBand" + DateTime.Now.TimeOfDay;
                var newBand = new AvrViewBand(-1, bFieldName, bFieldName, AvrView.DefaultFieldWidth)
                {
                    Order_Pivot = Bands.Count,
                    OriginalName = "",
                    UniquePath = "",
                };
                newBand.AddColumn(newCol);
            }
            else
                AddColumn(newCol);
            return newCol;
        }

        public void DeleteAggregateColumn(string path)
        {
            AvrViewColumn aCol = GetColumnByOriginalName(path);
            if (aCol != null && !aCol.Delete())
                aCol.Owner.Columns.Remove(aCol);
        }


        public virtual void ResetToPivot()
        {
            foreach (AvrViewBand band in Bands)
            {
                band.ResetToPivot();
            }
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].IsAggregate)
                {
                    if (!Columns[i].Delete())
                    {
                        Columns.RemoveAt(i--);
                    }
                }
                else
                {
                    Columns[i].ResetToPivot();
                }
            }
        }

        public virtual bool IsDiffFromPivot()
        {
            if (Bands.Any(band => band.IsDiffFromPivot()))
            {
                return true;
            }
            foreach (AvrViewColumn column in Columns)
            {
                if (column.IsAggregate)
                {
                    if (!column.IsToDelete)
                    {
                        return true;
                    }
                }
                else
                {
                    if (column.IsDiffFromPivot())
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public List<AvrViewColumn> GetAggregateColumnsList()
        {
            var result = new List<AvrViewColumn>(); 
            return GetAggregateColumnsList(result);
        }
        public List<AvrViewColumn> GetAggregateColumnsList(List<AvrViewColumn> result)
        {
            foreach (AvrViewBand band in Bands.FindAll(b => !b.IsToDelete && b.IsVisible))
            {
                band.GetAggregateColumnsList(result);
            }
            Columns.FindAll(c => !c.IsToDelete &&
                                 c.IsVisible &&
                                 c.IsAggregate
                           )
                    .ForEach(result.Add);

            return result;
        }

        public List<AvrViewColumn> GetVisibleRowAdminColumns(string path, bool? isRow, bool? isAdministrative, bool insertEmpty)
        {
            List<AvrViewColumn> result;
            if (insertEmpty)
            {
                var empty = new AvrViewColumn {FieldType = typeof (string)};
                result = new List<AvrViewColumn> {empty};
            }
            else
            {
                result = new List<AvrViewColumn>();
            }

            return GetVisibleRowAdminColumns(path, isRow, isAdministrative, result);
        }

        public List<AvrViewColumn> GetVisibleRowAdminColumns(string path, bool? isRow, bool? isAdministrative, List<AvrViewColumn> result)
        {
            foreach (AvrViewBand band in Bands.FindAll(b => !b.IsToDelete && b.IsVisible))
            {
                band.FullPath = (path.Length == 0 ? "" : path + "->") + Utils.Str(band.DisplayText);
                band.GetVisibleRowAdminColumns(band.FullPath, isRow, isAdministrative, result);
            }
            Columns.FindAll(c => !c.IsToDelete &&
                                 c.IsVisible &&
                                 (!isRow.HasValue || c.IsRowArea == isRow.Value) &&
                                 (!isAdministrative.HasValue || c.IsAdministrativeUnit == isAdministrative.Value)
                           )
                    .ForEach(c =>
                    {
                        c.FullPath = (path.Length == 0 ? "" : path + "->") + Utils.Str(c.DisplayText);
                        result.Add(c);
                    });

            return result;
        }

        // set default xAxis for chart as last column from Row Area
        public string LastRowAreaColumn()
        {
            string ret = null;
            foreach (AvrViewBand band in Bands.FindAll(x => !x.IsToDelete && x.IsVisible)
                                              .OrderBy(x => x.Order_ForUse))
            {
                string lRow = band.LastRowAreaColumn();
                if (lRow == null)
                {
                    break;
                }
                ret = lRow;
            }
            Columns.FindAll(x => !x.IsToDelete && x.IsVisible && x.IsRowArea)
                   .OrderBy(x => x.Order_ForUse)
                   .ToList()
                   .ForEach(c => ret = c.UniquePath);
            return ret;
        }

        public void FillColumnsBooleans(string[] cols, string booleanName)
        {
            foreach (AvrViewBand band in Bands)
            {
                band.FillColumnsBooleans(cols, booleanName);
            }

            foreach (AvrViewColumn col in Columns)
            {
                bool value = col.ExistsIn(cols);
                switch (booleanName)
                {
                    case "IsChartSeries":
                        col.IsChartSeries = value;
                        break;
                    case "IsMapDiagramSeries":
                        col.IsMapDiagramSeries = value;
                        break;
                    case "IsMapGradientSeries":
                        col.IsMapGradientSeries = value;
                        break;
                }
            }
        }

        public void FillColumnsBooleans(string cols, string booleanName)
        {
            Bands.ForEach(b => b.FillColumnsBooleans(cols, booleanName));

            foreach (AvrViewColumn col in Columns)
            {
                bool value = cols.Contains(col.UniquePath);
                switch (booleanName)
                {
                    case "IsChartSeries":
                        col.IsChartSeries = value;
                        break;
                    case "IsMapDiagramSeries":
                        col.IsMapDiagramSeries = value;
                        break;
                    case "IsMapGradientSeries":
                        col.IsMapGradientSeries = value;
                        break;
                }
            }
        }

        public static string GetColumnsBooleans(AvrView view, string booleanName)
        {
            return view.GetColumnsBooleans(booleanName);
        }
        public string GetColumnsBooleans(string booleanName)
        {
            string ret = "";
            switch (booleanName)
            {
                case "IsChartSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsChartSeries).ForEach(col => ret += ", " + col.UniquePath);
                    break;
                case "IsMapDiagramSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsMapDiagramSeries).ForEach(col => ret += ", " + col.UniquePath);
                    break;
                case "IsMapGradientSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsMapGradientSeries).ForEach(col => ret += ", " + col.UniquePath);
                    break;
            }
            Bands.FindAll(x => !x.IsToDelete).ForEach(b => ret += ", " + b.GetColumnsBooleans(booleanName));
            return ret.TrimStart(' ', ',');
        }

        public static string GetColumnsBooleanTexts(AvrView view, string booleanName)
        {
            return view.GetColumnsBooleanTexts(booleanName);
        }
        public string GetColumnsBooleanTexts(string booleanName)
        {
            string ret = "";
            switch (booleanName)
            {
                case "IsChartSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsChartSeries).ForEach(col => ret += ", " + col.FullPath);
                    break;
                case "IsMapDiagramSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsMapDiagramSeries).ForEach(col => ret += ", " + col.FullPath);
                    break;
                case "IsMapGradientSeries":
                    Columns.FindAll(x => !x.IsToDelete && x.IsMapGradientSeries).ForEach(col => ret += ", " + col.FullPath);
                    break;
            }
            Bands.FindAll(x => !x.IsToDelete).ForEach(b => { string s = b.GetColumnsBooleanTexts(booleanName); if(s.Length > 0) ret += ", " + s; });
            return ret.Length > 2 ? ret.Substring(2) : "";
        }

        public AvrViewColumn GetColumnByID(long? id)
        {
            AvrViewColumn ret = null;
            if (id != null)
            {
                ret = Columns.Find(x => x.ID == id);
                if (ret == null)
                {
                    foreach (AvrViewBand band in Bands)
                    {
                        ret = band.GetColumnByID(id);
                        if (ret != null)
                        {
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        // used only from web
        public BaseBand GetCurrentBand(string uniquePath)
        {
            AvrViewColumn col = GetColumnByOriginalName(uniquePath);
            if (col != null)
            {
                return col.Owner;
            }
            AvrViewBand band = GetBandByOriginalName(uniquePath);
            if (band != null)
            {
                return band;
            }
            return null;
        }

        // used only from web
        public BaseBand GetParent(string uniquePath)
        {
            AvrViewColumn col = GetColumnByOriginalName(uniquePath);
            if (col != null)
            {
                return col.Owner;
            }
            AvrViewBand band = GetBandByOriginalName(uniquePath);
            if (band != null)
            {
                return band.Owner;
            }
            return null;
        }

        public AvrViewColumn GetColumnByOriginalName(string origName)
        {
            AvrViewColumn ret = null;
            if (!string.IsNullOrEmpty(origName))
            {
                ret = Columns.Find(x => x.UniquePath == origName);
                if (ret == null)
                {
                    foreach (AvrViewBand band in Bands)
                    {
                        ret = band.GetColumnByOriginalName(origName);
                        if (ret != null)
                        {
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        public AvrViewBand GetBandByOriginalName(string origName)
        {
            AvrViewBand ret = null;
            if (!string.IsNullOrEmpty(origName))
            {
                ret = Bands.Find(x => x.UniquePath == origName);
                if (ret == null)
                {
                    foreach (AvrViewBand band in Bands)
                    {
                        ret = band.GetBandByOriginalName(origName);
                        if (ret != null)
                        {
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        public List<AvrViewColumn> GetColumnsByOriginalName(string origNames)
        {
            var ret = new List<AvrViewColumn>();
            if (!string.IsNullOrEmpty(origNames))
            {
                ret.AddRange(Columns.FindAll(x => origNames.Contains(x.UniquePath)));
                Bands.ForEach(b => ret.AddRange(b.GetColumnsByOriginalName(origNames)));
            }
            return ret;
        }

        #region Save Columns/Bands order from web gridview
        // used only from web
        public void SetOrderChanged(string origName)
        {
            BaseBand band = GetParent(origName);
            if (band != null)
            {
                band.Columns.ForEach(c => c.IsOrderChanged = true);
                band.Bands.ForEach(b => b.IsOrderChanged = true);
            }
        }

        // used only from web
        public void SetOrders()
        {
            int i = 1;
            Columns.Where(c => c.Order_Temp.HasValue && c.IsOrderChanged).OrderBy(c => c.Order_Temp).ToList().ForEach(c =>
            {
                c.Order = i++;
                c.IsOrderChanged = false;
            });
            i = 1;
            Bands.Where(c => c.Order_Temp.HasValue && c.IsOrderChanged).OrderBy(b => b.Order_Temp).ToList().ForEach(b =>
            {
                b.Order = i++;
                b.IsOrderChanged = false;
            });
            Bands.ForEach(b => b.SetOrders());
        }
        #endregion


        //Delete deleted bands and columns
        public void RemoveDeleted()
        {
            for (int i = 0; i < Bands.Count; i++)
            {
                if (Bands[i].IsToDelete)
                {
                    Bands.RemoveAt(i--);
                }
                else
                {
                    Bands[i].RemoveDeleted();
                }
            }
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].IsToDelete)
                {
                    Columns.RemoveAt(i--);
                }
            }
        }

        public void Dispose()
        {
            Bands.Clear();
            Columns.Clear();
        }

        public void SetAggrColumnsType()
        {
            Bands.ForEach(b => b.SetAggrColumnsType());

            foreach (AvrViewColumn col in Columns)
            {
                if (col.IsAggregate)
                    col.FieldType = typeof(string);
            }
        }

        public void SetPivotVisible()
        {
            Bands.ForEach(b => b.SetPivotVisible());
            Columns.ForEach(b => b.SetPivotVisible());
        }

        public IEnumerable<AvrViewColumn> FillBandColumns()
        {
            return GetVisibleRowAdminColumns(FullPath, null, null, true).FindAll(x => !x.IsAggregate);
        }

        public IEnumerable<AvrViewColumn> GetAllColumns()
        {
            foreach (AvrViewColumn col in Columns)
            {
                yield return col;
            }
            foreach (AvrViewBand band in Bands)
            {
                foreach (AvrViewColumn c in band.GetAllColumns())
                    yield return c;
            }
        }

        #endregion
    }
}