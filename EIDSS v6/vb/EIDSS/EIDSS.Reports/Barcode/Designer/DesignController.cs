using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Barcode.Designer.Events;
using EIDSS.Reports.BaseControls.Report;
using bv.common.Core;

namespace EIDSS.Reports.Barcode.Designer
{
    public class DesignController
    {
        private readonly DesignDbAdapter m_Adapter;
        private readonly string m_DefaultLayout;
        private readonly Form m_ParentForm;

        public DesignController(long numberingObjectIndex, XtraReport report, Form parentForm)
        {
            Utils.CheckNotNull(report, "report");
            Utils.CheckNotNull(parentForm, "parentForm");

            m_ParentForm = parentForm;
            m_Adapter = new DesignDbAdapter(numberingObjectIndex);
            m_DefaultLayout = GetLayout(report);
        }

        public void SwowDesigner()
        {
            using (XtraReport newReport = GetClonedReport())
            {
                ShowReportInDesigner(newReport);
            }
        }

        public BaseBarcodeReport GetClonedReport()
        {
            string savedLayout = m_Adapter.GetBarcodeLayout();
            string currentLayout = string.IsNullOrEmpty(savedLayout) ? m_DefaultLayout : savedLayout;
            XtraReport clonedReport = GetReport(currentLayout);
            if (!(clonedReport is BaseBarcodeReport))
            {
                clonedReport = GetReport(m_DefaultLayout);
            }

            return (BaseBarcodeReport) clonedReport;
        }

        private void ShowReportInDesigner(XtraReport newReport)
        {
            using (var designForm = new DesignForm(newReport))
            {
                designForm.OnReportSave += FormOnReportSave;
                designForm.OnReportLoadDefault += FormOnReportLoadDefault;

                ShowDesignerForm(designForm, m_ParentForm);

                designForm.OnReportSave -= FormOnReportSave;
                designForm.OnReportLoadDefault -= FormOnReportLoadDefault;
            }
        }

        public void DeleteReportLayout()
        {
            m_Adapter.DeleteBarcodeLayout();
        }

        private static string GetLayout(XtraReport report)
        {
            Utils.CheckNotNull(report, "report");

            string result;
            using (var stream = new MemoryStream())
            {
                report.SaveLayout(stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        private void FormOnReportSave(object sender, DesignerSaveEventArgs e)
        {
            Utils.CheckNotNull(e, "e");
            Utils.CheckNotNull(e.Report, "e.Report");

            string layout = GetLayout(e.Report);
            m_Adapter.SaveBarcodeLayout(layout);
        }

        private void FormOnReportLoadDefault(object sender, EventArgs e)
        {
            m_Adapter.DeleteBarcodeLayout();

            using (XtraReport newReport = GetReport(m_DefaultLayout))
            {
                ShowReportInDesigner(newReport);
            }
        }

        private static void ShowDesignerForm(Form designForm, Form parentForm)
        {
            if (parentForm != null)
            {
                designForm.MinimumSize = parentForm.MinimumSize;
                designForm.Bounds = parentForm.Bounds;
                designForm.WindowState = parentForm.WindowState;

                parentForm.Visible = false;
            }

            designForm.ShowDialog();

            if (parentForm != null)
            {
                parentForm.Visible = true;
            }
        }

        internal static XtraReport GetReport(string layout)
        {
            Utils.CheckNotNullOrEmpty(layout, "layout");

            XtraReport cloneReport;
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(layout);
                    writer.Flush();
                    stream.Position = 0;
                    cloneReport = XtraReport.FromStream(stream, true);
                }
            }
            return cloneReport;
        }
    }
}