using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Common
{
    public interface IAvrPivotGridField
    {
        [Description("Gets unique identifier of the field given from the database")]
        long FieldId { get; }
        
        [Description("Gets or sets the name of the database field that is assigned to the current field object.")]
        string FieldName { get; set; }

        [Description("Gets the original name (alias) of the database search field that is assigned to the current field object. Different fields may have the same alias")]
        string OriginalFieldName { get; }

        [Description("Gets or sets the field\'s display caption.")]
        string Caption { get; set; }

        [Description("Gets or sets the field\'s name. " +
                     "DON'T USE IT IN YOUR CODE except single setting when new field creating. Use FieldName instead.")]
        string Name { get; set; }

        [Description("Gets or sets the search field\'s data type. It's not the same as field data time. " +
                     "Example: for DateTime field with month groupping has SearchFieldDataType=typeof(DateTime), " +
                     "but field data type = typeof(string) (January, February..)")]
        Type SearchFieldDataType { get; set; }

        [Description("Gets or sets whether the field is visible.")]
        bool Visible { get; set; }


        [Description("Gets or sets whether the field belongs to the hidden Filter Area.")]
        bool IsHiddenFilterField { get; set; }

        [Description("Gets whether the field contains DateTime data")]
        bool IsDateTimeField { get; }

        [Description("Gets or sets the type of the PivotGridFieldBase summary function " +
                     "which is calculated against the current data field.")]
        PivotSummaryType SummaryType { set; get; }

        [Description("Gets or sets the type of the custom summary function which is calculated against the current data field.")]
        CustomSummaryType CustomSummaryType { get; set; }

        [Description("Gets or sets how a summary value calculated against the current data field is represented in a cell.")]
        PivotSummaryDisplayType SummaryDisplayType { set; get; }

        [Description("Gets or sets the area in which the field is displayed.")]
        PivotArea Area { set; get; }

        [Description("Gets or sets the field's index from among the other fields displayed within the same area.")]
        int AreaIndex { set; get; }

        [Description("Gets or sets the areas within which the field can be positioned.")]
        PivotGridAllowedAreas AllowedAreas { set; get; }

        [Description("Gets or sets the width of columns that correspond to the current field.")]
        int Width { set; get; }

        [Description("Gets or sets the field's sort order.")]
        PivotSortOrder SortOrder { set; get; }
        
        [Description("Gets or sets how the field's data is sorted when sorting is applied to it.")]
        PivotSortMode SortMode { set; get; }

        [Description("Gets or sets filter values for the current field.")]
        PivotGridFieldFilterValues FilterValues { set; get; }

        [Description("Gets or sets whether to use the current field's data format when the Pivot Grid Control is exported in XLS format.")]
        DefaultBoolean UseNativeFormat { set; get; }

        [Description("Provides access to the formatting settings applied to cells.")]
        FormatInfo CellFormat { get; }

        [Description("Gets the field's data type.")]
        Type DataType { get; }

        [Description("Gets or sets how the values of the current column or row field are combined into groups." +
                     " It's PivotGridFieldBase property")]
        PivotGroupInterval GroupInterval { set; get; }

        [Description("Gets or sets how the values of the current column or row field are combined into groups." +
                     " It's individual property for the field.")]
        PivotGroupInterval? PrivateGroupInterval { set; get; }

        [Description("Gets or sets how the values of the current column or row field are combined into groups by default, " +
                     "if PrivateGroupInterval is not set.")]
        PivotGroupInterval DefaultGroupInterval { set; get; }

        int Ordinal { get; set; }

        Dictionary<CustomSummaryType, int> PrecisionDictionary { get; }

        int? Precision { get; set; }

        bool AllowMissedReferenceValues { get; set; }

        string LookupTableName { get; set; }
        long? ReferenceTypeId { get; set; }
        long? GisReferenceTypeId { get; set; }

        long AggregateFunctionId { get; set; }
        long BasicCountFunctionId { get; set; }
        string UnitSearchFieldAlias { get; set; }
        long ?UnitLayoutSearchFieldId { get; set; }
        string DateSearchFieldAlias { get; set; }
        long ?DateLayoutSearchFieldId { get; set; }

        string LookupAttributeName { get; set; }

        int? HaCode { get; set; }

        bool AddMissedValues { get; set; }

        DateTime? DiapasonStartDate { get; set; }
        DateTime? DiapasonEndDate { get; set; }

        bool IsNumeric { get; }

        List<IAvrPivotGridField> AllPivotFields { get; set; }
        Dictionary<string, List<IAvrPivotGridField>> FieldNamesDictionary { get; set; }
        List<IAvrPivotGridField> RelatedFields { get; }
        List<IAvrPivotGridField> LinkedFields { get; }
        List<AvrRelatedFieldAttributes> RelatedFieldAttributes { get; }
     

        void UpdateImageIndex();
    }
}