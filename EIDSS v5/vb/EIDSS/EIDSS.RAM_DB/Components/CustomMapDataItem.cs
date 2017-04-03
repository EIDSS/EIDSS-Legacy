using System.Collections.Generic;
using System.Text;
using bv.common.Enums;

namespace EIDSS.RAM_DB.Components
{
    public class CustomMapDataItem
    {
        private readonly List<string> m_CaptionList = new List<string>();

        public CustomMapDataItem(double value, GisCaseType gisCaseType)
        {
            Value = value;
            GisCaseType = gisCaseType;
        }

        public CustomMapDataItem(double value, GisCaseType gisCaseType, string gisReferenceName)
        {
            Value = value;
            GisCaseType = gisCaseType;
            GisReferenceName = gisReferenceName;
        }

        public double Value { get; set; }
        public GisCaseType GisCaseType { get; set; }
        public string GisReferenceName { get; set; }

        public List<string> CaptionList
        {
            get { return m_CaptionList; }
        }

        public string TotalCaption
        {
            get
            {
                CaptionList.Sort();
                var captionBuilder = new StringBuilder();
                captionBuilder.AppendLine();
                foreach (string id in CaptionList)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        captionBuilder.AppendLine(id);
                    }
                }
                return captionBuilder.ToString();
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}