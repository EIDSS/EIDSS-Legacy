Imports EIDSS.model.Resources

Public Class SampleDestructionDetail
    Inherits bv.common.win.BaseDetailForm

    Friend WithEvents colOffice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbPerson As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

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
        Me.AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoSample, AuditTable.tlbContainer)
        'Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.VialDestruction
        Dim perm As String = PermissionHelper.DeletePermission(EIDSS.model.Enums.EIDSSPermissionObject.Sample)
        Me.Permissions = New StandardAccessPermissions(perm, perm, perm, perm, perm)
        Me.DbService = New SampleDestruction_DB()
        Me.m_RelatedLists = New String() {"LabSampleDispositionListItem", "LabSampleListItem", "LabSampleLogBookListItem"}
        SetDestroyMode(mode)
    End Sub


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleDestructionDetail))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colOffice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.cbPerson = New DevExpress.XtraEditors.LookUpEdit
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.AccessibleDescription = Nothing
        Me.GridControl1.AccessibleName = Nothing
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.BackgroundImage = Nothing
        Me.GridControl1.EmbeddedNavigator.AccessibleDescription = Nothing
        Me.GridControl1.EmbeddedNavigator.AccessibleName = Nothing
        Me.GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.GridControl1.EmbeddedNavigator.Anchor = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.BackgroundImage = Nothing
        Me.GridControl1.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("GridControl1.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.GridControl1.EmbeddedNavigator.ImeMode = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GridControl1.EmbeddedNavigator.TextLocation = CType(resources.GetObject("GridControl1.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.GridControl1.EmbeddedNavigator.ToolTip = resources.GetString("GridControl1.EmbeddedNavigator.ToolTip")
        Me.GridControl1.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.GridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("GridControl1.EmbeddedNavigator.ToolTipTitle")
        Me.GridControl1.Font = Nothing
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDepartment, Me.cbStatus})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSampleID, Me.colSampleType, Me.colOffice, Me.colStatus})
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
        Me.colSampleType.FieldName = "SpecimenType"
        Me.colSampleType.Name = "colSampleType"
        Me.colSampleType.OptionsColumn.AllowEdit = False
        '
        'colOffice
        '
        resources.ApplyResources(Me.colOffice, "colOffice")
        Me.colOffice.ColumnEdit = Me.cbDepartment
        Me.colOffice.FieldName = "idfOffice"
        Me.colOffice.Name = "colOffice"
        '
        'cbDepartment
        '
        Me.cbDepartment.AccessibleDescription = Nothing
        Me.cbDepartment.AccessibleName = Nothing
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.DisplayMember = "Name"
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.ValueMember = "idfDepartment"
        '
        'colStatus
        '
        resources.ApplyResources(Me.colStatus, "colStatus")
        Me.colStatus.ColumnEdit = Me.cbStatus
        Me.colStatus.FieldName = "idfsContainerStatus"
        Me.colStatus.Name = "colStatus"
        '
        'cbStatus
        '
        Me.cbStatus.AccessibleDescription = Nothing
        Me.cbStatus.AccessibleName = Nothing
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
        Me.cbPerson.BackgroundImage = Nothing
        Me.cbPerson.EditValue = Nothing
        Me.cbPerson.Name = "cbPerson"
        Me.cbPerson.Properties.AccessibleDescription = Nothing
        Me.cbPerson.Properties.AccessibleName = Nothing
        Me.cbPerson.Properties.AutoHeight = CType(resources.GetObject("cbPerson.Properties.AutoHeight"), Boolean)
        Me.cbPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbPerson.Properties.NullText = resources.GetString("cbPerson.Properties.NullText")
        Me.cbPerson.Properties.NullValuePrompt = resources.GetString("cbPerson.Properties.NullValuePrompt")
        Me.cbPerson.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbPerson.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbPerson.Tag = ""
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = Nothing
        Me.Label12.AccessibleName = Nothing
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Font = Nothing
        Me.Label12.Name = "Label12"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = Nothing
        Me.btnAdd.AccessibleName = Nothing
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.BackgroundImage = Nothing
        Me.btnAdd.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = Nothing
        Me.btnDelete.AccessibleName = Nothing
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.BackgroundImage = Nothing
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'SampleDestructionDetail
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cbPerson)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Label12)
        Me.FormID = "L08"
        Me.HelpTopicID = "SampleDestructionForm"
        Me.KeyFieldName = "idfContainer"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SampleDestructionDetail"
        Me.ObjectName = "Samples"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Sizable = True
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.GridControl1, 0)
        Me.Controls.SetChildIndex(Me.cbPerson, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub DefineBinding()
        Me.GridControl1.DataSource = Me.baseDataSet.Tables("Samples")

        'cbDepartment.Columns.Clear()
        'cbDepartment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        'New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        ')
        'cbDepartment.DataSource = Me.baseDataSet.Tables("DepartmentLookup")

        Me.cbStatus.DataSource = Me.baseDataSet.Tables("Status")
        cbStatus.Columns.Clear()
        cbStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        )
        cbStatus.DisplayMember = "name"

        ''Lookup_Db.FillPersonLookup(Me.baseDataSet, EIDSS.model.Core.EidssUserContext.User.OrganizationID)
        ''LookupBinder.BindPersonLookup(Me.cbPerson, Me.baseDataSet, Nothing)
        Core.LookupBinder.BindPersonLookup(cbPerson, baseDataSet, "User.idfDestroyedByPerson")
        Core.LookupBinder.SetPersonFilter(cbPerson)
        'CType(Me.cbPerson.Properties.DataSource, DataView).RowFilter = String.Format("idfOffice={0} or idfPerson={1}", EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID, EIDSS.model.Core.EidssUserContext.User.EmployeeID)
        'Me.cbPerson.EditValue = EIDSS.model.Core.EidssUserContext.User.EmployeeID

    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return True
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.GridView1.DeleteSelectedRows()
    End Sub

End Class
