using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class VsSession
    {
        public bool ValidateOnDelete()
        {
            return _ValidateOnDelete(false);
        }

        public List<object> GetParamsAction(Type oType)
        {
            var list = new List<object>();
            
            if (oType.Name == typeof(Vector).Name)
            {
                list.Add(idfVectorSurveillanceSession);
                list.Add(datStartDate);
                //дата начала сбора векторов совпадает с датой начала сессии по умолчанию 
                list.Add(strSessionID);
                list.Add(Location);
            }
            else if (oType.Name == typeof(VectorSample).Name)
            {
                if (Vectors.Count > 0)
                {
                    var vector = Vectors[0];
                    list.AddRange(vector.GetParamsAction(oType));
                }
            }

            return list;
        }

        /// <summary>
        /// Обновляет перечень диагнозов по всем тестам
        /// </summary>
        public void RefreshDiagnoses()
        {
            var accessor = DiagnosisItem.Accessor.Instance(null);
            DiagnosisList.Clear();
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var fieldTests = FieldTests;
                foreach (var ft in fieldTests)
                {
                    if (ft.IsMarkedToDelete) continue;
                    //если результат не индикативный, то эти диагнозы не добавляем
                    var idResult = ft.idfsPensideTestResult;
                    var idTestType = ft.idfsPensideTestName;
                    if (idResult == null) continue;
                    var matrix =
                        ft.TestResultLookup.FirstOrDefault(
                            r => (r.idfsPensideTestName == idTestType) && (r.idfsPensideTestResult == idResult));
                    if (matrix == null) continue;
                    if (!matrix.blnIndicative.HasValue) continue;
                    if (!matrix.blnIndicative.Value) continue;

                    var idDiagnosis = ft.idfsDiagnosis;
                    if (!idDiagnosis.HasValue) continue;
                    if (DiagnosisList.Count(s => s.idfsDiagnosis == idDiagnosis) == 0)
                    {
                        var diag = ft.DiagnosisLookup.FirstOrDefault(d => d.idfsDiagnosis == idDiagnosis);
                        if (diag != null) AddDiagnosisToList(accessor, manager, idDiagnosis.Value, diag.DiagnosisName);
                    }
                }
                foreach (var lt in LabTests) //TODO LabTestsFake?
                {
                    if (lt.IsMarkedToDelete) continue;
                    //если у лаб.теста результат не индикативный, то не добавляем его диагноз
                    //// commented by Vdovin because blnIndicative is absent
                    //if (!lt.blnIndicative.HasValue) continue;
                    //if (!lt.blnIndicative.Value) continue;
                    var idDiagnosis = lt.idfsDiagnosis;
                    if (DiagnosisList.Count(s => s.idfsDiagnosis == idDiagnosis) == 0)
                    {
                        var diag = DiagnosesLookup.SingleOrDefault(c => c.idfsDiagnosis == idDiagnosis);
                        if (diag != null) AddDiagnosisToList(accessor, manager, idDiagnosis, diag.name);
                    }
                }
                //дополняем диагнозами из Summary
                foreach (var summary in Summaries)
                {
                    if (summary.IsMarkedToDelete) continue;
                    foreach (var diag in summary.DiagnosisList)
                    {
                        if (diag.IsMarkedToDelete) continue;
                        if (diag.Diagnoses != null) AddDiagnosisToList(accessor, manager, diag.Diagnoses.idfsDiagnosis, diag.Diagnoses.name);
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
            DiagnosisList.Add(di);
        }

        private string GetVestorsNames()
        {
            var sb = new StringBuilder(); 
            foreach (var vector in Vectors)
            {
                if ((vector.VectorType == null) || (vector.IsMarkedToDelete)) continue; 
                if (!sb.ToString().Contains(vector.VectorType.strTranslatedName)) 
                    sb.AppendFormat(sb.Length == 0 ? "{0}" : ", {0}", vector.VectorType.strTranslatedName);
            } 
            foreach (var s in Summaries)
            {
                if (s.VectorType == null) continue; 
                if (!sb.ToString().Contains(s.VectorType.strTranslatedName)) 
                    sb.AppendFormat(sb.Length == 0 ? "{0}" : ", {0}", s.VectorType.strTranslatedName);
            } 
            return sb.ToString();
        }

        private string GetDiagnosesNames()
        {
            RefreshDiagnoses();
            var sb = new StringBuilder();
            foreach (var diag in DiagnosisList)
            {
                if (!sb.ToString().Contains(diag.NationalName))
                    sb.AppendFormat(sb.Length == 0 ? "{0}" : ", {0}", diag.NationalName);
            }
            return sb.ToString();
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

        protected void ChangeOutbreakDiagnosis()
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, idfOutbreak);
                var idfsDiagnosisGroup = outbreak.DiagnosisLookup.Single(
                        c => c.idfsDiagnosisOrDiagnosisGroup == outbreak.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup;
                manager.SetSpCommand("spOutbreak_Diagnosis_Update",
                                     manager.Parameter("@idfOutbreak", idfOutbreak),
                                     manager.Parameter("@idfsDiagnosisGroup", idfsDiagnosisGroup)
                    ).ExecuteNonQuery();
            }
        }
        /// <summary>
        /// See Floyd's cycle-finding algorithm 
        /// http://en.wikipedia.org/wiki/Floyd%27s_cycle-finding_algorithm#Tortoise_and_hare
        /// </summary>
        /// <returns></returns>
        public bool HasVectorHostLoop()
        {
            foreach (var vector in Vectors)
            {
                Vector fastNode1, fastNode2;
                Vector slowNode = fastNode2 = vector;
                while (slowNode != null && (fastNode1 = fastNode2.HostVector) != null && (fastNode2 = fastNode1.HostVector) != null)
                {
                    if (slowNode == fastNode1 || slowNode == fastNode2) return true;
                    slowNode = slowNode.HostVector;
                }
            }
            return false;
        }
        /// <summary>
        /// We are going to disable host vectors of 
        /// </summary>
        /// <returns></returns>
        public bool HasSecondLevelHostVector(Vector vector)
        {
            return vector.HostVector != null && vector.HostVector.HostVector != null;
        }
        /// <summary>
        /// Method assumes that host vector can't have host vector
        /// If this is not correct algorithm shall be improved
        /// using validation methods above
        /// </summary>
        public void SetPostingOrder()
        {
            //save original order before post
            int order = 0;
            foreach (var vector in Vectors)
                vector.intOriginalOrder = order++;
            //set post order
            order = 0;
            //vectors without host vectors must be posted firstly
            foreach (var vector in Vectors.Where(v => v.HostVector == null))
                vector.intPostOrder = order++;
            Vectors.Sort(new[] { "intPostOrder" });
        }
        public void RestoreOriginalOrder()
        {
            Vectors.Sort(new[] { "intOriginalOrder" });
        }

        public partial class Accessor
        {

            public void CheckOutbreak(VsSession obj)
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    if (obj.idfOutbreak.HasValue && obj.idfOutbreak.Value != 0)
                    {
                        var idfsCaseDiagnosis = manager.SetCommand("select dbo.fnIsCaseSessionDiagnosesInGroupOutbreak(@idfCase, @idfOutbreak)",
                            manager.Parameter("@idfCase", obj.idfVectorSurveillanceSession),
                            manager.Parameter("@idfOutbreak", obj.idfOutbreak))
                            .ExecuteScalar<long>();
                        if (idfsCaseDiagnosis == 0)
                        {
                            var outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, obj.idfOutbreak);
                            throw new ValidationModelException("msgOutbreakDiagnosisErrorCases", "idfOutbreak", "idfOutbreak",
                                new object[]
                                {
                                    obj.strSessionID,
                                    outbreak.strOutbreakID,
                                    outbreak.Diagnosis.name
                                }, GetType(), false, obj);
                        }
                        
                        if (idfsCaseDiagnosis > 0)
                        {
                            var outbreak = Outbreak.Accessor.Instance(null).SelectByKey(manager, obj.idfOutbreak);
                            throw new ValidationModelException("msgUpOutbreakDiagnosisToGroup", "idfOutbreak", "idfOutbreak",
                                new object[]
                                {
                                    outbreak.Diagnosis.name,
                                    obj.strSessionID,
                                    obj.strDiagnosesCalculated,
                                    outbreak.DiagnosisLookup.Single(i => i.idfsDiagnosisOrDiagnosisGroup == outbreak.DiagnosisLookup.Single(c => c.idfsDiagnosisOrDiagnosisGroup == outbreak.idfsDiagnosisOrDiagnosisGroup).idfsDiagnosisGroup).name
                                }, GetType(), true, obj);
                        }
                    }
                }
            }
        }
    }


}
