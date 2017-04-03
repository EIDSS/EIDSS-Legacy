using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Schema
{
    public partial class VectorLabTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        public void SetValues(VectorSample sample)
        {
            //idfMaterial = sample.idfMaterial;
            //PensideTestType = PensideTestTypeLookup.Where(c => c.idfsBaseReference == idTestType).SingleOrDefault();
            //strPensideTestTypeName = PensideTestType.strDefault;
            //strVectorID = sample.strVectorID;
            strFieldBarcode = sample.strFieldBarcode;
            //idfsSpecimenType = sample.idfsSpecimenType;
            //strSpecimenName = sample.strSpecimenName;
            //if (sample.datFieldCollectionDate.HasValue) datFieldCollectionDate = sample.datFieldCollectionDate.Value;
            //if (datTestDate == null) datTestDate = DateTime.Now;
            //strVectorTypeName = sample.strVectorTypeName;
            //if (sample.idfsVectorType.HasValue) idfsVectorType = sample.idfsVectorType.Value;
            AcceptChanges();
        }
    }
}
