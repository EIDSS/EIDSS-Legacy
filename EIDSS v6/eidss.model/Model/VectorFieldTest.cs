using System;
using System.Collections.Generic;

namespace eidss.model.Schema
{
    public partial class VectorFieldTest
    {
        

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
