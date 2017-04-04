using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.Flexible;
using EIDSS.Tests.Core;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class TreeTests : BaseFormTest
    {
        [Test]
        public void RootTest()
        {
            FlexNode rootNode = FlexNode.CreateRoot();
            Assert.IsTrue(rootNode.IsRoot);
            Assert.IsNull(rootNode.ParentNode);
            Assert.AreEqual(0, rootNode.Count);
        }

        [Test]
        public void ChildenTest()
        {
            FlexNode rootNode = FlexNode.CreateRoot();
            FlexibleFormsDS.LabelsDataTable labelsDataTable = GetLabelsDataTable();
            FlexibleFormsDS.LinesDataTable linesDataTable = GetLinesDataTable();

            rootNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[0]);
            Assert.AreEqual(1, rootNode.Count);

            FlexNode firstNode = rootNode[0];
            Assert.IsFalse(firstNode.IsRoot);
            Assert.AreEqual(rootNode, firstNode.ParentNode);
            Assert.IsTrue(firstNode.DataItem is FlexLabelItem);
            Assert.AreEqual("section", ((FlexLabelItem) firstNode.DataItem).Text);

            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[1]);
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[2]);
            firstNode.Add((FlexibleFormsDS.LinesRow) linesDataTable.Rows[0]);
            firstNode.Add((FlexibleFormsDS.LinesRow) linesDataTable.Rows[1]);
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[3]);

            Assert.AreEqual(5, firstNode.Count);
            Assert.IsTrue(firstNode[0].DataItem is FlexLabelItem);
            Assert.AreEqual("national1", ((FlexLabelItem) firstNode[0].DataItem).Text);
            Assert.IsTrue(firstNode[1].DataItem is FlexLabelItem);
            Assert.AreEqual("national2", ((FlexLabelItem) firstNode[1].DataItem).Text);
            Assert.IsTrue(firstNode[2].DataItem is FlexLineItem);
            Assert.IsTrue(firstNode[3].DataItem is FlexLineItem);
            FlexNode secondNode = firstNode[4];
            Assert.IsTrue(secondNode.DataItem is FlexLabelItem);
            secondNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[4]);
            secondNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[5]);

            Assert.AreEqual(firstNode, firstNode[0].ParentNode);
            Assert.IsFalse(firstNode[0].IsRoot);
            Assert.AreEqual(firstNode, firstNode[1].ParentNode);
            Assert.IsFalse(firstNode[1].IsRoot);
            Assert.AreEqual(firstNode, firstNode[2].ParentNode);
            Assert.IsFalse(firstNode[2].IsRoot);
            Assert.AreEqual(firstNode, firstNode[3].ParentNode);
            Assert.IsFalse(firstNode[3].IsRoot);
            Assert.AreEqual(firstNode, secondNode.ParentNode);
            Assert.IsFalse(secondNode.IsRoot);

            Assert.AreEqual(2, secondNode.Count);
            Assert.IsTrue(secondNode[0].DataItem is FlexLabelItem);
            Assert.AreEqual("param name", ((FlexLabelItem) secondNode[0].DataItem).Text);
            Assert.IsTrue(secondNode[1].DataItem is FlexLabelItem);
            Assert.AreEqual("param value", ((FlexLabelItem) secondNode[1].DataItem).Text);
        }

        [Test]
        public void ListReportVisitorTest()
        {
            FlexReport rootReport = FlexFactory.CreateFlexReport(CreateListTree(), "", null);
            Assert.AreEqual(1, rootReport.DetailBand.Controls.Count);
            Assert.IsTrue(rootReport.DetailBand.Controls[0] is XRSubreport);
            XRSubreport firstSubreport = ((XRSubreport) rootReport.DetailBand.Controls[0]);
            Assert.IsTrue(firstSubreport.ReportSource is FlexReport);
            FlexReport firstReport = (FlexReport) firstSubreport.ReportSource;
            Assert.AreEqual(5, firstReport.DetailBand.Controls.Count);
            Assert.IsTrue(firstReport.DetailBand.Controls[0] is XRLabel);
            Assert.IsTrue(firstReport.DetailBand.Controls[1] is XRLabel);
            Assert.IsTrue(firstReport.DetailBand.Controls[2] is XRShape);
            Assert.IsTrue(firstReport.DetailBand.Controls[3] is XRShape);
            Assert.IsTrue(firstReport.DetailBand.Controls[4] is XRSubreport);

            Assert.AreEqual("national1", firstReport.DetailBand.Controls[0].Text);
            Assert.AreEqual("national2", firstReport.DetailBand.Controls[1].Text);

            XRSubreport secondSubreport = ((XRSubreport) firstReport.DetailBand.Controls[4]);
            Assert.IsTrue(secondSubreport.ReportSource is FlexReport);
            FlexReport secondReport = (FlexReport) secondSubreport.ReportSource;
            Assert.AreEqual(2, secondReport.DetailBand.Controls.Count);
            Assert.IsTrue(secondReport.DetailBand.Controls[0] is XRLabel);
            Assert.IsTrue(secondReport.DetailBand.Controls[1] is XRLabel);
        }

        [Test]
        public void TableReportVisitorTest()
        {
            FlexReport rootReport = FlexFactory.CreateFlexReport(CreateTableTree(), "", null);
            Assert.AreEqual(1, rootReport.DetailBand.Controls.Count);
            //Assert.AreEqual(2, rootReport.HeaderBand.Controls.Count);
            Assert.IsTrue(rootReport.DetailBand.Controls[0] is XRSubreport);
            XRSubreport firstSubreport = ((XRSubreport) rootReport.DetailBand.Controls[0]);
            Assert.IsTrue(firstSubreport.ReportSource is FlexReport);
            FlexReport firstReport = (FlexReport) firstSubreport.ReportSource;
            Assert.AreEqual(2, firstReport.HeaderBand.Controls.Count);

            Assert.IsTrue(firstReport.HeaderBand.Controls[0] is XRLabel);
            Assert.IsTrue(firstReport.HeaderBand.Controls[1] is FlexTable);
            Assert.AreEqual("", firstReport.HeaderBand.Controls[0].Text);
            FlexTable firstTable = (FlexTable) firstReport.HeaderBand.Controls[1];
            Assert.AreEqual("national table", firstTable.HeaderCell.Text);
            Assert.AreEqual(2, firstTable.InnerRow.Cells.Count);
            Assert.AreEqual(1, firstTable.InnerRow.Cells[0].Controls.Count);
            Assert.AreEqual(0, firstTable.InnerRow.Cells[1].Controls.Count);
            Assert.IsTrue(firstTable.InnerRow.Cells[0].Controls[0] is FlexTable);
            FlexTable leftTable = (FlexTable) firstTable.InnerRow.Cells[0].Controls[0];
            Assert.AreEqual("left cell", leftTable.HeaderCell.Text);
            Assert.AreEqual("right cell", firstTable.InnerRow.Cells[1].Text);
            Assert.AreEqual(2, leftTable.InnerRow.Cells.Count);
            Assert.AreEqual(0, leftTable.InnerRow.Cells[0].Controls.Count);
            Assert.AreEqual(0, leftTable.InnerRow.Cells[1].Controls.Count);
            Assert.AreEqual("child left cell", leftTable.InnerRow.Cells[0].Text);
            Assert.AreEqual("child right cell", leftTable.InnerRow.Cells[1].Text);
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportListTest()
        {
            ShowReport(delegate { return FlexFactory.CreateFlexReport(CreateListTree(), "", null); });
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportTableTest()
        {
            ShowReport(delegate { return FlexFactory.CreateFlexReport(CreateTableTree(), "", null); });
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportViewTableTest()
        {
            IReportForm reportForm = new ReportForm();
            TestKeeper keeper = new TestKeeper();
            keeper.GenerateReportInjection = delegate() { return GenerateTableReport(); };

            reportForm.ShowReport(keeper);
            keeper.ReloadReport(true);
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportViewDynamicParametersTest()
        {
            IReportForm reportForm = new ReportForm();
            TestKeeper keeper = new TestKeeper();
            keeper.GenerateReportInjection = delegate()
                                                 {
                                                     TemplateHelper templateHelper = new TemplateHelper();
                                                     List<long> observations = new List<long>();
                                                     const long observation = 776990000000;
                                                     observations.Add(observation);
                                                     templateHelper.LoadTemplate(observations, 500000000, FFType.HumanClinicalSigns);
                                                     FlexNode node = templateHelper.GetFlexNodeFromTemplate(observation);
                                                     FlexReport report = FlexFactory.CreateFlexReport(node, "", 600);
                                                     report.Landscape = true;
                                                     return report;
                                                 };
            reportForm.ShowReport(keeper);
            keeper.ReloadReport(true);
        }

        private static FlexReport GenerateTableReport()
        {
            TemplateHelper templateHelper = new TemplateHelper();

            const long idfsFormTemplate = 250420000000;
            const long idfObservation = 22450000241;
            templateHelper.LoadTemplate(FFType.VetEpizooticActionDiagnosisInv, idfsFormTemplate, new long[] { idfObservation },
                                        new AggregateCaseSection[] { AggregateCaseSection.DiagnosticAction });
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(idfObservation);
            FlexReport report = FlexFactory.CreateFlexReport(flexNode, "", 600);
            report.Landscape = true;
            return report;
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportViewSimpleTest()
        {
            ShowReport(delegate { return GenerateReport(FFType.AggregateCase, 250410000000, 18920000241); });
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportViewSectionsTest()
        {
            ShowReport(delegate { return GenerateReport(FFType.HumanClinicalSigns, 249470000000, 18980000241); });
        }

        [Test]
        [Ignore("Manual test")]
        public void ReportViewNestedSectionsTest()
        {
            ShowReport(delegate { return GenerateReport(FFType.HumanClinicalSigns, 249640000000, 19230000241); });
        }

        public void ShowReport(GenerateReportDelegate reportCreator)
        {
            IReportForm reportForm = new ReportForm();
            TestKeeper keeper = new TestKeeper();
            keeper.GenerateReportInjection = reportCreator;

            reportForm.ShowReport(keeper);
            keeper.ReloadReport(true);
        }

        private static FlexReport GenerateReport(FFType formType, long idfsFormTemplate, long observation)
        {
            TemplateHelper templateHelper = new TemplateHelper();

            List<long> observations = new List<long>();
            observations.Add(observation);

            templateHelper.LoadTemplate(formType, idfsFormTemplate, observations, null);
            Assert.IsTrue(templateHelper.ParameterTemplate.Count > 0, "parameters not loaded!");
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
            Console.WriteLine(flexNode.Count);

            FlexReport report = FlexFactory.CreateFlexReport(flexNode, "", null);
            return report;
        }

        private static FlexNode CreateListTree()
        {
            FlexNode rootNode = FlexNode.CreateRoot();
            FlexibleFormsDS.LabelsDataTable labelsDataTable = GetLabelsDataTable();
            FlexibleFormsDS.LinesDataTable linesDataTable = GetLinesDataTable();
            rootNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[0]);
            FlexNode firstNode = rootNode[0];
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[1]);
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[2]);
            firstNode.Add((FlexibleFormsDS.LinesRow) linesDataTable.Rows[0]);
            firstNode.Add((FlexibleFormsDS.LinesRow) linesDataTable.Rows[1]);
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[3]);
            FlexNode secondNode = firstNode[4];
            secondNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[4]);
            secondNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[5]);
            return rootNode;
        }

        private static FlexNode CreateTableTree()
        {
            FlexNode rootNode = FlexNode.CreateRoot();
            FlexibleFormsDS.SectionTemplateDataTable dataTable = GetTablesDataTable();
            FlexibleFormsDS.LabelsDataTable labelsDataTable = GetTableLabelsDataTable();

            rootNode.Add((FlexibleFormsDS.SectionTemplateRow) dataTable.Rows[0]);
            FlexNode firstNode = rootNode[0];
            firstNode.Add((FlexibleFormsDS.SectionTemplateRow) dataTable.Rows[1]);
            firstNode.Add((FlexibleFormsDS.LabelsRow) labelsDataTable.Rows[0]);
            FlexNode secondNode = firstNode[0];
            secondNode.Add((FlexibleFormsDS.LabelsRow)labelsDataTable.Rows[1]);
            secondNode.Add((FlexibleFormsDS.LabelsRow)labelsDataTable.Rows[2]);

            return rootNode;
        }

        private static FlexibleFormsDS.LabelsDataTable GetLabelsDataTable()
        {
            FlexibleFormsDS.LabelsDataTable labelsDataTable = new FlexibleFormsDS.LabelsDataTable();
            labelsDataTable.AddLabelsRow(1, 2, "en", 3, 4, 5, 6, 700, 500, 0, 10, Color.Black.ToArgb(), "section",
                                         "section", Color.Black, 11);
            labelsDataTable.AddLabelsRow(10, 20, "en", 30, 40, 50, 60, 70, 80, 6, 20, Color.Red.ToArgb(), "default1",
                                         "national1", Color.Red, 110);
            labelsDataTable.AddLabelsRow(11, 21, "en", 31, 41, 150, 160, 70, 81, 0, 11, Color.Green.ToArgb(), "default1",
                                         "national2", Color.Green, 111);
            labelsDataTable.AddLabelsRow(1, 2, "en", 3, 4, 5, 400, 500, 200, 0, 10, Color.Black.ToArgb(), "subsection",
                                         "subsection", Color.Black, 11);
            labelsDataTable.AddLabelsRow(10, 20, "en", 30, 40, 50, 0, 70, 80, 2, 16, Color.Navy.ToArgb(), "default1",
                                         "param name", Color.Navy, 110);
            labelsDataTable.AddLabelsRow(11, 21, "en", 31, 41, 200, 0, 70, 80, 4, 16, Color.Blue.ToArgb(), "default1",
                                         "param value", Color.Blue, 111);
            return labelsDataTable;
        }

        private static FlexibleFormsDS.LinesDataTable GetLinesDataTable()
        {
            FlexibleFormsDS.LinesDataTable labelsDataTable = new FlexibleFormsDS.LinesDataTable();
            labelsDataTable.AddLinesRow(1, "en", 3, 4, 111, 200, 100, 1, Color.DarkViolet.ToArgb(), true,
                                        Color.DarkViolet, 1, 10);
            labelsDataTable.AddLinesRow(1, "en", 3, 4, 300, 200, 1, 100, Color.Green.ToArgb(), false, Color.Green, 1, 10);
            return labelsDataTable;
        }

        private static FlexibleFormsDS.SectionTemplateDataTable GetTablesDataTable()
        {
            FlexibleFormsDS.SectionTemplateDataTable dataTable = new FlexibleFormsDS.SectionTemplateDataTable();
            dataTable.AddSectionTemplateRow(1, 2, 3, 4, true, true, 10, 20, 300, 100, "default table",
                                            "national table", "en", true, true, 1, true, 10, 20);
            dataTable.AddSectionTemplateRow(5, 6, 7, 8, true, true, 0, 0, 200, 50, "left",
                                            "left cell", "en", true, true, 1, true, 10, 20);
            return dataTable;
        }

        private static FlexibleFormsDS.LabelsDataTable GetTableLabelsDataTable()
        {
            FlexibleFormsDS.LabelsDataTable labelsDataTable = new FlexibleFormsDS.LabelsDataTable();

            labelsDataTable.AddLabelsRow(17, 18, "en", 19, 20, 0, 0, 100, 50, 4, 12, Color.Green.ToArgb(), " right cell",
                                         "right cell", Color.Red, 111);

            labelsDataTable.AddLabelsRow(11, 21, "en", 31, 41, 0, 0, 130, 50, 4, 10, Color.Blue.ToArgb(),
                                         "child left cell",
                                         "child left cell", Color.Blue, 111);
            labelsDataTable.AddLabelsRow(17, 18, "en", 19, 20, 0, 0, 70, 50, 4, 10, Color.Red.ToArgb(),
                                         "child right cell",
                                         "child right cell", Color.Red, 111);
            return labelsDataTable;
        }
    }
}