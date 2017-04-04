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
    public partial class BasicSyndromicSurveillanceListPanel : BaseListPanel_BasicSyndromicSurveillanceListItem
    {
        public BasicSyndromicSurveillanceListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            RegisterItem("MenuBasicSyndromicSurveillanceList", 140, false, false, MenuGroup.MenuJournalsBss);
            //Toolbar menu
            RegisterItem("MenuBasicSyndromicSurveillanceList", 100010, true, false, MenuGroup.ToolbarJournals);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.BssList,
                           (int)MenuIcons.BssList)
                {
                    //TODO права
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToBssModule),
                    BeginGroup = beginGroup,
                    ShowInMenu = !showInToolbar,
                    Group = (int)group

                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(BasicSyndromicSurveillanceListPanel), BaseFormManager.MainForm,
                                       BasicSyndromicSurveillanceListItem.CreateInstance());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "BasicSyndromicSurveillanceItemDetail";
        }
    }
}