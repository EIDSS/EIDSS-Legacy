using System;
using System.Collections.Generic;
using System.Globalization;
using bv.common.Core;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.Factory;
using NUnit.Framework;
using GlobalSettings = bv.common.GlobalSettings;

//using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class ReportFactoryTests : BaseTests
    {
        #region Setup/Teardown

        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();

            m_Factory = new ReportFactory();
        }

        [SetUp]
        public void SetUp()
        {
            InitReportForm(false);
        }

        #endregion

        private IReportFactory m_Factory;

        private static void InitReportForm(bool isFake)
        {
            ReportFactory.CreateReportFormHandler = (isFake)
                                                        ? (CreateReportFormDelegate)
                                                          delegate { return new FakeReportForm(); }
                                                        : delegate { return new ReportForm(); };
        }

        [Test]
        public void SessionForm()
        {
            m_Factory.SessionForm(712900000000);
        }

        [Test]
        public void EventLog()
        {
            m_Factory.AdmEventLog();
        }

        [Test]
        public void HumEmergencyNotificationPdfBytesTest()
        {
            byte[] bytes = m_Factory.HumEmergencyNotificationPDFBytes("ru", 44550000204);
            Assert.IsNotEmpty(bytes);
            // File.WriteAllBytes(@"c:\1.pdf", bytes);
        }

        [Test]
        public void HumAccessionIn()
        {
            m_Factory.HumAccessionIn(128420000000);
        }

        [Test]
        public void HumCaseInvestigationForm()
        {
            m_Factory.HumCaseInvestigationForm(44550000204, 128950000002, 128960000002, 580000000);
        }

        [Test]
        public void HumDiagnosisToChangedDiagnosis()
        {
            m_Factory.HumDiagnosisToChangedDiagnosis();
        }

        [Test]
        public void HumEmergencyNotification()
        {
            m_Factory.HumEmergencyNotification(44550000204);
        }

        [Test]
        public void HumFormN1A3()
        {
            m_Factory.HumFormN1A3();
        }
        [Test]
        public void HumFormN1A4()
        {
            m_Factory.HumFormN1A4();
        }

        [Test]
        public void HumMonthlyMorbidityAndMortality()

        {
            m_Factory.HumMonthlyMorbidityAndMortality();
        }

        [Test]
        public void HumSummaryOfInfectiousDiseases()
        {
            m_Factory.HumSummaryOfInfectiousDiseases();
        }

        [Test]
        public void HumAggregateCase()
        {
            m_Factory.HumAggregateCase(11770000241, 11780000241);
        }

        [Test]
        public void HumAggregateCaseSummary()
        {
            m_Factory.HumAggregateCaseSummary(
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2010-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>",
                new long[] {11540000241, 11780000241});
        }

        [Test]
        public void VetAggregateCase()
        {
            m_Factory.VetAggregateCase(12360000241, 12370000241);
        }

        [Test]
        public void VetAggregateCaseActions()
        {
            m_Factory.VetAggregateCaseActions(5300360000000, 5300370000000, 5300380000000, 5300390000000, GetLabels());
        }

        

        [Test]
        public void VetAggregateCaseActionsSummary()
        {
            m_Factory.VetAggregateCaseActionsSummary(
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2009-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2010-12-31"" /></TimeInterval></ROOT>",
                new long[] {12730000241, 12737000000},
                new long[] {12740000241, 12738000000},
                new long[] {12750000241, 12739000000},
                GetLabels()
                );
        }
        private static Dictionary<string, string> GetLabels()
        {
            Dictionary<string, string> labels = new Dictionary<string, string>();
            foreach (string lang in GlobalSettings.SupportedLanguages.Keys)
            {
                labels.Add("@diagnosticText" + lang, "xtpDiagnosticAction.Text" + lang);
                labels.Add("@prophylacticText" + lang, "xtpProphilacticAction.Text" + lang);
                labels.Add("@sanitaryText" + lang, "xtpSanitaryAction.Text" + lang);

            }
            return labels;
        }

        [Test]
        public void VetAggregateCaseSummary()
        {
            m_Factory.VetAggregateCaseSummary(
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2009-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>",
                new long[] {12370000241});
        }

        [Test]
        public void VetAvianInvestigationForm()
        {
            m_Factory.VetAvianInvestigationForm(4970000002, 2480000000);
        }

        [Test]
        public void VetLivestockInvestigationForm()
        {
            m_Factory.VetLivestockInvestigationForm(4970000002, 2480000000);
        }

        [Test]
        public void VetSamplesCount()
        {
            m_Factory.VetSamplesCount();
        }

        [Test]
        public void VetSamplesReportBySampleType()
        {
            m_Factory.VetSamplesReportBySampleType();
        }

        [Test]
        public void VetSamplesReportBySampleTypesWithinRegions()
        {
            m_Factory.VetSamplesReportBySampleTypesWithinRegions();
        }

        [Test]
        public void VetYearlySituation()
        {
            m_Factory.VetYearlySituation();
        }

        [Test]
        public void HumSerologyResearchCard()
        {
            m_Factory.HumSerologyResearchCard();
        }
        [Test]
        public void HumMicrobiologyResearchCard()
        {
            m_Factory.HumMicrobiologyResearchCard();
        }
        [Test]
        public void HumAntibioticResistanceCard()
        {
            m_Factory.HumAntibioticResistanceCard();
        }
        [Test]
        public void Journal60BReportCard()
        {
            m_Factory.Journal60BReportCard();
        }

        [Test]
        public void HumInfectiousDiseaseMonth()
        {
            m_Factory.HumInfectiousDiseaseMonth();
        }

        [Test]
        public void HumInfectiousDiseaseIntermediateMonth()
        {
            m_Factory.HumInfectiousDiseaseIntermediateMonth();
        } 

        [Test]
        public void HumInfectiousDiseaseYear()
        {
            m_Factory.HumInfectiousDiseaseYear();
        }
        [Test]
        public void HumInfectiousDiseaseIntermediateYear()
        {
            m_Factory.HumInfectiousDiseaseIntermediateYear();
        }

        [Test]
        public void LimBatchTest()
        {
            Console.WriteLine((new CultureInfo("en-US")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("ru-RU")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("ka-GE")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("az-Latn-AZ")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("kk-KZ")).DateTimeFormat.ShortDatePattern);

            m_Factory.LimBatchTest(1780000241, 40580000000);
        }

        [Test]
        public void LimCaseTest()
        {
            m_Factory.LimCaseTest(20580000243, true);
        }

        [Test]
        public void LimContainerContent()
        {
            m_Factory.LimContainerContent(9190000002, null);
            m_Factory.LimContainerContent(null, 9190000002);
        }

        [Test]
        public void LimContainerDetails()
        {
            m_Factory.LimContainerDetails(1);
        }

        [Test]
        public void LimSampleTransferForm()
        {
            m_Factory.LimSampleTransferForm(8800000002);
        }

        [Test]
        public void LimTestResult()
        {
            m_Factory.LimTestResult(1, 2, 3);
        }

        [Test]
        public void UniOutbreak()
        {
            m_Factory.UniOutbreak(12430000004);
        }

        [Test]
        public void VetRegionPreventiveMeasures()
        {
            m_Factory.VetRegionPreventiveMeasuresReport();
        }
        [Test]
        public void VetCountryPreventiveMeasures()
        {
            m_Factory.VetCountryPreventiveMeasuresReport();
        }
        
        [Test]
        public void VetCountryProphilacticMeasures()
        {
            m_Factory.VetCountryProphilacticMeasuresReport();
        }

        [Test]
        public void VetRegionProphilacticMeasures()
        {
            m_Factory.VetRegionProphilacticMeasuresReport();
        }

        [Test]
        public void VetCountryPlannedDiagnosticTests()
        {
            m_Factory.VetCountryPlannedDiagnosticTestsReport();
        }

        [Test]
        public void VetRegionPlannedDiagnosticTests()
        {
            m_Factory.VetRegionPlannedDiagnosticTestsReport();
        }
    }
}