using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.common.Configuration;
//using bv.common.db.Core;
using bv.model.Model.Core;
//using EIDSS.FlexibleForms.DataBase;
using bv.model.Model.Extenders;
using eidss.model.Core.Security;
using eidss.model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.BLToolkit;
using eidss.model.Schema;
using eidss.model.Core;
//using EIDSS.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.FlexNodes;

namespace bv.tests.db.tests
{
    [TestClass]
    public class FFTests
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            ParameterSelect.Accessor.Instance(null);
            Parameter.Accessor.Instance(null);
            ParameterTemplate.Accessor.Instance(null);
            Section.Accessor.Instance(null);
            SectionTemplate.Accessor.Instance(null);
            FormType.Accessor.Instance(null);
        }
        [ClassCleanup]
        public static void Deinit()
        {
        }

        [TestMethod]
        public void context_cache_Test()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var cacheScope1 = new CacheScope())
            {
                using (var manager = DbManagerFactory.Factory.Create())
                {
                    var acc = Template.Accessor.Instance(cacheScope1);
                    var t1 = acc.SelectByKey(manager, 249540000000, null);
                    using (var cacheScope2 = new CacheScope())
                    {
                        var acc2 = Template.Accessor.Instance(cacheScope2);
                        var t3 = acc2.SelectByKey(manager, 249540000000, null);
                        var t4 = acc2.SelectByKey(manager, 249540000000, null);
                    }
                    var t2 = acc.SelectByKey(manager, 249540000000, null);
                }
            }

            /*
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                acc = Template.Accessor.CreateInstance<Template.Accessor>();
                Template t = acc.SelectByKey(manager, 249540000000, null);
                Assert.AreEqual("Human Clinical Signs", t.FormType.Name);
            }
            */
        }

        [TestMethod]
        [Ignore]
        public void general_template_Test()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var manager = DbManagerFactory.Factory.Create())
            {
                var acc = Template.Accessor.Instance(null);
                var t = acc.SelectByKey(manager, 979560000000, null);
                Assert.IsNotNull(t);
                Assert.AreEqual("HCS Cholera AZ", t.DefaultName);
                Assert.AreEqual("Human Clinical Signs", t.FormType.name);
                Assert.AreEqual(12, t.ParameterTemplates.Count);
                Assert.AreEqual(3, t.SectionTemplates.Count);
                Assert.AreEqual("Confirmed", t.SectionTemplates[0].DefaultName);
                Assert.AreEqual("Human Clinical Signs", t.SectionTemplates[0].FormType.name);
                Assert.IsNull(t.SectionTemplates[0].ParentSection);
                Assert.AreEqual("Confirmed", t.SectionTemplates[0].Section.DefaultName);
                Assert.AreEqual("Human Clinical Signs", t.SectionTemplates[0].Section.FormType.name);
                Assert.IsNull(t.SectionTemplates[0].Section.ParentSection);
                Assert.AreEqual(3, t.SectionTemplates[0].Section.Parameters.Count);
                Assert.AreEqual(99, t.FormType.Sections.Count);
                Assert.AreEqual(979, t.FormType.Parameters.Count);
                Assert.AreEqual(3, t.FormType.Parameters[0].SelectList.Count);
                Assert.AreEqual("Yes", t.FormType.Parameters[0].SelectList[0].strValueCaption);
                Assert.AreEqual(5, t.Labels.Count);
                Assert.AreEqual("Confirmed case", t.Labels[0].DefaultText);

                List<ActivityParameter> pars = ActivityParameter.Accessor.Instance(null).SelectList(manager, "979560000000");
                Assert.AreEqual(0, pars.Count);

                // Template has a reference of FormType and collections of SectionTemplate and ParameterTemplate
                FormType formType1 = t.FormType;
                EditableList<SectionTemplate> sectionTemplates = t.SectionTemplates;
                EditableList<ParameterTemplate> parameterTemplates = t.ParameterTemplates;
                EditableList<Label> parameterLabels = t.Labels;
                // SectionTemplate has a reference of FormType and refererencies of Section for section and parent section
                FormType formType2 = sectionTemplates[0].FormType;
                Section section1 = sectionTemplates[0].Section;
                Section sectionParent1 = sectionTemplates[0].ParentSection;
                // ParameterTemplate has a reference of FormType and reference to owner(parent) (Section) and list of ParameterSelect
                FormType formType3 = parameterTemplates[0].FormType;
                Section section3 = parameterTemplates[0].ParentSection;
                EditableList<ParameterSelect> parSelect1 = parameterTemplates[0].SelectList;
                // Section has a reference of FormType, collection of Parameters and reference to parent Section
                FormType formType4 = section1.FormType;
                EditableList<Parameter> params1 = section1.Parameters;
                Section sectionParent2 = section1.ParentSection;
                // Parameter has list of ParameterSelect
                EditableList<ParameterSelect> parSelect2 = params1[0].SelectList;
                // FormType has collections of Section and Parameter
                EditableList<Parameter> params2 = formType1.Parameters;
                EditableList<Section> sections = formType1.Sections;
            }
        }

        const string NeedNewValue = "(new)";
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";//"Administrator";
        //const string User = "test_user";
        const string AdminPassword = "test";//"EIDSS";
        //const string UserPassword = "test";

        [TestMethod]
        public void FFModel3LoadingAll()
        {
            /*
            EidssUserContext.Init();

            var dbService = new DbService();
            var transactionOpened = false;
            SqlTransaction transaction = null;
            try
            {
                if (dbService.Connection.State == ConnectionState.Closed) dbService.Connection.Open();
                Assert.IsTrue(dbService.Connection.State == ConnectionState.Open);
                //
                dbService.LoadFormTypes();
                Assert.IsTrue(dbService.MainDataSet.FormTypes.Count > 0);

                dbService.LoadSections(null, null, null);
                Assert.IsTrue(dbService.MainDataSet.Sections.Count > 0);

                dbService.LoadParameters(null, null);
                Assert.IsTrue(dbService.MainDataSet.Parameters.Count > 0);

                dbService.LoadHACodeList();
                Assert.IsNotNull(dbService.MainDataSet.HACodeList.DefaultView);

                dbService.LoadParameterEditors();
                Assert.IsTrue(dbService.MainDataSet.ParameterEditors.Count > 0);

                //ищем параметры по самому простому ключу (поиск только серверный)
                dbService.LoadParametersSearch("a");
                Assert.IsTrue(dbService.MainDataSet.ParametersSearch.Count > 0);
                dbService.LoadTemplatesByParameter(dbService.MainDataSet.ParametersSearch[0].idfsParameter);
                Assert.IsTrue(dbService.MainDataSet.TemplatesByParameter.Count > 0);

                var rowFormType = dbService.MainDataSet.FormTypes[0];

                dbService.LoadDeterminantTypes(rowFormType.idfsFormType);
                Assert.IsTrue(dbService.MainDataSet.DeterminantTypes.Count > 0);

                dbService.LoadDeterminants();
                Assert.IsTrue(dbService.MainDataSet.Determinants.Count > 0);

                dbService.LoadTemplates(rowFormType.idfsFormType);

                #region Создаём новую секцию

                //секция обычная, не табличная
                var rowSection = dbService.MainDataSet.Sections.NewSectionsRow();
                rowSection.idfsFormType = rowFormType.idfsFormType;
                rowSection.blnGrid = rowSection.blnFixedRowset = false;

                //подсчитаем, сколько секций, с наименованием по умолчанию уже содержится в таблице
                rowSection.DefaultName = "Section1";
                rowSection.NationalName = "Section1";
                rowSection.intOrder = 0;
                rowSection.langid = ModelUserContext.CurrentLanguage;
                //добавим строку
                dbService.MainDataSet.Sections.AddSectionsRow(rowSection);

                #endregion

                #region создаём новый параметр

                var rowParameter = dbService.MainDataSet.Parameters.NewParametersRow();
                rowParameter.idfsSection = rowSection.idfsSection;
                rowParameter.idfsFormType = rowFormType.idfsFormType;
                rowParameter.intScheme = 0;
                rowParameter.idfsParameterType = 217140000000; //Yes No Unknown
                rowParameter.idfsEditor = 10067002; //combo box
                rowParameter.intOrder = 0;
                rowParameter.intHACode = 0; //????
                rowParameter.intLabelSize = 75;
                rowParameter.intLeft = 0;
                rowParameter.intTop = 0;
                rowParameter.intWidth = 150;
                rowParameter.intHeight = 100;
                rowParameter.langid = ModelUserContext.CurrentLanguage;

                dbService.MainDataSet.Parameters.AddParametersRow(rowParameter);

                #endregion

                #region Создаём новый шаблон

                var rowTemplate = dbService.MainDataSet.Templates.NewTemplatesRow();
                rowTemplate.idfsFormType = rowFormType.idfsFormType;
                //если это первый шаблон в своём типе формы, то сделаем его UNI
                rowTemplate.blnUNI = (dbService.GetTemplatesByFormType(rowFormType.idfsFormType).Length == 0);
                rowTemplate.DefaultName = "Template1";
                rowTemplate.NationalName = "Template1";
                rowTemplate.NationalLongName = "Template Long name 1";
                rowTemplate.langid = ModelUserContext.CurrentLanguage;
                dbService.MainDataSet.Templates.AddTemplatesRow(rowTemplate);

                #endregion

                #region Добавляем на шаблон детерминанты

                var countries = dbService.GetDeterminants(bv.common.FFDeterminantTypes.Country);
                if (countries.Length > 0)
                {
                    dbService.CreateTemplateDeterminantValuesRow(countries[0], rowTemplate.idfsFormTemplate, rowTemplate.idfsFormType);
                }

                var diagnoses = dbService.GetDeterminants(bv.common.FFDeterminantTypes.Diagnosis);
                if (diagnoses.Length > 0)
                {
                    dbService.CreateTemplateDeterminantValuesRow(diagnoses[0], rowTemplate.idfsFormTemplate, rowTemplate.idfsFormType);
                }

                #endregion

                //сохранение шаблона
                transaction = (SqlTransaction)dbService.Connection.BeginTransaction();
                transactionOpened = true;
                dbService.PostDetail(dbService.MainDataSet, 0, transaction);

                #region Добавляем секцию в шаблон

                var rowSectionTemplate = dbService.CreateSectionTemplateRow(rowSection, rowTemplate.idfsFormTemplate);
                rowSectionTemplate.intLeft = 10;
                rowSectionTemplate.intTop = 10;
                rowSectionTemplate.intWidth = 150;
                rowSectionTemplate.intHeight = 100;

                #endregion

                #region Добавляем параметр в шаблон

                var rowParameterTemplate = dbService.CreateParameterTemplateRow(rowParameter, rowTemplate.idfsFormTemplate);
                //параметр внутри секции
                rowParameterTemplate.intLeft = 10;
                rowParameterTemplate.intTop = 10;
                rowParameterTemplate.intWidth = 120;
                rowParameterTemplate.intHeight = 80;
                rowParameterTemplate.intLabelSize = 60;

                #endregion

                #region Добавляем лейбл в шаблон

                var rowLabel = dbService.MainDataSet.Labels.NewLabelsRow();
                rowLabel.idfsDecorElementType = (long)FFDecorElementTypes.Label;
                rowLabel.langid = ModelUserContext.CurrentLanguage;
                rowLabel.idfsFormTemplate = rowTemplate.idfsFormTemplate;
                rowLabel.idfsSection = rowSection.idfsSection;
                rowLabel.intLeft = 5;
                rowLabel.intTop = 105;
                rowLabel.intWidth = 60;
                rowLabel.intHeight = 20;
                rowLabel.intColor = Color.Black.ToArgb();
                rowLabel.intFontSize = 10;
                rowLabel.intFontStyle = (int)FontStyle.Regular;
                rowLabel.DefaultText = "Label 1";
                rowLabel.NationalText = "Label 1";

                dbService.MainDataSet.Labels.AddLabelsRow(rowLabel);

                #endregion

                #region Добавляем линию в шаблон

                var rowLine = dbService.MainDataSet.Lines.NewLinesRow();
                rowLine.idfsDecorElementType = (long)FFDecorElementTypes.Line;
                //создаём именно для используемого в данный момент языка

                rowLine.langid = ModelUserContext.CurrentLanguage;
                rowLine.idfsFormTemplate = rowTemplate.idfsFormTemplate;
                rowLine.idfsSection = rowSection.idfsSection;
                rowLine.SetblnOrientationNull();
                rowLine.intLeft = 5;
                rowLine.intTop = 125;
                rowLine.intWidth = 100;
                rowLine.intHeight = 15;
                rowLine.intColor = Color.Black.ToArgb();

                dbService.MainDataSet.Lines.AddLinesRow(rowLine);

                #endregion

                //снова сохраняем
                dbService.PostDetail(dbService.MainDataSet, 0, transaction);

                #region Проверка ID

                Assert.IsTrue(rowSection.idfsSection > -1);
                Assert.IsTrue(rowParameter.idfsParameter > -1);
                Assert.IsTrue(rowTemplate.idfsFormTemplate > -1);

                Assert.IsTrue(rowParameterTemplate.idfsParameter > -1);
                Assert.IsTrue(rowParameterTemplate.idfsFormTemplate > -1);

                Assert.IsTrue(rowParameterTemplate.idfsSection > -1);
                Assert.IsTrue(rowParameterTemplate.idfsFormTemplate > -1);

                Assert.IsTrue(rowLine.idfDecorElement > -1);
                Assert.IsTrue(rowLabel.idfDecorElement > -1);

                #endregion

                #region Добавление правил                

                #endregion

                //снова сохраняем
                dbService.PostDetail(dbService.MainDataSet, 0, transaction);

                transaction.Commit();//.Rollback();
                transactionOpened = false;

                #region Перезагрузка сущностей

                dbService.LoadParameterSelectList(rowParameter.idfsParameter, rowParameter.idfsParameterType, rowParameter.intHACode);

                #endregion

                #region Дополнительные проверки

                //TODO проверить удаление параметра и ressurection
                //LoadParameterDeletedFromTemplate

                #endregion

                #region Проверка загрузки данных

                //создаём ещё один датасервис и через него проверяем правильность сохранения
                var dbService2 = new DbService();

                dbService2.LoadTemplates(rowTemplate.idfsFormType);
                var template = dbService2.GetTemplateRow(rowTemplate.idfsFormTemplate);
                Assert.IsNotNull(template);

                dbService2.LoadTemplateDeterminants(template.idfsFormTemplate);
                var determinants = dbService2.GetTemplateDeterminants(template.idfsFormTemplate);
                Assert.IsNotNull(determinants);
                Assert.IsTrue(determinants.Length == 2);

                dbService2.LoadSectionTemplate(template.idfsFormTemplate);
                var sectionsTemplate = dbService2.GetSectionTemplateRows(null, template.idfsFormTemplate);
                Assert.IsNotNull(sectionsTemplate);
                Assert.IsTrue(sectionsTemplate.Length == 1);

                dbService2.LoadParameterTemplate(template.idfsFormTemplate);
                var parametersTemplate = dbService2.GetParameterTemplateRows(null, template.idfsFormTemplate);
                Assert.IsNotNull(parametersTemplate);
                Assert.IsTrue(parametersTemplate.Length == 1);

                dbService2.LoadLines(template.idfsFormTemplate);
                var lines = dbService2.GetLineTemplateRows(template.idfsFormTemplate);
                Assert.IsNotNull(lines);
                Assert.IsTrue(lines.Length == 1);

                dbService2.LoadLabels(template.idfsFormTemplate);
                var labels = dbService2.GetLabelTemplateRows(template.idfsFormTemplate);
                Assert.IsNotNull(labels);
                Assert.IsTrue(labels.Length == 1);

                #endregion

                #region Удаление созданных объектов

                //удаляем его детерминанты
                dbService2.DeleteDeterminantsFromTemplate(template.idfsFormTemplate);
                //удаляем связанные секции
                dbService2.DeleteSectionTemplate(template.idfsFormTemplate, String.Empty);
                //удаляем связанные параметры
                dbService2.DeleteParameterTemplate(template.idfsFormTemplate, String.Empty);
                //удаляем связанные правила
                dbService2.DeleteRulesFromTemplate(template.idfsFormTemplate);
                //удаляем связанные лейблы
                dbService2.DeleteLabelTemplate(template.idfsFormTemplate, String.Empty);
                //удаляем связанные линии
                dbService2.DeleteLineTemplate(template.idfsFormTemplate, String.Empty);

                //удаляем строку
                template.Delete();

                dbService.PostDetail(dbService2.MainDataSet, 0, null);

                #endregion

                //    LoadMatrixStubInfo
                //        LoadObservations
                //    LoadParametersSearch
                //        LoadPredefinedStub
                //        LoadRuleConstants
                //            LoadRuleFunctions
                //            LoadRuleParameterForAction
                //                LoadRuleParameterForFunction
                //                LoadRulesForTemplate
                //                    LoadSections
            }
            finally
            {
                if ((transaction != null) && transactionOpened) transaction.Rollback();
                if (dbService.Connection.State != ConnectionState.Closed) dbService.Connection.Close();
                EidssUserContext.Clear();
            }
            */
        }

        [TestMethod]
        [Ignore]
        public void FFPresenterModelTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            var target = new EidssSecurityManager();
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);

            var session = VsSessionTest.GetTestSession();
            var idSession = session.idfVectorSurveillanceSession;

            Assert.IsTrue(session.PoolsVectors.Count >= 2);

            //определяем шаблон
            const long countryDeterminant = 780000000;
            const long secondDeterminant = 4576490000000; //Tick (vector type)

            //создаются в TestSection
            var vector1 = session.PoolsVectors[0];
            var vector2 = session.PoolsVectors[1];

            var vector1Observation = vector1.idfObservation;
            var vector2Observation = vector2.idfObservation;
            Assert.IsNotNull(vector1Observation);
            Assert.IsNotNull(vector2Observation);

            var ffPresenter1 = vector1.FFPresenter;
            var ffPresenter2 = vector2.FFPresenter;

            //инициируем шаблон
            ffPresenter1.SetProperties(countryDeterminant, secondDeterminant, FFTypeEnum.VectorTypeSpecificData, vector1Observation.Value);
            ffPresenter2.SetProperties(countryDeterminant, secondDeterminant, FFTypeEnum.VectorTypeSpecificData, vector2Observation.Value);
            Assert.IsNotNull(ffPresenter1.CurrentTemplate);
            Assert.IsNotNull(ffPresenter1.ActivityParameters);
            Assert.IsNotNull(ffPresenter2.CurrentTemplate);
            Assert.IsNotNull(ffPresenter2.ActivityParameters);

            Assert.IsTrue(ffPresenter1.CurrentTemplate.ParameterTemplates.Count > 0);

            //заводим значения в разные вектора. Но шаблон у них один. В реальности для каждого вектора шаблон будет перезагружаться.
            var idParameter = ffPresenter1.CurrentTemplate.ParameterTemplates[0].idfsParameter;

            //добавляем значения
            ffPresenter1.ActivityParameters.SetActivityParameterValue(
                ffPresenter1.CurrentTemplate
                , vector1Observation.Value
                , idParameter
                , 25460000000 //Yes-No-Unknown = YES
                );

            ffPresenter2.ActivityParameters.SetActivityParameterValue(
                ffPresenter2.CurrentTemplate
                , vector2Observation.Value
                , idParameter
                , 25660000000 //Yes-No-Unknown = UNKNOWN
                );

            Assert.IsTrue(ffPresenter1.ActivityParameters.Count == 1);
            Assert.IsTrue(ffPresenter2.ActivityParameters.Count == 1);

            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var acc = VsSession.Accessor.Instance(null);
                    manager.BeginTransaction();
                    //сохраняем значения
                    Assert.IsTrue(acc.Post(manager, session));
                    //загружаем сохранённую сессию из БД
                    session = acc.SelectByKey(manager, idSession);

                    //
                    Assert.IsNotNull(session);
                    Assert.IsTrue(session.PoolsVectors.Count >= 2);
                    vector1 = session.PoolsVectors[0];
                    vector2 = session.PoolsVectors[1];

                    vector1Observation = vector1.idfObservation;
                    vector2Observation = vector2.idfObservation;
                    Assert.IsNotNull(vector1Observation);
                    Assert.IsNotNull(vector2Observation);

                    ffPresenter1 = vector1.FFPresenter;
                    ffPresenter2 = vector2.FFPresenter;

                    Assert.IsNotNull(ffPresenter1);
                    Assert.IsNotNull(ffPresenter2);

                    Assert.IsTrue(ffPresenter1.ActivityParameters.Count == 1);
                    Assert.IsTrue(ffPresenter2.ActivityParameters.Count == 1);

                    manager.RollbackTransaction();
                    //manager.CommitTransaction();
                }
            }

            EidssUserContext.Clear();
        }

        [TestMethod]
        public void VetCaseFF()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                var result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var accVetCase = VetCase.Accessor.Instance(null);

                    var vc = accVetCase.CreateNewT(manager, null, (int)HACode.Livestock);
                    var id = vc.idfCase;

                    Assert.IsNotNull(vc.Farm);
                    Assert.IsNotNull(vc.AnimalList);
                    Assert.IsNotNull(vc.CaseTests);

                    #region Farm Tree Item

                    var farmTreeAccessor = VetFarmTree.Accessor.Instance(null);
                    var herdFarmTree = farmTreeAccessor.CreateHerd(manager, vc.Farm, vc.Farm.FarmTree[0]);
                    var speciesFarmTree = farmTreeAccessor.CreateSpecies(manager, vc.Farm, herdFarmTree);

                    CheckFFPresenter(speciesFarmTree.FFPresenterCs);

                    vc.Farm.FarmTree.Add(herdFarmTree);
                    vc.Farm.FarmTree.Add(speciesFarmTree);

                    #endregion

                    #region Animal List Item

                    var animalListItemAccessor = AnimalListItem.Accessor.Instance(null);
                    var animalListItem = animalListItemAccessor.CreateNewT(manager, vc, (int)HACode.Livestock);
                    animalListItem.CopyMainProperties(speciesFarmTree);

                    CheckFFPresenter(animalListItem.FFPresenterCs);

                    vc.AnimalList.Add(animalListItem);

                    #endregion

                    #region Case test

                    var caseTestAccessor = CaseTest.Accessor.Instance(null);
                    var caseTest = caseTestAccessor.Create(manager, vc, vc.idfCase);
                    caseTest.TestTypeRef = caseTest.TestTypeRefLookup.FirstOrDefault();
                    caseTest.VetCaseSample = caseTest.VetCaseSampleLookup.FirstOrDefault();
                    caseTest.TestResultRef = caseTest.TestResultRefLookup.FirstOrDefault();

                    Assert.IsNotNull(caseTest.FFPresenter);
                    Assert.IsNotNull(caseTest.FFPresenter.CurrentObservation);
                    Assert.IsNotNull(caseTest.FFPresenter.CurrentTemplate);

                    vc.CaseTests.Add(caseTest);

                    #endregion

                    #region Проверка FF

                    Assert.IsNotNull(vc.FFPresenterControlMeasures);
                    Assert.IsNotNull(vc.FFPresenterControlMeasures.CurrentObservation);

                    //выставляем диагноз
                    vc.TentativeDiagnosis =
                        vc.TentativeDiagnosisLookup.Where(c => (c.name == "Brucellosis") || (c.name == "Brucellosis - Unspecified")).FirstOrDefault();
                    
                    Assert.IsNotNull(vc.idfsDiagnosis);

                    //проверяем выставление нужных объектов в головном и дочерних объектах
                    CheckFFPresenter(vc.FFPresenterControlMeasures);
                    CheckFFPresenter(vc.Farm.FFPresenterEpi);
                    CheckFFPresenter(speciesFarmTree.FFPresenterCs);
                    CheckFFPresenter(animalListItem.FFPresenterCs);
                    CheckFFPresenter(caseTest.FFPresenter);

                    #endregion

                    #region Задание обязательных параметров

                    vc.strSummaryNotes = "aaa";
                    Assert.AreEqual("aaa", vc.strSummaryNotes);
                    vc.strTestNotes = "bbb";
                    vc.strSummaryNotes = "aaa";
                    Assert.AreEqual("aaa", vc.strSummaryNotes);
                    vc.strSampleNotes = "AAA";
                    vc.strSummaryNotes = "bbb";
                    Assert.AreEqual("bbb", vc.strSummaryNotes);

                    vc.Farm.Location.Region = vc.Farm.Location.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
                    Assert.AreEqual("Abkhazia", vc.Farm.Location.Region.strRegionName);
                    Assert.IsTrue(vc.Farm.Location.RayonLookup.Count > 0);
                    Assert.IsTrue(vc.Farm.Location.SettlementLookup.Count == 1);

                    vc.Farm.Location.Rayon = vc.Farm.Location.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
                    Assert.AreEqual("Gagra", vc.Farm.Location.Rayon.strRayonName);
                    Assert.IsTrue(vc.Farm.Location.SettlementLookup.Count > 1);

                    vc.Farm.Location.Settlement = vc.Farm.Location.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).SingleOrDefault();
                    Assert.AreEqual("Achmarda", vc.Farm.Location.Settlement.strSettlementName);

                    vc.Farm.Address.CopyGeoLocationValues(vc.Farm.Location);

                    vc.datAssignedDate = DateTime.Now.AddDays(-3);
                    vc.datReportDate = DateTime.Now.AddDays(-4);
                    vc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-2);
                    vc.datTentativeDiagnosis1Date = DateTime.Now.AddDays(-1);
                    vc.datTentativeDiagnosis2Date = DateTime.Now.AddDays(-1);

                    vc.strClinicalNotes = "cln";
                    vc.strSampleNotes = "BBB";

                    #endregion

                    //дополнительные проверки, чтобы прошла валидация
                    Assert.IsNotNull(animalListItem.idfSpecies);
                    Assert.IsNotNull(vc.Farm.Address.Rayon);
                    Assert.IsNotNull(vc.Farm.Address.Region);
                    Assert.IsNotNull(vc.Farm.Address.Settlement);

                    #region Добавляем пользовательские данные

                    //добавляем значения

                    var template = vc.FFPresenterControlMeasures.CurrentTemplate;
                    if (template.ParameterTemplates.Count > 0)
                    {
                        long idParameter = 0;

                        //пробуем отыскать в шаблоне Yes-No-Unknown
                        var parameter = template.ParameterTemplates.Where(c => c.idfsParameterType == 217140000000).FirstOrDefault();
                        if (parameter != null)
                        {
                            idParameter = parameter.idfsParameter;
                        }
                        else
                        {
                            parameter = template.ParameterTemplates.Where(c => c.idfsParameterType == (long)FFParameterTypes.String).FirstOrDefault();
                            if (parameter != null)
                            {
                                idParameter = parameter.idfsParameter;
                            }
                        }

                        if (idParameter > 0)
                        {
                            var idObservation = vc.FFPresenterControlMeasures.CurrentObservation.Value;

                            vc.FFPresenterControlMeasures.ActivityParameters.SetActivityParameterValue(
                                template
                                , idObservation
                                , idParameter
                                , 25460000000 //Yes-No-Unknown = YES
                                );
                        }
                    }

                    #endregion

                    manager.BeginTransaction();

                    vc.Validation += vc_Validation4;
                    vc.CaseTests.RemoveAll(c => true);
                    Assert.IsTrue(accVetCase.Post(manager, vc));
                    vc.Validation -= vc_Validation4;

                    var vetCase = accVetCase.SelectByKey(manager, id);
                    Assert.IsNotNull(vetCase);
                    Assert.IsTrue(vetCase.Farm.FarmTree.Count > 0);
                    Assert.IsTrue(vetCase.AnimalList.Count > 0);
                    //TODO вставить проверку для CaseTest, когда он будет сохраняться

                    #region Проверка наличия FF в головном и всех дочерних объектах

                    CheckFFPresenter(vetCase.FFPresenterControlMeasures);

                    var ft = vetCase.Farm.FarmTree[0];
                    var al = vetCase.AnimalList[0];

                    CheckFFPresenter(vetCase.Farm.FFPresenterEpi);
                    if (ft.FFPresenterCs != null) CheckFFPresenter(ft.FFPresenterCs);
                    CheckFFPresenter(al.FFPresenterCs);

                    #endregion

                    #region Проверка пользовательских данных

                    Assert.IsTrue(vetCase.FFPresenterControlMeasures.ActivityParameters.Count > 0);

                    #endregion

                    manager.RollbackTransaction();
                }
                EidssUserContext.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffPresenterModel"></param>
        public static void CheckFFPresenter(FFPresenterModel ffPresenterModel)
        {
            Assert.IsNotNull(ffPresenterModel);
            Assert.IsNotNull(ffPresenterModel.CurrentObservation);
            Assert.IsNotNull(ffPresenterModel.CurrentTemplate);
            Assert.IsNotNull(ffPresenterModel.CurrentTemplate.idfsFormTemplate > 0);
            Assert.IsTrue(ffPresenterModel.CurrentObservation.Value > 0);
        }

        private void vc_Validation1(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            Assert.AreEqual("strTestNotes", args.FieldName);
        }

        private void vc_Validation2(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("AAA", args.MessageId);
            Assert.AreEqual("", args.FieldName);
        }

        private void vc_Validation3(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            //Assert.AreEqual("strClinicalNotes", args.FieldName);
        }

        private void vc_Validation4(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            args.Continue = true;
        }

        [TestMethod]
        public void HumanAggregateCaseTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                var result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var hacAcc = HumanAggregateCase.Accessor.Instance(null);
                    var hc = hacAcc.CreateWithParamsT(manager, null, null);
                    Assert.IsNotNull(hc.Detailed);
                    Assert.IsNotNull(hc.Header);

                    Assert.IsTrue(hc.Header.idfVersion > 0);

                    Assert.IsNotNull(hc.Header.FFPresenterCase);
                    Assert.IsNull(hc.Header.FFPresenterDiagnostic);
                    Assert.IsNull(hc.Header.FFPresenterSanitary);
                    Assert.IsNull(hc.Header.FFPresenterProphylactic);

                    CheckFFPresenter(hc.Header.FFPresenterCase);

                    //должны быть загружены данные боковика
                    Assert.IsTrue(hc.Header.FFPresenterCase.ActivityParameters.Count > 0);

                    Assert.IsTrue(hc.Header.FFPresenterCase.CurrentTemplate.ParameterTemplates.Count > 0);

                    //заводим значения в разные вектора. Но шаблон у них один. В реальности для каждого вектора шаблон будет перезагружаться.
                    var idParameter = hc.Header.FFPresenterCase.CurrentTemplate.ParameterTemplates[0].idfsParameter;

                    //добавляем значения
                    // ReSharper disable PossibleInvalidOperationException
                    hc.Header.FFPresenterCase.ActivityParameters.SetActivityParameterValue(
                        hc.Header.FFPresenterCase.CurrentTemplate
                        , hc.Header.FFPresenterCase.CurrentObservation.Value
                        , idParameter
                        , 25
                        );
                    // ReSharper restore PossibleInvalidOperationException

                    var idAggrCase = hc.idfAggrCase;
                    Assert.IsNotNull(idAggrCase);

                    manager.BeginTransaction();
                    //сохраняем значения
                    //var achAcc = AggregateCaseHeader.Accessor.Instance(null);
                    //Assert.IsTrue(achAcc.Post(manager, hc.Header));

                    var ffAcc = eidss.model.Schema.FFPresenterModel.Accessor.Instance(null);
                    var idObservation = hc.Header.FFPresenterCase.CurrentObservation.Value;
                    var idfVersion = hc.Header.idfVersion;
                    Assert.IsNotNull(idfVersion);
                    //только для теста!
                    hc.Header.FFPresenterCase.SaveObservation();
                    Assert.IsTrue(ffAcc.Post(manager, hc.Header.FFPresenterCase));

                    //загружаем БД
                    /*
                    var hc2 = hacAcc.SelectByKey(manager, idAggrCase);
                    Assert.IsNotNull(hc2);
                    Assert.IsNotNull(hc2.Detailed);
                    Assert.IsNotNull(hc2.Header);
                    CheckFFPresenter(hc2.Header.FFPresenterCase);
                    */

                    var ff = ffAcc.SelectByKey(manager, idObservation);
                    CheckFFPresenter(ff);
                    Assert.IsTrue(ff.ActivityParameters.Count == 1);
                    //восстанавливаем боковик
                    ff.PrepareAggregateCase(AggregateCaseSectionEnum.HumanCase, idfVersion.Value);

                    Assert.IsTrue(ff.ActivityParameters.Count == hc.Header.FFPresenterCase.ActivityParameters.Count);

                    //в шаблоне единственный узел -- табличная секция.
                    Assert.IsTrue(ff.TemplateFlexNode.ChildListCount == 1);
                    var sectionNode = ff.TemplateFlexNode.ChildList.ElementAt(0);
                    var section = sectionNode.GetSectionTemplate();
                    Assert.IsNotNull(section);
                    Assert.IsTrue(section.blnGrid);

                    //параметры тела таблицы
                    //var pt = sectionNode.GetColumnsInfoForDataTable();
                    //Assert.IsTrue(pt.Count == ff.CurrentTemplate.ParameterTemplates.Count);

                    //пересчитываем node шаблона с учётом боковика
                    ff.RebuildTemplateFlexNode();
                    sectionNode = ff.TemplateFlexNode.ChildList.ElementAt(0);
                    //var pt = sectionNode.GetColumnsInfoForDataTable();

                    //преобразуем табличную секцию в таблицу
                    var sectionDataTable = sectionNode.GetDataTableForSectionTable();
                    Assert.IsNotNull(sectionDataTable);
                    //в столбцах идут параметры
                    //Assert.IsTrue(sectionDataTable.Columns.Count > pt.Count);

                    manager.RollbackTransaction();

                    //var accHcDetail = HumanAggregateCaseDetailed.Accessor.Instance(null);
                    //var accVcDetail = VetAggregateCaseDetailed.Accessor.Instance(null);
                    //var accVaDetail = VetAggregateActionDetailed.Accessor.Instance(null);

                    //var hcDetail = accHcDetail.CreateWithParamsT(manager, null);
                    //var vcDetail = accVcDetail.CreateWithParamsT(manager, null);
                    //var vaDetail = accVaDetail.CreateWithParamsT(manager, null);

                    //Assert.IsTrue(hcDetail.idfVersion > 0);
                    //Assert.IsTrue(vcDetail.idfVersion > 0);
                    //Assert.IsTrue(vaDetail.idfVersion > 0);

                    //var accessor = AggregateCaseHeader.Accessor.Instance(null);
                    //var headerHC = accessor.CreateWithParams(manager, (long)AggregateCaseType.HumanAggregateCase, hcDetail.idfVersion);
                    //var headerVC = accessor.CreateWithParams(manager, (long)AggregateCaseType.VetAggregateCase, vcDetail.idfVersion);
                    //var headerVA = accessor.CreateWithParams(manager, (long)AggregateCaseType.VetAggregateAction, vaDetail.idfVersion);

                    //HC
                    //Assert.IsNotNull(headerHC.FFPresenterCase);
                    //Assert.IsNull(headerHC.FFPresenterDiagnostic);
                    //Assert.IsNull(headerHC.FFPresenterSanitary);
                    //Assert.IsNull(headerHC.FFPresenterProphylactic);
                    ////VC
                    //Assert.IsNotNull(headerVC.FFPresenterCase);
                    //Assert.IsNull(headerVC.FFPresenterDiagnostic);
                    //Assert.IsNull(headerVC.FFPresenterSanitary);
                    //Assert.IsNull(headerVC.FFPresenterProphylactic);
                    ////VA
                    //Assert.IsNull(headerVA.FFPresenterCase);
                    //Assert.IsNotNull(headerVA.FFPresenterDiagnostic);
                    //Assert.IsNotNull(headerVA.FFPresenterSanitary);
                    //Assert.IsNotNull(headerVA.FFPresenterProphylactic);

                    //наличие шаблонов
                    //CheckFFPresenter(headerHC.FFPresenterCase);
                    //CheckFFPresenter(headerVC.FFPresenterCase);
                    //CheckFFPresenter(headerVA.FFPresenterDiagnostic);
                    //CheckFFPresenter(headerVA.FFPresenterSanitary);
                    //CheckFFPresenter(headerVA.FFPresenterProphylactic);


                }
            }
        }

        [TestMethod]
        public void SectionTableTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                var result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var hacAcc = HumanAggregateCase.Accessor.Instance(null);
                    var hc = hacAcc.CreateWithParamsT(manager, null, null);
                    var idAggrCase = hc.idfAggrCase;
                    Assert.IsNotNull(idAggrCase);
                    var idfVersion = hc.Header.idfVersion;
                    Assert.IsNotNull(idfVersion);

                    var ff = hc.Header.FFPresenterCase;
                    //должны быть загружены данные боковика
                    Assert.IsTrue(ff.ActivityParameters.Count > 0);

                    Assert.IsTrue(ff.CurrentTemplate.ParameterTemplates.Count > 0);

                    //заводим значения в разные вектора. Но шаблон у них один. В реальности для каждого вектора шаблон будет перезагружаться.
                    //var idParameter = ff.CurrentTemplate.ParameterTemplates[0].idfsParameter;

                    //добавляем значения
                    // ReSharper disable PossibleInvalidOperationException
                    //TODO добавить значение, но в строку idfRow из боковика
                    //ff.ActivityParameters.SetActivityParameterValue(
                    //    ff.CurrentTemplate
                    //    , ff.CurrentObservation.Value
                    //    , idParameter
                    //    , 25
                    //    );
                    // ReSharper restore PossibleInvalidOperationException

                    //manager.BeginTransaction();

                    CheckFFPresenter(ff);
                    Assert.IsTrue(ff.ActivityParameters.Count > 0);
                    //восстанавливаем боковик
                    ff.PrepareAggregateCase(AggregateCaseSectionEnum.HumanCase, idfVersion.Value);

                    Assert.IsTrue(ff.ActivityParameters.Count == hc.Header.FFPresenterCase.ActivityParameters.Count);

                    //в шаблоне единственный узел -- табличная секция.
                    Assert.IsTrue(ff.TemplateFlexNode.ChildListCount == 1);
                    var sectionNode = ff.TemplateFlexNode.ChildList.ElementAt(0);
                    var section = sectionNode.GetSectionTemplate();
                    Assert.IsNotNull(section);
                    Assert.IsTrue(section.blnGrid);

                    //параметры тела таблицы
                    //var pt = sectionNode.GetColumnsInfoForDataTable();
                    //Assert.IsTrue(pt.Count == ff.CurrentTemplate.ParameterTemplates.Count);

                    //пересчитываем node шаблона с учётом боковика
                    ff.RebuildTemplateFlexNode();
                    sectionNode = ff.TemplateFlexNode.ChildList.ElementAt(0);
                    //var pt = sectionNode.GetColumnsInfoForDataTable();

                    //преобразуем табличную секцию в таблицу
                    var sectionDataTable = sectionNode.GetDataTableForSectionTable();
                    Assert.IsNotNull(sectionDataTable);
                    Assert.IsTrue(sectionDataTable.Rows.Count > 0);

                    //manager.RollbackTransaction();
                }
            }
        }

        [TestMethod]
        [Ignore]
        public void SummaryTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                var result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var ffModel = new FFPresenterModel((long)FFTypeEnum.HumanAggregateCase);

                    const long idFormHumanAggregate = 6966590000000;//981280000000;

                    ffModel.SetProperties(idFormHumanAggregate);

                    manager.BeginTransaction();

                    //создаём две обсервации и наполняем тестовыми данными
                    var accObservation = Observation.Accessor.Instance(null);
                    var observation1 = accObservation.CreateNewT(manager, ffModel);
                    var observation2 = accObservation.CreateNewT(manager, ffModel);
                    observation1.idfsFormTemplate = observation2.idfsFormTemplate = idFormHumanAggregate;
                    ffModel.SaveObservation(observation1.idfObservation, observation1.idfsFormTemplate.Value);
                    ffModel.SaveObservation(observation2.idfObservation, observation2.idfsFormTemplate.Value);

                    #region Тестовые данные

                    var accAP = ActivityParameter.Accessor.Instance(null);
                    //ap1 и ap3 в одном столбце
                    var ap1 = accAP.CreateNewT(manager, ffModel);
                    ap1.idfsParameter = 1023700000000;
                    ap1.idfObservation = observation1.idfObservation;
                    ap1.idfsFormTemplate = observation1.idfsFormTemplate.Value;
                    ap1.varValue = 100;
                    ap1.idfRow = 3021680000000;

                    var ap2 = accAP.CreateNewT(manager, ffModel);
                    ap2.idfsParameter = 1024220000000;
                    ap2.idfObservation = observation2.idfObservation;
                    ap2.idfsFormTemplate = observation2.idfsFormTemplate.Value;
                    ap2.varValue = 5;
                    ap2.idfRow = 3021680000000;

                    var ap3 = accAP.CreateNewT(manager, ffModel);
                    ap3.idfsParameter = 1023700000000;
                    ap3.idfObservation = observation2.idfObservation;
                    ap3.idfsFormTemplate = observation2.idfsFormTemplate.Value;
                    ap3.varValue = 50;
                    ap3.idfRow = 3021680000000;

                    var ap4 = accAP.CreateNewT(manager, ffModel);
                    ap4.idfsParameter = 1023700000000;
                    ap4.idfObservation = observation2.idfObservation;
                    ap4.idfsFormTemplate = observation2.idfsFormTemplate.Value;
                    ap4.varValue = 480;
                    ap4.idfRow = 3021710000000;

                    accAP.Post(manager, ap1);
                    accAP.Post(manager, ap2);
                    accAP.Post(manager, ap3); 
                    accAP.Post(manager, ap4);

                    #endregion

                    var observations = new List<long> {observation1.idfObservation, observation2.idfObservation};
                    //для тестирования пустого шаблона
                    //observations.Clear();
                    ffModel.PrepareSummary(observations);

                    Assert.IsNotNull(ffModel.CurrentObservation);
                    Assert.IsTrue(ffModel.CurrentObservation.Value == ffModel.IdfsFormTemplateSummary);
                    Assert.IsTrue(ffModel.CurrentTemplate.SectionTemplates.Count > 0);
                    Assert.IsTrue(ffModel.CurrentTemplate.ParameterTemplates.Count > 0);

                    //смотрим, что в узле топовой табличной секции
                    Assert.IsNotNull(ffModel.TemplateFlexNode);
                    Assert.IsNotNull(ffModel.TemplateFlexNode.ChildListCount == 1);
                    var sectionNode = ffModel.TemplateFlexNode.ChildList.ElementAt(0);
                    var section = sectionNode.GetSectionTemplate();
                    Assert.IsTrue(section.blnGrid);
                    var sectionDataTable = sectionNode.GetDataTableForSectionTable();
                    Assert.IsTrue(sectionDataTable.Columns.Count > 0);
                    Assert.IsTrue(sectionDataTable.Rows.Count > 0);

                    manager.RollbackTransaction();
                }
            }
        }

        [TestMethod]
        public void FFSortTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                var result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                var ffModel = new FFPresenterModel();
                ffModel.SetProperties(FFPresenterModel.LoadActualTemplate(780000000, 784240000000,
                                                                          FFTypeEnum.HumanClinicalSigns));
                //const long idForm = 981170000000;

            }
        }
    }
}

