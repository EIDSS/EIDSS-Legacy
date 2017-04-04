using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.Mapping;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class DiagnosisOrGroupModel :IDisposable
    {
        public DiagnosisOrGroupModel(string bindingField = "DiagnosisId")
        {
            BindingField = bindingField;
        }

        public string BindingField { get; set; }

        public void Dispose()
        {
            if (ItemsList != null) ItemsList.Clear();
        }
        [LocalizedDisplayName("DiagnosisName")]
        public long? idfsDiagnosisOrDiagnosisGroup { get; set; }
        public List<SelectListItemSurrogate> ItemsList { get; private set; }
        public void SetDiagnoses(List<SelectListItemSurrogate> diagnosisList)
        {
            ItemsList = diagnosisList;
        }
    }
}
