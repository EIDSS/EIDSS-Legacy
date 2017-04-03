using System.Collections.Generic;
using EIDSS.FlexibleForms.Helpers;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class TreeTestsForFF
    {
        private TemplateHelper templateHelper;
        private List<long> observations;

        [SetUp]
        public void Init()
        {
            templateHelper = new TemplateHelper();
            //заглушка
            observations = new List<long>();
        }


        [Test, Ignore]
        public void GetSimpleTemplate()
        {
            //простой шаблон -- только 5 параметров
            const long idfsFormTemplate = 250410000000;
            observations.Add(749700000000);
            templateHelper.LoadTemplate(FFType.AggregateCase, idfsFormTemplate, observations, null);
            Assert.IsTrue(templateHelper.ParameterTemplate.Count > 0, "parameters not loaded!");
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        }

        [Test, Ignore]
        public void GetTemplateWithSections()
        {
            //шаблон с двумя невложенными секциями и разными лейблами
            const long idfsFormTemplate = 249470000000;
            observations.Add(749870000000);
            templateHelper.LoadTemplate(FFType.HumanClinicalSigns, idfsFormTemplate, observations, null);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        }

        [Test, Ignore]
        public void GetTemplateWithNestedSections()
        {
            //шаблон с двумя невложенными секциями и разными лейблами
            const long idfsFormTemplate = 249640000000;
            observations.Add(749950000000);
            templateHelper.LoadTemplate(FFType.HumanClinicalSigns, idfsFormTemplate, observations, null);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        }

        [Test, Ignore]
        public void GetSimpleTableTemplate()
        {
            //шаблон с двумя невложенными секциями и разными лейблами
            const long idfsFormTemplate = 250430000000;
            observations.Add(757910000000);
            List<AggregateCaseSection> presetStub = new List<AggregateCaseSection>();
            presetStub.Add(AggregateCaseSection.HumanCase);
            templateHelper.LoadTemplate(FFType.HumanAggregateCase, idfsFormTemplate, observations, presetStub);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        }

        [Test, Ignore]
        public void GetAdvancedTableTemplate()
        {
            //шаблон с двумя невложенными секциями и разными лейблами
            const long idfsFormTemplate = 250420000000;
            observations.Add(758500000000);
            templateHelper.LoadTemplate(FFType.VetEpizooticActionDiagnosisInv, idfsFormTemplate, observations, new AggregateCaseSection[] { AggregateCaseSection.DiagnosticAction });
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        }


        //[Test, Ignore]
        //public void GetAnotherAdvancedTableTemplate()
        //{
        //    //шаблон с двумя невложенными секциями и разными лейблами
        //    const long idfsFormTemplate = 250500000000;
        //    observations.Add(760700000000);
        //    templateHelper.LoadTemplate(FFType.VetEpizooticActionTreatment, idfsFormTemplate, observations, new AggregateCaseSection[] { AggregateCaseSection.ProphylacticAction });
        //    FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(observations[0]);
        //}

        [Test, Ignore]
        public void GetSummary()
        {
            observations.Add(759880000000);
            observations.Add(760030000000);
            templateHelper.LoadSummary(observations, FFType.VetEpizooticActionDiagnosisInv);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplateSummary();
        }
    }
}
