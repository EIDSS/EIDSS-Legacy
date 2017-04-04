using System.ComponentModel;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class DataQualityIndicatorsRayonsReport : BaseDataQualityIndicatorsReport
    {
        public DataQualityIndicatorsRayonsReport()
        {
            InitializeComponent();
        }

        protected override void BindSummaryAvarage(DQIDataSet.spRepHumDataQualityIndicatorsRow resultRow)
        {
            SummaryScoreByIndicatorsTotalCell.Text = resultRow.dbl_AVG_SummaryScoreByIndicators.ToString(DoubleFormat);
        }

        protected override bool HideDiagnosisIfEmpty(string[] checkedDiagnosis)
        {
            bool hide = base.HideDiagnosisIfEmpty(checkedDiagnosis);
            if (hide)
            {
                ((ISupportInitialize) (FirstSignatureTable)).BeginInit();
                ((ISupportInitialize) (SecondSignatureTable)).BeginInit();
                FirstOrganizationNameCell.WidthF = SecondOrganizationNameCell.WidthF = RegionHeaderCell.WidthF + RayonHeaderCell.WidthF;
                FirstPrintedFromEidssCell.WidthF = SecondPrintedFromEidssCell.WidthF = NumberOfCasesHeaderCell.WidthF;
                FirstDateTimeCell.WidthF = SecondDateTimeCell.WidthF = xrTableCell1.WidthF;
                ((ISupportInitialize) (SecondSignatureTable)).EndInit();
                ((ISupportInitialize) (FirstSignatureTable)).EndInit();
            }
            return hide;
        }
    }
}