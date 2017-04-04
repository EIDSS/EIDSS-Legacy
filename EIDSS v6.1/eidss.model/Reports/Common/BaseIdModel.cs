using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseIdModel : BaseModel
    {
        public BaseIdModel(string language, long id, bool useArchive)
            : base(language, useArchive)
        {
            Id = id;
        }

        public long Id { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Id={0}",  Id);
        }
    }
}