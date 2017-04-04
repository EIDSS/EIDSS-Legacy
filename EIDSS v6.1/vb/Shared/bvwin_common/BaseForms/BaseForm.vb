Imports bv.common.win.BaseForms
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports bv.common.db
Imports System.ComponentModel
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports System.Collections.Generic
Imports DevExpress.XtraBars
Imports bv.common.Enums
Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports bv.winclient.Core.TranslationTool
Imports bv.winclient.Layout
Imports bv.common.Resources
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.winclient.Localization
Imports System.Globalization
Imports System.Data.SqlClient
Imports bv.model.Helpers
Imports DevExpress.XtraTab
Imports Utils = bv.common.Core.Utils

''' -----------------------------------------------------------------------------
''' <summary>
''' Defines the development status of the form. 
''' </summary>
''' <remarks>
''' The forms having <b>Demo</b> status are opened in run-time without trying to connect to database.
''' Use <b>Demo</b> status if you want just demostrate form GUI without applying any database 
''' functionality for it.
''' All other statuses provides the same form behaviour and has only infomational difference.
''' </remarks>
''' <history>
''' 	[Mike]	26.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum FormStatus
    Demo
    Draft
    Functional
    Finished
End Enum
Public Enum ClosingMode
    None
    Ok
    Cancel
    Delete
End Enum


''' -----------------------------------------------------------------------------
''' Project	 : bvwin_common
''' Class	 : common.win.BaseForm
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' <i>BaseForm</i> class is intended to be used as the base class for all forms that should 
''' be shown on the main application form. It implements basic common methods and properties 
''' that can be used by inherited forms and set of virtual methods and properties that should 
''' be overwritten in the inherited classes.
''' </summary>
''' <remarks>
''' Do not use <i>BaseForm</i> class directly. The system provides several specialized classes inherited from <i>BaseForm</i> that
''' should be used as parent classes for real forms creation.
'''
''' </remarks>
''' <history>
''' 	[Mike]	26.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class BaseForm
    Inherits BvXtraUserControl
    Implements IApplicationForm
    Implements IRelatedObject
    Implements IPostable
    'Implements ITranslationView
    Public eventManager As New DataEventManager(Me)
    Protected Shared m_CurrentForm As BaseForm

    'Public Shared formSettings As New ConfigWriter
    Public Delegate Function CanDeleteRowHandler(ByVal row As DataRow) As Boolean

    Protected m_ClosingProcessed As Boolean = False
    Protected m_WasSaved As Boolean = False ' should be set to true during intermediate posting
    Protected m_LastFocusedControl As Control = Nothing
    Protected Shared AppWaitCount As Int32 = 0
    Friend WithEvents GroupStyleController As StyleController
    Friend WithEvents TabStyleController As StyleController
    Public Shared ShowFromID As Boolean = True
    Public Event OnValidatingData As ValidatingHandler
    Private ReadOnly m_Validators As New List(Of IValidator)
    Protected m_ClosingMode As ClosingMode
    Public Sub SetClosingMode(mode As ClosingMode)
        m_ClosingMode = mode
    End Sub

    Public ReadOnly Property Validators As List(Of IValidator)
        Get
            Return m_Validators
        End Get
    End Property


