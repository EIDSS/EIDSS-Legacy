using System;
using System.Collections.Generic;
using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;

namespace eidss.avr.PivotComponents
{
    public class WinPivotGridField : PivotGridField, IAvrPivotGridField
    {
        private bool m_IsHiddenFilterField;
        private readonly Dictionary<CustomSummaryType, int> m_PrecisionDictionary = new Dictionary<CustomSummaryType, int>();

        private PivotGroupInterval m_DefaultGroupInterval;
        private PivotGroupInterval? m_PrivateGroupInterval;
        private List<IAvrPivotGridField> m_RelatedFields;
        private List<IAvrPivotGridField> m_LinkedFields;
        private List<AvrRelatedFieldAttributes> m_RelatedFieldAttributes;
        private Type m_SearchFieldDataType;
        private long m_FieldId=-1;
        private string m_OriginalFieldName;

        public long FieldId
        {
            get
            {
                if (m_FieldId <= 0)
                {
                    m_FieldId= AvrPivotGridFieldHelper.GetIdFromFieldName(FieldName);
                }
                return m_FieldId; 
            }
        }

        public string OriginalFieldName
        {
            get
            {
                if (Utils.IsEmpty(m_OriginalFieldName))
                {
                    m_OriginalFieldName = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(FieldName);
                }
                return m_OriginalFieldName;
            }
        }

        public override string FieldName
        {
            get { return base.FieldName; }
            set
            {
                base.FieldName = value;
                m_FieldId = -1;
                m_OriginalFieldName = null;
            }
        }

        /// <summary>
        ///     Gets or sets the fields's Name
        ///     DON'T USE IT IN YOUR CODE except single setting when new field creating. Use FieldName instead.
        /// </summary>
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public Type SearchFieldDataType
        {
            get { return m_SearchFieldDataType; }
            set
            {
                m_SearchFieldDataType = value;
                this.UpdateSearchFieldDataType();
            }
        }

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

        public int Ordinal { get; set; }

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
        public int? HaCode { get; set; }

        public long AggregateFunctionId { get; set; }
        public long BasicCountFunctionId { get; set; }
        public string UnitSearchFieldAlias { get; set; }
        public long? UnitLayoutSearchFieldId { get; set; }
        public string DateSearchFieldAlias { get; set; }
        public long? DateLayoutSearchFieldId { get; set; }

        public bool AddMissedValues { get; set; }
        public DateTime? DiapasonStartDate { get; set; }
        public DateTime? DiapasonEndDate { get; set; }

        public List<IAvrPivotGridField> AllPivotFields { get; set; }

        public Dictionary<string, List<IAvrPivotGridField>> FieldNamesDictionary { get; set; }

        public List<IAvrPivotGridField> RelatedFields
        {
            get { return m_RelatedFields ?? (m_RelatedFields = this.GetRelatedFields(true)); }
            internal set { m_RelatedFields = value; }
        }

        public List<IAvrPivotGridField> LinkedFields
        {
            get { return m_LinkedFields ?? (m_LinkedFields = this.GetRelatedFields(false)); }
        }

        public List<AvrRelatedFieldAttributes> RelatedFieldAttributes
        {
            get { return m_RelatedFieldAttributes ?? (m_RelatedFieldAttributes = this.GetRelatedFieldAttributes()); }
        }

        public void UpdateImageIndex()
        {
            string suffix = AddMissedValues ? AvrFieldIcons.BorderedImageSuffix : string.Empty;

            ImageIndex = AvrFieldIcons.ImageList.Images.IndexOfKey(SearchFieldDataType + suffix);
        }
    }
}