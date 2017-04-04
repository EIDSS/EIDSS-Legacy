Imports System.Data
Imports bv.common.Core
Imports bv.common.Enums

Public Class HumanCaseDeduplication_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "HumanCaseDeduplication"
    End Sub

    Public Const tlbHumanCase As String = "tlbHumanCase"
    Public Const tlbMaterial As String = "tlbMaterial"

    Public Property PropertyArr As ArrayList

    Private Sub FillPropertyArr(ByVal ds As DataSet)
        PropertyArr = New ArrayList()
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.idfCase, "tlbHumanCase", "idfCase", Nothing, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.CaseID, "tlbHumanCase", Nothing, "strCaseID", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.LocalID, "tlbHumanCase", Nothing, "strLocalIdentifier", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.Diagnosis, "tlbHumanCase", "idfsTentativeDiagnosis", "TentativeDiagnosis_Name", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.DiagnosisDate, "tlbHumanCase", Nothing, "datTentativeDiagnosisDate", CaseProperty.CasePropertyKind.idfCase, ds))

        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.idfHuman, "tlbHumanCase", "idfHuman", Nothing, CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.LastName, "tlbHumanCase", Nothing, "strLastName", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.FirstName, "tlbHumanCase", Nothing, "strFirstName", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.SecondName, "tlbHumanCase", Nothing, "strSecondName", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.DOB, "tlbHumanCase", Nothing, "datDateofBirth", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PersonalIdType, "tlbHumanCase", "idfsPersonIDType", "strPersonIDType", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PersonalID, "tlbHumanCase", Nothing, "strPersonID", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.Age, "tlbHumanCase", Nothing, "intPatientAge", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.AgeUnits, "tlbHumanCase", "idfsHumanAgeType", "HumanAgeType_Name", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.Sex, "tlbHumanCase", "idfsHumanGender", "HumanGender_Name", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, "tlbHumanCase", "idfCurrentResidenceAddress", "idfCurrentResidenceAddress", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.RegionHome, "tlbHumanCase", Nothing, "Region", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.RayonHome, "tlbHumanCase", Nothing, "Rayon", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.SettlementHome, "tlbHumanCase", Nothing, "Settlement", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.StreetHome, "tlbHumanCase", Nothing, "Street", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PostalCodeHome, "tlbHumanCase", Nothing, "PostalCode", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.HouseHome, "tlbHumanCase", Nothing, "House", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.BuildingHome, "tlbHumanCase", Nothing, "Building", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.AptmHome, "tlbHumanCase", Nothing, "Appartment", CaseProperty.CasePropertyKind.idfCurrentResidenceAddress, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PhoneNumber, "tlbHumanCase", Nothing, "strHomePhone", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.Nationality, "tlbHumanCase", "idfsNationality", "Nationality_Name", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.EmployerName, "tlbHumanCase", Nothing, "strEmployerName", CaseProperty.CasePropertyKind.idfHuman, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.GeoLocationEmployer, "tlbHumanCase", "idfEmployerAddress", "EmployerAddress_Name", CaseProperty.CasePropertyKind.idfHuman, ds))

        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.OnsetDate, "tlbHumanCase", Nothing, "datOnSetDate", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.FinalState, "tlbHumanCase", "idfsFinalState", "FinalState_Name", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.ChangedDiagnosis, "tlbHumanCase", "idfsFinalDiagnosis", "FinalDiagnosis_Name", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.ChangedDiagnosisDate, "tlbHumanCase", Nothing, "datFinalDiagnosisDate", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PatientLocationStatus, "tlbHumanCase", "idfsHospitalizationStatus", "HospitalizationStatus_Name", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PatientLocationName, "tlbHumanCase", Nothing, "strCurrentLocation", CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.AddCaseInfo, "tlbHumanCase", Nothing, "strNote", CaseProperty.CasePropertyKind.idfCase, ds))

        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.HumanObsID, "tlbHumanCase", "idfEpiObservation", Nothing, CaseProperty.CasePropertyKind.idfCase, ds))
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.EpiObsID, "tlbHumanCase", "idfCSObservation", Nothing, CaseProperty.CasePropertyKind.idfCase, ds))
    End Sub

    Public Function FindProperty(ByVal propertyKind As CaseProperty.CasePropertyKind) As CaseProperty
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim curProperty As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                If curProperty.Kind = propertyKind Then
                    Return curProperty
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Function FindProperty(ByVal propertyName As String) As CaseProperty
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim curProperty As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                If curProperty.Name = propertyName Then
                    Return curProperty
                End If
            Next
        End If
        Return Nothing
    End Function


    Private m_SurvivorID As Object = Nothing
    Public ReadOnly Property SurvivorID() As Object
        Get
            Return m_SurvivorID
        End Get
    End Property

    Private m_SupersededID As Object = Nothing
    Public ReadOnly Property SupersededID() As Object
        Get
            Return m_SupersededID
        End Get
    End Property

    Public Sub ChangeRoles()
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim curProperty As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                curProperty.ChangeRoles()
            Next
        End If
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

            'tlbHumanCase
            If (TypeOf (ID) Is ArrayList) AndAlso (CType(ID, ArrayList).Count = 2) Then
                m_SurvivorID = CType(ID, ArrayList)(0)
                m_SupersededID = CType(ID, ArrayList)(1)
            End If
            Dim cmdHumanCaseDeduplication As IDbCommand = CreateSPCommand("spHumanCaseDeduplication_SelectDetail")
            AddParam(cmdHumanCaseDeduplication, "@SurvivorID", SurvivorID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmdHumanCaseDeduplication, "@SupersededID", SupersededID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmdHumanCaseDeduplication, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            ds.EnforceConstraints = False
            FillDataset(cmdHumanCaseDeduplication, ds, tlbHumanCase)
            ds.Tables(tlbHumanCase).PrimaryKey = Nothing
            CorrectTable(ds.Tables(tlbHumanCase), tlbHumanCase, "rowType")
            For Each col As DataColumn In ds.Tables(tlbHumanCase).Columns
                col.ReadOnly = False
            Next

            'tlbMaterial
            Dim cmdHumanCaseDeduplicationMaterial As IDbCommand = CreateSPCommand("spHumanCaseDeduplicationMaterial_SelectDetail")
            AddParam(cmdHumanCaseDeduplicationMaterial, "@SurvivorID", SurvivorID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmdHumanCaseDeduplicationMaterial, "@SupersededID", SupersededID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmdHumanCaseDeduplicationMaterial, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            FillDataset(cmdHumanCaseDeduplicationMaterial, ds, tlbMaterial)
            ds.Tables(tlbMaterial).PrimaryKey = Nothing
            CorrectTable(ds.Tables(tlbMaterial), tlbMaterial, "idfMaterial")
            For Each col As DataColumn In ds.Tables(tlbMaterial).Columns
                col.ReadOnly = False
            Next
            ds.Tables(tlbMaterial).Columns("AddToSurvivorCase").ReadOnly = False


            ds.EnforceConstraints = True

            FillPropertyArr(ds)

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Function GetValue(ByVal ds As DataSet, ByVal tableName As String, ByVal fieldName As String, ByVal rowType As String) As Object
        If (Not Utils.IsEmpty(rowType)) AndAlso _
           (Not Utils.IsEmpty(tableName)) AndAlso _
           (Not ds Is Nothing) AndAlso (ds.Tables.Contains(tableName) AndAlso _
           (ds.Tables(tableName).Rows.Count > 0)) Then
            Dim r As DataRow = ds.Tables(tableName).Rows.Find(rowType)
            If (Not r Is Nothing) Then
                If (Not Utils.IsEmpty(fieldName)) AndAlso _
                   (ds.Tables(tableName).Columns.Contains(fieldName)) Then
                    Return r(fieldName)
                End If
            End If
        End If
        Return DBNull.Value
    End Function

    Public Function GetValue(ByVal value As Object) As Object
        If Not Utils.IsEmpty(value) Then
            Return value
        End If
        Return DBNull.Value
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            If ds.Tables(tlbMaterial).Rows.Count > 0 Then
                For Each r As DataRow In ds.Tables(tlbMaterial).Rows
                    Dim cmdSample As IDbCommand
                    cmdSample = CreateSPCommand("spHumanCaseDeduplicationMaterial_Post", Connection, transaction)
                    AddTypedParam(cmdSample, "@SurvivorID", SqlDbType.BigInt)
                    AddTypedParam(cmdSample, "@SupersededID", SqlDbType.BigInt)
                    AddTypedParam(cmdSample, "@SurvivorPartyID", SqlDbType.BigInt)
                    AddTypedParam(cmdSample, "@SupersededPartyID", SqlDbType.BigInt)
                    AddTypedParam(cmdSample, "@MaterialID", SqlDbType.BigInt)
                    AddTypedParam(cmdSample, "@AddToSurvivorCase", SqlDbType.Bit)

                    Dim cid As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfCase)
                    If Not cid Is Nothing Then
                        SetParam(cmdSample, "@SurvivorID", GetValue(cid.SurvivorValueID))
                        SetParam(cmdSample, "@SupersededID", GetValue(cid.SupersededValueID))
                    Else
                        SetParam(cmdSample, "@SurvivorID", DBNull.Value)
                        SetParam(cmdSample, "@SupersededID", DBNull.Value)
                    End If
                    Dim pid As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfHuman)
                    If Not pid Is Nothing Then
                        SetParam(cmdSample, "@SurvivorPartyID", GetValue(pid.SurvivorValueID))
                        SetParam(cmdSample, "@SupersededPartyID", GetValue(pid.SupersededValueID))
                    Else
                        SetParam(cmdSample, "@SurvivorPartyID", DBNull.Value)
                        SetParam(cmdSample, "@SupersededPartyID", DBNull.Value)
                    End If
                    SetParam(cmdSample, "@MaterialID", r("idfMaterial"))
                    SetParam(cmdSample, "@AddToSurvivorCase", r("AddToSurvivorCase"))
                    cmdSample.ExecuteNonQuery()
                    ExecCommand(cmdSample, cmdSample.Connection, transaction, True)
                Next
            End If

            Dim cmdLink As IDbCommand
            cmdLink = CreateSPCommand("spHumanCaseDeduplicationLinks_Post", Connection, transaction)

            AddTypedParam(cmdLink, "@SurvivorID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SupersededID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SurvivorPartyID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SupersededPartyID", SqlDbType.BigInt)

            Dim caseID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfCase)
            If Not caseID Is Nothing Then
                SetParam(cmdLink, "@SurvivorID", GetValue(caseID.SurvivorValueID))
                SetParam(cmdLink, "@SupersededID", GetValue(caseID.SupersededValueID))
            Else
                SetParam(cmdLink, "@SurvivorID", DBNull.Value)
                SetParam(cmdLink, "@SupersededID", DBNull.Value)
            End If
            Dim partyID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfHuman)
            If Not partyID Is Nothing Then
                SetParam(cmdLink, "@SurvivorPartyID", GetValue(partyID.SurvivorValueID))
                SetParam(cmdLink, "@SupersededPartyID", GetValue(partyID.SupersededValueID))
            Else
                SetParam(cmdLink, "@SurvivorPartyID", DBNull.Value)
                SetParam(cmdLink, "@SupersededPartyID", DBNull.Value)
            End If
            cmdLink.ExecuteNonQuery()
            ExecCommand(cmdLink, cmdLink.Connection, transaction, True)

            If Not caseID Is Nothing Then
                Dim cmdHcDel As IDbCommand = CreateSPCommand("spHumanCase_DeleteInternal", Connection, transaction)
                AddTypedParam(cmdHcDel, "@ID", SqlDbType.BigInt)
                SetParam(cmdHcDel, "@ID", GetValue(caseID.SupersededValueID))
                AddParam(cmdHcDel, "@ClearFiltration", False)
                m_Error = ExecCommand(cmdHcDel, Connection, transaction)
                If (Not m_Error Is Nothing) Then
                    Return False
                End If
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
