Imports System.Data
Imports System.Data.Common
Imports bv.common.Core
Imports bv.common.Enums

Public Class HumanCaseDeduplication_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "HumanCaseDeduplication"
    End Sub

    Public Const tlbHumanCase As String = "tlbHumanCase"
    Public Const tlbMaterial As String = "tlbMaterial"

    Public PropertyArr As ArrayList

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
        PropertyArr.Add(New CaseProperty(CaseProperty.CasePropertyKind.PersonalId, "tlbHumanCase", Nothing, "strPersonID", CaseProperty.CasePropertyKind.idfHuman, ds))
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

    Public Function FindProperty(ByVal PropertyKind As CaseProperty.CasePropertyKind) As CaseProperty
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim cur_Property As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                If cur_Property.Kind = PropertyKind Then
                    Return cur_Property
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Function FindProperty(ByVal PropertyName As String) As CaseProperty
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim cur_Property As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                If cur_Property.Name = PropertyName Then
                    Return cur_Property
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
        'Dim m_primaryID As Object = m_SurvivorID
        'm_SurvivorID = m_SupersededID
        'm_SupersededID = m_primaryID
        If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            For i As Integer = 0 To PropertyArr.Count - 1
                Dim cur_Property As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)
                cur_Property.ChangeRoles()
            Next
        End If
    End Sub

    Dim HCDeduplication_Adapter As DbDataAdapter

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

            Dim HumanCaseDeduplicationDetail_Adapter As DbDataAdapter
            HumanCaseDeduplicationDetail_Adapter = CreateAdapter(cmdHumanCaseDeduplication, False)
            ds.EnforceConstraints = False
            HumanCaseDeduplicationDetail_Adapter.Fill(ds, tlbHumanCase)
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

            Dim HumanCaseDeduplicationMaterial_Adapter As DbDataAdapter
            HumanCaseDeduplicationMaterial_Adapter = CreateAdapter(cmdHumanCaseDeduplicationMaterial, False)
            ds.EnforceConstraints = False

            HumanCaseDeduplicationMaterial_Adapter.Fill(ds, tlbMaterial)
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
        Return Nothing
    End Function

    Private Function ParamVal(ByVal value As Object) As Object
        If (value Is Nothing) OrElse (value Is DBNull.Value) Then
            Return DBNull.Value
        End If
        If TypeOf (value) Is DateTime Then
            Return CDate(value).ToString("yyyy/MM/dd")
        End If
        If TypeOf (value) Is String Then
            Return Utils.Str(value)
        End If
        Return value
    End Function

    Public Function GetValue(ByVal ds As DataSet, ByVal TableName As String, ByVal FieldName As String, ByVal rowType As String) As Object
        If (Not Utils.IsEmpty(rowType)) AndAlso _
           (Not Utils.IsEmpty(TableName)) AndAlso _
           (Not ds Is Nothing) AndAlso (ds.Tables.Contains(TableName) AndAlso _
           (ds.Tables(TableName).Rows.Count > 0)) Then
            Dim r As DataRow = ds.Tables(TableName).Rows.Find(rowType)
            If (Not r Is Nothing) Then
                If (Not Utils.IsEmpty(FieldName)) AndAlso _
                   (ds.Tables(TableName).Columns.Contains(FieldName)) Then
                    Return r(FieldName)
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

    'TODO: Update PostDetail method
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            '(only for non-simple version of de-duplication)
            'If (Not PropertyArr Is Nothing) AndAlso (PropertyArr.Count > 0) Then
            'For i As Integer = 0 To PropertyArr.Count - 1
            'Dim cur_Property As CaseProperty = CType(PropertyArr.Item(i), CaseProperty)

            'Dim cmd As IDbCommand
            'cmd = CreateSPCommand("spHumanCaseDeduplication_FieldPost", Connection, transaction)
            'AddTypedParam(cmd, "@FieldType", SqlDbType.VarChar)
            'AddTypedParam(cmd, "@IsSurvivorPrimary", SqlDbType.Bit)
            'AddTypedParam(cmd, "@SurvivorID", SqlDbType.BigInt)
            'AddTypedParam(cmd, "@SurvivorText", SqlDbType.NVarChar)
            'AddTypedParam(cmd, "@SupersededID", SqlDbType.BigInt)
            'AddTypedParam(cmd, "@SupersededText", SqlDbType.NVarChar)
            'AddTypedParam(cmd, "@SurvivorParentID", SqlDbType.BigInt)
            'AddTypedParam(cmd, "@SupersededParentID", SqlDbType.BigInt)

            'SetParam(cmd, "@FieldType", cur_Property.Name)
            'SetParam(cmd, "@IsSurvivorPrimary", cur_Property.IsSurvivorValuePrimary)
            'SetParam(cmd, "@SurvivorID", ParamVal(cur_Property.SurvivorValueID))
            'SetParam(cmd, "@SurvivorText", ParamVal(cur_Property.SurvivorValueText))
            'SetParam(cmd, "@SupersededID", ParamVal(cur_Property.SupersededValueID))
            'SetParam(cmd, "@SupersededText", ParamVal(cur_Property.SupersededValueText))

            'If (cur_Property.ParentKind <> CaseProperty.CasePropertyKind.None) Then
            'Dim parent_Property As CaseProperty = FindProperty(cur_Property.ParentKind)
            'If (Not parent_Property Is Nothing) Then
            'SetParam(cmd, "@SurvivorParentID", ParamVal(parent_Property.SurvivorValueID))
            'SetParam(cmd, "@SupersededParentID", ParamVal(parent_Property.SupersededValueID))
            'Else
            'SetParam(cmd, "@SurvivorParentID", DBNull.Value)
            'SetParam(cmd, "@SupersededParentID", DBNull.Value)
            'End If
            'Else
            'SetParam(cmd, "@SurvivorParentID", DBNull.Value)
            'SetParam(cmd, "@SupersededParentID", DBNull.Value)
            'End If
            'cmd.ExecuteNonQuery()
            'Next
            'End If

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

                    Dim CID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfCase)
                    If Not CID Is Nothing Then
                        SetParam(cmdSample, "@SurvivorID", GetValue(CID.SurvivorValueID))
                        SetParam(cmdSample, "@SupersededID", GetValue(CID.SupersededValueID))
                    Else
                        SetParam(cmdSample, "@SurvivorID", DBNull.Value)
                        SetParam(cmdSample, "@SupersededID", DBNull.Value)
                    End If
                    Dim PID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfHuman)
                    If Not PID Is Nothing Then
                        SetParam(cmdSample, "@SurvivorPartyID", GetValue(PID.SurvivorValueID))
                        SetParam(cmdSample, "@SupersededPartyID", GetValue(PID.SupersededValueID))
                    Else
                        SetParam(cmdSample, "@SurvivorPartyID", DBNull.Value)
                        SetParam(cmdSample, "@SupersededPartyID", DBNull.Value)
                    End If
                    SetParam(cmdSample, "@MaterialID", r("idfMaterial"))
                    SetParam(cmdSample, "@AddToSurvivorCase", r("AddToSurvivorCase"))
                    cmdSample.ExecuteNonQuery()
                Next
            End If

            Dim cmdLink As IDbCommand
            cmdLink = CreateSPCommand("spHumanCaseDeduplicationLinks_Post", Connection, transaction)

            AddTypedParam(cmdLink, "@SurvivorID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SupersededID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SurvivorPartyID", SqlDbType.BigInt)
            AddTypedParam(cmdLink, "@SupersededPartyID", SqlDbType.BigInt)

            Dim CaseID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfCase)
            If Not CaseID Is Nothing Then
                SetParam(cmdLink, "@SurvivorID", GetValue(CaseID.SurvivorValueID))
                SetParam(cmdLink, "@SupersededID", GetValue(CaseID.SupersededValueID))
            Else
                SetParam(cmdLink, "@SurvivorID", DBNull.Value)
                SetParam(cmdLink, "@SupersededID", DBNull.Value)
            End If
            Dim PartyID As CaseProperty = FindProperty(CaseProperty.CasePropertyKind.idfHuman)
            If Not PartyID Is Nothing Then
                SetParam(cmdLink, "@SurvivorPartyID", GetValue(PartyID.SurvivorValueID))
                SetParam(cmdLink, "@SupersededPartyID", GetValue(PartyID.SupersededValueID))
            Else
                SetParam(cmdLink, "@SurvivorPartyID", DBNull.Value)
                SetParam(cmdLink, "@SupersededPartyID", DBNull.Value)
            End If
            cmdLink.ExecuteNonQuery()

            If Not CaseID Is Nothing Then
                Dim cmdHCDel As IDbCommand
                cmdHCDel = CreateSPCommand("spHumanCase_DeleteInternal", Connection, transaction)
                AddTypedParam(cmdHCDel, "@ID", SqlDbType.BigInt)
                SetParam(cmdHCDel, "@ID", GetValue(CaseID.SupersededValueID))
                AddParam(cmdHCDel, "@ClearFiltration", False)
                cmdHCDel.ExecuteNonQuery()
            End If

            'If Not PartyID Is Nothing Then
            '    Dim cmdPartyDel As IDbCommand
            '    cmdPartyDel = CreateSPCommand("spPatient_Delete", Connection, transaction)
            '    AddTypedParam(cmdPartyDel, "@ID", SqlDbType.UniqueIdentifier)
            '    SetParam(cmdPartyDel, "@ID", GetValue(PartyID.SupersededValueID))
            '    cmdPartyDel.ExecuteNonQuery()
            'End If

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
