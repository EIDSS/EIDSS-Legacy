Imports EIDSS.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports bv.common.Enums
Imports System.Collections.Generic

Public Class SampleDestructionDetail
    Inherits bv.common.win.BaseDetailForm

    Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbPerson As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents cbStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDestructionMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDestructionMethod As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents btnReport As bv.winclient.Core.PopUpButton

    Private DestroyMode As Boolean = False
    Public Sub New(mode As Boolean)
        Init(mode)
    End Sub
    Public Sub New()
        Init(True)
    End Sub

    Public Sub SetDestroyMode(ByVal mode As Boolean)
        DestroyMode = mode
        CType(DbService, SampleDestruction_DB).DestroyMode = mode
        If DestroyMode = False Then
            Dim shift As Integer = Me.GridControl1.Top - Me.cbPerson.Top
            Me.GridControl1.Top -= shift
            Me.GridControl1.Height += shift
            Me.cbPerson.Visible = False
            Me.Label12.Visible = False
            Me.ShowSaveButton = True
        End If

    End Sub
    Private Sub Init(mode As Boolean)
        InitializeComponent()
        Me.AuditObject = New AuditObject(EIDSSAuditObject.daoSampleDestruction, AuditTable.tlbMaterial)
        'Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.VialDestruction
        Dim perm As String = PermissionHelper.DeletePermission(EIDSSPermissionObject.Sample)
        Me.Permissions = New StandardAccessPermissions(perm, perm, perm, perm, perm)
        Me.DbService = New SampleDestruction_DB()
        Me.m_RelatedLists = New String() {"LabSampleDispositionListItem", "LabSampleListItem"}
        SetDestroyMode(mode)

        MenuItem1.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimSampleDestruction")
    End Sub


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleDestructionDetail))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDestructionMethod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDestructionMethod = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbPerson = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnReport = New bv.winclient.Core.PopUpButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDestructionMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SampleDestructionDetail), resources)
        'Form Is Localizable: True
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDepartment, Me.cbStatus, Me.cbDestructionMethod})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSampleID, Me.colSampleType, Me.colDestructionMethod})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colSampleID
        '
        resources.ApplyResources(Me.colSampleID, "colSampleID")
        Me.colSampleID.FieldName = "strBarcode"
        Me.colSampleID.Name = "colSampleID"
        Me.colSampleID.OptionsColumn.AllowEdit = False
        '
        'colSampleType
        '
        resources.ApplyResources(Me.colSampleType, "colSampleType")
        Me.colSampleType.FieldName = "strSampleName"
        Me.colSampleType.Name = "colSampleType"
        Me.colSampleType.OptionsColumn.AllowEdit = False
        '
        'colDestructionMethod
        '
        resources.ApplyResources(Me.colDestructionMethod, "colDestructionMethod")
        Me.colDestructionMethod.ColumnEdit = Me.cbDestructionMethod
        Me.colDestructionMethod.FieldName = "idfsDestructionMethod"
        Me.colDestructionMethod.Name = "colDestructionMethod"
        '
        'cbDestructionMethod
        '
        resources.ApplyResources(Me.cbDestructionMethod, "cbDestructionMethod")
        Me.cbDestructionMethod.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDestructionMethod.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDestructionMethod.Name = "cbDestructionMethod"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.DisplayMember = "Name"
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.ValueMember = "idfDepartment"
        '
        'cbStatus
        '
        resources.ApplyResources(Me.cbStatus, "cbStatus")
        Me.cbStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatus.DisplayMember = "Name"
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.ShowHeader = False
        Me.cbStatus.ValueMember = "idfsReference"
        '
        'cbPerson
        '
        resources.ApplyResources(Me.cbPerson, "cbPerson")
        Me.cbPerson.Name = "cbPerson"
        Me.cbPerson.Properties.AutoHeight = CType(resources.GetObject("cbPerson.Properties.AutoHeight"), Boolean)
        Me.cbPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbPerson.Properties.NullText = resources.GetString("cbPerson.Properties.NullText")
        Me.cbPerson.Tag = ""
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
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
        'btnReport
        '
        resources.ApplyResources(Me.btnReport, "btnReport")
        Me.btnReport.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.btnReport.Name = "btnReport"
        Me.btnReport.PopUpMenu = Me.cmReports
        Me.btnReport.Tag = "{Immovable}{AlwaysEditable}"
        '
        'SampleDestructionDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cbPerson)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Label12)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L08"
        Me.HelpTopicID = "lab_l08"
        Me.KeyFieldName = "idfMaterial"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SampleDestructionDetail"
        Me.ObjectName = "Samples"
        Me.ShowDeleteButton = False
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.GridControl1, 0)
        Me.Controls.SetChildIndex(Me.cbPerson, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnReport, 0)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDestructionMethod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub DefineBinding()
        Me.GridControl1.DataSource = Me.baseDataSet.Tables("Samples")
        Core.LookupBinder.BindPersonLookup(cbPerson, baseDataSet, "User.idfDestroyedByPerson", HACode.All)
        Core.LookupBinder.SetPersonFilter(cbPerson)
        Core.LookupBinder.BindBaseRepositoryLookup(cbDestructionMethod, db.BaseReferenceType.rftDestructionMethod)

    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return True
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.GridView1.DeleteSelectedRows()
    End Sub


  

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 OrElse (Not baseDataSet.Tables.Contains("Samples")) Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            Dim idList As List(Of Long) = New List(Of Long)()
            Dim table As DataTable = baseDataSet.Tables("Samples")
            For Each row As DataRow In table.Rows
                idList.Add(CLng(row("idfMaterial")))
            Next
            EidssSiteContext.ReportFactory.LimSampleDestruction(idList)
        End If


    End Sub
End Class
