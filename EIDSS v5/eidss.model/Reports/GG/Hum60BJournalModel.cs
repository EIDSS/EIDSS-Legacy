using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class Hum60BJournalModel : BaseIntervalModel
    {
        public Hum60BJournalModel()
        {
        }

        public Hum60BJournalModel(string lang, DateTime startDate, DateTime endDate, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
        }

        [LocalizedDisplayName("DiagnosisName")]
        public long? Diagnosis { get; set; }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get { return FilterHelper.GetHumanDiagnosisList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }
    }
}