using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Xml;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Aggregate
{
    [NullableAdapters]
    public sealed partial class AdmUnitReport : XtraReport
    {
        private const string SpName = "spRepGetAggSumParamAdmUnit";

        public AdmUnitReport()
        {
            InitializeComponent();
        }

        internal void SetParameters(string lang, string xml, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNullOrEmpty(xml, "xml");

            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            string admUnitType;
            List<string> admUnitList = GetAdmUnitList(manager, lang, xml, out admUnitType);
            List<KeyValuePair<DateTime, DateTime>> dateList = GetDateList(xml);
            for (int i = 0; i < Math.Max(dateList.Count, admUnitList.Count); i++)
            {
                AdmUnitDataSet.HeaderTableRow row = m_DataSet.HeaderTable.NewHeaderTableRow();
                if (i < dateList.Count)
                {
                    row.StartDate = dateList[i].Key;
                    row.FinishDate = dateList[i].Value;
                }
                if (i < admUnitList.Count)
                {
                    row.AdmUnitName = admUnitList[i];
                }

                m_DataSet.HeaderTable.AddHeaderTableRow(row);
            }

            if (!string.IsNullOrEmpty(admUnitType))
            {
                AdmUnitHeaderCell.Text = admUnitType;
            }
        }

        private static List<KeyValuePair<DateTime, DateTime>> GetDateList(string xml)
        {
            var result = new List<KeyValuePair<DateTime, DateTime>>();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            foreach (XmlElement element in xmlDoc.GetElementsByTagName("TimeIntervalUnit"))
            {
                XmlAttribute startAttribute = element.Attributes["StartDate"];
                XmlAttribute finishAttribute = element.Attributes["FinishDate"];
                DateTime startDate = DateTime.Parse(startAttribute.Value, CultureInfo.InvariantCulture);
                DateTime finishDate = DateTime.Parse(finishAttribute.Value, CultureInfo.InvariantCulture);
                result.Add(new KeyValuePair<DateTime, DateTime>(startDate, finishDate));
            }

            return result;
        }

        private static List<string> GetAdmUnitList(DbManagerProxy manager, string lang, string xml, out string admUnitType)
        {
            var result = new List<string>();
            admUnitType = string.Empty;
            using (var adapter = new SqlDataAdapter())
            {
                SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                command.Transaction = (SqlTransaction) manager.Transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SpName;
                command.CommandTimeout = BaseReport.CommandTimeout;
                command.Parameters.Add(new SqlParameter("@LangID", lang));
                command.Parameters.Add(new SqlParameter("@AggrXml", xml));

                adapter.SelectCommand = command;
                var dataSet = new DataSet();
                adapter.Fill(dataSet, SpName);

                if (dataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        result.Add(Utils.Str(row["AdmUnitName"]));
                        admUnitType = Utils.Str(row["AdmUnitType"]);
                    }
                }
            }

            return result;
        }
    }
}