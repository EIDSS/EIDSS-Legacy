using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Model;

namespace eidss.model.Schema
{
    public partial class VsSession
    {
        public bool ValidateOnDelete()
        {
            return _ValidateOnDelete(false);
        }

        /// <summary>
        /// Производит пересчёт списка FieldTest, когда изменились входные параметры
        /// </summary>
        public void RefreshFieldTests(DbManagerProxy manager)
        {
            //для списка входными параметрами являются набор семплов

            //фильтруем матрицу тестов по типам тестов, доступных для данной сессии
            var testTypes = new List<PensideTestLookup>();
            foreach (var testType in PensideTestTypeLookup)
            {
                var idTestType = testType.idfsPensideTestType;
                foreach (var vectorType in SessionToVectorType)
                {
                    if (vectorType.IsChecked == 0) continue;
                    var idVectorType = vectorType.idfsVectorType;

                    if ((testType.idfsVectorType == idVectorType)
                        &&
                        (testTypes.Count(c => c.idfsVectorType == idVectorType && c.idfsPensideTestType == idTestType) == 0)
                        )
                    {
                        testTypes.Add(testType);
                    }
                }
            }
            
            //удаляем более не нужные тесты
            for(var i = FieldTests.Count - 1; i>=0; i--)
            {
                var idMaterial = FieldTests[i].idfMaterial;
                var idTestType = FieldTests[i].idfsPensideTestType;
                if (
                    (Samples.All(s => s.idfMaterial != idMaterial))
                    ||
                    (testTypes.All(t => t.idfsPensideTestType != idTestType)))
                {
                    //FieldTests.RemoveAt(i);
                    FieldTests[i].MarkToDelete();
                    FieldTests[i].AcceptChanges();
                }
            }

            var accFieldTest = VectorFieldTest.Accessor.Instance(null);

            //добавляем тесты для сессий
            foreach (var sample in Samples)
            {
                if (sample.IsMarkedToDelete) continue;
                if (!sample.datFieldCollectionDate.HasValue) continue;
                if (sample.idfsSpecimenType == 0) continue;
                if (sample.strFieldBarcode == null) continue;
                if (sample.idfsVectorType == 0) continue;

                var idMaterial = sample.idfMaterial;
                foreach (var testType in testTypes)
                {
                    if (!testType.idfsVectorType.Equals(sample.idfsVectorType)) continue;
                    var idTestType = testType.idfsPensideTestType;
                    //если такой тест есть, то генерить его не надо
                    var fieldTests = FieldTests.Where(ft => (ft.idfMaterial == idMaterial) && (ft.idfsPensideTestType == idTestType)).ToList();
                    if (fieldTests.Count > 0)
                    {
                        foreach (var fieldTest in fieldTests)
                        {
                            fieldTest.SetValues(sample, testType.idfsPensideTestType);
                        }
                    }
                    else
                    {
                        var fieldTest = accFieldTest.CreateNewT(manager, this);
                        fieldTest.SetValues(sample, testType.idfsPensideTestType);
                        FieldTests.Add(fieldTest);
                        FieldTests[FieldTests.Count - 1].AcceptChanges();
                    }
                }
            }

            var comparer = new VectorFieldTest.VectorFieldTestComparer();
            FieldTests.Sort(comparer);
            FieldTests.AcceptChanges();

            //обновим и перечень диагнозов
            RefreshDiagnoses();

            //обновляем саммари для полевых тестов
            RefreshFieldTestsSummary();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFieldTestsSummary()
        {
            //обновляем саммари для лабораторных тестов
            FieldTestsSummary = SummaryTable.GetSummaryTables(FieldTests);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshLabTestsSummary()
        {
            //обновляем саммари для лабораторных тестов
            LabTestsSummary = SummaryTable.GetSummaryTables(LabTests);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshLabTests()
        {
            //добавляем тесты для сессий
            foreach (var sample in Samples)
            {
                sample.RefreshLabTestsForSample();
            }
            LabTests.AcceptChanges();
        }

        /// <summary>
        /// Обновляет перечень диагнозов по всем тестам
        /// </summary>
        public void RefreshDiagnoses()
        {
            var accessor = DiagnosisItem.Accessor.Instance(null);
            Diagnosis.Clear();
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                foreach (var ft in FieldTests)
                {
                    //если результат не индикативный, то эти диагнозы не добавляем
                    var idResult = ft.idfsPensideTestResult;
                    var idTestType = ft.idfsPensideTestType;
                    if (idResult == null) continue;
                    var matrix = ft.TypeFieldTestToResultMatrix.FirstOrDefault(r => (r.idfsPensideTestType == idTestType) && (r.idfsPensideTestResult == idResult));
                    if (matrix == null) continue;
                    if (!matrix.blnIndicative.HasValue) continue; 
                    if (!matrix.blnIndicative.Value) continue; 

                    var idDiagnosis = ft.idfsDiagnosis;
                    if (!idDiagnosis.HasValue) continue;
                    if (Diagnosis.Count(s => s.idfsDiagnosis == idDiagnosis) == 0)
                    {
                        var diag = ft.Diagnosis2PensideTestMatrix.FirstOrDefault(d => d.idfsDiagnosis == idDiagnosis);
                        if (diag != null) AddDiagnosisToList(accessor, manager, idDiagnosis.Value, diag.DiagnosisName);
                    }
                }
                foreach (var lt in LabTests)
                {
                    //если у лаб.теста результат не индикативный, то не добавляем его диагноз
                    //// commented by Vdovin because blnIndicative is absent
                    //if (!lt.blnIndicative.HasValue) continue;
                    //if (!lt.blnIndicative.Value) continue;
                    var idDiagnosis = lt.idfsDiagnosis;
                    if (Diagnosis.Count(s => s.idfsDiagnosis == idDiagnosis) == 0)
                    {
                        var diag = DiagnosesLookup.SingleOrDefault(c => c.idfsDiagnosis == idDiagnosis);
                        if (diag != null) AddDiagnosisToList(accessor, manager, idDiagnosis, diag.name);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="manager"></param>
        /// <param name="idDiagnosis"></param>
        /// <param name="diagnosisName"></param>
        private void AddDiagnosisToList(DiagnosisItem.Accessor accessor, DbManagerProxy manager, long idDiagnosis, string diagnosisName)
        {
            var di = accessor.CreateNewT(manager, this);
            di.idfVectorSurveillanceSession = idfVectorSurveillanceSession;
            di.idfsDiagnosis = idDiagnosis;
            di.NationalName = diagnosisName;
            Diagnosis.Add(di);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public void InitRoutines(DbManagerProxy manager)
        {
            RefreshFieldTests(manager);
            RefreshLabTestsSummary();
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void CheckCanDelete(VsSession obj)
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
        public partial class Accessor
        {

            /*
            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool ValidateCanDeleteWithoutException(DbManagerProxy manager, VsSession obj)
            {
                bool result;
                _canDelete(manager
                    , obj.idfVectorSurveillanceSession
                    , out result
                    );
                return result;
            }
             */
        }
    }


}
