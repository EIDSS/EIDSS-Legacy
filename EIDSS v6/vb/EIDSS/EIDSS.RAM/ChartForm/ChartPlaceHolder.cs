using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using bv.common.Core;
using eidss.model.Resources;

namespace eidss.avr.ChartForm
{
    public partial class ChartPlaceHolder : UserControl
    {
        public ChartPlaceHolder()
        {
            InitializeComponent();
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

        public AxisX AxisX
        {
            get
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                return xyDiagram != null
                           ? xyDiagram.AxisX
                           : null;
            }
        }

        public AxisY AxisY
        {
            get
            {
                var xyDiagram = ChartControl.Diagram as XYDiagram;
                return xyDiagram != null
                           ? xyDiagram.AxisY
                           : null;
            }
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

        private void ChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            ChartControl_CustomDrawSeriesPoint(sender, m_ChartControl.Diagram, e);
        }

        public static void ChartControl_CustomDrawSeriesPoint(object sender, Diagram diagram, CustomDrawSeriesPointEventArgs e)
        {
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