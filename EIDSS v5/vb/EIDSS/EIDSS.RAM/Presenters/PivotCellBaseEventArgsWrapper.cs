using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using bv.common.Core;
using bv.common.Enums;
using WinPivotGridField = DevExpress.XtraPivotGrid.PivotGridField;
using WebPivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;
using WinPivotCellBaseEventArgs = DevExpress.XtraPivotGrid.PivotCellBaseEventArgs;
using WebPivotCellBaseEventArgs = DevExpress.Web.ASPxPivotGrid.PivotCellBaseEventArgs;

namespace EIDSS.RAM.Presenters
{
    public class PivotCellBaseEventArgsWrapper
    {
        private readonly PivotCellEventArgs m_WinEventArgs;
        private readonly WebPivotCellBaseEventArgs m_WebEventArgs;

        public delegate PivotCellBaseEventArgsWrapper GetCellInfoDelegate(int columnIndex, int rowIndex);

        public PivotCellBaseEventArgsWrapper(PivotCellEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public PivotCellBaseEventArgsWrapper(WebPivotCellBaseEventArgs webEventArgs)
        {
            Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public bool IsWeb
        {
            get { return m_WinEventArgs == null; }
        }

        public object Value
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.Value
                           : m_WinEventArgs.Value;
            }
        }

        public bool Selected
        {
            get { return IsWeb || m_WinEventArgs.Selected; }
        }

        public bool Focused
        {
            get { return IsWeb || m_WinEventArgs.Focused; }
        }

        public double DoubleValue
        {
            get { return PivotPresenter.ConvertValueToDouble(Value); }
        }

        public PivotGridFieldBase DataField
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.DataField
                           : (PivotGridFieldBase) m_WinEventArgs.DataField;
            }
        }

        public PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return IsWeb
                       ? m_WebEventArgs.CreateDrillDownDataSource()
                       : m_WinEventArgs.CreateDrillDownDataSource();
        }

        public object GetFieldValue(PivotGridFieldBase idFieldBase)
        {
            Utils.CheckNotNull(idFieldBase, "idFieldBase");
            if (IsWeb)
            {
                var idField = (WebPivotGridField) idFieldBase;
                if (idField == null)
                {
                    throw new RamException(
                        "This method should be called from WinForms only. Parameter idFieldBase should has type DevExpress.XtraPivotGrid.PivotGridField");
                }
                return m_WebEventArgs.GetFieldValue(idField);
            }
            else
            {
                var idField = (WinPivotGridField) idFieldBase;
                if (idField == null)
                {
                    throw new RamException(
                        "This method should be called from WebForms only. Parameter idFieldBase should has type DevExpress.Web.ASPxPivotGrid.PivotGridField");
                }
                return m_WinEventArgs.GetFieldValue(idField);
            }
        }

        public static IList<CustomMapDataItem> GetSelectedCells
            (PivotGridFieldBase idFieldBase, PivotGridFieldBase typeFieldBase, GetCellInfoDelegate getCellInfo, Rectangle selection)
        {
            var mapData = new Dictionary<string, CustomMapDataItem>();
            for (int rowIndex = selection.Top; rowIndex < selection.Bottom; rowIndex++)
            {
                
                PivotCellBaseEventArgsWrapper cellInfo = getCellInfo(selection.Left, rowIndex);
                if (cellInfo.Selected || cellInfo.Focused)
                {

                    string gisReferenceName = Utils.Str(cellInfo.GetFieldValue(idFieldBase));
                    var newItem = new CustomMapDataItem(cellInfo.DoubleValue, GisCaseType.Unkown, gisReferenceName);

                    PivotDrillDownDataSource dataSource = cellInfo.CreateDrillDownDataSource();

                    // get all values in drill down of the curent value
                    if (cellInfo.DataField != null)
                    {
                        foreach (PivotDrillDownDataRow row in dataSource)
                        {
                            object caption = row[cellInfo.DataField];
                            if (caption != null)
                            {
                                newItem.CaptionList.Add(Utils.Str(caption));
                            }
                        }
                    }
                    // get type id of the current value
                    if (typeFieldBase != null)
                    {
                        foreach (PivotDrillDownDataRow row in dataSource)
                        {
                            string typeValue = Utils.Str(row[typeFieldBase]);
                            if ((typeValue != null) && (PivotPresenter.GisTypeDictionary.ContainsKey(typeValue)))
                            {
                                newItem.GisCaseType |= PivotPresenter.GisTypeDictionary[typeValue];
                            }
                        }
                    }
                    string key = newItem.GisReferenceName + newItem.GisCaseType;
                    if (!mapData.ContainsKey(key))
                    {
                        mapData.Add(key, newItem);
                    }
                    else
                    {
                        CustomMapDataItem existingItem = mapData[key];
                        existingItem.Value += newItem.Value;
                        existingItem.CaptionList.AddRange(newItem.CaptionList);
                    }
                }
            }

            return new List<CustomMapDataItem>(mapData.Values);
        }
    }
}
