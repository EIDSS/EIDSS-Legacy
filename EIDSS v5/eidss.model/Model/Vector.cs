using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.EditableObjects;
using System.Text;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class Vector
    {
        /*partial void Cloned(DbManagerProxy manager, IObject clone)
        {
            var ret = clone as Vector;
            if (ret == null) return;
            var acc = Accessor.Instance(null);
            ret.m_IsNew = IsNew;
            ret.Location = Location.DeepClone();
            ret.Vectors = Vectors;
            ret.Samples = Samples;
            ret.FieldTests = FieldTests;
            ret.LabTests = LabTests;
            ret.FFPresenter = FFPresenter;
            acc._SetupLoad(manager, ret);
        }*/

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void CheckCanDelete(Vector obj)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (!Accessor.Instance(m_CS).ValidateCanDeleteWithoutException(manager, obj)) 
                {
                    throw new ValidationModelException("msgCantDeleteRecord", "_on_delete", "_on_delete", null, null);
                }
            }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        public void RecalculateLocation()
        {
            if (Location == null) return;
            if (Location.Country != null)
            {
                idfsCountry = Location.Country.idfsCountry;
                strCountry = Location.Country.strCountryName;
            }
            if (Location.Region != null)
            {
                idfsRegion = Location.Region.idfsRegion;
                strRegion = Location.Region.strRegionName;
            }
            if (Location.Rayon != null)
            {
                idfsRayon = Location.Rayon.idfsRayon;
                strRayon = Location.Rayon.strRayonName;
            }
            if (Location.Settlement != null)
            {
                idfsSettlement = Location.Settlement.idfsSettlement;
                strSettlement = Location.Settlement.strSettlementName;
            }
            dblLatitude = Location.dblLatitude;
            dblLongitude = Location.dblLongitude;
        }

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
                    if (vector.idfVector != idfVector) list.Add(vector);
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RecalculateVectorSpecificData()
        {
            if (FFPresenter == null) return;
            if (FFPresenter.CurrentTemplate == null) return;
            var sb = new StringBuilder();
            foreach (var ap in FFPresenter.ActivityParameters)
            {
                if (ap.varValue == null) continue;
                var idfsParameter = ap.idfsParameter;
                var parameter =
                    FFPresenter.CurrentTemplate.ParameterTemplates.FirstOrDefault(p => p.idfsParameter == idfsParameter);
                if (parameter == null) continue;
                sb.AppendFormat("{0}: {1}; ", parameter.NationalName, ap.GetUserValue());
            }

            strVectorSpecificData = sb.ToString();
        }

        /// <summary>
        /// Заполняет пустым семплам значения по умолчанию
        /// </summary>
        void FillSamplesDefaultProperties()
        {
            if (Samples == null) return;
            foreach (var sample in Samples)
            {
                if (!sample.datFieldCollectionDate.HasValue && (datCollectionDateTime > DateTime.MinValue))
                    sample.datFieldCollectionDate = datCollectionDateTime;
                if (
                    (!sample.idfFieldCollectedByOffice.HasValue
                    || (sample.idfFieldCollectedByOffice == 0))
                    && (idfCollectedByOffice > 0)
                    )
                {
                    sample.idfFieldCollectedByOffice = idfCollectedByOffice;
                    sample.strVectorSubTypeName = strSpecies;
                }
                //if (String.IsNullOrEmpty(sample.strFieldBarcode)) sample.strFieldBarcode = "temp";
            }
        }

        /// <summary>
        /// Получает семплы, относящиеся только к этому вектору (readonly!)
        /// </summary>
        /// <returns></returns>
        public EditableList<VectorSample> SamplesForThisVector
        {
            get
            {
                var list = new EditableList<VectorSample>();
                //поскольку Session -- это указатель на session.Samples, то там хранятся все семплы
                if (Samples != null)
                {
                    foreach (var vectorSample in Samples)
                    {
                        if (vectorSample.idfVector != idfVector) continue;
                        if (vectorSample.IsMarkedToDelete) continue;
                        list.Add(vectorSample);
                    }
                }
                return list;
            }
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
        public partial class Accessor
        {
            /// <summary>
            /// Проверка внутренних семплов
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="vector"></param>
            protected void CheckSamples(DbManagerProxy manager, Vector vector)
            {
                var sampleAccessor = VectorSample.Accessor.Instance(m_CS);
                //проставим недостающие значения семплам
                vector.FillSamplesDefaultProperties();
                foreach (var sample in vector.SamplesForThisVector) //vector.Samples
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
        }
    }
}
