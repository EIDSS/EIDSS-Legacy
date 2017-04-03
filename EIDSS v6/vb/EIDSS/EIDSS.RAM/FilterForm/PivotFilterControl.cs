using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr.db.Common;
using EIDSS.Enums;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.avr.PivotComponents;
using eidss.avr.QueryBuilder;

namespace eidss.avr.FilterForm
{
    class PivotFilterControl : FilterControlBase
    {
        private AvrPivotGrid m_PivotGrid;
        public PivotFilterControl()
        {

        }

        public PivotFilterControl(AvrPivotGrid pivotGrid, bool createEditors, CriteriaOperator filterCriteria = null)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            InitPivotFilter(pivotGrid, createEditors, filterCriteria);
        }

        public void InitPivotFilter(AvrPivotGrid pivotGrid, bool createEditors, CriteriaOperator filterCriteria = null)
        {
            Init();
            FilterChanged += FilterChangedHandler;

            //take filter from parameter if it passed. Owerwithe teke it from pivot grid
            //FilterCriteria = filterCriteria ?? pivotGrid.Criteria;

            m_PivotGrid = pivotGrid;
            BindPivotGrid(pivotGrid, createEditors);


            //important! - exsting pivot grid filter criteria is displayed incorrectly if binding
            //is applied over it.
            //We must save filter criteria and apply it explictly after binding pivot grid columns
            //to display filter criteria correctly
           // FilterCriteria = FilterCriteria;
            FilterCriteria = filterCriteria ?? pivotGrid.Criteria;


            // disable control if no pivotgrid fields bound
            //ProcessEnablingFor(this);

        }
        protected override void Dispose(bool disposing)
        {
            FilterChanged -= FilterChangedHandler;
            base.Dispose(disposing);
        }
        protected override WinFilterTreeNodeModel CreateModel()
        {
            return new PivotFilterControlModel(this);
        }

