Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums

Public Class VetControlMeasures_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "VetControlMeasures"
    End Sub
    Public Const TableVetControlMeasures As String = "VetControlMeasures"
    Dim AnimalsAdapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("VetControlMeasures_DB service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try
            'Dim cmd As IDbCommand = CreateSPCommand("spVetControlMeasure_SelectDetail")
            'AddParam(cmd, "@idfCase", ID)

            'AnimalsAdapter = CreateAdapter(cmd)
            'AnimalsAdapter.Fill(ds, TableVetControlMeasures)
            'CorrectTable(ds.Tables(TableVetControlMeasures), TableVetControlMeasures)
            'ds.EnforceConstraints = False
            'm_ID = ID
            ''Init default values
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        'If ds Is Nothing Then Return True
        'Try
        '    If ds.Tables(TableVetControlMeasures).Rows.Count > 0 AndAlso ds.Tables(TableVetControlMeasures).Rows(0).RowState = DataRowState.Added Then
        '        Dim cmd As IDbCommand = CreateSPCommand("dbo.spCreateControlMeasure", Connection, transaction)
        '        AddParam(cmd, "@idfCaseActivity", m_ID)
        '        AddParam(cmd, "@idfMeasureActivity", ds.Tables(TableVetControlMeasures).Rows(0)("idfActivity"))
        '        cmd.ExecuteNonQuery()
        '    End If
        'Catch ex As Exception
        '    m_Error = New ErrorMessage(StandardError.PostError, ex)
        '    Return False
        'End Try
        Return True
    End Function

#Region "Flex Form Support"

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

        ' UNI BY DIAGNOSIS
        dt.Clear()
        SetParam(cmd, "@strUniRefTypes", "rftDiagnosis")
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            End If
        End If

        ' UNI BY Country
        dt.Clear()
        SetParam(cmd, "@strUniRefTypes", "rftCountry")
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


End Class
