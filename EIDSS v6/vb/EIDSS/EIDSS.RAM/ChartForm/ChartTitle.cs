namespace eidss.avr.ChartForm
{
    public class PivotChartTitle
    {
        public PivotChartTitle(string dataTitle, string rowTitle, string columnTitle)
        {
            DataTitle = dataTitle;
            RowTitle = rowTitle;
            ColumnTitle = columnTitle;
        }

        public string DataTitle { get; set; }
        public string RowTitle { get; set; }
        public string ColumnTitle { get; set; }
    }
}