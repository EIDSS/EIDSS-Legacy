using System;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
using eidss.model.Schema;
using eidss.winclient.Schema;
using bv.common.Enums;
using bv.model.BLToolkit;
using System.Collections.Generic;

namespace eidss.winclient.Human
{
    public partial class HumanCaseListPanel : BaseListPanel_HumanCaseListItem
    {
        public HumanCaseListPanel()
        {
            InitializeComponent();
            SearchPanelLabelWidth = 194;
        }

        public static void Register(Control parentControl)
        {
            RegisterItem("MenuFindHumanCase", 100, false, true, MenuGroup.MenuJournalsCase);
            //Toolbar menu
            RegisterItem("MenuFindHumanCase", 100000, true, false, MenuGroup.ToolbarJournals);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.SearchHumanCase,
                           (int)MenuIcons.SearchHumanCase)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase),
                    ShowInMenu = !showInToolbar,
                    Group = (int)group

                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(HumanCaseListPanel), BaseFormManager.MainForm,
                                       HumanCaseListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "HumanCaseDetail";
        }

        public override IApplicationForm Edit
            (
            object key
            , List<object> parameters
            , ActionTypes actionType
            , bool readOnly
            )
        {
            IObject bo = null;
            if ((parameters != null) && (parameters.Count > 1) && (parameters[1] is IObject))
            {
                bo = (IObject)parameters[1];
            }
            var detailPanelName = GetDetailFormName(bo);

            if (Utils.IsEmpty(detailPanelName))
            {
                ErrorForm.ShowMessage("msgNoDetails", "msgNoDetails");
                return null;
            }

            object detailPanel;
            using (new WaitDialog())
            {
                detailPanel = ClassLoader.LoadClass(detailPanelName);
                Dbg.Assert(detailPanel != null, "class {0} can't be loaded", detailPanelName);
                Dbg.Assert(detailPanel is IApplicationForm,
                           "detail form  {0} doesn't implement IApplicationFrom interface",
                           detailPanelName);
                InitDetailForm(detailPanel);

                if (detailPanel != null)
                {
                    var parentHumanCaseList = detailPanel.GetType().GetProperty("ParentHumanCaseList");
                    if (parentHumanCaseList != null)
                    {
                        parentHumanCaseList.SetValue(detailPanel, this.DataSource as List<HumanCaseListItem>, null);
                    }
                }
            }
            if (detailPanel is IBasePanel)
            {
                //((IBasePanel)detailPanel).ReadOnly = readOnly;

                var meta = ObjectAccessor.MetaInterface(BusinessObject.GetType());
                var foundAction =
                    meta.Actions.Find(
                        item =>
                        ((item.ActionType == ActionTypes.View) || (item.ActionType == ActionTypes.Edit)) &&
                        (item.PanelType == ActionsPanelType.Top));
                if (foundAction != null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var childObject = foundAction.RunAction(manager, null as IObject, new List<object> { key }).obj;

                        if (readOnly)
                            BaseFormManager.ShowNormal_ReadOnly(detailPanel as IApplicationForm, childObject);
                        else
                            BaseFormManager.ShowNormal(detailPanel as IApplicationForm, childObject);
                    }
                }
            }
            else
            {

                if (Utils.IsEmpty(key)) key = null;
                if (readOnly)
                    BaseFormManager.ShowNormal_ReadOnly(detailPanel as IApplicationForm, ref key);
                else
                    BaseFormManager.ShowNormal(detailPanel as IApplicationForm, ref key);
            }
            return detailPanel as IApplicationForm;

        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var humanCase = ((HumanCaseListItem)FocusedItem);
                EidssSiteContext.ReportFactory.HumCaseInvestigation(humanCase.idfCase,
                                                                        humanCase.idfEpiObservation ?? 0,
                                                                        humanCase.idfCSObservation ?? 0,
                                                                        humanCase.idfsDiagnosis ?? 0);
            }
        }

        private bool hideAge;
        protected override void HidePersonalData(List<HumanCaseListItem> list)
        {
            HumanCaseListItem humanCaseListItem = null;
            LocationPersonalDataHelper helper = null;
            bool hideName =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName);
            hideAge =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonAge);
            bool hideSettlement =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(
                    PersonalDataGroup.Human_CurrentResidence_Settlement);
            bool hideAddress =
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(
                    PersonalDataGroup.Human_CurrentResidence_Details);
            Grid.GridView.CustomDrawCell += CustomDrawCells;
            if (hideSettlement || hideAddress)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {

                    ////object creation
                    IObjectCreator meta = ObjectAccessor.CreatorInterface(typeof(HumanCaseListItem));

                    humanCaseListItem = meta.CreateNew(manager, null, null) as HumanCaseListItem;
                    helper = new LocationPersonalDataHelper(humanCaseListItem.CountryLookup,
                                                            humanCaseListItem.RegionLookup,
                                                            humanCaseListItem.RayonLookup,
                                                            humanCaseListItem.SettlementLookup);

                }
            }

            if (hideName || hideAge || hideSettlement || hideAddress)
            {
                foreach (var item in list)
                {
                    try
                    {
                        if (hideName)
                            item.PatientName = "*";
                        if (hideAge)
                        {
                            item.Age = "*";
                            item.datDateofBirth = null;

                        }
                        if (hideSettlement)
                        {
                            humanCaseListItem.idfsCountry = item.idfsCountry;
                            humanCaseListItem.idfsRegion = item.idfsRegion;
                            item.GeoLocationName = Utils.Join(",",
                                                              new[]
                                                              {
                                                                  helper.GetCountryName(item.idfsCountry),
                                                                  helper.GetRegionName(item.idfsRegion),
                                                                  helper.GetRayonName(item.idfsRayon),
                                                                  "*"
                                                              });
                        }

                        else if (hideAddress)
                        {
                            humanCaseListItem.idfsCountry = item.idfsCountry;
                            humanCaseListItem.idfsRegion = item.idfsRegion;
                            humanCaseListItem.idfsRayon = item.idfsRayon;
                            item.GeoLocationName = Utils.Join(",",
                                                              new[]
                                                                  {
                                                                  helper.GetCountryName(item.idfsCountry),
                                                                  helper.GetRegionName(item.idfsRegion),
                                                                  helper.GetRayonName(item.idfsRayon),
                                                                  helper.GetSettlementName(item.idfsSettlement),
                                                                  "*"
                                                                  });
                        }

                    }
                    catch (Exception ex)
                    {
                        Dbg.Debug("error in hiding personal in hc list: {0}", ex);
                        Dbg.Debug("list item {0}, {1}", item.idfCase, item.strCaseID);
                    }
                }
            }
        }

        private void CustomDrawCells(object sender, RowCellCustomDrawEventArgs e)
        {
            if (hideAge && e.Column.FieldName == "datDateofBirth")
                e.DisplayText = "*";
        }
    }
}