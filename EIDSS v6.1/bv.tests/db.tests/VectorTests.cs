using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;
using bv.model.Helpers;

namespace bv.tests.db.tests
{
    /// <summary>
    /// Тестирование сессии со всеми вложенными объектами
    /// </summary>
    [TestClass]
    public class VsSessionTest : EidssEnvWithLogin
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

        private static VectorSample AddSample(VectorSample.Accessor accSample, DbManagerProxy manager, Vector vector)
        {
            var sample1 = (VectorSample) accSample.CreateNew(manager, vector);
            Assert.IsNotNull(sample1);
            Assert.IsNotNull(sample1.idfParty);
            sample1.idfsVectorSubType = vector.idfsVectorSubType;
            //Assert.IsTrue(sample1.SampleTypesMatrix.Count > 0);
            //var sc = session.Samples.Count - 1;
            //if (sc < 0) sc = 0;
            //var sampleType = sample1.SampleTypesMatrix[sc <= sample1.SampleTypesMatrix.Count ? sc : 0];
            //sample1.idfsSampleType = sampleType.idfsSampleType;
            //sample1.strSampleName = sampleType.SampleName;
            sample1.strFieldBarcode = "testFieldBarcode";
            sample1.idfsAccessionCondition = (long) AccessionConditionEnum.AcceptedInGoodCondition;
            sample1.strNote = "testNote";

            //добавляем семплы 
            vector.Samples.Add(sample1);

            return sample1;
        }

