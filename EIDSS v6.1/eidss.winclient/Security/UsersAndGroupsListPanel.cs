using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.winclient.BasePanel;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Security
{
    public partial class UsersAndGroupsListPanel : BaseListPanel_UsersAndGroupsListItem
    {
        public UsersAndGroupsListPanel()
        {
            InitializeComponent();
        }
        public override string GetDetailFormName(IObject o)
        {
            return null;
        }
    }

}
