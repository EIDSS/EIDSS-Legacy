using System;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using eidss.model.AVR.SourceData;
using EIDSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrRowFilterTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
        }

        [TestMethod]
        public void AvrDataRowFilterTest()
        {
            var table = new AvrDataTable();
            table.Columns.Add("sflHC_CaseID", typeof (string));
            table.Columns.Add("sflHC_EnteredDate", typeof (DateTime));

            var row = table.NewRow(new object[] {"b", new DateTime(2000, 01, 01)});

            var op = CriteriaOperator.Parse(@"[fieldsflHC_EnteredDate_idfLayoutSearchField_57595750000000] >= #2000-01-01#");
            var evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            var isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);

            op =
                CriteriaOperator.Parse(
                    @"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Is Not Null And [fieldsflHC_EnteredDate_idfLayoutSearchField_57595750000000] > #2016-02-01#");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);

            op =
                CriteriaOperator.Parse(
                    @"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Is Not Null And [fieldsflHC_EnteredDate_idfLayoutSearchField_57595750000000] < #2016-02-01#");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);

            //atomic string criterias tests:
            //Is Null
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Is Null");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            //Is not Null
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Is Not Null");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //==
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] = 'b'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //!=
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] <> 'a'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //>
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] > 'a'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //>=
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] >= 'a'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //<
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] < 'a'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] < 'c'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //<=
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] <= 'a'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] <= 'b'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] <= 'c'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //Contains
            op = CriteriaOperator.Parse(@"Contains([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'a')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            op = CriteriaOperator.Parse(@"Contains([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'b')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //Not Contains
            op = CriteriaOperator.Parse(@"Not Contains([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'a')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            op = CriteriaOperator.Parse(@"Not Contains([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'b')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            //StatrsWith
            op = CriteriaOperator.Parse(@"StartsWith([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'a')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            op = CriteriaOperator.Parse(@"StartsWith([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'b')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            //EndsWith
            op = CriteriaOperator.Parse(@"EndsWith([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'b')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            op = CriteriaOperator.Parse(@"EndsWith([fieldsflHC_CaseID_idfLayoutSearchField_57595670000000], 'a')");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            //Like
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Like 'b%'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Like 'c%'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
            //Not Like
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Not Like 'a%'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsTrue(isFit);
            op = CriteriaOperator.Parse(@"[fieldsflHC_CaseID_idfLayoutSearchField_57595670000000] Not Like 'b%'");
            evaluator = new ExpressionEvaluator(new AvrRowEvaluatorContextDescriptor(table), op);
            isFit = evaluator.Fit(row);
            Assert.IsFalse(isFit);
        }
    }
}