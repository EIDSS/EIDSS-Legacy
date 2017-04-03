' DataEventManager is responsible for handling data change events in correct order.
' Usage:
'   For each form where data change handling is necessary (e.g. field auto-population
'   on ComboBox action) a DataEventManager instance should be created. This can be
'   accomplished by using the following member declaration:
'       Private eventManager As New DataEventManager(Me)
'   When all controls are created, field handlers should be added, like that:
'       eventManager.AttachDataHandler("orderHeader.CustomerID", AddressOf CustomerID_Changed)
'   It's handy to put such stuff into a separate method e.g. InstallFieldHooks(). It's important
'   to call this method after controls are created, as it invokes InstallBindingHelper(), which
'   installs special helper hooks for all form's combo boxes so that values are 'pulled' from them
'   after user selects some value (not when combo loses focus). InstallBindingHelper() performs
'   this action only once.
'
'   When field of a datarow is changed, a field change event is enqueued. If there's already an event
'   enqueued for this field, it's replaced. When application reaches "idle" state (before entering main
'   loop), handlers specified by AttachDataHandler() are called for enqueued events (in example
'   above, that would be CustomerID_Changed method). DataFieldChangeEventArgs passed to event
'   handler has following useful fields: Row, Column and Value (new value for the field).
'
'   While event handler is executed, no new field change events are enqueued. In order to execute
'   other handlers for some changed fields, it's possible to call Cascade():
'       eventManager.Cascade("sometable.somefield", somerow)
'   After that the event will be enqueued and corresponding handler will be executed before application
'   reaches main loop. If row parameter is not specified for Cascade(), 0th row of column's table will
'   be used.
Imports System.Collections.Generic
Imports bv.winclient.Core
Imports bv.common.db
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports bv.common.Enums

Public Class DataFieldChangeEventArgs
    Inherits EventArgs
    ReadOnly m_Row As DataRow
    ReadOnly m_Col As DataColumn
    ReadOnly m_Val As Object
    ReadOnly m_OldVal As Object

    Public Sub New(ByVal aRow As DataRow, ByVal aColumn As DataColumn, ByVal value As Object, ByVal oldValue As Object)
        m_Row = aRow
        m_Col = aColumn
        m_Val = value
        m_OldVal = oldValue
    End Sub

    Public ReadOnly Property Row() As DataRow
        Get
            Return m_row
        End Get
    End Property

    Public ReadOnly Property Column() As DataColumn
        Get
            Return m_col
        End Get
    End Property

    Public ReadOnly Property Value() As Object
        Get
            Return m_val
        End Get
    End Property

    Public ReadOnly Property OldValue() As Object
        Get
            Return m_oldVal
        End Get
    End Property
End Class

Public Delegate Sub DataFieldChangeHandler(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)

Public Class DataEventManager

#Region "Implementation Details"
    ' owner
    Private m_Owner As BaseForm

    Public ReadOnly Property Owner As BaseForm
        Get
            Return m_Owner
        End Get
    End Property

    ' suspend mode
    Private m_IgnoreEvents As Integer = 0

    ' event handler dictionary (column --> handler)
    Private ReadOnly m_EventDict As New Dictionary(Of DataColumn, List(Of DataFieldChangeHandler))

    ' a collection of BindingManagerBases to 'flush' before processing events
    Private ReadOnly m_Managers As New Hashtable

    ' Custom bindings
    Private ReadOnly m_CustomBindings As New Hashtable

    ' rows that need to be passed to viewNode.UpdateRelatedView()
    Private ReadOnly m_Rows As New Hashtable

    ' event 'queue' (order doesn't matter)
    Private ReadOnly m_Queue As New Hashtable

    ' ComboBox helper
    Private m_BindingHelper As BindingHelper


    ' Sync Lock for DataEventManagers
    Private Shared m_SharedSyncLock As New Object

    ' All active DataEventManagers
    Private Shared m_SharedDataEventManagers As New ArrayList

    ' An anti-recursion flag for DoFlush
    Private m_Flushing As Boolean = False

    Private Class DataEvent
        Public Sub New(ByVal e As DataFieldChangeEventArgs, ByVal handlers() As DataFieldChangeHandler)
            m_event = e
            m_handlers = handlers
        End Sub

        ' call event handler
        Public Sub exec()
            For Each handler As DataFieldChangeHandler In m_handlers
                handler(m_event.Column.Table, m_event)
            Next
        End Sub

        ' string representation for the event
        Public Overrides Function ToString() As String
            Dim valueStr As String
            Dim col As DataColumn = m_event.Column
            Dim value As Object = m_event.Value
            If value Is Nothing Then
                valueStr = "<nothing>"
            ElseIf IsDBNull(value) Then
                valueStr = "<dbnull>"
            Else
                Try
                    valueStr = CType(value, String)
                Catch ex As Exception
                    Trace.WriteLine(ex)
                    valueStr = "<nonconvertable>"
                End Try
            End If
            Return String.Format("({0}.{1} <- {2})", col.Table.TableName, col.ColumnName, valueStr)
        End Function

        Public ReadOnly Property Column() As DataColumn
            Get
                Return m_event.Column
            End Get
        End Property

        Private ReadOnly m_Event As DataFieldChangeEventArgs
        Private ReadOnly m_Handlers() As DataFieldChangeHandler
    End Class

    Private Class ValuePair
        Public Sub New(ByVal aNewValue As Object, ByVal aOldValue As Object)
            m_NewValue = aNewValue
            m_OldValue = aOldValue
        End Sub

        Private m_NewValue As Object

        Public ReadOnly Property NewValue() As Object
            Get
                Return m_NewValue
            End Get
        End Property

        Private m_OldValue As Object

        Public ReadOnly Property OldValue() As Object
            Get
                Return m_OldValue
            End Get
        End Property
    End Class

    ' update binding managers -- used to force pulling of ComboBox SelectedValues
    Private Sub UpdateBindingManagers()
        If m_Managers.Count > 0 Then
            Dim k As BindingManagerBase
            Dim bases(m_Managers.Count - 1) As BindingManagerBase
            m_Managers.Keys.CopyTo(bases, 0)
            For Each k In bases
                k.EndCurrentEdit()
            Next
            m_Managers.Clear()
        End If
    End Sub


    Private Sub Idle(ByVal sender As Object, ByVal e As EventArgs)
        DoFlush(False)
    End Sub

    ' handle queued events
    Private Function DoFlush(ByVal aSubmitCurrentEdit As Boolean) As Boolean
        ' extra protection - just in case something calls
        ' DataEventManager.Flush() during UpdateBindingManagers

        If m_Flushing Then
            Return True
        End If
        m_Flushing = True
        p_managers.Clear()
        Try
            ' UpdateBindingManagers() grabs changes from combo boxes,
            ' while Utils.SubmitCurrentEdit() affects all fields.
            ' We don't need to change data set every time user types a letter
            ' in edit field, so Utils.SubmitCurrentEdit() is only called during
            ' explicit DataEventManager.Flush()
            UpdateBindingManagers()
            If aSubmitCurrentEdit Then
                If SubmitCurrentEdit(m_Owner) = False Then Return False
            End If
            m_ignoreEvents += 1
            Dim releaseViewNode As Boolean = False
            If Not m_Owner Is Nothing Then
                m_Owner.BeginUpdate()
                releaseViewNode = True
            End If
            Try
                ' Call event handlers
                ' "While" is necessary because we want to handle 'cascade' events
                While m_Queue.Count > 0
                    Dim de As DataEvent
                    Dim events(m_Queue.Count - 1) As DataEvent
                    m_Queue.Values.CopyTo(events, 0)
                    m_Queue.Clear()
                    For Each de In events
                        de.exec()
                    Next
                End While
            Catch ex As Exception
                ErrorForm.ShowError(ex)
                Return False
            Finally
                If Not m_Owner Is Nothing And releaseViewNode Then
                    m_Owner.EndUpdate()
                End If

                ' Update related views
                'Try
                '    UpdateRelatedViews()
                'Finally
                m_ignoreEvents -= 1
                'End Try
            End Try
        Catch ex As Exception
            ErrorForm.ShowError(ex)
            Return False
        Finally
            p_managers.Clear()
            m_Flushing = False
        End Try
        Return True
    End Function

    Dim m_ChangingQueue As New Dictionary(Of DataColumn, ValuePair)

    Private Sub DataChanging(ByVal Sender As Object, ByVal e As DataColumnChangeEventArgs)
        ' ignore changes if events are suspended, owner has no ViewNode associated or it's ViewNode is updating
        If Not m_Owner Is Nothing Then _
            'e.Row.RowState <> DataRowState.Detached - this condition excluded because cut of event inside new rows in grid
            If _
                m_ignoreEvents = 0 AndAlso Not m_Owner.Loading AndAlso Not e.ProposedValue Is Nothing AndAlso
                Not AreEquals(e.Row(e.Column), e.ProposedValue) Then
                m_ChangingQueue(e.Column) = New ValuePair(e.ProposedValue, e.Row(e.Column))
            End If
        End If
    End Sub

    Public Function AreEquals(ByVal value1 As Object, ByVal value2 As Object) As Boolean
        If IsNumeric(value1) AndAlso IsNumeric(value2) AndAlso value1.GetType().Name <> value2.GetType().Name Then
            Return value1.Equals(Convert.ChangeType(value2, value1.GetType()))
        End If
        Return value1.Equals(value2)
    End Function
    ' data change ocurred
    Private m_HasChanges As Boolean

    Public Property HasChanges As Boolean
        Get
            If m_HasChanges Then
                Return True
            End If
            For Each child As IRelatedObject In m_Owner.Children
                If (TypeOf (child) Is BaseForm) AndAlso CType(child, BaseForm).eventManager.HasChanges Then
                    Return True
                End If
            Next
            Return False
        End Get
        Set(value As Boolean)
            m_HasChanges = value
        End Set
    End Property

    Private Sub DataChange(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        ' ignore changes if events are suspended, owner has no ViewNode associated or it's ViewNode is updating
        If Not m_Owner Is Nothing Then
            If Not m_Owner.Loading AndAlso m_ChangingQueue.ContainsKey(e.Column) AndAlso m_ChangingQueue(e.Column).NewValue.Equals(e.ProposedValue) Then
                Dim oldValue As Object = m_ChangingQueue(e.Column).OldValue
                m_ChangingQueue.Remove(e.Column)
                If _
                    m_IgnoreEvents = 0 AndAlso m_EventDict.ContainsKey(e.Column) _
                    Then 'Not Utils.IsEmpty(m_ChangingQueue(e.Column)) AndAlso 'AndAlso m_ChangingQueue.ContainsKey(e.Column) AndAlso m_ChangingQueue(e.Column).NewValue.Equals(e.ProposedValue)
                    'ViewNode.LoadingDetails AndAlso Not (m_Owner.viewNode Is Nothing OrElse m_Owner.viewNode.IsUpdating) Then
                    Dim handlers As List(Of DataFieldChangeHandler) = m_EventDict(e.Column)
                    If Not handlers Is Nothing AndAlso handlers.Count > 0 Then
                        'For Each handler As DataFieldChangeHandler In handlers
                        ' enque the new event or replace an old one
                        Dim _
                            de As _
                                New DataEvent(New DataFieldChangeEventArgs(e.Row, e.Column, e.ProposedValue, oldValue),
                                              handlers.ToArray())
                        'If m_queue(e.Column) Is Nothing Then
                        '    Utils.Debug("Putting data event to the queue: {0}", de.ToString())
                        'Else
                        '    Utils.Debug("Replacing event on queue: {0}", de.ToString())
                        'End If
                        m_Queue(e.Column) = de

                        'Next
                    End If
                    m_Rows(e.Row) = True
                End If
                If Not HasChanges AndAlso (Not e.ProposedValue.Equals(oldValue)) Then
                    HasChanges = True
                End If
            End If
        End If
    End Sub

    ' get column by name
    Private Function GetColumn(ByVal name As String) As DataColumn
        Dim n() As String = name.Split(CType(".", Char))
        If n.Length <> 2 Then
            Throw New SystemException("Invalid column specification: '" & name & "'")
        End If

        If m_Owner Is Nothing Then
            Throw New SystemException("null m_Owner")
        End If

        Dim ds As DataSet = m_Owner.baseDataSet
        If ds Is Nothing Then
            Throw New SystemException("null dataset")
        End If
        Dim table As DataTable = ds.Tables(n(0))
        If table Is Nothing Then
            Throw New SystemException("no such table: '" & n(0) & "'")
        End If
        Dim col As DataColumn = table.Columns(n(1))
        If col Is Nothing Then
            Throw New SystemException("no such column '" & n(1) & "' in table '" & n(0) & "'")
        End If
        Return col
    End Function

    ' force updating binding manager when application is idle
    Public Sub NeedBindingManagerUpdate(ByVal manager As BindingManagerBase)
        If Not manager Is Nothing Then
            m_Managers(manager) = True
        End If
    End Sub

    ' install Binding helper
    Public Sub InstallBindingHelper(Optional ByVal parent As Control = Nothing)
        If Not m_Owner Is Nothing Then
            If m_BindingHelper Is Nothing Then
                m_BindingHelper = New BindingHelper(Me)
            End If
            If parent Is Nothing Then parent = CType(m_Owner, Control)
            m_BindingHelper.Attach(parent)
        End If
    End Sub

    ' install our event handler for column changes in form's dataset
    Private Shared Sub AddDataChangingHandler(ByVal dt As DataTable, ByVal handler As DataColumnChangeEventHandler)
        Try
            RemoveHandler dt.ColumnChanging, handler
        Catch ex As Exception
        End Try
        AddHandler dt.ColumnChanging, handler
    End Sub

    Private Shared Sub AddDataChangedHandler(ByVal dt As DataTable, ByVal handler As DataColumnChangeEventHandler)
        Try
            RemoveHandler dt.ColumnChanged, handler
        Catch ex As Exception
        End Try
        AddHandler dt.ColumnChanged, handler
    End Sub
    Private Shared Sub AddRowDeleteHandler(ByVal dt As DataTable, ByVal handler As DataRowChangeEventHandler)
        Try
            RemoveHandler dt.RowDeleted, handler
        Catch ex As Exception
        End Try
        AddHandler dt.RowDeleted, handler
    End Sub

    Private Sub AddDataChangeHandler()
    End Sub

    Public Sub InstallColumnHandler()
        Dim dt As DataTable
        If Not m_Owner Is Nothing Then
            For Each dt In m_Owner.baseDataSet.Tables
                AddDataChangingHandler(dt, AddressOf DataChanging)
                AddDataChangedHandler(dt, AddressOf DataChange)
                AddRowDeleteHandler(dt, AddressOf RowDelete)
            Next
        End If
    End Sub

    Private Sub RowDelete(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        HasChanges = True
    End Sub

    Shared p_managers As New Hashtable

    Public Shared Function SubmitCurrentEdit(ByVal parent As Control) As Boolean
        Dim de As DictionaryEntry
        Dim ret As Boolean = True
        Try
            If parent Is Nothing Then Return True
            If TypeOf (parent) Is GridControl Then
                CType(parent, GridControl).MainView.PostEditor()
                Return True
            End If

            If TypeOf (parent) Is BaseEdit AndAlso parent.Visible Then
                For Each bind As Binding In parent.DataBindings
                    If Not bind.PropertyName Is Nothing AndAlso bind.PropertyName = "EditValue" _
                       AndAlso Not bind.BindingMemberInfo.BindingField Is Nothing _
                       AndAlso Not bind.BindingManagerBase Is Nothing _
                       AndAlso bind.BindingManagerBase.Position >= 0 Then
                        Dim row As DataRow = Nothing
                        If TypeOf (bind.BindingManagerBase.Current) Is DataRow Then
                            row = CType(bind.BindingManagerBase.Current, DataRow)
                        ElseIf TypeOf (bind.BindingManagerBase.Current) Is DataRowView Then
                            row = CType(bind.BindingManagerBase.Current, DataRowView).Row
                        End If
                        If Not row Is Nothing Then
                            Dim val As Object
                            Try
                                If CType(parent, BaseEdit).EditValue Is Nothing Then
                                    val = DBNull.Value
                                Else
                                    val = CType(parent, BaseEdit).EditValue
                                End If
                                If Not row(bind.BindingMemberInfo.BindingField).Equals(val) Then
                                    Try
                                        Dim newVal As Object = Convert.ChangeType(val,
                                                                                  row.Table.Columns(
                                                                                      bind.BindingMemberInfo.
                                                                                                       BindingField).
                                                                                     DataType)
                                        If Not row(bind.BindingMemberInfo.BindingField).Equals(newVal) Then
                                            row(bind.BindingMemberInfo.BindingField) = newVal
                                        End If
                                    Catch ex As Exception
                                        row(bind.BindingMemberInfo.BindingField) = val
                                    End Try
                                End If
                            Catch ex As Exception
                                Trace.WriteLine("dxControls flush failed:", ex)
                            End Try
                        End If
                        If bind.BindingManagerBase.Position >= 0 Then
                            bind.BindingManagerBase.EndCurrentEdit()
                        End If
                    End If
                Next
                Return True
            End If

            If parent.BindingContext Is Nothing Then Return True
            Try 'this try block is needed to catch possible binding context collection change
                'during the opertion inside this circle
                'this is not a good solution
                For Each de In parent.BindingContext
                    Dim we As WeakReference
                    we = CType(de.Value, WeakReference)
                    If we.IsAlive Then
                        Dim bmanager As BindingManagerBase = CType(we.Target, BindingManagerBase)
                        If _
                            Not bmanager Is Nothing AndAlso bmanager.Count > 0 AndAlso bmanager.Position >= 0 AndAlso
                            p_managers.ContainsKey(bmanager) = False Then
                            Try
                                If _
                                    TypeOf bmanager.Current Is DataRowView AndAlso
                                    Not CType(bmanager.Current, DataRowView).Row Is Nothing _
                                    AndAlso CType(bmanager.Current, DataRowView).Row.RowState <> DataRowState.Detached _
                                    Then
                                    bmanager.EndCurrentEdit()
                                End If
                                p_managers(bmanager) = True
                            Catch ex As ArgumentException
                                ErrorForm.ShowError(StandardError.DataValidationError, ex)
                                ret = False
                            Catch ex As Exception
                                ErrorForm.ShowError(StandardError.UnprocessedError, ex)
                                ret = False
                            End Try
                        End If
                    End If

                Next
            Catch ex As Exception
                Trace.WriteLine(Trace.Kind.Warning, "SubmitCurrentEdit fault for cotrol {0}{1}", parent.GetType().Name,
                                parent.Name)
            End Try
            For Each c As Control In parent.Controls
                If SubmitCurrentEdit(c) = False Then Return False
            Next

        Catch ex As Exception
            Throw New ApplicationException("SubmitCurrentEdit fault", ex)
        End Try

        Return ret
    End Function


    ' install our event handler for column changes in form's dataset
    'Public Sub InstallGridResizer(Optional ByVal ParentControl As Control = Nothing)
    '    If ParentControl Is Nothing Then
    '        ParentControl = CType(m_Owner, Control)
    '    End If
    '    For Each c As Control In ParentControl.Controls
    '        If TypeOf (c) Is DataGrid Then
    '            Dim m_ColumnResizer As New GridColumnResizer(c)
    '        ElseIf TypeOf (c) Is Panel Then
    '            InstallGridResizer(c)
    '        End If
    '    Next
    'End Sub


#End Region

#Region "Public API"
    ' constructor -- attach own handler to Application.Idle event, called by ViewNode
    Public Sub New(ByVal owner As BaseForm)
        m_Owner = owner
        SyncLock m_SharedSyncLock
            m_SharedDataEventManagers.Add(New WeakReference(Me))
        End SyncLock

        AddHandler Application.Idle, AddressOf Idle
    End Sub

    Public Sub ClearAllReferences()

        m_EventDict.Clear()
        m_Managers.Clear()
        m_CustomBindings.Clear()
        m_Rows.Clear()
        m_Queue.Clear()

        RemoveHandler Application.Idle, AddressOf Idle

        ''''' todo:[ivan] ask about danger if we delete manager from list
        Dim toDelete As WeakReference = Nothing
        Dim ref As WeakReference
        SyncLock m_SharedSyncLock
            For Each ref In m_SharedDataEventManagers
                Dim target As DataEventManager = CType(ref.Target, DataEventManager)
                If ReferenceEquals(target, Me) Then
                    toDelete = ref
                End If
            Next
            If Not toDelete Is Nothing Then
                m_SharedDataEventManagers.Remove(toDelete)
            End If
        End SyncLock

        '''''''''''
        m_Owner = Nothing
    End Sub


    ' wire the form
    Public Sub WireForm(Optional ByVal parent As Control = Nothing)
        InstallBindingHelper(parent)
        InstallColumnHandler()
        'InstallGridResizer()
    End Sub

    Public Function Clear(Optional ByVal parent As Control = Nothing) As Boolean
        'Dim de As DictionaryEntry
        '        Dim ret As Boolean = True
        '        Dim we As WeakReference = Nothing
        '        Dim bmanager As BindingManagerBase = Nothing

        If m_Owner Is Nothing Then
            Return True
        End If

        If parent Is Nothing Then parent = m_Owner

        For Each ctl As Control In parent.Controls
            ctl.DataBindings.Clear()
            If TypeOf (parent) Is PopupContainerEdit AndAlso parent.Visible Then
                Dim child As PopupContainerControl = CType(parent, PopupContainerEdit).Properties.PopupControl
                If (Not (child Is Nothing)) Then
                    Clear(child)
                End If

            Else
                Clear(ctl)
            End If
        Next

        Return True
        'If parent.BindingContext Is Nothing Then Return True
        'For Each de In parent.BindingContext
        '    we = CType(de.Value, WeakReference)
        '    If we.IsAlive Then
        '        bmanager = CType(we.Target, BindingManagerBase)
        '        If (Not bmanager Is Nothing) AndAlso (bmanager.Position >= 0) AndAlso (p_managers.ContainsKey(bmanager) = False) Then
        '            Try
        '                While bmanager.Count > 0
        '                    bmanager.RemoveAt(0)
        '                End While
        '                p_managers(bmanager) = True
        '            Catch ex As Exception
        '                If (Not ex.InnerException Is Nothing) Then
        '                    ErrorForm.ShowError(StandardError.UnprocessedError, ex)
        '                End If
        '                ret = False
        '            End Try
        '        End If
        '    End If
        'Next
        'If TypeOf (parent) Is BaseForm Then
        '    For i As Integer = 0 To CType(parent, BaseForm).DockPanelsCount - 1
        '        For Each c As Control In CType(parent, BaseForm).DockPanel(i).Controls
        '            If Clear(c) = False Then Return False
        '        Next
        '    Next
        'End If
        'For Each c As Control In parent.Controls
        '    If Clear(c) = False Then Return False
        'Next
        'Return ret
    End Function
    ' remove event handler
    Public Sub RemoveDataHandler(ByVal colSpec As String, Optional ByVal handler As DataFieldChangeHandler = Nothing)
        Dim col As DataColumn = GetColumn(colSpec)
        If m_EventDict.ContainsKey(col) Then
            If handler Is Nothing Then
                m_EventDict.Remove(col)
            ElseIf m_EventDict(col).Contains(handler) Then
                m_EventDict(col).Remove(handler)
            End If
        End If
    End Sub

    ' attach event handler
    Public Sub AttachDataHandler(ByVal colSpec As String, ByVal handler As DataFieldChangeHandler)
        Dim col As DataColumn = GetColumn(colSpec)
        WireForm()
        'RemoveDataHandler(colSpec)
        If (Not m_EventDict.ContainsKey(col)) Then
            m_EventDict(col) = New List(Of DataFieldChangeHandler)()
        End If
        If (Not m_EventDict(col).Contains(handler)) Then
            m_EventDict(col).Add(handler)
        End If
        'AddHandler col.Table.ColumnChanged, AddressOf DataChange
    End Sub

    ' event cascading
    Public Sub Cascade(ByVal colSpec As String, Optional ByVal row As DataRow = Nothing)
        If Not BaseSettings.ScanFormsMode Then
            Dim col As DataColumn = GetColumn(colSpec)
            If Not m_EventDict.ContainsKey(col) Then
                Return
            End If
            Dim handlers As List(Of DataFieldChangeHandler) = m_EventDict(col)
            If Not handlers Is Nothing Then
                For Each handler As DataFieldChangeHandler In handlers
                    If row Is Nothing AndAlso col.Table.Rows.Count > 0 Then
                        row = col.Table.Rows(0)
                    End If
                    'Utils.Debug("Enqueueing cascaded event for {0}.{1}", col.Table.TableName, col.ColumnName) ''''
                    If Not row Is Nothing Then
                        handler(col.Table, New DataFieldChangeEventArgs(row, col, row(col), row(col)))
                    Else
                        handler(col.Table, New DataFieldChangeEventArgs(Nothing, col, DBNull.Value, DBNull.Value))
                    End If
                Next
            End If
        End If
    End Sub

    ' use custom handler for control's bindings' parse/format events
    Public Sub CustomBinding(ByVal control As Control)
        Dim binding As Binding
        For Each binding In control.DataBindings
            CustomBinding(binding)
        Next
    End Sub

    ' use custom handler for binding's parse/format events
    Public Sub CustomBinding(ByVal binding As Binding)
        m_CustomBindings(binding) = True
    End Sub

    ' check whether a binding has custom parse/format handlers
    Public Function IsCustomBinding(ByVal binding As Binding) As Boolean
        Return Not m_CustomBindings(binding) Is Nothing
    End Function

    ' call to recalc the form before reaching main app loop
    'Public Sub NeedRecalc()
    '    m_needRecalc = True
    'End Sub

    ' flush all active DataEventManagers
    Public Shared Function Flush() As Boolean
        ' references to nonexistent DataEventManagers will be removed
        Dim managers As ArrayList = m_SharedDataEventManagers
        m_SharedDataEventManagers = New ArrayList
        Dim ref As WeakReference
        For Each ref In managers
            Dim target As DataEventManager = CType(ref.Target, DataEventManager)
            If Not target Is Nothing Then
                target.DoFlush(True) ' values from all fields will be grabbed
                SyncLock m_SharedSyncLock
                    m_SharedDataEventManagers.Add(ref)
                End SyncLock
            End If
        Next
    End Function

#End Region
End Class
