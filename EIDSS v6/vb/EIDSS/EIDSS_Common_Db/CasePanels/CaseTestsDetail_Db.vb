Imports System.Data
Imports System.Data.Common
Imports eidss.model.Enums
Imports EIDSS.model.Core
Imports bv.common.Enums

Public Class CaseTestsDetail_Db
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "CaseTest"
    End Sub


    Public Const TableTests As String = "CaseTest"
    Public Const TableValidation As String = "TestValidation"
    Public Const UnknownMaterial As Long = -2

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        MyBase.GetDetail(ID)
        If ID Is Nothing Then
            Throw New Exception("CaseTestsDetail service must be initialized with NOT NULL case ID")
        End If

        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spCaseTests_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim testAdapter As DbDataAdapter = CreateAdapter(cmd)

            'Fill the main object table
            DebugTimer.Start(String.Format("{0} adapter fill", Me.GetType.Name))
            testAdapter.Fill(ds, TableTests)
            DebugTimer.Stop()
            CorrectTable(ds.Tables(0), TableTests)
            CorrectTable(ds.Tables(1), TableValidation)
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Private m_HACode As HACode = HACode.Livestock
    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal Value As HACode)
            m_HACode = Value
        End Set
    End Property

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
        Try
            ExecPostProcedure("spLabTestEditable_Post", ds.Tables(TableTests), Connection, transaction)
            Dim table As DataTable = ds.Tables("TestValidation")
            Dim cmd As IDbCommand
            For Each row As DataRow In table.Rows
                If row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified Then
                    cmd = CreateSPCommand("spCaseTestsValidation_Update", transaction)
                    AddParam(cmd, "@idfTestValidation", row("idfTestValidation"), ParameterDirection.Input)
                    AddParam(cmd, "@idfTesting", row("idfTesting"), ParameterDirection.Input)
                    AddParam(cmd, "@idfsDiagnosis", row("idfsDiagnosis"), ParameterDirection.Input)
                    AddParam(cmd, "@idfsInterpretedStatus", row("idfsInterpretedStatus"), ParameterDirection.Input)
                    AddParam(cmd, "@idfInterpretedByPerson", row("idfInterpretedByPerson"), ParameterDirection.Input)
                    AddParam(cmd, "@datInterpretationDate", row("datInterpretationDate"), ParameterDirection.Input)
                    AddParam(cmd, "@strInterpretedComment", row("strInterpretedComment"), ParameterDirection.Input)
                    AddParam(cmd, "@blnValidateStatus", row("blnValidateStatus"), ParameterDirection.Input)
                    AddParam(cmd, "@idfValidatedByPerson", row("idfValidatedByPerson"), ParameterDirection.Input)
                    AddParam(cmd, "@datValidationDate", row("datValidationDate"), ParameterDirection.Input)
                    AddParam(cmd, "@strValidateComment", row("strValidateComment"), ParameterDirection.Input)
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function


    Public Function CreateTest(ByVal ds As DataSet, currentDiagnosisID As Object) As DataRow

        Dim testRow As DataRow = ds.Tables(TableTests).NewRow()
        InitTestRow(testRow, currentDiagnosisID)
        ds.Tables(TableTests).Rows.Add(testRow)
        Return testRow
    End Function

    Public Sub InitTestRow(ByVal dataRow As DataRow, currentDiagnosisID As Object)
        dataRow("idfTesting") = NewIntID()
        dataRow("idfObservation") = NewIntID()
        dataRow("idfsFormTemplate") = DBNull.Value '?
        dataRow("idfsTestStatus") = CLng(TestStatus.Finalized)
        dataRow("TestStatus") = LookupCache.GetLookupValue(CLng(TestStatus.Finalized), BaseReferenceType.rftTestStatus, "name")
        If Not currentDiagnosisID Is DBNull.Value AndAlso CLng(currentDiagnosisID) > 0 Then
            dataRow("idfsDiagnosis") = currentDiagnosisID
        End If
        dataRow("datConcludedDate") = DateTime.Now
        dataRow("blnNonLaboratoryTest") = 1
        dataRow("idfTestedByOffice") = EidssUserContext.User.OrganizationID
        dataRow("idfTestedByPerson") = EidssUserContext.User.EmployeeID
        dataRow("idfResultEnteredByOffice") = EidssUserContext.User.OrganizationID
        dataRow("idfResultEnteredByPerson") = EidssUserContext.User.EmployeeID
        dataRow("intHasAmendment") = 0
    End Sub
End Class
