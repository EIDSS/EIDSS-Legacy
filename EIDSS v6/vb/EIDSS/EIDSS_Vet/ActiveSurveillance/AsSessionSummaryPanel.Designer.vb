Namespace ActiveSurveillance
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AsSessionSummaryPanel
        Inherits BaseDetailPanel

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsSessionSummaryPanel))
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Me.AsSummaryGrid = New DevExpress.XtraGrid.GridControl()
            Me.AsSummaryView = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colFarmID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtFarmCode = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colSex = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSex = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colSampledAnimalsQty = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtQtyEditor = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
            Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSamples = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
            Me.SamplesPopupContainer = New DevExpress.XtraEditors.PopupContainerControl()
            Me.btnOkSamples = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCopySamples = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClearSamples = New DevExpress.XtraEditors.SimpleButton()
            Me.btnPasteSamples = New DevExpress.XtraEditors.SimpleButton()
            Me.SamplesList = New DevExpress.XtraEditors.CheckedListBoxControl()
            Me.colSamplesQty = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colCollectionDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.dtCollectionDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.colPositiveQty = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
            Me.DiagnosisPopupContainer = New DevExpress.XtraEditors.PopupContainerControl()
            Me.btnOkdiagnosis = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCopyDiagnosis = New DevExpress.XtraEditors.SimpleButton()
            Me.btnClearDiagnosis = New DevExpress.XtraEditors.SimpleButton()
            Me.btnPasteDiagnosis = New DevExpress.XtraEditors.SimpleButton()
            Me.DiagnosisList = New DevExpress.XtraEditors.CheckedListBoxControl()
            Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
            Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.txtAnimalsQtyTotal = New DevExpress.XtraEditors.TextEdit()
            Me.txtSamplesQtyTotal = New DevExpress.XtraEditors.TextEdit()
            Me.lbSamplesQtyTotal = New DevExpress.XtraEditors.LabelControl()
            Me.txtPositiveQtyTotal = New DevExpress.XtraEditors.TextEdit()
            Me.lbPositiveQtyTotal = New DevExpress.XtraEditors.LabelControl()
            CType(Me.AsSummaryGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AsSummaryView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtFarmCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSex, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtQtyEditor, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSamples, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SamplesPopupContainer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SamplesPopupContainer.SuspendLayout()
            CType(Me.SamplesList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DiagnosisPopupContainer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DiagnosisPopupContainer.SuspendLayout()
            CType(Me.DiagnosisList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtAnimalsQtyTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtSamplesQtyTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPositiveQtyTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AsSessionSummaryPanel), resources)
            'Form Is Localizable: True
            '
            'AsSummaryGrid
            '
            resources.ApplyResources(Me.AsSummaryGrid, "AsSummaryGrid")
            Me.AsSummaryGrid.MainView = Me.AsSummaryView
            Me.AsSummaryGrid.Name = "AsSummaryGrid"
            Me.AsSummaryGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtFarmCode, Me.cbSpecies, Me.cbSex, Me.txtQtyEditor, Me.dtCollectionDate, Me.cbDiagnosis, Me.cbSamples})
            Me.AsSummaryGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AsSummaryView})
            '
            'AsSummaryView
            '
            Me.AsSummaryView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFarmID, Me.colSpecies, Me.colSex, Me.colSampledAnimalsQty, Me.colSampleType, Me.colSamplesQty, Me.colCollectionDate, Me.colPositiveQty, Me.colDiagnosis})
            Me.AsSummaryView.GridControl = Me.AsSummaryGrid
            Me.AsSummaryView.Name = "AsSummaryView"
            Me.AsSummaryView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            Me.AsSummaryView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.AsSummaryView.OptionsView.ShowGroupPanel = False
            '
            'colFarmID
            '
            resources.ApplyResources(Me.colFarmID, "colFarmID")
            Me.colFarmID.ColumnEdit = Me.txtFarmCode
            Me.colFarmID.FieldName = "strFarmCode"
            Me.colFarmID.Name = "colFarmID"
            Me.colFarmID.OptionsColumn.ReadOnly = True
            '
            'txtFarmCode
            '
            resources.ApplyResources(Me.txtFarmCode, "txtFarmCode")
            Me.txtFarmCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmCode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarmCode.Buttons1"), CType(resources.GetObject("txtFarmCode.Buttons2"), Integer), CType(resources.GetObject("txtFarmCode.Buttons3"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons4"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons5"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarmCode.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtFarmCode.Buttons8"), CType(resources.GetObject("txtFarmCode.Buttons9"), Object), CType(resources.GetObject("txtFarmCode.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarmCode.Buttons11"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmCode.Buttons12"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarmCode.Buttons13"), CType(resources.GetObject("txtFarmCode.Buttons14"), Integer), CType(resources.GetObject("txtFarmCode.Buttons15"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons16"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons17"), Boolean), CType(resources.GetObject("txtFarmCode.Buttons18"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarmCode.Buttons19"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtFarmCode.Buttons20"), CType(resources.GetObject("txtFarmCode.Buttons21"), Object), CType(resources.GetObject("txtFarmCode.Buttons22"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarmCode.Buttons23"), Boolean))})
            Me.txtFarmCode.Name = "txtFarmCode"
            '
            'colSpecies
            '
            resources.ApplyResources(Me.colSpecies, "colSpecies")
            Me.colSpecies.ColumnEdit = Me.cbSpecies
            Me.colSpecies.FieldName = "idfSpecies"
            Me.colSpecies.Name = "colSpecies"
            '
            'cbSpecies
            '
            resources.ApplyResources(Me.cbSpecies, "cbSpecies")
            Me.cbSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecies.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSpecies.Name = "cbSpecies"
            '
            'colSex
            '
            resources.ApplyResources(Me.colSex, "colSex")
            Me.colSex.ColumnEdit = Me.cbSex
            Me.colSex.FieldName = "idfsAnimalSex"
            Me.colSex.Name = "colSex"
            '
            'cbSex
            '
            resources.ApplyResources(Me.cbSex, "cbSex")
            Me.cbSex.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSex.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSex.Name = "cbSex"
            '
            'colSampledAnimalsQty
            '
            resources.ApplyResources(Me.colSampledAnimalsQty, "colSampledAnimalsQty")
            Me.colSampledAnimalsQty.ColumnEdit = Me.txtQtyEditor
            Me.colSampledAnimalsQty.FieldName = "intSampledAnimalsQty"
            Me.colSampledAnimalsQty.Name = "colSampledAnimalsQty"
            '
            'txtQtyEditor
            '
            resources.ApplyResources(Me.txtQtyEditor, "txtQtyEditor")
            Me.txtQtyEditor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.txtQtyEditor.IsFloatValue = False
            Me.txtQtyEditor.Mask.EditMask = resources.GetString("txtQtyEditor.Mask.EditMask")
            Me.txtQtyEditor.MaxValue = New Decimal(New Integer() {100000, 0, 0, 0})
            Me.txtQtyEditor.Name = "txtQtyEditor"
            '
            'colSampleType
            '
            resources.ApplyResources(Me.colSampleType, "colSampleType")
            Me.colSampleType.ColumnEdit = Me.cbSamples
            Me.colSampleType.FieldName = "strSamples"
            Me.colSampleType.Name = "colSampleType"
            '
            'cbSamples
            '
            resources.ApplyResources(Me.cbSamples, "cbSamples")
            Me.cbSamples.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSamples.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSamples.Name = "cbSamples"
            Me.cbSamples.PopupControl = Me.SamplesPopupContainer
            Me.cbSamples.ShowPopupCloseButton = False
            '
            'SamplesPopupContainer
            '
            Me.SamplesPopupContainer.Controls.Add(Me.btnOkSamples)
            Me.SamplesPopupContainer.Controls.Add(Me.btnCopySamples)
            Me.SamplesPopupContainer.Controls.Add(Me.btnClearSamples)
            Me.SamplesPopupContainer.Controls.Add(Me.btnPasteSamples)
            Me.SamplesPopupContainer.Controls.Add(Me.SamplesList)
            resources.ApplyResources(Me.SamplesPopupContainer, "SamplesPopupContainer")
            Me.SamplesPopupContainer.Name = "SamplesPopupContainer"
            '
            'btnOkSamples
            '
            resources.ApplyResources(Me.btnOkSamples, "btnOkSamples")
            Me.btnOkSamples.Name = "btnOkSamples"
            '
            'btnCopySamples
            '
            resources.ApplyResources(Me.btnCopySamples, "btnCopySamples")
            Me.btnCopySamples.Image = Global.eidss.My.Resources.Resources.copy
            Me.btnCopySamples.Name = "btnCopySamples"
            Me.btnCopySamples.TabStop = False
            '
            'btnClearSamples
            '
            resources.ApplyResources(Me.btnClearSamples, "btnClearSamples")
            Me.btnClearSamples.Image = Global.eidss.My.Resources.Resources.Clear_Cancel_Changes1
            Me.btnClearSamples.Name = "btnClearSamples"
            Me.btnClearSamples.TabStop = False
            '
            'btnPasteSamples
            '
            resources.ApplyResources(Me.btnPasteSamples, "btnPasteSamples")
            Me.btnPasteSamples.Image = Global.eidss.My.Resources.Resources.paste
            Me.btnPasteSamples.Name = "btnPasteSamples"
            Me.btnPasteSamples.TabStop = False
            '
            'SamplesList
            '
            resources.ApplyResources(Me.SamplesList, "SamplesList")
            Me.SamplesList.CheckOnClick = True
            Me.SamplesList.DisplayMember = "name"
            Me.SamplesList.Name = "SamplesList"
            Me.SamplesList.ValueMember = "idfsSampleType"
            '
            'colSamplesQty
            '
            resources.ApplyResources(Me.colSamplesQty, "colSamplesQty")
            Me.colSamplesQty.ColumnEdit = Me.txtQtyEditor
            Me.colSamplesQty.FieldName = "intSamplesQty"
            Me.colSamplesQty.Name = "colSamplesQty"
            '
            'colCollectionDate
            '
            resources.ApplyResources(Me.colCollectionDate, "colCollectionDate")
            Me.colCollectionDate.ColumnEdit = Me.dtCollectionDate
            Me.colCollectionDate.FieldName = "datCollectionDate"
            Me.colCollectionDate.Name = "colCollectionDate"
            '
            'dtCollectionDate
            '
            resources.ApplyResources(Me.dtCollectionDate, "dtCollectionDate")
            Me.dtCollectionDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCollectionDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCollectionDate.Name = "dtCollectionDate"
            Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            '
            'colPositiveQty
            '
            resources.ApplyResources(Me.colPositiveQty, "colPositiveQty")
            Me.colPositiveQty.ColumnEdit = Me.txtQtyEditor
            Me.colPositiveQty.FieldName = "intPositiveAnimalsQty"
            Me.colPositiveQty.Name = "colPositiveQty"
            '
            'colDiagnosis
            '
            resources.ApplyResources(Me.colDiagnosis, "colDiagnosis")
            Me.colDiagnosis.ColumnEdit = Me.cbDiagnosis
            Me.colDiagnosis.FieldName = "strDiagnosis"
            Me.colDiagnosis.Name = "colDiagnosis"
            '
            'cbDiagnosis
            '
            resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
            Me.cbDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbDiagnosis.Name = "cbDiagnosis"
            Me.cbDiagnosis.PopupControl = Me.DiagnosisPopupContainer
            Me.cbDiagnosis.ShowPopupCloseButton = False
            '
            'DiagnosisPopupContainer
            '
            Me.DiagnosisPopupContainer.Controls.Add(Me.btnOkdiagnosis)
            Me.DiagnosisPopupContainer.Controls.Add(Me.btnCopyDiagnosis)
            Me.DiagnosisPopupContainer.Controls.Add(Me.btnClearDiagnosis)
            Me.DiagnosisPopupContainer.Controls.Add(Me.btnPasteDiagnosis)
            Me.DiagnosisPopupContainer.Controls.Add(Me.DiagnosisList)
            resources.ApplyResources(Me.DiagnosisPopupContainer, "DiagnosisPopupContainer")
            Me.DiagnosisPopupContainer.Name = "DiagnosisPopupContainer"
            '
            'btnOkdiagnosis
            '
            resources.ApplyResources(Me.btnOkdiagnosis, "btnOkdiagnosis")
            Me.btnOkdiagnosis.Name = "btnOkdiagnosis"
            '
            'btnCopyDiagnosis
            '
            resources.ApplyResources(Me.btnCopyDiagnosis, "btnCopyDiagnosis")
            Me.btnCopyDiagnosis.Image = Global.eidss.My.Resources.Resources.copy
            Me.btnCopyDiagnosis.Name = "btnCopyDiagnosis"
            Me.btnCopyDiagnosis.TabStop = False
            '
            'btnClearDiagnosis
            '
            resources.ApplyResources(Me.btnClearDiagnosis, "btnClearDiagnosis")
            Me.btnClearDiagnosis.Image = Global.eidss.My.Resources.Resources.Clear_Cancel_Changes1
            Me.btnClearDiagnosis.Name = "btnClearDiagnosis"
            Me.btnClearDiagnosis.TabStop = False
            '
            'btnPasteDiagnosis
            '
            resources.ApplyResources(Me.btnPasteDiagnosis, "btnPasteDiagnosis")
            Me.btnPasteDiagnosis.Image = Global.eidss.My.Resources.Resources.paste
            Me.btnPasteDiagnosis.Name = "btnPasteDiagnosis"
            Me.btnPasteDiagnosis.TabStop = False
            '
            'DiagnosisList
            '
            resources.ApplyResources(Me.DiagnosisList, "DiagnosisList")
            Me.DiagnosisList.CheckOnClick = True
            Me.DiagnosisList.DisplayMember = "name"
            Me.DiagnosisList.Name = "DiagnosisList"
            Me.DiagnosisList.ValueMember = "idfsDiagnosis"
            '
            'btnDelete
            '
            resources.ApplyResources(Me.btnDelete, "btnDelete")
            Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
            Me.btnDelete.Name = "btnDelete"
            '
            'LabelControl1
            '
            resources.ApplyResources(Me.LabelControl1, "LabelControl1")
            Me.LabelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.LabelControl1.Name = "LabelControl1"
            '
            'txtAnimalsQtyTotal
            '
            resources.ApplyResources(Me.txtAnimalsQtyTotal, "txtAnimalsQtyTotal")
            Me.txtAnimalsQtyTotal.Name = "txtAnimalsQtyTotal"
            Me.txtAnimalsQtyTotal.Properties.ReadOnly = True
            Me.txtAnimalsQtyTotal.Properties.Tag = "{R}"
            '
            'txtSamplesQtyTotal
            '
            resources.ApplyResources(Me.txtSamplesQtyTotal, "txtSamplesQtyTotal")
            Me.txtSamplesQtyTotal.Name = "txtSamplesQtyTotal"
            Me.txtSamplesQtyTotal.Properties.ReadOnly = True
            Me.txtSamplesQtyTotal.Properties.Tag = "{R}"
            '
            'lbSamplesQtyTotal
            '
            resources.ApplyResources(Me.lbSamplesQtyTotal, "lbSamplesQtyTotal")
            Me.lbSamplesQtyTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.lbSamplesQtyTotal.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbSamplesQtyTotal.Name = "lbSamplesQtyTotal"
            '
            'txtPositiveQtyTotal
            '
            resources.ApplyResources(Me.txtPositiveQtyTotal, "txtPositiveQtyTotal")
            Me.txtPositiveQtyTotal.Name = "txtPositiveQtyTotal"
            Me.txtPositiveQtyTotal.Properties.ReadOnly = True
            Me.txtPositiveQtyTotal.Properties.Tag = "{R}"
            '
            'lbPositiveQtyTotal
            '
            resources.ApplyResources(Me.lbPositiveQtyTotal, "lbPositiveQtyTotal")
            Me.lbPositiveQtyTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.lbPositiveQtyTotal.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lbPositiveQtyTotal.Name = "lbPositiveQtyTotal"
            '
            'AsSessionSummaryPanel
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.txtPositiveQtyTotal)
            Me.Controls.Add(Me.lbPositiveQtyTotal)
            Me.Controls.Add(Me.txtSamplesQtyTotal)
            Me.Controls.Add(Me.lbSamplesQtyTotal)
            Me.Controls.Add(Me.txtAnimalsQtyTotal)
            Me.Controls.Add(Me.LabelControl1)
            Me.Controls.Add(Me.DiagnosisPopupContainer)
            Me.Controls.Add(Me.SamplesPopupContainer)
            Me.Controls.Add(Me.btnDelete)
            Me.Controls.Add(Me.AsSummaryGrid)
            Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
            Me.Name = "AsSessionSummaryPanel"
            Me.Status = bv.common.win.FormStatus.Draft
            CType(Me.AsSummaryGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AsSummaryView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtFarmCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSex, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtQtyEditor, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSamples, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SamplesPopupContainer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SamplesPopupContainer.ResumeLayout(False)
            CType(Me.SamplesList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DiagnosisPopupContainer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DiagnosisPopupContainer.ResumeLayout(False)
            CType(Me.DiagnosisList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtAnimalsQtyTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtSamplesQtyTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPositiveQtyTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents AsSummaryGrid As DevExpress.XtraGrid.GridControl
        Friend WithEvents AsSummaryView As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents colFarmID As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtFarmCode As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colSex As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSex As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colSampledAnimalsQty As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtQtyEditor As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents colCollectionDate As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents dtCollectionDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents colPositiveQty As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
        Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSamples As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
        Friend WithEvents SamplesPopupContainer As DevExpress.XtraEditors.PopupContainerControl
        Friend WithEvents SamplesList As DevExpress.XtraEditors.CheckedListBoxControl
        Friend WithEvents DiagnosisPopupContainer As DevExpress.XtraEditors.PopupContainerControl
        Friend WithEvents DiagnosisList As DevExpress.XtraEditors.CheckedListBoxControl
        Friend WithEvents btnCopySamples As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClearSamples As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnPasteSamples As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCopyDiagnosis As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnClearDiagnosis As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnPasteDiagnosis As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnOkSamples As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnOkdiagnosis As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents colSamplesQty As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtAnimalsQtyTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtSamplesQtyTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbSamplesQtyTotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtPositiveQtyTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbPositiveQtyTotal As DevExpress.XtraEditors.LabelControl

    End Class
End Namespace