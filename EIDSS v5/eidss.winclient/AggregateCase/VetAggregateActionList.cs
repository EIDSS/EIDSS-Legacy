using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.winclient.Schema;
using eidss.model.Enums;
using bv.winclient.BasePanel;
using eidss.model.Schema;
using bv.winclient.Core;
using bv.common.Core;
using eidss.winclient.Helpers;
using bv.model.Model.Core;
namespace eidss.winclient.AggregateCase
{
    public partial class VetAggregateActionList : BaseListPanel_VetAggregateActionListItem
    {
        public VetAggregateActionList()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
                return;
            AfterLayoutCreated += LayoutCreated;
        }
        public static void Register(Control parentControl)
        {
            RegisterItem(308, false);

        }
        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var vetCase = ((VetAggregateActionListItem) FocusedItem);
                var ps = new AggregateActionsParameters(vetCase.idfAggrCase,
                                                        vetCase.idfsDiagnosticFormTemplate ?? 0, vetCase.idfDiagnosticObservation ?? 0,
                                                        vetCase.idfsProphylacticFormTemplate ?? 0, vetCase.idfProphylacticObservation ?? 0,
                                                        vetCase.idfsSanitaryFormTemplate ?? 0, vetCase.idfSanitaryObservation ?? 0, 
                                                        GetReportLabels());
                EidssSiteContext.ReportFactory.VetAggregateCaseActions(ps);
            }
        }

        private static Dictionary<string, string> GetReportLabels()
        {
            var labels = new Dictionary<string, string>();
            var resources = new ComponentResourceManager(typeof (VetAggregateActionList));
            foreach (KeyValuePair<string, string> language in Localizer.SupportedLanguages)
            {
                var cultureInfo = new CultureInfo(language.Value);
                string key = language.Key;
                string diagnostic = resources.GetString("diagnosticText.Text", cultureInfo) ?? @"Diagnostic investigations";
                labels.Add("@diagnosticText" + key, diagnostic);
                string prophylactic = resources.GetString("prophylacticText.Text", cultureInfo) ??@"Treatment-prophylactics and vaccination measures";
                labels.Add("@prophylacticText" + key, prophylactic);
                string sanitary = resources.GetString("sanitaryText.Text", cultureInfo) ?? @"Veterinary-sanitary measures (undertaking)";
                labels.Add("@sanitaryText" + key, sanitary);
            }
            return labels;
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuVetAggregateActionList", order, showInToolbar, (int)MenuIconsSmall.VetAggregateActionList)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase),
                BeginGroup = false,
                ShowInMenu = !showInToolbar
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VetAggregateActionList), BaseFormManager.MainForm,
                                       VetAggregateActionListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "VetAggregateActionDetail";
        }


        private void BeforeSelectAction(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            cancel = !AggregateHelper.ValidateSelection<VetAggregateActionListItem>(panel, action);

        }


        private void LayoutCreated()
        {
            var layout = GetLayout();
            layout.OnBeforeActionExecuting += BeforeSelectAction;
        }

    }
}
