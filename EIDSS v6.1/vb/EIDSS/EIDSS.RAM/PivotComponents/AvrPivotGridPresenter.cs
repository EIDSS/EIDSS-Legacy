using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.BaseComponents;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;
using eidss.model.AVR.SourceData;

namespace eidss.avr.PivotComponents
{
    public class AvrPivotGridPresenter : BaseAvrPresenter
    {
        private IAvrPivotGridView m_PivotGridView;
        private Dictionary<string, string> m_CaptionDictionary;

        public AvrPivotGridPresenter(SharedPresenter sharedPresenter, IAvrPivotGridView view)
            : base(sharedPresenter)
        {
            m_PivotGridView = view;
        }

        public override void Process(Command cmd)
        {
        }

        public override void Dispose()
        {
            try
            {
                m_PivotGridView = null;
            }
            finally
            {
                base.Dispose();
            }
        }

        #region Prepare Avr View Data

        public PivotGridDataLoadedCommand CreatePivotDataLoadedCommand(string layoutName, bool skipData = false)
        {
            var view = new AvrView(m_SharedPresenter.SharedModel.SelectedLayoutId, layoutName, m_SharedPresenter.SharedModel.SelectedQueryId);
            CreateTotalSuffixForView(view);

            bool isFlat = m_PivotGridView.PivotData.VisualItems.GetLevelCount(true) == 1;

            CreateViewHeaderFromRowArea(view, isFlat);

            CreateViewHeaderFromColumnArea(view, isFlat);

            AddColumnsToEmptyBands(view.Bands);

            view.RemoveHascFromDisplayText();

            view.AssignOwnerAndUniquePath();

            AssignCustomSummaryTypes(view);

            DataTable dataSource = CreateViewDataSourceStructure(view);

            CheckViewHeaderColumnCount(view);

            if (!skipData)
            {
                FillViewDataSource(view, dataSource);
            }
            var model = new AvrPivotViewModel(view, dataSource);

//                 string viewXmlNew = AvrViewSerializer.Serialize(view);
//            string data = DataTableSerializer.Serialize(dataSource);

            return new PivotGridDataLoadedCommand(this, model);
        }

        private void CreateTotalSuffixForView(AvrView view)
        {
            List<CustomSummaryType> types = m_PivotGridView.DataAreaFields.Select(field => field.CustomSummaryType).ToList();
            view.TotalSuffix = " " + m_PivotGridView.DisplayTextHandler.GetGrandTotalDisplayText(types, false);
            view.GrandTotalSuffix = m_PivotGridView.DisplayTextHandler.GetGrandTotalDisplayText(types, true);
        }

        private void CreateViewHeaderFromRowArea(AvrView view, bool isFlat)
        {
            DataView dvMapFieldList = AvrPivotGridHelper.GetMapFiledView(SharedPresenter.SharedModel.SelectedQueryId, true);

            AvrViewBand rowAreaRootBand = null;
            if (!isFlat && m_PivotGridView.RowAreaFields.Count > 0)
            {
                var firstField = (PivotGridFieldBase) m_PivotGridView.RowAreaFields[0];

                long fieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(firstField.FieldName);
                string fieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(firstField.FieldName);

                rowAreaRootBand = new AvrViewBand(fieldId, fieldAlias, string.Empty, 100);
                view.Bands.Add(rowAreaRootBand);
            }
            foreach (IAvrPivotGridField field in m_PivotGridView.RowAreaFields)
            {
                AvrViewColumn column = CreateViewColumnInternal(field.FieldName, field.Caption, field.Width);
                column.IsRowArea = true;
                foreach (DataRowView rowView in dvMapFieldList)
                {
                    string value = Utils.Str(rowView["FieldAlias"]);
                    if (field.FieldName.Contains(value))
                    {
                        column.GisReferenceTypeId = field.GisReferenceTypeId;
                        column.IsAdministrativeUnit = true;
                        column.MapDisplayOrder = rowView["intMapDisplayOrder"] is int
                            ? (int) rowView["intMapDisplayOrder"]
                            : int.MaxValue;
                    }
                }

                if (rowAreaRootBand == null)
                {
                    view.Columns.Add(column);
                }
                else
                {
                    rowAreaRootBand.AddColumn(column);
                }
            }
        }

