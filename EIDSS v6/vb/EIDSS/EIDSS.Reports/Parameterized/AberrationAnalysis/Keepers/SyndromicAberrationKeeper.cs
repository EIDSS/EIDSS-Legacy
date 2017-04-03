using System;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.BLToolkit;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using eidss.model.Core;
using eidss.model.Reports.AberrationAnalisys;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Reports;

namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    public partial class SyndromicAberrationKeeper : AberrationKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (SyndromicAberrationKeeper));

        public SyndromicAberrationKeeper()
        {
            ReportType = typeof (SyndromicAberrationReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                siteLookupFilter.EditValue = EidssSiteContext.Instance.SiteID;
                siteLookupFilter.SetMandatory();
                syndromicTypeLookupFilter.SetMandatory();
            }
            intType = 3;
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new BaseReport();
            }

            var model = new SyndromicAberrationModel(CurrentCulture.ShortName, StartDateTruncated, EndDateTruncated, RegionIdParam,
                RayonIdParam, SettlementIdParam, LocationParam,
                ThresholdParam, TimeUnitsParam, TimeUnitsTextParam, BaselineParam, LagParam, DateFieldsParam, DateFieldsTextParam,
                SiteL, siteLookupFilter.SelectedText, NotificationType, syndromicTypeLookupFilter.SelectedText,
                AgeFrom, AgeTo, Gender, humGenderLookupFilter.SelectedText, Hospital, syndrOrganizationFilter.SelectedText,
                UseArchive);
            var report = (SyndromicAberrationReport)CreateReportObject();

            report.SetParameters(manager, model);

            return report;
        }

        //if mandatory parameters were set
        [Browsable(false)]
        protected bool MandatorySet
        {
            get
            {
                if (NotificationType == -1 || SiteL == -1)
                {
                    return false;
                }
                return true;
            }
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_HasLoad = false;

                base.ApplyResources(manager);

                m_Resources.ApplyResources(pnlSettings, "pnlSettings");
                m_Resources.ApplyResources(this, "$this");

                siteLookupFilter.DefineBinding();
                syndromicTypeLookupFilter.DefineBinding();
                humGenderLookupFilter.DefineBinding();
                syndrOrganizationFilter.DefineBinding();

                ageFrom.EditValue = null;
                ageTo.EditValue = null;
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        [Browsable(false)]
        protected long SiteL
        {
            get
            {
                if (siteLookupFilter != null)
                {
                    return siteLookupFilter.EditValueId;
                }
                return -1;
            }
        }

        [Browsable(false)]
        protected long NotificationType
        {
            get
            {
                if (syndromicTypeLookupFilter != null)
                {
                    return syndromicTypeLookupFilter.EditValueId;
                }
                return -1;
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
                if (humGenderLookupFilter != null && humGenderLookupFilter.EditValueId > 0)
                {
                    return humGenderLookupFilter.EditValueId;
                }
                return null;
            }
        }

        [Browsable(false)]
        protected long? Hospital
        {
            get
            {
                if (syndrOrganizationFilter != null && syndrOrganizationFilter.EditValueId > 0)
                {
                    return syndrOrganizationFilter.EditValueId;
                }
                return null;
            }
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
                CheckNullValue((sender as TextEdit));
            }
        }

        private void age_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var edit = sender as TextEdit;
                if (edit != null)
                {
                    edit.EditValue = null;
                    edit.IsModified = false;
                }
                e.Handled = true;
            }
        }
    }
}