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
                throw new ValidationModelException("msgHospitalUniqueID", "BSS.Hospital", "BSS.Hospital", new object[] {}, null, false, bss);
            }

            var accessor = ObjectAccessor.SelectListInterface(typeof(BasicSyndromicSurveillanceAggregateList));
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var selectedList = accessor.SelectList(manager).Cast<BasicSyndromicSurveillanceAggregateList>().ToList();
                if (selectedList.Any(c => (c.intWeek == bss.intWeek) && (c.idfsSite == bss.idfsSite)))
                {
                    throw new ValidationModelException("msgBssAggUnique", "BSS.intWeek", "BSS.intWeek", new object[] { }, null, false, bss);
                }
            }
        }
    }
}
