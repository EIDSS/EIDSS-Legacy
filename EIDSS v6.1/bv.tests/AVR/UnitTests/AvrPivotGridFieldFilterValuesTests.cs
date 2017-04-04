using System;
using System.Collections.Generic;
using System.Data;
using bv.common.win;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;
using eidss.model.AVR.SourceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrPivotGridFieldFilterValuesTests
    {
        private IDisposable m_PresenterTransaction;

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(), new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
        }

        [TestMethod]
        public void AvrPivotGridFieldFilterValuesConvertorTest()
        {
            IEnumerable<PivotGridFieldBase> fields = CreateDiagnosisField();
            foreach (PivotGridFieldBase field in fields)
            {
                var avrValues = (AvrPivotGridFieldFilterValues) field.FilterValues;

                Assert.AreEqual(field.FilterValues.ShowBlanks, avrValues.ShowBlanks);
                Assert.AreEqual(field.FilterValues.FilterType, avrValues.FilterType);
                Assert.AreEqual(field.FilterValues.DeferFilterString, avrValues.DeferFilterString);
                Assert.AreEqual(field.FilterValues.Values.Length, avrValues.Values.Length);
                for (int i = 0; i < avrValues.Values.Length; i++)
                {
                    Assert.AreEqual(field.FilterValues.Values[i], avrValues.Values[i]);
                }
            }
        }

        [TestMethod]
        public void AvrPivotGridFieldFilterValuesSaveLoad()
        {
            IEnumerable<PivotGridFieldBase> fields = CreateDiagnosisField();
            foreach (PivotGridFieldBase field in fields)
            {
                var saved = (AvrPivotGridFieldFilterValues) field.FilterValues;
                string xml = saved.Serialize();

                string compressed = AvrPivotGridFieldExtender.CompressEndEncodeString(xml);
                string uncompressed = AvrPivotGridFieldExtender.UncompressEndDecodeString(compressed);
                Assert.AreEqual(xml, uncompressed);

                AvrPivotGridFieldFilterValues loaded = AvrPivotGridFieldFilterValues.Deserialize(uncompressed);

                Assert.AreEqual(loaded.ShowBlanks, saved.ShowBlanks);
                Assert.AreEqual(loaded.FilterType, saved.FilterType);
                Assert.AreEqual(loaded.DeferFilterString, saved.DeferFilterString);
                Assert.AreEqual(loaded.Values.Length, saved.Values.Length);
                for (int i = 0; i < saved.Values.Length; i++)
                {
                    Assert.AreEqual(loaded.Values[i], saved.Values[i]);
                }
            }
        }

        private static IEnumerable<PivotGridFieldBase> CreateDiagnosisField()
        {
            var result = new List<PivotGridFieldBase>();

            var grid = new AvrPivotGrid();
            var dataTable = new AvrDataTable(CreateTestDataSource());
            grid.SetDataSourceAndCreateFields(dataTable);
            Assert.AreEqual(8*2, grid.BaseFields.Count);

            PivotGridFieldBase diagnosisField = grid.BaseFields[6 *2];
            Assert.AreEqual("sflHC_Diagnosis_idfLayoutSearchField_51530730000000", diagnosisField.FieldName);
            var diagnosis = new List<object> {"Botulism", "Anthrax - Pulmonary"};
            diagnosisField.FilterValues.SetValues(diagnosis, PivotFilterType.Included, false);
            result.Add(diagnosisField);

            PivotGridFieldBase ageField = grid.BaseFields[1*2];
            Assert.AreEqual("sflHC_PatientAge_idfLayoutSearchField_51536690000000", ageField.FieldName);
            var age = new List<object> {66, 20};
            ageField.FilterValues.SetValues(age, PivotFilterType.Excluded, true);
            result.Add(ageField);

            return result;
        }

        public static DataTable CreateTestDataSource()
        {
            var result = new DataTable();
            result.Columns.Add("sflHC_PatientAge_idfLayoutSearchField_51536680000000", typeof (int));
            result.Columns.Add("sflHC_PatientAge_idfLayoutSearchField_51536690000000", typeof (int));
            result.Columns.Add("sflHC_CaseID_idfLayoutSearchField_51530710000000", typeof (string));
            result.Columns.Add("sflHC_CaseID_idfLayoutSearchField_51530720000000", typeof (string));
            result.Columns.Add("sflHC_EnteredDate_idfLayoutSearchField_51536700000000", typeof (DateTime));
            result.Columns.Add("sflHC_EnteredDate_idfLayoutSearchField_51536710000000", typeof (DateTime));
            result.Columns.Add("sflHC_Diagnosis_idfLayoutSearchField_51530730000000", typeof (string));
            result.Columns.Add("sflHC_Diagnosis_idfLayoutSearchField_51530740000000", typeof (string));

            result.Rows.Add(10, 10, "HGETBTB0130006", "HGETBTB0130006",
                new DateTime(2010, 1, 16), new DateTime(2010, 1, 16), "Influenza - virus unable to type", "Influenza - virus unable to type");
            result.Rows.Add(35, 35, "HGETBTB0130007", "HGETBTB0130007",
                new DateTime(2010, 2, 8), new DateTime(2010, 2, 8), "Botulism", "Botulism");
            result.Rows.Add(20, 20, "HGETBTB0130008", "HGETBTB0130008",
                new DateTime(2010, 3, 20), new DateTime(2010, 3, 20), "Anthrax - Pulmonary", "Anthrax - Pulmonary");
            result.Rows.Add(66, 66, "HGETBTB0130009", "HGETBTB0130009",
                new DateTime(2010, 12, 8), new DateTime(2010, 12, 8), "Anthrax - Gastrointestinal", "Anthrax - Gastrointestinal");

            return result;
        }
    }
}