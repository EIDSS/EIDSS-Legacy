Imports bv.common.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class SecurityPolicy_DB : Inherits BaseDbService
    Public Const Table As String = "PolicyList"
    Public Const Alphabet As String = "Alphabet"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        MyBase.GetDetail(ID)
        Dim ds As DataSet = New DataSet
        Dim cmd As IDbCommand = CreateSPCommand("spSecurityPolicy_List")
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ParameterDirection.Input)
        FillDataset(cmd, ds, Table)
        'CorrectTable(ds.Tables(Table))
        Dim t As DataTable = ds.Tables(Table)
        t.PrimaryKey = New DataColumn() {t.Columns("idfSecurityConfiguration")}

        'Dim col As DataColumn
        For Each col As DataColumn In t.Columns
            t.Columns(col.ColumnName).ReadOnly = False
        Next


        ds.Tables(1).TableName = Alphabet
        't.PrimaryKey = New DataColumn() {t.Columns("strName")}
        't.Columns("strValue").ReadOnly = False
        m_IsNewObject = False
        Return ds
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Try
            Dim row As DataRow = ds.Tables(Table).Rows(0)
            If (row.RowState = DataRowState.Modified) Then
                Dim cmd As IDbCommand = CreateSPCommand("spSecurityPolicy_Post", transaction)

                AddParam(cmd, "@ID", row("idfSecurityConfiguration"))
                AddParam(cmd, "@intAccountLockTimeout", row("intAccountLockTimeout"))
                AddParam(cmd, "@intAccountTryCount", row("intAccountTryCount"))
                AddParam(cmd, "@intInactivityTimeout", row("intInactivityTimeout"))
                AddParam(cmd, "@intPasswordAge", row("intPasswordAge"))
                AddParam(cmd, "@intPasswordHistoryLength", row("intPasswordHistoryLength"))
                AddParam(cmd, "@intPasswordMinimalLength", row("intPasswordMinimalLength"))
                AddParam(cmd, "@intForcePasswordComplexity", row("intForcePasswordComplexity"))
                ExecCommand(cmd, cmd.Connection, transaction, True)
                AddEvent(EventType.SecurityPolicyChanged, , False)
            End If

            Return True

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
    End Function


    Private Shared Function GetPolicyValue(ByRef ds As DataSet, ByVal name As String, ByVal def As Integer) As Integer
        If ds Is Nothing Then
            Dim svc As New SecurityPolicy_DB
            ds = svc.GetDetail(Nothing)
        End If
        Dim dt As DataTable = ds.Tables(Table)
        'If table.Rows.Count = 0 Then Return def
        'Dim result As Integer = def
        Dim obj As Integer = def
        If dt.Rows.Count > 0 Then obj = CType(dt.Rows(0)(name), Integer)
        'If Not Utils.IsEmpty(obj) Then
        Return obj
        'End If
        'Return def
    End Function

    'Private Shared Function GetPolicyValue(ByRef ds As DataSet, ByVal name As String, ByVal def As String) As String
    '    If ds Is Nothing Then
    '        Dim svc As New SecurityPolicy_DB
    '        ds = svc.GetDetail(Nothing)
    '    End If
    '    Dim dt As DataTable = ds.Tables(Table)
    '    'If table.Rows.Count = 0 Then Return def
    '    'Dim result As Integer = def
    '    Dim obj As Object
    '    If dt.Rows.Count > 0 Then obj = dt.Rows(0)(name)
    '    Return Utils.Str(obj, def)

    '    'Dim view As New DataView(ds.Tables(Table))
    '    'view.RowFilter = "strName='" + name + "'"
    '    'Dim obj As Object = Nothing
    '    'If view.Count > 0 Then obj = view(0)("strValue")
    '    'Return Utils.Str(obj, def)
    'End Function

    Public Shared Function LockTimeout(Optional ByRef ds As DataSet = Nothing) As Integer
        Dim timeout As Integer = GetPolicyValue(ds, "intInactivityTimeout", 15)
        If timeout <= 0 Then Return 15
        Return timeout
    End Function

    Public Shared Function PasswordMinimumLength(ByRef ds As DataSet) As Integer
        Return GetPolicyValue(ds, "intPasswordMinimalLength", 5)
        'Dim view As New DataView(ds.Tables(Table))
        'view.RowFilter = "strName='PasswordMinimalLength'"
        'If view.Count = 0 Then Return 5
        'Dim obj As Object = view(0)("strValue")
        'Dim result As Integer
        'If Integer.TryParse(Utils.Str(obj, "5"), result) Then
        '    Return result
        'End If
        'Return 5
    End Function

    'Public Shared Function ForcePasswordComplexity(ByRef ds As DataSet) As Boolean
    '    Return GetPolicyValue(ds, "ForcePasswordComplexity", 0) <> 0
    'End Function

    'Public Shared Function ValidatePassword(ByVal password As String, ByVal complex As Boolean) As Boolean
    '    If complex = False Then Return True
    '    Dim check As New System.Text.RegularExpressions.Regex("^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).+$", System.Text.RegularExpressions.RegexOptions.None)
    '    Dim matches As Text.RegularExpressions.MatchCollection = check.Matches(password)
    '    Return matches.Count = 1
    'End Function

    Public Shared Function PasswordExpression(ByVal ds As DataSet) As String
        Dim dt As DataTable = ds.Tables(Alphabet)
        If dt.Rows.Count = 0 Then Return ""
        Return Utils.Str(dt.Rows(0)("strAlphabet"), "")
        'Return GetPolicyValue(ds, "PasswordComplexityExpression", "")
    End Function

    Public Shared Function ValidatePassword(ByVal password As String, ByRef ds As DataSet) As Boolean
        If GetPolicyValue(ds, "intForcePasswordComplexity", 0) = 0 Then Return True
        Dim exp As String = PasswordExpression(ds)
        If exp.Length = 0 Then Return True
        'Dim check As New System.Text.RegularExpressions.Regex("^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).+$", System.Text.RegularExpressions.RegexOptions.None)
        'Dim matches As Text.RegularExpressions.MatchCollection = check.Matches(password)
        Dim matches As Text.RegularExpressions.MatchCollection = Text.RegularExpressions.Regex.Matches(password, exp)
        Return matches.Count > 0
    End Function


End Class
