using bv.common.db;
using eidss.avr.ChartForm;
using eidss.avr.LayoutForm;
using eidss.avr.MainForm;
using eidss.avr.MapForm;
using eidss.avr.PivotForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.Helpers
{
    public class ViewHelper
    {
        internal static LayoutDetailPanel CreateLayoutControls(out AvrMainForm avrMainForm)
        {
            avrMainForm = new AvrMainForm();

            LayoutDetailPanel layoutDetail = null;
            foreach (IRelatedObject child in avrMainForm.Children)
            {
                if (child is LayoutDetailPanel)
                {
                    layoutDetail = child as LayoutDetailPanel;
                }
            }

            Assert.IsNull(layoutDetail);

            avrMainForm.InitLayoutDetail(true);
            foreach (IRelatedObject child in avrMainForm.Children)
            {
                if (child is LayoutDetailPanel)
                {
                    layoutDetail = child as LayoutDetailPanel;
                }
            }
            Assert.IsNotNull(layoutDetail);
            return layoutDetail;
        }

        internal static PivotDetailPanel GetLayoutDetailControls(LayoutDetailPanel layoutDetail)
        {
            PivotDetailPanel pivotForm;

            MapDetailPanel mapForm;
            ChartDetailPanel chartForm;
            GetLayoutDetailControls(layoutDetail, out pivotForm, out mapForm, out chartForm);
            return pivotForm;
        }

        internal static void GetLayoutDetailControls
            (LayoutDetailPanel layoutDetail, out PivotDetailPanel pivotForm,
                out MapDetailPanel mapForm, out ChartDetailPanel chartForm)
        {
            pivotForm = null;
            mapForm = null;
            chartForm = null;

            foreach (IRelatedObject child in layoutDetail.Children)
            {
                if (child is PivotDetailPanel)
                {
                    pivotForm = child as PivotDetailPanel;
                }
                if (child is MapDetailPanel)
                {
                    mapForm = child as MapDetailPanel;
                }
                if (child is ChartDetailPanel)
                {
                    chartForm = child as ChartDetailPanel;
                }
            }
            Assert.IsNotNull(pivotForm);
            Assert.IsNotNull(mapForm);
            Assert.IsNotNull(chartForm);
        }
    }
}