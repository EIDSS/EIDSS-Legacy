Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Core
Imports bv.common.Enums

Public Class Patient_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Patient"
    End Sub

    Public Const tlbHuman As String = "tlbHuman"

    Public Property HasCurrentResidenceChanged As Boolean = False

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spPatient_SelectDetail")
            AddParam(cmd, "@idfHuman", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            Dim patientDetailAdapter As DbDataAdapter
            patientDetailAdapter = CreateAdapter(cmd, False)
            patientDetailAdapter.Fill(ds, tlbHuman)
            CorrectTable(ds.Tables(0), tlbHuman)
            For Each col As DataColumn In ds.Tables(tlbHuman).Columns
                col.ReadOnly = False
            Next
            ds.Tables(tlbHuman).Columns("strLastName").AllowDBNull = True

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
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If (Not Utils.IsEmpty(ID)) AndAlso (ID.Equals(Utils.SEARCH_MODE_ID)) Then Return True
        If ds Is Nothing Then Return True
        Dim strPersonID As String = String.Empty
        Try
            Dim row As DataRow = ds.Tables(tlbHuman).Rows(0)
            strPersonID = Utils.Str(row("strPersonID"))
            Dim notifyReferenceChange As Boolean = False
            If (postType = bv.common.Enums.PostType.FinalPosting) Then
                If IsNewObject OrElse (row.HasVersion(DataRowVersion.Original) AndAlso _
                    (Utils.Str(row("strLastName")) <> Utils.Str(row("strLastName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strFirstName")) <> Utils.Str(row("strFirstName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strSecondName")) <> Utils.Str(row("strSecondName", DataRowVersion.Original)) OrElse _
                    Utils.Str(row("strHomePhone")) <> Utils.Str(row("strHomePhone", DataRowVersion.Original)))) OrElse _
                    HasCurrentResidenceChanged Then
                    notifyReferenceChange = True
                End If
                If IsNewObject Then m_IsNewObject = False
                If HasCurrentResidenceChanged Then HasCurrentResidenceChanged = False
            End If

            ExecPostProcedure("spPatient_Post", ds.Tables(tlbHuman), Connection, transaction)
            If notifyReferenceChange Then
                LookupCache.NotifyChange("Human", transaction, ID)
            End If
        Catch ex As Exception
            m_Error = HandleErrorMessage(ex, strPersonID)
            Return False
        End Try
        Return True
    End Function
    Public Function HandleErrorMessage(ByVal err As Exception, Optional ByVal strPersonID As String = "") As ErrorMessage
        Dim space As System.Data.SqlClient.SqlException = TryCast(err, System.Data.SqlClient.SqlException)
        If space Is Nothing Then Return New ErrorMessage(err)
        If space.Number = 50000 And space.Class = 16 Then
            Dim strings As String() = space.Message.Split(" "c)
            Dim copy As String() = New String() {}
            Array.Resize(copy, strings.Length - 1)
            Array.Copy(strings, 1, copy, 0, strings.Length - 1)
            Dim errid As String = strings(0)
            If errid = "msgNotUniquePatientID" Then
                Return New EIDSSErrorMessage(errid, errid, Nothing, strPersonID)
            Else
                Return New EIDSSErrorMessage(errid, errid, Nothing, copy)
            End If
        End If

        Return New ErrorMessage(StandardError.PostError, err)
    End Function

End Class
