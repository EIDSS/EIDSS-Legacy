Imports System.Collections.Generic
Imports System.Linq
Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports bv.winclient.Core
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.model.Core
Imports EIDSS.model.Enums
Imports EIDSS.model.Resources
Imports bv.common.Enums
Imports bv.winclient.Localization

Public Class SampleTransferDetail
    Inherits BaseDetailForm
    Private m_Transfered As Boolean = False
    Private ReadOnly m_TransferService As SamplesTransfer_DB

    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTransferID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPurpose As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtSent As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbTransferTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTransferFrom As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbSentBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnDeleteSample As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddSample As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTransferIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTransferOut As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReport As bv.winclient.Core.PopUpButton
    Friend WithEvents SamplesGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SamplesGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFieldID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLabID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCondition As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents editMemo As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents btnLocation As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colLabNewID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceivedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLaboratory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents btnBarcodes As bv.winclient.Core.PopUpButton
    Friend WithEvents cmPrintBarcodes As System.Windows.Forms.ContextMenu
    Friend WithEvents miBarcodesSampleID As System.Windows.Forms.MenuItem
    Friend WithEvents miBarcodesSampleTransferID As System.Windows.Forms.MenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbReceivedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbLocation As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbDateReceived As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleTransferDetail))
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTransferID = New DevExpress.XtraEditors.TextEdit()
        Me.txtPurpose = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.dtSent = New DevExpress.XtraEditors.DateEdit()
        Me.cbTransferTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbTransferFrom = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSentBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.SamplesGrid = New DevExpress.XtraGrid.GridControl()
        Me.SamplesGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLabID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFieldID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLabNewID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReceivedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDateReceived = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colReceivedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbReceivedBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colConditionReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCondition = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbLocation = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.editMemo = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colLaboratory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnLocation = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.btnDeleteSample = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddSample = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTransferIn = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTransferOut = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReport = New bv.winclient.Core.PopUpButton(Me.components)
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnBarcodes = New bv.winclient.Core.PopUpButton(Me.components)
        Me.cmPrintBarcodes = New System.Windows.Forms.ContextMenu()
        Me.miBarcodesSampleID = New System.Windows.Forms.MenuItem()
        Me.miBarcodesSampleTransferID = New System.Windows.Forms.MenuItem()
        CType(Me.txtTransferID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSent.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTransferTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTransferFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSentBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDateReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDateReceived.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReceivedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.editMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SampleTransferDetail), resources)
        'Form Is Localizable: True
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'LabelControl4
        '
        resources.ApplyResources(Me.LabelControl4, "LabelControl4")
        Me.LabelControl4.Name = "LabelControl4"
        '
        'LabelControl5
        '
        resources.ApplyResources(Me.LabelControl5, "LabelControl5")
        Me.LabelControl5.Name = "LabelControl5"
        '
        'LabelControl6
        '
        resources.ApplyResources(Me.LabelControl6, "LabelControl6")
        Me.LabelControl6.Name = "LabelControl6"
        '
        'LabelControl7
        '
        resources.ApplyResources(Me.LabelControl7, "LabelControl7")
        Me.LabelControl7.Name = "LabelControl7"
        '
        'txtTransferID
        '
        resources.ApplyResources(Me.txtTransferID, "txtTransferID")
        Me.txtTransferID.Name = "txtTransferID"
        Me.txtTransferID.Tag = "{M}[en]"
        '
        'txtPurpose
        '
        resources.ApplyResources(Me.txtPurpose, "txtPurpose")
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.UseOptimizedRendering = True
        '
        'LabelControl8
        '
        resources.ApplyResources(Me.LabelControl8, "LabelControl8")
        Me.LabelControl8.Name = "LabelControl8"
        '
        'dtSent
        '
        resources.ApplyResources(Me.dtSent, "dtSent")
        Me.dtSent.Name = "dtSent"
        Me.dtSent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtSent.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtSent.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtSent.Tag = "{R}"
        '
        'cbTransferTo
        '
        resources.ApplyResources(Me.cbTransferTo, "cbTransferTo")
        Me.cbTransferTo.Name = "cbTransferTo"
        Me.cbTransferTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTransferTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTransferTo.Properties.NullText = resources.GetString("cbTransferTo.Properties.NullText")
        Me.cbTransferTo.Tag = ""
        '
        'cbTransferFrom
        '
        resources.ApplyResources(Me.cbTransferFrom, "cbTransferFrom")
        Me.cbTransferFrom.Name = "cbTransferFrom"
        Me.cbTransferFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTransferFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTransferFrom.Properties.NullText = resources.GetString("cbTransferFrom.Properties.NullText")
        Me.cbTransferFrom.Tag = "{R}"
        '
        'cbSentBy
        '
        resources.ApplyResources(Me.cbSentBy, "cbSentBy")
        Me.cbSentBy.Name = "cbSentBy"
        Me.cbSentBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSentBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSentBy.Properties.NullText = resources.GetString("cbSentBy.Properties.NullText")
        Me.cbSentBy.Tag = "{R}"
        '
        'GroupControl1
        '
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Controls.Add(Me.txtTransferID)
        Me.GroupControl1.Controls.Add(Me.txtPurpose)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupControl2
        '
        resources.ApplyResources(Me.GroupControl2, "GroupControl2")
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.cbSentBy)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.cbTransferFrom)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.cbTransferTo)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.dtSent)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        '
        'GroupControl3
        '
        resources.ApplyResources(Me.GroupControl3, "GroupControl3")
        Me.GroupControl3.Controls.Add(Me.SamplesGrid)
        Me.GroupControl3.Controls.Add(Me.btnDeleteSample)
        Me.GroupControl3.Controls.Add(Me.btnAddSample)
        Me.GroupControl3.Controls.Add(Me.btnTransferIn)
        Me.GroupControl3.Controls.Add(Me.btnTransferOut)
        Me.GroupControl3.Name = "GroupControl3"
        '
        'SamplesGrid
        '
        resources.ApplyResources(Me.SamplesGrid, "SamplesGrid")
        Me.SamplesGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.SamplesGrid.MainView = Me.SamplesGridView
        Me.SamplesGrid.Name = "SamplesGrid"
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btnLocation, Me.cbCondition, Me.editMemo, Me.cbDepartment, Me.cbReceivedBy, Me.cbLocation, Me.cbDateReceived})
        Me.SamplesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SamplesGridView})
        '
        'SamplesGridView
        '
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLabID, Me.colSampleType, Me.colFieldID, Me.colLabNewID, Me.colReceivedDate, Me.colReceivedBy, Me.colConditionReceived, Me.colLocation, Me.colComment, Me.colLaboratory})
        Me.SamplesGridView.GridControl = Me.SamplesGrid
        Me.SamplesGridView.Name = "SamplesGridView"
        Me.SamplesGridView.OptionsCustomization.AllowFilter = False
        Me.SamplesGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.SamplesGridView.OptionsView.RowAutoHeight = True
        Me.SamplesGridView.OptionsView.ShowGroupPanel = False
        '
        'colLabID
        '
        resources.ApplyResources(Me.colLabID, "colLabID")
        Me.colLabID.FieldName = "strBarcode"
        Me.colLabID.Name = "colLabID"
        '
        'colSampleType
        '
        resources.ApplyResources(Me.colSampleType, "colSampleType")
        Me.colSampleType.FieldName = "strSampleName"
        Me.colSampleType.Name = "colSampleType"
        '
        'colFieldID
        '
        resources.ApplyResources(Me.colFieldID, "colFieldID")
        Me.colFieldID.FieldName = "strFieldBarcode"
        Me.colFieldID.Name = "colFieldID"
        '
        'colLabNewID
        '
        resources.ApplyResources(Me.colLabNewID, "colLabNewID")
        Me.colLabNewID.FieldName = "strBarcodeNew"
        Me.colLabNewID.Name = "colLabNewID"
        '
        'colReceivedDate
        '
        resources.ApplyResources(Me.colReceivedDate, "colReceivedDate")
        Me.colReceivedDate.ColumnEdit = Me.cbDateReceived
        Me.colReceivedDate.DisplayFormat.FormatString = "d"
        Me.colReceivedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colReceivedDate.FieldName = "datAccession"
        Me.colReceivedDate.Name = "colReceivedDate"
        '
        'cbDateReceived
        '
        Me.cbDateReceived.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        resources.ApplyResources(Me.cbDateReceived, "cbDateReceived")
        Me.cbDateReceived.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDateReceived.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDateReceived.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cbDateReceived.Name = "cbDateReceived"
        '
        'colReceivedBy
        '
        resources.ApplyResources(Me.colReceivedBy, "colReceivedBy")
        Me.colReceivedBy.ColumnEdit = Me.cbReceivedBy
        Me.colReceivedBy.FieldName = "idfAccesionByPerson"
        Me.colReceivedBy.Name = "colReceivedBy"
        Me.colReceivedBy.OptionsColumn.AllowEdit = False
        '
        'cbReceivedBy
        '
        resources.ApplyResources(Me.cbReceivedBy, "cbReceivedBy")
        Me.cbReceivedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReceivedBy.Name = "cbReceivedBy"
        '
        'colConditionReceived
        '
        resources.ApplyResources(Me.colConditionReceived, "colConditionReceived")
        Me.colConditionReceived.ColumnEdit = Me.cbCondition
        Me.colConditionReceived.FieldName = "idfsAccessionCondition"
        Me.colConditionReceived.Name = "colConditionReceived"
        '
        'cbCondition
        '
        Me.cbCondition.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCondition.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCondition.Name = "cbCondition"
        '
        'colLocation
        '
        resources.ApplyResources(Me.colLocation, "colLocation")
        Me.colLocation.ColumnEdit = Me.cbLocation
        Me.colLocation.FieldName = "idfSubdivision"
        Me.colLocation.Name = "colLocation"
        '
        'cbLocation
        '
        resources.ApplyResources(Me.cbLocation, "cbLocation")
        Me.cbLocation.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocation.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocation.Name = "cbLocation"
        '
        'colComment
        '
        resources.ApplyResources(Me.colComment, "colComment")
        Me.colComment.ColumnEdit = Me.editMemo
        Me.colComment.FieldName = "strCondition"
        Me.colComment.Name = "colComment"
        '
        'editMemo
        '
        Me.editMemo.MaxLength = 200
        Me.editMemo.Name = "editMemo"
        Me.editMemo.ShowIcon = False
        '
        'colLaboratory
        '
        resources.ApplyResources(Me.colLaboratory, "colLaboratory")
        Me.colLaboratory.ColumnEdit = Me.cbDepartment
        Me.colLaboratory.FieldName = "idfInDepartment"
        Me.colLaboratory.Name = "colLaboratory"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.DisplayMember = "Name"
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.ValueMember = "idfDepartment"
        '
        'btnLocation
        '
        resources.ApplyResources(Me.btnLocation, "btnLocation")
        Me.btnLocation.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnLocation.Name = "btnLocation"
        '
        'btnDeleteSample
        '
        resources.ApplyResources(Me.btnDeleteSample, "btnDeleteSample")
        Me.btnDeleteSample.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteSample.Name = "btnDeleteSample"
        '
        'btnAddSample
        '
        resources.ApplyResources(Me.btnAddSample, "btnAddSample")
        Me.btnAddSample.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnAddSample.Name = "btnAddSample"
        '
        'btnTransferIn
        '
        resources.ApplyResources(Me.btnTransferIn, "btnTransferIn")
        Me.btnTransferIn.Image = Global.EIDSS.My.Resources.Resources.Sample_Transfer_Out__small_
        Me.btnTransferIn.Name = "btnTransferIn"
        '
        'btnTransferOut
        '
        resources.ApplyResources(Me.btnTransferOut, "btnTransferOut")
        Me.btnTransferOut.Image = Global.EIDSS.My.Resources.Resources.Sample_Transfer_in__small_
        Me.btnTransferOut.Name = "btnTransferOut"
        '
        'btnReport
        '
        resources.ApplyResources(Me.btnReport, "btnReport")
        Me.btnReport.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.btnReport.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.btnReport.ImageIndex = 0
        Me.btnReport.Name = "btnReport"
        Me.btnReport.PopUpMenu = Me.cmReports
        Me.btnReport.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmReports
        '
        Me.cmReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'btnBarcodes
        '
        resources.ApplyResources(Me.btnBarcodes, "btnBarcodes")
        Me.btnBarcodes.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.PrintBarcodes
        Me.btnBarcodes.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.btnBarcodes.ImageIndex = 1
        Me.btnBarcodes.Name = "btnBarcodes"
        Me.btnBarcodes.PopUpMenu = Me.cmPrintBarcodes
        Me.btnBarcodes.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmPrintBarcodes
        '
        Me.cmPrintBarcodes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miBarcodesSampleID, Me.miBarcodesSampleTransferID})
        '
        'miBarcodesSampleID
        '
        Me.miBarcodesSampleID.Index = 0
        resources.ApplyResources(Me.miBarcodesSampleID, "miBarcodesSampleID")
        '
        'miBarcodesSampleTransferID
        '
        Me.miBarcodesSampleTransferID.Index = 1
        resources.ApplyResources(Me.miBarcodesSampleTransferID, "miBarcodesSampleTransferID")
        '
        'SampleTransferDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnBarcodes)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L10"
        Me.HelpTopicID = "lab_l10"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SampleTransferDetail"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.GroupControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupControl2, 0)
        Me.Controls.SetChildIndex(Me.GroupControl3, 0)
        Me.Controls.SetChildIndex(Me.btnBarcodes, 0)
        Me.Controls.SetChildIndex(Me.btnReport, 0)
        CType(Me.txtTransferID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSent.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTransferTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTransferFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSentBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDateReceived.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDateReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReceivedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.editMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()
        InitializeComponent()
        CType(SamplesGrid.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsSelection.MultiSelect = True

        m_TransferService = New SamplesTransfer_DB
        DbService = m_TransferService
        AuditObject = New AuditObject(EIDSSAuditObject.daoTransfer, AuditTable.tlbTransferOUT)
        PermissionObject = EIDSSPermissionObject.SampleTransfer
        btnBarcodes.Enabled = EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.Barcode))
        btnTransferIn.Enabled = EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer))
        btnTransferOut.Enabled = EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer))
        MenuItem1.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimSampleTransfer")
        
    End Sub

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindOrganizationLookup(cbTransferFrom, baseDataSet, Nothing, HACode.All, False)
        Core.LookupBinder.BindPersonRepositoryLookup(cbReceivedBy)
        Core.LookupBinder.BindOrganizationLookup(cbTransferTo, baseDataSet, Nothing, HACode.All)
        DxControlsHelper.HideButtonEditButton(cbTransferTo, ButtonPredefines.Delete)
        Core.LookupBinder.BindPersonLookup(cbSentBy, baseDataSet, "Transfer.idfSendByPerson", HACode.All)
        SamplesGrid.DataSource = baseDataSet.Tables("Containers")

        Core.LookupBinder.BindTextEdit(txtTransferID, baseDataSet, "Transfer.strBarcode")
        Core.LookupBinder.BindTextEdit(txtPurpose, baseDataSet, "Transfer.strNote")
        Core.LookupBinder.BindDateEdit(dtSent, baseDataSet, "Transfer.datSendDate")

        cbTransferFrom.EditValue = baseDataSet.Tables("Transfer").Rows(0)("idfSendFromOffice")
        Core.LookupBinder.AddBinding(cbTransferTo, baseDataSet, "Transfer.idfSendToOffice", False)

        Core.LookupBinder.BindBaseRepositoryLookup(cbCondition, db.BaseReferenceType.rftAccessionCondition, HACode.All, False)
        Core.LookupBinder.BindDepartmentRepositoryLookup(cbDepartment)
        LabUtils.BindFreezerLocation(cbLocation)

        If baseDataSet.Tables("Transfer").Rows(0)("idfsTransferStatus").ToString <> CType(TestStatus.NotStarted, Long).ToString() Then m_Transfered = True

        ReflectStatus()
    End Sub

    Private Sub btnAddSample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSample.Click
        Dim dlg As IBaseListPanel = CType(ClassLoader.LoadClass("SampleListPanel"), IBaseListPanel)
        Dim selected As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(dlg, FindForm, , 1024, 800)
        SamplesTransfer_DB.CopyObjects(baseDataSet.Tables("containers"), selected)
        ReflectStatus()
    End Sub

    Private Sub btnDeleteSample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteSample.Click
        If SamplesGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Exit Sub
        End If
        SamplesGridView.DeleteRow(SamplesGridView.FocusedRowHandle)
    End Sub

    Private Sub ReflectStatus()
        If [ReadOnly] OrElse Not EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer)) Then
            Return
        End If
        If m_Transfered Then
            btnTransferOut.Enabled = False
            Dim selectedRows As Integer() = SamplesGridView.GetSelectedRows()
            Dim canIn As Boolean
            If selectedRows Is Nothing Then
                canIn = False
            Else
                canIn = (From rowHandle In selectedRows Select SamplesGridView.GetDataRow(rowHandle)).All(Function(row) CanAccession(row))
            End If
            btnTransferIn.Enabled = canIn AndAlso (baseDataSet.Tables("Transfer").Rows(0)("idfSendToOffice").ToString = EidssSiteContext.Instance.OrganizationID.ToString)
            btnAddSample.Enabled = False
            btnDeleteSample.Enabled = False
            ApplyControlState(cbTransferTo, ControlState.ReadOnly)
            ApplyControlState(txtTransferID, ControlState.ReadOnly)
            ApplyControlState(txtPurpose, ControlState.ReadOnly)
            miBarcodesSampleTransferID.Visible = True
        Else
            btnTransferIn.Enabled = False
            btnTransferOut.Enabled = Not Utils.IsEmpty(cbTransferTo.EditValue) And SamplesGridView.RowCount > 0
            miBarcodesSampleTransferID.Visible = False
        End If
    End Sub

    Private Sub btnTransferOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTransferOut.Click
        Dim valid As Boolean
        Try
            If DbService.Connection.State <> ConnectionState.Open Then DbService.Connection.Open()
            Dim trans As IDbTransaction = DbService.Connection.BeginTransaction

            Using trans
                valid = DbService.PostDetail(baseDataSet.Copy, PostType.PerformAdditionalPosting, trans)
                trans.Rollback()
            End Using
        Catch ex As Exception
            Throw
        Finally
            If DbService.Connection.State = ConnectionState.Open Then DbService.Connection.Close()
        End Try

        If valid Then
            If ValidateData() = False Then Exit Sub
            baseDataSet.Tables("Transfer").Rows(0)("idfsTransferStatus") = TestStatus.InProcess
            m_Transfered = True
            baseDataSet.Tables("Transfer").Rows(0)("idfSendByPerson") = EidssUserContext.User.EmployeeID
            baseDataSet.Tables("Transfer").Rows(0)("datSendDate") = DateTime.Now
            baseDataSet.Tables("Transfer").Rows(0).EndEdit()
            ReflectStatus()
        Else
            Dim err As ErrorMessage = m_TransferService.LastError
            If err Is Nothing Then
                ErrorForm.ShowMessageDirect(m_TransferService.ErrorList)
            Else
                ErrorForm.ShowErrorDirect(err.Text, err.Exception)
            End If
        End If
    End Sub

    Private Sub btnTransferIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTransferIn.Click
        Dim row As DataRow
        Dim i As Integer

        For i = 0 To SamplesGridView.SelectedRowsCount - 1
            row = SamplesGridView.GetDataRow(SamplesGridView.GetSelectedRows(i))
            If IsAccessioned(row) Then Exit Sub
            row("strBarcodeNew") = NumberingService.GetNextNumber(NumberingObject.Sample, DbService.Connection, Nothing)
            row("datAccession") = DateTime.Today
            row("idfAccesionByPerson") = EidssUserContext.User.EmployeeID
            row("idfsAccessionCondition") = AccessionCondition.AcceptedGood
        Next

        btnBarcodes.Enabled = True
        ReflectStatus()
    End Sub

    Private Sub cbTransferTo_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbTransferTo.EditValueChanged
        ReflectStatus()
    End Sub

    Private Sub SamplesGridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles SamplesGridView.SelectionChanged
        ReflectStatus()
    End Sub

    Private Sub SamplesGridView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SamplesGridView.ShowingEditor
        If Closing Then Return
        e.Cancel = True
        Dim row As DataRow = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)
        Dim col As DevExpress.XtraGrid.Columns.GridColumn = SamplesGridView.FocusedColumn
        If row.RowState = DataRowState.Unchanged Then Exit Sub
        If IsAccessioned(row) Then
            If col Is colLocation _
                                    OrElse col Is colComment _
                                    OrElse col Is colConditionReceived _
                                    OrElse col Is colLabNewID _
                                    OrElse col Is colReceivedDate _
                                    OrElse col Is colLaboratory Then
                e.Cancel = False
            End If
        End If
    End Sub

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return DbService.ID
    End Function


    Private Sub miBarcodesSampleID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miBarcodesSampleID.Click
        ' Barcode printing  for sample transfer
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow
            Dim I As Integer

            Dim objects As List(Of Long) = New List(Of Long)
            Dim transferRow As DataRow = baseDataSet.Tables("Transfer").Rows(0)
            Dim transferSite As Object = transferRow("idfsSite")

            For I = 0 To SamplesGridView.SelectedRowsCount - 1

                row = SamplesGridView.GetDataRow(SamplesGridView.GetSelectedRows(I))
                If row Is Nothing Then Exit Sub
                Dim sampleId As Object
                If IsAccessioned(row) = False OrElse transferSite Is DBNull.Value OrElse EidssSiteContext.Instance.SiteID.Equals(transferSite) Then
                    sampleId = row("idfMaterial")
                Else
                    sampleId = row("idfMaterialForTransferIn")
                End If
                If Utils.IsEmpty(sampleId) Then Exit Sub

                objects.Add(CType(sampleId, Long))

            Next
            EidssSiteContext.BarcodeFactory.ShowPreview(CType(NumberingObject.Sample, Long), objects)
        End If


    End Sub

    Private Sub miBarcodesSampleTransferID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miBarcodesSampleTransferID.Click
        ' Barcode printing  for sample transfer
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow = baseDataSet.Tables("Transfer").Rows(0)
            If row Is Nothing Then Exit Sub
            Dim objectId As Object = row("idfTransferOut")
            If Utils.IsEmpty(objectId) Then
                Exit Sub
            End If
            EidssSiteContext.BarcodeFactory.ShowPreview(CLng(NumberingObject.SampleTransfer), CLng(objectId))
        End If
    End Sub

    Public Function ValidateSamplesData(ByVal showError As Boolean) As Boolean
        If m_Transfered Then
            Dim i As Integer
            For i = 0 To SamplesGridView.RowCount - 1
                If Not IsCurrentSpecimenRowValid(i, showError) Then
                    If showError Then
                        SamplesGridView.FocusedRowHandle = i
                        SamplesGrid.Select()
                    End If
                    Return False
                End If
            Next
        End If
        Return MyBase.ValidateData
    End Function

    Public Function IsCurrentSpecimenRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = SamplesGridView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = SamplesGridView.GetDataRow(index)
        If row Is Nothing Then Return True
        Dim condition As Object = row("idfsAccessionCondition")
        If CLng(AccessionCondition.AcceptedPoor).Equals(condition) OrElse CLng(AccessionCondition.Rejected).Equals(condition) Then
            If Utils.Str(row("strCondition")).Trim().Length = 0 Then
                SamplesGridView.FocusedColumn = colComment
                If showError Then
                    Dim msg As String = String.Format(EidssMessages.Get("ErrSampleConditionRequired", "Please enter a comment describing why the {0} is identified as ""{1}"""), colConditionReceived.Caption, SamplesGridView.GetRowCellDisplayText(index, colConditionReceived))
                    ErrorForm.ShowWarningDirect(msg)
                End If
                Return False
            End If
        End If
        If IsJustAccessioned(row) AndAlso Utils.IsEmpty(row("strBarcodeNew")) Then
            SamplesGridView.FocusedColumn = colLabNewID
            If showError Then
                WinUtils.ShowMandatoryError(colLabNewID.Caption)
            End If
            Return False
        End If
        Return True
    End Function

    Public Overrides Function ValidateData() As Boolean
        Return ValidateSamplesData(True)
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        Dim res As Boolean = MyBase.Post(postType)
        If res = False AndAlso Not m_TransferService.ErrorList Is Nothing AndAlso m_TransferService.ErrorList.Length > 0 Then
            ErrorForm.ShowMessageDirect(m_TransferService.ErrorList)
        End If
        Return res
    End Function

    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimSampleTransfer(CType(DbService.ID, Long))
        End If
    End Sub

    Private Function IsAccessioned(row As DataRow) As Boolean
        Return Not row Is Nothing AndAlso Not Utils.IsEmpty(row("idfMaterialForTransferIn")) AndAlso (True.Equals(row("blnAccessioned")) OrElse Not Utils.IsEmpty(row("datAccession")))
    End Function

    Private Function CanAccession(row As DataRow) As Boolean
        Return Not row Is Nothing AndAlso Not Utils.IsEmpty(row("idfMaterialForTransferIn")) AndAlso Not True.Equals(row("blnAccessioned")) AndAlso Utils.IsEmpty(row("datAccession"))
    End Function
    'Row is accessioned by pressing Transfer In button and form was not saved yes
    Private Function IsJustAccessioned(row As DataRow) As Boolean
        Return Not row Is Nothing AndAlso Not Utils.IsEmpty(row("idfMaterialForTransferIn")) AndAlso Not True.Equals(row("blnAccessioned")) AndAlso Not Utils.IsEmpty(row("datAccession"))
    End Function

End Class
