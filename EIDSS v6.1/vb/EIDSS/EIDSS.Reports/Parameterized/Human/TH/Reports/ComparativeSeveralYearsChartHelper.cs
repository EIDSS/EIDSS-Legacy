using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using EIDSS.Reports.Parameterized.Human.TH.DataSets;

namespace EIDSS.Reports.Parameterized.Human.TH.Reports
{
    public static class ComparativeSeveralYearsChartHelper
    {
        internal static Series CreateValueSeriesForYear(string yearColumnName, Color color)
        {
            var series = new Series();
            var bar = new SideBySideBarSeriesView();
            ((ISupportInitialize) (series)).BeginInit();
            ((ISupportInitialize) (bar)).BeginInit();

            series.ArgumentDataMember = "ChartData.Month";
            series.ValueDataMembersSerializable = "ChartData." + yearColumnName;
            series.LabelsVisibility = DefaultBoolean.False;

            bar.Color = Color.FromArgb(100, color);
            bar.FillStyle.FillMode = FillMode.Solid;

            series.View = bar;

            ((ISupportInitialize) (bar)).EndInit();
            ((ISupportInitialize) (series)).EndInit();
            return series;
        }

        internal static Series CreatePercentSeriesForYear(string yearColumnName, Color color)
        {
            var series = new Series();
            var point = new PointSeriesLabel();
            var line = new LineSeriesView();
            ((ISupportInitialize) (series)).BeginInit();
            ((ISupportInitialize) (line)).BeginInit();
            ((ISupportInitialize) (point)).BeginInit();

            series.ArgumentDataMember = "ChartData.Month";
            series.ValueDataMembersSerializable = "ChartData." + yearColumnName;
            series.LabelsVisibility = DefaultBoolean.False;

            point.Border.Visibility = DefaultBoolean.False;
            point.LineVisibility = DefaultBoolean.True;
            series.Label = point;

            line.Color = color;
            line.LineMarkerOptions.BorderVisible = false;
            line.LineMarkerOptions.Color = color;
            line.LineMarkerOptions.FillStyle.FillMode = FillMode.Solid;
            line.LineMarkerOptions.Kind = MarkerKind.Diamond;
            line.AxisYName = "PercentAxis";
            series.View = line;

            ((ISupportInitialize) (point)).EndInit();
            ((ISupportInitialize) (line)).EndInit();
            ((ISupportInitialize) (series)).EndInit();
            return series;
        }

        internal static IList<int> GetMonthValues(ComparativeSeveralYearsTHDataSet.ComparativeTableRow row)
        {
            return new List<int>
            {
                row.intJanuary,
                row.intFebruary,
                row.intMarch,
                row.intApril,
                row.intMay,
                row.intJune,
                row.intJuly,
                row.intAugust,
                row.intSeptember,
                row.intOctober,
                row.intNovember,
                row.intDecember
            };
        }

        internal static IList<double?> GetMonthPercent(ComparativeSeveralYearsTHDataSet.ComparativeTableRow row)
        {
            return new List<double?>
            {
                row.IsdblJanuaryPercentNull() ? (double?) null : row.dblJanuaryPercent,
                row.IsdblFebruaryPercentNull() ? (double?) null : row.dblFebruaryPercent,
                row.IsdblMarchPercentNull() ? (double?) null : row.dblMarchPercent,
                row.IsdblAprilPercentNull() ? (double?) null : row.dblAprilPercent,
                row.IsdblMayPercentNull() ? (double?) null : row.dblMayPercent,
                row.IsdblJunePercentNull() ? (double?) null : row.dblJunePercent,
                row.IsdblJulyPercentNull() ? (double?) null : row.dblJulyPercent,
                row.IsdblAugustPercentNull() ? (double?) null : row.dblAugustPercent,
                row.IsdblSeptemberPercentNull() ? (double?) null : row.dblSeptemberPercent,
                row.IsdblOctoberPercentNull() ? (double?) null : row.dblOctoberPercent,
                row.IsdblNovemberPercentNull() ? (double?) null : row.dblNovemberPercent,
                row.IsdblDecemberPercentNull() ? (double?) null : row.dblDecemberPercent
            };
        }
    }
}