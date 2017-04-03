using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Human;
using eidss.winclient.Schema;

namespace eidss.winclient.BasicSyndromicSurveillance
{
    public sealed partial class BasicSyndromicSurveillanceItemDetail : BaseDetailPanel_BasicSyndromicSurveillanceItem
    {
        private List<Control> HiddenControls;

        public BasicSyndromicSurveillanceItemDetail()
        {
            InitializeComponent();
            if (patientAddress.Columns != null)
            {
                patientAddress.Columns[0].Left = 1;
                patientAddress.Columns[0].LabelWidth = 110;
                patientAddress.Columns[0].ControlWidth = 194;
                patientAddress.Columns[1].Left = 312;
                patientAddress.Columns[1].LabelWidth = 134;
                patientAddress.Columns[1].ControlWidth = 194;
                patientAddress.Columns[2].Left = 650;
                patientAddress.Columns[2].LabelWidth = 110;
                patientAddress.Columns[2].ControlWidth = 194;
                patientAddress.UpdateLayout();
            }
            HiddenControls = new List<Control>
                {
                    lblDateOfCare,
                    dtDateOfCare,
                    lblPatientWasHospitalized,
                    lePatientWasHospitalized,
                    lblOutcome,
                    leOutcome,
                    lblPatientER,
                    lePatientER,
                    lblTreatment,
                    leTreatment
                };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            RegisterItem(MenuActionManager.Instance.Create, "MenuNewBasicSyndromicSurveillanceItem", 240, false, false, MenuGroup.CreateBss);
            //Toolbar menu
            RegisterItem(MenuActionManager.Instance.Journals, "ToolbarNewBasicSyndromicSurveillanceItem", 100110, true, false, MenuGroup.ToolbarCreate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuAction"></param>
        /// <param name="resourceKey"></param>
        /// <param name="order"></param>
        /// <param name="showInToolbar"></param>
        /// <param name="beginGroup"></param>
        private static void RegisterItem
            (IMenuAction menuAction, string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAction,
                           resourceKey, order, showInToolbar, (int) MenuIconsSmall.Bss,
                           (int) MenuIcons.Bss)
                {
                    SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToBssModule),
                    BeginGroup = beginGroup,
                    ShowInMenu = !showInToolbar,
                    Group = (int)group
                };
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(typeof(BasicSyndromicSurveillanceItemDetail), ref id);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            base.DefineBinding();

            var bss = BusinessObject as BasicSyndromicSurveillanceItem;
            if (bss == null) return;

            LookupBinder.BindTextEdit(txtFormID, bss, "strFormID");
            LookupBinder.BindTextEdit(txtDateEntered, bss, "datDateEntered");
            LookupBinder.BindTextEdit(txtDateLastSaved, bss, "datDateLastSaved");
            /*
            LookupBinder.BindDate(dtDateEntered, bss, "datDateEntered");
            LookupBinder.BindDate(dtDateLastSaved, bss, "datDateLastSaved");
            */
            LookupBinder.BindTextEdit(txtCreatedBy, bss, "strEnteredBy");
            LookupBinder.BindTextEdit(txtSite, bss, "strSite");
            
            LookupBinder.BindBaseLookup(leNotification, bss, "BSSType", bss.BSSTypeLookup, false, false);
            LookupBinder.BindOrganizationLookup(leHospital, bss, "Hospital", bss.HospitalLookup, HACode.Syndromic);
            LookupBinder.BindDate(dtReportDate, bss, "datReportDate");

            RefreshPatientBindings(bss);
            
            LookupBinder.BindTextEdit(txtPersonalID, bss, "strPersonalID");
            //TODO вводить Age
            LookupBinder.BindSpinEdit(txtAgeYears, bss, "intAgeYear");
            LookupBinder.BindSpinEdit(txtAgeMonths, bss, "intAgeMonth");

            //clinical signs
            LookupBinder.BindBaseLookup(lePregnant, bss, "Pregnant", bss.PregnantLookup, false, false);
            LookupBinder.BindBaseLookup(lePostpartum, bss, "PostpartumPeriod", bss.PostpartumPeriodLookup, false, false);
            LookupBinder.BindDate(dtDateOfSymptomsOnset, bss, "datDateOfSymptomsOnset");
            LookupBinder.BindBaseLookup(leFever, bss, "Fever", bss.FeverLookup, false, false);
            LookupBinder.BindBaseLookup(leMethodMeasurement, bss, "MethodMeasurement", bss.MethodMeasurementLookup, false, false);
            LookupBinder.BindTextEdit(txtOtherMethod, bss, "strMethod");
            LookupBinder.BindBaseLookup(leCough, bss, "Cough", bss.CoughLookup, false, false);
            LookupBinder.BindBaseLookup(leShortnessBreath, bss, "ShortnessBreath", bss.ShortnessBreathLookup, false, false);
            LookupBinder.BindBaseLookup(leSeasonalFluVaccine, bss, "SeasonalFluVaccine", bss.SeasonalFluVaccineLookup, false, false);
            LookupBinder.BindDate(dtDateOfCare, bss, "datDateOfCare");
            LookupBinder.BindBaseLookup(lePatientWasHospitalized, bss, "PatientWasHospitalized", bss.PatientWasHospitalizedLookup, false, false);
            LookupBinder.BindBaseLookup(leOutcome, bss, "Outcome", bss.OutcomeLookup, false, false);
            LookupBinder.BindBaseLookup(lePatientER, bss, "PatientWasInER", bss.PatientWasInERLookup, false, false);
            LookupBinder.BindBaseLookup(leTreatment, bss, "Treatment", bss.TreatmentLookup, false, false);
            LookupBinder.BindBaseLookup(leAntiviral, bss, "AdministratedAntiviralMedication", bss.AdministratedAntiviralMedicationLookup, false, false);
            LookupBinder.BindTextEdit(txtNameOfMedication, bss, "strNameOfMedication");
            LookupBinder.BindDate(dtDateReceived, bss, "datDateReceivedAntiviralMedication");
            
            //Chronic diseases
            LookupBinder.BindCheckEdit(cbRespiratorySystem, bss, "blnRespiratorySystem");
            LookupBinder.BindCheckEdit(cbAsthma, bss, "blnAsthma");
            LookupBinder.BindCheckEdit(cbDiabetes, bss, "blnDiabetes");
            LookupBinder.BindCheckEdit(cbCardiovascular, bss, "blnCardiovascular");
            LookupBinder.BindCheckEdit(cbObesity, bss, "blnObesity");
            LookupBinder.BindCheckEdit(cbRenal, bss, "blnRenal");
            LookupBinder.BindCheckEdit(cbLiver, bss, "blnLiver");
            LookupBinder.BindCheckEdit(cbNeuro, bss, "blnNeurological");
            LookupBinder.BindCheckEdit(cbImmuno, bss, "blnImmunodeficiency");
            LookupBinder.BindCheckEdit(cbUnknownEtiology, bss, "blnUnknownEtiology");

            LookupBinder.BindDate(dtSampleCollectionDate, bss, "datSampleCollectionDate");
            LookupBinder.BindTextEdit(txtSampleID, bss, "strSampleID");
            LookupBinder.BindDate(dtResultDate, bss, "datTestResultDate");
            LookupBinder.BindBaseLookup(leTestResult, bss, "TestResult", bss.TestResultLookup, false, false);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            if (BusinessObject == null)
            {
                bppLocation.PopupControl.BusinessObject = null;
                patientAddress.BusinessObject = null;
            }
            else
            {
                var bss = BusinessObject as BasicSyndromicSurveillanceItem;
                if (bss != null)
                {
                    patientAddress.BusinessObject = bss.Patient.CurrentResidenceAddress;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "Report", ShowReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ShowReport(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            //if (Session == null) return false;
            ////parameters.Add(Session.idfVectorSurveillanceSession);
            //EidssSiteContext.ReportFactory.VectorSurveillanceSessionSummary(Session.idfVectorSurveillanceSession);
            return true;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o">Объект, который запрашивает набор входных параметров для своего создания</param>
        /// <returns></returns>
        public override List<object> GetParamsAction(IObject o)
        {
            var list = new List<object>();
            //if (Session != null) list = Session.GetParamsAction(o.GetType());
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBasicSyndromicSurveillanceItemDetailLoad(object sender, EventArgs e)
        {
            LayoutCorrector.SetStyleController(bppLocation, LayoutCorrector.MandatoryStyleController);
        }

        private void OnBeLastNameButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var bss = BusinessObject as BasicSyndromicSurveillanceItem;
            if ((bss == null) || (bss.Patient == null)) return;

            var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance);
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Glyph:
                    {
                        var r = BaseFormManager.ShowForSelection(new PatientListPanel(), FindForm(), null, 1024, 800) as PatientListItem;
                        if (r != null)
                        {
                            using (manager)
                            {
                                var patientAccessor = Patient.Accessor.Instance(null);
                                var patient = patientAccessor.SelectByKey(manager, r.idfHumanActual);
                                bss.Patient = bss.Patient.CopyFrom(manager, patient);
                                patientAddress.BusinessObject = bss.Patient.CurrentResidenceAddress;
                                bss.SetupChildHandlers();
                            }
                        }
                    }
                    break;
                case ButtonPredefines.Delete:
                    using (manager)
                    {
                        bss.Patient = bss.Patient.Clear(manager, bss.idfBasicSyndromicSurveillance);
                    }
                    break;
            }

            RefreshPatientBindings(bss);
        }

        private void RefreshPatientBindings(BasicSyndromicSurveillanceItem bss)
        {
            if (bss.Patient == null) return;
            
            LookupBinder.BindTextEdit(beLastName, bss.Patient, "strLastName");
            LookupBinder.BindTextEdit(txtFirstName, bss.Patient, "strFirstName");
            LookupBinder.BindTextEdit(txtMiddleName, bss.Patient, "strSecondName");

            LookupBinder.BindDate(dtDateOfBirth, bss.Patient, "datDateofBirth");

            LookupBinder.BindBaseLookup(leSex, bss.Patient, "Gender", bss.Patient.GenderLookup, false, false);
            LookupBinder.BindTextEdit(txtPhoneNumber, bss.Patient, "strHomePhone");
        }

        private void OnLeNotificationEditValueChanged(object sender, EventArgs e)
        {
            if (leNotification.EditValue == null) return;
            var isILI = ((BaseReference)leNotification.EditValue).idfsBaseReference == 50791920000000;

            foreach (var ctrl in HiddenControls)
            {
                ctrl.Visible = !isILI;
            }
        }
    }
}
