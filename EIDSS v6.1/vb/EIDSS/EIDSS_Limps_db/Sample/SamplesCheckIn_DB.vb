Imports System.Data.Common
Imports bv.common.Diagnostics
Imports bv.common.Core
Imports bv.common.Enums
Imports eidss.model.Core

Public Class SamplesCheckIn_DB
    Inherits CaseSamples_Db

    'Private m_HACode As HACode = HACode.Animal Or HACode.Livestock
    'Public Property HACode() As HACode
    '    Get
    '        Return m_HACode
    '    End Get
    '    Set(ByVal Value As HACode)
    '        m_HACode = Value
    '    End Set
    'End Property

    ''' <summary>
    ''' проверка , что материал есть в базе данных
    ''' </summary>
    ''' <param name="id">id материала</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckForExist(ByVal id As Long) As Boolean

        Try
            Dim value As Object
            Dim cmd As IDbCommand = CreateSPCommand("dbo.spLabSample_MaterialExists", Connection)
            'AddTypedParam(cmd, "@idfMaterial", SqlDbType.BigInt, ParameterDirection.InputOutput)
            AddParam(cmd, "@idfMaterial", id, ParameterDirection.Input)
            value = ExecScalar(cmd, Connection, m_Error)

            If Not m_Error Is Nothing Then
                Dbg.Debug("error during checking that sample exists for sample {0}: {1}", id, m_Error.DetailError)
                Return True
            End If
            If (Utils.IsEmpty(value)) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Dbg.Debug("error during checking that sample exists for sample {0}: {1}", id, ex)
            Return True 'let's return true and allow sample deleting to avoid user confusing in this case, error should not occur
        End Try
    End Function



    ''' <summary>
    ''' Check for existance of barcode
    ''' </summary>
    Public Shared Function CheckBarcodeForExist(row As DataRow) As Boolean
        If (row Is Nothing) Then
            Return False
        End If
        Dim idfMaterial As Long = CLng(row("idfMaterial"))
        Dim barcode As String = Utils.Str(row("strBarcode"))
        Dim value As Object
        Try
            Dim cmd As IDbCommand = CreateSPCommand("dbo.spLabSample_BarcodeExists", db.Core.ConnectionManager.DefaultInstance.Connection)
            Dim err As ErrorMessage = Nothing
            AddParam(cmd, "@idfMaterial", idfMaterial, ParameterDirection.Input)
            AddParam(cmd, "@strBarcode", barcode, ParameterDirection.Input)
            value = ExecScalar(cmd, cmd.Connection, err)

            If Not err Is Nothing Then
                Dbg.Debug("error during checking that barcode exists for sample with barcode {0}:'{1}", barcode, err.DetailError)
                Return True
            End If
            If (Not Utils.IsEmpty(value)) Then
                Return True
            End If
            If row.Table.Select(String.Format("idfMaterial<>{0} and strBarcode = '{1}'", idfMaterial, barcode)).Length > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Dbg.Debug("error during checking that barcode exists for sample with barcode {0}: {1}", barcode, ex)
            Return True
        End Try
    End Function


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        'If ID Is Nothing Then
        'Throw New Exception("CaseSamplesDetail service must be initialized with NOT NULL case ID")
        'End If
        Dim ds As New DataSet
        If ID Is Nothing Then
            Return ds
        End If

        m_ID = ID

        Try

            'ds.EnforceConstraints = False

            'GetCaseInformation(ds)

            Dim cmd As IDbCommand
            ' SELECT
            'cmd = CreateSPCommand("select top 10000 dbo.fn_Sample_SelectList.* from dbo.fn_Sample_SelectList(@LangID)  where 0 = 0',N'@LangID nvarchar(2)',@LangID=N'en'")
            'cmd.CommandType = CommandType.Text '.TableDirect()


            cmd = CreateSPCommand("spLabSampleReceive_SelectDetail")
            AddParam(cmd, "@CaseID", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            FillDataset(cmd, ds, TableCaseActivity)

            CorrectTable(ds.Tables(1), TableSamples)
            CorrectTable(ds.Tables(2), "PartyList")
            CorrectTable(ds.Tables(3), "Antibiotics")
            CorrectTable(ds.Tables(4), "VectorPartyList")
            ds.Tables(TableCaseActivity).PrimaryKey = New DataColumn() {ds.Tables(TableCaseActivity).Columns("ID")}
            ds.Tables(TableSamples).PrimaryKey = New DataColumn() {ds.Tables(TableSamples).Columns("idfMaterial")}
            ds.Tables("PartyList").PrimaryKey = New DataColumn() {ds.Tables("PartyList").Columns("idfParty")}
            ds.Tables("VectorPartyList").PrimaryKey = New DataColumn() {ds.Tables("VectorPartyList").Columns("idfParty")}
            ds.Tables(5).PrimaryKey = New DataColumn() {ds.Tables(5).Columns("idfCase"), ds.Tables(5).Columns("idfsDiagnosis"), ds.Tables(5).Columns("idfsSpeciesType")}
            CorrectTable(ds.Tables(5), "Diagnosis")
            CorrectTable(ds.Tables(6), "SampleToVectorType")

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
            MyBase.PostDetail(ds, PostType, transaction)
            For Each row As DataRow In ds.Tables(TableSamples).Rows
                If row.RowState <> DataRowState.Added And row.RowState <> DataRowState.Modified Then Continue For
                If row.RowState = DataRowState.Added OrElse _
                    ( _
                         (Not Utils.IsEmpty(row("datAccession"))) AndAlso _
                        Utils.IsEmpty(row("datAccession", DataRowVersion.Original)) _
                    ) Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSampleReceive_PostDetail", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
                    AddParam(cmd, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
                    AddParam(cmd, "@datAccession", row("datAccession"), ParameterDirection.Input)
                    AddParam(cmd, "@idfDepartment", row("idfInDepartment"), ParameterDirection.Input)
                    AddParam(cmd, "@strCondition", row("strCondition"), ParameterDirection.Input)
                    AddParam(cmd, "@idfsAccessionCondition", row("idfsAccessionCondition"), ParameterDirection.Input)
                    AddParam(cmd, "@strNote", row("strNote"), ParameterDirection.Input)
                    AddParam(cmd, "@idfSubdivision", row("idfSubdivision"), ParameterDirection.Input)
                    AddParam(cmd, "@idfAccesionByPerson", row("idfAccesionByPerson"), ParameterDirection.Input)
                    AddParam(cmd, "@idfSendToOffice", EidssSiteContext.Instance.OrganizationID, ParameterDirection.Input)
                    duplicateBarcode = Utils.Str(row("strBarcode"))
                    ExecCommand(cmd, cmd.Connection, transaction, True)
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


    Public Function GetCaseIdByBarcode(barcode As String) As Object

        Dim cmd As IDbCommand

        cmd = CreateSPCommand("spLabSample_BarcodeExistsInMaterial")
        AddParam(cmd, "@value", barcode)

        Dim val As Object = ExecScalar(cmd, Connection, m_Error)

        Return val

    End Function
    Public Overrides Sub LinkSample(row As DataRow, parentID As Object)
        If SessionType = model.Enums.SessionType.AsSession Then
            row("idfMonitoringSession") = parentID
        ElseIf SessionType = model.Enums.SessionType.VsSession Then
            row("idfVectorSurveillanceSession") = parentID
        Else
            row("idfCase") = parentID
        End If

    End Sub
    <CLSCompliantAttribute(False)>
    Public Property SessionType() As model.Enums.SessionType
    Public Shared Function GetTestCount(idfMaterial As Long) As Integer
        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_GetTestCount", db.Core.ConnectionManager.DefaultInstance.Connection)
        Dim errMsg As ErrorMessage = Nothing
        AddParam(cmd, "@idfMaterial", idfMaterial)
        Dim cnt As Object = ExecScalar(cmd, db.Core.ConnectionManager.DefaultInstance.Connection, errMsg)
        If (Not Utils.IsEmpty(cnt)) Then
            Return CInt(cnt)
        Else
            Return 0
        End If

    End Function
End Class
