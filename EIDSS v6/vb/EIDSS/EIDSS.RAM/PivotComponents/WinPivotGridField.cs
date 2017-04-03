using System;
using System.Collections.Generic;
using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;
using eidss.model.Avr.Pivot;

namespace eidss.avr.PivotComponents
{
    public class WinPivotGridField : PivotGridField, IAvrPivotGridField
    {
        private bool m_IsHiddenFilterField;
        private readonly Dictionary<CustomSummaryType, int> m_PrecisionDictionary = new Dictionary<CustomSummaryType, int>();

        private PivotGroupInterval m_DefaultGroupInterval;
        private PivotGroupInterval? m_PrivateGroupInterval;
        private List<IAvrPivotGridField> m_RelatedFields;

        /// <summary>
        ///     Gets or sets the fields's Name
        ///     DON'T USE IT IN YOUR CODE except single setting when new field creating. Use FieldName instead.
        /// </summary>
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public Type SearchFieldDataType { get; set; }

        public bool IsDateTimeField
        {
            get { return SearchFieldDataType.IsDate(); }
        }

        public bool IsNumeric
        {
            get { return SearchFieldDataType.IsNumeric(); }
        }

        public bool IsHiddenFilterField
        {
            get { return m_IsHiddenFilterField; }
            set
            {
                m_IsHiddenFilterField = value;
                this.OnSetIsHiddenFilterField(value);
            }
        }

     

        public CustomSummaryType CustomSummaryType { get; set; }

        public PivotGroupInterval? PrivateGroupInterval
        {
            get { return m_PrivateGroupInterval; }
            set
            {
                m_PrivateGroupInterval = value;
                this.UpdateGroupInterval();
            }
        }

        public PivotGroupInterval DefaultGroupInterval
        {
            get { return m_DefaultGroupInterval; }
            set
            {
                m_DefaultGroupInterval = value;
                this.UpdateGroupInterval();
            }
        }

        public int? Precision { get; set; }

        public Dictionary<CustomSummaryType, int> PrecisionDictionary
        {
            get { return m_PrecisionDictionary; }
        }

        public bool AllowMissedReferenceValues { get; set; }

        public string LookupTableName { get; set; }
        public long? ReferenceTypeId { get; set; }
        public long? GisReferenceTypeId { get; set; }
        public string LookupAttributeName { get; set; }

        public long AggregateFunctionId { get; set; }
        public string UnitSearchFieldAlias { get; set; }
        public long? UnitLayoutSearchFieldId { get; set; }
        public string DateSearchFieldAlias { get; set; }
        public long? DateLayoutSearchFieldId { get; set; }

        public bool AddMissedValues { get; set; }
        public DateTime? DiapasonStartDate { get; set; }
        public DateTime? DiapasonEndDate { get; set; }

        public List<IAvrPivotGridField> AllPivotFields { get; set; }

        public List<IAvrPivotGridField> RelatedFields
        {
            get { return m_RelatedFields ?? (m_RelatedFields = this.GetRelatedFields()); }
            set { m_RelatedFields = value; }
        }

        public void UpdateImageIndex()
        {
            string suffix = AddMissedValues ? AvrFieldIcons.BorderedImageSuffix : string.Empty;

            ImageIndex = AvrFieldIcons.ImageList.Images.IndexOfKey(SearchFieldDataType + suffix);
        }
    }
}