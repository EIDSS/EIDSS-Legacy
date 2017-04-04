using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Configuration;
using BLToolkit.Reflection;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
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
                var includeMap = BaseSettings.PrintMapInVetReports;
                if (item.idfsCaseType == (long)CaseTypeEnum.Avian)
                {
                    EidssSiteContext.ReportFactory.VetAvianInvestigation(item.idfCase, item.idfsDiagnosis ?? 0, includeMap);
                }
                else
                {
                    EidssSiteContext.ReportFactory.VetLivestockInvestigation(item.idfCase, item.idfsDiagnosis ?? 0, includeMap);
                }
            }
        }

        public override string GetDetailFormName(IObject o)
        {
            string name = ((VetCaseListItem)o).idfsCaseType == (long)CaseTypeEnum.Avian
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
            RegisterItem("MenuVetCase", 105, false, MenuGroup.MenuJournalsCase);
            //Toolbar menu
            RegisterItem("MenuVetCase", 100020, true, MenuGroup.ToolbarJournals);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.SearchVetCase,
                           (int)MenuIcons.SearchVetCase)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase),
                ShowInMenu = !showInToolbar,
                Group = (int)group
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
                throw new TypeMismatchException("listPanel", typeof(IBaseListPanel));
            }
            Dictionary<string, object> startupParams = null;
            if (
                !EidssUserContext.User.HasPermission(
                    PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToFarmData)))
            {
                var farm = BaseFormManager.ShowForSelection(new FarmListPanel(), BaseFormManager.MainForm, null, 1024, 800);
                if (farm == null)
                    return false;
                startupParams = new Dictionary<string, object> { { "RootFarmID", farm.Key } };
            }
            var listPanel = ((IBaseListPanel)parameters[2]);
            var vetCase = (VetCaseListItem)TypeAccessor.CreateInstance(typeof(VetCaseListItem));
            vetCase.idfsCaseType = (long)caseType;

            listPanel.Edit(null, new List<object> { null, vetCase, listPanel, startupParams }, ActionTypes.Create, false);

            return true;
        }
        private VetCaseListItem m_VetCaseListItem;

        protected override void HidePersonalData(List<VetCaseListItem> list)
        {
            bool hideSettlement =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement);
            bool hideName =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details) ||
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement) ||
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates);
            LocationPersonalDataHelper helper = null;
            if (hideSettlement || hideName)
            {
                if (m_VetCaseListItem == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {

                        ////object creation
                        IObjectCreator meta = ObjectAccessor.CreatorInterface(typeof(VetCaseListItem));

                        m_VetCaseListItem = meta.CreateNew(manager, null, null) as VetCaseListItem;
                        helper = new LocationPersonalDataHelper(null,
                                                                m_VetCaseListItem.RegionLookup,
                                                                m_VetCaseListItem.RayonLookup,
                                                                null);

                    }
                }

                foreach (var item in list)
                {
                    try
                    {
                        item.strOwnerFirstName = "*";
                        item.strOwnerLastName = "*";
                        item.strOwnerMiddleName = "*";
                        if (hideSettlement)
                        {
                            m_VetCaseListItem.idfsCountry = item.idfsCountry;
                            m_VetCaseListItem.idfsRegion = item.idfsRegion;
                            m_VetCaseListItem.idfsRayon = item.idfsRayon;
                            item.AddressName = Utils.Join(",",
                                                          new[]
                                                              {
                                                                  "*",
                                                                  helper.GetRayonName(item.idfsRayon),
                                                                  helper.GetRegionName(item.idfsRegion)
                                                              });

                        }

                    }
                    catch (Exception ex)
                    {
                        Dbg.Debug("error in hiding personal in vc list: {0}", ex);
                        Dbg.Debug("list item {0}, {1}", item.idfCase, item.strCaseID);

                    }
                }

            }

        }

    }
}
