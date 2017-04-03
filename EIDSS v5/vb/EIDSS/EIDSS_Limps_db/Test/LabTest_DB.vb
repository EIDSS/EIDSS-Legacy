Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports EIDSS.model.Enums
Imports bv.common.Diagnostics
Imports bv.common.db.Core

Public Class LabTest_DB
    Inherits BaseDbService

    '--------- Flexible Form
    Public ObjID As String
    Public ValuesTableName As String
    '--------- Flexible Form


    Public Sub New()
        ObjectName = "LabTest"
    End Sub
    Public Const TableTest As String = "LabTest"
    Public Const TableSample As String = "LabSample"
    Public Const TableAmendment As String = "Amendment"
    Public Const TableDiagnosis As String = "Diagnosis"
#Region "Flex Forms"

    ' Depends on Country and TestType
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

    ' 1- Animal; 2- Human
    'Public Function GetHACode(ByVal TestID As String) As Integer
    '    Dim cmd As IDbCommand = CreateCommand("select ISNULL(intHACode,0) from dbo.Testing where idfActivity=@TestID", Connection)
    '    Dim err As ErrorMessage

    '    AddParam(cmd, "@TestID", TestID)
    '    Dim oType As Object = ExecScalar(cmd, Connection, err)
    '    If Utils.IsEmpty(oType) Then Return 0
    '    Return CInt(oType)
    'End Function


