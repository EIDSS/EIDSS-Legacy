Imports System.Data
Imports System.Data.Common
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class VetAggregateAction_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "VetAggregateAction"
    End Sub

#Region "Flex Forms"

    ' Get Template for Human Case
    Public Function GetFFTemplate(ByVal strFFormTypeID As String, ByVal strDeterminantsList As String) As String
        Dim dt As New DataTable
        Dim cmd As IDbCommand

        cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplate", Connection)
        AddParam(cmd, "@FFTypeID", strFFormTypeID)
        AddParam(cmd, "@strDeterminant", strDeterminantsList)
        AddParam(cmd, "@strUniRefTypes", "")

        ' EXACTLY Template
        dt.Clear()
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            End If
        End If

        ' UNI BY ALL

        cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplateUni", Connection)
        AddParam(cmd, "@FFTypeID", strFFormTypeID)

        dt.Clear()
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            Else
                Return ""
            End If
        End If

        Return ""
    End Function


#End Region

    Public Const TableAggregateHeader As String = "AggregateHeader"
    Public Const TableDiagnosticMatrixVersion As String = "DiagnosticMatrixVersion"
    Public Const TableProphilacticMatrixVersion As String = "ProphilacticMatrixVersion"
    Public Const TableSanitaryMatrixVersion As String = "SanitaryMatrixVersion"
    Public Const TableSettings As String = "Settings"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetAggregateAction_SelectDetail")
            AddParam(cmd, "@idfAggrCase", ID)

            Dim AggregateCaseDetail_Adapter As DbDataAdapter = CreateAdapter(cmd)
            AggregateCaseDetail_Adapter.Fill(ds, TableAggregateHeader)
            CorrectTable(ds.Tables(0), TableAggregateHeader)
            CorrectTable(ds.Tables(1), TableSettings)
            CorrectTable(ds.Tables(2), TableDiagnosticMatrixVersion)
            CorrectTable(ds.Tables(3), TableProphilacticMatrixVersion)
            CorrectTable(ds.Tables(4), TableSanitaryMatrixVersion)
            ClearColumnsAttibutes(ds)
            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TableAggregateHeader).NewRow
                r("idfAggrCase") = ID
                r("idfsAggrCaseType") = CLng(AggregateCaseType.VetAggregateAction)
                r("strCaseID") = "(new)"

                If ds.Tables(TableDiagnosticMatrixVersion).Rows.Count > 0 Then
                    r("idfDiagnosticVersion") = ds.Tables(TableDiagnosticMatrixVersion).Rows(0)("idfVersion")
                End If
                If ds.Tables(TableProphilacticMatrixVersion).Rows.Count > 0 Then
                    r("idfProphylacticVersion") = ds.Tables(TableProphilacticMatrixVersion).Rows(0)("idfVersion")
                End If
                If ds.Tables(TableSanitaryMatrixVersion).Rows.Count > 0 Then
                    r("idfSanitaryVersion") = ds.Tables(TableSanitaryMatrixVersion).Rows(0)("idfVersion")
                End If

                r("idfEnteredByOffice") = eidss.model.Core.EidssUserContext.User.OrganizationID
                r("idfEnteredByPerson") = eidss.model.Core.EidssUserContext.User.EmployeeID
                r("datEnteredByDate") = DateTime.Now
                r("idfDiagnosticObservation") = NewIntID()
                r("idfProphylacticObservation") = NewIntID()
                r("idfSanitaryObservation") = NewIntID()
                ds.Tables(TableAggregateHeader).Rows.Add(r)
                ds.EnforceConstraints = False
                m_IsNewObject = True
            Else
                m_IsNewObject = False
            End If
            m_ID = ID
            Return ds

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            If (postType = bv.common.Enums.PostType.FinalPosting) Then
                If IsNewObject Then
                    m_IsNewObject = False
                    AddEvent(EventType.VetAggregateActionCreatedLocal, , False)
                ElseIf ds.Tables(TableAggregateHeader).Rows.Count > 0 Then
                    Dim r As DataRow = ds.Tables(TableAggregateHeader).Rows(0)
                    If r.HasVersion(DataRowVersion.Original) Then
                        If (Not r("idfsAdministrativeUnit").Equals(r("idfsAdministrativeUnit", DataRowVersion.Original))) _
                            OrElse (Not r("datStartDate").Equals(r("datStartDate", DataRowVersion.Original))) _
                            OrElse (Not r("datFinishDate").Equals(r("datFinishDate", DataRowVersion.Original))) Then
                            AddEvent(EventType.VetAggregateActionChangedLocal, , False)
                        End If
                    End If
                End If
            End If
            ExecPostProcedure("spAggregateCaseHeader_Post", ds.Tables(TableAggregateHeader), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
