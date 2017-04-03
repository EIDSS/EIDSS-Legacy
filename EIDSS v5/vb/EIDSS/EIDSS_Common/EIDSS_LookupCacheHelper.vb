Imports bv.common.Objects
Imports bv.common.db.Core
Imports System.Collections.Generic
Imports EIDSS.model.Enums

Public Enum LookupTables
    Country
    Rayon
    Region
    Settlement
    Organization
    Person
    ParametersFixedPresetValue
    'AvianDiagnoses
    'LivestockDiagnoses
    'VetDiagnoses
    HumanDiagnoses
    HumanVetDiagnoses
    HumanStandardDiagnosis
    AvianStandardDiagnosis
    LivestockStandardDiagnosis
    VetStandardDiagnosis
    HumanAggregatedDiagnosis
    AvianAggregatedDiagnosis
    LivestockAggregatedDiagnosis
    VetAggregatedDiagnosis
    VectorDiagnosis
    AnimalAgeList
    PensideTestResult
    'VetCaseType
    Department
    TestResult
    'TestResult2Test
    'Patient
    'PatientAdditionalInfo
    'ContactRelationType
    Outbreak
    'SearchCriteria
    SearchField
    SearchObject
    SearchObjectRelation
    SearchTable
    ParameterForFFType
    Query
    QuerySearchField
    QuerySearchFieldPersonalDataGroup
    Layout
    LayoutFolder
    AggregateFunction
    PopulationStatistics
    PopulationGenderStatistics
    PopulationAgeGroupGenderStatistics
    Sex
    VetProphilacticAction
    VetSanitaryAction
    Street
    PostalCode
    SettlementType
    Site
    AggregateMatrixVersion
    FFTemplate
    Repository
    ParameterTypeReferenceEditor
    ASCampaign
    AVRGIS
    SanitaryMeasureTypeName
    DiagnosticInvestigationDiagnosis
    DiagnosticInvestigationSpecies
    DiagnosticInvestigationType
    ProphylacticDiagnosis
    ProphylacticSpecies
    ProphylacticMeasureType
    RepVetOrganization
    RepHumOrganization
    MainTableForObject
    FieldSourceForTable
    CaseType
    StandardDiagnosis
    SearchObjectToSystemFunction
    QueryToSystemFunction
    RayonForAggregate
    RegionForAggregate
    SettlementForAggregate

End Enum

