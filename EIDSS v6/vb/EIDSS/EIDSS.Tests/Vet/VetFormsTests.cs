using System;
using System.Collections.Generic;
using bv.common;
using bv.common.db;
using bv.common.db.Core;
using EIDSS.Tests.Core;
using NUnit.Framework;
using System.Data;
namespace EIDSS.Tests.Vet
{
    [TestFixture]
    public class VetFormsTests : BaseFormTest
    {
        
        #region Private methods
        private static Dictionary<string, object> GetFarmTestFields()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("FarmPanel.Farm.strContactPhone", "123");
            fields.Add("FarmPanel.Farm.strInternationalName", "strInternationalName");
            fields.Add("FarmPanel.Farm.strNationalName", "strNationalName");
            fields.Add("FarmPanel.Farm.strFarmCode", "strFarmCode");
            fields.Add("FarmPanel.Farm.strFax", "strFax");
            fields.Add("AddressPanel.Address.idfsCountry", 780000000);
            fields.Add("AddressPanel.Address.idfsRegion", 37020000000);
            fields.Add("AddressPanel.Address.idfsRayon", 3260000000);
            fields.Add("AddressPanel.Address.idfsSettlement", 259730000000);
            fields.Add("pnFarmLocation.GeoLocation.dblLatitude", 50.2345);
            fields.Add("pnFarmLocation.GeoLocation.dblLongitude", 70.678);
            fields.Add("pnFarmLocation.GeoLocation.dblAccuracy", 0.01);
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
            fields.Add("AggregateHeader1.AggregateHeader.datStartDate",  CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.datFinishDate",  CurDate());
            fields.Add("AggregateHeader1.AggregateHeader.MonthForAggr",  CurDate().Month);
            fields.Add("AggregateHeader1.AggregateHeader.DayForAggr",  CurDate());
            return fields;
        }

