using System;
using System.Collections.Generic;
using bv.common.Core;
using bv.model.Model.Core;
using DevExpress.XtraPrinting;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class DataQualityIndicatorsReport : BaseDataQualityIndicatorsReport
    {
        public DataQualityIndicatorsReport()
        {
            InitializeComponent();
        }

        protected override void BindSummaryAvarage(DQIDataSet.spRepHumDataQualityIndicatorsRow resultRow)
        {
            _1_NotificationAVGCell.Text = resultRow.dbl_AVG__1_NotificationAVG.ToString(DoubleFormat);
            CaseStatusCell.Text = resultRow.dbl_AVG_CaseStatus.ToString(DoubleFormat);
            DateOfCompletionOfPaperFormCell.Text = resultRow.dbl_AVG_DateOfCompletionOfPaperForm.ToString(DoubleFormat);
            NameOfEmployerCell.Text = resultRow.dbl_AVG_NameOfEmployer.ToString(DoubleFormat);
            CurrentLocationOfPatientCell.Text = resultRow.dbl_AVG_CurrentLocationOfPatient.ToString(DoubleFormat);
            NotificationDateTimeCell.Text = resultRow.dbl_AVG_NotificationDateTime.ToString(DoubleFormat);
            NotificationSentByNameCell.Text = resultRow.dbl_AVG_NotificationReceivedByName.ToString(DoubleFormat);
            NotificationReceivedByFacilityCell.Text = resultRow.dbl_AVG_NotificationReceivedByFacility.ToString(DoubleFormat);
            NotificationReceivedByNameCell.Text = resultRow.dbl_AVG_NotificationReceivedByName.ToString(DoubleFormat);
            TimelinessofDataEntryCell.Text = resultRow.dbl_AVG_TimelinessofDataEntry.ToString(DoubleFormat);
            _2_CaseInvestigationCell.Text = resultRow.dbl_AVG__2_CaseInvestigation.ToString(DoubleFormat);
            DemographicInformationStartingDateTimeOfInvestigationCell.Text =
                resultRow.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation.ToString(DoubleFormat);
            DemographicInformationOccupationCell.Text = resultRow.dbl_AVG_DemographicInformationOccupation.ToString(DoubleFormat);
            ClinicalInformationInitialCaseClassificationCell.Text =
                resultRow.dbl_AVG_ClinicalInformationInitialCaseClassification.ToString(DoubleFormat);
            ClinicalInformationLocationOfExposureCell.Text = resultRow.dbl_AVG_ClinicalInformationLocationOfExposure.ToString(DoubleFormat);
            ClinicalInformationAntibioticAntiviralTherapyCell.Text =
                resultRow.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy.ToString(DoubleFormat);
            SamplesCollectionSamplesCollectedCell.Text = resultRow.dbl_AVG_SamplesCollectionSamplesCollected.ToString(DoubleFormat);
            ContactListAddContactCell.Text = resultRow.dbl_AVG_ContactListAddContact.ToString(DoubleFormat);
            CaseClassificationClinicalSignsCell.Text = resultRow.dbl_AVG_CaseClassificationClinicalSigns.ToString(DoubleFormat);
            EpidemiologicalLinksAndRiskFactorsCell.Text = resultRow.dbl_AVG_EpidemiologicalLinksAndRiskFactors.ToString(DoubleFormat);
            FinalCaseClassificationDateOfFinalDiagnosisCell.Text =
                resultRow.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis.ToString(DoubleFormat);
            FinalCaseClassificationBasisOfDiagnosisCell.Text =
                resultRow.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis.ToString(DoubleFormat);
            FinalCaseClassificationOutcomeCell.Text = resultRow.dbl_AVG_FinalCaseClassificationOutcome.ToString(DoubleFormat);
            FinalCaseClassificationIsThisCaseOutbreakCell.Text =
                resultRow.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak.ToString(DoubleFormat);
            FinalCaseClassificationEpidemiologistNameCell.Text =
                resultRow.dbl_AVG_FinalCaseClassificationEpidemiologistName.ToString(DoubleFormat);
            _3_TheResultsOfLaboratoryTestsCell.Text = resultRow.dbl_AVG__3_TheResultsOfLaboratoryTests.ToString(DoubleFormat);
            TheResultsOfLaboratoryTestsTestsConductedCell.Text =
                resultRow.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted.ToString(DoubleFormat);
            TheResultsOfLaboratoryTestsResultObservationCell.Text =
                resultRow.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation.ToString(DoubleFormat);
            SummaryScoreByIndicators.Text = resultRow.dbl_AVG_SummaryScoreByIndicators.ToString(DoubleFormat);
        }

        protected override void BindSummaryMax(DQIDataSet.spRepHumDataQualityIndicatorsRow row)
        {
            if (!row.Isdbl_1_NotificationNull())
            {
                _1_NotificationMaxCell.Text = row.dbl_1_Notification.ToString(DoubleFormat);
            }
            if (!row.IsdblCaseStatusNull())
            {
                CaseStatusMaxCell.Text = row.dblCaseStatus.ToString(DoubleFormat);
            }
            if (!row.IsdblDateOfCompletionOfPaperFormNull())
            {
                DateOfCompletionOfPaperFormMaxCell.Text = row.dblDateOfCompletionOfPaperForm.ToString(DoubleFormat);
            }
            if (!row.IsdblNameOfEmployerNull())
            {
                NameOfEmployerMaxCell.Text = row.dblNameOfEmployer.ToString(DoubleFormat);
            }
            if (!row.IsdblCurrentLocationOfPatientNull())
            {
                CurrentLocationOfPatientMaxCell.Text = row.dblCurrentLocationOfPatient.ToString(DoubleFormat);
            }
            if (!row.IsdblNotificationDateTimeNull())
            {
                NotificationDateTimeMaxCell.Text = row.dblNotificationDateTime.ToString(DoubleFormat);
            }
            if (!row.IsdbldblNotificationSentByNameNull())
            {
                NotificationSentByNameMaxCell.Text = row.dbldblNotificationSentByName.ToString(DoubleFormat);
            }
            if (!row.IsdblNotificationReceivedByFacilityNull())
            {
                NotificationReceivedByFacilityMaxCell.Text = row.dblNotificationReceivedByFacility.ToString(DoubleFormat);
            }
            if (!row.IsdblNotificationReceivedByNameNull())
            {
                NotificationReceivedByNameMaxCell.Text = row.dblNotificationReceivedByName.ToString(DoubleFormat);
            }
            if (!row.IsdblTimelinessofDataEntryNull())
            {
                TimelinessofDataEntryMaxCell.Text = row.dblTimelinessofDataEntry.ToString(DoubleFormat);
            }
            if (!row.Isdbl_2_CaseInvestigationNull())
            {
                _2_CaseInvestigationMaxCell.Text = row.dbl_2_CaseInvestigation.ToString(DoubleFormat);
            }
            if (!row.IsdblDemographicInformationStartingDateTimeOfInvestigationNull())
            {
                DemographicInformationStartingDateTimeOfInvestigationMaxCell.Text =
                    row.dblDemographicInformationStartingDateTimeOfInvestigation.ToString(DoubleFormat);
            }
            if (!row.IsdblDemographicInformationOccupationNull())
            {
                DemographicInformationOccupationMaxCell.Text = row.dblDemographicInformationOccupation.ToString(DoubleFormat);
            }
            if (!row.IsdblClinicalInformationInitialCaseClassificationNull())
            {
                ClinicalInformationInitialCaseClassificationMaxCell.Text =
                    row.dblClinicalInformationInitialCaseClassification.ToString(DoubleFormat);
            }
            if (!row.IsdblClinicalInformationLocationOfExposureNull())
            {
                ClinicalInformationLocationOfExposureMaxCell.Text = row.dblClinicalInformationLocationOfExposure.ToString(DoubleFormat);
            }
            if (!row.IsdblClinicalInformationAntibioticAntiviralTherapyNull())
            {
                ClinicalInformationAntibioticAntiviralTherapyMaxCell.Text =
                    row.dblClinicalInformationAntibioticAntiviralTherapy.ToString(DoubleFormat);
            }
            if (!row.IsdblSamplesCollectionSamplesCollectedNull())
            {
                SamplesCollectionSamplesCollectedMaxCell.Text = row.dblSamplesCollectionSamplesCollected.ToString(DoubleFormat);
            }
            if (!row.IsdblContactListAddContactNull())
            {
                ContactListAddContactMaxCell.Text = row.dblContactListAddContact.ToString(DoubleFormat);
            }
            if (!row.IsdblCaseClassificationClinicalSignsNull())
            {
                CaseClassificationClinicalSignsMaxCell.Text = row.dblCaseClassificationClinicalSigns.ToString(DoubleFormat);
            }
            if (!row.IsdblEpidemiologicalLinksAndRiskFactorsNull())
            {
                EpidemiologicalLinksAndRiskFactorsMaxCell.Text = row.dblEpidemiologicalLinksAndRiskFactors.ToString(DoubleFormat);
            }
            if (!row.IsdblFinalCaseClassificationDateOfFinalDiagnosisNull())
            {
                FinalCaseClassificationDateOfFinalDiagnosisMaxCell.Text =
                    row.dblFinalCaseClassificationDateOfFinalDiagnosis.ToString(DoubleFormat);
            }
            if (!row.IsdblFinalCaseClassificationBasisOfDiagnosisNull())
            {
                FinalCaseClassificationBasisOfDiagnosisMaxCell.Text = row.dblFinalCaseClassificationBasisOfDiagnosis.ToString(DoubleFormat);
            }
            if (!row.IsdblFinalCaseClassificationOutcomeNull())
            {
                FinalCaseClassificationOutcomeMaxCell.Text = row.dblFinalCaseClassificationOutcome.ToString(DoubleFormat);
            }
            if (!row.IsdblFinalCaseClassificationIsThisCaseOutbreakNull())
            {
                FinalCaseClassificationIsThisCaseOutbreakMaxCell.Text =
                    row.dblFinalCaseClassificationIsThisCaseOutbreak.ToString(DoubleFormat);
            }
            if (!row.IsdblFinalCaseClassificationEpidemiologistNameNull())
            {
                FinalCaseClassificationEpidemiologistNameMaxCell.Text =
                    row.dblFinalCaseClassificationEpidemiologistName.ToString(DoubleFormat);
            }
            if (!row.Isdbl_3_TheResultsOfLaboratoryTestsNull())
            {
                _3_TheResultsOfLaboratoryTestsMaxCell.Text = row.dbl_3_TheResultsOfLaboratoryTests.ToString(DoubleFormat);
            }
            if (!row.IsdblTheResultsOfLaboratoryTestsTestsConductedNull())
            {
                TheResultsOfLaboratoryTestsTestsConductedMaxCell.Text =
                    row.dblTheResultsOfLaboratoryTestsTestsConducted.ToString(DoubleFormat);
            }
            if (!row.IsdblTheResultsOfLaboratoryTestsResultObservationNull())
            {
                TheResultsOfLaboratoryTestsResultObservationMaxCell.Text =
                    row.dblTheResultsOfLaboratoryTestsResultObservation.ToString(DoubleFormat);
            }
            if (!row.IsdblSummaryScoreByIndicatorsNull())
            {
                SummaryScoreByIndicatorsMaxCell.Text = row.dblSummaryScoreByIndicators.ToString(DoubleFormat);
            }
        }

        protected override Dictionary<string, double> ConvertSecondChartData
            (DQIDataSet.spRepHumDataQualityIndicatorsRow maxRow, DQIDataSet.spRepHumDataQualityIndicatorsRow averageRow)

        {
            var result = new Dictionary<string, double>
            {
                {
                    _1_NotificationHeaderCell.Text,
                    maxRow.Isdbl_1_NotificationNull() || Math.Abs(maxRow.dbl_1_Notification) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG__1_NotificationAVG / maxRow.dbl_1_Notification
                },
                {
                    CaseStatusHeaderCell.Text,
                    maxRow.IsdblCaseStatusNull() || Math.Abs(maxRow.dblCaseStatus) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_CaseStatus / maxRow.dblCaseStatus
                },
                {
                    DateOfCompletionOfPaperFormHeaderCell.Text,
                    maxRow.IsdblDateOfCompletionOfPaperFormNull() || Math.Abs(maxRow.dblDateOfCompletionOfPaperForm) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_DateOfCompletionOfPaperForm / maxRow.dblDateOfCompletionOfPaperForm
                },
                {
                    NameOfEmployerHeaderCell.Text,
                    maxRow.IsdblNameOfEmployerNull() || Math.Abs(maxRow.dblNameOfEmployer) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_NameOfEmployer / maxRow.dblNameOfEmployer
                },
                {
                    CurrentLocationOfPatientHeaderCell.Text,
                    maxRow.IsdblCurrentLocationOfPatientNull() || Math.Abs(maxRow.dblCurrentLocationOfPatient) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_CurrentLocationOfPatient / maxRow.dblCurrentLocationOfPatient
                },
                {
                    NotificationDateTimeHeaderCell.Text,
                    maxRow.IsdblNotificationDateTimeNull() || Math.Abs(maxRow.dblNotificationDateTime) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_NotificationDateTime / maxRow.dblNotificationDateTime
                },
                {
                    NotificationSentByNameHeaderCell.Text,
                    maxRow.IsdbldblNotificationSentByNameNull() || Math.Abs(maxRow.dbldblNotificationSentByName) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_dblNotificationSentByName / maxRow.dbldblNotificationSentByName
                },
                {
                    NotificationReceivedByFacilityHeaderCell.Text,
                    maxRow.IsdblNotificationReceivedByFacilityNull() || Math.Abs(maxRow.dblNotificationReceivedByFacility) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_NotificationReceivedByFacility / maxRow.dblNotificationReceivedByFacility
                },
                {
                    NotificationReceivedByNameHeaderCell.Text,
                    maxRow.IsdblNotificationReceivedByNameNull() || Math.Abs(maxRow.dblNotificationReceivedByName) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_NotificationReceivedByName / maxRow.dblNotificationReceivedByName
                },
                {
                    TimelinessofDataEntryHeaderCell.Text,
                    maxRow.IsdblTimelinessofDataEntryNull() || Math.Abs(maxRow.dblTimelinessofDataEntry) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_TimelinessofDataEntry / maxRow.dblTimelinessofDataEntry
                },
                {
                    _2_CaseInvestigationHeaderCell.Text,
                    maxRow.Isdbl_2_CaseInvestigationNull() || Math.Abs(maxRow.dbl_2_CaseInvestigation) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG__2_CaseInvestigation / maxRow.dbl_2_CaseInvestigation
                },
                {
                    DemographicInformationStartingDateTimeOfInvestigationHeaderCell.Text,
                    maxRow.IsdblDemographicInformationStartingDateTimeOfInvestigationNull() ||
                    Math.Abs(maxRow.dblDemographicInformationStartingDateTimeOfInvestigation) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_DemographicInformationStartingDateTimeOfInvestigation /
                          maxRow.dblDemographicInformationStartingDateTimeOfInvestigation
                },
                {
                    DemographicInformationOccupationHeaderCell.Text,
                    maxRow.IsdblDemographicInformationOccupationNull() || Math.Abs(maxRow.dblDemographicInformationOccupation) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_DemographicInformationOccupation / maxRow.dblDemographicInformationOccupation
                },
                {
                    ClinicalInformationInitialCaseClassificationHeaderCell.Text,
                    maxRow.IsdblClinicalInformationInitialCaseClassificationNull() ||
                    Math.Abs(maxRow.dblClinicalInformationInitialCaseClassification) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_ClinicalInformationInitialCaseClassification /
                          maxRow.dblClinicalInformationInitialCaseClassification
                },
                {
                    ClinicalInformationLocationOfExposureHeaderCell.Text,
                    maxRow.IsdblClinicalInformationLocationOfExposureNull() || Math.Abs(maxRow.dblClinicalInformationLocationOfExposure) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_ClinicalInformationLocationOfExposure / maxRow.dblClinicalInformationLocationOfExposure
                },
                {
                    ClinicalInformationAntibioticAntiviralTherapyHeaderCell.Text,
                    maxRow.IsdblClinicalInformationAntibioticAntiviralTherapyNull() ||
                    Math.Abs(maxRow.dblClinicalInformationAntibioticAntiviralTherapy) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_ClinicalInformationAntibioticAntiviralTherapy /
                          maxRow.dblClinicalInformationAntibioticAntiviralTherapy
                },
                {
                    SamplesCollectionSamplesCollectedHeaderCell.Text,
                    maxRow.IsdblSamplesCollectionSamplesCollectedNull() || Math.Abs(maxRow.dblSamplesCollectionSamplesCollected) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_SamplesCollectionSamplesCollected / maxRow.dblSamplesCollectionSamplesCollected
                },
                {
                    ContactListAddContactHeaderCell.Text,
                    maxRow.IsdblContactListAddContactNull() || Math.Abs(maxRow.dblContactListAddContact) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_ContactListAddContact / maxRow.dblContactListAddContact
                },
                {
                    CaseClassificationClinicalSignsHeaderCell.Text,
                    maxRow.IsdblCaseClassificationClinicalSignsNull() || Math.Abs(maxRow.dblCaseClassificationClinicalSigns) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_CaseClassificationClinicalSigns / maxRow.dblCaseClassificationClinicalSigns
                },
                {
                    EpidemiologicalLinksAndRiskFactorsHeaderCell.Text,
                    maxRow.IsdblEpidemiologicalLinksAndRiskFactorsNull() || Math.Abs(maxRow.dblEpidemiologicalLinksAndRiskFactors) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_EpidemiologicalLinksAndRiskFactors / maxRow.dblEpidemiologicalLinksAndRiskFactors
                },
                {
                    FinalCaseClassificationDateOfFinalDiagnosisHeaderCell.Text,
                    maxRow.IsdblFinalCaseClassificationDateOfFinalDiagnosisNull() ||
                    Math.Abs(maxRow.dblFinalCaseClassificationDateOfFinalDiagnosis) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_FinalCaseClassificationDateOfFinalDiagnosis /
                          maxRow.dblFinalCaseClassificationDateOfFinalDiagnosis
                },
                {
                    FinalCaseClassificationBasisOfDiagnosisHeaderCell.Text,
                    maxRow.IsdblFinalCaseClassificationBasisOfDiagnosisNull() || Math.Abs(maxRow.dblFinalCaseClassificationBasisOfDiagnosis) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_FinalCaseClassificationBasisOfDiagnosis / maxRow.dblFinalCaseClassificationBasisOfDiagnosis
                },
                {
                    FinalCaseClassificationOutcomeHeaderCell.Text,
                    maxRow.IsdblFinalCaseClassificationOutcomeNull() || Math.Abs(maxRow.dblFinalCaseClassificationOutcome) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_FinalCaseClassificationOutcome / maxRow.dblFinalCaseClassificationOutcome
                },
                {
                    FinalCaseClassificationIsThisCaseOutbreakHeaderCell.Text,
                    maxRow.IsdblFinalCaseClassificationIsThisCaseOutbreakNull() || Math.Abs(maxRow.dblFinalCaseClassificationIsThisCaseOutbreak) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_FinalCaseClassificationIsThisCaseOutbreak / maxRow.dblFinalCaseClassificationIsThisCaseOutbreak
                },
                {
                    FinalCaseClassificationEpidemiologistNameHeaderCell.Text,
                    maxRow.IsdblFinalCaseClassificationEpidemiologistNameNull() || Math.Abs(maxRow.dblFinalCaseClassificationEpidemiologistName) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_FinalCaseClassificationEpidemiologistName / maxRow.dblFinalCaseClassificationEpidemiologistName
                },
                {
                    _3_TheResultsOfLaboratoryTestsHeaderCell.Text,
                    maxRow.Isdbl_3_TheResultsOfLaboratoryTestsNull() || Math.Abs(maxRow.dbl_3_TheResultsOfLaboratoryTests) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG__3_TheResultsOfLaboratoryTests / maxRow.dbl_3_TheResultsOfLaboratoryTests
                },
                {
                    TheResultsOfLaboratoryTestsTestsConductedHeaderCell.Text,
                    maxRow.IsdblTheResultsOfLaboratoryTestsTestsConductedNull() || Math.Abs(maxRow.dblTheResultsOfLaboratoryTestsTestsConducted) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_TheResultsOfLaboratoryTestsTestsConducted / maxRow.dblTheResultsOfLaboratoryTestsTestsConducted
                },
                {
                    TheResultsOfLaboratoryTestsResultObservationHeaderCell.Text,
                    maxRow.IsdblTheResultsOfLaboratoryTestsResultObservationNull() ||
                    Math.Abs(maxRow.dblTheResultsOfLaboratoryTestsResultObservation) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_TheResultsOfLaboratoryTestsResultObservation /
                          maxRow.dblTheResultsOfLaboratoryTestsResultObservation
                },
                {
                    SummaryScoreByIndicatorsHeaderCell.Text,
                    maxRow.IsdblSummaryScoreByIndicatorsNull() || Math.Abs(maxRow.dblSummaryScoreByIndicators) < 2*double.MinValue
                        ? 0
                        : averageRow.dbl_AVG_SummaryScoreByIndicators / maxRow.dblSummaryScoreByIndicators
                },
            };

            return result;
        }

        protected override void AjustPadding()
        {
            var padding = new PaddingInfo(2, 2, 2, 5);
            if (ModelUserContext.CurrentLanguage == Localizer.lngEn || ModelUserContext.CurrentLanguage == Localizer.lngRu)
            {
                DemographicInformationStartingDateTimeOfInvestigationHeaderCell.Padding = padding;
            }
            if (ModelUserContext.CurrentLanguage == Localizer.lngRu)
            {
                FinalCaseClassificationOutcomeHeaderCell.Padding = padding;
                _2_CaseInvestigationHeaderCell.Padding = padding;
                DemographicInformationOccupationHeaderCell.Padding = padding;
                ClinicalInformationInitialCaseClassificationHeaderCell.Padding = padding;
                ClinicalInformationLocationOfExposureHeaderCell.Padding = padding;
            }
            if (ModelUserContext.CurrentLanguage == Localizer.lngAzLat)
            {
                ContactListAddContactHeaderCell.Padding = padding;
            }
        }
    }
}