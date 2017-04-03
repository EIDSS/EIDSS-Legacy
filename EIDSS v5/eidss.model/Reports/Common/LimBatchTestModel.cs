using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class LimBatchTestModel : BaseIdModel
    {
        public LimBatchTestModel(string language, long id, long typeId, bool useArchive)
            : base(language, id, useArchive)
        {
            TypeId = typeId;
        }

        public long TypeId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, TypeId={1}", base.ToString(), TypeId);
        }

    }
}