        private void CreateViewHeaderFromColumnArea(AvrView view, bool isFlat)
        {
            int columnItemCount = m_PivotGridView.PivotData.VisualItems.GetItemCount(true);
            for (int i = 0; i < columnItemCount; i++)
            {
                PivotFieldValueItem item = m_PivotGridView.PivotData.VisualItems.GetItem(true, i);

                long? gisReferenceTypeId = GetGisReferenceTypeId(item.ColumnField);

                if (item.Level == 0)
                {
                    if (isFlat)
                    {
                        string fieldName = GetFieldName(item);

                        int width = (m_PivotGridView.ColumnAreaFields.Count == 0)
                            ? GetFieldWidth(item)
                            : GetBandWidth(item);

                        AvrViewColumn column = CreateViewColumnInternal(fieldName, item.DisplayText, width);
                        column.IsAdministrativeUnit = gisReferenceTypeId.HasValue;
                        view.Columns.Add(column);
                    }
                    else
                    {
                        string bandName = GetBandName(item);
                        string fieldName = GetFieldName(item);
                        int width = GetFieldWidth(item);

                        AvrViewBand band = CreateViewBandInternal(bandName, fieldName, item.DisplayText, width);
                        band.IsAdministrativeUnit = gisReferenceTypeId.HasValue;
                        view.Bands.Add(band);
                        CreateViewBandsAndColumns(band, item);
                    }
                }
            }
        }

        internal void CreateViewBandsAndColumns(AvrViewBand band, PivotFieldValueItem item)
        {
            Utils.CheckNotNull(band, "band");
            Utils.CheckNotNull(item, "item");

            var children = new List<PivotFieldValueItem>();
            for (int i = 0; i < item.CellCount; i++)
            {
                children.Add(item.GetCell(i));
            }

            bool isChildrenHasChildren = children.Any(child => child.CellCount != 0);

            foreach (PivotFieldValueItem child in children)
            {
                if (isChildrenHasChildren)
                {
                    AvrViewBand childBand = CreateViewBand(band, child);
                    band.Bands.Add(childBand);
                    CreateViewBandsAndColumns(childBand, child);
                }
                else
                {
                    AvrViewColumn childColumn = CreateViewColumn(band, child);
                    childColumn.GisReferenceTypeId = GetGisReferenceTypeId(child.ColumnField);
                    childColumn.IsAdministrativeUnit = childColumn.GisReferenceTypeId.HasValue;

                    band.Columns.Add(childColumn);
                }
            }
        }

        private void AssignCustomSummaryTypes(AvrView view)
        {
            List<AvrViewColumn> viewColumns = view.GetAllViewColumns();
            foreach (AvrViewColumn column in viewColumns)
            {
                string fieldName = AvrPivotGridFieldHelper.CreateFieldName(column.LayoutSearchFieldName, column.LayoutSearchFieldId);
                IAvrPivotGridField field = m_PivotGridView.DataAreaFields.FirstOrDefault(f => f.FieldName == fieldName);
                column.CustomSummaryType = field != null
                    ? field.CustomSummaryType
                    : CustomSummaryType.Undefined;
            }
        }

        private DataTable CreateViewDataSourceStructure(AvrView view)
        {
            var dataSource = new DataTable("ViewData");
            dataSource.BeginInit();

            var fields = new List<IAvrPivotGridField>();
            fields.AddRange(m_PivotGridView.RowAreaFields);
            fields.AddRange(m_PivotGridView.DataAreaFields);

            List<AvrViewColumn> viewColumns = view.GetAllViewColumns();
            foreach (AvrViewColumn viewColumn in viewColumns)
            {
                viewColumn.FieldType = GetViewColumnType(viewColumn, fields);
                DataColumn dataColumn = dataSource.Columns.Add(viewColumn.UniquePath, viewColumn.FieldType);
                dataColumn.Caption = viewColumn.DisplayText;
            }

            dataSource.EndInit();
            return dataSource;
        }

