using bv.model.Model.Core;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class VsSessionSummaryDiagnosis
    {
        protected static void CustomValidations(VsSessionSummaryDiagnosis sd)
        {
            //должны быть введены уникальные диагнозы
            if (sd.SessionSummary == null) return;
            if (
                sd.SessionSummary.DiagnosisList.Any(
                    d =>
                    (d.idfsVSSessionSummaryDiagnosis != sd.idfsVSSessionSummaryDiagnosis) 
                    &&
                    (d.idfsDiagnosis == sd.idfsDiagnosis)
                    &&
                    !d.IsMarkedToDelete
                    ))
            {
                throw new ValidationModelException("msgDiagnosesUniqueID", "idfsDiagnosis", "idfsDiagnosis", new object[] { }, null, ValidationEventType.Error, sd);
            }
        }
        /*
        protected static void CheckSum(VsSessionSummaryDiagnosis sd)
        {
            //сумма семплов по всем диагнозам должна быть меньше или равна общему кол-ву диагнозов
            if (sd.SessionSummary == null) return;
            if (!sd.SessionSummary.intQuantity.HasValue) return;
            var sum = sd.SessionSummary.DiagnosisList.Where(d => d.intPositiveQuantity.HasValue).Sum(d => d.intPositiveQuantity.Value);

            if (sd.SessionSummary.intQuantity.Value < sum)
            {
                throw new ValidationModelException("msgVSSummaryQuantities", "intPositiveQuantity", "intPositiveQuantity", new object[] { }, null, false);
            }
        }
        */
        /// <summary>
        /// 
        /// </summary>
        public partial class Accessor
        {
            
        }
    }
}