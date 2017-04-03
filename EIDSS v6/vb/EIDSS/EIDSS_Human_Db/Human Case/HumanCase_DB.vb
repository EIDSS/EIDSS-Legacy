Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Core
Imports bv.common.Diagnostics
Imports bv.model.Model.Core
Imports EIDSS.model.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums
Imports EIDSS.model.Resources

Public Class HumanCase_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "HumanCase"
        IdentityFieldName = "idfCase"
    End Sub

    Public Const tlbHumanCase As String = "tlbHumanCase"
    Public Const tlbContactedCasePerson As String = "tlbContactedCasePerson"
    Public Const tlbAntimicrobialTherapy As String = "tlbAntimicrobialTherapy"
    Public Const tlbChangeDiagnosisHistory As String = "tlbChangeDiagnosisHistory"

    Public PatientID As Object

#Region "Navigator"
    Public Shared Function GetHumanCaseCount(Optional ByVal Connection As IDbConnection = Nothing) As Integer
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnHumanCaseCount(@idfsSite) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfsSite", EIDSS.model.Core.EidssSiteContext.Instance.SiteID)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Dim res As Integer = 0
        If (Not Utils.IsEmpty(val)) AndAlso Integer.TryParse(Utils.Str(val), res) Then
            res = CInt(val)
        End If
        Return res
    End Function

    Public Shared Function GetHumanCaseNumber(ByVal idfCase As Object, Optional ByVal Connection As IDbConnection = Nothing) As Integer
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnHumanCaseNumber(@idfCase) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfCase", idfCase)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Dim res As Integer = 0
        If (Not Utils.IsEmpty(val)) AndAlso Integer.TryParse(Utils.Str(val), res) Then
            res = CInt(val)
        End If
        Return res
    End Function

    Public Shared Function GetFirstHumanCase(Optional ByVal Connection As IDbConnection = Nothing) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnFirstHumanCase(@idfsSite) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfsSite", EIDSS.model.Core.EidssSiteContext.Instance.SiteID)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return val
    End Function

    Public Shared Function GetLastHumanCase(Optional ByVal Connection As IDbConnection = Nothing) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnLastHumanCase(@idfsSite) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfsSite", EIDSS.model.Core.EidssSiteContext.Instance.SiteID)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return val
    End Function

    Public Shared Function GetNextHumanCaseID(ByVal idfCase As Object, Optional ByVal Connection As IDbConnection = Nothing) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnNextHumanCaseID(@idfCase) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfCase", idfCase)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return val
    End Function

    Public Shared Function GetPrevHumanCaseID(ByVal idfCase As Object, Optional ByVal Connection As IDbConnection = Nothing) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnPrevHumanCaseID(@idfCase) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@idfCase", idfCase)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return val
    End Function

    Public Shared Function GetHumanCaseIDByNumber(ByVal Number As Integer, Optional ByVal Connection As IDbConnection = Nothing) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnHumanCaseIDByNumber(@Number, @idfsSite) ", Connection, Nothing)
        BaseDbService.AddParam(cmd, "@Number", Number)
        BaseDbService.AddParam(cmd, "@idfsSite", EIDSS.model.Core.EidssSiteContext.Instance.SiteID)
        Dim val As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return val
    End Function
