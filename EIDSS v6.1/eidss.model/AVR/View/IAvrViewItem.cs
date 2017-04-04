namespace eidss.model.Avr.View
{
    public interface IAvrViewItem
    {
        long LayoutSearchFieldId { get; set; }
        string LayoutSearchFieldName { get; }
        string DisplayText { get; }
        long ID { get; set; }
        string UniquePath { get; set; }
        BaseBand Owner { get; }
        void SetChanges();
    }
}