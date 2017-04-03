Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports System.Collections.Generic
Imports eidss.model.Core
Imports EIDSS.model.Enums

Public Class SampleTransferDetail
    Inherits bv.common.win.BaseDetailForm
    Protected Transfered As Boolean = False
    Protected TransferService As SamplesTransfer_DB

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
    Friend WithEvents btnReport As bv.common.win.PopUpButton
    Friend WithEvents SamplesGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SamplesGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFieldID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLabID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCondition As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents btnBarcodes As bv.common.win.BarcodeButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbReceivedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbLocation As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbDateReceived As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
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
        Me.colCondition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.editMemo = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbLocation = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLaboratory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnLocation = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.btnDeleteSample = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddSample = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTransferIn = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTransferOut = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReport = New bv.common.win.PopUpButton()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnBarcodes = New bv.common.win.BarcodeButton()
        CType(Me.txtTransferID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSent.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.cbDateReceived.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReceivedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.editMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dtSent.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
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
        Me.SamplesGrid.MainView = Me.SamplesGridView
        Me.SamplesGrid.Name = "SamplesGrid"
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btnLocation, Me.editMemo, Me.cbDepartment, Me.cbReceivedBy, Me.cbLocation, Me.cbDateReceived})
        Me.SamplesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SamplesGridView})
        '
        'SamplesGridView
        '
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLabID, Me.colSampleType, Me.colFieldID, Me.colLabNewID, Me.colReceivedDate, Me.colReceivedBy, Me.colCondition, Me.colLocation, Me.colComment, Me.colLaboratory})
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
        Me.colSampleType.FieldName = "SpecimenType"
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
        Me.colReceivedDate.FieldName = "datCreationDate"
        Me.colReceivedDate.Name = "colReceivedDate"
        '
        'cbDateReceived
        '
        resources.ApplyResources(Me.cbDateReceived, "cbDateReceived")
        Me.cbDateReceived.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDateReceived.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDateReceived.DisplayFormat.FormatString = "d"
        Me.cbDateReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbDateReceived.EditFormat.FormatString = "d"
        Me.cbDateReceived.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbDateReceived.Mask.EditMask = resources.GetString("cbDateReceived.Mask.EditMask")
        Me.cbDateReceived.Name = "cbDateReceived"
        Me.cbDateReceived.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colReceivedBy
        '
        resources.ApplyResources(Me.colReceivedBy, "colReceivedBy")
        Me.colReceivedBy.ColumnEdit = Me.cbReceivedBy
        Me.colReceivedBy.FieldName = "idfReceivedByPerson"
        Me.colReceivedBy.Name = "colReceivedBy"
        Me.colReceivedBy.OptionsColumn.AllowEdit = False
        '
        'cbReceivedBy
        '
        resources.ApplyResources(Me.cbReceivedBy, "cbReceivedBy")
        Me.cbReceivedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReceivedBy.Name = "cbReceivedBy"
        '
        'colCondition
        '
        resources.ApplyResources(Me.colCondition, "colCondition")
        Me.colCondition.ColumnEdit = Me.editMemo
        Me.colCondition.FieldName = "strCondition"
        Me.colCondition.Name = "colCondition"
        '
        'editMemo
        '
        resources.ApplyResources(Me.editMemo, "editMemo")
        Me.editMemo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("editMemo.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.editMemo.MaxLength = 200
        Me.editMemo.Name = "editMemo"
        Me.editMemo.ShowIcon = False
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
        Me.colComment.FieldName = "strNote"
        Me.colComment.Name = "colComment"
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
        Me.btnReport.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
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
        Me.btnBarcodes.Name = "btnBarcodes"
        Me.btnBarcodes.Tag = "{Immovable}{AlwaysEditable}"
        '
        'SampleTransferDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnBarcodes)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormID = "L10"
        Me.HelpTopicID = "SampleTransferOutForm"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SampleTransferDetail"
        Me.ShowDeleteButton = False
        Me.Controls.SetChildIndex(Me.GroupControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupControl2, 0)
        Me.Controls.SetChildIndex(Me.GroupControl3, 0)
        Me.Controls.SetChildIndex(Me.btnBarcodes, 0)
        Me.Controls.SetChildIndex(Me.btnReport, 0)
        CType(Me.txtTransferID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSent.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.cbDateReceived.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDateReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReceivedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.editMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()
        InitializeComponent()
        TransferService = New SamplesTransfer_DB
        Me.DbService = TransferService
        AuditObject = New AuditObject(EIDSSAuditObject.daoTransfer, AuditTable.tlbTransferOUT)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.SampleTransfer
        Me.btnBarcodes.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.Barcode))
        btnTransferIn.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer))
        btnTransferOut.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer))
        'Me.Label1.Font = Me.txtTransferID.Font
    End Sub

    Protected Overrides Sub DefineBinding()
        'If DbService.ID Is Nothing Then Me.State = BusinessObjectState.NewObject
        'Lookup_Db.FillSiteLookup(Me.baseDataSet)
        'LookupBinder.BindSiteLookup(Me.cbTransferFrom, Me.baseDataSet, Nothing)
        'LookupBinder.BindSiteLookup(Me.cbTransferTo, Me.baseDataSet, Nothing)
        'Lookup_Db.FillOrganizationLookup(Me.baseDataSet)
        'Lookup_Db.FillPersonLookup(Me.baseDataSet, EIDSS.model.Core.EidssUserContext.User.OrganizationID)
        Core.LookupBinder.BindOrganizationLookup(Me.cbTransferFrom, Me.baseDataSet, Nothing, False)
        Core.LookupBinder.BindPersonRepositoryLookup(cbReceivedBy)
        'Me.cbTransferFrom.Properties.DataSource = Me.baseDataSet.Tables(Lookup_Db.MappingName(Lookup_Db.TableOrganization))
        Core.LookupBinder.BindOrganizationLookup(Me.cbTransferTo, Me.baseDataSet, Nothing)
        For Each btn As DevExpress.XtraEditors.Controls.EditorButton In Me.cbTransferTo.Properties.Buttons
            If btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then btn.Visible = False
        Next

        'Me.cbTransferTo.Properties.DataSource = Me.baseDataSet.Tables(Lookup_Db.MappingName(Lookup_Db.TableOrganization))
        Core.LookupBinder.BindPersonLookup(Me.cbSentBy, Me.baseDataSet, "Transfer.idfSendByPerson")
        'CType(Me.cbSentBy.Properties.DataSource, DataView).RowFilter = "idfOffice=" + baseDataSet.Tables("Transfer").Rows(0)("idfSendFromOffice").ToString()
        'Me.cbSentBy.Properties.DataSource = Me.baseDataSet.Tables(Lookup_Db.MappingName(Lookup_Db.TablePerson))
        Me.SamplesGrid.DataSource = Me.baseDataSet.Tables("Containers")

        Core.LookupBinder.BindTextEdit(txtTransferID, baseDataSet, "Transfer.strBarcode")
        Core.LookupBinder.BindTextEdit(txtPurpose, baseDataSet, "Transfer.strNote")
        Core.LookupBinder.BindDateEdit(dtSent, baseDataSet, "Transfer.datSendDate")

        Me.cbTransferFrom.EditValue = baseDataSet.Tables("Transfer").Rows(0)("idfSendFromOffice")
        Core.LookupBinder.AddBinding(Me.cbTransferTo, baseDataSet, "Transfer.idfSendToOffice", False)
        'Me.cbSentBy.EditValue = EIDSS.model.Core.EidssUserContext.User.EmployeeID
        'Me.dtSent.EditValue = DateTime.Now

        'Core.LookupBinder.BindDepartmentLookup(cbDepartment, baseDataSet, Nothing, True)
        Core.LookupBinder.BindDepartmentRepositoryLookup(cbDepartment)
        'CType(cbDepartment.DataSource, DataView).RowFilter = "idfInstitution=" + EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID.ToString()
        'cbDepartment.Columns.Clear()
        'cbDepartment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        'New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        ')
        'cbDepartment.DataSource = Me.baseDataSet.Tables("DepartmentLookup")
        LabUtils.BindFreezerLocation(Me.cbLocation)

        If baseDataSet.Tables("Transfer").Rows(0)("idfsTransferStatus").ToString <> CType(TestStatus.Undefined, Long).ToString() Then Me.Transfered = True

        ReflectStatus()
    End Sub

    Private Sub btnAddSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSample.Click
        Dim dlg As IBaseListPanel = CType(ClassLoader.LoadClass("SampleListPanel"), IBaseListPanel)
        Dim selected As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(dlg, FindForm, , 1024, 800)
        SamplesTransfer_DB.CopyObjects(baseDataSet.Tables("containers"), selected)
        ReflectStatus()
    End Sub

    Private Sub btnDeleteSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSample.Click
        Dim handle As Integer = Me.SamplesGridView.FocusedRowHandle
        If handle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
        Me.SamplesGridView.DeleteRow(handle)
    End Sub

    Private Sub ReflectStatus()
        If [ReadOnly] OrElse Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer)) Then
            Return
        End If
        If Me.Transfered Then
            Me.btnTransferOut.Enabled = False
            Dim canIn As Boolean = False
            If (Me.SamplesGridView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle) Then
                canIn = Utils.IsEmpty(Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)("idfTransferIn"))
            End If
            Me.btnTransferIn.Enabled = canIn AndAlso (Me.baseDataSet.Tables("Transfer").Rows(0)("idfSendToOffice").ToString = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID.ToString)
            Me.btnAddSample.Enabled = False
            Me.btnDeleteSample.Enabled = False
            Me.ApplyControlState(Me.cbTransferTo, ControlState.ReadOnly)
            Me.ApplyControlState(Me.txtTransferID, ControlState.ReadOnly)
            Me.ApplyControlState(Me.txtPurpose, ControlState.ReadOnly)
        Else
            Me.btnTransferIn.Enabled = False
            Me.btnTransferOut.Enabled = (Not Utils.IsEmpty(Me.cbTransferTo.EditValue)) And (Me.SamplesGridView.RowCount > 0)
        End If
    End Sub

    Private Sub btnTransferOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferOut.Click
        Dim valid As Boolean = False
        Try
            If DbService.Connection.State <> ConnectionState.Open Then DbService.Connection.Open()
            Dim trans As IDbTransaction = DbService.Connection.BeginTransaction

            Using trans
                valid = DbService.PostDetail(Me.baseDataSet, PostType.PerformAdditionalPosting, trans)
                trans.Rollback()
            End Using
        Catch ex As Exception
            Throw
        Finally
            If DbService.Connection.State = ConnectionState.Open Then DbService.Connection.Close()
        End Try

        If valid Then
            If Me.ValidateData() = False Then Exit Sub
            Me.baseDataSet.Tables("Transfer").Rows(0)("idfsTransferStatus") = TestStatus.InProgress
            Me.Transfered = True
            Me.baseDataSet.Tables("Transfer").Rows(0)("idfSendByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
            Me.baseDataSet.Tables("Transfer").Rows(0)("datSendDate") = DateTime.Now
            Me.baseDataSet.Tables("Transfer").Rows(0).EndEdit()
            ReflectStatus()
        Else
            Dim err As ErrorMessage = TransferService.LastError
            If err Is Nothing Then
                ErrorForm.ShowMessageDirect(TransferService.ErrorList)
            Else
                ErrorForm.ShowError(err)
            End If
        End If
    End Sub

    Private Sub btnTransferIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferIn.Click
        Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
        If Not Utils.IsEmpty(row("idfTransferIn")) Then Exit Sub
        row("idfTransferIn") = BaseDbService.NewIntID()
        row("strBarcodeNew") = NumberingService.GetNextNumber(NumberingObject.Specimen, Me.DbService.Connection, Nothing)
        row("datCreationDate") = DateTime.Now
        row("idfContainerNew") = BaseDbService.NewIntID()
        'row("TransferIn") = True
        'row("FullName") = EIDSS.model.Core.EidssUserContext.User.FullName
        row("idfReceivedByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
        Me.btnBarcodes.Enabled = True
        ReflectStatus()
    End Sub

    Private Sub cbTransferTo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTransferTo.EditValueChanged
        ReflectStatus()
    End Sub

    'Private Sub btnLocation_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnLocation.ButtonClick
    '    Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
    '    Me.SamplesGridView.EditingValue = LabUtils.ChangeLocation(FindForm(), row)
    '    'Dim selected As DataRow() = Nothing
    '    'Try
    '    '    Dim FreezerTree As BaseForm = New EIDSS.FreezerTree()
    '    '    selected = BaseForm.ShowForMultiSelection(FreezerTree, row("idfsSubdivisionID"), Me)
    '    'Catch ex As Exception
    '    'End Try
    '    'If Not selected Is Nothing Then
    '    '    Me.SamplesGridView.EditingValue = selected(0)("Path")
    '    '    row("idfsSubdivisionID") = selected(0)("idfsSubdivisionID")
    '    'End If
    'End Sub

    Private Sub SamplesGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles SamplesGridView.FocusedRowChanged
        ReflectStatus()
        'Dim r As DataRow = Me.SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)

        'If r Is Nothing OrElse r("strBarcodeNew").ToString = "" Then
        'Me.btnBarcodes.Enabled = False
        'Else
        'Me.btnBarcodes.Enabled = True
        'End If
    End Sub

    Private Sub SamplesGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SamplesGridView.ShowingEditor
        If Closing Then Return
        e.Cancel = True
        Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
        'If row.RowState = DataRowState.Added Then
        'e.Cancel = False
        'End If
        If row.RowState = DataRowState.Unchanged Then Exit Sub
        If Not Utils.IsEmpty(row("idfTransferIn")) Then
            If Me.SamplesGridView.FocusedColumn Is Me.colLocation Or Me.SamplesGridView.FocusedColumn Is Me.colComment Or Me.SamplesGridView.FocusedColumn Is Me.colCondition Or Me.SamplesGridView.FocusedColumn Is Me.colLabNewID Or Me.SamplesGridView.FocusedColumn Is Me.colReceivedDate Or Me.SamplesGridView.FocusedColumn Is Me.colLaboratory Then
                e.Cancel = False
            End If
        End If
    End Sub

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return Me.DbService.ID
    End Function

    Private Sub SampleTransferDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler btnBarcodes.ButtonPressed, AddressOf BarcodePressed
    End Sub

    Public Sub BarcodePressed()

        m_ClosingMode = ClosingMode.None
        ' Barcode printing  for sample transfer
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow = Me.SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) 'GetCurrentRow()
            If row Is Nothing Then Exit Sub

            Dim transferRow As DataRow = baseDataSet.Tables("Transfer").Rows(0)
            Dim transferSite As Object = transferRow("idfsSite")
            'On the transfer out site we will print original sample barcode
            'on all other sites we will print transferred in sample barcode or nothing if sample ws not transferred in
            Dim sampleId As Object
            If Utils.IsEmpty(row("idfTransferIn")) OrElse transferSite Is DBNull.Value OrElse EidssSiteContext.Instance.SiteID.Equals(transferSite) Then
                sampleId = row("idfContainer")
            Else
                sampleId = row("idfContainerNew")
            End If
            If Utils.IsEmpty(sampleId) Then Exit Sub
            EidssSiteContext.BarcodeFactory.ShowPreview(CType(NumberingObject.Specimen, Long), CLng(sampleId))
        End If

        'Dim r As DataRow = Me.SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) 'GetCurrentRow()
        'Dim stTop, stBottom As String

        'Dim stCaseID As String = r.Item("CaseID").ToString
        'Dim stPartyCode As String = r.Item("SpeciesCode").ToString
        'Dim stSpecimenCode As String = r.Item("SpecimenCode").ToString
        'Dim dtAccIn As Date = CType(baseDataSet.Tables("Transfer").Rows(0).Item("datStartDate"), Date)

        'If Not r Is Nothing Then
        '    stTop = BarcodePrint.MakeTopString(stCaseID, stPartyCode, stSpecimenCode)
        '    stBottom = BarcodePrint.MakeBottomString(r.Item("strBarcodeNew").ToString, dtAccIn, "")

        'End If

    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        Dim res As Boolean = MyBase.Post(PostType)
        If res = False AndAlso Not TransferService.ErrorList Is Nothing AndAlso TransferService.ErrorList.Length > 0 Then
            ErrorForm.ShowMessageDirect(Me.TransferService.ErrorList)
        End If
        Return res
    End Function

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimSampleTransfer(CType(Me.DbService.ID, Long))
            'DVDoc.Show_LIM_TransferForm(bv.model.Model.Core.ModelUserContext.CurrentLanguage, Me.DbService.ID.ToString)

        End If
    End Sub
End Class