#End Region
    Private m_IsMultiTest As Boolean
    Public ReadOnly Property IsMultiTest As Boolean
        Get
            Return m_IsMultiTest
        End Get
    End Property
    Private m_ReadOnlyFields As New List(Of String)
    Public ReadOnly Property ReadOnlyFields As List(Of String)
        Get
            Return m_ReadOnlyFields
        End Get
    End Property
    Private m_Observations As New List(Of Long)
    Public ReadOnly Property Observations As List(Of Long)
        Get
            Return m_Observations
        End Get
    End Property
    Public Property SampleID As Object
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dbg.Assert(Not (ID Is Nothing AndAlso SampleID Is Nothing), "Sample ID is not specified for new test")
            Dim keys As List(Of Object) = Nothing
            If (TypeOf (ID) Is List(Of Object)) Then
                m_IsMultiTest = True
                keys = CType(ID, List(Of Object))
            End If
            Dim cmd As IDbCommand = CreateSPCommand("spLabTestEditable_SelectDetail")
            If IsMultiTest Then
                AddParam(cmd, "@idfTesting", keys(0))
            Else
                AddParam(cmd, "@idfTesting", ID)
            End If
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            Dim materialID As Object = Nothing
            If IsMultiTest Then
                da.Fill(ds, TableTest)
                ClearColumnsAttibutes(ds)
                materialID = ds.Tables(TableTest).Rows(0)("idfContainer") 'we should remember first materail ID here because it will be cleared later
                If Not ds.Tables(TableTest).Rows(0)("idfObservation") Is DBNull.Value Then
                    m_Observations.Add(CLng(ds.Tables(TableTest).Rows(0)("idfObservation")))
                End If
                Using ds1 As New DataSet
                    For i As Integer = 1 To keys.Count - 1
                        SetParam(cmd, "@idfTesting", keys(i))
                        ds1.Clear()
                        da.Fill(ds1, TableTest)
                        If Not ds1.Tables(TableTest).Rows(0)("idfObservation") Is DBNull.Value Then
                            m_Observations.Add(CLng(ds1.Tables(TableTest).Rows(0)("idfObservation")))
                        End If
                        For Each col As DataColumn In ds1.Tables(0).Columns
                            If (col.ColumnName <> "idfTesting" AndAlso col.ColumnName <> "idfObservation" AndAlso Not ds.Tables(TableTest).Rows(0)(col.ColumnName).Equals(ds1.Tables(0).Rows(0)(col.ColumnName))) Then
                                If (Not m_ReadOnlyFields.Contains(col.ColumnName)) Then
                                    m_ReadOnlyFields.Add(col.ColumnName)
                                    ds.Tables(TableTest).Rows(0)(col.ColumnName) = DBNull.Value
                                End If
                            End If
                        Next
                    Next
                    ds.Tables(TableTest).Rows(0)("idfTesting") = -1
                    ds.Tables(TableTest).Rows(0)("idfObservation") = -1
                End Using
            Else
                da.Fill(ds, TableTest)
                If ds.Tables(TableTest).Rows.Count > 0 Then
                    materialID = ds.Tables(TableTest).Rows(0)("idfContainer")
                End If
            End If
            ds.Tables.Add(New DataTable)
            ds.Tables(TableTest).PrimaryKey = New DataColumn() {ds.Tables(TableTest).Columns("idfTesting")}
            'ds.Tables(TableTest).Columns("idfResultEnteredByPerson").DefaultValue = EIDSS.model.Core.EidssUserContext.User.EmployeeID
            'ds.Tables(TableTest).Columns("idfResultEnteredByOffice").DefaultValue = EIDSS.model.Core.EidssUserContext.User.OrganizationID
            ds.Tables(TableTest).Columns("idfTestedByOffice").DefaultValue = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID
            'ds.Tables(TableTest).Columns("idfValidatedByOffice").DefaultValue = EIDSS.model.Core.EidssUserContext.User.OrganizationID
            ds.Tables(TableTest).Columns("blnNonLaboratoryTest").DefaultValue = False
            CorrectTable(ds.Tables(0), TableTest)
            CorrectTable(ds.Tables(1), TableSample)
            CorrectTable(ds.Tables(2), TableAmendment)
            If Not bv.common.Core.Utils.IsEmpty(materialID) Then
                cmd = CreateSPCommand("spLabTestEditable_GetSampleDiagnosis")
                AddParam(cmd, "@idfMaterial", materialID)
                AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                da = CreateAdapter(cmd, False)
                da.Fill(ds.Tables(3))
                CorrectTable(ds.Tables(3), TableDiagnosis)

            End If

            ClearColumnsAttibutes(ds)
            If ID Is Nothing Then
                Dim row As DataRow = ds.Tables(0).NewRow
                ID = BaseDbService.NewIntID
                row("idfTesting") = ID
                row("idfContainer") = SampleID
                row("idfObservation") = BaseDbService.NewIntID
                row("idfsTestStatus") = CLng(TestStatus.Undefined)

                cmd = CreateSPCommand("spLabTestEditable_PopulateSampleInfo")
                AddParam(cmd, "@idfMaterial", SampleID)
                AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                da = CreateAdapter(cmd, False)
                Using ds1 As New DataSet
                    da.Fill(ds1)
                    Dim sampleRow As DataRow = ds.Tables(1).NewRow
                    For Each col As DataColumn In ds.Tables(1).Columns
                        If ds1.Tables(0).Columns.Contains(col.ColumnName) Then
                            sampleRow(col.ColumnName) = ds1.Tables(0).Rows(0)(col.ColumnName)
                        End If
                    Next
                    CorrectTable(ds1.Tables(1), TableDiagnosis)
                    ds.Tables(1).Rows.Add(sampleRow)
                    ds.Tables(1).AcceptChanges()
                    row("idfMonitoringSession") = ds1.Tables(0).Rows(0)("idfMonitoringSession")
                    row("idfCase") = ds1.Tables(0).Rows(0)("idfCase")
                    row("strCaseID") = ds1.Tables(0).Rows(0)("strCaseID")
                    row("SessionID") = ds1.Tables(0).Rows(0)("SessionID")
                    row("idfsDiagnosis") = ds1.Tables(0).Rows(0)("idfsDefaultDiagnosis")
                    row("idfVectorSurveillanceSession") = ds1.Tables(0).Rows(0)("idfVectorSurveillanceSession")
                    row("DepartmentName") = ds1.Tables(0).Rows(0)("DepartmentName")
                    row("intHACode") = ds1.Tables(0).Rows(0)("intHACode")
                    ds.Tables(0).Rows.Add(row)
                    ds.Tables(3).Clear()
                    ds.Tables(3).Merge(ds1.Tables(1))
                    CorrectTable(ds.Tables(3), TableDiagnosis)
                End Using
                m_IsNewObject = True
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim testRow As DataRow = ds.Tables(TableTest).Rows(0)
            If IsMultiTest Then
                Dim cmd As IDbCommand = CreateSPCommand("spLabTestEditable_SelectDetail", Connection, transaction)
                StoredProcParamsCache.CreateParameters(cmd)
                Dim da As DbDataAdapter = CreateAdapter(cmd, False)
                Using tempDs As New DataSet
                    For Each key As Object In CType(m_ID, List(Of Object))
                        tempDs.Clear()
                        SetParam(cmd, "@idfTesting", key)
                        da.Fill(tempDs, TableTest)
                        CorrectTable(tempDs.Tables(TableTest))
                        ClearColumnsAttibutes(tempDs)
                        Dim tmpRow As DataRow = tempDs.Tables(TableTest).Rows(0)
                        For Each col As DataColumn In tempDs.Tables(TableTest).Columns
                            If col.ColumnName <> "idfTesting" AndAlso col.ColumnName <> "idfObservation" AndAlso ReadOnlyFields.IndexOf(col.ColumnName) < 0 Then
                                tmpRow(col.ColumnName) = testRow(col.ColumnName)
                            End If
                        Next
                        tmpRow.EndEdit()
                        ExecPostProcedure("spLabTestEditable_Post", tempDs.Tables(TableTest), Connection, transaction)
                    Next

                End Using

                'testRow("idfTesting") = -1
            Else
                If testRow.HasVersion(DataRowVersion.Original) AndAlso _
                    testRow("idfsTestStatus", DataRowVersion.Original).Equals(CLng(TestStatus.InProgress)) AndAlso _
                    testRow("idfsTestStatus").Equals(CLng(TestStatus.Undefined)) Then
                    testRow("idfTestedByPerson") = DBNull.Value
                    testRow("idfTestedByOffice") = DBNull.Value
                    testRow("strNote") = DBNull.Value
                    testRow("idfsTestResult") = DBNull.Value
                    testRow("datStartedDate") = DBNull.Value
                    testRow("datConcludedDate") = DBNull.Value
                    testRow("idfValidatedByPerson") = DBNull.Value
                    testRow("idfValidatedByOffice") = DBNull.Value
                End If
                If (testRow.HasVersion(DataRowVersion.Original) AndAlso _
                    Not testRow("idfsTestStatus", DataRowVersion.Original).Equals(CLng(TestStatus.Completed)) AndAlso _
                    testRow("idfsTestStatus").Equals(CLng(TestStatus.Completed))) _
                    OrElse _
                    (Not testRow.HasVersion(DataRowVersion.Original) AndAlso testRow("idfsTestStatus").Equals(CLng(TestStatus.Completed))) Then
                    Dim TestID As Object = testRow("idfTesting")
                    If Not TestID Is Nothing Then
                        AddEvent(EventType.NewTestResult, TestID)
                    End If
                End If
                For Each row As DataRow In ds.Tables(TableAmendment).Rows
                    If (row.RowState = DataRowState.Added) Then
                        AddEvent(EventType.NewTestAmendment, testRow("idfTesting"))
                        Exit For
                    End If
                Next
                ExecPostProcedure("spLabTestEditable_Post", ds.Tables(TableTest), Connection, transaction)
                ExecPostProcedure("spLabTestAmendmentHistory_Post", ds.Tables(TableAmendment), Connection, transaction)
            End If

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Shared Function GetDefaultTestCategory(idfsDiagnosis As Long, idfsTestType As Long) As Object
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLabTest_GetDefaultCategory", ConnectionManager.DefaultInstance.Connection)
        BaseDbService.AddParam(cmd, "@idfsDiagnosis", idfsDiagnosis)
        BaseDbService.AddParam(cmd, "@idfsTestType", idfsTestType)

        Dim errMsg As ErrorMessage = Nothing
        Dim res As Object = BaseDbService.ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, errMsg)
        If res Is Nothing Then
            res = DBNull.Value
        End If
        Return res
    End Function

End Class
