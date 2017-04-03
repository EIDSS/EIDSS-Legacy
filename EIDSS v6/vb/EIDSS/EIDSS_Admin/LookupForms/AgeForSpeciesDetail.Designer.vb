<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgeForSpeciesDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgeForSpeciesDetail))
        Me.lbSpeciesType = New System.Windows.Forms.Label()
        Me.cbSpeciesType = New DevExpress.XtraEditors.LookUpEdit()
        Me.AnimalAgeGrid = New DevExpress.XtraGrid.GridControl()
        Me.AnimalAgeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDerivative = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalAgeMatrix = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.cbSpeciesType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalAgeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalAgeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalAgeMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AgeForSpeciesDetail), resources)
        'Form Is Localizable: True
        '
        'lbSpeciesType
        '
        resources.ApplyResources(Me.lbSpeciesType, "lbSpeciesType")
        Me.lbSpeciesType.Name = "lbSpeciesType"
        '
        'cbSpeciesType
        '
        resources.ApplyResources(Me.cbSpeciesType, "cbSpeciesType")
        Me.cbSpeciesType.Name = "cbSpeciesType"
        Me.cbSpeciesType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpeciesType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpeciesType.Properties.NullText = resources.GetString("cbSpeciesType.Properties.NullText")
        Me.cbSpeciesType.Tag = "{AlwaysEditable}"
        '
        'AnimalAgeGrid
        '
        resources.ApplyResources(Me.AnimalAgeGrid, "AnimalAgeGrid")
        Me.AnimalAgeGrid.MainView = Me.AnimalAgeView
        Me.AnimalAgeGrid.Name = "AnimalAgeGrid"
        Me.AnimalAgeGrid.TabStop = False
        Me.AnimalAgeGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AnimalAgeView})
        '
        'AnimalAgeView
        '
        Me.AnimalAgeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDerivative})
        Me.AnimalAgeView.GridControl = Me.AnimalAgeGrid
        resources.ApplyResources(Me.AnimalAgeView, "AnimalAgeView")
        Me.AnimalAgeView.Name = "AnimalAgeView"
        Me.AnimalAgeView.OptionsCustomization.AllowFilter = False
        Me.AnimalAgeView.OptionsNavigation.AutoFocusNewRow = True
        Me.AnimalAgeView.OptionsView.ShowGroupPanel = False
        '
        'colDerivative
        '
        resources.ApplyResources(Me.colDerivative, "colDerivative")
        Me.colDerivative.ColumnEdit = Me.cbAnimalAgeMatrix
        Me.colDerivative.FieldName = "idfsAnimalAge"
        Me.colDerivative.Name = "colDerivative"
        '
        'cbAnimalAgeMatrix
        '
        resources.ApplyResources(Me.cbAnimalAgeMatrix, "cbAnimalAgeMatrix")
        Me.cbAnimalAgeMatrix.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalAgeMatrix.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalAgeMatrix.Name = "cbAnimalAgeMatrix"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'AgeForSpeciesDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lbSpeciesType)
        Me.Controls.Add(Me.cbSpeciesType)
        Me.Controls.Add(Me.AnimalAgeGrid)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A27"
        Me.HelpTopicID = "Species-Animal_Age_Matrix"
        Me.KeyFieldName = "idfAgeForSpecies"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Matrix__large__46_
        Me.MinHeight = 400
        Me.MinWidth = 600
        Me.Name = "AgeForSpeciesDetail"
        Me.ObjectName = "AgeForSpecies"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AgeForSpecies"
        Me.Controls.SetChildIndex(Me.AnimalAgeGrid, 0)
        Me.Controls.SetChildIndex(Me.cbSpeciesType, 0)
        Me.Controls.SetChildIndex(Me.lbSpeciesType, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        CType(Me.cbSpeciesType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalAgeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalAgeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalAgeMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbSpeciesType As System.Windows.Forms.Label
    Friend WithEvents cbSpeciesType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AnimalAgeGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AnimalAgeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDerivative As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbAnimalAgeMatrix As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton

End Class
