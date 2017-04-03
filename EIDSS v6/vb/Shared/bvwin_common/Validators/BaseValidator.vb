Imports bv.common.Resources

Public Class BaseValidator
    Implements IValidator
    Public Property Caption As String
    Public Property FieldName As String
    Public Property TableName As String
    Public Property Owner As BaseForm
    Public Property Control As Control
    Public Property RowHandle As Integer
    Public Property ShowErrorForm As Boolean
    Protected m_OldValue As Object
    Protected m_Filter As String
    Protected m_View As DataView
    Protected ReadOnly Property View As DataView
        Get
            If (m_View Is Nothing) Then
                If Not Owner Is Nothing AndAlso Not Owner.baseDataSet Is Nothing AndAlso Owner.baseDataSet.Tables.Contains(TableName) Then
                    m_View = New DataView(Owner.baseDataSet.Tables(TableName))
                    If (String.IsNullOrEmpty(Filter)) Then
                        m_View.RowFilter = Filter
                    End If
                    m_View.RowStateFilter = DataViewRowState.CurrentRows
                End If
            End If
            Return m_View
        End Get
    End Property
    Protected m_RootForm As BaseForm

    Public Property Filter As String
        Get
            Return m_Filter
        End Get
        Set(aValue As String)
            m_Filter = aValue
            If (Not View Is Nothing) Then
                View.RowFilter = m_Filter
                View.RowStateFilter = DataViewRowState.CurrentRows
            End If
        End Set
    End Property
    Public Sub New(aOwner As BaseForm, aControl As Control, aTableName As String, aFieldName As String, aCaption As String, Optional aFilter As String = Nothing, Optional onAfterFieldChangeValidate As Action = Nothing)
        Owner = aOwner
        FieldName = aFieldName
        Caption = aCaption
        Filter = aFilter
        TableName = aTableName
        Control = aControl
        Active = True
        ShowErrorForm = True
        If Not onAfterFieldChangeValidate Is Nothing Then
            AddHandler AfterFieldChangeValidate, onAfterFieldChangeValidate
        End If
    End Sub

    Public Overridable Sub RegisterValidator(ByVal baseForm As BaseForm, Optional ByVal validateOnFieldChange As Boolean = False) Implements IValidator.RegisterValidator
        m_RootForm = baseForm
        m_RootForm.Validators.Add(Me)
        If (validateOnFieldChange) Then
            AttachEventHandler(AddressOf OnDataFieldChange)
        End If
    End Sub

    Public Overridable Function Validate(rowToValidate As DataRow, ByVal showError As Boolean) As Boolean Implements IValidator.Validate
        m_ErrorMessage = Nothing
        Return True
    End Function

    Public Overridable Function Validate(rowToValidate As DataRow, oldValue As Object, ByVal showError As Boolean) As Boolean
        m_OldValue = oldValue
        Dim result As Boolean = Validate(rowToValidate, showError)
        m_OldValue = Nothing
        Return result
    End Function

    Public Overridable Property Active() As Boolean Implements IValidator.Active

    Protected Overridable Sub AttachEventHandler(handler As DataFieldChangeHandler)
        If Not Owner Is Nothing Then
            Owner.eventManager.AttachDataHandler(String.Format("{0}.{1}", TableName, FieldName), handler)
        End If
    End Sub

    Public Overridable Sub OnDataFieldChange(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Validate(e.Row, e.OldValue, True)
        RaiseEvent AfterFieldChangeValidate()
    End Sub

    Public Event AfterFieldChangeValidate As Action

    Private Shared m_Messages As BaseStringsStorage = BvMessages.Instance
    Public Shared Property Messages() As BaseStringsStorage
        Get
            Return m_Messages
        End Get
        Set(value As BaseStringsStorage)
            m_Messages = value
        End Set
    End Property
    Protected m_ErrorMessage As String
    Public ReadOnly Property ErrorMessage As String
        Get
            Return m_ErrorMessage
        End Get
    End Property
    Protected Overridable Function Message(Optional aStrict As Boolean = False) As String
        Return String.Empty
    End Function

    Public Overridable ReadOnly Property Row(Optional index As Integer = 0) As DataRow
        Get
            If (Not View Is Nothing AndAlso index < View.Count) Then
                Return View(index).Row
            End If
            Return Nothing
        End Get

    End Property
    Public Overridable ReadOnly Property Value(Optional index As Integer = 0) As Object
        Get
            Dim row As DataRow = Me.Row(index)
            If (Not row Is Nothing AndAlso View.Table.Columns.Contains(FieldName)) Then
                Return row(FieldName)
            End If
            Return DBNull.Value
        End Get
    End Property
    Public Overridable ReadOnly Property Count() As Integer
        Get
            If (Not View Is Nothing) Then
                Return View.Count
            End If
            Return 0
        End Get
    End Property


End Class