        private void BindPivotGrid(AvrPivotGrid pivotGrid, bool createEditors)
        {
            //SourceControl = pivotGrid;
            using (pivotGrid.BeginTransaction())
            {
                m_FieldInfo.Clear();
                var columns = new DataColumnInfoFilterColumnCollection(null);
                int i = 1;
                var processedFieldNames = new List<string>();
                foreach (IAvrPivotGridField field in pivotGrid.AvrFields)
                {
                    //do not process non-filter fields
                    if (!field.IsHiddenFilterField)
                        continue;
                    //do not process fields copies
                    if (processedFieldNames.Contains(field.Name))
                        continue;
                    processedFieldNames.Add(field.Name);

                    var column = CreatePivotGridColumn(i++, field, createEditors);
                    columns.Add(column);
                }
                // ???
                DeleteNodesWithAbsentFields();
                SetFilterColumnsCollection(columns);
                Enabled = FilterColumns.Count > 0;
            }
        }
        private UnboundQueryFilterColumn CreatePivotGridColumn
            (int conditionID, IAvrPivotGridField field, bool createEditors)
        {
            string fieldName = field.Name;

            DataRow fieldRow;
            DataRow paramRow = null;
            SearchFieldType fieldType;
            string caption = field.Caption;
            int pos = fieldName.IndexOf("__", StringComparison.Ordinal);
            if (pos > 0)
            {
                string[] fieldParts = field.GetOriginalName().Split(new[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
                int i = m_SearchFieldsLookupView.Find(fieldParts[0]);
                Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
                paramRow = LookupCache.GetLookupRow(field.GetOriginalName(), LookupTables.ParameterForFFType.ToString());
                object paramType = paramRow["idfsParameterType"];
                object referenceType = paramRow["idfsReferenceType"];
                // Commented because now caption should be taken directrly from the field caption 
                //  caption = Utils.Str(paramRow["ParameterName"]);
                fieldType = !Utils.IsEmpty(referenceType)
                                ? SearchFieldType.ID
                                : ParamType2FieldType(paramType);
                fieldRow = m_SearchFieldsLookupView[i].Row;
            }
            else
            {
                int i = m_SearchFieldsLookupView.Find(field.GetOriginalName());
                Dbg.Assert(i >= 0, "search field with alias {0} is not found in lookup table", fieldName);
                fieldRow = m_SearchFieldsLookupView[i].Row;
                // Commented because now caption should be taken directrly from the field caption 
                //caption = Utils.Str(fieldRow["FieldCaption"]);
                if (IsLookupField(fieldRow))
                {
                    fieldType = SearchFieldType.ID;
                }
                else
                {
                    fieldType = (SearchFieldType)fieldRow["idfsSearchFieldType"];
                    // commented because calendar editor should be used for all datetime fields
                    //                    if (fieldType == SearchFieldType.Date && interval != PivotGroupInterval.Date)
                    //                    {
                    //                        fieldType = interval == PivotGroupInterval.DateDayOfWeek
                    //                                        ? SearchFieldType.String
                    //                                        : SearchFieldType.Integer;
                    //                    }
                }
            }

            m_FieldInfo.Add(fieldName, new FilterFieldInfo(conditionID, caption, null));

            UnboundPivotGridColumn col;

            if (fieldType == SearchFieldType.Date) //field.DataType.Equals(typeof(DateTime))
            {
                col = new UnboundPivotGridColumn(caption, fieldName, typeof(DateTime), DefaultDateEditor,
                                                 FilterColumnClauseClass.DateTime);
            }
            else
            {
                if (fieldType == SearchFieldType.ID)
                {
                    var cb = new RepositoryItem();
                    if (createEditors)
                    {
                        cb = (paramRow != null)
                                 ? GetFFFieldEditor(paramRow, fieldRow, out fieldType)
                                 : GetLookupEditor(fieldRow, GetValueMemberForBaseLookup());
                    }
                    col = new UnboundPivotGridColumn(caption, fieldName, field.DataType, cb,
                                                     FilterColumnClauseClass.Lookup);
                }
                else
                {
                    var cb = new RepositoryItemTextEdit();
                    col = new UnboundPivotGridColumn(caption, fieldName, field.DataType, cb,
                                                               FilterColumnClauseClass.String);
                    // Note: Commented by Ivan to change lookup edit to text edit for  all text fields 
                    //                    var cb = new RepositoryItemComboBox();
                    //                    if (createEditors)
                    //                    {
                    //                        field.FilterValues.FilterType = PivotFilterType.Included;
                    //                        field.FilterValues.FilterType = PivotFilterType.Excluded;
                    //
                    //                        string key = queryId.HasValue
                    //                                         ? queryId.Value.ToString(CultureInfo.InvariantCulture)
                    //                                         : string.Empty;
                    //                        key = key + RamPivotGridHelper.GetOriginalNameFromFieldName(field.FieldName);
                    //
                    //                        if (!ValueHash.ContainsKey(key))
                    //                        {
                    //                            ValueHash[key] = field.FilterValues.ValuesIncluded;
                    //                        }
                    //                        cb.Items.AddRange(ValueHash[key]);
                    //
                    //                    }
                    //                    col = new UnboundPivotGridColumn(caption, fieldName, SearchFieldType2Type(fieldType), cb,
                    //                                                     FilterColumnClauseClass.Generic);
                }
            }
            return col;
        }
        public static string GetFilterTextForPivotGrid(AvrPivotGrid grid, CriteriaOperator criteria)
        {
            using (var filter = new PivotFilterControl(grid, false))
            {
                return filter.GetFilterText(criteria, null, Environment.NewLine);
            }
        }

        public static bool CheckPivotGridPrefilter(AvrPivotGrid grid)
        {
            using (var filter = new PivotFilterControl(grid, false))
            {
                filter.RefreshNodes();

                if (filter.FilterString != grid.CriteriaString)
                {
                    grid.Criteria = filter.FilterCriteria;
                    return true;
                }
            }
            return false;
        }
        protected override string GetOperandPropertyText(OperandProperty op)
        {
            string caption = op.PropertyName;
            PivotGridField field = GetPivotGridField((SourceControl as PivotGridControl), caption);
            if (field != null)
            {
                caption = field.Caption;

            }
            return string.Format("[{0}]", caption);
        }

        protected override string GetValueMemberForSpecialLookup(string type)
        {
            switch (type)
            {
                case "Country":
                case "Region":
                case "Rayon":
                case "Settlement":
                    return "ExtendedName";

                case "Site":
                    return "strSiteName";
                case "AccessoryCode":
                    return "CodeName";
                default:
                    return "name";

            }
        }

        protected override string GetValueMemberForBaseLookup()
        {
            return "name";
        }

        protected override string GetValueMemberForFFFixedPresetValue()
        {
            return "NationalName";
        }
        private static PivotGridField GetPivotGridField(PivotGridControl grid, string fieldName)
        {
            var field = grid.Fields.GetFieldByName(fieldName);
            if (field == null && fieldName.StartsWith("field"))
            {
                field = grid.Fields.GetFieldByName(fieldName.Substring("field".Length));
            }
            return field;
        }
        private static IAvrPivotGridField GetWinPivotGridField(PivotGridControl grid, string fieldName)
        {
            return (IAvrPivotGridField)GetPivotGridField(grid, fieldName);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }


    }
}
