Imports System.Collections.Generic
Imports bv.winclient.Core

Namespace Validators

    Public MustInherit Class ChainValidator(Of T)
        Inherits BaseValidator
        Private m_Children As List(Of ChainValidator(Of T))
        Protected m_ErrorItem1 As ChainValidator(Of T)
        Protected m_ErrorItem2 As ChainValidator(Of T)
        Public ReadOnly Property ErrorItem1 As ChainValidator(Of T)
            Get
                Return m_ErrorItem1
            End Get
        End Property
        Public ReadOnly Property ErrorItem2 As ChainValidator(Of T)
            Get
                Return m_ErrorItem2
            End Get
        End Property

        Public Property Children As List(Of ChainValidator(Of T))
            Get
                If m_Children Is Nothing Then
                    m_Children = New List(Of ChainValidator(Of T))
                End If
                Return m_Children
            End Get
            Set(val As List(Of ChainValidator(Of T)))
                m_Children = val
            End Set
        End Property
        Protected Property Parent As ChainValidator(Of T)
        Protected m_ParentFilterTemplate As String

        Private Function GetFilterValue(aView As DataView, index As Integer, aFieldName As String) As Object
            If aView Is Nothing OrElse aView.Count <= index Then
                Return -1
            End If
            If Utils.IsEmpty(aView(index)(aFieldName)) Then
                Return -1
            End If
            Return aView(index)(aFieldName)
        End Function
        Protected Overridable ReadOnly Property ParentFilter(parentIndex As Integer) As String
            Get
                If m_View Is Nothing OrElse String.IsNullOrEmpty(m_ParentFilterTemplate) OrElse Parent Is Nothing Then
                    Return Nothing
                End If
                If Not String.IsNullOrEmpty(ParentFilterKeyField) Then
                    Return String.Format(m_ParentFilterTemplate, GetFilterValue(Parent.View, parentIndex, ParentFilterKeyField))
                ElseIf Not Parent.View.Table.PrimaryKey Is Nothing AndAlso Parent.View.Table.PrimaryKey.Length > 0 Then
                    Return String.Format(m_ParentFilterTemplate, GetFilterValue(Parent.View, parentIndex, Parent.View.Table.PrimaryKey(0).ColumnName))
                End If
                Return Nothing
            End Get
        End Property
        Public Property ParentFilterKeyField As String
        Public Property Strict As Boolean

        Public Sub New(aOwner As BaseForm, aControl As Control, aTableName As String, aFieldName As String, aCaption As String, Optional aFilter As String = Nothing, Optional aParentFilterTemplate As String = Nothing, Optional aStrict As Boolean = False, Optional aParentFilterKeyField As String = Nothing, Optional onAfterFieldChangeValidate As Action = Nothing)
            MyBase.New(aOwner, aControl, aTableName, aFieldName, aCaption, aFilter, onAfterFieldChangeValidate)
            m_ParentFilterTemplate = aParentFilterTemplate
            Strict = aStrict
            ParentFilterKeyField = aParentFilterKeyField
        End Sub
        Private m_LastShowErrorTime As Long
        Private Const ShowErrorGap As Long = 500
        Protected Sub DisplayError(showError As Boolean)
            Dim gap As Long = (Environment.TickCount And Int32.MaxValue) - m_LastShowErrorTime
            If (ShowErrorForm AndAlso showError AndAlso (gap < 0 OrElse gap > ShowErrorGap)) Then
                m_LastShowErrorTime = (Environment.TickCount And Int32.MaxValue)
                ErrorForm.ShowWarningDirect(m_ErrorMessage)
            End If
        End Sub
        Protected Overridable Function ValidateMe(rowToValidate As DataRow, showError As Boolean) As Boolean
            Return True
        End Function
        Public Overrides Function Validate(rowToValidate As DataRow, showError As Boolean) As Boolean
            If Not Active Then
                Return True
            End If
            m_ErrorItem1 = Nothing
            m_ErrorItem2 = Nothing
            m_ErrorMessage = Nothing
            Dim defaultItem As ChainValidator(Of T) = Me
            Dim defaultIndex As Integer
            Dim result As Boolean = False
            'Here we try to validate only nodes in chain tree that contain current item
            'ValidateParent metod validates current item against parent nodes only
            Try
                If (Not rowToValidate Is Nothing) Then
                    If (Not ValidateMe(rowToValidate, showError)) Then
                        Return result
                    End If
                    If (ValidateParent(showError, rowToValidate)) Then
                        result = ValidateChild(defaultItem, defaultIndex, showError, rowToValidate)
                    End If
                    Return result
                Else
                    For i As Integer = 0 To Count - 1
                        If Not Validate(Row(i), showError) Then
                            Return result
                        End If
                    Next
                End If
                result = True
                Return result
            Finally
                If Not rowToValidate Is Nothing AndAlso showError AndAlso result = False Then
                    If Not m_OldValue Is Nothing Then
                        rowToValidate(FieldName) = m_OldValue
                    ElseIf rowToValidate.HasVersion(DataRowVersion.Original) Then
                        rowToValidate(FieldName) = rowToValidate(FieldName, DataRowVersion.Original)
                    Else
                        rowToValidate(FieldName) = DBNull.Value
                    End If
                    rowToValidate.EndEdit()
                End If
            End Try
        End Function

        Protected Overrides Sub AttachEventHandler(handler As DataFieldChangeHandler)
            If (Not handler Is Nothing) Then
                MyBase.AttachEventHandler(handler)
            Else
                MyBase.AttachEventHandler(AddressOf OnDataFieldChange)
            End If
            For Each child As ChainValidator(Of T) In Children
                child.AttachEventHandler(Nothing)
            Next
        End Sub
        Private Function ValidateChild(defaultItem As ChainValidator(Of T), defaultItemIndex As Integer, showError As Boolean, rowToValidate As DataRow) As Boolean
            If (defaultItem Is Nothing OrElse defaultItem.Value(defaultItemIndex) Is DBNull.Value) Then
                defaultItem = Me
                defaultItemIndex = defaultItemIndex
            End If
            For i As Integer = 0 To Count - 1
                If (Not rowToValidate Is Nothing AndAlso Not Row(i) Is rowToValidate) Then
                    Continue For
                End If
                Dim itemToCompare As ChainValidator(Of T) = Me
                Dim indexToCompare As Integer = i
                If (Value(i) Is DBNull.Value) Then
                    itemToCompare = defaultItem
                    indexToCompare = defaultItemIndex
                End If
                For Each child As ChainValidator(Of T) In Children
                    Dim storedFilter As String = child.Filter
                    Dim childRowToValidate As DataRow = Nothing
                    Try
                        If AreItemsInTheSameTable(Me, child) Then
                            childRowToValidate = Row(i)
                            child.Filter = Filter
                        Else
                            child.Filter = child.ParentFilter(i)
                        End If
                        If (Not child.ValidateMe(Nothing, showError)) Then
                            m_ErrorMessage = child.ErrorMessage
                            Return False
                        End If
                        If Not Compare(itemToCompare, indexToCompare, child) Then
                            DisplayError(showError)
                            Return False
                        End If

                        If Not child.ValidateChild(itemToCompare, indexToCompare, showError, childRowToValidate) Then
                            m_ErrorMessage = child.ErrorMessage
                            Return False
                        End If
                    Finally
                        child.Filter = storedFilter
                    End Try
                Next
            Next
            Return True
        End Function
        Protected Function AreItemsInTheSameTable(item1 As ChainValidator(Of T), item2 As ChainValidator(Of T)) As Boolean
            Return item1.Owner Is item2.Owner AndAlso item1.TableName = item2.TableName
        End Function
        Protected Function FindNonEmptyParentRowWithMaxDate(childRow As DataRow, ByRef parentItem As ChainValidator(Of T)) As Integer
            If parentItem Is Nothing Then
                Return -1
            End If
            Dim parentRowWithMaxDateIndex As Integer = -1
            Dim parentItemWithMaxDate As ChainValidator(Of T) = Nothing
            If Utils.Str(parentItem.View.RowFilter) <> Utils.Str(parentItem.Filter) Then
                parentItem.View.RowFilter = parentItem.Filter
            End If
            For i As Integer = 0 To parentItem.Count - 1
                Dim parentRow As DataRow = parentItem.Row(i)
                For Each child As ChainValidator(Of T) In parentItem.Children
                    Dim storedFilter As String = child.Filter
                    Try
                        If AreItemsInTheSameTable(parentItem, child) Then
                            child.Filter = parentItem.Filter
                        Else 'we should filter child list by parent key to check only children that are linked with current parent record
                            child.Filter = child.ParentFilter(i)
                        End If
                        For j As Integer = 0 To child.Count - 1
                            If (childRow Is child.Row(j)) Then
                                If (parentItem.Value(i) Is DBNull.Value) Then
                                    Dim parentItem1 As ChainValidator(Of T) = parentItem.Parent
                                    Dim index As Integer = FindNonEmptyParentRowWithMaxDate(parentRow, parentItem1)
                                    If (index >= 0) Then
                                        If (parentRowWithMaxDateIndex < 0) OrElse (Not Compare(DirectCast(parentItem1.Value(index), T), DirectCast(parentItemWithMaxDate.Value(parentRowWithMaxDateIndex), T))) Then
                                            parentRowWithMaxDateIndex = i
                                            parentItemWithMaxDate = parentItem1
                                        End If
                                    End If
                                ElseIf (parentRowWithMaxDateIndex < 0) OrElse (Not Compare(DirectCast(parentItem.Value(i), T), DirectCast(parentItemWithMaxDate.Value(parentRowWithMaxDateIndex), T))) Then
                                    parentRowWithMaxDateIndex = i
                                    parentItemWithMaxDate = parentItem
                                End If
                            End If
                        Next

                    Finally
                        child.Filter = storedFilter
                    End Try
                Next
            Next
            If (parentRowWithMaxDateIndex >= 0) Then
                parentItem = parentItemWithMaxDate
                Return parentRowWithMaxDateIndex
            End If
            Return -1
        End Function
        Private Function ValidateParent(showError As Boolean, rowToValidate As DataRow) As Boolean
            If Parent Is Nothing Then
                Return True
            End If
            Dim parentItem As ChainValidator(Of T) = Parent
            While Not parentItem Is Nothing
                If (Not parentItem.ValidateMe(Nothing, showError)) Then
                    m_ErrorMessage = parentItem.ErrorMessage
                    Return False
                End If
                parentItem = parentItem.Parent
            End While
            parentItem = Parent
            Dim parentRowIndex As Integer = FindNonEmptyParentRowWithMaxDate(rowToValidate, parentItem)
            If (parentRowIndex < 0 OrElse parentItem.Value(parentRowIndex) Is DBNull.Value OrElse rowToValidate(FieldName) Is DBNull.Value) Then
                Return True
            End If
            Dim result As Boolean = Compare(DirectCast(parentItem.Value(parentRowIndex), T), parentItem.Caption, DirectCast(rowToValidate(FieldName), T), Caption, Strict)
            If Not result Then
                DisplayError(showError)
            End If
            Return result
        End Function

        Public Function AddChild(child As ChainValidator(Of T)) As ChainValidator(Of T)
            Children.Add(child)
            child.Parent = Me
            Return child
        End Function
        Public Function Compare(value1 As T, caption1 As String, value2 As T, caption2 As String, aStrict As Boolean) As Boolean
            If (aStrict) Then
                If Not CompareStrict(value1, value2) Then
                    m_ErrorMessage = String.Format(Message(aStrict), caption1, value1, caption2, value2)
                    Return False
                End If
            Else
                If Not Compare(value1, value2) Then
                    m_ErrorMessage = String.Format(Message(aStrict), caption1, value1, caption2, value2)
                    Return False
                End If
            End If
            Return True
        End Function

        Public Function Compare(item1 As ChainValidator(Of T), i As Integer, item2 As ChainValidator(Of T)) As Boolean
            If AreItemsInTheSameTable(item1, item2) Then 'compare values in the same record
                If (item1.Value(i) Is DBNull.Value OrElse item2.Value(i) Is DBNull.Value) Then
                    Return True
                End If
                If Not Compare(DirectCast(item1.Value(i), T), item1.Caption, DirectCast(item2.Value(i), T), item2.Caption, item2.Strict) Then
                    m_ErrorItem1 = item1
                    m_ErrorItem2 = item2
                    Return False
                End If
                Return True
            End If

            For j As Integer = 0 To item2.Count - 1
                If (item1.Value(i) Is DBNull.Value OrElse item2.Value(j) Is DBNull.Value) Then
                    Continue For
                End If
                If Not Compare(DirectCast(item1.Value(i), T), item1.Caption, DirectCast(item2.Value(j), T), item2.Caption, item2.Strict) Then
                    m_ErrorItem1 = item1
                    m_ErrorItem2 = item2
                    Return False
                End If
            Next
            Return True
        End Function

        Protected Overridable Function CompareStrict(x As T, y As T) As Boolean
            Return True
        End Function
        Protected Overridable Function Compare(x As T, y As T) As Boolean
            Return True
        End Function
        Public Overrides Property Active() As Boolean
            Get
                Return MyBase.Active
            End Get
            Set(val As Boolean)
                MyBase.Active = val
                For Each child As ChainValidator(Of T) In Children
                    child.Active = val
                Next
            End Set
        End Property
    End Class
End Namespace