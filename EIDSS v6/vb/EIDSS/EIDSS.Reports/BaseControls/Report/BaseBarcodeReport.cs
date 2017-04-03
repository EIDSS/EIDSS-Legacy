using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Barcode;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseBarcodeReport : XtraReport
    {
        private float m_HeightRatio = 1;
        private float m_WidthRatio = 1;
        private float m_FontRatio = 1;

        public BaseBarcodeReport()
        {
            InitializeComponent();
        }

        public void InitPrinterSettings()
        {
            int externalWidth = PageWidth;
            int externalHeight = PageHeight;
            if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
            {
                PrinterName = BaseSettings.BarcodePrinter ?? string.Empty;
                if (!string.IsNullOrEmpty(PrinterName))
                {
                    var settings = new PrinterSettings {PrinterName = PrinterName};
                    PaperSize paperSize = settings.DefaultPageSettings.PaperSize;
                    externalWidth = paperSize.Width;
                    externalHeight = paperSize.Height;
                }
            }
            else
            {
                externalWidth = BaseSettings.WebBarcodePageWidth;
                externalHeight = BaseSettings.WebBarcodePageHeight;
            }

            if (externalHeight != PageHeight || externalWidth != PageWidth)
            {
                ((ISupportInitialize) this).BeginInit();
                if (externalHeight != PageHeight)
                {
                    m_HeightRatio = (float) externalHeight / PageHeight;
                    PageHeight = externalHeight;
                }
                if (externalWidth != PageWidth)
                {
                    m_WidthRatio = (float) externalWidth / PageWidth;
                    PageWidth = externalWidth;
                }
                m_FontRatio = Math.Min(m_HeightRatio, m_WidthRatio);

                ResizeControls();
                ((ISupportInitialize) this).EndInit();
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning && m_FontRatio < 1)
                {
                    ErrorForm.ShowWarning("msgBarcodePaperTooSmall",
                        "Barcode printer has too small paper size. It's  possible that  printed labels cannot be scanned.");
                }
            }
        }

        public virtual void GetBarcodeById(DbManagerProxy manager, long typeId, IList<long> idList)
        {
            spRepGetBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;
            foreach (long id in idList)
            {
                var barcodeData = new BarcodeDataSet.spRepGetBarcodeDataTable();
                spRepGetBarcodeTableAdapter.Fill(barcodeData, typeId, id);
                barcodeDataSet1.spRepGetBarcode.Merge(barcodeData);
                //spRepGetBarcodeTableAdapter.Fill(barcodeDataSet1.spRepGetBarcode, typeId, id);
            }
        }

        public void GetNewBarcode(DbManagerProxy manager, long typeId, int quantity)
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

        private void ResizeControls()
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo[] fields = GetType().GetFields(flags);

            var controlList = new List<XRControl>();
            var initalList = new List<ISupportInitialize>();

            foreach (FieldInfo info in fields)
            {
                if (typeof (XRControl).IsAssignableFrom(info.FieldType))
                {
                    var value = info.GetValue(this) as XRControl;
                    if (value != null)
                    {
                        controlList.Add(value);

                        var initializable = value as ISupportInitialize;
                        if (initializable != null)
                        {
                            initalList.Add(initializable);
                            initializable.BeginInit();
                        }
                    }
                }
            }

            foreach (XRControl control in controlList)
            {
                if (Math.Abs(m_HeightRatio - 1) > float.Epsilon)
                {
                    control.TopF *= m_HeightRatio;
                    control.HeightF *= m_HeightRatio;
                }
                if (Math.Abs(m_WidthRatio - 1) > float.Epsilon)
                {
                    control.LeftF *= m_WidthRatio;
                    control.WidthF *= m_WidthRatio;
                }

                var label = control as XRLabel;
                if (label != null && Math.Abs(m_FontRatio - 1) > float.Epsilon)
                {
                    Font font = label.Font;
                    label.Font = new Font(font.Name, font.Size * m_FontRatio,
                        font.Style, font.Unit, font.GdiCharSet, font.GdiVerticalFont);
                }
            }

            foreach (ISupportInitialize initializable in initalList)
            {
                initializable.EndInit();
            }
        }
    }
}