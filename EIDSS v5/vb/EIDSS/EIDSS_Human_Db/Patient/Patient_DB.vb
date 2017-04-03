Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Core

Public Class Patient_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Patient"
    End Sub

    Public Const tlbHuman As String = "tlbHuman"

    Public HasCurrentResidenceChanged As Boolean = False

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spPatient_SelectDetail")
            AddParam(cmd, "@idfHuman", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim PatientDetail_Adapter As DbDataAdapter
            PatientDetail_Adapter = CreateAdapter(cmd, False)
            PatientDetail_Adapter.Fill(ds, tlbHuman)
            CorrectTable(ds.Tables(0), tlbHuman)
            For Each col As DataColumn In ds.Tables(tlbHuman).Columns
                col.ReadOnly = False
            Next

            HasCurrentResidenceChanged = False

            If ID Is Nothing Then
                ID = NewIntID()
            End If

            If ds.Tables(tlbHuman).Rows.Count = 0 Then
                m_IsNewObject = True
                Dim r As DataRow = ds.Tables(tlbHuman).NewRow
                r("idfHuman") = ID
                If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then
                    r("idfCurrentResidenceAddress") = Utils.SEARCH_MODE_ID
                    r("idfEmployerAddress") = Utils.SEARCH_MODE_ID
                    'r("idfRegistrationAddress") = Utils.SEARCH_MODE_ID
                Else
                    r("idfCurrentResidenceAddress") = NewIntID()
                    r("idfEmployerAddress") = NewIntID()
                    'r("idfRegistrationAddress") = NewIntID()
                End If
                ds.EnforceConstraints = False
                ds.Tables(tlbHuman).Rows.Add(r)
                ForceTableChanges(ds.Tables(tlbHuman))
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then Return True
        If ds Is Nothing Then Return True
        Try
            Dim row As DataRow = ds.Tables(tlbHuman).Rows(0)
            Dim NotifyReferenceChange As Boolean = False
            If (post_Type = PostType.FinalPosting) Then
                If IsNewObject OrElse (row.HasVersion(DataRowVersion.Original) AndAlso _
                    (Utils.Str(row("strLastName")) <> Utils.Str(row("strLastName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strFirstName")) <> Utils.Str(row("strFirstName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strSecondName")) <> Utils.Str(row("strSecondName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strHomePhone")) <> Utils.Str(row("strHomePhone", DataRowVersion.Original)))) OrElse _
                    HasCurrentResidenceChanged Then
                    NotifyReferenceChange = True
                End If
                If IsNewObject Then m_IsNewObject = False
                If HasCurrentResidenceChanged Then HasCurrentResidenceChanged = False
            End If

            ExecPostProcedure("spPatient_Post", ds.Tables(tlbHuman), Connection, transaction)
            If NotifyReferenceChange Then
                LookupCache.NotifyChange("Human", transaction, ID)
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