        private Type GetViewColumnType(AvrViewColumn column, IEnumerable<IAvrPivotGridField> fields)
        {
            Type type = typeof (string);

            string fieldName = AvrPivotGridFieldHelper.CreateFieldName(column.LayoutSearchFieldName, column.LayoutSearchFieldId);
            IAvrPivotGridField field = fields.FirstOrDefault(f => f.FieldName == fieldName);
            if (field != null && field.Area == PivotArea.DataArea)
            {
                switch (field.CustomSummaryType)
                {
                    case CustomSummaryType.Average:
                    case CustomSummaryType.Pop10000:
                    case CustomSummaryType.Pop100000:
                    case CustomSummaryType.PopGender100000:
                    case CustomSummaryType.PopAgeGroupGender100000:
                    case CustomSummaryType.PopAgeGroupGender10000:
                    case CustomSummaryType.StdDev:
                    case CustomSummaryType.Variance:
                        type = typeof (double);
                        break;

                    case CustomSummaryType.Count:
                    case CustomSummaryType.DistinctCount:
                        type = typeof (long);
                        break;
                    case CustomSummaryType.Sum:
                        type = field.DataType == typeof (double) ||
                               field.DataType == typeof (float) ||
                               field.DataType == typeof (decimal)
                            ? field.DataType
                            : typeof (long);
                        break;
                    case CustomSummaryType.Max:
                    case CustomSummaryType.Min:
                        type = GetRealFieldType(field);
                        break;
                }
            }
            return type;
        }

        private Type GetRealFieldType(IAvrPivotGridField field)
        {
            Utils.CheckNotNull(field, "field");

            Type type;
            if (field.GroupInterval.IsDate())
            {
                switch (field.GroupInterval)
                {
                    case PivotGroupInterval.DateDayOfYear:
                    case PivotGroupInterval.DateQuarter:
                    case PivotGroupInterval.DateWeekOfYear:
                    case PivotGroupInterval.DateWeekOfMonth:
                    case PivotGroupInterval.DateYear:
                    case PivotGroupInterval.DateDay:
                        type = typeof (int);
                        break;
                    case PivotGroupInterval.Date:
                        type = typeof (DateTime);
                        break;
                    case PivotGroupInterval.DateDayOfWeek:
                        type = typeof (DayOfWeek);
                        break;
                    case PivotGroupInterval.DateMonth:
                        type = typeof (AvrMonth);
                        break;
                    default:
                        type = typeof (DateTime);
                        break;
                }
            }
            else
            {
                type = field.DataType;
            }
            return type;
        }

