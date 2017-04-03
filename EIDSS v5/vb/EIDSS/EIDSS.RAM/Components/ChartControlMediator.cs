using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using bv.common;
using bv.common.Core;
using eidss.model.Core.CultureInfo;
using eidss.model.Resources;

namespace EIDSS.RAM.Components
{
    public class ChartControlMediator
    {
        private readonly ChartControl m_ChartControl;
        private readonly Control m_Parent;

        public ChartControlMediator(Control parent)
        {
            m_Parent = parent;
            // workaround
            // Note: it needed to prevent fail when chart control first time initialized in english
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName != Localizer.lngEn)
            {
                using (new CultureInfoTransaction(CultureInfo.GetCultureInfo("en-US")))
                {
                    using (new ChartControl())
                    {
                    }
                }
            }
            m_ChartControl = new ChartControl();
            InitializeChart();
        }

        public ChartControl ChartControl
        {
            get { return m_ChartControl; }
        }

        public string ChartName
        {
            get { return m_ChartControl.Titles[0].Text; }
            set
            {
                if (Utils.IsEmpty(value))
                {
                    value = EidssMessages.Get(@"msgNoReportHeader", "[Untitled]");
                }
                m_ChartControl.Titles[0].Text = value;
            }
        }

        public string ChartFilter
        {
            get { return m_ChartControl.Titles[1].Text; }
            set { m_ChartControl.Titles[1].Text = value; }
        }

        public string AxisXTitle
        {
            get
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                return xyDiagram != null
                           ? xyDiagram.AxisX.Title.Text
                           : string.Empty;
            }
            set
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                if (xyDiagram != null)
                {
                    xyDiagram.AxisX.Title.Text = value;
                    xyDiagram.AxisX.Visible = true;
                }
            }
        }

        public string AxisYTitle
        {
            get
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                return xyDiagram != null
                           ? xyDiagram.AxisY.Title.Text
                           : string.Empty;
            }
            set
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                if (xyDiagram != null)
                {
                    xyDiagram.AxisY.Title.Text = value;
                    xyDiagram.AxisY.Visible = true;
                }
            }
        }

        private void InitializeChart()
        {
            Trace.WriteLine(Trace.Kind.Info, @"ChartControlMediator.InitializeChart(): Init Chart...");

            m_Parent.SuspendLayout();
            var areaSeriesView1 = new AreaSeriesView();

            ((ISupportInitialize) (areaSeriesView1)).BeginInit();
            ((ISupportInitialize) (m_ChartControl)).BeginInit();

            m_ChartControl.Location = new Point(12, 12);
            m_ChartControl.Name = @"m_ChartControl";
            m_ChartControl.SeriesSerializable = new Series[0];
            m_ChartControl.SeriesTemplate.View = areaSeriesView1;
            m_ChartControl.Size = new Size(644, 526);
            m_ChartControl.TabIndex = 0;
            m_ChartControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            m_ChartControl.Dock = DockStyle.Fill;

            m_ChartControl.SeriesDataMember = @"Series";
            m_ChartControl.SeriesTemplate.ArgumentDataMember = @"Arguments";
            m_ChartControl.SeriesTemplate.ValueDataMembers.AddRange(new[] {@"Values"});

            var diagram = new XYDiagram();
            diagram.AxisX.Alignment = AxisAlignment.Zero;
            diagram.AxisX.Label.Angle = 20;
            diagram.AxisX.Label.Antialiasing = true;

            diagram.AxisX.Range.SideMarginsEnabled = false;
            diagram.AxisY.Range.SideMarginsEnabled = true;
            diagram.AxisY.Label.Antialiasing = true;
            m_ChartControl.Diagram = diagram;

            m_ChartControl.Titles.Clear();
            m_ChartControl.Titles.Add(new ChartTitle());
            m_ChartControl.Titles.Add(new ChartTitle());

            m_Parent.Controls.Add(m_ChartControl);
            ((ISupportInitialize) (m_ChartControl)).EndInit();
            ((ISupportInitialize) (areaSeriesView1)).EndInit();
            m_ChartControl.CustomDrawAxisLabel += ChartControl_CustomDrawAxisLabel;
            m_ChartControl.CustomDrawSeries += ChartControl_CustomDrawSeries;
            m_ChartControl.CustomDrawSeriesPoint += ChartControl_CustomDrawSeriesPoint;

            m_Parent.ResumeLayout(false);
        }

        private void ChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            ChartControl_CustomDrawSeriesPoint(sender, m_ChartControl.Diagram, e);
        }

        public static void ChartControl_CustomDrawSeriesPoint(object sender, Diagram diagram, CustomDrawSeriesPointEventArgs e)
        {
            /*
             * TODO: [Ivan] remove after testing
            if ((diagram is SimpleDiagram) || (diagram is SimpleDiagram3D) )
            {
                e.LabelText = string.Format(@"{0} - {1}", GetTruncatedArgument(e.LabelText), GetTruncatedArgument(e.SeriesPoint.Argument));
            }
            else if (diagram is XYDiagram)
            {
                 e.LabelText =  GetTruncatedArgument(e.LabelText);
            }
            */
            e.LabelText = GetTruncatedArgument(e.LabelText);
        }

        public static void ChartControl_CustomDrawSeries(object sender, CustomDrawSeriesEventArgs e)
        {
            e.LegendText = GetTruncatedArgument(e.LegendText);
        }

        public static void ChartControl_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            e.Item.Text = GetTruncatedArgument(e.Item.Text);
        }

        private static string GetTruncatedArgument(string argument)
        {
            string[] complexArgument = argument.Split(new[] {@" | "},
                                                      StringSplitOptions.None);
            return complexArgument.Length < 2
                       ? argument
                       : complexArgument[complexArgument.Length - 1];
        }
    }
}