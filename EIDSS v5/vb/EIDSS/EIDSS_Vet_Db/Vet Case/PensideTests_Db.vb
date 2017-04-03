Imports System.Data
Imports System.Data.Common

Public Class PensideTests_Db
    Inherits BaseDbService

    Public Const TableTests As String = "PensideTest"
    Public Const TableTestActivity As String = "TestActivity"
    Public Const TableSampleLink As String = "SampleLink"
    Public Const TableCaseActivity As String = "CaseActivity"
    Public Const TableCaseLink As String = "CaseLink"
    Public Sub New()
        ObjectName = "PensideTests"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        If ID Is Nothing Then
            Throw New Exception("PensideTests service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet
        Try

            Dim cmd As IDbCommand = CreateSPCommand("spPensideTests_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim TestAdapter As DbDataAdapter = CreateAdapter(cmd)

            'Fill the main object table
            DebugTimer.Start(String.Format("{0} adapter fill", Me.GetType.Name))
            TestAdapter.Fill(ds, TableTests)
            DebugTimer.Stop()
            CorrectTable(ds.Tables(0), TableTests)
            ClearColumnsAttibutes(ds)
            'ds.Tables(0).Columns("strSpecimenName").ReadOnly = False
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
    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
        Dim dsCopy As DataSet = ds.Copy()
        Try
            ExecPostProcedure("spPensideTest_Post", ds.Tables(TableTests), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function CreateTest(ByVal ds As DataSet) As DataRow
        Dim testRow As DataRow = ds.Tables(TableTests).NewRow()
        testRow("idfPensideTest") = NewIntID()
        'testRow("intHACode") = HACode
        testRow("idfVetCase") = m_ID
        ds.EnforceConstraints = False
        ds.Tables(TableTests).Rows.Add(testRow)
        Return testRow
    End Function
    Public Sub DeleteTest(ByVal ds As DataSet, ByVal TestID As Object)
        Dim row As DataRow = ds.Tables(TableTests).Rows.Find(TestID)
        If Not row Is Nothing Then
            row.Delete()
        End If
    End Sub

End Class
