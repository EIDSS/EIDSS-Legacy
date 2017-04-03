using System;
using System.Data;
using System.Data.SqlClient;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseBarcodeReport : XtraReport
    {
        public BaseBarcodeReport()
        {
            InitializeComponent();
            PrinterName = BaseSettings.BarcodePrinter ?? string.Empty;
        }

        internal virtual void GetBarcodeById(DbManagerProxy manager, long typeId, long id)
        {
            spRepGetBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepGetBarcodeTableAdapter.Fill(barcodeDataSet1.spRepGetBarcode, typeId, id);
        }

        internal void GetNewBarcode(DbManagerProxy manager, long typeId, int quantity)
        {
            using (var adapter = new SqlDataAdapter())
            {
                SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetNextNumberRange";

                command.Parameters.Add(new SqlParameter("@NextNumberName", typeId));
                command.Parameters.Add(new SqlParameter("@count", quantity));
                command.Parameters.Add(new SqlParameter("@InstallationSite", DBNull.Value));
                adapter.SelectCommand = command;

                var numberRangeDataSet = new DataSet();
                adapter.Fill(numberRangeDataSet);
                foreach (DataRow row in numberRangeDataSet.Tables[0].Rows)
                {
                    string newNumber = row["NumbersRange"].ToString();
                    AppendDatasetWithNewRow(newNumber);
                }
            }
        }

        protected virtual void AppendDatasetWithNewRow(string newId)
        {
            Utils.CheckNotNullOrEmpty(newId, "newId");
            barcodeDataSet1.spRepGetBarcode.AddspRepGetBarcodeRow(string.Empty, newId, newId);
        }
    }
}