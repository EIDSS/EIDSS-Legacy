using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Human
{
    public partial class HumanCaseDeduplicationList : BaseListPanel_HumanCaseListItem
    {
        public HumanCaseDeduplicationList()
        {
            InitializeComponent();
            HelpTopicID = "HumanDeduplicationForm";
        }
        public override ILayout GetLayout()
        {
            if (ParentLayout == null)
            {
                ParentLayout = (DeduplicationLayout)LayoutHelper.CreateLayout(typeof(DeduplicationLayout), this, BusinessObject);
                ((LayoutSimple) ParentLayout).SetProperties(Caption, FormID, Icon);
                if (ParentLayout != null && ParentLayout.SearchPanelVisible != m_SearchPanelVisible)
                    ParentLayout.SearchPanelVisible = m_SearchPanelVisible;
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }
        public override string FormID { get { return "H10"; } set { } }
        public static void Register(Control parentControl)
        {
            RegisterItem("MenuHumanCaseDeduplication", 210, false);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar)
        {
            if (EidssUserContext.User.HasPermission(PermissionHelper.PersonalDataPermission(EIDSSPermissionObject.HumanCase)))
            {
                new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search,
                               resourceKey, order, showInToolbar, (int) MenuIconsSmall.SearchHumanCasesForDeduplication)
                    {
                        SelectPermission =
                            PermissionHelper.ExecutePermission(EIDSSPermissionObject.HumanCaseDeduplication),
                        BeginGroup = false,
                        ShowInMenu = !showInToolbar
                    };
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(HumanCaseDeduplicationList), BaseFormManager.MainForm,
                                       HumanCaseListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "";
        }
        public override IApplicationForm Edit(object key, List<object> parameters, bv.common.Enums.ActionTypes actionType, bool readOnly)
        {
            IObject bo = null;
            if ((parameters != null) && (parameters.Count > 1) && (parameters[1] is IObject))
            {
                bo = (IObject)parameters[1];
            }
            using (var manager = CreateDbManagerProxy())
            {
                var layout = (DeduplicationLayout) GetLayout();
                layout.AddForDeduplication(manager, bo, parameters);
            }
            return null;
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
        //public override void SetCustomActions()
        //{
        //    base.SetCustomActions();

        //    SetActionFunction("AddForDeduplication", AddForDeduplication);
        //}

        //private bool AddForDeduplication(DbManagerProxy manager, IObject bo, List<object> pars)
        //{
        //    var layout = (DeduplicationLayout) GetLayout();
        //    if (layout.DeduplicationList.Count<2)
        //    {
        //        if (layout.DeduplicationList.Count == 1 && layout.DeduplicationList[0].Key.Equals(((HumanCaseListItem)pars[1]).Key))
        //            return true;
        //        layout.DeduplicationList.Add((HumanCaseListItem)((HumanCaseListItem)pars[1]).Clone());
        //        if (layout.DeduplicationGrid.DataSource == null || layout.DeduplicationGrid.DataSource != layout.DeduplicationList)
        //            layout.DeduplicationGrid.DataSource = layout.DeduplicationList;
        //         layout.DeduplicationView.RefreshData();

        //        return true;
        //    }
        //    return false;
        //}
    }

}

