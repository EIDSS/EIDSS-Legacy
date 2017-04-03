using System.Collections.Generic;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class LoginInfoGroupPanel : BaseGroupPanel_LoginInfo
    {
        public LoginInfoGroupPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
        }

        public long idfPerson { get; set; }

        
    }
}
