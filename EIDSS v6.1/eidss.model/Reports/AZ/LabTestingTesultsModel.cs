using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class LabTestingTesultsModel : BaseModel
    {
        public LabTestingTesultsModel()
        {
        }

        public LabTestingTesultsModel(string language, string sampleId, long labDepartmentId, bool useArchive)
            : base(language, useArchive)
        {
            SampleId = sampleId;
            LabDepartmentId = labDepartmentId;
        }

        [LocalizedDisplayName("SampleID")]
        public string SampleId { get; set; }

        [LocalizedDisplayName("strLabDepartment")]
        public long? LabDepartmentId { get; set; }
        public List<SelectListItemSurrogate> DepartmentsList
        {
            get
            {
                if (!string.IsNullOrEmpty(SampleId))
                    return FilterHelper.GetLabSampleDepartments(SampleId, Localizer.CurrentCultureLanguageID);
                return new List<SelectListItemSurrogate>();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, sample={1}, department={2}", base.ToString(), SampleId, LabDepartmentId);
        }
    }
}