#End Region

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

            'tlbHumanCase
            Dim cmdHumanCase As IDbCommand = CreateSPCommand("spHumanCase_SelectDetail")
            AddParam(cmdHumanCase, "@idfCase", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim HumanCaseDetail_Adapter As DbDataAdapter
            HumanCaseDetail_Adapter = CreateAdapter(cmdHumanCase, False)
            HumanCaseDetail_Adapter.Fill(ds, tlbHumanCase)
            CorrectTable(ds.Tables(tlbHumanCase), tlbHumanCase)
            For Each col As DataColumn In ds.Tables(tlbHumanCase).Columns
                col.ReadOnly = False
            Next

            ds.Tables(tlbHumanCase).Columns("idfsCSFormTemplate").AllowDBNull = True
            ds.Tables(tlbHumanCase).Columns("idfsEPIFormTemplate").AllowDBNull = True

            Dim GeoLocationNameCol As DataColumn
            GeoLocationNameCol = ds.Tables(tlbHumanCase).Columns.Add("GeoLocationName", Type.GetType("System.String"))
            GeoLocationNameCol.Unique = False
            GeoLocationNameCol.ReadOnly = False

            If (ds.Tables(tlbHumanCase).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(ds.Tables(tlbHumanCase).Rows(0)("idfPointGeoLocation"))) Then
                ds.Tables(tlbHumanCase).Rows(0)("GeoLocationName") = _
                    EIDSS_DbUtils.GetGeoLocaionString(CType(ds.Tables(tlbHumanCase).Rows(0)("idfPointGeoLocation"), Long))
            End If

            'tlbContactedCasePerson
            Dim cmdContactedCasePerson As IDbCommand = CreateSPCommand("spContactedCasePerson_SelectDetail")
            AddParam(cmdContactedCasePerson, "@idfCase", ID)
            AddParam(cmdContactedCasePerson, "@LangID", ModelUserContext.CurrentLanguage)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim ContactedCasePersonDetail_Adapter As DbDataAdapter
            ContactedCasePersonDetail_Adapter = CreateAdapter(cmdContactedCasePerson, False)
            ContactedCasePersonDetail_Adapter.Fill(ds, tlbContactedCasePerson)
            CorrectTable(ds.Tables(tlbContactedCasePerson), tlbContactedCasePerson)
            For Each col As DataColumn In ds.Tables(tlbContactedCasePerson).Columns
                col.ReadOnly = False
            Next

            ds.Tables(tlbContactedCasePerson).Columns("bitIsRootMain").DefaultValue = 0

            Dim LookupHumanCol As DataColumn
            LookupHumanCol = ds.Tables(tlbContactedCasePerson).Columns.Add( _
                "idfLookupHuman", Type.GetType("System.Int64"), "IsNull(idfRootHuman, 0) * bitIsRootMain + IsNull(idfHuman, 0) * (1 - bitIsRootMain)")
            LookupHumanCol.Unique = False
            LookupHumanCol.ReadOnly = True

            'tlbAntimicrobialTherapy
            Dim cmdAntimicrobialTherapy As IDbCommand = CreateSPCommand("spAntimicrobialTherapy_SelectDetail")
            AddParam(cmdAntimicrobialTherapy, "@idfCase", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim AntimicrobialTherapyDetail_Adapter As DbDataAdapter
            AntimicrobialTherapyDetail_Adapter = CreateAdapter(cmdAntimicrobialTherapy, False)
            AntimicrobialTherapyDetail_Adapter.Fill(ds, tlbAntimicrobialTherapy)
            CorrectTable(ds.Tables(tlbAntimicrobialTherapy), tlbAntimicrobialTherapy)
            For Each col As DataColumn In ds.Tables(tlbAntimicrobialTherapy).Columns
                col.ReadOnly = False
            Next

            'tlbChangeDiagnosisHistory
            Dim cmdChangeDiagnosisHistory As IDbCommand = CreateSPCommand("spChangeDiagnosisHistory_SelectDetail")
            AddParam(cmdChangeDiagnosisHistory, "@idfCase", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            AddParam(cmdChangeDiagnosisHistory, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim ChangeDiagnosisHistoryDetail_Adapter As DbDataAdapter
            ChangeDiagnosisHistoryDetail_Adapter = CreateAdapter(cmdChangeDiagnosisHistory, False)
            ChangeDiagnosisHistoryDetail_Adapter.Fill(ds, tlbChangeDiagnosisHistory)
            CorrectTable(ds.Tables(tlbChangeDiagnosisHistory), tlbChangeDiagnosisHistory)
            For Each col As DataColumn In ds.Tables(tlbChangeDiagnosisHistory).Columns
                col.ReadOnly = False
            Next

            If ID Is Nothing Then
                ID = NewIntID()
            End If

            If ds.Tables(tlbHumanCase).Rows.Count = 0 Then
                m_IsNewObject = True
                Dim r As DataRow = ds.Tables(tlbHumanCase).NewRow
                r("idfCase") = ID
                If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then
                    r("idfPointGeoLocation") = Utils.SEARCH_MODE_ID
                    r("idfEpiObservation") = 2L
                    r("idfCSObservation") = 1L
                    r("idfHuman") = Utils.SEARCH_MODE_ID
                    r("idfRegistrationAddress") = Utils.SEARCH_MODE_ID
                    r("GeoLocationName") = ""
                    r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
                Else
                    r("idfPointGeoLocation") = NewIntID()
                    r("idfEpiObservation") = NewIntID()
                    r("idfCSObservation") = NewIntID()
                    r("idfHuman") = NewIntID()
                    r("idfRegistrationAddress") = NewIntID()
                    r("GeoLocationName") = ""
                    r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
                    r("datEnteredDate") = DateTime.Now
                    r("idfsCaseProgressStatus") = CLng(Enums.CaseStatus.InProgress)
                    r("blnEnableTestsConducted") = True
                    r("idfPersonEnteredBy") = eidss.model.Core.EidssUserContext.User.EmployeeID
                    r("strPersonEnteredBy") = eidss.model.Core.EidssUserContext.User.FullName
                    r("strOfficeEnteredBy") = EIDSS.model.Core.EidssUserContext.User.Organization
                    If EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.UseSimplifiedHumanCaseReportForm)) Then
                        r("strNote") = EidssMessages.Get("msgSimplifiedHumanCaseMode")
                    End If
                End If
                ds.EnforceConstraints = False
                ds.Tables(tlbHumanCase).Rows.Add(r)
                ForceTableChanges(ds.Tables(tlbHumanCase))
            End If

            PatientID = ds.Tables(tlbHumanCase).Rows(0)("idfHuman")
            'ds.Tables(tlbHumanCase).Columns.Add("idfsCurrentDiagnosis", GetType(Int64), "isnull(idfsFinalDiagnosis, idfsTentativeDiagnosis)")
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Private Function AntimicrobialTherapyCmd(ByVal r As DataRow, Optional ByVal transaction As IDbTransaction = Nothing) As IDbCommand
        Dim cmd As IDbCommand = Nothing
        If Not r Is Nothing Then
            If r.RowState <> DataRowState.Deleted Then
                cmd = CreateSPCommand("spAntimicrobialTherapy_Post", Connection, transaction)
                AddTypedParam(cmd, "@idfAntimicrobialTherapy", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfHumanCase", SqlDbType.BigInt)
                AddTypedParam(cmd, "@datFirstAdministeredDate", SqlDbType.DateTime)
                AddTypedParam(cmd, "@strAntimicrobialTherapyName", SqlDbType.NVarChar)
                AddTypedParam(cmd, "@strDosage", SqlDbType.NVarChar)

                SetParam(cmd, "@idfAntimicrobialTherapy", r("idfAntimicrobialTherapy"))
                SetParam(cmd, "@idfHumanCase", r("idfHumanCase"))
                SetParam(cmd, "@datFirstAdministeredDate", r("datFirstAdministeredDate"))
                SetParam(cmd, "@strAntimicrobialTherapyName", r("strAntimicrobialTherapyName"))
                SetParam(cmd, "@strDosage", r("strDosage"))
            Else
                cmd = CreateSPCommand("spAntimicrobialTherapy_Delete", Connection, transaction)
                AddTypedParam(cmd, "@ID", SqlDbType.BigInt)
                SetParam(cmd, "@ID", r("idfAntimicrobialTherapy", DataRowVersion.Original))
            End If
        End If
        Return cmd
    End Function

    Private Function ChangeDiagnosisHistoryCmd(ByVal r As DataRow, Optional ByVal transaction As IDbTransaction = Nothing) As IDbCommand
        Dim cmd As IDbCommand = Nothing
        If (Not r Is Nothing) Then
            If r.RowState <> DataRowState.Deleted Then
                cmd = CreateSPCommand("spChangeDiagnosisHistory_Post", Connection, transaction)
                AddTypedParam(cmd, "@idfChangeDiagnosisHistory", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfHumanCase", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfPerson", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfsPreviousDiagnosis", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfsCurrentDiagnosis", SqlDbType.BigInt)
                AddTypedParam(cmd, "@datChangedDate", SqlDbType.DateTime)
                AddTypedParam(cmd, "@idfsChangeDiagnosisReason", SqlDbType.BigInt)

                SetParam(cmd, "@idfChangeDiagnosisHistory", r("idfChangeDiagnosisHistory"))
                SetParam(cmd, "@idfHumanCase", r("idfHumanCase"))
                SetParam(cmd, "@idfPerson", r("idfPerson"))
                SetParam(cmd, "@idfsPreviousDiagnosis", r("idfsPreviousDiagnosis"))
                SetParam(cmd, "@idfsCurrentDiagnosis", r("idfsCurrentDiagnosis"))
                SetParam(cmd, "@datChangedDate", r("datChangedDate"))
                SetParam(cmd, "@idfsChangeDiagnosisReason", r("idfsChangeDiagnosisReason"))
            End If
        End If
        Return cmd
    End Function

    Private Function ContactedCasePersonCmd(ByVal r As DataRow, Optional ByVal transaction As IDbTransaction = Nothing) As IDbCommand
        Dim cmd As IDbCommand = Nothing
        If Not r Is Nothing Then
            If r.RowState <> DataRowState.Deleted Then
                cmd = CreateSPCommand("spContactedCasePerson_Post", Connection, transaction)
                AddTypedParam(cmd, "@idfContactedCasePerson", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfHumanCase", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfHuman", SqlDbType.BigInt)
                AddTypedParam(cmd, "@idfsPersonContactType", SqlDbType.BigInt)
                AddTypedParam(cmd, "@datDateOfLastContact", SqlDbType.DateTime)
                AddTypedParam(cmd, "@strPlaceInfo", SqlDbType.NVarChar)
                AddParam(cmd, "@strComments", r("strComments"))

                SetParam(cmd, "@idfContactedCasePerson", r("idfContactedCasePerson"))
                SetParam(cmd, "@idfHumanCase", r("idfHumanCase"))
                SetParam(cmd, "@idfHuman", r("idfHuman"))
                SetParam(cmd, "@idfsPersonContactType", r("idfsPersonContactType"))
                SetParam(cmd, "@datDateOfLastContact", r("datDateOfLastContact"))
                SetParam(cmd, "@strPlaceInfo", r("strPlaceInfo"))
            Else
                cmd = CreateSPCommand("spPatient_Delete", Connection, transaction)
                AddTypedParam(cmd, "@ID", SqlDbType.BigInt)
                SetParam(cmd, "@ID", r("idfHuman", DataRowVersion.Original))
            End If
        End If
        Return cmd
    End Function

    Private Function Patient_CreateCopyOfRootCmd(ByVal r As DataRow, Optional ByVal transaction As IDbTransaction = Nothing) As IDbCommand
        Dim cmd As IDbCommand = Nothing
        If (Not r Is Nothing) AndAlso (r.RowState <> DataRowState.Deleted) AndAlso _
           (Not Utils.IsEmpty(r("bitIsRootMain"))) AndAlso (CInt(r("bitIsRootMain")) > 0) Then
            cmd = CreateSPCommand("spPatient_CreateCopyOfRoot", Connection, transaction)
            AddTypedParam(cmd, "@idfHuman", SqlDbType.BigInt)
            AddTypedParam(cmd, "@idfRootHuman", SqlDbType.BigInt)
            AddTypedParam(cmd, "@idfCase", SqlDbType.BigInt)

            SetParam(cmd, "@idfHuman", r("idfHuman"))
            SetParam(cmd, "@idfRootHuman", r("idfRootHuman"))
            SetParam(cmd, "@idfCase", DBNull.Value)
        End If
        Return cmd
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then Return True
        If ds Is Nothing Then Return True
        Try
            'TODO: remove this method call if human case ID are assigned explicitly in other place
            For Each row As DataRow In ds.Tables(tlbHumanCase).Rows
                If row.RowState <> DataRowState.Deleted AndAlso _
                   row.RowState <> DataRowState.Detached AndAlso _
                   Utils.IsEmpty(row("strCaseID")) Then
                    row("strCaseID") = _
                        NumberingService.GetNextNumber(NumberingObject.HumanCase, Connection, m_Error, transaction)
                End If
            Next
            'Replication Events
            If (postType = bv.common.Enums.PostType.FinalPosting) Then
                If IsNewObject Then
                    m_IsNewObject = False
                    AddEvent(EventType.HumanCaseCreatedLocal)
                ElseIf ds.Tables(tlbHumanCase).Rows.Count > 0 Then
                    Dim r As DataRow = ds.Tables(tlbHumanCase).Rows(0)
                    If r.HasVersion(DataRowVersion.Original) Then
                        If Utils.Str(r("idfsFinalDiagnosis"), Utils.Str(r("idfsTentativeDiagnosis"))) <> _
                           Utils.Str(r("idfsFinalDiagnosis", DataRowVersion.Original), Utils.Str(r("idfsTentativeDiagnosis", DataRowVersion.Original))) Then
                            AddEvent(EventType.HumanCaseDiagnosisChangedLocal)
                        End If

                        If Utils.Str(r("idfsFinalCaseStatus"), Utils.Str(r("idfsInitialCaseStatus"))) <> _
                           Utils.Str(r("idfsFinalCaseStatus", DataRowVersion.Original), Utils.Str(r("idfsInitialCaseStatus", DataRowVersion.Original))) Then
                            AddEvent(EventType.HumanCaseClassificationChangedLocal)
                        End If
                        If (Not r("idfOutbreak") Is DBNull.Value AndAlso Not r("idfOutbreak").Equals(r("idfOutbreak", DataRowVersion.Original))) Then
                            AddEvent(EventType.NewVetCaseAddedToOutbreakLocal)
                        End If
                        If CLng(CaseStatusEnum.Closed).Equals(r("idfsCaseProgressStatus", DataRowVersion.Original)) AndAlso CLng(CaseStatusEnum.InProgress).Equals(r("idfsCaseProgressStatus")) Then
                            AddEvent(EventType.ClosedHumanCaseReopenedLocal)
                        End If

                    End If
                End If

            End If


            'tlbHumanCase
            ExecPostProcedure("spHumanCase_Post", ds.Tables(tlbHumanCase), Connection, transaction)

            Dim cmd As IDbCommand = Nothing

            'tlbContactedCasePerson
            Dim NotifyReferenceChange As Boolean = False
            For Each row As DataRow In ds.Tables(tlbContactedCasePerson).Rows
                If (row.RowState = DataRowState.Added) AndAlso (Not NotifyReferenceChange) Then NotifyReferenceChange = True
                cmd = Patient_CreateCopyOfRootCmd(row, transaction)
                If Not cmd Is Nothing Then cmd.ExecuteNonQuery()
                cmd = ContactedCasePersonCmd(row, transaction)
                If Not cmd Is Nothing Then cmd.ExecuteNonQuery()
                If (row.RowState <> DataRowState.Deleted) Then row("bitIsRootMain") = 0
            Next

            If NotifyReferenceChange Then
                LookupCache.NotifyChange("Human", transaction, Nothing)
            End If


            'tlbAntimicrobialTherapy
            For Each row As DataRow In ds.Tables(tlbAntimicrobialTherapy).Rows
                cmd = AntimicrobialTherapyCmd(row, transaction)
                If Not cmd Is Nothing Then cmd.ExecuteNonQuery()
            Next

            'tlbChangeDiagnosisHistory
            For Each row As DataRow In ds.Tables(tlbChangeDiagnosisHistory).Rows
                If (row.RowState = DataRowState.Added) Then
                    cmd = ChangeDiagnosisHistoryCmd(row, transaction)
                    If Not cmd Is Nothing Then cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function GetNewColumn(ByVal columnName As String, ByVal dataType As Type, Optional ByVal allowDBNull As Boolean = True) As DataColumn
        Dim col As DataColumn = Nothing
        col = New DataColumn()
        If Not Utils.IsEmpty(columnName) Then col.ColumnName = columnName
        If Not dataType Is Nothing Then col.DataType = dataType Else col.DataType = GetType(String)
        col.AllowDBNull = allowDBNull
        Return col
    End Function

    Public Shared Function PopulateContactInfo(patientID As Object) As DataRow
        If Utils.IsEmpty(patientID) Then
            Return Nothing
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spPatient_PopulateInfo", ConnectionManager.DefaultInstance.Connection)
        SetParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
        SetParam(cmd, "@ID", patientID)
        Dim da As DbDataAdapter = CreateAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        End If
        Return Nothing
    End Function

    Public Function GetFilteredCase() As DataTable
        Dim value As DataTable
        Dim errMsg As ErrorMessage = Nothing

        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_SampleTypeFilter", ConnectionManager.DefaultInstance.Connection)

        AddParam(cmd, "@idfCase", ID.ToString(), ParameterDirection.Input)

        value = ExecTable(cmd)

        Return value
    End Function

    Public Function CheckOutbreakDiagnosis(ByVal idfOutbreak As Object) As Long
        Dim err As ErrorMessage = Nothing
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnIsCaseSessionDiagnosesInGroupOutbreak(@idfCase, @idfOutbreak)", Connection)
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@idfOutbreak", idfOutbreak)
            Return CLng(BaseDbService.ExecScalar(cmd, Connection, err, , True))
        Catch ex As Exception
            Dbg.Debug("error during fnIsCaseSessionDiagnosesInGroupOutbreak call: {0}", ex)
            Return CLng(0)
        End Try
    End Function

    Public Shared Sub ChangeOutbreakDiagnosis(ByVal idfOutbreak As Object, ByVal idfsDiagnosisGroup As Object)
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommandWithParams("spOutbreak_Diagnosis_Update", ConnectionManager.DefaultInstance.Connection)
            AddParam(cmd, "@idfOutbreak", idfOutbreak)
            AddParam(cmd, "@idfsDiagnosisGroup", idfsDiagnosisGroup)
            BaseDbService.ExecCommand(cmd, ConnectionManager.DefaultInstance.Connection)
        Catch ex As Exception
            Dbg.Debug("error during spOutbreak_Diagnosis_Update call: {0}", ex)
        End Try
    End Sub

End Class
