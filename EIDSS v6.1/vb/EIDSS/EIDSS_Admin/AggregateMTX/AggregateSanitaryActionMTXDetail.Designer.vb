<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateSanitaryActionMTXDetail
    Inherits EIDSS.AggregateMatrixBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateSanitaryActionMTXDetail))
        Me.pnMatrix = New DevExpress.XtraEditors.GroupControl()
        Me.gcMTX = New DevExpress.XtraGrid.GridControl()
        Me.gvMTX = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolActionID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSanitaryAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolActionCode = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMatrix.SuspendLayout()
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSanitaryAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AggregateSanitaryActionMTXDetail), resources)
        'Form Is Localizable: True
        '
        'pnMatrix
        '
        resources.ApplyResources(Me.pnMatrix, "pnMatrix")
        Me.pnMatrix.Controls.Add(Me.gcMTX)
        Me.pnMatrix.Name = "pnMatrix"
        '
        'gcMTX
        '
        resources.ApplyResources(Me.gcMTX, "gcMTX")
        Me.gcMTX.MainView = Me.gvMTX
        Me.gcMTX.Name = "gcMTX"
        Me.gcMTX.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSanitaryAction})
        Me.gcMTX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvMTX})
        '
        'gvMTX
        '
        Me.gvMTX.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolActionID, Me.gcolActionCode})
        Me.gvMTX.GridControl = Me.gcMTX
        resources.ApplyResources(Me.gvMTX, "gvMTX")
        Me.gvMTX.Name = "gvMTX"
        Me.gvMTX.OptionsCustomization.AllowFilter = False
        Me.gvMTX.OptionsCustomization.AllowGroup = False
        Me.gvMTX.OptionsCustomization.AllowSort = False
        Me.gvMTX.OptionsNavigation.AutoFocusNewRow = True
        Me.gvMTX.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.gvMTX.OptionsView.ShowGroupPanel = False
        '
        'gcolActionID
        '
        Me.gcolActionID.AppearanceHeader.Font = CType(resources.GetObject("gcolActionID.AppearanceHeader.Font"), System.Drawing.Font)
        Me.gcolActionID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolActionID, "gcolActionID")
        Me.gcolActionID.ColumnEdit = Me.cbSanitaryAction
        Me.gcolActionID.FieldName = "idfsSanitaryAction"
        Me.gcolActionID.Name = "gcolActionID"
        Me.gcolActionID.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'cbSanitaryAction
        '
        resources.ApplyResources(Me.cbSanitaryAction, "cbSanitaryAction")
        Me.cbSanitaryAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSanitaryAction.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSanitaryAction.Name = "cbSanitaryAction"
        '
        'gcolActionCode
        '
        resources.ApplyResources(Me.gcolActionCode, "gcolActionCode")
        Me.gcolActionCode.FieldName = "strActionCode"
        Me.gcolActionCode.Name = "gcolActionCode"
        Me.gcolActionCode.OptionsColumn.AllowEdit = False
        Me.gcolActionCode.OptionsColumn.ReadOnly = True
        Me.gcolActionCode.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'AggregateSanitaryActionMTXDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("AggregateSanitaryActionMTXDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.pnMatrix)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A16"
        Me.HelpTopicID = "Vet_sanitary_action_matrix_edi"
        Me.KeyFieldName = "idfSanitaryActionMTX"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Matrix__large__46_
        Me.Name = "AggregateSanitaryActionMTXDetail"
        Me.ObjectName = "SanitaryActionsMatrix"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.pnMatrix, 0)
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMatrix.ResumeLayout(False)
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSanitaryAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnMatrix As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcMTX As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvMTX As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolActionID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSanitaryAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolActionCode As DevExpress.XtraGrid.Columns.GridColumn

End Class
