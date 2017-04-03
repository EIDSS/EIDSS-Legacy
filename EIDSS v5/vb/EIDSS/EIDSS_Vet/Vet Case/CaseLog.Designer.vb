<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaseLog
    Inherits bv.common.win.BaseDetailPanel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaseLog))
        Me.pnCaseLog = New DevExpress.XtraEditors.GroupControl()
        Me.cmdDeleteTest = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdNew = New DevExpress.XtraEditors.SimpleButton()
        Me.CaseLogGrid = New DevExpress.XtraGrid.GridControl()
        Me.CaseLogView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colActionRequired = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colEnteredBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbEnteredBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtComment = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rgStatus = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        CType(Me.pnCaseLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnCaseLog.SuspendLayout()
        CType(Me.CaseLogGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaseLogView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEnteredBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnCaseLog
        '
        Me.pnCaseLog.Appearance.BackColor = CType(resources.GetObject("pnCaseLog.Appearance.BackColor"), System.Drawing.Color)
        Me.pnCaseLog.Appearance.Options.UseBackColor = True
        Me.pnCaseLog.AppearanceCaption.Font = CType(resources.GetObject("pnCaseLog.AppearanceCaption.Font"), System.Drawing.Font)
        Me.pnCaseLog.AppearanceCaption.Options.UseFont = True
        Me.pnCaseLog.Controls.Add(Me.cmdDeleteTest)
        Me.pnCaseLog.Controls.Add(Me.cmdNew)
        Me.pnCaseLog.Controls.Add(Me.CaseLogGrid)
        resources.ApplyResources(Me.pnCaseLog, "pnCaseLog")
        Me.pnCaseLog.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnCaseLog.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnCaseLog.Name = "pnCaseLog"
        Me.pnCaseLog.TabStop = True
        '
        'cmdDeleteTest
        '
        resources.ApplyResources(Me.cmdDeleteTest, "cmdDeleteTest")
        Me.cmdDeleteTest.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.cmdDeleteTest.Name = "cmdDeleteTest"
        '
        'cmdNew
        '
        resources.ApplyResources(Me.cmdNew, "cmdNew")
        Me.cmdNew.Image = Global.EIDSS.My.Resources.Resources.add
        Me.cmdNew.Name = "cmdNew"
        '
        'CaseLogGrid
        '
        resources.ApplyResources(Me.CaseLogGrid, "CaseLogGrid")
        Me.CaseLogGrid.MainView = Me.CaseLogView
        Me.CaseLogGrid.Name = "CaseLogGrid"
        Me.CaseLogGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.dtDate, Me.cbEnteredBy, Me.txtComment, Me.rgStatus})
        Me.CaseLogGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CaseLogView})
        '
        'CaseLogView
        '
        Me.CaseLogView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colActionRequired, Me.colDate, Me.colEnteredBy, Me.colComment, Me.colStatus})
        Me.CaseLogView.GridControl = Me.CaseLogGrid
        resources.ApplyResources(Me.CaseLogView, "CaseLogView")
        Me.CaseLogView.Name = "CaseLogView"
        Me.CaseLogView.OptionsCustomization.AllowFilter = False
        Me.CaseLogView.OptionsCustomization.AllowSort = False
        Me.CaseLogView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.CaseLogView.OptionsNavigation.AutoFocusNewRow = True
        Me.CaseLogView.OptionsNavigation.EnterMoveNextColumn = True
        Me.CaseLogView.OptionsView.ShowGroupPanel = False
        '
        'colActionRequired
        '
        Me.colActionRequired.AppearanceHeader.Font = CType(resources.GetObject("colActionRequired.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colActionRequired.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colActionRequired, "colActionRequired")
        Me.colActionRequired.FieldName = "strActionRequired"
        Me.colActionRequired.Name = "colActionRequired"
        Me.colActionRequired.OptionsColumn.AllowSize = False
        '
        'colDate
        '
        Me.colDate.AppearanceCell.Font = CType(resources.GetObject("colDate.AppearanceCell.Font"), System.Drawing.Font)
        Me.colDate.AppearanceCell.Options.UseFont = True
        Me.colDate.AppearanceHeader.Font = CType(resources.GetObject("colDate.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colDate, "colDate")
        Me.colDate.ColumnEdit = Me.dtDate
        Me.colDate.FieldName = "datCaseLogDate"
        Me.colDate.Name = "colDate"
        Me.colDate.OptionsColumn.AllowMove = False
        '
        'dtDate
        '
        resources.ApplyResources(Me.dtDate, "dtDate")
        Me.dtDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDate.HideSelection = False
        Me.dtDate.Name = "dtDate"
        Me.dtDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colEnteredBy
        '
        resources.ApplyResources(Me.colEnteredBy, "colEnteredBy")
        Me.colEnteredBy.ColumnEdit = Me.cbEnteredBy
        Me.colEnteredBy.FieldName = "idfPerson"
        Me.colEnteredBy.Name = "colEnteredBy"
        '
        'cbEnteredBy
        '
        resources.ApplyResources(Me.cbEnteredBy, "cbEnteredBy")
        Me.cbEnteredBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEnteredBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbEnteredBy.Name = "cbEnteredBy"
        Me.cbEnteredBy.PopupWidth = 300
        '
        'colComment
        '
        Me.colComment.AppearanceHeader.Font = CType(resources.GetObject("colComment.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colComment.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colComment, "colComment")
        Me.colComment.ColumnEdit = Me.txtComment
        Me.colComment.FieldName = "strNote"
        Me.colComment.Name = "colComment"
        '
        'txtComment
        '
        resources.ApplyResources(Me.txtComment, "txtComment")
        Me.txtComment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtComment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ShowIcon = False
        '
        'colStatus
        '
        Me.colStatus.AppearanceHeader.Font = CType(resources.GetObject("colStatus.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colStatus.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colStatus, "colStatus")
        Me.colStatus.ColumnEdit = Me.rgStatus
        Me.colStatus.FieldName = "idfsCaseLogStatus"
        Me.colStatus.Name = "colStatus"
        '
        'rgStatus
        '
        Me.rgStatus.Name = "rgStatus"
        '
        'CaseLog
        '
        Me.Controls.Add(Me.pnCaseLog)
        Me.Name = "CaseLog"
        resources.ApplyResources(Me, "$this")
        CType(Me.pnCaseLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnCaseLog.ResumeLayout(False)
        CType(Me.CaseLogGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaseLogView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEnteredBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnCaseLog As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CaseLogGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CaseLogView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colActionRequired As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEnteredBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbEnteredBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents txtComment As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents rgStatus As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents cmdDeleteTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdNew As DevExpress.XtraEditors.SimpleButton

End Class
