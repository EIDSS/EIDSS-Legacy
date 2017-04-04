using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;
using eidss.winclient.Security;

namespace eidss.winclient.Administration
{
    public partial class PersonGroupInfoPanel : BaseGroupPanel_PersonGroupInfo
    {
        public PersonGroupInfoPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
        }

        public long idfEmployee { get; set; }

        /// <summary>
        /// Выбор юзера или группы для включения его в эту группу
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ActionSelectUserGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var form = new UserGroupListPanel { SearchPanelVisible = false };
            //var filter = new FilterParams();
            //filter.Add("idfsEmployeeType", "=", "10023001");
            //form.StaticFilter = filter; 
            var obj = BaseFormManager.ShowForSelection(form, this);
            var item = obj as UserGroupListItem;
            PersonGroupInfo member = null;
            if ((item != null) && item.idfEmployeeGroup>0)
            {
                if (DataSource.Count(u => u.idfEmployeeGroup == item.idfEmployeeGroup) == 0)
                {
                    var acc = PersonGroupInfo.Accessor.Instance(null);
                    member = acc.CreateNewT(manager, bo);
                    member.idfEmployee = idfEmployee;
                    member.idfEmployeeGroup = item.idfEmployeeGroup;
                    member.strName = item.strName;
                    member.strDescription = item.strDescription;
                    DataSource.Add(member);
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
            var member = bo as PersonGroupInfo;
            if (member != null) member.MarkToDelete();
            return new ActResult(true, member);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public override KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetFirstUIFunc(string actionName)
        {
            if (actionName.Equals("AddGroupInfo"))
                return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(ActionSelectUserGroup, null);
            if (actionName.Equals("DeleteGroupInfo"))
                return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(ActionDeleteUserGroup, null);
            return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(null, null);
        }
    }
}
