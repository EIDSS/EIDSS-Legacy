Imports System.Collections.Generic

Public Class HumanCaseSearch

    Private FieldArr As Dictionary(Of String, FieldValue) = Nothing
    Private m_FromCondition As String = ""
    Private m_WhereCondition As String = ""
    Private m_HumanCaseListObjectName As String = "HumanCase"

    Public Sub New()
        FillFieldArr()
        m_FromCondition = ""
        m_WhereCondition = ""
        m_HumanCaseListObjectName = "HumanCase"
    End Sub

    Public Sub New(ByVal aHumanCaseListObjectName As String)
        FillFieldArr()
        m_FromCondition = ""
        m_WhereCondition = ""
        If Utils.IsEmpty(aHumanCaseListObjectName) Then m_HumanCaseListObjectName = "HumanCase" _
        Else m_HumanCaseListObjectName = aHumanCaseListObjectName
    End Sub

    Public Property HumanCaseListObjectName() As String
        Get
            Return m_HumanCaseListObjectName
        End Get
        Set(ByVal value As String)
            If Utils.IsEmpty(value) Then m_HumanCaseListObjectName = "HumanCase" _
            Else m_HumanCaseListObjectName = value
        End Set
    End Property

    Public ReadOnly Property fn_HumanCase_SelectList_Name() As String
        Get
            Return fnSelectList_Name(m_HumanCaseListObjectName)

        End Get
    End Property

    Public ReadOnly Property FromCondition(Optional ByVal DoCreateCondition As Boolean = True) As String
        Get
            If DoCreateCondition Then CreateFromCondition()
            Return m_FromCondition
        End Get
    End Property

    Public ReadOnly Property WhereCondition(Optional ByVal DoCreateCondition As Boolean = True) As String
        Get
            If DoCreateCondition Then
                CreateFromCondition()
                CreateWhereCondition()
            End If
            Return m_WhereCondition
        End Get
    End Property

    Public Enum HCTable
        tlbNone
        tlbHumanCase
        tlbHuman
        tlbGeoLocation_case
        tlbGeoLocation_home
        tlbGeoLocation_emp
        tlbGeoLocation_reg
        tlbOffice_sent
        tlbOffice_rec
        tlbOffice_inv
        tlbOutbreak
        tlbObservation_cs
        tlbObservation_epi
        tlbActivityParameters
        tlbContactedCasePerson
        tlbMaterial
        tlbTesting
        tlbBatchTest
        tlbContainer
        tlbAntimicrobialTherapy
    End Enum

    Public Function GetPrefix(ByVal table As HCTable) As String
        Return GetPrefix(table, m_HumanCaseListObjectName)
    End Function


    Public Function GetPrefix(ByVal table As HCTable, ByVal index As Integer) As String
        If index > 0 Then Return GetPrefix(table) + "_" + index.ToString()
        Return GetPrefix(table)
    End Function

    Public Function GetHCTable(ByVal prefix As String) As HCTable
        Return GetHCTable(prefix, m_HumanCaseListObjectName)
    End Function

    Public Function GetHCTable(ByVal prefix As String, ByVal index As Integer) As HCTable
        Return GetHCTable(prefix, index, m_HumanCaseListObjectName)
    End Function

    Public Function GetDoublePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable) As String
        Return GetDoublePrefix(firstT, secondT, m_HumanCaseListObjectName)
    End Function

    Public Function GetTriplePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal thirdT As HCTable) As String
        Return GetTriplePrefix(firstT, secondT, thirdT, m_HumanCaseListObjectName)
    End Function

    Public Function GetDoublePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal index As Integer) As String
        Return GetDoublePrefix(firstT, secondT, index, m_HumanCaseListObjectName)
    End Function

    Public Function GetTriplePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal thirdT As HCTable, ByVal index As Integer) As String
        Return GetTriplePrefix(firstT, secondT, thirdT, index, m_HumanCaseListObjectName)
    End Function

    Public Function GetFieldFullName(fieldName As String) As String
        If FieldArr.ContainsKey(fieldName) Then
            Return FieldArr(fieldName).FullName
        End If
        Return String.Empty
    End Function
    Private Sub FillFieldArr()
        FieldArr = New Dictionary(Of String, FieldValue)

        'tlbCase
        FieldArr.Add("strCaseID", New FieldValue("strCaseID", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsCaseProgressStatus", New FieldValue("idfsCaseProgressStatus", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datEnteredDate", New FieldValue("datEnteredDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))

        'tlbHumanCase
        FieldArr.Add("datModificationDate", New FieldValue("datModificationDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datCompletionPaperFormDate", New FieldValue("datCompletionPaperFormDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("strNote", New FieldValue("strNote", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datNotificationDate", New FieldValue("datNotificationDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsFinalCaseStatus", New FieldValue("idfsFinalCaseStatus", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfsInitialCaseStatus", New FieldValue("idfsInitialCaseStatus", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfsYNAntimicrobialTherapy", New FieldValue("idfsYNAntimicrobialTherapy", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfsYNRelatedToOutbreak", New FieldValue("idfsYNRelatedToOutbreak", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfsYNSpecimenCollected", New FieldValue("idfsYNSpecimenCollected", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datOnsetDate", New FieldValue("datOnsetDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfSentByPerson", New FieldValue("idfSentByPerson", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        'FieldArr.Add("strSentByFirstName", New FieldValue("strSentByFirstName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        'FieldArr.Add("strSentByPatronymicName", New FieldValue("strSentByPatronymicName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        'FieldArr.Add("strSentByLastName", New FieldValue("strSentByLastName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfReceivedByPerson", New FieldValue("idfReceivedByPerson", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        'FieldArr.Add("strReceivedByFirstName", New FieldValue("strReceivedByFirstName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        'FieldArr.Add("strReceivedByPatronymicName", New FieldValue("strReceivedByPatronymicName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        'FieldArr.Add("strReceivedByLastName", New FieldValue("strReceivedByLastName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datInvestigationStartDate", New FieldValue("datInvestigationStartDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("strClinicalNotes", New FieldValue("strClinicalNotes", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsOutcome", New FieldValue("idfsOutcome", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("strEpidemiologistsName", New FieldValue("strEpidemiologistsName", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("strSummaryNotes", New FieldValue("strSummaryNotes", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsNotCollectedReason", New FieldValue("idfsNotCollectedReason", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("intPatientAge", New FieldValue("intPatientAge", Nothing, GetType(Integer), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsHumanAgeType", New FieldValue("idfsHumanAgeType", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datFacilityLastVisit", New FieldValue("datFacilityLastVisit", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("strLocalIdentifier", New FieldValue("strLocalIdentifier", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsHospitalizationStatus", New FieldValue("idfsHospitalizationStatus", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("strCurrentLocation", New FieldValue("strCurrentLocation", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfHospital", New FieldValue("idfHospital", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfsFinalState", New FieldValue("idfsFinalState", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datExposureDate", New FieldValue("datExposureDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datDischargeDate", New FieldValue("datDischargeDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datFirstSoughtCareDate", New FieldValue("datFirstSoughtCareDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("strSoughtCareFacility", New FieldValue("strSoughtCareFacility", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsYNHospitalization", New FieldValue("idfsYNHospitalization", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("strHospitalizationPlace", New FieldValue("strHospitalizationPlace", Nothing, GetType(String), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datHospitalizationDate", New FieldValue("datHospitalizationDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsTentativeDiagnosis", New FieldValue("idfsTentativeDiagnosis", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datTentativeDiagnosisDate", New FieldValue("datTentativeDiagnosisDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsFinalDiagnosis", New FieldValue("idfsFinalDiagnosis", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datFinalDiagnosisDate", New FieldValue("datFinalDiagnosisDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsNonNotifiableDiagnosis", New FieldValue("idfsNonNotifiableDiagnosis", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("blnClinicalDiagBasis", New FieldValue("blnClinicalDiagBasis", Nothing, GetType(Boolean), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("blnLabDiagBasis", New FieldValue("blnLabDiagBasis", Nothing, GetType(Boolean), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("blnEpiDiagBasis", New FieldValue("blnEpiDiagBasis", Nothing, GetType(Boolean), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("datFinalCaseClassificationDate", New FieldValue("datFinalCaseClassificationDate", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))
        FieldArr.Add("idfsDiagnosis", New FieldValue("idfsDiagnosis", Nothing, GetType(Int64), GetPrefix(HCTable.tlbNone), True))
        FieldArr.Add("idfsCaseClassification", New FieldValue("isnull({0}.idfsFinalCaseStatus,{0}.idfsInitialCaseStatus)", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfPersonEnteredBy", New FieldValue("idfPersonEnteredBy", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("idfOfficeEnteredBy", New FieldValue("idfsSite", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHumanCase), True))
        FieldArr.Add("datDiagnosisDate", New FieldValue("isnull({0}.datFinalDiagnosisDate,{0}.datTentativeDiagnosisDate)", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHumanCase), False))

        'tlbHuman
        FieldArr.Add("strRegistrationPhone", New FieldValue("strRegistrationPhone", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("idfsOccupationType", New FieldValue("idfsOccupationType", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHuman), True))
        FieldArr.Add("strWorkPhone", New FieldValue("strWorkPhone", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("datDateOfDeath", New FieldValue("datDateOfDeath", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("strFirstName", New FieldValue("strFirstName", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("strLastName", New FieldValue("strLastName", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("strSecondName", New FieldValue("strSecondName", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("strEmployerName", New FieldValue("strEmployerName", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("strHomePhone", New FieldValue("strHomePhone", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("datDateOfBirth", New FieldValue("datDateOfBirth", Nothing, GetType(DateTime), GetPrefix(HCTable.tlbHuman), False))
        FieldArr.Add("idfsHumanGender", New FieldValue("idfsHumanGender", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHuman), True))
        FieldArr.Add("idfsNationality", New FieldValue("idfsNationality", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHuman), True))
        FieldArr.Add("idfsPersonIDType", New FieldValue("idfsPersonIDType", Nothing, GetType(Int64), GetPrefix(HCTable.tlbHuman), True))
        FieldArr.Add("strPersonID", New FieldValue("strPersonID", Nothing, GetType(String), GetPrefix(HCTable.tlbHuman), False))

        'tlbGeoLocation_case
        FieldArr.Add("loc.idfsGeoLocationType", New FieldValue("idfsGeoLocationType", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.idfsCountry", New FieldValue("idfsCountry", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.idfsRegion", New FieldValue("idfsRegion", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.idfsRayon", New FieldValue("idfsRayon", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.strDescription", New FieldValue("strDescription", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_case), False))
        FieldArr.Add("loc.dblAccuracy", New FieldValue("dblAccuracy", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_case), False, SearchCriteria.IsBetween))

        FieldArr.Add("loc.dblLongitude", New FieldValue("dblLongitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_case), False, SearchCriteria.IsBetween))
        FieldArr.Add("loc.dblLatitude", New FieldValue("dblLatitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_case), False, SearchCriteria.IsBetween))

        FieldArr.Add("loc.idfsSettlement", New FieldValue("idfsSettlement", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.dblAlignment", New FieldValue("dblAlignment", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_case), False, SearchCriteria.IsBetween))
        FieldArr.Add("loc.dblDistance", New FieldValue("dblDistance", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_case), False, SearchCriteria.IsBetween))
        FieldArr.Add("loc.idfsGroundType", New FieldValue("idfsGroundType", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_case), True))
        FieldArr.Add("loc.strForeignAddress", New FieldValue("strForeignAddress", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_case), False))

        'tlbGeoLocation_home
        FieldArr.Add("home.idfsCountry", New FieldValue("idfsCountry", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_home), True))
        FieldArr.Add("home.idfsRegion", New FieldValue("idfsRegion", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_home), True))
        FieldArr.Add("home.idfsRayon", New FieldValue("idfsRayon", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_home), True))
        FieldArr.Add("home.idfsSettlement", New FieldValue("idfsSettlement", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_home), True))
        FieldArr.Add("home.strStreetName", New FieldValue("strStreetName", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_home), False))
        FieldArr.Add("home.strPostCode", New FieldValue("strPostCode", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_home), False))
        FieldArr.Add("home.strHouse", New FieldValue("strHouse", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_home), False))
        FieldArr.Add("home.strBuilding", New FieldValue("strBuilding", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_home), False))
        FieldArr.Add("home.strApartment", New FieldValue("strApartment", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_home), False))
        FieldArr.Add("home.dblLongitude", New FieldValue("dblLongitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_home), False, SearchCriteria.IsBetween))
        FieldArr.Add("home.dblLatitude", New FieldValue("dblLatitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_home), False, SearchCriteria.IsBetween))

        'tlbGeoLocation_emp
        FieldArr.Add("emp.idfsCountry", New FieldValue("idfsCountry", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_emp), True))
        FieldArr.Add("emp.idfsRegion", New FieldValue("idfsRegion", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_emp), True))
        FieldArr.Add("emp.idfsRayon", New FieldValue("idfsRayon", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_emp), True))
        FieldArr.Add("emp.idfsSettlement", New FieldValue("idfsSettlement", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_emp), True))
        FieldArr.Add("emp.strStreetName", New FieldValue("strStreetName", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_emp), False))
        FieldArr.Add("emp.strPostCode", New FieldValue("strPostCode", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_emp), False))
        FieldArr.Add("emp.strHouse", New FieldValue("strHouse", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_emp), False))
        FieldArr.Add("emp.strBuilding", New FieldValue("strBuilding", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_emp), False))
        FieldArr.Add("emp.strApartment", New FieldValue("strApartment", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_emp), False))

        'tlbGeoLocation_reg
        FieldArr.Add("reg.idfsCountry", New FieldValue("idfsCountry", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_reg), True))
        FieldArr.Add("reg.idfsRegion", New FieldValue("idfsRegion", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_reg), True))
        FieldArr.Add("reg.idfsRayon", New FieldValue("idfsRayon", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_reg), True))
        FieldArr.Add("reg.idfsSettlement", New FieldValue("idfsSettlement", Nothing, GetType(Int64), GetPrefix(HCTable.tlbGeoLocation_reg), True))
        FieldArr.Add("reg.strStreetName", New FieldValue("strStreetName", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.strPostCode", New FieldValue("strPostCode", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.strHouse", New FieldValue("strHouse", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.strBuilding", New FieldValue("strBuilding", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.strApartment", New FieldValue("strApartment", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.blnForeignAddress", New FieldValue("blnForeignAddress", Nothing, GetType(Boolean), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.strForeignAddress", New FieldValue("strForeignAddress", Nothing, GetType(String), GetPrefix(HCTable.tlbGeoLocation_reg), False))
        FieldArr.Add("reg.dblLongitude", New FieldValue("dblLongitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_reg), False, SearchCriteria.IsBetween))
        FieldArr.Add("reg.dblLatitude", New FieldValue("dblLatitude", Nothing, GetType(Double), GetPrefix(HCTable.tlbGeoLocation_reg), False, SearchCriteria.IsBetween))

        'tlbOffice_sent
        FieldArr.Add("sent.idfOffice", New FieldValue("idfOffice", Nothing, GetType(Int64), GetPrefix(HCTable.tlbOffice_sent), True))

        'tlbOffice_rec
        FieldArr.Add("receive.idfOffice", New FieldValue("idfOffice", Nothing, GetType(Int64), GetPrefix(HCTable.tlbOffice_rec), True))

        'tlbOffice_inv
        FieldArr.Add("inv.idfOffice", New FieldValue("idfOffice", Nothing, GetType(Int64), GetPrefix(HCTable.tlbOffice_inv), True))

        'tlbOutbreak
        FieldArr.Add("idfOutbreak", New FieldValue("idfOutbreak", Nothing, GetType(Int64), GetPrefix(HCTable.tlbOutbreak), True))
    End Sub

    Public Function SearchField(ByVal fieldName As String) As FieldValue

        If (FieldArr Is Nothing) OrElse Not FieldArr.ContainsKey(fieldName) Then Return Nothing
        Return FieldArr(fieldName)
        'For i As Integer = 0 To FieldArr.Count - 1
        '    If TypeOf (FieldArr.Item(i)) Is FieldValue Then
        '        Dim CurField As FieldValue = CType(FieldArr.Item(i), FieldValue)
        '        If CurField.FullName.ToLower(Globalization.CultureInfo.InvariantCulture) = FieldFullName.ToLower(Globalization.CultureInfo.InvariantCulture) Then
        '            Return CurField
        '        End If
        '    End If
        'Next
        'Return Nothing
    End Function

    'Private Function Get_tlbCase_From(Optional ByVal joinType As String = "left") As String
    '    Return Get_tlbCase_From(m_HumanCaseListObjectName, joinType)
    'End Function

    Private Function Get_tlbHumanCase_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbHumanCase_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbHuman_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbHuman_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbGeoLocation_home_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbGeoLocation_home_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbGeoLocation_emp_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbGeoLocation_emp_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbGeoLocation_reg_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbGeoLocation_reg_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbOffice_sent_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbOffice_sent_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbOffice_rec_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbOffice_rec_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbOffice_inv_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbOffice_inv_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbGeoLocation_case_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbGeoLocation_case_From(m_HumanCaseListObjectName, joinType)
    End Function

    Private Function Get_tlbOutbreak_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbOutbreak_From(m_HumanCaseListObjectName, joinType)
    End Function

    Public Function Get_tlbObservation_cs_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbObservation_cs_From(m_HumanCaseListObjectName, joinType)
    End Function

    Public Function Get_tlbObservation_epi_From(Optional ByVal joinType As String = "left") As String
        Return Get_tlbObservation_epi_From(m_HumanCaseListObjectName, joinType)
    End Function

    Public Function GetFrom(ByVal table As HCTable, Optional ByVal joinType As String = "left") As String
        Return GetFrom(table, m_HumanCaseListObjectName, joinType)
    End Function

    Private Sub CorrectFromCondition(ByVal f As FieldValue)
        If (Not f Is Nothing) AndAlso _
           (Not Utils.IsEmpty(f.FValue)) AndAlso _
           (GetHCTable(f.Prefix) <> HCTable.tlbNone) Then
            If Not S1_Contains_S2(m_FromCondition, GetFrom(GetHCTable(f.Prefix))) Then
                m_FromCondition = m_FromCondition + GetFrom(GetHCTable(f.Prefix))
            End If
        End If
    End Sub

    Private Sub CreateFromCondition()
        m_FromCondition = ""
        If (FieldArr Is Nothing) OrElse (FieldArr.Count = 0) Then Return
        For Each v As FieldValue In FieldArr.Values
            CorrectFromCondition(v)
        Next
    End Sub

    Private Sub AddWhereCondition(ByVal f As FieldValue)
        If (Not f Is Nothing) AndAlso _
           (Not Utils.IsEmpty(f.DefaultCondition)) Then
            If (GetHCTable(f.Prefix) <> HCTable.tlbNone) AndAlso _
               (Not S1_Contains_S2(m_FromCondition, GetFrom(GetHCTable(f.Prefix)))) Then
                m_FromCondition = m_FromCondition + GetFrom(GetHCTable(f.Prefix))
            End If
            If Not S1_Contains_S2(m_WhereCondition, f.DefaultCondition) Then
                If m_WhereCondition.Trim().EndsWith(")") Then m_WhereCondition = m_WhereCondition + "and "
                m_WhereCondition = m_WhereCondition + f.DefaultCondition
            End If
        End If
    End Sub

    Private Sub CreateWhereCondition()
        m_WhereCondition = ""
        If (FieldArr Is Nothing) OrElse (FieldArr.Count = 0) Then Return
        For Each v As FieldValue In FieldArr.Values
            AddWhereCondition(v)
        Next
    End Sub

    Public Function Get_tlbActivityParameters_cs_From(ByVal index As Integer, ByVal paramID As Int64, ByVal val As Object) As String
        If (index <= 0) OrElse Utils.IsEmpty(paramID) OrElse Utils.IsEmpty(val) Then Return ""
        Dim valCondition As String = GetSQLVariantCondition( _
            String.Format("{0}.varValue", _
                    GetDoublePrefix(HCTable.tlbActivityParameters, HCTable.tlbObservation_cs, index)), _
            val)
        If Utils.IsEmpty(valCondition) Then Return ""
        Dim From As String = String.Format( _
            "inner join tlbActivityParameters as {0} " + _
            "on         {0}.idfObservation = {1}.idfObservation " + _
            "           and {0}.idfsParameter = {2} " + _
            "           and {0}.intRowStatus = 0 " + _
            "           and {3} ", _
            GetDoublePrefix(HCTable.tlbActivityParameters, HCTable.tlbObservation_cs, index), _
            GetPrefix(HCTable.tlbObservation_cs), _
            paramID, _
            valCondition)
        Return From
    End Function

    Public Function Get_tlbActivityParameters_epi_From(ByVal index As Integer, ByVal paramID As Int64, ByVal val As Object) As String
        If (index <= 0) OrElse Utils.IsEmpty(paramID) OrElse Utils.IsEmpty(val) Then Return ""
        Dim valCondition As String = GetSQLVariantCondition( _
            String.Format("{0}.varValue", _
                    GetDoublePrefix(HCTable.tlbActivityParameters, HCTable.tlbObservation_epi, index)), _
            val)
        If Utils.IsEmpty(valCondition) Then Return ""
        Dim From As String = String.Format( _
            "inner join tlbActivityParameters as {0} " + _
            "on         {0}.idfObservation = {1}.idfObservation " + _
            "           and {0}.idfsParameter = {2} " + _
            "           and {0}.intRowStatus = 0 " + _
            "           and {3} ", _
            GetDoublePrefix(HCTable.tlbActivityParameters, HCTable.tlbObservation_epi, index), _
            GetPrefix(HCTable.tlbObservation_epi), _
            paramID, _
            valCondition)
        Return From
    End Function

    Public Function Get_tlbContactedCasePerson_From(ByVal index As Integer, Optional ByVal joinType As String = "left") As String
        If (index <= 0) Then Return ""
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbContactedCasePerson as {1} " + _
            "   inner join  tlbHuman as {2} " + _
            "   on          {2}.idfHuman = {2}.idfHuman " + _
            "               and {2}.intRowStatus = 0 " +
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase " + _
            "           and {1}.intRowStatus = 0 " + _
            "{4}", _
            joinType, _
            GetPrefix(HCTable.tlbContactedCasePerson, index), _
            GetDoublePrefix(HCTable.tlbHuman, HCTable.tlbContactedCasePerson, index), _
            fn_HumanCase_SelectList_Name, _
            NotInCondition(index, GetPrefix(HCTable.tlbContactedCasePerson, index), "idfContactedCasePerson"))
        'GetDoublePrefix(HCTable.tlbParty, HCTable.tlbContactedCasePerson, index), _
        '"   inner join  tlbParty as {2} " + _
        '"   on          {2}.idfParty = {1}.idfHuman " + _
        '"               and {2}.idfsPartyType = 10072006 /*Human*/ " + _
        '"               and {2}.intRowStatus = 0 " + _
        Return From
    End Function

    Public Function Get_tlbContactedCasePerson_UniqueFrom(ByVal index As Integer, ByVal cond As String) As String
        If (index <= 0) OrElse Utils.IsEmpty(cond) OrElse (cond.Trim().Length = 0) OrElse _
           S1_Contains_S2("and ", cond.Trim()) Then Return ""
        Dim condition As String = cond.Trim()
        If Not condition.StartsWith("and ") Then condition = "and " + condition + " "
        condition = condition.Replace("_" + index.ToString(), "__" + index.ToString())
        condition = "           " + condition
        Dim From As String = String.Format( _
            "left join  ( " + _
            "   tlbContactedCasePerson as {0} " + _
            "   inner join  tlbHuman as {1} " + _
            "   on          {1}.idfHuman = {0}.idfHuman " + _
            "               and {1}.intRowStatus = 0 " +
            "           ) " + _
            "on         {0}.idfHumanCase = {2}.idfCase " + _
            "           and {0}.intRowStatus = 0 " + _
            "{3}" + _
            "{4}" + _
            "           and {0}.idfContactedCasePerson < {5}.idfContactedCasePerson ", _
            GetPrefix(HCTable.tlbContactedCasePerson, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            GetDoublePrefix(HCTable.tlbHuman, HCTable.tlbContactedCasePerson, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            fn_HumanCase_SelectList_Name, _
            NotInCondition( _
                index, _
                GetPrefix(HCTable.tlbContactedCasePerson, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
                "idfContactedCasePerson"), _
            condition, _
            GetPrefix(HCTable.tlbContactedCasePerson, index))
        '    GetDoublePrefix(HCTable.tlbParty, HCTable.tlbContactedCasePerson, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
        '"   inner join  tlbParty as {1} " + _
        '"   on          {1}.idfParty = {0}.idfHuman " + _
        '"               and {1}.idfsPartyType = 10072006 /*Human*/ " + _
        '"               and {1}.intRowStatus = 0 " + _
        Return From
    End Function

    Public Function Get_tlbContactedCasePerson_UniqueWhere(ByVal index As Integer, ByVal cond As String) As String
        If (index <= 0) OrElse Utils.IsEmpty(cond) OrElse (cond.Trim().Length = 0) OrElse _
           S1_Contains_S2("and ", cond.Trim()) Then Return ""
        Dim Where As String = String.Format( _
            "({0}.idfContactedCasePerson is null) ", _
            GetPrefix(HCTable.tlbContactedCasePerson, index).Replace("_" + index.ToString(), "__" + index.ToString()))
        Return Where
    End Function

    Public Function Get_tlbMaterial_From(ByVal index As Integer, Optional ByVal Add_tlbHuman_From As Boolean = False, Optional ByVal joinType As String = "left") As String
        If (index <= 0) Then Return ""
        Dim tlbHuman_From As String = ""
        If Add_tlbHuman_From Then tlbHuman_From = Get_tlbHuman_From(joinType)
        Dim From As String = String.Format( _
            "{0}" + _
            "{1} join   ( " + _
            "   tlbMaterial as {2} " + _
            "   left join   ( " + _
            "       tlbTesting as {3} " + _
            "       left join   tlbBatchTest as {4} " + _
            "       on          {4}.idfBatchTest = {3}.idfBatchTest " + _
            "                   and {4}.intRowStatus = 0 " + _
            "               ) " + _
            "   on          {3}.idfTesting = {2}.idfTesting " + _
            String.Format("               and {{}}.i{0}dfMaterial = {{2}}.idfMaterial ", "ARG0") + _
            "               and {3}.idfsTestStatus = 10001001 /*Completed*/ " + _
            "               and {3}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {2}.idfCase = {5}.idfCase " + _
            "           and {2}.intRowStatus = 0 " + _
            "{6}", _
            tlbHuman_From, _
            joinType, _
            GetPrefix(HCTable.tlbMaterial, index), _
            GetDoublePrefix(HCTable.tlbTesting, HCTable.tlbMaterial, index), _
            GetDoublePrefix(HCTable.tlbBatchTest, HCTable.tlbMaterial, index), _
            fn_HumanCase_SelectList_Name, _
            NotInCondition(index, GetPrefix(HCTable.tlbMaterial, index), "idfMaterial"))
        Return From
    End Function

    Public Function Get_tlbMaterial_UniqueFrom(ByVal index As Integer, ByVal tlbMaterial_Cond As String, ByVal tlbTesting_Cond As String) As String
        If (index <= 0) OrElse _
           ((Utils.IsEmpty(tlbMaterial_Cond) OrElse (tlbMaterial_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) AndAlso _
            (Utils.IsEmpty(tlbTesting_Cond) OrElse (tlbTesting_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbTesting_Cond.Trim()))) Then _
            Return ""
        Dim tlbMaterial_Condition As String = ""
        Dim tlbTesting_Condition As String = ""
        Dim tlbTesting_JoinType As String = "left"
        If (Not Utils.IsEmpty(tlbMaterial_Cond)) AndAlso (tlbMaterial_Cond.Trim().Length > 0) AndAlso _
           (Not S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) Then
            tlbMaterial_Condition = tlbMaterial_Cond.Trim()
            If Not tlbMaterial_Condition.StartsWith("and ") Then tlbMaterial_Condition = "and " + tlbMaterial_Condition
            tlbMaterial_Condition = tlbMaterial_Condition.Replace("_" + index.ToString(), "__" + index.ToString())
            tlbMaterial_Condition = "           " + tlbMaterial_Condition + " "
        End If
        If (Not Utils.IsEmpty(tlbTesting_Cond)) AndAlso (tlbTesting_Cond.Trim().Length > 0) AndAlso _
           (Not S1_Contains_S2("and ", tlbTesting_Cond.Trim())) Then
            tlbTesting_Condition = tlbTesting_Cond.Trim()
            If Not tlbTesting_Condition.StartsWith("and ") Then tlbTesting_Condition = "and " + tlbTesting_Condition
            tlbTesting_Condition = tlbTesting_Condition.Replace("_" + index.ToString(), "__" + index.ToString())
            tlbTesting_Condition = "           " + tlbTesting_Condition + " "
            tlbTesting_JoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "left join   ( " + _
            "   tlbMaterial as {0} " + _
            "   {1} join    ( " + _
            "       tlbTesting as {2} " + _
            "       left join   tlbBatchTest as {3} " + _
            "       on          {3}.idfBatchTest = {2}.idfBatchTest " + _
            "                   and {3}.intRowStatus = 0 " + _
            "               ) " + _
            "   on          {2}.idfTesting = {0}.idfTesting " + _
            "               and {2}.idfMaterial = {0}.idfMaterial " + _
            "               and {2}.idfsTestStatus = 10001001 /*Completed*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "{4}" + _
            "           ) " + _
            "on         {0}.idfCase = {5}.idfCase " + _
            "           and {0}.intRowStatus = 0 " + _
            "{6}" + _
            "{7}" + _
            "           and {0}.idfMaterial < {8}.idfMaterial ", _
            GetPrefix(HCTable.tlbMaterial, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            tlbTesting_JoinType, _
            GetDoublePrefix(HCTable.tlbTesting, HCTable.tlbMaterial, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            GetDoublePrefix(HCTable.tlbBatchTest, HCTable.tlbMaterial, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            tlbTesting_Condition, _
            fn_HumanCase_SelectList_Name, _
            NotInCondition( _
                index, _
                GetPrefix(HCTable.tlbMaterial, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
                "idfMaterial"), _
            tlbMaterial_Condition, _
            GetPrefix(HCTable.tlbMaterial, index))
        Return From
    End Function

    Public Function Get_tlbMaterial_UniqueWhere(ByVal index As Integer, ByVal tlbMaterial_Cond As String, ByVal tlbTesting_Cond As String) As String
        If (index <= 0) OrElse _
           ((Utils.IsEmpty(tlbMaterial_Cond) OrElse (tlbMaterial_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) AndAlso _
            (Utils.IsEmpty(tlbTesting_Cond) OrElse (tlbTesting_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbTesting_Cond.Trim()))) Then _
            Return ""
        Dim Where As String = String.Format( _
            "({0}.idfMaterial is null) ", _
            GetPrefix(HCTable.tlbMaterial, index).Replace("_" + index.ToString(), "__" + index.ToString()))
        Return Where
    End Function

    Public Function Get_tlbAntimicrobialTherapy_From(ByVal index As Integer, Optional ByVal joinType As String = "left") As String
        If (index <= 0) Then Return ""
        Dim From As String = String.Format( _
            "{0} join   tlbAntimicrobialTherapy as {1} " + _
            "on         {1}.idfHumanCase = {2}.idfCase " + _
            "           and {1}.intRowStatus = 0 " + _
            "{3}", _
            joinType, _
            GetPrefix(HCTable.tlbAntimicrobialTherapy, index), _
            fn_HumanCase_SelectList_Name, _
            NotInCondition(index, GetPrefix(HCTable.tlbAntimicrobialTherapy, index), "idfAntimicrobialTherapy"))
        Return From
    End Function

    Public Function Get_tlbAntimicrobialTherapy_UniqueFrom(ByVal index As Integer, ByVal cond As String) As String
        If (index <= 0) OrElse Utils.IsEmpty(cond) OrElse (cond.Trim().Length = 0) OrElse _
           S1_Contains_S2("and ", cond.Trim()) Then Return ""
        Dim condition As String = cond.Trim()
        If Not condition.StartsWith("and ") Then condition = "and " + condition + " "
        condition = condition.Replace("_" + index.ToString(), "__" + index.ToString())
        condition = "           " + condition
        Dim From As String = String.Format( _
            "left join  tlbAntimicrobialTherapy as {0} " + _
            "on         {0}.idfHumanCase = {1}.idfHumanCase " + _
            "           and {0}.intRowStatus = 0 " + _
            "{2}" + _
            "{3}" + _
            "           and {0}.idfAntimicrobialTherapy < {1}.idfAntimicrobialTherapy ", _
            GetPrefix(HCTable.tlbAntimicrobialTherapy, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
            GetPrefix(HCTable.tlbAntimicrobialTherapy, index), _
            NotInCondition( _
                index, _
                GetPrefix(HCTable.tlbAntimicrobialTherapy, index).Replace("_" + index.ToString(), "__" + index.ToString()), _
                "idfAntimicrobialTherapy"), _
            condition)
        Return From
    End Function

    Public Function Get_tlbAntimicrobialTherapy_UniqueWhere(ByVal index As Integer, ByVal cond As String) As String
        If (index <= 0) OrElse Utils.IsEmpty(cond) OrElse (cond.Trim().Length = 0) OrElse _
           S1_Contains_S2("and ", cond.Trim()) Then Return ""
        Dim Where As String = String.Format( _
            "({0}.idfAntimicrobialTherapy is null) ", _
            GetPrefix(HCTable.tlbAntimicrobialTherapy, index).Replace("_" + index.ToString(), "__" + index.ToString()))
        Return Where
    End Function

#Region " Shared Functions "

    Public Shared Function S1_Contains_S2(ByVal s1 As String, ByVal s2 As String) As Boolean
        Dim res As Boolean = False
        Dim Length1 As Integer = s1.Length
        Dim Length2 As Integer = s2.Length
        Dim i As Integer = 0
        While (i <= Length1 - Length2) AndAlso Not s1.Substring(i, Length2).Equals(s2)
            i = i + 1
        End While
        If i <= Length1 - Length2 Then res = True
        Return res
    End Function

    Public Shared Function fnSelectList_Name(Optional ByVal ObjectName As String = "HumanCase") As String
        If Utils.IsEmpty(ObjectName) Then ObjectName = "HumanCase"
        Return String.Format("fn_{0}_SelectList", ObjectName)
    End Function

    Public Shared Function GetPrefix(ByVal table As HCTable, ByVal ObjectName As String) As String
        Select Case table
            'Case HCTable.tlbCase
            '    Return "c"
            Case HCTable.tlbHumanCase
                Return "hc"
            Case HCTable.tlbHuman
                Return "h"
            Case HCTable.tlbGeoLocation_case
                Return "gl_case"
            Case HCTable.tlbGeoLocation_home
                Return "gl_home"
            Case HCTable.tlbGeoLocation_emp
                Return "gl_emp"
            Case HCTable.tlbGeoLocation_reg
                Return "gl_reg"
            Case HCTable.tlbOffice_sent
                Return "o_sent"
            Case HCTable.tlbOffice_rec
                Return "o_rec"
            Case HCTable.tlbOffice_inv
                Return "o_inv"
            Case HCTable.tlbOutbreak
                Return "out"
            Case HCTable.tlbObservation_cs
                Return "obs_cs"
            Case HCTable.tlbObservation_epi
                Return "obs_epi"
            Case HCTable.tlbActivityParameters
                Return "ap"
            Case HCTable.tlbContactedCasePerson
                Return "ccp"
            Case HCTable.tlbMaterial
                Return "m"
            Case HCTable.tlbTesting
                Return "t"
            Case HCTable.tlbBatchTest
                Return "bt"
            Case HCTable.tlbContainer
                Return "c"
            Case HCTable.tlbAntimicrobialTherapy
                Return "at"
        End Select
        Return fnSelectList_Name(ObjectName)
    End Function

    Public Shared Function GetPrefix(ByVal table As HCTable, ByVal index As Integer, ByVal ObjectName As String) As String
        If index > 0 Then Return GetPrefix(table, ObjectName) + "_" + index.ToString()
        Return GetPrefix(table, ObjectName)
    End Function

    Public Shared Function GetHCTable(ByVal prefix As String, ByVal ObjectName As String) As HCTable
        If Utils.IsEmpty(prefix) Then Return HCTable.tlbNone
        Select Case prefix.ToLower(Globalization.CultureInfo.InvariantCulture)
            'Case GetPrefix(HCTable.tlbCase, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
            '    Return HCTable.tlbCase
            Case GetPrefix(HCTable.tlbHumanCase, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbHumanCase
            Case GetPrefix(HCTable.tlbHuman, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbHuman
            Case GetPrefix(HCTable.tlbGeoLocation_case, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbGeoLocation_case
            Case GetPrefix(HCTable.tlbGeoLocation_home, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbGeoLocation_home
            Case GetPrefix(HCTable.tlbGeoLocation_emp, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbGeoLocation_emp
            Case GetPrefix(HCTable.tlbGeoLocation_reg, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbGeoLocation_reg
            Case GetPrefix(HCTable.tlbOffice_sent, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbOffice_sent
            Case GetPrefix(HCTable.tlbOffice_rec, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbOffice_rec
            Case GetPrefix(HCTable.tlbOffice_inv, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbOffice_inv
            Case GetPrefix(HCTable.tlbOutbreak, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbOutbreak
            Case GetPrefix(HCTable.tlbObservation_cs, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbObservation_cs
            Case GetPrefix(HCTable.tlbObservation_epi, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbObservation_epi
            Case GetPrefix(HCTable.tlbActivityParameters, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbActivityParameters
            Case GetPrefix(HCTable.tlbContactedCasePerson, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbContactedCasePerson
            Case GetPrefix(HCTable.tlbMaterial, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbMaterial
            Case GetPrefix(HCTable.tlbTesting, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbTesting
            Case GetPrefix(HCTable.tlbBatchTest, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbBatchTest
            Case GetPrefix(HCTable.tlbContainer, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbContainer
            Case GetPrefix(HCTable.tlbAntimicrobialTherapy, ObjectName).ToLower(Globalization.CultureInfo.InvariantCulture)
                Return HCTable.tlbAntimicrobialTherapy
        End Select
        Return HCTable.tlbNone
    End Function

    Public Shared Function GetHCTable(ByVal prefix As String, ByVal index As Integer, ByVal ObjectName As String) As HCTable
        If (index > 0) AndAlso (Not Utils.IsEmpty(prefix)) AndAlso _
           (prefix.EndsWith("_" + index.ToString())) AndAlso (prefix.Length > index.ToString().Length + 1) Then
            Return GetHCTable(prefix.Substring(0, prefix.Length - index.ToString().Length - 1), ObjectName)
        End If
        Return GetHCTable(prefix, ObjectName)
    End Function

    Public Shared Function GetDoublePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal ObjectName As String) As String
        Return GetPrefix(firstT, ObjectName) + "_" + GetPrefix(secondT, ObjectName)
    End Function

    Public Shared Function GetTriplePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal thirdT As HCTable, ByVal ObjectName As String) As String
        Return GetPrefix(firstT, ObjectName) + "_" + GetPrefix(secondT, ObjectName) + "_" + GetPrefix(thirdT, ObjectName)
    End Function

    Public Shared Function GetDoublePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal index As Integer, ByVal ObjectName As String) As String
        If index > 0 Then Return GetDoublePrefix(firstT, secondT, ObjectName) + "_" + index.ToString()
        Return GetDoublePrefix(firstT, secondT, ObjectName)
    End Function

    Public Shared Function GetTriplePrefix(ByVal firstT As HCTable, ByVal secondT As HCTable, ByVal thirdT As HCTable, ByVal index As Integer, ByVal ObjectName As String) As String
        If index > 0 Then Return GetTriplePrefix(firstT, secondT, thirdT, ObjectName) + "_" + index.ToString()
        Return GetTriplePrefix(firstT, secondT, thirdT, ObjectName)
    End Function

    Private Shared Function GetSQLVariantCondition(ByVal fieldName As String, ByVal val As Object) As String
        If Utils.IsEmpty(fieldName) OrElse Utils.IsEmpty(val) Then Return ""
        Dim Cond As String = ""
        If (val.GetType() Is GetType(String)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') in ('char', 'nchar', 'nvarchar', 'varchar')) " + _
                "and (cast({0} as nvarchar) like {1}))", _
                fieldName, _
                FieldValue.CorrectLikeValue(Utils.Str(val), GetType(String)) _
            )
        ElseIf (val.GetType() Is GetType(Double)) OrElse _
               (val.GetType() Is GetType(Decimal)) OrElse _
               (val.GetType() Is GetType(Single)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') in ('decimal', 'float', 'numeric', 'real')) " + _
                "and (cast({0} as float) = {1}))", _
                fieldName, _
                val _
            )
        ElseIf (val.GetType() Is GetType(Long)) OrElse _
               (val.GetType() Is GetType(Integer)) OrElse _
               (val.GetType() Is GetType(Short)) OrElse _
               (val.GetType() Is GetType(Byte)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') in ('bigint', 'int', 'smallint', 'tinyint')) " + _
                "and (cast({0} as bigint) = {1}))", _
                fieldName, _
                val _
            )
        ElseIf (val.GetType() Is GetType(Boolean)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') = 'bit')) " + _
                "and (cast({0} as bit) = {1}))", _
                fieldName, _
                Utils.Str(val).Replace(Boolean.TrueString, "1").Replace(Boolean.FalseString, "0") _
            )
        ElseIf (val.GetType() Is GetType(System.Guid)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') = 'uniqueidentifier')) " + _
                "and (cast({0} as uniqueidentifier) = '{1}'))", _
                fieldName, _
                val _
            )
        ElseIf (val.GetType() Is GetType(Date)) OrElse _
               (val.GetType() Is GetType(System.TimeSpan)) Then
            Cond = String.Format( _
                "((SQL_VARIANT_PROPERTY({0}, 'BaseType') in ('datetime', 'smalldatetime')) " + _
                "and (cast({0} as nvarchar) like {1}))", _
                fieldName, _
                FieldValue.CorrectLikeValue(Utils.Str(val), GetType(Date)) _
            )
        End If
        Return Cond
    End Function

    'Private Shared Function Get_tlbCase_From(ByVal ObjectName As String, ByVal joinType As String) As String
    '    Dim DefaultJoinType As String = "left"
    '    If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
    '        DefaultJoinType = "inner"
    '    End If
    '    Dim From As String = String.Format( _
    '        "{0} join   tlbCase as {1} " + _
    '        "on         {1}.idfCase = {2}.idfCase " + _
    '        "           and {1}.intRowStatus = 0 ", _
    '        DefaultJoinType, _
    '        GetPrefix(HCTable.tlbCase, ObjectName), _
    '        fnSelectList_Name(ObjectName))
    '    Return From
    'End Function

    Private Shared Function Get_tlbHumanCase_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   " + _
            "   tlbHumanCase as {1} " + _
            "on         {1}.idfHumanCase = {2}.idfCase ", _
            DefaultJoinType, _
            GetPrefix(HCTable.tlbHumanCase, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbHuman_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   " + _
            "   tlbHuman as {1} " + _
            "on         {1}.idfHuman = {2}.idfHuman " + _
            "           and {1}.intRowStatus = 0 ", _
            DefaultJoinType, _
            GetPrefix(HCTable.tlbHuman, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbGeoLocation_home_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHuman as {1} " + _
            "   inner join  tlbGeoLocation as {2} " + _
            "   on          {2}.idfGeoLocation = {1}.idfCurrentResidenceAddress " + _
            "               and {2}.idfsGeoLocationType = 10036001 /*'lctAddress'*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHuman = {3}.idfHuman " + _
            "           and {1}.intRowStatus = 0 ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHuman, HCTable.tlbGeoLocation_home, ObjectName), _
            GetPrefix(HCTable.tlbGeoLocation_home, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbGeoLocation_emp_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHuman as {1} " + _
             "   inner join  tlbGeoLocation as {2} " + _
            "   on          {2}.idfGeoLocation = {1}.idfEmployerAddress " + _
            "               and {2}.idfsGeoLocationType = 10036001 /*'lctAddress'*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHuman = {3}.idfHuman " + _
            "           and {1}.intRowStatus = 0 ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHuman, HCTable.tlbGeoLocation_emp, ObjectName), _
            GetPrefix(HCTable.tlbGeoLocation_emp, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbGeoLocation_reg_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHuman as {1} " + _
            "   inner join  tlbGeoLocation as {2} " + _
            "   on          {2}.idfGeoLocation = {1}.idfRegistrationAddress " + _
            "               and {2}.idfsGeoLocationType = 10036001 /*'lctAddress'*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHuman = {3}.idfHuman " + _
            "           and {1}.intRowStatus = 0 ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHuman, HCTable.tlbGeoLocation_reg, ObjectName), _
            GetPrefix(HCTable.tlbGeoLocation_reg, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbOffice_sent_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbOffice as {2} " + _
            "   on          {2}.idfOffice = {1}.idfSentByOffice " + _
            "               and {3}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbOffice_sent, ObjectName), _
            GetPrefix(HCTable.tlbOffice_sent, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbOffice_rec_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbOffice as {2} " + _
            "   on          {2}.idfOffice = {1}.idfReceivedByOffice " + _
            "               and {3}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbOffice_rec, ObjectName), _
            GetPrefix(HCTable.tlbOffice_rec, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbOffice_inv_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbOffice as {2} " + _
            "   on          {2}.idfOffice = {1}.idfInvestigatedByOffice " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbOffice_inv, ObjectName), _
            GetPrefix(HCTable.tlbOffice_inv, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbGeoLocation_case_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbGeoLocation as {2} " + _
            "   on          {2}.idfGeoLocation = {1}.idfPointGeoLocation " + _
            "               and {2}.idfsGeoLocationType <> 10036001 /*'lctAddress'*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbGeoLocation_case, ObjectName), _
            GetPrefix(HCTable.tlbGeoLocation_case, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Private Shared Function Get_tlbOutbreak_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbOutbreak as {2} " + _
            "   on          {2}.idfOutbreak = {1}.idfOutbreak " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase " + _
            "           and {1}.intRowStatus = 0 ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbOutbreak, ObjectName), _
            GetPrefix(HCTable.tlbOutbreak, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Public Shared Function Get_tlbObservation_cs_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbObservation as {2} " + _
            "   on          {2}.idfObservation = {1}.idfCSObservation " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbObservation_cs, ObjectName), _
            GetPrefix(HCTable.tlbObservation_cs, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Public Shared Function Get_tlbObservation_epi_From(ByVal ObjectName As String, ByVal joinType As String) As String
        Dim DefaultJoinType As String = "left"
        If Utils.Str(joinType).Trim().ToLower(Globalization.CultureInfo.InvariantCulture) = "inner" Then
            DefaultJoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "{0} join   ( " + _
            "   tlbHumanCase as {1} " + _
            "   inner join  tlbObservation as {2} " + _
            "   on          {2}.idfObservation = {1}.idfEpiObservation " + _
            "               and {2}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {1}.idfHumanCase = {3}.idfCase ", _
            DefaultJoinType, _
            GetDoublePrefix(HCTable.tlbHumanCase, HCTable.tlbObservation_epi, ObjectName), _
            GetPrefix(HCTable.tlbObservation_epi, ObjectName), _
            fnSelectList_Name(ObjectName))
        Return From
    End Function

    Public Shared Function GetFrom(ByVal table As HCTable, ByVal ObjectName As String, ByVal joinType As String) As String
        Select Case table
            'Case HCTable.tlbCase
            '    Return Get_tlbCase_From(ObjectName, joinType)
            Case HCTable.tlbHumanCase
                Return Get_tlbHumanCase_From(ObjectName, joinType)
            Case HCTable.tlbHuman
                Return Get_tlbHuman_From(ObjectName, joinType)
            Case HCTable.tlbGeoLocation_home
                Return Get_tlbGeoLocation_home_From(ObjectName, joinType)
            Case HCTable.tlbGeoLocation_emp
                Return Get_tlbGeoLocation_emp_From(ObjectName, joinType)
            Case HCTable.tlbGeoLocation_reg
                Return Get_tlbGeoLocation_reg_From(ObjectName, joinType)
            Case HCTable.tlbOffice_sent
                Return Get_tlbOffice_sent_From(ObjectName, joinType)
            Case HCTable.tlbOffice_rec
                Return Get_tlbOffice_rec_From(ObjectName, joinType)
            Case HCTable.tlbOffice_inv
                Return Get_tlbOffice_inv_From(ObjectName, joinType)
            Case HCTable.tlbGeoLocation_case
                Return Get_tlbGeoLocation_case_From(ObjectName, joinType)
            Case HCTable.tlbOutbreak
                Return Get_tlbOutbreak_From(ObjectName, joinType)
            Case HCTable.tlbObservation_cs
                Return Get_tlbObservation_cs_From(ObjectName, joinType)
            Case HCTable.tlbObservation_epi
                Return Get_tlbObservation_epi_From(ObjectName, joinType)
        End Select
        Return ""
    End Function

    Public Shared Sub CorrectFromCondition(ByVal table As HCTable, ByVal ObjectName As String, ByVal joinType As String, ByRef From As String)
        If Utils.IsEmpty(From) Then From = ""
        Dim AddFrom As String = GetFrom(table, ObjectName, joinType)
        If (Not Utils.IsEmpty(AddFrom)) AndAlso (Not S1_Contains_S2(From, AddFrom)) Then
            If (Not Utils.IsEmpty(From)) AndAlso (Not From.EndsWith(" ")) Then From = From + " "
            From = From + AddFrom
        End If
    End Sub

    Private Shared Function NotInCondition(ByVal index As Integer, ByVal prefix As String, ByVal fieldName As String) As String
        If (index <= 1) OrElse _
           Utils.IsEmpty(prefix) OrElse _
           (Not prefix.EndsWith("_" + index.ToString())) OrElse _
           Utils.IsEmpty(fieldName) Then Return ""
        Dim FinalPrefix As String = prefix
        If prefix.EndsWith("__" + index.ToString()) Then _
            FinalPrefix = prefix.Replace("__" + index.ToString(), "_" + index.ToString())
        Dim condition As String = String.Format( _
            "           and {0}.{1} not in ({2}.{1}", _
            prefix, _
            fieldName, _
            FinalPrefix.Replace("_" + index.ToString(), "_1"))
        If index > 2 Then
            For i As Integer = 2 To index - 1
                condition = condition + String.Format(", {0}.{1}", FinalPrefix.Replace("_" + index.ToString(), "_" + i.ToString()), fieldName)
            Next
        End If
        condition = condition + ") "
        Return condition
    End Function

    Public Shared Function Get_tlbMaterial_From(ByVal ObjectName As String, ByVal index As Integer, Optional ByVal Add_tlbHuman_From As Boolean = False, Optional ByVal joinType As String = "left") As String
        If (index <= 0) Then Return ""
        Dim tlbHuman_From As String = ""
        If Add_tlbHuman_From Then tlbHuman_From = Get_tlbHuman_From(ObjectName, joinType)
        Dim From As String = String.Format( _
            "{0}" + _
            "{1} join   ( " + _
            "   tlbMaterial as {2} " + _
            "   left join   ( " + _
            "       tlbTesting as {3} " + _
            "       left join   tlbBatchTest as {4} " + _
            "       on          {4}.idfBatchTest = {3}.idfBatchTest " + _
            "                   and {4}.intRowStatus = 0 " + _
            "               ) " + _
            "   on          {3}.idfTesting = {2}.idfTesting " + _
            "               and {3}.idfMaterial = {2}.idfMaterial " + _
            "               and {3}.idfsTestStatus = 10001001 /*Completed*/ " + _
            "               and {3}.intRowStatus = 0 " + _
            "           ) " + _
            "on         {2}.idfCase = {5}.idfCase " + _
            "           and {2}.intRowStatus = 0 " + _
            "{6}", _
            tlbHuman_From, _
            joinType, _
            GetPrefix(HCTable.tlbMaterial, index, ObjectName), _
            GetDoublePrefix(HCTable.tlbTesting, HCTable.tlbMaterial, index, ObjectName), _
            GetDoublePrefix(HCTable.tlbBatchTest, HCTable.tlbMaterial, index, ObjectName), _
            fnSelectList_Name(ObjectName), _
            NotInCondition(index, GetPrefix(HCTable.tlbMaterial, index, ObjectName), "idfMaterial"))
        Return From
    End Function

    Public Shared Function Get_tlbMaterial_UniqueFrom(ByVal ObjectName As String, ByVal index As Integer, ByVal tlbMaterial_Cond As String, ByVal tlbTesting_Cond As String) As String
        If (index <= 0) OrElse _
           ((Utils.IsEmpty(tlbMaterial_Cond) OrElse (tlbMaterial_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) AndAlso _
            (Utils.IsEmpty(tlbTesting_Cond) OrElse (tlbTesting_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbTesting_Cond.Trim()))) Then _
            Return ""
        Dim tlbMaterial_Condition As String = ""
        Dim tlbTesting_Condition As String = ""
        Dim tlbTesting_JoinType As String = "left"
        If (Not Utils.IsEmpty(tlbMaterial_Cond)) AndAlso (tlbMaterial_Cond.Trim().Length > 0) AndAlso _
           (Not S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) Then
            tlbMaterial_Condition = tlbMaterial_Cond.Trim()
            If Not tlbMaterial_Condition.StartsWith("and ") Then tlbMaterial_Condition = "and " + tlbMaterial_Condition
            tlbMaterial_Condition = tlbMaterial_Condition.Replace("_" + index.ToString(), "__" + index.ToString())
            tlbMaterial_Condition = "           " + tlbMaterial_Condition + " "
        End If
        If (Not Utils.IsEmpty(tlbTesting_Cond)) AndAlso (tlbTesting_Cond.Trim().Length > 0) AndAlso _
           (Not S1_Contains_S2("and ", tlbTesting_Cond.Trim())) Then
            tlbTesting_Condition = tlbTesting_Cond.Trim()
            If Not tlbTesting_Condition.StartsWith("and ") Then tlbTesting_Condition = "and " + tlbTesting_Condition
            tlbTesting_Condition = tlbTesting_Condition.Replace("_" + index.ToString(), "__" + index.ToString())
            tlbTesting_Condition = "           " + tlbTesting_Condition + " "
            tlbTesting_JoinType = "inner"
        End If
        Dim From As String = String.Format( _
            "left join   ( " + _
            "   tlbMaterial as {0} " + _
            "   {1} join    ( " + _
            "       tlbTesting as {2} " + _
            "       left join   tlbBatchTest as {3} " + _
            "       on          {3}.idfBatchTest = {2}.idfBatchTest " + _
            "                   and {3}.intRowStatus = 0 " + _
            "               ) " + _
            "   on          {2}.idfTesting = {0}.idfTesting " + _
            "               and {2}.idfMaterial = {0}.idfMaterial " + _
            "               and {2}.idfsTestStatus = 10001001 /*Completed*/ " + _
            "               and {2}.intRowStatus = 0 " + _
            "{4}" + _
            "           ) " + _
            "on         {0}.idfCase = {5}.idfCase " + _
            "           and {0}.intRowStatus = 0 " + _
            "{6}" + _
            "{7}" + _
            "           and {0}.idfMaterial < {8}.idfMaterial ", _
            GetPrefix(HCTable.tlbMaterial, index, ObjectName).Replace("_" + index.ToString(), "__" + index.ToString()), _
            tlbTesting_JoinType, _
            GetDoublePrefix(HCTable.tlbTesting, HCTable.tlbMaterial, index, ObjectName).Replace("_" + index.ToString(), "__" + index.ToString()), _
            GetDoublePrefix(HCTable.tlbBatchTest, HCTable.tlbMaterial, index, ObjectName).Replace("_" + index.ToString(), "__" + index.ToString()), _
            tlbTesting_Condition, _
            fnSelectList_Name(ObjectName), _
            NotInCondition( _
                index, _
                GetPrefix(HCTable.tlbMaterial, index, ObjectName).Replace("_" + index.ToString(), "__" + index.ToString()), _
                "idfMaterial"), _
            tlbMaterial_Condition, _
            GetPrefix(HCTable.tlbMaterial, index, ObjectName))
        Return From
    End Function

    Public Shared Function Get_tlbMaterial_UniqueWhere(ByVal ObjectName As String, ByVal index As Integer, ByVal tlbMaterial_Cond As String, ByVal tlbTesting_Cond As String) As String
        If (index <= 0) OrElse _
           ((Utils.IsEmpty(tlbMaterial_Cond) OrElse (tlbMaterial_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbMaterial_Cond.Trim())) AndAlso _
            (Utils.IsEmpty(tlbTesting_Cond) OrElse (tlbTesting_Cond.Trim().Length = 0) OrElse S1_Contains_S2("and ", tlbTesting_Cond.Trim()))) Then _
            Return ""
        Dim Where As String = String.Format( _
            "({0}.idfMaterial is null) ", _
            GetPrefix(HCTable.tlbMaterial, index, ObjectName).Replace("_" + index.ToString(), "__" + index.ToString()))
        Return Where
    End Function

    Public Shared Sub CorrectMaterialFromCondition( _
        ByRef From As String, _
        ByVal ObjectName As String, _
        ByVal index As Integer, _
        ByVal tlbMaterial_Cond As String, _
        ByVal tlbTesting_Cond As String, _
        Optional ByVal Add_tlbHuman_From As Boolean = False, _
        Optional ByVal joinType As String = "left")

        If Utils.IsEmpty(From) Then From = ""

        Dim UniqueWhere As String = Get_tlbMaterial_UniqueWhere( _
                ObjectName, index, tlbMaterial_Cond, tlbTesting_Cond)
        If Not Utils.IsEmpty(UniqueWhere) Then
            Dim AddFrom As String = Get_tlbMaterial_From(ObjectName, index, False)
            Dim UniqueFrom As String = Get_tlbMaterial_UniqueFrom( _
                    ObjectName, index, tlbMaterial_Cond, tlbTesting_Cond)
            If (Not Utils.IsEmpty(AddFrom)) AndAlso (Not Utils.IsEmpty(UniqueFrom)) Then
                AddFrom = AddFrom + UniqueFrom
                CorrectFromCondition(HCTable.tlbHuman, ObjectName, "left", From)
                If (Not Utils.IsEmpty(AddFrom)) AndAlso (Not S1_Contains_S2(From, AddFrom)) Then
                    If (Not Utils.IsEmpty(From)) AndAlso (Not From.EndsWith(" ")) Then From = From + " "
                    From = From + AddFrom
                End If
            End If
        End If
    End Sub

#End Region

End Class
