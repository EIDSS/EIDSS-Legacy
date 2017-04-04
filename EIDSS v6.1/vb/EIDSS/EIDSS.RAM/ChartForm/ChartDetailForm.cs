using System;
using System.Data;
using System.Drawing;
using bv.common;
using bv.common.win;
using eidss.avr.db.DBService;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.ChartForm
{
    public partial class ChartDetailForm : BaseDetailForm
    {
        private DataTable m_DataSource;

        public ChartDetailForm()
        {
            InitializeComponent();

            if (IsDesignMode())
            {
                return;
            }

            DbService = new Chart_DB();

            ChartDetail.UseParentDataset = true;
            RegisterChildObject(ChartDetail, RelatedPostOrder.SkipPost);
            IgnoreAudit = true;

            ShowNewButton = false;
            ShowDeleteButton = false;
            ExportChartButton.Enabled = true;
            PrintChartButton.Enabled = true;
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            eventManager.ClearAllReferences();
            if (ChartDetail != null)
            {
                UnRegisterChildObject(ChartDetail);
                ChartDetail.Dispose();
                ChartDetail = null;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public DataTable DataSource
        {
            get { return m_DataSource; }
            set
            {
                m_DataSource = value;
                ChartDetail.DataSource = m_DataSource;
            }
        }

        public Size ChartControlSize
        {
            get { return ChartDetail.ChartControl.Size; }
            set
            {
                int deltaWidth = Width - ChartDetail.ChartControl.Width;
                int deltaHeight = Height - ChartDetail.ChartControl.Height;
                Size = new Size(value.Width + deltaWidth, value.Height + deltaHeight);
            }
        }

        private void ExportChartButton_Click(object sender, EventArgs e)
        {
            ChartDetail.ExportChart();
        }

        private void PrintChartButton_Click(object sender, EventArgs e)
        {
            ChartDetail.PrintChart();
        }

        public ChartExportDTO ExportToJpgBytes(byte[] initialChartSettings, DBChartType? chartType)
        {
            if (initialChartSettings != null && initialChartSettings.Length > 0)
            {
                ChartDetail.SetInitialXml(BinaryCompressor.UnzipString(initialChartSettings));
            }
            else
            {
                ChartDetail.SetupChart();
            }
            
            var finalChartSettings = initialChartSettings;
            if (chartType.HasValue)
            {
                ChartDetail.ChangeChartTypeForAllSeries(chartType.Value);
                finalChartSettings = ChartDetail.GetXml();
            }

            var jpgBytes = ChartDetail.ExportToJpgBytes();

            return new ChartExportDTO(jpgBytes, finalChartSettings);
        }

        public string GetXml()
        {
            return ChartDetail != null ? ChartDetail.GetXmlString() : String.Empty;
        }

        public void SetXml(string xml)
        {
            if (ChartDetail == null) return;
            ChartDetail.SetInitialXml(xml);
        }

        public bool NeedSave()
        {
            return ChartDetail != null && !ChartDetail.IsPosted;
        }
    }
}