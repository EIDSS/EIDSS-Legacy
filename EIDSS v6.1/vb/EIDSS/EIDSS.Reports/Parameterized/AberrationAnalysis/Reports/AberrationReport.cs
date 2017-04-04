using System;
using EIDSS.Reports.Factory;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.winclient.Core;
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

        public void SetParameters(AberrationModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            cellInputAnalysisMethod.Text = model.AnalysisMethod;
            cellInputThreshold.Text = model.Threshold.ToString();
            cellInputBaseline.Text = model.Baseline + " " + model.TimeIntervalText;
            cellInputLag.Text = model.Lag + " " + model.TimeIntervalText;
            cellInputTimeUnit.Text = model.TimeIntervalText;

            AxisX firstChartAxisX = ((XYDiagram) xrChart1.Diagram).AxisX;
            DateTimeScaleOptions firstChartOptions = firstChartAxisX.DateTimeScaleOptions;
            firstChartOptions.ScaleMode = ScaleMode.Manual;
            int diff =  model.EndDate.Subtract(model.StartDate).Days;
            if (diff > 1100)
            {
                firstChartOptions.MeasureUnit = DateTimeMeasureUnit.Year;
                firstChartOptions.GridAlignment = DateTimeGridAlignment.Year;
            }
            else if (diff > 150)
            {
                firstChartOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                firstChartOptions.GridAlignment = DateTimeGridAlignment.Month;
            }
            else
            {
                firstChartOptions.GridAlignment = DateTimeGridAlignment.Week;
                if (diff > 30 || model.TimeIntervalId > 1)
                    firstChartOptions.MeasureUnit = DateTimeMeasureUnit.Week;
                else
                    firstChartOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            }


            AxisX secondChartAxisX = ((XYDiagram) xrChart2.Diagram).AxisX;
            DateTimeScaleOptions secondChartOptions = secondChartAxisX.DateTimeScaleOptions;
            switch (model.TimeIntervalId)
            {
                case 1: //Day
                    secondChartOptions.MeasureUnit = DateTimeMeasureUnit.Day;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText;
                    break;
                case 2: //Week
                    secondChartOptions.MeasureUnit = DateTimeMeasureUnit.Week;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText + " (" + BvMessages.Get("BeginningDate") + ")";
                    break;
                case 3: //Month
                    secondChartOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                    cellTableCaptionTimeUnit.Text = model.TimeIntervalText + " (" + BvMessages.Get("BeginningDate") + ")";
                    break;
            }

            firstChartAxisX.Title.Text = model.DateFilterText;
            secondChartAxisX.Title.Text = model.DateFilterText;

            ReportRtlHelper.SetRTL(this);
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
            cellDataSetXofY.Text = x >= 0 ? String.Format(BvMessages.Get("DataSetrecordsof"), x, y) : String.Empty;
            //AxisX firstChartAxisX = ((XYDiagram)xrChart1.Diagram).AxisX;
            //firstChartAxisX.WholeRange.SetMinMaxValues(m_aberrationDataSet1.AberrationData[0].date, m_aberrationDataSet1.AberrationData[m_aberrationDataSet1.AberrationData.Count-1].date);
        }
    }
}