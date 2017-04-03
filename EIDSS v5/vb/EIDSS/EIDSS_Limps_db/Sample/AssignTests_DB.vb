Imports bv.common.Diagnostics
Imports bv.common.Core
Imports bv.model.Model.Core

Public Class AssignTests_DB

    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AssignTests"

    End Sub

    Public Code As HACode

    Protected Sub CreateTables(ByRef ds As DataSet)
        Dim Containers As DataTable = New DataTable("Containers")
        ds.Tables.Add(Containers)
        Containers.Columns.Add("idfContainer", GetType(Long))
        Containers.Columns.Add("strBarcode", GetType(String))
        Containers.Columns.Add("idfCase", GetType(Long))
        Containers.Columns.Add("idfMonitoringSession", GetType(Long))
        Containers.Columns.Add("idfVectorSurveillanceSession", GetType(Long))
        Containers.Columns.Add("idfsDiagnosis", GetType(Long))
        Containers.Columns.Add("idfsSpeciesType", GetType(Long))

        Containers.PrimaryKey = New DataColumn() {Containers.Columns("idfContainer")}

        Dim Cases As DataTable = New DataTable("Cases")
        ds.Tables.Add(Cases)
        Cases.Columns.Add("idfCase", GetType(Long))
        Cases.Columns.Add("idfsDiagnosis", GetType(Long))
        Cases.Columns.Add("datDiagnosis", GetType(Date))
        Cases.Columns.Add("idfsSpeciesType", GetType(Long))
        Cases.PrimaryKey = New DataColumn() {Cases.Columns("idfCase"), Cases.Columns("idfsDiagnosis"), Cases.Columns("idfsSpeciesType")}
        Dim view As DataView = New DataView(Cases)
        view.Sort = "idfCase"

        Dim cmd As IDbCommand = CreateSPCommand("spCase_DiagnosisList")

        For Each row As Object In CType(ID, IEnumerable)

            Dim Caseid As Object = Nothing
            Dim idfMonitoringSession As Object = Nothing
            Dim idfVSSession As Object = Nothing
            Dim diagnosis As Object = Nothing
            Dim idfContainer As Object = Nothing
            Dim strBarcode As Object = Nothing
            Dim idfCase As Object = Nothing
            Dim idfsSpeciesType As Object = Nothing
            If TypeOf row Is DataRow Then 'call from Accession form
                Dim rowSample As DataRow = CType(row, DataRow)
                Caseid = rowSample("idfCase")
                idfMonitoringSession = rowSample("idfMonitoringSession")
                idfVSSession = rowSample("idfVectorSurveillanceSession")
                diagnosis = DBNull.Value
                strBarcode = rowSample("strBarcode")
                idfCase = rowSample("idfCase")
                idfContainer = rowSample("idfContainer")
                idfsSpeciesType = rowSample("idfsSpeciesType")
                If rowSample("idfsCaseType").Equals(CLng(CaseType.Avian)) Then
                    Code = HACode.Avian
                ElseIf rowSample("idfsCaseType").Equals(CLng(CaseType.Livestock)) Then
                    Code = HACode.Livestock
                ElseIf rowSample("idfsCaseType").Equals(CLng(CaseType.Human)) Then
                    Code = HACode.Human

                End If

            ElseIf TypeOf row Is IObject Then 'Call from SamplesListPanel
                Dim rowObject As IObject = CType(row, IObject)
                'If rowObject.ObjectName = "LabSampleLogBookListItem" Then
                '    Caseid = rowObject.GetValue("idfCase")
                '    idfMonitoringSession = rowObject.GetValue("idfMonitoringSession")
                '    idfVSSession = rowObject.GetValue("idfVectorSurveillanceSession")
                '    diagnosis = rowObject.GetValue("idfsDiagnosis")
                '    strBarcode = rowObject.GetValue("strBarcode")
                '    idfCase = rowObject.GetValue("idfCase")
                '    idfContainer = rowObject.GetValue("idfMaterial")
                '    idfsSpeciesType = rowObject.GetValue("idfsSpeciesType")
                'Else
                Caseid = rowObject.GetValue("idfCase")
                idfMonitoringSession = rowObject.GetValue("idfMonitoringSession")
                idfVSSession = rowObject.GetValue("idfVectorSurveillanceSession")
                diagnosis = rowObject.GetValue("idfsShowDiagnosis")
                strBarcode = rowObject.GetValue("strBarcode")
                idfCase = rowObject.GetValue("idfCase")
                idfContainer = rowObject.GetValue("idfContainer")
                idfsSpeciesType = rowObject.GetValue("idfsSpeciesType")
                Code = CType(rowObject.GetValue("HACode"), HACode)
                'End If
            End If
            If Not Utils.IsEmpty(idfVSSession) Then
                Code = HACode.Vector
            ElseIf Not Utils.IsEmpty(idfMonitoringSession) Then
                Code = HACode.Livestock
            End If

            'For Each rowSample As DataRow In CType(ID, IEnumerable)

            If Utils.IsEmpty(Caseid) Then Caseid = idfMonitoringSession
            If Utils.IsEmpty(Caseid) Then Caseid = 0
            If view.Find(Caseid) = -1 Then
                cmd.Parameters.Clear()
                AddParam(cmd, "@idfCase", Caseid)
                AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                CreateAdapter(cmd).Fill(Cases)
                ds.Merge(Cases)
            End If
            Dim count As Integer = view.FindRows(Caseid).Length
            view.Sort = "name"
            If (count > 1) Then
                'diagnosis = DBNull.Value
                If Not idfMonitoringSession Is Nothing AndAlso Utils.IsEmpty(diagnosis) Then
                    diagnosis = view(0)("idfsDiagnosis")
                End If
            ElseIf count = 1 AndAlso Utils.IsEmpty(diagnosis) Then
                diagnosis = view(0)("idfsDiagnosis")
            End If
            view.Sort = "idfCase"

            Containers.Rows.Add(idfContainer, strBarcode, idfCase, idfMonitoringSession, idfVSSession, diagnosis, idfsSpeciesType)
        Next

    End Sub

    Protected Sub CreateAsigned(ByRef ds As DataSet)
        Dim table As DataTable = New DataTable("Assigned")
        ds.Tables.Add(table)
        table.Columns.Add("idfTesting", GetType(Long))
        table.Columns.Add("idfContainer", GetType(Long))
        table.Columns.Add("strBarcode", GetType(String))
        table.Columns.Add("idfCase", GetType(Long))
        table.Columns.Add("idfMonitoringSession", GetType(Long))
        table.Columns.Add("idfVectorSurveillanceSession", GetType(Long))
        table.Columns.Add("idfsDiagnosis", GetType(Long))
        table.Columns.Add("idfsTestType", GetType(Long))
        table.Columns.Add("TestName", GetType(String))
        table.Columns.Add("idfsTestForDiseaseType", GetType(Long))

        table.PrimaryKey = New DataColumn() {table.Columns("idfContainer"), table.Columns("idfsDiagnosis"), table.Columns("idfsTestType")}
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        m_ID = ID
        MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        CreateTables(ds)

        Dim cmd As IDbCommand = Me.CreateSPCommand("spLabTestAssign_SelectList")
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ParameterDirection.Input)
        AddParam(cmd, "@HACode", Code, ParameterDirection.Input)
        CreateAdapter(cmd).Fill(ds, "Test")
        Dim table As DataTable = ds.Tables("Test1")
        CorrectTable(table, "DiseaseTest")
        table = ds.Tables("Test")
        'table = table.Clone
        'table.TableName = "Assigned"
        'table.PrimaryKey = New DataColumn() {table.Columns("idfsReference")}
        'For Each c As DataColumn In table.Columns
        '    c.ReadOnly = False
        'Next
        'ds.Tables.Add(table)
        CreateAsigned(ds)
        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Dim table As DataTable = ds.Tables("Assigned")
        For Each rowTest As DataRow In table.Rows
            If rowTest.RowState = DataRowState.Added Then
                AssignTestToSample(rowTest, transaction)
            End If
            If rowTest.RowState = DataRowState.Deleted Then
                Dim test As Object = rowTest.Item("idfTesting", DataRowVersion.Original)
                If CanDelete(test, "LabTest", transaction) Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabTest_Delete", transaction)
                    AddParam(cmd, "@ID", test)
                    cmd.ExecuteNonQuery()
                End If
            End If
        Next
        Return True
    End Function

    'Sub AssignTests(ByRef Sample As DataRow, ByRef Test As DataRow, ByRef transaction As IDbTransaction)

    '    Dim idfContainer As Object = Sample("idfContainer")
    '    'Dim idfMaterial As Object = Sample("idfMaterial")
    '    Dim idfCase As Object = Sample("idfCase")
    '    Dim TestName As Object = Test("idfsReference")
    '    Dim TestType As Object = Test("idfsTestForDiseaseType")

    '    AssignTestToSample(idfContainer, idfCase, TestName, TestType, transaction)
    'End Sub

    Public Shared Function AssignTestToSample(ByRef row As DataRow, ByRef transaction As IDbTransaction) As Boolean
        If (row("idfTesting") Is DBNull.Value OrElse CLng(row("idfTesting")) <= 0) Then
            Dim NewTestID As Long = NewIntID(transaction)
            row("idfTesting") = NewTestID
        End If


        '''''Dim EventID As Object = Nothing
        '''''PutDAO(NewTestID, EIDSSAuditObject.daoTest.ToString(), "Activity", transaction, EventID)

        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLabTest_Create", bv.common.db.Core.ConnectionManager.DefaultInstance.Connection, transaction)
        AddParam(cmd, "@idfTesting", row("idfTesting"))
        AddParam(cmd, "@idfContainer", row("idfContainer"))
        AddParam(cmd, "@idfsTestType", row("idfsTestType"))
        AddParam(cmd, "@idfsTestForDiseaseType", row("idfsTestForDiseaseType"))
        AddParam(cmd, "@idfsDiagnosis", row("idfsDiagnosis"))
        AddParam(cmd, "@idfTestedByOffice", EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID)

        BaseDbService.ExecCommand(cmd, bv.common.db.Core.ConnectionManager.DefaultInstance.Connection, transaction, True)

        Return True

    End Function


    Private Sub PutDAO(ByVal ID As Object, ByRef type As String, ByVal MainObjectTable As String, ByRef transaction As IDbTransaction, ByRef EventID As Object)

        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spAudit_CreateNewEvent", Me.Connection, transaction)

        BaseDbService.AddParam(command, "@idfsDataAuditEventType", "daeCreate", ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfsDataAuditObjectType ", type, ParameterDirection.Input)
        BaseDbService.AddParam(command, "@strMainObjectTable", MainObjectTable, ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfsMainObject", ID, ParameterDirection.Input)
        BaseDbService.AddParam(command, "@strReason", Nothing, ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfDataAuditEvent", EIDSS.model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Output)
        command.ExecuteNonQuery()
        EventID = BaseDbService.GetParamValue(command, "@idfDataAuditEvent")
    End Sub

    Private Sub ClearDAO(ByRef transaction As IDbTransaction, ByRef EventID As Object)
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spClearContextData", Me.Connection, transaction)
        BaseDbService.AddParam(command, "@ClearEventID", False, ParameterDirection.Input)
        BaseDbService.AddParam(command, "@ClearDataAuditEvent", True, ParameterDirection.Input)
        command.ExecuteNonQuery()
        command = BaseDbService.CreateSPCommand("dbo.spFiltered_CheckEvent", Connection, transaction)
        BaseDbService.AddParam(command, "@event", EventID)
        command.ExecuteNonQuery()
    End Sub
    Public Overrides Sub Merge(ByVal dsTarget As DataSet, ByVal dsSource As DataSet)
#If Debug = True Then
        For Each t As DataTable In dsTarget.Tables
            Dbg.Assert(t.PrimaryKey IsNot Nothing AndAlso t.PrimaryKey.Length > 0, "The table {0} has no primary key", t.TableName)
        Next
#End If
        For Each t As DataTable In dsTarget.Tables
            t.Clear()
            t.AcceptChanges()
        Next
        dsTarget.Merge(dsSource)
    End Sub

End Class
