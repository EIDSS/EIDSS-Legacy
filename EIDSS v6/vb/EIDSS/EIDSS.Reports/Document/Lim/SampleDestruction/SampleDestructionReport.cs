using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.SampleDestruction
{
    public sealed partial class SampleDestructionReport : BaseDocumentReport
    {
        public SampleDestructionReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            if (!parameters.ContainsKey("@Samples"))
            {
                throw new ArgumentException("Could not get parameter '@Samples' from input dictionary.", "parameters");
            }
            string xml = parameters["@Samples"];

            SampleDestructionDataSet.EnforceConstraints = false;
            SampleDestructionAdapter.Connection = (SqlConnection) manager.Connection;
            SampleDestructionAdapter.Transaction = (SqlTransaction) manager.Transaction;
            SampleDestructionAdapter.CommandTimeout = CommandTimeout;

            SampleDestructionAdapter.Fill(SampleDestructionDataSet.SampleDestruction, lang, xml);
        }

        public void SetParameters(DbManagerProxy manager, string lang, IEnumerable<long> sampleIds)
        {
            SetParameters(manager, lang, ConvertSampeIdsToParameters(sampleIds));
        }

        public static Dictionary<string, string> ConvertSampeIdsToParameters(IEnumerable<long> sampleIds)
        {
            string xml = FilterHelper.GetXmlFromList("idfMaterial", sampleIds.Select(s => s.ToString()));
            var parameters = new Dictionary<string, string> {{"@Samples", xml}};
            return parameters;
        }
    }
}