using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using bv.common.Core;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Aggregate
{
    public sealed partial class AdmUnitReport : XtraReport
    {
        private const string SpName = "spRepGetAggSumParamAdmUnit";

        public AdmUnitReport()
        {
            InitializeComponent();
        }

        internal void SetParameters(DbManagerProxy manager, string lang, string xml)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNullOrEmpty(xml, "xml");

            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            SqlCommand command = GetCommand(lang, xml, manager);
            using (var adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = command;
                adapter.Fill(admUnitDataSet1, SpName);
            }
        }

        private static SqlCommand GetCommand(string lang, string xml, DbManagerProxy manager)
        {
            SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
            command.Transaction = (SqlTransaction) manager.Transaction;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = SpName;
            command.CommandTimeout = BaseReport.CommandTimeout;
            command.Parameters.Add(new SqlParameter("@LangID", lang));
            command.Parameters.Add(new SqlParameter("@AggrXml", xml));
            return command;
        }
    }
}