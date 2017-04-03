using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using eidss.model.Resources;
using EIDSS.Reports.Barcode;
using EIDSS.Reports.Barcode.Designer;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public partial class BaseBarcodeKeeper : BvXtraUserControl
    {
        public const float BarcodeZoom = 2.0f;
        private const string ColumnNumberName = "strNumberName";
        private const string ColumnNumberId = "idfsNumberName";
        private BarcodeKeeperMode m_Mode = BarcodeKeeperMode.New;
        private IList<long> m_ObjectIdList = new List<long>();
        private IList<SampleBarcodeDTO> m_SamplesList = new List<SampleBarcodeDTO>();
        private DesignController m_DesignController;

        public BaseBarcodeKeeper()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }

            BindCbTemplateTypes();

            reportView1.OnReportEdit += ReportViewOnReportEdit;
            reportView1.OnReportLoadDefault += ReportView1OnReportLoadDefault;
        }

        public void SetObject(NumberingObject type, IList<long> idList)
        {
            m_ObjectIdList = idList ?? new List<long>();
            if (m_ObjectIdList.Count > 0)
            {
                m_Mode = BarcodeKeeperMode.Existing;
            }

            InitBarcodeTypeLookup(type);
        }

        public void SetObject(IList<SampleBarcodeDTO> samples)
        {
            m_SamplesList = samples ?? new List<SampleBarcodeDTO>();
            m_Mode = BarcodeKeeperMode.SampleNewOrExisting;
            InitBarcodeTypeLookup(NumberingObject.Sample);
        }

        private void InitBarcodeTypeLookup(NumberingObject type)
        {
            var dataView = ((DataView) cbTemplateTypes.Properties.DataSource);
            dataView.Sort = "idfsNumberName";
            DataRowView[] found = dataView.FindRows((long) type);
            if (found.Length > 0)
            {
                cbTemplateTypes.EditValue = found[0][ColumnNumberId];
            }
        }

        private void ReportView1OnReportLoadDefault(object sender, EventArgs e)
        {
            if (m_DesignController == null)
            {
                throw new ApplicationException("Report Design Controller is not initialized.");
            }

            DialogResult dialogResult = MessageForm.Show(BvMessages.Get("msgLoadDefaultReport", "Load default report?"),
                BvMessages.Get("Confirmation"),
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                m_DesignController.DeleteReportLayout();
                ReloadReport();
            }
        }

        private void ReportViewOnReportEdit(object sender, EventArgs e)
        {
            if (m_DesignController == null)
            {
                throw new ApplicationException("Report Design Controller is not initialized.");
            }

            m_DesignController.SwowDesigner();

            ReloadReport();
        }

        private void cbTemplateTypes_EditValueChanged(object sender, EventArgs e)
        {
            ReloadReport();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            ReloadReport();
        }

        private void ReloadReport()
        {
            grcHeader.Visible = m_Mode == BarcodeKeeperMode.New;
            if (Utils.IsEmpty(cbTemplateTypes.EditValue))
            {
                return;
            }

            var itemId = (long) (cbTemplateTypes.EditValue);

            BaseBarcodeReport defaultReport = BarcodeReportGenerator.GenerateBarcodeReport(itemId);

            m_DesignController = new DesignController(itemId, defaultReport, FindForm());
            BaseBarcodeReport report = m_DesignController.GetClonedReport();
            report.InitPrinterSettings();

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                switch (m_Mode)
                {
                    case BarcodeKeeperMode.New:
                        report.GetNewBarcode(manager, itemId, (int) numQuantity.Value);
                        break;
                    case BarcodeKeeperMode.Existing:
                        report.GetBarcodeById(manager, itemId, m_ObjectIdList);
                        break;

                    case BarcodeKeeperMode.SampleNewOrExisting:
                        ((SampleBarcodeReport) report).GetBarcodeBySampleData(m_SamplesList);
                        break;
                }
            }
            if (reportView1.Report != null)
            {
                reportView1.Report.PrintingSystem.StartPrint -= PrintingSystem_StartPrint;
            }
            reportView1.SetReport(report, true);
            reportView1.Report.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
            reportView1.Zoom = BarcodeZoom;
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            if (numCopies.Value > 3)
            {
                numCopies.Value = 3;
            }
            if (numCopies.Value < 1)
            {
                numCopies.Value = 1;
            }
            e.PrintDocument.PrinterSettings.Copies = (short) numCopies.Value;
        }

        private void BindCbTemplateTypes()
        {
            cbTemplateTypes.Properties.Columns.Clear();
            string caption = EidssMessages.Get("colBarcodeType", "Barcode type");

            cbTemplateTypes.Properties.Columns.Add(new LookUpColumnInfo(ColumnNumberName, caption, 200, FormatType.None,
                "", true, HorzAlignment.Near));

            cbTemplateTypes.Properties.DataSource = GetNumberNamesTable();
            cbTemplateTypes.Properties.DisplayMember = ColumnNumberName;
            cbTemplateTypes.Properties.ValueMember = ColumnNumberId;
        }

        private static DataView GetNumberNamesTable()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spRepGetNumberNameList";

                    command.Parameters.Add(new SqlParameter("@LangID",
                        ModelUserContext.CurrentLanguage));
                    adapter.SelectCommand = command;
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    DataTable dataTable = dataSet.Tables[0];
                    dataTable.PrimaryKey = new[] {dataTable.Columns[ColumnNumberId]};
                    var dataView = new DataView(dataTable) {Sort = ColumnNumberName};
                    return dataView;
                }
            }
        }
    }
}