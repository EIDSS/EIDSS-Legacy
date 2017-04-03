using System;
using System.Collections.Generic;
using System.Data;
using bv.common;
using bv.common.db.Core;
using EIDSS.Tests.Core;
using EIDSS.Tests.Vet;
using NUnit.Framework;
namespace EIDSS.Tests.Human
{
    [TestFixture]
    public class HumanTestsForms : BaseFormTest
    {
       

        private static Dictionary<string, object> GetHumanCaseFields()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            Random rand = new Random();
            DataView diagnosisView = LookupCache.Get(LookupTables.HumanStandardDiagnosis);
            fields.Add("PatientInfo."+Patient_DB.tlbHuman + ".strLastName", "Ivanov" + rand.Next(100) );
            fields.Add("PatientInfo." + Patient_DB.tlbHuman + ".strFirstName", "Ivan" + rand.Next(100));
            fields.Add(HumanCase_DB.tlbHumanCase + ".idfsTentativeDiagnosis",
                       diagnosisView[rand.Next(5)]["idfsDiagnosis"]);
            fields.Add("CurrentResidence_AddressLookup.Address.idfsCountry", 780000000);
            fields.Add("CurrentResidence_AddressLookup.Address.idfsRegion", 37020000000);
            fields.Add("CurrentResidence_AddressLookup.Address.idfsRayon", 3260000000);
            fields.Add("CurrentResidence_AddressLookup.Address.idfsSettlement", 259730000000);
            return fields;
        }

        private static DateTime CurDate()
        {
            return DateTime.Today;
        }
        private static Dictionary<string, object> GetAggregateTestFields()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("AggregateHeader1.AggregateHeader.idfsAdministrativeUnit", 259730000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfsCountry", 780000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfsRegion", 37020000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfsRayon", 3260000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfsSettlement", 259730000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfReceivedByOffice", 49820000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfReceivedByPerson", eidss.model.Core.EidssUserContext.User.EmployeeID);
            fields.Add("AggregateHeader1.AggregateHeader.idfSentByOffice", 49820000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfSentByPerson", eidss.model.Core.EidssUserContext.User.EmployeeID);
            fields.Add("AggregateHeader1.AggregateHeader.idfEnteredByOffice", 49820000000);
            fields.Add("AggregateHeader1.AggregateHeader.idfEnteredByPerson", eidss.model.Core.EidssUserContext.User.EmployeeID);
            fields.Add("AggregateHeader1.AggregateHeader.datReceivedByDate", CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.datSentByDate", CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.datEnteredByDate", CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.datStartDate", CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.datFinishDate", CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.MonthForAggr", CurDate().Month);
            fields.Add("AggregateHeader1.AggregateHeader.DayForAggr", CurDate());
            return fields;
        }


        [Test]
        public void AggregateCaseDetail_Test()
        {
            if (!VetFormsTests.CheckAggergateCaseMatrix(AggregateCaseSection.HumanCase))
                Assert.Fail("Aggregate case matrix for Human Aggregate Case is not defined.");
            VetFormsTests.SetDefaultAggregateSetting(AggregateCaseType.AggregateCase);
            const long adminUnit = 259730000000;
            long caseID = AggregateSummary_DB.FindAggregateCase(
                AggregateCaseType.AggregateCase,
                CurDate(),
                CurDate(),
                adminUnit);
            if (caseID > 0)
                RunAutoBaseFormTest(caseID, "AggregateCaseDetail", GetAggregateTestFields(), true);
            else
                RunAutoBaseFormTest("AggregateCaseDetail", GetAggregateTestFields());
        }
        [Test]
        public void AggregateSummaryCaseDetail_Test()
        {
            if (!VetFormsTests.CheckAggergateCaseMatrix(AggregateCaseSection.HumanCase ))
                Assert.Fail("Aggregate case matrix for Human Aggregate Case is not defined.");
            VetFormsTests.SetDefaultAggregateSetting(AggregateCaseType.AggregateCase);
            RunAutoBaseFormTest("AggregateSummaryCaseDetail", null, false);
        }
        [Test]
        public void HumanCaseDetail_Test()
        {
            RunAutoBaseFormTest("HumanCaseDetail", GetHumanCaseFields());
        }
        [Test]
        public void HumanCaseList_Test()
        {
            RunDefaultListFormTest("HumanCaseList");
        }

        [Test, Ignore("manual test")]
        public void AggregateCaseDetailManual_Test()
        {
            RunManualBaseFormTest("AggregateCaseDetail");
        }
        [Test, Ignore("manual test")]
        public void HumanCaseDetailManual_Test()
        {
            RunManualBaseFormTest("HumanCaseDetail",GetHumanCaseFields());
        }
        [Test, Ignore("manual test")]
        public void AggregateSummaryCaseDetailManual_Test()
        {
            RunManualBaseFormTest("AggregateSummaryCaseDetail");
        }

    }
}
