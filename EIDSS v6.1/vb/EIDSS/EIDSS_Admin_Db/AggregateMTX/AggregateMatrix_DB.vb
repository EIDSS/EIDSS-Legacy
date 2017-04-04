Imports System.Data.Common
Imports System.Text.RegularExpressions
Imports bv.common.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class AggregateMatrix_DB
    Inherits BaseDbService

    Public Sub New()
        Me.UseDatasetCopyInPost = False
    End Sub

    Public Const TableMatrix As String = "AggregateMatrix"
    Public Const TableVersionsList As String = "VersionLookup"
    Public Const TableCurrentVersion As String = "Version"
    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand

            cmd = CreateSPCommand(SelectProcedure)
            FillDataset(cmd, ds, TableMatrix)
            CorrectTable(ds.Tables(1), TableCurrentVersion)
            CorrectTable(ds.Tables(2), TableVersionsList)
            ClearColumnsAttibutes(ds)
            ds.Tables(TableMatrix).Columns(MatrixKeyField).AutoIncrement = True
            ds.Tables(TableMatrix).Columns(MatrixKeyField).AutoIncrementSeed = -1
            ds.Tables(TableMatrix).Columns(MatrixKeyField).AutoIncrementStep = -1
            ds.Tables(TableMatrix).PrimaryKey = New DataColumn() {ds.Tables(TableMatrix).Columns(MatrixKeyField), ds.Tables(TableMatrix).Columns("idfVersion")}
            If ds.Tables(TableCurrentVersion).Rows.Count = 0 Then
                CreateNewMatrixVersion(ds, -1)
                ForceTableChanges(ds.Tables(TableCurrentVersion))
                ForceTableChanges(ds.Tables(TableVersionsList))
            End If

            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal postType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim view As DataView = New DataView(ds.Tables(TableMatrix))
            view.Sort = "idfVersion, intNumRow"
            For Each versionRow As DataRow In ds.Tables(TableVersionsList).Rows
                If versionRow.RowState = DataRowState.Deleted OrElse versionRow.RowState = DataRowState.Detached Then
                    Continue For
                End If
                Dim i As Integer = 0
                view.RowFilter = String.Format("idfVersion={0}", versionRow("idfVersion"))
                For Each row As DataRowView In view
                    If (Not row("intNumRow").Equals(i)) Then
                        row("intNumRow") = i
                        row.EndEdit()
                    End If
                    i += 1
                Next

            Next

            ExecPostProcedure("spAggregateMatrixVersionHeader_Post", ds.Tables(TableVersionsList), Connection, transaction)
            ExecPostProcedure(PostProcedure, ds.Tables(TableMatrix), Connection, transaction)
            bv.common.db.Core.LookupCache.NotifyChange("AggrMatrixVersionHeader", transaction)
            'use matrix type as event id
            AddEvent(EventType.MatrixChanged, MatrixEditorName, False)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Sub CreateNewMatrixVersion(ByVal ds As DataSet, ByVal baseVersion As Long)
        Dim row As DataRow
        If ds.Tables(TableCurrentVersion).Rows.Count = 0 Then
            row = ds.Tables(TableCurrentVersion).NewRow
        Else
            row = ds.Tables(TableCurrentVersion).Rows(0)
        End If
        Dim versionName As String = Utils.Str(row("MatrixName"))
        If Utils.IsEmpty(versionName) Then
            versionName = "Matrix Name"
        Else
            versionName = GenerateDefaultVersionName(versionName, ds)
        End If
        Dim newVersion As Long = BaseDbService.NewIntID
        row("idfVersion") = newVersion
        row("idfsAggrCaseSection") = MatrixType
        row("MatrixName") = versionName
        row("datStartDate") = DateTime.Now
        row("blnIsActive") = 0
        row("blnIsDefault") = 0
        If ds.Tables(TableCurrentVersion).Rows.Count = 0 Then
            ds.Tables(TableCurrentVersion).Rows.Add(row)
        End If
        row.EndEdit()
        Dim row1 As DataRow = ds.Tables(TableVersionsList).NewRow
        For Each col As DataColumn In ds.Tables(TableVersionsList).Columns
            If (row.Table.Columns.Contains(col.ColumnName)) AndAlso col.ColumnName <> "datStartDate" Then
                row1(col.ColumnName) = row(col.ColumnName)
            End If
        Next
        row1("intState") = 0
        ds.Tables(TableVersionsList).Rows.Add(row1)
        Dim originalRows As DataRow() = ds.Tables(TableMatrix).Select(String.Format("idfVersion = {0}", baseVersion))
        For Each row In originalRows
            Dim rowCopy As DataRow = ds.Tables(TableMatrix).NewRow
            For Each col As DataColumn In ds.Tables(TableMatrix).Columns
                If col.ColumnName = MatrixKeyField Then
                    Continue For
                End If
                If col.ColumnName = "idfVersion" Then
                    rowCopy(col.ColumnName) = newVersion
                ElseIf col.ColumnName = "intNumRow" OrElse Not col.ColumnName.EndsWith("Row") Then
                    rowCopy(col.ColumnName) = row(col.ColumnName)
                End If
            Next
            ds.Tables(TableMatrix).Rows.Add(rowCopy)

        Next
    End Sub

    Shared nameRegEx As New Regex("(?<Name>.*?)\s*\(Copy\s(?<Num>\d+)\)")
    Private Function GenerateDefaultVersionName(ByVal name As String, ByVal ds As DataSet) As String
        Dim newName As String
        Dim i As Integer = 1
        Dim match As Match = nameRegEx.Match(name)
        If match.Length > 0 Then
            If Integer.TryParse(match.Groups("Num").Value, i) Then
                i += 1
            End If
            name = match.Groups("Name").Value
        End If
        Do
            newName = String.Format("{0} (Copy {1})", name, i)

            If ds.Tables(TableVersionsList).Select(String.Format("MatrixName='{0}'", newName.Replace("'", "''"))).Length = 0 Then
                Return newName
            End If
            i += 1
        Loop
    End Function

    Dim m_SelectProcedure As String

    Public Property SelectProcedure() As String
        Get
            Return m_SelectProcedure
        End Get
        Set(ByVal Value As String)
            m_SelectProcedure = Value
        End Set
    End Property

    Dim m_PostProcedure As String

    Public Property PostProcedure() As String
        Get
            Return m_PostProcedure
        End Get
        Set(ByVal Value As String)
            m_PostProcedure = Value
        End Set
    End Property

    Dim m_MatrixKeyField As String

    Public Property MatrixKeyField() As String
        Get
            Return m_MatrixKeyField
        End Get
        Set(ByVal Value As String)
            m_MatrixKeyField = Value
        End Set
    End Property

    Dim m_MatrixType As AggregateCaseSection

    Public Property MatrixType() As AggregateCaseSection
        Get
            Return m_MatrixType
        End Get
        Set(ByVal Value As AggregateCaseSection)
            m_MatrixType = Value
        End Set
    End Property

    Public Property MatrixEditorName() As String


End Class
