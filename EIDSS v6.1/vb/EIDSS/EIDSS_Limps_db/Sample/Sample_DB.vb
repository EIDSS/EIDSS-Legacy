Imports System.Data
Imports bv.common.Enums
Imports EIDSS.model.Enums

Public Class Sample_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Sample"
    End Sub


    Public Const TableSample As String = "Sample"
    Public Const TableDiagnosis As String = "Diagnosis"
    Public Const TableTest As String = "Test"
    Public Const TableTransferFrom As String = "TransferFrom"
    Public Const TableTransferTo As String = "TransferTo"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        ds.EnforceConstraints = False
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spLabSample_SelectDetail")
            AddParam(cmd, "@idfMaterial", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            'Fill the main object table
            FillDataset(cmd, ds, TableSample)

            CorrectTable(ds.Tables(0), TableSample)
            CorrectTable(ds.Tables(1), TableTest)
            CorrectTable(ds.Tables(2), TableTransferFrom)
            CorrectTable(ds.Tables(3), TableTransferTo)

            For Each col As DataColumn In ds.Tables(TableTest).Columns
                col.ReadOnly = False
            Next

            'Dim idfCase As Object = -1
            'If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            '    If Not ds.Tables(0).Rows(0)("idfCase") Is DBNull.Value Then
            '        idfCase = ds.Tables(0).Rows(0)("idfCase")
            '    ElseIf Not ds.Tables(0).Rows(0)("idfMonitoringSession") Is DBNull.Value Then
            '        idfCase = ds.Tables(0).Rows(0)("idfMonitoringSession")
            '    ElseIf Not ds.Tables(0).Rows(0)("idfVectorSurveillanceSession") Is DBNull.Value Then
            '        idfCase = 0 'diagnosis for all vector sessions are the same and populated using predefined key = 0
            '    End If
            'End If

            cmd = CreateSPCommand("spLabTestEditable_GetSampleDiagnosis")
            AddParam(cmd, "@idfMaterial", ID)
            AddParam(cmd, "@idfCase", DBNull.Value)
            AddParam(cmd, "@idfCaseType", DBNull.Value)
            'AddParam(cmd, "@idfsDiagnosis", DBNull.Value)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            FillDataset(cmd, ds, TableDiagnosis)
            CorrectTable(ds.Tables(TableDiagnosis), TableDiagnosis)
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
            Dim cmd As IDbCommand
            Dim row As DataRow = ds.Tables(TableSample).Rows(0)
            If row.RowState = DataRowState.Modified Then
                cmd = CreateSPCommand("spLabSample_Post", transaction)
                AddParam(cmd, "idfMaterial", ID)
                AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                'AddParam(cmd, "@useDepartment", 1)
                AddParam(cmd, "@idfInDepartment", row("idfInDepartment"))
                AddParam(cmd, "@strNote", row("strNote"))
                AddParam(cmd, "@strBarcode", row("strBarcode"))
                ExecCommand(cmd, cmd.Connection, transaction, True)
            End If
            For Each testRow As DataRow In ds.Tables(TableTest).Rows
                If testRow.RowState = DataRowState.Deleted _
                    OrElse testRow.RowState = DataRowState.Detached _
                    OrElse True.Equals(testRow("blnExternalTest")) Then
                    Continue For
                End If

                If (testRow.HasVersion(DataRowVersion.Original) AndAlso _
                    Not testRow("idfsTestStatus", DataRowVersion.Original).Equals(CLng(TestStatus.Finalized)) AndAlso _
                    testRow("idfsTestStatus").Equals(CLng(TestStatus.Finalized))) _
                    OrElse _
                    (Not testRow.HasVersion(DataRowVersion.Original) AndAlso testRow("idfsTestStatus").Equals(CLng(TestStatus.Finalized))) Then
                    Dim testID As Object = testRow("idfTesting")
                    If Not testID Is Nothing Then
                        If Not row("idfVectorSurveillanceSession") Is DBNull.Value Then
                            AddEvent(EventType.VsSessionTestResultRegistrationLocal, row("idfVectorSurveillanceSession"))
                        ElseIf Not row("idfMonitoringSession") Is DBNull.Value Then
                            AddEvent(EventType.AsSessionTestResultRegistrationLocal, row("idfMonitoringSession"))
                        ElseIf Not row("idfCase") Is DBNull.Value Then
                            If (CType(HACode.Human, Integer).Equals(row("intHACode"))) Then
                                AddEvent(EventType.HumanTestResultRegistrationLocal, row("idfCase"))
                            Else
                                AddEvent(EventType.VetCaseTestResultRegistrationLocal, row("idfCase"))
                            End If
                        End If
                        If (True.Equals(row("blnSampleTransferred"))) Then
                            AddEvent(EventType.TestResultForSampleTransferredIn, testID)
                        End If
                    End If
                End If
            Next
            ExecPostProcedure("spLabSample_TestsPost", ds.Tables(TableTest), Connection, transaction)

        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function

End Class
