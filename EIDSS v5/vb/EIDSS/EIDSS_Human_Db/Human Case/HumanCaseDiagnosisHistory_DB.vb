﻿Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class HumanCaseDiagnosisHistory_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "HumanCase"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

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

            Dim ChangeDiagnosisHistory_Adapter As DbDataAdapter
            ChangeDiagnosisHistory_Adapter = CreateAdapter(cmdChangeDiagnosisHistory, False)
            ChangeDiagnosisHistory_Adapter.Fill(ds, HumanCase_DB.tlbChangeDiagnosisHistory)
            CorrectTable(ds.Tables(HumanCase_DB.tlbChangeDiagnosisHistory), HumanCase_DB.tlbChangeDiagnosisHistory)
            For Each col As DataColumn In ds.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).Columns
                col.ReadOnly = False
            Next

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
