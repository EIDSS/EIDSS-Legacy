using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;
using System.Linq;

namespace bv.tests.db.tests
{
    [TestClass]
    public class DiagnosisAgeGroupTest : EidssEnvWithLogin
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DiagnosisAgeGroup CreateDiagnosisAgeGroup()
        {
            var acc = DiagnosisAgeGroup.Accessor.Instance(null);
            var matrixItem = acc.CreateNewT(manager, null);

            Assert.IsTrue(matrixItem.AgeTypeLookup.Count > 1);

            matrixItem.DiagnosisAgeGroupName = "default name";
            matrixItem.DiagnosisAgeGroupNameTranslated = "translated name";
            Assert.IsTrue(matrixItem.intOrder == 0);
            matrixItem.intLowerBoundary = 0;
            matrixItem.intUpperBoundary = 10;
            matrixItem.AgeType = matrixItem.AgeTypeLookup[1];
            acc.Post(manager, matrixItem);
            return matrixItem;
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }


        [TestMethod]
        public void DagTest()
        {
            var accMaster = DiagnosisAgeGroupMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = DiagnosisAgeGroup.Accessor.Instance(null);
            var matrixItem = acc.CreateNewT(manager, null);

            Assert.IsTrue(matrixItem.AgeTypeLookup.Count > 1);

            matrixItem.DiagnosisAgeGroupName = "default name";
            matrixItem.DiagnosisAgeGroupNameTranslated = "translated name";
            Assert.IsTrue(matrixItem.intOrder == 0);
            matrixItem.intLowerBoundary = 0;
            matrixItem.intUpperBoundary = 10;
            matrixItem.AgeType = matrixItem.AgeTypeLookup[1];

            master.DiagnosisAgeGroups.Add(matrixItem);

            Assert.IsTrue(accMaster.Post(manager, master));

            //вновь созданный объект должен содержать весь справочник
            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.DiagnosisAgeGroups.Count > 0);
            Assert.IsTrue(masterNew.DiagnosisAgeGroups.Count == master.DiagnosisAgeGroups.Count);
            var mi = masterNew.DiagnosisAgeGroups.FirstOrDefault(c => c.idfsDiagnosisAgeGroup == matrixItem.idfsDiagnosisAgeGroup);
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.idfsAgeType > 0);
            Assert.IsTrue(mi.intLowerBoundary == matrixItem.intLowerBoundary);
            Assert.IsTrue(mi.intUpperBoundary == matrixItem.intUpperBoundary);
        }

        [TestMethod]
        public void Diagnosis2DiagnosisAgeGroupTest()
        {
            //создаем один элемент на всякий случай
            var dg = CreateDiagnosisAgeGroup();

            var accMaster = Diagnosis2DiagnosisAgeGroupMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = DiagnosisAgeGroupToDiagnosis.Accessor.Instance(null);
            var matrixItem = acc.CreateNewT(manager, null);

            Assert.IsTrue(master.idfsDiagnosis == 0);
            Assert.IsTrue(master.DiagnosisLookup.Count > 1);
            Assert.IsTrue(matrixItem.DiagnosisAgeGroupLookup.Count > 1);

            Assert.IsTrue(master.idfsDiagnosis == 0);
            var diagnosis = master.Diagnosis = master.DiagnosisLookup[1];
            matrixItem.idfsDiagnosis = diagnosis.idfsDiagnosis;
            matrixItem.idfsDiagnosisAgeGroup = dg.idfsDiagnosisAgeGroup;
            //matrixItem.DiagnosisAgeGroup = matrixItem.DiagnosisAgeGroupLookup[0];

            master.DiagnosisAgeGroupToDiagnoses.Add(matrixItem);

            Assert.IsTrue(accMaster.Post(manager, master));

            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.idfsDiagnosis == 0);

            masterNew.Diagnosis = diagnosis;
            Assert.IsTrue(masterNew.DiagnosisAgeGroupToDiagnoses.Count > 0);

            var mi = masterNew.DiagnosisAgeGroupToDiagnoses.FirstOrDefault(c => c.idfDiagnosisAgeGroupToDiagnosis == matrixItem.idfDiagnosisAgeGroupToDiagnosis);
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.idfsDiagnosis == diagnosis.idfsDiagnosis);
            //Assert.IsTrue(mi.idfsDiagnosisAgeGroup == matrixItem.idfsDiagnosisAgeGroup);
            //Assert.IsTrue(mi.DiagnosisAgeGroup == matrixItem.DiagnosisAgeGroup);
        }

        [TestMethod]
        //[Ignore]
        public void DAG2SAGTest()
        {
            //создаем один элемент на всякий случай
            var dg = CreateDiagnosisAgeGroup();

            var accMaster = DiagnosisAgeGroup2StatisticalAgeGroupMaster.Accessor.Instance(null);
            var master = accMaster.CreateNewT(manager, null);
            var acc = DiagnosisAgeGroup2StatisticalAgeGroup.Accessor.Instance(null);
            var matrixItem = acc.CreateNewT(manager, null);

            Assert.IsTrue(master.idfsDiagnosisAgeGroup == 0);
            Assert.IsTrue(master.DiagnosisAgeGroupLookup.Count > 0);
            Assert.IsTrue(matrixItem.StatisticalAgeGroupLookup.Count > 0);

            master.idfsDiagnosisAgeGroup = matrixItem.idfsDiagnosisAgeGroup = dg.idfsDiagnosisAgeGroup;// dag.idfsDiagnosisAgeGroup;
            matrixItem.StatisticalAgeGroup = matrixItem.StatisticalAgeGroupLookup[1];

            master.DAG2SAG.Add(matrixItem);

            Assert.IsTrue(accMaster.Post(manager, master));

            var masterNew = accMaster.CreateNewT(manager, null);
            Assert.IsTrue(masterNew.idfsDiagnosisAgeGroup == 0);

            masterNew.idfsDiagnosisAgeGroup = dg.idfsDiagnosisAgeGroup;
            Assert.IsTrue(masterNew.DAG2SAG.Count > 0);

            var mi = masterNew.DAG2SAG.FirstOrDefault(c => c.idfDiagnsosisAgeGroupToStatisticalAgeGroup == matrixItem.idfDiagnsosisAgeGroupToStatisticalAgeGroup);
            Assert.IsNotNull(mi);
            Assert.IsTrue(mi.idfsDiagnosisAgeGroup == dg.idfsDiagnosisAgeGroup);
            Assert.IsTrue(mi.StatisticalAgeGroup == matrixItem.StatisticalAgeGroup);
        }
    }
}
