using System;
using System.Collections.Generic;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class VectorFieldTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="idTestType"></param>
        public void SetValues(VectorSample sample, long idTestType)
        {
            idfMaterial = sample.idfMaterial;
            PensideTestType = PensideTestTypeLookup.SingleOrDefault(c => c.idfsBaseReference == idTestType);
            if (PensideTestType != null) strPensideTestTypeName = PensideTestType.strDefault;
            strVectorID = sample.strVectorID;
            strFieldBarcode = sample.strFieldBarcode;
            idfsSpecimenType = sample.idfsSpecimenType;
            strSpecimenName = sample.strSpecimenName;
            if (sample.datFieldCollectionDate.HasValue) datFieldCollectionDate = sample.datFieldCollectionDate.Value;
            //Test Date заполняется только во время сохранения Полевого теста, если при этом сохранён результат теста
            //if (datTestDate == null) datTestDate = DateTime.Now;
            strVectorTypeName = sample.strVectorTypeName;
            strVectorSubTypeName = sample.strVectorSubTypeName;
            if (sample.idfsVectorType != 0) idfsVectorType = sample.idfsVectorType;
            AcceptChanges();
        }

        /// <summary>
        /// Возвращает перечень результатов тестов, подходящих для этого типа теста
        /// </summary>
        /// <returns></returns>
        public List<long> GetTestResults()
        {
            var testResults = new List<long>();
            var matrix = TypeFieldTestToResultMatrix.Where(m => m.idfsPensideTestType == idfsPensideTestType).ToList();
            testResults.AddRange(matrix.Select(m => m.idfsPensideTestResult));
            return testResults;
        }

        /// <summary>
        /// 
        /// </summary>
        public class VectorFieldTestComparer : IComparer<VectorFieldTest>
        {
            public int Compare(VectorFieldTest x, VectorFieldTest y)
            {
                var o = String.Compare(x.strPensideTestTypeName, y.strPensideTestTypeName);
                if (o == 0) o = String.Compare(x.strFieldBarcode, y.strFieldBarcode);
                return o;
            }
        }
    }
}
