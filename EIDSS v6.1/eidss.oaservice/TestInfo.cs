using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eidss.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;


namespace EIDSS.Web
{
    public class TestInfo
    {
        [XmlIgnore]
        [FieldName("idfTesting")]
        public long Id { get; set; }
        [FieldName("idfsTestName")]
        public BaseReferenceItem Type { get; set; }
        [FieldName("strBarcode")]
        public string SampleID { get; set; }
        [FieldName("idfsTestCategory")]
        public BaseReferenceItem Category { get; set; }
        [FieldName("idfsDiagnosis")]
        public BaseReferenceItem Diagnosis { get; set; }
        [FieldName("idfsTestStatus")]
        public BaseReferenceItem Status { get; set; }
        [FieldName("idfsTestResult")]
        public BaseReferenceItem Result { get; set; }
        [FieldName("datPerformedDate")]
        public DateTime? PerformedDate { get; set; }
        [FieldName("idfPerformedByOffice")]
        public BaseReferenceItem PerformedByOffice { get; set; }
        [FieldName("PerformedByPerson")]
        public string PerformedByPerson { get; set; }
        [FieldName("BatchTestCode")]
        public string BatchID { get; set; }
        [FieldName("strCaseID")]
        public string CaseID { get; set; }

        public static TestInfo[] GetAll(TestInfo filter)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return LabTestListItem.Accessor.Instance(null)
                    .SelectListT(manager, FilterAutoBuilder.BuildFilter(filter))
                    .Select(
                        c => new TestInfo()
                        {
                            Id = c.idfTesting,
                            Type = new BaseReferenceItem() { Id = c.idfsTestName, Name = c.TestName != null ? c.TestNameRef.name : "" },
                            SampleID = c.strBarcode,
                            Category = new BaseReferenceItem() { Id = c.idfsTestCategory, Name = c.TestCategory != null ? c.TestCategoryRef.name : "" },
                            Diagnosis = new BaseReferenceItem() { Id = c.idfsDiagnosis, Name = c.Diagnosis != null ? c.Diagnosis.name : "" },
                            Status = new BaseReferenceItem() { Id = c.idfsTestStatus, Name = c.TestStatus != null ? c.TestStatus.name : "" },
                            Result = new BaseReferenceItem() { Id = c.idfsTestResult, Name = c.TestResultRef != null ? c.TestResultRef.name : "" },
                            PerformedDate = c.datPerformedDate,
                            PerformedByOffice = new BaseReferenceItem() { Id = 0, Name = "" },
                            PerformedByPerson = "",
                            BatchID = c.BatchTestCode,
                            CaseID = c.CaseID
                        }
                    ).ToArray();
            }
            //return GetAll("fnWebTestList",FilterAutoBuilder.BuildFilter(filter));
        }

    }

}