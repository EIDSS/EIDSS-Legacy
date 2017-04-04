using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.win;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class PivotGridFieldTests
    {
        private const string FieldName = @"sfLHC_CaseID";
        private const string FieldNameWithId = @"sfLHC_CaseID_idfLayoutSearchField_12345678";


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
        public void FieldNameWithIdTest()
        {
            var field = new WinPivotGridField
            {
                Name = @"field" + FieldNameWithId,
                FieldName = FieldNameWithId,
                Caption = @"Some caption",
                Area = PivotArea.DataArea,
                Visible = true,
            };

            Assert.AreEqual(FieldNameWithId, field.FieldName);
            Assert.AreEqual(@"field" + FieldNameWithId, field.Name);
            Assert.AreEqual(FieldName, field.OriginalFieldName);
            Assert.AreEqual(12345678L, field.FieldId);
        }

        [TestMethod]
        public void FieldNameSimpleTest()
        {
            var field = new WinPivotGridField
            {
                Name = @"field" + FieldName,
                FieldName = FieldName,
                Caption = @"Some caption",
                Area = PivotArea.DataArea,
                Visible = true,
            };

            Assert.AreEqual(FieldName, field.FieldName);
            Assert.AreEqual(@"field" + FieldName, field.Name);
            Assert.AreEqual(FieldName, field.OriginalFieldName);
            Assert.AreEqual(-1L, field.FieldId);
        }

        [TestMethod]
        public void PivotGridLinkedFieldSimpleTest()
        {
            IAvrPivotGridField region = GetIAvrPivotGridField("Region");
            IAvrPivotGridField rayon = GetIAvrPivotGridField("Rayon");
            IAvrPivotGridField settlement = GetIAvrPivotGridField("Settlement");

            var fields = new List<IAvrPivotGridField> {region, rayon, settlement};
            foreach (IAvrPivotGridField field in fields)
            {
                field.AllPivotFields = fields;
            }
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(region, result[0]);
            Assert.AreEqual(rayon, result[1]);
            Assert.AreEqual(settlement, result[2]);
        }

        [TestMethod]
        public void PivotGridLinkedFieldRayonRegionSettlementTest()
        {
            WinPivotGridField region = GetIAvrPivotGridField("Region");
            WinPivotGridField rayon = GetIAvrPivotGridField("Rayon");
            rayon.RelatedFields = new List<IAvrPivotGridField> {region};
            WinPivotGridField settlement = GetIAvrPivotGridField("Settlement");
            settlement.RelatedFields = new List<IAvrPivotGridField> {rayon, region};
            WinPivotGridField diagnosis = GetIAvrPivotGridField("Diagnosis");
            WinPivotGridField zoonotic = GetIAvrPivotGridField("Zoonotic");
            zoonotic.RelatedFields = new List<IAvrPivotGridField> {diagnosis};

            var allFields = new List<IAvrPivotGridField> {region, rayon, settlement, diagnosis, zoonotic};
            foreach (IAvrPivotGridField field in allFields)
            {
                field.AllPivotFields = allFields;
            }

            Assert.AreEqual(2, settlement.GetRelatedFieldChain().Count);
            Assert.AreEqual(1, zoonotic.GetRelatedFieldChain().Count);

            var fields = new List<IAvrPivotGridField> {rayon, region, settlement, zoonotic};
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(region, result[0]);
            Assert.AreEqual(rayon, result[1]);
            Assert.AreEqual(settlement, result[2]);
            Assert.AreEqual(diagnosis, result[3]);
            Assert.AreEqual(zoonotic, result[4]);
        }

        [TestMethod]
        public void PivotGridLinkedFieldCountryRayonRegionElevationSettlementTest()
        {
            WinPivotGridField country = GetIAvrPivotGridField("Country");

            WinPivotGridField region = GetIAvrPivotGridField("Region");
            region.RelatedFields = new List<IAvrPivotGridField> {country};

            WinPivotGridField rayon = GetIAvrPivotGridField("Rayon");
            rayon.RelatedFields = new List<IAvrPivotGridField> {region, country};

            WinPivotGridField elevation = GetIAvrPivotGridField("Elevation");

            WinPivotGridField settlement = GetIAvrPivotGridField("Settlement");

            settlement.RelatedFields = new List<IAvrPivotGridField> {region, rayon, country, elevation};

            WinPivotGridField diagnosis = GetIAvrPivotGridField("Diagnosis");
            WinPivotGridField zoonotic = GetIAvrPivotGridField("Zoonotic");

            var allFields = new List<IAvrPivotGridField> { settlement, region, rayon, country, elevation, diagnosis, zoonotic };
            foreach (IAvrPivotGridField field in allFields)
            {
                field.AllPivotFields = allFields;
            }

            Assert.AreEqual(4, settlement.GetRelatedFieldChain().Count);
            Assert.AreEqual(country, settlement.GetRelatedFieldChain()[0]);
            Assert.AreEqual(region, settlement.GetRelatedFieldChain()[1]);
            Assert.AreEqual(rayon, settlement.GetRelatedFieldChain()[2]);
            Assert.AreEqual(elevation, settlement.GetRelatedFieldChain()[3]);

            zoonotic.RelatedFields = new List<IAvrPivotGridField> {diagnosis};

            Assert.AreEqual(1, zoonotic.GetRelatedFieldChain().Count);

            var fields = new List<IAvrPivotGridField> {region, settlement, zoonotic};
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(7, result.Count);
            Assert.AreEqual(country, result[0]);
            Assert.AreEqual(region, result[1]);
            Assert.AreEqual(rayon, result[2]);
            Assert.AreEqual(elevation, result[3]);
            Assert.AreEqual(settlement, result[4]);

            Assert.AreEqual(diagnosis, result[5]);
            Assert.AreEqual(zoonotic, result[6]);
        }

        [TestMethod]
        public void PivotGridDeleteFieldDuplicateTest()
        {
            IAvrPivotGridField date1 = GetIAvrPivotGridField("Date");
            date1.SearchFieldDataType = typeof(DateTime);
            IAvrPivotGridField region1 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField region2 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField region3 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField date2 = GetIAvrPivotGridField("Date");
            date2.SearchFieldDataType = typeof(DateTime);

            var fields = new List<IAvrPivotGridField> {date1, region1, region2, region3, date2};
            foreach (IAvrPivotGridField field in fields)
            {
                field.AllPivotFields = fields;
            }
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(date1, result[0]);
            Assert.AreEqual(region1, result[1]);
        }

        [TestMethod]
        public void PivotGridDeleteFieldMissedValuesDuplicateTest()
        {
            IAvrPivotGridField date1 = GetIAvrPivotGridField("Date");
            date1.SearchFieldDataType = typeof (DateTime);
            date1.AddMissedValues = true;

            IAvrPivotGridField region1 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField region2 = GetIAvrPivotGridField("Region");
            region2.AddMissedValues = true;
            IAvrPivotGridField region3 = GetIAvrPivotGridField("Region");
            region3.AddMissedValues = true;

            IAvrPivotGridField date2 = GetIAvrPivotGridField("Date");
            date2.SearchFieldDataType = typeof(DateTime);
            date2.AddMissedValues = true;

            var fields = new List<IAvrPivotGridField> {date1, region1, region2, region3, date2};
            foreach (IAvrPivotGridField field in fields)
            {
                field.AllPivotFields = fields;
            }
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(date1, result[0]);
            Assert.AreEqual(region2, result[1]);
        }

        [TestMethod]
        public void PivotGridMissedValuesFilterDateTest()
        {
            IAvrPivotGridField date1 = GetIAvrPivotGridField("Date");
            date1.SearchFieldDataType = typeof(DateTime);
            date1.GroupInterval = PivotGroupInterval.DateYear;
            date1.AddMissedValues = true;

            IAvrPivotGridField date2 = GetIAvrPivotGridField("Date");
            date2.SearchFieldDataType = typeof(DateTime);
            date2.GroupInterval = PivotGroupInterval.DateMonth;
            date2.AddMissedValues = true;


            IAvrPivotGridField date3 = GetIAvrPivotGridField("Date");
            date3.SearchFieldDataType = typeof(DateTime);
            date3.IsHiddenFilterField = true;
            
            
            var fields = new List<IAvrPivotGridField> { date1, date2, date3 };
            foreach (IAvrPivotGridField field in fields)
            {
                field.AllPivotFields = fields;
            }
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(new List<IAvrPivotGridField> { date1, date2}).ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(date1, result[0]);
        }

        [TestMethod]
        public void PivotGridDeleteFieldMissedValuesSingleTest()
        {
            IAvrPivotGridField region1 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField region2 = GetIAvrPivotGridField("Region");
            IAvrPivotGridField region3 = GetIAvrPivotGridField("Region");
            region3.AddMissedValues = true;

            var fields = new List<IAvrPivotGridField> {region1, region2, region3};
            foreach (IAvrPivotGridField field in fields)
            {
                field.AllPivotFields = fields;
            }
            List<IAvrPivotGridField> result = AvrPivotGridHelper.AddRelatedFields(fields).ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(region3, result[0]);
        }

        private static WinPivotGridField GetIAvrPivotGridField(string fieldName)
        {
            var field = new WinPivotGridField
            {
                Name = @"field" + fieldName,
                FieldName = fieldName,
                Caption = @"caption " + fieldName,
                Area = PivotArea.RowArea,
                Visible = true,
            };
            return field;
        }
    }
}