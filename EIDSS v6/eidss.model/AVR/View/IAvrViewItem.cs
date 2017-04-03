namespace eidss.model.Avr.View
{
    public interface IAvrViewItem
    {
        long LayoutSearchFieldId { get; }
        string LayoutSearchFieldName { get; }
        string DisplayText { get; }

        string UniquePath { get; set; }
        BaseBand Owner { get; }
    }
}