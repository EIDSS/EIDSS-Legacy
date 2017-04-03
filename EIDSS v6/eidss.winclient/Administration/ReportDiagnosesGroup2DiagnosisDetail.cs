using System;
using System.ComponentModel;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class ReportDiagnosesGroup2DiagnosisDetail : BaseGroupPanel_ReportDiagnosesGroup2Diagnosis
    {
        public ReportDiagnosesGroup2DiagnosisDetail()
        {
            InitializeComponent();
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {

            var matrix = dummyObjectWithLookups as ReportDiagnosesGroup2Diagnosis;
            if (matrix == null) return;

            var column = Grid.GridView.Columns.ColumnByName("idfsDiagnosis");
            if (column != null)
            {
                LookupBinder.BindDiagnosisRepositoryLookup(column.SetLookupEditor(), matrix.DiagnosisLookup, HACode.All, "name", false, false);
            }

            Grid.GridView.InitNewRow += InitNewMatrixRow;
            TopPanelVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitNewMatrixRow(object sender, InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            var rd = obj as ReportDiagnosesGroup2Diagnosis;
            if (rd == null) return;
            if (IdfsSummaryReportType.HasValue)
                rd.idfsCustomReportType = IdfsSummaryReportType.Value;
            if (IdfsReportDiagnosisGroup.HasValue)
                rd.idfsReportDiagnosisGroup = IdfsReportDiagnosisGroup.Value;
        }

        private long? m_IdfsSummaryReportType;
        private long? m_IdfsReportDiagnosisGroup;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public long? IdfsSummaryReportType
        {
            get { return m_IdfsSummaryReportType; }
            set
            {
                m_IdfsSummaryReportType = value;
                Refresh(DataSource, GetFilter(m_IdfsSummaryReportType, m_IdfsReportDiagnosisGroup));
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public long? IdfsReportDiagnosisGroup
        {
            get { return m_IdfsReportDiagnosisGroup; }
            set
            {
                m_IdfsReportDiagnosisGroup = value;
                Refresh(DataSource, GetFilter(m_IdfsSummaryReportType, m_IdfsReportDiagnosisGroup));
            }
        }

        private string GetFilter(long? idfsSummaryReportType, long? idfsReportDiagnosisGroup)
        {
            var sb = new StringBuilder();
            sb.Append(idfsSummaryReportType.HasValue
                    ? String.Format("idfsCustomReportType={0}", idfsSummaryReportType.Value)
                    : "idfsCustomReportType=-1");
            sb.Append(" && ");
            sb.Append(idfsReportDiagnosisGroup.HasValue
                    ? String.Format("idfsReportDiagnosisGroup={0}", idfsReportDiagnosisGroup.Value)
                    : "idfsReportDiagnosisGroup=-1");
            return sb.ToString();
        }
    }
}
