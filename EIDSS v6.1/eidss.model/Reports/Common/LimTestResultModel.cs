using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class LimTestResultModel : BaseIdModel
    {
        public LimTestResultModel(string language, long id, long csId, long typeId, bool useArchive)
            : base(language, id, useArchive)
        {
            CsId = csId;
            TypeId = typeId;
        }

        public long CsId { get; set; }
        public long TypeId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, TypeId={1}, CsId={2}", base.ToString(), TypeId, CsId);
        }
    }
}