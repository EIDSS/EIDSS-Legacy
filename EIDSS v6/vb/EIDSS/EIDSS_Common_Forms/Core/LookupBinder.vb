Imports System.ComponentModel
Imports bv.model.Model.Core
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports bv.common.Configuration
Imports System.Drawing
Imports eidss.model.Core
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList
Imports eidss.model.Enums
Imports System.Text.RegularExpressions
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections.Generic
Imports bv.winclient.Localization
Imports eidss.model.Resources
Imports System.Linq
Imports bv.common.Resources
Imports DevExpress.XtraGrid
Imports bv.winclient.Layout
Imports System.Reflection
Imports DevExpress.Utils
Imports System.Text
Imports EIDSS.My.Resources

Namespace Core
    Public Class LookupBinder
        Public Delegate Sub SetFilterDelegate(sender As Object, defaultFilter As String)

        Public Const IgnoreClear As String = "IgnoreClear"

#Region "Private methods"

        Private Shared Sub AddButtonClickHandler(ByVal cb As ButtonEdit, ByVal handler As ButtonPressedEventHandler)
            If handler.Method.Name = "AddBaseReference" Then
                If _
                    Not _
                    EidssUserContext.User.HasPermission(
                        PermissionHelper.InsertPermission(EIDSSPermissionObject.Reference)) Then
                    cb.HidePlusButton()
                    Return
                End If
            End If
            Try
                RemoveHandler cb.ButtonClick, handler
            Finally
                AddHandler cb.ButtonClick, handler

            End Try
        End Sub

        Private Shared Sub AddButtonClickHandler(ByVal cb As RepositoryItemButtonEdit,
                                                 ByVal handler As ButtonPressedEventHandler)
            If handler.Method.Name = "AddBaseReference" Then
                If _
                    Not _
                    EidssUserContext.User.HasPermission(
                        PermissionHelper.InsertPermission(EIDSSPermissionObject.Reference)) Then
                    cb.HidePlusButton()
                    Return
                End If
            End If
            Try
                RemoveHandler cb.ButtonClick, handler
            Finally
                AddHandler cb.ButtonClick, handler
            End Try
        End Sub

        Private Shared Sub AddKeyDownHandler(ByVal cb As Control, ByVal handler As KeyEventHandler)
            Try
                RemoveHandler cb.KeyDown, handler
            Finally
                AddHandler cb.KeyDown, handler
            End Try
        End Sub

        Private Shared Sub AddKeyDownHandler(ByVal cb As RepositoryItemButtonEdit, ByVal handler As KeyEventHandler)
            Try
                RemoveHandler cb.KeyDown, handler
            Finally
                AddHandler cb.KeyDown, handler
            End Try
        End Sub

        Private Shared Sub AddPlusButton(ByVal cb As ButtonEdit, Optional tooltip As String = Nothing)
            Dim btn As EditorButton
            For Each btn In cb.Properties.Buttons
                If btn.Kind = ButtonPredefines.Plus Then
                    Return
                End If
            Next
            btn = New EditorButton(ButtonPredefines.Plus)
            If (tooltip Is Nothing) Then
                tooltip = EidssMessages.Get("msgAddReference")
            End If
            btn.ToolTip = tooltip
            cb.Properties.Buttons.Add(btn)
        End Sub

        Private Shared Sub AddEditButton(ByVal cb As ButtonEdit)
            Dim btn As EditorButton
            If _
                cb.Properties.Buttons.Cast (Of EditorButton)().Any(
                    Function(button) button.Kind = ButtonPredefines.Ellipsis) Then
                Return
            End If
            btn = New EditorButton(ButtonPredefines.Ellipsis)
            cb.Properties.Buttons.Add(btn)
        End Sub

        Private Shared Sub AddPlusButton(ByVal cb As RepositoryItemButtonEdit, Optional tooltip As String = Nothing)
            Dim btn As EditorButton
            For Each btn In cb.Buttons
                If btn.Kind = ButtonPredefines.Plus Then
                    Return
                End If
            Next
            btn = New EditorButton(ButtonPredefines.Plus)
            If (tooltip Is Nothing) Then
                tooltip = EidssMessages.Get("msgAddReference")
            End If
            btn.ToolTip = tooltip
            cb.Buttons.Add(New EditorButton(ButtonPredefines.Plus))
        End Sub

        Public Shared Sub AddClearButton(ByVal cb As ButtonEdit, Optional ByVal ForceAddClearButton As Boolean = False)
            Return
            AddKeyDownHandler(cb, AddressOf KeyDown)
            WinUtils.SetClearTooltip(cb)
            If Not ForceAddClearButton AndAlso BaseSettings.ShowClearLookupButton = False Then
                Return
            End If
            For Each btn As EditorButton In cb.Properties.Buttons
                If btn.Kind = ButtonPredefines.Delete Then
                    Return
                End If
            Next
            cb.Properties.Buttons.Add(New EditorButton(ButtonPredefines.Delete,
                                                       BvMessages.Get("btnClear", "Clear the field contents")))
            AddButtonClickHandler(cb, AddressOf ClearLookup)
        End Sub

        Public Shared Sub AddClearButton(ByVal cb As RepositoryItemButtonEdit,
                                         Optional ByVal ForceAddClearButton As Boolean = False)
            Return
            AddKeyDownHandler(cb, AddressOf KeyDown)
            If Not ForceAddClearButton AndAlso BaseSettings.ShowClearRepositoryLookupButton = False Then
                Return
            End If
            For Each btn As EditorButton In cb.Buttons
                If btn.Kind = ButtonPredefines.Delete Then
                    Return
                End If
            Next
            cb.Buttons.Add(New EditorButton(ButtonPredefines.Delete,
                                            BvMessages.Get("btnClear", "Clear the field contents")))
            AddButtonClickHandler(cb, AddressOf ClearLookup)
        End Sub

        Public Shared Sub AddClearButton(ByVal cb As PopupContainerEdit,
                                         Optional ByVal ForceAddClearButton As Boolean = False)
            Return
            AddKeyDownHandler(cb, AddressOf KeyDown)
            If Not ForceAddClearButton AndAlso BaseSettings.ShowClearRepositoryLookupButton = False Then
                Return
            End If
            For Each btn As EditorButton In cb.Properties.Buttons
                If btn.Kind = ButtonPredefines.Delete Then
                    Return
                End If
            Next
            cb.Properties.Buttons.Add(New EditorButton(ButtonPredefines.Delete,
                                                       BvMessages.Get("btnClear", "Clear the field contents")))
            AddButtonClickHandler(cb, AddressOf ClearLookup)
        End Sub

        Public Shared Sub SetDataSource(ByVal cb As LookUpEditBase, ByVal dv As DataView, ByVal displayMember As String,
                                        ByVal valueMember As String)
            cb.Properties.DataSource = Nothing
            cb.Properties.DataSource = dv
            cb.Properties.DisplayMember = displayMember
            cb.Properties.ValueMember = valueMember
            cb.Properties.NullText = ""
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Properties.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub

        Public Shared Sub SetDataSource(ByVal cb As GridLookUpEdit, ByVal dv As DataView, ByVal displayMember As String,
                                        ByVal valueMember As String)
            cb.Properties.DataSource = Nothing
            cb.Properties.DataSource = dv
            cb.Properties.DisplayMember = displayMember
            cb.Properties.ValueMember = valueMember
            cb.Properties.NullText = ""
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Properties.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub

        Public Shared Sub SetDataSource(ByVal cb As RepositoryItemLookUpEdit, ByVal dv As DataView,
                                        ByVal displayMember As String, ByVal valueMember As String,
                                        setDefaultFilterHandler As EventHandler,
                                        clearDefaultFilterHandler As EventHandler)
            cb.DataSource = dv
            cb.DisplayMember = displayMember
            cb.ValueMember = valueMember
            cb.NullText = ""
            AddLookupClosedHandler(cb)
            AddEnterEventHandler(cb, setDefaultFilterHandler)
            AddLeaveEventHandler(cb, clearDefaultFilterHandler)
            'AddSetDefaultFilterHandler(cb, queryPopupHandler)
            'AddClearDefaultFilterHandler(cb, closePopupHandler)
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub

        Private Shared Sub SetDataSource(ByVal cb As TreeListLookUpEdit, ByVal dv As DataView,
                                         ByVal displayMember As String, ByVal valueMember As String,
                                         ByVal parentKeyField As String)
            cb.Properties.DataSource = dv
            cb.Properties.DisplayMember = displayMember
            cb.Properties.ValueMember = valueMember
            cb.Properties.TreeList.ParentFieldName = parentKeyField
            cb.Properties.TreeList.KeyFieldName = valueMember
            cb.Properties.NullText = ""
            RemoveHandler cb.Properties.TreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler cb.Properties.TreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            'AddEnterEventHandler(cb, setDefaultFilterHandler)
            'AddLeaveEventHandler(cb, clearDefaultFilterHandler)
            'AddSetDefaultFilterHandler(cb, queryPopupHandler)
            'AddClearDefaultFilterHandler(cb, closePopupHandler)
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Properties.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub

        Public Shared Sub SetDataSource(ByVal cb As RepositoryItemTreeListLookUpEdit, ByVal dv As DataView,
                                        ByVal displayMember As String, ByVal valueMember As String,
                                        ByVal parentKeyField As String)
            cb.DataSource = dv
            cb.DisplayMember = displayMember
            cb.ValueMember = valueMember
            cb.TreeList.ParentFieldName = parentKeyField
            cb.TreeList.KeyFieldName = valueMember
            cb.NullText = ""
            RemoveHandler cb.TreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler cb.TreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddLookupClosedHandler(cb)
            'AddEnterEventHandler(cb, setDefaultFilterHandler)
            'AddLeaveEventHandler(cb, clearDefaultFilterHandler)
            'AddSetDefaultFilterHandler(cb, queryPopupHandler)
            'AddClearDefaultFilterHandler(cb, closePopupHandler)
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub


        Public Shared Sub SetDataSource(ByVal cb As TreeList, ByVal dv As DataView, ByVal valueMember As String,
                                        ByVal parentMember As String, ByVal value As Object)
            cb.DataSource = Nothing
            cb.DataSource = dv
            cb.RootValue = 0
            cb.KeyFieldName = valueMember
            cb.ParentFieldName = parentMember
            LookUpSetFilter(cb.DataSource, valueMember, value)
        End Sub

        Public Shared Sub AddEnterEventHandler(ByVal cb As RepositoryItemLookUpEditBase, handler As EventHandler)
            If handler Is Nothing Then Return
            Dim popupHandler As CancelEventHandler = Sub(sender, e)
                handler(sender, New EventArgs())
                    End Sub
            Try
                RemoveHandler cb.Enter, handler
                If (TagHelper.IsTagHelper(cb.Tag)) AndAlso Not CType(cb.Tag, TagHelper).QueryPopupHandler Is Nothing _
                    Then
                    cb.Tag = New TagHelper().Init(cb.Tag)
                    RemoveHandler cb.QueryPopUp, CType(cb.Tag, TagHelper).QueryPopupHandler
                End If
            Finally
                AddHandler cb.Enter, handler
                AddHandler cb.QueryPopUp, popupHandler
                If (Not TagHelper.IsTagHelper(cb.Tag)) Then
                    cb.Tag = New TagHelper().Init(cb.Tag)
                End If
                CType(cb.Tag, TagHelper).QueryPopupHandler = popupHandler
            End Try
        End Sub

        Public Shared Sub AddLeaveEventHandler(ByVal cb As RepositoryItemLookUpEditBase, handler As EventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.Leave, handler
            Finally
                AddHandler cb.Leave, handler
            End Try
        End Sub
        'Public Shared Sub AddSetDefaultFilterHandler(ByVal cb As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEditBase, handler As CancelEventHandler)
        '    If handler Is Nothing Then Return
        '    Try
        '        RemoveHandler cb.QueryPopUp, handler
        '    Finally
        '        AddHandler cb.QueryPopUp, handler
        '    End Try
        'End Sub
        'Public Shared Sub AddClearDefaultFilterHandler(ByVal cb As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEditBase, handler As CancelEventHandler)
        '    If handler Is Nothing Then Return
        '    Try
        '        RemoveHandler cb.QueryCloseUp, handler
        '    Finally
        '        AddHandler cb.QueryCloseUp, handler
        '    End Try
        'End Sub
        Public Shared Sub AddChangingHandler(ByVal cb As BaseEdit, handler As ChangingEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.EditValueChanging, handler
            Finally
                AddHandler cb.EditValueChanging, handler
            End Try
        End Sub

        Public Shared Sub AddChangingHandler(ByVal cb As RepositoryItem, handler As ChangingEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.EditValueChanging, handler
            Finally
                AddHandler cb.EditValueChanging, handler
            End Try
        End Sub

        Public Shared Sub OnClear(sender As Object, e As ChangingEventArgs)
            Dim ctl As Control = CType(sender, Control)
            If IgnoreClear.Equals(ctl.Tag) Then
                Return
            End If
            If _
                e.NewValue Is DBNull.Value OrElse
                (TypeOf (e.NewValue) Is Long AndAlso CType(e.NewValue, Long) = LookupCache.EmptyLineKey) Then
                If _
                    Not e.OldValue Is DBNull.Value AndAlso TypeOf (e.OldValue) Is Long AndAlso
                    Not CType(e.OldValue, Long) = LookupCache.EmptyLineKey Then
                    If Not WinUtils.ConfirmLookupClear() Then
                        e.Cancel = True
                        Return
                    End If
                End If
                If Not e.NewValue Is DBNull.Value Then
                    e.NewValue = DBNull.Value
                End If
            End If
        End Sub


        Public Shared Sub RemoveDefaultFilterHandlers(ByVal cb As RepositoryItemLookUpEditBase)
            Try
                RemoveHandler cb.Enter, AddressOf SetDefaultFilter
                If (TagHelper.IsTagHelper(cb.Tag)) AndAlso Not CType(cb.Tag, TagHelper).QueryPopupHandler Is Nothing _
                    Then
                    RemoveHandler cb.QueryPopUp, CType(cb.Tag, TagHelper).QueryPopupHandler
                End If
            Finally
            End Try
            Try
                RemoveHandler cb.Leave, AddressOf ClearDefaultFilter
            Finally
            End Try
        End Sub

        Public Shared Sub AddLookupClosedHandler(ByVal cb As RepositoryItemLookUpEditBase)
            Try
                RemoveHandler cb.Closed, AddressOf RelositoryItemLookupEdit_Closed
            Finally
                AddHandler cb.Closed, AddressOf RelositoryItemLookupEdit_Closed
            End Try
        End Sub

        Public Shared Sub RelositoryItemLookupEdit_Closed(ByVal sender As Object, ByVal e As ClosedEventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            If TypeOf (cb.Parent) Is GridControl Then _
                ' AndAlso CType(CType(cb.Parent, GridControl).FocusedView, ColumnView).FocusedRowHandle <> GridControl.NewItemRowHandle Then
                'CType(cb.Parent, GridControl).FocusedView.CloseEditor()
                CType(cb.Parent, GridControl).FocusedView.PostEditor()
            ElseIf TypeOf (cb.Parent) Is TreeList Then
                CType(cb.Parent, TreeList).CloseEditor()
                CType(cb.Parent, TreeList).EndCurrentEdit()
            End If
        End Sub

        Private Shared Sub SetDataSource(ByVal imlbc As ImageListBoxControl, ByVal dv As DataView,
                                         ByVal displayMember As String, ByVal valueMember As String,
                                         ByVal imageDisplayMember As String)
            imlbc.DataSource = Nothing
            imlbc.DataSource = dv
            imlbc.DisplayMember = displayMember
            imlbc.ValueMember = valueMember
            imlbc.ImageIndexMember = imageDisplayMember
        End Sub

        Private Shared Sub SetDataSource(ByVal lbc As ListBoxControl, ByVal dv As DataView,
                                         ByVal displayMember As String, ByVal valueMember As String)
            lbc.DataSource = Nothing
            lbc.DataSource = dv
            lbc.DisplayMember = displayMember
            lbc.ValueMember = valueMember
        End Sub

        Public Shared Sub AddBinding(ByVal cb As LookUpEditBase, ByVal ds As Object, ByVal bindField As String,
                                     Optional ByVal showClearButton As Boolean = True,
                                     Optional defaultFilter As String = Nothing)
            cb.DataBindings.Clear()
            Dim oldTag As Object = cb.Tag
            cb.Tag = IgnoreClear
            If Utils.IsEmpty(bindField) Then
                cb.EditValue = DBNull.Value
            ElseIf ds IsNot Nothing Then
                cb.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnPropertyChanged)
            End If
            If showClearButton Then
                AddClearButton(cb)
            End If

            LookUpSetFilter(cb.Properties.DataSource, cb.Properties.ValueMember, GetBindedValue(cb), defaultFilter)
            cb.Tag = oldTag
            'If TypeOf (cb.Properties.DataSource) Is DataView Then
            '    If (CType(cb.Properties.DataSource, DataView).Table.Columns.Contains("intRowStatus")) Then
            '        Dim val As Object = GetBindedValue(cb)
            '        Dim filter As String
            '        If (Utils.IsEmpty(defaultFilter)) Then
            '            If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(val) Then
            '                filter = String.Format("intRowStatus = 0 or {0} = {1}", cb.Properties.ValueMember, val)
            '            Else
            '                filter = String.Format("intRowStatus = 0")
            '            End If
            '        Else
            '            If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(val) Then
            '                filter = String.Format("(intRowStatus = 0 or {0} = {1}) and ({2})", cb.Properties.ValueMember, val, defaultFilter)
            '            Else
            '                filter = String.Format("intRowStatus = 0 and ({0})", defaultFilter)
            '            End If
            '        End If
            '        If (CType(cb.Properties.DataSource, DataView).Table.PrimaryKey.Length > 0) Then
            '            filter = String.Format("({0}) or {1} = {2}", filter, CType(cb.Properties.DataSource, DataView).Table.PrimaryKey(0), LookupCache.EmptyLineKey)
            '        End If

            '        CType(cb.Properties.DataSource, DataView).RowFilter = filter
            '    Else
            '        CType(cb.Properties.DataSource, DataView).RowFilter = defaultFilter
            '    End If
            'Else
            '    Dbg.Debug("lookup binding source is not DataView")
            'End If
        End Sub

        Public Shared Sub AddBinding(ByVal cb As PopupContainerEdit, ByVal ds As Object, ByVal bindField As String)
            cb.DataBindings.Clear()
            If Utils.IsEmpty(bindField) Then
                cb.EditValue = DBNull.Value
            ElseIf ds IsNot Nothing Then
                cb.DataBindings.Add("EditValue", ds, bindField)
            End If
        End Sub

        Private Shared Sub LookUpSetFilter(ByRef ds As Object, ByVal bindField As String, ByVal value As Object,
                                           Optional defaultFilter As String = Nothing)
            If TypeOf (ds) Is DataView Then
                If (CType(ds, DataView).Table.Columns.Contains("intRowStatus")) Then

                    Dim filter As String
                    If (Utils.IsEmpty(defaultFilter)) Then
                        If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(value) Then
                            filter = String.Format("intRowStatus = 0 or {0} = {1}", bindField, value)
                        Else
                            filter = String.Format("intRowStatus = 0")
                        End If
                    Else
                        If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(value) Then
                            filter = String.Format("(intRowStatus = 0 and ({2})) or {0} = {1} ", bindField, value,
                                                   defaultFilter)
                        Else
                            filter = String.Format("intRowStatus = 0 and ({0})", defaultFilter)
                        End If
                    End If
                    If (CType(ds, DataView).Table.PrimaryKey.Length > 0) Then
                        filter = String.Format("({0}) or {1} = {2}", filter, CType(ds, DataView).Table.PrimaryKey(0),
                                               LookupCache.EmptyLineKey)
                    End If

                    CType(ds, DataView).RowFilter = filter
                Else
                    CType(ds, DataView).RowFilter = defaultFilter
                End If
                If (TypeOf (ds) Is LookupCacheDataView) Then
                    CType(ds, LookupCacheDataView).DefaultFilter = defaultFilter
                End If
            Else
                Dbg.Debug("lookup binding source is not DataView")
            End If
        End Sub

        Public Shared Sub AddBinding(ByVal cb As GridLookUpEdit, ByVal ds As Object, ByVal bindField As String,
                                     Optional ByVal showClearButton As Boolean = True)
            cb.DataBindings.Clear()
            Dim oldTag As Object = cb.Tag
            cb.Tag = IgnoreClear
            If Utils.IsEmpty(bindField) Then
                cb.EditValue = DBNull.Value
            Else
                Dbg.Assert(ds IsNot Nothing, "datasource for binding field {0} is not defined", bindField)
                cb.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnPropertyChanged)
            End If
            If showClearButton Then
                AddClearButton(cb)
            End If
            cb.Tag = oldTag
        End Sub

        Public Shared Sub BindTextEdit(ByVal txt As TextEdit, ByVal ds As DataSet, ByVal bindField As String)
            txt.DataBindings.Clear()
            Dbg.Assert(ds IsNot Nothing, "datasource for binding field {0} is not defined", bindField)
            txt.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnValidation)
            Dim maxLen As Integer = GetFieldLength(ds, bindField)
            If maxLen > 0 Then
                txt.Properties.MaxLength = maxLen
            End If
            If _
                Not txt.Tag Is Nothing AndAlso TypeOf txt.Tag Is TagHelper AndAlso
                TagHelper.GetTagHelper(txt).ControlLanguage = "en" Then
                DxControlsHelper.SetEnglishEditorMask(txt.Properties.Mask)
            End If
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataTextEdit(ByVal txt As TextEdit, ByVal ds As DataSet, ByVal bindField As String,
                                                   personalDataGroup As PersonalDataGroup, ignorePersonalData As Boolean,
                                                   Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup) Then
                BindPersonalDataContol(txt, displayString)
            Else
                BindTextEdit(txt, ds, bindField)
            End If
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataTextEdit(ByVal txt As TextEdit, ByVal ds As DataSet, ByVal bindField As String,
                                                   personalDataGroup As PersonalDataGroup(),
                                                   ignorePersonalData As Boolean, Optional displayString As String = "*")
            If Not ignorePersonalData Then
                For Each group As PersonalDataGroup In personalDataGroup
                    If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                        BindPersonalDataContol(txt, displayString)
                        Return
                    End If
                Next
            End If
            BindTextEdit(txt, ds, bindField)
        End Sub

        Public Shared Sub BindDateEdit(ByVal dt As DateEdit, ByVal ds As DataSet, ByVal bindField As String)
            dt.DataBindings.Clear()
            Dbg.Assert(ds IsNot Nothing, "datasource for binding field {0} is not defined", bindField)
            dt.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnPropertyChanged)
            DxControlsHelper.InitDateEdit(dt)
        End Sub

        Public Shared Sub BindPersonalDataContol(ctl As BaseEdit, Optional displayString As String = "*")
            ctl.DataBindings.Clear()
            ctl.Tag = "{R}"
            ctl.EditValue = DBNull.Value
            ctl.Properties.NullText = displayString
            ctl.Properties.ReadOnly = True
            ctl.Enabled = False
            LayoutCorrector.SetStyleController(ctl, LayoutCorrector.ReadOnlyStyleController)
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataDateEdit(ByVal dt As DateEdit, ByVal ds As DataSet, ByVal bindField As String,
                                                   personalDataGroup As PersonalDataGroup, ignorePersonalData As Boolean,
                                                   Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup)) Then
                BindPersonalDataContol(dt, displayString)
            Else
                BindDateEdit(dt, ds, bindField)
            End If
        End Sub

        Public Shared Function GetFieldLength(ByVal ds As DataSet, ByVal fieldName As String) As Integer
            Dim n() As String = fieldName.Split(CType(".", Char))
            If n.Length <> 2 Then
                Throw New SystemException("Invalid column specification: '" & fieldName & "'")
            End If
            Dim table As DataTable = ds.Tables(n(0))
            If table Is Nothing Then
                Throw New SystemException("no such table: '" & n(0) & "'")
            End If
            Return GetFieldLength(table, n(1))
        End Function


        Public Shared Function GetFieldLength(ByVal table As DataTable, ByVal fieldName As String) As Integer
            Dim col As DataColumn = table.Columns(fieldName)
            If col Is Nothing Then
                Throw New SystemException("no such column '" & fieldName & "' in table '" & table.TableName & "'")
            End If
            If col.DataType Is GetType(String) AndAlso col.MaxLength > 0 Then
                Return col.MaxLength
            End If
            Return 0
        End Function


        Private Shared Function IsPrintButton(ByVal btn As EditorButton) As Boolean
            Return btn.Kind = ButtonPredefines.Glyph _
            'AndAlso Not btn.Tag Is Nothing AndAlso TypeOf (btn.Tag) Is String AndAlso btn.Tag.ToString().StartsWith("print:")
        End Function

        'Private Shared Sub AddPrintButton(ByVal cb As ButtonEdit)
        '    For Each btn As EditorButton In cb.Properties.Buttons
        '        If IsPrintButton(btn) Then
        '            Return
        '        End If
        '    Next
        '    Dim btn1 As EditorButton = New EditorButton(ButtonPredefines.Glyph)
        '    btn1.Image = Utils.LoadBitmapFromResource("EIDSS.print.gif", GetType(LookupBinder))
        '    cb.Properties.Buttons.Add(btn1)
        'End Sub
        Private Shared Function FindParentPopupContol(ByVal ctl As Control) As BaseLookupForm
            Dim lookupCtl As Control = ctl.Parent
            While Not lookupCtl Is Nothing
                If TypeOf lookupCtl Is BaseLookupForm Then
                    If CType(lookupCtl, BaseLookupForm).LookupLayout = LookupFormLayout.DropDownList Then
                        Return CType(lookupCtl, BaseLookupForm)
                    End If
                ElseIf TypeOf lookupCtl Is PopupContainerControl Then
                    Dim pc As PopupContainerControl = CType(lookupCtl, PopupContainerControl)
                    If Not pc.OwnerEdit Is Nothing Then
                        Return CType(pc.OwnerEdit.Parent, BaseLookupForm)
                    End If
                End If
                lookupCtl = lookupCtl.Parent
            End While
            Return Nothing
        End Function

        Private Shared Sub AddPerson(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            'If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then
                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        If _
                            Not _
                            EidssUserContext.User.HasPermission(
                                PermissionHelper.InsertPermission(EIDSSPermissionObject.Person)) Then
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission",
                                                            "You have no rights to create this object"))
                            Return
                        End If
                        Dim id As Object = Nothing
                        Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                        Dim organizationID As Object =
                                GetParentIDFromRowFilter(CType(cb.Properties.DataSource, DataView).RowFilter)
                        Dim startUpParams As New Dictionary(Of String, Object)
                        If Not organizationID Is Nothing Then
                            startUpParams("OrganizationID") = organizationID
                        End If
                        If _
                            BaseFormManager.ShowModal(
                                CType(ClassLoader.LoadClass("PersonDetailPanel"), IApplicationForm), cb.FindForm(), id,
                                Nothing, startUpParams) Then
                            cb.EditValue = id
                            cb.Properties.ReadOnly = CType(cb.Properties.DataSource, DataView).Count <= 1
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub EditPerson(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If ActionLocker.LockAction(sender) Then
                Try
                    If e.Button.Kind = ButtonPredefines.Ellipsis Then
                        If _
                            Not _
                            EidssUserContext.User.HasPermission(
                                PermissionHelper.UpdatePermission(EIDSSPermissionObject.Person)) Then
                            MessageForm.Show(BvMessages.Get("msgNoUpdatePermission"))
                            Return
                        End If
                        Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                        Dim id As Object = cb.EditValue
                        If Utils.IsEmpty(id) Then
                            Return
                        End If
                        Dim pars As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                        pars.Add("NotDeleteAction", True)
                        If _
                            BaseFormManager.ShowModal(
                                CType(ClassLoader.LoadClass("PersonDetailPanel"), IApplicationForm), cb.FindForm(), id,
                                Nothing, pars) Then
                            cb.EditValue = id
                            cb.Properties.ReadOnly = CType(cb.Properties.DataSource, DataView).Count <= 1
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared RowFilterExp As New Regex("\=\s*([\'a-zA-Z0-9_]*)")

        Private Shared Function GetParentIDFromRowFilter(ByVal filter As String) As Object
            If Utils.IsEmpty(filter) Then Return Nothing
            Dim m As Match = RowFilterExp.Match(filter)
            Dim ParentId As String = Nothing
            If m.Success Then
                ParentId = m.Result("$1")
                Try
                    Return CLng(ParentId)
                Catch ex As Exception
                End Try
            End If
            Return ParentId
        End Function


#End Region

#Region "Handlers"

        Public Shared Event ClearingValueEvent As ChangingEventHandler

        Private Shared Sub ClearLookup(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Delete Then
                        If Not WinUtils.ConfirmLookupClear() Then
                            Return
                        End If
                        Dim cb As BaseEdit = CType(sender, BaseEdit)
                        Dim e1 As ChangingEventArgs = New ChangingEventArgs(cb.EditValue, DBNull.Value)
                        Dim mi As MethodInfo = cb.GetType().GetMethod("OnEditValueChanging",
                                                                      BindingFlags.Instance Or BindingFlags.NonPublic)
                        If Not mi Is Nothing Then
                            mi.Invoke(cb, New Object() {e1})
                            If e1.Cancel Then
                                Return
                            End If
                        End If
                        If cb.DataBindings.Count > 0 Then
                            Dim row As DataRow = BaseForm.GetControlCurrentRow(cb)
                            If _
                                Not row Is Nothing AndAlso
                                Not row(cb.DataBindings(0).BindingMemberInfo.BindingField) Is DBNull.Value Then
                                row.BeginEdit()
                                row(cb.DataBindings(0).BindingMemberInfo.BindingField) = DBNull.Value
                                row.EndEdit()
                                'Dim bf As BaseForm = BaseForm.FindBaseForm(cb)
                                'If Not bf Is Nothing Then
                                'End If
                            End If
                        End If
                        cb.EditValue = DBNull.Value
                        Dim pi As PropertyInfo = cb.GetType().GetProperty("EditorContainer",
                                                                          BindingFlags.Instance Or
                                                                          BindingFlags.NonPublic)
                        If _
                            Not pi Is Nothing AndAlso Not pi.GetValue(cb, Nothing) Is Nothing AndAlso
                            TypeOf (pi.GetValue(cb, Nothing)) Is GridControl Then
                            CType((pi.GetValue(cb, Nothing)), GridControl).MainView.PostEditor()
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Public Shared Sub KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.Control = True AndAlso e.KeyCode = Keys.Delete Then
                If TypeOf sender Is BaseEdit Then
                    Dim cb As BaseEdit = CType(sender, BaseEdit)
                    cb.EditValue = DBNull.Value
                    e.Handled = True
                ElseIf TypeOf sender Is RepositoryItemButtonEdit Then
                    Dim cb As RepositoryItemButtonEdit = CType(sender, RepositoryItemButtonEdit)
                    If Not cb.OwnerEdit Is Nothing Then
                        cb.OwnerEdit.EditValue = DBNull.Value
                        WinUtils.SetClearTooltip(cb.OwnerEdit)
                    End If
                    e.Handled = True
                End If
            End If
        End Sub

        Public Shared Function ShowBaseReferenceEditor(ByVal sender As Object, ByVal TableID As db.BaseReferenceType) _
            As Object
            Dim ID As Object = Nothing
            Dim bf As Object = ClassLoader.LoadClass("ReferenceDetail")
            If bf Is Nothing Then Throw New Exception("Can't load ReferenceDetail form")
            Dim startUpParam As New Dictionary(Of String, Object)
            startUpParam("ReferenceType") = TableID
            If _
                BaseFormManager.ShowModal(CType(bf, BaseForm), CType(sender, Control).FindForm(), ID, Nothing,
                                          startUpParam) Then
                Return ID
            End If
            Return Nothing
        End Function

        Public Shared Sub AddBaseReference(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim TableID As db.BaseReferenceType = GetLookupTableID(sender)
                        Dim haCode As HACode = GetHACode(sender)
                        Dim ID As Object = ShowBaseReferenceEditor(sender, TableID)
                        If Not ID Is Nothing Then
                            If TypeOf sender Is RepositoryItemLookUpEdit Then
                                Dim cb As RepositoryItemLookUpEdit = CType(sender, RepositoryItemLookUpEdit)


                                '--------------------Updated by Olga 27.07.2007
                                LookupCache.Refresh(TableID, haCode, False)
                                Dim r As DataRow = CType(cb.DataSource, DataView).Table.Rows.Find(ID)
                                If r Is Nothing Then
                                    cb.OwnerEdit.EditValue = DBNull.Value
                                Else
                                    cb.OwnerEdit.EditValue = ID
                                End If
                                DataEventManager.SubmitCurrentEdit(cb.OwnerEdit)
                                '--------------------Updated by Olga 27.07.2007
                            ElseIf TypeOf sender Is LookUpEdit Then
                                Dim cb As LookUpEdit = CType(sender, LookUpEdit)


                                '--------------------Updated by Olga 27.07.2007
                                LookupCache.Refresh(TableID, haCode, False)
                                If CType(cb.Properties.DataSource, DataView).Table.PrimaryKey.Length = 1 Then

                                    Dim r As DataRow = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID)
                                    If r Is Nothing Then
                                        CType(sender, LookUpEdit).EditValue = DBNull.Value
                                    Else
                                        CType(sender, LookUpEdit).EditValue =
                                            r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
                                        If Not CType(sender, LookUpEdit).Parent Is Nothing Then
                                            If TypeOf CType(sender, LookUpEdit).Parent Is TreeList Then
                                                CType(CType(sender, LookUpEdit).Parent, TreeList).ShowEditor()
                                                CType(CType(sender, LookUpEdit).Parent, TreeList).EditingValue =
                                                    r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
                                                CType(CType(sender, LookUpEdit).Parent, TreeList).CloseEditor()
                                                CType(CType(sender, LookUpEdit).Parent, TreeList).EndCurrentEdit()
                                            End If
                                        End If
                                    End If
                                    DataEventManager.SubmitCurrentEdit(cb)
                                End If
                                '--------------------Updated by Olga 27.07.2007
                            End If
                        End If
                    End If

                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub ShowReferenceEditor(ByVal sender As Object, ByVal e As ButtonPressedEventArgs,
                                               editorName As String)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim ID As Object = Nothing
                        If _
                            BaseFormManager.ShowModal(CType(ClassLoader.LoadClass(editorName), BaseForm),
                                                      CType(sender, Control).FindForm(), ID, Nothing, Nothing) Then
                            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                            Dim r As DataRow = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID.ToString)
                            If Not r Is Nothing Then
                                CType(sender, LookUpEdit).EditValue = r(CType(sender, LookUpEdit).Properties.ValueMember) _
                                'ID
                                If Not CType(sender, LookUpEdit).Parent Is Nothing Then
                                    If TypeOf CType(sender, LookUpEdit).Parent Is TreeList Then
                                        CType(CType(sender, LookUpEdit).Parent, TreeList).ShowEditor()
                                        CType(CType(sender, LookUpEdit).Parent, TreeList).EditingValue =
                                            r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
                                        CType(CType(sender, LookUpEdit).Parent, TreeList).CloseEditor()
                                        CType(CType(sender, LookUpEdit).Parent, TreeList).EndCurrentEdit()
                                    End If
                                End If
                            End If
                            DataEventManager.SubmitCurrentEdit(cb)
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Public Shared Sub AddSpecies(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            ShowReferenceEditor(sender, e, "SpeciesTypeDetail")
            'If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            'If ActionLocker.LockAction(sender) Then

            '    Try
            '        If e.Button.Kind = ButtonPredefines.Plus Then
            '            Dim ID As Object = Nothing
            '            If BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("SpeciesTypeDetail"), BaseForm), CType(sender, Control).FindForm(), ID, Nothing, Nothing) Then
            '                Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            '                Dim r As DataRow = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID.ToString)
            '                If Not r Is Nothing Then
            '                    CType(sender, LookUpEdit).EditValue = r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
            '                    If Not CType(sender, LookUpEdit).Parent Is Nothing Then
            '                        If TypeOf CType(sender, LookUpEdit).Parent Is DevExpress.XtraTreeList.TreeList Then
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).ShowEditor()
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).EditingValue = r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).CloseEditor()
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).EndCurrentEdit()
            '                        End If
            '                    End If
            '                End If
            '                DataEventManager.SubmitCurrentEdit(cb)
            '            End If
            '        End If
            '    Finally
            '        ActionLocker.UnlockAction(sender)
            '    End Try
            'End If
        End Sub

        Public Shared Sub AddSampleType(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            ShowReferenceEditor(sender, e, "SampleTypeDetail")

            'If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            'If ActionLocker.LockAction(sender) Then

            '    Try
            '        If e.Button.Kind = ButtonPredefines.Plus Then
            '            Dim ID As Object = Nothing
            '            If BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("SampleTypeDetail"), BaseForm), CType(sender, Control).FindForm(), ID, Nothing, Nothing) Then
            '                Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            '                Dim r As DataRow = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID.ToString)
            '                If Not r Is Nothing Then
            '                    CType(sender, LookUpEdit).EditValue = r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
            '                    If Not CType(sender, LookUpEdit).Parent Is Nothing Then
            '                        If TypeOf CType(sender, LookUpEdit).Parent Is DevExpress.XtraTreeList.TreeList Then
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).ShowEditor()
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).EditingValue = r(CType(sender, LookUpEdit).Properties.ValueMember) 'ID
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).CloseEditor()
            '                            CType(CType(sender, LookUpEdit).Parent, DevExpress.XtraTreeList.TreeList).EndCurrentEdit()
            '                        End If
            '                    End If
            '                End If
            '                DataEventManager.SubmitCurrentEdit(cb)
            '            End If
            '        End If
            '    Finally
            '        ActionLocker.UnlockAction(sender)
            '    End Try
            'End If
        End Sub

        Public Shared Sub AddDiagnosis(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            ShowReferenceEditor(sender, e, "DiagnosisReferenceDetail")
        End Sub

#End Region

#Region "Control lookup properties"

        Private Shared m_LookupControls As New Hashtable

        Public Shared Property LookupTableName(ByVal ctl As Control) As String
            Get
                Return TagHelper.GetTagHelper(ctl).LookupTableName
            End Get
            Set(ByVal Value As String)
                TagHelper.GetTagHelper(ctl).LookupTableName = Value
            End Set
        End Property

        Public Shared Property LookupTableName(ByVal ctl As RepositoryItemLookUpEdit) As String
            Get
                Return Utils.Str(m_LookupControls(ctl))
            End Get
            Set(ByVal Value As String)
                If m_LookupControls.Contains(ctl) = False Then
                    AddHandler ctl.Disposed, AddressOf Lookup_Disposed
                End If
                m_LookupControls(ctl) = Value
            End Set
        End Property
        'Private Shared Function GetLookupTableName(ByVal ctl As Object) As String
        '    If TypeOf (ctl) Is Control Then
        '        Return LookupTableName(CType(ctl, Control))
        '    ElseIf TypeOf (ctl) Is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Then
        '        Return LookupTableName(CType(ctl, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit))
        '    End If
        '    Throw New Exception("Invalid looup object type")
        'End Function

        Public Shared Property LookupTableID(ByVal ctl As Control) As db.BaseReferenceType
            Get
                Dim Tag As TagHelper = TagHelper.GetTagHelper(ctl)
                If Utils.Str(Tag.LookupTableName) = "" Then
                    If Not Tag.Tag Is Nothing AndAlso TypeOf Tag.Tag Is RepositoryItemLookUpEdit Then
                        Return LookupTableID(CType(Tag.Tag, RepositoryItemLookUpEdit))
                    End If
                    Return db.BaseReferenceType.rftNone
                End If
                Return _
                    CType(db.BaseReferenceType.Parse(GetType(db.BaseReferenceType), Tag.LookupTableName),
                          db.BaseReferenceType)
            End Get
            Set(ByVal Value As db.BaseReferenceType)
                TagHelper.GetTagHelper(ctl).LookupTableName = Value.ToString
            End Set
        End Property

        Public Shared Property LookupTableID(ByVal ctl As RepositoryItemLookUpEdit) As db.BaseReferenceType
            Get
                If m_LookupControls.Contains(ctl) Then
                    Return _
                        CType(db.BaseReferenceType.Parse(GetType(db.BaseReferenceType), Utils.Str(m_LookupControls(ctl))),
                              db.BaseReferenceType)
                End If
                Return Nothing
            End Get
            Set(ByVal Value As db.BaseReferenceType)
                LookupTableName(ctl) = Value.ToString
            End Set
        End Property

        Private Shared Sub Lookup_Disposed(ByVal sender As Object, ByVal e As EventArgs)
            m_LookupControls.Remove(sender)
        End Sub

        Private Shared Function GetLookupTableID(ByVal ctl As Object) As db.BaseReferenceType
            If TypeOf (ctl) Is Control Then
                Return LookupTableID(CType(ctl, Control))
            ElseIf TypeOf (ctl) Is RepositoryItemLookUpEdit Then
                Return LookupTableID(CType(ctl, RepositoryItemLookUpEdit))
            End If
            Throw New Exception("Invalid lookup object type")
        End Function

        '--------------------Added by Olga 27.07.2007
        Public Shared Property HACodeName(ByVal ctl As Control) As String
            Get
                Return TagHelper.GetTagHelper(ctl).HACodeName
            End Get
            Set(ByVal Value As String)
                TagHelper.GetTagHelper(ctl).HACodeName = Value
            End Set
        End Property

        Private Shared m_HACodeControls As New Hashtable

        Public Shared Property HACodeName(ByVal ctl As RepositoryItemLookUpEdit) As String
            Get
                Return Utils.Str(m_HACodeControls(ctl))
            End Get
            Set(ByVal Value As String)
                If m_HACodeControls.Contains(ctl) = False Then
                    AddHandler ctl.Disposed, AddressOf HACode_Disposed
                End If
                m_HACodeControls(ctl) = Value
            End Set
        End Property
        'Private Shared Function GetHACodeName(ByVal ctl As Object) As String
        '    If TypeOf (ctl) Is Control Then
        '        Return HACodeName(CType(ctl, Control))
        '    ElseIf TypeOf (ctl) Is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Then
        '        Return HACodeName(CType(ctl, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit))
        '    End If
        '    Throw New Exception("Invalid object HACode")
        'End Function

        Private Shared Sub HACode_Disposed(ByVal sender As Object, ByVal e As EventArgs)
            m_HACodeControls.Remove(sender)
        End Sub

        Public Shared Property HACodeValue(ByVal ctl As Control) As HACode
            Get
                Dim Tag As TagHelper = TagHelper.GetTagHelper(ctl)
                If Utils.Str(Tag.HACodeName) = "" Then
                    If Not Tag.Tag Is Nothing AndAlso TypeOf Tag.Tag Is RepositoryItemLookUpEdit Then
                        Return HACodeValue(CType(Tag.Tag, RepositoryItemLookUpEdit))
                    Else
                        Return HACode.None
                    End If
                End If
                Return CType(HACode.Parse(GetType(HACode), Tag.HACodeName), HACode)
            End Get
            Set(ByVal Value As HACode)
                TagHelper.GetTagHelper(ctl).HACodeName = Value.ToString
            End Set
        End Property

        Public Shared Property HACodeValue(ByVal ctl As RepositoryItemLookUpEdit) As HACode
            Get
                If m_HACodeControls.Contains(ctl) Then
                    If Utils.IsEmpty(m_HACodeControls(ctl)) Then Return HACode.None
                    Return CType(HACode.Parse(GetType(HACode), Utils.Str(m_HACodeControls(ctl))), HACode)
                End If
                Return Nothing
            End Get
            Set(ByVal Value As HACode)
                HACodeName(ctl) = Value.ToString
            End Set
        End Property

        Private Shared Function GetHACode(ByVal ctl As Object) As HACode
            If TypeOf (ctl) Is Control Then
                Return HACodeValue(CType(ctl, Control))
            ElseIf TypeOf (ctl) Is RepositoryItemLookUpEdit Then
                Return HACodeValue(CType(ctl, RepositoryItemLookUpEdit))
            End If
            Throw New Exception("Invalid object HACode")
        End Function

#End Region

#Region "Base lookup binding"

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode)
            BindBaseLookup(cb, ds, bindField, tableId, aHACode, True)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode,
                                         ByVal showPlusButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            LookupTableID(cb) = tableId
            HACodeValue(cb) = aHACode
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId, aHACode), "name", "idfsReference")
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal rg As RadioGroup, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode)
            LookupTableID(rg) = tableId
            HACodeValue(rg) = aHACode
            rg.Properties.Items.Clear()
            Dim dw As DataView = LookupCache.Get(tableId, aHACode)
            For Each row As DataRowView In dw
                rg.Properties.Items.Add(New RadioGroupItem(row("idfsReference"), Utils.Str(row("name"))))
            Next
            rg.DataBindings.Add("EditValue", ds, bindField)
        End Sub

        Public Shared Sub BindBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode,
                                                   ByVal showPlusButton As Boolean,
                                                   Optional ByVal ShowClearButton As Boolean = False)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            LookupTableID(cb) = tableId
            HACodeValue(cb) = aHACode
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId, aHACode), "name", "idfsReference", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddClearButton(cb, ShowClearButton)
        End Sub

        Public Shared Sub BindBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode,
                                                   ByVal addButtonHandler As ButtonPressedEventHandler)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            LookupTableID(cb) = tableId
            HACodeValue(cb) = aHACode
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId, aHACode), "name", "idfsReference", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If Not addButtonHandler Is Nothing Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, addButtonHandler)
            End If
            AddClearButton(cb)
        End Sub

        Public Shared Sub BindBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   ByVal tableId As db.BaseReferenceType, ByVal aHACode As HACode)
            BindBaseRepositoryLookup(cb, tableId, aHACode, True)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal showPlusButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            LookupTableID(cb) = tableId
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference")
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddBinding(cb, dataSource, bindField)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType,
                                         ByVal addButtonHandler As ButtonPressedEventHandler)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            LookupTableID(cb) = tableId
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference")
            If Not AddButtonHandler Is Nothing Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddButtonHandler)
            End If
            AddBinding(cb, dataSource, bindField)
        End Sub
        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, haCode As HACode,
                                         ByVal addButtonHandler As ButtonPressedEventHandler)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            LookupTableID(cb) = tableId
            HACodeValue(cb) = haCode
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId, haCode), "name", "idfsReference")
            If Not addButtonHandler Is Nothing Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, addButtonHandler)
            End If
            AddBinding(cb, dataSource, bindField)
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                     ByVal bindField As String, ByVal tableId As db.BaseReferenceType,
                                                     ByVal aHACode As HACode, ByVal showPlusButton As Boolean,
                                                     personalDataGroup As PersonalDataGroup,
                                                     ignorePersonalData As Boolean,
                                                     Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup) Then
                BindPersonalDataContol(cb, displayString)
            Else
                BindBaseLookup(cb, ds, bindField, tableId, aHACode, showPlusButton)
            End If
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                     ByVal bindField As String, ByVal tableId As db.BaseReferenceType,
                                                     ByVal showPlusButton As Boolean, ByVal showClearButton As Boolean,
                                                     personalDataGroup As PersonalDataGroup,
                                                     ignorePersonalData As Boolean,
                                                     Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup) Then
                BindPersonalDataContol(cb, displayString)
            Else
                BindBaseLookup(cb, ds, bindField, tableId, showPlusButton, showClearButton)
            End If
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal showPlusButton As Boolean,
                                         ByVal showClearButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            LookupTableID(cb) = tableId
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference")
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddBinding(cb, ds, bindField, showClearButton)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType, ByVal showPlusButton As Boolean)
            BindBaseLookup(cb, ds, bindField, tableId, showPlusButton, True)
        End Sub

        Public Shared Sub BindStandardLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                             ByVal tableId As [Enum], ByVal showPlusButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference")
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType)
            BindBaseLookup(cb, ds, bindField, tableId, True)
        End Sub

        Public Shared Sub BindBaseLookup(ByVal rg As RadioGroup, ByVal ds As DataSet, ByVal bindField As String,
                                         ByVal tableId As db.BaseReferenceType)
            LookupTableID(rg) = tableId
            rg.Properties.Items.Clear()
            Dim dw As DataView = LookupCache.Get(tableId.ToString)
            For Each row As DataRowView In dw
                rg.Properties.Items.Add(New RadioGroupItem(row("idfsReference"), Utils.Str(row("name"))))
            Next
            rg.DataBindings.Clear()
            If (Not Utils.IsEmpty(bindField)) Then
                rg.DataBindings.Add("EditValue", ds, bindField)
            End If
        End Sub

        Public Shared Sub SetDefaultFilter(sender As Object, e As CancelEventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            SetDefaultFilter(cb, True)
        End Sub

        Public Shared Sub SetDefaultFilter(sender As Object, e As EventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            SetDefaultFilter(cb, True)
        End Sub

        Public Shared Sub SetDefaultFilter(cb As LookUpEditBase, filter As String, isRepositoryLookup As Boolean)
            If _
                (Not cb.Tag Is Nothing AndAlso TypeOf cb.Tag Is DataView AndAlso
                 CType(cb.Tag, DataView).RowFilter = filter) Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            If (isRepositoryLookup) Then
                Dim clonedView As DataView = New DataView(view.Table)
                clonedView.RowFilter = filter
                cb.Properties.DataSource = clonedView
                TagHelper.GetTagHelper(cb).ClonedView = clonedView
            Else
                view.RowFilter = filter
            End If
        End Sub

        Public Shared Sub SetDefaultFilter(cb As LookUpEditBase, isRepositoryLookup As Boolean)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            Dim defaultFilter As String = String.Empty
            If (TypeOf view Is LookupCacheDataView) Then _
                'we popup dropdown without user interface, so not filtered view come from repositoryLookup
                defaultFilter = CType(view, LookupCacheDataView).DefaultFilter
            Else 'cloned dataview is used already, we should not filter it
                Return
            End If
            If (view.Table.Columns.Contains("intRowStatus")) Then
                If Not Utils.IsEmpty(defaultFilter) Then
                    defaultFilter = String.Format("(({0}) AND intRowStatus = 0)", defaultFilter)
                Else
                    defaultFilter = "(intRowStatus = 0)"
                End If
                If (Not Utils.IsEmpty(cb.EditValue)) Then
                    If (TypeOf (cb.EditValue) Is String) Then
                        defaultFilter = String.Format("{2} or {0}='{1}'", cb.Properties.ValueMember, cb.EditValue,
                                                      defaultFilter)
                    Else
                        defaultFilter = String.Format("{2} or {0}={1}", cb.Properties.ValueMember, cb.EditValue,
                                                      defaultFilter)
                    End If
                End If
            End If
            SetDefaultFilter(cb, defaultFilter, isRepositoryLookup)
        End Sub

        Public Shared Sub ClearDefaultFilter(cb As LookUpEditBase)
            If (Not cb.Tag Is Nothing AndAlso TypeOf (cb.Tag) Is TagHelper) Then
                Dim view As DataView = TagHelper.GetTagHelper(cb).ClonedView
                If Not view Is Nothing Then
                    Try
                        view.Dispose()
                    Finally
                        TagHelper.GetTagHelper(cb).ClonedView = Nothing
                    End Try
                End If
            End If
        End Sub

        Public Shared Sub ClearDefaultFilter(sender As Object, e As CancelEventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            ClearDefaultFilter(cb)

            'If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
            '    Return
            'End If
            'Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            'If (view.Table.Columns.Contains("intRowStatus")) Then
            '    view.RowFilter = ""
            'End If
        End Sub

        Public Shared Sub ClearDefaultFilter(sender As Object, e As EventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            ClearDefaultFilter(cb)
        End Sub

        Public Shared Sub BindBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   ByVal tableId As db.BaseReferenceType,
                                                   Optional ByVal showPlusButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            LookupTableID(cb) = tableId
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddClearButton(cb)
        End Sub
        'Can be used for the filtered base reference lookups that are defined in the LookupTables enumeration
        Public Shared Sub BindStandardRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                       ByVal tableId As LookupTables,
                                                       Optional ByVal showPlusButton As Boolean = True,
                                                       Optional valueMember As String = "idfsReference",
                                                       Optional displayMember As String = "name")
            BindStandardRepositoryLookup(cb, tableId, AddressOf SetDefaultFilter, showPlusButton, valueMember,
                                         displayMember)
        End Sub

        Public Shared Sub BindStandardRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                       ByVal tableId As LookupTables, setFilterHandler As EventHandler,
                                                       Optional ByVal showPlusButton As Boolean = True,
                                                       Optional valueMember As String = "idfsReference",
                                                       Optional displayMember As String = "name")
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo(displayMember, "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), displayMember, valueMember, setFilterHandler,
                          AddressOf ClearDefaultFilter)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddClearButton(cb)
        End Sub

#End Region

        '#Region "CheckListBox Binding"
        '        Public Shared Sub BindCheckListLookup(ByVal lst As CheckedListBoxControl, ByVal dt As DataTable, ByVal ValueMember As String, ByVal DisplayMember As String, Optional ByVal AddEmptyString As Boolean = False, Optional ByVal tableId As BaseReferenceType = BaseReferenceType.rftNone)
        '            Dim t As New TagHelper(lst)
        '            t.IntTag = CType(tableId, Integer)
        '            If AddEmptyString Then
        '                AddOtherValue(dt)
        '                Try
        '                    RemoveHandler lst.ItemChecking, AddressOf CheckList_ItemChecking
        '                Finally
        '                    AddHandler lst.ItemChecking, AddressOf CheckList_ItemChecking
        '                End Try
        '            End If
        '            lst.DataSource = New DataView(dt)
        '            lst.DisplayMember = DisplayMember
        '            lst.ValueMember = ValueMember
        '            Dim bf As BaseForm = BaseForm.FindBaseForm(lst)
        '            'If bf.Created Then
        '            MarkCheckListBoxes(bf, lst)
        '            'End If
        '            If Not bf Is Nothing Then
        '                Try
        '                    RemoveHandler bf.Load, AddressOf CheckList_Load
        '                Finally
        '                    AddHandler bf.Load, AddressOf CheckList_Load
        '                End Try
        '            End If
        '            Try
        '                RemoveHandler lst.ItemCheck, AddressOf CheckList_ItemCheck
        '            Finally
        '                AddHandler lst.ItemCheck, AddressOf CheckList_ItemCheck
        '            End Try
        '        End Sub
        '        Public Const Other As String = "Other"
        '        Private Shared Sub AddOtherValue(ByVal dt As DataTable)
        '            If dt.Select(String.Format("idfsReference='{0}'", Other)).Length = 0 Then
        '                Dim row As DataRow = dt.NewRow
        '                row("idfsReference") = Other
        '                dt.Columns("name").ReadOnly = False
        '                row("name") = Other)
        '                dt.Rows.Add(row)
        '                row.AcceptChanges()
        '            End If

        '        End Sub

        '        Private Shared Sub CheckList_ItemChecking(ByVal sender As Object, ByVal e As ItemCheckingEventArgs)
        '            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
        '            Dim bf As BaseForm = BaseForm.FindBaseForm(lst)
        '            If bf Is Nothing OrElse bf.Loading Then Return
        '            Dim dt As DataTable = CType(lst.DataSource, DataView).Table
        '            Dim t As New TagHelper(lst)
        '            Dim tableId As BaseReferenceType = CType(t.IntTag, BaseReferenceType)

        '            If dt.Rows(e.Index)("idfsReference").ToString = LookupBinder.Other AndAlso tableId <> BaseReferenceType.rftNone Then
        '                e.Cancel = True
        '                Dim ID As Object = LookupBinder.ShowBaseReferenceEditor(sender, tableId)
        '                If Not ID Is Nothing Then
        '                    'Currently this chek list boxes are not using in the program
        '                    'if there will be need in this the commented text should be rewwritten for using with LookupCache
        '                    'Using ds As New DataSet()
        '                    '    Lookup_Db.FillBaseLookup(ds, tableId)
        '                    '    For Each r As DataRow In ds.Tables(0).Rows
        '                    '        If dt.Select(String.Format("idfsReference={0}", r("idfsReference"))).Length = 0 Then
        '                    '            dt.BeginLoadData()
        '                    '            Dim dr As DataRow = dt.NewRow()
        '                    '            dr("idfsReference") = r("idfsReference")
        '                    '            dr("Name") = r("Name")
        '                    '            dr("intStatus") = 1
        '                    '            dt.Rows.Add(dr)
        '                    '            dt.EndLoadData()
        '                    '        End If
        '                    '    Next
        '                    '    DbDisposeHelper.ClearDataset(ds)
        '                    'End Using
        '                    lst.BeginUpdate()
        '                    Dim i As Integer = 0
        '                    While Not lst.GetItem(i) Is Nothing
        '                        lst.SetItemChecked(i, CType(IIf(True.Equals(lst.GetItemValue(i)), True, False), Boolean))
        '                        i += 1
        '                    End While
        '                    lst.EndUpdate()
        '                End If
        '            End If
        '        End Sub
        '        Private Shared Sub CheckList_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        '            Dim bf As BaseForm = CType(sender, BaseForm)
        '            VisitCheckLlists(bf, bf)
        '        End Sub

        '        Private Shared Sub VisitCheckLlists(ByVal bf As BaseForm, ByVal parentCtl As Control)
        '            For Each ctl As Control In parentCtl.Controls
        '                If TypeOf ctl Is CheckedListBoxControl Then
        '                    MarkCheckListBoxes(bf, CType(ctl, CheckedListBoxControl))
        '                Else
        '                    VisitCheckLlists(bf, ctl)
        '                End If
        '            Next

        '        End Sub
        '        Public Shared Sub MarkCheckListBoxes(ByVal bf As BaseForm, ByVal lst As CheckedListBoxControl)
        '            bf.BeginUpdate()
        '            Dim i As Integer = 0
        '            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
        '                lst.BeginUpdate()
        '                While Not lst.GetItem(i) Is Nothing
        '                    lst.SetItemChecked(i, CType(IIf(True.Equals(lst.GetItemValue(i)), True, False), Boolean))
        '                    i += 1
        '                End While
        '                lst.EndUpdate()
        '            End If
        '            bf.EndUpdate()

        '        End Sub

        '        Private Shared Sub CheckList_ItemCheck(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs)
        '            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
        '            'Dim bf As BaseForm = BaseForm.FindBaseForm(lst)
        '            'If bf Is Nothing OrElse bf.Loading Then Return
        '            'If bf.Loading Then Return
        '            Dim dt As DataTable = CType(lst.DataSource, DataView).Table
        '            dt.Rows(e.Index)("intStatus") = (e.State = CheckState.Checked)
        '        End Sub

        '#End Region
        Public Shared Sub RemoveEmptyRow(view As DataView)
            If view.Count > 0 Then
                Dim row As DataRowView = view(0)
                If (row(0).Equals(LookupCache.EmptyLineKey)) Then
                    view.Delete(0)
                End If
            End If
        End Sub

#Region "Special Bindings"

        Public Shared Sub BindCountryLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                            Optional ByVal bindField As String = Nothing,
                                            Optional ByVal showEmptyValue As Boolean = True)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strCountryName",
                                                                                               "colCountryName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = cb.Width
            SetDataSource(cb, LookupCache.Get(LookupTables.Country.ToString), "strCountryName", "idfsCountry")
            If (Not showEmptyValue) Then
                RemoveEmptyRow(CType(cb.Properties.DataSource, DataView))
            End If
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Sub BindCountryRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                      Optional ByVal showEmptyValue As Boolean = True)
            cb.Columns.Clear()

            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("strCountryName", "colCountryName",
                                                                                    200, FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(LookupTables.Country.ToString), "strCountryName", "idfsCountry", Nothing,
                          Nothing)
            If (Not showEmptyValue) Then
                RemoveEmptyRow(CType(cb.DataSource, DataView))
            End If
        End Sub

        Public Shared Sub BindRegionLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                           Optional ByVal bindField As String = Nothing,
                                           Optional showAggregateRegions As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strRegionName",
                                                                                               "colRegionName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            cb.Properties.PopupWidth = cb.Width
            Dim view As DataView
            If showAggregateRegions Then
                view = LookupCache.Get(LookupTables.RegionForAggregate.ToString)
            Else
                view = LookupCache.Get(LookupTables.Region.ToString)
            End If
            SetDataSource(cb, view, "strRegionName", "idfsRegion")
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Function FilterRegion(ByVal cb As LookUpEdit, ByVal country As Object) As Object
            If Utils.IsEmpty(country) Then
                country = - 1
            End If
            Dim val As Object = GetBindedValue(cb)
            If Not Utils.IsEmpty(val) Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsCountry = {0} and (intRowStatus = 0 or {1} = {2})) or {1} = {3}", country,
                                  cb.Properties.ValueMember, val, LookupCache.EmptyLineKey)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsCountry = {0} and intRowStatus = 0) or {1} = {2}", country,
                                  cb.Properties.ValueMember, LookupCache.EmptyLineKey)
            End If
            cb.Properties.ReadOnly = CType(cb.Properties.DataSource, DataView).Count <= 1
            Return country
        End Function

        Public Shared Function FilterRayon(ByVal cb As LookUpEdit, ByVal region As Object) As Object
            If Utils.IsEmpty(region) Then
                region = - 1
            End If
            Dim val As Object = GetBindedValue(cb)
            If Not Utils.IsEmpty(val) Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsRegion = {0} and (intRowStatus = 0 or {1} = {2})) or {1} = {3}", region,
                                  cb.Properties.ValueMember, val, LookupCache.EmptyLineKey)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsRegion = {0} and intRowStatus = 0) or {1} = {2}", region,
                                  cb.Properties.ValueMember, LookupCache.EmptyLineKey)
            End If
            cb.Properties.ReadOnly = CType(cb.Properties.DataSource, DataView).Count <= 1
            Return region
        End Function


        Public Shared Function FilterSettlement(ByVal cb As LookUpEdit, ByVal rayon As Object) As Object
            If Utils.IsEmpty(rayon) Then
                rayon = - 1
            End If
            If cb.Properties.DataSource Is Nothing Then
                Return rayon
            End If
            Dim val As Object = GetBindedValue(cb)
            If Not Utils.IsEmpty(val) Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsRayon = {0} and (intRowStatus = 0 or {1} = {2})) or {1} = {3}", rayon,
                                  cb.Properties.ValueMember, val, LookupCache.EmptyLineKey)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(idfsRayon = {0} and intRowStatus = 0) or {1} = {2}", rayon,
                                  cb.Properties.ValueMember, LookupCache.EmptyLineKey)
            End If
            cb.Properties.ReadOnly = CType(cb.Properties.DataSource, DataView).Count <= 1
            Return rayon
        End Function
        'Public Shared Sub BindRegionRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit)
        '    cb.Columns.Clear()

        '    cb.Columns.AddRange(New BvLookUpColumnInfo() { _
        '               New BvLookUpColumnInfo("strRegionName", "colRegionName", "Region Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Region.ToString), "strRegionName", "idfsRegion", Nothing, Nothing)
        'End Sub

        Public Shared Sub BindRayonLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                          Optional ByVal bindField As String = Nothing,
                                          Optional showAggregateRayons As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strRayonName",
                                                                                               "colRayonName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            Dim view As DataView
            If showAggregateRayons Then
                view = LookupCache.Get(LookupTables.RayonForAggregate.ToString)
            Else
                view = LookupCache.Get(LookupTables.Rayon.ToString)
            End If
            cb.Properties.PopupWidth = cb.Width
            SetDataSource(cb, view, "strRayonName", "idfsRayon")
            AddBinding(cb, ds, bindField)
        End Sub

        'Public Shared Sub BindRayonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit)
        '    cb.Columns.Clear()

        '    cb.Columns.AddRange(New BvLookUpColumnInfo() { _
        '               New BvLookUpColumnInfo("strRayonName", "colRayonName", "Rayon Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Rayon.ToString), "strRayonName", "idfsRayon")
        'End Sub

        Public Shared Sub BindSettlementLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                               Optional ByVal bindField As String = Nothing,
                                               Optional showAggregateSettlements As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strSettlementName",
                                                                                               "colSettlementName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            If Not BaseSettings.ScanFormsMode Then
                cb.Properties.PopupWidth = cb.Width
                Dim dv As DataView
                If showAggregateSettlements Then
                    dv = LookupCache.Get(LookupTables.SettlementForAggregate.ToString)
                Else
                    dv = LookupCache.Get(LookupTables.Settlement.ToString)
                End If
                dv.Sort = "strSettlementName"
                SetDataSource(cb, dv, "strSettlementName", "idfsSettlement")
                AddBinding(cb, ds, bindField)
            End If
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataSettlementLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                           personalDataGroup As PersonalDataGroup,
                                                           ignorePersonalData As Boolean,
                                                           Optional ByVal bindField As String = Nothing,
                                                           Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup) Then
                BindPersonalDataContol(cb, displayString)
            Else
                BindSettlementLookup(cb, ds, bindField)
            End If
        End Sub

        'Public Shared Sub BindSettlementRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit)
        '    cb.Columns.Clear()

        '    cb.Columns.AddRange(New BvLookUpColumnInfo() { _
        '               New BvLookUpColumnInfo("strSettlementName", "colSettlementName", "Settlement Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    Dim dv As DataView = LookupCache.Get(LookupTables.Settlement.ToString)
        '    dv.Sort = "strSettlementName"
        '    SetDataSource(cb, dv, "strSettlementName", "idfsSettlement")
        'End Sub

        Public Shared Sub BindPersonLookup(ByVal cb As LookUpEdit, ByVal ds As Object, ByVal bindField As String,
                                           Optional ByVal showPlusButton As Boolean = True,
                                           Optional showEditButton As Boolean = False)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("FullName",
                                                                                               "colPersonFullName", 200),
                                                                        New BvLookupColumnInfo("Organization",
                                                                                               "strOrganization", 80),
                                                                        New BvLookupColumnInfo("Position", "colPosition",
                                                                                               50)})
            cb.Properties.PopupWidth = 350
            Dim dv As DataView = LookupCache.Get(LookupTables.Person.ToString)
            SetDataSource(cb, dv, "FullName", "idfPerson")

            If (showPlusButton) Then
                AddPlusButton(cb)
            End If
            AddButtonClickHandler(cb, AddressOf AddPerson)
            If (showEditButton) Then
                AddEditButton(cb)
                AddButtonClickHandler(cb, AddressOf EditPerson)
                AddHandler cb.EditValueChanged, AddressOf EnableEditButton
            End If
            AddBinding(cb, ds, bindField, True)
        End Sub

        Public Shared Sub EnableEditButton(sender As Object, e As EventArgs)

            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim bf As BaseForm = BaseForm.FindBaseForm(cb)

            If Not cb.Enabled OrElse (Not bf Is Nothing AndAlso bf.ReadOnly) Then
                Return
            End If
            Dim oldTag As Object = cb.Tag
            cb.Tag = IgnoreClear
            Try
                For Each btn As EditorButton In cb.Properties.Buttons
                    If (btn.Kind = ButtonPredefines.Ellipsis) Then
                        btn.Enabled = Not Utils.IsEmpty(GetBindedValue(cb))
                    End If
                Next

            Finally
                cb.Tag = oldTag
            End Try
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     Optional ByVal showClearButton As Boolean = True, Optional accessory As HACode = HACode.None)
            BindPersonRepositoryLookup(cb, AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter, showClearButton, accessory)
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     defaultFilterHandler As EventHandler,
                                                     Optional ByVal showClearButton As Boolean = True, Optional accessory As HACode = HACode.None)
            BindPersonRepositoryLookup(cb, defaultFilterHandler, AddressOf ClearDefaultFilter, showClearButton, accessory)
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     defaultFilterHandler As EventHandler,
                                                     clearFilterHandler As EventHandler,
                                                     Optional ByVal showClearButton As Boolean = True, Optional accessory As HACode = HACode.None)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("FullName", "colPersonFullName", 200),
                                                             New BvLookupColumnInfo("Organization", "strOrganization",
                                                                                    80),
                                                             New BvLookupColumnInfo("Position", "colPosition", 50)})
            cb.PopupWidth = 400
            Dim dv As DataView = LookupCache.Get(LookupTables.Person.ToString)
            If (Not dv Is Nothing) Then
                CType(dv, LookupCacheDataView).DefaultFilter = GetDefaultHACodeFilter(accessory) + String.Format(" OR idfPerson = {0}", LookupCache.EmptyLineKey)
            End If

            SetDataSource(cb, dv, "FullName", "idfPerson", defaultFilterHandler, clearFilterHandler)
            AddPlusButton(cb)
            AddButtonClickHandler(cb, AddressOf AddPerson)
            If showClearButton Then
                AddClearButton(cb, showClearButton)
            End If
        End Sub

        Public Shared Function GetControlBindingField(ByVal ctrl As Control) As String
            If ctrl.DataBindings.Count = 0 Then Return Nothing
            Return ctrl.DataBindings(0).BindingMemberInfo.BindingField
        End Function

        Public Shared Function GetOriginalValue(ByVal row As DataRow, ByVal ColumnName As String) As Object
            If Not row Is Nothing AndAlso row.HasVersion(DataRowVersion.Original) AndAlso Not (ColumnName Is Nothing) _
                Then
                Return row(ColumnName, DataRowVersion.Original)
            End If
            Return DBNull.Value
        End Function

        Public Shared Function GetBindedValue(ByVal lookup As LookUpEditBase) As Object
            If lookup.DataBindings.Count > 0 Then
                If Not lookup.DataBindings(0).BindingManagerBase Is Nothing Then
                    If lookup.DataBindings(0).BindingManagerBase.Position >= 0 Then
                        Dim row As DataRowView = CType(lookup.DataBindings(0).BindingManagerBase.Current, DataRowView)
                        If Not row Is Nothing Then
                            If row.Row.Table.Columns.Contains(lookup.DataBindings(0).BindingMemberInfo.BindingField) _
                                Then
                                Return row(lookup.DataBindings(0).BindingMemberInfo.BindingField)
                            End If
                        End If
                    End If
                ElseIf TypeOf (lookup.DataBindings(0).DataSource) Is DataSet Then
                    Dim ds As DataSet = CType(lookup.DataBindings(0).DataSource, DataSet)
                    If Not ds Is Nothing Then
                        If ds.Tables.Contains(lookup.DataBindings(0).BindingMemberInfo.BindingPath) Then
                            If ds.Tables(lookup.DataBindings(0).BindingMemberInfo.BindingPath).Rows.Count > 0 Then
                                Dim row As DataRow =
                                        ds.Tables(lookup.DataBindings(0).BindingMemberInfo.BindingPath).Rows(0)
                                If row.Table.Columns.Contains(lookup.DataBindings(0).BindingMemberInfo.BindingField) _
                                    Then
                                    Return row(lookup.DataBindings(0).BindingMemberInfo.BindingField)
                                End If
                            End If
                        End If
                    End If
                ElseIf TypeOf (lookup.DataBindings(0).DataSource) Is DataView Then
                    Dim view As DataView = CType(lookup.DataBindings(0).DataSource, DataView)
                    If Not view Is Nothing Then
                        If view.Count > 0 Then
                            Dim row As DataRow = view(0).Row
                            If row.Table.Columns.Contains(lookup.DataBindings(0).BindingMemberInfo.BindingField) Then
                                Return row(lookup.DataBindings(0).BindingMemberInfo.BindingField)
                            End If
                        End If
                    End If
                End If
            End If
            Return Nothing
        End Function


        Public Shared Sub SetPersonFilter(ByVal cbOrganisation As LookUpEdit, ByVal cbPerson As LookUpEdit)
            If cbOrganisation.DataBindings.Count = 0 Then Exit Sub
            SetPersonFilter(
                BaseForm.GetControlCurrentRow(cbOrganisation),
                GetControlBindingField(cbOrganisation),
                cbPerson)
        End Sub

        Public Shared Sub SetPersonFilter(ByVal organizationRow As DataRow, ByVal organizationColumn As String,
                                          ByVal cbPerson As LookUpEdit, Optional ByVal softLink As Boolean = False,
                                          Optional isRepository As Boolean = False)
            If cbPerson.Properties.DataSource Is Nothing Then
                Return
            End If
            Dim filter As String = ""
            If organizationRow Is Nothing Then
                CType(cbPerson.Properties.DataSource, DataView).RowFilter = String.Format("idfPerson = {0}",
                                                                                          LookupCache.EmptyLineKey)
                cbPerson.EditValue = DBNull.Value
            Else
                Dim currentOrg As String = Utils.Str(organizationRow(organizationColumn), "-1")
                Dim originalOrg As String = Utils.Str(GetOriginalValue(organizationRow, organizationColumn), "-1")
                If softLink AndAlso currentOrg = "-1" Then
                    filter = ""
                Else
                    Dim val As Object = GetBindedValue(cbPerson)
                    If Not Utils.IsEmpty(val) Then
                        filter =
                            String.Format(
                                "(idfOffice = {0} and intRowStatus = 0 ) or idfPerson = {1} or idfPerson = {2}",
                                currentOrg, val, LookupCache.EmptyLineKey)
                    Else
                        filter = String.Format("(idfOffice = {0} and intRowStatus = 0) or idfPerson = {1}", currentOrg,
                                               LookupCache.EmptyLineKey)
                    End If
                End If

                If Not Utils.IsEmpty(cbPerson.EditValue) Then
                    Dim valueExist As Boolean = False
                    For Each row As DataRowView In CType(cbPerson.Properties.DataSource, DataView)
                        If row("idfPerson").Equals(cbPerson.EditValue) Then
                            valueExist = True
                            Exit For
                        End If
                    Next
                    If Not valueExist Then
                        cbPerson.EditValue = DBNull.Value
                    End If
                End If
            End If
            SetDefaultFilter(cbPerson, filter, isRepository)
            cbPerson.Properties.ReadOnly = CType(cbPerson.Properties.DataSource, DataView).Count <= 1
        End Sub

        Public Shared Sub SetPersonFilter(ByVal cbPerson As LookUpEdit)
            If cbPerson.Properties.DataSource Is Nothing Then
                Return
            End If
            Dim filter As String = String.Format("((intRowStatus = 0 and idfOffice = {0}) or idfPerson={1})",
                                                 EidssSiteContext.Instance.OrganizationID,
                                                 EidssUserContext.User.EmployeeID)
            If (cbPerson.DataBindings.Count > 0) Then
                Dim row As DataRow = BaseForm.GetControlCurrentRow(cbPerson)
                Dim columnName As String = GetControlBindingField(cbPerson)
                filter = filter + " or idfPerson=" + Utils.Str(GetOriginalValue(row, columnName), "-1")
            End If
            SetDefaultFilter(cbPerson, filter, False)
            cbPerson.Enabled = CType(cbPerson.Properties.DataSource, DataView).Count > 1
        End Sub


        Private Shared Sub AddOrganization(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        If _
                            Not _
                            EidssUserContext.User.HasPermission(
                                PermissionHelper.InsertPermission(EIDSSPermissionObject.Organization)) Then
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission",
                                                            "You have no rights to create this object"))
                            Return
                        End If
                        Dim ID As Object = Nothing
                        If _
                            BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("OrganizationDetail"), BaseForm),
                                                      CType(sender, Control).FindForm(), ID, Nothing, Nothing) Then
                            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                            'LookupCache.Fill(LookupCache.LookupTables(LookupTables.Organization.ToString), True)
                            If (TypeOf (cb.Properties.DataSource) Is LookupCacheDataView) Then
                                LookUpSetFilter(cb.Properties.DataSource, cb.Properties.ValueMember, ID,
                                                CType(cb.Properties.DataSource, LookupCacheDataView).DefaultFilter)
                            End If
                            cb.EditValue = ID
                            If (TypeOf (cb.Parent) Is GridControl) Then
                                UpdateFocusedCellValue(
                                    CType(CType(cb.Parent, GridControl).FocusedView, ColumnView).FocusedColumn, ID)
                            End If
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub SearchOrganization(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Glyph Then
                        Dim haCode As Integer = 0
                        If (Not e.Button.Tag Is Nothing) Then
                            haCode = TagHelper.ToInt(e.Button.Tag)
                        End If
                        Dim filter As New FilterParams()
                        filter.Add("intHACode", "&", haCode)
                        Dim orgList As IBaseListPanel = CType(ClassLoader.LoadClass("OrganizationListPanel"),
                                                              IBaseListPanel)
                        orgList.InitialSearchFilter = filter
                        Dim bo As IObject = BaseFormManager.ShowForSelection(orgList, CType(sender, Control).FindForm())
                        If Not bo Is Nothing Then
                            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                            If (TypeOf (cb.Properties.DataSource) Is LookupCacheDataView) Then 'usual lookup
                                LookUpSetFilter(cb.Properties.DataSource, cb.Properties.ValueMember, bo.Key,
                                                CType(cb.Properties.DataSource, LookupCacheDataView).DefaultFilter)
                            End If
                            cb.EditValue = bo.Key
                            If (TypeOf (cb.Parent) Is GridControl) Then
                                UpdateFocusedCellValue(
                                    CType(CType(cb.Parent, GridControl).FocusedView, ColumnView).FocusedColumn, bo.Key)
                            End If
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub UpdateFocusedCellValue(ByVal col As GridColumn, val As Object)
            Dim row As DataRow = col.View.GetFocusedDataRow()
            If row Is Nothing Then
                Return
            End If
            row(col.FieldName) = val
            col.View.HideEditor()
            Dim newCol As GridColumn = Nothing
            If (col.VisibleIndex > 1) Then
                newCol = col.View.VisibleColumns(col.VisibleIndex - 1)
            ElseIf col.VisibleIndex < col.View.VisibleColumns.Count - 1 Then
                newCol = col.View.VisibleColumns(col.View.VisibleColumns.Count - 1)
            End If
            If (Not newCol Is Nothing) Then
                col.View.FocusedColumn = newCol
            End If
            Application.DoEvents()
            col.View.FocusedColumn = col
        End Sub

        Private Shared Sub AddOrganizationSearchButton(ByVal buttons As EditorButtonCollection, haCode As HACode)
            For Each b As EditorButton In buttons
                If b.Kind = ButtonPredefines.Glyph Then
                    b.Tag = CInt(haCode)
                    Return
                End If
            Next
            Dim btn As New EditorButton(ButtonPredefines.Glyph)
            btn.Tag = CInt(haCode)
            btn.Image = Browse5
            btn.ToolTip = EidssMessages.Get("msgFindOrganization", "Find Organization")
            buttons.Add(btn)
        End Sub

        Public Shared Sub BindOrganizationLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                                 ByVal bindField As String, haCode As HACode)
            BindOrganizationLookup(cb, dataSource, bindField, haCode, True)
        End Sub

        Public Shared Sub BindOrganizationLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                                 ByVal bindField As String, haCode As HACode,
                                                 ByVal showPlusButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name",
                                                                                               "colOrganizationShortName",
                                                                                               150),
                                                                        New BvLookupColumnInfo("FullName",
                                                                                               "strOrganization", 200)})
            cb.Properties.PopupWidth = 350
            SetDataSource(cb, LookupCache.Get(LookupTables.Organization.ToString), "name", "idfInstitution")
            AddOrganizationSearchButton(cb.Properties.Buttons, haCode)
            AddButtonClickHandler(cb, AddressOf SearchOrganization)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddOrganization"))
                AddButtonClickHandler(cb, AddressOf AddOrganization)
            End If
            Dim defaultFilter As String = GetDefaultHACodeFilter(haCode)
            AddBinding(cb, dataSource, bindField, False, defaultFilter)
        End Sub

        Private Shared Sub AppendOrFilter(ByRef filter As String, filterPart As String)
            If (Utils.IsEmpty(filter)) Then
                filter = String.Format("({0})", filterPart)
            Else
                filter = String.Format("{0} OR ({1})", filter, filterPart)
            End If
        End Sub

        Private Shared Function GetDefaultHACodeFilter(ByVal haCode As HACode) As String
            Dim defaultFilter As String = ""
            If (haCode And haCode.Human) > 0 Then
                AppendOrFilter(defaultFilter, "blnHuman = 1")
            End If
            If (haCode And haCode.Avian) > 0 Then
                AppendOrFilter(defaultFilter, "blnAvian = 1")
            End If
            If (haCode And haCode.Livestock) > 0 Then
                AppendOrFilter(defaultFilter, "blnLivestock = 1")
            End If
            If (haCode And haCode.Vector) > 0 Then
                AppendOrFilter(defaultFilter, "blnVector = 1")
            End If
            If (haCode And haCode.Syndromic) > 0 Then
                AppendOrFilter(defaultFilter, "blnSyndromic = 1")
            End If
            AppendOrFilter(Nothing, defaultFilter) 'set brackets around entire filter
            Return defaultFilter
        End Function

        Public Shared Sub BindOrganizationRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit, haCode As HACode,
                                                           Optional ByVal showPlusButton As Boolean = True,
                                                           Optional ByVal ShowClearButton As Boolean = False)
            BindOrganizationRepositoryLookup(cb, "idfInstitution", haCode, showPlusButton, ShowClearButton)
        End Sub

        Public Shared Sub BindOrganizationRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                           ByVal valueMember As String, haCode As HACode,
                                                           Optional ByVal showPlusButton As Boolean = True,
                                                           Optional ByVal ShowClearButton As Boolean = False)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colOrganizationShortName",
                                                                                    150),
                                                             New BvLookupColumnInfo("FullName", "strOrganization", 200)})
            cb.PopupWidth = 350
            'Dim tag As TagHelper = TagHelper.GetTagHelper(cb)
            Dim view As DataView = LookupCache.Get(LookupTables.Organization.ToString)
            If (Not view Is Nothing) Then
                CType(view, LookupCacheDataView).DefaultFilter = GetDefaultHACodeFilter(haCode)
            End If

            SetDataSource(cb, view, "name", valueMember, AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter)
            AddOrganizationSearchButton(cb.Buttons, haCode)
            AddButtonClickHandler(cb, AddressOf SearchOrganization)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddOrganization"))
                AddButtonClickHandler(cb, AddressOf AddOrganization)
            End If
            If ShowClearButton Then
                AddClearButton(cb, ShowClearButton)
            End If
        End Sub


        Private Shared Function GetDiagnosisHACode(ByVal DiagnosisType As LookupTables) As Integer
            Dim code As Integer = HACode.None
            Try
                Dim t As LookupTableInfo = LookupCache.LookupTables(DiagnosisType.ToString())
                Dim stored As Object = t.Parameters("@HACode")
                If (TypeOf (stored) Is HACode) Then
                    code = CType(stored, Integer)
                Else
                    code = Integer.Parse(stored.ToString())
                End If
            Catch
            Finally
            End Try
            Return code
        End Function

        Private Shared Sub CreateDiagnosisColumns(ByVal cb As TreeList, ByVal ShowAdditionalColumns As Boolean)
            cb.Columns.Clear()
            Dim first As TreeListColumn = cb.Columns.Add()
            first.Caption = EidssMessages.Get("DiagnosisOrDiagnosisGroup")
            first.Name = "colDiseaseName"
            first.FieldName = "name"
            first.OptionsColumn.AllowSort = False
            first.Visible = True
            first = cb.Columns.Add()
            first.Name = "intOrder"
            first.FieldName = "intOrder"
            first.Visible = False

            If (ShowAdditionalColumns = True) Then
                Dim second As TreeListColumn = cb.Columns.Add()
                second.Caption = EidssMessages.Get("colIDC10")
                second.Name = "colIDC10"
                second.FieldName = "strIDC10"
                second.OptionsColumn.AllowSort = False
                second.Visible = True
                second = cb.Columns.Add()
                second.Caption = EidssMessages.Get("colOIECode")
                second.Name = "colOIECode"
                second.FieldName = "strOIECode"
                second.OptionsColumn.AllowSort = False
                second.Visible = True
            End If
        End Sub

        Private Shared Sub CreateDiagnosisColumns(ByVal cb As RepositoryItemLookUpEdit,
                                                  ByVal ShowAdditionalColumns As Boolean)
            cb.Columns.Clear()
            cb.Columns.Add(
                New BvLookupColumnInfo("name", "colDiseaseName", 200, FormatType.None, "", True, HorzAlignment.Near)
                )

            If (ShowAdditionalColumns = True) Then
                cb.Columns.Add(
                    New BvLookupColumnInfo("strIDC10", "colIDC10", 200, FormatType.None, "", True, HorzAlignment.Near)
                    )
                cb.Columns.Add(
                    New BvLookupColumnInfo("strOIECode", "colOIECode", 200, FormatType.None, "", True,
                                           HorzAlignment.Near)
                    )
            End If
        End Sub

        Public Shared Sub BindDiagnosisLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                              Optional ByVal ShowAdditionalColumns As Boolean = True)
            CreateDiagnosisColumns(cb.Properties, ShowAdditionalColumns)
            cb.Properties.PopupWidth = 500
            SetDataSource(cb, LookupCache.Get(LookupTables.HumanVetDiagnoses), "name", "idfsDiagnosis")
            AddBinding(cb, ds, bindField)
        End Sub

        Private Shared Function InitDiagnosisTreePopup(parent As Control, showAdditionalColumns As Boolean,
                                                       value As Object) As PopupContainerControl
            Dim popup As PopupContainerControl = New PopupContainerControl
            popup.Parent = parent
            Dim cb As New TreeList
            cb.Dock = DockStyle.Fill
            cb.OptionsBehavior.AllowExpandOnDblClick = False
            cb.OptionsBehavior.Editable = False
            CreateDiagnosisColumns(cb, showAdditionalColumns)
            popup.Height = 400
            popup.Controls.Add(cb)
            SetDataSource(cb, LookupCache.Get(LookupTables.DiagnosesAndGroups), "idfsDiagnosisOrDiagnosisGroup",
                          "idfsDiagnosisGroup", value)
            cb.BeginSort()
            cb.Columns("intOrder").SortOrder = SortOrder.Ascending
            cb.EndSort()
            cb.MakeNodeVisible(cb.FocusedNode)
            RemoveHandler cb.FocusedNodeChanged, AddressOf Tree_FocusedNodeChanged
            AddHandler cb.FocusedNodeChanged, AddressOf Tree_FocusedNodeChanged
            RemoveHandler cb.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler cb.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            Return popup
        End Function

        Public Shared Function BindDiagnosisTreeLookup(ByVal cb As TreeListLookUpEdit, ByVal ds As DataSet,
                                                       ByVal bindField As String,
                                                       Optional ByVal showAdditionalColumns As Boolean = True,
                                                       Optional ByVal showClearButton As Boolean = True) As DataView
            CreateDiagnosisColumns(cb.Properties.TreeList, showAdditionalColumns)
            SetDataSource(cb, LookupCache.Get(LookupTables.DiagnosesAndGroups), "name", "idfsDiagnosisOrDiagnosisGroup",
                          "idfsDiagnosisGroup")
            AddBinding(cb, ds, bindField)
            If showClearButton Then
                AddClearButton(cb, True)
            End If
            Return CType(cb.Properties.DataSource, DataView)
        End Function


        Public Shared Sub BindDiagnosisTreeRepositoryLookup(ByVal cb As RepositoryItemTreeListLookUpEdit,
                                                            parent As Control,
                                                            Optional ByVal showAdditionalColumns As Boolean = True,
                                                            Optional ByVal showPlusButton As Boolean = True)

            CreateDiagnosisColumns(cb.TreeList, showAdditionalColumns)
            cb.PopupFormWidth = 400
            SetDataSource(cb, LookupCache.Get(LookupTables.DiagnosesAndGroups), "name", "idfsDiagnosisOrDiagnosisGroup",
                          "idfsDiagnosisGroup")
            If (showPlusButton) Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDiagnosis)
            End If
        End Sub

        Public Shared Sub BindDiagnosisAndGroupsRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                                 Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                                 Optional ByVal ShowClearButton As Boolean = True,
                                                                 Optional showPlusButton As Boolean = False)
            CreateDiagnosisColumns(cb, ShowAdditionalColumns)
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(LookupTables.DiagnosesAndGroups), "name", "idfsDiagnosisOrDiagnosisGroup",
                          AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter)
            If (showPlusButton) Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDiagnosis)
            End If
            If ShowClearButton Then
                AddClearButton(cb, True)
            End If
        End Sub

        Public Shared Sub BindDiagnosisHACodeRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                              ByVal DiagnosisType As LookupTables,
                                                              Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                              Optional ByVal ShowClearButton As Boolean = True,
                                                              Optional ByVal displayMember As String = "name",
                                                              Optional showPlusButton As Boolean = False)
            CreateDiagnosisColumns(cb, ShowAdditionalColumns)
            'cb.Columns.Clear()
            'cb.Columns.AddRange(New BvLookUpColumnInfo() { _
            'New BvLookUpColumnInfo("Name", "colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New BvLookUpColumnInfo(DiseaseCodeColumnName, CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(DiagnosisType), displayMember, "idfsDiagnosis", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If (showPlusButton) Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDiagnosis)
            End If
            If ShowClearButton Then
                AddClearButton(cb, True)
            End If
        End Sub

        Public Shared Sub BindDiagnosisHACodeLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                    ByVal diagnosisType As LookupTables, ByVal bindField As String,
                                                    Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                    Optional ByVal ShowClearButton As Boolean = True,
                                                    Optional showPlusButton As Boolean = False)
            CreateDiagnosisColumns(cb.Properties, ShowAdditionalColumns)
            'cb.Properties.Columns.AddRange(New BvLookUpColumnInfo() { _
            'New BvLookUpColumnInfo("Name", "colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New BvLookUpColumnInfo("strIDC10", CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            cb.Properties.PopupWidth = 500
            SetDataSource(cb, LookupCache.Get(diagnosisType), "name", "idfsDiagnosis")
            If (showPlusButton) Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDiagnosis)
            End If
            If ShowClearButton Then
                AddClearButton(cb, True)
            End If
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Sub BindStandardDiagnosisRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                                ByVal aHACode As HACode,
                                                                Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                                Optional ByVal DisplayMember As String = "name",
                                                                Optional ByVal AddClearBtn As Boolean = True,
                                                                Optional ByVal AddPlusBtn As Boolean = True)
            CreateDiagnosisColumns(cb, ShowAdditionalColumns)
            'cb.Columns.Clear()
            'cb.Columns.AddRange(New BvLookUpColumnInfo() { _
            'New BvLookUpColumnInfo("Name", "colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New BvLookUpColumnInfo(DiseaseCodeColumnName, CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            HACodeValue(cb) = aHACode
            cb.PopupWidth = 400
            Dim dv As DataView = Nothing
            If (aHACode And HACode.Human) <> 0 Then
                dv = LookupCache.Get(LookupTables.HumanStandardDiagnosis)
            ElseIf (aHACode And HACode.Avian And HACode.Livestock) = (HACode.Avian Or HACode.Livestock) Then
                dv = LookupCache.Get(LookupTables.VetStandardDiagnosis)
            ElseIf (aHACode And HACode.Avian) <> 0 Then
                dv = LookupCache.Get(LookupTables.AvianStandardDiagnosis)
            ElseIf (aHACode And HACode.Livestock) <> 0 Then
                dv = LookupCache.Get(LookupTables.LivestockStandardDiagnosis)
            End If
            SetDataSource(cb, dv, DisplayMember, "idfsDiagnosis", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If AddPlusBtn Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDiagnosis)
            End If
            If AddClearBtn Then AddClearButton(cb)
        End Sub


        Public Shared Sub BindAnimalAgeRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                        Optional ByVal showPlusButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            LookupTableID(cb) = db.BaseReferenceType.rftAnimalAgeList
            SetDataSource(cb, LookupCache.Get(LookupTables.AnimalAgeList), "name", "idfsReference",
                          AddressOf cbAnimalAge_SetFilter, AddressOf ClearDefaultFilter)
            RemoveDefaultFilterHandlers(cb)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddBaseReference)
            End If
            AddClearButton(cb)
        End Sub

        Private Shared Function GetBoundDataRow(cb As LookUpEdit) As DataRow
            Return CType(CType(cb.Parent, GridControl).MainView, GridView).GetFocusedDataRow()
        End Function

        Private Shared Sub cbAnimalAge_SetFilter(ByVal sender As Object, ByVal e As EventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim row As DataRow = GetBoundDataRow(cb)
            Dim filter As String
            Dim speciesType As Long
            If row Is Nothing OrElse Utils.IsEmpty(row("idfsSpeciesType")) Then
                speciesType = - 1L
            Else
                speciesType = CLng(row("idfsSpeciesType"))
            End If

            If Not Utils.IsEmpty(cb.EditValue) Then
                filter = String.Format("(intRowStatus = 0 and idfsSpeciesType = {0} and idfsReference = {1})",
                                       speciesType, cb.EditValue)
                If CType(cb.Properties.DataSource, DataView).Table.Select(filter).Length > 0 Then
                    filter = String.Format("(intRowStatus = 0 and idfsSpeciesType = {0}) or idfsReference = {1}",
                                           speciesType, LookupCache.EmptyLineKey)
                Else
                    filter = String.Format("idfsReference = {0})", cb.EditValue)
                    Dim rows() As DataRow = CType(cb.Properties.DataSource, DataView).Table.Select(filter)
                    If rows.Length > 0 Then
                        filter =
                            String.Format(
                                "(intRowStatus = 0 and idfsSpeciesType = {0}) or idfsReference = {1} or idfRowNumber = {2}",
                                speciesType, LookupCache.EmptyLineKey, rows(0)("idfRowNumber"))
                    Else
                        filter = String.Format("((intRowStatus = 0 and idfsSpeciesType = {1}) or idfsReference = {0})",
                                               LookupCache.EmptyLineKey, speciesType)
                    End If
                End If
            Else
                filter = String.Format("((intRowStatus = 0 and idfsSpeciesType = {1}) or idfsReference = {0})",
                                       LookupCache.EmptyLineKey, speciesType)
            End If
            SetDefaultFilter(cb, filter, True)
            CType(cb.Properties.DataSource, DataView).Sort = "idfsReference"
            If Not Utils.IsEmpty(cb.EditValue) AndAlso CType(cb.Properties.DataSource, DataView).Find(cb.EditValue) < 0 _
                Then
                cb.EditValue = DBNull.Value
            End If
            CType(cb.Properties.DataSource, DataView).Sort = Nothing
        End Sub

        Public Shared Sub BindDepartmentLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                               Optional ByVal showPlusButton As Boolean = True)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name",
                                                                                               "colDepartmentName", 200)})
            cb.Properties.PopupWidth = cb.Width
            SetDataSource(cb, LookupCache.Get(LookupTables.Department), "name", "idfDepartment")
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDepartment)
            End If
            AddBinding(cb, ds, bindField, True)
        End Sub

        Public Shared Sub BindDepartmentRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                         Optional ByVal showPlusButton As Boolean = False)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colDepartmentName", 200)})
            cb.PopupWidth = 400
            Dim view As DataView = LookupCache.Get(LookupTables.Department)
            SetDataSource(cb, view, "name", "idfDepartment", AddressOf cbDepartment_SetFilter,
                          AddressOf ClearDefaultFilter)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDepartment)
            End If
            AddClearButton(cb)
        End Sub

        Private Shared Sub cbDepartment_SetFilter(ByVal sender As Object, ByVal e As EventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim filter As String
            If Not cb.EditValue Is DBNull.Value Then
                filter = String.Format("idfInstitution = {0} and (intRowStatus = 0 or idfDepartment={1}) ",
                                       EidssSiteContext.Instance.OrganizationID, cb.EditValue)
            Else
                filter = String.Format("idfInstitution = {0} and intRowStatus = 0",
                                       EidssSiteContext.Instance.OrganizationID)
            End If
            SetDefaultFilter(cb, filter, True)
        End Sub


        Private Shared Sub AddDepartment(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim ID As Object = Nothing
                        Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                        Dim ParentID As Object =
                                GetParentIDFromRowFilter(CType(cb.Properties.DataSource, DataView).RowFilter)
                        Dim startupParams As New Dictionary(Of String, Object)
                        If (Not ParentID Is Nothing) Then
                            startupParams.Add("OrganizationID", ParentID)
                        End If
                        If _
                            BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("DepartmentDetail"), BaseForm),
                                                      cb.FindForm(), ID, Nothing, startupParams) Then
                            cb.EditValue = ID
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Public Shared Sub BindTestResultRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                         Optional ByVal showClearButton As Boolean = False,
                                                         Optional useDefaultFilter As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("name", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            LookupTableID(cb) = db.BaseReferenceType.rftTestResult
            If useDefaultFilter Then
                SetDataSource(cb, LookupCache.Get(LookupTables.TestResult), "name", "idfsReference",
                              AddressOf cbTestResult_SetFilter, AddressOf ClearDefaultFilter)
            Else
                SetDataSource(cb, LookupCache.Get(LookupTables.TestResult), "name", "idfsReference", Nothing, Nothing)
            End If
            AddPlusButton(cb)
            AddButtonClickHandler(cb, AddressOf AddBaseReference)
            If (showClearButton) Then
                AddClearButton(cb, True)
            End If
        End Sub

        Private Shared Sub cbTestResult_SetFilter(ByVal sender As Object, ByVal e As EventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim row As DataRow = GetBoundDataRow(cb)
            Dim filter As String
            If row Is Nothing OrElse row("idfsTestName") Is DBNull.Value Then
                filter = "idfsTestName = -1"
            ElseIf Not row("idfsTestResult") Is DBNull.Value Then
                filter =
                    String.Format(
                        "((intRowStatus = 0 or idfsReference = {1}) and idfsTestName = {0}) or idfsReference ={2}",
                        row("idfsTestName"), row("idfsTestResult"), LookupCache.EmptyLineKey)
            Else
                filter = String.Format("(intRowStatus = 0 and idfsTestName = {0}) or idfsReference = {1}",
                                       row("idfsTestName"), LookupCache.EmptyLineKey)
            End If
            SetDefaultFilter(cb, filter, True)
        End Sub

        Public Shared Sub BindTestResultLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                               ByVal bindField As String, defaultFilter As String)
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = 400
            LookupTableID(cb) = db.BaseReferenceType.rftTestResult
            Dim ds As DataSet = Nothing
            If Not dataSource Is Nothing Then
                If TypeOf dataSource Is DataView Then
                    ds = CType(dataSource, DataView).Table.DataSet
                ElseIf TypeOf (dataSource) Is DataSet Then
                    ds = CType(dataSource, DataSet)
                Else
                    Throw New Exception("unsupported datasource type")
                End If
            End If
            SetDataSource(cb, LookupCache.Get(LookupTables.TestResult), "name", "idfsReference")
            AddPlusButton(cb)
            AddButtonClickHandler(cb, AddressOf AddBaseReference)

            AddBinding(cb, ds, bindField, False, defaultFilter)
        End Sub

        'Public Shared Sub BindPatientRepositoryLookup(ByVal cb As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Columns.Clear()
        '    cb.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("PatientName", "colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Patient), "PatientName", ValueMember)
        'End Sub

        'Public Shared Sub BindPatientLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("PatientName", "colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.Properties.PopupWidth = 400
        '    Dim ds As DataSet = Nothing
        '    If TypeOf dataSource Is DataView Then
        '        ds = CType(dataSource, DataView).Table.DataSet
        '    ElseIf TypeOf (dataSource) Is DataSet Then
        '        ds = CType(dataSource, DataSet)
        '    Else
        '        Throw New Exception("unsupported datasource type")
        '    End If
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Patient), "PatientName", ValueMember)
        '    Core.LookupBinder.AddBinding(cb, ds, bindField, False)
        'End Sub

        'Public Shared Sub BindPatientAdditionalInfoRepositoryLookup(ByVal cb As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Columns.Clear()
        '    cb.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("PatientInformation", "colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.PatientAdditionalInfo), "PatientInformation", ValueMember)
        'End Sub

        'Public Shared Sub BindPatientAdditionalInfoLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("PatientInformation", "colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.Properties.PopupWidth = 400
        '    Dim ds As DataSet = Nothing
        '    If TypeOf dataSource Is DataView Then
        '        ds = CType(dataSource, DataView).Table.DataSet
        '    ElseIf TypeOf (dataSource) Is DataSet Then
        '        ds = CType(dataSource, DataSet)
        '    Else
        '        Throw New Exception("unsupported datasource type")
        '    End If
        '    SetDataSource(cb, LookupCache.Get(LookupTables.PatientAdditionalInfo), "PatientInformation", ValueMember)
        '    Core.LookupBinder.AddBinding(cb, ds, bindField, False)
        'End Sub

        Public Shared Sub BindOutbreakLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                             ByVal bindField As String)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strOutbreakID",
                                                                                               "colOutbreakID", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)})
            cb.Properties.PopupWidth = 350
            Dim ds As DataSet
            If TypeOf dataSource Is DataView Then
                ds = CType(dataSource, DataView).Table.DataSet
            ElseIf TypeOf (dataSource) Is DataSet Then
                ds = CType(dataSource, DataSet)
            Else
                Throw New Exception("unsupported datasource type")
            End If
            SetDataSource(cb, LookupCache.Get(LookupTables.Outbreak), "strOutbreakID", "idfOutbreak")
            AddBinding(cb, dataSource, bindField)
        End Sub

        Public Shared Sub AddQuery(ByVal sender As Object, ByVal e As EventArgs)
            If Not TypeOf (sender) Is Control Then
                Return
            End If
            Dim th As TagHelper = TagHelper.GetTagHelper(CType(sender, Control))
            If (th Is Nothing) Then
                Return
            End If
            If Not TypeOf (th.Tag) Is LookUpEdit Then
                Return
            End If
            ShowRAMQueryEditor(CType(th.Tag, LookUpEdit))
        End Sub

        Private Shared Sub ShowRAMQueryEditor(ByVal cb As LookUpEdit)
            Dim ID As Object = Nothing
            Dim objBF As Object = ClassLoader.LoadClass("QueryDetail")
            If ((objBF Is Nothing) OrElse (Not TypeOf (objBF) Is BaseDetailForm)) Then
                Throw New Exception("Can't load QueryDetail form")
            End If
            Dim bf As BaseDetailForm = CType(objBF, BaseDetailForm)
            If BaseFormManager.ShowModal(bf, cb.FindForm(), ID, Nothing, Nothing) Then
                'LookupCache.Fill(LookupCache.LookupTables(LookupTables.Query.ToString()), True)
                cb.EditValue = ID
            End If
        End Sub

        Private Shared Sub AddQuery(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If (Not TypeOf (sender) Is LookUpEdit) Then
                Return
            End If
            If CType(sender, LookUpEdit).Properties.ReadOnly Then
                Return
            End If

            If (e.Button.Kind = ButtonPredefines.Plus) Then
                If ActionLocker.LockAction(sender) Then

                    Try
                        ShowRAMQueryEditor(CType(sender, LookUpEdit))
                    Finally
                        ActionLocker.UnlockAction(sender)
                    End Try
                End If
            End If
        End Sub


        Public Shared Sub BindQueryLookup(ByVal cb As LookUpEdit, ByVal showAllItems As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("QueryName",
                                                                                               "colQueryName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = cb.Width
            cb.DataBindings.Clear()

            SetDataSource(cb, GetQueryDataView(showAllItems), "QueryName", "idflQuery")
            AddButtonClickHandler(cb, AddressOf AddQuery)
        End Sub

        Public Shared Function GetQueryDataView(ByVal showAllItems As Boolean) As DataView


            Dim id As String = LookupTables.QueryToSystemFunction.ToString()
            Dim queryToPermissions As DataView = LookupCache.Get(id)
            If queryToPermissions Is Nothing Then
                Throw _
                    New ApplicationException(
                        String.Format("Lookup table {0} is not filled. Please check connection to the DataBase", id))
            End If


            Dim permissionList As List(Of EIDSSPermissionObject) = New List(Of EIDSSPermissionObject)
            Dim permissionTable As DataTable = queryToPermissions.ToTable(True, "idfsSystemFunction")
            For Each row As DataRow In permissionTable.Rows
                Dim value As Object = row(0)
                If [Enum].IsDefined(GetType(EIDSSPermissionObject), value) Then
                    Dim permission As EIDSSPermissionObject = CType(value, EIDSSPermissionObject)
                    If HasNoPermission(permission) Then
                        permissionList.Add(permission)
                    End If
                End If
            Next

            Dim queryIdList As List(Of Long) = New List(Of Long)
            For Each permission As EIDSSPermissionObject In permissionList
                queryToPermissions.RowFilter = "idfsSystemFunction=" + CLng(permission).ToString()

                For Each rowView As DataRowView In queryToPermissions
                    Dim queryId As Long = CLng(rowView("idflQuery"))
                    If Not queryIdList.Contains(queryId) Then
                        queryIdList.Add(queryId)
                    End If
                Next
            Next

            Dim sbFilter As StringBuilder = New StringBuilder()
            If (queryIdList.Count > 0) Then
                sbFilter.Append("idflQuery NOT IN (")
                Dim firstTime As Boolean = True
                For Each queryId As Long In queryIdList
                    If (Not firstTime) Then
                        sbFilter.Append(", ")
                    End If
                    sbFilter.Append(queryId)
                    firstTime = False
                Next
                sbFilter.Append(")")
            End If

            If showAllItems = False Then
                If (sbFilter.Length > 0) Then
                    sbFilter.Append(" AND (blnReadOnly = 1)")
                Else
                    sbFilter.Append(" (blnReadOnly = 1) ")
                End If
            End If

            Dim tableID As String = LookupTables.Query.ToString()
            Dim dv As DataView = LookupCache.Get(tableID)
            If dv Is Nothing Then
                Throw _
                    New ApplicationException(
                        String.Format("Lookup table {0} is not filled. Please check connection to the DataBase", tableID))
            End If

            dv.RowFilter = sbFilter.ToString
            Return dv
        End Function

        Private Shared Function HasNoPermission(ByVal permissionObject As EIDSSPermissionObject) As Boolean
            Return Not EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(permissionObject))
        End Function

        Public Shared Sub BindSearchFieldLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                                ByVal ShowClearButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("FieldCaption",
                                                                                               "colFieldName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            cb.Properties.PopupWidth = cb.Width

            SetDataSource(cb, LookupCache.Get(LookupTables.SearchField.ToString()), "FieldCaption", "idfsSearchField")
            AddBinding(cb, ds, bindField, ShowClearButton)
        End Sub

        Public Shared Sub BindSearchFieldLookup(ByVal lbc As ListBoxControl)
            lbc.Items.Clear()
            Dim dv As DataView = LookupCache.Get(LookupTables.SearchField)
            If dv Is Nothing Then
                Return
            End If
            If (dv.Table.Columns.Contains("blnAvailable") = False) Then
                Dim colAvailable As DataColumn = New DataColumn("blnAvailable", GetType(Boolean))
                dv.Table.Columns.Add(colAvailable)
                For Each r As DataRow In dv.Table.Rows
                    r("blnAvailable") = 1
                Next
            End If
            dv.RowFilter = "blnAvailable = 1"
            dv.Sort = "FieldCaption"
            dv.RowStateFilter = DataViewRowState.CurrentRows
            SetDataSource(lbc, dv, "FieldCaption", "idfsSearchField")
            lbc.DataBindings.Clear()
        End Sub

        Public Shared Sub BindSearchFieldLookup(ByVal imlbc As ImageListBoxControl)
            imlbc.Items.Clear()
            Dim dv As DataView = LookupCache.Get(LookupTables.SearchField)
            If dv Is Nothing Then
                Return
            End If
            If (dv.Table.Columns.Contains("blnAvailable") = False) Then
                Dim colAvailable As DataColumn = New DataColumn("blnAvailable", GetType(Boolean))
                dv.Table.Columns.Add(colAvailable)
                For Each r As DataRow In dv.Table.Rows
                    r("blnAvailable") = 1
                Next
            End If
            dv.RowFilter = "blnAvailable = 1"
            dv.Sort = "FieldCaption"
            dv.RowStateFilter = DataViewRowState.CurrentRows
            SetDataSource(imlbc, dv, "FieldCaption", "idfsSearchField", "TypeImageIndex")
            imlbc.DataBindings.Clear()
        End Sub

        Public Shared Sub BindParameterForFFTypeLookup(ByVal lbc As ListBoxControl)
            lbc.Items.Clear()
            Dim dv As DataView = LookupCache.Get(LookupTables.ParameterForFFType)
            If (dv Is Nothing) OrElse (dv.Table Is Nothing) Then
                Return
            End If
            If (dv.Table.PrimaryKey Is Nothing) OrElse
               (dv.Table.PrimaryKey.Length <> 1) OrElse
               (dv.Table.PrimaryKey(0).ColumnName <> "FieldAlias") Then
                dv.Table.PrimaryKey = Nothing
                If dv.Table.Columns.Contains("FieldAlias") Then
                    dv.Table.Columns("FieldAlias").AllowDBNull = False
                    dv.Table.PrimaryKey = New DataColumn() {dv.Table.Columns("FieldAlias")}
                End If
            End If

            If (dv.Table.Columns.Contains("blnAvailable") = False) Then
                Dim colAvailable As DataColumn = New DataColumn("blnAvailable", GetType(Boolean))
                dv.Table.Columns.Add(colAvailable)
                For Each r As DataRow In dv.Table.Rows
                    r("blnAvailable") = 1
                Next
            End If
            dv.RowFilter = "blnAvailable = 1"
            dv.Sort = "ParameterName"
            dv.RowStateFilter = DataViewRowState.CurrentRows
            SetDataSource(lbc, dv, "ParameterName", "idfsParameter")
            lbc.DataBindings.Clear()
        End Sub

        Public Shared Sub BindParameterForFFTypeLookup(ByVal imlbc As ImageListBoxControl)
            imlbc.Items.Clear()
            Dim dv As DataView = LookupCache.Get(LookupTables.ParameterForFFType)
            If (dv Is Nothing) OrElse (dv.Table Is Nothing) Then
                Return
            End If
            If (dv.Table.PrimaryKey Is Nothing) OrElse
               (dv.Table.PrimaryKey.Length <> 1) OrElse
               (dv.Table.PrimaryKey(0).ColumnName <> "FieldAlias") Then
                dv.Table.PrimaryKey = Nothing
                If dv.Table.Columns.Contains("FieldAlias") Then
                    dv.Table.Columns("FieldAlias").AllowDBNull = False
                    dv.Table.PrimaryKey = New DataColumn() {dv.Table.Columns("FieldAlias")}
                End If
            End If

            If (dv.Table.Columns.Contains("blnAvailable") = False) Then
                Dim colAvailable As DataColumn = New DataColumn("blnAvailable", GetType(Boolean))
                dv.Table.Columns.Add(colAvailable)
                For Each r As DataRow In dv.Table.Rows
                    r("blnAvailable") = 1
                Next
            End If
            dv.RowFilter = "blnAvailable = 1"
            dv.Sort = "ParameterName"
            dv.RowStateFilter = DataViewRowState.CurrentRows
            SetDataSource(imlbc, dv, "ParameterName", "idfsParameter", "TypeImageIndex")
            imlbc.DataBindings.Clear()
        End Sub


        Public Shared Sub BindQuerySearchFieldLookup(ByVal cb As LookUpEdit, ByVal dv As DataView, ByVal ds As DataSet,
                                                     ByVal bindField As String, ByVal ShowClearButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("FieldCaption",
                                                                                               "colFieldName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            cb.Properties.PopupWidth = cb.Width
            If ((dv Is Nothing) OrElse (dv.Table Is Nothing) OrElse
                (Not dv.Table.Columns.Contains("idfnQuerySearchField")) OrElse
                (Not dv.Table.Columns.Contains("FieldCaption"))) Then
                dv = LookupCache.Get(LookupTables.QuerySearchField.ToString())
            End If
            SetDataSource(cb, dv, "FieldCaption", "idfnQuerySearchField")
            If ((Not Utils.IsEmpty(bindField)) OrElse (ShowClearButton = True)) Then
                AddBinding(cb, ds, bindField, ShowClearButton)
            Else
                cb.DataBindings.Clear()
            End If
        End Sub

        'Public Shared Sub BindSearchCriteriaLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String, ByVal ShowClearButton As Boolean)
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("strCriteriaText", "colCriteria", "Criteria"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.Properties.PopupWidth = cb.Width

        '    SetDataSource(cb, LookupCache.Get(LookupTables.SearchCriteria.ToString()), "strCriteriaText", "idfSearchCriteria")
        '    If ((Not Utils.IsEmpty(bindField)) OrElse (ShowClearButton = True)) Then
        '        AddBinding(cb, ds, bindField, ShowClearButton)
        '    Else
        '        cb.DataBindings.Clear()
        '    End If
        'End Sub


        Public Shared Sub BindParametersFixedPresetValueLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                               ByVal bindField As String,
                                                               ByVal ShowClearButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("name", "colName", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )

            cb.Properties.PopupWidth = cb.Width

            SetDataSource(cb, LookupCache.Get(LookupTables.ParametersFixedPresetValue.ToString()), "name",
                          "idfsReference")
            If ((Not Utils.IsEmpty(bindField)) OrElse (ShowClearButton = True)) Then
                AddBinding(cb, ds, bindField, ShowClearButton)
            Else
                cb.DataBindings.Clear()
            End If
        End Sub

        Public Shared Sub BindParametersFixedPresetValueRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                                         ByVal showClearButton As Boolean)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo("NationalName", "colName", 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(LookupTables.ParametersFixedPresetValue.ToString()), "NationalName",
                          "idfsParameterFixedPresetValue", AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter)
            If showClearButton Then
                AddClearButton(cb)
            End If
        End Sub

        'Public Shared Sub BindBaseValueLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String, ByVal tableId As BaseReferenceType, ByVal aHACode As HACode, ByVal showPlusButton As Boolean, ByVal ShowClearButton As Boolean)
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New BvLookUpColumnInfo() { _
        '        New BvLookUpColumnInfo("name", "colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    LookupTableID(cb) = tableId
        '    HACodeValue(cb) = aHACode
        '    cb.Properties.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(tableId, aHACode), "name", "idfsReference")
        '    If showPlusButton Then
        '        AddPlusButton(cb)
        '        AddButtonClickHandler(cb, AddressOf AddBaseReference)
        '    End If
        '    If ((Not Utils.IsEmpty(bindField)) OrElse (ShowClearButton = True)) Then
        '        AddBinding(cb, ds, bindField, ShowClearButton)
        '    Else
        '        cb.DataBindings.Clear()
        '    End If
        'End Sub
        Public Shared Sub BindActionBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                         ByVal tableId As LookupTables,
                                                         ByVal aHACode As HACode,
                                                         Optional ByVal actionColumnName As String = "colActionName",
                                                         Optional ByVal actionCodeFieldName As String = "strActionCode",
                                                         Optional ByVal codeColumnName As String = "colActionCode",
                                                         Optional ByVal displayMember As String = "name",
                                                         Optional ByVal valueMember As String = "idfsReference",
                                                         Optional ByVal addClearBtn As Boolean = True,
                                                         Optional ByVal addPlusBtn As Boolean = True,
                                                         Optional ByVal addActionHandler As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() { _
                                                             New BvLookupColumnInfo(displayMember, actionColumnName, 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near),
                                                             New BvLookupColumnInfo(actionCodeFieldName, codeColumnName,
                                                                                    200, FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                )
            If tableId = LookupTables.VetSanitaryAction Then
                LookupTableID(cb) = db.BaseReferenceType.rftSanitaryActionList
            ElseIf tableId = LookupTables.VetProphilacticAction Then
                LookupTableID(cb) = db.BaseReferenceType.rftProphilacticActionList
            End If
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString()), displayMember, valueMember,
                          AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter)
            If addPlusBtn Then
                AddPlusButton(cb)
                If addActionHandler Then AddButtonClickHandler(cb, AddressOf AddActionReference)
            End If
            If addClearBtn Then AddClearButton(cb)
        End Sub

        Public Shared Function ShowActionReferenceEditor(ByVal TableID As db.BaseReferenceType) As Object
            Dim ID As Object = Nothing
            Dim bf As Object = ClassLoader.LoadClass("ActionDetail")
            If bf Is Nothing Then Throw New Exception("Can't load ActionDetail form")
            Dim startUpParam As New Dictionary(Of String, Object)
            startUpParam("ReferenceType") = CLng(TableID)
            If BaseFormManager.ShowModal(CType(bf, BaseForm), BaseFormManager.MainForm, ID, Nothing, startUpParam) Then
                Return ID
            End If
            Return Nothing
        End Function

        Private Shared Sub AddActionReference(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If ActionLocker.LockAction(sender) Then

                Try
                    If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim TableID As db.BaseReferenceType = GetLookupTableID(sender)
                        Dim ID As Object = ShowActionReferenceEditor(TableID)
                        SetLookupEditValue(sender, TableID, ID)
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub SetLookupEditValue(ByVal sender As Object, ByVal TableID As [Enum], ByVal ID As Object)
            If Not ID Is Nothing Then
                Dim r As DataRow = Nothing
                Dim owner As LookUpEditBase = Nothing
                If TypeOf sender Is RepositoryItemLookUpEdit Then
                    Dim cb As RepositoryItemLookUpEdit = CType(sender, RepositoryItemLookUpEdit)
                    r = CType(cb.DataSource, DataView).Table.Rows.Find(ID)
                    If r Is Nothing Then
                        LookupCache.Refresh(TableID, 0, False)
                        r = CType(cb.DataSource, DataView).Table.Rows.Find(ID)
                    End If
                    owner = cb.OwnerEdit
                ElseIf TypeOf sender Is LookUpEditBase Then
                    Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
                    owner = cb
                    r = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID)
                    If r Is Nothing Then
                        LookupCache.Refresh(TableID, 0, False)
                        r = CType(cb.Properties.DataSource, DataView).Table.Rows.Find(ID)
                    End If
                End If
                If Not owner Is Nothing Then
                    If r Is Nothing Then
                        owner.EditValue = DBNull.Value
                    Else
                        owner.EditValue = ID
                    End If
                    If Not owner.Parent Is Nothing AndAlso TypeOf (owner.Parent) Is GridControl Then
                        CType(owner.Parent, GridControl).FocusedView.PostEditor()
                    Else
                        DataEventManager.SubmitCurrentEdit(owner)
                    End If
                End If
            End If
        End Sub

        Private Shared Function CreateSiteLookupColumns() As BvLookupColumnInfo()
            Return New BvLookupColumnInfo() { _
                                                New BvLookupColumnInfo("strSiteID", "colSiteID", 70, FormatType.None, "",
                                                                       True, HorzAlignment.Near),
                                                New BvLookupColumnInfo("strSiteType", "colSiteType", 70, FormatType.None,
                                                                       "", True, HorzAlignment.Near),
                                                New BvLookupColumnInfo("strSiteName", "colSiteName", 260,
                                                                       FormatType.None, "", True, HorzAlignment.Near)}
        End Function

        Public Shared Sub BindSiteLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         Optional ByVal ShowClearButton As Boolean = True)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(CreateSiteLookupColumns())
            cb.Properties.ShowHeader = True
            cb.Properties.PopupWidth = 400

            SetDataSource(cb, LookupCache.Get(LookupTables.Site), "strSiteName", "idfsSite")

            AddBinding(cb, ds, bindField, ShowClearButton)
        End Sub

        Public Shared Sub BindSiteRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   Optional ByVal showClearButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(CreateSiteLookupColumns())
            cb.ShowHeader = True
            cb.PopupWidth = 400

            SetDataSource(cb, LookupCache.Get(LookupTables.Site), "strSiteName", "idfsSite", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
        End Sub

        Private Shared imageList1 As ImageList

        Public Shared Sub BindAggregateMatrixVersionLookup(ByVal cb As GridLookUpEdit, ByVal ds As DataSet,
                                                           ByVal bindField As String,
                                                           ByVal MatrixType As AggregateCaseSection,
                                                           ByVal ShowActiveMatrixOnly As Boolean)

            Dim chkDefault As New RepositoryItemImageComboBox
            If imageList1 Is Nothing Then
                imageList1 = New ImageList()
                imageList1.TransparentColor = Color.Magenta
                imageList1.ImageSize = New Size(14, 14)
                imageList1.Images.Add("state_nonactive", state_nonactive)
                imageList1.Images.Add("state_activated", state_activated)
                imageList1.Images.Add("state_default", state_default)
            End If
            chkDefault.SmallImages = imageList1
            chkDefault.Items.AddRange(New ImageComboBoxItem() { _
                                                                  New ImageComboBoxItem(
                                                                      EidssMessages.Get("strMatrixNotActive",
                                                                                        "Not Active"), 0, 0),
                                                                  New ImageComboBoxItem(
                                                                      EidssMessages.Get("strMatrixActive", "Active"), 1,
                                                                      1),
                                                                  New ImageComboBoxItem(
                                                                      EidssMessages.Get("strDefault", "Default"), 2, 2)})
            chkDefault.GlyphAlignment = HorzAlignment.Center
            cb.Properties.RepositoryItems.AddRange(New RepositoryItem() {chkDefault})

            Dim colDefault As New GridColumn()
            colDefault.Caption = EidssMessages.Get("colState", "State")
            colDefault.FieldName = "intState"
            colDefault.ColumnEdit = chkDefault
            colDefault.Width = 25
            colDefault.VisibleIndex = 0
            colDefault.ImageIndex = 0
            colDefault.ImageAlignment = StringAlignment.Center
            colDefault.OptionsColumn.AllowSize = False
            colDefault.OptionsFilter.AllowFilter = False

            Dim colMatrixName As New GridColumn()
            colMatrixName.Caption = EidssMessages.Get("colName", "Name")
            colMatrixName.FieldName = "MatrixName"
            colMatrixName.Width = 200
            colMatrixName.VisibleIndex = 1

            Dim colMatrixDate As New GridColumn()
            colMatrixDate.Caption = EidssMessages.Get("colMatrixDate", "Activation Date")
            colMatrixDate.FieldName = "datStartDate"
            colMatrixDate.Width = 100
            colMatrixDate.VisibleIndex = 2

            Dim gridView As New GridView()

            gridView.Columns.AddRange(New GridColumn() {colDefault, colMatrixName, colMatrixDate})
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus
            gridView.OptionsSelection.EnableAppearanceFocusedCell = False
            gridView.OptionsView.ShowGroupPanel = False
            gridView.OptionsView.ShowIndicator = False
            gridView.Images = imageList1

            cb.Properties.View = gridView

            cb.Properties.PopupFormSize = New Size(400, 0)

            Dim view As DataView = LookupCache.Get(LookupTables.AggregateMatrixVersion)
            Dim filter As String = String.Format("idfsAggrCaseSection={0}", CLng(MatrixType))
            If (ShowActiveMatrixOnly) Then
                filter += " and blnIsActive=1"
            End If
            view.RowFilter = filter
            SetDataSource(cb, view, "MatrixName", "idfVersion")
            AddBinding(cb, ds, bindField, False)
        End Sub

        Public Shared Sub BindFFTemplatesLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                                ByVal formType As FFType)

            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("NationalName", "colName",
                                                                                               200, FormatType.None, "",
                                                                                               True, HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = 400
            Dim view As DataView = LookupCache.Get(LookupTables.FFTemplate)
            Dim filter As String = String.Format("idfsFormType={0}", CLng(formType))
            'view.RowFilter = Filter
            SetDataSource(cb, view, "NationalName", "idfsFormTemplate")
            AddBinding(cb, ds, bindField, False, filter)
        End Sub

        Public Shared Sub BindASCampaignLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String)

            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New BvLookupColumnInfo() { _
                                                                        New BvLookupColumnInfo("strCampaignID",
                                                                                               "colCampaignID", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near),
                                                                        New BvLookupColumnInfo("strCampaignName",
                                                                                               "colCampaignName", 200,
                                                                                               FormatType.DateTime, "d",
                                                                                               True, HorzAlignment.Near),
                                                                        New BvLookupColumnInfo("strCampaignStatus",
                                                                                               "colCampaignStatus", 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                           )
            cb.Properties.PopupWidth = 400
            Dim view As DataView = LookupCache.Get(LookupTables.ASCampaign)
            SetDataSource(cb, view, "strCampaignID", "idfCampaign")
            AddBinding(cb, ds, bindField, False)
        End Sub

#End Region

#Region "HACode lookup binder"

        Private Shared Function GetHacodeView(haCodeMask As Integer) As DataView
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("spHACode_SelectCheckList",
                                                                ConnectionManager.DefaultInstance.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            BaseDbService.AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
            BaseDbService.AddParam(cmd, "@intHACodeMask", haCodeMask)
            Dim t As DataTable = BaseDbService.ExecTable(cmd)
            If Not t Is Nothing Then
                Return New DataView(t) '.DefaultView
            End If
            Return Nothing
        End Function

        Private Shared Sub InitPopupContainer(popup As PopupContainerControl, ByVal dv As DataView,
                                              intHACodeMask As Integer)
            If dv Is Nothing Then
                Return
            End If
            Dim haCodePopupHeight As Integer = 0
            Dim haCodePopupWidth As Integer = 0
            dv.Sort = "intHACode"
            popup.Tag = New List(Of CheckEdit)
            UpdateHACodeList(dv, popup, intHACodeMask, haCodePopupWidth, haCodePopupHeight)
            popup.AutoScroll = True
            popup.AutoScrollMinSize = New Size(haCodePopupWidth, haCodePopupHeight)
            popup.Width = 200
            popup.Height = haCodePopupHeight
        End Sub

        Public Shared Sub BindHACodeLookup(ByVal popupContainer As PopupContainerEdit, ByVal ds As DataSet,
                                           ByVal bindField As String, intHACodeMask As Integer)
            Dim popup As PopupContainerControl = New PopupContainerControl
            InitPopupContainer(popup, GetHacodeView(intHACodeMask), intHACodeMask)
            AddBinding(popupContainer, ds, bindField)
            popupContainer.Properties.PopupControl = popup
            RemoveHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            AddHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            RemoveHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            AddHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            RemoveHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
            AddHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
        End Sub

        Public Shared Sub BindReprositoryHACodeLookup(ByVal popupContainer As RepositoryItemPopupContainerEdit,
                                                      ByVal dv As DataView, ByVal gridView As GridView,
                                                      intHACodeMask As Integer)
            Dim popup As PopupContainerControl = New PopupContainerControl
            InitPopupContainer(popup, dv, intHACodeMask)
            popupContainer.PopupControl = popup
            RemoveHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            AddHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            RemoveHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            AddHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            RemoveHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
            AddHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
            RemoveHandler gridView.ShowFilterPopupListBox, AddressOf HACodeColumn_ShowFilterPopupListBox
            AddHandler gridView.ShowFilterPopupListBox, AddressOf HACodeColumn_ShowFilterPopupListBox
        End Sub
        'Public Shared Sub BindRepositoryAvrFarmTypeLookup(ByVal cb As RepositoryItemLookUpEdit)
        '    Dim view As DataView = GetHacodeView(HACode.Avian Or HACode.Livestock)
        '    cb.Columns.Clear()
        '    cb.Columns.AddRange(New BvLookupColumnInfo() { _
        '        New BvLookupColumnInfo("CodeName", "colName", 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '                        )
        '    cb.PopupWidth = 200
        '    LookupTableID(cb) = db.BaseReferenceType.rftHA_Code_List
        '    SetDataSource(cb, view, "CodeName", "intHACode", Nothing, Nothing)
        'End Sub
        Private Shared Sub HACodeColumn_ShowFilterPopupListBox(ByVal sender As Object,
                                                               ByVal e As _
                                                                  DevExpress.XtraGrid.Views.Grid.
                                                                  FilterPopupListBoxEventArgs)
            If e.Column.FieldName = "intHACode" AndAlso e.ComboBox.Items.Count > 0 Then
                For Each item As DevExpress.XtraGrid.Views.Grid.FilterItem In e.ComboBox.Items
                    If _
                        TypeOf (item.Value) Is DevExpress.XtraGrid.Views.Grid.FilterItem AndAlso
                        CType(item.Value, DevExpress.XtraGrid.Views.Grid.FilterItem).Value.Equals(1) Then
                        e.ComboBox.Items.Remove(item)
                        Return
                    End If
                Next
            End If
        End Sub

        Public Shared Sub UpdateHACodeList(ByVal dv As DataView, ByVal popup As PopupContainerControl,
                                           intHACodeMask As Integer, ByRef popupWidth As Integer,
                                           ByRef popupHeight As Integer)
            popup.Controls.Clear()
            For Each row As DataRowView In dv
                If (CInt(row("intHACode")) And intHACodeMask) <> 0 Then
                    AddHACode(dv, popup, CInt(row("intHACode")), popupWidth, popupHeight)
                End If
            Next
        End Sub

        Private Shared Function AddHACode(ByVal dv As DataView, ByVal popup As PopupContainerControl,
                                          ByVal code As Integer, ByRef popupWidth As Integer,
                                          ByRef popupHeight As Integer) As Boolean
            Dim found As DataRowView() = dv.FindRows(code)
            If found.Length = 0 Then Return False
            Dim check As CheckEdit = New CheckEdit
            check.Tag = code
            check.Text = found(0).Row("CodeName").ToString()
            check.Top = popupHeight
            check.Width = check.CalcBestSize().Width()
            If check.Width > popupWidth Then popupWidth = check.Width
            popupHeight += check.Height
            popup.Controls.Add(check)
            CType(popup.Tag, List(Of CheckEdit)).Add(check)
            'AddHandler check.CheckedChanged, AddressOf CheckedHandler
            Return True
        End Function

        Private Shared Function GetHaCodeChecksList(sender As Object) As List(Of CheckEdit)
            Dim popup As PopupContainerControl = Nothing
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                If (Not CType(sender, PopupContainerEdit).Properties.PopupControl Is Nothing) Then
                    popup = CType(sender, PopupContainerEdit).Properties.PopupControl
                ElseIf TypeOf CType(sender, PopupContainerEdit).Tag Is RepositoryItemPopupContainerEdit Then
                    Dim popupContainer As RepositoryItemPopupContainerEdit = CType(CType(sender, PopupContainerEdit).Tag,
                                                                                   RepositoryItemPopupContainerEdit)
                    popup = popupContainer.PopupControl
                End If
            ElseIf _
                TypeOf sender Is RepositoryItemPopupContainerEdit AndAlso
                Not CType(sender, RepositoryItemPopupContainerEdit) Is Nothing Then
                popup = CType(sender, RepositoryItemPopupContainerEdit).PopupControl
            End If
            If Not popup Is Nothing Then
                Return CType(popup.Tag, List(Of CheckEdit))
            End If
            Return Nothing
        End Function
        'Private Shared Sub CheckedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim check As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        '    Dim popup As PopupContainerControl = CType(check.Parent, PopupContainerControl)
        '    Dim code As Integer = CInt(check.Tag)
        '    If code = HACode.Animal Then
        '        SetChecked(CType(popup.Tag, List(Of CheckEdit))(1), check.Checked)
        '        SetChecked(CType(popup.Tag, List(Of CheckEdit))(2), check.Checked)
        '    End If
        '    If code = HACode.Avian Or code = HACode.Livestock Then
        '        SetChecked(CType(popup.Tag, List(Of CheckEdit))(0), CType(popup.Tag, List(Of CheckEdit))(1).Checked Or CType(popup.Tag, List(Of CheckEdit))(2).Checked)
        '    End If
        'End Sub

        Private Shared Sub PopupContainerEdit_QueryResultValue(ByVal sender As Object,
                                                               ByVal e As QueryResultValueEventArgs)
            'If Closing Then
            '    Return
            'End If
            Dim haCode As Integer = 0
            Dim checkEdits As List(Of CheckEdit) = GetHaCodeChecksList(sender)
            If Not checkEdits Is Nothing Then
                For Each check As CheckEdit In checkEdits
                    If check.Checked Then
                        haCode += TagHelper.ToInt(check.Tag)
                    End If
                Next
                If Utils.IsEmpty(e.Value) AndAlso haCode = 0 Then
                    Return
                End If
                If (haCode > 0) Then
                    e.Value = haCode
                Else
                    e.Value = DBNull.Value
                End If
            End If
        End Sub

        Private Shared Sub PopupContainerTree_QueryResultValue(ByVal sender As Object,
                                                               ByVal e As QueryResultValueEventArgs)
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                Dim popupContainer As PopupContainerEdit = CType(sender, PopupContainerEdit)
                If _
                    Not popupContainer.Properties.PopupControl.Controls(0) Is Nothing AndAlso
                    TypeOf popupContainer.Properties.PopupControl.Controls(0) Is TreeList Then
                    Dim tree As TreeList = CType(popupContainer.Properties.PopupControl.Controls(0), TreeList)
                    Dim row As DataRowView = CType(tree.GetDataRecordByNode(tree.FocusedNode), DataRowView)
                    If Not row Is Nothing AndAlso Not e.Value Is row.Row(tree.KeyFieldName) Then
                        e.Value = row.Row(tree.KeyFieldName)
                    End If
                End If
            End If
        End Sub

        Private Shared Sub PopupContainer_QueryDisplayText(ByVal sender As Object, ByVal e As QueryDisplayTextEventArgs)
            Dim HACode As Integer = 0
            If Utils.IsEmpty(e.EditValue) = False Then
                HACode = CType(e.EditValue, Integer)
            End If
            Dim checkEdits As List(Of CheckEdit) = GetHaCodeChecksList(sender)
            If Not checkEdits Is Nothing Then
                e.DisplayText = ""
                For Each check As CheckEdit In checkEdits
                    Dim bitSet As Boolean = (TagHelper.ToInt(check.Tag) And HACode) <> 0
                    'SetChecked(check, bitSet)
                    If bitSet Then
                        Utils.AppendLine(e.DisplayText, check.Text, ", ")
                    End If
                Next
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Private Shared Sub PopupContainerTree_QueryDisplayText(ByVal sender As Object,
                                                               ByVal e As QueryDisplayTextEventArgs)
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                Dim popupContainer As PopupContainerEdit = CType(sender, PopupContainerEdit)
                If popupContainer.Properties.PopupControl Is Nothing Then
                    Return
                End If
                Dim tree As TreeList = CType(popupContainer.Properties.PopupControl.Controls(0), TreeList)

                Dim diag As Long = 0
                If Not Utils.IsEmpty(e.EditValue) AndAlso TypeOf e.EditValue Is Long Then
                    diag = CType(e.EditValue, Long)
                    tree.Tag = diag
                    Dim foundName As Object = getValue(CType(tree.DataSource, DataView), diag,
                                                       "idfsDiagnosisOrDiagnosisGroup", "name")
                    If Not Utils.IsEmpty(foundName) Then
                        e.DisplayText = CType(foundName, String)
                    Else
                        e.DisplayText = ""
                    End If
                End If
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Public Shared Function getValue(ByVal dv As DataView, ByVal id As Long, ByVal fieldId As String,
                                        ByVal fieldResult As String) As Object
            Dim rows As DataRow() = dv.Table.Select(String.Format("{0}={1}", fieldId, id))
            If (rows.Length > 0) Then
                Return rows(0)(fieldResult)
            End If
            Return Nothing
        End Function

        Private Shared Sub PopupContainer_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim HACode As Integer = 0
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                If Utils.IsEmpty(CType(sender, PopupContainerEdit).EditValue) = False Then
                    HACode = CType(CType(sender, PopupContainerEdit).EditValue, Integer)
                End If
            End If
            Dim checkEdits As List(Of CheckEdit) = GetHaCodeChecksList(sender)
            If Not checkEdits Is Nothing Then
                For Each check As CheckEdit In checkEdits
                    Dim bitSet As Boolean = (TagHelper.ToInt(check.Tag) And HACode) <> 0
                    SetChecked(check, bitSet)
                Next
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Private Shared Sub PopupContainerTree_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                Dim popupContainer As PopupContainerEdit = CType(sender, PopupContainerEdit)
                If (popupContainer.EditValue Is DBNull.Value) Then
                    Return
                End If
                If _
                    Not popupContainer.Properties.PopupControl.Controls(0) Is Nothing AndAlso
                    TypeOf popupContainer.Properties.PopupControl.Controls(0) Is TreeList Then
                    Dim tree As TreeList = CType(popupContainer.Properties.PopupControl.Controls(0), TreeList)
                    tree.FocusedNode = tree.FindNodeByKeyID(popupContainer.EditValue)
                    tree.MakeNodeVisible(tree.FocusedNode) 'doesn't work
                Else
                    Dbg.Debug("treelist not found")
                End If
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Private Shared Sub Tree_FocusedNodeChanged(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
            If TypeOf sender Is TreeList AndAlso Not CType(sender, TreeList) Is Nothing Then
                Dim tree As TreeList = CType(sender, TreeList)
                If _
                    TypeOf tree.Parent Is PopupContainerControl AndAlso
                    Not CType(tree.Parent, PopupContainerControl) Is Nothing Then
                    If Not CType(tree.Parent, PopupContainerControl).OwnerEdit Is Nothing Then
                        CType(tree.Parent, PopupContainerControl).OwnerEdit.ClosePopup()
                    End If
                Else
                    Dbg.Debug("unexpected type")
                End If
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Private Shared Sub Tree_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
            If e.Column.AbsoluteIndex > 0 Then Exit Sub
            If TypeOf sender Is TreeList AndAlso Not CType(sender, TreeList) Is Nothing Then
                Dim tree As TreeList = CType(sender, TreeList)
                Dim dv As DataView = CType(tree.DataSource, DataView)
                Dim foundIndex As Integer = - 1
                If Not Utils.IsEmpty(e.Node.Id) Then foundIndex = CType(e.Node.Id, Integer)
                If _
                    foundIndex > 0 AndAlso Not Utils.IsEmpty(dv(foundIndex)("blnGroup")) AndAlso
                    Convert.ToInt32(dv(foundIndex)("blnGroup")) = 1 Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub


        Private Shared Sub SetChecked(ByVal check As CheckEdit, ByVal status As Boolean)
            If check.Checked = status Then Exit Sub
            'RemoveHandler check.CheckedChanged, AddressOf CheckedHandler
            check.Checked = status
            'AddHandler check.CheckedChanged, AddressOf CheckedHandler
        End Sub

#End Region
        '#Region "Repository check list lookup binder"
        '        Public Shared Sub BindReprositoryCheckListLookup(ByVal checkList As RepositoryItemCheckedComboBoxEdit, ByVal dv As DataView, ByVal ValueMember As String, ByVal DisplayMember As String)
        '            checkList.DataSource = dv
        '            checkList.ValueMember = ValueMember
        '            checkList.DisplayMember = DisplayMember
        '            checkList.SelectAllItemVisible = False
        '            checkList.SynchronizeEditValueWithCheckedItems = True
        '        End Sub


        '#End Region


        Public Shared Function BindAVRGisRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                          ByVal referenceType As GisRefereneceType,
                                                          Optional ByVal valueMember As String = "idfsReference",
                                                          Optional ByVal dataSource As DataView = Nothing) _
            As DataView
            cb.Columns.Clear()
            cb.Columns.AddRange(New BvLookupColumnInfo() {New BvLookupColumnInfo("ExtendedName",
                                                                                 "colName",
                                                                                 200, FormatType.None, "", True,
                                                                                 HorzAlignment.Near)})

            cb.PopupWidth = 400
            If dataSource Is Nothing Then
                dataSource = LookupCache.Get(LookupTables.AVRGIS.ToString)
                If referenceType = GisRefereneceType.Country Then
                    dataSource.RowFilter = String.Format("idfsGISReferenceType = {0}", CLng(referenceType))
                Else
                    dataSource.RowFilter = String.Format("idfsCountry = {0} and idfsGISReferenceType = {1}",
                                                         EidssSiteContext.Instance.CountryID, CLng(referenceType))
                End If

            End If

            SetDataSource(cb, dataSource, "ExtendedName", valueMember, Nothing, Nothing)
            Return dataSource
        End Function

        Public Shared Function GetDefSamplesFilter(Optional fieldName As String = "idfsReference") As String
            Return String.Format("{0}<>{1}", fieldName, CLng(SampleTypeEnum.Unknown))
        End Function

        Public Shared Sub BindSampleLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                           ByVal showPlusButton As Boolean)
            BindBaseLookup(cb, ds, bindField, db.BaseReferenceType.rftSampleType, False)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddSampleType"))
                AddButtonClickHandler(cb, AddressOf AddSampleType)
            End If
            AddBinding(cb, ds, bindField, True, GetDefSamplesFilter())
        End Sub

        Public Shared Sub BindSampleRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit, haCode As HACode,
                                                     Optional ByVal showPlusButton As Boolean = True,
                                                     Optional ByVal showClearButton As Boolean = True)
            BindBaseRepositoryLookup(cb, db.BaseReferenceType.rftSampleType, haCode, False, showClearButton)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddSampleType"))
                AddButtonClickHandler(cb, AddressOf AddSampleType)
            End If
            RemoveDefaultFilterHandlers(cb)
            AddEnterEventHandler(cb, AddressOf SetSampleDefaultFilter)
            AddLeaveEventHandler(cb, AddressOf ClearDefaultFilter)
        End Sub

        Private Shared Sub SetSampleDefaultFilter(sender As Object, e As EventArgs)
            Dim cb As LookUpEditBase = CType(sender, LookUpEditBase)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim filter As String
            If (Utils.IsEmpty(cb.EditValue)) Then
                filter = String.Format("intRowStatus = 0 and ({0})", GetDefSamplesFilter())
            Else
                filter = String.Format("(intRowStatus = 0 or {0}={1}) and ({2})", cb.Properties.ValueMember,
                                       cb.EditValue, GetDefSamplesFilter())
            End If
            SetDefaultFilter(cb, filter, True)
        End Sub

        <CLSCompliant(False)>
        Public Shared Sub BindPersonalDataSpinEdit(spinEdit As SpinEdit, ds As Object, bindField As String,
                                                   personalDataGroup As PersonalDataGroup, ignorePersonalData As Boolean,
                                                   Optional minValue As Decimal = 0, Optional maxValue As Decimal = 0,
                                                   Optional isFloatingValue As Boolean = False,
                                                   Optional increment As Decimal = 1,
                                                   Optional displayString As String = "*")
            If _
                Not ignorePersonalData AndAlso
                EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(personalDataGroup) Then
                BindPersonalDataContol(spinEdit, displayString)
            Else
                BindSpinEdit(spinEdit, ds, bindField, minValue, maxValue, isFloatingValue, increment)
            End If
        End Sub

        Public Shared Sub BindSpinEdit(spinEdit As SpinEdit, ds As Object, bindField As String,
                                       Optional minValue As Decimal = 0, Optional maxValue As Decimal = 0,
                                       Optional isFloatingValue As Boolean = False, Optional increment As Decimal = 1)
            spinEdit.DataBindings.Clear()
            RemoveHandler spinEdit.KeyDown, AddressOf SpinEdit_KeyDown
            Dbg.Assert(Not ds Is Nothing, "datasource for binding field {0} is not defined", bindField)
            spinEdit.DataBindings.Add("EditValue", ds, bindField, True, DataSourceUpdateMode.OnPropertyChanged)
            If (minValue <> 0) Then
                spinEdit.Properties.MinValue = minValue
            End If
            If (maxValue <> 0) Then
                spinEdit.Properties.MaxValue = maxValue
            End If
            spinEdit.Properties.IsFloatValue = isFloatingValue
            spinEdit.Properties.Increment = increment
            spinEdit.Properties.AllowNullInput = DefaultBoolean.True
            AddHandler spinEdit.KeyDown, AddressOf SpinEdit_KeyDown
        End Sub

        Private Shared Sub SpinEdit_KeyDown(sender As Object, e As KeyEventArgs)
            If (e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back) Then
                If (CType(sender, SpinEdit).Text.Replace("0", "").Replace(".", "").Replace(",", "") = "") Then
                    CType(sender, SpinEdit).EditValue = DBNull.Value
                End If
            End If
        End Sub

        Public Shared Sub SetGridViewConstraints(grid As GridView)
            If _
                grid.GridControl.DataSource Is Nothing OrElse Not grid.OptionsBehavior.Editable OrElse
                grid.OptionsBehavior.ReadOnly Then
                Return
            End If
            Dim table As DataTable
            If (TypeOf (grid.GridControl.DataSource) Is DataView) Then
                table = CType(grid.GridControl.DataSource, DataView).Table
            Else
                table = CType(grid.GridControl.DataSource, DataTable)
            End If
            For Each col As GridColumn In grid.Columns
                If Not Utils.IsEmpty(col.FieldName) AndAlso table.Columns.Contains(col.FieldName) Then
                    Dim len As Integer = GetFieldLength(table, col.FieldName)
                    If len > 0 AndAlso col.OptionsColumn.AllowEdit AndAlso Not col.OptionsColumn.ReadOnly Then
                        If (col.ColumnEdit Is Nothing) Then
                            col.ColumnEdit = GetTextColumnEdit(len)
                        ElseIf TypeOf (col.ColumnEdit) Is RepositoryItemTextEdit Then
                            CType(col.ColumnEdit, RepositoryItemTextEdit).MaxLength = len
                        ElseIf TypeOf (col.ColumnEdit) Is RepositoryItemMemoEdit Then
                            CType(col.ColumnEdit, RepositoryItemMemoEdit).MaxLength = len
                        End If
                    End If
                End If
            Next
        End Sub

        Private Shared Function GetTextColumnEdit(ByVal len As Integer) As RepositoryItem
            Dim edit As New RepositoryItemTextEdit
            edit.MaxLength = len
            Return edit
        End Function

        <CLSCompliant(False)>
        Public Shared Sub BindHumanAgeUnits(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                            personalDataGroup As PersonalDataGroup, ignorePersonalData As Boolean,
                                            Optional displayString As String = "*")
            BindPersonalDataBaseLookup(cb, ds, bindField, db.BaseReferenceType.rftHumanAgeType, HACode.Human, False,
                                       personalDataGroup, ignorePersonalData, displayString)
            LookUpSetFilter(cb.Properties.DataSource, cb.Properties.ValueMember, GetBindedValue(cb),
                            "idfsReference <> 10042004")
        End Sub
    End Class
End Namespace
