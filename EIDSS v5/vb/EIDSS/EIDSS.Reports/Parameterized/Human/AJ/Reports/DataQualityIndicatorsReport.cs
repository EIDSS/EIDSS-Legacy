using System;
using System.Data;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using bv.common.Core;
using bv.model.Model.Core;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class DataQualityIndicatorsReport : BaseDataQualityIndicatorsReport
    {
        public DataQualityIndicatorsReport()
        {
            InitializeComponent();
        }

        protected override void AjustPadding()
        {
            var padding = new PaddingInfo(2, 2, 2, 5);
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn || ModelUserContext.CurrentLanguage == Localizer.lngRu)
            {
                xrTableCell8.Padding = padding;
            }
            if (ModelUserContext.CurrentLanguage == Localizer.lngRu)
            {
                xrTableCell9.Padding = padding;
                xrTableCell25.Padding = padding;
                xrTableCell26.Padding = padding;
                xrTableCell15.Padding = padding;
                xrTableCell29.Padding = padding;
            }
            if (ModelUserContext.CurrentLanguage == Localizer.lngAzLat)
            {
                xrTableCell16.Padding = padding;
            }
        }

        protected override void BindSummaty(DQIDataSet.spRepHumDataQualityIndicatorsDataTable source)
        {
            DataTable distinct = source.DefaultView.ToTable(true, "idfsRegion", "strRegion", "idfsRayon", "strRayon",
                                                            "dbl_AVG__1_NotificationAVG",
                                                            "dbl_AVG_CaseStatus",
                                                            "dbl_AVG_DateOfCompletionOfPaperForm",
                                                            "dbl_AVG_NameOfEmployer",
                                                            "dbl_AVG_DateOfSymptomsOnset",
                                                            "dbl_AVG_CurrentLocationOfPatient",
                                                            "dbl_AVG_NotificationDateTime",
                                                            "dbl_AVG_dblNotificationSentByFacility",
                                                            "dbl_AVG_dblNotificationSentByName",
                                                            "dbl_AVG_NotificationReceivedByFacility",
                                                            "dbl_AVG_NotificationReceivedByName",
                                                            "dbl_AVG_TimelinessofDataEntry",
                                                            "dbl_AVG__2_CaseInvestigation",
                                                            "dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation",
                                                            "dbl_AVG_DemographicInformationOccupation",
                                                            "dbl_AVG_ClinicalInformationInitialCaseClassification",
                                                            "dbl_AVG_ClinicalInformationLocationOfExposure",
                                                            "dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy",
                                                            "dbl_AVG_SamplesCollectionSamplesCollected",
                                                            "dbl_AVG_ContactListAddContact",
                                                            "dbl_AVG_CaseClassificationClinicalSigns",
                                                            "dbl_AVG_EpidemiologicalLinksAndRiskFactors",
                                                            "dbl_AVG_FinalCaseClassificationFinalCaseClassification",
                                                            "dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis",
                                                            "dbl_AVG_FinalCaseClassificationBasisOfDiagnosis",
                                                            "dbl_AVG_FinalCaseClassificationOutcome",
                                                            "dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak",
                                                            "dbl_AVG_FinalCaseClassificationEpidemiologistName",
                                                            "dbl_AVG__3_TheResultsOfLaboratoryTests",
                                                            "dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted",
                                                            "dbl_AVG_TheResultsOfLaboratoryTestsResultObservation",
                                                            "dbl_AVG_SummaryScoreByIndicators");

            if (distinct.Rows.Count > 0)
            {
                const int minColumnIndex = 4;
                const int minCellIndex = 2;

                bool isFirstRow = true;
                DataRow summaryRow = distinct.NewRow();
                for (int i = minColumnIndex; i < distinct.Columns.Count; i++)
                {
                    summaryRow[i] = 0.0;
                }

                foreach (DataRow row in distinct.Rows)
                {
                    if (!isFirstRow)
                    {
                        for (int i = minColumnIndex; i < distinct.Columns.Count; i++)
                        {
                            if (!(row[i] is DBNull))
                            {
                                summaryRow[i] = (double) summaryRow[i] + (double) row[i];
                            }
                        }
                    }
                    isFirstRow = false;
                }

                for (int i = 0; i < Math.Min(distinct.Columns.Count - minColumnIndex, TotalDynamicRow.Cells.Count - minCellIndex); i++)
                {
                    XRTableCell currentCell = TotalDynamicRow.Cells[i + minCellIndex];
                    currentCell.Text = ((double) summaryRow[i + minColumnIndex] / distinct.Rows.Count).ToString("0.00");
                }
            }
        }
    }
}