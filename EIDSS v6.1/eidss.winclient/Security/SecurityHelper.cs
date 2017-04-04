using System.Windows.Forms;
using bv.winclient.Layout;
using System.Drawing;
using eidss.model.Resources;
using System;
using bv.common.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;

namespace eidss.winclient.Security
{
    public static class SecurityHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static UserGroupMemberListPanel AddUserGroupMemberListPanel(this Control ownerControl)
        {
            var panel = new UserGroupMemberListPanel();
            var layout = (Control)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static ObjectAccessListPanel AddObjectAccessListPanel(this Control ownerControl)
        {
            var panel = new ObjectAccessListPanel();
            var layout = (Control)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            //var objectAccess = panel.BusinessObject as ObjectAccess;
            //AddSiteFilter(panel.GetLayout(), objectAccess, panel.OnSitesEditValueChanged);

            return panel;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="objectAccess"></param>
        /// <param name="eventHandler"></param>
        public static void AddSiteFilter(ILayout layout, ObjectAccess objectAccess, EventHandler eventHandler)
        {
            var lbSites = new DevExpress.XtraEditors.LabelControl
            {
                Location = new Point(11, 5),
                Name = "lbSites",
                Size = new Size(60, 19),
                TabIndex = 0,
                Text = EidssFields.Get("lbSites", String.Empty)
            };
            layout.AddCustomControlToActionPanel(lbSites, ActionsPanelType.Group);

            var leSites = new DevExpress.XtraEditors.LookUpEdit
                              {
                                  Location = new Point(100, 5),
                                  Name = "leSites",
                                  Size = new Size(80, 19),
                                  TabIndex = 1,
                              };
            leSites.Properties.NullText = String.Empty;
            layout.AddCustomControlToActionPanel(leSites, ActionsPanelType.Group);
            
            //leSites.Properties.ValueMember = "idfSite";
            //leSites.Properties.ValueMember = "strSiteName";
            LookupBinder.BindSiteLookup(leSites, objectAccess, "Site", objectAccess.SiteLookup, false);
            leSites.EditValueChanged += eventHandler;
        }
        */
    }
}
