Namespace ActiveSurveillance
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AsSessionTableViewPanel
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsSessionTableViewPanel))
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Me.TableViewGrid = New DevExpress.XtraGrid.GridControl()
            Me.TableView = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colFarmID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtFarmID = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colAnimalID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbAnimalCode = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
            Me.cbAnimalAge1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.cbAnimalSex1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.AnimalDropdownView = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colAnimalID1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalAge1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colColor1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalSex1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalName1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalAge = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbAnimalAge = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colAnimalColor = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalSex = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbAnimalSex = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colAnimalName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colAnimalComment = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtAnimalComment = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
            Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSampleType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.colFieldSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colCollectionDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.dtCollectionDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.colSentToOffice = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.cbSentToOffice = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
            Me.txtAnimalCopyCount = New DevExpress.XtraEditors.SpinEdit()
            Me.btnCopyAnimal = New DevExpress.XtraEditors.SimpleButton()
            Me.txtSamplesQtyTotal = New DevExpress.XtraEditors.TextEdit()
            Me.lbSamplesQtyTotal = New DevExpress.XtraEditors.LabelControl()
            Me.txtAnimalsQtyTotal = New DevExpress.XtraEditors.TextEdit()
            Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
            CType(Me.TableViewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TableView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtFarmID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbAnimalCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbAnimalAge1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbAnimalSex1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AnimalDropdownView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbAnimalAge, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbAnimalSex, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtAnimalComment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSampleType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtCollectionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cbSentToOffice, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtAnimalCopyCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtSamplesQtyTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtAnimalsQtyTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AsSessionTableViewPanel), resources)
            'Form Is Localizable: True
            '
            'TableViewGrid
            '
            resources.ApplyResources(Me.TableViewGrid, "TableViewGrid")
            Me.TableViewGrid.Cursor = System.Windows.Forms.Cursors.Default
            Me.TableViewGrid.MainView = Me.TableView
            Me.TableViewGrid.Name = "TableViewGrid"
            Me.TableViewGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtFarmID, Me.cbSpecies, Me.cbAnimalAge, Me.cbAnimalSex, Me.cbSampleType, Me.dtCollectionDate, Me.cbAnimalCode, Me.txtAnimalComment, Me.cbSentToOffice})
            Me.TableViewGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TableView})
            '
            'TableView
            '
            Me.TableView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFarmID, Me.colSpecies, Me.colAnimalID, Me.colAnimalAge, Me.colAnimalColor, Me.colAnimalSex, Me.colAnimalName, Me.colAnimalComment, Me.colSampleType, Me.colFieldSampleID, Me.colCollectionDate, Me.colSentToOffice})
            Me.TableView.GridControl = Me.TableViewGrid
            Me.TableView.Name = "TableView"
            Me.TableView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            Me.TableView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.TableView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            Me.TableView.OptionsView.ShowGroupPanel = False
            '
            'colFarmID
            '
            resources.ApplyResources(Me.colFarmID, "colFarmID")
            Me.colFarmID.ColumnEdit = Me.txtFarmID
            Me.colFarmID.FieldName = "strFarmCode"
            Me.colFarmID.Name = "colFarmID"
            Me.colFarmID.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
            '
            'txtFarmID
            '
            resources.ApplyResources(Me.txtFarmID, "txtFarmID")
            Me.txtFarmID.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmID.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarmID.Buttons1"), CType(resources.GetObject("txtFarmID.Buttons2"), Integer), CType(resources.GetObject("txtFarmID.Buttons3"), Boolean), CType(resources.GetObject("txtFarmID.Buttons4"), Boolean), CType(resources.GetObject("txtFarmID.Buttons5"), Boolean), CType(resources.GetObject("txtFarmID.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarmID.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtFarmID.Buttons8"), CType(resources.GetObject("txtFarmID.Buttons9"), Object), CType(resources.GetObject("txtFarmID.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarmID.Buttons11"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmID.Buttons12"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarmID.Buttons13"), CType(resources.GetObject("txtFarmID.Buttons14"), Integer), CType(resources.GetObject("txtFarmID.Buttons15"), Boolean), CType(resources.GetObject("txtFarmID.Buttons16"), Boolean), CType(resources.GetObject("txtFarmID.Buttons17"), Boolean), CType(resources.GetObject("txtFarmID.Buttons18"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarmID.Buttons19"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtFarmID.Buttons20"), CType(resources.GetObject("txtFarmID.Buttons21"), Object), CType(resources.GetObject("txtFarmID.Buttons22"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarmID.Buttons23"), Boolean))})
            Me.txtFarmID.Name = "txtFarmID"
            Me.txtFarmID.ReadOnly = True
            Me.txtFarmID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
            'colAnimalID
            '
            resources.ApplyResources(Me.colAnimalID, "colAnimalID")
            Me.colAnimalID.ColumnEdit = Me.cbAnimalCode
            Me.colAnimalID.FieldName = "idfAnimal"
            Me.colAnimalID.Name = "colAnimalID"
            '
            'cbAnimalCode
            '
            resources.ApplyResources(Me.cbAnimalCode, "cbAnimalCode")
            Me.cbAnimalCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalCode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbAnimalCode.DisplayMember = "strAnimalCode"
            Me.cbAnimalCode.Name = "cbAnimalCode"
            Me.cbAnimalCode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbAnimalAge1, Me.cbAnimalSex1})
            Me.cbAnimalCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
            Me.cbAnimalCode.ValueMember = "idfAnimal"
            Me.cbAnimalCode.View = Me.AnimalDropdownView
            '
            'cbAnimalAge1
            '
            resources.ApplyResources(Me.cbAnimalAge1, "cbAnimalAge1")
            Me.cbAnimalAge1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalAge1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbAnimalAge1.Name = "cbAnimalAge1"
            '
            'cbAnimalSex1
            '
            resources.ApplyResources(Me.cbAnimalSex1, "cbAnimalSex1")
            Me.cbAnimalSex1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalSex1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbAnimalSex1.Name = "cbAnimalSex1"
            '
            'AnimalDropdownView
            '
            Me.AnimalDropdownView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAnimalID1, Me.colAnimalAge1, Me.colColor1, Me.colAnimalSex1, Me.colAnimalName1})
            Me.AnimalDropdownView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.AnimalDropdownView.Name = "AnimalDropdownView"
            Me.AnimalDropdownView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.AnimalDropdownView.OptionsView.ShowGroupPanel = False
            '
            'colAnimalID1
            '
            resources.ApplyResources(Me.colAnimalID1, "colAnimalID1")
            Me.colAnimalID1.FieldName = "strAnimalCode"
            Me.colAnimalID1.Name = "colAnimalID1"
            '
            'colAnimalAge1
            '
            resources.ApplyResources(Me.colAnimalAge1, "colAnimalAge1")
            Me.colAnimalAge1.ColumnEdit = Me.cbAnimalAge1
            Me.colAnimalAge1.FieldName = "idfsAnimalAge"
            Me.colAnimalAge1.Name = "colAnimalAge1"
            '
            'colColor1
            '
            resources.ApplyResources(Me.colColor1, "colColor1")
            Me.colColor1.FieldName = "strColor"
            Me.colColor1.Name = "colColor1"
            '
            'colAnimalSex1
            '
            resources.ApplyResources(Me.colAnimalSex1, "colAnimalSex1")
            Me.colAnimalSex1.ColumnEdit = Me.cbAnimalSex1
            Me.colAnimalSex1.FieldName = "idfsAnimalGender"
            Me.colAnimalSex1.Name = "colAnimalSex1"
            '
            'colAnimalName1
            '
            resources.ApplyResources(Me.colAnimalName1, "colAnimalName1")
            Me.colAnimalName1.FieldName = "strName"
            Me.colAnimalName1.Name = "colAnimalName1"
            '
            'colAnimalAge
            '
            resources.ApplyResources(Me.colAnimalAge, "colAnimalAge")
            Me.colAnimalAge.ColumnEdit = Me.cbAnimalAge
            Me.colAnimalAge.FieldName = "idfsAnimalAge"
            Me.colAnimalAge.Name = "colAnimalAge"
            '
            'cbAnimalAge
            '
            resources.ApplyResources(Me.cbAnimalAge, "cbAnimalAge")
            Me.cbAnimalAge.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalAge.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbAnimalAge.Name = "cbAnimalAge"
            '
            'colAnimalColor
            '
            resources.ApplyResources(Me.colAnimalColor, "colAnimalColor")
            Me.colAnimalColor.FieldName = "strColor"
            Me.colAnimalColor.Name = "colAnimalColor"
            '
            'colAnimalSex
            '
            resources.ApplyResources(Me.colAnimalSex, "colAnimalSex")
            Me.colAnimalSex.ColumnEdit = Me.cbAnimalSex
            Me.colAnimalSex.FieldName = "idfsAnimalGender"
            Me.colAnimalSex.Name = "colAnimalSex"
            '
            'cbAnimalSex
            '
            resources.ApplyResources(Me.cbAnimalSex, "cbAnimalSex")
            Me.cbAnimalSex.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalSex.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbAnimalSex.Name = "cbAnimalSex"
            '
            'colAnimalName
            '
            resources.ApplyResources(Me.colAnimalName, "colAnimalName")
            Me.colAnimalName.FieldName = "strName"
            Me.colAnimalName.Name = "colAnimalName"
            '
            'colAnimalComment
            '
            resources.ApplyResources(Me.colAnimalComment, "colAnimalComment")
            Me.colAnimalComment.ColumnEdit = Me.txtAnimalComment
            Me.colAnimalComment.FieldName = "strDescription"
            Me.colAnimalComment.Name = "colAnimalComment"
            '
            'txtAnimalComment
            '
            resources.ApplyResources(Me.txtAnimalComment, "txtAnimalComment")
            Me.txtAnimalComment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtAnimalComment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.txtAnimalComment.Name = "txtAnimalComment"
            Me.txtAnimalComment.ShowIcon = False
            '
            'colSampleType
            '
            resources.ApplyResources(Me.colSampleType, "colSampleType")
            Me.colSampleType.ColumnEdit = Me.cbSampleType
            Me.colSampleType.FieldName = "idfsSampleType"
            Me.colSampleType.Name = "colSampleType"
            '
            'cbSampleType
            '
            resources.ApplyResources(Me.cbSampleType, "cbSampleType")
            Me.cbSampleType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSampleType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSampleType.Name = "cbSampleType"
            '
            'colFieldSampleID
            '
            resources.ApplyResources(Me.colFieldSampleID, "colFieldSampleID")
            Me.colFieldSampleID.FieldName = "strFieldBarcode"
            Me.colFieldSampleID.Name = "colFieldSampleID"
            '
            'colCollectionDate
            '
            resources.ApplyResources(Me.colCollectionDate, "colCollectionDate")
            Me.colCollectionDate.ColumnEdit = Me.dtCollectionDate
            Me.colCollectionDate.FieldName = "datFieldCollectionDate"
            Me.colCollectionDate.Name = "colCollectionDate"
            '
            'dtCollectionDate
            '
            resources.ApplyResources(Me.dtCollectionDate, "dtCollectionDate")
            Me.dtCollectionDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCollectionDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.dtCollectionDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.dtCollectionDate.Name = "dtCollectionDate"
            '
            'colSentToOffice
            '
            resources.ApplyResources(Me.colSentToOffice, "colSentToOffice")
            Me.colSentToOffice.ColumnEdit = Me.cbSentToOffice
            Me.colSentToOffice.FieldName = "idfSendToOffice"
            Me.colSentToOffice.Name = "colSentToOffice"
            '
            'cbSentToOffice
            '
            resources.ApplyResources(Me.cbSentToOffice, "cbSentToOffice")
            Me.cbSentToOffice.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSentToOffice.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.cbSentToOffice.Name = "cbSentToOffice"
            '
            'RepositoryItemComboBox1
            '
            resources.ApplyResources(Me.RepositoryItemComboBox1, "RepositoryItemComboBox1")
            Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemComboBox1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
            Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
            '
            'btnDelete
            '
            resources.ApplyResources(Me.btnDelete, "btnDelete")
            Me.btnDelete.Name = "btnDelete"
            '
            'txtAnimalCopyCount
            '
            resources.ApplyResources(Me.txtAnimalCopyCount, "txtAnimalCopyCount")
            Me.txtAnimalCopyCount.Name = "txtAnimalCopyCount"
            Me.txtAnimalCopyCount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.txtAnimalCopyCount.Properties.IsFloatValue = False
            Me.txtAnimalCopyCount.Properties.Mask.EditMask = resources.GetString("txtAnimalCopyCount.Properties.Mask.EditMask")
            Me.txtAnimalCopyCount.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.txtAnimalCopyCount.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'btnCopyAnimal
            '
            resources.ApplyResources(Me.btnCopyAnimal, "btnCopyAnimal")
            Me.btnCopyAnimal.Image = Global.eidss.My.Resources.Resources.copy
            Me.btnCopyAnimal.Name = "btnCopyAnimal"
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
            'txtAnimalsQtyTotal
            '
            resources.ApplyResources(Me.txtAnimalsQtyTotal, "txtAnimalsQtyTotal")
            Me.txtAnimalsQtyTotal.Name = "txtAnimalsQtyTotal"
            Me.txtAnimalsQtyTotal.Properties.ReadOnly = True
            Me.txtAnimalsQtyTotal.Properties.Tag = "{R}"
            '
            'LabelControl1
            '
            resources.ApplyResources(Me.LabelControl1, "LabelControl1")
            Me.LabelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.LabelControl1.Name = "LabelControl1"
            '
            'AsSessionTableViewPanel
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.txtAnimalsQtyTotal)
            Me.Controls.Add(Me.txtSamplesQtyTotal)
            Me.Controls.Add(Me.lbSamplesQtyTotal)
            Me.Controls.Add(Me.LabelControl1)
            Me.Controls.Add(Me.txtAnimalCopyCount)
            Me.Controls.Add(Me.btnCopyAnimal)
            Me.Controls.Add(Me.btnDelete)
            Me.Controls.Add(Me.TableViewGrid)
            Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
            Me.Name = "AsSessionTableViewPanel"
            Me.Status = bv.common.win.FormStatus.Draft
            CType(Me.TableViewGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TableView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtFarmID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbAnimalCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbAnimalAge1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbAnimalSex1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AnimalDropdownView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbAnimalAge, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbAnimalSex, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtAnimalComment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSampleType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCollectionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cbSentToOffice, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtAnimalCopyCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtSamplesQtyTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtAnimalsQtyTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableViewGrid As DevExpress.XtraGrid.GridControl
        Friend WithEvents TableView As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents colFarmID As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtFarmID As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colAnimalID As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colAnimalAge As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbAnimalAge As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colAnimalColor As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colAnimalSex As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbAnimalSex As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colAnimalName As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSampleType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colFieldSampleID As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colCollectionDate As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents dtCollectionDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents txtAnimalCopyCount As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents btnCopyAnimal As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents colAnimalID1 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colAnimalAge1 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbAnimalAge1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colColor1 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colAnimalSex1 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbAnimalSex1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Friend WithEvents colAnimalName1 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Friend WithEvents txtSamplesQtyTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lbSamplesQtyTotal As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtAnimalsQtyTotal As DevExpress.XtraEditors.TextEdit
        Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cbAnimalCode As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
        Friend WithEvents AnimalDropdownView As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents colAnimalComment As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtAnimalComment As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
        Friend WithEvents colSentToOffice As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents cbSentToOffice As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit


    End Class
End Namespace
