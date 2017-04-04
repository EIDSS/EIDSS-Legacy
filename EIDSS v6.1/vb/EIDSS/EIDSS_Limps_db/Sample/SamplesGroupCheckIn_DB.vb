Imports bv.common.Diagnostics
Imports bv.common.Core
Imports bv.common.Enums
Imports eidss.model.Core

Public Class SamplesGroupCheckIn_DB
    Inherits CaseSamples_Db

    ''' <summary>
    ''' проверка , что материал есть в базе данных
    ''' </summary>
    ''' <param name="materialId">id материала</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckForExist(ByVal materialId As Long) As Boolean

        Try
            Dim value As Object
            Dim cmd As IDbCommand = CreateSPCommand("dbo.spLabSample_MaterialExists", Connection)
            AddParam(cmd, "@idfMaterial", materialId, ParameterDirection.Input)
            value = ExecScalar(cmd, Connection, m_Error)

            If Not m_Error Is Nothing Then
                Dbg.Debug("error during checking that sample exists for sample {0}: {1}", materialId, m_Error.DetailError)
                Return True
            End If
            If (Utils.IsEmpty(value)) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Dbg.Debug("error during checking that sample exists for sample {0}: {1}", materialId, ex)
            Return True 'let's return true and allow sample deleting to avoid user confusing in this case, error should not occur
        End Try
    End Function

    Public Overrides Function GetDetail(ByVal barCode As Object) As DataSet

        Dim ds As New DataSet
        If barCode Is Nothing Then
            Return ds
        End If

        m_ID = barCode

        Try


            Dim cmd As IDbCommand
            cmd = CreateSPCommand("spLabGroupSample_SelectDetail")
            AddParam(cmd, "@Barcode", barCode)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            FillDataset(cmd, ds, TableSamples)

            ds.Tables(TableSamples).Columns.Add("Used", GetType(Int16))


            ds.Tables(TableSamples).PrimaryKey = New DataColumn() {ds.Tables(TableSamples).Columns("idfMaterial")}

            For Each table As DataTable In ds.Tables
                For Each col As DataColumn In table.Columns
                    col.AllowDBNull = True
                    col.ReadOnly = False
                Next
            Next
            'TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
            ds.AcceptChanges()

            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Dim duplicateBarcode As String = ""
        Try
            If ds.Tables.Count = 0 Then
                Return True
            End If

            For Each row As DataRow In ds.Tables(TableSamples).Rows
                If row.RowState <> DataRowState.Added And row.RowState <> DataRowState.Modified Then Continue For
                If row.RowState = DataRowState.Modified OrElse _
                    ( _
                         (Not Utils.IsEmpty(row("datAccession"))) And _
                        Utils.IsEmpty(row("datAccession", DataRowVersion.Original)) _
                    ) Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSampleReceive_PostDetail", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
                    AddParam(cmd, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
                    AddParam(cmd, "@datAccession", row("datAccession"), ParameterDirection.Input)
                    AddParam(cmd, "@idfDepartment", row("idfInDepartment"), ParameterDirection.Input)
                    AddParam(cmd, "@strCondition", row("strCondition"), ParameterDirection.Input)
                    AddParam(cmd, "@idfsAccessionCondition", row("idfsAccessionCondition"), ParameterDirection.Input)
                    AddParam(cmd, "@strNote", DBNull.Value, ParameterDirection.Input)
                    AddParam(cmd, "@idfSubdivision", row("idfSubdivision"), ParameterDirection.Input)
                    AddParam(cmd, "@idfAccesionByPerson", model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Input)
                    AddParam(cmd, "@idfSendToOffice", EidssSiteContext.Instance.OrganizationID, ParameterDirection.Input)
                    duplicateBarcode = Utils.Str(row("strBarcode"))
                    ExecCommand(cmd, cmd.Connection, transaction, True)
                    row("Used") = "1"

                Else
                    duplicateBarcode = ""
                End If
            Next
        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex, duplicateBarcode)
            Return False
        End Try
        Return True
    End Function

End Class
