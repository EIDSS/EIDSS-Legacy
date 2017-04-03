using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VsSessionListPanel : BaseListPanel_VsSessionListItem
    {
        public VsSessionListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            RegisterItem("MenuFindVSSession", 910, false, true);
            RegisterItem("ToolbarFindVSSession", 202, true, false);
        }

        private static void RegisterItem(string resourceKey, int order, bool showInToolbar, bool beginGroup)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.VsSessionList,
                           (int)MenuIcons.VsSessionList)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.VsSession),
                    BeginGroup = beginGroup,
                    ShowInMenu = !showInToolbar
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VsSessionListPanel), BaseFormManager.MainForm,
                                       VsSessionListItem.CreateInstance());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "VsSessionDetail";
        }
    }
}