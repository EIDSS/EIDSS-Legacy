using System;
using System.Text;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class IdListModel : BaseModel
    {
        public IdListModel(string language, long[] idList, bool useArchive)
            : base(language, useArchive)
        {
            IdList = idList;
        }

        public long[] IdList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            foreach (long id in IdList)
            {
                sb.AppendFormat(" Id={0}", id);
            }
            return sb.ToString();
        }
    }
}