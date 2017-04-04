Imports bv.common.Diagnostics
Imports bv.common.Core
Imports bv.model.Model.Core

Public Class AssignTests_DB

    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AssignTests"

    End Sub

    Public Property Code As HACode

    Protected Sub CreateTables(ByRef ds As DataSet)
        Dim containers As DataTable = New DataTable("Containers")
        ds.Tables.Add(containers)
        containers.Columns.Add("idfMaterial", GetType(Long))
        containers.Columns.Add("strBarcode", GetType(String))
        containers.Columns.Add("idfCase", GetType(Long))
        containers.Columns.Add("idfMonitoringSession", GetType(Long))
        containers.Columns.Add("idfVectorSurveillanceSession", GetType(Long))
        containers.Columns.Add("idfsDiagnosis", GetType(Long))
        containers.Columns.Add("idfsSpeciesType", GetType(Long))

        containers.PrimaryKey = New DataColumn() {containers.Columns("idfMaterial")}

        Dim cases As DataTable = New DataTable("Cases")
        ds.Tables.Add(cases)
        cases.Columns.Add("idfCase", GetType(Long))
        cases.Columns.Add("idfsDiagnosis", GetType(Long))
        cases.Columns.Add("datDiagnosis", GetType(Date))
        cases.Columns.Add("idfsSpeciesType", GetType(Long))
        cases.PrimaryKey = New DataColumn() {cases.Columns("idfCase"), cases.Columns("idfsDiagnosis"), cases.Columns("idfsSpeciesType")}
        Dim view As DataView = New DataView(cases)
        view.Sort = "idfCase"

        Dim cmd As IDbCommand = CreateSPCommand("spCase_DiagnosisList")

        For Each row As Object In CType(ID, IEnumerable)

            Dim caseid As Object = Nothing
            Dim idfMonitoringSession As Object = Nothing
            Dim idfVsSession As Object = Nothing
            Dim diagnosis As Object = Nothing
            Dim idfMaterial As Object = Nothing
            Dim strBarcode As Object = Nothing
            Dim idfCase As Object = Nothing
            Dim idfsSpeciesType As Object = Nothing
            If TypeOf row Is DataRow Then 'call from Accession form
                Dim rowSample As DataRow = CType(row, DataRow)
                caseid = rowSample("idfCase")
                idfMonitoringSession = rowSample("idfMonitoringSession")
                idfVsSession = rowSample("idfVectorSurveillanceSession")
                diagnosis = DBNull.Value
                strBarcode = rowSample("strBarcode")
                idfCase = rowSample("idfCase")
                idfMaterial = rowSample("idfMaterial")
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
                caseid = rowObject.GetValue("idfCase")
                idfMonitoringSession = rowObject.GetValue("idfMonitoringSession")
                idfVsSession = rowObject.GetValue("idfVectorSurveillanceSession")
                diagnosis = rowObject.GetValue("idfsShowDiagnosis")
                strBarcode = rowObject.GetValue("strBarcode")
                idfCase = rowObject.GetValue("idfCase")
                idfMaterial = rowObject.GetValue("idfMaterial")
                idfsSpeciesType = rowObject.GetValue("idfsSpeciesType")
                Code = CType(rowObject.GetValue("HACode"), HACode)
                'End If
            End If
            If Not Utils.IsEmpty(idfVsSession) Then
                Code = HACode.Vector
            ElseIf Not Utils.IsEmpty(idfMonitoringSession) Then
                Code = HACode.Livestock
            End If

            If Utils.IsEmpty(caseid) Then caseid = idfMonitoringSession
            If Utils.IsEmpty(caseid) Then caseid = 0
            If view.Find(caseid) = -1 Then
                cmd.Parameters.Clear()
                AddParam(cmd, "@idfCase", caseid)
                AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
                FillTable(cmd, cases)
                ds.Merge(cases)
            End If
            'view.Sort = "name"
            Dim caseRows As DataRowView() = view.FindRows(caseid)
            If (caseRows.Length > 1) Then
                If Not idfMonitoringSession Is Nothing AndAlso Utils.IsEmpty(diagnosis) Then
                    diagnosis = caseRows(0)("idfsDiagnosis")
                End If
            ElseIf caseRows.Length = 1 AndAlso Utils.IsEmpty(diagnosis) Then
                diagnosis = caseRows(0)("idfsDiagnosis")
            End If
            'view.Sort = "idfCase"

            containers.Rows.Add(idfMaterial, strBarcode, idfCase, idfMonitoringSession, idfVsSession, diagnosis, idfsSpeciesType)
        Next

    End Sub

    Protected Sub CreateAsigned(ByRef ds As DataSet)
        Dim table As DataTable = New DataTable("Assigned")
        ds.Tables.Add(table)
        table.Columns.Add("idfTesting", GetType(Long))
        table.Columns.Add("idfMaterial", GetType(Long))
        table.Columns.Add("strBarcode", GetType(String))
        table.Columns.Add("idfCase", GetType(Long))
        table.Columns.Add("idfMonitoringSession", GetType(Long))
        table.Columns.Add("idfVectorSurveillanceSession", GetType(Long))
        table.Columns.Add("idfsDiagnosis", GetType(Long))
        table.Columns.Add("idfsTestName", GetType(Long))
        table.Columns.Add("TestName", GetType(String))
        table.Columns.Add("idfsTestCategory", GetType(Long))

        table.PrimaryKey = New DataColumn() {table.Columns("idfMaterial"), table.Columns("idfsDiagnosis"), table.Columns("idfsTestName")}
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        m_ID = ID
        MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        CreateTables(ds)

        Dim cmd As IDbCommand = CreateSPCommand("spLabTestAssign_SelectList")
        AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage, ParameterDirection.Input)
        AddParam(cmd, "@HACode", Code, ParameterDirection.Input)
        FillDataset(cmd, ds, "Test")
        Dim table As DataTable = ds.Tables("Test1")
        CorrectTable(table, "DiseaseTest")
        CreateAsigned(ds)
        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
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
                    ExecCommand(cmd, cmd.Connection, transaction, True)
                End If
            End If
        Next
        Return True
    End Function


    Public Shared Function AssignTestToSample(ByRef row As DataRow, ByRef transaction As IDbTransaction) As Boolean
        If (row("idfTesting") Is DBNull.Value OrElse CLng(row("idfTesting")) <= 0) Then
            Dim newTestID As Long = NewIntID(transaction)
            row("idfTesting") = newTestID
        End If

        Dim cmd As IDbCommand = CreateSPCommand("spLabTest_Create", db.Core.ConnectionManager.DefaultInstance.Connection, transaction)
        AddParam(cmd, "@idfTesting", row("idfTesting"))
        AddParam(cmd, "@idfMaterial", row("idfMaterial"))
        AddParam(cmd, "@idfsTestName", row("idfsTestName"))
        AddParam(cmd, "@idfsTestCategory", row("idfsTestCategory"))
        AddParam(cmd, "@idfsDiagnosis", row("idfsDiagnosis"))
        AddParam(cmd, "@idfTestedByOffice", model.Core.EidssSiteContext.Instance.OrganizationID)

        ExecCommand(cmd, db.Core.ConnectionManager.DefaultInstance.Connection, transaction, True)

        Return True

    End Function


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
