Imports System.Data
Imports bv.common.Enums

Public Class VetAggregateSummaryCase_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "VetAggregateSummaryCase"
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

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spAggregateCaseHeader_SelectDetail")
            AddParam(cmd, "@idfAggrCase", ID)
            AddParam(cmd, "@idfsAggrCaseType", CLng(AggregateCaseType.VetAggregateCase))

            FillDataset(cmd, ds, AggregateHeader_DB.TableAggregateHeader)
            CorrectTable(ds.Tables(0), AggregateHeader_DB.TableAggregateHeader)
            CorrectTable(ds.Tables(1), AggregateHeader_DB.TableSettings)
            ClearColumnsAttibutes(ds)

            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(AggregateHeader_DB.TableAggregateHeader).NewRow
                r("idfAggrCase") = -1
                r("idfsAggrCaseType") = CLng(AggregateCaseType.VetAggregateCase)
                ds.Tables(AggregateHeader_DB.TableAggregateHeader).Rows.Add(r)
            End If
            ds.EnforceConstraints = False
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overridable Function GetFlexTable(ByVal fFormTemplateID As String, ByVal aggrXml As String) As DataSet
        Dim retDs As New DataSet
        Try
            m_Error = Nothing
            Dim cmd As IDbCommand = CreateSPCommand("sp_GetVetAggregateCaseSummary")
            AddParam(cmd, "@idfsFFormTemplateID", fFormTemplateID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            AddParam(cmd, "@AggrXml", AggrXml, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            FillDataset(cmd, retDs, "FlexTable")
            Return retDs
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
