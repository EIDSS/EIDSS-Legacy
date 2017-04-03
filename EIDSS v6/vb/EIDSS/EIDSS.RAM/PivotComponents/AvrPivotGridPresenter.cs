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
using eidss.avr.Tools;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;

namespace eidss.avr.PivotComponents
{
    public class AvrPivotGridPresenter : BaseAvrPresenter
    {
        private IAvrPivotGridView m_PivotGridView;
        private Dictionary<string, string> m_CaptionDictionary;
        private DistinctCounter m_DistinctCounter;

        public AvrPivotGridPresenter(SharedPresenter sharedPresenter, IAvrPivotGridView view)
            : base(sharedPresenter)
        {
            m_PivotGridView = view;

            DistinctCounter = new DistinctCounter();
        }

        public DistinctCounter DistinctCounter
        {
            get { return m_DistinctCounter; }
            set
            {
                if (m_DistinctCounter != null)
                {
                    m_DistinctCounter.Dispose();
                }
                m_DistinctCounter = value;
            }
        }

        public override void Process(Command cmd)
        {
        }

        public override void Dispose()
        {
            try
            {
                m_PivotGridView = null;
                DistinctCounter = null;
            }
            finally
            {
                base.Dispose();
            }
        }

        #region Prepare Avr View Data

        public PivotGridDataLoadedCommand CreatePivotDataLoadedCommand(string layoutName, bool skipData = false)
        {
            var view = new AvrView(m_SharedPresenter.SharedModel.SelectedLayoutId, layoutName);
            CreateTotalSuffixForView(view);

            bool isFlat = m_PivotGridView.PivotData.VisualItems.GetLevelCount(true) == 1;

            CreateViewHeaderFromRowArea(view, isFlat);

            CreateViewHeaderFromColumnArea(view, isFlat);

            AddColumnsToEmptyBands(view.Bands);

            view.AssignOwnerAndUniquePath();

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

                if (item.Level == 0)
                {
                    string displayText = item.DisplayText;

                    if (isFlat)
                    {
                        string fieldName = GetFieldName(item);

                        int width = (m_PivotGridView.ColumnAreaFields.Count == 0)
                            ? GetFieldWidth(item)
                            : GetBandWidth(item);

                        AvrViewColumn column = CreateViewColumnInternal(fieldName, displayText, width);

                        view.Columns.Add(column);
                    }
                    else
                    {
                        string bandName = GetBandName(item);
                        string fieldName = GetFieldName(item);
                        int width = GetFieldWidth(item);

                        AvrViewBand band = CreateViewBandInternal(bandName, fieldName, displayText, width);
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
                    band.Columns.Add(childColumn);
                }
            }
        }

        private DataTable CreateViewDataSourceStructure(AvrView view)
        {
            var dataSource = new DataTable("ViewData");
            dataSource.BeginInit();

            var fields = new List<IAvrPivotGridField>();
            fields.AddRange(m_PivotGridView.RowAreaFields);
            fields.AddRange(m_PivotGridView.DataAreaFields);

            List<AvrViewColumn> viewColumns = GetAllViewColumns(view);
            foreach (AvrViewColumn viewColumn in viewColumns)
            {
                Type columnType = GetViewColumnType(viewColumn, fields);

                viewColumn.FieldType = GetViewColumnType(viewColumn, fields);

                DataColumn dataColumn = dataSource.Columns.Add(viewColumn.UniquePath, columnType);
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
            List<AvrViewColumn> viewColumns = GetAllViewColumns(view);
            if (viewColumns.Count - m_PivotGridView.RowAreaFields.Count != m_PivotGridView.Cells.ColumnCount)
            {
                throw new AvrException("Internal Error. DataArea column count isn't equal to RowArea column count.");
            }
        }

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
                            if (!isRowAreaCreated)
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
            (AvrView view, PivotCellEventArgs cellInfo,
                List<IAvrPivotGridField> rowAreaFields, DataRow dataRow)
        {
            PivotDrillDownDataSource drillDown = cellInfo.CreateDrillDownDataSource();
            bool result = drillDown.RowCount > 0;
            if (result)
            {
                int totalIndex = 0;
                if (cellInfo.RowValueType == PivotGridValueType.Value)
                {
                    totalIndex = rowAreaFields.Count;
                }
                else if (cellInfo.RowField != null)
                {
                    totalIndex = cellInfo.RowField.AreaIndex;
                }

                for (int i = 0; i < rowAreaFields.Count; i++)
                {
                    IAvrPivotGridField rowAreaField = rowAreaFields[i];
                    object rowAreaValue = (i < totalIndex + 1)
                        ? drillDown[0][rowAreaField.FieldName]
                        : string.Empty;
                    if (rowAreaValue == null
                        && BaseSettings.ShowAvrAsterisk
                        && cellInfo.RowValueType == PivotGridValueType.Value)
                    {
                        rowAreaValue = BaseSettings.Asterisk;
                    }

                    var displayTextArgs = new InternalPivotCellDisplayTextEventArgs(rowAreaValue, rowAreaField, false);
                    m_PivotGridView.DisplayTextHandler.DisplayCellText(displayTextArgs, CustomSummaryType.Max, -1);

                    dataRow[i] = displayTextArgs.DisplayText;
                }

                if (rowAreaFields.Count > 0)
                {
                    if (cellInfo.RowValueType == PivotGridValueType.GrandTotal)
                    {
                        dataRow[0] = view.GrandTotalSuffix;
                    }
                    else if (cellInfo.RowValueType != PivotGridValueType.Value)
                    {
                        dataRow[totalIndex] += view.TotalSuffix;
                    }
                }
            }
            return result;
        }

        private static void CreateDataAreaCell
            (DataRow dataRow, int currentRowIndex, PivotCellEventArgs cellInfo, Dictionary<string, CustomSummaryType> summaryTypes)
        {
            object value;
            if (cellInfo.Value != null)
            {
                value = cellInfo.Value;
            }
            else
            {
                value = DBNull.Value;
                if (cellInfo.DataField != null && summaryTypes.ContainsKey(cellInfo.DataField.FieldName))
                {
                    CustomSummaryType summaryType = summaryTypes[cellInfo.DataField.FieldName];
                    if (summaryType != CustomSummaryType.Max &&
                        summaryType != CustomSummaryType.Min)
                    {
                        value = 0;
                    }
                }
            }

            dataRow[currentRowIndex] = value;
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

        internal static List<AvrViewColumn> GetAllViewColumns(AvrView view)
        {
            List<AvrViewColumn> viewColumns = (view.Bands.Count == 0)
                ? view.Columns
                : GetAllBandColumns(view.Bands);

            return viewColumns;
        }

        internal static List<AvrViewColumn> GetAllBandColumns(IEnumerable<AvrViewBand> avrViewBands)
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
        public void InitPivotCaptions(DataTable data)
        {
            m_CaptionDictionary = new Dictionary<string, string>();
            foreach (DataColumn column in data.Columns)
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