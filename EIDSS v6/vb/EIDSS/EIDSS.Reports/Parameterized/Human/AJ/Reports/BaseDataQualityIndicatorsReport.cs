using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class BaseDataQualityIndicatorsReport : BaseDateReport
    {
        protected const string DoubleFormat = "0.00";

        protected bool m_IsRegionPrint = true;
        protected bool m_IsRayonPrint = true;

        public BaseDataQualityIndicatorsReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }

        public void SetParameters(DbManagerProxy manager, DataQualityIndicatorsSurrogateModel model)
        {
            base.SetParameters(manager, model);

            BindHeaderLabel(model);

            string diagnosisXml = FilterHelper.GetXmlFromList(model.DiagnosisCheckedItems);
            DQIDataSet.spRepHumDataQualityIndicatorsDataTable indicatorsTable = FillReportDataSource(manager, model, diagnosisXml);


            var chartTable = (DQIDataSet.spRepHumDataQualityIndicatorsDataTable) indicatorsTable.Copy();


            DQIDataSet.spRepHumDataQualityIndicatorsRow maxRow = indicatorsTable.NewspRepHumDataQualityIndicatorsRow();

            if (indicatorsTable.Count > 0)
            {
                maxRow = indicatorsTable[0];
                BindSummaryMax(maxRow);
            }

            DQIDataSet.spRepHumDataQualityIndicatorsRow averageRow = CalculateAverage(indicatorsTable);
            BindSummaryAvarage(averageRow);

            averageRow = CalculateFilteredAverage(model, chartTable, averageRow);

            var chartData = ConvertSecondChartData(maxRow, averageRow);

            FillFirstChartDataSource(indicatorsTable, model.ArrangeRayonsAlphabetically);

            FillSecondChartDataSource(chartData);

            AjustPadding();

            HideDiagnosisIfEmpty(model.DiagnosisCheckedItems);
        }

        private static DQIDataSet.spRepHumDataQualityIndicatorsRow CalculateFilteredAverage
            (DataQualityIndicatorsSurrogateModel model, DQIDataSet.spRepHumDataQualityIndicatorsDataTable chartTable, DQIDataSet.spRepHumDataQualityIndicatorsRow chartRow)
        {
            if (model.RegionId.HasValue)
            {
                var rowToDeleteList = new List<DQIDataSet.spRepHumDataQualityIndicatorsRow>();
                foreach (DQIDataSet.spRepHumDataQualityIndicatorsRow row in chartTable)
                {
                    if ((row.idfsRegion != model.RegionId) ||
                        (model.RayonId.HasValue && row.idfsRayon != model.RayonId.Value))
                    {
                        rowToDeleteList.Add(row);
                    }
                }

                chartTable.BeginLoadData();
                foreach (DQIDataSet.spRepHumDataQualityIndicatorsRow row in rowToDeleteList)
                {
                    chartTable.Rows.Remove(row);
                }
                chartTable.EndLoadData();
                chartRow = CalculateAverage(chartTable);
            }
            return chartRow;
        }

        protected DQIDataSet.spRepHumDataQualityIndicatorsDataTable FillReportDataSource
            (DbManagerProxy manager, DataQualityIndicatorsSurrogateModel surrogateModel, string diagnosisXml)
        {
            Action<SqlConnection> action = (connection =>
            {
                m_DQIAdapter.Connection = connection;
                m_DQIAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_DQIAdapter.CommandTimeout = CommandTimeout;
                m_DQIDataSet.EnforceConstraints = false;

                m_DQIAdapter.Fill(m_DQIDataSet.spRepHumDataQualityIndicators,
                    surrogateModel.Language,
                    diagnosisXml,
                    surrogateModel.Year, surrogateModel.Month, surrogateModel.MonthEnd,
                    surrogateModel.SiteId);
            });
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_DQIDataSet.spRepHumDataQualityIndicators,
                surrogateModel.Mode,
                new[] {"strRegion", "strRayon", "strDiagnosis"});

            //  m_DQIDataSet.spRepHumDataQualityIndicators.DefaultView.Sort = "intRegionOrder, strRegion, strRayon, strDiagnosis";
            return m_DQIDataSet.spRepHumDataQualityIndicators;
        }

        private void BindHeaderLabel(DataQualityIndicatorsSurrogateModel model)
        {
            if (!model.Month.HasValue || !model.MonthEnd.HasValue || (model.Month.Value == 1 && model.MonthEnd.Value == 12))
            {
                HeaderPeriodLabel.Text = model.Year.ToString();
            }
            else
            {
                HeaderPeriodLabel.Text = model.Month.Value == model.MonthEnd.Value
                    ? string.Format("{0}, {1}", model.Year, FilterHelper.GetMonthName(model.Month.Value))
                    : string.Format("{0}, {1} - {2}", model.Year, FilterHelper.GetMonthName(model.Month.Value), FilterHelper.GetMonthName(model.MonthEnd.Value));
            }

            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            FirstDateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);
            SecondDateTimeCell.Text = rebinder.ToDateTimeString(DateTime.Now);
        }

       

        protected virtual void BindSummaryAvarage(DQIDataSet.spRepHumDataQualityIndicatorsRow resultRow)
        {
        }

        protected virtual void BindSummaryMax(DQIDataSet.spRepHumDataQualityIndicatorsRow row)
        {
        }

        protected virtual Dictionary<string, double> ConvertSecondChartData(DQIDataSet.spRepHumDataQualityIndicatorsRow maxRow, DQIDataSet.spRepHumDataQualityIndicatorsRow averageRow)
        {
            return new Dictionary<string, double>();
        }

        protected virtual bool HideDiagnosisIfEmpty(string[] checkedDiagnosis)
        {
            bool hide = checkedDiagnosis == null || checkedDiagnosis.Length == 0;
            if (hide)
            {
                DynamicTopTableRow.Cells.Remove(DiagnosisHeaderCell);
                DetailDynamicTableRow.Cells.Remove(DiagnosisDetailCell);
                MaximumDynamicRow.Cells.Remove(DiagnosisMaxCell);
                TotalDynamicRow.Cells.Remove(DiagnosisTotalCell);
            }
            return hide;
        }

        protected virtual void AjustPadding()
        {
        }


        #region ChartProcessing

        private void FillFirstChartDataSource(DQIDataSet.spRepHumDataQualityIndicatorsDataTable dataSource, bool arrangeRayons)
        {
            DataRowCollection chartRows = m_DQIChartDataSet.FirstChartData.Rows;

            DataView rayonView = dataSource.DefaultView.ToTable(true, "idfsRayon").DefaultView;
            rayonView.RowFilter = "idfsRayon > 0";
            foreach (DataRowView rayonRow in rayonView)
            {
                string rayon = Utils.Str(rayonRow[0]);
                DataRow[] rows = dataSource.Select("idfsRayon = " + rayon);
                if (rows.Length > 0)
                {
                    double sum = 0;
                    int count = 0;
                    foreach (DQIDataSet.spRepHumDataQualityIndicatorsRow row in rows)
                    {
                        if (!row.IsdblSummaryScoreByIndicatorsNull() && row.dblSummaryScoreByIndicators > 0)
                        {
                            sum += row.dblSummaryScoreByIndicators;
                            count++;
                        }
                    }
                    double avg = count == 0 ? 0 : sum / count;
                    if (avg > 0)
                    {
                        var firstRow = (DQIDataSet.spRepHumDataQualityIndicatorsRow) rows[0];
                        DQIChartDataSet.FirstChartDataRow chartRow = m_DQIChartDataSet.FirstChartData.NewFirstChartDataRow();
                        chartRow.RegionOrder = firstRow.IsintRegionOrderNull()
                            ? 0
                            : firstRow.intRegionOrder;
                        chartRow.RegionName = firstRow.strRegion;
                        chartRow.RayonName = firstRow.strRayon;
                        chartRow.AZRayonName = firstRow.strAZRayon;
                        chartRow.Value = avg;

                        chartRows.Add(chartRow);
                    }
                }
            }

            if (chartRows.Count > 0)
            {
                double avg = chartRows.Cast<DQIChartDataSet.FirstChartDataRow>().Sum(row => row.Value) / chartRows.Count;
                foreach (DQIChartDataSet.FirstChartDataRow row in chartRows)
                {
                    row.AverageValue = avg;
                }
            }

            m_DQIChartDataSet.FirstChartData.DefaultView.Sort = arrangeRayons
                ? "RegionOrder, RegionName, AZRayonName"
                : "RegionOrder, RegionName, Value desc, RayonName";
        }

        private void FillSecondChartDataSource(Dictionary<string, double> secondChartData)
        {
            foreach (KeyValuePair<string, double> pair in secondChartData)
            {
                DQIChartDataSet.SecondChartDataRow chartRow = m_DQIChartDataSet.SecondChartData.NewSecondChartDataRow();
                string name = pair.Key;
                while (name.Contains("  "))
                {
                    name = name.Replace("  ", " ");
                }
                chartRow.IndicatorName = name;
                chartRow.IndicatorValue = pair.Value;
                m_DQIChartDataSet.SecondChartData.AddSecondChartDataRow(chartRow);
            }
            if (secondChartData.Count == 0)
            {
                SecondSignatureTable.Visible = false;
                xrChart2.Visible = false;
                ReportFooter.Height = xrChart1.Height;
            }
            else
            {
                FirstSignatureTable.Visible = false;
            }
        }

        #endregion

        #region Before and after print handlers

        protected void RegionDetailCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRegionPrint)
            {
                RegionDetailCell.Text = string.Empty;
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRegionPrint = false;
        }

        protected void RayonDetailCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRayonPrint)
            {
                RayonDetailCell.Text = string.Empty;
                RayonDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RayonDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRayonPrint = false;
        }

        protected void GroupFooterRegion_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRegionPrint = true;
        }

        protected void GroupHeaderRayon_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRayonPrint = true;
        }

        private void MaximumDynamicTable_AfterPrint(object sender, EventArgs e)
        {
            m_DQIDataSet.spRepHumDataQualityIndicators.DefaultView.RowFilter = "idfsRegion > 0";
        }

        #endregion

        #region Calculate max and average

        protected static DQIDataSet.spRepHumDataQualityIndicatorsRow CalculateAverage
            (DQIDataSet.spRepHumDataQualityIndicatorsDataTable source)
        {
            DQIDataSet.spRepHumDataQualityIndicatorsRow resultRow = source.NewspRepHumDataQualityIndicatorsRow();
            SetNullRowIndicatorsSummary(resultRow);

            DataView diagnosisView = source.DefaultView.ToTable(true, "idfsDiagnosis").DefaultView;
            diagnosisView.RowFilter = "idfsDiagnosis > 0";
            if (diagnosisView.Count == 0)
            {
                if (source.Count == 0)
                {
                    return resultRow;
                }
                foreach (DQIDataSet.spRepHumDataQualityIndicatorsRow row in source)
                {
                    // ignore first row that contains max indicators 
                    if (!row.IsidfsRegionNull() && row.idfsRegion > 0)
                    {
                        AddRowIndicatorsSummary(resultRow, row);
                    }
                }
                CalculateRowIndicatorsSummary(resultRow);
                return resultRow;
            }

            foreach (DataRowView diagnosisRow in diagnosisView)
            {
                string diagnosis = Utils.Str(diagnosisRow[0]);
                DataRow[] rows = source.Select("idfsDiagnosis = " + diagnosis);
                if (rows.Length > 0)
                {
                    var firstRow = (DQIDataSet.spRepHumDataQualityIndicatorsRow) rows[0];
                    SetNullRowIndicatorsSummary(firstRow);
                    foreach (DQIDataSet.spRepHumDataQualityIndicatorsRow row in rows)
                    {
                        AddRowIndicatorsSummary(firstRow, row);
                    }
                    CalculateRowIndicatorsSummary(firstRow);

                    DQIDataSet.spRepHumDataQualityIndicatorsRow temp = source.NewspRepHumDataQualityIndicatorsRow();
                    SetNullRowIndicatorsSummary(temp);
                    CopyRowIndicatorsSummaryToOrdinalIndicators(firstRow, temp);
                    AddRowIndicatorsSummary(resultRow, temp);
                }
            }
            CalculateRowIndicatorsSummary(resultRow);

            return resultRow;
        }

        private static void SetNullRowIndicatorsSummary(DQIDataSet.spRepHumDataQualityIndicatorsRow row)
        {
            row.dbl_AVG__1_NotificationAVG = row.dbl_N__1_NotificationAVG = 0;
            row.dbl_AVG_CaseStatus = row.dbl_N_CaseStatus = 0;
            row.dbl_AVG_DateOfCompletionOfPaperForm = row.dbl_N_DateOfCompletionOfPaperForm = 0;
            row.dbl_AVG_NameOfEmployer = row.dbl_N_NameOfEmployer = 0;
            row.dbl_AVG_CurrentLocationOfPatient = row.dbl_N_CurrentLocationOfPatient = 0;
            row.dbl_AVG_NotificationDateTime = row.dbl_N_NotificationDateTime = 0;
            row.dbl_AVG_dblNotificationSentByName = row.dbl_N_dblNotificationSentByName = 0;
            row.dbl_AVG_NotificationReceivedByFacility = row.dbl_N_NotificationReceivedByFacility = 0;
            row.dbl_AVG_NotificationReceivedByName = row.dbl_N_NotificationReceivedByName = 0;
            row.dbl_AVG_TimelinessofDataEntry = row.dbl_N_TimelinessofDataEntry = 0;
            row.dbl_AVG__2_CaseInvestigation = row.dbl_N__2_CaseInvestigation = 0;
            row.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation =
                row.dbl_N_DemographicInformationStartingDateTimeOfInvestigation = 0;
            row.dbl_AVG_DemographicInformationOccupation = row.dbl_N_DemographicInformationOccupation = 0;
            row.dbl_AVG_ClinicalInformationInitialCaseClassification = row.dbl_N_ClinicalInformationInitialCaseClassification = 0;
            row.dbl_AVG_ClinicalInformationLocationOfExposure = row.dbl_N_ClinicalInformationLocationOfExposure = 0;
            row.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy = row.dbl_N_ClinicalInformationAntibioticAntiviralTherapy = 0;
            row.dbl_AVG_SamplesCollectionSamplesCollected = row.dbl_N_SamplesCollectionSamplesCollected = 0;
            row.dbl_AVG_ContactListAddContact = row.dbl_N_ContactListAddContact = 0;
            row.dbl_AVG_CaseClassificationClinicalSigns = row.dbl_N_CaseClassificationClinicalSigns = 0;
            row.dbl_AVG_EpidemiologicalLinksAndRiskFactors = row.dbl_N_EpidemiologicalLinksAndRiskFactors = 0;
            row.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis = row.dbl_N_FinalCaseClassificationDateOfFinalDiagnosis = 0;
            row.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis = row.dbl_N_FinalCaseClassificationBasisOfDiagnosis = 0;
            row.dbl_AVG_FinalCaseClassificationOutcome = row.dbl_N_FinalCaseClassificationOutcome = 0;
            row.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak = row.dbl_N_FinalCaseClassificationIsThisCaseOutbreak = 0;
            row.dbl_AVG_FinalCaseClassificationEpidemiologistName = row.dbl_N_FinalCaseClassificationEpidemiologistName = 0;
            row.dbl_AVG__3_TheResultsOfLaboratoryTests = row.dbl_N__3_TheResultsOfLaboratoryTests = 0;
            row.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted = row.dbl_N_TheResultsOfLaboratoryTestsTestsConducted = 0;
            row.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation = row.dbl_N_TheResultsOfLaboratoryTestsResultObservation = 0;
            row.dbl_AVG_SummaryScoreByIndicators = row.dbl_N_SummaryScoreByIndicators = 0;
        }

        private static void AddRowIndicatorsSummary
            (DQIDataSet.spRepHumDataQualityIndicatorsRow summaryRow, DQIDataSet.spRepHumDataQualityIndicatorsRow row)
        {
            if (!row.Isdbl_1_NotificationNull() && row.dbl_1_Notification > 0)
            {
                summaryRow.dbl_AVG__1_NotificationAVG += row.dbl_1_Notification;
                summaryRow.dbl_N__1_NotificationAVG++;
            }
            if (!row.IsdblCaseStatusNull() && row.dblCaseStatus > 0)
            {
                summaryRow.dbl_AVG_CaseStatus += row.dblCaseStatus;
                summaryRow.dbl_N_CaseStatus++;
            }
            if (!row.IsdblDateOfCompletionOfPaperFormNull() && row.dblDateOfCompletionOfPaperForm > 0)
            {
                summaryRow.dbl_AVG_DateOfCompletionOfPaperForm += row.dblDateOfCompletionOfPaperForm;
                summaryRow.dbl_N_DateOfCompletionOfPaperForm++;
            }
            if (!row.IsdblNameOfEmployerNull() && row.dblNameOfEmployer > 0)
            {
                summaryRow.dbl_AVG_NameOfEmployer += row.dblNameOfEmployer;
                summaryRow.dbl_N_NameOfEmployer++;
            }
            if (!row.IsdblCurrentLocationOfPatientNull() && row.dblCurrentLocationOfPatient > 0)
            {
                summaryRow.dbl_AVG_CurrentLocationOfPatient += row.dblCurrentLocationOfPatient;
                summaryRow.dbl_N_CurrentLocationOfPatient++;
            }
            if (!row.IsdblNotificationDateTimeNull() && row.dblNotificationDateTime > 0)
            {
                summaryRow.dbl_AVG_NotificationDateTime += row.dblNotificationDateTime;
                summaryRow.dbl_N_NotificationDateTime++;
            }
            if (!row.IsdbldblNotificationSentByNameNull() && row.dbldblNotificationSentByName > 0)
            {
                summaryRow.dbl_AVG_dblNotificationSentByName += row.dbldblNotificationSentByName;
                summaryRow.dbl_N_dblNotificationSentByName++;
            }
            if (!row.IsdblNotificationReceivedByFacilityNull() && row.dblNotificationReceivedByFacility > 0)
            {
                summaryRow.dbl_AVG_NotificationReceivedByFacility += row.dblNotificationReceivedByFacility;
                summaryRow.dbl_N_NotificationReceivedByFacility++;
            }
            if (!row.IsdblNotificationReceivedByNameNull() && row.dblNotificationReceivedByName > 0)
            {
                summaryRow.dbl_AVG_NotificationReceivedByName += row.dblNotificationReceivedByName;
                summaryRow.dbl_N_NotificationReceivedByName++;
            }
            if (!row.IsdblTimelinessofDataEntryNull() && row.dblTimelinessofDataEntry > 0)
            {
                summaryRow.dbl_AVG_TimelinessofDataEntry += row.dblTimelinessofDataEntry;
                summaryRow.dbl_N_TimelinessofDataEntry++;
            }
            if (!row.Isdbl_2_CaseInvestigationNull() && row.dbl_2_CaseInvestigation > 0)
            {
                summaryRow.dbl_AVG__2_CaseInvestigation += row.dbl_2_CaseInvestigation;
                summaryRow.dbl_N__2_CaseInvestigation++;
            }
            if (!row.IsdblDemographicInformationStartingDateTimeOfInvestigationNull() &&
                row.dblDemographicInformationStartingDateTimeOfInvestigation > 0)
            {
                summaryRow.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation +=
                    row.dblDemographicInformationStartingDateTimeOfInvestigation;
                summaryRow.dbl_N_DemographicInformationStartingDateTimeOfInvestigation++;
            }
            if (!row.IsdblDemographicInformationOccupationNull() && row.dblDemographicInformationOccupation > 0)
            {
                summaryRow.dbl_AVG_DemographicInformationOccupation += row.dblDemographicInformationOccupation;
                summaryRow.dbl_N_DemographicInformationOccupation++;
            }
            if (!row.IsdblClinicalInformationInitialCaseClassificationNull() && row.dblClinicalInformationInitialCaseClassification > 0)
            {
                summaryRow.dbl_AVG_ClinicalInformationInitialCaseClassification += row.dblClinicalInformationInitialCaseClassification;
                summaryRow.dbl_N_ClinicalInformationInitialCaseClassification++;
            }
            if (!row.IsdblClinicalInformationLocationOfExposureNull() && row.dblClinicalInformationLocationOfExposure > 0)
            {
                summaryRow.dbl_AVG_ClinicalInformationLocationOfExposure += row.dblClinicalInformationLocationOfExposure;
                summaryRow.dbl_N_ClinicalInformationLocationOfExposure++;
            }
            if (!row.IsdblClinicalInformationAntibioticAntiviralTherapyNull() && row.dblClinicalInformationAntibioticAntiviralTherapy > 0)
            {
                summaryRow.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy += row.dblClinicalInformationAntibioticAntiviralTherapy;
                summaryRow.dbl_N_ClinicalInformationAntibioticAntiviralTherapy++;
            }
            if (!row.IsdblSamplesCollectionSamplesCollectedNull() && row.dblSamplesCollectionSamplesCollected > 0)
            {
                summaryRow.dbl_AVG_SamplesCollectionSamplesCollected += row.dblSamplesCollectionSamplesCollected;
                summaryRow.dbl_N_SamplesCollectionSamplesCollected++;
            }
            if (!row.IsdblContactListAddContactNull() && row.dblContactListAddContact > 0)
            {
                summaryRow.dbl_AVG_ContactListAddContact += row.dblContactListAddContact;
                summaryRow.dbl_N_ContactListAddContact++;
            }
            if (!row.IsdblCaseClassificationClinicalSignsNull() && row.dblCaseClassificationClinicalSigns > 0)
            {
                summaryRow.dbl_AVG_CaseClassificationClinicalSigns += row.dblCaseClassificationClinicalSigns;
                summaryRow.dbl_N_CaseClassificationClinicalSigns++;
            }
            if (!row.IsdblEpidemiologicalLinksAndRiskFactorsNull() && row.dblEpidemiologicalLinksAndRiskFactors > 0)
            {
                summaryRow.dbl_AVG_EpidemiologicalLinksAndRiskFactors += row.dblEpidemiologicalLinksAndRiskFactors;
                summaryRow.dbl_N_EpidemiologicalLinksAndRiskFactors++;
            }
            if (!row.IsdblFinalCaseClassificationDateOfFinalDiagnosisNull() && row.dblFinalCaseClassificationDateOfFinalDiagnosis > 0)
            {
                summaryRow.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis += row.dblFinalCaseClassificationDateOfFinalDiagnosis;
                summaryRow.dbl_N_FinalCaseClassificationDateOfFinalDiagnosis++;
            }
            if (!row.IsdblFinalCaseClassificationBasisOfDiagnosisNull() && row.dblFinalCaseClassificationBasisOfDiagnosis > 0)
            {
                summaryRow.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis += row.dblFinalCaseClassificationBasisOfDiagnosis;
                summaryRow.dbl_N_FinalCaseClassificationBasisOfDiagnosis++;
            }
            if (!row.IsdblFinalCaseClassificationOutcomeNull() && row.dblFinalCaseClassificationOutcome > 0)
            {
                summaryRow.dbl_AVG_FinalCaseClassificationOutcome += row.dblFinalCaseClassificationOutcome;
                summaryRow.dbl_N_FinalCaseClassificationOutcome++;
            }
            if (!row.IsdblFinalCaseClassificationIsThisCaseOutbreakNull() && row.dblFinalCaseClassificationIsThisCaseOutbreak > 0)
            {
                summaryRow.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak += row.dblFinalCaseClassificationIsThisCaseOutbreak;
                summaryRow.dbl_N_FinalCaseClassificationIsThisCaseOutbreak++;
            }
            if (!row.IsdblFinalCaseClassificationEpidemiologistNameNull() && row.dblFinalCaseClassificationEpidemiologistName > 0)
            {
                summaryRow.dbl_AVG_FinalCaseClassificationEpidemiologistName += row.dblFinalCaseClassificationEpidemiologistName;
                summaryRow.dbl_N_FinalCaseClassificationEpidemiologistName++;
            }
            if (!row.Isdbl_3_TheResultsOfLaboratoryTestsNull() && row.dbl_3_TheResultsOfLaboratoryTests > 0)
            {
                summaryRow.dbl_AVG__3_TheResultsOfLaboratoryTests += row.dbl_3_TheResultsOfLaboratoryTests;
                summaryRow.dbl_N__3_TheResultsOfLaboratoryTests++;
            }
            if (!row.IsdblTheResultsOfLaboratoryTestsTestsConductedNull() && row.dblTheResultsOfLaboratoryTestsTestsConducted > 0)
            {
                summaryRow.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted += row.dblTheResultsOfLaboratoryTestsTestsConducted;
                summaryRow.dbl_N_TheResultsOfLaboratoryTestsTestsConducted++;
            }
            if (!row.IsdblTheResultsOfLaboratoryTestsResultObservationNull() && row.dblTheResultsOfLaboratoryTestsResultObservation > 0)
            {
                summaryRow.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation += row.dblTheResultsOfLaboratoryTestsResultObservation;
                summaryRow.dbl_N_TheResultsOfLaboratoryTestsResultObservation++;
            }
            if (!row.IsdblSummaryScoreByIndicatorsNull() && row.dblSummaryScoreByIndicators > 0)
            {
                summaryRow.dbl_AVG_SummaryScoreByIndicators += row.dblSummaryScoreByIndicators;
                summaryRow.dbl_N_SummaryScoreByIndicators++;
            }
        }

        private static void CalculateRowIndicatorsSummary(DQIDataSet.spRepHumDataQualityIndicatorsRow row)
        {
            if (row.dbl_N__1_NotificationAVG > 0)
            {
                row.dbl_AVG__1_NotificationAVG /= row.dbl_N__1_NotificationAVG;
            }
            if (row.dbl_N_CaseStatus > 0)
            {
                row.dbl_AVG_CaseStatus /= row.dbl_N_CaseStatus;
            }
            if (row.dbl_N_DateOfCompletionOfPaperForm > 0)
            {
                row.dbl_AVG_DateOfCompletionOfPaperForm /= row.dbl_N_DateOfCompletionOfPaperForm;
            }
            if (row.dbl_N_NameOfEmployer > 0)
            {
                row.dbl_AVG_NameOfEmployer /= row.dbl_N_NameOfEmployer;
            }
            if (row.dbl_N_CurrentLocationOfPatient > 0)
            {
                row.dbl_AVG_CurrentLocationOfPatient /= row.dbl_N_CurrentLocationOfPatient;
            }
            if (row.dbl_N_NotificationDateTime > 0)
            {
                row.dbl_AVG_NotificationDateTime /= row.dbl_N_NotificationDateTime;
            }
            if (row.dbl_N_dblNotificationSentByName > 0)
            {
                row.dbl_AVG_dblNotificationSentByName /= row.dbl_N_dblNotificationSentByName;
            }
            if (row.dbl_N_NotificationReceivedByFacility > 0)
            {
                row.dbl_AVG_NotificationReceivedByFacility /= row.dbl_N_NotificationReceivedByFacility;
            }
            if (row.dbl_N_NotificationReceivedByName > 0)
            {
                row.dbl_AVG_NotificationReceivedByName /= row.dbl_N_NotificationReceivedByName;
            }
            if (row.dbl_N_TimelinessofDataEntry > 0)
            {
                row.dbl_AVG_TimelinessofDataEntry /= row.dbl_N_TimelinessofDataEntry;
            }
            if (row.dbl_N__2_CaseInvestigation > 0)
            {
                row.dbl_AVG__2_CaseInvestigation /= row.dbl_N__2_CaseInvestigation;
            }
            if (row.dbl_N_DemographicInformationStartingDateTimeOfInvestigation > 0)
            {
                row.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation /=
                    row.dbl_N_DemographicInformationStartingDateTimeOfInvestigation;
            }
            if (row.dbl_N_DemographicInformationOccupation > 0)
            {
                row.dbl_AVG_DemographicInformationOccupation /= row.dbl_N_DemographicInformationOccupation;
            }
            if (row.dbl_N_ClinicalInformationInitialCaseClassification > 0)
            {
                row.dbl_AVG_ClinicalInformationInitialCaseClassification /= row.dbl_N_ClinicalInformationInitialCaseClassification;
            }
            if (row.dbl_N_ClinicalInformationLocationOfExposure > 0)
            {
                row.dbl_AVG_ClinicalInformationLocationOfExposure /= row.dbl_N_ClinicalInformationLocationOfExposure;
            }
            if (row.dbl_N_ClinicalInformationAntibioticAntiviralTherapy > 0)
            {
                row.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy /= row.dbl_N_ClinicalInformationAntibioticAntiviralTherapy;
            }
            if (row.dbl_N_SamplesCollectionSamplesCollected > 0)
            {
                row.dbl_AVG_SamplesCollectionSamplesCollected /= row.dbl_N_SamplesCollectionSamplesCollected;
            }
            if (row.dbl_N_ContactListAddContact > 0)
            {
                row.dbl_AVG_ContactListAddContact /= row.dbl_N_ContactListAddContact;
            }
            if (row.dbl_N_CaseClassificationClinicalSigns > 0)
            {
                row.dbl_AVG_CaseClassificationClinicalSigns /= row.dbl_N_CaseClassificationClinicalSigns;
            }
            if (row.dbl_N_EpidemiologicalLinksAndRiskFactors > 0)
            {
                row.dbl_AVG_EpidemiologicalLinksAndRiskFactors /= row.dbl_N_EpidemiologicalLinksAndRiskFactors;
            }
            if (row.dbl_N_FinalCaseClassificationDateOfFinalDiagnosis > 0)
            {
                row.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis /= row.dbl_N_FinalCaseClassificationDateOfFinalDiagnosis;
            }
            if (row.dbl_N_FinalCaseClassificationBasisOfDiagnosis > 0)
            {
                row.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis /= row.dbl_N_FinalCaseClassificationBasisOfDiagnosis;
            }
            if (row.dbl_N_FinalCaseClassificationOutcome > 0)
            {
                row.dbl_AVG_FinalCaseClassificationOutcome /= row.dbl_N_FinalCaseClassificationOutcome;
            }
            if (row.dbl_N_FinalCaseClassificationIsThisCaseOutbreak > 0)
            {
                row.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak /= row.dbl_N_FinalCaseClassificationIsThisCaseOutbreak;
            }
            if (row.dbl_N_FinalCaseClassificationEpidemiologistName > 0)
            {
                row.dbl_AVG_FinalCaseClassificationEpidemiologistName /= row.dbl_N_FinalCaseClassificationEpidemiologistName;
            }
            if (row.dbl_N__3_TheResultsOfLaboratoryTests > 0)
            {
                row.dbl_AVG__3_TheResultsOfLaboratoryTests /= row.dbl_N__3_TheResultsOfLaboratoryTests;
            }
            if (row.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted > 0)
            {
                row.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted /= row.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted;
            }
            if (row.dbl_N_TheResultsOfLaboratoryTestsResultObservation > 0)
            {
                row.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation /= row.dbl_N_TheResultsOfLaboratoryTestsResultObservation;
            }
            if (row.dbl_N_SummaryScoreByIndicators > 0)
            {
                row.dbl_AVG_SummaryScoreByIndicators /= row.dbl_N_SummaryScoreByIndicators;
            }
        }

        private static void CopyRowIndicatorsSummaryToOrdinalIndicators
            (DQIDataSet.spRepHumDataQualityIndicatorsRow source, DQIDataSet.spRepHumDataQualityIndicatorsRow dest)
        {
            dest.dbl_1_Notification = source.dbl_AVG__1_NotificationAVG;
            dest.dblCaseStatus = source.dbl_AVG_CaseStatus;
            dest.dblDateOfCompletionOfPaperForm = source.dbl_AVG_DateOfCompletionOfPaperForm;
            dest.dblNameOfEmployer = source.dbl_AVG_NameOfEmployer;
            dest.dblCurrentLocationOfPatient = source.dbl_AVG_CurrentLocationOfPatient;
            dest.dblNotificationDateTime = source.dbl_AVG_NotificationDateTime;
            dest.dbldblNotificationSentByName = source.dbl_AVG_dblNotificationSentByName;
            dest.dblNotificationReceivedByFacility = source.dbl_AVG_NotificationReceivedByFacility;
            dest.dblNotificationReceivedByName = source.dbl_AVG_NotificationReceivedByName;
            dest.dblTimelinessofDataEntry = source.dbl_AVG_TimelinessofDataEntry;
            dest.dbl_2_CaseInvestigation = source.dbl_AVG__2_CaseInvestigation;
            dest.dblDemographicInformationStartingDateTimeOfInvestigation =
                source.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation;
            dest.dblDemographicInformationOccupation = source.dbl_AVG_DemographicInformationOccupation;
            dest.dblClinicalInformationInitialCaseClassification = source.dbl_AVG_ClinicalInformationInitialCaseClassification;
            dest.dblClinicalInformationLocationOfExposure = source.dbl_AVG_ClinicalInformationLocationOfExposure;
            dest.dblClinicalInformationAntibioticAntiviralTherapy = source.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy;
            dest.dblSamplesCollectionSamplesCollected = source.dbl_AVG_SamplesCollectionSamplesCollected;
            dest.dblContactListAddContact = source.dbl_AVG_ContactListAddContact;
            dest.dblCaseClassificationClinicalSigns = source.dbl_AVG_CaseClassificationClinicalSigns;
            dest.dblEpidemiologicalLinksAndRiskFactors = source.dbl_AVG_EpidemiologicalLinksAndRiskFactors;
            dest.dblFinalCaseClassificationDateOfFinalDiagnosis = source.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis;
            dest.dblFinalCaseClassificationBasisOfDiagnosis = source.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis;
            dest.dblFinalCaseClassificationOutcome = source.dbl_AVG_FinalCaseClassificationOutcome;
            dest.dblFinalCaseClassificationIsThisCaseOutbreak = source.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak;
            dest.dblFinalCaseClassificationEpidemiologistName = source.dbl_AVG_FinalCaseClassificationEpidemiologistName;
            dest.dbl_3_TheResultsOfLaboratoryTests = source.dbl_AVG__3_TheResultsOfLaboratoryTests;
            dest.dblTheResultsOfLaboratoryTestsTestsConducted = source.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted;
            dest.dblTheResultsOfLaboratoryTestsResultObservation = source.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation;
            dest.dblSummaryScoreByIndicators = source.dbl_AVG_SummaryScoreByIndicators;
        }

        #endregion
    }
}