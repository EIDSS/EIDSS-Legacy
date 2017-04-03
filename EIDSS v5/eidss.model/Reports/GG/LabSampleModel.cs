using System;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class LabSampleModel : BaseModel
    {
        public LabSampleModel()
        {
        }

        public LabSampleModel(string language, string sampleId, string firstName, string lastName, bool useArchive)
            : base(language, useArchive)
        {
            SampleId = sampleId;
            FirstName = firstName;
            LastName = lastName;
        }

        [LocalizedDisplayName("SampleID")]
        public string SampleId { get; set; }

        [LocalizedDisplayName("strFirstName")]
        public string FirstName { get; set; }

        [LocalizedDisplayName("strLastName")]
        public string LastName { get; set; }
    }
}