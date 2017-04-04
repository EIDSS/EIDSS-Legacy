using System.Data;
using bv.common;
using bv.common.Core;
using EIDSS.FlexibleForms.DataBase;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems
{
    /// <summary>
    /// Item represents table Flex form section including all inner sections
    /// </summary>
    public class FlexTableItem : FlexItem
    {
        private DataTable mBodyData;
        private readonly string mText;

        public DataTable BodyData
        {
            get { return mBodyData; }
            set { mBodyData = value; }
        }

        public string Text
        {
            get { return mText; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        internal FlexTableItem(FlexibleFormsDS.SectionTemplateRow row)
        {
            Height = row.IsintHeightNull() ? 0 : row.intHeight;
            Width = row.IsintWidthNull() ? 0 : row.intWidth;
            Top = row.IsintTopNull() ? 0 : row.intTop;
            Left = row.IsintLeftNull() ? 0 : row.intLeft;
            Order = row.IsintOrderNull() ? 0 : row.intOrder;
            LinkedObject = row;

            mText = Utils.IsEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }
    }
}