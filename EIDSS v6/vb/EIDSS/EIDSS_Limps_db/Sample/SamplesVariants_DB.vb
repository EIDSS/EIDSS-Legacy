Imports bv.common.db.Core
Imports bv.model.Model.Core

Public Class SamplesVariants_DB
    Inherits BaseDbService

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        Dim en As IEnumerator = CType(ID, IEnumerable).GetEnumerator()
        If en Is Nothing Then Return Nothing
        Dim cmd As IDbCommand
        While en.MoveNext
            Dim row As IObject = CType(en.Current, IObject)
            cmd = CreateSPCommand("spLabSampleVariant_SelectDetail")
            AddParam(cmd, "@idfMaterial", row.GetValue("idfMaterial"))
            Using materialRow As DataSet = New DataSet
                CreateAdapter(cmd).Fill(materialRow, "Original")
                ds.Merge(materialRow)
                DbDisposeHelper.ClearDataset(materialRow)
            End Using
        End While

        cmd = CreateSPCommand("spLabDerivativeTypes")
        AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
        CreateAdapter(cmd).Fill(ds, "Derivatives")

        Dim original As DataTable = ds.Tables("Original")
        original.PrimaryKey = New DataColumn() {original.Columns("idfMaterial")}
        Dim variants As DataTable = original.Clone
        variants.TableName = "Variant"

        original.Columns.Add("NewItems", GetType(Integer), Nothing)

        variants.Columns.Add("Path", GetType(String), Nothing)
        variants.Columns.Add("idfParentMaterial", GetType(String), Nothing)
        For Each col As DataColumn In variants.Columns
            col.AllowDBNull = True
        Next
        ds.Tables.Add(variants)
        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Try

            For Each row As DataRow In ds.Tables("Variant").Rows
                If row.RowState <> DataRowState.Modified Then Continue For
                Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Post", Connection, transaction)
                AddParam(cmd, "@idfMaterial", row("idfMaterial"))
                AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                AddParam(cmd, "@strNote", row("strNote"))
                AddParam(cmd, "@idfInDepartment", row("idfInDepartment"))
                AddParam(cmd, "@strBarcode", row("strBarcode"))
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function

End Class
