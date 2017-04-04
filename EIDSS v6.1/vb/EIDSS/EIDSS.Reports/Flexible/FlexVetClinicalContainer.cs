using System.Collections.Generic;
using System.Drawing;
using bv.model.Helpers;
using bv.winclient.Core;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Resources;

namespace EIDSS.Reports.Flexible
{
    public sealed class FlexVetClinicalContainer : BaseReportContainer
    {
        private const int Delta = 35;
        private readonly int m_Width;
        private readonly bool m_IsAvian;

        public FlexVetClinicalContainer(XRControl parentControl, int width, bool isAvian) : base(parentControl)
        {
            m_Width = width;
            m_IsAvian = isAvian;
        }

        public void SetObservations(Dictionary<long, string> observationList, long determinant)
        {
            ClearFFSubreports();
            foreach (KeyValuePair<long, string> pair in observationList)
            {
                long observation = pair.Key;
                string species = pair.Value;
                AddFFSubreport(observation, determinant, species);
            }
        }

        private void AddFFSubreport(long observation, long determinant, string speciesName)
        {
            int previousTop = (Subreports.Count > 0) ? Subreports[Subreports.Count - 1].Bottom + Delta : 0;

            CreateSpeciesLabel(previousTop, speciesName);

            XRSubreport subreport = CreateSubreport(observation);
            subreport.Top = previousTop + Delta;
            subreport.Width = m_Width;

            if (m_IsAvian)
            {
                FlexFactory.CreateAvianClinicalReport(subreport, observation, determinant);
            }
            else
            {
                FlexFactory.CreateLivestockClinicalReport(subreport, observation, determinant);
            }
            Reports.Add(subreport.ReportSource);
        }

        private void CreateSpeciesLabel(int previousTop, string speciesName)
        {
            var label = new XRLabel
            {
                Text = speciesName,
                Top = previousTop,
                Width = m_Width,
                BackColor = Color.Gainsboro,
                Borders = BorderSide.All,
                Font = new Font(WinClientContext.CurrentFont.Name, 10, FontStyle.Bold),
                TextAlignment = TextAlignment.MiddleLeft
            };

            label.Text = string.Format("   {0}:        {1}", EidssMessages.Get(@"Species"), speciesName);
            ParentControl.Controls.Add(label);
        }
    }
}