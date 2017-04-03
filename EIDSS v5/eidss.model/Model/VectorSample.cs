using System;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class VectorSample
    {
        /*partial void Cloned(DbManagerProxy manager, IObject clone)
        {
            var ret = clone as VectorSample;
            if (ret == null) return;
            ret.m_IsNew = IsNew;
            //не все поля почему-то переносятся в базовом клонировании
            //ret.idfsAccessionCondition = idfsAccessionCondition;
            //ret.idfCase = idfVector;
            //ret.idfsSpecimenType = idfsSpecimenType;
            //ret.idfFieldCollectedByOffice = idfFieldCollectedByOffice;
            var acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void CheckCanDelete(VectorSample obj)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (!Accessor.Instance(m_CS).ValidateCanDeleteWithoutException(manager, obj))
                {
                    throw new ValidationModelException("msgCantDeleteRecord", "_on_delete", "_on_delete", null, null, false);
                }
                var fts = FieldTests.Where(ft => ft.idfMaterial == idfMaterial).ToList();
                //проверим на удаление с точки зрения полевых тестов
                if (fts.Count(ft => (ft.idfsPensideTestResult != null)
                                       || (ft.datTestDate != null)
                                       || (ft.PensideTestCategory != null)
                                       || (ft.TestedByOffice != null)
                                       || (ft.TestedByPerson != null)
                                       || (ft.idfsDiagnosis != null)) > 0)
                {
                    throw new ValidationModelException("msgCantDeleteVectorSampleFT", "_on_delete", "_on_delete", null, null, false);
                }
            }
        }

        /// <summary>
        /// Обновляет свойства полевого теста по родительскому семплу
        /// </summary>
        public void RefreshFieldTestsForSample()
        {
            if (FieldTests == null) return;
            var fieldTests = FieldTests.Where(ft => ft.idfMaterial == idfMaterial).ToList();
            foreach (var ft in fieldTests)
            {
                if (ft.idfsPensideTestType.HasValue) ft.SetValues(this, ft.idfsPensideTestType.Value);
            }
        }

        /// <summary>
        /// Обновляет свойства лабораторного теста по родительскому семплу
        /// </summary>
        public void RefreshLabTestsForSample()
        {
            if (LabTests == null) return;
            var labTests = LabTests.Where(lt => lt.idfMaterial == idfMaterial).ToList();
            foreach (var lt in labTests)
            {
                lt.SetValues(this);
                lt.AcceptChanges();
            }
        }

        /// <summary>
        /// Выставление свойств семплу от родительского вектора
        /// </summary>
        public void SetValues(Vector vector)
        {
            if (vector == null) vector = ParentVector;
            if (vector == null) return;
            var vectorTypeChanged = idfsVectorType != vector.idfsVectorType;
            idfsVectorType = vector.idfsVectorType;
            idfsVectorSubType = vector.idfsVectorSubType;
            strVectorID = vector.strVectorID;
            strVectorTypeName = vector.strVectorType;
            isPool = vector.IsPoolVectorType;
            if (ParentVector.VsVectorSubType != null) strVectorSubTypeName = vector.VsVectorSubType.name;
            if (vectorTypeChanged)
            {
                //выдадим первый подтип из доступных для нового типа вектора
                var matrixFirst = SampleTypesMatrix.FirstOrDefault(m => m.idfsVectorType == idfsVectorType);
                if (matrixFirst != null)
                {
                    idfsSpecimenType = matrixFirst.idfsSampleType;
                    strSpecimenName = matrixFirst.SampleName;
                }
            }
            else
            {
                var matrix = SampleTypesMatrix.FirstOrDefault(m => m.idfsSampleType == idfsSpecimenType);
                if (matrix != null) strSpecimenName = matrix.SampleName;
            }

            //обновляем в зависимых полевых и лабораторных тестах
            RefreshFieldTestsForSample();
            RefreshLabTestsForSample();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            return VectorType != null ? String.Format("F_{0}_VT_{1}", strFieldBarcode, VectorType.idfsBaseReference) : String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        protected static void CustomValidations(VectorSample sample)
        {
            //у всех семплов в сессии должна быть уникальная пара Field Sample ID + Vector Type
            if (sample.VectorType == null) return;
            if (sample.SessionSamples == null) return;
            if (sample.SessionSamples.Count(s => (s.GetKey() == sample.GetKey()) && (s.idfMaterial != sample.idfMaterial)) > 0)
            {
                throw new ValidationModelException("msgVectorSampleUniqueID", "strFieldBarcode", "strFieldBarcode", new object[] { }, null, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public partial class Accessor
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool ValidateCanDeleteWithoutException(DbManagerProxy manager, VectorSample obj)
            {
                bool result;
                _canDelete(manager
                    , obj.idfMaterial
                    , out result
                    );
                return result;
            }
        }
    }
}