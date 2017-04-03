Imports System.Data.Common
Imports bv.common.Diagnostics
Imports bv.common.Core

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
    ''' <param name="barcodeValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckBarcodeForExist(ByVal barcodeValue As String) As Boolean

        Try
            Dim value As Object
            Dim cmd As IDbCommand = CreateSPCommand("dbo.spLabSample_BarcodeExists", Connection)

            AddParam(cmd, "@value", barcodeValue, ParameterDirection.Input)
            value = ExecScalar(cmd, Connection, m_Error)

            If Not m_Error Is Nothing Then
                Dbg.Debug("error during checking that barcode exists for sample {0}: {1}", ID, m_Error.DetailError)
                Return True
            End If
            If (Utils.IsEmpty(value)) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Dbg.Debug("error during checking that barcode exists for sample {0}: {1}", ID, ex)
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

            Dim SamplesAdapter As DbDataAdapter = CreateAdapter(cmd)
            SamplesAdapter.Fill(ds, CaseSamples_Db.TableCaseActivity)

            CorrectTable(ds.Tables(1), CaseSamples_Db.TableSamples)
            CorrectTable(ds.Tables(2), "PartyList")
            CorrectTable(ds.Tables(3), "Antibiotics")
            CorrectTable(ds.Tables(4), "VectorPartyList")
            ds.Tables(CaseSamples_Db.TableCaseActivity).PrimaryKey = New DataColumn() {ds.Tables(CaseSamples_Db.TableCaseActivity).Columns("ID")}
            ds.Tables(CaseSamples_Db.TableSamples).PrimaryKey = New DataColumn() {ds.Tables(CaseSamples_Db.TableSamples).Columns("idfMaterial")}
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
            TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
            ds.AcceptChanges()

            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Dim duplicateBarcode As String = ""
        Try
            MyBase.PostDetail(ds, PostType, transaction)
            For Each row As DataRow In ds.Tables(CaseSamples_Db.TableSamples).Rows
                If row.RowState <> DataRowState.Added And row.RowState <> DataRowState.Modified Then Continue For
                If row.RowState = DataRowState.Added OrElse _
                    ( _
                         (Not Utils.IsEmpty(row("idfContainer"))) AndAlso _
                        Utils.IsEmpty(row("idfContainer", DataRowVersion.Original)) _
                    ) Then
                    Dim command As IDbCommand = CreateSPCommand("spLabSampleReceive_PostDetail", Connection, transaction)
                    AddParam(command, "@idfContainer", row("idfContainer"), ParameterDirection.Input)
                    AddParam(command, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
                    AddParam(command, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
                    AddParam(command, "@datAccession", TimeUtils.Local2UTC(row("datAccession")), ParameterDirection.Input)
                    AddParam(command, "@idfDepartment", row("idfInDepartment"), ParameterDirection.Input)
                    AddParam(command, "@strCondition", row("strCondition"), ParameterDirection.Input)
                    AddParam(command, "@idfsAccessionCondition", row("idfsAccessionCondition"), ParameterDirection.Input)
                    AddParam(command, "@strNote", row("strNote"), ParameterDirection.Input)
                    AddParam(command, "@idfSubdivision", row("idfSubdivision"), ParameterDirection.Input)
                    AddParam(command, "@idfAccesionByPerson", row("idfAccesionByPerson"), ParameterDirection.Input)
                    'AddParam(command, "@idfsSpecimenType", row("idfsSpecimenType"), ParameterDirection.Input)
                    duplicateBarcode = Utils.Str(row("strBarcode"))
                    command.ExecuteNonQuery()
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
        'Dim SamplesAdapter As DbDataAdapter = CreateAdapter(cmd)
        'SamplesAdapter.Fill(ds, "material")

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
    Public Property SessionType() As eidss.model.Enums.SessionType
    Public Shared Function GetTestCount(idfMaterial As Long) As Integer
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLabSample_GetTestCount", bv.common.db.Core.ConnectionManager.DefaultInstance.Connection)
        Dim errMsg As ErrorMessage = Nothing
        BaseDbService.AddParam(cmd, "@idfMaterial", idfMaterial)
        Dim cnt As Object = BaseDbService.ExecScalar(cmd, bv.common.db.Core.ConnectionManager.DefaultInstance.Connection, errMsg)
        If (Not Utils.IsEmpty(cnt)) Then
            Return CInt(cnt)
        Else
            Return 0
        End If

    End Function
End Class
