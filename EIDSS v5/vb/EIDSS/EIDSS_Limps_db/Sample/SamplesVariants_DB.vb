Imports bv.common.db.Core
Imports bv.model.Model.Core

Public Class SamplesVariants_DB
    Inherits BaseDbService

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        Dim en As IEnumerator = CType(ID, IEnumerable).GetEnumerator()
        If en Is Nothing Then Return Nothing
        Dim cmd As IDbCommand
        While en.MoveNext
            Dim row As IObject = CType(en.Current, IObject)
            cmd = CreateSPCommand("spLabSampleVariant_SelectDetail")
            AddParam(cmd, "@idfContainer", row.GetValue("idfContainer"))
            Using materialRow As DataSet = New DataSet
                CreateAdapter(cmd).Fill(materialRow, "Original")
                ds.Merge(materialRow)
                DbDisposeHelper.ClearDataset(materialRow)
            End Using
        End While

        cmd = CreateSPCommand("spLabDerivativeTypes")
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        CreateAdapter(cmd).Fill(ds, "Derivatives")

        'retrieve departments
        'Lookup_Db.FillDepartmentLookup(ds, EIDSS.model.Core.EidssUserContext.User.OrganizationID)

        Dim original As DataTable = ds.Tables("Original")
        original.PrimaryKey = New DataColumn() {original.Columns("idfContainer")}
        Dim variants As DataTable = original.Clone
        variants.TableName = "Variant"

        original.Columns.Add("NewItems", GetType(Integer), Nothing)

        'variants.Columns.Add("idfMaterialParent", variants.Columns("idfMaterial").DataType, Nothing)
        'variants.Columns.Add("idfContainerParent", variants.Columns("idfContainer").DataType, Nothing)
        variants.Columns.Add("Path", GetType(String), Nothing)
        variants.Columns.Add("idfParentContainer", GetType(String), Nothing)
        For Each col As DataColumn In variants.Columns
            col.AllowDBNull = True
        Next
        ds.Tables.Add(variants)
        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Try

            For Each row As DataRow In ds.Tables("Variant").Rows
                If row.RowState <> DataRowState.Modified Then Continue For
                Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Post", Connection, transaction)
                AddParam(cmd, "@idfContainer", row("idfContainer"))
                AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                AddParam(cmd, "@strNote", row("strNote"))
                'AddParam(cmd, "@useDepartment", 1)
                AddParam(cmd, "@idfInDepartment", row("idfInDepartment"))
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function

End Class
