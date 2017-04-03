using System;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
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
    public class VsSessionTest
    {
        private static VectorSample AddSample(VectorSample.Accessor accSample, DbManagerProxy manager, VsSession session, Vector vector)
        {
            //var sample1 = accSample.Create(manager
            //                               , vector.idfVector
            //                               , true //TODO выставить реальное значение
            //                               , vector.idfsVectorType
            //                               , vector.datCollectionDateTime
            //                               , vector.idfCollectedByOffice
            //                               , session.idfVectorSurveillanceSession
            //                               , null
            //                               , session.Samples
            //                               , session.FieldTests
            //                               , session.PoolsVectors
            //                               , session.LabTests
            //    );
            var sample1 = accSample.Create(manager, session, vector, null);
            Assert.IsNotNull(sample1);
            Assert.IsNotNull(sample1.idfParty);
            sample1.idfsVectorSubType = vector.idfsVectorSubType;
            //Assert.IsTrue(sample1.SampleTypesMatrix.Count > 0);
            //var sc = session.Samples.Count - 1;
            //if (sc < 0) sc = 0;
            //var sampleType = sample1.SampleTypesMatrix[sc <= sample1.SampleTypesMatrix.Count ? sc : 0];
            //sample1.idfsSpecimenType = sampleType.idfsSampleType;
            //sample1.strSpecimenName = sampleType.SampleName;
            sample1.strFieldBarcode = "testFieldBarcode";
            sample1.idfsAccessionCondition = (long)AccessionConditionEnum.AcceptedInGoodCondition;
            sample1.strNote = "testNote";

            //добавляем семплы 
            vector.Samples.Add(sample1);

            return sample1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accVector"></param>
        /// <param name="manager"></param>
        /// <param name="session"></param>
        private static Vector AddVector(Vector.Accessor accVector, DbManagerProxy manager, VsSession session)
        {
            BaseReference vsVectorType;
            using (var vectorTemp = accVector.CreateNewT(manager, session))
            {
                Assert.IsTrue(vectorTemp.VsVectorTypeLookup.Count > 0);
                var tickVectorType = vectorTemp.VsVectorTypeLookup.FirstOrDefault(c => c.name.ToLowerInvariant().Contains("tick"));
                vsVectorType = tickVectorType ?? vectorTemp.VsVectorTypeLookup[0];
            }

            var vector = accVector.Create(manager, session
                                           , session.idfVectorSurveillanceSession
                                           , vsVectorType.idfsBaseReference
                                           , vsVectorType.name
                                           , session.datStartDate
                                           , session.strSessionID
                                           , session.PoolsVectors
                                           , session.Samples
                                           , session.Location
                                           , session.FieldTests
                                           , session.LabTests
                );

            Assert.IsNotNull(vector.Location);
            vector.Location.Country = vector.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            vector.Location.Region = vector.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            vector.Location.Rayon = vector.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");
            vector.VsVectorType = vsVectorType;
            Assert.IsTrue(vector.VsVectorSubTypeLookup.Count > 1);
            vector.VsVectorSubType = vector.VsVectorSubTypeLookup[1];
            Assert.IsNotNull(vector.idfsVectorSubType);
            Assert.IsTrue(vector.CollectedByOfficeLookup.Count > 1);
            vector.CollectedByOffice = vector.CollectedByOfficeLookup[1];
            vector.intQuantity = 5;
            vector.strFieldVectorID = "teststrFieldVectorID";
            vector.intElevation = 150;
            Assert.IsTrue(vector.VsSurroundingLookup.Count > 1);
            vector.VsSurrounding = vector.VsSurroundingLookup[1];
            vector.strGEOReferenceSources = "teststrGEOReferenceSources";
            //Assert.IsTrue(vector.CollectorLookup.Count > 0);
            //vector.Collector = vector.CollectorLookup[0];
            //vector.intCollectionEffort = 20;
            Assert.IsNotNull(vector.CollectionMethodLookup.Count > 1);
            vector.CollectionMethod = vector.CollectionMethodLookup[1];
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

            session.PoolsVectors.Add(vector);

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
                        session.VsStatusLookup.Where(l => l.idfsBaseReference == (long)VsStatusEnum.InProgress).
                            SingleOrDefault();
                    session.datStartDate = DateTime.Now;

                    session.strDescription = "created from unit test";
                    session.Location.Country = session.Location.CountryLookup.Where(c => c.strCountryName == "Georgia").SingleOrDefault();
                    session.Location.Region = session.Location.RegionLookup.Where(c => c.strRegionName == "Abkhazia").SingleOrDefault();
                    session.Location.Rayon = session.Location.RayonLookup.Where(c => c.strRayonName == "Gagra").SingleOrDefault();
                    
                    #endregion

                    #region SessionToVectorType

                    foreach (var vectorType in session.SessionToVectorType)
                    {
                        vectorType.IsChecked = 1;
                    }

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
                    AddSample(accSample, manager, session, vector1);
                    AddSample(accSample, manager, session, vector1);
                    AddSample(accSample, manager, session, vector2);

                    #endregion

                    #region работа с полевыми тестами Field Tests

                    //sample1.isJustCreated = !sample1.isJustCreated; //??? TODO не всегда срабатывает
                    session.RefreshFieldTests(manager);

                    //в первом тесте меняем что-либо, чтобы строка реально сохранилась в БД
                    if (session.FieldTests.Count > 0)
                    {
                        foreach (var fieldTest in session.FieldTests)
                        {
                            var idTest = fieldTest.idfsPensideTestType;

                            //определим результат, который подходит для данного типа теста
                            var results =
                                fieldTest.TypeFieldTestToResultMatrix.Where(
                                    c => c.idfsPensideTestType == idTest);
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

        const string NeedNewValue = "(new)";
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        //const string User = "test_user";
        const string AdminPassword = "test";
        //const string UserPassword = "test";

        [TestMethod]
        //[Ignore]
        public void VsSessionFullTest()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                using (var manager = DbManagerFactory.Factory.Create(context))
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
                        session.VsStatusLookup.Where(l => l.idfsBaseReference == (long) VsStatusEnum.InProgress).
                            SingleOrDefault();
                    Assert.AreEqual(10310001, session.idfsVectorSurveillanceStatus);

                    session.datStartDate = DateTime.Now;
                    
                    session.strDescription = "created from unit test";
                    Assert.IsTrue(session.PensideTestTypeLookup.Count > 0);

                    session.Location.Country = session.Location.CountryLookup.Where(c => c.strCountryName == "Georgia").SingleOrDefault();
                    session.Location.Region = session.Location.RegionLookup.Where(c => c.strRegionName == "Abkhazia").SingleOrDefault();
                    session.Location.Rayon = session.Location.RayonLookup.Where(c => c.strRayonName == "Gagra").SingleOrDefault();

                    Assert.IsNotNull(session.Location.Country);
                    Assert.IsNotNull(session.Location.Region);
                    Assert.IsNotNull(session.Location.Rayon);

                    #endregion

                    #region SessionToVectorType

                    foreach (var vectorType in session.SessionToVectorType)
                    {
                        vectorType.IsChecked = 1;
                    }

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
                    AddSample(accSample, manager, session, vector1);
                    var sample3 = AddSample(accSample, manager, session, vector3);

                    Assert.IsTrue(session.Samples.Count == 2);
                    Assert.IsTrue(session.Samples.Count == vector2.Samples.Count);
                    Assert.IsTrue(vector1.SamplesForThisVector.Count == 1);
                    Assert.IsTrue(vector2.SamplesForThisVector.Count == 0);
                    Assert.IsTrue(vector3.SamplesForThisVector.Count == 1);

                    #endregion

                    #region проверяем клонирование, замену в контейнере и установку флагов изменения

                    Assert.IsTrue(session.PoolsVectors[0].HasChanges);
                    Assert.IsTrue(session.PoolsVectors[0].Location.HasChanges);
                    var clonedVector = session.PoolsVectors[0].CloneWithSetup(manager) as Vector;
                    Assert.IsNotNull(clonedVector);
                    Assert.IsFalse(clonedVector.HasChanges);
                    Assert.IsFalse(clonedVector.Location.HasChanges);
                    session.PoolsVectors.ReplaceAndSetChange(session.PoolsVectors[0], clonedVector);
                    Assert.IsTrue(clonedVector.HasChanges);
                    Assert.IsTrue(clonedVector.Location.HasChanges);

                    #endregion

                    //проверим связность списков
                    Assert.IsTrue(session.PoolsVectors.Count > 0);
                    Assert.IsTrue(vector1.Vectors.Count == session.PoolsVectors.Count);
                    Assert.IsTrue(session.Samples.Count > 0);
                    Assert.IsTrue(vector1.Samples.Count == session.Samples.Count);

                    var target = new EidssSecurityManager();
                    int result = target.LogIn(Organizaton, Admin, AdminPassword);
                    Assert.AreEqual(0, result);

                    #region работа с полевыми тестами Field Tests

                    //sample1.isJustCreated = !sample1.isJustCreated; //??? TODO не всегда срабатывает
                    session.RefreshFieldTests(manager);
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
                        var results = fieldTest.TypeFieldTestToResultMatrixLookup.Where(c => c.idfsPensideTestType == fieldTest.idfsPensideTestType);
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
                    //перерасчёт происходит в RefreshFieldTests
                    session.RefreshFieldTestsSummary();
                    session.RefreshLabTestsSummary();

                    //TODO вставить проверки саммари

                    #endregion

                    //сохранение сессии со всеми дочерними объектами
                    session.Validation += OnSessionValidation;

                    foreach (var vector in session.PoolsVectors)
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
                    manager.RollbackTransaction();
                    //manager.CommitTransaction();
                }
            }
            EidssUserContext.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnSessionValidation(object sender, ValidationEventArgs args)
        {
            
        }
    }
}
