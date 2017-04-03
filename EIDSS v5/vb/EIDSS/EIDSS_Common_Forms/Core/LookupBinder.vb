Imports System.ComponentModel
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports bv.common.Configuration
Imports bv.model.Model.Core
Imports System.Drawing
Imports DevExpress.XtraGrid.Columns
Imports eidss.model.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports eidss.model.Enums
Imports System.Text.RegularExpressions
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.winclient.Localization
Imports eidss.model.Resources
Imports bv.common.Resources
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTreeList
Imports System.Globalization
Imports bv.winclient.Layout
Imports System.Collections.Generic
Imports System.Reflection
Imports DevExpress.Utils
Imports System.Text
Imports EIDSS.My.Resources

Namespace Core
    Public Class LookupBinder

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
            ' Note: this unreachable code commented to remove warning
            '
            'AddKeyDownHandler(cb, AddressOf KeyDown)
            'WinUtils.SetClearTooltip(cb)
            'If Not ForceAddClearButton AndAlso BaseSettings.ShowClearLookupButton = False Then
            '    Return
            'End If
            'For Each btn As EditorButton In cb.Properties.Buttons
            '    If btn.Kind = ButtonPredefines.Delete Then
            '        Return
            '    End If
            'Next
            'cb.Properties.Buttons.Add(New EditorButton(ButtonPredefines.Delete,
            '                                           BvMessages.Get("btnClear", "Clear the field contents")))
            'AddButtonClickHandler(cb, AddressOf ClearLookup)
        End Sub

        Public Shared Sub AddClearButton(ByVal cb As RepositoryItemButtonEdit,
                                         Optional ByVal ForceAddClearButton As Boolean = False)
            Return
            ' Note: this unreachable code commented to remove warning
            '
            'AddKeyDownHandler(cb, AddressOf KeyDown)
            'If Not ForceAddClearButton AndAlso BaseSettings.ShowClearRepositoryLookupButton = False Then
            '    Return
            'End If
            'For Each btn As EditorButton In cb.Buttons
            '    If btn.Kind = ButtonPredefines.Delete Then
            '        Return
            '    End If
            'Next
            'cb.Buttons.Add(New EditorButton(ButtonPredefines.Delete,
            '                                BvMessages.Get("btnClear", "Clear the field contents")))
            'AddButtonClickHandler(cb, AddressOf ClearLookup)
        End Sub

        Public Shared Sub SetDataSource(ByVal cb As LookUpEdit, ByVal dv As DataView, ByVal displayMember As String,
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
                                        queryPopupHandler As CancelEventHandler, closePopupHandler As CancelEventHandler)
            cb.DataSource = dv
            cb.DisplayMember = displayMember
            cb.ValueMember = valueMember
            cb.NullText = ""
            AddLookupClosedHandler(cb)
            AddSetDefaultFilterHandler(cb, queryPopupHandler)
            AddClearDefaultFilterHandler(cb, closePopupHandler)
            AddChangingHandler(cb, AddressOf OnClear)
            cb.Buttons.SetButtonTooltip(ButtonPredefines.Combo, EidssMessages.Get("msgExpandDropdown"))
        End Sub

        Public Shared Sub AddSetDefaultFilterHandler(ByVal cb As RepositoryItemLookUpEditBase,
                                                     handler As CancelEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.QueryPopUp, handler
            Finally
                AddHandler cb.QueryPopUp, handler
            End Try
        End Sub

        Public Shared Sub AddClearDefaultFilterHandler(ByVal cb As RepositoryItemLookUpEditBase,
                                                       handler As CancelEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.QueryCloseUp, handler
            Finally
                AddHandler cb.QueryCloseUp, handler
            End Try
        End Sub

        Public Shared Sub AddChangingHandler(ByVal cb As BaseEdit, handler As ChangingEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.EditValueChanging, handler
            Finally
                AddHandler cb.EditValueChanging, handler
            End Try
        End Sub

        Public Shared Sub AddChangingHandler(ByVal cb As RepositoryItemLookUpEdit, handler As ChangingEventHandler)
            If handler Is Nothing Then Return
            Try
                RemoveHandler cb.EditValueChanging, handler
            Finally
                AddHandler cb.EditValueChanging, handler
            End Try
        End Sub

        Public Shared Sub OnClear(sender As Object, e As ChangingEventArgs)
            'Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            If TypeOf (e.NewValue) Is Long AndAlso CType(e.NewValue, Long) = LookupCache.EmptyLineKey Then
                If Not WinUtils.ConfirmLookupClear() Then
                    e.Cancel = True
                    Return
                End If
                e.NewValue = DBNull.Value
            End If
        End Sub


        Public Shared Sub RemoveDefaultFilterHandlers(ByVal cb As RepositoryItemLookUpEditBase)
            Try
                RemoveHandler cb.QueryPopUp, AddressOf SetDefaultFilter
            Finally
            End Try
            Try
                RemoveHandler cb.QueryCloseUp, AddressOf ClearDefaultFilter
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

        Public Shared Sub AddBinding(ByVal cb As LookUpEdit, ByVal ds As Object, ByVal bindField As String,
                                     Optional ByVal showClearButton As Boolean = True,
                                     Optional defaultFilter As String = Nothing)
            cb.DataBindings.Clear()
            If Utils.IsEmpty(bindField) Then
                cb.EditValue = DBNull.Value
            ElseIf ds IsNot Nothing Then
                cb.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnPropertyChanged)
            End If
            If showClearButton Then
                AddClearButton(cb)
            End If
            If TypeOf (cb.Properties.DataSource) Is DataView Then
                If (CType(cb.Properties.DataSource, DataView).Table.Columns.Contains("intRowStatus")) Then
                    Dim val As Object = GetBindedValue(cb)
                    Dim filter As String
                    If (Utils.IsEmpty(defaultFilter)) Then
                        If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(val) Then
                            filter = String.Format("intRowStatus = 0 or {0} = {1}", cb.Properties.ValueMember, val)
                        Else
                            filter = String.Format("intRowStatus = 0")
                        End If
                    Else
                        If Not Utils.IsEmpty(bindField) AndAlso Not Utils.IsEmpty(val) Then
                            filter = String.Format("(intRowStatus = 0 or {0} = {1}) and ({2})",
                                                   cb.Properties.ValueMember, val, defaultFilter)
                        Else
                            filter = String.Format("intRowStatus = 0 and ({0})", defaultFilter)
                        End If
                    End If
                    If (CType(cb.Properties.DataSource, DataView).Table.PrimaryKey.Length > 0) Then
                        filter = String.Format("({0}) or {1} = {2}", filter,
                                               CType(cb.Properties.DataSource, DataView).Table.PrimaryKey(0),
                                               LookupCache.EmptyLineKey)
                    End If

                    CType(cb.Properties.DataSource, DataView).RowFilter = filter
                Else
                    CType(cb.Properties.DataSource, DataView).RowFilter = defaultFilter
                End If
            Else
                Dbg.Debug("lookup binding source is not DataView")
            End If
        End Sub

        Public Shared Sub AddBinding(ByVal cb As GridLookUpEdit, ByVal ds As Object, ByVal bindField As String,
                                     Optional ByVal showClearButton As Boolean = True)
            cb.DataBindings.Clear()
            If Utils.IsEmpty(bindField) Then
                cb.EditValue = DBNull.Value
            Else
                Dbg.Assert(ds IsNot Nothing, "datasource for binding field {0} is not defined", bindField)
                cb.DataBindings.Add("EditValue", ds, bindField, False, DataSourceUpdateMode.OnPropertyChanged)
            End If
            If showClearButton Then
                AddClearButton(cb)
            End If
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
            If (BaseSettings.ShowDateTimeFormatAsNullText) Then
                dt.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            If (dt.Properties.MinValue = DateTime.MinValue) Then
                dt.Properties.MinValue = New DateTime(1900, 1, 1)
            End If
            If (dt.Properties.MaxValue = DateTime.MinValue) Then
                dt.Properties.MaxValue = New DateTime(2050, 1, 1)
            End If
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
                        Dim ID As Object = Nothing
                        Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                        Dim OrganizationID As Object =
                                GetParentIDFromRowFilter(CType(cb.Properties.DataSource, DataView).RowFilter)
                        Dim StartUpParams As New Dictionary(Of String, Object)
                        If Not OrganizationID Is Nothing Then
                            StartUpParams("OrganizationID") = OrganizationID
                        End If
                        If _
                            BaseFormManager.ShowModal(
                                CType(ClassLoader.LoadClass("PersonDetailPanel"), IApplicationForm), cb.FindForm(), ID,
                                Nothing, StartUpParams) Then
                            cb.EditValue = ID
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

        Public Shared Sub AddSpecies(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim ID As Object = Nothing
                        If _
                            BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("SpeciesTypeDetail"), BaseForm),
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

        Public Shared Sub AddSampleType(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
            If CType(sender, BaseEdit).Properties.ReadOnly = True Then Return
            If ActionLocker.LockAction(sender) Then

                Try
                    If e.Button.Kind = ButtonPredefines.Plus Then
                        Dim ID As Object = Nothing
                        If _
                            BaseFormManager.ShowModal(CType(ClassLoader.LoadClass("SampleTypeDetail"), BaseForm),
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
                                         ByVal AddButtonHandler As ButtonPressedEventHandler)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            If (view.Table.Columns.Contains("intRowStatus")) Then
                If (Utils.IsEmpty(cb.EditValue)) Then
                    view.RowFilter = "intRowStatus = 0"
                Else
                    If (TypeOf (cb.EditValue) Is String) Then
                        view.RowFilter = String.Format("intRowStatus = 0 or {0}='{1}'", cb.Properties.ValueMember,
                                                       cb.EditValue)
                    Else
                        view.RowFilter = String.Format("intRowStatus = 0 or {0}={1}", cb.Properties.ValueMember,
                                                       cb.EditValue)
                    End If
                End If
            End If
        End Sub

        Public Shared Sub ClearDefaultFilter(sender As Object, e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            If (view.Table.Columns.Contains("intRowStatus")) Then
                view.RowFilter = ""
            End If
        End Sub

        Public Shared Sub BindBaseRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   ByVal tableId As db.BaseReferenceType,
                                                   Optional ByVal showPlusButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
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
                                                       Optional ByVal showPlusButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
                                                                                HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(tableId.ToString), "name", "idfsReference", AddressOf SetDefaultFilter,
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
        '                row("name") = EidssMessages.Get(Other)
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

            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strCountryName",
                                                                                           EidssMessages.Get(
                                                                                               "colCountryName",
                                                                                               "Country Name"), 200,
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

            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("strCountryName",
                                                                                EidssMessages.Get("colCountryName",
                                                                                                  "Country Name"), 200,
                                                                                FormatType.None, "", True,
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
                                           Optional ByVal bindField As String = Nothing, Optional showAggregateRegions As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strRegionName",
                                                                                           EidssMessages.Get(
                                                                                               "colRegionName",
                                                                                               "Region Name"), 200,
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

        '    cb.Columns.AddRange(New LookUpColumnInfo() { _
        '               New LookUpColumnInfo("strRegionName", EidssMessages.Get("colRegionName", "Region Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Region.ToString), "strRegionName", "idfsRegion", Nothing, Nothing)
        'End Sub

        Public Shared Sub BindRayonLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                          Optional ByVal bindField As String = Nothing, Optional showAggregateRayons As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strRayonName",
                                                                                           EidssMessages.Get(
                                                                                               "colRayonName",
                                                                                               "Rayon Name"), 200,
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

        '    cb.Columns.AddRange(New LookUpColumnInfo() { _
        '               New LookUpColumnInfo("strRayonName", EidssMessages.Get("colRayonName", "Rayon Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Rayon.ToString), "strRayonName", "idfsRayon")
        'End Sub

        Public Shared Sub BindSettlementLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                               Optional ByVal bindField As String = Nothing, Optional showAggregateSettlements As Boolean = False)
            cb.Properties.Columns.Clear()

            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strSettlementName",
                                                                                           EidssMessages.Get(
                                                                                               "colSettlementName",
                                                                                               "Settlement Name"), 200,
                                                                                           FormatType.None, "", True,
                                                                                           HorzAlignment.Near)}
                                           )

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

        '    cb.Columns.AddRange(New LookUpColumnInfo() { _
        '               New LookUpColumnInfo("strSettlementName", EidssMessages.Get("colSettlementName", "Settlement Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )

        '    cb.PopupWidth = 400
        '    Dim dv As DataView = LookupCache.Get(LookupTables.Settlement.ToString)
        '    dv.Sort = "strSettlementName"
        '    SetDataSource(cb, dv, "strSettlementName", "idfsSettlement")
        'End Sub

        Public Shared Sub BindPersonLookup(ByVal cb As LookUpEdit, ByVal ds As Object, ByVal bindField As String,
                                           Optional ByVal showClearButton As Boolean = True)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("FullName",
                                                                                           EidssMessages.Get(
                                                                                               "colPersonFullName",
                                                                                               "Name"), 200),
                                                                      New LookUpColumnInfo("Organization",
                                                                                           EidssMessages.Get(
                                                                                               "strOrganization",
                                                                                               "Organization"), 80),
                                                                      New LookUpColumnInfo("Position",
                                                                                           EidssMessages.Get(
                                                                                               "colPosition", "Position"),
                                                                                           50)})
            cb.Properties.PopupWidth = 350
            Dim dv As DataView = LookupCache.Get(LookupTables.Person.ToString)
            SetDataSource(cb, dv, "FullName", "idfPerson")

            AddPlusButton(cb)
            AddButtonClickHandler(cb, AddressOf AddPerson)
            AddBinding(cb, ds, bindField, showClearButton)
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     Optional ByVal showClearButton As Boolean = True)
            BindPersonRepositoryLookup(cb, AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter, showClearButton)
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     queryPopupHandler As CancelEventHandler,
                                                     Optional ByVal showClearButton As Boolean = True)
            BindPersonRepositoryLookup(cb, queryPopupHandler, AddressOf ClearDefaultFilter, showClearButton)
        End Sub

        Public Shared Sub BindPersonRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                     queryPopupHandler As CancelEventHandler,
                                                     closePopupHandler As CancelEventHandler,
                                                     Optional ByVal showClearButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("FullName",
                                                                                EidssMessages.Get("colPersonFullName",
                                                                                                  "Name"), 200),
                                                           New LookUpColumnInfo("Organization",
                                                                                EidssMessages.Get("strOrganization",
                                                                                                  "Organization"), 80),
                                                           New LookUpColumnInfo("Position",
                                                                                EidssMessages.Get("colPosition",
                                                                                                  "Position"), 50)})
            cb.PopupWidth = 400
            Dim dv As DataView = LookupCache.Get(LookupTables.Person.ToString)
            SetDataSource(cb, dv, "FullName", "idfPerson", queryPopupHandler, closePopupHandler)
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

        Public Shared Function GetBindedValue(ByVal lookup As LookUpEdit) As Object
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
                                          ByVal cbPerson As LookUpEdit, Optional ByVal softLink As Boolean = False)
            If cbPerson.Properties.DataSource Is Nothing Then
                Return
            End If
            If organizationRow Is Nothing Then
                CType(cbPerson.Properties.DataSource, DataView).RowFilter = String.Format("idfPerson = {0}",
                                                                                          LookupCache.EmptyLineKey)
                cbPerson.EditValue = DBNull.Value
            Else
                Dim currentOrg As String = Utils.Str(organizationRow(organizationColumn), "-1")
                Dim originalOrg As String = Utils.Str(GetOriginalValue(organizationRow, organizationColumn), "-1")
                If softLink AndAlso currentOrg = "-1" Then
                    CType(cbPerson.Properties.DataSource, DataView).RowFilter = ""
                Else
                    Dim val As Object = GetBindedValue(cbPerson)
                    If Not cbPerson.Properties.DataSource Is Nothing Then
                        If Not Utils.IsEmpty(val) Then
                            CType(cbPerson.Properties.DataSource, DataView).RowFilter =
                                String.Format(
                                    "(idfOffice = {0} and intRowStatus = 0 ) or idfPerson = {1} or idfPerson = {2}",
                                    currentOrg, val, LookupCache.EmptyLineKey)
                        Else
                            CType(cbPerson.Properties.DataSource, DataView).RowFilter =
                                String.Format("(idfOffice = {0} and intRowStatus = 0) or idfPerson = {1}", currentOrg,
                                              LookupCache.EmptyLineKey)
                        End If
                    End If
                End If

                If Not Utils.IsEmpty(cbPerson.EditValue) Then
                    Dim valueExist As Boolean = False
                    For Each row As DataRowView In CType(cbPerson.Properties.DataSource, DataView)
                        If row("idfPerson").Equals(cbPerson.EditValue) Then
                            valueExist = True
                            Return
                        End If
                    Next
                    If Not valueExist Then
                        cbPerson.EditValue = DBNull.Value
                    End If
                End If
            End If
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
            CType(cbPerson.Properties.DataSource, DataView).RowFilter = filter
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
                            cb.EditValue = ID
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
                        Dim bo As IObject =
                                BaseFormManager.ShowForSelection(
                                    CType(ClassLoader.LoadClass("OrganizationListPanel"), IBaseListPanel),
                                    CType(sender, Control).FindForm())
                        If Not bo Is Nothing Then
                            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
                            cb.EditValue = bo.Key
                        End If
                    End If
                Finally
                    ActionLocker.UnlockAction(sender)
                End Try
            End If
        End Sub

        Private Shared Sub AddOrganizationSearchButton(ByVal buttons As EditorButtonCollection)
            For Each b As EditorButton In buttons
                If b.Kind = ButtonPredefines.Glyph Then
                    Return
                End If
            Next
            Dim btn As New EditorButton(ButtonPredefines.Glyph)
            btn.Image = Browse5
            btn.ToolTip = EidssMessages.Get("msgFindOrganization", "Find Organization")
            buttons.Add(btn)
        End Sub

        Public Shared Sub BindOrganizationLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                                 ByVal bindField As String)
            BindOrganizationLookup(cb, dataSource, bindField, True)
        End Sub

        Public Shared Sub BindOrganizationLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                                 ByVal bindField As String, ByVal showPlusButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get(
                                                                                               "colOrganizationShortName",
                                                                                               "Short Name"), 150),
                                                                      New LookUpColumnInfo("FullName",
                                                                                           EidssMessages.Get(
                                                                                               "strOrganization",
                                                                                               "Organization"), 200)})
            cb.Properties.PopupWidth = 350
            SetDataSource(cb, LookupCache.Get(LookupTables.Organization.ToString), "name", "idfInstitution")
            AddOrganizationSearchButton(cb.Properties.Buttons)
            AddButtonClickHandler(cb, AddressOf SearchOrganization)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddOrganization"))
                AddButtonClickHandler(cb, AddressOf AddOrganization)
            End If
            AddBinding(cb, dataSource, bindField)
        End Sub

        Public Shared Sub BindOrganizationRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                           Optional ByVal showPlusButton As Boolean = True,
                                                           Optional ByVal ShowClearButton As Boolean = False)
            BindOrganizationRepositoryLookup(cb, "idfInstitution", showPlusButton, ShowClearButton)
        End Sub

        Public Shared Sub BindOrganizationRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                           ByVal valueMember As String,
                                                           Optional ByVal showPlusButton As Boolean = True,
                                                           Optional ByVal ShowClearButton As Boolean = False)
            cb.Columns.Clear()
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get(
                                                                                    "colOrganizationShortName",
                                                                                    "Short Name"), 150),
                                                           New LookUpColumnInfo("FullName",
                                                                                EidssMessages.Get("strOrganization",
                                                                                                  "Organization"), 200)})
            cb.PopupWidth = 350
            SetDataSource(cb, LookupCache.Get(LookupTables.Organization.ToString), "name", valueMember,
                          AddressOf SetDefaultFilter, AddressOf ClearDefaultFilter)
            AddOrganizationSearchButton(cb.Buttons)
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

        Private Shared Sub CreateDiagnosisColumns(ByVal cb As RepositoryItemLookUpEdit, ByVal aHACode As Integer,
                                                  ByVal ShowAdditionalColumns As Boolean)
            cb.Columns.Clear()
            cb.Columns.Add(
                New LookUpColumnInfo("name", EidssMessages.Get("colDiseaseName", "Diagnosis"), 200, FormatType.None, "",
                                     True, HorzAlignment.Near)
                )
            If (ShowAdditionalColumns = False) Then
                Exit Sub
            End If
            If ((aHACode And HACode.Human) = HACode.Human) Then
                cb.Columns.Add(
                    New LookUpColumnInfo("strIDC10", EidssMessages.Get("colIDC10"), 200, FormatType.None, "", True,
                                         HorzAlignment.Near)
                    )
            End If
            If (CInt(aHACode And HACode.Avian And HACode.Livestock) <> 0) Then
                cb.Columns.Add(
                    New LookUpColumnInfo("strOIECode", EidssMessages.Get("colOIECode"), 200, FormatType.None, "", True,
                                         HorzAlignment.Near)
                    )
            End If
        End Sub

        Public Shared Sub BindDiagnosisLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                              Optional ByVal ShowAdditionalColumns As Boolean = True)
            CreateDiagnosisColumns(cb.Properties, GetDiagnosisHACode(LookupTables.HumanVetDiagnoses),
                                   ShowAdditionalColumns)
            'cb.Properties.Columns.Clear()
            'cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
            'New LookUpColumnInfo("Name", EidssMessages.Get("colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New LookUpColumnInfo("strIDC10", EidssMessages.Get(CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            cb.Properties.PopupWidth = 500
            SetDataSource(cb, LookupCache.Get(LookupTables.HumanVetDiagnoses), "name", "idfsDiagnosis")
            AddBinding(cb, ds, bindField)
        End Sub

        Public Shared Sub BindDiagnosisHACodeRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                              ByVal DiagnosisType As LookupTables,
                                                              Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                              Optional ByVal ShowClearButton As Boolean = True,
                                                              Optional ByVal displayMember As String = "name")
            CreateDiagnosisColumns(cb, GetDiagnosisHACode(DiagnosisType), ShowAdditionalColumns)
            'cb.Columns.Clear()
            'cb.Columns.AddRange(New LookUpColumnInfo() { _
            'New LookUpColumnInfo("Name", EidssMessages.Get("colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New LookUpColumnInfo(DiseaseCodeColumnName, EidssMessages.Get(CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(DiagnosisType), displayMember, "idfsDiagnosis", AddressOf SetDefaultFilter,
                          AddressOf ClearDefaultFilter)
            If ShowClearButton Then
                AddClearButton(cb, True)
            End If
            'AddPlusButton(cb)
            'AddButtonClickHandler(cb, AddressOf AddBaseReference)
        End Sub

        Public Shared Sub BindDiagnosisHACodeLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet,
                                                    ByVal DiagnosisType As LookupTables, ByVal bindField As String,
                                                    Optional ByVal ShowAdditionalColumns As Boolean = True,
                                                    Optional ByVal ShowClearButton As Boolean = True)
            CreateDiagnosisColumns(cb.Properties, GetDiagnosisHACode(DiagnosisType), ShowAdditionalColumns)
            'cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
            'New LookUpColumnInfo("Name", EidssMessages.Get("colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New LookUpColumnInfo("strIDC10", EidssMessages.Get(CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
            ')

            cb.Properties.PopupWidth = 500
            SetDataSource(cb, LookupCache.Get(DiagnosisType), "name", "idfsDiagnosis")
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
            CreateDiagnosisColumns(cb, aHACode, ShowAdditionalColumns)
            'cb.Columns.Clear()
            'cb.Columns.AddRange(New LookUpColumnInfo() { _
            'New LookUpColumnInfo("Name", EidssMessages.Get("colDiseaseName", "Disease"), 200, FormatType.None, "", True, HorzAlignment.Near), _
            'New LookUpColumnInfo(DiseaseCodeColumnName, EidssMessages.Get(CodeColumnName), 200, FormatType.None, "", True, HorzAlignment.Near)} _
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
            End If
            If AddClearBtn Then AddClearButton(cb)
        End Sub


        Public Shared Sub BindAnimalAgeRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                        Optional ByVal showPlusButton As Boolean = True)
            cb.Columns.Clear()
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
                                                                                HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            SetDataSource(cb, LookupCache.Get(LookupTables.AnimalAgeList), "name", "idfsReference",
                          AddressOf cbAnimalAge_QueryPopUp, AddressOf ClearDefaultFilter)
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

        Private Shared Sub cbAnimalAge_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim row As DataRow = GetBoundDataRow(cb)
            Dim speciesType As Long = CLng(IIf(Utils.IsEmpty(row("idfsSpeciesType")), - 1, row("idfsSpeciesType")))
            If Not cb.EditValue Is DBNull.Value Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(intRowStatus = 0  or idfsReference = {1}) and idfsSpeciesType = {0}", speciesType,
                                  cb.EditValue)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(intRowStatus = 0 and idfsSpeciesType = {0})", speciesType)
            End If
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get(
                                                                                               "colDepartmentName",
                                                                                               "Department"), 200)})
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colDepartmentName",
                                                                                                  "Department"), 200)})
            cb.PopupWidth = 400
            Dim view As DataView = LookupCache.Get(LookupTables.Department)
            SetDataSource(cb, view, "name", "idfDepartment", AddressOf cbDepartment_QueryPopUp,
                          AddressOf ClearDefaultFilter)
            If showPlusButton Then
                AddPlusButton(cb)
                AddButtonClickHandler(cb, AddressOf AddDepartment)
            End If
            AddClearButton(cb)
        End Sub

        Private Shared Sub cbDepartment_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)

            If Not cb.EditValue Is DBNull.Value Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("idfInstitution = {0} and (intRowStatus = 0 or idfDepartment={1}) ",
                                  EidssSiteContext.Instance.OrganizationID, cb.EditValue)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("idfInstitution = {0} and intRowStatus = 0", EidssSiteContext.Instance.OrganizationID)
            End If
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("name",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
                                                                                HorzAlignment.Near)}
                                )
            cb.PopupWidth = 400
            LookupTableID(cb) = db.BaseReferenceType.rftTestResult
            If useDefaultFilter Then
                SetDataSource(cb, LookupCache.Get(LookupTables.TestResult), "name", "idfsReference",
                              AddressOf cbTestResult_QueryPopUp, AddressOf ClearDefaultFilter)
            Else
                SetDataSource(cb, LookupCache.Get(LookupTables.TestResult), "name", "idfsReference", Nothing, Nothing)
            End If
            AddPlusButton(cb)
            AddButtonClickHandler(cb, AddressOf AddBaseReference)
            If (showClearButton) Then
                AddClearButton(cb, True)
            End If
        End Sub

        Private Shared Sub cbTestResult_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            Dim row As DataRow = GetBoundDataRow(cb)

            If row Is Nothing OrElse row("idfsTestType") Is DBNull.Value Then
                CType(cb.Properties.DataSource, DataView).RowFilter = "idfsTestType = -1"
            ElseIf Not row("idfsTestResult") Is DBNull.Value Then
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format(
                        "((intRowStatus = 0 or idfsReference = {1}) and idfsTestType = {0}) or idfsReference ={2}",
                        row("idfsTestType"), row("idfsTestResult"), LookupCache.EmptyLineKey)
            Else
                CType(cb.Properties.DataSource, DataView).RowFilter =
                    String.Format("(intRowStatus = 0 and idfsTestType = {0}) or idfsReference = {1}",
                                  row("idfsTestType"), LookupCache.EmptyLineKey)
            End If
        End Sub

        Public Shared Sub BindTestResultLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object,
                                               ByVal bindField As String, defaultFilter As String)
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
        '    cb.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("PatientName", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.Patient), "PatientName", ValueMember)
        'End Sub

        'Public Shared Sub BindPatientLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("PatientName", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
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
        '    cb.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("PatientInformation", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
        '    )
        '    cb.PopupWidth = 400
        '    SetDataSource(cb, LookupCache.Get(LookupTables.PatientAdditionalInfo), "PatientInformation", ValueMember)
        'End Sub

        'Public Shared Sub BindPatientAdditionalInfoLookup(ByVal cb As LookUpEdit, ByVal dataSource As Object, ByVal bindField As String, Optional ByVal ValueMember As String = "idfHuman")
        '    cb.Properties.Columns.Clear()
        '    cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("PatientInformation", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strOutbreakID",
                                                                                           EidssMessages.Get(
                                                                                               "colOutbreakID",
                                                                                               "Outbreak ID"), 200,
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("QueryName",
                                                                                           EidssMessages.Get(
                                                                                               "colQueryName",
                                                                                               "Query name"), 200,
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("FieldCaption",
                                                                                           EidssMessages.Get(
                                                                                               "colFieldName",
                                                                                               "Field name"), 200,
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


        Public Shared Sub BindLayoutLookup(ByVal cb As LookUpEdit, ByVal userId As Object, ByVal showAllItems As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strLayoutName",
                                                                                           EidssMessages.Get(
                                                                                               "colLayoutName",
                                                                                               "Layout name"), 200,
                                                                                           FormatType.None, "", True,
                                                                                           HorzAlignment.Near)}
                                           )

            cb.Properties.PopupWidth = cb.Width

            Dim dv As DataView = LookupCache.Get(LookupTables.Layout.ToString())
            Dim filter As String = String.Format("((idfUserID is null) or (idfUserID = '{0}'))", userId)
            If showAllItems = False Then
                filter = filter + " and (blnReadOnly = 1)"
            End If

            dv.RowFilter = filter
            ' dv.Table.Rows.


            SetDataSource(cb, dv, "strLayoutName", "idflLayout")
            'cb.Properties.NullText = EidssMessages.Get("NoSavedLayoutMessage")

            cb.DataBindings.Clear()
        End Sub


        Public Shared Sub BindQuerySearchFieldLookup(ByVal cb As LookUpEdit, ByVal dv As DataView, ByVal ds As DataSet,
                                                     ByVal bindField As String, ByVal ShowClearButton As Boolean)
            cb.Properties.Columns.Clear()
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("FieldCaption",
                                                                                           EidssMessages.Get(
                                                                                               "colFieldName",
                                                                                               "Field Name"), 200,
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
        '    cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("strCriteriaText", EidssMessages.Get("colCriteria", "Criteria"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("name",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
                                                                                           200, FormatType.None, "",
                                                                                           True, HorzAlignment.Near)}
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo("NationalName",
                                                                                EidssMessages.Get("colName", "Name"),
                                                                                200, FormatType.None, "", True,
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
        '    cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
        '        New LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, FormatType.None, "", True, HorzAlignment.Near)} _
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
            cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                           New LookUpColumnInfo(displayMember,
                                                                                EidssMessages.Get(actionColumnName), 200,
                                                                                FormatType.None, "", True,
                                                                                HorzAlignment.Near),
                                                           New LookUpColumnInfo(actionCodeFieldName,
                                                                                EidssMessages.Get(codeColumnName), 200,
                                                                                FormatType.None, "", True,
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
                Dim owner As LookUpEdit = Nothing
                If TypeOf sender Is RepositoryItemLookUpEdit Then
                    Dim cb As RepositoryItemLookUpEdit = CType(sender, RepositoryItemLookUpEdit)
                    r = CType(cb.DataSource, DataView).Table.Rows.Find(ID)
                    If r Is Nothing Then
                        LookupCache.Refresh(TableID, 0, False)
                        r = CType(cb.DataSource, DataView).Table.Rows.Find(ID)
                    End If
                    owner = cb.OwnerEdit
                ElseIf TypeOf sender Is LookUpEdit Then
                    Dim cb As LookUpEdit = CType(sender, LookUpEdit)
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


        Public Shared Sub BindSiteLookup(ByVal cb As LookUpEdit, ByVal ds As DataSet, ByVal bindField As String,
                                         Optional ByVal ShowClearButton As Boolean = True,
                                         Optional ByVal showSiteId As Boolean = True)
            cb.Properties.Columns.Clear()
            If showSiteId Then
                cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                          New LookUpColumnInfo("strSiteID",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteID",
                                                                                                   "Site ID"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near),
                                                                          New LookUpColumnInfo("strSiteType",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteType",
                                                                                                   "Site Type"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near),
                                                                          New LookUpColumnInfo("strSiteName",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteName",
                                                                                                   "Site Name"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                               )
            Else
                cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                          New LookUpColumnInfo("strSiteName",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteName",
                                                                                                   "Site Name"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near),
                                                                          New LookUpColumnInfo("strSiteType",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteType",
                                                                                                   "Site Type"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near),
                                                                          New LookUpColumnInfo("strSiteID",
                                                                                               EidssMessages.Get(
                                                                                                   "colSiteID",
                                                                                                   "Site ID"), 200,
                                                                                               FormatType.None, "", True,
                                                                                               HorzAlignment.Near)}
                                               )

            End If

            cb.Properties.PopupWidth = 400

            Dim dv As DataView = LookupCache.Get(LookupTables.Site)
            Dim displayMember As String = "strSiteID"
            If Not showSiteId Then displayMember = "strSiteName"

            If (Not dv Is Nothing) AndAlso (Not dv.Table Is Nothing) AndAlso
               (dv.Table.Columns.Contains(displayMember)) AndAlso
               (dv.Table.Columns.Contains("idfsSite")) Then
                dv.Sort = displayMember
                SetDataSource(cb, dv, displayMember, "idfsSite")
            End If

            AddBinding(cb, ds, bindField, ShowClearButton)
        End Sub

        Public Shared Sub BindSiteRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit,
                                                   Optional ByVal showClearButton As Boolean = True,
                                                   Optional ByVal showSiteId As Boolean = True)
            cb.Columns.Clear()
            If showSiteId Then
                cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                               New LookUpColumnInfo("strSiteID",
                                                                                    EidssMessages.Get("colSiteID",
                                                                                                      "Site ID"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near),
                                                               New LookUpColumnInfo("strSiteType",
                                                                                    EidssMessages.Get("colSiteType",
                                                                                                      "Site Type"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near),
                                                               New LookUpColumnInfo("strSiteName",
                                                                                    EidssMessages.Get("colSiteName",
                                                                                                      "Site Name"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                    )
            Else
                cb.Columns.AddRange(New LookUpColumnInfo() { _
                                                               New LookUpColumnInfo("strSiteName",
                                                                                    EidssMessages.Get("colSiteName",
                                                                                                      "Site Name"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near),
                                                               New LookUpColumnInfo("strSiteType",
                                                                                    EidssMessages.Get("colSiteType",
                                                                                                      "Site Type"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near),
                                                               New LookUpColumnInfo("strSiteID",
                                                                                    EidssMessages.Get("colSiteID",
                                                                                                      "Site ID"), 200,
                                                                                    FormatType.None, "", True,
                                                                                    HorzAlignment.Near)}
                                    )
            End If

            cb.PopupWidth = 400

            Dim dv As DataView = LookupCache.Get(LookupTables.Site)
            Dim displayMember As String = "strSiteID"
            If Not showSiteId Then displayMember = "strSiteName"

            If (Not dv Is Nothing) AndAlso (Not dv.Table Is Nothing) AndAlso
               (dv.Table.Columns.Contains(displayMember)) AndAlso
               (dv.Table.Columns.Contains("idfsSite")) Then
                dv.Sort = displayMember
                SetDataSource(cb, dv, displayMember, "idfsSite", AddressOf SetDefaultFilter,
                              AddressOf ClearDefaultFilter)
            End If
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("NationalName",
                                                                                           EidssMessages.Get("colName",
                                                                                                             "Name"),
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
            cb.Properties.Columns.AddRange(New LookUpColumnInfo() { _
                                                                      New LookUpColumnInfo("strCampaignID",
                                                                                           EidssMessages.Get(
                                                                                               "colCampaignID",
                                                                                               "Campaign ID"), 200,
                                                                                           FormatType.None, "", True,
                                                                                           HorzAlignment.Near),
                                                                      New LookUpColumnInfo("strCampaignName",
                                                                                           EidssMessages.Get(
                                                                                               "colCampaignName",
                                                                                               "Campaign Name"), 200,
                                                                                           FormatType.DateTime, "d",
                                                                                           True, HorzAlignment.Near),
                                                                      New LookUpColumnInfo("strCampaignStatus",
                                                                                           EidssMessages.Get(
                                                                                               "colCampaignStatus",
                                                                                               "Campaign Status"), 200,
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

        Private Shared HACodePopupHeight As Integer = 0

        Public Shared Sub BindReprositoryHACodeLookup(ByVal popupContainer As RepositoryItemPopupContainerEdit,
                                                      ByVal dv As DataView, ByVal gridView As GridView)
            Dim popup As PopupContainerControl = New PopupContainerControl
            popupContainer.PopupControl = popup
            HACodePopupHeight = 0
            Dim HACodePopupWidth As Integer = 0
            dv.Sort = "intHACode"
            popup.Tag = New List(Of CheckEdit)
            'AddHACode(dv, popupContainer, HACode.Animal, HACodePopupWidth)
            'AddHACode(dv, popupContainer, HACode.Avian, HACodePopupWidth)
            'AddHACode(dv, popupContainer, HACode.Livestock, HACodePopupWidth)

            'Dim listed As Hashtable = New Hashtable
            'listed(CInt(HACode.Animal)) = Nothing
            'listed(CInt(HACode.Avian)) = Nothing
            'listed(CInt(HACode.Livestock)) = Nothing
            For Each row As DataRowView In dv
                'If (listed.Contains(CInt(row("intHACode"))) = False) Then
                AddHACode(dv, popupContainer, CInt(row("intHACode")), HACodePopupWidth)
                'End If
            Next
            'Dim code As Integer = 1
            'While True
            '    If (listed.Contains(code) = False) Then
            '        If AddHACode(dv, popupContainer, code, HACodePopupWidth) = False Then Exit While
            '    End If
            '    code = code * 2
            'End While
            popup.AutoScroll = True
            popup.AutoScrollMinSize = New Size(HACodePopupWidth, HACodePopupHeight)
            RemoveHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            AddHandler popupContainer.QueryResultValue, AddressOf PopupContainerEdit_QueryResultValue
            RemoveHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            AddHandler popupContainer.QueryPopUp, AddressOf PopupContainer_QueryPopUp
            RemoveHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
            AddHandler popupContainer.QueryDisplayText, AddressOf PopupContainer_QueryDisplayText
            RemoveHandler gridView.ShowFilterPopupListBox, AddressOf HACodeColumn_ShowFilterPopupListBox
            AddHandler gridView.ShowFilterPopupListBox, AddressOf HACodeColumn_ShowFilterPopupListBox
        End Sub

        Private Shared Sub HACodeColumn_ShowFilterPopupListBox(ByVal sender As Object,
                                                               ByVal e As FilterPopupListBoxEventArgs)
            If e.Column.FieldName = "intHACode" AndAlso e.ComboBox.Items.Count > 0 Then
                For Each item As FilterItem In e.ComboBox.Items
                    If TypeOf (item.Value) Is FilterItem AndAlso CType(item.Value, FilterItem).Value.Equals(1) Then
                        e.ComboBox.Items.Remove(item)
                        Return
                    End If
                Next
            End If
        End Sub

        Private Shared Function AddHACode(ByVal dv As DataView, ByVal popupContainer As RepositoryItemPopupContainerEdit,
                                          ByVal code As Integer, ByRef HACodePopupWidth As Integer) As Boolean
            Dim found As DataRowView() = dv.FindRows(code)
            If found.Length = 0 Then Return False
            Dim check As CheckEdit = New CheckEdit
            check.Tag = code
            check.Text = found(0).Row("CodeName").ToString()
            check.Top = HACodePopupHeight
            check.Width = check.CalcBestSize().Width()
            If check.Width > HACodePopupWidth Then HACodePopupWidth = check.Width
            HACodePopupHeight += check.Height
            popupContainer.PopupControl.Controls.Add(check)
            CType(popupContainer.PopupControl.Tag, List(Of CheckEdit)).Add(check)
            'AddHandler check.CheckedChanged, AddressOf CheckedHandler
            Return True
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
            Dim HACode As Integer = 0
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                sender = CType(sender, PopupContainerEdit).Tag
            End If
            If TypeOf sender Is RepositoryItemPopupContainerEdit Then
                Dim popupContainer As RepositoryItemPopupContainerEdit = CType(sender, RepositoryItemPopupContainerEdit)
                For Each check As CheckEdit In CType(popupContainer.PopupControl.Tag, List(Of CheckEdit))
                    If check.Checked Then
                        HACode += CInt(check.Tag)
                    End If
                Next
                If Utils.IsEmpty(e.Value) AndAlso HACode = 0 Then
                    Return
                End If
                e.Value = HACode
            End If
        End Sub

        Private Shared Sub PopupContainer_QueryDisplayText(ByVal sender As Object, ByVal e As QueryDisplayTextEventArgs)
            Dim HACode As Integer = 0
            If Utils.IsEmpty(e.EditValue) = False Then
                HACode = CType(e.EditValue, Integer)
            End If
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                sender = CType(sender, PopupContainerEdit).Tag
            End If

            If TypeOf sender Is RepositoryItemPopupContainerEdit Then
                Dim popupContainer As RepositoryItemPopupContainerEdit = CType(sender, RepositoryItemPopupContainerEdit)
                e.DisplayText = ""
                For Each check As CheckEdit In CType(popupContainer.PopupControl.Tag, List(Of CheckEdit))
                    Dim bitSet As Boolean = (CInt(check.Tag) And HACode) <> 0
                    'SetChecked(check, bitSet)
                    If bitSet Then
                        Utils.AppendLine(e.DisplayText, check.Text, ", ")
                    End If
                Next
            Else
                Dbg.Debug("unexpected type")
            End If
        End Sub

        Private Shared Sub PopupContainer_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim HACode As Integer = 0
            If TypeOf sender Is PopupContainerEdit AndAlso Not CType(sender, PopupContainerEdit) Is Nothing Then
                If Utils.IsEmpty(CType(sender, PopupContainerEdit).EditValue) = False Then
                    HACode = CType(CType(sender, PopupContainerEdit).EditValue, Integer)
                End If
                sender = CType(sender, PopupContainerEdit).Tag
            End If

            If TypeOf sender Is RepositoryItemPopupContainerEdit Then
                Dim popupContainer As RepositoryItemPopupContainerEdit = CType(sender, RepositoryItemPopupContainerEdit)
                popupContainer.PopupControl.Size = New Size(200, popupContainer.PopupControl.AutoScrollMinSize.Height)
                For Each check As CheckEdit In CType(popupContainer.PopupControl.Tag, List(Of CheckEdit))
                    Dim bitSet As Boolean = (CInt(check.Tag) And HACode) <> 0
                    SetChecked(check, bitSet)
                Next
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
            cb.Columns.AddRange(New LookUpColumnInfo() {New LookUpColumnInfo("ExtendedName",
                                                                             EidssMessages.Get("colName", "Name"),
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
            BindBaseLookup(cb, ds, bindField, db.BaseReferenceType.rftSpecimenType, False)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddSampleType"))
                AddButtonClickHandler(cb, AddressOf AddSampleType)
            End If
            AddBinding(cb, ds, bindField, True, GetDefSamplesFilter())
        End Sub

        Public Shared Sub BindSampleRepositoryLookup(ByVal cb As RepositoryItemLookUpEdit, haCode As HACode,
                                                     Optional ByVal showPlusButton As Boolean = True,
                                                     Optional ByVal showClearButton As Boolean = True)
            BindBaseRepositoryLookup(cb, db.BaseReferenceType.rftSpecimenType, haCode, False, showClearButton)
            If showPlusButton Then
                AddPlusButton(cb, EidssMessages.Get("msgAddSampleType"))
                AddButtonClickHandler(cb, AddressOf AddSampleType)
            End If
            RemoveDefaultFilterHandlers(cb)
            AddSetDefaultFilterHandler(cb, AddressOf SetSampleDefaultFilter)
            AddClearDefaultFilterHandler(cb, AddressOf ClearSampleDefaultFilter)
        End Sub

        Public Shared Sub SetSampleDefaultFilter(sender As Object, e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            If (Utils.IsEmpty(cb.EditValue)) Then
                view.RowFilter = String.Format("intRowStatus = 0 and ({0})", GetDefSamplesFilter())
            Else
                view.RowFilter = String.Format("(intRowStatus = 0 or {0}={1}) and ({2})", cb.Properties.ValueMember,
                                               cb.EditValue, GetDefSamplesFilter())
            End If
        End Sub

        Public Shared Sub ClearSampleDefaultFilter(sender As Object, e As CancelEventArgs)
            Dim cb As LookUpEdit = CType(sender, LookUpEdit)
            If cb.Properties.DataSource Is Nothing OrElse Not TypeOf (cb.Properties.DataSource) Is DataView Then
                Return
            End If
            Dim view As DataView = CType(cb.Properties.DataSource, DataView)
            view.RowFilter = GetDefSamplesFilter()
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

        Public Shared Sub SetInitialCaseClassificationFilter(cb As LookUpEdit)
            If cb Is Nothing OrElse cb.Properties.DataSource Is Nothing Then
                Return
            End If
            CType(cb.Properties.DataSource, DataView).RowFilter =
                String.Format(
                    "idfsReference = 350000000 or idfsReference = 360000000 or idfsReference = 380000000 or idfsReference = {0}",
                    LookupCache.EmptyLineKey)  'confirmed or probable or suspect
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
    End Class
End Namespace
