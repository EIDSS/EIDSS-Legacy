Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.IO
Imports bv.common.win.BaseForms
Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports bv.common.db
Imports bv.common.Objects
Imports bv.common.Core
Imports DevExpress.XtraBars
Imports DevExpress.XtraNavBar
Imports bv.winclient.Localization
Imports bv.winclient.Core
Imports bv.common.Enums
Imports bv.common.Resources
Imports bv.winclient.Layout
Imports DevExpress.XtraGrid

''' -----------------------------------------------------------------------------
''' <summary>
''' Enumerates application interface types
''' </summary>
''' <remarks>
''' Ititialize <see cref="BaseForm.AppType"/> property before main form loading to define interface type
''' </remarks>
''' <history>
''' 	[Mike]	19.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum ApplicationType
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines MDI applications interface that allows displaying multiple documents at the same time inside the main 
    ''' application form, 
    ''' with each document displayed in its own window. 
    ''' </summary>
    ''' <remarks>
    ''' Current <see cref="BaseForm"/> implementation defines the next forms behaviour when MDI is selected:
    ''' <list>
    ''' <item>
    ''' <description>
    ''' all list forms are opened in the separate windows that are appeared as MDI children of the application main form.
    ''' Only one list form of specific type can be opened at one time. If you try to open the same form twice from menu, the 
    ''' already opened form will be brought to front.
    ''' </description>
    ''' </item>
    ''' <item>
    ''' <description>
    ''' all detail forms are opened in as modal windows, so nested detail forms are opened as nested modal windows.
    ''' So the only details form branch can be open at once.
    ''' </description>
    ''' </item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    MDI
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines the applications interface that displays the only form inside the main application window. 
    ''' </summary>
    ''' <remarks>
    ''' Current <see cref="BaseForm"/> implementation defines the next forms behaviour when SDI is selected:
    ''' <list>
    ''' <item>
    ''' <description>
    ''' all list forms are opened inside the main application form and the only form can be visible at once. Forms are use the stack 
    ''' principle for showing: when the form is closed, the previous form became visible.
    ''' </description>
    ''' </item>
    ''' <item>
    ''' <description>
    ''' all detail forms are opened in as modal windows, so nested detail forms are opened as nested modal windows.
    ''' So the only details form branch can be open at once.
    ''' </description>
    ''' </item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    SDI
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines the applications interface that uses the toolbar as the main form and displays 
    ''' different document forms in separate windows. 
    ''' </summary>
    ''' <remarks>
    ''' Current <see cref="BaseForm"/> implementation defines the next forms behaviour when <b>Dashboard</b> is selected:
    ''' <list>
    ''' <item>
    ''' <description>
    ''' The application toolbar is displayed at the top of the desktop as separate window.
    ''' </description>
    ''' </item>
    ''' <item>
    ''' <description>
    ''' all list forms are opened as separate normal forms on the desktop.
    ''' </description>
    ''' </item>
    ''' <item>
    ''' <description>
    ''' all detail forms are opened in as modal windows, so nested detail forms are opened as nested modal windows.
    ''' So the only details form branch can be open at once.
    ''' </description>
    ''' </item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Dashboard
End Enum

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
    Inherits DevExpress.XtraEditors.XtraUserControl
    Implements IApplicationForm
    Implements IRelatedObject
    Implements IPostable
    Public eventManager As New DataEventManager(Me)
    Protected Shared m_CurrentForm As BaseForm
    'Public Shared formSettings As New ConfigWriter
    Public Delegate Function CanDeleteRowHandler(ByVal row As DataRow) As Boolean
    Protected m_ClosingProcessed As Boolean = False
    Protected m_WasSaved As Boolean = False ' should be set to true during intermediate posting
    Protected m_LastFocusedControl As Control = Nothing
    Protected Shared AppWaitCount As Int32 = 0
    Friend WithEvents GroupStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents TabStyleController As DevExpress.XtraEditors.StyleController
    Public Shared ShowFromID As Boolean = True
    Public Event OnValidatingData As ValidatingHandler
    Protected m_ClosingMode As BaseDetailForm.ClosingMode

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
        If Not IsDesignMode() Then
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
        If FormsList.Contains(Me) Then
            FormsList.Remove(Me)
        End If

        m_Closing = True
     
        If disposing Then
            RemoveIdleHandler()
            'If m_CurrentForm Is Me Then
            '    SetCurrentForm(Nothing)
            '    FindPrevBaseForm()
            'End If
            'RemoveForm(Me)
            If Me.ParentObject Is Nothing Then
                MemoryManager.Flush()
            End If
            eventManager.Clear(Me)
            comparer.Clear()
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        If Not m_Canvas Is Nothing Then
            m_Canvas.Dispose()
        End If
        MyBase.Dispose(disposing)
        If UseParentDataset = False Then
            DbDisposeHelper.DisposeDataset(m_dataSet)
        End If
        DbDisposeHelper.DisposeDataset(m_ChangesDataset)

        ' this call needs because of memory leak when layout helper has references to disposed form
        LayoutCorrector.Reset()
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents HelpProvider1 As bv.Tools.MSHelp2Support.Help2Provider
    Friend WithEvents EditStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents ButtonStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents MandatoryFieldStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents PopupEditStyleController As DevExpress.XtraEditors.StyleController
    Friend WithEvents ReadOnlyStyleController As DevExpress.XtraEditors.StyleController
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.HelpProvider1 = New bv.Tools.MSHelp2Support.Help2Provider(Me.components)
        Me.EditStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.ButtonStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.MandatoryFieldStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.PopupEditStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.ReadOnlyStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.GroupStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.TabStyleController = New DevExpress.XtraEditors.StyleController(Me.components)
        CType(Me.EditStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MandatoryFieldStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupEditStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReadOnlyStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabStyleController, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.MandatoryFieldStyleController.Appearance.BackColor = System.Drawing.Color.LemonChiffon
        Me.MandatoryFieldStyleController.Appearance.BorderColor = System.Drawing.Color.Red
        Me.MandatoryFieldStyleController.Appearance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MandatoryFieldStyleController.Appearance.Options.UseBackColor = True
        Me.MandatoryFieldStyleController.Appearance.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.Appearance.Options.UseFont = True
        Me.MandatoryFieldStyleController.AppearanceDisabled.BorderColor = System.Drawing.Color.Red
        Me.MandatoryFieldStyleController.AppearanceDisabled.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.AppearanceDropDown.BorderColor = System.Drawing.Color.Red
        Me.MandatoryFieldStyleController.AppearanceDropDown.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.AppearanceDropDownHeader.BorderColor = System.Drawing.Color.Red
        Me.MandatoryFieldStyleController.AppearanceDropDownHeader.Options.UseBorderColor = True
        Me.MandatoryFieldStyleController.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        '
        'PopupEditStyleController
        '
        Me.PopupEditStyleController.Appearance.BackColor = System.Drawing.Color.White
        Me.PopupEditStyleController.Appearance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PopupEditStyleController.Appearance.Options.UseBackColor = True
        Me.PopupEditStyleController.Appearance.Options.UseFont = True
        '
        'GroupStyleController
        '
        Me.GroupStyleController.Appearance.BackColor = System.Drawing.Color.Gray
        Me.GroupStyleController.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupStyleController.Appearance.Options.UseBackColor = True
        '
        'TabStyleController
        '
        Me.TabStyleController.Appearance.BackColor = System.Drawing.Color.Gray
        Me.TabStyleController.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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

    ''' -----------------------------------------------------------------------------
    ''' Project	 : bvwin_common
    ''' Class	 : common.win.BaseForm.HorizCoordComparer
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Implements <b>IComparer</b> interface for comparison of controls <b>Left</b> properties values
    ''' </summary>
    ''' <remarks>
    ''' This class is used by <i>BaseForm</i> class internally to arrange form buttons in horizontal direction.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Class HorizCoordComparer
        Implements IComparer

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Compares <b>Left</b> coordinates of 2 controls
        ''' </summary>
        ''' <param name="x">
        ''' the first control to compare
        ''' </param>
        ''' <param name="y">
        ''' the second control to compare
        ''' </param>
        ''' <returns>
        ''' Returns A signed number indicating the relative values of controls <b>Left</b> coordinates.
        '''<list type="table">
        '''  <listheader>
        '''     <term>Return Value</term>
        '''     <description>Meaning</description>
        '''  </listheader>
        '''<item>
        '''<term>Less than zero</term>
        '''<description><b>x.Left</b> is less than <b>y.Left</b></description>
        '''</item>
        '''<item>
        '''<term>Zero</term>
        '''<description><b>x.Left</b> and <b>y.Left</b> are equal</description>
        '''</item>
        '''<item>
        '''<term>Greater than zero</term>
        '''<description><b>x.Left</b> is greater than <b>y.Left</b></description>
        '''</item>
        ''' </list>
        ''' </returns>
        ''' <history>
        ''' 	[Mike]	04.05.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                   Implements IComparer.Compare
            If TypeOf (x) Is Control AndAlso TypeOf (y) Is Control Then
                Dim LeftX As Integer
                If Not m_StoredLeftControlEdge.ContainsKey(CType(x, Control)) Then
                    LeftX = CType(x, Control).Left
                    m_StoredLeftControlEdge(CType(x, Control)) = LeftX
                Else
                    LeftX = m_StoredLeftControlEdge(CType(x, Control))
                End If
                Dim LeftY As Integer
                If Not m_StoredLeftControlEdge.ContainsKey(CType(y, Control)) Then
                    LeftY = CType(y, Control).Left
                    m_StoredLeftControlEdge(CType(y, Control)) = LeftY
                Else
                    LeftY = m_StoredLeftControlEdge(CType(y, Control))
                End If
                Return LeftY - LeftX
            End If
            Throw New ArgumentException("object is not a Control")
        End Function 'IComparer.Compare
        'This list stores left edge positions of controls that should be aligned horizontally
        'used for controls sorting by its left position
        Private m_StoredLeftControlEdge As New Collections.Generic.Dictionary(Of Control, Integer)
        Public Sub Clear()
            m_StoredLeftControlEdge.Clear()
        End Sub

    End Class

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
            Me.m_ClosingProcessed = True
            RemoveIdleHandler()
            Dim Disposed As Boolean = False
            If Not ParentForm Is Nothing Then
                If ParentForm.Modal Then
                    Me.ParentForm.DialogResult = DialogResult.Cancel
                    ParentForm.Close()
                    Disposed = True
                ElseIf Not ParentForm Is BaseFormManager.MainForm Then
                    Me.ParentForm.Close()
                    Disposed = True
                End If
            End If
            BaseFormManager.Close(Me)
            If AppType = ApplicationType.SDI AndAlso Not Disposed Then Me.Dispose()
        Catch ex As Exception
            ErrorForm.ShowError(StandardError.UnprocessedError, ex)
        Finally
            m_Closing = False
            'DisplayCaption()
        End Try
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
            Me.m_ClosingProcessed = True
            RemoveIdleHandler()
            Dim Disposed As Boolean = False
            If Not ParentForm Is Nothing Then
                If ParentForm.Modal Then
                    Me.ParentForm.DialogResult = DialogResult.OK
                    Disposed = True
                ElseIf Not ParentForm Is BaseFormManager.MainForm Then
                    Me.ParentForm.Close()
                    Disposed = True
                End If
            End If
            BaseFormManager.Close(Me, DialogResult.OK, FormClosingMode.NoSave) 'UnRegister(Me)
            'If AppType = ApplicationType.SDI Then Me.Dispose()???Why I commented it?
            If AppType = ApplicationType.SDI AndAlso Not Disposed Then Me.Dispose()
        Catch ex As Exception
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
    Public Overridable Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
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
                    Dbg.Debug("base form {0} has no key field name. First column is used for key retrieving", Me.GetType.Name)
                    Return r(0)
                End If
            Catch ex As Exception
                Dbg.Debug("primary key for form {0} is not defined", Me.GetType.Name)
                Return Nothing
            End Try
        End If
        Return Nothing
    End Function
    Public Overridable Function GetRecordKey(ByVal row As DataRow, Optional ByVal aKeyFieldName As String = Nothing) As Object
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
    Public Function SetDetailTableValue(ByVal TableName As String, ByVal FieldName As String, ByVal Val As Object) As DataRow
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
    'Public Shared Sub SetCurrentForm(ByVal ctl As BaseForm)
    '    If Not ctl Is Nothing AndAlso FormsList.IndexOf(ctl) < 0 Then
    '        FormsList.Add(ctl)
    '    End If
    '    If Not m_CurrentForm Is Nothing AndAlso Not ctl Is Nothing AndAlso m_CurrentForm Is ctl Then
    '        Return
    '    End If
    '    Dim form As Form
    '    If Not m_CurrentForm Is Nothing Then
    '        form = m_CurrentForm.FindForm
    '        If Not form Is Nothing Then
    '            Try
    '                RemoveHandler form.KeyDown, AddressOf m_CurrentForm.BaseForm_KeyDown
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    '    m_CurrentForm = ctl
    '    If Not ctl Is Nothing Then
    '        Dbg.Debug("set current form: ", ctl.GetType().Name)
    '    End If
    '    If Not m_CurrentForm Is Nothing Then
    '        form = m_CurrentForm.FindForm
    '        If Not form Is Nothing Then
    '            Try
    '                RemoveHandler form.KeyDown, AddressOf m_CurrentForm.BaseForm_KeyDown
    '            Catch ex As Exception
    '            End Try
    '            AddHandler form.KeyDown, AddressOf m_CurrentForm.BaseForm_KeyDown
    '        End If
    '        m_CurrentForm.DisplayCaption()
    '        'form.BringToFront()
    '        m_CurrentForm.BringToFront()
    '    End If
    'End Sub
    'Public Shared Sub RemoveForm(ByVal ctl As BaseForm)
    '    Dim form As Form
    '    If Not ctl Is Nothing Then
    '        If FormsList.IndexOf(ctl) >= 0 Then
    '            FormsList.Remove(ctl)
    '            form = ctl.FindForm
    '            If Not form Is Nothing Then
    '                ctl.RemoveParentFormEvents(form)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Public Shared ReadOnly Property CurrentBaseForm() As BaseForm
    '    Get
    '        Return m_CurrentForm
    '    End Get
    'End Property
    Private Shared m_MainForm As Form = Nothing
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the instance of the application main form 
    ''' </summary>
    ''' <remarks>
    ''' This property must be initialized during main form initialization to provide 
    ''' the expected <b>BaseForm</b> behaviour.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public Shared Property MainForm() As Form
    '    Get
    '        Return m_MainForm
    '    End Get
    '    Set(ByVal Value As Form)
    '        m_MainForm = Value
    '    End Set
    'End Property
    Private Shared m_BarManager As BarManager
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shared Property MainBarManager() As BarManager
        Get
            Return m_BarManager
        End Get
        Set(ByVal Value As BarManager)
            m_BarManager = Value
        End Set
    End Property

    Private Shared m_AppType As ApplicationType = ApplicationType.SDI
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the <b>BaseForm</b> <see cref="ApplicationType"/>, that defines the application appearance 
    ''' and <b>BaseForm</b> instances behaviour
    ''' </summary>
    ''' <remarks>
    ''' <see cref="ApplicationType"/> is set to <see cref="ApplicationType.SDI"/> by default.
    ''' Initialize this property during main application form initialization if you want to use
    ''' other <see cref="ApplicationType"/> value.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shared Property AppType() As ApplicationType
        Get
            Return m_AppType
        End Get
        Set(ByVal Value As ApplicationType)
            m_AppType = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Searches the form of specified type related with the specified object ID and refershes data in the specified <b>BaseForm</b> if form is found.
    ''' </summary>
    ''' <param name="c">
    ''' <b>BaseForm</b> to refresh
    ''' </param>
    ''' <param name="ID">
    ''' primary key related with form to refresh. Should be Nothing for List forms.
    ''' </param>
    ''' <returns>
    ''' Returns <b>True</b> if form is found among open forms and false in other case.
    ''' </returns>
    ''' <remarks>
    ''' System architecture assumes that the only form of specific type with specific ID can be open simultaniously.
    ''' This method is used internally by other <b>BaseForm</b> methods to find existing form and activateit 
    ''' rather then create the new one.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	22.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    'Private Shared Function ReloadOpenForm(ByVal c As BaseForm, Optional ByVal ID As Object = Nothing) As Boolean
    '    For Each form As BaseForm In FormsList
    '        Dim key As Object = form.GetKey()
    '        If form.GetType() Is c.GetType() AndAlso ((key Is Nothing AndAlso ID Is Nothing) _
    '                OrElse (Not key Is Nothing AndAlso key.Equals(ID))) Then
    '            form.Post(PostType.IntermediatePosting)
    '            form.LoadData(ID)
    '            'form.DisplayCaption()
    '            form.FindForm().BringToFront()
    '            Return True
    '        End If
    '    Next
    '    'FormsList.Add(c)
    '    Return False
    'End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Opens the detail form for the object selected in the list form. 
    ''' </summary>
    ''' <param name="FormToOpen">
    ''' <b>BaseForm</b> to be open
    ''' </param>
    ''' <param name="ID">
    ''' primary key of the object related with this <b>BaseForm</b>
    ''' </param>
    ''' <param name="ParentID">
    ''' primary key of the object related with parent <b>BaseForm</b>.
    ''' </param>
    ''' <remarks>
    ''' <paramref name="ParentID"/> passed as parameter is used to initialze 
    ''' <b>FormToOpen.ParentID</b> property. It can be used to set link between parent object and current one
    ''' inside specific <b>BaseFeom</b> implementation. As a rule <paramref name="ParentID"/> is initialized when
    ''' you open detail form from other parent detail form.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	05.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    'Public Shared Sub ShowListDetail(ByVal FormToOpen As BaseForm, Optional ByVal ID As Object = Nothing, Optional ByVal ParentID As Object = Nothing)
    '    If Config.GetSetting("DetailFormType", "") = "Normal" OrElse AppType <> ApplicationType.SDI Then
    '        ShowNormal(FormToOpen, ID, FormToOpen.StartUpParameters)
    '        Return
    '    End If
    '    'If AppType = ApplicationType.SDI Then
    '    ShowModal(FormToOpen, MainForm, ID, ParentID, FormToOpen.StartUpParameters)
    '    'Else
    '    'If ReloadOpenForm(FormToOpen, ID) = False Then
    '    '    ShowNormal(FormToOpen, ID, FormToOpen.StartUpParameters)
    '    'End If
    '    'End If
    'End Sub
    'Protected Shared ModalFormCount As Integer = 0
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Shows the <b>BaseForm</b> in the dialog window.
    ''' </summary>
    ''' <param name="FormToShow">
    ''' <b>BaseForm</b> to be open
    ''' </param>
    ''' <param name="ID">
    ''' primary key of the object related with this <b>BaseForm</b>
    ''' </param>
    ''' <param name="ParentID">
    ''' primary key of the object related with parent <b>BaseForm</b>.
    ''' </param>
    ''' <param name="Params">
    ''' additional list of arbitrary parameters that should be applied to the <b>FormToShow</b>.
    ''' These parameters will be accessible inside <b>BaseForm</b> instance through <see cref="StartUpParameters"/> property
    ''' </param>
    ''' <param name="Width">
    ''' Sets the desired width of the <paramref name="FormToShow"/>. If <b>Width = 0</b> (default value), the form width is not changed.
    ''' If <b>Width = &lt; 0 </b>, the form width is fit to the screen width. In other case the form width is set to the passed value.
    ''' </param>
    ''' <param name="Height">
    ''' Sets the desired height of the <paramref name="FormToShow"/>. If <b>Height = 0</b> (default value), the form height is not changed.
    ''' If <b>Height = &lt; 0 </b>, the form height is fit to the screen height. In other case the form height is set to the passed value.
    ''' </param>
    ''' <returns>
    ''' Returns <b>True</b> if dialog window was closed with <b>DialogResult.OK</b> status or <b>False</b> in other case.
    ''' </returns>
    ''' <remarks>
    ''' <b>ShowModal</b> method is used by framework to show detail form when <see cref="ApplicationType"/> is set to <b>ApplicationType.SDI</b>.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	22.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    'Public Shared Function ShowModal(ByVal FormToShow As BaseForm, ByVal Owner As Form, Optional ByRef ID As Object = Nothing, Optional ByVal ParentID As Object = Nothing, Optional ByVal Params As Dictionary(Of String, Object) = Nothing, Optional ByVal Width As Integer = 0, Optional ByVal Height As Integer = 0) As Boolean
    '    If FormToShow Is Nothing Then Return False
    '    If Not FormToShow.CanOpenForm(ID) Then
    '        Return False
    '    End If

    '    Dim frm As New XtraForm
    '    DebugTimer.Start(String.Format("{0} show", FormToShow.GetType.Name))
    '    DebugTimer.Start(String.Format("{0} before load", FormToShow.GetType.Name))
    '    Using New WaitDialog()
    '        If (Not BaseFormManager.MainForm Is Nothing) Then
    '            'frm.Owner = BaseForm.MainForm
    '            frm.Icon = BaseFormManager.MainForm.Icon
    '        End If
    '        Dim ScreenSize As Rectangle = Screen.GetWorkingArea(frm)

    '        If (FormToShow.Sizable) Then
    '            frm.FormBorderStyle = FormBorderStyle.Sizable
    '            If Width > 0 Then
    '                FormToShow.Width = Width
    '            ElseIf Width < 0 OrElse FormToShow.Width > ScreenSize.Width Then
    '                FormToShow.Width = ScreenSize.Width
    '            End If
    '            If Height > 0 Then
    '                FormToShow.Height = Height
    '            ElseIf Height < 0 OrElse FormToShow.Height > ScreenSize.Height Then
    '                FormToShow.Height = ScreenSize.Height
    '            End If

    '        Else
    '            frm.FormBorderStyle = FormBorderStyle.FixedDialog
    '            frm.MaximizeBox = False
    '        End If
    '        If FormToShow.MinHeight <> 0 AndAlso FormToShow.Height < FormToShow.MinHeight Then
    '            FormToShow.Height = FormToShow.MinHeight
    '        End If
    '        If FormToShow.MinWidth <> 0 AndAlso FormToShow.Width < FormToShow.MinWidth Then
    '            FormToShow.Width = FormToShow.MinWidth
    '        End If
    '        frm.ClientSize = New Size(FormToShow.Width, FormToShow.Height)
    '        frm.MinimumSize = New Size(CInt(IIf(FormToShow.MinWidth = 0, 0, FormToShow.MinWidth + frm.Width - FormToShow.Width)), _
    '                                CInt(IIf(FormToShow.MinHeight = 0, 0, FormToShow.MinHeight + frm.Height - FormToShow.Height)))
    '        frm.ShowInTaskbar = False
    '        frm.KeyPreview = True
    '        frm.MinimizeBox = False
    '        If Owner Is Nothing OrElse Owner Is m_MainForm OrElse frm.Width < Owner.Width OrElse frm.Height < Owner.Height Then
    '            frm.StartPosition = FormStartPosition.CenterScreen
    '        Else
    '            frm.StartPosition = FormStartPosition.Manual
    '            frm.Left = Owner.Left + 10
    '            frm.Top = Owner.Top + 10
    '        End If

    '        'frm.AcceptButton = FormToShow.AcceptButton
    '        frm.CancelButton = FormToShow.RejectButton
    '        FormToShow.Dock = DockStyle.Fill
    '        If frm.Width > ScreenSize.Width Then
    '            If Not FormToShow.Sizable Then
    '                FormToShow.Location = New Point(0, 0)
    '                FormToShow.Dock = DockStyle.None
    '            End If
    '            frm.Width = ScreenSize.Width
    '            frm.Left = ScreenSize.Left
    '        End If
    '        If frm.Height > ScreenSize.Height Then
    '            If Not FormToShow.Sizable Then
    '                FormToShow.Location = New Point(0, 0)
    '                FormToShow.Dock = DockStyle.None
    '            End If
    '            frm.Height = ScreenSize.Height
    '            frm.Top = ScreenSize.Top
    '        End If
    '        If frm.Left + frm.Width > ScreenSize.Width Then
    '            frm.Left = ScreenSize.Width - frm.Width
    '        End If
    '        If frm.Top + frm.Height > ScreenSize.Height Then
    '            frm.Top = ScreenSize.Height - frm.Height
    '        End If
    '        If Not FormToShow.Sizable Then
    '            frm.AutoScroll = True
    '        End If
    '        'AddHandler frm.KeyDown, AddressOf FormToShow.BaseFom_KeyDown
    '        FormToShow.Parent = frm
    '        DebugTimer.Start(String.Format("{0} set visible", FormToShow.GetType.Name))
    '        FormToShow.Visible = True
    '        DebugTimer.Stop()
    '        FormToShow.ParentKey = ParentID
    '        FormToShow.StartUpParameters = Params
    '        FormToShow.m_ParentBaseForm = m_CurrentForm
    '        If Not FormToShow.m_ParentBaseForm Is Nothing Then
    '            Dbg.Debug("parent base form for {0} is {1}", FormToShow.GetType().Name, FormToShow.m_ParentBaseForm.GetType().Name)
    '        End If
    '        If TypeOf FormToShow Is ISearchable Then
    '            CType(FormToShow, ISearchable).LoadSearchPanel()
    '            If Not Params Is Nothing Then
    '                If Params.ContainsKey("FromCondition") Then
    '                    FormToShow.DbService.ListFromCondition = Params("FromCondition").ToString()
    '                End If
    '                If Params.ContainsKey("FilterCondition") Then
    '                    FormToShow.DbService.ListFilterCondition = Params("FilterCondition").ToString()
    '                End If
    '                If Params.ContainsKey("SearchParameters") Then
    '                    FormToShow.DbService.SearchParameters = CType(Params("SearchParameters"), Generic.Dictionary(Of String, Object))
    '                End If
    '            End If
    '        End If
    '        DebugTimer.Stop()
    '        If FormToShow.LoadData(ID) = False Then Return False
    '        frm.WindowState = FormToShow.DefaultFormState
    '        frm.Text = FormToShow.Caption
    '        DebugTimer.Stop()
    '        If (TypeOf FormToShow Is ISearchable) AndAlso FormToShow.DbService.DoClearListConditions Then
    '            FormToShow.DbService.ListFromCondition = ""
    '            FormToShow.DbService.ListFilterCondition = ""
    '            FormToShow.DbService.SearchParameters = Nothing
    '        End If
    '    End Using
    '    'SetCurrentForm(FormToShow)
    '    Try
    '        ModalFormCount += 1
    '        Dim ret As DialogResult = frm.ShowDialog(Owner)
    '        If FormToShow.WasPosted OrElse ret = DialogResult.OK Then
    '            ID = FormToShow.GetKey
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        ErrorForm.ShowError(StandardError.UnprocessedError, ex)
    '    Finally
    '        ModalFormCount -= 1
    '        'SetCurrentForm(FormToShow.m_ParentBaseForm)
    '        If ModalFormCount <= 0 AndAlso Not m_CurrentForm Is Nothing AndAlso TypeOf (m_CurrentForm) Is BaseListForm Then 'AndAlso m_CurrentForm.GetKey() Is Nothing
    '            Try
    '                If FormToShow.RefreshParentForm Then
    '                    m_CurrentForm.LoadData(Nothing)
    '                End If
    '                m_CurrentForm.BringToFront()
    '            Catch ex As Exception
    '                ErrorForm.ShowError(StandardError.UnprocessedError, ex)
    '            End Try
    '        End If
    '        BaseFormGarbageCollector.MarkForDisposing(FormToShow)
    '    End Try
    'End Function

    'Public Shared Function ShowModal_ReadOnly(ByVal FormToShow As BaseForm, ByVal Owner As Form, Optional ByRef ID As Object = Nothing, Optional ByVal ParentID As Object = Nothing, Optional ByVal Params As Dictionary(Of String, Object) = Nothing, Optional ByVal Width As Integer = 0, Optional ByVal Height As Integer = 0) As Boolean

    '    If FormToShow Is Nothing Then Return False
    '    If Not FormToShow.CanViewObject() Then
    '        Return False
    '    End If
    'Dim frm As New XtraForm
    '    DebugTimer.Start(String.Format("{0} show", FormToShow.GetType.Name))
    '    DebugTimer.Start(String.Format("{0} before load", FormToShow.GetType.Name))

    '    If (Not BaseFormManager.MainForm Is Nothing) Then
    ''frm.Owner = BaseForm.MainForm
    '        frm.Icon = BaseFormManager.MainForm.Icon
    '    End If
    'Dim ScreenSize As Rectangle = Screen.GetWorkingArea(frm)

    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    If (FormToShow.Sizable) Then
    '        frm.FormBorderStyle = FormBorderStyle.Sizable
    '        If Width > 0 Then
    '            FormToShow.Width = Width
    '        ElseIf Width < 0 OrElse FormToShow.Width > ScreenSize.Width Then
    '            FormToShow.Width = ScreenSize.Width
    '        End If
    '        If Height > 0 Then
    '            FormToShow.Height = Height
    '        ElseIf Height < 0 OrElse FormToShow.Height > ScreenSize.Height Then
    '            FormToShow.Height = ScreenSize.Height
    '        End If

    '    Else
    '        frm.FormBorderStyle = FormBorderStyle.FixedDialog
    '        frm.MaximizeBox = False
    '    End If
    '    If FormToShow.MinHeight <> 0 AndAlso FormToShow.Height < FormToShow.MinHeight Then
    '        FormToShow.Height = FormToShow.MinHeight
    '    End If
    '    If FormToShow.MinWidth <> 0 AndAlso FormToShow.Width < FormToShow.MinWidth Then
    '        FormToShow.Width = FormToShow.MinWidth
    '    End If
    '    frm.ClientSize = New Size(FormToShow.Width, FormToShow.Height)
    '    frm.ShowInTaskbar = False
    '    frm.KeyPreview = True
    '    frm.MinimizeBox = False
    ''frm.AcceptButton = FormToShow.AcceptButton
    '    frm.CancelButton = FormToShow.RejectButton
    '    FormToShow.Dock = DockStyle.Fill
    '    If frm.Width > ScreenSize.Width Then
    '        If Not FormToShow.Sizable Then
    '            FormToShow.Location = New Point(0, 0)
    '            FormToShow.Dock = DockStyle.None
    '        End If
    '        frm.Width = ScreenSize.Width
    '        frm.Left = ScreenSize.Left
    '    End If
    '    If frm.Height > ScreenSize.Height Then
    '        If Not FormToShow.Sizable Then
    '            FormToShow.Location = New Point(0, 0)
    '            FormToShow.Dock = DockStyle.None
    '        End If
    '        frm.Height = ScreenSize.Height
    '        frm.Top = ScreenSize.Top
    '    End If
    '    If Not FormToShow.Sizable Then
    '        frm.AutoScroll = True
    '    End If
    ''AddHandler frm.KeyDown, AddressOf FormToShow.BaseFom_KeyDown
    '    FormToShow.Parent = frm
    '    DebugTimer.Start(String.Format("{0} set visible", FormToShow.GetType.Name))
    '    FormToShow.Visible = True
    '    DebugTimer.Stop()
    '    FormToShow.ParentKey = ParentID
    '    FormToShow.StartUpParameters = Params
    '    FormToShow.m_ParentBaseForm = m_CurrentForm
    '    If TypeOf FormToShow Is ISearchable Then
    '        CType(FormToShow, ISearchable).LoadSearchPanel()
    '        If Not Params Is Nothing Then
    '            If Params.ContainsKey("FromCondition") Then
    '                FormToShow.DbService.ListFromCondition = Params("FromCondition").ToString()
    '            End If
    '            If Params.ContainsKey("FilterCondition") Then
    '                FormToShow.DbService.ListFilterCondition = Params("FilterCondition").ToString()
    '            End If
    '            If Params.ContainsKey("SearchParameters") Then
    '                FormToShow.DbService.SearchParameters = CType(Params("SearchParameters"), Generic.Dictionary(Of String, Object))
    '            End If
    '        End If
    '    End If
    ''SetCurrentForm(FormToShow)
    '    DebugTimer.Stop()
    '    If FormToShow.LoadData(ID) = False Then Return False
    '    frm.WindowState = FormToShow.DefaultFormState
    '    frm.Text = FormToShow.Caption
    '    DebugTimer.Stop()
    '    If (TypeOf FormToShow Is ISearchable) AndAlso FormToShow.DbService.DoClearListConditions Then
    '        FormToShow.DbService.ListFromCondition = ""
    '        FormToShow.DbService.ListFilterCondition = ""
    '        FormToShow.DbService.SearchParameters = Nothing
    '    End If
    '    Try
    '        ModalFormCount += 1
    '        FormToShow.ReadOnly = True
    'Dim ret As DialogResult = frm.ShowDialog(Owner)
    '        If ret = DialogResult.OK Then ID = FormToShow.GetKey
    '        Return ret = DialogResult.OK
    '    Catch ex As Exception
    '        ErrorForm.ShowError(StandardError.UnprocessedError, ex)
    '    Finally
    ''frm.Dispose()
    ''GC.Collect()
    '        ModalFormCount -= 1
    ''SetCurrentForm(FormToShow.m_ParentBaseForm)
    '        If ModalFormCount <= 0 AndAlso Not m_CurrentForm Is Nothing AndAlso TypeOf (m_CurrentForm) Is BaseListForm Then 'AndAlso m_CurrentForm.GetKey() Is Nothing
    '            Try
    '                m_CurrentForm.LoadData()
    '                m_CurrentForm.BringToFront()
    '            Catch ex As Exception
    '                ErrorForm.ShowError(StandardError.UnprocessedError, ex)
    '            End Try
    '        End If
    '        BaseFormGarbageCollector.MarkForDisposing(FormToShow)
    '    End Try
    'End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Displays the <b>BaseFrom</b> for the purpose of record selection 
    ''' and returns the selected <b>DataRow</b> if it was succesfully selected.
    ''' </summary>
    ''' <param name="c"></param>
    ''' <param name="ID"></param>
    ''' <param name="ParentID"></param>
    ''' <param name="Params"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	22.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    'Public Shared Function ShowForSelection(ByVal c As BaseForm, ByVal Owner As Form, Optional ByRef ID As Object = Nothing, Optional ByVal ParentID As Object = Nothing, Optional ByVal Params As Dictionary(Of String, Object) = Nothing, Optional ByVal Width As Integer = 0, Optional ByVal Height As Integer = 0) As DataRow
    '    If c Is Nothing Then Return Nothing
    '    If Not c.CanViewObject() Then
    '        Return Nothing
    '    End If
    '    c.State = BusinessObjectState.SelectObject
    '    If Width <= 0 Then
    '        Width = 1000
    '    End If
    '    If Height <= 0 Then
    '        Height = 600
    '    End If
    '    If ShowModal(c, Owner, ID, ParentID, Params, Width, Height) = True Then
    '        Return c.GetCurrentRow
    '    End If
    '    Return Nothing
    'End Function
    'Public Shared Function ShowForMultiSelection(ByVal c As BaseForm, ByVal Owner As Form, Optional ByRef ID As Object = Nothing, Optional ByVal ParentID As Object = Nothing, Optional ByVal Params As Dictionary(Of String, Object) = Nothing, Optional ByVal Width As Integer = 0, Optional ByVal Height As Integer = 0) As DataRow()
    '    If c Is Nothing Then Return Nothing
    '    If Not c.CanViewObject() Then
    '        Return Nothing
    '    End If
    '    c.State = BusinessObjectState.SelectObject
    '    c.MultiSelect = True
    '    If Width <= 0 Then
    '        Width = 1000
    '    End If
    '    If Height <= 0 Then
    '        Height = 600
    '    End If
    '    If ShowModal(c, Owner, ID, ParentID, Params, Width, Height) = True Then
    '        Return c.GetSelectedRows
    '    End If
    '    Return Nothing
    'End Function

    'Private Shared Function CreateParentForm(ByVal c As BaseForm) As Form
    '    Dim frm As New XtraForm
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    If (c.Sizable) Then
    '        frm.FormBorderStyle = FormBorderStyle.Sizable
    '    End If
    '    If c.MinHeight <> 0 AndAlso c.Height < c.MinHeight Then
    '        c.Height = c.MinHeight
    '    End If
    '    If c.MinWidth <> 0 AndAlso c.Width < c.MinWidth Then
    '        c.Width = c.MinWidth
    '    End If
    '    frm.ClientSize = New Size(c.Width, c.Height)
    '    Application.DoEvents()
    '    frm.MinimumSize = New Size(CInt(IIf(c.MinWidth = 0, 0, c.MinWidth + frm.Width - c.Width)), _
    '                            CInt(IIf(c.MinHeight = 0, 0, c.MinHeight + frm.Height - c.Height)))
    '    frm.ShowInTaskbar = (AppType = ApplicationType.Dashboard)
    '    frm.KeyPreview = True
    '    'frm.AcceptButton = c.AcceptButton
    '    frm.CancelButton = c.RejectButton
    '    'AddHandler frm.KeyDown, AddressOf c.BaseFom_KeyDown
    '    c.Dock = DockStyle.Fill
    '    c.Parent = frm
    '    c.Visible = True
    '    Return frm
    'End Function

    'Public Shared Function ShowNormal(ByVal c As BaseForm, Optional ByVal ID As Object = Nothing, Optional ByVal Params As Hashtable = Nothing) As Form
    '    If c Is Nothing Then Return Nothing
    '    If Not c.CanOpenForm(ID) Then
    '        Return Nothing
    '    End If
    '    Using New WaitDialog()
    '        If c.AlwaysOpenInNewWindow = False Then
    '            Dim existingForm As BaseForm = Nothing
    '            If c.SingleInstance Then
    '                existingForm = FindFormByTypeAndOpen(c.GetType())
    '            Else
    '                existingForm = FindFormByIDAndOpen(c.GetType(), ID)
    '            End If
    '            If Not existingForm Is Nothing Then
    '                Dim parentFrm As Form = existingForm.FindForm
    '                If Not parentFrm Is Nothing Then
    '                    c.Dispose()
    '                    parentFrm.Show()
    '                    parentFrm.BringToFront()
    '                    Return parentFrm
    '                Else
    '                    existingForm.Dispose()
    '                End If
    '            End If
    '        End If
    '        If TypeOf c Is ISearchable Then
    '            CType(c, ISearchable).LoadSearchPanel()
    '        End If
    '        DebugTimer.Start("ShowNormal for form {0}", c.Name)
    '        Splash.SetTopmost(False)
    '        Dim frm As Form = CreateParentForm(c)
    '        AddHandler frm.Activated, AddressOf OnFormActivate
    '        AddHandler frm.Closing, AddressOf OnFormClosing
    '        If AppType = ApplicationType.MDI Then
    '            frm.MdiParent = MainForm
    '        End If
    '        c.StartUpParameters = Params
    '        If Not TypeOf (c) Is BaseListForm Then
    '            DebugTimer.Start("LoadData for form {0}", c.Name)
    '            If c.LoadData(ID) = False Then
    '                DebugTimer.Stop()
    '                Return Nothing
    '            End If
    '            DebugTimer.Stop()
    '        End If
    '        c.m_ParentBaseForm = m_CurrentForm
    '        'SetCurrentForm(c)
    '        frm.Text = c.Caption

    '        Splash.SetTopmost(False)
    '        frm.WindowState = c.DefaultFormState
    '        frm.ShowInTaskbar = True
    '        If c.Sizable = False Then
    '            frm.FormBorderStyle = FormBorderStyle.FixedSingle
    '            frm.MaximizeBox = False
    '        End If
    '        If (Not BaseForm.MainForm Is Nothing) Then
    '            frm.Icon = BaseForm.MainForm.Icon
    '        End If
    '        frm.StartPosition = FormStartPosition.CenterScreen
    '        frm.Show()
    '        Splash.SetTopmost(True)
    '        'c.InitFormLayout()
    '        frm.BringToFront()
    '        DebugTimer.Stop()
    '        Return frm
    '    End Using
    'End Function
    Public Shared Sub OnFormActivate(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf (sender) Is Form Then
            Dim frm As Form = CType(sender, Form)
            For Each c As Control In frm.Controls
                If TypeOf (c) Is BaseForm Then
                    'SetCurrentForm(CType(c, BaseForm))
                    If TypeOf (c) Is BaseListForm Then
                        If CType(c, BaseListForm).Loading Then Exit Sub
                        If CType(c, BaseListForm).LoadData(Nothing) = False Then
                            CType(c, BaseListForm).DoClose()
                        End If
                    End If
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

    Public Shared Sub CloseAll()
        While FormsList.Count > 0
            CType(FormsList(0), BaseForm).DoClose()
        End While
        m_CurrentForm = Nothing
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

    Private Shared Sub DisplayClientForm(ByVal c As BaseForm, ByVal ParentControl As Control, Optional ByVal ID As Object = Nothing, Optional ByVal Params As Dictionary(Of String, Object) = Nothing, Optional ByVal LoadSearchPanel As Boolean = True)
        Dim f As Form = ParentControl.FindForm
        'AddHandler f.KeyDown, AddressOf c.BaseFom_KeyDown
        f.SuspendLayout()
        c.Parent = ParentControl
        c.StartUpParameters = Params
        If TypeOf c Is ISearchable AndAlso LoadSearchPanel Then
            CType(c, ISearchable).LoadSearchPanel()
        End If
        c.LoadData(ID)
        c.Dock = DockStyle.Fill
        c.BringToFront()
        'c.UpdateBounds()
        c.BeginUpdate()
        c.Visible = True
        c.EndUpdate()
        'SetCurrentForm(c)
        f.ResumeLayout()
    End Sub

    'Public Shared Sub ShowClient(ByVal c As BaseForm, ByVal ParentControl As Control, Optional ByVal ID As Object = Nothing, Optional ByVal Params As Hashtable = Nothing)
    '    If c Is Nothing Then Return
    '    If Not c.CanViewObject() Then
    '        Return
    '    End If
    '    Using New WaitDialog()

    '        'If AppType <> ApplicationType.SDI Then
    '        '    If ReloadOpenForm(c, ID) = False Then
    '        '        ShowNormal(c, ID, Params)
    '        '    End If
    '        '    'SetCurrentForm(c)
    '        '    Return
    '        'End If
    '        For Each ctl As Control In ParentControl.Controls
    '            If ctl.GetType() Is c.GetType() Then
    '                'SetCurrentForm(CType(ctl, BaseForm))
    '                DisplayClientForm(CType(ctl, BaseForm), ParentControl, ID, Params, False)
    '                Return
    '            End If
    '        Next
    '        c.Visible = False
    '        DisplayClientForm(c, ParentControl, ID, Params)
    '    End Using
    'End Sub

    Public Shared Function FindRow(ByVal t As DataTable, ByVal fieldValue As Object, Optional ByVal FieldName As String = Nothing) As DataRow
        Return BaseDbService.FindRow(t, fieldValue, FieldName)
    End Function

    ' Public Shared Property FormLayoutRegistryKey() As String
    '    Get
    '        Return m_FormLayoutKey
    '    End Get
    '    Set(ByVal Value As String)
    '        Try
    'Dim key As Microsoft.Win32.RegistryKey
    '            key = Microsoft.Win32.Registry.EIDSS.model.Core.EidssUserContext.User.OpenSubKey(Value, True)
    '            m_FormLayoutKey = Value
    '        Catch ex As Exception
    '            m_FormLayoutKey = Nothing
    '        End Try
    '    End Set
    'End Property

    Public Shared Sub WaitIncrement(ByVal value As Int32)
        BaseForm.AppWaitCount += value
    End Sub

    Public Shared Function BeginWaitCursor() As Int32
        BaseForm.AppWaitCount += 1

        If (BaseForm.AppWaitCount > 0) Then
            'ctl.Cursor = Cursors.AppStarting
            Cursor.Current = Cursors.AppStarting
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "BeginWaitCursor: to Wait; count = {0}", BaseForm.AppWaitCount)
        End If

        Return BaseForm.AppWaitCount
    End Function

    Public Shared Function EndWaitCursor() As Int32
        BaseForm.AppWaitCount -= 1

        If (BaseForm.AppWaitCount <= 0) Then
            'ctl.Cursor = Cursors.Arrow
            Cursor.Current = Cursors.Arrow
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "EndWaitCursor: to Default; count = {0}", BaseForm.AppWaitCount)
        End If

        Return BaseForm.AppWaitCount
    End Function

#End Region

#Region "Overridable Methods"
    Public Overridable Sub Merge(ByVal ds As DataSet)
        baseDataSet.EnforceConstraints = ds.EnforceConstraints
        baseDataSet.Merge(ds, True)
        'If (baseDataSet.EnforceConstraints) Then
        For Each dt As DataTable In baseDataSet.Tables
            For Each col As DataColumn In dt.Columns
                If ds.Tables.Contains(dt.TableName) AndAlso ds.Tables(dt.TableName).Columns.Contains(col.ColumnName) Then
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

    Public Overridable Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean Implements IPostable.Post

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
        Return Me.Height
    End Function
    Public Function GetCurrentRow(Optional ByVal aTableName As String = Nothing) As DataRow
        If aTableName Is Nothing Then
            aTableName = ObjectName
        End If
        If aTableName Is Nothing AndAlso baseDataSet.Tables.Count > 0 Then
            aTableName = baseDataSet.Tables(0).TableName
            Dbg.Debug("base form {0} has no object/table name. First table in dataset is used for key receiving", Me.GetType.Name)
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
                    If TypeOf bmanager.Current Is DataRowView AndAlso Not CType(bmanager.Current, DataRowView).Row Is Nothing _
                            AndAlso CType(bmanager.Current, DataRowView).Row.RowState <> DataRowState.Detached Then
                        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper AndAlso Not Utils.IsEmpty(TagHelper.GetTagHelper(c).MandatoryFieldName) Then
                            Return Utils.IsEmpty(CType(bmanager.Current, DataRowView)(TagHelper.GetTagHelper(c).MandatoryFieldName))
                        End If

                        Return Utils.IsEmpty(CType(bmanager.Current, DataRowView)(c.DataBindings(0).BindingMemberInfo.BindingField))
                    End If
                Catch ex As Exception
                    Dbg.Debug("error during reading mandatory value from field {0}", c.DataBindings(0).BindingMemberInfo.BindingPath)
                End Try
            End If
        End If
        Return Utils.IsEmpty(CType(c, BaseEdit).EditValue) OrElse Utils.IsEmpty(c.Text)
    End Function
    Protected Sub ShowErrorAtValidateMandatoryFields(ByVal c As Control)
        ShowErrorAtValidateMandatoryFields(c, GetControlLabel(c))
    End Sub
    Protected Sub ShowErrorAtValidateMandatoryFields(ByVal c As Control, ByVal caption As String)
        ErrorForm.ShowWarning("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving", caption)
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
                If (TypeOf (c) Is Label OrElse TypeOf (c) Is LabelControl) AndAlso (c.Visible OrElse p.Visible = False) Then
                    Dim middle As Double = c.Top + c.Height / 2
                    If middle >= ctl.Top AndAlso _
                        middle <= (ctl.Top + ctl.Height) AndAlso _
                        c.Left < ctl.Left AndAlso _
                        (ctl.Left - c.Left - c.Width) < 100 Then
                        Return c.Text
                    End If

                End If
            Next
        End If
        'This is don to go around the problem with mandatory Age field on PatientInfo panel
        'The label is invisible the
        If Not p Is Nothing Then
            For Each c As Control In p.Controls
                If (TypeOf (c) Is Label OrElse TypeOf (c) Is LabelControl) Then
                    Dim middle As Double = c.Top + c.Height / 2
                    If middle >= ctl.Top AndAlso _
                        middle <= (ctl.Top + ctl.Height) AndAlso _
                        c.Left < ctl.Left AndAlso _
                        (ctl.Left - c.Left - c.Width) < 100 Then
                        Return c.Text
                    End If

                End If
            Next
        End If
        Return ctl.Name
    End Function
    Public Shared Sub SetEnabled(ByVal enable As Boolean)
        For Each frm As BaseForm In FormsList
            frm.Enabled = enable
            If enable AndAlso TypeOf frm Is ISearchable Then
                CType(frm, ISearchable).EnableSearchPanel()
            End If
            If frm Is BaseFormManager.CurrentForm Then
                frm.Refresh()
            End If
        Next
    End Sub

    Public Shared Function ResetLanguage() As Boolean
        LayoutCorrector.Init()
        Dim openedFoms As ArrayList = CType(FormsList.Clone, ArrayList)
        Try
            For Each frm As BaseForm In openedFoms
                If Not frm.GetType().IsSubclassOf(GetType(BaseListForm)) Then
                    frm.DoClose()
                    Continue For
                End If
                ResetLanguage(frm)
            Next
        Catch ex As Exception
            Dbg.Trace()
            Dbg.Debug(ex.ToString)
        End Try
        Return True
    End Function

    Public Shared Function SaveAllOpenedForms() As Boolean
        For Each frm As BaseForm In FormsList
            'SetCurrentForm(frm)
            If frm.Post(PostType.FinalPosting) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Sub ResetLanguage(ByVal frm As BaseForm)
        Dim ParentControl As Control = frm.Parent
        Dim c As BaseForm = CType(ClassLoader.LoadClass(frm.GetType.Name), BaseForm)
        c.StartUpParameters = frm.StartUpParameters
        Dim index As Integer = ParentControl.Controls.IndexOf(frm)
        c.Visible = False
        Dim f As Form = ParentControl.FindForm
        f.SuspendLayout()
        c.Parent = ParentControl
        ParentControl.Controls.SetChildIndex(c, index)
        c.Dock = DockStyle.Fill
        'c.SendToBack()
        'c.baseDataSet.Merge(ds)
        frm.Parent = Nothing
        If TypeOf c Is ISearchable Then
            CType(c, ISearchable).LoadSearchPanel()
        End If
        If TypeOf c Is BasePagedListForm Then
            CType(c, BasePagedListForm).ShowSearch = CType(frm, BasePagedListForm).ShowSearch
        End If
        If Not TypeOf c Is BaseListForm Then
            c.LoadData(frm.GetKey)
        Else
            c.LoadData(Nothing)
        End If
        c.Visible = True
        'If frm Is BaseFormManager.CurrentForm Then
        '    BaseFormManager.SetCurrentForm(c)
        'End If
        f.ResumeLayout()
        'If (TypeOf c Is BaseListForm) Then
        '    CType(c, BaseListForm).LocateRow(key)
        'End If
        frm.RemoveParentFormEvents(f)
        frm.Dispose()
    End Sub
    Protected m_MultiSelect As Boolean
    <Localizable(False)> _
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

    <Browsable(True), DefaultValue(0), Localizable(False)> _
    Public Property MinWidth() As Integer Implements IApplicationForm.MinWidth
        Get
            Return m_MinWidth
        End Get
        Set(ByVal Value As Integer)
            m_MinWidth = Value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Overridable ReadOnly Property IsSingleTone() As Boolean Implements IApplicationForm.IsSingleTone
        Get
            Return False
        End Get
    End Property

    Dim m_MinHeight As Integer = 0
    <Browsable(True), DefaultValue(0), Localizable(False)> _
    Public Property MinHeight() As Integer Implements IApplicationForm.MinHeight
        Get
            Return m_MinHeight
        End Get
        Set(ByVal Value As Integer)
            m_MinHeight = Value
        End Set
    End Property



    Dim m_Sizable As Boolean = False
    <Browsable(True), DefaultValue(False), Localizable(False)> _
    Public Property Sizable() As Boolean Implements winclient.BasePanel.IApplicationForm.Sizable
        Get
            Return m_Sizable
        End Get
        Set(ByVal Value As Boolean)
            m_Sizable = Value
        End Set
    End Property

    Dim m_DefaultFormState As Windows.Forms.FormWindowState = FormWindowState.Normal
    <Browsable(True), DefaultValue(FormWindowState.Normal), Localizable(False)> _
    Public Property DefaultFormState() As Windows.Forms.FormWindowState
        Get
            Return m_DefaultFormState
        End Get
        Set(ByVal Value As Windows.Forms.FormWindowState)
            m_DefaultFormState = Value
        End Set
    End Property
    Protected m_StartUpParameters As Dictionary(Of String, Object)
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Overridable Property StartUpParameters() As Dictionary(Of String, Object) Implements winclient.BasePanel.IApplicationForm.StartUpParameters
        Get
            Return m_StartUpParameters
        End Get
        Set(ByVal Value As Dictionary(Of String, Object))
            m_StartUpParameters = Value
        End Set
    End Property

    Protected m_Loading As Integer = 0
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Loading() As Boolean
        Get
            Return m_Loading > 0
        End Get
    End Property
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property RootBaseForm() As BaseForm
        Get
            If Not ParentObject Is Nothing AndAlso TypeOf ParentObject Is BaseForm Then
                Return CType(ParentObject, BaseForm).RootBaseForm
            End If
            Return Me
        End Get
    End Property
    Private m_Closing As Boolean
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Closing() As Boolean
        Get
            Return RootBaseForm.m_Closing
        End Get
    End Property
    Protected m_State As BusinessObjectState
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    <Browsable(True), Localizable(False)> _
    Public Property HelpTopicID() As String
        Get
            Return m_HelpTopicID
        End Get
        Set(ByVal Value As String)
            m_HelpTopicID = Value
        End Set
    End Property

    <Browsable(True), Localizable(False)> _
    Public ReadOnly Property ImageList() As ImageList
        Get
            Return ImageList1
        End Get
    End Property

    Dim m_TableName As String
    <Browsable(True), Localizable(False)> _
    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal Value As String)
            m_TableName = Value
        End Set
    End Property
    Dim m_ObjectName As String
    <Browsable(True), Localizable(False)> _
    Public Property ObjectName() As String
        Get
            Return m_ObjectName
        End Get
        Set(ByVal Value As String)
            m_ObjectName = Value
        End Set
    End Property

    Private m_KeyFieldName As String
    <Browsable(True), Localizable(False)> _
    Public Property KeyFieldName() As String
        Get
            Return m_KeyFieldName
        End Get
        Set(ByVal Value As String)
            m_KeyFieldName = Value
        End Set
    End Property

    Private m_Caption As String
    <Browsable(True), Localizable(True)> _
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
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property ParentKey() As Object
        Get
            Return m_ParentKey
        End Get
        Set(ByVal Value As Object)
            m_ParentKey = Value
        End Set
    End Property
    Protected m_FullScreenMode As Boolean = False
    <Browsable(True), DefaultValue(False)> _
    Public Overridable Property FullScreenMode() As Boolean
        Get
            Return m_FullScreenMode
        End Get
        Set(ByVal Value As Boolean)
            m_FullScreenMode = Value
        End Set
    End Property

    Protected m_FormID As String
    <Browsable(True), Localizable(False)> _
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
    <Browsable(True), DefaultValue(FormStatus.Draft), Localizable(False)> _
    Public Property Status() As FormStatus
        Get
            Return m_Status
        End Get
        Set(ByVal Value As FormStatus)
            m_Status = Value
        End Set
    End Property
    Protected m_ParentBaseForm As BaseForm = Nothing
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ParentBaseForm() As BaseForm
        Get
            If Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed Then
                Return m_ParentBaseForm
            End If
            Return Nothing
        End Get
    End Property
    Private Shared m_ConvertTabsToDockPanels As Boolean = False
    <Browsable(False), DefaultValue(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shared Property ConvertTabsToDockPanels() As Boolean
        Get
            Return m_ConvertTabsToDockPanels
        End Get
        Set(ByVal Value As Boolean)
            m_ConvertTabsToDockPanels = Value
        End Set
    End Property
    Private Shared m_UseFormStatus As Boolean = True
    <DefaultValue(True), Localizable(False)> _
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
    <Browsable(True), DefaultValue(False)> _
    Public Overridable Property [ReadOnly]() As Boolean Implements IRelatedObject.ReadOnly
        Get
            If IsDesignMode() OrElse Not IsHandleCreated Then
                Return m_Readonly
            End If

            If ((Not DbService Is Nothing) AndAlso (Utils.Str(DbService.ID) = Utils.Str(Utils.SEARCH_MODE_ID))) Then
                Return False
            End If
            If BaseFormManager.ReadOnly Then
                Return True
            End If
            If (Not m_IsNewObject AndAlso Not TypeOf Me Is BaseDetailList AndAlso (Not Permissions.CanUpdate) AndAlso (Not Permissions.CanExecute)) OrElse _
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
            If (m_BindingDefined = True) Then
                ApplyReadOnlyStyle(Me, Value, False)
            End If
            For Each child As IRelatedObject In m_ChildForms
                child.ReadOnly = Value
            Next
        End Set
    End Property
    Private m_IsStatusReadOnly As Boolean = False
    Public Property IsStatusReadOnly() As Boolean
        Get
            Return m_IsStatusReadOnly
        End Get
        Set(ByVal value As Boolean)
            m_IsStatusReadOnly = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property AcceptButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property RejectButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property SelectButton() As IButtonControl
        Get
            Return Nothing
        End Get
    End Property
    Public Event AfterLoadData As EventHandler

    Dim m_UseParentBackColor As Boolean = False
    <Browsable(True), DefaultValue(False)> _
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
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
        If HasImage Then
            w.Width += 16
        End If
        If w.Width < 80 Then w.Width = 80
        Return CInt(w.Width)
    End Function

    Sub ArrangeButton(ByVal parentControl As Control, ByVal btn As Control, ByVal prevButton As Control, Optional ByVal ButtonTop As Integer = 8)
        If btn Is Nothing Then Return
        Dim PrevButtonLeft As Integer = parentControl.Width - 8
        If Not prevButton Is Nothing Then
            PrevButtonLeft = prevButton.Left - 8
            ButtonTop = prevButton.Top
            btn.Anchor = prevButton.Anchor
        End If
        Dim hasImage As Boolean = False
        If TypeOf btn Is Button Then
            hasImage = Not CType(btn, Button).Image Is Nothing OrElse (Not CType(btn, Button).ImageList Is Nothing AndAlso CType(btn, Button).ImageIndex >= 0 AndAlso CType(btn, Button).ImageList.Images.Count > CType(btn, Button).ImageIndex)
        ElseIf TypeOf btn Is SimpleButton Then
            Dim btn1 As SimpleButton = CType(btn, SimpleButton)
            hasImage = Not btn1.Image Is Nothing OrElse (btn1.ImageList Is Nothing AndAlso btn1.ImageIndex >= 0 AndAlso CType(btn1.ImageList, ImageList).Images.Count > btn1.ImageIndex)
        End If
        Dim w As Integer = CalcButtonWidth(btn, hasImage)
        If w > btn.Width Then
            btn.Width = w
        End If
        btn.Location = New Point(PrevButtonLeft - btn.Width, ButtonTop)
        btn.Parent = parentControl
    End Sub


    Dim m_Canvas As Graphics = Nothing
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
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

    <Browsable(False), DefaultValue(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    Public Shared Function GetHelpPath(ByRef language As String) As String
        Dim path As String
        If bv.winclient.Core.WinClientContext.HelpFiles.ContainsKey(language) Then
            path = bv.winclient.Core.WinClientContext.HelpFiles(language)
        Else
            path = ""
        End If
        If path <> "" AndAlso File.Exists(path) Then
            Return path
        End If
        If bv.winclient.Core.WinClientContext.HelpFiles.ContainsKey(bv.common.Core.Localizer.lngEn) Then
            path = bv.winclient.Core.WinClientContext.HelpFiles(bv.common.Core.Localizer.lngEn)
        End If
        If path <> "" AndAlso File.Exists(path) Then
            language = bv.common.Core.Localizer.lngEn
            Return path
        End If
        If Utils.Str(BaseHelpFileName) <> "" Then
            path = String.Format("{0}{1}.HxS", BaseHelpFileName, language)
            If File.Exists(path) Then
                Return path
            End If
            path = BaseHelpFileName + bv.common.Core.Localizer.lngEn
            If File.Exists(path) Then
                language = String.Format("{0}.HxS", bv.common.Core.Localizer.lngEn)
                Return path
            End If
        End If
        If path <> "" Then
            Return Nothing
        End If
        Return ""
    End Function
    Protected Sub ShowHelp(ByVal TopicID As String)
        Dim language As String = bv.model.Model.Core.ModelUserContext.CurrentLanguage
        If GetHelpPath(language) Is Nothing Then Return
        If bv.winclient.Core.WinClientContext.HelpNames.ContainsKey(language) = False Then Return
        If Not Utils.IsEmpty(TopicID) Then
            bv.Tools.MSHelp2Support.Help2.ShowHelp(Me, bv.winclient.Core.WinClientContext.HelpNames(language).ToString, TopicID)
        Else
            bv.Tools.MSHelp2Support.Help2.ShowHelp(Me, bv.winclient.Core.WinClientContext.HelpNames(language).ToString)
        End If
    End Sub

    'Private Sub BaseForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    '    FormsList.Remove(Me)
    'End Sub

    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If IsDesignMode() OrElse Not Created Then Return
            If m_BindingDefined = False AndAlso (TypeOf (Me) Is BaseListForm) Then 'OrElse UseFormStatus = True OrElse Status <> FormStatus.Demo
                m_BindingDefined = True
                DefineBinding()
            End If
            'DxControlsHelper.InitStyleController(Me.EditStyleController)
            'DxControlsHelper.InitStyleController(LayoutHelper.MandatoryStyleController)
            'DxControlsHelper.InitStyleController(Me.ReadOnlyStyleController)
            'DxControlsHelper.InitStyleController(Me.PopupEditStyleController)
            'DxControlsHelper.InitStyleController(Me.ButtonStyleController)
            LayoutCorrector.Reset()
            ApplyStyle(Me)
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
            ErrorForm.ShowError(StandardError.FillDatasetError, ex)
        End Try
    End Sub

    Protected Sub MergeTable(ByVal ds As DataSet, ByVal tableName As String)
        If ds.Tables.Contains(tableName) Then baseDataSet.Merge(ds.Tables(tableName))
    End Sub
    Private Function ShouldIgnoreReadonly(ByVal tag As Object) As Boolean
        Dim strTag As String = ""
        If Not tag Is Nothing AndAlso TypeOf (tag) Is TagHelper AndAlso CType(tag, TagHelper).StringTag <> Nothing Then
            strTag = Utils.Str(CType(tag, TagHelper).StringTag).ToLowerInvariant
        Else
            strTag = Utils.Str(tag).ToLowerInvariant
        End If
        If strTag.IndexOf("{alwayseditable}") >= 0 Then
            Return True
        ElseIf IsStatusReadOnly AndAlso strTag.IndexOf("{statuscontrol}") >= 0 Then
            Return True
        End If
        Return False
    End Function

    'Private Function ShouldIgnoreReadonly(ByVal c As Control) As Boolean
    '    If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
    '        If CType(c.Tag, TagHelper).StringTag.ToLowerInvariant.IndexOf("{alwayseditable}") >= 0 Then
    '            Return True
    '        ElseIf IsStatusReadOnly AndAlso CType(c.Tag, TagHelper).StringTag.ToLowerInvariant.IndexOf("{statuscontrol}") >= 0 Then
    '            Return True
    '        End If
    '    ElseIf Utils.Str(c.Tag).ToLowerInvariant.IndexOf("{alwayseditable}") >= 0 Then
    '        Return True
    '    ElseIf IsStatusReadOnly AndAlso Utils.Str(c.Tag).ToLowerInvariant.IndexOf("{statuscontrol}") >= 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    'Private Function ShouldIgnoreReadonly(ByVal btn As EditorButton) As Boolean
    '    If Utils.Str(btn.Tag).ToLowerInvariant.IndexOf("{alwayseditable}") >= 0 Then
    '        Return True
    '    ElseIf IsStatusReadOnly AndAlso Utils.Str(btn.Tag).ToLowerInvariant.IndexOf("{statuscontrol}") >= 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Protected Sub ApplyReadOnlyStyle(ByVal p As Control, ByVal Value As Boolean, Optional ByVal IgnoreReadOnly As Boolean = False)
        If Not p.GetType.GetInterface("ISearchForm") Is Nothing OrElse ShouldIgnoreReadonly(p.Tag) Then
            IgnoreReadOnly = True
        End If
        For Each c As Control In p.Controls
            Dim ctlIgnoreReadonly As Boolean = IgnoreReadOnly
            If Not ctlIgnoreReadonly Then
                ctlIgnoreReadonly = ShouldIgnoreReadonly(c.Tag)
            End If
            If (TypeOf (c) Is BaseButton) OrElse TypeOf c Is Button Then
                If ctlIgnoreReadonly = False AndAlso (Not ((TypeOf (p) Is BaseDetailForm) AndAlso _
                     ((c Is CType(p, BaseDetailForm).cmdCancel) OrElse _
                      (c Is CType(p, BaseDetailForm).cmdOk)))) Then
                    c.Enabled = Not Value
                End If
            ElseIf TypeOf (c) Is BaseEdit Then
                If ctlIgnoreReadonly = False Then
                    SetControlReadOnly(c, Value, False)
                End If
                SetControlState(CType(c, BaseControl), ctlIgnoreReadonly)
            ElseIf TypeOf (c) Is DevExpress.XtraGrid.GridControl Then
                SetGridControlReadOnlyState(CType(c, DevExpress.XtraGrid.GridControl), Value, ctlIgnoreReadonly)
            ElseIf TypeOf c Is CheckedListBoxControl Then
                c.Enabled = Not Value
            ElseIf Not TypeOf c Is IRelatedObject Then
                ApplyReadOnlyStyle(c, Value, ctlIgnoreReadonly)
            End If
        Next
    End Sub

    'Private Sub SetGridControlNotReadOnlyState(ByVal c As DevExpress.XtraGrid.GridControl, ByVal IgnoreNotReadOnly As Boolean)
    '    If IgnoreNotReadOnly = False Then
    '        If TypeOf (c.FocusedView) Is DevExpress.XtraGrid.Views.Grid.GridView Then
    '            Dim xgv As DevExpress.XtraGrid.Views.Grid.GridView = _
    '                CType(c.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
    '            If TypeOf (xgv.DataSource) Is DataView Then
    '                CType(xgv.DataSource, DataView).AllowNew = True
    '                CType(xgv.DataSource, DataView).AllowEdit = True
    '                CType(xgv.DataSource, DataView).AllowDelete = True
    '            End If
    '        End If
    '        For Each rit As DevExpress.XtraEditors.Repository.RepositoryItem In c.RepositoryItems
    '            SetRepositoryControlNotReadOnlyState(rit, IgnoreNotReadOnly)
    '        Next
    '    End If
    'End Sub

    Private Shared Sub SetGridControlReadOnlyState(ByVal c As DevExpress.XtraGrid.GridControl, ByVal value As Boolean, ByVal IgnoreReadOnly As Boolean)
        If IgnoreReadOnly = False Then
            If TypeOf (c.FocusedView) Is DevExpress.XtraGrid.Views.Grid.GridView Then
                Dim xgv As DevExpress.XtraGrid.Views.Grid.GridView = _
                    CType(c.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
                xgv.OptionsBehavior.Editable = Not value
                If TypeOf (xgv.DataSource) Is DataView Then
                    CType(xgv.DataSource, DataView).AllowNew = Not value
                    CType(xgv.DataSource, DataView).AllowEdit = Not value
                    CType(xgv.DataSource, DataView).AllowDelete = Not value
                End If
            End If
            For Each rit As DevExpress.XtraEditors.Repository.RepositoryItem In c.RepositoryItems
                If value Then
                    SetRepositoryControlReadOnlyState(rit, IgnoreReadOnly)
                Else
                    SetRepositoryControlNotReadOnlyState(rit, IgnoreReadOnly)
                End If
            Next
        End If
    End Sub

    Private Shared Sub SetRepositoryControlNotReadOnlyState(ByVal c As DevExpress.XtraEditors.Repository.RepositoryItem, ByVal IgnoreNotReadOnly As Boolean)
        If Not IgnoreNotReadOnly Then
            c.ReadOnly = False
            If TypeOf (c) Is DevExpress.XtraEditors.Repository.RepositoryItemPopupBase Then
                CType(c, DevExpress.XtraEditors.Repository.RepositoryItemPopupBase).ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick
                For Each btn As DevExpress.XtraEditors.Controls.EditorButton In CType(c, DevExpress.XtraEditors.Repository.RepositoryItemPopupBase).Buttons
                    btn.Enabled = True
                Next
            End If
        End If
    End Sub

    Private Shared Sub SetRepositoryControlReadOnlyState(ByVal c As DevExpress.XtraEditors.Repository.RepositoryItem, ByVal IgnoreReadOnly As Boolean)
        If IgnoreReadOnly = False Then
            c.ReadOnly = True
            If TypeOf (c) Is DevExpress.XtraEditors.Repository.RepositoryItemPopupBase Then
                CType(c, DevExpress.XtraEditors.Repository.RepositoryItemPopupBase).ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
                For Each btn As DevExpress.XtraEditors.Controls.EditorButton In CType(c, DevExpress.XtraEditors.Repository.RepositoryItemPopupBase).Buttons
                    btn.Enabled = False
                Next
            End If
        End If
    End Sub

    Public Sub ResetStyle(ByVal p As Control)
        '        If p Is Nothing Then Return
        '
        '        For Each c As Control In p.Controls
        '            c.Font = New Font("Tahoma", 10)
        '            If TypeOf (c) Is BaseControl Then
        '                Dim baseControl As BaseControl = CType(c, BaseControl)
        '                baseControl.StyleController = Nothing
        '
        '                Dim cb As LookUpEdit = TryCast(c, LookUpEdit)
        '                If (cb IsNot Nothing) Then
        '                    cb.Properties.Appearance.Font = c.Font
        '                    cb.Properties.AppearanceDisabled.Font = c.Font
        '                    cb.Properties.AppearanceDropDown.Font = c.Font
        '                    cb.Properties.AppearanceDropDownHeader.Font = c.Font
        '                    cb.Properties.AppearanceFocused.Font = c.Font
        '                    cb.Properties.AppearanceReadOnly.Font = c.Font
        '                End If
        '
        '            End If
        '            ResetStyle(c)
        'Next
    End Sub

    Public Sub ApplyStyle(ByVal p As Control, Optional ByVal IgnoreReadOnly As Boolean = False)
        If Not p.GetType.GetInterface("ISearchForm") Is Nothing OrElse Utils.Str(p.Tag) = "AlwaysEditable" Then
            IgnoreReadOnly = True
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
                        If Not c.Tag Is Nothing AndAlso Not TypeOf (c.Tag) Is TagHelper AndAlso Not OwnerBaseForm Is Nothing AndAlso OwnerBaseForm.GetType.Name <> "FFPresenter" Then
                            Dim th As TagHelper = New TagHelper(c)
                        End If
                        SetControlState(CType(c, BaseControl), IgnoreReadOnly)
                        SetControlLanguage(CType(c, BaseEdit))
                    End If
                End If
                ApplyStyle(c, IgnoreReadOnly)
            End If
        Next
    End Sub

    Private Function TagEquals(ByVal ctl As Control, ByVal text As String) As Boolean
        If ctl.Tag Is Nothing Then Return False
        If TypeOf (ctl.Tag) Is TagHelper Then
            Return Utils.Str(CType(ctl.Tag, TagHelper).StringTag) = text
        End If
        Return Utils.Str(ctl.Tag) = text
    End Function
    'Private Sub SetControlFont(ByVal c As Object)
    '    If TypeOf c Is Control AndAlso TagEquals(CType(c, Control), "FixFont") Then
    '        Return
    '    End If
    '    If TypeOf c Is Label OrElse TypeOf c Is LabelControl OrElse TypeOf c Is TabControl OrElse TypeOf c Is PopUpButton OrElse TypeOf c Is BarcodeButton OrElse TypeOf c Is Button Then
    '        Dim ctl As Control = CType(c, Control)
    '        If ctl.Font.Size <> 8.25! OrElse TagEquals(ctl, "FixFontSize") Then
    '            ctl.Font = New Font(bv.winclient.Core.WinClientContext.CurrentFont.FontFamily.Name, ctl.Font.Size, ctl.Font.Style)
    '        Else
    '            ctl.Font = bv.winclient.Core.WinClientContext.CurrentFont
    '        End If
    '    ElseIf TypeOf (c) Is DevExpress.XtraGrid.GridControl Then
    '        DxControlsHelper.InitXtraGridAppearance(CType(c, DevExpress.XtraGrid.GridControl), Me.ShowDateTimeFormatAsNullText)
    '    ElseIf TypeOf (c) Is DevExpress.XtraPivotGrid.PivotGridControl Then
    '        DxControlsHelper.InitPivotGridAppearance(CType(c, DevExpress.XtraPivotGrid.PivotGridControl))
    '    ElseIf TypeOf (c) Is DevExpress.XtraNavBar.NavBarControl Then
    '        DxControlsHelper.InitNavAppearance(CType(c, DevExpress.XtraNavBar.NavBarControl))
    '    ElseIf TypeOf (c) Is DevExpress.XtraTreeList.TreeList Then
    '        DxControlsHelper.InitXtraTreeAppearance(CType(c, DevExpress.XtraTreeList.TreeList), Me.ShowDateTimeFormatAsNullText)
    '    ElseIf TypeOf c Is DevExpress.XtraTab.XtraTabPage Then
    '        DxControlsHelper.InitXtraTabAppearance(CType(c, DevExpress.XtraTab.XtraTabPage))
    '    ElseIf TypeOf (c) Is GroupControl Then
    '        DxControlsHelper.InitGroupControlAppearance(CType(c, GroupControl))
    '    ElseIf TypeOf (c) Is RadioGroup Then
    '        DxControlsHelper.InitRadioGroupAppearance(CType(c, RadioGroup))
    '    ElseIf TypeOf (c) Is CheckEdit Then
    '        DxControlsHelper.InitCheckEditAppearance(CType(c, CheckEdit))
    '    ElseIf TypeOf (c) Is CheckedListBoxControl Then
    '        DxControlsHelper.InitAppearance(CType(c, CheckedListBoxControl).Appearance)
    '    ElseIf TypeOf c Is Control Then
    '        Dim ctl As Control = CType(c, Control)
    '        If ctl.Font.Size <> 8.25! OrElse TagEquals(ctl, "FixFontSize") Then
    '            ctl.Font = New Font(bv.winclient.Core.WinClientContext.CurrentFont.FontFamily.Name, ctl.Font.Size, ctl.Font.Style)
    '        Else
    '            ctl.Font = bv.winclient.Core.WinClientContext.CurrentFont
    '        End If
    '    End If
    'End Sub
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
            isReadOnly = True
            Return
        End If
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
            Dim th As TagHelper = CType(c.Tag, TagHelper)
            If th.IsReadOnly OrElse ([ReadOnly] AndAlso IgnoreReadOnly = False) Then
                SetControlReadOnly(c, True, False)
                isReadOnly = True
            ElseIf th.IsKeyField Then
                If (Me.State And BusinessObjectState.NewObject) = 0 AndAlso TypeOf c Is BaseEdit AndAlso Not CType(c, BaseEdit).EditValue Is DBNull.Value Then
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
            If (TypeOf (c) Is BaseEdit) AndAlso _
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

    'Private Sub SetControlNotReadOnly(ByVal c As DevExpress.XtraEditors.BaseControl, ByVal IgnoreNotReadOnly As Boolean)
    '    If Not IgnoreNotReadOnly Then
    '        If TypeOf c Is BaseEdit Then
    '            CType(c, BaseEdit).Properties.ReadOnly = False
    '        Else
    '            c.Enabled = True
    '        End If
    '        If TypeOf (c) Is PopupBaseEdit Then
    '            CType(c, PopupBaseEdit).Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick
    '            CType(c, PopupBaseEdit).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
    '            For Each btn As DevExpress.XtraEditors.Controls.EditorButton In CType(c, PopupBaseEdit).Properties.Buttons
    '                btn.Enabled = True
    '                btn.Visible = True
    '            Next
    '        End If
    '    End If
    'End Sub
    Private m_SavedReadonly As New Collections.Generic.Dictionary(Of Object, IStyleController)
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
                CType(c, PopupBaseEdit).Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
                CType(c, PopupBaseEdit).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Else
                DxControlsHelper.SetPopupControlBehavior(CType(c, PopupBaseEdit), False)
                If Not TypeOf (c) Is LookUpEdit Then
                    CType(c, PopupBaseEdit).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
                End If
            End If
            For Each btn As DevExpress.XtraEditors.Controls.EditorButton In CType(c, PopupBaseEdit).Properties.Buttons
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
    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        TagHelper.SetControlLanguage(CType(sender, Control), LastInputLanguage)
    End Sub

    Private Sub Control_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        SystemLanguages.SwitchInputLanguage(LastInputLanguage)
    End Sub

    'Private Sub DisplayCaption()
    '    Dim f As Form = Me.FindForm()
    '    If f Is Nothing OrElse Not f Is MainForm Then Exit Sub
    '    If Utils.Str(Caption) <> "" Then 'Visible AndAlso 
    '        If BaseForm.ShowFromID = True AndAlso FormID IsNot Nothing AndAlso FormID.Length > 0 Then
    '            f.Text = String.Format("[{0}]{1} - [{2}]", FormID, bv.model.core..AppCaption, Caption)
    '        Else
    '            f.Text = String.Format("{0} - [{1}]", GlobalSettings.AppCaption, Caption)
    '        End If
    '    Else
    '        If BaseForm.ShowFromID = True AndAlso FormID IsNot Nothing AndAlso FormID.Length > 0 Then
    '            f.Text = String.Format("[{0}]{1}", FormID, GlobalSettings.AppCaption)
    '        Else
    '            f.Text = EIDSS..model.core.AppCaption
    '        End If
    '    End If

    'End Sub

    'Private Sub FindPrevBaseForm()
    '    Dim f As Form = Me.FindForm()
    '    If Not f Is Nothing Then f.Text = String.Format("{0}", GlobalSettings.AppCaption)
    '    Dim p As Control = Me.Parent
    '    If Not p Is Nothing Then
    '        For Each c As Control In p.Controls
    '            If TypeOf (c) Is BaseForm AndAlso Not c Is Me Then
    '                SetCurrentForm(CType(c, BaseForm))
    '                Exit Sub
    '            End If
    '        Next
    '    End If
    'End Sub
    Shared Function IsButton(ByVal c As Control) As Boolean
        If TypeOf (c) Is Button Then Return True
        If TypeOf (c) Is SimpleButton Then Return True
        If TypeOf (c) Is PopUpButton Then Return True
        If TypeOf (c) Is BarcodeButton Then Return True
        If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is String AndAlso CType(c.Tag, String).IndexOf("Button") >= 0 Then Return True
        Return False
    End Function

    Private comparer As New HorizCoordComparer
    Protected Sub ArrangeButtons(ByVal ButtonTop As Integer, ByVal buttonGroupName As String, Optional ByVal ButtonHeight As Integer = 23, Optional ByVal NewTop As Integer = -1)
        ArrangeButtons(Me, ButtonTop, buttonGroupName, ButtonHeight, NewTop)
    End Sub

    Protected Sub ArrangeButtons(ByVal ctl As Control, ByVal ButtonTop As Integer, ByVal buttonGroupName As String, Optional ByVal ButtonHeight As Integer = 23, Optional ByVal NewTop As Integer = -1)
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
                    If c.Tag Is Nothing OrElse c.Tag.ToString.ToLower(Globalization.CultureInfo.InvariantCulture).IndexOf("{immovable}") < 0 Then
                        Buttons.Add(c)
                    End If
                ElseIf NewTop <> ButtonTop Then
                    If middle >= NewTop And middle <= (NewTop + ButtonHeight) Then
                        ' To Leave Button on it Place (Andrey)
                        If c.Tag Is Nothing OrElse c.Tag.ToString.ToLower(Globalization.CultureInfo.InvariantCulture).IndexOf("{immovable}") < 0 Then
                            Buttons.Add(c)
                        End If
                    End If
                End If
            End If
        Next

        ' Buttons
        Buttons.Sort(comparer)
        Dim prevButton As Control = Nothing
        Dim handleCreated As Boolean = IsHandleCreated
        For Each o As Object In Buttons
            Dim c As Control = CType(o, Control)
            If c.Visible OrElse Not handleCreated Then
                ArrangeButton(ctl, c, prevButton, NewTop)
                prevButton = c
            End If
        Next
        If Not handleCreated Then
            comparer.Clear()
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
    Public Overridable Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Implements IApplicationForm.BaseForm_KeyDown
        If e.KeyCode = Keys.Enter Then
            'e.Handled = True
            Dim FocusedControl As Control = ActiveControl
            While TypeOf (FocusedControl) Is ContainerControl AndAlso Not CType(FocusedControl, ContainerControl).ActiveControl Is Nothing
                FocusedControl = CType(FocusedControl, ContainerControl).ActiveControl
                If TypeOf (FocusedControl) Is BaseSearchPanel Then
                    CType(FocusedControl, BaseSearchPanel).BaseSearchPanel_KeyDown(CType(FocusedControl, BaseSearchPanel).ActiveControl, e)
                    Exit Sub
                End If
            End While
            If TypeOf (FocusedControl) Is DevExpress.XtraGrid.GridControl Then
                Exit Sub
            End If
            If Not FocusedControl.Parent Is Nothing AndAlso TypeOf (FocusedControl.Parent) Is DevExpress.XtraGrid.GridControl Then
                Exit Sub
            End If
            If Not FocusedControl.Parent Is Nothing AndAlso Not FocusedControl.Parent.Parent Is Nothing AndAlso TypeOf (FocusedControl.Parent.Parent) Is DevExpress.XtraGrid.GridControl Then
                Exit Sub
            End If
            If TypeOf (FocusedControl) Is BaseSearchPanel Then
                CType(FocusedControl, BaseSearchPanel).BaseSearchPanel_KeyDown(CType(FocusedControl, BaseSearchPanel).ActiveControl, e)
                Exit Sub
            End If
            ' Not TypeOf (FocusedControl) Is LookUpEdit AndAlso _
            If TypeOf (FocusedControl) Is PopupBaseEdit AndAlso _
                    CType(FocusedControl, PopupBaseEdit).IsPopupOpen() Then
                Exit Sub
            End If
            If TypeOf (FocusedControl) Is MemoEdit OrElse _
                    (TypeOf (FocusedControl) Is TextBoxMaskBox) AndAlso _
                    (Not CType(FocusedControl, TextBoxMaskBox).Parent Is Nothing AndAlso _
                    TypeOf (CType(FocusedControl, TextBoxMaskBox).Parent) Is MemoEdit) Then
                Exit Sub
            End If
            If (TypeOf (FocusedControl) Is TextBoxMaskBox) AndAlso _
               (Not FocusedControl.Parent Is Nothing) AndAlso _
               (TypeOf (FocusedControl.Parent) Is ButtonEdit) Then
                Dim edit As ButtonEdit = CType(FocusedControl.Parent, ButtonEdit)
                If (Not edit.Tag Is Nothing) AndAlso (TypeOf (edit.Tag) Is TagHelper) Then
                    Dim helper As TagHelper = CType(edit.Tag, TagHelper)
                    If helper.IsBarcode Then
                        edit.SelectAll()
                        Exit Sub
                    End If
                End If
            End If
            SelectNextControl(FocusedControl, True, True, True, True)
        ElseIf e.KeyCode = Keys.F1 Then
            ShowHelp()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.DoClose()
        End If
    End Sub

    Public Sub Release() Implements IApplicationForm.Release

    End Sub


    Public Shared Sub BaseForm_InputLanguageChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangedEventArgs)
        Dim frm As Form = CType(sender, Control).FindForm
        If Not frm Is Nothing Then
            Dim ctl As Control = frm.ActiveControl

        End If
        For Each c As Control In CType(sender, Control).Controls
        Next
    End Sub

    Protected Overridable Function SavePromptDialog(Optional ByVal DefaultResult As DialogResult = DialogResult.Yes) As DialogResult
        If BaseSettings.ShowSaveDataPrompt AndAlso Not Utils.IsCalledFromUnitTest Then 'AndAlso HasChanges() 
            Return MessageForm.Show(BvMessages.Get("Save data?"), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        End If
        Return DefaultResult
    End Function

    Protected Function DeletePromptDialog() As DialogResult
        If BaseSettings.ShowDeletePrompt AndAlso Not Utils.IsCalledFromUnitTest Then
            Return MessageForm.Show(BvMessages.Get("msgDeletePrompt", "The object will be deleted. Delete object?"), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

    'Public Overridable Function MeBeginWaitCursor() As Int32
    '    Return BaseForm.BeginWaitCursor(CType(Me, Control))
    'End Function

    'Public Overridable Function MeEndWaitCursor() As Int32
    '    Return BaseForm.EndWaitCursor(CType(Me, Control))
    'End Function

#Region "IRelatedObject Interface"
    Private m_DbService As BaseDbService = Nothing
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property DbService() As BaseDbService Implements IRelatedObject.DBService
        Get
            Return m_DbService
        End Get
        Set(ByVal Value As BaseDbService)
            m_DbService = Value
        End Set
    End Property


    Public Overridable Function GetChildKey(ByVal child As IRelatedObject) As Object Implements IRelatedObject.GetChildKey
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
            Dim AttemptsCount As Integer = 3
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                BaseForm.BeginWaitCursor()
                'Cursor.Current = Cursors.WaitCursor
            End If
            BeginUpdate()
            'While AttemptsCount > 0
            m_DataLoaded = False
            Try
                Result = LoadDataInternal(id)
                If (Result = False) Then
                    Dim err As ErrorMessage = DbService.LastError
                    If Not err Is Nothing AndAlso Not err.Exception Is Nothing Then
                        Throw err.Exception
                    End If
                End If
                If (Utils.IsEmpty(id) AndAlso TypeOf (Me) Is BaseDetailForm) Then
                    id = GetKey()
                End If
                Return Result
            Catch ex1 As SqlClient.SqlException
                'Select Case ex1.Number
                '    Case 11, 19, 17142 'GeneralNetworkError
                '        AttemptsCount -= 1
                '        If AttemptsCount = 0 Then
                '            ErrorForm.ShowError(ex1)
                '            Return False
                '        End If
                '    Case 17 'SQL server doesn't exists
                '        ErrorForm.ShowError(New ErrorMessage("errSqlServerDoesntExist", "Can't connect to the SQLServer. Please check that network connection is established, SQL Server is not shut down and try to open this form again.", ex1))
                '        Return False
                '    Case -1 'SQL server doesn't exists
                '        If ex1.ErrorCode = -2146232060 Then
                '            AttemptsCount -= 1
                '            If AttemptsCount = 0 Then
                '                ErrorForm.ShowError(New ErrorMessage("errGeneralNetworkError", "Can't establish connction to the SQL Server. Please check that network connection is established and try to open this form again.", ex1))
                '                Return False
                '            End If
                '        End If
                '    Case Else
                If (Not SqlExceptionHandler.Handle(ex1)) Then
                    ErrorForm.ShowError(StandardError.FillDatasetError, ex1)
                End If
                Return False
                'End Select
            End Try
            'End While
        Catch ex1 As UserErrorException
            ErrorForm.ShowWarningDirect(ex1.Message)
            Return False
        Catch ex As Exception
            ErrorForm.ShowError(StandardError.FillDatasetError, ex)
            Return False
        Finally
            EndUpdate()
            m_DataLoaded = True
            If (Result = True) Then
                AfterLoad()
            End If
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                BaseForm.EndWaitCursor()
            End If
            If Not Me.PermissionObject Is Nothing Then
                If ((Utils.Str(id) <> "SearchMode") AndAlso ((DbService Is Nothing) OrElse (Utils.Str(DbService.ID) <> Utils.Str(Utils.SEARCH_MODE_ID)))) Then
                    If (Me.State And BusinessObjectState.NewObject) <> 0 AndAlso _
                       (Permissions.CanInsert = False) AndAlso _
                        (Permissions.CanExecute = False) Then
                        If Me.GetType().Name = "HumanCaseDetail" Then
                            ReflectionHelper.SetProperty(Me, "ShowNavigators", False)
                        End If
                        Me.ReadOnly = True
                    End If
                    If (Me.State And BusinessObjectState.NewObject) = 0 AndAlso _
                       ((Permissions.CanUpdate = False) AndAlso _
                        (Permissions.CanExecute = False)) AndAlso _
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
        Dim key As Object
        If TypeOf (Me) Is BaseListForm Then
            key = CType(Me, BaseListForm).GetKey()
        Else
            key = Nothing
        End If
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
                Result = FillDataset(ID)
            End SyncLock
        End If
        DebugTimer.Stop()
        If (Result = True) Then
#If DEBUG Then
            For Each t As DataTable In baseDataSet.Tables
                Dbg.Assert(t.PrimaryKey IsNot Nothing AndAlso t.PrimaryKey.Length > 0, "The table {0} has no primary key", t.TableName)
            Next
#End If
            If Not DbService Is Nothing AndAlso DbService.IsNewObject Then
                m_State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
                m_IsNewObject = True
            ElseIf Not DbService Is Nothing AndAlso Not DbService.IsNewObject Then
                m_State = BusinessObjectState.EditObject
            End If
            If Not TypeOf (Me) Is BaseListForm Then  '  AndAlso m_BindingDefined = False
                'eventManager.Clear()
                DefineBinding()
                SetupGrids(Me)
                m_BindingDefined = True
                If m_ReadOnlyChanged Then
                    If (TypeOf (Me) Is BaseDetailForm) OrElse (TypeOf (Me) Is BaseLookupForm) OrElse (TypeOf (Me) Is BaseDetailPanel) Then
                        CType(Me, BaseForm).ApplyReadOnlyStyle(CType(Me, BaseForm), Me.ReadOnly, False)
                    End If
                    m_ReadOnlyChanged = False
                End If
            End If

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
            If Not DbService Is Nothing AndAlso Not (TypeOf (Me) Is BaseListForm) AndAlso (Me.State And BusinessObjectState.NewObject) = 0 Then
                '    Application.DoEvents()

                If ((Not TypeOf (Me) Is BaseRamDetailPanel) AndAlso (Not TypeOf (Me) Is BaseReportForm)) Then
                    Application.DoEvents()
                End If

                DataEventManager.Flush()
                DbService.AcceptChanges(baseDataSet)
                eventManager.HasChanges = False
            End If
            RaiseEvent AfterLoadData(Me, EventArgs.Empty)
            If Me.ParentObject Is Nothing AndAlso FormsList.IndexOf(Me) < 0 Then
                FormsList.Add(Me)
            End If
            If Not key Is Nothing AndAlso (TypeOf (Me) Is BaseListForm) Then
                CType(Me, BaseListForm).LocateRow(key)
            End If
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
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ParentObject() As IRelatedObject Implements IRelatedObject.ParentObject
        Get
            Return m_ParentForm
        End Get
        Set(ByVal Value As IRelatedObject)
            m_ParentForm = Value
        End Set
    End Property
    Protected m_ChildForms As New System.Collections.Generic.List(Of IRelatedObject)
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Children() As System.Collections.Generic.List(Of IRelatedObject) Implements IRelatedObject.Children
        Get
            Return m_ChildForms
        End Get
    End Property

    Public Sub RegisterChildObject(ByVal child As IRelatedObject, Optional ByVal childPostingType As RelatedPostOrder = RelatedPostOrder.PostFirst) Implements IRelatedObject.RegisterChildObject
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
        DbService.RemoveLinkedDbService(child.DBService)
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
            If TypeOf page Is DevExpress.XtraTab.XtraTabPage Then
                CType(page, DevExpress.XtraTab.XtraTabPage).TabControl.SelectedTabPage = CType(page, DevExpress.XtraTab.XtraTabPage)
                BringUpCurrentTab(CType(page, DevExpress.XtraTab.XtraTabPage).TabControl.Parent)
                Return
            End If
            page = page.Parent
        End While
    End Sub
    Public Overridable Function ValidateData() As Boolean Implements IRelatedObject.ValidateData
        If ValidateMandatoryFields(Me) = False Then Return False
        For Each child As IRelatedObject In m_ChildForms
            If child.ValidateData() = False Then
                BringUpCurrentTab(CType(child, Control))
                Return False
            End If
        Next
        Return True
    End Function

    Dim m_dataSet As New DataSet
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property baseDataSet() As System.Data.DataSet Implements IRelatedObject.baseDataSet
        Get
            Return m_dataSet
        End Get
        Set(ByVal Value As System.Data.DataSet)
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

    Private Sub BaseForm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
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


    Protected Function GetLookupValue(ByVal keyFieldValue As Object, ByVal LookupTableName As String, ByVal DisplayFieldName As String) As String
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
    'Private m_DefaultFontFamily As String = Nothing

    'Public ReadOnly Property DefaultFontFamily() As String
    '    Get
    '        Return m_DefaultFontFamily
    '    End Get
    'End Property

    'Private m_DefaultFontSize As Single = 8.25!

    'Public Sub InitDefaultFont()
    '    If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngGe AndAlso Not Utils.IsEmpty(GlobalSettings.GGSystemFontName) Then
    '        m_DefaultFontFamily = GlobalSettings.GGSystemFontName
    '        m_DefaultFontSize = GlobalSettings.GGSystemFontSize
    '    Else
    '        m_DefaultFontFamily = GlobalSettings.SystemFontName
    '        m_DefaultFontSize = GlobalSettings.SystemFontSize
    '    End If
    'End Sub
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

    Private Sub BaseForm_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        If Not Parent Is Nothing Then
            SetParentBackColor()
            AddHandler Parent.BackColorChanged, AddressOf Me.BaseForm_BackColorChanged
        End If
    End Sub

    Private Sub BaseForm_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Parent Is Nothing Then
            SetParentBackColor()
        End If
    End Sub
    Private Sub SetParentBackColor(Optional ByVal parentCtl As Control = Nothing)
        If parentCtl Is Nothing Then parentCtl = Parent
        If parentCtl Is Nothing Then Return
        If UseParentBackColor Then
            'If parentCtl.BackColor.ToArgb <> Color.Transparent.ToArgb Then
            Try
                Me.BackColor = parentCtl.BackColor
            Catch ex As Exception
                If parentCtl.Parent Is Nothing Then Return
                SetParentBackColor(parentCtl.Parent)
            End Try
            'ElseIf Not IsDesignMode() Then
            'End If
        End If
    End Sub
    Private m_HandlerLocked As Boolean

    Public Function LockHandler() As Boolean
        If m_HandlerLocked Then Return False
        m_HandlerLocked = True
        Return True
    End Function
    Public Sub UnlockHandler()
        m_HandlerLocked = False
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
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Row was {2} in the table {3}", ObjectName, Me.GetType, row.RowState.ToString, t.TableName)
                            Return True
                        End If
                        If row.RowState = DataRowState.Modified Then
                            For Each col As DataColumn In t.Columns
                                If Not AreEquals(row(col), row(col, DataRowVersion.Original)) Then
                                    Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}", ObjectName, Me.GetType, col.ColumnName, t.TableName, row(col, DataRowVersion.Original).ToString, row(col).ToString)
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
                    Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Table {2} is added", ObjectName, Me.GetType, t.TableName)
                    Return True
                End If
                For Each row As DataRow In t.Rows
                    If row.RowState = DataRowState.Deleted Then
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Row was deleted in the table {2}", ObjectName, Me.GetType, t.TableName)
                        Return True
                    End If
                    If t.PrimaryKey.Length = 0 Then
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}): table {2} doesn't contain primary key", ObjectName, Me.GetType, t.TableName)
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
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Original row for table {2} is not found in changed dataset ", ObjectName, Me.GetType, t.TableName)
                        Return True
                    End If
                    For Each col As DataColumn In t.Columns
                        If Not m_ChangesDataset.Tables(t.TableName).Columns.Contains(col.ColumnName) Then
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} was added to the table {3}", ObjectName, Me.GetType, col.ColumnName, t.TableName)
                            Return True
                        End If
                        If CheckColumnForModification(t.TableName, col.ColumnName) AndAlso Not AreEquals(originalRow(col.ColumnName), row(col)) Then
                            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}", ObjectName, Me.GetType, col.ColumnName, t.TableName, originalRow(col.ColumnName), row(col))
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
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property RefreshParentForm() As Boolean
        Get
            Return m_RefereshParentForm
        End Get
    End Property
    Public Shared Function FindFormByIDAndOpen(ByVal formType As Type, ByVal ID As Object) As BaseForm
        Dim form As BaseForm = FindFormByID(formType, ID)
        If Not form Is Nothing Then
            'form.Post(PostType.IntermediatePosting)
            'form.LoadData(ID)
            form.FindForm().BringToFront()
            'SetCurrentForm(form)
            Return form
        End If
        Return Nothing
    End Function
    Public Shared Function FindFormByID(ByVal formType As Type, ByVal ID As Object) As BaseForm
        For Each form As BaseForm In FormsList
            If Not form.IsDisposed Then
                Dim key As Object = form.GetKey()
                If form.GetType() Is formType AndAlso Utils.SEARCH_MODE_ID.Equals(key) AndAlso Utils.SEARCH_MODE_ID.Equals(ID) Then
                    Return form
                End If
                If form.GetType() Is formType AndAlso ((key Is Nothing AndAlso ID Is Nothing) _
                        OrElse (Not key Is Nothing AndAlso key.Equals(ID))) Then
                    Return form
                End If
            End If
        Next
        Return Nothing
    End Function
    Public Shared Function FindDetailFormByID(ByVal ID As Object) As BaseForm
        If Utils.IsEmpty(ID) Then
            Return Nothing
        End If
        For Each form As BaseForm In FormsList
            If Not form.IsDisposed AndAlso TypeOf (form) Is BaseDetailForm Then
                Dim key As Object = form.GetKey()
                If Not key Is Nothing AndAlso key.Equals(ID) Then
                    Return form
                End If
            End If
        Next
        Return Nothing
    End Function
    Public Shared Function FindFormByTypeAndOpen(ByVal formType As Type) As BaseForm
        Dim form As BaseForm = FindFormByType(formType)
        If Not form Is Nothing Then
            'form.Post(PostType.IntermediatePosting)
            'form.LoadData(ID)
            form.FindForm().BringToFront()
            'SetCurrentForm(form)
            Return form
        End If
        Return Nothing
    End Function
    Public Shared Function FindFormByType(ByVal formType As Type) As BaseForm
        For Each form As BaseForm In FormsList
            If Not form.IsDisposed Then
                If form.GetType() Is formType Then
                    Return form
                End If
            End If
        Next
        Return Nothing
    End Function
    Private m_PermissionObject As [Enum] = Nothing
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Permissions() As IAccessPermission
        Get
            Return m_Permissions
        End Get
        Set(ByVal value As IAccessPermission)
            m_Permissions = value
        End Set
    End Property
    Private m_IgnoreAudit As Boolean = False
    <Browsable(True), Localizable(False), DefaultValue(False)> _
    Public Property IgnoreAudit() As Boolean
        Get
            Return m_IgnoreAudit
        End Get
        Set(ByVal value As Boolean)
            m_IgnoreAudit = value
        End Set
    End Property

    Private m_AuditObject As AuditObject = Nothing
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
                Dbg.DbgAssert(Not Utils.IsEmpty(AuditObject.Key), "object key is not defined for object {0}", AuditObject.Name)
                AuditObject.EventType = AuditEventType.daeDelete
                AddHandler DbService.OnTransactionStarted, AddressOf CreateAuditEvent
                AddHandler DbService.OnTransactionFinished, AddressOf ProcessFiltration
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
                RemoveHandler DbService.OnTransactionFinished, AddressOf ProcessFiltration
            End If
            If TypeOf Me Is BaseListForm Then
                LoadData(Nothing)
            ElseIf Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed AndAlso TypeOf Me.m_ParentBaseForm Is BaseListForm Then
                m_ParentBaseForm.LoadData(Nothing)
            End If
        End Try
    End Function
    Public Sub CreateAuditEvent(ByVal sender As Object, ByVal args As PostEventArgs)
        AuditManager.CreateAuditEvent(Me.AuditObject, args.Transaction)
    End Sub
    Protected Sub ProcessFiltration(ByVal sender As Object, ByVal args As PostEventArgs)
        AuditManager.ProcessFiltration(Me.AuditObject)
    End Sub
    Protected Sub SaveEventLog(ByVal sender As Object, ByVal args As PostEventArgs)
        If BaseForm.EventLog Is Nothing Then
            Return
        End If
        Try
            Dim events As List(Of EventInfo) = DbService.GetEventTypes
            If Not events Is Nothing AndAlso events.Count > 0 Then
                If Not Utils.IsCalledFromUnitTest AndAlso (Not ReplicationNeeded OrElse Not WinUtils.ConfirmMessage(BvMessages.Get("msgReplicationPrompt", "Start the replication to transfer data on other sites?"), BvMessages.Get("msgREplicationPromptCaption", "Confirm Replication"))) Then
                    For Each evt As EventInfo In events
                        evt.Processed = 2
                    Next
                End If
                'Dim checkNotificationService As Boolean = False
                For Each evt As EventInfo In events
                    If Utils.IsEmpty(evt.ID) Then
                        evt.ID = GetKey()
                    End If
                    If evt.Processed = 0 Then
                        AuditObject.EventLog = BaseForm.EventLog
                        evt.Processed = 2
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
            Dbg.Debug("-> object {0}", Me.ObjectName)
            Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
            Dbg.Trace()

        End Try
        'End If
    End Sub
    Private Shared m_ReplicationNeeded As Boolean = True
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
            If Not m_LastFocusedControl.Parent Is Nothing AndAlso TypeOf m_LastFocusedControl.Parent Is DevExpress.XtraGrid.GridControl Then
                CType(m_LastFocusedControl.Parent, DevExpress.XtraGrid.GridControl).Select()
                CType(m_LastFocusedControl.Parent, DevExpress.XtraGrid.GridControl).MainView.ShowEditor()
            End If
            m_LastFocusedControl.Select()
        End If
    End Sub
    Protected Function FormCloseButtonClicked() As Boolean
        Dim f As Form = Me.FindForm()
        If Not f Is Nothing Then
            Dim pt As Point = Cursor.Position
            pt = f.PointToClient(pt)
            f.GetChildAtPoint(pt)
            Return pt.X < f.Width AndAlso pt.X >= f.Width - 40 AndAlso pt.Y < 0
        End If
        Return False
    End Function
    Private m_ShowDateTimeFormatAsNullText As Boolean = True
    <Browsable(True), Localizable(False), DefaultValue(True)> _
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
            RemoveHandler form.BackColorChanged, AddressOf Me.BaseForm_BackColorChanged
        Catch ex As Exception
        End Try
    End Sub
    Private m_AlwaysOpenInNewWindow As Boolean = False
    <Browsable(True), Localizable(False), DefaultValue(False)> _
    Public Property AlwaysOpenInNewWindow() As Boolean
        Get
            Return m_AlwaysOpenInNewWindow
        End Get
        Set(ByVal value As Boolean)
            m_AlwaysOpenInNewWindow = value
        End Set
    End Property

    Private m_SingleInstance As Boolean = False
    <Browsable(True), Localizable(False), DefaultValue(False)> _
    Public Property SingleInstance() As Boolean
        Get
            Return m_SingleInstance
        End Get
        Set(ByVal Value As Boolean)
            m_SingleInstance = Value
        End Set
    End Property
    Dim m_UseParentDataset As Boolean = False

    <Browsable(True), Localizable(False), DefaultValue(False)> _
    Public Property UseParentDataset() As Boolean
        Get
            Return m_UseParentDataset
        End Get
        Set(ByVal Value As Boolean)
            m_UseParentDataset = Value
        End Set
    End Property

    Private Shared m_EventLog As IEventLog
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shared Property EventLog() As IEventLog
        Get
            Return m_EventLog
        End Get
        Set(ByVal value As IEventLog)
            m_EventLog = value
        End Set
    End Property

    Private m_FormType As BaseFormType
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property FormType() As BaseFormType
        Get
            Return m_FormType
        End Get
        Set(ByVal value As BaseFormType)
            m_FormType = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overridable Function Activate() As System.Windows.Forms.Control Implements winclient.BasePanel.IApplicationForm.Activate
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

    Public ReadOnly Property AppCaption As String Implements winclient.BasePanel.IApplicationForm.Caption
        Get
            Return m_Caption
        End Get
    End Property

    <CLSCompliant(False)>
    Public Function Close(closeMode As FormClosingMode) As Boolean Implements winclient.BasePanel.IApplicationForm.Close
        If closeMode <> FormClosingMode.NoSave Then
            m_ClosingMode = BaseDetailForm.ClosingMode.Cancel
            If Not Post(PostType.FinalPosting) Then
                Return False
            End If
        End If
        DoClose()
        Return True
    End Function


    Public ReadOnly Property Key As Object Implements winclient.BasePanel.IApplicationForm.Key
        Get
            Return GetKey()
        End Get
    End Property

End Class

