using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLToolkit.DataAccess;
using BLToolkit.Reflection;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;
using eidss.model.Core;

namespace eidss.winclient.Vet
{
    public partial class VetCaseListPanel : BaseListPanel_VetCaseListItem
    {
        public VetCaseListPanel()
        {
            InitializeComponent();
            SearchPanelLabelWidth = 194;
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((VetCaseListItem)FocusedItem);
                if (item.idfsCaseType == (long)CaseTypeEnum.Avian)
                {
                    EidssSiteContext.ReportFactory.VetAvianInvestigation(item.idfCase, item.idfsDiagnosis ?? 0);
                }
                else
                {
                    EidssSiteContext.ReportFactory.VetLivestockInvestigation(item.idfCase, item.idfsDiagnosis ?? 0);
                }
            }
        }

        public override string GetDetailFormName(IObject o)
        {
            string name = ((VetCaseListItem) o).idfsCaseType == (long) CaseTypeEnum.Avian
                              ? "VetCaseAvianDetail"
                              : "VetCaseLiveStockDetail";
            return name;

            
        }

        public override List<object> GetParamsAction()
        {
            return FocusedItem == null 
                ? null 
                : new List<object> { FocusedItem.Key, FocusedItem };
        }

        public static void Register(Control parentControl)
        {
            RegisterItem("MenuVetCase", 300, false);
            RegisterItem("ToolbarFindVetCase", 190, true);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar)
        {
            //TODO вставить правильные иконки
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.SearchVetCase,
                           (int)MenuIcons.SearchVetCase)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase),
                ShowInMenu = !showInToolbar
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VetCaseListPanel), BaseFormManager.MainForm,
                                      VetCaseListItem.CreateInstance());
            
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "CreateLivestock", CreateLivestock);
            SetActionFunction(actions, "CreateAvian", CreateAvian);
        }


        private static ActResult CreateLivestock(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return Create(parameters, CaseTypeEnum.Livestock);
        }

        private static ActResult CreateAvian(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return Create(parameters, CaseTypeEnum.Avian);
        }

        private static bool Create(List<object> parameters, CaseTypeEnum caseType)
        {
            if (!(parameters[2] is IBaseListPanel))
            {
                throw new TypeMismatchException("listPanel", typeof (IBaseListPanel));
            }

            var listPanel = ((IBaseListPanel) parameters[2]);
            object key = null;
            var vetCase = (VetCaseListItem) TypeAccessor.CreateInstance(typeof (VetCaseListItem));
            vetCase.idfsCaseType = (long) caseType;
           
            listPanel.Edit(key, new List<object> {key, vetCase, listPanel}, ActionTypes.Create, false);

            return true;
        }
        private VetCaseListItem m_VetCaseListItem;

        protected override void HidePersonalData(List<VetCaseListItem> list)
        {
            bool hideAddress =
                    EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details);
            bool hideSettlement =
                    EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement);
            if (hideSettlement || hideAddress)
            {
                if (m_VetCaseListItem == null )
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {

                        ////object creation
                        IObjectCreator meta = ObjectAccessor.CreatorInterface(typeof(VetCaseListItem));

                        m_VetCaseListItem = meta.CreateNew(manager, null, null) as VetCaseListItem;

                    }
                }

                foreach (var item in list)
                {
                    item.strOwnerFirstName = "*";
                    item.strOwnerLastName = "*";
                    item.strOwnerMiddleName = "*";

                    m_VetCaseListItem.idfsCountry = item.idfsCountry;
                    m_VetCaseListItem.idfsRegion = item.idfsRegion;
                    m_VetCaseListItem.idfsRayon = item.idfsRayon;
                    if (hideSettlement)
                        item.AddressName = Utils.Join(",",
                                                          new[]
                                                              {
                                                                  "*",
                                                                  m_VetCaseListItem.RayonLookup.Find(
                                                                      c => c.idfsRayon == item.idfsRayon).strRayonName,
                                                                  m_VetCaseListItem.RegionLookup.Find(
                                                                      c => c.idfsRegion == item.idfsRegion).strRegionName
                                                                   //,
                                                                  //m_VetCaseListItem.CountryLookup.Find(
                                                                  //    c => c.idfsCountry == item.idfsCountry).
                                                                  //    strCountryName
                                                              });

                    else
                        item.AddressName = Utils.Join(",",
                                                          new[]
                                                              {
                                                                  "*",
                                                                  m_VetCaseListItem.SettlementLookup.Find(
                                                                      c => c.idfsSettlement == item.idfsSettlement).
                                                                      strSettlementName,
                                                                  m_VetCaseListItem.RayonLookup.Find(
                                                                      c => c.idfsRayon == item.idfsRayon).strRayonName,
                                                                  m_VetCaseListItem.RegionLookup.Find(
                                                                      c => c.idfsRegion == item.idfsRegion).strRegionName//,
                                                                  //m_VetCaseListItem.CountryLookup.Find(
                                                                  //    c => c.idfsCountry == item.idfsCountry).
                                                                  //    strCountryName
                                                              });

                }
            }

        }
        /*perm!!
        public override void CheckActionPermission(ActionMetaItem action, ref bool showAction)
        {
            switch (action.Name)
            {
                case "CreateAvian":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.VetCase)) && !ReadOnly;
                    return;

                case "CreateLivestock":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.VetCase)) && !ReadOnly;
                    return;
                case "Delete":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSSPermissionObject.VetCase)) && !ReadOnly;
                    return;

            }

        }*/

       
    }
}
