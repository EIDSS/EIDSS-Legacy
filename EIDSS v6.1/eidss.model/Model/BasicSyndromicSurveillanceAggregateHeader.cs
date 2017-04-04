using BLToolkit.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class BasicSyndromicSurveillanceAggregateHeader
    {
        /// <summary>
        /// 
        /// </summary>
        protected static void CustomValidations(BasicSyndromicSurveillanceAggregateHeader bss)
        {
            if (bss.BSSAggregateDetail == null) return;

            if (bss.BSSAggregateDetail.Any(d => bss.BSSAggregateDetail.Count(b => b.idfHospital == d.idfHospital) > 1))
            {
                throw new ValidationModelException("msgHospitalUniqueID", "BSS.Hospital", "BSS.Hospital", new object[] { }, null, ValidationEventType.Error, bss);
            }

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var ret = manager.SetSpCommand("spBasicSyndromicSurveillanceAggregateHeader_Exists",
                                     manager.Parameter("@idfAggregateHeader", bss.idfAggregateHeader),
                                     manager.Parameter("@intWeek", bss.intWeek),
                                     manager.Parameter("@intYear", bss.intYear),
                                     manager.Parameter("@idfsSite", bss.idfsSite)).ExecuteScalar<int>(ScalarSourceType.ReturnValue);
                if (ret == 1)
                {
                    throw new ValidationModelException("msgBssAggUnique", "", "", new object[] { }, null, ValidationEventType.Error, bss);
                }
            }
        }
    }
}
