using System;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.BLToolkit;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using eidss.model.Reports.AberrationAnalisys;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Reports;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    public partial class HumAberrationKeeper : AberrationKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumAberrationKeeper));

        private string[] m_Diagnosis;
        private string[] m_CaseClassification;

        public HumAberrationKeeper()
        {
            ReportType = typeof (HumAberrationReport);
            InitializeComponent();
            dtEnd.EditValue = TruncateDate(DateTime.Now);
            dtStart.EditValue = TruncateDate(DateTime.Now.AddMonths(-1));

            diagnosisFilter.SetMandatory();
            intType = 1;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new HumAberrationModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, RegionIdParam,
                RayonIdParam, SettlementIdParam, LocationParam,
                ThresholdParam, TimeUnitsParam, TimeUnitsTextParam, BaselineParam, LagParam, DateFieldsParam, DateFieldsTextParam,
                m_Diagnosis, AgeFrom, AgeTo, Gender, humGenderLookupFilter.SelectedText, m_CaseClassification, UseArchive);
            var report = (HumAberrationReport) CreateReportObject();

            report.SetParameters( model,manager,archiveManager);

            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            diagnosisFilter.DefineBinding();
            humGenderLookupFilter.DefineBinding();
            humCaseClassificationMultiFilter.DefineBinding();

            ageFrom.EditValue = null;
            ageTo.EditValue = null;
        }

        //if mandatory parameters were set
        [Browsable(false)]
        protected bool MandatorySet
        {
            get
            {
                if (m_Diagnosis == null || m_CaseClassification == null || m_Diagnosis.Length == 0 || m_CaseClassification.Length == 0)
                {
                    return false;
                }
                return true;
            }
        }

        [Browsable(false)]
        protected int? AgeFrom
        {
            get
            {
                if (ageFrom != null && ageFrom.EditValue != null)
                {
                    return int.Parse(ageFrom.EditValue.ToString());
                }
                return null;
            }
        }

        [Browsable(false)]
        protected int? AgeTo
        {
            get
            {
                if (ageTo != null && ageTo.EditValue != null)
                {
                    return int.Parse(ageTo.EditValue.ToString());
                }
                return null;
            }
        }

        [Browsable(false)]
        protected long? Gender
        {
            get
            {
                if (humGenderLookupFilter != null)
                {
                    return humGenderLookupFilter.EditValueId;
                }
                return null;
            }
        }

        private void diagnosisFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_Diagnosis = e.KeyArray;
        }

        private void humCaseClassificationMultiFilter_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_CaseClassification = e.KeyArray;
        }

        private void ageFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (ageFrom.EditValue != null && ageTo.EditValue != null && Int32.Parse(ageTo.EditValue.ToString()) != 0 &&
                Int32.Parse(ageFrom.EditValue.ToString()) > Int32.Parse(ageTo.EditValue.ToString()))
            {
                ageTo.EditValue = ageFrom.EditValue;
            }
        }

        private void ageTo_EditValueChanged(object sender, EventArgs e)
        {
            if (ageFrom.EditValue != null && ageTo.EditValue != null && Int32.Parse(ageTo.EditValue.ToString()) != 0 &&
                Int32.Parse(ageFrom.EditValue.ToString()) > Int32.Parse(ageTo.EditValue.ToString()))
            {
                ageFrom.EditValue = ageTo.EditValue;
            }
        }

        private void CheckNullValue(TextEdit edit)
        {
            if (edit.Text.Replace("0", "").Replace(".", "") == "")
            {
                edit.EditValue = null;
            }
        }

        private void age_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                CheckNullValue(sender as TextEdit);
            }
        }

        private void age_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var textEdit = sender as TextEdit;
                if (textEdit != null)
                {
                    textEdit.EditValue = null;
                    textEdit.IsModified = false;
                }
                e.Handled = true;
            }
        }
    }
}