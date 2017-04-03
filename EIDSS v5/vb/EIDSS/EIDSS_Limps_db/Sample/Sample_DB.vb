Imports System.Data
Imports System.Data.Common
Imports bv.common.Core

Public Class Sample_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Sample"
        Dim val As Long = ContainerStatus.Accessioned
        Me.ListFilterCondition = "idfsContainerStatus=" + val.ToString()
    End Sub

    '--------- Flexible Form
    Public ObjID As String
    Public ValuesTableName As String
    '--------- Flexible Form

    'Dim SampleDetail_Adapter As DbDataAdapter
    'Dim AgentType_Adapter As DbDataAdapter
    'Dim SpecimenType_Adapter As DbDataAdapter
    'Dim CaseLink_Adapter As DbDataAdapter
    'Dim PartyLink_Adapter As DbDataAdapter

    Public Const TableSample As String = "Sample"
    Public Const TableDiagnosis As String = "Diagnosis"
    'Public Const TableCase As String = "CaseActivity"
    'Public Const TableCaseInfo As String = "Case"
    'Public Const TableAgent As String = "Agent"
    'Public Const TableSpecimen As String = "Specimen"
    'Public Const TableContainer As String = "Container"
    Public Const TableTest As String = "Test"
    Public Const TableTransferFrom As String = "TransferFrom"
    Public Const TableTransferTo As String = "TransferTo"
    'Public Const TablePartyLink As String = "PartyLink"
    'Public Const TableParty As String = "Party"
    'Public Const TableRegistrationActivity As String = "RegistrationActivity"
    'Public Const TableRegistration As String = "Registration"
    'Public Const TableCollectedByOrganization As String = "CollectedByOrganization"
    'Public Const TableCollectedByEmployee As String = "CollectedByEmployee"
    'Public Const TableRegisteredByOrganization As String = "RegisteredByOrganization"
    'Public Const TableRegisteredByEmployee As String = "RegisteredByEmployee"
    'Public Const TableRegMaterialParticipation As String = "RegMaterialParticipation"
    'Public Const TableLabManageActivity As String = "LabManageActivity"
    'Public Const TableOriginalMaterial As String = "OriginalMaterial"
    'Public Const TableSampleParameters As String = "SampleParameters"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        ds.EnforceConstraints = False
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spLabSample_SelectDetail")
            AddParam(cmd, "@idfContainer", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            'Fill the main object table
            CreateAdapter(cmd, False).Fill(ds, TableSample)

            CorrectTable(ds.Tables(0), TableSample)
            CorrectTable(ds.Tables(1), TableTest)
            CorrectTable(ds.Tables(2), TableTransferFrom)
            CorrectTable(ds.Tables(3), TableTransferTo)

            For Each col As DataColumn In ds.Tables(TableTest).Columns
                col.ReadOnly = False
            Next

            Dim idfCase As Object = -1
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                If Not ds.Tables(0).Rows(0)("idfCase") Is DBNull.Value Then
                    idfCase = ds.Tables(0).Rows(0)("idfCase")
                ElseIf Not ds.Tables(0).Rows(0)("idfMonitoringSession") Is DBNull.Value Then
                    idfCase = ds.Tables(0).Rows(0)("idfMonitoringSession")
                ElseIf Not ds.Tables(0).Rows(0)("idfVectorSurveillanceSession") Is DBNull.Value Then
                    idfCase = 0 'diagnosis for all vector sessions are the same and populated using predefined key = 0
                End If
            End If

            'cmd = CreateSPCommand("spCase_DiagnosisList")
            'AddParam(cmd, "@idfCase", idfCase)
            cmd = CreateSPCommand("spLabTestEditable_GetSampleDiagnosis")
            AddParam(cmd, "@idfMaterial", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            CreateAdapter(cmd, False).Fill(ds, TableDiagnosis)
            Dim table As DataTable = ds.Tables(TableDiagnosis)
            CorrectTable(ds.Tables(TableDiagnosis), TableDiagnosis)
            'table.PrimaryKey = New DataColumn() {table.Columns("idfCase"), table.Columns("idfsDiagnosis")}

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
            Dim cmd As IDbCommand
            Dim row As DataRow = ds.Tables(TableSample).Rows(0)
            If row.RowState = DataRowState.Modified Then
                cmd = CreateSPCommand("spLabSample_Post", transaction)
                AddParam(cmd, "idfContainer", ID)
                AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                'AddParam(cmd, "@useDepartment", 1)
                AddParam(cmd, "@idfInDepartment", row("idfInDepartment"))
                AddParam(cmd, "@strNote", row("strNote"))
                cmd.ExecuteNonQuery()
            End If
            ExecPostProcedure("spLabSample_TestsPost", ds.Tables(TableTest), Connection, transaction)

        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function


    Private Shared Sub SetVirtualMaterialLink(ByVal row As DataRow, ByVal MaterialId As Object)
        row.Table.Columns("idfMaterial").ReadOnly = False
        row("idfMaterial") = MaterialId
        row.Table.Columns("idfMaterial").ReadOnly = True
    End Sub

End Class