        private void CheckViewHeaderColumnCount(AvrView view)
        {
            List<AvrViewColumn> viewColumns = view.GetAllViewColumns();
            if (viewColumns.Count - m_PivotGridView.RowAreaFields.Count != m_PivotGridView.Cells.ColumnCount)
            {
                throw new AvrException("Internal Error. DataArea column count isn't equal to RowArea column count.");
            }
        }

//        private void FillViewDataSource(AvrView view, DataTable dataSource)
//        {
//            var rowCount = m_PivotGridView.Cells.RowCount;
//            if (rowCount > 0)
//            {
//                AvrCellInfo[,] infoDictionary = new AvrCellInfo[rowCount, m_PivotGridView.Cells.ColumnCount];
//
//                Action<int, int> cellInfoCalculator = (min, max) =>
//                {
//                    for (var rowIndex = min; rowIndex < max; rowIndex++)
//                    {
//                        for (var columnIndex = 0; columnIndex < m_PivotGridView.Cells.ColumnCount; columnIndex++)
//                        {
//                            var cellInfo = m_PivotGridView.Cells.GetCellInfo(columnIndex, rowIndex);
//                            infoDictionary[rowIndex, columnIndex] = new AvrCellInfo(cellInfo);
//                        }
//                    }
//                };
//
//                if (rowCount > 16)
//                {
//                    var tasks = new[]
//                    {
//                        Task.Factory.StartNew(() => cellInfoCalculator(0, rowCount / 4)),
//                        Task.Factory.StartNew(() => cellInfoCalculator(rowCount / 4, rowCount / 2)),
//                        Task.Factory.StartNew(() => cellInfoCalculator(rowCount / 2, 3 * rowCount / 4)),
//                        Task.Factory.StartNew(() => cellInfoCalculator(3 * rowCount / 4, rowCount)),
//                    };
//                    Task.WaitAll(tasks);
//                }
//                else
//                {
//                    cellInfoCalculator(0, rowCount);
//                }
//                Dictionary<string, CustomSummaryType> summaryTypes =
//                    m_PivotGridView.DataAreaFields.ToDictionary(field => field.FieldName, field => field.CustomSummaryType);
//
//                dataSource.BeginLoadData();
//                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
//                {
//                    DataRow dataRow = dataSource.NewRow();
//                    bool isRowAreaCreated = false;
//                    for (int columnIndex = 0; columnIndex < m_PivotGridView.Cells.ColumnCount; columnIndex++)
//                    {
//                        var avrCellInfo = infoDictionary[rowIndex, columnIndex];
//                        if (avrCellInfo != null && avrCellInfo.Info != null)
//                        {
//                            if (!isRowAreaCreated && m_PivotGridView.RowAreaFields.Count > 0)
//                            {
//                                isRowAreaCreated = CreateRowAreaCells(view, avrCellInfo.Info, m_PivotGridView.RowAreaFields, dataRow);
//                            }
//
//                            int currentRowIndex = m_PivotGridView.RowAreaFields.Count + columnIndex;
//
//                            CreateDataAreaCell(dataRow, currentRowIndex, avrCellInfo, summaryTypes);
//                        }
//                    }
//                    dataSource.Rows.Add(dataRow);
//                }
//                dataSource.EndLoadData();
//                dataSource.AcceptChanges();
//            }
//        }
        private void FillViewDataSource(AvrView view, DataTable dataSource)
        {
            if (m_PivotGridView.Cells.RowCount > 0)
            {
                Dictionary<string, CustomSummaryType> summaryTypes =
                    m_PivotGridView.DataAreaFields.ToDictionary(field => field.FieldName, field => field.CustomSummaryType);

                dataSource.BeginLoadData();
                for (int rowIndex = 0; rowIndex < m_PivotGridView.Cells.RowCount; rowIndex++)
                {
                    DataRow dataRow = dataSource.NewRow();
                    bool isRowAreaCreated = false;
                    for (int columnIndex = 0; columnIndex < m_PivotGridView.Cells.ColumnCount; columnIndex++)
                    {
                        PivotCellEventArgs cellInfo = m_PivotGridView.Cells.GetCellInfo(columnIndex, rowIndex);

                        if (cellInfo != null)
                        {
                            if (!isRowAreaCreated && m_PivotGridView.RowAreaFields.Count > 0)
                            {
                                isRowAreaCreated = CreateRowAreaCells(view, cellInfo, m_PivotGridView.RowAreaFields, dataRow);
                            }

                            int currentRowIndex = m_PivotGridView.RowAreaFields.Count + columnIndex;

                            CreateDataAreaCell(dataRow, currentRowIndex, cellInfo, summaryTypes);
                        }
                    }
                    dataSource.Rows.Add(dataRow);
                }
                dataSource.EndLoadData();
                dataSource.AcceptChanges();
            }
        }

        private bool CreateRowAreaCells
            (AvrView view, PivotCellEventArgs cellInfo, List<IAvrPivotGridField> avrRowFields, DataRow dataRow)
        {
            var infoRowFields = cellInfo.GetRowFields();

            bool result = infoRowFields.Length > 0;
            if (result)
            {
                int totalIndex = 0;
                if (cellInfo.RowValueType == PivotGridValueType.Value)
                {
                    totalIndex = infoRowFields.Length;
                }
                else if (cellInfo.RowField != null)
                {
                    totalIndex = cellInfo.RowField.AreaIndex;
                }

                for (int i = 0; i < infoRowFields.Length; i++)
                {
                    var rowField = infoRowFields[i];
                    object rowAreaValue = (i < totalIndex + 1)
                        ? cellInfo.GetFieldValue(rowField)
                        : string.Empty;
                    var avrField = avrRowFields.Find(f => f.Name == rowField.Name);
                    if (avrField != null)
                    {
                        if (rowAreaValue == null
                            && BaseSettings.ShowAvrAsterisk
                            && cellInfo.RowValueType == PivotGridValueType.Value)
                        {
                            rowAreaValue = BaseSettings.Asterisk;
                        }

                        var displayTextArgs = new InternalPivotCellDisplayTextEventArgs(rowAreaValue, avrField, false);
                        m_PivotGridView.DisplayTextHandler.DisplayCellText(displayTextArgs, CustomSummaryType.Max, -1);
                        dataRow[i] = displayTextArgs.DisplayText;
                    }
                }

                if (cellInfo.RowValueType != PivotGridValueType.Value)
                {
                    dataRow[totalIndex] += view.TotalSuffix;
                }
            }
            else if (cellInfo.RowValueType == PivotGridValueType.GrandTotal)
            {
                dataRow[0] = view.GrandTotalSuffix;
            }
            return result;
        }

