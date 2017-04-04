using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.EditableObjects;
using System.Text;
using System.Linq;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Helpers;

namespace eidss.model.Schema
{
    public partial class Vector
    {
        protected static void CustomValidations(Vector obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenter, true, false, true);
            }
        }

        public bool GetIsPoolVectorType(long idVectorType)
        {
            var vectorTypeLookup = VectorTypeLookup.FirstOrDefault(m => m.idfsBaseReference == idVectorType)
                                   ?? VectorType;
            return vectorTypeLookup != null && vectorTypeLookup.bitCollectionByPool;
        }

        public void RefreshFF()
        {
            if (!idfObservation.HasValue) return;
            FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, idfsVectorType, FFTypeEnum.VectorTypeSpecificData, idfObservation.Value, idfVector);
            if (FFPresenter.CurrentTemplate != null)
            {
                idfsFormTemplate = FFPresenter.CurrentTemplate.idfsFormTemplate;
                OnPropertyChanged("FFPresenter");
            }
        }

        /*
    /// <summary>
    /// 
    /// </summary>
    public void RecalculateLocation()
    {
        if (Location == null) return;
        if (Location.idfsCountry > 0)
        {
            idfsCountry = Location.idfsCountry;
            var x = Location.CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            if (x != null) strCountry = x.strCountryName;
        }
        if (Location.idfsRegion > 0)
        {
            idfsRegion = Location.idfsRegion;
            var x = Location.RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            if (x != null) strRegion = x.strRegionName;
        }
        if (Location.idfsRayon > 0)
        {
            idfsRayon = Location.idfsRayon;
            var x = Location.RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            if (x != null) strRayon = x.strRayonName;
        }
        if (Location.idfsSettlement > 0)
        {
            idfsSettlement = Location.idfsSettlement;
            var x = Location.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
            if (x != null) strSettlement = x.strSettlementName;
        }
        dblLatitude = Location.dblLatitude;
        dblLongitude = Location.dblLongitude;
    }
        */

        /// <summary>
        /// Перечень векторов сессии без этого вектора
        /// </summary>
        /// <returns></returns>
        public EditableList<Vector> VectorsWithoutThisVector()
        {
            var list = new EditableList<Vector>();
            //поскольку Vector -- это указатель на session.PoolsVectors, то там хранятся все вектора
            if (Vectors != null)
            {
                foreach (var vector in Vectors)
                {
                    //отбираем только которые не пулы (крысы годятся, блохи -- нет)
                    //we should not enable vector hosts loops also to avoid problems with vectors post order
                    //so we exlude vectors with hosts from this list too
                    if (vector.IsPoolVectorType || vector.IsMarkedToDelete || vector.HostVector != null) continue;
                    if (vector.idfVector != idfVector) list.Add(vector);
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public string RecalculateVectorSpecificData()
        {
            var result = String.Empty;
            if (FFPresenter == null) return result;
            if (FFPresenter.CurrentTemplate == null) return result;
            var sb = new StringBuilder();
            foreach (var ap in FFPresenter.ActivityParameters)
            {
                if (ap.varValue == null) continue;
                var idfsParameter = ap.idfsParameter;
                var parameter =
                    FFPresenter.CurrentTemplate.ParameterTemplatesLookup.FirstOrDefault(p => p.idfsParameter == idfsParameter);
                if (parameter == null) continue;
                sb.AppendFormat("{0}: {1}; ", parameter.NationalName, ap.GetUserValue());
            }

            result = sb.ToString();
            return result;
        }

        public void CopyLocation(GeoLocation locationFrom)
        {
            LocationHelper.CopyLocation(locationFrom, Location);

            //TODO разобраться почему эти поля не вычисляются в штатном порядке
            strRegion = Location.Region == null ? String.Empty : Location.Region.strRegionName;
            strRayon = Location.Rayon == null ? String.Empty : Location.Rayon.strRayonName;
            strSettlement = Location.Settlement == null ? String.Empty : Location.Settlement.strSettlementName;
            dblLatitude = Location.dblLatitude;
            dblLongitude = Location.dblLongitude;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="needCopyFF"></param>
        /// <param name="needCopySamples"></param>
        /// <param name="needCopyFT"></param>
        /// <returns></returns>
        public Vector CopyVector(DbManagerProxy manager, bool needCopyFF, bool needCopySamples, bool needCopyFT)
        {
            if (needCopyFT) needCopySamples = true;

            //создаём новый объект и добавляем туда всё нужное из старого
            var accVector = Accessor.Instance(null);
            var vectorNew = accVector.CreateWithParamsT(manager, Session, Session.GetParamsAction(typeof(Vector)));

            vectorNew.VectorType = VectorType;
            vectorNew.idfsVectorSubType = idfsVectorSubType;
            vectorNew.CopyLocation(Location);

            //vectorNew.RecalculateLocation();
            vectorNew.intElevation = intElevation;
            vectorNew.Surrounding = Surrounding;
            vectorNew.BasisOfRecord = BasisOfRecord;
            vectorNew.idfHostVector = idfHostVector;
            vectorNew.CollectedByOffice = CollectedByOffice;
            vectorNew.idfCollectedByOffice = idfCollectedByOffice;
            vectorNew.strCollectedByOffice = strCollectedByOffice;
            if (vectorNew.CollectedByOffice == null)
                vectorNew.CollectedByOffice =
                    CollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == vectorNew.idfCollectedByOffice);
            vectorNew.Collector = Collector;
            vectorNew.strGEOReferenceSources = strGEOReferenceSources;
            vectorNew.CollectionMethod = CollectionMethod;
            vectorNew.datCollectionDateTime = datCollectionDateTime;
            vectorNew.DayPeriod = DayPeriod;
            vectorNew.idfsEctoparasitesCollected = idfsEctoparasitesCollected;
            vectorNew.intQuantity = intQuantity;
            vectorNew.idfsSex = idfsSex;
            vectorNew.IdentifiedByOffice = IdentifiedByOffice;
            vectorNew.idfIdentifiedByOffice = idfIdentifiedByOffice;
            vectorNew.strIdentifiedByOffice = strIdentifiedByOffice;
            if (vectorNew.IdentifiedByOffice == null)
                vectorNew.IdentifiedByOffice =
                    IdentifiedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == vectorNew.idfIdentifiedByOffice);
            
            vectorNew.Identifier = Identifier;
            vectorNew.IdentificationMethod = IdentificationMethod;
            vectorNew.datIdentifiedDateTime = datIdentifiedDateTime;

            if (needCopyFF)
            {
                var accessor = ActivityParameter.Accessor.Instance(null);
                vectorNew.FFPresenter.SetProperties(FFPresenter.CurrentTemplate.idfsFormTemplate, Session.idfVectorSurveillanceSession);
                foreach (var ap in FFPresenter.ActivityParameters)
                {
                    if (!ap.idfsParameter.HasValue) continue;
                    if (!vectorNew.idfObservation.HasValue) continue;
                    var apNew = accessor.Create(manager, null, ap.idfsParameter.Value, vectorNew.idfObservation.Value, vectorNew.FFPresenter.CurrentTemplate.idfsFormTemplate);
                    apNew.varValue = ap.varValue;
                    apNew.strNameValue = ap.strNameValue;
                    vectorNew.FFPresenter.ActivityParameters.Add(apNew);
                }
                vectorNew.RecalculateVectorSpecificData();
            }

            if (needCopySamples)
            {
                var accSample = VectorSample.Accessor.Instance(null);
                var accFieldTest = VectorFieldTest.Accessor.Instance(null);

                foreach (var sample in Samples)
                {
                    var sampleNew = accSample.CreateWithParamsT(manager, vectorNew, vectorNew.GetParamsAction(typeof(VectorSample)));
                    sampleNew.VectorType = sample.VectorType;
                    sampleNew.VectorSubType = sample.VectorSubType;
                    sampleNew.strVectorSubTypeName = sample.strVectorSubTypeName;
                    //sampleNew.idfParty = sample.idfParty;
                    //это не копируем (баг 8865)
                    //sampleNew.strFieldBarcode = sample.strFieldBarcode;
                    sampleNew.idfsSampleType = sample.idfsSampleType;
                    sampleNew.datCollectionDateTime = sample.datCollectionDateTime;
                    sampleNew.FieldCollectedByOffice = sample.FieldCollectedByOffice;
                    sampleNew.idfFieldCollectedByOffice = sample.idfFieldCollectedByOffice;
                    //sampleNew.strFieldCollectedByOffice = sample.strFieldCollectedByOffice;
                    vectorNew.Samples.Add(sampleNew);

                    //перевешиваем его полевые тесты
                    if (needCopyFT)
                    {
                        var idMaterial = sampleNew.idfMaterial;
                        var fts = FieldTests.Where(c => c.idfMaterial == sample.idfMaterial).ToList();
                        foreach (var fieldTest in fts)
                        {
                            var fieldTestNew = accFieldTest.CreateWithParamsT(manager, vectorNew, vectorNew.GetParamsAction(typeof(VectorFieldTest)));
                            fieldTestNew.idfMaterial = idMaterial; //подвешен к новому семплу
                            fieldTestNew.idfsSampleType = fieldTest.idfsSampleType;
                            fieldTestNew.strSampleName = fieldTest.strSampleName;
                            fieldTestNew.idfsVectorType = fieldTest.idfsVectorType;
                            fieldTestNew.idfsPensideTestName = fieldTest.idfsPensideTestName;
                            fieldTestNew.TestType = fieldTest.TestType;
                            fieldTestNew.TestCategory = fieldTest.TestCategory;
                            fieldTestNew.datTestDate = fieldTest.datTestDate;
                            fieldTestNew.TestedByOffice = fieldTest.TestedByOffice;
                            fieldTestNew.TestedByPerson = fieldTest.TestedByPerson;
                            //по заданию копировать не надо
                            //fieldTestNew.TestResult = fieldTest.TestResult;
                            //fieldTestNew.Diagnosis = fieldTest.Diagnosis;
                            vectorNew.FieldTests.Add(fieldTestNew);
                        }
                    }
                }
            }

            //помечаем игнорирование валидации, чтобы специальным образом обработать Cancel на детальной форме векторов
            vectorNew.blnIgnoreValidation = true;

            return vectorNew;
        }

        /// <summary>
        /// 
        /// </summary>
        public class ComparerList : IComparer<Vector>
        {
            public int Compare(Vector x, Vector y)
            {
                var result = String.CompareOrdinal(x.strVectorType, y.strVectorType);
                if (result == 0) result = String.CompareOrdinal(x.strSpecies, y.strSpecies);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<object> GetParamsAction(Type oType)
        {
            var list = new List<object> { this };

            //if (oType.Name == typeof (VectorSample).Name)
            //{
            //    long? idfsSampleType = 0;
            //    if (IsPoolVectorType)
            //    {
            //        var matr = SampleTypesMatrix.FirstOrDefault(m => m.idfsVectorType == idfsVectorType);
            //        if (matr != null) idfsSampleType = matr.idfsSampleType;
            //    }
            //    list.Add(idfsSampleType);
            //}

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public partial class Accessor : IObjectSelectDetail
        {
            /// <summary>
            /// Проверка внутренних семплов
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="vector"></param>
            protected void CheckSamples(DbManagerProxy manager, Vector vector)
            {
                //TODO нужно ли это? Может движок проверяет?
                var sampleAccessor = VectorSample.Accessor.Instance(m_CS);
                //проставим недостающие значения семплам
                //vector.FillSamplesDefaultProperties();
                foreach (var sample in vector.Samples) //vector.Samples
                {
                    try
                    {
                        sample.Validation += OnSampleValidation;
                        sampleAccessor.Validate(manager, sample, true, true, true);
                    }
                    finally
                    {
                        sample.Validation -= OnSampleValidation;
                    }
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            void OnSampleValidation(object sender, ValidationEventArgs args)
            {
                throw new ValidationModelException(args);
            }
            /*
            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool ValidateCanDeleteWithoutException(DbManagerProxy manager, Vector obj)
            {
                bool result;
                _canDelete(manager
                    , obj.idfVector
                    , out result
                    );
                return result;
            }
            */
            public IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (bv.common.Configuration.BaseSettings.ScanFormsMode)
                    return CreateNew(manager, null, HACode);
                else
                    throw new NotImplementedException();
            }
        }
    }
}
