Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports eidss.model.Enums
Imports bv.common.db.Core

Public Class Batches_DB
    Inherits BaseDbService

    '--------- Flexible Form
    ' Public ObjID As Guid
    Public ValuesTableName As String
    '--------- Flexible Form

    Dim BatchDetail_Adapter As DbDataAdapter


    Public Sub New()
        ObjectName = "BatchTest"
    End Sub

    Delegate Sub ObservCreator(ByVal ActivityID As Guid, ByVal ObservationID As Guid, ByVal FFormTemplate As String, ByVal transaction As IDbTransaction)

    Public Const TableBatchDetail As String = "BatchDetail"
    Public Const TestsList As String = "TestsList"


#Region "Flex Forms"


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

        ' UNI BY TestType
        dt.Clear()
        SetParam(cmd, "@strUniRefTypes", "rftTestType")
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


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            If (ID Is Nothing) Then
                Me.m_IsNewObject = True
                ID = NewIntID()
            End If
            Me.m_ID = ID

 
            Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_SelectDetail")
            AddParam(cmd, "@idfBatchTest", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)


            BatchDetail_Adapter = CreateAdapter(cmd, False)
            BatchDetail_Adapter.Fill(ds, Batches_DB.TableBatchDetail)

            Dim dtBatch As DataTable = ds.Tables(0)
            CorrectTable(dtBatch, TableBatchDetail)
            If (Me.IsNewObject) Then CreateNewBatchRow(dtBatch)

            CorrectTable(ds.Tables(1), Batches_DB.TestsList)
            For Each col As DataColumn In ds.Tables(1).Columns
                col.ReadOnly = False
            Next

            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function


    Sub CreateNewBatchRow(ByVal dtBatch As DataTable)
        Dim drBatch As DataRow = dtBatch.NewRow()
        drBatch("idfBatchTest") = Me.ID
        drBatch("idfsBatchStatus") = 10001003 'in Progress
        drBatch("idfObservation") = NewIntID()

        drBatch("strBarcode") = "(new)" 'BatchCode
        dtBatch.Rows.Add(drBatch)

        Me.m_IsNewObject = True

    End Sub



    Sub CreateNewBatch(ByVal drBatch As DataRow, ByVal tests As DataTable, Optional ByVal transaction As IDbTransaction = Nothing)
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_Create", Me.Connection, transaction)
            StoredProcParamsCache.CreateParameters(cmd, Nothing)

            SetParam(cmd, "@idfBatchTest", drBatch("idfBatchTest"))
            SetParam(cmd, "@idfsTestType", drBatch("idfsTestType"))
            SetParam(cmd, "@idfPerformedByOffice", drBatch("idfPerformedByOffice"))
            SetParam(cmd, "@strBarcode", drBatch("strBarcode"))
            SetParam(cmd, "@idfObservation", drBatch("idfObservation"))

            m_Error = BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)
            If Not drBatch("strBarcode").Equals(GetParamValue(cmd, "@strBarcode")) Then
                drBatch("strBarcode") = GetParamValue(cmd, "@strBarcode")
                drBatch.EndEdit()
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Throw
        End Try
    End Sub




    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim batches As DataTable = ds.Tables(Batches_DB.TableBatchDetail)
            Dim drBatch As DataRow = batches.Rows(0)
            Dim tests As DataTable = ds.Tables(Batches_DB.TestsList)

            If (Me.IsNewObject) Then ' new Batch
                CreateNewBatch(drBatch, tests, transaction)
            End If


            UpdateBatchData(drBatch, transaction)

            UpdateTests(tests, transaction)

            Dim close As Boolean = False
            If drBatch("idfsBatchStatus").ToString = TestStatus.Completed.ToString("d") Then ' "10001001" Then 'acsCompleted
                If (drBatch.RowState = DataRowState.Added) Then
                    close = True
                Else
                    If drBatch("idfsBatchStatus", DataRowVersion.Original).ToString <> TestStatus.Completed.ToString("d") Then close = True
                End If
            End If
            If close Then
                Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_Finalize", transaction)
                AddParam(cmd, "@idfBatchTest", drBatch("idfBatchTest"))
                cmd.ExecuteNonQuery()
                For Each row As DataRow In tests.Rows
                    If row.RowState = DataRowState.Deleted Then Continue For
                    Dim TestID As Object = row("idfTesting")
                    If Not TestID Is Nothing Then
                        AddEvent(EventType.NewTestResult, TestID)
                    End If
                Next
            End If
            Me.m_IsNewObject = False

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function


    Sub UpdateBatchData(ByVal dr As DataRow, Optional ByVal transaction As IDbTransaction = Nothing)
        Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_Update")
        AddParam(cmd, "@idfBatchTest", dr("idfBatchTest"))
        AddParam(cmd, "@strBarcode", dr("strBarcode"))
        AddParam(cmd, "@idfsTestType", dr("idfsTestType"))

        AddParam(cmd, "@datPerformedDate", dr("datPerformedDate"))
        AddParam(cmd, "@idfPerformedByPerson", dr("idfPerformedByPerson"))

        AddParam(cmd, "@datValidatedDate", dr("datValidatedDate"))
        AddParam(cmd, "@idfValidatedByPerson", dr("idfValidatedByPerson"))
        AddParam(cmd, "@idfResultEnteredByOffice", eidss.model.Core.EidssUserContext.User.OrganizationID)
        AddParam(cmd, "@idfResultEnteredByPerson", eidss.model.Core.EidssUserContext.User.EmployeeID)

        BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)
        cmd = CreateSPCommand("spObservation_Post")
        AddParam(cmd, "@idfObservation", dr("idfObservation"))
        AddParam(cmd, "@idfsFormTemplate", dr("idfsFormTemplate"))
        BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)

    End Sub


    Sub UpdateTests(ByVal dtTests As DataTable, Optional ByVal transaction As IDbTransaction = Nothing)

        Dim dtUpdatedTests As DataTable = dtTests.GetChanges()
        If (dtUpdatedTests Is Nothing OrElse dtUpdatedTests.Rows Is Nothing OrElse dtUpdatedTests.Rows.Count = 0) Then Return


        For Each dr As DataRow In dtUpdatedTests.Rows
            If (dr.RowState = DataRowState.Deleted) Then
                Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_RemoveTest")
                AddParam(cmd, "@idfBatchTest", ID) 'dr("idfBatchTest", DataRowVersion.Original))
                AddParam(cmd, "@idfTesting", dr("idfTesting", DataRowVersion.Original))
                BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)
                Continue For
            End If

            If (dr.RowState = DataRowState.Added AndAlso Not dr("idfContainer") Is DBNull.Value AndAlso CLng(dr("idfContainer")) > 0) Then
                AssignTests_DB.AssignTestToSample(dr, transaction)
            End If

            If (dr.RowState = DataRowState.Added) Then
                Dim cmd As IDbCommand = CreateSPCommand("spLabBatch_AddTest")
                AddParam(cmd, "@idfBatchTest", ID) 'dr("idfBatchTest"))
                AddParam(cmd, "@idfTesting", dr("idfTesting"))
                BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)
            End If

            If (dr.RowState = DataRowState.Modified OrElse dr.RowState = DataRowState.Added) Then
                Dim cmd As IDbCommand = CreateSPCommand("spLabTest_Update", transaction)
                StoredProcParamsCache.CreateParameters(cmd)
                SetParam(cmd, "@idfTesting", dr("idfTesting"))
                SetParam(cmd, "@idfsTestResult", dr("idfsTestResult"))
                SetParam(cmd, "@intTestNumber", dr("intTestNumber"))
                SetParam(cmd, "@idfResultEnteredByPerson", dr("idfResultEnteredByPerson"))
                SetParam(cmd, "@idfsTestForDiseaseType", dr("idfsTestForDiseaseType"))
                BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)

                cmd = CreateSPCommand("spObservation_Post")
                AddParam(cmd, "@idfObservation", dr("idfObservation"))
                AddParam(cmd, "@idfsFormTemplate", dr("idfsFormTemplate"))
                BaseDbService.ExecCommand(cmd, Me.Connection, transaction, True)
            End If
        Next
        'after successful post clear material references - now this these tests shall be treated as existing tests.
        For Each dr As DataRow In dtUpdatedTests.Rows
            If (dr.RowState = DataRowState.Deleted) Then
                Continue For
            End If
            If (Not dr("idfContainer") Is DBNull.Value AndAlso CLng(dr("idfContainer")) > 0) Then
                dr("idfContainer") = 0
            End If
        Next

    End Sub



    Public Function FinalizeBatch(ByVal ds As DataSet) As Boolean

        '1. Save Changes of batch & tests
        Dim IsSaved As Boolean = PostDetail(ds, PostType.FinalPosting)
        If (IsSaved = False) Then Return False


        '2. Set Complite-status for Batch and Tests
        Dim dr As DataRow = ds.Tables(Batches_DB.TableBatchDetail).Rows(0)
        Dim BatchID As Guid = CType(dr("idfActivity"), Guid)


        Dim cmd As IDbCommand = CreateSPCommand("spLab_Batch_Finalize")
        AddParam(cmd, "@BatchID", BatchID)
        BaseDbService.ExecCommand(cmd, Me.Connection, Nothing, True)

        Return True
    End Function
    Public Function SelectTestsBySampleID(testType As Long, sampleBarcode As String) As DataSet
        Dim cmd As IDbCommand = CreateSPCommandWithParams("spLabBatch_FindTestBySampleBarcode")
        SetParam(cmd, "@idfsTestType", testType)
        SetParam(cmd, "@strSampleBarcode", sampleBarcode)
        Dim da As DbDataAdapter = CreateAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, TestsList)
        CorrectTable(ds.Tables(0), TestsList)
        CorrectTable(ds.Tables(1), "Diagnosis")
        CorrectTable(ds.Tables(2), "DefaultDiagnosis")
        ClearColumnsAttibutes(ds)
        Return ds

    End Function

End Class
