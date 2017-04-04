using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;

namespace eidss.avr.service.VirtualLayout
{
    public partial class VirtualPivotPlaceHolder : UserControl, IPostable
    {
        public VirtualPivotPlaceHolder()
        {
            InitializeComponent();
        }

        public bool HasChanges()
        {
            return false;
        }

        public bool Post(PostType postType = PostType.FinalPosting)
        {
            return true;
        }
    }
}