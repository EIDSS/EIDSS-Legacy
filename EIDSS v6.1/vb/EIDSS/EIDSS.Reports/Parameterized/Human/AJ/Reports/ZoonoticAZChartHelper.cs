using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public static class ZoonoticAZChartHelper
    {

        internal static IList<int> GetMonthValues(ZoonoticMonthsDataSet.ZoonoticByMonthTableRow row)
        {
            try
            {
                return new List<int>
                    {
                        row.intJan,
                        row.intFeb,
                        row.intMar,
                        row.intApr,
                        row.intMay,
                        row.intJun,
                        row.intJul,
                        row.intAug,
                        row.intSep,
                        row.intOct,
                        row.intNov,
                        row.intDec
                    };
            }
            catch (System.Exception)
            {
                return new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
        }
    }
}