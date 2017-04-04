Imports System.Data
Imports bv.common.Enums

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
            FillDataset(cmd, ds, TableTests)
            CorrectTable(ds.Tables(0), TableTests)
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
        Set(ByVal value As HACode)
            m_HACode = value
        End Set
    End Property
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
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
        InitTestRow(testRow)
        ds.EnforceConstraints = False
        ds.Tables(TableTests).Rows.Add(testRow)
        Return testRow
    End Function
    Public Sub DeleteTest(ByVal ds As DataSet, ByVal testID As Object)
        Dim row As DataRow = ds.Tables(TableTests).Rows.Find(testID)
        If Not row Is Nothing Then
            row.Delete()
        End If
    End Sub

    Public Sub InitTestRow(ByVal dataRow As DataRow)
        dataRow("idfPensideTest") = NewIntID()
        dataRow("idfVetCase") = m_ID
    End Sub
End Class