        private static VectorFieldTest AddFieldTest(VectorFieldTest.Accessor accFT, DbManagerProxy manager, Vector vector, VectorSample sample)
        {
            var fieldTestNew = accFT.CreateWithParamsT(manager, vector, vector.GetParamsAction(typeof(VectorFieldTest)));
            fieldTestNew.idfMaterial = sample.idfMaterial;

            fieldTestNew.idfsSampleType = sample.idfsSampleType;
            fieldTestNew.strSampleName = sample.strSampleType;

            /*
            fieldTestNew.TestType = fieldTest.TestType;
            fieldTestNew.TestCategory = fieldTest.TestCategory;
            fieldTestNew.datTestDate = DateTime.Now;
            fieldTestNew.TestedByOffice = fieldTest.TestedByOffice;
            fieldTestNew.TestedByPerson = fieldTest.TestedByPerson;
            fieldTestNew.idfsVectorType = fieldTest.idfsVectorType;
            //по заданию копировать не надо
            //fieldTestNew.TestResult = fieldTest.TestResult;
            //fieldTestNew.Diagnosis = fieldTest.Diagnosis;
            
            //добавляем семплы 
            vector.FieldTests.Add(fieldTestNew);
            */
            return fieldTestNew;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accVector"></param>
        /// <param name="manager"></param>
        /// <param name="session"></param>
        private static Vector AddVector(Vector.Accessor accVector, DbManagerProxy manager, VsSession session)
        {
            VectorTypeLookup vsVectorType;
            using (var vectorTemp = accVector.CreateNewT(manager, session))
            {
                Assert.IsTrue(vectorTemp.VectorTypeLookup.Count > 0);
                var tickVectorType =
                    vectorTemp.VectorTypeLookup.FirstOrDefault(
                        c => c.strTranslatedName.ToLowerInvariant().Contains("tick"));
                vsVectorType = tickVectorType ?? vectorTemp.VectorTypeLookup[0];
            }

            var parameters = new List<object>();
            parameters.AddRange(session.GetParamsAction(typeof (Vector)));

            var vector = accVector.CreateT(manager, session, parameters);

            Assert.IsNotNull(vector.Location);
            vector.Location.Country = vector.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            vector.Location.Region = vector.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            vector.Location.Rayon = vector.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");

            // изначально тип вектора не задан
            Assert.IsNull(vector.VectorType);
            Assert.IsTrue(vector.idfsVectorType == 0);
            Assert.IsTrue(vector.idfsVectorSubType == 0);

            //присваиваем тип вектора. Должны присвоиться и другие лукапы.

            vector.VectorType = vsVectorType;
            Assert.IsTrue(vector.idfsVectorType > 0);
            Assert.IsTrue(vector.idfsVectorSubType == 0);

            Assert.IsTrue(vector.VectorSubTypeLookup.Count > 1);
            vector.VectorSubType = vector.VectorSubTypeLookup[1];
            Assert.IsNotNull(vector.idfsVectorSubType);
            Assert.IsTrue(vector.CollectedByOfficeLookup.Count > 1);
            vector.CollectedByOffice = vector.CollectedByOfficeLookup[1];
            vector.intQuantity = 5;
            vector.strFieldVectorID = "teststrFieldVectorID";
            vector.intElevation = 150;
            Assert.IsTrue(vector.SurroundingLookup.Count > 1);
            vector.Surrounding = vector.SurroundingLookup[1];
            vector.strGEOReferenceSources = "teststrGEOReferenceSources";
            //Assert.IsTrue(vector.CollectorLookup.Count > 0);
            //vector.Collector = vector.CollectorLookup[0];
            //vector.intCollectionEffort = 20;

            //TODO восстановить CollectionMethodLookup
            //Assert.IsTrue(vector.CollectionMethodLookup.Count > 1);
            //vector.CollectionMethod = vector.CollectionMethodLookup[1];

            Assert.IsTrue(vector.BasisOfRecordLookup.Count > 1);
            vector.BasisOfRecord = vector.BasisOfRecordLookup[1];
            //Assert.IsTrue(vector.AnimalGenderLookup.Count > 0);
            //vector.AnimalGender = vector.AnimalGenderLookup[0];
            Assert.IsTrue(vector.IdentifierLookup.Count > 1);
            vector.Identifier = vector.IdentifierLookup[1];
            vector.datIdentifiedDateTime = DateTime.Now;
            Assert.IsTrue(vector.IdentificationMethodLookup.Count > 1);
            vector.IdentificationMethod = vector.IdentificationMethodLookup[1];
            Assert.IsTrue(vector.DayPeriodLookup.Count > 1);
            vector.DayPeriod = vector.DayPeriodLookup[1];
            Assert.IsNotNull(vector.idfObservation);

            session.Vectors.Add(vector);

            return vector;
        }

        public static VsSession GetTestSession()
        {
            VsSession session;

            //EidssUserContext.Init(); должен быть обёрнут извне
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var acc = VsSession.Accessor.Instance(null);

                    #region создание сессии

                    session = acc.CreateNewT(manager, null);

                    session.strSessionID = NeedNewValue;
                    session.strFieldSessionID = "testFieldSessionID";
                    session.VsStatus =
                        session.VsStatusLookup.Where(l => l.idfsBaseReference == (long) VsStatusEnum.InProgress).
                                SingleOrDefault();
                    session.datStartDate = DateTime.Now;

                    session.strDescription = "created from unit test";
                    session.Location.Country =
                        session.Location.CountryLookup.Where(c => c.strCountryName == "Georgia").SingleOrDefault();
                    session.Location.Region =
                        session.Location.RegionLookup.Where(c => c.strRegionName == "Abkhazia").SingleOrDefault();
                    session.Location.Rayon =
                        session.Location.RayonLookup.Where(c => c.strRayonName == "Gagra").SingleOrDefault();

                    #endregion

                    #region создаём векторы

                    var accVector = Vector.Accessor.Instance(null);

                    //
                    var vector1 = AddVector(accVector, manager, session);

                    //
                    var vector2 = AddVector(accVector, manager, session);

                    //проверка hostvector
                    vector2.HostVector = vector1;

                    #endregion

                    #region в вектор создаём sample

                    var accSample = VectorSample.Accessor.Instance(null);

                    //подвешиваем семплы к 1 и 3 векторам
                    AddSample(accSample, manager, vector1);
                    AddSample(accSample, manager, vector1);
                    AddSample(accSample, manager, vector2);

                    #endregion

                    #region работа с полевыми тестами Field Tests

                    //sample1.isJustCreated = !sample1.isJustCreated; //??? TODO не всегда срабатывает

                    //в первом тесте меняем что-либо, чтобы строка реально сохранилась в БД
                    if (session.FieldTests.Count > 0)
                    {
                        foreach (var fieldTest in session.FieldTests)
                        {
                            var idTest = fieldTest.idfsPensideTestName;

                            //определим результат, который подходит для данного типа теста
                            var results =
                                fieldTest.TestResultLookup.Where(
                                    c => c.idfsPensideTestName == idTest);
                            /*
                            if (fieldTest.TypeFieldTestToResultMatrix.Count > 0)
                            {
                                if (results.Count() > 0)
                                {
                                    fieldTest.PensideTestResult =
                                        fieldTest.PensideTestResultLookup.Where(
                                            c => c.idfsBaseReference == results.ToList()[0].idfsPensideTestResult).
                                            ToList()[0];
                                }
                                else
                                {
                                    fieldTest.PensideTestResult = fieldTest.PensideTestResultLookup[0];
                                }
                            }
                             * */
                        }
                    }

                    #endregion
                }
            }
            //EidssUserContext.Clear();

