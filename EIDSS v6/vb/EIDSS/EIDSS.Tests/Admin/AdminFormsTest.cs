using System;
using System.Collections.Generic;
using System.Data;
using bv.common.db;
using bv.common.db.Core;
using EIDSS.Tests.Core;
using NUnit.Framework;

namespace EIDSS.Tests.Admin
{
    [TestFixture]
    public class AdminFormsTest : BaseFormTest
    {
        [SetUp]
        public override void Init()
        {
            base.Init();
            ScriptLoader.RunScript(PathToTestFolder.Get("Admin") + "Data\\InitAggregateMatrix.sql");
        }
        #region Auto tests
        [Test]
        public void AggregateDiagnosticActionMTXDetailTest()
        {
            RunAutoBaseFormTest("AggregateDiagnosticActionMTXDetail", null, false);
        }
        [Test]
        public void AggregateProphylacticActionMTXDetailTest()
        {
            RunAutoBaseFormTest("AggregateProphylacticActionMTXDetail", null, false);
        }
        [Test]
        public void AggregateVetCaseMTXDetailTest()
        {
            RunAutoBaseFormTest("AggregateVetCaseMTXDetail", null, false);
        }
        [Test]
        public void AggregateSettingsDetailTest()
        {
            RunAutoBaseFormTest("AggregateSettingsDetail", null);
        }
        [Test]
        public void NextNumbersDetailTest()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("intNumberValue", 6); //Outbreak
            RunAutoBaseFormTest(10057015,"NextNumbersDetail", fields, true);
        }
        [Test]
        public void NextNumbersListTest()
        {
            RunDefaultListFormTest("NextNumbersList");
        }
        [Test]
        public void ActionDetailTest()
        {
            RunAutoBaseFormTest("ActionDetail", null, false);
        }
        [Test]
        public void DepartmentDetailTest()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("DefaultName", "Dept123");
            fields.Add("Name", "Dept123");
            fields.Add("idfOrganization", 49820000000); //NCDC
            RunAutoBaseFormTest("DepartmentDetail", fields);
        }
        [Test]
        public void MaterialForDiseaseDetailTest()
        {
            RunAutoBaseFormTest("MaterialForDiseaseDetail", null, false);
        }
        [Test]
        public void TestForDiseaseDetailTest()
        {
            RunAutoBaseFormTest("TestForDiseaseDetail", null, false);
        }
        [Test]
        public void OrganizationDetailTest()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("EnglishName", "Org123");
            fields.Add("EnglishAbbreviation", "Org123");
            fields.Add("Name", "Org123");
            fields.Add("Abbreviation", "Org123");
            fields.Add("strContactPhone", "123");
            fields.Add("AddressPanel.Address.idfsCountry", 780000000);
            fields.Add("AddressPanel.Address.idfsRegion", 37020000000);
            fields.Add("AddressPanel.Address.idfsRayon", 3260000000);
            fields.Add("AddressPanel.Address.idfsSettlement", 259730000000);

            RunAutoBaseFormTest("OrganizationDetail", fields);
        }
        [Test]
        public void OrganizationListTest()
        {
            RunDefaultListFormTest("OrganizationList" );
        }
        [Test]
        public void ReferenceDetailTest()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("MasterReferenceType.idfsReferenceType", 19000006); //rftAnimalCondition
            RunAutoBaseFormTest("ReferenceDetail", fields, false);
        }
        [Test]
        public void StatisticTypeDetailTest()
        {
            RunAutoBaseFormTest("StatisticTypeDetail", null);
        }
        [Test]
        public void PersonDetailTest()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("strFamilyName", "strFamilyName");
            fields.Add("strFirstName", "strFirstName");
            fields.Add("strSecondName", "strSecondName");
            fields.Add("strContactPhone", "strContactPhone");
            fields.Add("idfInstitution", 49820000000); //NCDC

            RunAutoBaseFormTest("PersonDetail", fields);
        }
        [Test]
        public void PersonListTest()
        {
            RunDefaultListFormTest("PersonList");
        }
        [Test]
        public void SiteActivationServerDetailTest()
        {
            RunAutoBaseFormTest("SiteActivationServerDetail", null);
        }
        [Test]
        public void SiteActivationServerListTest()
        {
            RunDefaultListFormTest("SiteActivationServerList");
        }
        [Test]
        public void StatisticDetailTest()
        {

            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("idfsStatisticDataType", 39850000000);
            fields.Add("idfsStatisticAreaType", 10089002);
            fields.Add("idfsStatisticPeriodType", 10091002);
            fields.Add("idfsArea", 3260000000);
            fields.Add("datStatisticStartDate", DateTime.Today); 
            fields.Add("varValue", "1000");
            Dictionary<string, object> param = new Dictionary<string, object>();
            IDbCommand cmd1 = BaseDbService.CreateSPCommand("spStatisticType_Post",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            param.Add("@Action", 16);
            param.Add("@idfsBaseReference", 39850000000);
            param.Add("@idfsStatisticPeriodType", 10091002);
            param.Add("@idfsStatisticAreaType", 10089002);
            StoredProcParamsCache.CreateParameters(cmd1, param);
            BaseDbService.ExecCommand(cmd1, cmd1.Connection, null, true);

            IDbCommand cmd = BaseDbService.CreateSPCommand("spStatistic_Exists",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            param.Clear();
            param.Add("@Area", 3260000000);
            param.Add("@StatisticDataType", 39850000000);
            param.Add("@StatisticPeriodType", 10091002);
            param.Add("@StartDate", fields["datStatisticStartDate"]);
            StoredProcParamsCache.CreateParameters(cmd, param);
            BaseDbService.ExecCommand(cmd, cmd.Connection, null, true);
            object id = null;
            if ((int)(BaseDbService.GetParamValue(cmd, "@RETURN_VALUE")) != 0)
            {
                id = BaseDbService.GetParamValue(cmd, "@ExistingStatistic");
            }

            RunAutoBaseFormTest(id, "StatisticDetail", fields, true);

        }
        [Test]
        public void StatisticListTest()
        {
            RunDefaultListFormTest("StatisticList");
        }
        [Test]
        public void SystemPermissionsTest()
        {
            RunAutoBaseFormTest("SystemPermissions", null);
        }
        [Test]
        public void DiagnosisReferenceDetailTest()
        {
            RunAutoBaseFormTest("DiagnosisReferenceDetail", null);
        }
        [Test]
        public void DataAuditListTest()
        {
            RunDefaultListFormTest("DataAuditList");
        }
        [Test]
        public void DataAuditDetailTest()
        {
            RunAutoBaseFormTest("DataAuditDetail", null);
        }
        #endregion

        #region Manual tests
        [Test, Ignore("manual test")]
        public void AggregateSettingsDetailManualTest()
        {
            RunManualBaseFormTest("AggregateSettingsDetail");
        }

        [Test, Ignore("manual test")]
        public void StatisticTypeManualTest()
        {
            RunManualBaseFormTest("StatisticTypeDetail");
        }
        [Test, Ignore("manual test")]
        public void OrganizationDetailManualTest()
        {
            RunManualBaseFormTest("OrganizationDetail");
        }
        [Test, Ignore("manual test")]
        public void OrganizationListManualTest()
        {
            RunManualBaseFormTest("OrganizationList");
        }
        [Test, Ignore("manual test")]
        public void PersonManualTest()
        {
            RunManualBaseFormTest("PersonDetail");
        }
        [Test, Ignore("manual test")]
        public void PersonListManualTest()
        {
            RunManualBaseFormTest("PersonList");
        }
        [Test, Ignore("manual test")]
        public void ReferenceDetailManualTest()
        {
            RunManualBaseFormTest("ReferenceDetail");
        }
        [Test, Ignore("manual test")]
        public void MaterialForDiseaseDetailManualTest()
        {
            RunManualBaseFormTest("MaterialForDiseaseDetail");
        }
        [Test, Ignore("manual test")]
        public void TestForDiseaseDetailManualTest()
        {
            RunManualBaseFormTest("TestForDiseaseDetail");
        }
        [Test, Ignore("manual test")]
        public void StatisticDetailManualTest()
        {
            RunManualBaseFormTest("StatisticDetail");
        }
        [Test, Ignore("manual test")]
        public void StatisticListManualTest()
        {
            RunManualBaseFormTest("StatisticList");
        }

        [Test, Ignore("manual test")]
        public void AggregateVetCaseMtxDetailManualTest()
        {
            RunManualBaseFormTest("AggregateVetCaseMTXDetail");
        }
        [Test, Ignore("manual test")]
        public void DiagnosisReferenceManualTest()
        {
            RunManualBaseFormTest("DiagnosisReferenceDetail");
        }
        [Test, Ignore("manual test")]
        public void AggregateDiagnosticActionMTXManualTest()
        {
            RunManualBaseFormTest("AggregateDiagnosticActionMTXDetail");
        }
        [Test, Ignore("manual test")]
        public void AggregateProphylacticActionMTXManualTest()
        {
            RunManualBaseFormTest("AggregateProphylacticActionMTXDetail");
        }
        [Test, Ignore("manual test")]
        public void AggregateHumanCaseMTXManualTest()
        {
            RunManualBaseFormTest("AggregateHumanCaseMTXDetail");
        }

        #endregion
    }
}