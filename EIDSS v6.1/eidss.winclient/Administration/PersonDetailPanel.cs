using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using eidss.winclient.Security;

namespace eidss.winclient.Administration
{
    public partial class PersonDetailPanel : BaseDetailPanel_Person
    {
        /// <summary>
        /// 
        /// </summary>
        public PersonDetailPanel()
        {
            InitializeComponent();

            PersonLoginInfoPanel = new LoginInfoGroupPanel();
            var layout = (LayoutGroup)PersonLoginInfoPanel.GetLayout();
            tpLogin.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.SearchPanelVisible = false;
            if (!EidssUserContext.User.HasPermission(
                    PermissionHelper.SelectPermission(EIDSSPermissionObject.User)))
                tcMain.TabPages.Remove(tpLogin);
            PersonGroupInfoPanel = new PersonGroupInfoPanel();
            layout = (LayoutGroup)PersonGroupInfoPanel.GetLayout();
            tpGroups.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.SearchPanelVisible = false;
            if (!EidssUserContext.User.HasPermission(
                    PermissionHelper.SelectPermission(EIDSSPermissionObject.UserGroup)))
                tcMain.TabPages.Remove(tpGroups);

            ObjectAccessListPanel = pSystemFunctionsDown.AddObjectAccessListPanel();
            layout = (LayoutGroup)ObjectAccessListPanel.GetLayout();
            layout.SearchPanelVisible = false;
            if (!EidssUserContext.User.HasPermission(
                PermissionHelper.SelectPermission(EIDSSPermissionObject.SystemFunction)))
                tcMain.TabPages.Remove(tbSystemFunctions);
        }

        private LoginInfoGroupPanel PersonLoginInfoPanel { get; set; }
        private PersonGroupInfoPanel PersonGroupInfoPanel { get; set; }
        private ObjectAccessListPanel ObjectAccessListPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<object> GetParamsAction(IObject o)
        {
            var list = new List<object>();
            var person = BusinessObject as Person;
            if (person != null)
            {
                list.Add(person.idfPerson);
                //list.Add(person.Site);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var person = BusinessObject as Person;
            if (person == null) return;

            LookupBinder.BindTextEdit(txtFirstName, person, "strFirstName");
            LookupBinder.BindTextEdit(txtMiddleName, person, "strSecondName");
            LookupBinder.BindTextEdit(txtLastName, person, "strFamilyName");

            HACode haCode = HACode.All;
            if (StartUpParameters != null && StartUpParameters.ContainsKey("HACode") && !Utils.IsEmpty(StartUpParameters["HACode"]))
            {
                haCode = (HACode)StartUpParameters["HACode"];
                StartUpParameters.Remove("HACode");
            }

            List<OrganizationLookup> list = person.InstitutionLookup.Where(i => !i.intHACode.HasValue || (i.intHACode.Value & (int)haCode) != 0).ToList();
            LookupBinder.BindOrganizationLookup(cbOrganization, person, "Institution", list, haCode, false);
            cbOrganization.EditValueChanging += OrganizationChanging;
            cbOrganization.EditValueChanged += OrganizationChanged;
            if (StartUpParameters != null && StartUpParameters.ContainsKey("OrganizationID") && !Utils.IsEmpty(StartUpParameters["OrganizationID"]))
            {
                person.Institution = list.FirstOrDefault(c => c.idfInstitution == (long)StartUpParameters["OrganizationID"]);
                StartUpParameters.Remove("OrganizationID");
            }
            if (StartUpParameters != null && StartUpParameters.ContainsKey("NotDeleteAction"))
            {
                person.HideDeleteAction = true;
                StartUpParameters.Remove("NotDeleteAction");
            }

            LookupBinder.BindDepartmentLookup(cbDepartment, person, person.DepartmentLookup, "Department");
            LookupBinder.BindBaseLookup(cbRank, person, "StaffPosition", person.StaffPositionLookup);
            LookupBinder.BindTextEdit(txtTelephone, person, "strContactPhone");
            person.PropertyChanged -= OnPropertyChanged;
            person.PropertyChanged += OnPropertyChanged;
            OrganizationChanged(cbOrganization, EventArgs.Empty);
        }

        private void OrganizationChanged(object sender, EventArgs e)
        {
            var person = BusinessObject as Person;
            if (person != null)
            {
                cbOrganization.DataBindings[0].WriteValue();
                tpLogin.PageVisible = person.idfsOrganizationSite.HasValue &&
                                      EidssUserContext.User.HasPermission(
                                          PermissionHelper.SelectPermission(EIDSSPermissionObject.User));
                tpGroups.PageVisible = person.idfsOrganizationSite.HasValue &&
                                       EidssUserContext.User.HasPermission(
                                           PermissionHelper.SelectPermission(EIDSSPermissionObject.UserGroup));
                tbSystemFunctions.PageVisible = person.idfsOrganizationSite.HasValue &&
                                                EidssUserContext.User.HasPermission(
                                                    PermissionHelper.SelectPermission(
                                                        EIDSSPermissionObject.SystemFunction));
            }
        }
        private void OrganizationChanging(object sender, ChangingEventArgs e)
        {
            var person = BusinessObject as Person;
            if (e.NewValue != null && person != null)
            {
                var org = person.InstitutionLookup.FirstOrDefault(i => i == e.NewValue);
                if ((org == null || org.idfsSite == null) && person.LoginInfoList.Count(l => !l.IsMarkedToDelete) > 0)
                {
                    e.Cancel = true;
                    ErrorForm.ShowWarning("msgCantChangeEmployeeOrganization");
                }
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Site")
                ObjectAccessListPanel.ExpandAll();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            var person = BusinessObject as Person;
            if (person == null) return;

            PersonGroupInfoPanel.idfEmployee = person.idfPerson;
            PersonGroupInfoPanel.SetDataSource(person, person.GroupInfoList);

            PersonLoginInfoPanel.idfPerson = person.idfPerson;
            PersonLoginInfoPanel.SetDataSource(person, person.LoginInfoList);

            ObjectAccessListPanel.SetDataSource(person, person.ObjectAccessListFiltered); //userGroupDetail.ObjectAccessList;
            ObjectAccessListPanel.ExpandAll();
        }
    }
}
