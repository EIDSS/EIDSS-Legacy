Imports System.Collections.Generic

Namespace Core
    Public Interface IReportFactory
        Sub ResetLanguage()

        'Reports

        Sub AdmEventLog()
        Sub HumAccessionIn (ByVal caseId As Long)
        Sub HumAggregateCase (ByVal caseId As Long, ByVal observationId As Long)
        Sub HumAggregateCaseSummary (ByVal aggrXml As String, ByVal observationList As IEnumerable(Of Long))

        Sub HumCaseInvestigationForm (ByVal caseId As Long, ByVal epiId As Long, ByVal csId As Long, _
                                      ByVal diagnosisId As Long)

        Sub HumDiagnosisToChangedDiagnosis()
        Sub HumEmergencyNotification (ByVal caseId As Long)
        Sub HumMonthlyMorbidityAndMortality()
        Sub HumSummaryOfInfectiousDiseases()
        Sub LimBatchTest (ByVal id As Long, ByVal typeID As Long)
        Sub LimCaseTest (ByVal id As Long, ByVal isHuman As Boolean)
        Sub LimContainerContent (ByVal contId As Nullable(Of Long), ByVal freeserId As Nullable(Of Long))
        Sub LimContainerDetails (ByVal id As Long)
        Sub LimSampleTransferForm (ByVal id As Long)
        Sub LimTestResult (ByVal id As Long, ByVal csId As Long, ByVal typeID As Long)
        Sub SessionForm (ByVal id As Long)
        Sub UniOutbreak (ByVal id As Long)
        Sub VetAggregateCase (ByVal caseId As Long, ByVal observationId As Long)

        Sub VetAggregateCaseActions (ByVal caseId As Long, ByVal diagnosticObservation As Long, _
                                     ByVal prophylacticObservation As Long, ByVal sanitaryObservation As Long, _
                                     ByVal labels As IDictionary(Of String, String))

        Sub VetAggregateCaseActionsSummary (ByVal aggrXml As String, ByVal diagnosticObservation As IEnumerable(Of Long), _
                                            ByVal prophylacticObservation As IEnumerable(Of Long), _
                                            ByVal sanitaryObservation As IEnumerable(Of Long), _
                                            ByVal labels As IDictionary(Of String, String))

        Sub VetAggregateCaseSummary (ByVal aggrXml As String, ByVal observationList As IEnumerable(Of Long))
        Sub VetAvianInvestigationForm (ByVal caseId As Long, ByVal diagnosisId As Long)
        Sub VetLivestockInvestigationForm (ByVal caseId As Long, ByVal diagnosisId As Long)
        Sub VetSamplesCount()
        Sub VetSamplesReportBySampleType()
        Sub VetSamplesReportBySampleTypesWithinRegions()
        Sub VetYearlySituation()

        'Report PDF for Web
        Function HumEmergencyNotificationPDFBytes (ByVal lang As String, ByVal caseId As Long) As Byte()


        ' GG reports
        Sub HumSerologyResearchCard()
        Sub HumMicrobiologyResearchCard()
        Sub HumAntibioticResistanceCard()
        Sub Journal60BReportCard()
        Sub HumInfectiousDiseaseMonth()
        Sub HumInfectiousDiseaseIntermediateMonth()
        Sub HumInfectiousDiseaseYear()
        Sub HumInfectiousDiseaseIntermediateYear()

        'kz Reports
        Sub VetRegionPreventiveMeasuresReport()
        Sub VetCountryPreventiveMeasuresReport()
        Sub VetCountryProphilacticMeasuresReport()
        Sub VetRegionProphilacticMeasuresReport()
        Sub VetCountryPlannedDiagnosticTestsReport()
        Sub VetRegionPlannedDiagnosticTestsReport()

        'AJ Reports

        Sub HumFormN1A3()
        Sub HumFormN1A4()
    End Interface
End Namespace