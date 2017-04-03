using System.Collections.Generic;
using System.Drawing;
using bv.common.Core;
using bv.winclient.Core;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Resources;

namespace EIDSS.Reports.Flexible
{
    public class FlexVetClinicalContainer
    {
        private const int Delta = 35;
        private readonly XRControl m_ParentControl;
        private readonly List<FlexReport> m_TestCaseFFReports = new List<FlexReport>();
        private readonly List<XRSubreport> m_Subreports = new List<XRSubreport>();
        private readonly int m_Width;
        private readonly bool m_IsAvian;

        public FlexVetClinicalContainer(XRControl parentControl, int width, bool isAvian)
        {
            Utils.CheckNotNull(parentControl, "parentControl");
            m_ParentControl = parentControl;
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

        private void ClearFFSubreports()
        {
            foreach (XRSubreport oldSubreport in m_Subreports)
            {
                m_ParentControl.Controls.Remove(oldSubreport);
            }
            m_Subreports.Clear();
        }

        private void AddFFSubreport(long observation, long determinant, string speciesName)
        {
            int previousTop = (m_Subreports.Count > 0) ? m_Subreports[m_Subreports.Count - 1].Bottom + Delta : 0;

            CreateSpeciesLabel(previousTop, speciesName);

            XRSubreport subreport = CreateSubreport(observation, previousTop);

            if (m_IsAvian)
            {
                FlexFactory.CreateAvianClinicalReport(subreport, observation, determinant);
            }
            else
            {
                FlexFactory.CreateLivestockClinicalReport(subreport, observation, determinant);
            }
            m_TestCaseFFReports.Add((FlexReport) subreport.ReportSource);
        }

        private XRSubreport CreateSubreport(long observation, int previousTop)
        {
            var subreport = new XRSubreport {Top = previousTop + Delta, Width = m_Width};
            m_Subreports.Add(subreport);
            m_ParentControl.Controls.Add(subreport);

            subreport.Name = "xrSubreport_" + observation;
            subreport.SendToBack();
            return subreport;
        }

        private void CreateSpeciesLabel(int previousTop, string speciesName)
        {
            var label = new XRLabel();
            label.Text = speciesName;
            label.Top = previousTop;
            label.Width = m_Width;
            label.BackColor = Color.Gainsboro;
            label.Borders = BorderSide.All;
            label.Font = new Font(WinClientContext.CurrentFont.Name, 10, FontStyle.Bold);
            label.TextAlignment = TextAlignment.MiddleLeft;

            label.Text = string.Format("   {0}:        {1}", EidssMessages.Get(@"Species"), speciesName);
            m_ParentControl.Controls.Add(label);
        }
    }
}