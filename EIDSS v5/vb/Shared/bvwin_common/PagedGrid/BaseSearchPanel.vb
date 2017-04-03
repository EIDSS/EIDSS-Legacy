
Imports System.Collections.Generic

Public Class BaseSearchPanel
    Inherits DevExpress.XtraEditors.XtraUserControl
    Implements ISearchForm
    Private Shared m_StringOperators As New List(Of SearchOperatorItem)
    Private Shared m_IntOperators As New List(Of SearchOperatorItem)
    Private Shared m_DateOperators As New List(Of SearchOperatorItem)
    Private Shared m_BoolOperators As New List(Of SearchOperatorItem)
    Private Shared m_LookupOperators As New List(Of SearchOperatorItem)

    Public Enum SearchOpertorKind
        [String]
        [Numeric]
        [Date]
        [Bool]
        Lookup
    End Enum
    Protected Class SearchOperatorItem
        Public Sub New(ByVal op As String)
            m_Name = op
            m_Operator = op
        End Sub

        Private m_Operator As String
        Public Property [Operator]() As String
            Get
                Return m_Operator
            End Get
            Set(ByVal Value As String)
                m_Operator = Value
            End Set
        End Property

        Private m_Name As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property
    End Class
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitOperators()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseSearchPanel
        '
        Me.Name = "BaseSearchPanel"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overridable ReadOnly Property FilterCondition() As String Implements ISearchForm.FilterCondition
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property FromCondition() As String Implements ISearchForm.FromCondition
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable Sub Init(ByVal Grid As Object) Implements ISearchForm.Init
        Clear()
    End Sub

    Public Event Search(ByVal FilterCondition As String, ByVal FromCondition As String) Implements ISearchForm.Search
    Public Event SearchUsingProcedure(ByVal SearchParameters As System.Collections.Generic.Dictionary(Of String, Object)) Implements ISearchForm.SearchUsingProcedure

    Public Overridable Sub SetStartupParameters(ByVal parameters As System.Collections.Hashtable) Implements ISearchForm.SetStartupParameters

    End Sub

    Public Overridable ReadOnly Property SearchParameters() As System.Collections.Generic.Dictionary(Of String, Object) Implements ISearchForm.SearchParameters
        Get
            Return Nothing
        End Get
    End Property
    Private m_SearchMethod As ListSearchMethod = common.ListSearchMethod.Function
    Public Property SearchMethod() As ListSearchMethod
        Get
            Return m_SearchMethod
        End Get
        Set(ByVal value As ListSearchMethod)
            m_SearchMethod = value
        End Set
    End Property
    Public Sub DoSearch()
        Try
            If SearchMethod = common.ListSearchMethod.Function Then
                RaiseEvent Search(FilterCondition, FromCondition)
            Else
                RaiseEvent SearchUsingProcedure(SearchParameters)
            End If

        Catch ex As InvalidCastException
            ErrorForm.ShowWarning("errInvalidSearchCriteria", "Invalid search criteria.")
        Catch ex1 As Exception
            ErrorForm.ShowError(ex1)
        End Try

    End Sub

    Protected Sub AddWhereCondition(ByVal value As Object, ByVal FieldName As String, ByVal FieldType As Type, ByVal FieldCaption As String, ByVal Operation As String, ByRef where As String)
        'Dim convertedValue As Object
        If Not Utils.IsEmpty(value) Then
            'If Operation.Trim.ToUpper() <> "LIKE" Then
            '    Try
            '        If (FieldType.Equals(GetType(String)) = True) Then
            '            'convertedValue = value.ToString()
            '            convertedValue = Utils.Str(value)
            '        Else
            '            convertedValue = Convert.ChangeType(value, FieldType)
            '        End If
            '    Catch exeption As Exception
            '        Throw New Exception(String.Format(BvMessages.Get("ErrInvalidFieldFormat", "Invalid data format for field '{0}'."), FieldCaption), exeption)
            '    End Try
            'End If
            Try
                Convert.ChangeType(value, FieldType)
            Catch ex As Exception
                Throw New InvalidCastException
            End Try
            If Not Utils.IsEmpty(where) Then where += " And "
            where += "(" + bv.common.db.SqlParser.CreateCondition(FieldName, FieldType, Operation, value) + ")"
        End If
    End Sub
    Protected Sub AddWhereCondition(ByVal ed As DevExpress.XtraEditors.BaseEdit, ByVal FieldName As String, ByVal FieldType As Type, ByVal FieldCaption As String, ByVal Operation As String, ByRef where As String)
        Try
            AddWhereCondition(ed.EditValue, FieldName, FieldType, FieldCaption, Operation, where)
        Catch ex As Exception
            ed.Select()
            Throw
        End Try
    End Sub
    Protected Sub Clear()
        For Each ctl As Control In Controls
            If TypeOf (ctl) Is DevExpress.XtraEditors.BaseEdit Then
                CType(ctl, DevExpress.XtraEditors.BaseEdit).EditValue = DBNull.Value
            End If
        Next
    End Sub

    Public Sub BaseSearchPanel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'e.Handled = True
            DoSearch()
            Return
            '    Dim FocusedControl As Control = ActiveControl
            '    If TypeOf (ActiveControl) Is ContainerControl Then
            '        FocusedControl = CType(ActiveControl, ContainerControl).ActiveControl
            '    End If

            '    If TypeOf (FocusedControl) Is DevExpress.XtraEditors.PopupBaseEdit AndAlso _
            '        Not TypeOf (FocusedControl) Is DevExpress.XtraEditors.LookUpEdit AndAlso _
            '        CType(FocusedControl, DevExpress.XtraEditors.PopupBaseEdit).IsPopupOpen() Then
            '        Exit Sub
            '    End If
            '    If TypeOf (FocusedControl) Is DevExpress.XtraEditors.MemoEdit OrElse _
            '            (TypeOf (FocusedControl) Is DevExpress.XtraEditors.TextBoxMaskBox) AndAlso _
            '            (Not CType(FocusedControl, DevExpress.XtraEditors.TextBoxMaskBox).Parent Is Nothing AndAlso _
            '            TypeOf (CType(FocusedControl, DevExpress.XtraEditors.TextBoxMaskBox).Parent) Is DevExpress.XtraEditors.MemoEdit) Then
            '        Exit Sub
            '    End If
            '    If (TypeOf (FocusedControl) Is DevExpress.XtraEditors.TextBoxMaskBox) AndAlso _
            '       (Not FocusedControl.Parent Is Nothing) AndAlso _
            '       (TypeOf (FocusedControl.Parent) Is DevExpress.XtraEditors.ButtonEdit) Then
            '        Dim edit As DevExpress.XtraEditors.ButtonEdit = CType(FocusedControl.Parent, DevExpress.XtraEditors.ButtonEdit)
            '        If (Not edit.Tag Is Nothing) AndAlso (TypeOf (edit.Tag) Is TagHelper) Then
            '            Dim helper As TagHelper = CType(edit.Tag, TagHelper)
            '            If helper.IsBarcode Then
            '                edit.SelectAll()
            '                Exit Sub
            '            End If
            '        End If
            '    End If
            '    SelectNextControl(FocusedControl, True, True, True, True)
        End If
    End Sub
    Protected Shared Sub FillSearchKind(ByVal cbSearchKind As DevExpress.XtraEditors.ComboBoxEdit, _
                               ByVal SearchKindCase As Integer)
        cbSearchKind.Properties.Items.Clear()
        Select Case SearchKindCase
            Case 0
                cbSearchKind.Properties.Items.Add("=")
                cbSearchKind.Properties.Items.Add("<>")
                cbSearchKind.Properties.Items.Add(">")
                cbSearchKind.Properties.Items.Add("<")
                cbSearchKind.Properties.Items.Add("Like")
            Case 1
                cbSearchKind.Properties.Items.Add("=")
                cbSearchKind.Properties.Items.Add("<>")
            Case 2
                cbSearchKind.Properties.Items.Add("=")
                cbSearchKind.Properties.Items.Add("<>")
                cbSearchKind.Properties.Items.Add(">")
                cbSearchKind.Properties.Items.Add("<")
        End Select
        cbSearchKind.SelectedIndex = 0
    End Sub

    Protected Shared Function GetOperatorsList(ByVal opKind As SearchOpertorKind) As List(Of SearchOperatorItem)
        Select Case opKind
            Case SearchOpertorKind.Bool
                Return m_BoolOperators
            Case SearchOpertorKind.Date
                Return m_DateOperators
            Case SearchOpertorKind.Lookup
                Return m_LookupOperators
            Case SearchOpertorKind.Numeric
                Return m_IntOperators
            Case SearchOpertorKind.String
                Return m_StringOperators
            Case Else
                Return m_StringOperators
        End Select
    End Function
    Private Shared Sub InitOperators()
        If m_StringOperators.Count = 0 Then
            m_StringOperators.Add(New SearchOperatorItem("="))
            m_StringOperators.Add(New SearchOperatorItem("<>"))
            m_StringOperators.Add(New SearchOperatorItem(">"))
            m_StringOperators.Add(New SearchOperatorItem("<"))
            m_StringOperators.Add(New SearchOperatorItem("Like"))
        End If

        If m_BoolOperators.Count = 0 Then
            m_BoolOperators.Add(New SearchOperatorItem("="))
            m_BoolOperators.Add(New SearchOperatorItem("<>"))
        End If

        If m_LookupOperators.Count = 0 Then
            m_LookupOperators.Add(New SearchOperatorItem("="))
            m_LookupOperators.Add(New SearchOperatorItem("<>"))
        End If

        If m_DateOperators.Count = 0 Then
            m_DateOperators.Add(New SearchOperatorItem("="))
            m_DateOperators.Add(New SearchOperatorItem("<>"))
            m_DateOperators.Add(New SearchOperatorItem(">"))
            m_DateOperators.Add(New SearchOperatorItem("<"))
        End If

        If m_IntOperators.Count = 0 Then
            m_IntOperators.Add(New SearchOperatorItem("="))
            m_IntOperators.Add(New SearchOperatorItem("<>"))
            m_IntOperators.Add(New SearchOperatorItem(">"))
            m_IntOperators.Add(New SearchOperatorItem("<"))
        End If

    End Sub

    Protected Shared Sub AddWhereUTCTime(ByVal value As Object, ByVal FieldName As String, ByVal Operation As String, ByRef where As String)
        If Not (TypeOf (value) Is DateTime) Then Exit Sub
        If Not Utils.IsEmpty(where) Then where += " And "
        Dim dt As String = CType(bv.common.db.TimeUtils.Local2UTC(value), DateTime).ToString("s")
        where += "(" + FieldName + Operation + "'" + dt + "')"
    End Sub

End Class
