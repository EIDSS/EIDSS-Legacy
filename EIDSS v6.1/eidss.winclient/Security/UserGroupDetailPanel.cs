using System.ComponentModel;
using bv.common.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.winclient.Core;
using eidss.winclient.Schema;

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
            var layoutGroupUserGroupMember = (LayoutGroup)UserGroupMemberListPanel.GetLayout();
            layoutGroupUserGroupMember.SearchPanelVisible = false;

            ObjectAccessListPanel = pSystemFunctionsDown.AddObjectAccessListPanel();
            var layoutGroupObjectAccessList = (LayoutGroup)ObjectAccessListPanel.GetLayout();
            layoutGroupObjectAccessList.SearchPanelVisible = false;
            if (!EidssUserContext.User.HasPermission(
                PermissionHelper.SelectPermission(EIDSSPermissionObject.SystemFunction)))
                tcMain.TabPages.Remove(tpSystemFunctions);
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
    }
}
