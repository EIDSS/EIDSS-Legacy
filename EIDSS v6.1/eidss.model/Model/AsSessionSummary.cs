using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;

namespace eidss.model.Schema
{
    public partial class AsSessionSummary
    {

        partial void Cloned()
        {
            /*var saveSamples = Samples;
            Samples = new EditableList<AsSessionSummarySample>();
            saveSamples.ForEach(c => Samples.Add(c.Clone()));

            var saveDiagnosis = Diagnosis;
            Diagnosis = new EditableList<AsSessionSummaryDiagnosis>();
            saveDiagnosis.ForEach(c => Diagnosis.Add(c.Clone()));*/
        }

        public static bool ValidateDateInRange(AsSessionSummary obj)
        {
            if (obj.datCollectionDate.HasValue)
            {
                if (((AsSession)obj.Parent).datStartDate.HasValue && obj.datCollectionDate < ((AsSession)obj.Parent).datStartDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { obj.datCollectionDate, ((AsSession)obj.Parent).datStartDate, ((AsSession)obj.Parent).datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, obj);
                if (((AsSession)obj.Parent).datEndDate.HasValue && obj.datCollectionDate > ((AsSession)obj.Parent).datEndDate)
                    throw new ValidationModelException("AsSession.SummaryItem.datCollectionDate_msgId", "datCollectionDate", "datCollectionDate", new object[] { obj.datCollectionDate, ((AsSession)obj.Parent).datStartDate, ((AsSession)obj.Parent).datEndDate }, typeof(PredicateValidator), ValidationEventType.Error, obj);
            }
            return true;
        }
    }
}
