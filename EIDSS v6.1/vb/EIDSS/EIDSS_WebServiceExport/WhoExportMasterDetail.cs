using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EIDSS;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using HACode = eidss.model.Enums.HACode;
using bv.common.Configuration;

namespace eidss.winclient.WhoExport
{
    public partial class WhoExportMasterDetail : BaseDetailPanel_WhoExportMaster
    {
        public WhoExportMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                whoExportDetail.DisplayLayout();
                ((LayoutGroup)whoExportDetail.GetLayout()).SearchPanelVisible = false;
            }
        }
        public static void Register(Control parentControl)
        {
            if (Config.GetBoolSetting("UseWhoModule"))
            {
                var menuAction = new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.DataExport, "CISIDExport", 1000);
                menuAction.SelectPermission = PermissionHelper.ExecutePermission(eidss.model.Enums.EIDSSPermissionObject.CanImportExportData);
            }
        }

        private static void ShowMe()
        {
            object id = 0;
            BaseFormManager.ShowNormal(new WhoExportMasterDetail(), ref id, null, 800, 600);
        }

        protected override void InitChildren()
        {
            whoExportDetail.SetDataSource(BusinessObject, ((WhoExportMaster)BusinessObject).WhoExportItems);
            whoExportDetail.ReadOnly = true;
            whoExportDetail.InlineMode = InlineMode.None;

            LookupBinder.BindDate(deDateStart, BusinessObject, "datStartDate");
            LookupBinder.BindDate(deDateFinish, BusinessObject, "datEndDate");
            LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, BusinessObject, ((WhoExportMaster)BusinessObject).DiagnosisLookup, "Diagnosis", HACode.Human, false, false);
        }
        
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "Export", Export);
            SetActionFunction(actions, "Edit", Edit);
        }

        private ActResult Export(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var obj = bo as eidss.model.Schema.WhoExportMaster;
            if (obj != null)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.DefaultExt = "*.txt";
                    dialog.Filter = "*.txt|*.txt";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var bld = new StringBuilder();
                        obj.WhoExportItems.ForEach(o => bld.AppendFormat(
                            "{0}\t{1}\t{2:dd\\/MM\\/yyyy}\t{3}\t{4:dd\\/MM\\/yyyy}\t{5}\t{6}\t{7:dd\\/MM\\/yyyy}\t{8:dd\\/MM\\/yyyy}\t{9:dd\\/MM\\/yyyy}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}\t{24}\t{25:dd\\/MM\\/yyyy}\t{26}\t{27:dd\\/MM\\/yyyy}\t{28}\t{29}\t{30}\t{31}\t{32}\r\n",
                            o.strCaseID, o.intAreaID, o.datDRash, o.intGenderID, o.datDBirth,
                            o.intAgeAtRashOnset, o.intNumOfVaccines, o.datDvaccine, o.datDNotification, o.datDInvestigation,
                            o.intClinFever, o.intClinCCC, o.intClinRashDuration, o.intClinOutcome, o.intClinHospitalization,
                            o.intSrcInf, o.intSrcOutbreakRelated, o.strSrcOutbreakID, o.intCompComplications, o.intCompEncephalitis,
                            o.intCompPneumonia, o.intCompMalnutrition, o.intCompDiarrhoea, o.intCompOther, o.intFinalClassification,
                            o.datDSpecimen, o.intSpecimen, o.datDLabResult, o.intMeaslesIgm, o.intMeaslesVirusDetection,
                            o.intRubellaIgm, o.intRubellaVirusDetection, o.strCommentsEpi
                            ));
                        File.WriteAllText(dialog.FileName, bld.ToString());
                    }
                }
            }
            return true;
        }

        private ActResult Edit(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            var o = whoExportDetail.Grid.GridView.GetFocusedRow() as eidss.model.Schema.WhoExport;
            if (o != null)
            {
                //BaseFormManager.ShowNormal(new HumanCaseDetail(), HumanCase.Accessor.Instance(null).SelectByKey(manager, o.idfCase));
                object id = o.idfCase;
                BaseFormManager.ShowNormal(new HumanCaseDetail(), ref id);
            }
            return true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object Key
        {
            get { return whoExportDetail.Key; }
        }
    }
}
