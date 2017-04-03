using System.Collections.Generic;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public sealed partial class FormN1Report : BaseDateReport
    {
        private const int DeltaPageWidth = 820;

        public FormN1Report(bool isA3Format) : this()
        {
            if (!isA3Format)
            {
                return;
            }

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

        public FormN1Report()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, FormNo1SurrogateModel model)
        {
            
            SetParameters(manager,(BaseDateModel)model);

            formN1Header1.SetParameters(manager, model, baseDataSet1.sprepGetBaseParameters[0].CountryName);
            formN1InfectiousDiseases1.SetParameters(manager, model);
            formN1Page31.SetParameters(manager, model);
        }
    }
}