Imports System.Data
Imports System.Data.Common
Imports eidss.model.Enums
Imports eidss.model.Core

Public Class CaseTestsDetail_Db
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "CaseTest"
    End Sub


    Public Const TableTests As String = "CaseTest"
    Public Const TableValidation As String = "TestValidation"
    Public Const UnknownMaterial As Long = -2

#Region "Flex Forms"

    ' Depends on Country and TestType
    ' Get Template for Human Case
    'Public Function GetFFTemplate(ByVal strFFormTypeID As String, ByVal strDeterminantsList As String) As String
    '    Dim dt As New DataTable
    '    Dim cmd As IDbCommand

    '    cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplate", Connection)
    '    AddParam(cmd, "@FFTypeID", strFFormTypeID)
    '    AddParam(cmd, "@strDeterminant", strDeterminantsList)
    '    AddParam(cmd, "@strUniRefTypes", "")

    '    ' EXACTLY Template
    '    dt.Clear()
    '    FillTable(cmd, dt)
    '    If Not dt.Rows.Count = 0 Then
    '        If Not dt.Rows(0).Item(0) Is DBNull.Value Then
    '            Return dt.Rows(0).Item(0).ToString
    '        End If
    '    End If

    '    ' UNI BY DIAGNOSIS
    '    dt.Clear()
    '    SetParam(cmd, "@strUniRefTypes", "rftTestType")
    '    FillTable(cmd, dt)
    '    If Not dt.Rows.Count = 0 Then
    '        If Not dt.Rows(0).Item(0) Is DBNull.Value Then
    '            Return dt.Rows(0).Item(0).ToString
    '        End If
    '    End If

    '    ' UNI BY Country
    '    dt.Clear()
    '    SetParam(cmd, "@strUniRefTypes", "rftCountry")
    '    FillTable(cmd, dt)
    '    If Not dt.Rows.Count = 0 Then
    '        If Not dt.Rows(0).Item(0) Is DBNull.Value Then
    '            Return dt.Rows(0).Item(0).ToString
    '        End If
    '    End If

    '    ' UNI BY ALL

    '    cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplateUni", Connection)
    '    AddParam(cmd, "@FFTypeID", strFFormTypeID)

    '    dt.Clear()
    '    FillTable(cmd, dt)
    '    If Not dt.Rows.Count = 0 Then
    '        If Not dt.Rows(0).Item(0) Is DBNull.Value Then
    '            Return dt.Rows(0).Item(0).ToString
    '        Else
    '            Return ""
    '        End If
    '    End If

    '    Return ""
    'End Function

#End Region


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        MyBase.GetDetail(ID)
        If ID Is Nothing Then
            Throw New Exception("CaseTestsDetail service must be initialized with NOT NULL case ID")
        End If

        'stCaseID = ID.ToString
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spCaseTests_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            'AddParam(cmd, "@Completed", ShowCompleted)

            Dim TestAdapter As DbDataAdapter = CreateAdapter(cmd)

            'Fill the main object table
            DebugTimer.Start(String.Format("{0} adapter fill", Me.GetType.Name))
            TestAdapter.Fill(ds, TableTests)
            DebugTimer.Stop()
            CorrectTable(ds.Tables(0), TableTests)
            CorrectTable(ds.Tables(1), TableValidation)
            'For Each col As System.Data.DataColumn In ds.Tables(TableValidation).Columns
            '    col.ReadOnly = False
            'Next
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
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
    'Private Sub SetColumnsReadonlyState(ByVal ds As DataSet, ByVal [Readonly] As Boolean)
    '    ds.Tables(TableTests).Columns("idfMaterial").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("Specimen").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("idfsSpecimen_Type").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("strActivityCode").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("strSpecimenType").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("strBarcode").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("idfOffice").ReadOnly = [Readonly]
    '    ds.Tables(TableCaseActivity).Columns("idfsActivity_Type").ReadOnly = [Readonly]
    '    ds.Tables(TableTests).Columns("idfsSpecimen_Type").ReadOnly = [Readonly]
    '    If ds.Tables(TableCaseActivity).Columns.Contains("VetCaseType") Then
    '        ds.Tables(TableCaseActivity).Columns("VetCaseType").ReadOnly = [Readonly]
    '    End If

    'End Sub


    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
        Try
            ExecPostProcedure("spLabTestEditable_Post", ds.Tables(TableTests), Connection, transaction)
            Dim table As DataTable = ds.Tables("TestValidation")
            Dim cmd As IDbCommand
            For Each row As DataRow In table.Rows
                If row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified Then
                    cmd = Me.CreateSPCommand("spCaseTestsValidation_Update", transaction)
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
        testRow("idfTesting") = BaseDbService.NewIntID
        testRow("idfObservation") = BaseDbService.NewIntID
        testRow("idfsFormTemplate") = DBNull.Value '?
        testRow("idfsTestStatus") = CLng(TestStatus.Completed)
        testRow("TestStatus") = LookupCache.GetLookupValue(CLng(TestStatus.Completed), BaseReferenceType.rftActivityStatus, "name")
        If Not currentDiagnosisID Is DBNull.Value AndAlso CLng(currentDiagnosisID) > 0 Then
            testRow("idfsDiagnosis") = currentDiagnosisID
        End If
        testRow("datConcludedDate") = DateTime.Now
        testRow("blnNonLaboratoryTest") = 1
        testRow("idfTestedByOffice") = EidssUserContext.User.OrganizationID
        testRow("idfTestedByPerson") = EidssUserContext.User.EmployeeID
        testRow("idfResultEnteredByOffice") = EidssUserContext.User.OrganizationID
        testRow("idfResultEnteredByPerson") = EidssUserContext.User.EmployeeID
        testRow("intHasAmendment") = 0
        ds.Tables(TableTests).Rows.Add(testRow)
        Return testRow
    End Function

End Class
