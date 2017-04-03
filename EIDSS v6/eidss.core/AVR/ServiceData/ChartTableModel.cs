using System.Data;
using bv.common.Core;
using eidss.model.Avr.Chart;

namespace eidss.model.AVR.ServiceData
{
    public class ChartTableModel
    {
        public ChartTableModel
            (long viewId, string lang, DataTable table, byte[] chartSettings, DBChartType? chartType, int width, int height)
        {
            Utils.CheckNotNull(table, "table");

            ViewId = viewId;
            Lang = lang;
            ChartSettings = chartSettings;
            ChartType = chartType;
            Width = width;
            Height = height;

            Table = table;
        }

        public long ViewId { get; set; }

        public string Lang { get; set; }

        public byte[] ChartSettings { get; set; }

        public DataTable Table { get; set; }

        public DBChartType? ChartType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}