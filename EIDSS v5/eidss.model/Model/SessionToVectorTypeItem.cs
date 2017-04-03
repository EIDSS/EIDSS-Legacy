namespace eidss.model.Schema
{
    public partial class SessionToVectorTypeItem
    {
        public bool Checked
        {
            get { return IsChecked == 1 ? true : false; }
            set { IsChecked = value ? 1 : 0; }
        }
    }
}
