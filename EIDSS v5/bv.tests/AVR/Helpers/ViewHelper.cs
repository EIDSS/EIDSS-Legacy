using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.win;

namespace bv.tests.AVR.Helpers
{
    public class ViewHelper
    {
        internal static LayoutDetail CreateLayoutControls(out QueryInfo queryInfo, out LayoutInfo layoutInfo, out RamForm ramForm)
        {
            ramForm = new RamForm();

            LayoutDetail layoutDetail = null;
            queryInfo = null;
            layoutInfo = null;
            foreach (IRelatedObject child in ramForm.Children)
            {
                if (child is LayoutDetail)
                {
                    layoutDetail = child as LayoutDetail;
                }
                if (child is LayoutInfo)
                {
                    layoutInfo = child as LayoutInfo;
                }
                if (child is QueryInfo)
                {
                    queryInfo = child as QueryInfo;
                }
            }

            Assert.IsNotNull(layoutDetail);
            Assert.IsNotNull(queryInfo);
            Assert.IsNotNull(layoutInfo);
            return layoutDetail;
        }

        internal static PivotForm GetLayoutDetailControls(LayoutDetail layoutDetail)
        {
            PivotForm pivotForm;
            PivotReportForm reportForm;
            MapForm mapForm;
            ChartForm chartForm;
            GetLayoutDetailControls(layoutDetail, out pivotForm, out reportForm, out mapForm, out chartForm);
            return pivotForm;
        }

        internal static void GetLayoutDetailControls
            (LayoutDetail layoutDetail, out PivotForm pivotForm,
             out PivotReportForm reportForm, out MapForm mapForm,
             out ChartForm chartForm)
        {
            pivotForm = null;
            mapForm = null;
            chartForm = null;
            reportForm = null;
            foreach (IRelatedObject child in layoutDetail.Children)
            {
                if (child is PivotForm)
                {
                    pivotForm = child as PivotForm;
                }
                if (child is MapForm)
                {
                    mapForm = child as MapForm;
                }
                if (child is ChartForm)
                {
                    chartForm = child as ChartForm;
                }
                if (child is PivotReportForm)
                {
                    reportForm = child as PivotReportForm;
                }
            }
            Assert.IsNotNull(pivotForm);
            Assert.IsNotNull(mapForm);
            Assert.IsNotNull(chartForm);
            Assert.IsNotNull(reportForm);
        }
    }
}