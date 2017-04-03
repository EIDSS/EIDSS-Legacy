Imports System.Data
Imports System.Data.Common

Public Class Outbreak_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Outbreak"
        Me.UseDatasetCopyInPost = False
    End Sub

    Dim ActivityDetail_Adapter As DbDataAdapter
    Dim OutbreakDetail_Adapter As DbDataAdapter
    Dim ActivityRelationDetail_Adapter As DbDataAdapter

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spOutbreak_SelectDetail")
            AddParam(cmd, "@OutbreakID", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            ActivityDetail_Adapter = CreateAdapter(cmd)
            'Fill the main object table
            ActivityDetail_Adapter.Fill(ds, "Outbreak")
            'Fill other object tables here
            CorrectTable(ds.Tables(1), "CaseList")
            CorrectTable(ds.Tables(2), "Notes")
            ds.Tables(0).Columns("strPrimaryCase").ReadOnly = False
            ds.Tables(2).Columns("idfPerson").DefaultValue = eidss.model.Core.EidssUserContext.User.EmployeeID
            If ID Is Nothing Then
                ID = NewIntID()
            End If
            ClearColumnsAttibutes(ds)
            ds.Tables(2).Columns("idfOutbreak").DefaultValue = ID
            ds.Tables(2).Columns("datNoteDate").DefaultValue = DateTime.Now
            ds.Tables(2).Columns("idfOutbreakNote").AllowDBNull = False
            ds.Tables(2).Columns("idfOutbreakNote").AutoIncrement = True
            ds.Tables(2).Columns("idfOutbreakNote").AutoIncrementSeed = -1
            ds.Tables(2).Columns("idfOutbreakNote").AutoIncrementStep = -1
            If ds.Tables("Outbreak").Rows.Count = 0 Then
                m_IsNewObject = True
                Dim r As DataRow = ds.Tables("Outbreak").NewRow()
                r("idfOutbreak") = ID
                r("idfGeoLocation") = NewIntID()
                ds.Tables("Outbreak").Rows.Add(r)
                ds.EnforceConstraints = True
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal Post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spOutbreak_Post", ds.Tables("Outbreak"), Connection, transaction)
            ExecPostProcedure("spOutbreak_PostCaseList", ds.Tables("CaseList"), Connection, transaction)
            ExecPostProcedure("spOutbreak_PostNotes", ds.Tables("Notes"), Connection, transaction)
            If (Post_Type = PostType.FinalPosting) Then
                If IsNewObject Then
                    m_IsNewObject = False
                    AddEvent(EventType.NewOutbreak)
                    bv.common.db.Core.LookupCache.NotifyChange("Outbreak", transaction)
                End If
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function CanCaseBeAddedToOutbreak(ByVal CaseID As Object, Optional ByVal Connection As IDbConnection = Nothing) As Boolean
        Dim err As ErrorMessage = Nothing
        Dim Value As Integer = 0
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnCanCaseBeAddedToOutbreak(@CaseID)", Connection)
            AddParam(cmd, "@CaseID", CaseID)
            Return CBool(BaseDbService.ExecScalar(cmd, Connection, err, , True))
        Catch ex As Exception
            Dbg.Debug("error during fnCanCaseBeAddedToOutbreak call: {0}", ex)
            Return False
        End Try
    End Function

    Public Function IsCaseInOutbreak(ByVal CaseID As Object, ByVal OutbreakID As Object, Optional ByVal Connection As IDbConnection = Nothing) As Boolean
        Dim err As ErrorMessage = Nothing
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnIsCaseInOutbreak(@CaseID, @OutBreakID)", Connection)
            AddParam(cmd, "@CaseID", CaseID)
            AddParam(cmd, "@OutbreakID", OutbreakID)
            Return CBool(BaseDbService.ExecScalar(cmd, Connection, err, , True))
        Catch ex As Exception
            Dbg.Debug("error during fnIsCaseInOutbreak call: {0}", ex)
            Return False
        End Try
    End Function

    Public Sub RefreshCaseInfo(ByVal ds As DataSet, ByVal caseID As Object)
        If ds Is Nothing Or Utils.IsEmpty(caseID) Then
            Return
        End If
        If Not ds.Tables.Contains("CaseList") Then
            Return
        End If
        Dim row As DataRow = ds.Tables("CaseList").Rows.Find(caseID)
        If row Is Nothing Then
            Return
        End If
        Dim cmd As IDbCommand = Me.CreateSPCommand("spOutbreak_PopulateCaseInfo")
        BaseDbService.AddParam(cmd, "@CaseID", caseID)
        BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        SyncLock cmd.Connection
            If Not cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Open()
            End If
            Dim reader As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While (reader.Read)
                row("datEnteredDate") = reader("datEnteredDate")
                row("strGeoLocation") = reader("strGeoLocation")
                row("strAddress") = reader("strAddress")
                row("strDiagnosis") = reader("strDiagnosis")
                row("strCaseStatus") = reader("strCaseStatus")
                row("Confirmed") = reader("Confirmed")
                row("strPatientName") = reader("strPatientName")
                row.EndEdit()
                If row.RowState <> DataRowState.Added Then
                    row.AcceptChanges()
                End If
            End While

        End SyncLock

    End Sub
End Class
