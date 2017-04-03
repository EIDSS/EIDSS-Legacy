Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports DevExpress.XtraTreeList.Nodes
Imports EIDSS.model.Enums

Public Class RepositorySchemeDetail
    Inherits BaseDetailForm

    Dim RepositorySchemeDbService As RepositoryScheme_DB
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCapacity As DevExpress.XtraEditors.SpinEdit
    Dim CanPrint As Boolean = True
    Dim CanEdit As Boolean = True

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        pnlFreezer.Dock = DockStyle.Fill
        pnlSubdivision.Dock = DockStyle.Fill
        'Add any initialization after the InitializeComponent() call
        RepositorySchemeDbService = New RepositoryScheme_DB

        DbService = RepositorySchemeDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoRepositoryScheme, AuditTable.tlbFreezer)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.RepositoryScheme

        'menuAction.MenuAccessRights = new EIDSS_AccessRights(new EIDSS.UserFunctions[] {UserFunctions.CanViewPlacementTree});
        'Me.btnLocation.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.PlacementTree))
        SetMandatoryFieldVisible(txtSubdivisionName, False)
        SetMandatoryFieldVisible(cbSubdivisionType, False)
        CanPrint = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSS.model.Enums.EIDSSPermissionObject.Barcode))
        CanEdit = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSS.model.Enums.EIDSSPermissionObject.RepositoryScheme)) OrElse _
        (Me.State And BusinessObjectState.NewObject) <> 0
        'btnCopy.Enabled = CanEdit
        'btnDelete.Enabled = btnCopy.Enabled = CanEdit
        'btnNew.Enabled = CanEdit
        Me.m_RelatedLists = New String() {"RepositorySchemeListItem"}
    End Sub

    'Form overrides dispose to clean up the component list.

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
    Friend WithEvents lblFreezerName As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtFreezerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents meNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents tvFreezerStruct As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlFreezer As System.Windows.Forms.Panel
    Friend WithEvents pnlSubdivision As System.Windows.Forms.Panel
    Friend WithEvents lblSubdivisionName As System.Windows.Forms.Label
    Friend WithEvents lblSubdivisionType As System.Windows.Forms.Label
    Friend WithEvents lblSubdivisionNote As System.Windows.Forms.Label
    Friend WithEvents txtSubdivisionName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbSubdivisionType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meSubdivisionNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSubdivisionBarCode As System.Windows.Forms.Label
    Friend WithEvents txtSubdivisionBarCode As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblFreezerBarcode As System.Windows.Forms.Label
    Friend WithEvents txtFreezerBarcode As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cbStorageType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RepositorySchemeDetail))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvFreezerStruct = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.pnlFreezer = New System.Windows.Forms.Panel()
        Me.cbStorageType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFreezerBarcode = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtFreezerName = New DevExpress.XtraEditors.TextEdit()
        Me.meNote = New DevExpress.XtraEditors.MemoEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFreezerBarcode = New System.Windows.Forms.Label()
        Me.lblFreezerName = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlSubdivision = New System.Windows.Forms.Panel()
        Me.txtCapacity = New DevExpress.XtraEditors.SpinEdit()
        Me.txtSubdivisionName = New DevExpress.XtraEditors.TextEdit()
        Me.cbSubdivisionType = New DevExpress.XtraEditors.LookUpEdit()
        Me.meSubdivisionNote = New DevExpress.XtraEditors.MemoEdit()
        Me.txtSubdivisionBarCode = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSubdivisionName = New System.Windows.Forms.Label()
        Me.lblSubdivisionType = New System.Windows.Forms.Label()
        Me.lblSubdivisionNote = New System.Windows.Forms.Label()
        Me.lblSubdivisionBarCode = New System.Windows.Forms.Label()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tvFreezerStruct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFreezer.SuspendLayout()
        CType(Me.cbStorageType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFreezerBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFreezerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSubdivision.SuspendLayout()
        CType(Me.txtCapacity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubdivisionName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSubdivisionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meSubdivisionNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubdivisionBarCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(RepositorySchemeDetail), resources)
        'Form Is Localizable: True
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvFreezerStruct)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlFreezer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlSubdivision)
        '
        'tvFreezerStruct
        '
        Me.tvFreezerStruct.Appearance.Empty.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.EvenRow.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.FixedLine.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.FocusedCell.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.FocusedRow.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.FooterPanel.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.GroupButton.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.GroupFooter.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.HeaderPanel.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.HideSelectionRow.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.HorzLine.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.OddRow.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.Preview.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.Row.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.SelectedRow.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.TreeLine.Options.UseFont = True
        Me.tvFreezerStruct.Appearance.VertLine.Options.UseFont = True
        Me.tvFreezerStruct.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1})
        resources.ApplyResources(Me.tvFreezerStruct, "tvFreezerStruct")
        Me.tvFreezerStruct.Name = "tvFreezerStruct"
        Me.tvFreezerStruct.OptionsBehavior.Editable = False
        Me.tvFreezerStruct.OptionsView.ShowColumns = False
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.FieldName = "TreeListColumn1"
        Me.TreeListColumn1.Name = "TreeListColumn1"
        resources.ApplyResources(Me.TreeListColumn1, "TreeListColumn1")
        '
        'pnlFreezer
        '
        Me.pnlFreezer.Controls.Add(Me.cbStorageType)
        Me.pnlFreezer.Controls.Add(Me.txtFreezerBarcode)
        Me.pnlFreezer.Controls.Add(Me.txtFreezerName)
        Me.pnlFreezer.Controls.Add(Me.meNote)
        Me.pnlFreezer.Controls.Add(Me.Label1)
        Me.pnlFreezer.Controls.Add(Me.lblFreezerBarcode)
        Me.pnlFreezer.Controls.Add(Me.lblFreezerName)
        Me.pnlFreezer.Controls.Add(Me.lblNote)
        resources.ApplyResources(Me.pnlFreezer, "pnlFreezer")
        Me.pnlFreezer.Name = "pnlFreezer"
        '
        'cbStorageType
        '
        resources.ApplyResources(Me.cbStorageType, "cbStorageType")
        Me.cbStorageType.Name = "cbStorageType"
        Me.cbStorageType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStorageType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStorageType.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbStorageType.Properties.Buttons2"), CType(resources.GetObject("cbStorageType.Properties.Buttons3"), Integer), CType(resources.GetObject("cbStorageType.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbStorageType.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbStorageType.Properties.Buttons6"), Boolean), CType(resources.GetObject("cbStorageType.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbStorageType.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbStorageType.Properties.Buttons9"), CType(resources.GetObject("cbStorageType.Properties.Buttons10"), Object), CType(resources.GetObject("cbStorageType.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbStorageType.Properties.Buttons12"), Boolean))})
        Me.cbStorageType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbStorageType.Properties.Columns"), resources.GetString("cbStorageType.Properties.Columns1"))})
        Me.cbStorageType.Properties.NullText = resources.GetString("cbStorageType.Properties.NullText")
        Me.cbStorageType.Tag = "{M}"
        '
        'txtFreezerBarcode
        '
        resources.ApplyResources(Me.txtFreezerBarcode, "txtFreezerBarcode")
        Me.txtFreezerBarcode.Name = "txtFreezerBarcode"
        Me.txtFreezerBarcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFreezerBarcode.Properties.Buttons1"), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons2"), Integer), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtFreezerBarcode.Properties.Buttons8"), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons9"), Object), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFreezerBarcode.Properties.Buttons11"), Boolean))})
        Me.txtFreezerBarcode.Properties.MaxLength = 20
        Me.txtFreezerBarcode.Tag = "[en]"
        '
        'txtFreezerName
        '
        resources.ApplyResources(Me.txtFreezerName, "txtFreezerName")
        Me.txtFreezerName.Name = "txtFreezerName"
        Me.txtFreezerName.Properties.MaxLength = 200
        Me.txtFreezerName.Tag = "{M}"
        '
        'meNote
        '
        resources.ApplyResources(Me.meNote, "meNote")
        Me.meNote.Name = "meNote"
        Me.meNote.Properties.MaxLength = 200
        Me.meNote.UseOptimizedRendering = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblFreezerBarcode
        '
        resources.ApplyResources(Me.lblFreezerBarcode, "lblFreezerBarcode")
        Me.lblFreezerBarcode.Name = "lblFreezerBarcode"
        '
        'lblFreezerName
        '
        resources.ApplyResources(Me.lblFreezerName, "lblFreezerName")
        Me.lblFreezerName.Name = "lblFreezerName"
        '
        'lblNote
        '
        resources.ApplyResources(Me.lblNote, "lblNote")
        Me.lblNote.Name = "lblNote"
        '
        'pnlSubdivision
        '
        Me.pnlSubdivision.Controls.Add(Me.txtCapacity)
        Me.pnlSubdivision.Controls.Add(Me.txtSubdivisionName)
        Me.pnlSubdivision.Controls.Add(Me.cbSubdivisionType)
        Me.pnlSubdivision.Controls.Add(Me.meSubdivisionNote)
        Me.pnlSubdivision.Controls.Add(Me.txtSubdivisionBarCode)
        Me.pnlSubdivision.Controls.Add(Me.Label2)
        Me.pnlSubdivision.Controls.Add(Me.lblSubdivisionName)
        Me.pnlSubdivision.Controls.Add(Me.lblSubdivisionType)
        Me.pnlSubdivision.Controls.Add(Me.lblSubdivisionNote)
        Me.pnlSubdivision.Controls.Add(Me.lblSubdivisionBarCode)
        resources.ApplyResources(Me.pnlSubdivision, "pnlSubdivision")
        Me.pnlSubdivision.Name = "pnlSubdivision"
        '
        'txtCapacity
        '
        resources.ApplyResources(Me.txtCapacity, "txtCapacity")
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCapacity.Properties.IsFloatValue = False
        Me.txtCapacity.Properties.Mask.EditMask = resources.GetString("txtCapacity.Properties.Mask.EditMask")
        Me.txtCapacity.Properties.MaxValue = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'txtSubdivisionName
        '
        resources.ApplyResources(Me.txtSubdivisionName, "txtSubdivisionName")
        Me.txtSubdivisionName.Name = "txtSubdivisionName"
        Me.txtSubdivisionName.Properties.MaxLength = 50
        Me.txtSubdivisionName.Tag = "{M}"
        '
        'cbSubdivisionType
        '
        resources.ApplyResources(Me.cbSubdivisionType, "cbSubdivisionType")
        Me.cbSubdivisionType.Name = "cbSubdivisionType"
        Me.cbSubdivisionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSubdivisionType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSubdivisionType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSubdivisionType.Properties.Columns"), resources.GetString("cbSubdivisionType.Properties.Columns1"))})
        Me.cbSubdivisionType.Properties.NullText = resources.GetString("cbSubdivisionType.Properties.NullText")
        Me.cbSubdivisionType.Tag = "{M}"
        '
        'meSubdivisionNote
        '
        resources.ApplyResources(Me.meSubdivisionNote, "meSubdivisionNote")
        Me.meSubdivisionNote.Name = "meSubdivisionNote"
        Me.meSubdivisionNote.Properties.MaxLength = 200
        Me.meSubdivisionNote.UseOptimizedRendering = True
        '
        'txtSubdivisionBarCode
        '
        resources.ApplyResources(Me.txtSubdivisionBarCode, "txtSubdivisionBarCode")
        Me.txtSubdivisionBarCode.Name = "txtSubdivisionBarCode"
        Me.txtSubdivisionBarCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtSubdivisionBarCode.Properties.Buttons1"), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons2"), Integer), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("txtSubdivisionBarCode.Properties.Buttons8"), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons9"), Object), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtSubdivisionBarCode.Properties.Buttons11"), Boolean))})
        Me.txtSubdivisionBarCode.Properties.MaxLength = 20
        Me.txtSubdivisionBarCode.Tag = "[en]"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'lblSubdivisionName
        '
        resources.ApplyResources(Me.lblSubdivisionName, "lblSubdivisionName")
        Me.lblSubdivisionName.Name = "lblSubdivisionName"
        '
        'lblSubdivisionType
        '
        resources.ApplyResources(Me.lblSubdivisionType, "lblSubdivisionType")
        Me.lblSubdivisionType.Name = "lblSubdivisionType"
        '
        'lblSubdivisionNote
        '
        resources.ApplyResources(Me.lblSubdivisionNote, "lblSubdivisionNote")
        Me.lblSubdivisionNote.Name = "lblSubdivisionNote"
        '
        'lblSubdivisionBarCode
        '
        resources.ApplyResources(Me.lblSubdivisionBarCode, "lblSubdivisionBarCode")
        Me.lblSubdivisionBarCode.Name = "lblSubdivisionBarCode"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnNew.Name = "btnNew"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Image = Global.EIDSS.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.ContextMenu1
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'RepositorySchemeDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnCopy)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L12"
        Me.HelpTopicID = "lab_l12"
        Me.KeyFieldName = "idfFreezer"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.MinimumSize = New System.Drawing.Size(738, 440)
        Me.Name = "RepositorySchemeDetail"
        Me.ObjectName = "tlbFreezer"
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Freezer"
        Me.Controls.SetChildIndex(Me.btnCopy, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tvFreezerStruct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFreezer.ResumeLayout(False)
        CType(Me.cbStorageType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFreezerBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFreezerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSubdivision.ResumeLayout(False)
        CType(Me.txtCapacity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubdivisionName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSubdivisionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meSubdivisionNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubdivisionBarCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region




    Protected Overrides Sub DefineBinding()
        Try
            Core.LookupBinder.BindBaseLookup(cbSubdivisionType, baseDataSet, RepositoryScheme_DB.TableSubdivision + ".idfsSubdivisionType", db.BaseReferenceType.rftSubdivisionType)
            txtCapacity.DataBindings.Add("EditValue", baseDataSet, RepositoryScheme_DB.TableSubdivision + ".intCapacity")

            Core.LookupBinder.BindTextEdit(txtFreezerName, baseDataSet, RepositoryScheme_DB.TableFreezer + ".strFreezerName")
            Core.LookupBinder.BindTextEdit(meNote, baseDataSet, RepositoryScheme_DB.TableFreezer + ".strNote")
            Core.LookupBinder.BindBaseLookup(cbStorageType, baseDataSet, RepositoryScheme_DB.TableFreezer + ".idfsStorageType", db.BaseReferenceType.rftStorageType)

            Core.LookupBinder.BindTextEdit(txtFreezerBarcode, baseDataSet, RepositoryScheme_DB.TableFreezer + ".strBarcode")
            AddPrintButton(txtFreezerBarcode)

            Core.LookupBinder.BindTextEdit(txtSubdivisionName, baseDataSet, RepositoryScheme_DB.TableSubdivision + ".strNameChars")
            Core.LookupBinder.BindTextEdit(meSubdivisionNote, baseDataSet, RepositoryScheme_DB.TableSubdivision + ".strNote")

            Core.LookupBinder.BindTextEdit(txtSubdivisionBarCode, baseDataSet, RepositoryScheme_DB.TableSubdivision + ".strBarcode")
            AddPrintButton(txtSubdivisionBarCode)

            Dim TempTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tvFreezerStruct.AppendNode(Nothing, 0)
            TempTreeListNode.Tag = baseDataSet.Tables(RepositoryScheme_DB.TableFreezer).Rows(0)
            TempTreeListNode.SetValue(0, baseDataSet.Tables(RepositoryScheme_DB.TableFreezer).Rows(0)("strFreezerName").ToString())

            PopulateTreeList(Nothing)

            TempTreeListNode.Expanded = True
            'Event processing template
            eventManager.AttachDataHandler(RepositoryScheme_DB.TableSubdivision + ".strNameChars", AddressOf SubdivName_Changed)
            eventManager.AttachDataHandler(RepositoryScheme_DB.TableFreezer + ".strFreezerName", AddressOf FreezerName_Changed)
            CanEdit = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSS.model.Enums.EIDSSPermissionObject.RepositoryScheme)) OrElse _
            (Me.State And BusinessObjectState.NewObject) <> 0
            btnCopy.Enabled = False 'Freeser can't be copied
            btnDelete.Enabled = False 'Freeser can't be deleted
            btnNew.Enabled = CanEdit

        Catch e As Exception
            MessageForm.Show(e.Message)
        End Try

    End Sub

    Protected Sub PopulateTreeList(ByVal ParentNode As DevExpress.XtraTreeList.Nodes.TreeListNode)
        Dim DivisionView As DataView = New DataView(baseDataSet.Tables(RepositoryScheme_DB.TableSubdivision))
        Dim TempTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode

        If ParentNode Is Nothing Then
            If tvFreezerStruct.Nodes.Count <> 0 Then
                ParentNode = tvFreezerStruct.Nodes(0)
            End If
            DivisionView.RowFilter = "idfParentSubdivision is null"
        Else
            DivisionView.RowFilter = "idfParentSubdivision = '" + _
                GetRowObjectFromNodeData(ParentNode.Tag)("idfSubdivision").ToString() + "'"
        End If
        Dim TempDataViewRow As DataRowView
        For Each TempDataViewRow In DivisionView
            TempTreeListNode = tvFreezerStruct.AppendNode(Nothing, ParentNode)
            TempTreeListNode.Tag = TempDataViewRow.Row
            TempTreeListNode.SetValue(0, TempDataViewRow.Row("strNameChars").ToString())
            PopulateTreeList(TempTreeListNode)
        Next
    End Sub

    Protected Function GetRowObjectFromNodeData(ByVal NodeData As Object) As DataRow
        Return (CType(NodeData, DataRow))
    End Function

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        If Not (MyBase.ValidateData()) Then Return

        If Not tvFreezerStruct.FocusedNode Is Nothing Then
            Dim tempDivRow As DataRow = baseDataSet.Tables(RepositoryScheme_DB.TableSubdivision).NewRow()
            Dim parentDRow As DataRow

            tempDivRow("idfSubdivision") = BaseDbService.NewIntID()
            tempDivRow("idfFreezer") = GetKey()
            baseDataSet.Tables(RepositoryScheme_DB.TableSubdivision).Rows.Add(tempDivRow)

            tempDivRow.SetParentRow(baseDataSet.Tables(RepositoryScheme_DB.TableFreezer).Rows(0), baseDataSet.Relations(RepositoryScheme_DB.TableSubdivision))
            If GetRowObjectFromNodeData(tvFreezerStruct.FocusedNode.Tag).Table.TableName = RepositoryScheme_DB.TableSubdivision Then
                parentDRow = GetRowObjectFromNodeData(tvFreezerStruct.FocusedNode.Tag)
                tempDivRow.SetParentRow(parentDRow, baseDataSet.Relations("SubdivisionTree"))
            Else
                parentDRow = baseDataSet.Tables(RepositoryScheme_DB.TableFreezer).Rows(0)
            End If

            Dim tempTreeListNode As TreeListNode = tvFreezerStruct.AppendNode(Nothing, tvFreezerStruct.FocusedNode)
            tempTreeListNode.Tag = tempDivRow
            tempTreeListNode.SetValue(0, "")
            tvFreezerStruct.FocusedNode = tempTreeListNode
        End If
    End Sub

    Private Function CheckSubdivision(ByRef Node As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal capacity As Object) As String
        Dim row As DataRow = CType(Node.Tag, DataRow)
        Dim cmd As IDbCommand = Nothing
        Try
            If DbService.Connection.State <> ConnectionState.Open Then DbService.Connection.Open()
            Dim trans As IDbTransaction = DbService.Connection.BeginTransaction()
            cmd = BaseDbService.CreateSPCommand("spFreezerSubdivision_Validate", DbService.Connection, trans)
            BaseDbService.AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
            BaseDbService.AddParam(cmd, "@intCapacity", capacity, ParameterDirection.InputOutput)
            BaseDbService.AddParam(cmd, "@intStored", capacity, ParameterDirection.InputOutput)
            cmd.ExecuteNonQuery()
            trans.Rollback()
        Catch ex As System.Data.SqlClient.SqlException
            If ex.Number = 50000 And ex.Class = 16 AndAlso Not cmd Is Nothing Then
                If (ex.Message = "msgCanNotDecreaseLocationVial") Then
                    Return String.Format(EidssMessages.Get(ex.Message), BaseDbService.GetParamValue(cmd, "@intStored"), capacity)
                End If
                Return EidssMessages.Get(ex.Message)
            End If
            Return ex.Message
        Finally
            DbService.Connection.Close()
        End Try
        Return Nothing
    End Function

    Private Sub DeleteSubdivision(ByRef node As DevExpress.XtraTreeList.Nodes.TreeListNode)
        CType(node.Tag, DataRow).Delete()
        node.ParentNode.Nodes.Remove(node)
        For Each child As DevExpress.XtraTreeList.Nodes.TreeListNode In node.Nodes
            DeleteSubdivision(child)
        Next
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim focused As DevExpress.XtraTreeList.Nodes.TreeListNode = tvFreezerStruct.FocusedNode
        If Not focused Is Nothing Then
            If Not CanDelete(tvFreezerStruct.FocusedNode) Then
                ErrorForm.ShowWarningDirect(EidssMessages.Get("msgCanNotDeleteSubDivVial"))
                Exit Sub
            End If

            Try
                Me.DeleteAction = True
                Dim parent As DevExpress.XtraTreeList.Nodes.TreeListNode = focused.ParentNode
                tvFreezerStruct.FocusedNode = parent
                DeleteSubdivision(focused)

            Finally
                Me.DeleteAction = False
            End Try

        End If
    End Sub

    Private Sub txtFreezerBarcode_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFreezerBarcode.ButtonClick

        If Post(bv.common.Enums.PostType.FinalPosting) Then
            Dim typeId As Long = CType(NumberingObject.FreezerBarcode, Long)
            Dim objectId As Long = CType(GetKey(), Long)
            EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)
        End If


    End Sub

    Private Sub txtSubdivisionBarCode_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtSubdivisionBarCode.ButtonClick


        If Post(bv.common.Enums.PostType.FinalPosting) Then

            If Not tvFreezerStruct.FocusedNode Is Nothing Then
                Dim focusedRow As DataRow = GetRowObjectFromNodeData(tvFreezerStruct.FocusedNode.Tag)
                Dim objectId As Long = CType(focusedRow("idfSubdivision"), Long)
                Dim typeId As Long = CType(NumberingObject.FreezerBarcode, Long)
                EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)
            End If

        End If

    End Sub

    Protected Overridable Function CanDelete(ByVal Node As DevExpress.XtraTreeList.Nodes.TreeListNode) As Boolean
        If Not CheckSubdivision(Node, 0) Is Nothing Then Return False
        Dim valid As Boolean = True
        For Each child As DevExpress.XtraTreeList.Nodes.TreeListNode In Node.Nodes
            valid = valid And Not CheckSubdivision(child, 0) Is Nothing
            If valid = False Then Return False
        Next
        Return True
    End Function

    Private DeleteAction As Boolean = False
    Private Sub tvFreezerStruct_BeforeFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.BeforeFocusNodeEventArgs) Handles tvFreezerStruct.BeforeFocusNode
        If DeleteAction = False Then
            e.CanFocus = ValidateData()
        End If
    End Sub

    Private Sub tvFreezerStruct_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tvFreezerStruct.AfterFocusNode

        If GetRowObjectFromNodeData(e.Node.Tag).Table.TableName = RepositoryScheme_DB.TableSubdivision Then
            pnlFreezer.Visible = False
            SetMandatoryFieldVisible(txtFreezerName, False)
            SetMandatoryFieldVisible(cbStorageType, False)
            pnlSubdivision.Visible = True
            SetMandatoryFieldVisible(txtSubdivisionName, True)
            SetMandatoryFieldVisible(cbSubdivisionType, True)
            btnDelete.Enabled = CanEdit
            btnCopy.Enabled = CanEdit
            Dim TempDRow As DataRow = GetRowObjectFromNodeData(e.Node.Tag)
            Me.BindingContext.Item(baseDataSet, RepositoryScheme_DB.TableSubdivision).Position = LocateSubdivRow(TempDRow)
            Dim LocCount, VialCount As Integer
            GetLocationNumber(TempDRow, LocCount, VialCount)
        Else
            pnlFreezer.Visible = True
            SetMandatoryFieldVisible(txtFreezerName, True)
            SetMandatoryFieldVisible(cbStorageType, True)
            pnlSubdivision.Visible = False
            SetMandatoryFieldVisible(txtSubdivisionName, False)
            SetMandatoryFieldVisible(cbSubdivisionType, False)
            btnDelete.Enabled = False
            btnCopy.Enabled = False
        End If
        If e.Node.Level >= 6 Then
            btnNew.Enabled = False
        Else
            btnNew.Enabled = CanEdit
        End If
    End Sub

    Private Sub SubdivName_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim TempdRow As DataRow = e.Row
        If TempdRow.Table.TableName = RepositoryScheme_DB.TableSubdivision Then
            Dim nd As DevExpress.XtraTreeList.Nodes.TreeListNode = LocateNodeByRow(TempdRow, Nothing)
            If Not nd Is Nothing Then
                nd.SetValue(0, TempdRow("strNameChars").ToString())
            End If
        End If
    End Sub

    Private Sub FreezerName_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim TempdRow As DataRow = e.Row
        If TempdRow.Table.TableName = RepositoryScheme_DB.TableFreezer Then
            tvFreezerStruct.Nodes(0).SetValue(0, TempdRow("strFreezerName").ToString())
        End If
    End Sub

    Protected Function LocateSubdivRow(ByVal DRow As DataRow) As Integer
        Dim TempDV As DataView = baseDataSet.Tables(RepositoryScheme_DB.TableSubdivision).DefaultView
        Dim i As Integer
        For i = 0 To TempDV.Count - 1
            If TempDV(i).Row.Equals(DRow) Then
                Return (i)
            End If
        Next
    End Function


    Protected Sub GetLocationNumber(ByVal DRow As DataRow, ByRef LocationNumber As Integer, ByRef VialNumber As Integer)
        Dim TempDRow As DataRow
        VialNumber = 0
        LocationNumber = 0
        For Each TempDRow In DRow.GetChildRows("SubdivisionLocation")
            If Not TempDRow.IsNull("idfMaterial") Then
                VialNumber += 1
            End If
            LocationNumber += 1
        Next
    End Sub


    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If tvFreezerStruct.FocusedNode Is Nothing Then Exit Sub
        If Me.ValidateData() = False Then Exit Sub
        Dim ClonedDRow, CloneDRow As DataRow
        ClonedDRow = GetRowObjectFromNodeData(tvFreezerStruct.FocusedNode.Tag)
        CloneDRow = RepositoryScheme_DB.CopySubdivsionRow(ClonedDRow)
        If Not ClonedDRow.GetParentRow("SubdivisionTree") Is Nothing Then
            CloneDRow.SetParentRow(ClonedDRow.GetParentRow("SubdivisionTree"), baseDataSet.Relations("SubdivisionTree"))
        End If
        Dim TempTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode
        TempTreeListNode = tvFreezerStruct.AppendNode(Nothing, tvFreezerStruct.FocusedNode.ParentNode)
        TempTreeListNode.Tag = CloneDRow
        TempTreeListNode.SetValue(0, CloneDRow("strNameChars").ToString())
        PopulateTreeList(TempTreeListNode)
    End Sub


    Protected Function LocateNodeByRow(ByVal DRow As DataRow, ByVal ND As DevExpress.XtraTreeList.Nodes.TreeListNode) As DevExpress.XtraTreeList.Nodes.TreeListNode
        Dim RetRes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        Dim NDColl As DevExpress.XtraTreeList.Nodes.TreeListNodes
        If ND Is Nothing Then
            NDColl = tvFreezerStruct.Nodes
        Else
            NDColl = ND.Nodes
        End If
        For Each RetRes In NDColl
            If GetRowObjectFromNodeData(RetRes.Tag) Is DRow Then Return (RetRes)
            RetRes = LocateNodeByRow(DRow, RetRes)
            If Not RetRes Is Nothing Then Return (RetRes)
        Next
        Return (Nothing)
    End Function


