using DevExpress.XtraEditors.Controls;
using bv.common.Resources;

namespace bv.winclient.Core
{
    public class BvLookupColumnInfo : LookUpColumnInfo
    {
        public string ResourceKey { get; set; }
        public static BaseStringsStorage Messages { get; set; }
        public BvLookupColumnInfo(string fieldName, string caption, int width, DevExpress.Utils.FormatType formatType, string formatString, bool visible, DevExpress.Utils.HorzAlignment alignment)
            : base(fieldName, caption, width, formatType, formatString, visible, alignment)
        {
            Init(caption);
        }
        public BvLookupColumnInfo(string fieldName, string caption, int width)
            : base(fieldName, caption, width)
        {
            Init(caption);
        }

        private void Init(string caption)
        {
            if (Messages != null)
            {
                ResourceKey = caption;
                Caption = Messages.GetString(ResourceKey);
            }
        }
    }
}