            return session;
        }

        private const string NeedNewValue = "(new)";
        private const string Organizaton = "NCDC&PH";
        private const string Admin = "test_admin";
        //const string User = "test_user";
        private const string AdminPassword = "test";
        //const string UserPassword = "test";

        [TestMethod]
        [Ignore]
        public void FieldTest()
        {
            var acc = VsSession.Accessor.Instance(null);
            manager.BeginTransaction();
            const long idSession = 51525030000000;
            var session = acc.SelectByKey(manager, idSession);
            Assert.IsNotNull(session);
            Assert.IsTrue(session.idfVectorSurveillanceSession > 0);
            Assert.IsTrue(session.FieldTests.Count > 0);
            var ft = session.FieldTests[0];
            manager.RollbackTransaction();
        }

        [TestMethod]
        //[Ignore]
        public void VsSessionFullTest()
        {

            var acc = VsSession.Accessor.Instance(null);
            manager.BeginTransaction();

            #region создание сессии

            var session = acc.CreateNewT(manager, null);
            Assert.IsNotNull(session);
            var idSession = session.idfVectorSurveillanceSession;

            session.strSessionID = NeedNewValue;
            session.strFieldSessionID = "testFieldSessionID";
            Assert.IsTrue(session.VsStatusLookup.Count > 0);
            session.VsStatus =
                session.VsStatusLookup.SingleOrDefault(l => l.idfsBaseReference == (long) VsStatusEnum.InProgress);
            Assert.AreEqual(10310001, session.idfsVectorSurveillanceStatus);

            session.datStartDate = DateTime.Now;

            session.strDescription = "created from unit test";
            //Assert.IsTrue(session.PensideTestTypeLookup.Count > 0);

            session.Location.Country = session.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            session.Location.Region = session.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            session.Location.Rayon = session.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");

            Assert.IsNotNull(session.Location.Country);
            Assert.IsNotNull(session.Location.Region);
            Assert.IsNotNull(session.Location.Rayon);

            #endregion

            #region создаём векторы

            var accVector = Vector.Accessor.Instance(null);

            //
            var vector1 = AddVector(accVector, manager, session);

            //
            var vector2 = AddVector(accVector, manager, session);
            var idVector1 = vector1.idfVector;

            //проверка hostvector
            Assert.IsNull(vector2.idfHostVector);
            vector2.HostVector = vector1;
            Assert.IsNotNull(vector2.idfHostVector);

            var idVector2 = vector2.idfVector;
            //
            var vector3 = AddVector(accVector, manager, session);
            var idVector3 = vector3.idfVector;

            #endregion

            #region в вектор создаём sample

            var accSample = VectorSample.Accessor.Instance(null);

            //подвешиваем семплы к 1 и 3 векторам
            AddSample(accSample, manager, vector1);
            AddSample(accSample, manager, vector3);

            Assert.IsTrue(session.Samples.Count == 2);
            Assert.IsTrue(vector1.Samples.Count == 1);
            Assert.IsTrue(vector2.Samples.Count == 0);
            Assert.IsTrue(vector3.Samples.Count == 1);

            #endregion

            #region проверяем клонирование, замену в контейнере и установку флагов изменения

            Assert.IsTrue(session.Vectors[0].HasChanges);
            Assert.IsTrue(session.Vectors[0].Location.HasChanges);
            var clonedVector = session.Vectors[0].CloneWithSetup(manager) as Vector;
            Assert.IsNotNull(clonedVector);
            Assert.IsFalse(clonedVector.HasChanges);
            Assert.IsFalse(clonedVector.Location.HasChanges);
            session.Vectors.ReplaceAndSetChange(session.Vectors[0], clonedVector);
            Assert.IsTrue(clonedVector.HasChanges);
            Assert.IsTrue(clonedVector.Location.HasChanges);

            #endregion

            //проверим связность списков
            Assert.IsTrue(session.Vectors.Count > 0);
            Assert.IsTrue(vector1.Vectors.Count == session.Vectors.Count);
            Assert.IsTrue(session.Samples.Count > 0);
            Assert.IsTrue(vector1.Samples.Count + vector3.Samples.Count == session.Samples.Count);

            var target = new EidssSecurityManager();
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);

            #region работа с полевыми тестами Field Tests

            //sample1.isJustCreated = !sample1.isJustCreated; //??? TODO не всегда срабатывает

            foreach (var fieldTest in session.FieldTests)
            {
                Assert.IsNotNull(fieldTest.idfPensideTest);
                Assert.AreEqual(EidssUserContext.User.EmployeeID, fieldTest.idfTestedByPerson);
                Assert.AreEqual(EidssUserContext.User.OrganizationID, fieldTest.idfTestedByOffice);
            }

            //в первом тесте меняем что-либо, чтобы строка реально сохранилась в БД
            // commented variable because of warning
            //int fieldTestsChangedRowsCount = 0;
            if (session.FieldTests.Count > 0)
            {
                var fieldTest = session.FieldTests[0];
                //определим результат, который подходит для данного типа теста
                /*
                var results = fieldTest.TypeFieldTestToResultMatrixLookup.Where(c => c.idfsPensideTestName == fieldTest.idfsPensideTestName);
                if (fieldTest.PensideTestResultLookup.Count > 0)
                {
                    if (results.Count() > 0)
                    {
                        fieldTest.PensideTestResult =
                            fieldTest.PensideTestResultLookup.Where(
                                c => c.idfsBaseReference == results.ToList()[0].idfsPensideTestResult).ToList()[0];
                    }
                    else
                    {
                        fieldTest.PensideTestResult = fieldTest.PensideTestResultLookup[0];
                    }
                }
                fieldTestsChangedRowsCount++;
                 */
            }


            //TODO вставить проверки саммари

            #endregion

            //сохранение сессии со всеми дочерними объектами
            session.Validation += OnSessionValidation;

            foreach (var vector in session.Vectors)
            {
                vector.Validation += OnSessionValidation;
            }

            foreach (var sample in session.Samples)
            {
                sample.Validation += OnSessionValidation;
            }

            /*
            Assert.IsTrue(acc.Post(manager, session));

            foreach (var vector in session.PoolsVectors)
            {
                vector.Validation -= OnSessionValidation;
            }

            foreach (var sample in session.Samples)
            {
                sample.Validation -= OnSessionValidation;
            }
            session.Validation -= OnSessionValidation;

            //загружаем сохранённую сессию из БД
            session = acc.SelectByKey(manager, idSession);

            #region Проверки для сессии

            Assert.IsNotNull(session);
            Assert.AreEqual(idSession, session.idfVectorSurveillanceSession);
            Assert.AreNotEqual(NeedNewValue, session.strSessionID);
            Assert.AreEqual(10310001, session.idfsVectorSurveillanceStatus);
            Assert.IsTrue(session.strFieldSessionID.Length > 0);
            Assert.IsTrue(session.strDescription.Length > 0);
            Assert.IsNotNull(session.datStartDate);

            //TODO проверить диагнозы
            //TODO проверить summary

            #endregion

            #region Проверки для векторов

            vector1 = session.PoolsVectors.Where(c => c.idfVector == idVector1).SingleOrDefault();
            vector2 = session.PoolsVectors.Where(c => c.idfVector == idVector2).SingleOrDefault();
            vector3 = session.PoolsVectors.Where(c => c.idfVector == idVector3).SingleOrDefault();

            Assert.IsNotNull(vector1, "vector1 is null");
            Assert.IsNotNull(vector2, "vector2 is null");
            Assert.IsNotNull(vector3, "vector3 is null");

            Assert.IsTrue(session.PoolsVectors.Count > 0);
            Assert.IsNotNull(vector1.Vectors);
            Assert.IsNotNull(vector1.Samples);
            Assert.IsTrue(vector1.Vectors.Count == session.PoolsVectors.Count);
            Assert.IsTrue(vector2.Vectors.Count == session.PoolsVectors.Count);
            Assert.IsTrue(vector3.Vectors.Count == session.PoolsVectors.Count);

            Assert.IsTrue(session.Samples.Count > 0);
            Assert.IsTrue(vector1.Samples.Count == session.Samples.Count);
            Assert.IsTrue(vector2.Samples.Count == session.Samples.Count);
            Assert.IsTrue(vector3.Samples.Count == session.Samples.Count);

            //проверить наличие семплов на В1 и В3, отсутствие на В2. Общее кол-во семплов совпадает с сессионными.
            Assert.IsTrue(vector1.SamplesForThisVector.Count == 1);
            Assert.IsTrue(vector2.SamplesForThisVector.Count == 0);
            Assert.IsTrue(vector3.SamplesForThisVector.Count == 1);

            Assert.IsTrue(vector1.SamplesForThisVector[0].idfVector == vector1.idfVector);

            //проверить Host у В2
            Assert.IsNotNull(vector2.idfHostVector);
                    
            //проверим на одном векторе
            Assert.AreEqual(idVector1, vector1.idfVector);
            Assert.AreNotEqual(NeedNewValue, vector1.strVectorID);
            Assert.IsNotNull(vector1.VsVectorType);
            Assert.IsNotNull(vector1.VsVectorSubType);
            Assert.IsNotNull(vector1.datCollectionDateTime);
            Assert.IsTrue(vector1.strSessionID.Length > 0);
            Assert.IsNotNull(vector1.CollectedByOffice);
            Assert.IsTrue(vector1.intQuantity > 0);
            Assert.IsTrue(vector1.strFieldVectorID.Length > 0);
            Assert.IsTrue(vector1.intElevation > 0);
            Assert.IsNotNull(vector1.VsSurrounding);
            Assert.IsTrue(vector1.strGEOReferenceSources.Length > 0);
            //Assert.IsNotNull(vector1.Collector);
            Assert.IsTrue(vector1.intCollectionEffort > 0);
            Assert.IsNotNull(vector1.CollectionMethod);
            Assert.IsNotNull(vector1.BasisOfRecord);
            Assert.IsNotNull(vector1.AnimalGender);
            Assert.IsNotNull(vector1.Identifier);
            Assert.IsNotNull(vector1.datIdentifiedDateTime);
            Assert.IsNotNull(vector1.IdentificationMethod);
            Assert.IsNotNull(vector1.DayPeriod);

            #endregion

            #region Проверки для семплов (samples)

            //проверим на одном семпле
            var sample1 = vector3.SamplesForThisVector[0];
                    
            Assert.IsTrue(sample1.idfMaterial == sample3.idfMaterial);
            Assert.IsNotNull(sample1.idfVectorSurveillanceSession);
            Assert.IsNotNull(sample1.idfVector);
            Assert.IsNotNull(sample1.idfParty);
            Assert.IsNotNull(sample1.idfsVectorType);
            Assert.IsNotNull(sample1.idfsVectorSubType);
            //Assert.IsNotNull(sample1.SampleType);
            Assert.IsTrue(sample1.strFieldBarcode.Length > 0);
            Assert.IsNotNull(sample1.datCollectionDateTime);
            Assert.IsNotNull(sample1.idfFieldCollectedByOffice);
            //TODO это поле должно приходить не нулевым, когда доделают AccessionIn
            //Assert.IsNotNull(sample1.idfsAccessionCondition);
            Assert.IsTrue(sample1.strNote.Length > 0);

            #endregion

            #region Проверки для полевых тестов Field Tests
                    
            Assert.IsTrue(session.FieldTests.Count > 0);
                    
            if (fieldTestsChangedRowsCount > 0)
            {
                //столько тестов должно быть с не пустым результатом
                //Assert.AreEqual(session.FieldTests.Where(c => c.PensideTestResult != null).Count(),
                //                fieldTestsChangedRowsCount);
            }
                    
            #endregion
            */

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnSessionValidation(object sender, ValidationEventArgs args)
        {

        }

        [TestMethod]
        public void TestVsSessionSummary()
        {
            var accSessionSummary = VsSessionSummary.Accessor.Instance(null);
            var accSession = VsSession.Accessor.Instance(null);
            manager.BeginTransaction();

            //делаем парента
            var session = accSession.CreateNewT(manager, null);
            Assert.IsNotNull(session);

            #region Сессия

            session.strSessionID = NeedNewValue;
            session.strFieldSessionID = "testFieldSessionID";
            Assert.IsTrue(session.VsStatusLookup.Count > 0);
            session.VsStatus =
                session.VsStatusLookup.SingleOrDefault(l => l.idfsBaseReference == (long) VsStatusEnum.InProgress);
            Assert.AreEqual(10310001, session.idfsVectorSurveillanceStatus);

            session.datStartDate = DateTime.Now;

            session.strDescription = "created from unit test";
            session.intCollectionEffort = 1;

            session.Location.Country = session.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            session.Location.Region = session.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            session.Location.Rayon = session.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");

            #endregion

            var sessionSummary = accSessionSummary.CreateNewT(manager, session);
            Assert.IsNotNull(sessionSummary);
            Assert.IsNotNull(sessionSummary.Parent);
            Assert.IsTrue(sessionSummary.Parent is VsSession);
            Assert.IsNotNull(sessionSummary.Session);
            Assert.IsTrue(sessionSummary.idfsVSSessionSummary > 0);
            Assert.IsTrue(sessionSummary.idfVectorSurveillanceSession > 0);
            Assert.IsTrue(sessionSummary.strVSSessionSummaryID.Length > 0);

            Assert.IsTrue(sessionSummary.idfsVectorType == 0);
            Assert.IsTrue(sessionSummary.idfsVectorSubType == 0);
            Assert.IsTrue(sessionSummary.VectorTypeLookup.Count > 1);
            Assert.IsTrue(sessionSummary.VectorSubTypeLookup.Count > 0);

            sessionSummary.Location.Country =
                sessionSummary.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            sessionSummary.Location.Region =
                sessionSummary.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            sessionSummary.Location.Rayon =
                sessionSummary.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");
            Assert.IsNotNull(sessionSummary.Location.Country);
            Assert.IsNotNull(sessionSummary.Location.Region);
            Assert.IsNotNull(sessionSummary.Location.Rayon);

            Assert.IsTrue(sessionSummary.AnimalGenderLookup.Count > 1);

            var vtRodent = sessionSummary.VectorTypeLookup.FirstOrDefault(vt => vt.strDefaultName == "Rodent");
            Assert.IsNotNull(vtRodent);

            sessionSummary.VectorType = vtRodent;
            //должны загрузиться подтипы грызунов
            Assert.IsTrue(sessionSummary.VectorSubTypeLookup.Count > 1);
            sessionSummary.VectorSubType = sessionSummary.VectorSubTypeLookup[1];
            Assert.IsTrue(sessionSummary.idfsVectorType > 0);
            Assert.IsTrue(sessionSummary.idfsVectorSubType > 0);
            Assert.IsTrue(sessionSummary.VectorType.strTranslatedName.Length > 0);
            Assert.IsTrue(sessionSummary.VectorSubType.name.Length > 0);
            Assert.IsTrue(sessionSummary.strVectorType.Length > 0);
            Assert.IsTrue(sessionSummary.strVectorSubType.Length > 0);

            sessionSummary.datCollectionDateTime = DateTime.Now;

            sessionSummary.AnimalGender = sessionSummary.AnimalGenderLookup[1];
            Assert.IsTrue(sessionSummary.idfsSex > 0);
            Assert.IsTrue(sessionSummary.strSex.Length > 0);

            sessionSummary.intQuantity = 15;

            //ввод и сохранение диагнозов
            var accVsSessionSummaryDiagnosis = VsSessionSummaryDiagnosis.Accessor.Instance(null);
            var vsSessionSummaryDiagnosis = accVsSessionSummaryDiagnosis.CreateNewT(manager, sessionSummary);
            Assert.IsTrue(vsSessionSummaryDiagnosis.DiagnosesLookup.Count > 1);
            vsSessionSummaryDiagnosis.Diagnoses = vsSessionSummaryDiagnosis.DiagnosesLookup[1];
            vsSessionSummaryDiagnosis.intPositiveQuantity = 10;

            Assert.IsTrue(sessionSummary.strDiagnosesSummary.Length == 0);
            sessionSummary.DiagnosisList.Add(vsSessionSummaryDiagnosis);
            Assert.IsTrue(sessionSummary.strDiagnosesSummary.Length > 0);

            //сохранение сессии со всеми дочерними объектами
            session.Validation += OnSessionValidation;
            vsSessionSummaryDiagnosis.Validation += OnSessionValidation;
            sessionSummary.Validation += OnSessionValidation;

            session.Summaries.Add(sessionSummary);
            Assert.IsTrue(accSession.Post(manager, session));

            vsSessionSummaryDiagnosis.Validation -= OnSessionValidation;
            sessionSummary.Validation -= OnSessionValidation;
            session.Validation -= OnSessionValidation;

            //загружаем сохранённую сессию из БД
            var sessionLoaded = accSession.SelectByKey(manager, session.idfVectorSurveillanceSession);
            Assert.IsNotNull(sessionLoaded);
            Assert.IsTrue(sessionLoaded.Summaries.Count > 0);

            var sessionSummaryLoaded = sessionLoaded.Summaries[0];

            #region Проверка загруженного объекта

            Assert.IsNotNull(sessionSummaryLoaded);
            Assert.IsNotNull(sessionSummaryLoaded.Session);
            Assert.IsTrue(sessionSummaryLoaded.idfsVSSessionSummary == sessionSummary.idfsVSSessionSummary);
            Assert.IsTrue(sessionSummaryLoaded.idfVectorSurveillanceSession ==
                          sessionSummary.idfVectorSurveillanceSession);

            Assert.IsTrue(sessionSummaryLoaded.idfsVectorType == sessionSummary.idfsVectorType);
            Assert.IsTrue(sessionSummaryLoaded.idfsVectorSubType == sessionSummary.idfsVectorSubType);
            Assert.IsTrue(sessionSummaryLoaded.VectorType == sessionSummary.VectorType);
            Assert.IsTrue(sessionSummaryLoaded.VectorSubType == sessionSummary.VectorSubType);
            Assert.IsTrue(sessionSummaryLoaded.strVectorType.Length > 0);
            Assert.IsTrue(sessionSummaryLoaded.strVectorSubType.Length > 0);

            Assert.IsTrue(sessionSummaryLoaded.Location.Country == sessionSummary.Location.Country);
            Assert.IsTrue(sessionSummaryLoaded.Location.Region == sessionSummary.Location.Region);
            Assert.IsTrue(sessionSummaryLoaded.Location.Rayon == sessionSummary.Location.Rayon);

            Assert.IsTrue(sessionSummaryLoaded.AnimalGender == sessionSummary.AnimalGender);
            Assert.IsTrue(sessionSummaryLoaded.idfsSex == sessionSummary.idfsSex);
            Assert.IsTrue(sessionSummaryLoaded.strSex == sessionSummary.strSex);

            Assert.IsTrue(sessionSummaryLoaded.datCollectionDateTime.ToString() ==
                          sessionSummary.datCollectionDateTime.ToString());

            Assert.IsTrue(sessionSummaryLoaded.intQuantity == sessionSummary.intQuantity);

            //диагнозы
            Assert.IsTrue(sessionSummaryLoaded.DiagnosisList.Count == 1);
            Assert.IsTrue(sessionSummaryLoaded.strDiagnosesSummary.Length > 0);

            var dng = sessionSummaryLoaded.DiagnosisList[0];
            Assert.IsTrue(dng.intPositiveQuantity == vsSessionSummaryDiagnosis.intPositiveQuantity);
            Assert.IsTrue(dng.Diagnoses == vsSessionSummaryDiagnosis.Diagnoses);
            Assert.IsTrue(dng.strDiagnosis == vsSessionSummaryDiagnosis.strDiagnosis);

            #endregion

        }
    }
}
