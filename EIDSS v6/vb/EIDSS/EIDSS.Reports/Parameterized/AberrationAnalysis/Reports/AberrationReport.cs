using System;
using bv.common.Resources;
using bv.model.BLToolkit;
using DevExpress.XtraCharts;
using eidss.model.Reports.AberrationAnalisys;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Reports
{
    public partial class AberrationReport : BaseIntervalReport
    {
        public AberrationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, AberrationModel model)
        {
            base.SetParameters(manager, model);

            cellInputAnalysisMethod.Text = model.AnalysisMethod;
            cellInputThreshold.Text = model.Threshold.ToString();
            cellInputBaseline.Text = model.Baseline + " " + model.TimeIntervalText;
            if (model.Baseline != 1)
            {
                cellInputBaseline.Text += "s";
            }
            cellInputLag.Text = model.Lag + " " + model.TimeIntervalText;
            if (model.Lag != 1)
            {
                cellInputLag.Text += "s";
            }
            cellInputTimeUnit.Text = model.TimeIntervalText;

            switch (model.TimeIntervalId)
            {
                case 1://Day
                    ((XYDiagram) xrChart1.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
                    ((XYDiagram) xrChart2.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText;
                    break;
                case 2://Week
                    ((XYDiagram) xrChart1.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week;
                    ((XYDiagram) xrChart2.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText + " (" + BvMessages.Get("BeginningDate") + ")";
                    break;
                case 3://Month
                    ((XYDiagram) xrChart1.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                    ((XYDiagram) xrChart2.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText + " (" + BvMessages.Get("BeginningDate") + ")";
                    break;
            }

            (xrChart1.Diagram as DevExpress.XtraCharts.XYDiagram).AxisX.Title.Text = model.DateFilterText;
            (xrChart2.Diagram as DevExpress.XtraCharts.XYDiagram).AxisX.Title.Text = model.DateFilterText;
        }

        public void SetLabel()
        {
            int x = 0;
            int y = 0;
            if (m_aberrationDataSet1.AberrationData.Count > 0)
            {
                x = m_aberrationDataSet1.AberrationData[0].sum;
                y = m_aberrationDataSet1.AberrationData[0].fullsum;
            }
            if (x >= 0)
                cellDataSetXofY.Text = String.Format(BvMessages.Get("DataSetrecordsof"), x, y);
            else
                cellDataSetXofY.Text = String.Empty;
        }
    }
}