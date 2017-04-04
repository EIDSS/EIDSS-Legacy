using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.BasicSyndromicSurveillance
{
    public partial class BasicSyndromicSurveillanceAggregateListPanel : BaseListPanel_BasicSyndromicSurveillanceAggregateList
    {
        public BasicSyndromicSurveillanceAggregateListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            RegisterItem("MenuBasicSyndromicSurveillanceAggregateList", 130, false, true, MenuGroup.MenuJournalsAggregate);
            //Toolbar menu
            //RegisterItem("MenuFindBasicSyndromicSurveillanceAggregateList", 203, true, false, MenuGroup.ToolbarAggregate);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.BssAggregateList,
                           (int)MenuIcons.BssAggregateList)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToBssModule),
                    ShowInMenu = !showInToolbar,
                    Group = (int)group
               };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(BasicSyndromicSurveillanceAggregateListPanel), BaseFormManager.MainForm,
                                       BasicSyndromicSurveillanceAggregateList.CreateInstance());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "BasicSyndromicSurveillanceAggregateHeaderDetail";
        }
    }
}