        private static void CreateDataAreaCell
            (DataRow dataRow, int currentRowIndex, PivotCellEventArgs cellInfo, Dictionary<string, CustomSummaryType> summaryTypes)
        {
            object resultVal;
            PivotGridField field = cellInfo.DataField;
            var cellVal = cellInfo.Value;
            if (cellVal != null)
            {
                resultVal = cellVal;
                var avrField = field as IAvrPivotGridField;
                if (avrField != null && avrField.GisReferenceTypeId != null && summaryTypes.ContainsKey(avrField.FieldName))
                {
                    CustomSummaryType summaryType = summaryTypes[avrField.FieldName];
                    if (summaryType.IsMinMax())
                    {
                        resultVal = AvrViewHelper.RemoveHasc(resultVal);
                    }
                }
            }
            else
            {
                resultVal = DBNull.Value;
                CustomSummaryType summaryType;
                if (field != null && summaryTypes.TryGetValue(field.FieldName, out summaryType))
                {
                    if (!summaryType.IsMinMax() && !summaryType.IsAdmUnitOrGender())
                    {
                        resultVal = 0;
                    }
                }
            }

            dataRow[currentRowIndex] = resultVal;
        }

        internal AvrViewBand CreateViewBand(AvrViewBand parentBand, PivotFieldValueItem item)
        {
            Utils.CheckNotNull(item, "item");

            string bandName = GetBandName(item);
            string fieldName = GetFieldName(item);
            int width = GetBandWidth(item);
            AvrViewBand band = CreateViewBandInternal(bandName, fieldName, item.DisplayText, width);
            if (parentBand != null)
            {
                band.IsAdministrativeUnit = parentBand.IsAdministrativeUnit;
                band.MapDisplayOrder = parentBand.MapDisplayOrder;
                band.IsRowArea = parentBand.IsRowArea;
            }
            return band;
        }

        private AvrViewBand CreateViewBandInternal(string bandName, string fieldName, string caption, int width)
        {
            long bandId = AvrPivotGridFieldHelper.GetIdFromFieldName(bandName);
            string bandAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(bandName);

            long fieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
            string fieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
            int? presicion = GetPrecisionByName(fieldName);
            var band = new AvrViewBand(bandId, bandAlias, caption, width, presicion)
            {
                LayoutChildSearchFieldId = fieldId,
                LayoutChildSearchFieldName = fieldAlias,
            };

            return band;
        }

        internal AvrViewColumn CreateViewColumn(AvrViewBand parentBand, PivotFieldValueItem item)
        {
            Utils.CheckNotNull(item, "item");
            string fieldName = GetFieldName(item);
            int width = GetFieldWidth(item);

            AvrViewColumn column = CreateViewColumnInternal(fieldName, item.DisplayText, width);
            if (parentBand != null)
            {
                column.IsAdministrativeUnit = parentBand.IsAdministrativeUnit;
                column.MapDisplayOrder = parentBand.MapDisplayOrder;
                column.IsRowArea = parentBand.IsRowArea;
            }

            return column;
        }

        private AvrViewColumn CreateViewColumnInternal(string fieldName, string caption, int width)
        {
            long fieldId = AvrPivotGridFieldHelper.GetIdFromFieldName(fieldName);
            string fieldAlias = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(fieldName);
            int? presicion = GetPrecisionByName(fieldName);
            var column = new AvrViewColumn(fieldId, fieldAlias, caption, width, presicion);

            return column;
        }

