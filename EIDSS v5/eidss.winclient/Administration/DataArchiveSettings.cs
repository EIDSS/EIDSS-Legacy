using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eidss.winclient.Schema;
using eidss.winclient.Core;
using bv.winclient.Core;
using eidss.model.Enums;
using bv.winclient.BasePanel;

namespace eidss.winclient.Security
{
    public partial class DataArchiveSettings : BaseDetailPanel_DataArchiveSettings
    {
        public DataArchiveSettings()
        {
            InitializeComponent();
        }
        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.System,
                           "MenuDataArchiveSettings", 906, false, (int)MenuIconsSmall.DataArchiveSettings,
                           -1)
            {
                ShowInMenu = true,
            };
        }
        private static void ShowMe()
        {
            object id=0;
            BaseFormManager.ShowModal_ReadOnly(new DataArchiveSettings(), BaseFormManager.MainForm, ref id,null,null); 
        }

        public override void DefineBinding()
        {
            LookupBinder.BindTextEdit(txtSchedule, BusinessObject, "strSchedule");
            LookupBinder.BindTextEdit(txtInterval, BusinessObject, "strDataRelevanceInterval");
        }
    }
}
