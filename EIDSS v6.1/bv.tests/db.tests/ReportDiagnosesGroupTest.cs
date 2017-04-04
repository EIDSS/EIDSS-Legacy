using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;
using System.Linq;

namespace bv.tests.db.tests
{
    [TestClass]
    public class ReportDiagnosesGroupTest : EidssEnvWithLogin
    {
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }


        [TestMethod]
        public void RDGETest()
        {
            var accMaster = ReportDiagnosesGroupMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = ReportDiagnosesGroup.Accessor.Instance(null);
            var item = acc.CreateNewT(manager, null);
            item.strName = "default name";
            item.strTranslatedName = "translated name";
            item.Code = "I24";
            master.ReportDiagnosesGroups.Add(item);

            Assert.IsTrue(accMaster.Post(manager, master));

            //вновь созданный объект должен содержать весь справочник
            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.ReportDiagnosesGroups.Count > 0);
            Assert.IsTrue(masterNew.ReportDiagnosesGroups.Count == master.ReportDiagnosesGroups.Count);
            var mi = masterNew.ReportDiagnosesGroups.FirstOrDefault(c => c.idfsReportDiagnosesGroup == item.idfsReportDiagnosesGroup);
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.strName == item.strName);
            Assert.IsTrue(mi.Code == item.Code);
        }

        [TestMethod]
        //Report Diagnoses Group 2 Diagnosis
        public void RDGE2DTest()
        {
            var accMaster = ReportDiagnosesGroup2DiagnosisMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = ReportDiagnosesGroup2Diagnosis.Accessor.Instance(null);
            var item = acc.CreateNewT(manager, null);

            if (!(master.SummaryReportTypeLookup.Count > 1)) return;
            if (!(master.ReportDiagnosisGroupLookup.Count > 1)) return;
            if (!(item.DiagnosisLookup.Count > 1)) return;

            var srt = master.SummaryReportTypeLookup[1].idfsBaseReference;
            var rdg = master.ReportDiagnosisGroupLookup[1].idfsBaseReference;
            Assert.IsTrue(srt > 0);
            Assert.IsTrue(rdg > 0);

            //отыскиваем диагноз, который ещё не добавлен в эту группу
            var list = master.ReportDiagnosesGroup2Diagnoses.Where(c =>
                (c.idfsCustomReportType == srt) && (c.idfsReportDiagnosisGroup == rdg)).ToList();
            DiagnosisLookup dgn = null;
            foreach (var d in item.DiagnosisLookup)
            {
                if (list.All(c => c.idfsDiagnosis != d.idfsDiagnosis))
                {
                    dgn = d;
                    break;
                }
            }
            if (dgn == null) return;

            item.idfsCustomReportType = srt;
            item.idfsReportDiagnosisGroup = rdg;
            item.Diagnosis = item.DiagnosisLookup[1];

            Assert.IsTrue(item.idfsDiagnosis > 0);
            master.ReportDiagnosesGroup2Diagnoses.Add(item);

            Assert.IsTrue(accMaster.Post(manager, master));

            //вновь созданный объект
            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.ReportDiagnosesGroup2Diagnoses.Count > 0);
            Assert.IsTrue(masterNew.ReportDiagnosesGroup2Diagnoses.Count == master.ReportDiagnosesGroup2Diagnoses.Count);
            var mi = masterNew.ReportDiagnosesGroup2Diagnoses.FirstOrDefault(c =>
                (c.idfsCustomReportType == item.idfsCustomReportType) && (c.idfsReportDiagnosisGroup == item.idfsReportDiagnosisGroup));
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.idfsDiagnosis > 0);
            Assert.IsTrue(mi.idfsDiagnosis == item.idfsDiagnosis);
        }

        [TestMethod]
        public void CustomReportRowsTest()
        {
            var accMaster = CustomReportRowsMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = CustomReportRow.Accessor.Instance(null);
            var item = acc.CreateNewT(manager, null);

            if (master.SummaryReportTypeLookup.Count <= 1) return;
            var srt = master.SummaryReportTypeLookup[1];

            item.idfsCustomReportType = srt.idfsBaseReference;

            Assert.IsTrue(item.DiagnosisOrReportGroupLookup.Count > 1);
            Assert.IsTrue(item.ReportAdditionalTextLookup.Count > 1);
            Assert.IsTrue(item.ICDReportAdditionalTextLookup.Count > 1);

            var diagnType = item.DiagnosisOrReportGroupLookup.FirstOrDefault(c => c.idfsReference == 19000019);
            Assert.IsNotNull(diagnType);

            var reportGroupType = item.DiagnosisOrReportGroupLookup.FirstOrDefault(c => c.idfsReference == 19000130);
            Assert.IsNotNull(reportGroupType);

            item.DiagnosisOrReportGroup = reportGroupType;//diagnType;
            Assert.IsTrue(item.idfsDiagnosisOrGroup > 0);
            Assert.IsTrue(item.DiagnosisLookup.Count > 1);

            var diagn = item.DiagnosisLookup.FirstOrDefault(c => c.blnGroup == false) ?? item.DiagnosisLookup[1];
            Assert.IsTrue(diagn.idfsDiagnosisOrDiagnosisGroup > 0);

            item.Diagnosis = diagn;
            Assert.IsTrue(diagn.idfsDiagnosisOrDiagnosisGroup > 0);
            /*
            Assert.IsNotNull(item.strUsingType);
            Assert.IsTrue(item.strUsingType.Length > 0);
            Assert.IsTrue(item.idfsDiagnosisOrReportDiagnosisGroup > 0);
            Assert.IsNotNull(item.strDiagnosisOrReportDiagnosisGroup);
            Assert.IsTrue(item.strDiagnosisOrReportDiagnosisGroup.Length > 0);
            */
            item.intRowOrder = 1;

            var rat = item.ReportAdditionalTextLookup[1];
            Assert.IsTrue(rat.idfsBaseReference > 0);
            var irat = item.ICDReportAdditionalTextLookup[1];
            Assert.IsTrue(irat.idfsBaseReference > 0);

            item.ReportAdditionalText = rat;
            item.ICDReportAdditionalText = irat;
            Assert.IsTrue(item.idfsReportAdditionalText > 0);
            Assert.IsTrue(item.idfsICDReportAdditionalText > 0);

            master.CustomReportRows.Add(item);

            Assert.IsTrue(accMaster.Post(manager, master));

            //вновь созданный объект должен содержать весь справочник
            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.CustomReportRows.Count > 0);
            Assert.IsTrue(masterNew.CustomReportRows.Count == master.CustomReportRows.Count);
            var mi = masterNew.CustomReportRows.FirstOrDefault(c =>
                (c.idfsCustomReportType == item.idfsCustomReportType)
                &&
                (c.idfsDiagnosisOrReportDiagnosisGroup == item.idfsDiagnosisOrReportDiagnosisGroup)
                );
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.idfsReportAdditionalText == item.idfsReportAdditionalText);
            Assert.IsTrue(mi.idfsICDReportAdditionalText == item.idfsICDReportAdditionalText);
        }
    }
}