        public static bool CheckAggergateCaseMatrix(AggregateCaseSection caseType)
        {
            IDbCommand cmd = BaseDbService.CreateSPCommand("spFFGetPredefinedStub",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            BaseDbService.AddParam(cmd, "@MatrixID", (long)caseType,
                                   ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@VersionList", "",
                                   ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@LangID", "en",
                                   ParameterDirection.Input);
            using(DataTable dt = new DataTable())
            {
                BaseDbService.FillTable(cmd, dt, null, true);
                if(dt.Rows.Count>0)
                    return true;
            }
            return false;
        }
        public static void SetDefaultAggregateSetting(AggregateCaseType caseType)
        {
            IDbCommand cmd = BaseDbService.CreateSPCommand("spAggregateSettings_Post",ConnectionManager.DefaultInstance.Connection,null);

            BaseDbService.AddParam(cmd, "@idfsAggrCaseType", (long) caseType,ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@idfsCountry", 780000000, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@idfsStatisticAreaType", (long)StatisticAreaType.Settlement, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@idfsStatisticPeriodType", (long)StatisticPeriodType.Day, ParameterDirection.Input);
            BaseDbService.ExecCommand(cmd, cmd.Connection, null, true);
        }
        #endregion
        #region Auto tests
        [Test]
        public void FarmDetail_Test()
        {
            RunAutoBaseFormTest("FarmDetail", GetFarmTestFields());
        }
        [Test]
        public void FarmList_Test()
        {
            RunDefaultListFormTest("FarmList");
        }
        [Test]
        public void VetCaseLiveStockDetail_Test()
        {
            RunAutoBaseFormTest("VetCaseLiveStockDetail", GetFarmTestFields());
        }
        [Test]
        public void VetCaseAvianDetail_Test()
        {
            RunAutoBaseFormTest("VetCaseAvianDetail", GetFarmTestFields());
        }
        [Test]
        public void VetCaseList_Test()
        {
            RunDefaultListFormTest("VetCaseList");
        }
        [Test]
        public void ASSessionList_Test()
        {
            RunDefaultListFormTest("ASCampaignList");
        }
        [Test]
        public void ASCampaignList_Test()
        {
            RunDefaultListFormTest("ASSessionList");
        }
        [Test]
        public void VetAggregateCaseDetail_Test()
        {
            if (!CheckAggergateCaseMatrix(AggregateCaseSection.VetCase))
                Assert.Fail("Aggregate case matrix for Vet Aggregate Case is not defined.");
            SetDefaultAggregateSetting(AggregateCaseType.VetAggregateCase );
            const long adminUnit = 259730000000;
            long caseID = AggregateSummary_DB.FindAggregateCase(
                AggregateCaseType.VetAggregateCase,
                CurDate(),
                CurDate(),
                adminUnit);
            if (caseID>0)
                RunAutoBaseFormTest(caseID,"VetAggregateCaseDetail", GetAggregateTestFields(),true);
            else
                RunAutoBaseFormTest("VetAggregateCaseDetail", GetAggregateTestFields());
        }
        [Test]
        public void VetAggregateActionDetail_Test()
        {
            if (!CheckAggergateCaseMatrix(AggregateCaseSection.DiagnosticAction) && !CheckAggergateCaseMatrix(AggregateCaseSection.ProphylacticAction) && !CheckAggergateCaseMatrix(AggregateCaseSection.SanitaryAction))
                Assert.Fail("Aggregate case matrix for Vet Aggregate Action is not defined.");
            SetDefaultAggregateSetting(AggregateCaseType.VetAggregateAction);
            const long adminUnit = 259730000000;
            long caseID = AggregateSummary_DB.FindAggregateCase(
                AggregateCaseType.VetAggregateAction,
                CurDate(),
                CurDate(),
                adminUnit);
            if (caseID>0)
                RunAutoBaseFormTest(caseID, "VetAggregateActionDetail", GetAggregateTestFields(), true);
            else
                RunAutoBaseFormTest("VetAggregateActionDetail", GetAggregateTestFields());
        }
        [Test]
        public void VetAggregateSummaryActionDetail_Test()
        {
            if (!CheckAggergateCaseMatrix(AggregateCaseSection.DiagnosticAction) && !CheckAggergateCaseMatrix(AggregateCaseSection.ProphylacticAction) && !CheckAggergateCaseMatrix(AggregateCaseSection.SanitaryAction))
                Assert.Fail("Aggregate case matrix for Vet Aggregate Action is not defined.");
            SetDefaultAggregateSetting(AggregateCaseType.VetAggregateAction);
            RunAutoBaseFormTest("VetAggregateSummaryActionDetail", null, false);
        }
        [Test]
        public void VetAggregateSummaryCaseDetail_Test()
        {
            if (!CheckAggergateCaseMatrix(AggregateCaseSection.VetCase))
                Assert.Fail("Aggregate case matrix for Vet Aggregate Case is not defined.");
            SetDefaultAggregateSetting(AggregateCaseType.VetAggregateCase);
            RunAutoBaseFormTest("VetAggregateSummaryCaseDetail", null, false);
        }
        #endregion

        #region Manual tests
        [Test, Ignore("manual test")]
        public void VetCaseListManual_Test()
        {
            RunManualBaseFormTest("VetCaseList");
        }
        [Test, Ignore("manual test")]
        public void ASCampaignListManual_Test()
        {
            RunManualBaseFormTest("ASCampaignList");
        }
        [Test, Ignore("manual test")]
        public void ASSessionListManual_Test()
        {
            RunManualBaseFormTest("ASSessionList");
        }
        [Test, Ignore("manual test")]
        public void LivestockManual_Test()
        {
            RunManualBaseFormTest("VetCaseLiveStockDetail");
        }
        [Test, Ignore("manual test")]
        public void AvianManual_Test()
        {
            RunManualBaseFormTest("VetCaseAvianDetail");
        }
        [Test, Ignore("manual test")]
        public void FarmListManual_Test()
        {
            RunManualBaseFormTest("FarmList");
        }
        [Test, Ignore("manual test")]
        public void FarmDetailManual_Test()
        {
            RunManualBaseFormTest("FarmDetail");
        }

        [Test, Ignore("manual test")]
        public void VetAggregateCaseDetailManual_Test()
        {
            RunManualBaseFormTest("VetAggregateCaseDetail");
        }
        [Test, Ignore("manual test")]
        public void VetAggregateSummaryCaseDetailManual_Test()
        {
            RunManualBaseFormTest("VetAggregateSummaryCaseDetail");
        }
        [Test, Ignore("manual test")]
        public void VetAggregateActionDetailManual_Test()
        {
            RunManualBaseFormTest("VetAggregateActionDetail");
        }
        [Test, Ignore("manual test")]
        public void VetAggregateSummaryActionDetailManual_Test()
        {
            RunManualBaseFormTest("VetAggregateSummaryActionDetail");
        }
        #endregion

    }
}