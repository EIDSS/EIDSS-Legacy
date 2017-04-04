using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public static class ComparativeTwoYearsChartHelper
    {
        internal static Series CreateLineSeriesForYear(string seriesName, string valueColumnName, Color color, bool isPrimaryAxis = true)
        {
            var series = new Series();
            var point = new PointSeriesLabel();
            var view = new LineSeriesView();
            ((ISupportInitialize) (series)).BeginInit();
            ((ISupportInitialize) (point)).BeginInit();
            ((ISupportInitialize) (view)).BeginInit();

            series.Name = seriesName;
            series.ArgumentDataMember = "ChartData.Month";
            series.ValueDataMembersSerializable = "ChartData." + valueColumnName;

            point.Border.Visibility = DefaultBoolean.False;
            point.LineVisibility = DefaultBoolean.True;
            series.Label = point;

            view.Color = color;
            view.LineMarkerOptions.BorderVisible = false;
            view.LineMarkerOptions.Color = color;
            view.LineMarkerOptions.FillStyle.FillMode = FillMode.Solid;
            view.LineMarkerOptions.Kind = MarkerKind.Diamond;
            if (!isPrimaryAxis)
            {
                view.AxisYName = "Secondary AxisY 1";
            }
            series.View = view;

            ((ISupportInitialize) (point)).EndInit();
            ((ISupportInitialize) (view)).EndInit();
            ((ISupportInitialize) (series)).EndInit();
            return series;
        }

        internal static Series CreateBarSeriesForYear(string seriesName, string valueColumnName, Color color)
        {
            var series = new Series();
            var label = new SideBySideBarSeriesLabel();
            var view = new SideBySideBarSeriesView();

            ((ISupportInitialize) (series)).BeginInit();
            ((ISupportInitialize) (label)).BeginInit();
            ((ISupportInitialize) (view)).BeginInit();

            series.Name = seriesName;
            series.ArgumentDataMember = "ChartData.Month";
            series.ValueDataMembersSerializable = "ChartData." + valueColumnName;

            label.Border.Visibility = DefaultBoolean.False;
            label.LineVisibility = DefaultBoolean.True;
            series.Label = label;

            view.FillStyle.FillMode = FillMode.Solid;
            view.Color = Color.FromArgb(150, color);

            series.View = view;

            ((ISupportInitialize) (label)).EndInit();
            ((ISupportInitialize) (view)).EndInit();
            ((ISupportInitialize) (series)).EndInit();
            return series;
        }

        internal static IList<double> GetMonthValues(ComparativeTroYearsDataSet.ComparativeTwoYearsRow row)
        {
            return new List<double>
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
    }
}