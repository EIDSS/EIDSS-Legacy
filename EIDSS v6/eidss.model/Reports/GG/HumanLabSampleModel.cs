using System;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class HumanLabSampleModel : BaseModel
    {
        public HumanLabSampleModel()
        {
        }

        public HumanLabSampleModel(string language, string sampleId, string firstName, string lastName, bool useArchive)
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

        public override string ToString()
        {
            return string.Format("{0}, sample={1}, First Name={2}, Last Name={3}",
                base.ToString(), SampleId, FirstName, LastName);
        }
    }
}