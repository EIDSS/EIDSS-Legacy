using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class PivotGridFieldTests
    {
        private const string FieldName = @"sfLHC_CaseID";
        private const string FieldNameWithId = @"sfLHC_CaseID_idfLayoutSearchField_12345678";

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
            Assert.AreEqual(FieldName, field.OriginalName);
            Assert.AreEqual(12345678L, field.Id);
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
            Assert.AreEqual(FieldName, field.OriginalName);
            Assert.AreEqual(-1L, field.Id);
        }

      
    }
}