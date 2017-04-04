using System;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class VectorSample
    {
        
        /*
        /// <summary>
        /// Обновляет свойства полевого теста по родительскому семплу
        /// </summary>
        public void RefreshFieldTestsForSample()
        {
            if (FieldTests == null) return;
            var fieldTests = FieldTests.Where(ft => ft.idfMaterial == idfMaterial).ToList();
            foreach (var ft in fieldTests)
            {
                if (ft.idfsPensideTestName.HasValue) ft.SetValues(this, ft.idfsPensideTestName.Value);
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
        */
        

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
            if (sample.Samples == null) return;
            if (sample.Samples.Count(s => (s.GetKey() == sample.GetKey()) && (s.idfMaterial != sample.idfMaterial) && !s.IsMarkedToDelete) > 0)
            {
                throw new ValidationModelException("msgVectorSampleUniqueID", "strFieldBarcode", "strFieldBarcode", new object[] { }, null, ValidationEventType.Error, sample);
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