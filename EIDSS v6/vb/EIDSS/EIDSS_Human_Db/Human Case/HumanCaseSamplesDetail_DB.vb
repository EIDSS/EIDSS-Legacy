Imports System.Data
Imports System
Imports System.Data.Common
Imports System.ComponentModel


Public Class HumanCaseSamplesDetail_DB
    'Inherits BaseDbService
    Inherits CaseSamples_Db

    Public Const TableTests As String = "Tests"
    'Dim CaseGuid As Guid = Nothing

    Public Sub New()
        MyBase.New()
        ObjectName = "CaseTest"
    End Sub

    Enum TablesEnum
        Materials = 0
        Tests = 1
        ' PartyParticipation = 2
    End Enum

    'Private m_DefaultPartyID As Object = DBNull.Value
    '<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public Property DefaultPartyID() As Object
    '       Get
    '           Return m_DefaultPartyID
    '       End Get
    '       Set(ByVal Value As Object)
    '           m_DefaultPartyID = Value
    '       End Set
    '   End Property

    'Private Function GetNewMaterialsTable() As DataTable
    '    Dim dt As DataTable = Nothing
    '    dt = New DataTable(TablesEnum.Materials.ToString())
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfMaterial", GetType(Guid), False))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("strFieldBarCode", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("strBarCode", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfsSpecimen_Type", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("datCollectionDate", GetType(DateTime), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("datSentDate", GetType(DateTime), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfParty", GetType(Guid), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfActivity", GetType(Guid), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("datReceiveDate", GetType(DateTime), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("blnCanEdit", GetType(Boolean), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfsTest_Type", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("datComplete_Date", GetType(DateTime), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfsTestResult", GetType(String), True))
    '    Dim PK(1) As DataColumn
    '    PK(0) = dt.Columns("idfMaterial")
    '    dt.PrimaryKey = PK
    '    Return dt
    'End Function

    'Private Function GetNewTestsTable() As DataTable
    '    Dim dt As DataTable = Nothing
    '    dt = New DataTable(TablesEnum.Tests.ToString())
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfActivity", GetType(Guid), False))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("strActivityCode", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("idfMaterial", GetType(Guid), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("TestType", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("Result", GetType(String), True))
    '    dt.Columns.Add(HumanCase_DB.GetNewColumn("datComplete_Date", GetType(DateTime), True))
    '    Dim PK(1) As DataColumn
    '    PK(0) = dt.Columns("idfActivity")
    '    dt.PrimaryKey = PK
    '    Return dt
    'End Function

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        m_ID = ID
        Dim ds As DataSet = Nothing
        'Remove for Search Mode'If (Not Utils.IsEmpty(ID)) AndAlso (Utils.Str(ID) = Utils.Str(Utils.SEARCH_MODE_ID)) Then
        'Remove for Search Mode'    'ds.Tables.Add(GetNewMaterialsTable())
        'Remove for Search Mode'    'ds.Tables.Add(GetNewTestsTable())
        'Remove for Search Mode'    'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftSpecimenType, Connection, HACode.Human, False)
        'Remove for Search Mode'    'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftTestName, Connection, HACode.Human, False)
        'Remove for Search Mode'    'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftTestResult, Connection, HACode.Human, False)
        'Remove for Search Mode'Else
        'ds = MyBase.GetDetail(ID)
        ds = New DataSet()

        Dim cmd As IDbCommand = CreateSPCommand("spHumanCaseSamples_SelectDetail")
        AddParam(cmd, "@idfCase", ID)
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        Dim TestAdapter As DbDataAdapter = CreateAdapter(cmd)
        TestAdapter.Fill(ds, TableSamples)
        CorrectTable(ds.Tables(0))
        CorrectTable(ds.Tables(1), TableTests)
        CorrectTable(ds.Tables(2), TableCaseActivity)
        CorrectTable(ds.Tables(3), TableSamplesToCollect)

        ClearColumnsAttibutes(ds)
        TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
        'Remove for Search Mode'End If
        Dim t As DataTable = ds.Tables(TableCaseActivity)
        If (t.Rows.Count = 0) Then
            Dim cs As DataRow = t.NewRow()
            cs("idfVetCase") = ID
            t.Rows.Add(cs)
        End If

        For Each col As DataColumn In ds.Tables(TableTests).Columns
            ds.Tables(TableTests).Columns(col.ColumnName).ReadOnly = False
        Next
        Return ds
    End Function


    'Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
    '    Dim ds As New DataSet
    '    Try
    '        If (Not Utils.IsEmpty(ID)) AndAlso (Utils.Str(ID) = Utils.Str(Utils.SEARCH_MODE_ID)) Then
    '            ds.Tables.Add(GetNewMaterialsTable())
    '            ds.Tables.Add(GetNewTestsTable())
    '            'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftSpecimenType, Connection, HACode.Human, False)
    '            'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftTestName, Connection, HACode.Human, False)
    '            'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftTestResult, Connection, HACode.Human, False)
    '        Else
    '            If Utils.IsEmpty(ID) Then
    '                Throw New Exception("Human Case Samples Db Service must be initialized with NOT NULL Case ID")
    '            ElseIf Not Utils.IsGuid(ID) Then
    '                Throw New Exception("Case ID for Human Case Samples Db Service must be guid.")
    '            End If

    '            Me.CaseGuid = CType(ID, Guid)

    '            Dim cmd As IDbCommand = CreateSPCommand("spCaseTests_SelectDetail2")
    '            AddParam(cmd, "@idfCase", ID)
    '            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

    '            Dim TestAdapter As DbDataAdapter = CreateAdapter(cmd)
    '            TestAdapter.Fill(ds)

    '            For Each TableName As TablesEnum In System.Enum.GetValues(GetType(TablesEnum))
    '                CorrectTable(ds.Tables(TableName), TableName.ToString())
    '            Next

    '            'ds.Tables(TablesEnum.Materials).Columns("strSampleName").ReadOnly = False
    '            ds.Tables(TablesEnum.Materials).Columns("idfActivity").ReadOnly = False
    '            ds.Tables(TablesEnum.Materials).Columns("datReceiveDate").ReadOnly = True
    '            ds.Tables(TablesEnum.Materials).Columns("blnCanEdit").ReadOnly = False

    '            'c'Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftSpecimenType, Connection, HACode.Human, False)
    '        End If
    '        m_ID = ID
    '        Return ds
    '    Catch ex As Exception
    '        m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
    '        Return Nothing
    '    End Try
    '    Return Nothing
    'End Function

    'Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
    '    Dim tChangedMaterials As DataTable = ds.Tables(TablesEnum.Materials).GetChanges()
    '    If (tChangedMaterials Is Nothing) Then Return True
    '    Try
    '        For Each row As DataRow In tChangedMaterials.Rows
    '            If (row.RowState = DataRowState.Added) Then
    '                AddNewSample(row, transaction)
    '            ElseIf (row.RowState = DataRowState.Modified) Then
    '                UpdateSample(row, transaction)
    '                Dim IsTestChanged As Boolean = _
    '                        Utils.Str(row("idfActivity", DataRowVersion.Current)) <> _
    '                        Utils.Str(row("idfActivity", DataRowVersion.Original))
    '                If IsTestChanged Then AssignMainTest(row, transaction)
    '            ElseIf (row.RowState = DataRowState.Deleted) Then
    '                DeleteSample(row, transaction)
    '            End If
    '        Next
    '    Catch ex As Exception
    '        m_Error = New ErrorMessage(StandardError.PostError, ex)
    '        Return False
    '    End Try
    '    Return True
    'End Function


    'Public Sub UpdateSample(ByVal SampleRow As System.Data.DataRow, Optional ByVal transaction As System.Data.IDbTransaction = Nothing)
    '    Dim fields As String() = {"idfMaterial", "strFieldBarcode", "datCollectionDate", "idfsSpecimen_Type", "datSentDate"}
    '    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Update", transaction)

    '    'AddParam(cmd, "@idfMaterial", NewSampleRow("idfMaterial"))
    '    'AddParam(cmd, "@datCollectionDate", NewSampleRow("datCollectionDate"))
    '    'AddParam(cmd, "@idfsSpecimen_Type", NewSampleRow("idfsSpecimen_Type"))
    '    'AddParam(cmd, "@datSentDate", NewSampleRow("datCollectionDate"))

    '    For Each field As String In fields
    '        AddParam(cmd, "@" + field, SampleRow(field))
    '    Next
    '    cmd.ExecuteNonQuery()
    'End Sub

    'Public Sub AddNewSample(ByVal SampleRow As System.Data.DataRow, Optional ByVal transaction As System.Data.IDbTransaction = Nothing)
    '    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Create", transaction)
    '    AddParam(cmd, "@idfActivity", Me.CaseGuid)
    '    AddParam(cmd, "@idfMaterial", SampleRow("idfMaterial"))
    '    AddParam(cmd, "@idfsMaterial_Type", "mttLivingObject")
    '    AddParam(cmd, "@idfsMaterial_Responsibility_Type", "mrtHumanSample")
    '    Dim fields As String() = {"strFieldBarcode", "idfsSpecimen_Type", "idfParty", "datSentDate"}
    '    For Each field As String In fields
    '        AddParam(cmd, "@" + field, SampleRow(field))
    '    Next
    '    AddParam(cmd, "@datCollectedDate", SampleRow("datCollectionDate"))
    '    AddParam(cmd, "@idfEmployeeRegistered", EIDSS.model.Core.EidssUserContext.User.EmployeeID)
    '    AddParam(cmd, "@idfOfficeRegistered", EIDSS.model.Core.EidssUserContext.User.OrganizationID)
    '    cmd.ExecuteNonQuery()
    'End Sub


    'Public Function CanDeleteSample(ByVal ID As Object) As Boolean
    '    Dim cmd As IDbCommand = CreateSPCommand("spSample_CanDelete")
    '    AddParam(cmd, "@ID", ID)
    '    AddParam(cmd, "@Result", 0, ParameterDirection.Output)
    '    m_Error = ExecCommand(cmd, Connection)
    '    Dim Result As Object = GetParamValue(cmd, "@Result")
    '    Dim res As Boolean = False
    '    If (Not Utils.IsEmpty(Result)) Then
    '        res = CBool(Result)
    '    End If
    '    Return res
    'End Function

    'Public Sub DeleteSample(ByVal SampleRow As System.Data.DataRow, Optional ByVal transaction As System.Data.IDbTransaction = Nothing)
    '    Dim cmd As IDbCommand = CreateSPCommand("spMaterialSample_Delete", transaction)
    '    Dim MaterialID As Object = SampleRow("idfMaterial", DataRowVersion.Original)
    '    AddParam(cmd, "@ID", MaterialID)
    '    cmd.ExecuteNonQuery()
    'End Sub

    'Sub AssignMainTest(ByVal SampleRow As System.Data.DataRow, Optional ByVal transaction As System.Data.IDbTransaction = Nothing)
    '    Dim cmd As IDbCommand = CreateSPCommand("spCaseMaterial_AssignMainTest", transaction)
    '    AddParam(cmd, "@TestGuid", SampleRow("idfActivity")) ' ID теста 
    '    AddParam(cmd, "@MaterialGuid", SampleRow("idfMaterial")) '
    '    cmd.ExecuteNonQuery()
    'End Sub
End Class