Public Class EIDSS_LookupCacheHelper
    Public Shared Sub Init()
        Dim table As LookupTableInfo = Nothing
        LookupCache.Clear()
        LookupCache.LookupTables.Add(LookupTables.Country.ToString, New LookupTableInfo(LookupTables.Country, True, "Country"))
        LookupCache.LookupTables.Add(LookupTables.Organization.ToString, _
                                      New LookupTableInfo(LookupTables.Organization, True, "Organization"))
        LookupCache.LookupTables.Add(LookupTables.Person.ToString, New LookupTableInfo(LookupTables.Person, True, "Person"))
        LookupCache.LookupTables.Add(LookupTables.Rayon.ToString, New LookupTableInfo(LookupTables.Rayon, True, "Rayon"))
        LookupCache.LookupTables.Add(LookupTables.Region.ToString, New LookupTableInfo(LookupTables.Region, True, "Region"))
        LookupCache.LookupTables.Add(LookupTables.Settlement.ToString, _
                                      New LookupTableInfo(LookupTables.Settlement, True, "Settlement"))

        LookupCache.LookupTables.Add(LookupTables.SettlementType.ToString, _
                                      New LookupTableInfo(LookupTables.SettlementType, True, "SettlementType"))

        LookupCache.LookupTables.Add(LookupTables.ParametersFixedPresetValue.ToString, _
                                      New LookupTableInfo(LookupTables.ParametersFixedPresetValue.ToString, False, "ParameterFixedPresetValue", "spFFGetParameterFixedPresetValue"))

        'table = _
        '    New LookupTableInfo(LookupTables.AvianDiagnoses, True, "Diagnosis", _
        '                         "spDiagnosis_List_HACode_SelectLookup")
        'table.Parameters.Add("@HACode", HACode.Animal Or HACode.Avian)
        'LookupCache.LookupTables.Add(LookupTables.AvianDiagnoses.ToString, table)

        'table = _
        '    New LookupTableInfo(LookupTables.LivestockDiagnoses, True, "Diagnosis", _
        '                         "spDiagnosis_List_HACode_SelectLookup")
        'table.Parameters.Add("@HACode", HACode.Animal Or HACode.Livestock)
        'LookupCache.LookupTables.Add(LookupTables.LivestockDiagnoses.ToString, table)

        'table = _
        '    New LookupTableInfo(LookupTables.VetDiagnoses, True, "Diagnosis", _
        '                         "spDiagnosis_List_HACode_SelectLookup")
        'table.Parameters.Add("@HACode", HACode.Animal Or HACode.Avian Or HACode.Livestock)
        'LookupCache.LookupTables.Add(LookupTables.VetDiagnoses.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.StandardDiagnosis, False, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.All)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.StandardDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.VectorDiagnosis, False, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Vector)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.VectorDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.HumanDiagnoses, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Human)
        table.Parameters.Add("@DiagnosisUsingType", DBNull.Value)
        LookupCache.LookupTables.Add(LookupTables.HumanDiagnoses.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.HumanVetDiagnoses, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Human Or HACode.Avian Or HACode.Livestock)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.HumanVetDiagnoses.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.HumanStandardDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Human)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.HumanStandardDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.AvianStandardDiagnosis, False, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Avian)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.AvianStandardDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.LivestockStandardDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Livestock)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.LivestockStandardDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.VetStandardDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Livestock Or HACode.Avian)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.StandardCase))
        LookupCache.LookupTables.Add(LookupTables.VetStandardDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.HumanAggregatedDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Human)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.AggregatedCase))
        LookupCache.LookupTables.Add(LookupTables.HumanAggregatedDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.AvianAggregatedDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Avian)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.AggregatedCase))
        LookupCache.LookupTables.Add(LookupTables.AvianAggregatedDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.LivestockAggregatedDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Livestock)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.AggregatedCase))
        LookupCache.LookupTables.Add(LookupTables.LivestockAggregatedDiagnosis.ToString, table)

        table = _
            New LookupTableInfo(LookupTables.VetAggregatedDiagnosis, True, "Diagnosis", _
                                 "spDiagnosisRepare_SelectLookup")
        table.Parameters.Add("@HACode", HACode.Livestock Or HACode.Avian)
        table.Parameters.Add("@DiagnosisUsingType", CLng(DiagnosisUsingType.AggregatedCase))
        LookupCache.LookupTables.Add(LookupTables.VetAggregatedDiagnosis.ToString, table)

        LookupCache.LookupTables.Add(LookupTables.AnimalAgeList.ToString, _
                                      New LookupTableInfo(LookupTables.AnimalAgeList, True, "rftAnimalAgeList"))
        LookupCache.LookupTables.Add(LookupTables.PensideTestResult.ToString, _
                                      New LookupTableInfo(LookupTables.PensideTestResult, False, "rftPensideTestResult"))
        LookupCache.LookupTables.Add(LookupTables.Department.ToString, _
                                      New LookupTableInfo(LookupTables.Department, True, "Organization"))
        LookupCache.LookupTables.Add(LookupTables.TestResult.ToString, _
                                      New LookupTableInfo(LookupTables.TestResult, False, "rftTestResult"))
        'LookupCache.LookupTables.Add(LookupTables.TestResult2Test.ToString, _
        '                              New LookupTableInfo(LookupTables.TestResult2Test, False, "rftTestResult"))

        'LookupCache.LookupTables.Add(LookupTables.Patient.ToString, _
        '                              New LookupTableInfo(LookupTables.Patient, True, "Human"))

        'LookupCache.LookupTables.Add(LookupTables.PatientAdditionalInfo.ToString, _
        '                              New LookupTableInfo(LookupTables.PatientAdditionalInfo, True, "Human", _
        '                                                   "spPatientInformation_SelectLookup", Nothing, _
        '                                                   New List(Of String)(New String() {"Settlement"})))

        LookupCache.LookupTables.Add(LookupTables.Outbreak.ToString, _
                                      New LookupTableInfo(LookupTables.Outbreak, True, "Outbreak"))
        ''Human case base references
        'LookupCache.LookupTables.Add(BaseReferenceType.rftHospStatus.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftHospStatus, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftFinalState.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftFinalState, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftOccupationType.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftOccupationType, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftCaseStatus.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftCaseStatus, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftYesNoValue.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftYesNoValue, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftOutcome.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftOutcome, True))
        '                              New LookupTableInfo(BaseReferenceType.rftHumanGender, True))
        'LookupCache.LookupTables.Add(BaseReferenceType.rftNationality.ToString, _
        '                              New LookupTableInfo(BaseReferenceType.rftNationality, True))

        'LookupCache.LookupTables.Add(LookupTables.SearchCriteria.ToString(), _
        '                        New LookupTableInfo(LookupTables.SearchCriteria))

        table = New LookupTableInfo( _
            LookupTables.SearchObject, _
            False, _
            "SearchObject", _
            "spAsSearchObject_SelectLookup", _
            Nothing, _
            New List(Of String)(New String() {"SearchObjectToSearchObject", "SearchField", "Parameter", "QuerySearchField", "QuerySearchFieldPersonalDataGroup", "SearchObjectToSystemFunction"}), False)
        LookupCache.LookupTables.Add(LookupTables.SearchObject.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.SearchObjectRelation, _
            False, _
            "SearchObjectToSearchObject", _
            "spAsSearchObjectToSearchObject_SelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.SearchObjectRelation.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.SearchTable, _
            False, _
            "SearchTable", _
            "spAsSearchTableSelectLookup", _
            "idfSearchTableTree", , False)
        LookupCache.LookupTables.Add(LookupTables.SearchTable.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.MainTableForObject, _
            False, _
            "MainTableForObject", _
            "spAsMainSearchTableSelectLookup", _
            "idfMainSearchTableTree", , False)
        LookupCache.LookupTables.Add(LookupTables.MainTableForObject.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.FieldSourceForTable, _
            False, _
            "FieldSourceForTable", _
            "spAsFieldSourceTableSelectLookup", _
            "idfFieldSourceTableTree", , False)
        LookupCache.LookupTables.Add(LookupTables.FieldSourceForTable.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.SearchField, _
            False, _
            "SearchField", _
            "spAsSearchFieldSelectLookup", _
            Nothing, _
            New List(Of String)(New String() {"QuerySearchField", "QuerySearchFieldPersonalDataGroup", "Parameter"}), False)
        LookupCache.LookupTables.Add(LookupTables.SearchField.ToString(), table)


        table = New LookupTableInfo( _
            LookupTables.ParameterForFFType, _
            False, _
            "Parameter", _
            "spAsParameterSelectLookup", _
            "FieldAlias", _
            New List(Of String)(New String() {"QuerySearchField", "QuerySearchFieldPersonalDataGroup"}))
        LookupCache.LookupTables.Add(LookupTables.ParameterForFFType.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.Query, _
            False, _
            "Query", _
            "spAsQuerySelectLookup", _
            Nothing, _
            New List(Of String)(New String() {"QuerySearchField", "QuerySearchFieldPersonalDataGroup", "Layout", "QueryToSystemFunction"}), False)
        LookupCache.LookupTables.Add(LookupTables.Query.ToString(), table)


        table = New LookupTableInfo( _
            LookupTables.QuerySearchField, _
            False, _
            "QuerySearchField", _
            "spAsQuerySearchFieldSelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.QuerySearchField.ToString(), table)


        table = New LookupTableInfo( _
            LookupTables.QuerySearchFieldPersonalDataGroup, _
            False, _
            "QuerySearchFieldPersonalDataGroup", _
            "spAsQuerySearchFieldPersonalDataGroupSelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.QuerySearchFieldPersonalDataGroup.ToString(), table)



        table = New LookupTableInfo( _
            LookupTables.Layout, _
            False, _
            "Layout", _
            "spAsLayoutSelectLookup", Nothing, Nothing, False)
        LookupCache.LookupTables.Add(LookupTables.Layout.ToString(), table)

        table = New LookupTableInfo( _
           LookupTables.LayoutFolder, _
           False, _
           "LayoutFolder", _
           "spAsFolderSelectLookup", Nothing, Nothing, False)
        LookupCache.LookupTables.Add(LookupTables.LayoutFolder.ToString(), table)


        table = New LookupTableInfo( _
          LookupTables.AggregateFunction, _
          False, _
          Nothing, _
          "spAsAggregateFunctionSelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.AggregateFunction.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.PopulationStatistics, _
            True, _
            "Statistic", _
            "spAsPopulationStatisticsSelectLookup", _
            "AdminUnitName", , False)
        LookupCache.LookupTables.Add(LookupTables.PopulationStatistics.ToString(), table)

        table = New LookupTableInfo( _
                   LookupTables.PopulationGenderStatistics, _
                   True, _
                   "Statistic", _
                   "spAsPopulationGenderStatisticsSelectLookup", _
                   "strGenderName", , False)
        LookupCache.LookupTables.Add(LookupTables.PopulationGenderStatistics.ToString(), table)

        table = New LookupTableInfo( _
                 LookupTables.PopulationAgeGroupGenderStatistics, _
                 True, _
                 "Statistic", _
                 "spAsPopulationAgeGroupGenderStatisticsSelectLookup", _
                 "strAgeGroupGenderName", , False)
        LookupCache.LookupTables.Add(LookupTables.PopulationAgeGroupGenderStatistics.ToString(), table)

        table = New LookupTableInfo( _
         LookupTables.Sex, _
         False, _
         "Sex", _
         "spSexSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.Sex.ToString(), table)

   table = New LookupTableInfo( _
            LookupTables.VetProphilacticAction, _
            False, _
            "ProphilacticAction", _
            "spProphilacticActionList_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.VetProphilacticAction.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.VetSanitaryAction, _
            False, _
            "SanitaryAction", _
            "spSanitaryActionList_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.VetSanitaryAction.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.Street, _
            True, _
            "Street", _
            "spStreet_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.Street.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.PostalCode, _
            True, _
            "PostalCode", _
            "spPostalCode_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.PostalCode.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.Site, _
            False, _
            "Site", _
            "spSite_SelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.Site.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.AggregateMatrixVersion, _
            False, _
            "AggrMatrixVersionHeader", _
            "spAggregateMatrixVersion_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.AggregateMatrixVersion.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.FFTemplate, _
            False, _
            "FormTemplate", _
            "spFFGetTemplates")
        LookupCache.LookupTables.Add(LookupTables.FFTemplate.ToString(), table)
        table = New LookupTableInfo( _
            LookupTables.Repository, _
            False, _
            "Freezer", _
            "spRepository_SelectLookup")
        LookupCache.LookupTables.Add(LookupTables.Repository.ToString(), table)
        LookupCache.LookupTables.Add(LookupTables.ParameterTypeReferenceEditor.ToString(), New LookupTableInfo(LookupTables.ParameterTypeReferenceEditor, False, "ParameterTypeReferenceEditor", "spFFGetParameterReferenceType"))

        table = New LookupTableInfo( _
           LookupTables.AVRGIS, _
           False, _
           "AVRGIS", _
           "spAsGisSelectLookup", , , False)
        LookupCache.LookupTables.Add(LookupTables.AVRGIS.ToString(), table)


        table = New LookupTableInfo( _
          LookupTables.SanitaryMeasureTypeName, _
          False, _
          "SanitaryMeasureTypeName", _
          "spRepVetSanitarySelectLookup")
        LookupCache.LookupTables.Add(LookupTables.SanitaryMeasureTypeName.ToString(), table)


        table = New LookupTableInfo( _
                 LookupTables.DiagnosticInvestigationDiagnosis, _
                 False, _
                 "DiagnosticInvestigationDiagnosis", _
                 "spRepVetDiagnosisInvDiagnosisSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.DiagnosticInvestigationDiagnosis.ToString(), table)


        table = New LookupTableInfo( _
               LookupTables.DiagnosticInvestigationSpecies, _
               False, _
               "DiagnosticInvestigationSpecies", _
               "spRepVetDiagnosisInvSpeciesSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.DiagnosticInvestigationSpecies.ToString(), table)


        table = New LookupTableInfo( _
                 LookupTables.DiagnosticInvestigationType, _
                 False, _
                 "DiagnosticInvestigationType", _
                 "spRepVetDiagnosisInvTypeSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.DiagnosticInvestigationType.ToString(), table)


        table = New LookupTableInfo( _
                  LookupTables.ProphylacticDiagnosis, _
                  False, _
                  "ProphylacticDiagnosis", _
                  "spRepVetProphylacticDiagnosisSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.ProphylacticDiagnosis.ToString(), table)

        table = New LookupTableInfo( _
                 LookupTables.ProphylacticSpecies, _
                 False, _
                 "ProphylacticSpecies", _
                 "spRepVetProphylacticSpeciesSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.ProphylacticSpecies.ToString(), table)

        table = New LookupTableInfo( _
                LookupTables.ProphylacticMeasureType, _
                False, _
                "ProphylacticMeasureType", _
                "spRepVetProphylacticTypeSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.ProphylacticMeasureType.ToString(), table)

        table = New LookupTableInfo( _
               LookupTables.RepVetOrganization, _
               False, _
               "RepVetOrganization", _
               "spRepVetOrganizationSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.RepVetOrganization.ToString(), table)

        table = New LookupTableInfo( _
              LookupTables.RepHumOrganization, _
              False, _
              "RepHumOrganization", _
              "spRepHumOrganizationSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.RepHumOrganization.ToString(), table)


        table = New LookupTableInfo( _
               LookupTables.CaseType, _
               False, _
               "CaseType", _
               "spCaseTypeSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.CaseType.ToString(), table)

        LookupCache.LookupTables.Add(BaseReferenceType.rftAvianFarmType.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftAvianFarmType, False, "rftAvianFarmType", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftOwnershipType.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftOwnershipType, False, "rftOwnershipType", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftMonitoringSessionActionStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftMonitoringSessionActionStatus, False, "rftMonitoringSessionActionStatus", , , , False))

        LookupCache.LookupTables.Add(BaseReferenceType.rftVetCaseLogStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftVetCaseLogStatus, False, "rftVetCaseLogStatus", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftHospStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftHospStatus, False, "rftHospStatus", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftContact_Type.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftContact_Type, False, "rftContact_Type", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftCaseProgressStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftCaseProgressStatus, False, "rftCaseProgressStatus", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftCampaignStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftCampaignStatus, False, "rftCampaignStatus", , , , False))
        LookupCache.LookupTables.Add(BaseReferenceType.rftMonitoringSessionStatus.ToString, _
                                      New LookupTableInfo(BaseReferenceType.rftMonitoringSessionStatus, False, "rftMonitoringSessionStatus", , , , False))

        table = New LookupTableInfo( _
            LookupTables.SearchObjectToSystemFunction, _
            False, _
            "SearchObjectToSystemFunction", _
            "spAsSearchObjectToSystemFunctionSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.SearchObjectToSystemFunction.ToString(), table)

        table = New LookupTableInfo( _
            LookupTables.QueryToSystemFunction, _
            False, _
            "QueryToSystemFunction", _
            "spAsQueryToSystemFunctionSelectLookup")
        LookupCache.LookupTables.Add(LookupTables.QueryToSystemFunction.ToString(), table)

        table = New LookupTableInfo(LookupTables.RayonForAggregate, False, "Rayon", "spRayonAggr_SelectLookup")
        table.Parameters.Add("@idfsAggrCaseType", CLng(AggregateCaseType.AggregateCase))
        LookupCache.LookupTables.Add(LookupTables.RayonForAggregate.ToString, table)

        table = New LookupTableInfo(LookupTables.RegionForAggregate, False, "Region", "spRegionAggr_SelectLookup")
        table.Parameters.Add("@idfsAggrCaseType", CLng(AggregateCaseType.AggregateCase))
        LookupCache.LookupTables.Add(LookupTables.RegionForAggregate.ToString, table)

        table = New LookupTableInfo(LookupTables.SettlementForAggregate, False, "Settlement", "spSettlementAggr_SelectLookup")
        table.Parameters.Add("@idfsAggrCaseType", CLng(AggregateCaseType.AggregateCase))
        LookupCache.LookupTables.Add(LookupTables.SettlementForAggregate.ToString, table)

        LookupCache.Init()
    End Sub
End Class
