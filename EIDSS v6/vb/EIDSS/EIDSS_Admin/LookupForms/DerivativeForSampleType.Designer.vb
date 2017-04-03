<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DerivativeForSampleType
    Inherits bv.common.win.BaseDetailList

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DerivativeForSampleType))
        Me.lbSampleType = New System.Windows.Forms.Label()
        Me.cbSampleType = New DevExpress.XtraEditors.LookUpEdit()
        Me.DerivativeGrid = New DevExpress.XtraGrid.GridControl()
        Me.DerivativeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDerivative = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDerivativeType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.cbSampleType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DerivativeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DerivativeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDerivativeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(DerivativeForSampleType), resources)
        'Form Is Localizable: True
        '
        'lbSampleType
        '
        resources.ApplyResources(Me.lbSampleType, "lbSampleType")
        Me.lbSampleType.Name = "lbSampleType"
        '
        'cbSampleType
        '
        resources.ApplyResources(Me.cbSampleType, "cbSampleType")
        Me.cbSampleType.Name = "cbSampleType"
        Me.cbSampleType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSampleType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSampleType.Properties.NullText = resources.GetString("cbSampleType.Properties.NullText")
        Me.cbSampleType.Tag = "{AlwaysEditable}"
        '
        'DerivativeGrid
        '
        resources.ApplyResources(Me.DerivativeGrid, "DerivativeGrid")
        Me.DerivativeGrid.MainView = Me.DerivativeView
        Me.DerivativeGrid.Name = "DerivativeGrid"
        Me.DerivativeGrid.TabStop = False
        Me.DerivativeGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DerivativeView})
        '
        'DerivativeView
        '
        Me.DerivativeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDerivative})
        Me.DerivativeView.GridControl = Me.DerivativeGrid
        resources.ApplyResources(Me.DerivativeView, "DerivativeView")
        Me.DerivativeView.Name = "DerivativeView"
        Me.DerivativeView.OptionsCustomization.AllowFilter = False
        Me.DerivativeView.OptionsNavigation.AutoFocusNewRow = True
        Me.DerivativeView.OptionsView.ShowGroupPanel = False
        '
        'colDerivative
        '
        resources.ApplyResources(Me.colDerivative, "colDerivative")
        Me.colDerivative.ColumnEdit = Me.cbDerivativeType
        Me.colDerivative.FieldName = "idfsDerivativeType"
        Me.colDerivative.Name = "colDerivative"
        '
        'cbDerivativeType
        '
        resources.ApplyResources(Me.cbDerivativeType, "cbDerivativeType")
        Me.cbDerivativeType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDerivativeType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDerivativeType.Name = "cbDerivativeType"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'DerivativeForSampleType
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lbSampleType)
        Me.Controls.Add(Me.cbSampleType)
        Me.Controls.Add(Me.DerivativeGrid)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A26"
        Me.HelpTopicID = "Sample_type-derivative_type_ma"
        Me.KeyFieldName = "idfDerivativeForSampleType"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Matrix__large__46_
        Me.MinHeight = 400
        Me.MinWidth = 600
        Me.Name = "DerivativeForSampleType"
        Me.ObjectName = "DerivativeForSampleType"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "DerivativeForSampleType"
        Me.Controls.SetChildIndex(Me.DerivativeGrid, 0)
        Me.Controls.SetChildIndex(Me.cbSampleType, 0)
        Me.Controls.SetChildIndex(Me.lbSampleType, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        CType(Me.cbSampleType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DerivativeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DerivativeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDerivativeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbSampleType As System.Windows.Forms.Label
    Friend WithEvents cbSampleType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DerivativeGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents DerivativeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDerivative As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDerivativeType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton

End Class
