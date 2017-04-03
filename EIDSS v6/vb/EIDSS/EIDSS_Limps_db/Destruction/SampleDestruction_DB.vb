Imports bv.common.Core
Imports bv.model.Model.Core
Imports System.Data.Common
Imports bv.common.db.Core
Imports eidss.model.Core
Imports EIDSS.model.Enums

Public Class SampleDestruction_DB
    Inherits bv.common.db.BaseDbService

    Public Property DestroyMode As Boolean = False

    Public Sub New()
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Me.m_IsNewObject = True
        'MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        Dim rows As IEnumerable = CType(ID, IEnumerable)
        Dim cmd As IDbCommand
        If Not rows Is Nothing Then
            Dim table As DataTable = New DataTable("Samples")
            table.Columns.Add("idfMaterial", GetType(Long))
            table.Columns.Add("strBarcode", GetType(String))
            table.Columns.Add("strSampleName", GetType(String))
            table.Columns.Add("idfsSampleStatus", GetType(Long))
            table.Columns.Add("idfsDestructionMethod", GetType(Long))
            table.PrimaryKey = New DataColumn() {table.Columns("idfMaterial")}
            For Each sample As IObject In rows
                Dim row As DataRow = table.NewRow
                For Each col As DataColumn In table.Columns
                    Dim val As Object = sample.GetValue(col.ColumnName)
                    If Not val Is Nothing Then
                        If col.ColumnName = "idfsSampleStatus" Then
                            If DestroyMode Then
                                If Utils.Str(val) = CType(SampleStatus.Delete, Long).ToString() Then
                                    val = SampleStatus.IsDeleted
                                Else
                                    val = SampleStatus.Destroyed
                                End If
                            Else
                                val = SampleStatus.RoutineDestruction
                            End If
                        End If
                        row(col.ColumnName) = val
                    ElseIf col.ColumnName = "idfsDestructionMethod" AndAlso CLng(SampleStatus.Destroyed).Equals(row("idfsSampleStatus")) Then
                        SetDefaultDestructionMethod(row)

                    End If
                Next
                table.Rows.Add(row)
            Next
            table.TableName = "Samples"
            ds.Tables.Add(table)
        End If

        Dim user As DataTable = New DataTable("User")
        user.Columns.Add("idfDestroyedByPerson", GetType(Long))
        user.PrimaryKey = New DataColumn() {user.Columns(0)}
        user.Rows.Add(New Object() {EIDSS.model.Core.EidssUserContext.User.EmployeeID})
        ds.Tables.Add(user)


        cmd = CreateSPCommand("spLabSampleDestruction_SelectDetail")
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        AddParam(cmd, "@destroy", DestroyMode)
        CreateAdapter(cmd).Fill(ds, "Status")

        Return ds
    End Function
    Public Shared Sub SetDefaultDestructionMethod(row As DataRow)
        Dim view As DataView = LookupCache.Get(db.BaseReferenceType.rftDestructionMethod)
        If view.Count > 1 Then
            row("idfsDestructionMethod") = view(1)("idfsReference")
            row.EndEdit()
        End If

    End Sub
    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal postType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Dim person As Object = ds.Tables("User").Rows(0)("idfDestroyedByPerson")
        Dim table As DataTable = ds.Tables("Samples")
        For Each row As DataRow In table.Rows
            If row.RowState = DataRowState.Deleted Then Continue For
            Dim cmd As IDbCommand = CreateSPCommand("spLabSampleDestruction_Post", transaction)
            AddParam(cmd, "idfMaterial", row("idfMaterial"), ParameterDirection.Input)
            AddParam(cmd, "@idfsSampleStatus", row("idfsSampleStatus"), ParameterDirection.Input)
            AddParam(cmd, "@idfsDestructionMethod", row("idfsDestructionMethod"), ParameterDirection.Input)
            AddParam(cmd, "@idfDestroyedByPerson", person, ParameterDirection.Input)
            AddParam(cmd, "@destroy", Me.DestroyMode, ParameterDirection.Input)
            AddParam(cmd, "@idfMarkedForDispositionByPerson", EidssUserContext.User.EmployeeID, ParameterDirection.Input)
            cmd.ExecuteNonQuery()
        Next
        Return True
    End Function

    '    Public Overrides Function CanDelete(ByVal ID As Object, Optional ByVal aObjectName As String = Nothing, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
    '       Return True
    '  End Function

    Public Overrides Function Delete(ByVal ID As Object, ByVal transaction As System.Data.IDbTransaction, ByVal name As String) As Boolean
        'Dim rows As DataRow() = CType(ID, DataRow())
        'For Each row As DataRow In rows
        Dim cmd As IDbCommand = CreateSPCommand("spLabSampleDestruction_Delete", Connection, transaction)
        If AddParam(cmd, "@ID", ID, m_Error) Is Nothing Then Return (False)
        m_Error = ExecCommand(cmd, Connection, transaction)
        If Not m_Error Is Nothing Then Return False
        'Next
        Return True
    End Function

End Class
