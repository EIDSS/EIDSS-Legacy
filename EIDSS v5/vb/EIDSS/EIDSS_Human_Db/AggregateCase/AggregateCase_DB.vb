Imports System.Data
Imports System.Data.Common

Public Class AggregateCase_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AggregateCase"
    End Sub

    Dim AggregateCaseDetail_Adapter As DbDataAdapter

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
    Public Const TableMatrixVersion As String = "MatrixVersion"
    Public Const TableSettings As String = "Settings"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spAggregateCase_SelectDetail")
            AddParam(cmd, "@idfAggrCase", ID)

            Dim AggregateCaseDetail_Adapter As DbDataAdapter = CreateAdapter(cmd)
            AggregateCaseDetail_Adapter.Fill(ds, TableAggregateHeader)
            CorrectTable(ds.Tables(0), TableAggregateHeader)
            CorrectTable(ds.Tables(1), TableSettings)
            CorrectTable(ds.Tables(2), TableMatrixVersion)
            ClearColumnsAttibutes(ds)
            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TableAggregateHeader).NewRow
                r("idfAggrCase") = ID
                r("idfsAggrCaseType") = CLng(AggregateCaseType.AggregateCase)
                r("strCaseID") = "(new)"
                If ds.Tables(TableMatrixVersion).Rows.Count > 0 Then
                    r("idfVersion") = ds.Tables(TableMatrixVersion).Rows(0)("idfVersion")
                End If
                r("idfEnteredByOffice") = EIDSS.model.Core.EidssUserContext.User.OrganizationID
                r("idfEnteredByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
                r("datEnteredByDate") = DateTime.Now
                r("idfCaseObservation") = NewIntID()
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


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal Post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spAggregateCaseHeader_Post", ds.Tables(TableAggregateHeader), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Sub GetHumanAggregateSettings(ByRef PeriodType As StatisticPeriodType, ByRef AreaType As StatisticAreaType)
        Dim cmd As IDbCommand = CreateSPCommand("spAggregateSettings_SelectDetail")
        AddParam(cmd, "@idfsAggrCaseType", CLng(AggregateCaseType.AggregateCase))
        Dim da As DbDataAdapter = CreateAdapter(cmd)
        Using dt As New DataTable
            da.Fill(dt)
            PeriodType = CType(dt.Rows(0)("idfsStatisticPeriodType"), StatisticPeriodType)
            AreaType = CType(dt.Rows(0)("idfsStatisticAreaType"), StatisticAreaType)
        End Using
    End Sub
End Class