        private int? GetPrecisionByName(string fieldName)
        {
            var field = m_PivotGridView.BaseFields.GetFieldByName("field" + fieldName) as IAvrPivotGridField;

            int? presicion = (field == null || field.IsDateTimeField)
                ? null
                : field.Precision;
            return presicion;
        }

        private long? GetGisReferenceTypeId(PivotFieldItemBase field)
        {
            if (field != null)
            {
                var avrField = m_PivotGridView.BaseFields.GetFieldByName("field" + field.FieldName) as IAvrPivotGridField;
                if (avrField != null)
                {
                    return avrField.GisReferenceTypeId;
                }
            }
            return null;
        }

        internal static int GetFieldWidth(PivotFieldValueItem item)
        {
            PivotFieldItemBase field = GetCorrespondingField(item, true);
            return field == null
                ? AvrView.DefaultFieldWidth
                : field.Width;
        }

        internal static int GetBandWidth(PivotFieldValueItem item)
        {
            PivotFieldItemBase field = GetCorrespondingField(item, false);
            return field == null
                ? AvrView.DefaultFieldWidth
                : field.Width;
        }

        internal static string GetFieldName(PivotFieldValueItem item)
        {
            return GetName(item, true);
        }

        internal static string GetBandName(PivotFieldValueItem item)
        {
            return GetName(item, false);
        }

        private static string GetName(PivotFieldValueItem item, bool isColumn)
        {
            PivotFieldItemBase field = GetCorrespondingField(item, isColumn);
            return field == null
                ? string.Empty
                : field.FieldName;
        }

        private static PivotFieldItemBase GetCorrespondingField(PivotFieldValueItem item, bool isColumn)
        {
            Utils.CheckNotNull(item, "item");
            PivotFieldItemBase primaryField = isColumn ? item.DataField : item.ColumnField;
            PivotFieldItemBase secondaryField = isColumn ? item.ColumnField : item.DataField;

            PivotFieldItemBase field = null;
            if (primaryField != null)
            {
                field = primaryField;
            }
            else if (secondaryField != null)
            {
                field = secondaryField;
            }
            return field;
        }

        internal static void AddColumnsToEmptyBands(IEnumerable<AvrViewBand> avrViewBands)
        {
            foreach (AvrViewBand band in avrViewBands)
            {
                if (band.Bands.Count == 0 && band.Columns.Count == 0)
                {
                    var column = new AvrViewColumn(band.LayoutChildSearchFieldId, band.LayoutChildSearchFieldName,
                        String.Empty, band.ColumnWidth, band.Precision)
                    {
                        IsAdministrativeUnit = band.IsAdministrativeUnit,
                        MapDisplayOrder = band.MapDisplayOrder,
                        IsRowArea = band.IsRowArea,
                    };
                    band.Columns.Add(column);
                }
                else
                {
                    AddColumnsToEmptyBands(band.Bands);
                }
            }
        }

        #endregion

        #region Pivot Captions

        /// <summary>
        ///     Init captions given from data columns of data table
        /// </summary>
        public void InitPivotCaptions(AvrDataTable data)
        {
            m_CaptionDictionary = new Dictionary<string, string>();
            foreach (AvrDataColumn column in data.Columns)
            {
                m_CaptionDictionary.Add(column.ColumnName, column.Caption);
            }
        }

        /// <summary>
        ///     Update captions given from internal dictionary of fields of pivot grid
        /// </summary>
        public void UpdatePivotCaptions()
        {
            if (m_CaptionDictionary == null)
            {
                return;
            }

            using (m_PivotGridView.BeginTransaction())
            {
                foreach (PivotGridField field in m_PivotGridView.BaseFields)
                {
                    if (!m_CaptionDictionary.ContainsKey(field.FieldName))
                    {
                        throw new AvrException("Pivot caption dictionary  doesn't contains field " + field.FieldName);
                    }
                    field.Caption = m_CaptionDictionary[field.FieldName];
                }
            }
        }

        #endregion
    }
}