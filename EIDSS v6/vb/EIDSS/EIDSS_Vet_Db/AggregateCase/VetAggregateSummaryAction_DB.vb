Imports System.Data
Imports System.Data.Common
Imports bv.common.Core
Imports bv.common.Enums

Public Class VetAggregateSummaryAction_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "VetAggregateSummaryAction"
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

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spAggregateCaseHeader_SelectDetail")
            AddParam(cmd, "@idfAggrCase", ID)
            AddParam(cmd, "@idfsAggrCaseType", CLng(AggregateCaseType.VetAggregateAction))

            Dim AggregateCaseDetail_Adapter As DbDataAdapter = CreateAdapter(cmd)
            AggregateCaseDetail_Adapter.Fill(ds, AggregateHeader_DB.TableAggregateHeader)
            CorrectTable(ds.Tables(0), AggregateHeader_DB.TableAggregateHeader)
            CorrectTable(ds.Tables(1), AggregateHeader_DB.TableSettings)
            ClearColumnsAttibutes(ds)
            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(AggregateHeader_DB.TableAggregateHeader).NewRow
                r("idfAggrCase") = -1
                r("idfsAggrCaseType") = CLng(AggregateCaseType.VetAggregateAction)
                ds.Tables(AggregateHeader_DB.TableAggregateHeader).Rows.Add(r)
            End If
            ds.EnforceConstraints = False
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overridable Function GetOneFlexTable(ByVal FFormTemplateID As String, ByVal AggrXml As String, ByVal ActionType As String) As DataSet
        If Utils.IsEmpty(ActionType) Then Return Nothing
        Dim RetDS As New DataSet
        Try
            m_Error = Nothing
            Dim cmd As IDbCommand = CreateSPCommand(String.Format("sp_GetVetAggregate{0}Summary", Utils.Str(ActionType)))
            AddParam(cmd, "@idfsFFormTemplateID", FFormTemplateID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmd, "@AggrXml", AggrXml, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AggregateCaseDetail_Adapter = CreateAdapter(cmd, False)
            AggregateCaseDetail_Adapter.Fill(RetDS, "FlexTable")

            Return RetDS
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overridable Function GetAllFlexTable(ByVal D_FFormTemplateID As String, ByVal P_FFormTemplateID As String, ByVal S_FFormTemplateID As String, ByVal AggrXml As String) As DataSet
        Dim RetDS As New DataSet
        Try
            m_Error = Nothing
            Dim cmd As IDbCommand = CreateSPCommand("sp_GetVetAggregateActionSummary")
            AddParam(cmd, "@D_idfsFFormTemplateID", D_FFormTemplateID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmd, "@P_idfsFFormTemplateID", P_FFormTemplateID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmd, "@S_idfsFFormTemplateID", S_FFormTemplateID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmd, "@AggrXml", AggrXml, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AggregateCaseDetail_Adapter = CreateAdapter(cmd, False)
            AggregateCaseDetail_Adapter.Fill(RetDS, "FlexTable")
            RetDS.Tables("FlexTable").TableName = "D_FlexTable"
            RetDS.Tables("FlexTable" & 1).TableName = "P_FlexTable"
            RetDS.Tables("FlexTable" & 2).TableName = "S_FlexTable"

            Return RetDS
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
