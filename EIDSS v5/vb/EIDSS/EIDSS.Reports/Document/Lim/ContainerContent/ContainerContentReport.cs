using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.ContainerContent
{
    public sealed partial class ContainerContentReport : BaseDocumentReport
    {
        private delegate bool ShouldRemoveRowDelegate(ContainerContentDataSet.spRepLimContainerContentRow dataRow);

        public ContainerContentReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            long? contId = GetLongParamValue(parameters, "@ContID");
            long? freezerId = GetLongParamValue(parameters, "@FreezerID");

            containerContentDataSet1.EnforceConstraints = false;
            sp_rep_LIM_ContainerContentTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_LIM_ContainerContentTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_LIM_ContainerContentTableAdapter1.CommandTimeout = CommandTimeout;

            sp_rep_LIM_ContainerContentTableAdapter1.Fill(containerContentDataSet1.spRepLimContainerContent, lang, contId, freezerId);

            RemoveDataRows(dataRow => dataRow.IsSubDivisionNameNull());
        }

        private static long? GetLongParamValue(IDictionary<string, string> parameters, string paramName)
        {
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(parameters, "parameters");

            string outValue;
            if (!parameters.TryGetValue(paramName, out outValue))
            {
                throw new ArgumentException(string.Format("Could not get parameter {0}.", paramName));
            }
            long? result = string.IsNullOrEmpty(outValue) ? (long?) null : long.Parse(outValue);
            return result;
        }

        private void cellBarcode_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null)
            {
                if (cell.Text == @"**")
                {
                    cell.Text = "";
                }
            }
        }

        private void RemoveDataRows(ShouldRemoveRowDelegate shouldRemoveRow)
        {
            Utils.CheckNotNull(shouldRemoveRow, "shouldRemoveRow");
            var rowsToRemove = new List<DataRow>();
            foreach (
                ContainerContentDataSet.spRepLimContainerContentRow dataRow in
                    containerContentDataSet1.spRepLimContainerContent.Rows)
            {
                if (shouldRemoveRow(dataRow))
                {
                    rowsToRemove.Add(dataRow);
                }
            }
            foreach (DataRow dataRow in rowsToRemove)
            {
                containerContentDataSet1.spRepLimContainerContent.Rows.Remove(dataRow);
            }
        }
    }
}