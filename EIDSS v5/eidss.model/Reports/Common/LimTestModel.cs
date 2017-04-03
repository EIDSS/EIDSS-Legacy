using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class LimTestModel : BaseIdModel
    {
        public LimTestModel(string language, long id, bool isHuman, bool useArchive)
            : base(language, id, useArchive)
        {
            IsHuman = isHuman;
        }

        public bool IsHuman { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, IsHuman={1}", base.ToString(), IsHuman);
        }
    }
}