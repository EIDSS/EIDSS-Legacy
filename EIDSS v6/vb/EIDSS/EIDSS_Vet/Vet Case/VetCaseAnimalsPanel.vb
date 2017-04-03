Imports System.ComponentModel
Imports bv.common.db
Imports System.Collections.Generic
Imports EIDSS.FlexibleForms.DataBase
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.winclient.Localization
Imports DevExpress.XtraGrid.Views.Grid

Public Class VetCaseAnimalsPanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public AnimalsDbService As VetCaseAnimals_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AnimalsDbService = New VetCaseAnimals_DB
        DbService = AnimalsDbService
        RegisterChildObject(ffAnimalClinicalSigns, RelatedPostOrder.PostLast)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cbAnimalAge As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbAnimalGender As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbAnimalSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmdDeleteAnimal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AnimalsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents cbHerds As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ffAnimalClinicalSigns As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents btnPaste As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AnimalsGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cbClinicalSigns As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents ClincalSignsContainer As DevExpress.XtraEditors.PopupContainerControl
    Friend WithEvents AnimalView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAnimalHerdID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalAge As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalGender As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClinicalSigns As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents commandPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbAnimalStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseAnimalsPanel))
        Me.AnimalsGrid = New DevExpress.XtraGrid.GridControl()
        Me.AnimalView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAnimalHerdID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbHerds = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAnimalID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnimalAge = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalAge = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAnimalGender = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalGender = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAnimalSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAnimalStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colClinicalSigns = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbClinicalSigns = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.ClincalSignsContainer = New DevExpress.XtraEditors.PopupContainerControl()
        Me.commandPanel = New DevExpress.XtraEditors.PanelControl()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.ffAnimalClinicalSigns = New eidss.FlexibleForms.FFPresenter()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPaste = New DevExpress.XtraEditors.SimpleButton()
        Me.AnimalsGroup = New DevExpress.XtraEditors.GroupControl()
        Me.cmdDeleteAnimal = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.AnimalsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbHerds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalGender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbClinicalSigns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClincalSignsContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ClincalSignsContainer.SuspendLayout()
        CType(Me.commandPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.commandPanel.SuspendLayout()
        CType(Me.AnimalsGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalsGroup.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetCaseAnimalsPanel), resources)
        'Form Is Localizable: True
        '
        'AnimalsGrid
        '
        resources.ApplyResources(Me.AnimalsGrid, "AnimalsGrid")
        Me.AnimalsGrid.MainView = Me.AnimalView
        Me.AnimalsGrid.Name = "AnimalsGrid"
        Me.AnimalsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbAnimalAge, Me.cbAnimalGender, Me.cbAnimalSpecies, Me.cbHerds, Me.cbAnimalStatus, Me.cbClinicalSigns})
        Me.AnimalsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AnimalView})
        '
        'AnimalView
        '
        Me.AnimalView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAnimalHerdID, Me.colAnimalID, Me.colAnimalAge, Me.colAnimalGender, Me.colAnimalSpecies, Me.colAnimalStatus, Me.colClinicalSigns})
        Me.AnimalView.GridControl = Me.AnimalsGrid
        Me.AnimalView.Name = "AnimalView"
        Me.AnimalView.OptionsBehavior.AutoPopulateColumns = False
        Me.AnimalView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.AnimalView.OptionsFilter.AllowMRUFilterList = False
        Me.AnimalView.OptionsMenu.EnableColumnMenu = False
        Me.AnimalView.OptionsMenu.EnableFooterMenu = False
        Me.AnimalView.OptionsMenu.EnableGroupPanelMenu = False
        Me.AnimalView.OptionsNavigation.EnterMoveNextColumn = True
        Me.AnimalView.OptionsView.ShowGroupPanel = False
        Me.AnimalView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        '
        'colAnimalHerdID
        '
        Me.colAnimalHerdID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimalHerdID, "colAnimalHerdID")
        Me.colAnimalHerdID.ColumnEdit = Me.cbHerds
        Me.colAnimalHerdID.FieldName = "idfHerd"
        Me.colAnimalHerdID.Name = "colAnimalHerdID"
        '
        'cbHerds
        '
        resources.ApplyResources(Me.cbHerds, "cbHerds")
        Me.cbHerds.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbHerds.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbHerds.Name = "cbHerds"
        '
        'colAnimalID
        '
        Me.colAnimalID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimalID, "colAnimalID")
        Me.colAnimalID.FieldName = "strAnimalCode"
        Me.colAnimalID.Name = "colAnimalID"
        Me.colAnimalID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colAnimalID.OptionsFilter.AllowFilter = False
        '
        'colAnimalAge
        '
        Me.colAnimalAge.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimalAge, "colAnimalAge")
        Me.colAnimalAge.ColumnEdit = Me.cbAnimalAge
        Me.colAnimalAge.FieldName = "idfsAnimalAge"
        Me.colAnimalAge.Name = "colAnimalAge"
        Me.colAnimalAge.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colAnimalAge.OptionsFilter.AllowFilter = False
        '
        'cbAnimalAge
        '
        resources.ApplyResources(Me.cbAnimalAge, "cbAnimalAge")
        Me.cbAnimalAge.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalAge.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalAge.Name = "cbAnimalAge"
        '
        'colAnimalGender
        '
        Me.colAnimalGender.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimalGender, "colAnimalGender")
        Me.colAnimalGender.ColumnEdit = Me.cbAnimalGender
        Me.colAnimalGender.FieldName = "idfsAnimalGender"
        Me.colAnimalGender.Name = "colAnimalGender"
        Me.colAnimalGender.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colAnimalGender.OptionsFilter.AllowFilter = False
        '
        'cbAnimalGender
        '
        resources.ApplyResources(Me.cbAnimalGender, "cbAnimalGender")
        Me.cbAnimalGender.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalGender.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalGender.Name = "cbAnimalGender"
        '
        'colAnimalSpecies
        '
        Me.colAnimalSpecies.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimalSpecies, "colAnimalSpecies")
        Me.colAnimalSpecies.ColumnEdit = Me.cbAnimalSpecies
        Me.colAnimalSpecies.FieldName = "idfSpecies"
        Me.colAnimalSpecies.Name = "colAnimalSpecies"
        Me.colAnimalSpecies.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colAnimalSpecies.OptionsFilter.AllowFilter = False
        '
        'cbAnimalSpecies
        '
        resources.ApplyResources(Me.cbAnimalSpecies, "cbAnimalSpecies")
        Me.cbAnimalSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalSpecies.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalSpecies.Name = "cbAnimalSpecies"
        '
        'colAnimalStatus
        '
        resources.ApplyResources(Me.colAnimalStatus, "colAnimalStatus")
        Me.colAnimalStatus.ColumnEdit = Me.cbAnimalStatus
        Me.colAnimalStatus.FieldName = "idfsAnimalCondition"
        Me.colAnimalStatus.Name = "colAnimalStatus"
        '
        'cbAnimalStatus
        '
        resources.ApplyResources(Me.cbAnimalStatus, "cbAnimalStatus")
        Me.cbAnimalStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAnimalStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalStatus.Name = "cbAnimalStatus"
        '
        'colClinicalSigns
        '
        resources.ApplyResources(Me.colClinicalSigns, "colClinicalSigns")
        Me.colClinicalSigns.ColumnEdit = Me.cbClinicalSigns
        Me.colClinicalSigns.FieldName = "idfObservation"
        Me.colClinicalSigns.Name = "colClinicalSigns"
        Me.colClinicalSigns.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'cbClinicalSigns
        '
        Me.cbClinicalSigns.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbClinicalSigns.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbClinicalSigns.CloseOnOuterMouseClick = False
        Me.cbClinicalSigns.Mask.EditMask = resources.GetString("cbClinicalSigns.Mask.EditMask")
        Me.cbClinicalSigns.Mask.IgnoreMaskBlank = CType(resources.GetObject("cbClinicalSigns.Mask.IgnoreMaskBlank"), Boolean)
        Me.cbClinicalSigns.Mask.SaveLiteral = CType(resources.GetObject("cbClinicalSigns.Mask.SaveLiteral"), Boolean)
        Me.cbClinicalSigns.Mask.ShowPlaceHolders = CType(resources.GetObject("cbClinicalSigns.Mask.ShowPlaceHolders"), Boolean)
        Me.cbClinicalSigns.Name = "cbClinicalSigns"
        Me.cbClinicalSigns.PopupControl = Me.ClincalSignsContainer
        Me.cbClinicalSigns.PopupSizeable = False
        Me.cbClinicalSigns.ShowPopupCloseButton = False
        '
        'ClincalSignsContainer
        '
        Me.ClincalSignsContainer.Controls.Add(Me.commandPanel)
        Me.ClincalSignsContainer.Controls.Add(Me.ffAnimalClinicalSigns)
        Me.ClincalSignsContainer.Controls.Add(Me.btnCopy)
        Me.ClincalSignsContainer.Controls.Add(Me.btnClear)
        Me.ClincalSignsContainer.Controls.Add(Me.btnPaste)
        resources.ApplyResources(Me.ClincalSignsContainer, "ClincalSignsContainer")
        Me.ClincalSignsContainer.Name = "ClincalSignsContainer"
        '
        'commandPanel
        '
        Me.commandPanel.Appearance.BackColor = CType(resources.GetObject("commandPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.commandPanel.Appearance.Options.UseBackColor = True
        Me.commandPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.commandPanel.Controls.Add(Me.btnOk)
        resources.ApplyResources(Me.commandPanel, "commandPanel")
        Me.commandPanel.Name = "commandPanel"
        '
        'btnOk
        '
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.Name = "btnOk"
        '
        'ffAnimalClinicalSigns
        '
        resources.ApplyResources(Me.ffAnimalClinicalSigns, "ffAnimalClinicalSigns")
        Me.ffAnimalClinicalSigns.DelayedLoadingNeeded = False
        Me.ffAnimalClinicalSigns.DynamicParameterEnabled = False
        Me.ffAnimalClinicalSigns.FormID = Nothing
        Me.ffAnimalClinicalSigns.HelpTopicID = Nothing
        Me.ffAnimalClinicalSigns.KeyFieldName = Nothing
        Me.ffAnimalClinicalSigns.MultiSelect = False
        Me.ffAnimalClinicalSigns.Name = "ffAnimalClinicalSigns"
        Me.ffAnimalClinicalSigns.ObjectName = Nothing
        Me.ffAnimalClinicalSigns.SectionTableCaptionsIsVisible = True
        Me.ffAnimalClinicalSigns.TableName = Nothing
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Image = Global.eidss.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.TabStop = False
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Image = Global.eidss.My.Resources.Resources.Clear_Cancel_Changes1
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabStop = False
        '
        'btnPaste
        '
        resources.ApplyResources(Me.btnPaste, "btnPaste")
        Me.btnPaste.Image = Global.eidss.My.Resources.Resources.paste
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.TabStop = False
        '
        'AnimalsGroup
        '
        Me.AnimalsGroup.Appearance.BackColor = CType(resources.GetObject("AnimalsGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.AnimalsGroup.Appearance.Options.UseBackColor = True
        Me.AnimalsGroup.AppearanceCaption.Options.UseFont = True
        Me.AnimalsGroup.Controls.Add(Me.ClincalSignsContainer)
        Me.AnimalsGroup.Controls.Add(Me.cmdDeleteAnimal)
        Me.AnimalsGroup.Controls.Add(Me.AnimalsGrid)
        resources.ApplyResources(Me.AnimalsGroup, "AnimalsGroup")
        Me.AnimalsGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.AnimalsGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.AnimalsGroup.Name = "AnimalsGroup"
        Me.AnimalsGroup.TabStop = True
        '
        'cmdDeleteAnimal
        '
        resources.ApplyResources(Me.cmdDeleteAnimal, "cmdDeleteAnimal")
        Me.cmdDeleteAnimal.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.cmdDeleteAnimal.Name = "cmdDeleteAnimal"
        '
        'VetCaseAnimalsPanel
        '
        Me.Controls.Add(Me.AnimalsGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "VetCaseAnimalsPanel"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        CType(Me.AnimalsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbHerds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalGender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbClinicalSigns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClincalSignsContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ClincalSignsContainer.ResumeLayout(False)
        CType(Me.commandPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.commandPanel.ResumeLayout(False)
        CType(Me.AnimalsGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalsGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Protected Overrides Sub DefineBinding()
        AnimalsGrid.DataSource = baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals)
        Core.LookupBinder.BindAnimalAgeRepositoryLookup(cbAnimalAge, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalGender, BaseReferenceType.rftAnimalSex, HACode.Livestock, False)
        'Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalSpecies, BaseReferenceType.rftSpeciesList, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalStatus, BaseReferenceType.rftAnimalCondition, HACode.Livestock, False)
        BindSpeciesLookup()
        BindHerdsLookup()
        eventManager.AttachDataHandler(VetCaseAnimals_DB.TableVetCaseAnimals + ".idfSpecies", AddressOf Species_Changed)
        eventManager.AttachDataHandler(VetCaseAnimals_DB.TableVetCaseAnimals + ".idfHerd", AddressOf Herd_Changed)
        eventManager.AttachDataHandler(VetCaseAnimals_DB.TableVetCaseAnimals + ".strAnimalCode", AddressOf Animal_Changed)
        UpdateButtons()
        If [ReadOnly] Then
            btnCopy.Enabled = False
            btnClear.Enabled = False
            'cmdDeleteAnimal.Enabled = False
            ''cmdNewAnimal.Enabled = False
            'AnimalView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub Animal_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        RaiseEvent AnimalInfoChanged(Me, New Data.DataRowChangeEventArgs(e.Row, DataRowAction.Change))
    End Sub

    Private Sub Herd_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not cbAnimalSpecies.DataSource Is Nothing Then
            If e.Value Is DBNull.Value Then
                e.Row("idfSpecies") = DBNull.Value
                e.Row.EndEdit()
                Return
            End If
            If (Not e.Row("idfSpecies") Is DBNull.Value) Then
                Dim rows As DataRow() = CType(cbAnimalSpecies.DataSource, DataView).Table.Select(String.Format("idfHerd = {0} and idfsReference={1}", e.Value, e.Row("idfsSpeciesType")))
                If rows.Length = 0 Then
                    e.Row("idfSpecies") = DBNull.Value
                Else
                    e.Row("idfSpecies") = rows(0)("idfSpecies")
                End If
                e.Row.EndEdit()
            End If
        End If
    End Sub

    'I assume that HerdsList contains  DataView with fields idfParty and strName
    'HerdsList should be inititialized in the parent form
    'Right for now it is assumed that this is filtered view that is taken from the FarmTreePanel.baseDataset
    Private Sub BindHerdsLookup()
        cbHerds.Columns.Clear()
        cbHerds.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
            New DevExpress.XtraEditors.Controls.LookUpColumnInfo("strName", HerdCaption, 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        )
        cbHerds.PopupWidth = 400
        cbHerds.DataSource = HerdsList
        cbHerds.DisplayMember = "strName"
        cbHerds.ValueMember = "idfParty"
        cbHerds.NullText = ""
        Core.LookupBinder.AddLookupClosedHandler(cbHerds)
    End Sub

    Dim m_HerdsList As DataView
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property HerdsList() As DataView
        Get
            Return m_HerdsList
        End Get
        Set(ByVal Value As DataView)
            m_HerdsList = Value
            cbHerds.DataSource = m_HerdsList
            UpdateButtons()
        End Set
    End Property

    'I assume that SpeciesList contains  DataView with fields idfSpecies, idfHerd and Name
    'HerdsList should be inititialized in the parent form
    'Right for now it is assumed that this is filtered view that is taken from the FarmTreePanel.baseDataset
    Private Sub BindSpeciesLookup()
        cbAnimalSpecies.Columns.Clear()
        cbAnimalSpecies.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
            New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        )
        cbAnimalSpecies.PopupWidth = 200
        cbAnimalSpecies.DataSource = SpeciesList
        cbAnimalSpecies.DisplayMember = "name"
        cbAnimalSpecies.ValueMember = "idfSpecies"
        cbAnimalSpecies.NullText = ""
        Core.LookupBinder.AddLookupClosedHandler(cbAnimalSpecies)

    End Sub

    Dim m_SpeciesList As DataView
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SpeciesList() As DataView
        Get
            Return m_SpeciesList
        End Get
        Set(ByVal Value As DataView)
            m_SpeciesList = Value
            cbAnimalSpecies.DataSource = m_SpeciesList
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property DefaultHerd() As Object
        Get
            Try

                If m_HerdsList Is Nothing Then Return DBNull.Value
                If m_HerdsList.Count > 0 Then
                    Return m_HerdsList(0).Row("idfParty")
                Else
                    Return DBNull.Value
                End If
            Catch ex As Exception
                Return DBNull.Value
            End Try
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property AnimalsList() As DataView
        Get
            Return New DataView(baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals))
        End Get
    End Property


    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property HerdCaption() As String
        Get
            Return Me.colAnimalHerdID.Caption ' EidssMessages.Get("strHerd")
        End Get
    End Property
    Private m_FreezeEvents As Boolean = False
    Private m_EnterClickHandler As Boolean = False
    Private Sub cmdNewAnimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Not m_EnterClickHandler) Then
            m_FreezeEvents = True
            m_EnterClickHandler = True
            Me.Enabled = False
            Dim row As DataRow = Nothing
            Try
                row = AnimalsDbService.NewAnimal(baseDataSet, DefaultHerd)
                DxControlsHelper.SetRowHandleForDataRow(AnimalView, row, "idfAnimal")
                RaiseEvent AnimalStateChanged(Me, New Data.DataRowChangeEventArgs(row, DataRowAction.Add))
            Finally
                m_FreezeEvents = False
                'RefreshFlexibleForm()
                If Not row Is Nothing Then
                    SetFlexibleFormVisibility(True)
                    ShowFlexibleForm(row, True)
                End If
                m_EnterClickHandler = False
                Me.Enabled = True
            End Try
        End If
    End Sub

    Public Event AnimalStateChanged As DataRowChangeEventHandler
    Public Event AnimalInfoChanged As DataRowChangeEventHandler
    Public Event OnDeleteAnimal As RowCollectionChangedHandler
    Private Sub cmdDeleteAnimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteAnimal.Click
        If AnimalView.FocusedRowHandle < 0 Then Return
        Dim row As DataRow = AnimalView.GetDataRow(AnimalView.FocusedRowHandle)
        If row Is Nothing Then Return
        Dim args As New DataRowEventArgs(row)
        RaiseEvent OnDeleteAnimal(Me, args)
        If args.Cancel Then
            ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantDeleteAnimal", "This animal can't be deleted."))
            Return
        End If
        If MessageForm.Show(EidssMessages.Get("msgConfermCaseAnimalDelete", "The animal, all samples and tests related with this animal will be deleted. Delete animal?"), EidssMessages.Get("titleDeleteAnimal", "Delete Animal"), MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
        End If
        RaiseEvent AnimalStateChanged(Me, New Data.DataRowChangeEventArgs(row, DataRowAction.Delete))
        row.Delete()
    End Sub
    Public Sub Clear()
        AnimalsDbService.Clear(baseDataSet)
    End Sub
    Private m_DiagnosisID As Long = -1
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisID() As Long
        Set(ByVal Value As Long)
            If m_DiagnosisID <> Value Then
                m_DiagnosisID = Value
                'If Not RootBaseForm.Loading Then
                '    For Each row As DataRow In baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Rows
                '        row("idfsFormTemplate") = DBNull.Value
                '    Next
                'End If
                'RefreshFlexibleForm()
            End If
        End Set
    End Property

    Private ReadOnly Property AnimalRow() As DataRow
        Get
            Return AnimalView.GetDataRow(AnimalView.FocusedRowHandle)
        End Get
    End Property
    Private ReadOnly Property AnimalRowView() As DataRowView
        Get
            If AnimalView.FocusedRowHandle < 0 Then Return Nothing
            Return CType(AnimalView.GetRow(AnimalView.FocusedRowHandle), DataRowView)
        End Get
    End Property

#Region "Flexible Forms Support"

    Private Sub RefreshFlexibleForm()
        If Loading OrElse m_FreezeEvents Then Return
        Dim rview As DataRowView = AnimalRowView
        If rview Is Nothing Then
            SetFlexibleFormVisibility(False)
            Return
        End If
        SetFlexibleFormVisibility(True)
        For Each row As DataRow In baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Rows
            ShowFlexibleForm(row, True)
        Next
    End Sub

    Private Sub ShowFlexibleForm(ByVal row As DataRow, ByVal showImmediatly As Boolean)
        If row.RowState = DataRowState.Deleted Then
            Return
        End If
        SetFlexibleFormVisibility(True)
        Dim objectId As Long
        If row("idfObservation") Is DBNull.Value Then
            row("idfObservation") = BaseDbService.NewIntID
        End If
        objectId = CLng(row("idfObservation"))
        ffAnimalClinicalSigns.Visible = True
        If row("idfsFormTemplate") Is DBNull.Value Then
            ffAnimalClinicalSigns.ShowFlexibleFormByDeterminant(-1, objectId, FFType.LivestockAnimalCS) 'm_DiagnosisID
            If ffAnimalClinicalSigns.TemplateID.HasValue AndAlso ffAnimalClinicalSigns.TemplateID.Value > 0 Then
                row("idfsFormTemplate") = ffAnimalClinicalSigns.TemplateID
            End If
        Else
            ffAnimalClinicalSigns.ShowFlexibleForm(CLng(row("idfsFormTemplate")), objectId, FFType.LivestockAnimalCS, True, showImmediatly)
        End If

    End Sub


    Private Sub SetFlexibleFormVisibility(ByVal aVisible As Boolean)
        Me.ffAnimalClinicalSigns.Visible = aVisible
        btnClear.Visible = aVisible
        btnCopy.Visible = aVisible
        btnPaste.Visible = aVisible
    End Sub


    Protected Overrides Sub AfterLoad()
        For Each row As DataRow In baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Rows
            ShowFlexibleForm(row, True)
        Next
    End Sub

    Dim m_Updating As Boolean
    Private Sub AnimalView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AnimalView.FocusedRowChanged
        'RefreshFlexibleForm()
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsRowValid(e.PrevFocusedRowHandle) = False Then
                AnimalView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            UpdateButtons()
            m_Updating = False
        End Try
    End Sub
#End Region

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return Nothing
    End Function

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        'cmdNewAnimal.Enabled = Not [ReadOnly] AndAlso Not DefaultHerd Is DBNull.Value
        Me.btnPaste.Enabled = Me.ffAnimalClinicalSigns.CanPaste
        'Dim observationId As Object = AnimalRow("idfObservation")
        'Dim dataExists As Boolean = False
        'If ffAnimalClinicalSigns.MainDbService.MainDataSet.ActivityParameters.Select(String.Format("idfObservation = {0}", observationId)).Length > 0 Then
        '    dataExists = True
        'End If
        'btnCopy.Enabled = dataExists

    End Sub
    Private Function IsRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = AnimalView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = AnimalView.GetDataRow(index)
        If row Is Nothing Then Return True
        Return IsRowValid(row, showError)
    End Function
    Private Function IsRowValid(row As DataRow, Optional ByVal showError As Boolean = True) As Boolean
        If row Is Nothing Then Return True
        If (row("idfHerd") Is DBNull.Value) Then
            Dim errMsg As String = ""
            If (showError) Then
                errMsg = EidssMessages.Get("ErrNoHerdForAnimalLiveStock", "There is an animal in the animals list that is not linked to the specific herd. Please link each animal to the herd.")
                ErrorForm.ShowWarningDirect(errMsg)
            End If
            Return False
        End If
        If row("idfSpecies") Is DBNull.Value Then
            If showError Then
                ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrAnimalSpeciesIsNotDefined", "There is an animal with undefined species type. Please select the species type for each animal in the list."))
            End If
            Return False
        End If

        Return True
    End Function

    Public Overrides Function ValidateData() As Boolean
        For Each row As DataRow In baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Rows
            If (row.RowState <> DataRowState.Deleted) Then
                If Not IsRowValid(row, True) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function


    'Private Sub AnimalView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AnimalView.ShowingEditor
    '    If Closing Then Return
    '    If Not cbAnimalSpecies.DataSource Is Nothing Then
    '        CType(cbAnimalSpecies.DataSource, DataView).RowFilter = String.Format("idfHerd = {0}", AnimalRow("idfHerd")) 'GetHerdSpeciesFilter(AnimalRow("idfHerd"))
    '    End If
    'End Sub
    Private Sub cbAnimalSpecies_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbAnimalSpecies.QueryPopUp
        If Not cbAnimalSpecies.DataSource Is Nothing Then
            CType(cbAnimalSpecies.DataSource, DataView).RowFilter = String.Format("idfHerd = {0}", AnimalRow("idfHerd")) 'GetHerdSpeciesFilter(AnimalRow("idfHerd"))
        End If
    End Sub
    Private Sub cbAnimalSpecies_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbAnimalSpecies.CloseUp
        If Not cbAnimalSpecies.DataSource Is Nothing Then
            CType(cbAnimalSpecies.DataSource, DataView).RowFilter = ""
        End If
    End Sub

    'Private Sub AnimalView_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimalView.HiddenEditor
    '    If Not cbAnimalSpecies.DataSource Is Nothing Then
    '        CType(cbAnimalSpecies.DataSource, DataView).RowFilter = ""
    '    End If
    'End Sub
    Public Delegate Function GetObjectFilterHandler(ByVal ObjectId As Object) As String
    Public GetHerdSpeciesFilter As GetObjectFilterHandler

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (WinUtils.ConfirmMessage(EidssMessages.Get("msgClearFF", "Panel content will be cleared. Clear it?"), EidssMessages.Get("msgClearFFCaption", "Clear panel"))) Then
            ffAnimalClinicalSigns.Clear()
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        ffAnimalClinicalSigns.Copy()
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        ffAnimalClinicalSigns.Paste()
    End Sub



    Private Sub cbClinicalSigns_QueryDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs) Handles cbClinicalSigns.QueryDisplayText
        If Closing Then
            Return
        End If
        Dim objectId As String
        objectId = Utils.Str(e.EditValue)

        ' To avoid empty ID in the Flex Form Hash
        If objectId = "" Then
            e.DisplayText = ""
            Return
        End If

        Dim text As New System.Text.StringBuilder
        Dim parametersView As DataView = ffAnimalClinicalSigns.ActivityParameters.DefaultView
        Dim parameterTemplate As FlexibleFormsDS.ParameterTemplateDataTable = ffAnimalClinicalSigns.ParameterTemplate
        parametersView.RowFilter = String.Format("idfObservation = {0}", objectId)
        For Each r As DataRowView In parametersView
            If Utils.Str(r("varValue")) = "True" Then
                Dim param As Object = parameterTemplate.FindByidfsParameteridfsFormTemplatelangid(CLng(r("idfsParameter")), CLng(ffAnimalClinicalSigns.TemplateID), bv.model.Model.Core.ModelUserContext.CurrentLanguage)("NationalName")
                If text.Length = 0 Then
                    text.Append(Utils.Str(param))
                Else
                    text.AppendFormat(",{0}", Utils.Str(param))
                End If
            End If
        Next
        e.DisplayText = text.ToString
        parametersView.RowFilter = ""
    End Sub

    Private Sub cbClinicalSigns_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbClinicalSigns.QueryPopUp
        SetFlexibleFormVisibility(True)
        btnPaste.Enabled = ffAnimalClinicalSigns.CanPaste
        Me.ShowFlexibleForm(AnimalRow, False)
    End Sub


    Private Sub Species_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not m_SpeciesList Is Nothing Then
            m_SpeciesList.Sort = "idfSpecies"
            Dim i As Integer = m_SpeciesList.Find(e.Value)
            If i >= 0 Then
                e.Row("idfsSpeciesType") = m_SpeciesList(i)("idfsReference")
                If Not e.Row("idfsAnimalAge") Is DBNull.Value AndAlso _
                    (CType(cbAnimalAge.DataSource, DataView)).Table.Select( _
                    String.Format("idfsSpeciesType = {0} and idfsReference = {1}", e.Row("idfsSpeciesType"), e.Row("idfsAnimalAge")) _
                    ).Length = 0 Then
                    e.Row("idfsAnimalAge") = DBNull.Value
                    e.Row.EndEdit()
                End If
                e.Row("strSpecies") = m_SpeciesList(i)("strSpecies")
            End If
        End If
        Animal_Changed(sender, e)
    End Sub
    Private Sub cbAnimalGender_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnimalGender.EditValueChanged
        If IsDesignMode() OrElse Loading Then Return
        AnimalRow("strGender") = CType(sender, DevExpress.XtraEditors.BaseEdit).Text
    End Sub

    'Private Sub cbAnimalSpecies_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnimalSpecies.EditValueChanged
    '    If IsDesignMode() OrElse Loading Then Return
    '    AnimalRow("strSpecies") = CType(sender, DevExpress.XtraEditors.BaseEdit).Text
    'End Sub
    Private Sub cbAnimalSpecies_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbAnimalSpecies.EditValueChanging
        If Not Utils.IsEmpty(e.NewValue) AndAlso Not CaseSamples_Db.CheckAccessionForSpecies(CLng(e.NewValue)) Then
            MessageForm.Show(String.Format(EidssMessages.Get("msgCantChangeAnimalSpecies", "Can't change species. There are accessioned samples that belongs to this animal.")))
            e.Cancel = True
        End If
    End Sub

    Public Function CanDeleteFarmTreeNode(ByVal row As DataRow) As Boolean
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Farm
                Return False
            Case PartyType.Herd
                If baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Select(String.Format("idfHerd={0}", row("idfParty").ToString)).Length > 0 Then
                    Return False
                End If
            Case PartyType.Species
                If baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Select(String.Format("idfHerd={0} and idfSpecies={1}", row("idfParentParty").ToString, Utils.Str(row("idfParty")))).Length > 0 Then
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not AnimalsGrid.FocusedView.ActiveEditor Is Nothing AndAlso TypeOf AnimalsGrid.FocusedView.ActiveEditor Is PopupContainerEdit AndAlso CType(AnimalsGrid.FocusedView.ActiveEditor, PopupContainerEdit).IsPopupOpen Then
            CType(AnimalsGrid.FocusedView.ActiveEditor, PopupContainerEdit).ClosePopup()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not AnimalsGrid.FocusedView.ActiveEditor Is Nothing AndAlso TypeOf AnimalsGrid.FocusedView.ActiveEditor Is PopupContainerEdit AndAlso CType(AnimalsGrid.FocusedView.ActiveEditor, PopupContainerEdit).IsPopupOpen Then
            CType(AnimalsGrid.FocusedView.ActiveEditor, PopupContainerEdit).ClosePopup()
        End If
    End Sub

    Private Sub VetCaseAnimalsPanel_OnAfterPost(sender As Object, e As System.EventArgs) Handles Me.OnAfterPost
        For Each row As DataRow In baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Rows
            Animal_Changed(Nothing, New DataFieldChangeEventArgs(row, baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals).Columns("strAnimalCode"), row("strAnimalCode"), row("strAnimalCode")))
        Next
    End Sub
    Private Sub AnimalView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles AnimalView.InitNewRow
        Dim row As DataRow = AnimalView.GetDataRow(e.RowHandle)
        AnimalsDbService.InitRow(row, DefaultHerd, baseDataSet.Tables(VetCaseAnimals_DB.TableVetCaseAnimals))
        If Not row Is Nothing Then
            SetFlexibleFormVisibility(True)
            ShowFlexibleForm(row, True)
        End If
        RaiseEvent AnimalStateChanged(Me, New Data.DataRowChangeEventArgs(row, DataRowAction.Add))
    End Sub

    Public Sub UpdateButtons()
        Dim rowSelected As Boolean = AnimalView.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso Not AnimalView.GetFocusedDataRow() Is Nothing
        cmdDeleteAnimal.Enabled = Not [ReadOnly] AndAlso rowSelected
        AnimalView.OptionsBehavior.Editable = Not [ReadOnly]
        EnableRowAdding(Not [ReadOnly] AndAlso Not DefaultHerd Is DBNull.Value AndAlso IsRowValid(, False))
    End Sub

    Public Sub EnableRowAdding(enable As Boolean)
        If (AnimalView.FocusedRowHandle = GridControl.NewItemRowHandle) Then
            Return
        End If
        If (Not enable) Then
            AnimalView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Else
            AnimalView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        End If
    End Sub
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            UpdateButtons()
        End Set
    End Property


    Private Sub AnimalView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles AnimalView.ShowingEditor
        If AnimalView.FocusedColumn Is colAnimalID AndAlso Utils.IsEmpty(AnimalView.GetFocusedRowCellValue("idfHerd")) Then
            e.Cancel = True
            Return
        End If
        If Not AnimalView.FocusedColumn Is colAnimalID AndAlso Not AnimalView.FocusedColumn Is colAnimalHerdID AndAlso Utils.IsEmpty(AnimalView.GetFocusedRowCellValue("idfAnimal")) Then
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub VetCaseAnimalsPanel_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If (Visible) Then
            UpdateButtons()
        End If
    End Sub
End Class
