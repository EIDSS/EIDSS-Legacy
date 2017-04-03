using System;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class VetLabSampleModel : BaseModel
    {
        public VetLabSampleModel()
        {
        }

        public VetLabSampleModel(string language, string sampleId, bool useArchive)
            : base(language, useArchive)
        {
            SampleId = sampleId;
        }

        [LocalizedDisplayName("SampleID")]
        public string SampleId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, sample={1}", base.ToString(), SampleId);
        }
    }
}