#Region "Reports"
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        Dim dr As DataRow
        If Post(bv.common.Enums.PostType.IntermediatePosting) Then
            dr = CType(tvFreezerStruct.Selection(0).Tag, DataRow)

            If tvFreezerStruct.Selection(0).ParentNode Is Nothing Then
                Dim freeserId As Long = CType(dr.Item("idfFreezer"), Long)
                EidssSiteContext.ReportFactory.LimContainerContent(Nothing, freeserId)
            Else
                Dim subdivisionId As Long = CType(dr.Item("idfSubdivision"), Long)
                EidssSiteContext.ReportFactory.LimContainerContent(subdivisionId, Nothing)
            End If

        End If

    End Sub
#End Region



    Private Sub AddPrintButton(ByRef cb As DevExpress.XtraEditors.ButtonEdit)

        Dim print As DevExpress.XtraEditors.Controls.EditorButton = cb.Properties.Buttons(0)
        print.Enabled = CanPrint

    End Sub

    Private Sub txtCapacity_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtCapacity.EditValueChanging
        Dim errMsg As String = CheckSubdivision(Me.tvFreezerStruct.FocusedNode, e.NewValue)
        e.Cancel = Not errMsg Is Nothing
        If e.Cancel Then
            ErrorForm.ShowWarningDirect(errMsg)
        End If

    End Sub
    Public Overrides Function ValidateData() As Boolean
        If MyBase.ValidateData() = False Then
            Return False
        End If
        Try
            Dim freezerRow As DataRow = baseDataSet.Tables(RepositoryScheme_DB.TableFreezer).Rows(0)
            If RepositorySchemeDbService.ValidateFreezerName(CLng(freezerRow("idfFreezer")), Utils.Str(freezerRow("strFreezerName"))) = False Then
                ErrorForm.ShowWarning("errDuplicateFreezerName", "Freezer with such name exists already. Please enter other freezer name.")
                txtFreezerName.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            ErrorForm.ShowError(bv.common.Enums.StandardError.UnprocessedError, ex)
            Return False
        End Try
    End Function
End Class