using System;
using System.Collections.Generic;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.winclient.BasePanel;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;
using System.Linq;

namespace eidss.winclient.Security
{
    public partial class UserGroupMemberListPanel : BaseGroupPanel_UserGroupMember
    {
        /// <summary>
        /// 
        /// </summary>
        public UserGroupMemberListPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
        }

        public EditableList<UserGroupMember> UserGroupMemberList { get; set; }

        public long idfEmployeeGroup { get; set; }

        public override string GetDetailFormName(IObject o)
        {
            return null;
        }

        /// <summary>
        /// Выбор юзера или группы для включения его в эту группу
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ActionSelectUserGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var obj = BaseFormManager.ShowForSelection(new UsersAndGroupsListPanel(), this);
            var item = obj as UsersAndGroupsListItem;
            UserGroupMember member = null;
            if ((item != null) && (item.idfEmployee > 0))
            {
                if (UserGroupMemberList.Count(u => u.idfEmployee == item.idfEmployee) == 0)
                {
                    var acc = UserGroupMember.Accessor.Instance(null);
                    member = acc.CreateNewT(manager, bo);
                    member.idfEmployee = item.idfEmployee;
                    member.idfEmployeeGroup = idfEmployeeGroup;
                    member.EmployeeTypeName = item.EmployeeTypeName;
                    member.strName = item.strName;
                    member.OrganizationName = item.OrganizationName;
                    member.strDescription = item.strDescription;
                    UserGroupMemberList.Add(member);
                }
                else
                {
                    MessageForm.Show(EidssMessages.Get("UserGroupMemberList Item already in list"));
                }
            }
            return new ActResult(true, member);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ActionDeleteUserGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var member = bo as UserGroupMember;
            if (member != null) member.MarkToDelete();
            //if (member != null)
            //{
            //    GroupParent.UserGroupMemberList.Where(c => c.ID == member.ID)
            //}
            return new ActResult(true, member);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public override KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetFirstUIFunc(string actionName)
        {
            if (actionName.Equals("AddGroupMember"))
                return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(ActionSelectUserGroup, null);
            if (actionName.Equals("DeleteGroupMember"))
                return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(ActionDeleteUserGroup, null);
            return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(null, null);
        }
    }

}
