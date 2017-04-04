using System.Collections.Generic;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class FormN1Report : BaseDateReport
    {
        private const int DeltaPageWidth = 820;

        public FormN1Report()
        {
            InitializeComponent();
        }

        public void SetParameters(FormNo1SurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (model.IsA3Format)
            {
                ChangeFormatToA3();
            }
            SetParameters((BaseDateModel) model, manager, archiveManager);

            formN1Header1.SetParameters(model, m_BaseDataSet.sprepGetBaseParameters[0].CountryName, manager, archiveManager);
            formN1InfectiousDiseases1.SetParameters(model, manager, archiveManager);
            formN1Page31.SetParameters(model, manager, archiveManager);
        }

        private void ChangeFormatToA3()
        {
            PaperKind = PaperKind.A3;
            Landscape = true;

            MovePage(DetailPage1, DetailPage4, true);
            MovePage(DetailPage2, DetailPage3, false);
            DetailReportPage3.Visible = false;
            DetailReportPage4.Visible = false;
        }

        private static void MovePage(DetailBand firstPage, DetailBand secondPage, bool shiftFirstPage)
        {
            DetailBand pageToShift = (shiftFirstPage) ? firstPage : secondPage;
            foreach (XRControl control in pageToShift.Controls)
            {
                control.Left += DeltaPageWidth;
            }

            var page4Controls = new List<XRControl>();
            foreach (XRControl control in secondPage.Controls)
            {
                page4Controls.Add(control);
            }
            foreach (XRControl control in page4Controls)
            {
                secondPage.Controls.Remove(control);
                firstPage.Controls.Add(control);
            }
        }
    }
}