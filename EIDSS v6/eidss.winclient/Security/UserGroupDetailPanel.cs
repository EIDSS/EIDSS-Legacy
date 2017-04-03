using System;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using System.Linq;

namespace eidss.winclient.Security
{
    public partial class UserGroupDetailPanel : BaseDetailPanel_UserGroupDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public UserGroupDetailPanel()
        {
            InitializeComponent();

            UserGroupMemberListPanel = tpUsersGroups.AddUserGroupMemberListPanel();
            var layoutGroupUserGroupMember = (LayoutGroup) UserGroupMemberListPanel.GetLayout();
            layoutGroupUserGroupMember.SearchPanelVisible = false;

            ObjectAccessListPanel = pSystemFunctionsDown.AddObjectAccessListPanel();
            var layoutGroupObjectAccessList = (LayoutGroup) ObjectAccessListPanel.GetLayout();
            layoutGroupObjectAccessList.SearchPanelVisible = false;
            if (!EidssUserContext.User.HasPermission(
                PermissionHelper.SelectPermission(EIDSSPermissionObject.SystemFunction)))
                tcMain.TabPages.Remove(tpSystemFunctions);
            bApplyToAllSites.Enabled =
                EidssUserContext.User.HasPermission(
                    PermissionHelper.SelectPermission(EIDSSPermissionObject.ManageRightsRemotely));
        }

        private UserGroupMemberListPanel UserGroupMemberListPanel { get; set; }
        private ObjectAccessListPanel ObjectAccessListPanel { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            base.DefineBinding();

            var userGroupDetail = BusinessObject as model.Schema.UserGroupDetail;
            if (userGroupDetail == null) return;

            LookupBinder.BindTextEdit(txtName, userGroupDetail, "strGroupName");
            LookupBinder.BindTextEdit(txtNameNational, userGroupDetail, "strNationalGroupName");
            LookupBinder.BindTextEdit(txtDescription, userGroupDetail, "strDescription");
            LookupBinder.BindSiteLookup(leSites, userGroupDetail, "Site", userGroupDetail.SiteLookup, false);
            userGroupDetail.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Site")
            {
                ObjectAccessListPanel.ExpandAll();

                var userGroupDetail = BusinessObject as model.Schema.UserGroupDetail;
                if (userGroupDetail == null) return;
                ObjectAccessListPanel.SetDataSource(userGroupDetail, userGroupDetail.ObjectAccessListFiltered); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            var userGroupDetail = BusinessObject as model.Schema.UserGroupDetail;
            if (userGroupDetail == null) return;

            UserGroupMemberListPanel.UserGroupMemberList = userGroupDetail.UserGroupMemberList;
            UserGroupMemberListPanel.idfEmployeeGroup = userGroupDetail.idfEmployeeGroup;
            UserGroupMemberListPanel.SetDataSource(userGroupDetail, userGroupDetail.UserGroupMemberList);

            ObjectAccessListPanel.SetDataSource(userGroupDetail, userGroupDetail.ObjectAccessListFiltered); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBApplyToAllSitesClick(object sender, EventArgs e)
        {
            var userGroupDetail = BusinessObject as model.Schema.UserGroupDetail;
            if (userGroupDetail == null) return;
            if (!WinUtils.ConfirmMessage(EidssMessages.Get("ObjectAccess_ApplyForAllSites"), String.Empty)) return;
            foreach (var oa in userGroupDetail.ObjectAccessListFiltered)
            {
                var idOperation = oa.idfsObjectOperation;
                var idObjectType = oa.idfsObjectType;
                var idObjectID = oa.idfsObjectID;
                var idSite = oa.idfsSite;
                var allow = oa.isAllow;
                var deny = oa.isDeny;
                var oaChange = userGroupDetail.ObjectAccessList.Where(c =>
                                                                      (c.idfsObjectOperation == idOperation)
                                                                      && (c.idfsObjectType == idObjectType)
                                                                      && (c.idfsObjectID == idObjectID)
                                                                      && (c.idfsSite != idSite)
                    ).ToList();
                foreach (var objectAccess in oaChange)
                {
                    objectAccess.isAllow = allow;
                    objectAccess.isDeny = deny;
                }
            }
            MessageForm.Show(EidssMessages.Get("ObjectAccess_Complete"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