#Region " Windows Form Designer generated code "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new instance of <i>BaseForm</i> class.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        MyBase.New()
        Visible = False
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.UpdateStyles()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        If Not IsDesignMode() AndAlso Not BaseSettings.ScanFormsMode Then
            AddHandler Application.Idle, AddressOf UpdateButtonsState
        End If
        'If formSettings.Initialized = False Then
        '    Try
        '        formSettings.Read(Path.GetDirectoryName(Application.ExecutablePath) + "\formlayout.xml")
        '    Catch ex As Exception
        '        Trace.WriteLine(Trace.Kind.Error, String.Format("Cannot load settings for {0}", Me.GetType().Name))
        '    End Try
        'End If
        'InitDefaultFont()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        m_Closing = True
        Try
            If disposing Then
                RemoveIdleHandler()
                If Me.ParentObject Is Nothing Then
                    MemoryManager.Flush()
                End If
                eventManager.Clear(Me)
                m_Comparer.Clear()
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            If Not m_Canvas Is Nothing Then
                m_Canvas.Dispose()
            End If
            If Not m_OldParent Is Nothing Then
                RemoveHandler m_OldParent.BackColorChanged, AddressOf BaseForm_BackColorChanged
            End If

            ' this call needs because of memory leak when layout helper has references to disposed form
            LayoutCorrector.Reset()

            If UseParentDataset = False Then
                DbDisposeHelper.DisposeDataset(m_dataSet)
            End If
            DbDisposeHelper.DisposeDataset(m_ChangesDataset)

            eventManager.ClearAllReferences()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents HelpProvider1 As bv.winclient.Core.Help2Provider
    Friend WithEvents EditStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents ButtonStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents MandatoryFieldStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents PopupEditStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents ReadOnlyStyleController As DevExpress.XtraEditors.StyleController

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(BaseForm))
        Me.ImageList1 = New System.Windows.Forms.ImageList()
        Me.HelpProvider1 = New bv.winclient.Core.Help2Provider()
        Me.EditStyleController = New DevExpress.XtraEditors.StyleController()
        Me.ButtonStyleController = New DevExpress.XtraEditors.StyleController()
        Me.MandatoryFieldStyleController = New DevExpress.XtraEditors.StyleController()
        Me.PopupEditStyleController = New DevExpress.XtraEditors.StyleController()
        Me.ReadOnlyStyleController = New DevExpress.XtraEditors.StyleController()
        Me.GroupStyleController = New DevExpress.XtraEditors.StyleController()
        Me.TabStyleController = New DevExpress.XtraEditors.StyleController()
        CType(Me.EditStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MandatoryFieldStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupEditStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReadOnlyStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(BaseForm), resources)
        'Form Is Localizable: True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList1, "ImageList1")
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = Nothing
        '
        'MandatoryFieldStyleController
        '
        Me.MandatoryFieldStyleController.Appearance.BackColor =
            CType(resources.GetObject("MandatoryFieldStyleController.Appearance.BackColor"), System.Drawing.Color)
        Me.MandatoryFieldStyleController.Appearance.BorderColor =
            CType(resources.GetObject("MandatoryFieldStyleController.Appearance.BorderColor"), System.Drawing.Color)
        Me.MandatoryFieldStyleController.Appearance.Font =
            CType(resources.GetObject("MandatoryFieldStyleController.Appearance.Font"), System.Drawing.Font)
        Me.MandatoryFieldStyleController.Appearance.Options.UseBackColor = True
        Me.MandatoryFieldStyleController.Appearance.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.Appearance.Options.UseFont = True
        Me.MandatoryFieldStyleController.AppearanceDisabled.BorderColor =
            CType(resources.GetObject("MandatoryFieldStyleController.AppearanceDisabled.BorderColor"), 
                  System.Drawing.Color)
        Me.MandatoryFieldStyleController.AppearanceDisabled.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.AppearanceDropDown.BorderColor =
            CType(resources.GetObject("MandatoryFieldStyleController.AppearanceDropDown.BorderColor"), 
                  System.Drawing.Color)
        Me.MandatoryFieldStyleController.AppearanceDropDown.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.AppearanceDropDownHeader.BorderColor =
            CType(resources.GetObject("MandatoryFieldStyleController.AppearanceDropDownHeader.BorderColor"), 
                  System.Drawing.Color)
        Me.MandatoryFieldStyleController.AppearanceDropDownHeader.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        '
        'PopupEditStyleController
        '
        Me.PopupEditStyleController.Appearance.BackColor =
            CType(resources.GetObject("PopupEditStyleController.Appearance.BackColor"), System.Drawing.Color)
        Me.PopupEditStyleController.Appearance.Font =
            CType(resources.GetObject("PopupEditStyleController.Appearance.Font"), System.Drawing.Font)
        Me.PopupEditStyleController.Appearance.Options.UseBackColor = True
        Me.PopupEditStyleController.Appearance.Options.UseFont = True
        '
        'GroupStyleController
        '
        Me.GroupStyleController.Appearance.BackColor =
            CType(resources.GetObject("GroupStyleController.Appearance.BackColor"), System.Drawing.Color)
        Me.GroupStyleController.Appearance.BackColor2 =
            CType(resources.GetObject("GroupStyleController.Appearance.BackColor2"), System.Drawing.Color)
        Me.GroupStyleController.Appearance.Options.UseBackColor = True
        '
        'TabStyleController
        '
        Me.TabStyleController.Appearance.BackColor = CType(resources.GetObject("TabStyleController.Appearance.BackColor"), 
                                                           System.Drawing.Color)
        Me.TabStyleController.Appearance.BackColor2 =
            CType(resources.GetObject("TabStyleController.Appearance.BackColor2"), System.Drawing.Color)
        Me.TabStyleController.Appearance.Options.UseBackColor = True
        '
        'BaseForm
        '
        resources.ApplyResources(Me, "$this")
        Me.HelpProvider1.SetHelpKeyword(Me, Nothing)
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.AssociateIndex)
        Me.HelpProvider1.SetHelpString(Me, Nothing)
        Me.Name = "BaseForm"
        Me.HelpProvider1.SetShowHelp(Me, False)
        CType(Me.EditStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MandatoryFieldStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupEditStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReadOnlyStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabStyleController, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region


#Region "Public Methods"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Closes the current <b>BaseForm</b> instance and force the parent form to return <b>DialogResult.Cancel</b> if it was shown as modal form.
    ''' </summary>
    ''' <remarks>
    ''' This method is called by default in the descendant classes when <b>Cancel</b> button is called.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub DoClose()
        Try
            m_Closing = True
            m_ClosingProcessed = True
            SaveGridLayoutsRecursive()
            RemoveIdleHandler()
            Dim disposed As Boolean = False
            If Not ParentForm Is Nothing Then
                If ParentForm.Modal Then
                    ParentForm.DialogResult = DialogResult.Cancel
                    ParentForm.Close()
                    disposed = True
                ElseIf Not ParentForm Is BaseFormManager.MainForm Then
                    ParentForm.Close()
                    disposed = True
                End If
            End If
            BaseFormManager.Close(Me)
            If Not disposed Then Dispose()
        Catch ex As Exception
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            ErrorForm.ShowError(StandardError.UnprocessedError, ex)
        Finally
            m_Closing = False
            'DisplayCaption()
        End Try
    End Sub
    Protected Sub SaveGridLayoutsRecursive()
        SaveGridLayouts()
        For Each bf As IRelatedObject In m_ChildForms
            CType(bf, BaseForm).SaveGridLayoutsRecursive()
        Next
    End Sub
    Protected Overridable Sub SaveGridLayouts()
    End Sub
    Protected Overridable Sub LoadGridLayouts()
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Closes the current <b>BaseForm</b> instance and force the parent form to return <b>DialogResult.OK</b> if it was shown as modal form.
    ''' </summary>
    ''' <remarks>
    ''' This method is called by default in the descendant classes when <b>Ok</b> button is called.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub DoOk()
        Try
            m_Closing = True
            m_ClosingProcessed = True
            RemoveIdleHandler()
            Dim disposed As Boolean = False
            If Not ParentForm Is Nothing Then
                If ParentForm.Modal Then
                    ParentForm.DialogResult = DialogResult.OK
                    disposed = True
                ElseIf Not ParentForm Is BaseFormManager.MainForm Then
                    ParentForm.Close()
                    disposed = True
                End If
            End If
            SaveGridLayoutsRecursive()
            BaseFormManager.Close(Me, DialogResult.OK, FormClosingMode.NoSave) 'UnRegister(Me)
            'If AppType = ApplicationType.SDI Then Me.Dispose()???Why I commented it?
            If Not disposed Then Dispose()
        Catch ex As Exception
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            ErrorForm.ShowError(StandardError.UnprocessedError, ex)
        Finally
            m_Closing = False
            'DisplayCaption()
        End Try
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns primary key field value related with the current <b>BaseForm</b> <b>DataRow</b>. 
    ''' </summary>
    ''' <param name="aTableName">
    ''' the name of the table in the <see cref="baseDataSet"/> that contains the primary key.
    ''' </param>
    ''' <param name="aKeyFieldName">
    ''' the primary key field name.
    ''' </param>
    ''' <returns>
    ''' Returns the <b>BaseForm</b> related primary key if it is defined or <b>Nothing</b> in other case.
    ''' </returns>
    ''' <remarks>
    ''' If <paramref name="aTableName"/> and <paramref name="aKeyFieldName"/> parameters are not specified,
    ''' the <see cref="ObjectName"/> and <see cref="KeyFieldName"/> are used as default values for this parameters.
    ''' The <b>GetKey</b> returns the primary key related with the current grid row for the list form and 
    ''' the primary key of the main detail form object for the detail form . 
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overridable Function GetKey(Optional ByVal aTableName As String = Nothing,
                                       Optional ByVal aKeyFieldName As String = Nothing) As Object
        If baseDataSet Is Nothing Then
            Return Nothing
        End If
        If aTableName Is Nothing Then
            If baseDataSet.Tables.Contains(ObjectName) Then
                aTableName = ObjectName
            ElseIf baseDataSet.Tables.Contains(TableName) Then
                aTableName = TableName
            ElseIf baseDataSet.Tables.Count > 0 Then
                aTableName = baseDataSet.Tables(0).TableName
            End If
        End If
        If aKeyFieldName Is Nothing Then aKeyFieldName = KeyFieldName
        Dim r As DataRow = GetCurrentRow(aTableName)
        If Not r Is Nothing Then
            Try
                If Not aKeyFieldName Is Nothing Then
                    Return r(aKeyFieldName)
                ElseIf r.Table.Columns.Count > 0 Then
                    Dbg.Debug("base form {0} has no key field name. First column is used for key retrieving",
                              Me.GetType.Name)
                    Return r(0)
                End If
            Catch ex As Exception
                If (BaseSettings.ThrowExceptionOnError) Then
                    Throw
                End If
                Dbg.Debug("primary key for form {0} is not defined", Me.GetType.Name)
                Return Nothing
            End Try
        End If
        Return Nothing
    End Function

    Public Overridable Function GetRecordKey(ByVal row As DataRow, Optional ByVal aKeyFieldName As String = Nothing) _
        As Object
        If row Is Nothing Then
            Return Nothing
        End If
        Try
            If Not aKeyFieldName Is Nothing Then
                Return row(aKeyFieldName)
            Else
                If Not row.Table.PrimaryKey Is Nothing Then
                    If row.Table.PrimaryKey.Length = 1 Then
                        Return row(row.Table.PrimaryKey(0).ColumnName)
                    End If
                End If
                Return row(0)
            End If
        Catch ex As Exception
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            Dbg.Debug("primary key for form {0} is not defined", Me.GetType.Name)
            Return Nothing
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Reloads data in the current <b>BaseForm</b> if it exists.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ReloadCurrentForm()
        If Not m_CurrentForm Is Nothing Then
            Try
                Dim id As Object = Nothing
                m_CurrentForm.LoadData(id)
            Catch ex As Exception
                If (BaseSettings.ThrowExceptionOnError) Then
                    Throw
                End If
                ErrorForm.ShowError(StandardError.UnprocessedError, ex)
            End Try
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the specific field value in the first <b>DataRow</b> of the spesific <see cref="baseDataSet"/> table.
    ''' </summary>
    ''' <param name="TableName">
    ''' the name of <b>DataTable</b> in the <see cref="baseDataSet"/>
    ''' </param>
    ''' <param name="FieldName">
    ''' the name of the field to set
    ''' </param>
    ''' <param name="Val">
    ''' the field value to set
    ''' </param>
    ''' <returns>
    ''' Returns <b>DataRow</b> that was modified or nothing if some error occured.
    ''' </returns>
    ''' <remarks>
    ''' Use <b>SetDetailTableValue</b> if you need to set the field value even if the requested <b>DataTable</b> has no records.
    ''' In this case the new <b>DataRow</b> will be created , 
    ''' inserted into the <b>DataTable</b>, initialized with passed value and returned.
    ''' <note>
    ''' This method will have the effect only if <see cref="DbService"/> property is initialized 
    ''' with form related <see cref="bv.common.db.BaseDbService"/>.
    ''' </note>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function SetDetailTableValue(ByVal TableName As String, ByVal FieldName As String, ByVal Val As Object) _
        As DataRow
        If DbService Is Nothing Then
            Return Nothing
        End If
        Return BaseDbService.SetDetailTableValue(baseDataSet.Tables(TableName), FieldName, Val)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Links all child controls of the <paramref name="ctl"/> control to the <see cref="eventManager"/>.
    ''' </summary>
    ''' <param name="ctl">
    ''' the control to wire
    ''' </param>
    ''' <remarks>
    ''' All <b>BaseForm</b> controls that are created in the design time are wired to the <see cref="eventManager"/>
    ''' automatically. Use this method to wire the control that is created in the run time.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub WireControl(Optional ByVal ctl As Control = Nothing)
        eventManager.WireForm(ctl)
    End Sub

#End Region

#Region "Shared Methods"

    Protected Shared FormsList As New ArrayList
    Private Shared m_BarManager As BarManager

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shared Property MainBarManager() As BarManager
        Get
            Return m_BarManager
        End Get
        Set(ByVal Value As BarManager)
            m_BarManager = Value
        End Set
    End Property

    Public Shared Sub OnFormActivate(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf (sender) Is Form Then
            Dim frm As Form = CType(sender, Form)
            For Each c As Control In frm.Controls
                If TypeOf (c) Is BaseForm Then
                    'SetCurrentForm(CType(c, BaseForm))
                    'If TypeOf (c) Is BaseListForm Then
                    '    If CType(c, BaseListForm).Loading Then Exit Sub
                    '    If CType(c, BaseListForm).LoadData(Nothing) = False Then
                    '        CType(c, BaseListForm).DoClose()
                    '    End If
                    'End If
                End If
            Next
        End If
    End Sub

    Public Shared Sub OnFormClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
        If TypeOf (sender) Is Form Then
            Dim frm As Form = CType(sender, Form)
            For Each c As Control In frm.Controls
                If TypeOf (c) Is BaseForm Then
                    If CType(c, BaseForm).Loading Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            Next

            For Each c As Control In frm.Controls
                If TypeOf (c) Is BaseForm Then
                    'CType(c, BaseForm).SaveFormLayout()
                    'RemoveForm(CType(c, BaseForm))
                End If
            Next
        End If
    End Sub


    Public Function CanOpenForm(ByVal ID As Object) As Boolean
        If FormType = BaseFormType.DetailForm AndAlso ID Is Nothing AndAlso CanCreateObject() Then
            Return True
        ElseIf CanViewObject() Then
            Return True
        End If
        Return False
    End Function

    Public Function CanViewObject() As Boolean
        If (Not Permissions.CanSelect) AndAlso (Not Permissions.CanExecute) Then
            MessageForm.Show(BvMessages.Get("msgNoSelectPermission", "You have no rights to view this form"))
            Return False
        End If
        Return True
    End Function

    Public Function CanCreateObject() As Boolean
        If Not Permissions.CanInsert Then
            MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"))
            Return False
        End If
        Return True
    End Function

    Public Function CanDeleteObject() As Boolean
        If Not Permissions.CanDelete Then
            MessageForm.Show(BvMessages.Get("msgNoDeletePermission", "You have no rights to delete this object"))
            Return False
        End If
        Return True
    End Function


    Public Shared Function FindRow(ByVal t As DataTable, ByVal fieldValue As Object,
                                   Optional ByVal FieldName As String = Nothing) As DataRow
        Return BaseDbService.FindRow(t, fieldValue, FieldName)
    End Function


    Public Shared Sub WaitIncrement(ByVal value As Int32)
        AppWaitCount += value
    End Sub

    Public Shared Function BeginWaitCursor() As Int32
        AppWaitCount += 1

        If (AppWaitCount > 0) Then
            'ctl.Cursor = Cursors.AppStarting
            Cursor.Current = Cursors.AppStarting
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "BeginWaitCursor: to Wait; count = {0}", AppWaitCount)
        End If

        Return AppWaitCount
    End Function

    Public Shared Function EndWaitCursor() As Int32
        AppWaitCount -= 1

        If (AppWaitCount <= 0) Then
            'ctl.Cursor = Cursors.Arrow
            Cursor.Current = Cursors.Arrow
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "EndWaitCursor: to Default; count = {0}", AppWaitCount)
        End If

        Return AppWaitCount
    End Function

#End Region

#Region "Overridable Methods"

    Public Overridable Sub Merge(ByVal ds As DataSet)
        baseDataSet.EnforceConstraints = ds.EnforceConstraints
        baseDataSet.Merge(ds, True)
        'If (baseDataSet.EnforceConstraints) Then
        For Each dt As DataTable In baseDataSet.Tables
            For Each col As DataColumn In dt.Columns
                If ds.Tables.Contains(dt.TableName) AndAlso ds.Tables(dt.TableName).Columns.Contains(col.ColumnName) _
                    Then
                    col.AllowDBNull = ds.Tables(dt.TableName).Columns(col.ColumnName).AllowDBNull
                End If
            Next
        Next
        'End If
    End Sub

    Public Overridable Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        Return True
    End Function

    Protected Sub RefreshChildLayout()

        For Each child As IRelatedObject In m_ChildForms
            If Not (TypeOf (child) Is BaseForm) Then Continue For

            CType(child, BaseForm).RefreshLayout()
            CType(child, BaseForm).RefreshChildLayout()
        Next
    End Sub

    Protected Overridable Sub RefreshLayout()
    End Sub

    Protected Overridable Sub ClearBinding(ByVal ctl As Control)
        eventManager.Clear(ctl)
    End Sub

    Protected Sub ResetBinding()
        ClearBinding(Me)
        DefineBinding()
    End Sub

    Protected Overridable Sub DefineBinding()
    End Sub

    Protected Overridable Sub RegisterValidators()
    End Sub

    Protected Overridable Sub AfterLoad()
    End Sub

    Public Event OnBeforePost As EventHandler
    Public Event OnAfterPost As EventHandler

    Protected Sub RaiseBeforePostEvent(ByVal sender As Object)
        RaiseEvent OnBeforePost(sender, EventArgs.Empty)
        If TypeOf sender Is IRelatedObject AndAlso Not CType(sender, IRelatedObject).Children Is Nothing Then
            For Each child As IRelatedObject In CType(sender, IRelatedObject).Children
                If TypeOf child Is BaseForm Then
                    CType(child, BaseForm).RaiseBeforePostEvent(child)
                Else
                    RaiseEvent OnBeforePost(child, EventArgs.Empty)
                End If
            Next
        End If
    End Sub

    Protected Sub RaiseAfterPostEvent(ByVal sender As Object)
        RaiseEvent OnAfterPost(sender, EventArgs.Empty)
        eventManager.HasChanges = False
        If TypeOf sender Is IRelatedObject AndAlso Not CType(sender, IRelatedObject).Children Is Nothing Then
            For Each child As IRelatedObject In CType(sender, IRelatedObject).Children
                If TypeOf child Is BaseForm Then
                    CType(child, BaseForm).RaiseAfterPostEvent(child)
                Else
                    RaiseEvent OnAfterPost(child, EventArgs.Empty)
                End If
            Next
        End If
    End Sub

    Public Event OnBeforeValidating As EventHandler

    Protected Sub RaiseBeforeValidatingEvent()
        RaiseEvent OnBeforeValidating(Me, EventArgs.Empty)
    End Sub

    Public Overridable Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean _
        Implements IPostable.Post

        If ValidateData() = False Then Return False
        m_WasPosted = True
        Return True
    End Function

    'Public Overridable Function GetCurrentRow() As DataRow
    '    Return Nothing
    'End Function
    Public Overridable Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        Return Nothing
    End Function

    Public Overridable Function GetClientHeight() As Integer
        Return Height
    End Function

    Public Function GetCurrentRow(Optional ByVal aTableName As String = Nothing) As DataRow
        If aTableName Is Nothing Then
            aTableName = ObjectName
        End If
        If aTableName Is Nothing AndAlso baseDataSet.Tables.Count > 0 Then
            aTableName = baseDataSet.Tables(0).TableName
            Dbg.Debug("base form {0} has no object/table name. First table in dataset is used for key receiving",
                      Me.GetType.Name)
        End If
        If aTableName Is Nothing Then Return Nothing
        Dim bm As BindingManagerBase = GetBindingManager(aTableName)
        If bm Is Nothing OrElse bm.Position < 0 Then Return Nothing
        If TypeOf bm.Current Is DataRow Then
            Return CType(bm.Current, DataRow)
        ElseIf TypeOf bm.Current Is DataRowView Then
            Return CType(bm.Current, DataRowView).Row
        End If
        Return Nothing
    End Function

    Public Shared Function GetControlCurrentRow(ByVal ctl As Control) As DataRow
        If ctl.DataBindings.Count > 0 Then
            Dim bm As BindingManagerBase = ctl.DataBindings(0).BindingManagerBase
            If bm Is Nothing OrElse bm.Position < 0 Then Return Nothing
            If TypeOf bm.Current Is DataRow Then
                Return CType(bm.Current, DataRow)
            ElseIf TypeOf bm.Current Is DataRowView Then
                Return CType(bm.Current, DataRowView).Row
            End If
        End If
        Return Nothing
    End Function

    Public Overridable Function GetSelectedRows() As DataRow()
        Return Nothing
    End Function

    Public Overridable Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Public Sub SetMandatoryFieldVisible(ByVal c As Control, ByVal value As Boolean)
        c.Visible = value
        c.Enabled = value
    End Sub

    Private Function IsMandatoryFieldEmpty(ByVal c As Control) As Boolean
        If c.DataBindings.Count > 0 Then
            Dim bmanager As BindingManagerBase = c.DataBindings(0).BindingManagerBase
            If Not bmanager Is Nothing AndAlso bmanager.Count > 0 AndAlso bmanager.Position >= 0 Then
                Try
                    If _
                        TypeOf bmanager.Current Is DataRowView AndAlso
                        Not CType(bmanager.Current, DataRowView).Row Is Nothing _
                        AndAlso CType(bmanager.Current, DataRowView).Row.RowState <> DataRowState.Detached Then
                        If _
                            Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper AndAlso
                            Not Utils.IsEmpty(TagHelper.GetTagHelper(c).MandatoryFieldName) Then
                            Return _
                                Utils.IsEmpty(
                                    CType(bmanager.Current, DataRowView)(TagHelper.GetTagHelper(c).MandatoryFieldName))
                        End If

                        Return _
                            Utils.IsEmpty(
                                CType(bmanager.Current, DataRowView)(c.DataBindings(0).BindingMemberInfo.BindingField))
                    End If
                Catch ex As Exception
                    If (BaseSettings.ThrowExceptionOnError) Then
                        Throw
                    End If
                    Dbg.Debug("error during reading mandatory value from field {0}",
                              c.DataBindings(0).BindingMemberInfo.BindingPath)
                End Try
            End If
        End If
        Return Utils.IsEmpty(CType(c, BaseEdit).EditValue) OrElse Utils.IsEmpty(c.Text)
    End Function

    Protected Sub ShowErrorAtValidateMandatoryFields(ByVal c As Control)
        ShowErrorAtValidateMandatoryFields(c, GetControlLabel(c))
    End Sub

    Protected Sub ShowErrorAtValidateMandatoryFields(ByVal c As Control, ByVal fieldName As String)
        WinUtils.ShowMandatoryError(fieldName)
        FocusOnField(c)
    End Sub

    Protected Sub FocusOnField(ByVal c As Control)
        BringUpCurrentTab(c)
        c.Select()
    End Sub

    Protected Function GetMandatoryFieldName(ByVal c As Control) As String
        If c Is Nothing OrElse c.DataBindings.Count <= 0 Then
            Return ""
        End If
        Return c.DataBindings(0).BindingMemberInfo.BindingMember
    End Function

    Protected Function ValidateMandatoryFields(ByVal p As Control) As Boolean
        If p Is Nothing Then Return True
        If p.GetType.Name = "FFPresenter" Then
            Return True
        End If
        For Each c As Control In p.Controls
            If TypeOf c Is BaseForm Then
                Continue For
            End If
            If TypeOf (c) Is BaseEdit AndAlso c.Enabled Then 'AndAlso c.Visible 
                Dim be As BaseEdit = CType(c, BaseEdit)
                If Not c.Tag Is Nothing Then
                    Dim th As TagHelper
                    If Not TypeOf (c.Tag) Is TagHelper Then
                        th = New TagHelper(c)
                    Else
                        th = CType(c.Tag, TagHelper)
                    End If
                    If th.IsMandatory Then
                        If IsMandatoryFieldEmpty(c) Then
                            Dim e As New ValidatingEventArgs(GetKey, GetMandatoryFieldName(c))
                            RaiseEvent OnValidatingData(c, e)
                            If e.Cancel Then
                                Return True
                            End If
                            ShowErrorAtValidateMandatoryFields(c)
                            Return False
                        End If
                    End If
                End If
            End If
            If ValidateMandatoryFields(c) = False Then
                Return False
            End If
        Next
        If TypeOf (p) Is PopupContainerEdit AndAlso p.Visible Then
            Return ValidateMandatoryFields(CType(p, PopupContainerEdit).Properties.PopupControl)
        End If
        Return True
    End Function

    Public Overridable Function GetControlLabel(ByVal ctl As Control) As String
        Dim p As Control = ctl.Parent
        If Not p Is Nothing Then
            For Each c As Control In p.Controls
                If (TypeOf (c) Is Label OrElse TypeOf (c) Is LabelControl) AndAlso (c.Visible OrElse p.Visible = False) _
                    Then
                    Dim middle As Double = c.Top + c.Height / 2
                    If (bv.common.Core.Localizer.IsRtl) Then
                        If middle >= ctl.Top AndAlso
                           middle <= (ctl.Top + ctl.Height) AndAlso
                           c.Right > ctl.Right AndAlso
                           (c.Left - ctl.Left - ctl.Width) < 100 Then
                            Return c.Text
                        End If
                    Else
                        If middle >= ctl.Top AndAlso
                           middle <= (ctl.Top + ctl.Height) AndAlso
                           c.Left < ctl.Left AndAlso
                           (ctl.Left - c.Left - c.Width) < 100 Then
                            Return c.Text
                        End If
                    End If

                End If
            Next
        End If
        'This is done to go around the problem with mandatory Age field on PatientInfo panel
        'The label is invisible
        If Not p Is Nothing Then
            For Each c As Control In p.Controls
                If (TypeOf (c) Is Label OrElse TypeOf (c) Is LabelControl) Then
                    Dim middle As Double = c.Top + c.Height / 2
                    If middle >= ctl.Top AndAlso
                       middle <= (ctl.Top + ctl.Height) AndAlso
                       c.Left < ctl.Left AndAlso
                       (ctl.Left - c.Left - c.Width) < 100 Then
                        Return c.Text
                    End If

                End If
            Next
        End If
        Dim filedCaption As String = GetCaptionByFieldName(GetMandatoryFieldName(ctl))
        If Not String.IsNullOrEmpty(filedCaption) Then
            Return filedCaption
        End If
        Return ctl.Name
    End Function

    Protected Overridable Function GetCaptionByFieldName(ByVal fieldName As String) As String
        Return Nothing
    End Function


    Protected m_MultiSelect As Boolean

    <Localizable(False)>
    Public Overridable Property MultiSelect() As Boolean
        Get
            Return m_MultiSelect
        End Get
        Set(ByVal Value As Boolean)
            m_MultiSelect = Value
        End Set
    End Property

#End Region

#Region "Public Properies"


    Dim m_MinWidth As Integer = 0

    <Browsable(True), DefaultValue(0), Localizable(False)>
    Public Property MinWidth() As Integer Implements IApplicationForm.MinWidth
        Get
            Return m_MinWidth
        End Get
        Set(ByVal Value As Integer)
            m_MinWidth = Value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)>
    Public Overridable ReadOnly Property IsSingleTone() As Boolean Implements IApplicationForm.IsSingleTone
        Get
            Return False
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)>
    Public Property RtlRecalcWidth() As Integer Implements IApplicationForm.RtlRecalcWidth

    Dim m_MinHeight As Integer = 0

    <Browsable(True), DefaultValue(0), Localizable(False)>
    Public Property MinHeight() As Integer Implements IApplicationForm.MinHeight
        Get
            Return m_MinHeight
        End Get
        Set(ByVal Value As Integer)
            m_MinHeight = Value
        End Set
    End Property


    Dim m_Sizable As Boolean = False

    <Browsable(True), DefaultValue(False), Localizable(False)>
    Public Property Sizable() As Boolean Implements IApplicationForm.Sizable
        Get
            Return m_Sizable
        End Get
        Set(ByVal Value As Boolean)
            m_Sizable = Value
        End Set
    End Property

    Dim m_DefaultFormState As FormWindowState = FormWindowState.Normal

    <Browsable(True), DefaultValue(FormWindowState.Normal), Localizable(False)>
    Public Property DefaultFormState() As FormWindowState
        Get
            Return m_DefaultFormState
        End Get
        Set(ByVal Value As FormWindowState)
            m_DefaultFormState = Value
        End Set
    End Property

    Protected m_StartUpParameters As Dictionary(Of String, Object)

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)>
    Public Overridable Property StartUpParameters() As Dictionary(Of String, Object) _
        Implements IApplicationForm.StartUpParameters
        Get
            Return m_StartUpParameters
        End Get
        Set(ByVal Value As Dictionary(Of String, Object))
            m_StartUpParameters = Value
        End Set
    End Property

    Protected m_Loading As Integer = 0

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable ReadOnly Property Loading() As Boolean
        Get
            Return m_Loading > 0
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property RootBaseForm() As BaseForm
        Get
            If Not ParentObject Is Nothing AndAlso TypeOf ParentObject Is BaseForm Then
                Return CType(ParentObject, BaseForm).RootBaseForm
            End If
            Return Me
        End Get
    End Property

    Private m_Closing As Boolean

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property Closing() As Boolean
        Get
            Return RootBaseForm.m_Closing
        End Get
    End Property

    Protected m_State As BusinessObjectState

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property State() As BusinessObjectState
        Get
            Return m_State
        End Get
        Set(ByVal Value As BusinessObjectState)
            m_State = Value
        End Set
    End Property

    Protected m_IsNewObject As Boolean
    Private m_HelpTopicID As String

    <Browsable(True), Localizable(False)>
    Public Property HelpTopicID() As String
        Get
            Return m_HelpTopicID
        End Get
        Set(ByVal Value As String)
            m_HelpTopicID = Value
        End Set
    End Property

    <Browsable(True), Localizable(False)>
    Public ReadOnly Property ImageList() As ImageList
        Get
            Return ImageList1
        End Get
    End Property

    Dim m_TableName As String

    <Browsable(True), Localizable(False)>
    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal Value As String)
            m_TableName = Value
        End Set
    End Property

    Dim m_ObjectName As String

    <Browsable(True), Localizable(False)>
    Public Property ObjectName() As String
        Get
            Return m_ObjectName
        End Get
        Set(ByVal Value As String)
            m_ObjectName = Value
        End Set
    End Property

    Private m_KeyFieldName As String

    <Browsable(True), Localizable(False)>
    Public Property KeyFieldName() As String
        Get
            Return m_KeyFieldName
        End Get
        Set(ByVal Value As String)
            m_KeyFieldName = Value
        End Set
    End Property

    Private m_Caption As String

    <Browsable(True), Localizable(True)>
    Public Overridable Property Caption() As String
        Get
            Return m_Caption
        End Get
        Set(ByVal Value As String)
            m_Caption = Value
        End Set
    End Property

    Public Function GetLastExecutedAction() As ActionMetaItem Implements IApplicationForm.GetLastExecutedAction
        Return Nothing
    End Function

    Protected m_ParentKey As Object

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)>
    Public Property ParentKey() As Object
        Get
            Return m_ParentKey
        End Get
        Set(ByVal Value As Object)
            m_ParentKey = Value
        End Set
    End Property

    Protected m_FullScreenMode As Boolean = False

    <Browsable(True), DefaultValue(False)>
    Public Overridable Property FullScreenMode() As Boolean
        Get
            Return m_FullScreenMode
        End Get
        Set(ByVal Value As Boolean)
            m_FullScreenMode = Value
        End Set
    End Property

    Protected m_FormID As String

    <Browsable(True), Localizable(False)>
    Public Overridable Property FormID() As String
        Get
            Return m_FormID
        End Get
        Set(ByVal Value As String)
            If m_FormID <> Value Then
                m_FormID = Value
                Caption = m_Caption
            End If
        End Set
    End Property

    Private m_Status As FormStatus = FormStatus.Draft

    <Browsable(True), DefaultValue(FormStatus.Draft), Localizable(False)>
    Public Property Status() As FormStatus
        Get
            Return m_Status
        End Get
        Set(ByVal Value As FormStatus)
            m_Status = Value
        End Set
    End Property

    Protected m_ParentBaseForm As BaseForm = Nothing

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property ParentBaseForm() As BaseForm
        Get
            If Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed Then
                Return m_ParentBaseForm
            End If
            Return Nothing
        End Get
    End Property

    Private Shared m_ConvertTabsToDockPanels As Boolean = False

    <Browsable(False), DefaultValue(False), Localizable(False),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shared Property ConvertTabsToDockPanels() As Boolean
        Get
            Return m_ConvertTabsToDockPanels
        End Get
        Set(ByVal Value As Boolean)
            m_ConvertTabsToDockPanels = Value
        End Set
    End Property

    Private Shared m_UseFormStatus As Boolean = True

    <DefaultValue(True), Localizable(False)>
    Public Shared Property UseFormStatus() As Boolean
        Get
            Return m_UseFormStatus
        End Get
        Set(ByVal Value As Boolean)
            m_UseFormStatus = Value
        End Set
    End Property


    Protected m_Readonly As Boolean = False
    Protected m_ReadOnlyChanged As Boolean = False

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable Property [ReadOnly]() As Boolean Implements IRelatedObject.ReadOnly
        Get
            If (Not IsValidObject) Then
                Return True
            End If
            If Not ParentObject Is Nothing AndAlso ParentObject.ReadOnly Then
                Return True
            End If
            If IsDesignMode() OrElse Not IsHandleCreated Then
                Return m_Readonly
            End If
            If _
                ((Not DbService Is Nothing) AndAlso
                 (bv.common.Core.Utils.Str(DbService.ID) = bv.common.Core.Utils.Str(bv.common.Core.Utils.SEARCH_MODE_ID))) _
                Then
                Return False
            End If
            If BaseFormManager.ReadOnly Then
                Return True
            End If
            If _
                (Not m_IsNewObject AndAlso Not TypeOf Me Is BaseDetailList AndAlso (Not Permissions.CanUpdate) AndAlso
                 (Not Permissions.CanExecute)) OrElse
                (m_IsNewObject AndAlso Not (Permissions.CanInsert Or Permissions.CanExecute)) Then
                Return True
            End If
            Return m_Readonly
        End Get
        Set(ByVal Value As Boolean)
            If m_Readonly <> Value Then
                m_ReadOnlyChanged = True
            End If
            m_Readonly = Value
            ' If (m_BindingDefined = True) Then
            ApplyReadOnlyStyle(Me, Value, False)
            'End If
            For Each child As IRelatedObject In m_ChildForms
                child.ReadOnly = Value
            Next
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsStatusReadOnly() As Boolean

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable ReadOnly Property AcceptButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable ReadOnly Property RejectButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable ReadOnly Property SelectButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property

    Public Event AfterLoadData As EventHandler

    Dim m_UseParentBackColor As Boolean = False

    <Browsable(True), DefaultValue(False)>
    Public Overridable Property UseParentBackColor() As Boolean
        Get
            Return m_UseParentBackColor
        End Get
        Set(ByVal Value As Boolean)
            m_UseParentBackColor = Value
            If Value AndAlso Not Parent Is Nothing Then
                SetParentBackColor()
            End If
        End Set
    End Property

    Protected m_WasPosted As Boolean = False

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property WasPosted() As Boolean
        Get
            Return m_WasPosted
        End Get
    End Property


#End Region

#Region "Private Methods"

    Protected Function CalcButtonWidth(ByVal btn As Control, ByVal hasImage As Boolean) As Integer
        If (TypeOf (btn) Is SimpleButton) Then
            Return CType(btn, SimpleButton).CalcBestSize.Width
        ElseIf (TypeOf (btn) Is BarcodeButton) Then
            Return CType((Canvas.MeasureString(CType(btn, BarcodeButton).ButtonCaption, btn.Font).Width + 26), Integer)
        End If
        Dim w As SizeF = Canvas.MeasureString(btn.Text, btn.Font)
        w.Width += 10
        If hasImage Then
            w.Width += 16
        End If
        If w.Width < 80 Then w.Width = 80
        Return CInt(w.Width)
    End Function

    Sub ArrangeButton(ByVal parentControl As Control, ByVal btn As Control, ByVal prevButton As Control,
                      Optional ByVal ButtonTop As Integer = 8)
        If btn Is Nothing Then Return
        Dim PrevButtonLeft As Integer = parentControl.Width - 8
        If Not prevButton Is Nothing Then
            PrevButtonLeft = prevButton.Left - 8
            ButtonTop = prevButton.Top
            btn.Anchor = prevButton.Anchor
        End If
        Dim hasImage As Boolean = False
        If TypeOf btn Is Button Then
            hasImage = Not CType(btn, Button).Image Is Nothing OrElse
                       (Not CType(btn, Button).ImageList Is Nothing AndAlso CType(btn, Button).ImageIndex >= 0 AndAlso
                        CType(btn, Button).ImageList.Images.Count > CType(btn, Button).ImageIndex)
        ElseIf TypeOf btn Is SimpleButton Then
            Dim btn1 As SimpleButton = CType(btn, SimpleButton)
            hasImage = Not btn1.Image Is Nothing OrElse
                       (btn1.ImageList Is Nothing AndAlso btn1.ImageIndex >= 0 AndAlso
                        CType(btn1.ImageList, ImageList).Images.Count > btn1.ImageIndex)
        End If
        Dim w As Integer = CalcButtonWidth(btn, hasImage)
        If w > btn.Width Then
            btn.Width = w
        End If
        btn.Location = New Point(PrevButtonLeft - btn.Width, ButtonTop)
        btn.Parent = parentControl
        RegisterArrangedButton(btn)
    End Sub


    Dim m_Canvas As Graphics = Nothing

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ReadOnly Property Canvas() As Graphics
        Get
            If m_Canvas Is Nothing Then
                Dim hDC As IntPtr = WindowsAPI.GetWindowDC(Handle)
                m_Canvas = Graphics.FromHdc(hDC)
                WindowsAPI.ReleaseDC(Handle, hDC)
            End If
            Return m_Canvas
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Canvas Is Nothing Then
            'Get handle to device context.
            Dim hdc As IntPtr = e.Graphics.GetHdc()
            'Create new graphics object using handle to device context.
            m_Canvas = Graphics.FromHdc(hdc)
            'Release handle to device context.
            e.Graphics.ReleaseHdc(hdc)
        End If
    End Sub

    Public Overridable Sub ShowHelp() Implements IApplicationForm.ShowHelp
        ShowHelp(m_HelpTopicID)
    End Sub

    <Browsable(False), DefaultValue(False), Localizable(False),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisableDelayedDisposing() As Boolean Implements IApplicationForm.DisableDelayedDisposing


    Private Shared m_BaseHelpFileName As String

    Public Shared Property BaseHelpFileName() As String
        Get
            Return m_BaseHelpFileName
        End Get
        Set(ByVal value As String)
            m_BaseHelpFileName = value
        End Set
    End Property

    Protected Sub ShowHelp(ByVal topicID As String)
        Dim language As String = ModelUserContext.CurrentLanguage
        If WinClientContext.HelpNames.ContainsKey(language) = False Then Return
        If Not bv.common.Core.Utils.IsEmpty(topicID) Then
            Help2.ShowHelp(Me, WinClientContext.HelpNames(language).ToString, topicID)
        Else
            Help2.ShowHelp(Me, WinClientContext.HelpNames(language).ToString)
        End If
    End Sub


    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            If IsDesignMode() OrElse Not Created Then Return
            LayoutCorrector.Reset()
            ApplyStyle(Me)
            LoadGridLayouts()

            If Not ActiveControl Is Nothing Then
                ActiveControl.Select()
                If TypeOf ActiveControl Is TextBoxMaskBox Then
                    Control_Enter(ActiveControl.Parent, EventArgs.Empty)
                Else
                    Control_Enter(ActiveControl, EventArgs.Empty)
                End If
            End If
            eventManager.WireForm()
        Catch ex As Exception
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            ErrorForm.ShowError(StandardError.FillDatasetError, ex)
        End Try
    End Sub

    Protected Sub MergeTable(ByVal ds As DataSet, ByVal tableName As String)
        If ds.Tables.Contains(tableName) Then baseDataSet.Merge(ds.Tables(tableName))
    End Sub

    Private Function ShouldIgnoreReadonly(ByVal tag As Object) As Boolean
        Dim strTag As String = ""
        If Not tag Is Nothing AndAlso TypeOf (tag) Is TagHelper AndAlso CType(tag, TagHelper).StringTag <> Nothing Then
            strTag = bv.common.Core.Utils.Str(CType(tag, TagHelper).StringTag).ToLowerInvariant
        Else
            strTag = bv.common.Core.Utils.Str(tag).ToLowerInvariant
        End If
        If strTag.IndexOf("{alwayseditable}") >= 0 Then
            Return True
        ElseIf IsStatusReadOnly AndAlso strTag.IndexOf("{statuscontrol}") >= 0 Then
            Return True
        End If
        Return False
    End Function


    Protected Sub ApplyReadOnlyStyle(ByVal p As Control, ByVal Value As Boolean,
                                     Optional ByVal IgnoreReadOnly As Boolean = False)
        If Not p.GetType.GetInterface("ISearchForm") Is Nothing OrElse ShouldIgnoreReadonly(p.Tag) Then
            IgnoreReadOnly = True
        End If
        For Each c As Control In p.Controls
            Dim ctlIgnoreReadonly As Boolean = IgnoreReadOnly
            If Not ctlIgnoreReadonly Then
                ctlIgnoreReadonly = ShouldIgnoreReadonly(c.Tag)
            End If
            If (TypeOf (c) Is BaseButton) OrElse TypeOf c Is Button Then
                If ctlIgnoreReadonly = False AndAlso (Not ((TypeOf (p) Is BaseDetailForm) AndAlso
                                                           ((c Is CType(p, BaseDetailForm).cmdCancel) OrElse
                                                            (c Is CType(p, BaseDetailForm).cmdOk)))) Then
                    c.Enabled = Not Value
                End If
            ElseIf TypeOf (c) Is BaseEdit Then
                If ctlIgnoreReadonly = False Then
                    SetControlReadOnly(c, Value, False)
                End If
                SetControlState(CType(c, BaseControl), ctlIgnoreReadonly)
            ElseIf TypeOf (c) Is GridControl Then
                SetGridControlReadOnlyState(CType(c, GridControl), Value, ctlIgnoreReadonly)
            ElseIf TypeOf c Is CheckedListBoxControl Then
                c.Enabled = Not Value
            ElseIf Not TypeOf c Is IRelatedObject Then
                ApplyReadOnlyStyle(c, Value, ctlIgnoreReadonly)
            End If
        Next
    End Sub


    Private Shared Sub SetGridControlReadOnlyState(ByVal c As GridControl, ByVal value As Boolean,
                                                   ByVal IgnoreReadOnly As Boolean)
        If IgnoreReadOnly = False Then
            If TypeOf (c.FocusedView) Is GridView Then
                Dim xgv As GridView =
                        CType(c.FocusedView, GridView)
                xgv.OptionsBehavior.Editable = Not value
                If TypeOf (xgv.DataSource) Is DataView Then
                    CType(xgv.DataSource, DataView).AllowNew = Not value
                    CType(xgv.DataSource, DataView).AllowEdit = Not value
                    CType(xgv.DataSource, DataView).AllowDelete = Not value
                End If
            End If
            For Each rit As RepositoryItem In c.RepositoryItems
                If value Then
                    SetRepositoryControlReadOnlyState(rit, IgnoreReadOnly)
                Else
                    SetRepositoryControlNotReadOnlyState(rit, IgnoreReadOnly)
                End If
            Next
        End If
    End Sub

    Private Shared Sub SetRepositoryControlNotReadOnlyState(ByVal c As RepositoryItem,
                                                            ByVal IgnoreNotReadOnly As Boolean)
        If Not IgnoreNotReadOnly Then
            c.ReadOnly = False
            If TypeOf (c) Is RepositoryItemPopupBase Then
                CType(c, RepositoryItemPopupBase).ShowDropDown = ShowDropDown.SingleClick
                For Each btn As EditorButton In CType(c, RepositoryItemPopupBase).Buttons
                    btn.Enabled = True
                Next
            End If
        End If
    End Sub

    Private Shared Sub SetRepositoryControlReadOnlyState(ByVal c As RepositoryItem, ByVal IgnoreReadOnly As Boolean)
        If IgnoreReadOnly = False Then
            c.ReadOnly = True
            If TypeOf (c) Is RepositoryItemPopupBase Then
                CType(c, RepositoryItemPopupBase).ShowDropDown = ShowDropDown.Never
                For Each btn As EditorButton In CType(c, RepositoryItemPopupBase).Buttons
                    btn.Enabled = False
                Next
            End If
        End If
    End Sub


    Public Overridable Sub ApplyStyle(ByVal p As Control, Optional ByVal ignoreReadOnly As Boolean = False)
        If _
            Not p.GetType.GetInterface("ISearchForm") Is Nothing OrElse
            bv.common.Core.Utils.Str(p.Tag) = "AlwaysEditable" Then
            ignoreReadOnly = True
        End If
        Dim OwnerBaseForm As BaseForm
        If TypeOf p Is BaseForm Then
            OwnerBaseForm = CType(p, BaseForm)
        Else
            OwnerBaseForm = FindBaseForm(p)
        End If
        FindBaseForm(p)
        For Each c As Control In p.Controls
            If Not TypeOf c Is BaseForm Then
                LayoutCorrector.SetControlFont(c)
                'If TypeOf (c) Is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Then
                '    AddHandler CType(c, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).EditValueChanged, AddressOf RepositoryLookup_EditValueChanged
                'End If
                If TypeOf (c) Is BaseButton Then
                    LayoutCorrector.SetStyleController(CType(c, BaseButton), LayoutCorrector.ButtonStyleController)
                    If Not TagEquals(c, "FixFont") Then
                        c.Font = LayoutCorrector.ButtonStyleController.Appearance.Font
                    End If
                ElseIf TypeOf (c) Is BaseControl Then
                    If OwnerBaseForm.GetType().Name <> "FFPresenter" _
                       OrElse Not CType(c, BaseControl).StyleController.IsMandatory() _
                        Then
                        LayoutCorrector.SetStyleController(CType(c, BaseControl), LayoutCorrector.EditorStyleController)
                    End If
                    'It should be done by LookupBinder
                    'If TypeOf (c) Is DateEdit Then
                    '    If ShowDateTimeFormatAsNullText AndAlso CType(c, DateEdit).Properties.NullText <> "*" Then
                    '        CType(c, DateEdit).Properties.NullText = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
                    '    End If
                    '    If CType(c, DateEdit).Properties.MinValue = DateTime.MinValue Then
                    '        CType(c, DateEdit).Properties.MinValue = New Date(1900, 1, 1)
                    '    End If
                    '    If CType(c, DateEdit).Properties.MaxValue = DateTime.MinValue Then
                    '        CType(c, DateEdit).Properties.MaxValue = New Date(2050, 1, 1)
                    '    End If
                    'End If
                    If TypeOf (c) Is BaseEdit Then
                        If _
                            Not c.Tag Is Nothing AndAlso Not TypeOf (c.Tag) Is TagHelper AndAlso
                            Not OwnerBaseForm Is Nothing AndAlso OwnerBaseForm.GetType.Name <> "FFPresenter" Then
                            Dim th As TagHelper = New TagHelper(c)
                        End If
                        SetControlState(CType(c, BaseControl), ignoreReadOnly)
                        SetControlLanguage(CType(c, BaseEdit))
                    End If
                End If
                ApplyStyle(c, ignoreReadOnly)
            End If
        Next
    End Sub

    Private Function TagEquals(ByVal ctl As Control, ByVal text As String) As Boolean
        If ctl.Tag Is Nothing Then Return False
        If TypeOf (ctl.Tag) Is TagHelper Then
            Return bv.common.Core.Utils.Str(CType(ctl.Tag, TagHelper).StringTag) = text
        End If
        Return bv.common.Core.Utils.Str(ctl.Tag) = text
    End Function

    Sub SetControlMandatoryState(ByVal c As BaseControl)
        LayoutCorrector.SetStyleController(c, LayoutCorrector.MandatoryStyleController)
    End Sub

    Sub SetControlState(ByVal c As BaseControl, ByVal IgnoreReadOnly As Boolean)
        Dim isReadOnly As Boolean = False
        If Not IgnoreReadOnly Then
            IgnoreReadOnly = ShouldIgnoreReadonly(c.Tag)
        End If
        If [ReadOnly] AndAlso IgnoreReadOnly = False Then
            SetControlReadOnly(c, True, False)
            Return
        End If
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
            Dim th As TagHelper = CType(c.Tag, TagHelper)
            If th.IsReadOnly OrElse ([ReadOnly] AndAlso IgnoreReadOnly = False) Then
                SetControlReadOnly(c, True, False)
                isReadOnly = True
            ElseIf th.IsKeyField Then
                If _
                    (Me.State And BusinessObjectState.NewObject) = 0 AndAlso TypeOf c Is BaseEdit AndAlso
                    Not CType(c, BaseEdit).EditValue Is DBNull.Value Then
                    SetControlReadOnly(c, True, False)
                Else
                    SetControlMandatoryState(c)
                End If
            End If
            If isReadOnly = False Then
                If th.IsMandatory Then
                    'c.StyleController = MandatoryFieldStyleController
                    SetControlMandatoryState(c)
                ElseIf TypeOf (c) Is PopupBaseEdit Then
                    LayoutCorrector.SetStyleController(c, LayoutCorrector.DropDownStyleController)
                End If
            ElseIf th.IsMandatory Then
                If th.IsReadOnly = False Then
                    If TypeOf c Is BaseEdit Then
                        CType(c, BaseEdit).Properties.ReadOnly = False
                    Else
                        c.Enabled = False
                    End If
                End If
                'c.StyleController = MandatoryFieldStyleController
                SetControlMandatoryState(c)
            End If
        Else
            If (TypeOf (c) Is BaseEdit) AndAlso
               (CType(c, BaseEdit).Properties.ReadOnly = False) Then
                If TypeOf (c) Is PopupBaseEdit AndAlso Not c.StyleController.IsMandatory() Then
                    LayoutCorrector.SetStyleController(c, LayoutCorrector.DropDownStyleController)
                End If
            End If
        End If
        If TypeOf (c) Is PopupBaseEdit Then
            CType(c, PopupBaseEdit).SetPopupControlBehavior(False)
        End If
    End Sub

    Protected Sub SetControlState(ctl As BaseControl, ctlState As ControlState, rdOnly As Boolean)
        ApplyControlState(ctl, ControlState.Normal)
        SetControlReadOnly(ctl, rdOnly, False)
        If Not rdOnly AndAlso ctlState = ControlState.Mandatory Then
            If (TypeOf (ctl.Tag) Is TagHelper) Then
                CType(ctl.Tag, TagHelper).IsMandatory = True
                SetControlReadOnly(ctl, False, False)
            Else
                ctl.Tag = "{M}"
            End If
            SetControlMandatoryState(ctl)
        End If
    End Sub

    Protected Sub SetControlReadOnly(ByVal c As Control, ByVal value As Boolean, ByVal savePreviousState As Boolean)
        c.TabStop = Not value
        If TypeOf c Is BaseEdit Then
            CType(c, BaseEdit).Properties.ReadOnly = value
            CType(c, BaseEdit).ShowToolTips = Not value
            If value Then
                LayoutCorrector.SetStyleController(CType(c, BaseEdit), LayoutCorrector.ReadOnlyStyleController)
            Else
                If TypeOf (c) Is PopupBaseEdit Then
                    LayoutCorrector.SetStyleController(CType(c, BaseEdit), LayoutCorrector.DropDownStyleController)
                Else
                    LayoutCorrector.SetStyleController(CType(c, BaseEdit), LayoutCorrector.EditorStyleController)

                End If

            End If
        Else
            c.Enabled = Not value
        End If
        If TypeOf (c) Is PopupBaseEdit Then
            If value Then
                CType(c, PopupBaseEdit).Properties.ShowDropDown = ShowDropDown.Never
                CType(c, PopupBaseEdit).Properties.TextEditStyle = TextEditStyles.DisableTextEditor
            Else
                DxControlsHelper.SetPopupControlBehavior(CType(c, PopupBaseEdit), False)
                If Not TypeOf (c) Is LookUpEdit Then
                    CType(c, PopupBaseEdit).Properties.TextEditStyle = TextEditStyles.Standard
                End If
            End If
        End If
        If TypeOf (c) Is ButtonEdit Then
            For Each btn As EditorButton In CType(c, ButtonEdit).Properties.Buttons
                If Not ShouldIgnoreReadonly(btn.Tag) Then
                    btn.Enabled = Not value
                    btn.Visible = Not value
                End If
            Next
        End If
    End Sub

    Public Sub ApplyControlState(ByVal c As BaseControl, ByVal state As ControlState)
        Dim tag As String = ""
        Dim tHelper As TagHelper = Nothing
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
            tHelper = CType(c.Tag, TagHelper)
        End If
        If (state And ControlState.ReadOnly) = ControlState.ReadOnly Then tag += "R"
        If (state And ControlState.Mandatory) = ControlState.Mandatory Then tag += "M"
        If (state And ControlState.KeyField) = ControlState.KeyField Then tag += "K"
        If (state And ControlState.Barcode) = ControlState.KeyField Then tag += "B"
        If tag <> "" Then
            tag = String.Format("{{{0}}}", tag)
            If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
                CType(c.Tag, TagHelper).StringTag = tag
            Else
                c.Tag = tag
                c.Tag = New TagHelper(c)
            End If
        Else
            'If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
            '    CType(c.Tag, TagHelper).StringTag = Nothing
            'Else
            c.Tag = Nothing
            'End If
        End If
        SetControlState(c, False)
    End Sub

    Sub SetControlLanguage(ByVal c As BaseEdit)
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
            Dim th As TagHelper = CType(c.Tag, TagHelper)
            If th.ControlLanguage <> "" Then
                AddHandler c.Enter, AddressOf Control_Enter
                AddHandler c.Leave, AddressOf Control_Leave
            End If
        End If
    End Sub

    Dim LastInputLanguage As String

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As EventArgs)
        TagHelper.SetControlLanguage(CType(sender, Control), LastInputLanguage)
    End Sub

    Private Sub Control_Leave(ByVal sender As Object, ByVal e As EventArgs)
        SystemLanguages.SwitchInputLanguage(LastInputLanguage)
    End Sub

    Shared Function IsButton(ByVal c As Control) As Boolean
        If TypeOf (c) Is Button Then Return True
        If TypeOf (c) Is SimpleButton Then Return True
        If TypeOf (c) Is PopUpButton Then Return True
        If TypeOf (c) Is BarcodeButton Then Return True
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is String AndAlso CType(c.Tag, String).IndexOf("Button") >= 0 _
            Then Return True
        Return False
    End Function

    Protected m_Comparer As New HorizCoordComparer

    Protected Sub ArrangeButtons(ByVal ButtonTop As Integer, ByVal buttonGroupName As String,
                                 Optional ByVal ButtonHeight As Integer = 23, Optional ByVal NewTop As Integer = -1)
        ArrangeButtons(Me, ButtonTop, buttonGroupName, ButtonHeight, NewTop)
    End Sub

    Protected Sub ArrangeButtons(ByVal ctl As Control, ByVal ButtonTop As Integer, ByVal buttonGroupName As String,
                                 Optional ByVal ButtonHeight As Integer = 23, Optional ByVal NewTop As Integer = -1)
        If DesignMode Then Exit Sub
        Me.SuspendLayout()
        If NewTop = -1 Then NewTop = ButtonTop
        buttonGroupName = buttonGroupName & Controls.Count
        Dim Buttons As ArrayList = New ArrayList
        For Each c As Control In ctl.Controls
            If IsButton(c) Then
                If c.Visible Then
                    c.BringToFront()
                End If
                Dim middle As Double = c.Top + c.Height / 2
                If middle >= ButtonTop And middle <= (ButtonTop + ButtonHeight) Then
                    ' To Leave Button on it Place (Andrey)
                    If _
                        c.Tag Is Nothing OrElse
                        c.Tag.ToString.ToLower(CultureInfo.InvariantCulture).IndexOf("{immovable}") < 0 Then
                        Buttons.Add(c)
                    End If
                ElseIf NewTop <> ButtonTop Then
                    If middle >= NewTop And middle <= (NewTop + ButtonHeight) Then
                        ' To Leave Button on it Place (Andrey)
                        If _
                            c.Tag Is Nothing OrElse
                            c.Tag.ToString.ToLower(CultureInfo.InvariantCulture).IndexOf("{immovable}") < 0 Then
                            Buttons.Add(c)
                        End If
                    End If
                End If
            End If
        Next

        ' Buttons
        Buttons.Sort(m_Comparer)
        Dim prevButton As Control = Nothing
        Dim handleCreated As Boolean = IsHandleCreated
        For Each o As Object In Buttons
            Dim c As Control = CType(o, Control)
            If c.Visible OrElse Not handleCreated Then
                ArrangeButton(ctl, c, prevButton, NewTop)
                prevButton = c
            End If
        Next
        If (common.Core.Localizer.IsRtl) Then
            For Each o As Object In Buttons
                Dim c As Control = CType(o, Control)
                If c.Visible OrElse Not handleCreated Then
                    RtlHelper.SetRTL(c)
                End If
            Next
        End If
        If Not handleCreated Then
            m_Comparer.Clear()
        End If
        Me.ResumeLayout(True)
    End Sub

    Dim m_FullScreenModeSet As Boolean

    Protected Sub SetFullscreenMode(ByVal YShift As Integer, ByVal HeightDelta As Integer)
        If m_FullScreenModeSet = m_FullScreenMode Then Return

        If m_FullScreenMode = False Then
            YShift = -YShift
            HeightDelta = -HeightDelta
        End If
        Height -= HeightDelta
        For Each c As Control In Controls
            If ((c.Anchor And AnchorStyles.Top) <> 0) AndAlso (YShift <> 0) Then
                c.Top -= YShift
            End If
            If (c.Anchor And AnchorStyles.Bottom) <> 0 AndAlso (c.Anchor And AnchorStyles.Top) <> 0 Then
                c.Height += HeightDelta
            End If
        Next
        m_FullScreenModeSet = m_FullScreenMode
    End Sub

#End Region

    Public Overridable Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Implements IApplicationForm.BaseForm_KeyDown
        If e.KeyCode = Keys.Enter Then
            'e.Handled = True
            Dim focusedControl As Control = ActiveControl
            While _
                TypeOf (focusedControl) Is ContainerControl AndAlso
                Not CType(focusedControl, ContainerControl).ActiveControl Is Nothing
                focusedControl = CType(focusedControl, ContainerControl).ActiveControl
                'If TypeOf (FocusedControl) Is BaseSearchPanel Then
                '    CType(FocusedControl, BaseSearchPanel).BaseSearchPanel_KeyDown(CType(FocusedControl, BaseSearchPanel).ActiveControl, e)
                '    Exit Sub
                'End If
            End While
            If TypeOf (focusedControl) Is GridControl Then
                Exit Sub
            End If
            If Not focusedControl.Parent Is Nothing AndAlso TypeOf (focusedControl.Parent) Is GridControl Then
                Exit Sub
            End If
            If _
                Not focusedControl.Parent Is Nothing AndAlso Not focusedControl.Parent.Parent Is Nothing AndAlso
                TypeOf (focusedControl.Parent.Parent) Is GridControl Then
                Exit Sub
            End If
            'If TypeOf (FocusedControl) Is BaseSearchPanel Then
            '    CType(FocusedControl, BaseSearchPanel).BaseSearchPanel_KeyDown(CType(FocusedControl, BaseSearchPanel).ActiveControl, e)
            '    Exit Sub
            'End If
            ' Not TypeOf (FocusedControl) Is LookUpEdit AndAlso _
            If TypeOf (focusedControl) Is PopupBaseEdit AndAlso
               CType(focusedControl, PopupBaseEdit).IsPopupOpen() Then
                Exit Sub
            End If
            If TypeOf (focusedControl) Is MemoEdit OrElse
               (TypeOf (focusedControl) Is TextBoxMaskBox) AndAlso
               (Not CType(focusedControl, TextBoxMaskBox).Parent Is Nothing AndAlso
                TypeOf (CType(focusedControl, TextBoxMaskBox).Parent) Is MemoEdit) Then
                Exit Sub
            End If
            If (TypeOf (focusedControl) Is TextBoxMaskBox) AndAlso
               (Not focusedControl.Parent Is Nothing) AndAlso
               (TypeOf (focusedControl.Parent) Is ButtonEdit) Then
                Dim edit As ButtonEdit = CType(focusedControl.Parent, ButtonEdit)
                If (Not edit.Tag Is Nothing) AndAlso (TypeOf (edit.Tag) Is TagHelper) Then
                    Dim helper As TagHelper = CType(edit.Tag, TagHelper)
                    If helper.IsBarcode Then
                        edit.SelectAll()
                        Exit Sub
                    End If
                End If
            End If
            SelectNextControl(focusedControl, True, True, True, True)
        ElseIf e.KeyCode = Keys.F1 Then
            ShowHelp()
        ElseIf e.KeyCode = Keys.Escape AndAlso Not BaseSettings.TranslationMode Then
            Me.DoClose()
        End If
    End Sub

    Public Sub Release() Implements IApplicationForm.Release
    End Sub


    Public Shared Sub BaseForm_InputLanguageChanged(ByVal sender As Object, ByVal e As InputLanguageChangedEventArgs)
        Dim frm As Form = CType(sender, Control).FindForm
        If Not frm Is Nothing Then
            Dim ctl As Control = frm.ActiveControl

        End If
        For Each c As Control In CType(sender, Control).Controls
        Next
    End Sub

    Protected Overridable Function SavePromptDialog(Optional ByVal DefaultResult As DialogResult = DialogResult.Yes) _
        As DialogResult
        If BaseSettings.ShowSaveDataPrompt AndAlso Not Utils.IsCalledFromUnitTest Then 'AndAlso HasChanges() 
            Dim res As Boolean = False

            If m_ClosingMode = ClosingMode.None Then
                res = WinUtils.ConfirmSave
            ElseIf m_ClosingMode = ClosingMode.Ok Then
                res = WinUtils.ConfirmOk
            ElseIf m_ClosingMode = ClosingMode.Cancel Then
                res = WinUtils.ConfirmCancel(FindForm())
            End If
            If res Then
                Return DialogResult.Yes
            Else
                Return DialogResult.No
            End If
        End If
        Return DefaultResult
    End Function

    Protected Function DeletePromptDialog() As DialogResult
        If BaseSettings.ShowDeletePrompt AndAlso Not bv.common.Core.Utils.IsCalledFromUnitTest Then
            Return _
                MessageForm.Show(BvMessages.Get("msgDeletePrompt", "The object will be deleted. Delete object?"),
                                 BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        Return DialogResult.Yes
    End Function

    Protected Function IsDesignMode() As Boolean
        Return IsComponentInDesignMode(Me)
    End Function

    ''' <summary>
    ''' Check is component in design mode.</summary>
    ''' <param name="component">Component.</param>
    ''' <returns>true, if component open in designer.</returns>
    ''' <remarks>Lookup in stack trace</remarks>
    Friend Shared Function IsComponentInDesignMode(ByVal component As IComponent) As Boolean
        Return WinUtils.IsComponentInDesignMode(component)
    End Function


#Region "IRelatedObject Interface"

    Private m_DbService As BaseDbService = Nothing

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DbService() As BaseDbService Implements IRelatedObject.DBService
        Get
            Return m_DbService
        End Get
        Set(ByVal Value As BaseDbService)
            m_DbService = Value
        End Set
    End Property


    Public Overridable Function GetChildKey(ByVal child As IRelatedObject) As Object _
        Implements IRelatedObject.GetChildKey
        Return GetKey()
    End Function

    Public Overridable Function HasChanges() As Boolean Implements IRelatedObject.HasChanges, IPostable.HasChanges
        If m_WasSaved Then Return True
        If baseDataSet Is Nothing Then
            Return False
        End If
        If baseDataSet.HasChanges Then
            If WasModified() Then
                Return True
            End If
        End If
        For Each child As IRelatedObject In m_ChildForms
            If child.HasChanges() Then
                Return True
            End If
        Next
        Return False
    End Function


    Protected m_BindingDefined As Boolean = False
    Protected m_DataLoaded As Boolean = False

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fills <see cref="baseDataSet"/> with the object related data.
    ''' </summary>
    ''' <param name="id">
    ''' unique identifier of the form related object
    ''' </param>
    ''' <returns>
    ''' <b>True</b> if the data was successfullly loaded and <b>False</b> if error occurred.
    ''' </returns>
    ''' <remarks>
    ''' This method should be called to fill form with data. 
    ''' Internally it calls <see cref="FillDataSet"/> method that performs all specific data loading.
    ''' In distinguish to <see cref="FillDataSet"/> method <b>LoadData</b> is more safe, it prevents to simultanious 
    ''' asynchronic method calls and provides the several load data attempts if some kind of network errors occured.
    ''' When data loading is finished, the overridable <see cref="AfterLoad"/> method is called. If <b>BaseForm</b>
    ''' descendant class needs in perfoming some specific operations right after data loading, it's  <see cref="AfterLoad"/> method
    ''' should be overridden in the proper way.
    ''' <para>
    ''' If <paramref name="id"/> is <b>Nothing</b>, the <see cref="baseDataSet"/> is filled with new object data or
    ''' with the list of objects depending on form type (detail or list form).
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overridable Function LoadData(ByRef id As Object) As Boolean Implements IRelatedObject.LoadData

        If UseFormStatus = True AndAlso m_Status = FormStatus.Demo Then
            Return True
        End If
        If Me.DesignMode Then Return True
        Dim Result As Boolean
        Try
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                BeginWaitCursor()
                'Cursor.Current = Cursors.WaitCursor
            End If
            BeginUpdate()
            'While AttemptsCount > 0
            m_DataLoaded = False
            Try
                Result = LoadDataInternal(id)
                If (Result = False AndAlso Not BaseSettings.ScanFormsMode) Then
                    Dim err As ErrorMessage = DbService.LastError
                    If Not err Is Nothing AndAlso Not err.Exception Is Nothing Then
                        Throw err.Exception
                    End If
                End If
                If (bv.common.Core.Utils.IsEmpty(id) AndAlso TypeOf (Me) Is BaseDetailForm) Then
                    id = GetKey()
                End If
                Return Result
            Catch ex1 As SqlException
                If (BaseSettings.ThrowExceptionOnError) Then
                    Throw
                End If
                If (Not SqlExceptionHandler.Handle(ex1)) Then
                    ErrorForm.ShowError(StandardError.FillDatasetError, ex1)
                End If
                Return False
            End Try
        Catch ex1 As UserErrorException
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            ErrorForm.ShowWarningDirect(ex1.Message)
            Return False
        Catch ex As Exception
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw
            End If
            ErrorForm.ShowError(StandardError.FillDatasetError, ex)
            Return False
        Finally
            EndUpdate()
            m_DataLoaded = True
            If (Result = True) Then
                AfterLoad()
                Validators.Clear()
                RegisterValidators()
            End If
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                EndWaitCursor()
            End If
            If Not Me.PermissionObject Is Nothing Then
                If _
                    ((bv.common.Core.Utils.Str(id) <> "SearchMode") AndAlso
                     ((DbService Is Nothing) OrElse
                      (bv.common.Core.Utils.Str(DbService.ID) <>
                       bv.common.Core.Utils.Str(bv.common.Core.Utils.SEARCH_MODE_ID)))) Then
                    If (Me.State And BusinessObjectState.NewObject) <> 0 AndAlso
                       (Permissions.CanInsert = False) AndAlso
                       (Permissions.CanExecute = False) Then
                        If Me.GetType().Name = "HumanCaseDetail" Then
                            ReflectionHelper.SetProperty(Me, "ShowNavigators", False)
                        End If
                        Me.ReadOnly = True
                    End If
                    If (State And BusinessObjectState.NewObject) = 0 AndAlso
                       ((Permissions.CanUpdate = False) AndAlso
                        (Permissions.CanExecute = False)) AndAlso
                       Not TypeOf Me Is BaseDetailList Then
                        If Me.GetType().Name = "HumanCaseDetail" Then
                            ReflectionHelper.SetProperty(Me, "NavigatorReadOnlyMode", True)
                        End If
                        Me.ReadOnly = True
                    ElseIf TypeOf Me Is BaseDetailList AndAlso (Permissions.CanUpdate = False) Then
                        Me.ReadOnly = True
                    End If
                End If
            End If
            DebugTimer.Stop()
        End Try
    End Function

    Protected Function LoadDataInternal(ByVal ID As Object) As Boolean
        Dim Result As Boolean
        'Dim key As Object
        'If TypeOf (Me) Is BaseListForm Then
        '    key = CType(Me, BaseListForm).GetKey()
        'Else
        '    key = Nothing
        'End If
        DebugTimer.Start(String.Format("{0} loading", Me.GetType.Name))
        If ID Is Nothing AndAlso Me.FormType = BaseFormType.DetailForm Then
            m_State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
        ElseIf (m_State And BusinessObjectState.SelectObject) = 0 Then
            m_State = BusinessObjectState.EditObject
        End If
        DebugTimer.Start(String.Format("{0} ClearBinding", Me.GetType.Name))
        ClearBinding(Me)
        DebugTimer.Stop()

        For Each child As IRelatedObject In m_ChildForms
            If TypeOf child Is BaseForm AndAlso CType(child, BaseForm).UseParentDataset Then
                Continue For
            End If
            child.baseDataSet.Clear()
        Next

        DebugTimer.Start(String.Format("{0} FillDataset", Me.GetType.Name))
        If UseParentDataset AndAlso Not ParentObject Is Nothing Then
            baseDataSet = ParentObject.baseDataSet
            Result = True
        Else
            SyncLock ConnectionManager.DefaultInstance.Connection
                If (BaseSettings.ValidateObject AndAlso Not String.IsNullOrEmpty(ValidationProcedureName) AndAlso Not Utils.IsEmpty(ID)) Then
                    IsValidObject = (BaseDbService.ValidateObject(ValidationProcedureName, ID) = 0)
                    If Not IsValidObject Then
                        m_ReadOnlyChanged = True
                    End If
                End If
                Result = FillDataset(ID)
            End SyncLock
        End If
        DebugTimer.Stop()
        If (Result = True) Then
#If DEBUG Then
            For Each t As DataTable In baseDataSet.Tables
                Dbg.Assert(t.PrimaryKey IsNot Nothing AndAlso t.PrimaryKey.Length > 0,
                           "The table {0} has no primary key", t.TableName)
            Next
#End If
            If Not DbService Is Nothing AndAlso DbService.IsNewObject Then
                m_State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
                m_IsNewObject = True
            ElseIf Not DbService Is Nothing AndAlso Not DbService.IsNewObject Then
                m_State = BusinessObjectState.EditObject
            End If
            'If Not TypeOf (Me) Is BaseListForm Then  '  AndAlso m_BindingDefined = False
            'eventManager.Clear()
            DefineBinding()
            SetupGrids(Me)
            m_BindingDefined = True
            If m_ReadOnlyChanged Then
                If _
                    (TypeOf (Me) Is BaseDetailForm) OrElse (TypeOf (Me) Is BaseLookupForm) OrElse
                    (TypeOf (Me) Is BaseDetailPanel) Then
                    CType(Me, BaseForm).ApplyReadOnlyStyle(CType(Me, BaseForm), Me.ReadOnly, False)
                End If
                m_ReadOnlyChanged = False
            End If
            'End If

            Dim tempChildForms As New List(Of IRelatedObject)
            tempChildForms.AddRange(m_ChildForms)
            For Each child As IRelatedObject In tempChildForms
                If child.LoadData(GetChildKey(child)) = False Then
                    Return False
                End If
            Next
            ''
            If (Me.ParentObject Is Nothing) Then RefreshLayout()
            Me.RefreshChildLayout()

            'Fix the current state of dataset for the existing objects
            If Not DbService Is Nothing AndAlso (Me.State And BusinessObjectState.NewObject) = 0 Then
                '    Application.DoEvents()

                If ((Not TypeOf (Me) Is BaseAvrDetailPanel) AndAlso (Not TypeOf (Me) Is BaseAvrForm)) Then
                    Application.DoEvents()
                End If

                DataEventManager.Flush()
                DbService.AcceptChanges(baseDataSet)
                eventManager.HasChanges = False
            End If
            RaiseEvent AfterLoadData(Me, EventArgs.Empty)

            SaveInitialChanges()
            m_WasShown = False
        End If

        Return Result
    End Function

    Private Sub SetupGrids(ctl As Control)
        For Each c As Control In ctl.Controls
            If (TypeOf (c) Is GridControl) Then
                DxControlsHelper.SetGridConstraints(CType(c, GridControl))
            Else
                SetupGrids(c)
            End If
        Next
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Increases the internal counter that prevents to asynchronous <see cref="LoadData"/> method calls.
    ''' </summary>
    ''' <remarks>
    ''' Call this method before critical operations with <see cref="baseDataSet"/> to prevent asynchronous data reloading.
    ''' The <see cref="EndUpdate"/> method must be called after each <b>BeginUpdate</b> call.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub BeginUpdate()
        m_Loading += 1
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Decreases the internal counter that prevents to asynchronous <see cref="LoadData"/> method calls.
    ''' </summary>
    ''' <remarks>
    ''' Call this method after <see cref="BeginUpdate"/> method call when the critical operations with <see cref="baseDataSet"/> is completed to enable data reloading.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub EndUpdate()
        m_Loading -= 1
    End Sub

    Private m_ParentForm As IRelatedObject

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ParentObject() As IRelatedObject Implements IRelatedObject.ParentObject
        Get
            Return m_ParentForm
        End Get
        Set(ByVal Value As IRelatedObject)
            m_ParentForm = Value
        End Set
    End Property

    Protected m_ChildForms As New List(Of IRelatedObject)

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property Children() As List(Of IRelatedObject) Implements IRelatedObject.Children
        Get
            Return m_ChildForms
        End Get
    End Property

    Public Sub RegisterChildObject(ByVal child As IRelatedObject,
                                   Optional ByVal childPostingType As RelatedPostOrder = RelatedPostOrder.PostFirst) _
        Implements IRelatedObject.RegisterChildObject
        If DesignMode Then Return
        If child Is Nothing Then Return
        If m_ChildForms.Contains(child) Then
            Return
        End If
        m_ChildForms.Add(child)
        DbService.AddLinkedDbService(child.DBService, child.baseDataSet, childPostingType)
        If Not child.ParentObject Is Nothing AndAlso Not child.ParentObject Is Me Then
            child.ParentObject.UnRegisterChildObject(child)
        End If
        child.ParentObject = Me
    End Sub

    Public Sub UnRegisterChildObject(ByVal child As IRelatedObject) Implements IRelatedObject.UnRegisterChildObject
        If DesignMode Then Return
        If child Is Nothing Then Return
        If Not child.DBService Is Nothing Then
            DbService.RemoveLinkedDbService(child.DBService)
        End If
        m_ChildForms.Remove(child)
        child.ParentObject = Nothing
    End Sub

    Protected Shared Sub BringUpCurrentTab(ByVal ctl As Control)
        Dim page As Control = TabPage.GetTabPageOfComponent(ctl)
        'process standard tab control
        If Not page Is Nothing Then
            CType(page.Parent, TabControl).SelectedTab = CType(page, TabPage)
            BringUpCurrentTab(page.Parent.Parent)
            Return
        End If
        'XtraTabControl
        page = ctl '.Parent
        While Not page Is Nothing
            If TypeOf page Is XtraTabPage Then
                CType(page, XtraTabPage).TabControl.SelectedTabPage = CType(page, XtraTabPage)
                BringUpCurrentTab(CType(page, XtraTabPage).TabControl.Parent)
                Return
            End If
            page = page.Parent
        End While
    End Sub

    Public Overridable Function ValidateData() As Boolean Implements IRelatedObject.ValidateData
        If ValidateMandatoryFields(Me) = False Then Return False
        For Each validator As IValidator In Validators
            If Not validator.Validate(Nothing, True) Then
                Return False
            End If
        Next
        For Each child As IRelatedObject In m_ChildForms
            If child.ValidateData() = False Then
                BringUpCurrentTab(CType(child, Control))
                Return False
            End If
        Next
        Return True
    End Function

    Dim m_dataSet As New DataSet

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property baseDataSet() As DataSet Implements IRelatedObject.baseDataSet
        Get
            Return m_dataSet
        End Get
        Set(ByVal Value As DataSet)
            If m_dataSet IsNot Nothing Then
                If m_dataSet Is Value Then
                    Return
                End If
                DbDisposeHelper.DisposeDataset(m_dataSet)
            End If
            m_dataSet = Value
        End Set
    End Property

    Protected m_WasShown As Boolean

#End Region

    Private Sub BaseForm_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.VisibleChanged
        If IsCreated() AndAlso Visible = True AndAlso m_WasShown = False Then
            m_WasShown = True
            If Not DbService Is Nothing Then
                DbService.IgnoreChanges = False
            End If
            ResizeForm()
        End If
    End Sub

    Protected Overridable Sub ResizeForm()
    End Sub


    Protected Function GetLookupValue(ByVal keyFieldValue As Object, ByVal LookupTableName As String,
                                      ByVal DisplayFieldName As String) As String
        Dim dt As DataTable = baseDataSet.Tables(LookupTableName)
        If dt Is Nothing Then Return ""
        Dim row As DataRow = dt.Rows.Find(keyFieldValue)
        If Not Utils.IsEmpty(row) Then
            Return Utils.Str(row(DisplayFieldName))
        End If
        Return ""
    End Function

    Protected Function IsCreated() As Boolean
        Dim ctl As Control = Me
        While Not ctl Is Nothing
            If ctl.Created = False Then Return False
            ctl = ctl.Parent
        End While
        Return True
    End Function

    Public Shared Function FindBaseForm(ByVal ctl As Control) As BaseForm
        Dim p As Control = ctl.Parent
        While (Not p Is Nothing)
            If TypeOf (p) Is BaseForm Then
                Return CType(p, BaseForm)
            End If
            If TypeOf (p) Is PopupContainerControl AndAlso Not CType(p, PopupContainerControl).OwnerEdit Is Nothing Then
                p = CType(p, PopupContainerControl).OwnerEdit.Parent
            Else
                p = p.Parent
            End If
        End While
        Return Nothing
    End Function

    Protected m_SkipLookupEditValueChange As Boolean = False


    Protected m_OldParent As Control

    Private Sub BaseForm_ParentChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.ParentChanged
        If Not Parent Is Nothing Then
            If Not m_OldParent Is Nothing Then
                RemoveHandler m_OldParent.BackColorChanged, AddressOf BaseForm_BackColorChanged
            End If
            m_OldParent = Parent

            SetParentBackColor()
            AddHandler Parent.BackColorChanged, AddressOf BaseForm_BackColorChanged
        End If
    End Sub

    Private Sub BaseForm_BackColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not Parent Is Nothing Then
            SetParentBackColor()
        End If
    End Sub

    Private Sub SetParentBackColor(Optional ByVal parentCtl As Control = Nothing)
        If parentCtl Is Nothing Then parentCtl = Parent
        If parentCtl Is Nothing Then Return
        If UseParentBackColor Then
            Try
                BackColor = parentCtl.BackColor
            Catch ex As Exception
                If parentCtl.Parent Is Nothing Then Return
                SetParentBackColor(parentCtl.Parent)
            End Try
        End If
    End Sub

    Protected ReadOnly m_ActionLocker As New ActionLocker()

    Public Function LockHandler(Optional waitType As WaitDialogType = WaitDialogType.None) As Boolean
        Return m_ActionLocker.Lock(waitType)
    End Function

    Public Sub UnlockHandler()
        m_ActionLocker.Unlock()
    End Sub

    Protected Sub VisitCheckLlists(ByVal parentCtl As Control)
        For Each ctl As Control In parentCtl.Controls
            If TypeOf ctl Is CheckedListBoxControl Then
                MarkCheckListBoxes(CType(ctl, CheckedListBoxControl))
            Else
                VisitCheckLlists(ctl)
            End If
        Next
    End Sub

    Private Sub MarkCheckListBoxes(ByVal lst As CheckedListBoxControl)
        BeginUpdate()
        Dim i As Integer = 0
        If Not lst.DataSource Is Nothing AndAlso CType(lst.DataSource, DataView).Count > 0 Then
            lst.BeginUpdate()
            While Not lst.GetItem(i) Is Nothing AndAlso TypeOf lst.GetItemValue(i) Is Boolean
                lst.SetItemChecked(i, CType(IIf(True.Equals(lst.GetItemValue(i)), True, False), Boolean))
                i += 1
            End While
            lst.EndUpdate()
        End If
        EndUpdate()
    End Sub

    Protected Overridable Sub RemoveIdleHandler()
        Try
            For Each child As IRelatedObject In Me.Children
                If TypeOf child Is BaseForm Then
                    CType(child, BaseForm).RemoveIdleHandler()
                End If
            Next
            RemoveHandler Application.Idle, AddressOf UpdateButtonsState
        Catch ex As Exception
        End Try
    End Sub

    Protected m_ChangesDataset As DataSet

    Public Sub SaveInitialChanges()
        m_ChangesDataset = baseDataSet.GetChanges()
    End Sub

    Protected Shared Function AreEquals(ByVal value1 As Object, ByVal value2 As Object) As Boolean
        If value1 Is Nothing AndAlso value2 Is Nothing Then
            Return True
        End If
        If value1 Is DBNull.Value AndAlso value2 Is DBNull.Value Then
            Return True
        End If
        If Not value1 Is DBNull.Value AndAlso Not value2 Is DBNull.Value AndAlso value1.ToString = value2.ToString Then
            Return True
        End If
        Return False
    End Function

    Protected Overridable Function CheckColumnForModification(tableName As String, columnName As String) As Boolean
        Return True
    End Function

    Private Function WasModified() As Boolean
        Dim EnforceConstrains As Boolean = baseDataSet.EnforceConstraints
        If EnforceConstrains Then
            baseDataSet.EnforceConstraints = False
        End If
        Try

            If m_ChangesDataset Is Nothing Then
                For Each t As DataTable In baseDataSet.Tables
                    'Dim changes As DataTable = t.GetChanges
                    'If Not changes Is Nothing Then
                    For Each row As DataRow In t.Rows
                        If row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Deleted Then
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                                 "object {0}(class {1}) is modified. Row was {2} in the table {3}",
                                                 ObjectName, Me.GetType, row.RowState.ToString, t.TableName)
                            Return True
                        End If
                        If row.RowState = DataRowState.Modified Then
                            For Each col As DataColumn In t.Columns
                                If Not AreEquals(row(col), row(col, DataRowVersion.Original)) Then
                                    Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                                         "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}",
                                                         ObjectName, Me.GetType, col.ColumnName, t.TableName,
                                                         row(col, DataRowVersion.Original).ToString, row(col).ToString)
                                    Return True
                                End If
                            Next
                        End If
                    Next
                    'End If

                Next
                Return False
            End If
            Dim currentChanges As DataSet = baseDataSet.GetChanges
            For Each t As DataTable In currentChanges.Tables
                If m_ChangesDataset.Tables.Contains(t.TableName) = False Then
                    Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                         "object {0}(class {1}) is modified. Table {2} is added", ObjectName, Me.GetType,
                                         t.TableName)
                    Return True
                End If
                For Each row As DataRow In t.Rows
                    If row.RowState = DataRowState.Deleted Then
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                             "object {0}(class {1}) is modified. Row was deleted in the table {2}",
                                             ObjectName, Me.GetType, t.TableName)
                        Return True
                    End If
                    If t.PrimaryKey.Length = 0 Then
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                             "object {0}(class {1}): table {2} doesn't contain primary key", ObjectName,
                                             Me.GetType, t.TableName)
                        Return True
                    End If
                    Dim pk As New ArrayList
                    For Each col As DataColumn In t.PrimaryKey
                        pk.Add(row(col))
                    Next
                    Dim originalRow As DataRow = m_ChangesDataset.Tables(t.TableName).Rows.Find(pk.ToArray())
                    If originalRow Is Nothing Then
                        'If row.HasVersion(DataRowVersion.Original) Then
                        '    For Each col As DataColumn In t.PrimaryKey
                        '        If Not row(col).Equals(row(col, DataRowVersion.Original)) Then
                        '            Dbg.Debug(11, "object {0}(class {1}) is modified. Column {2} was changed from {3} to {4}", ObjectName, Me.GetType, col.ColumnName, row(col, DataRowVersion.Original), row(col))
                        '            Return True
                        '        End If
                        '    Next
                        'Else
                        '    Dbg.Debug(11, "object {0}(class {1}) is modified. Original row for table {2} is not found in changed dataset ", ObjectName, Me.GetType, t.TableName)
                        '    Return True
                        'End If
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                             "object {0}(class {1}) is modified. Original row for table {2} is not found in changed dataset ",
                                             ObjectName, Me.GetType, t.TableName)
                        Return True
                    End If
                    For Each col As DataColumn In t.Columns
                        If Not m_ChangesDataset.Tables(t.TableName).Columns.Contains(col.ColumnName) Then
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                                 "object {0}(class {1}) is modified. Column {2} was added to the table {3}",
                                                 ObjectName, Me.GetType, col.ColumnName, t.TableName)
                            Return True
                        End If
                        If _
                            CheckColumnForModification(t.TableName, col.ColumnName) AndAlso
                            Not AreEquals(originalRow(col.ColumnName), row(col)) Then
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle,
                                                 "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}",
                                                 ObjectName, Me.GetType, col.ColumnName, t.TableName,
                                                 originalRow(col.ColumnName), row(col))
                            Return True
                        End If
                    Next
                Next
            Next
            DbDisposeHelper.DisposeDataset(currentChanges)
        Finally
            If EnforceConstrains Then
                baseDataSet.EnforceConstraints = True
            End If
        End Try
        Return False
    End Function

    Protected m_RefereshParentForm As Boolean = False

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property RefreshParentForm() As Boolean
        Get
            Return m_RefereshParentForm
        End Get
    End Property

    Private m_PermissionObject As [Enum] = Nothing

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PermissionObject() As [Enum]
        Get
            Return m_PermissionObject
        End Get
        Set(ByVal value As [Enum])
            m_PermissionObject = value
            If Not m_PermissionObject Is Nothing Then
                Permissions = New StandardAccessPermissions(m_PermissionObject)
            End If
        End Set
    End Property

    Private m_Permissions As IAccessPermission = New DefaultAccessPermissions

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Permissions() As IAccessPermission
        Get
            Return m_Permissions
        End Get
        Set(ByVal value As IAccessPermission)
            m_Permissions = value
        End Set
    End Property

    Private m_IgnoreAudit As Boolean = False

    <Browsable(True), Localizable(False), DefaultValue(False)>
    Public Property IgnoreAudit() As Boolean
        Get
            Return m_IgnoreAudit
        End Get
        Set(ByVal value As Boolean)
            m_IgnoreAudit = value
        End Set
    End Property

    Private m_AuditObject As AuditObject = Nothing

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property AuditObject() As AuditObject
        Get
            Return m_AuditObject
        End Get
        Set(ByVal value As AuditObject)
            m_AuditObject = value
        End Set
    End Property

    Public Overridable Function Delete(ByVal key As Object) As Boolean
        Try
            If Not AuditObject Is Nothing Then
                AuditObject.Key = key
                Dbg.DbgAssert(Not Utils.IsEmpty(AuditObject.Key),
                              "object key is not defined for object {0}", AuditObject.Name)
                AuditObject.EventType = AuditEventType.daeDelete
                AddHandler DbService.OnTransactionStarted, AddressOf CreateAuditEvent
                AddHandler DbService.OnTransactionFinished, AddressOf StartReplicationAsync
            End If
            If DbService.Delete(key) Then
                If Not LookupTableNames Is Nothing Then
                    For Each name As String In LookupTableNames
                        LookupCache.NotifyDelete(name, Nothing, key)
                    Next
                ElseIf Not AuditObject Is Nothing AndAlso Not Utils.IsEmpty(AuditObject.AuditTable) Then
                    LookupCache.NotifyDelete(AuditObject.AuditTableName, Nothing, key)
                End If
                'If TypeOf Me Is BaseListForm Then
                '    Me.LoadData(Nothing)
                'End If
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw
        Finally
            If Not AuditObject Is Nothing Then
                RemoveHandler DbService.OnTransactionStarted, AddressOf CreateAuditEvent
                RemoveHandler DbService.OnTransactionFinished, AddressOf StartReplicationAsync
            End If
            'If TypeOf Me Is BaseListForm Then
            '    LoadData(Nothing)
            'ElseIf Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed AndAlso TypeOf Me.m_ParentBaseForm Is BaseListForm Then
            '    m_ParentBaseForm.LoadData(Nothing)
            'End If
        End Try
    End Function

    Public Sub CreateAuditEvent(ByVal sender As Object, ByVal args As PostEventArgs)
        AuditManager.CreateAuditEvent(AuditObject, args.Transaction)
    End Sub

    Protected Sub StartReplicationAsync(ByVal sender As Object, ByVal args As PostEventArgs)
        AuditManager.StartReplicationAsync(AuditObject)
    End Sub

    Protected Sub SaveEventLog(ByVal sender As Object, ByVal args As PostEventArgs)
        If EventLog Is Nothing Then
            Return
        End If
        Try
            Dim events As List(Of EventInfo) = DbService.GetEventTypes
            If Not events Is Nothing AndAlso events.Count > 0 Then
                Dim askForReplication As Boolean = False
                For Each evt As EventInfo In events
                    If (evt.StartReplication = False) Then
                        evt.Processed = 2
                    Else
                        askForReplication = True
                    End If
                Next
                Dim startReplication As Boolean = Not Utils.IsCalledFromUnitTest AndAlso
                                                  askForReplication AndAlso ReplicationNeeded
                If _
                    startReplication AndAlso
                    Not _
                    WinUtils.ConfirmMessage(
                        BvMessages.Get("msgReplicationPrompt", "Start the replication to transfer data on other sites?"),
                        BvMessages.Get("msgREplicationPromptCaption", "Confirm Replication")) Then
                    For Each evt As EventInfo In events
                        evt.Processed = 2
                    Next
                End If
                'Dim checkNotificationService As Boolean = False
                For Each evt As EventInfo In events
                    If Utils.IsEmpty(evt.ID) Then
                        evt.ID = GetKey()
                    End If
                    If startReplication AndAlso evt.Processed = 0 Then
                        AuditObject.EventLog = EventLog _
                        'Transaction will be started asynchronously by StartReplicationAsync after transaction finising
                        evt.Processed = 2 'mark for skip replication start
                        'checkNotificationService = True
                    End If
                    EventLog.CreateProcessedEvent(evt.Type, evt.ID, evt.Processed, Nothing)
                Next
                'If checkNotificationService Then
                '    EventLog.CheckNotificationService()
                'End If

            End If

        Catch ex As Exception
            Dbg.Debug("error during event log saving: {0}", ex.Message)
            Dbg.Debug("-> object {0}", ObjectName)
            Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
            Dbg.Trace()

        End Try
        'End If
    End Sub

    Private Shared m_ReplicationNeeded As Boolean = True

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shared Property ReplicationNeeded() As Boolean
        Get
            Return m_ReplicationNeeded
        End Get
        Set(ByVal value As Boolean)
            m_ReplicationNeeded = value
        End Set
    End Property

    'This method can be used for adding _ReadOnly column that defines the readonly behavior of the specific object
    Public Shared Sub AddReadOnlyColumn(ByVal table As DataTable, Optional ByVal expression As String = "True")
        If Not table Is Nothing AndAlso Not table.Columns.Contains("_ReadOnly") Then
            Dim col As New DataColumn("_ReadOnly", GetType(Boolean), expression)
            col.ReadOnly = True
            table.Columns.Add(col)
        End If
    End Sub

    Private m_LookupTableNames As String()

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property LookupTableNames() As String()
        Get
            Return m_LookupTableNames
        End Get
        Set(ByVal value As String())
            m_LookupTableNames = value
        End Set
    End Property

    Protected Sub SelectLastFocusedControl()
        If Not m_LastFocusedControl Is Nothing Then
            If Not m_LastFocusedControl.Parent Is Nothing AndAlso TypeOf m_LastFocusedControl.Parent Is GridControl Then
                CType(m_LastFocusedControl.Parent, GridControl).Select()
                CType(m_LastFocusedControl.Parent, GridControl).MainView.ShowEditor()
            End If
            m_LastFocusedControl.Select()
        End If
    End Sub

    Protected Function FormCloseButtonClicked() As Boolean
        Dim f As Form = FindForm()
        If Not f Is Nothing Then
            Dim pt As Point = Cursor.Position
            pt = f.PointToClient(pt)
            f.GetChildAtPoint(pt)
            Return pt.X < f.Width AndAlso pt.X >= f.Width - 40 AndAlso pt.Y < 0
        End If
        Return False
    End Function

    Private m_ShowDateTimeFormatAsNullText As Boolean = True

    <Browsable(True), Localizable(False), DefaultValue(True)>
    Public Property ShowDateTimeFormatAsNullText() As Boolean
        Get
            Return m_ShowDateTimeFormatAsNullText
        End Get
        Set(ByVal value As Boolean)
            m_ShowDateTimeFormatAsNullText = value
        End Set
    End Property

    Protected Overridable Sub RemoveParentFormEvents(ByVal form As Form)
        Try
            RemoveHandler form.KeyDown, AddressOf BaseForm_KeyDown
        Catch ex As Exception
        End Try
        Try
            RemoveHandler form.Activated, AddressOf OnFormActivate
        Catch ex As Exception
        End Try

        Try
            RemoveHandler form.Closing, AddressOf OnFormClosing
        Catch ex As Exception
        End Try
        Try
            RemoveHandler form.BackColorChanged, AddressOf BaseForm_BackColorChanged
        Catch ex As Exception
        End Try
    End Sub

    Private m_AlwaysOpenInNewWindow As Boolean = False

    <Browsable(True), Localizable(False), DefaultValue(False)>
    Public Property AlwaysOpenInNewWindow() As Boolean
        Get
            Return m_AlwaysOpenInNewWindow
        End Get
        Set(ByVal value As Boolean)
            m_AlwaysOpenInNewWindow = value
        End Set
    End Property

    Private m_SingleInstance As Boolean = False

    <Browsable(True), Localizable(False), DefaultValue(False)>
    Public Property SingleInstance() As Boolean
        Get
            Return m_SingleInstance
        End Get
        Set(ByVal value As Boolean)
            m_SingleInstance = value
        End Set
    End Property

    Dim m_UseParentDataset As Boolean = False

    <Browsable(True), Localizable(False), DefaultValue(False)>
    Public Property UseParentDataset() As Boolean
        Get
            Return m_UseParentDataset
        End Get
        Set(ByVal value As Boolean)
            m_UseParentDataset = value
        End Set
    End Property

    Private Shared m_EventLog As IEventLog

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shared Property EventLog() As IEventLog
        Get
            Return m_EventLog
        End Get
        Set(ByVal value As IEventLog)
            m_EventLog = value
        End Set
    End Property

    Private m_FormType As BaseFormType

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FormType() As BaseFormType
        Get
            Return m_FormType
        End Get
        Set(ByVal value As BaseFormType)
            m_FormType = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        Try
            MyBase.Finalize()
        Catch ex As Exception
            If Not BaseSettings.ScanFormsMode Then
                Throw
            End If
        End Try
    End Sub

    Public Overridable Function Activate() As Control Implements IApplicationForm.Activate
        Dim frm As Form = FindForm()
        If (frm Is Nothing) Then
            Return Nothing
        Else
            If (Not m_DataLoaded) Then
                LoadData(GetKey())
            End If
            frm.Activate()
            BringToFront()
            frm.BringToFront()
            Return frm
        End If
    End Function

    Public ReadOnly Property AppCaption As String Implements IApplicationForm.Caption
        Get
            Return m_Caption
        End Get
    End Property

    <CLSCompliant(False)>
    Public Function Close(closeMode As FormClosingMode) As Boolean Implements IApplicationForm.Close

        'сохраняем все переводы, если мы в режиме правки
        If (BaseSettings.TranslationMode AndAlso Not DCManager Is Nothing AndAlso DCManager.HasChanges) Then
            If (DCManager.SaveTranslations() = False) Then
                Return False
            End If
        End If

        If closeMode <> FormClosingMode.NoSave Then
            m_ClosingMode = ClosingMode.Cancel
            If Not Post(PostType.FinalPosting) Then
                Return False
            End If
        End If

        DoClose()
        Return True
    End Function


    Public ReadOnly Property Key As Object Implements IApplicationForm.Key
        Get
            Return GetKey()
        End Get
    End Property


    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ValidationProcedureName As String

    Private m_IsValidObject As Boolean = True
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsValidObject As Boolean
        Get
            Return m_IsValidObject
        End Get
        Set(value As Boolean)
            m_IsValidObject = value
        End Set
    End Property
#Region "ITranslationView"

    Protected ReadOnly m_ArrangedButtons As List(Of Control) = New List(Of Control)()

    Private Sub RegisterArrangedButton(ctl As Control)
        If (Not m_ArrangedButtons.Contains(ctl)) Then
            m_ArrangedButtons.Add(ctl)
        End If
    End Sub

    Public Overrides Function GetDesignTypeForComponent(component As Component) As DesignElement
        Dim ctl As Control = Nothing
        If (TypeOf (component) Is ControlDesignerProxy) Then
            ctl = CType(component, ControlDesignerProxy).HostControl
        ElseIf TypeOf (component) Is Control Then
            ctl = CType(component, Control)
        End If
        If m_ArrangedButtons.Contains(ctl) Then
            Return DesignElement.Sizing Or DesignElement.Caption
        End If
        Return MyBase.GetDesignTypeForComponent(component)
    End Function

#End Region
End Class

