Imports System.ComponentModel

Public Class SortProxy
    Implements IBindingList
    Implements ITypedList

    Private m_target As IBindingList = Nothing

    Private Sub TargetListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
        If Me.MyTarget Is Nothing OrElse MyTarget.Count = 0 Then
            Return
        End If
        RaiseEvent ListChanged(Me, e)
    End Sub

    Public Event SortCommand(ByVal sortBy As String, ByVal ascending As Boolean)
    Public Event AfterSort(ByVal sender As Object, ByVal e As EventArgs)

    Public Property Target() As IBindingList
        Get
            Return m_target
        End Get
        Set(ByVal Value As IBindingList)
            If m_target Is Value Then
                Return
            End If
            If Not m_target Is Nothing Then
                RemoveHandler m_target.ListChanged, AddressOf TargetListChanged
            End If
            m_target = Value
            If Not m_target Is Nothing Then
                AddHandler m_target.ListChanged, AddressOf TargetListChanged
                RaiseEvent ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
            End If
        End Set
    End Property

    Private ReadOnly Property MyTarget() As IBindingList
        Get
            If m_target Is Nothing Then
                Throw New SystemException("target not defined")
            End If
            Return m_target
        End Get
    End Property
#Region " IList Interface implementation"

    Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
        MyTarget.CopyTo(array, index)
    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            If Not m_target Is Nothing Then
                Return m_target.Count
            Else
                Return -1
            End If
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return MyTarget.IsSynchronized
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return MyTarget.SyncRoot
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        If IsSorted Then
            Return MyTarget.GetEnumerator
        End If
        Return Nothing
    End Function

    Public Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
        Return MyTarget.Add(value)
    End Function

    Public Sub Clear() Implements System.Collections.IList.Clear
        MyTarget.Clear()
    End Sub

    Public Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
        Return MyTarget.Contains(value)
    End Function

    Public Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
        Return MyTarget.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
        MyTarget.Insert(index, value)
    End Sub

    Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
        Get
            Return MyTarget.IsFixedSize
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
        Get
            Return MyTarget.IsReadOnly
        End Get
    End Property

    Default Public Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
        Get
            Return MyTarget.Item(index)
        End Get
        Set(ByVal Value As Object)
            MyTarget(index) = Value
        End Set
    End Property

    Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
        MyTarget.Remove(value)
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
        MyTarget.RemoveAt(index)
    End Sub

#End Region

#Region " Rest of IBindingList Interface Implementation"

    Public Sub AddIndex(ByVal [property] As System.ComponentModel.PropertyDescriptor) Implements System.ComponentModel.IBindingList.AddIndex
        MyTarget.AddIndex([property])
    End Sub

    Public Function AddNew() As Object Implements System.ComponentModel.IBindingList.AddNew
        Return MyTarget.AddNew()
    End Function

    Public ReadOnly Property AllowEdit() As Boolean Implements System.ComponentModel.IBindingList.AllowEdit
        Get
            Return MyTarget.AllowEdit()
        End Get
    End Property

    Public ReadOnly Property AllowNew() As Boolean Implements System.ComponentModel.IBindingList.AllowNew
        Get
            Return MyTarget.AllowNew
        End Get
    End Property

    Public ReadOnly Property AllowRemove() As Boolean Implements System.ComponentModel.IBindingList.AllowRemove
        Get
            Return MyTarget.AllowRemove
        End Get
    End Property
    Dim m_Sorting As Boolean = False
    Public Sub ApplySort(ByVal [property] As System.ComponentModel.PropertyDescriptor, ByVal direction As System.ComponentModel.ListSortDirection) Implements System.ComponentModel.IBindingList.ApplySort
        If m_Sorting Then Exit Sub
        m_Sorting = True
        Try
            Dim ascending As Boolean = True
            If direction = ListSortDirection.Descending Then
                ascending = False
            End If
            RaiseEvent SortCommand([property].Name, ascending)
            MyTarget.ApplySort([property], direction)
            RaiseEvent AfterSort(Nothing, EventArgs.Empty)
        Finally
            m_Sorting = False
        End Try

    End Sub

    Public Function Find(ByVal [property] As System.ComponentModel.PropertyDescriptor, ByVal key As Object) As Integer Implements System.ComponentModel.IBindingList.Find
        MyTarget.Find([property], key)
    End Function

    Public ReadOnly Property IsSorted() As Boolean Implements System.ComponentModel.IBindingList.IsSorted
        Get
            Return MyTarget.IsSorted
        End Get
    End Property

    Public Event ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Implements System.ComponentModel.IBindingList.ListChanged
    Public Sub RemoveIndex(ByVal [property] As System.ComponentModel.PropertyDescriptor) Implements System.ComponentModel.IBindingList.RemoveIndex
        MyTarget.RemoveIndex([property])
    End Sub

    Public Sub RemoveSort() Implements System.ComponentModel.IBindingList.RemoveSort
        MyTarget.RemoveSort()
    End Sub

    Public ReadOnly Property SortDirection() As System.ComponentModel.ListSortDirection Implements System.ComponentModel.IBindingList.SortDirection
        Get
            Return MyTarget.SortDirection
        End Get
    End Property

    Public ReadOnly Property SortProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.IBindingList.SortProperty
        Get
            Return MyTarget.SortProperty
        End Get
    End Property

    Public ReadOnly Property SupportsChangeNotification() As Boolean Implements System.ComponentModel.IBindingList.SupportsChangeNotification
        Get
            If m_target Is Nothing Then
                Return False
            End If
            Return MyTarget.SupportsChangeNotification
        End Get
    End Property

    Public ReadOnly Property SupportsSearching() As Boolean Implements System.ComponentModel.IBindingList.SupportsSearching
        Get
            Return MyTarget.SupportsSearching
        End Get
    End Property

    Public ReadOnly Property SupportsSorting() As Boolean Implements System.ComponentModel.IBindingList.SupportsSorting
        Get
            Return MyTarget.SupportsSorting
        End Get
    End Property
#End Region

#Region " ITypedList Interface Implementation "
    Public Function GetItemProperties(ByVal listAccessors() As System.ComponentModel.PropertyDescriptor) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ITypedList.GetItemProperties
        Return CType(MyTarget, ITypedList).GetItemProperties(listAccessors)
    End Function

    Public Function GetListName(ByVal listAccessors() As System.ComponentModel.PropertyDescriptor) As String Implements System.ComponentModel.ITypedList.GetListName
        Return CType(MyTarget, ITypedList).GetListName(listAccessors)
    End Function
#End Region

End Class
