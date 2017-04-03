Imports System.ComponentModel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports bv.common.win.Validators
Imports bv.common.Resources
Imports eidss.model.Resources
Imports eidss.model.Enums
Imports bv.winclient.Localization


Public Class CaseSamplesPanel
    Inherits BaseDetailPanel

    Protected ReadOnly Property CaseSamplesDbService As CaseSamples_Db
        Get
            Return CType(DbService, CaseSamples_Db)
        End Get
    End Property

    Protected WithEvents memoEdit As RepositoryItemMemoExEdit
    Protected WithEvents cbCondition As RepositoryItemLookUpEdit
    Protected WithEvents cbAccessionDate As RepositoryItemDateEdit
    Protected WithEvents colTestsCount As GridColumn
    Protected WithEvents grpSendToOffice As GroupControl
    Friend WithEvents lbSendToOffice As LabelControl
    Protected WithEvents cbSendToOffice As LookUpEdit

    Protected WithEvents colCollectedByInstitution As GridColumn
    Protected WithEvents colCollectedByOfficer As GridColumn
    Protected WithEvents colSentToOrganization As GridColumn
    Protected WithEvents cbCollectedByInstitution As RepositoryItemLookUpEdit
    Protected WithEvents cbCollectedByOfficer As RepositoryItemLookUpEdit
    Protected WithEvents cbSentToOrganization As RepositoryItemLookUpEdit

    'Protected WithEvents colSampleCondition As DevExpress.XtraGrid.Columns.GridColumn
    'Protected WithEvents colConditionReceived As DevExpress.XtraGrid.Columns.GridColumn
    'Protected WithEvents colAccessionedDate As DevExpress.XtraGrid.Columns.GridColumn
    Dim CollectedByOrganizationDataView As DataView
    'Dim CollectedByEmpoyeeDataView As DataView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        DebugTimer.Start("CaseSamplesPanel Constructor")
        InitializeComponent()
        If WinUtils.IsComponentInDesignMode(Me) Then
            DebugTimer.Stop()
            Return
        End If
        'Add any initialization after the InitializeComponent() call
        DbService = New CaseSamples_Db
    End Sub

    'Form overrides dispose to clean up the component list.
    'Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '    If disposing Then
    '        If Not (components Is Nothing) Then
    '            components.Dispose()
    '        End If
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Protected WithEvents CollectedByGroup As DevExpress.XtraEditors.GroupControl

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lbCollectedByOrganization As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCollectedByEmployee As DevExpress.XtraEditors.LabelControl
    Protected WithEvents SamplesGrid As DevExpress.XtraGrid.GridControl
    Protected WithEvents cbCollectedByOrganization As DevExpress.XtraEditors.LookUpEdit
    Protected WithEvents cbCollectedByPerson As DevExpress.XtraEditors.LookUpEdit
    Protected WithEvents btnNewSpecimen As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents btnDeleteSpecimen As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents colAnimal As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbAnimalLookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected WithEvents colSpecimenID As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colSpecimenType As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbSpecimenType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected WithEvents SamplesGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Protected WithEvents pnSpecimenDetail As DevExpress.XtraEditors.GroupControl
    Protected WithEvents colCollectionDate As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents NotesGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtSampleNotes As DevExpress.XtraEditors.MemoEdit
    Protected WithEvents SamplesGroup As DevExpress.XtraEditors.GroupControl
    Protected WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected Friend WithEvents colVectorID As DevExpress.XtraGrid.Columns.GridColumn
    Protected Friend WithEvents cbVectorID As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected Friend WithEvents colVectorType As DevExpress.XtraGrid.Columns.GridColumn
    Protected Friend WithEvents cbVectorType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected WithEvents colSampleCondition As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colConditionReceived As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colAccessionedDate As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents dtCollectionDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(CaseSamplesPanel))
        Me.dtCollectionDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.SamplesGroup = New DevExpress.XtraEditors.GroupControl()
        Me.btnNewSpecimen = New DevExpress.XtraEditors.SimpleButton()
        Me.SamplesGrid = New DevExpress.XtraGrid.GridControl()
        Me.SamplesGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSpecimenID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSpecimenType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecimenType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAnimal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAnimalLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colVectorID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbVectorID = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colVectorType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbVectorType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCollectionDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCondition = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSampleCondition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.memoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colAccessionedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAccessionDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colCollectedByInstitution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCollectedByInstitution = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCollectedByOfficer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCollectedByOfficer = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSentToOrganization = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSentToOrganization = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestsCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDeleteSpecimen = New DevExpress.XtraEditors.SimpleButton()
        Me.pnSpecimenDetail = New DevExpress.XtraEditors.GroupControl()
        Me.grpSendToOffice = New DevExpress.XtraEditors.GroupControl()
        Me.lbSendToOffice = New DevExpress.XtraEditors.LabelControl()
        Me.cbSendToOffice = New DevExpress.XtraEditors.LookUpEdit()
        Me.CollectedByGroup = New DevExpress.XtraEditors.GroupControl()
        Me.lbCollectedByOrganization = New DevExpress.XtraEditors.LabelControl()
        Me.cbCollectedByOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbCollectedByPerson = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbCollectedByEmployee = New DevExpress.XtraEditors.LabelControl()
        Me.NotesGroup = New DevExpress.XtraEditors.GroupControl()
        Me.txtSampleNotes = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesGroup.SuspendLayout()
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSpecimenDetail.SuspendLayout()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSendToOffice.SuspendLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollectedByGroup.SuspendLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NotesGroup.SuspendLayout()
        CType(Me.txtSampleNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        BvResourceManagerChanger.GetResourceManager(GetType(CaseSamplesPanel), resources)
        'Form Is Localizable: True
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                {New DevExpress.XtraEditors.Controls.EditorButton(
                                                    CType(resources.GetObject("dtCollectionDate.Buttons"),
                                                          DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtCollectionDate.Name = "dtCollectionDate"
        Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                                    {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'SamplesGroup
        '
        resources.ApplyResources(Me.SamplesGroup, "SamplesGroup")
        Me.SamplesGroup.Appearance.BackColor = CType(resources.GetObject("SamplesGroup.Appearance.BackColor"),
                                                     System.Drawing.Color)
        Me.SamplesGroup.Appearance.Options.UseBackColor = True
        Me.SamplesGroup.Controls.Add(Me.btnNewSpecimen)
        Me.SamplesGroup.Controls.Add(Me.SamplesGrid)
        Me.SamplesGroup.Controls.Add(Me.btnDeleteSpecimen)
        Me.SamplesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.SamplesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SamplesGroup.Name = "SamplesGroup"
        '
        'btnNewSpecimen
        '
        resources.ApplyResources(Me.btnNewSpecimen, "btnNewSpecimen")
        Me.btnNewSpecimen.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnNewSpecimen.Name = "btnNewSpecimen"
        '
        'SamplesGrid
        '
        resources.ApplyResources(Me.SamplesGrid, "SamplesGrid")
        Me.SamplesGrid.MainView = Me.SamplesGridView
        Me.SamplesGrid.Name = "SamplesGrid"
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() _
                                                   {Me.cbAnimalLookup, Me.cbSpecimenType, Me.cbSpecies, Me.cbVectorID,
                                                    Me.cbVectorType, Me.cbAccessionDate, Me.cbCondition, Me.memoEdit,
                                                    Me.dtCollectionDate, Me.cbCollectedByInstitution,
                                                    Me.cbCollectedByOfficer, Me.cbSentToOrganization})
        Me.SamplesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SamplesGridView})
        '
        'SamplesGridView
        '
        Me.SamplesGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() _
                                               {Me.colSpecimenID, Me.colSpecimenType, Me.colAnimal, Me.colSpecies,
                                                Me.colVectorID, Me.colVectorType, Me.colCollectionDate,
                                                Me.colConditionReceived, Me.colSampleCondition, Me.colAccessionedDate,
                                                Me.colCollectedByInstitution, Me.colCollectedByOfficer,
                                                Me.colSentToOrganization, Me.colTestsCount})
        Me.SamplesGridView.GridControl = Me.SamplesGrid
        resources.ApplyResources(Me.SamplesGridView, "SamplesGridView")
        Me.SamplesGridView.Name = "SamplesGridView"
        Me.SamplesGridView.OptionsBehavior.AutoPopulateColumns = False
        Me.SamplesGridView.OptionsCustomization.AllowFilter = False
        Me.SamplesGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.SamplesGridView.OptionsView.ColumnAutoWidth = False
        Me.SamplesGridView.OptionsView.RowAutoHeight = True
        Me.SamplesGridView.OptionsView.ShowGroupPanel = False
        '
        'colSpecimenID
        '
        Me.colSpecimenID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colSpecimenID, "colSpecimenID")
        Me.colSpecimenID.FieldName = "strFieldBarcode"
        Me.colSpecimenID.Name = "colSpecimenID"
        Me.colSpecimenID.Tag = "[en]"
        '
        'colSpecimenType
        '
        Me.colSpecimenType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colSpecimenType, "colSpecimenType")
        Me.colSpecimenType.ColumnEdit = Me.cbSpecimenType
        Me.colSpecimenType.FieldName = "idfsSampleType"
        Me.colSpecimenType.Name = "colSpecimenType"
        '
        'cbSpecimenType
        '
        resources.ApplyResources(Me.cbSpecimenType, "cbSpecimenType")
        Me.cbSpecimenType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                              {New DevExpress.XtraEditors.Controls.EditorButton(
                                                  CType(resources.GetObject("cbSpecimenType.Buttons"),
                                                        DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecimenType.Name = "cbSpecimenType"
        Me.cbSpecimenType.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick
        '
        'colAnimal
        '
        Me.colAnimal.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colAnimal, "colAnimal")
        Me.colAnimal.ColumnEdit = Me.cbAnimalLookup
        Me.colAnimal.FieldName = "idfParty"
        Me.colAnimal.Name = "colAnimal"
        Me.colAnimal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colAnimal.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'cbAnimalLookup
        '
        resources.ApplyResources(Me.cbAnimalLookup, "cbAnimalLookup")
        Me.cbAnimalLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                              {New DevExpress.XtraEditors.Controls.EditorButton(
                                                  CType(resources.GetObject("cbAnimalLookup.Buttons"),
                                                        DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAnimalLookup.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() _
                                              {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                                  resources.GetString("cbAnimalLookup.Columns"),
                                                  resources.GetString("cbAnimalLookup.Columns1")),
                                               New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                                   resources.GetString("cbAnimalLookup.Columns2"),
                                                   resources.GetString("cbAnimalLookup.Columns3")),
                                               New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                                   resources.GetString("cbAnimalLookup.Columns4"),
                                                   resources.GetString("cbAnimalLookup.Columns5"))})
        Me.cbAnimalLookup.DisplayMember = "strAnimalCode"
        Me.cbAnimalLookup.Name = "cbAnimalLookup"
        Me.cbAnimalLookup.ValueMember = "idfAnimal"
        '
        'colSpecies
        '
        resources.ApplyResources(Me.colSpecies, "colSpecies")
        Me.colSpecies.ColumnEdit = Me.cbSpecies
        Me.colSpecies.FieldName = "idfParty"
        Me.colSpecies.Name = "colSpecies"
        '
        'cbSpecies
        '
        resources.ApplyResources(Me.cbSpecies, "cbSpecies")
        Me.cbSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                         {New DevExpress.XtraEditors.Controls.EditorButton(
                                             CType(resources.GetObject("cbSpecies.Buttons"),
                                                   DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecies.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() _
                                         {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                             resources.GetString("cbSpecies.Columns"),
                                             resources.GetString("cbSpecies.Columns1"))})
        Me.cbSpecies.DisplayMember = "strSpecies"
        Me.cbSpecies.Name = "cbSpecies"
        '
        'colVectorID
        '
        Me.colVectorID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colVectorID, "colVectorID")
        Me.colVectorID.ColumnEdit = Me.cbVectorID
        Me.colVectorID.FieldName = "idfParty"
        Me.colVectorID.Name = "colVectorID"
        Me.colVectorID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colVectorID.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'cbVectorID
        '
        resources.ApplyResources(Me.cbVectorID, "cbVectorID")
        Me.cbVectorID.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                          {New DevExpress.XtraEditors.Controls.EditorButton(
                                              CType(resources.GetObject("cbVectorID.Buttons"),
                                                    DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbVectorID.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() _
                                          {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                              resources.GetString("cbVectorID.Columns"),
                                              resources.GetString("cbVectorID.Columns1")),
                                           New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                               resources.GetString("cbVectorID.Columns2"),
                                               resources.GetString("cbVectorID.Columns3")),
                                           New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                               resources.GetString("cbVectorID.Columns4"),
                                               resources.GetString("cbVectorID.Columns5"))})
        Me.cbVectorID.DisplayMember = "strVectorID"
        Me.cbVectorID.Name = "cbVectorID"
        Me.cbVectorID.ValueMember = "idfVector"
        '
        'colVectorType
        '
        resources.ApplyResources(Me.colVectorType, "colVectorType")
        Me.colVectorType.ColumnEdit = Me.cbVectorType
        Me.colVectorType.FieldName = "idfParty"
        Me.colVectorType.Name = "colVectorType"
        '
        'cbVectorType
        '
        resources.ApplyResources(Me.cbVectorType, "cbVectorType")
        Me.cbVectorType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                            {New DevExpress.XtraEditors.Controls.EditorButton(
                                                CType(resources.GetObject("cbVectorType.Buttons"),
                                                      DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbVectorType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() _
                                            {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(
                                                resources.GetString("cbVectorType.Columns"),
                                                resources.GetString("cbVectorType.Columns1"))})
        Me.cbVectorType.DisplayMember = "strVectorType"
        Me.cbVectorType.Name = "cbVectorType"
        '
        'colCollectionDate
        '
        Me.colCollectionDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colCollectionDate, "colCollectionDate")
        Me.colCollectionDate.ColumnEdit = Me.dtCollectionDate
        Me.colCollectionDate.FieldName = "datFieldCollectionDate"
        Me.colCollectionDate.Name = "colCollectionDate"
        '
        'colConditionReceived
        '
        resources.ApplyResources(Me.colConditionReceived, "colConditionReceived")
        Me.colConditionReceived.ColumnEdit = Me.cbCondition
        Me.colConditionReceived.FieldName = "idfsAccessionCondition"
        Me.colConditionReceived.Name = "colConditionReceived"
        Me.colConditionReceived.OptionsColumn.AllowEdit = False
        '
        'cbCondition
        '
        resources.ApplyResources(Me.cbCondition, "cbCondition")
        Me.cbCondition.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                           {New DevExpress.XtraEditors.Controls.EditorButton(
                                               CType(resources.GetObject("cbCondition.Buttons"),
                                                     DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCondition.Name = "cbCondition"
        '
        'colSampleCondition
        '
        resources.ApplyResources(Me.colSampleCondition, "colSampleCondition")
        Me.colSampleCondition.ColumnEdit = Me.memoEdit
        Me.colSampleCondition.FieldName = "strCondition"
        Me.colSampleCondition.Name = "colSampleCondition"
        '
        'memoEdit
        '
        Me.memoEdit.MaxLength = 200
        Me.memoEdit.Name = "memoEdit"
        Me.memoEdit.ShowIcon = False
        '
        'colAccessionedDate
        '
        resources.ApplyResources(Me.colAccessionedDate, "colAccessionedDate")
        Me.colAccessionedDate.ColumnEdit = Me.cbAccessionDate
        Me.colAccessionedDate.FieldName = "datAccession"
        Me.colAccessionedDate.Name = "colAccessionedDate"
        Me.colAccessionedDate.OptionsColumn.AllowEdit = False
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                               {New DevExpress.XtraEditors.Controls.EditorButton(
                                                   CType(resources.GetObject("cbAccessionDate.Buttons"),
                                                         DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAccessionDate.Name = "cbAccessionDate"
        Me.cbAccessionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                                   {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colCollectedByInstitution
        '
        resources.ApplyResources(Me.colCollectedByInstitution, "colCollectedByInstitution")
        Me.colCollectedByInstitution.ColumnEdit = Me.cbCollectedByInstitution
        Me.colCollectedByInstitution.FieldName = "idfFieldCollectedByOffice"
        Me.colCollectedByInstitution.MinWidth = 100
        Me.colCollectedByInstitution.Name = "colCollectedByInstitution"
        '
        'cbCollectedByInstitution
        '
        resources.ApplyResources(Me.cbCollectedByInstitution, "cbCollectedByInstitution")
        Me.cbCollectedByInstitution.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                        {New DevExpress.XtraEditors.Controls.EditorButton(
                                                            CType(resources.GetObject("cbCollectedByInstitution.Buttons"),
                                                                  DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByInstitution.Name = "cbCollectedByInstitution"
        '
        'colCollectedByOfficer
        '
        resources.ApplyResources(Me.colCollectedByOfficer, "colCollectedByOfficer")
        Me.colCollectedByOfficer.ColumnEdit = Me.cbCollectedByOfficer
        Me.colCollectedByOfficer.FieldName = "idfFieldCollectedByPerson"
        Me.colCollectedByOfficer.MinWidth = 100
        Me.colCollectedByOfficer.Name = "colCollectedByOfficer"
        '
        'cbCollectedByOfficer
        '
        resources.ApplyResources(Me.cbCollectedByOfficer, "cbCollectedByOfficer")
        Me.cbCollectedByOfficer.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                    {New DevExpress.XtraEditors.Controls.EditorButton(
                                                        CType(resources.GetObject("cbCollectedByOfficer.Buttons"),
                                                              DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByOfficer.Name = "cbCollectedByOfficer"
        '
        'colSentToOrganization
        '
        resources.ApplyResources(Me.colSentToOrganization, "colSentToOrganization")
        Me.colSentToOrganization.ColumnEdit = Me.cbSentToOrganization
        Me.colSentToOrganization.FieldName = "idfSendToOffice"
        Me.colSentToOrganization.MinWidth = 100
        Me.colSentToOrganization.Name = "colSentToOrganization"
        '
        'cbSentToOrganization
        '
        resources.ApplyResources(Me.cbSentToOrganization, "cbSentToOrganization")
        Me.cbSentToOrganization.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                    {New DevExpress.XtraEditors.Controls.EditorButton(
                                                        CType(resources.GetObject("cbSentToOrganization.Buttons"),
                                                              DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSentToOrganization.Name = "cbSentToOrganization"
        '
        'colTestsCount
        '
        resources.ApplyResources(Me.colTestsCount, "colTestsCount")
        Me.colTestsCount.FieldName = "strTests"
        Me.colTestsCount.Name = "colTestsCount"
        Me.colTestsCount.OptionsColumn.AllowEdit = False
        '
        'btnDeleteSpecimen
        '
        resources.ApplyResources(Me.btnDeleteSpecimen, "btnDeleteSpecimen")
        Me.btnDeleteSpecimen.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteSpecimen.Name = "btnDeleteSpecimen"
        '
        'pnSpecimenDetail
        '
        resources.ApplyResources(Me.pnSpecimenDetail, "pnSpecimenDetail")
        Me.pnSpecimenDetail.Appearance.BackColor = CType(resources.GetObject("pnSpecimenDetail.Appearance.BackColor"),
                                                         System.Drawing.Color)
        Me.pnSpecimenDetail.Appearance.Options.UseBackColor = True
        Me.pnSpecimenDetail.AppearanceCaption.Options.UseFont = True
        Me.pnSpecimenDetail.Controls.Add(Me.grpSendToOffice)
        Me.pnSpecimenDetail.Controls.Add(Me.CollectedByGroup)
        Me.pnSpecimenDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnSpecimenDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnSpecimenDetail.Name = "pnSpecimenDetail"
        '
        'grpSendToOffice
        '
        resources.ApplyResources(Me.grpSendToOffice, "grpSendToOffice")
        Me.grpSendToOffice.AppearanceCaption.Options.UseFont = True
        Me.grpSendToOffice.Controls.Add(Me.lbSendToOffice)
        Me.grpSendToOffice.Controls.Add(Me.cbSendToOffice)
        Me.grpSendToOffice.Name = "grpSendToOffice"
        '
        'lbSendToOffice
        '
        resources.ApplyResources(Me.lbSendToOffice, "lbSendToOffice")
        Me.lbSendToOffice.Name = "lbSendToOffice"
        '
        'cbSendToOffice
        '
        resources.ApplyResources(Me.cbSendToOffice, "cbSendToOffice")
        Me.cbSendToOffice.Name = "cbSendToOffice"
        Me.cbSendToOffice.Properties.AutoHeight = CType(resources.GetObject("cbSendToOffice.Properties.AutoHeight"),
                                                        Boolean)
        Me.cbSendToOffice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                         {New DevExpress.XtraEditors.Controls.EditorButton(
                                                             CType(
                                                                 resources.GetObject("cbSendToOffice.Properties.Buttons"),
                                                                 DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSendToOffice.Properties.NullText = resources.GetString("cbSendToOffice.Properties.NullText")
        Me.cbSendToOffice.Tag = ""
        '
        'CollectedByGroup
        '
        resources.ApplyResources(Me.CollectedByGroup, "CollectedByGroup")
        Me.CollectedByGroup.AppearanceCaption.Options.UseFont = True
        Me.CollectedByGroup.Controls.Add(Me.lbCollectedByOrganization)
        Me.CollectedByGroup.Controls.Add(Me.cbCollectedByOrganization)
        Me.CollectedByGroup.Controls.Add(Me.cbCollectedByPerson)
        Me.CollectedByGroup.Controls.Add(Me.lbCollectedByEmployee)
        Me.CollectedByGroup.Name = "CollectedByGroup"
        '
        'lbCollectedByOrganization
        '
        resources.ApplyResources(Me.lbCollectedByOrganization, "lbCollectedByOrganization")
        Me.lbCollectedByOrganization.Name = "lbCollectedByOrganization"
        '
        'cbCollectedByOrganization
        '
        resources.ApplyResources(Me.cbCollectedByOrganization, "cbCollectedByOrganization")
        Me.cbCollectedByOrganization.Name = "cbCollectedByOrganization"
        Me.cbCollectedByOrganization.Properties.AutoHeight =
            CType(resources.GetObject("cbCollectedByOrganization.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                                    {New DevExpress.XtraEditors.Controls.EditorButton(
                                                                        CType(
                                                                            resources.GetObject(
                                                                                "cbCollectedByOrganization.Properties.Buttons"),
                                                                            DevExpress.XtraEditors.Controls.
                                                                                                                         ButtonPredefines))})
        Me.cbCollectedByOrganization.Properties.NullText =
            resources.GetString("cbCollectedByOrganization.Properties.NullText")
        Me.cbCollectedByOrganization.Tag = ""
        '
        'cbCollectedByPerson
        '
        resources.ApplyResources(Me.cbCollectedByPerson, "cbCollectedByPerson")
        Me.cbCollectedByPerson.Name = "cbCollectedByPerson"
        Me.cbCollectedByPerson.Properties.AutoHeight =
            CType(resources.GetObject("cbCollectedByPerson.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
                                                              {New DevExpress.XtraEditors.Controls.EditorButton(
                                                                  CType(
                                                                      resources.GetObject(
                                                                          "cbCollectedByPerson.Properties.Buttons"),
                                                                      DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByPerson.Properties.NullText = resources.GetString("cbCollectedByPerson.Properties.NullText")
        Me.cbCollectedByPerson.Tag = ""
        '
        'lbCollectedByEmployee
        '
        resources.ApplyResources(Me.lbCollectedByEmployee, "lbCollectedByEmployee")
        Me.lbCollectedByEmployee.Name = "lbCollectedByEmployee"
        '
        'NotesGroup
        '
        resources.ApplyResources(Me.NotesGroup, "NotesGroup")
        Me.NotesGroup.Appearance.BackColor = CType(resources.GetObject("NotesGroup.Appearance.BackColor"),
                                                   System.Drawing.Color)
        Me.NotesGroup.Appearance.Options.UseBackColor = True
        Me.NotesGroup.AppearanceCaption.Options.UseFont = True
        Me.NotesGroup.Controls.Add(Me.txtSampleNotes)
        Me.NotesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.NotesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.NotesGroup.Name = "NotesGroup"
        '
        'txtSampleNotes
        '
        resources.ApplyResources(Me.txtSampleNotes, "txtSampleNotes")
        Me.txtSampleNotes.Name = "txtSampleNotes"
        Me.txtSampleNotes.Properties.MaxLength = 1000
        '
        'CaseSamplesPanel
        '
        Me.Controls.Add(Me.SamplesGroup)
        Me.Controls.Add(Me.pnSpecimenDetail)
        Me.Controls.Add(Me.NotesGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.KeyFieldName = "idfMaterial"
        Me.Name = "CaseSamplesPanel"
        Me.ObjectName = "CaseSamples"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Material"
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SamplesGroup.ResumeLayout(False)
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSpecimenDetail.ResumeLayout(False)
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSendToOffice.ResumeLayout(False)
        Me.grpSendToOffice.PerformLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollectedByGroup.ResumeLayout(False)
        Me.CollectedByGroup.PerformLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NotesGroup.ResumeLayout(False)
        CType(Me.txtSampleNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

    Protected m_SamplesView As DataView

    Protected Overrides Sub DefineBinding()
        If Me.DesignMode OrElse baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then Return

        LookupBinder.BindSampleRepositoryLookup(Me.cbSpecimenType, HACode, False)
        cbSpecies.Columns(0).Caption = EidssMessages.Get("colName")
        cbAnimalLookup.Columns(0).Caption = EidssFields.Get("AnimalID")
        cbAnimalLookup.Columns(1).Caption = EidssMessages.Get("Species")
        cbAnimalLookup.Columns(2).Caption = EidssMessages.Get("Gender")


        cbVectorID.Columns(0).Caption = EidssMessages.Get("PoolVectorID")
        cbVectorID.Columns(1).Caption = EidssMessages.Get("VectorType")
        cbVectorID.Columns(2).Caption = EidssMessages.Get("VectorSpecies")
        cbVectorType.Columns(0).Caption = EidssMessages.Get("VectorType")
        m_SamplesView = New DataView(baseDataSet.Tables(CaseSamples_Db.TableSamples))
        m_SamplesView.RowFilter = String.Format("IsNull(idfsSampleType, -1) <> {0}", CLng(SampleTypeEnum.Unknown))

        'Bind detail panel controls to grid datasource to use current view row as binding source
        LookupBinder.BindPersonLookup(cbCollectedByPerson, m_SamplesView, "idfFieldCollectedByPerson")
        LookupBinder.BindOrganizationLookup(cbCollectedByOrganization, m_SamplesView, "idfFieldCollectedByOffice",
                                            HACode, False)
        LookupBinder.BindOrganizationLookup(cbSendToOffice, m_SamplesView, "idfSendToOffice", HACode, False)

        LookupBinder.BindOrganizationRepositoryLookup(cbCollectedByInstitution, HACode, False, True)
        LookupBinder.BindPersonRepositoryLookup(cbCollectedByOfficer, AddressOf cbCollectedByOfficer_SetFilter, True)
        LookupBinder.BindOrganizationRepositoryLookup(cbSentToOrganization, HACode, False, True)

        SamplesGrid.DataSource = m_SamplesView

        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfFieldCollectedByOffice",
                                       AddressOf OrganizationChangeHandler)
        If baseDataSet.Tables.Contains(CaseSamples_Db.TableCaseActivity) Then
            LookupBinder.BindTextEdit(txtSampleNotes, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strSampleNotes")
        End If
        LookupBinder.BindBaseRepositoryLookup(Me.cbCondition, db.BaseReferenceType.rftAccessionCondition, HACode.All,
                                              False)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfMainTest", AddressOf MainTestChanged)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfParty", AddressOf UpdatePartyInfo)
        RefreshRelatedViews()
        ShowSampleDetails(0)
        ShowNewButton = False
        If [ReadOnly] Then
            EnableSampleAdding(False)
            Me.SamplesGridView.OptionsBehavior.Editable = False
        End If
        cbFilteredSampleTypeEditor = CType(cbSpecimenType.Clone(), RepositoryItemLookUpEdit)
        Try
            RemoveHandler SamplesGridView.CustomRowCellEditForEditing,
                AddressOf SamplesGridView_CustomRowCellEditForEditing
        Finally
            AddHandler SamplesGridView.CustomRowCellEditForEditing,
                AddressOf SamplesGridView_CustomRowCellEditForEditing
        End Try
    End Sub

    Private m_ShowNewButton As Boolean = False

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ShowNewButton As Boolean
        Get
            Return m_ShowNewButton
        End Get
        Set(value As Boolean)
            m_ShowNewButton = value
            btnNewSpecimen.Visible = m_ShowNewButton
            If (m_ShowNewButton) Then
                SamplesGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Else
                SamplesGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            End If
        End Set
    End Property

    Public Sub EnableSampleAdding(enable As Boolean)
        Me.btnNewSpecimen.Enabled = enable
        If (m_ShowNewButton OrElse Not enable) Then
            SamplesGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Else
            SamplesGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        End If
    End Sub

    Private Sub MainTestChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If RelatedTestsPanel Is Nothing Then
            Return
        End If
        RelatedTestsPanel.SetMainTestForSample(e.Row("idfMainTest"), e.Row("idfMaterial"))
    End Sub

    Private Sub OrganizationChangeHandler(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If pnSpecimenDetail.Visible Then
            LookupBinder.SetPersonFilter(e.Row, e.Column.ColumnName, cbCollectedByPerson)
        End If
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CasePartyList() As Object
        Get
            If (HACode And HACode.Livestock) <> 0 Then
                Return cbAnimalLookup.DataSource
            ElseIf (HACode And HACode.Avian) <> 0 Then
                Return cbSpecies.DataSource
            ElseIf (HACode And HACode.Vector) <> 0 Then
                Return cbVectorID.DataSource
            End If
            Return Nothing
        End Get
        Set(ByVal Value As Object)
            If (HACode And HACode.Livestock) <> 0 Then
                Me.cbSpecies.ValueMember = "idfAnimal"
                CType(Value, DataView).RowFilter = "idfAnimal is not null"
            ElseIf (HACode And HACode.Avian) <> 0 Then
                Me.cbSpecies.ValueMember = "idfSpecies"
            ElseIf (HACode And HACode.Vector) <> 0 Then
                Me.cbVectorType.ValueMember = "idfVector"
                CType(Value, DataView).RowFilter = "idfVector is not null"
            End If
            If ((HACode And HACode.Livestock) <> 0) OrElse ((HACode And HACode.Avian) <> 0) Then
                cbAnimalLookup.DataSource = Value
                cbSpecies.DataSource = Value
            ElseIf (HACode And HACode.Vector) <> 0 Then
                cbVectorID.DataSource = Value
                cbVectorType.DataSource = Value
            End If
        End Set
    End Property

    Private m_DefaultPartyID As Object = DBNull.Value

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable Property DefaultPartyID() As Object
        Get
            Return m_DefaultPartyID
        End Get
        Set(ByVal Value As Object)
            m_DefaultPartyID = Value
        End Set
    End Property

    Private m_HACode As HACode = HACode.Livestock

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal Value As HACode)
            m_HACode = Value

            If (HACode And HACode.Avian) <> 0 Then
                Me.colAnimal.Visible = False
                Me.colSpecies.OptionsColumn.AllowEdit = True
                Me.colVectorID.Visible = False
                Me.colVectorType.Visible = False
            End If
            If (HACode And HACode.Livestock) <> 0 Then
                Me.colAnimal.Visible = True
                Me.colSpecies.OptionsColumn.AllowEdit = False
                Me.colVectorID.Visible = False
                Me.colVectorType.Visible = False
            End If
            If HACode = HACode.Human Then
                Me.colSpecies.Visible = False
                Me.colAnimal.Visible = False
                Me.colVectorID.Visible = False
                Me.colVectorType.Visible = False
                Me.colSpecimenID.Caption = EidssMessages.Get("HumanSampleID", "Local Sample ID")
            End If
            If HACode = HACode.Vector Then
                Me.colSpecies.Visible = False
                Me.colAnimal.Visible = False
                Me.colVectorID.Visible = True
                Me.colVectorType.Visible = True
                Me.colVectorType.OptionsColumn.AllowEdit = False
            End If
        End Set
    End Property

    Dim m_ShowPopupImmediatly As Boolean = False

    Protected Function GetLastRow() As DataRow
        If (SamplesGridView.RowCount > 0) Then
            Return SamplesGridView.GetDataRow(SamplesGridView.RowCount - 1)
        Else
            Return Nothing
        End If
    End Function


    Overridable Function CreateNewRecord() As DataRow
        Dim SpecimenName As String = Nothing
        Dim SampleType As Object = Nothing 'GetCurrentSampleToCollectID(SpecimenName)
        Me.BeginUpdate()
        Dim lastRow As DataRow = GetLastRow()
        Dim row As DataRow = CaseSamplesDbService.CreateSample(baseDataSet, m_DefaultPartyID, lastRow)
        Me.EndUpdate()
        For i As Integer = 0 To SamplesGridView.RowCount - 1
            If SamplesGridView.GetDataRow(i) Is row Then
                If (SamplesGridView.OptionsSelection.MultiSelect) Then
                    SamplesGridView.ClearSelection()
                    SamplesGridView.SelectRow(i)
                End If
                SamplesGridView.FocusedRowHandle = i
                Exit For
            End If
        Next
        If colAnimal.Visible AndAlso colAnimal.AbsoluteIndex >= 0 Then
            SamplesGridView.FocusedColumn = colAnimal
        ElseIf colVectorID.Visible AndAlso colVectorID.AbsoluteIndex >= 0 Then
            SamplesGridView.FocusedColumn = colVectorID
        ElseIf Utils.IsEmpty(SampleType) Then
            SamplesGridView.FocusedColumn = colSpecimenType
        Else
            SamplesGridView.FocusedColumn = colSpecimenID
        End If
        UpdatePartyInfo(row("idfParty"))
        Return row
    End Function

    Overridable Sub btnNewSpecimen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewSpecimen.Click
        If _
            IsCurrentSpecimenRowValid(, True) = False OrElse
            (Utils.IsEmpty(Me.m_DefaultPartyID) AndAlso ValidatePartyList(True) = False) Then
            Return
        End If
        CreateNewRecord()
        ShowSampleDetails(SamplesGridView.FocusedRowHandle)
        m_ShowPopupImmediatly = True
        SamplesGrid.Select()
        Application.DoEvents()
        RefreshRelatedViews()
        SamplesGridView.ShowEditor()
    End Sub

    Protected m_Updating As Boolean = False

    Private Sub SamplesGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs) _
        Handles SamplesGridView.FocusedRowChanged
        If (Not Created) OrElse m_Updating Then Return
        m_Updating = True
        Try
            If IsCurrentSpecimenRowValid(e.PrevFocusedRowHandle) = False Then
                If (e.PrevFocusedRowHandle = GridControl.NewItemRowHandle) Then
                    SamplesGridView.FocusedRowHandle = SamplesGridView.RowCount - 1
                Else
                    SamplesGridView.FocusedRowHandle = e.PrevFocusedRowHandle
                End If
            Else
                ShowSampleDetails(e.FocusedRowHandle)
                ''TODO: Remove: Dim row As DataRow = SamplesGridView.GetDataRow(e.FocusedRowHandle)
                ''TODO: Remove: If Not row Is Nothing Then
                ''TODO: Remove:    UpdateSampleTypeDataSource(row("idfVector"))
                ''TODO: Remove: End If
            End If
        Finally
            UpdateButtons()
            m_Updating = False
        End Try
    End Sub


    Public Event evDateChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Event evGridViewCustomRowCellEditForEditing(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)

    Public Event OnDeleteSample As RowCollectionChangedHandler

    Public Overridable Sub btnDeleteSpecimen_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnDeleteSpecimen.Click
        Dim SampleRow As DataRow = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)

        If SampleRow Is Nothing Then Return
        If SampleRow.RowState <> DataRowState.Added AndAlso Utils.Str(SampleRow("Used")) = "1" Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return
        End If
        If _
            CaseSamples_Db.CheckAccessIn(CLng(SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)("idfMaterial"))) =
            False Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return
        End If
        Dim args As New DataRowEventArgs(SampleRow)
        RaiseEvent OnDeleteSample(Me, args)
        If args.Cancel Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return
        End If
        If WinUtils.ConfirmDelete Then
            CaseSamplesDbService.DeleteSample(baseDataSet, SampleRow("idfMaterial"))
            RefreshRelatedViews()
            IsCurrentSpecimenRowValid(- 1, False)
        End If
    End Sub


    Private Sub cbSpecimenType_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbSpecimenType.EditValueChanged
        Dim materialRow As DataRow = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)
        Dim s As String = Me.cbSpecimenType.GetDisplayText(SamplesGridView.EditingValue)
        materialRow.Table.Columns("strSampleName").ReadOnly = False
        materialRow("strSampleName") = s
    End Sub

    Public Sub UpdatePartyInfo(idfParty As Object)
        If Utils.IsEmpty(idfParty) Then
            Return
        End If
        Dim partyRows As DataRow() =
                baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfParty = {0}", idfParty))
        If Not partyRows Is Nothing AndAlso partyRows.Length > 0 Then
            For Each partyRow As DataRow In partyRows
                UpdatePartyInfo(Nothing, New DataFieldChangeEventArgs(partyRow, Nothing, Nothing, Nothing))
            Next
        End If
    End Sub

    Protected Overridable Sub UpdatePartyInfo(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim materialRow As DataRow = e.Row
        If (HACode And HACode.Livestock) <> 0 Then
            Dim animalRow As DataRow = FindRow(CType(cbAnimalLookup.DataSource, DataView).Table, materialRow("idfParty"),
                                               "idfAnimal")
            If Not animalRow Is Nothing Then
                materialRow("strAnimalCode") = animalRow("strAnimalCode")
                materialRow("AnimalName") = animalRow("strAnimalCode")
                If _
                    animalRow.Table.Columns.Contains("strSpecies") AndAlso
                    materialRow.Table.Columns.Contains("SpeciesName") Then
                    materialRow("SpeciesName") = animalRow("strSpecies")
                End If
                If _
                    animalRow.Table.Columns.Contains("idfsSpeciesType") AndAlso
                    materialRow.Table.Columns.Contains("idfsSpeciesType") Then
                    materialRow("idfsSpeciesType") = animalRow("idfsSpeciesType")
                    If materialRow.Table.Columns.Contains("SpeciesName") Then
                        materialRow("SpeciesName") = LookupCache.GetLookupValue(animalRow("idfsSpeciesType"),
                                                                                BaseReferenceType.rftSpeciesList, "name")
                    End If
                End If
                If _
                    (materialRow.RowState = DataRowState.Added AndAlso
                     (e.Column Is Nothing OrElse e.Column.ColumnName = "idfParty")) Then
                    Dim sourceRow As DataRow = FindLastAnimalRow(materialRow)
                    If Not sourceRow Is Nothing Then
                        materialRow("datFieldCollectionDate") = sourceRow("datFieldCollectionDate")
                        materialRow("idfSendToOffice") = sourceRow("idfSendToOffice")
                        materialRow("idfFieldCollectedByPerson") = sourceRow("idfFieldCollectedByPerson")
                        materialRow("idfFieldCollectedByOffice") = sourceRow("idfFieldCollectedByOffice")
                    End If
                End If
            End If
        ElseIf (HACode And HACode.Avian) <> 0 Then
            Dim speciesRow As DataRow = FindRow(CType(cbSpecies.DataSource, DataView).Table, e.Row("idfParty"),
                                                "idfSpecies")
            If Not speciesRow Is Nothing Then
                materialRow("AnimalName") = speciesRow("strSpecies")
                materialRow("SpeciesName") = speciesRow("strSpecies")
            End If
        ElseIf (HACode And HACode.Vector) <> 0 Then
            Dim vectorRow As DataRow = FindRow(CType(cbVectorID.DataSource, DataView).Table, e.Row("idfParty"),
                                               "idfVector")
            If Not vectorRow Is Nothing Then
                materialRow("idfVector") = vectorRow("idfVector")
                materialRow("idfsVectorType") = vectorRow("idfsVectorType")
                materialRow("strVectorID") = vectorRow("strVectorID")
                materialRow("strVectorType") = vectorRow("strVectorType")
            End If


        End If
        materialRow.EndEdit()
    End Sub

    Private Function FindLastAnimalRow(ByVal sourceRow As DataRow) As DataRow
        If (sourceRow Is Nothing) Then
            Return Nothing
        End If
        Dim idfAnimal As Object = sourceRow("idfParty")
        If (Utils.IsEmpty(idfAnimal)) Then
            Return Nothing
        End If
        For i As Integer = SamplesGridView.RowCount - 1 To 0 Step - 1
            Dim row As DataRow = SamplesGridView.GetDataRow(i)
            If row Is sourceRow Then
                Continue For
            End If
            If (row("idfParty").Equals(idfAnimal)) Then
                Return row
            End If
        Next
        Return Nothing
    End Function

    'Private Sub cbAnimalLookup_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnimalLookup.EditValueChanged, cbSpecies.EditValueChanged
    '    SamplesGridView.PostEditor()

    '    Dim materialRow As DataRow = SamplesGridView.GetFocusedDataRow()
    '    If CType(sender, DevExpress.XtraEditors.LookUpEdit).Properties.Name = cbAnimalLookup.Name Then
    '        Dim animalRow As DataRow = FindRow(CType(cbAnimalLookup.DataSource, DataView).Table, CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, "idfAnimal")
    '        If Not animalRow Is Nothing Then
    '            materialRow("strAnimalCode") = animalRow("strAnimalCode")
    '            materialRow("AnimalName") = animalRow("strAnimalCode")
    '            materialRow("SpeciesName") = animalRow("strSpecies")
    '            If animalRow.Table.Columns.Contains("idfsSpeciesType") AndAlso materialRow.Table.Columns.Contains("idfsSpeciesType") Then
    '                materialRow("idfsSpeciesType") = animalRow("idfsSpeciesType")
    '            End If
    '        End If
    '    ElseIf CType(sender, DevExpress.XtraEditors.LookUpEdit).Properties.Name = cbSpecies.Name Then
    '        Dim speciesRow As DataRow = FindRow(CType(cbSpecies.DataSource, DataView).Table, CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, "idfSpecies")
    '        If Not speciesRow Is Nothing Then
    '            materialRow("AnimalName") = speciesRow("strSpecies")
    '            materialRow("SpeciesName") = speciesRow("strSpecies")
    '        End If
    '    End If
    '    materialRow.EndEdit()
    'End Sub

    Protected Sub UpdateSampleTypeDataSource(ByVal idfVector As Object)
        If (HACode = HACode.Vector) AndAlso (Not baseDataSet Is Nothing) AndAlso
           (baseDataSet.Tables.Contains("VectorPartyList")) AndAlso
           (Not Me.cbSpecimenType.DataSource Is Nothing) AndAlso (TypeOf (Me.cbSpecimenType.DataSource) Is DataView) _
            Then

            Dim filteredDataTable As DataTable = baseDataSet.Tables("VectorPartyList")

            Dim Filter As String = "idfsReference = 0 "

            For Each vector As DataRow In filteredDataTable.Rows
                If Utils.Str(vector(0), "") = Utils.Str(idfVector, "") Then
                    Filter = vector("SampleFilter").ToString()
                    Exit For
                End If
            Next

            CType(Me.cbSpecimenType.DataSource, DataView).RowFilter = Filter
            CType(Me.cbSpecimenType.DataSource, DataView).Sort = "idfsReference"
        End If
    End Sub

    Protected Sub UpdateSampleTypeValue(ByVal idfVector As Object)
        If (HACode = HACode.Vector) AndAlso (Not baseDataSet Is Nothing) AndAlso
           (baseDataSet.Tables.Contains("VectorPartyList")) AndAlso
           (Not Me.cbSpecimenType.DataSource Is Nothing) AndAlso (TypeOf (Me.cbSpecimenType.DataSource) Is DataView) AndAlso
           (Me.SamplesGridView.FocusedRowHandle >= 0) Then

            Dim i As Integer = Me.SamplesGridView.FocusedRowHandle
            Dim row As DataRow = SamplesGridView.GetDataRow(i)
            If (Not row Is Nothing) AndAlso (Not Utils.IsEmpty(row("idfsSampleType"))) Then
                Dim filteredDataTable As DataTable = baseDataSet.Tables("VectorPartyList")

                Dim CorrectValue As Boolean = False
                For Each vector As DataRow In filteredDataTable.Rows
                    If Utils.Str(vector(0), "") = Utils.Str(idfVector, "") AndAlso
                       (Utils.Str(vector("SampleFilter"), "").Contains(Utils.Str(row("idfsSampleType"), "")) = True) _
                        Then
                        CorrectValue = True
                        Exit For
                    End If
                Next

                If (Not CorrectValue) AndAlso (Not Utils.IsEmpty(row("idfsSampleType"))) Then
                    row.BeginEdit()
                    row("idfsSampleType") = DBNull.Value
                    row.EndEdit()
                End If

            End If
        End If
    End Sub

    Private Sub cbVectorID_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbVectorID.EditValueChanged, cbVectorType.EditValueChanged
        SamplesGridView.PostEditor()

        Dim materialRow As DataRow = SamplesGridView.GetFocusedDataRow()
        If (materialRow Is Nothing) Then
            Return
        End If

        If (CType(sender, LookUpEdit).Properties.Name = cbVectorID.Name) OrElse
           (CType(sender, LookUpEdit).Properties.Name = cbVectorType.Name) Then
            Dim vectorRow As DataRow = FindRow(CType(cbVectorID.DataSource, DataView).Table,
                                               CType(sender, LookUpEdit).EditValue, "idfVector")
            If Not vectorRow Is Nothing Then
                materialRow("strVectorID") = vectorRow("strVectorID")
                materialRow("strVectorType") = vectorRow("strVectorType")
                materialRow("strVectorSpecies") = vectorRow("strVectorSpecies")

                UpdateSampleTypeValue(vectorRow("idfVector"))

                '' TODO: Add clearing idfsSampleType in materialRow if it doesn't satisfy filter by vector
            End If
        End If
        materialRow.EndEdit()
    End Sub

    Public Sub DeletePartySamples(ByVal PartyID As Object)
        Me.CaseSamplesDbService.DeletePartySamples(baseDataSet, PartyID)
    End Sub

    Overridable Sub ShowSampleDetails(ByVal sampleIndex As Integer)
        If SamplesGridView.RowCount = 0 OrElse sampleIndex < 0 Then
            pnSpecimenDetail.Enabled = False
            Return
        End If
        pnSpecimenDetail.Enabled = True

        Dim row As DataRow = SamplesGridView.GetDataRow(SampleIndex)
        If (row Is Nothing) Then _
            ' this sitaution is possible when we create row using new row interface (before row initialization)
            Return
        End If
        If pnSpecimenDetail.Visible Then
            Dim modify As Boolean = (Utils.Str(row("Used")) <> "1")
            SetLookupReadOnly(Me.cbCollectedByOrganization, modify)
            SetLookupReadOnly(Me.cbCollectedByPerson, modify)
            SetLookupReadOnly(Me.cbSendToOffice, modify)
        End If
        LookupBinder.SetPersonFilter(row, "idfFieldCollectedByOffice", cbCollectedByPerson)
    End Sub

    Private Sub SamplesGridView_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) _
        Handles SamplesGridView.ShownEditor
        If _
            Not SamplesGridView.ActiveEditor Is Nothing AndAlso TypeOf (SamplesGridView.ActiveEditor) Is LookUpEdit AndAlso
            m_ShowPopupImmediatly Then
            CType(SamplesGridView.ActiveEditor, LookUpEdit).ShowPopup()
            m_ShowPopupImmediatly = False
        End If
        If Not SamplesGridView.ActiveEditor Is Nothing Then
            If SamplesGridView.FocusedColumn Is colSpecimenID Then
                SystemLanguages.SwitchInputLanguage(bv.common.Core.Localizer.lngEn)
            End If
        End If
    End Sub


    Protected Function ValidatePartyList(Optional ByVal showError As Boolean = True) As Boolean

        If _
            (HACode And HACode.Avian And HACode.Livestock) <> 0 AndAlso
            (CasePartyList Is Nothing OrElse CType(CasePartyList, DataView).Count = 0) Then
            If showError Then
                If (HACode And HACode.Livestock) <> 0 Then
                    ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrNoAnimalsForSample",
                                                                  "To add sample you should have at least one animal in the animals list."))
                ElseIf (HACode And HACode.Avian) <> 0 Then
                    ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrNoSpeciesForSample",
                                                                  "To add sample you should have at least one registered species."))
                End If
            End If
            Return False
        ElseIf _
            (HACode And HACode.Vector) <> 0 AndAlso
            (CasePartyList Is Nothing OrElse CType(CasePartyList, DataView).Count = 0) Then
            If showError Then
                ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrNoVectorForSample",
                                                              "To add sample you should have at least one registered pool/vector."))
            End If
            Return False
        End If
        Return True
    End Function

    Overridable Function IsCurrentSpecimenRowValid(Optional ByVal index As Integer = - 1,
                                                   Optional ByVal showError As Boolean = True) As Boolean
        If index = - 1 Then index = SamplesGridView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = SamplesGridView.GetDataRow(index)

        If row Is Nothing Then Return True
        Dim msg As String = ""
        If row("idfsSampleType") Is DBNull.Value Then
            ' SamplesGridView.SetColumnError(colSpecimenType, String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), SamplesGridView.Columns("idfsSampleType").Caption))
            If showError Then
                msg +=
                    String.Format(
                        BvMessages.Get("ErrMandatoryFieldRequired",
                                       "The field {0} is mandatory. You must enter data to this field before form saving"),
                        SamplesGridView.Columns("idfsSampleType").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
                SamplesGridView.FocusedColumn = colSpecimenType
                SamplesGridView.FocusedRowHandle = index
            End If
            Return False
        Else
            ' SamplesGridView.SetColumnError(colSpecimenType, Nothing)
        End If
        If row("idfParty") Is DBNull.Value Then
            For Each col As GridColumn In SamplesGridView.Columns
                If col.Visible AndAlso col.FieldName = "idfParty" Then
                    'SamplesGridView.SetColumnError(colPartyID, String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), SamplesGridView.Columns("idfParty").Caption))
                    If showError Then
                        msg +=
                            String.Format(
                                BvMessages.Get("ErrMandatoryFieldRequired",
                                               "The field {0} is mandatory. You must enter data to this field before form saving"),
                                col.Caption) + vbCrLf
                        ErrorForm.ShowWarningDirect(msg)
                        SamplesGridView.FocusedColumn = col
                        SamplesGridView.FocusedRowHandle = index
                    End If
                    Return False
                End If
            Next
        Else
            'SamplesGridView.SetColumnError(colPartyID, Nothing)
        End If
        Dim customMandatoryType As CustomMandatoryField
        If (HACode And HACode.Human) > 0 Then
            customMandatoryType = CustomMandatoryField.HumanCaseSample_SentTo
        ElseIf (HACode And (HACode.Avian Or HACode.Livestock)) > 0 Then
            customMandatoryType = CustomMandatoryField.VetCaseSample_SentTo
        End If
        If _
            colSentToOrganization.Visible AndAlso
            EidssSiteContext.Instance.CustomMandatoryFields.Contains(customMandatoryType) AndAlso
            Not True.Equals(row("Used")) AndAlso Utils.IsEmpty(row("idfSendToOffice")) Then
            'SamplesGridView.SetColumnError(colPartyID, String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), SamplesGridView.Columns("idfParty").Caption))
            If showError Then
                msg += String.Format(EidssMessages.Get("ErrMandatoryFieldRequired"), colSentToOrganization.Caption)
                ErrorForm.ShowWarningDirect(msg)
                SamplesGridView.FocusedColumn = colSentToOrganization
                SamplesGridView.FocusedRowHandle = index
            End If
            Return False
        End If
        If Not CollectionDateValidator Is Nothing Then
            Return CollectionDateValidator.Validate(row, showError)
        End If
        Return True
    End Function

    'Public Overrides Sub UpdateButtonsState(ByVal Sender As Object, ByVal e As System.EventArgs)
    '    Dim SpecimenSelected As Boolean = Not SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) Is Nothing
    '    btnDeleteSpecimen.Enabled = Not [ReadOnly] AndAlso SpecimenSelected
    '    btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False)
    'End Sub

    Public Overridable Sub UpdateButtons()
        Dim specimenSelected As Boolean = Not SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) Is Nothing
        btnDeleteSpecimen.Enabled = Not [ReadOnly] AndAlso specimenSelected
        EnableSampleAdding(Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False))
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            UpdateButtons()
        End Set
    End Property

    'Private Sub dtCollectionDate_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAccessionDate.EditValueChanged
    'DataEventManager.Flush()
    'CaseSamplesDbService.UpdateSamplesToCollect(baseDataSet)
    'End Sub
    'Public Function MinMax_Err(ByVal MinD As Object, ByVal MaxD As Object, ByVal MinDName As String, ByVal MaxDName As String, ByVal AllowBeEqual As Boolean, Optional ByVal showError As Boolean = True) As Boolean
    '    Dim res As Boolean = False
    '    If Utils.IsEmpty(MinD) = False And Utils.IsEmpty(MaxD) = False Then
    '        Dim MinMax As MinMaxDate = New MinMaxDate(CType(MinD, Date), CType(MaxD, Date), MinDName, MaxDName, AllowBeEqual)
    '        If MinMax.MinMaxOk = False Then
    '            If showError Then MinMax.CheckMinMax()
    '            res = True
    '        End If
    '    End If
    '    Return res
    'End Function

    'Private m_SetSamplesView As SetDataView
    '<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public Property SetSamplesView() As SetDataView
    '    Get
    '        Return m_SetSamplesView
    '    End Get
    '    Set(ByVal Value As SetDataView)
    '        m_SetSamplesView = Value
    '    End Set
    'End Property

    'Use this property to get samples list for assigning in other panels
    'it returns new DataView on each request
    'this is needed to have the possibility of applying different filters to different views
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property SamplesList() As DataView
        Get
            Return New DataView(baseDataSet.Tables(CaseSamples_Db.TableSamples)) _
            'CType(Me.SamplesGridView.DataSource, DataView) 
        End Get
    End Property

    'use this pproperty for direct access of samples list on sample panel
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property SamplesDataView() As DataView
        Get
            If Me.SamplesGridView.DataSource Is Nothing Then
                Return Nothing
            End If
            Return CType(Me.SamplesGridView.DataSource, DataView)
        End Get
        Set(ByVal value As DataView)
            Me.SamplesGrid.DataSource = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property RelatedTestsPanel() As CaseTestsPanel

    Public Sub RefreshRelatedViews()
        'If Not m_SetSamplesView Is Nothing Then
        '    m_SetSamplesView(New DataView(baseDataSet.Tables(CaseSamplesDetail_Db.TableSamples)))
        'End If
    End Sub

    'Private m_firstLoad As Boolean

    'Private Sub BeforeAcceptChanges(ByVal sender As Object, ByVal e As EventArgs)
    '    Exit Sub
    '    For i As Integer = 0 To baseDataSet.Tables(CaseSamplesDetail_Db.TableSamples).Rows.Count - 1
    '        Dim materialRow As DataRow = baseDataSet.Tables(CaseSamplesDetail_Db.TableSamples).Rows(i)
    '        If (HACode And EIDSS.HACode.Livestock) <> 0 Then
    '            Dim animalRow As DataRow = FindRow(CType(cbAnimalLookup.DataSource, DataView).Table, materialRow("idfParty"), "idfParty")
    '            If Not animalRow Is Nothing AndAlso Utils.Str(materialRow("AnimalID")) <> Utils.Str(animalRow("strUniqueCode")) Then
    '                materialRow("AnimalID") = animalRow("strUniqueCode")
    '                materialRow.EndEdit()
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub CaseSamplesPanel_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.VisibleChanged
        'If IsCreated() AndAlso Me.Visible AndAlso m_firstLoad = False Then
        'm_firstLoad = True
        'ShowSampleDetails(0)
        'End If
    End Sub

    Public Function HasSamples() As Boolean
        Return baseDataSet.Tables(CaseSamples_Db.TableSamples).Rows.Count > 0
    End Function

    ' Note [Ivan] Barcode: commented because usages not found
    'Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
    '    ' Create Tabel
    '    Dim dr, drNew As DataRow
    '    Dim CaseID As String
    '    Dim SampleSiteID As Long = 0
    '    Dim i As Integer
    '    Dim dt As New DataTable("SamplesBarcodes")
    '    Dim blnContinue As Boolean = True


    '    If (CType(Me.Parent.Parent.Parent, BaseForm).State And BusinessObjectState.NewObject) <> 0 Then
    '        blnContinue = CType(Me.Parent.Parent.Parent, BaseForm).Post(PostType.FinalPosting)
    '        SampleSiteID = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
    '    End If

    '    CaseID = Me.CaseSamplesDbService.GetCaseBarcode()
    '    If blnContinue Then
    '        dt.Columns.Add(New DataColumn("Barcode"))
    '        dt.Columns.Add(New DataColumn("Description"))

    '        For i = 0 To SamplesGridView.RowCount - 1
    '            dr = SamplesGridView.GetDataRow(i)
    '            drNew = dt.NewRow
    '            drNew.Item("Barcode") = dr.Item("strBarcode")

    '            If CaseSamplesDbService.HasTopString(NumberingObject.Specimen) Then

    '                If SampleSiteID <> 0 Then
    '                    drNew.Item("Description") = CaseSamplesDbService.GetAdditionalInfoString(NumberingObject.Specimen, SampleSiteID)
    '                Else
    '                    drNew.Item("Description") = CaseSamplesDbService.GetAdditionalInfoString(NumberingObject.Specimen, EIDSS.model.Core.EidssSiteContext.Instance.SiteID) 'baseDataSet.Tables(CaseSamplesDetail_Db.TableSamples).Rows(0).Item("idfsSite").ToString
    '                End If

    '            Else
    '                drNew.Item("Description") = CaseID
    '            End If

    '            dt.Rows.Add(drNew)
    '        Next

    '        ' Call Barcode Printing

    '        Dim eidssStat As Object
    '        Dim parArr(3) As Object

    '        parArr(0) = dt
    '        parArr(1) = "Barcode"
    '        parArr(2) = "Description"
    '        parArr(3) = "Barcode"

    '        eidssStat = ClassLoader.LoadClass("BarcodePrint")
    '        Dim mi As System.Reflection.MethodInfo = eidssStat.GetType().GetMethod("PrintSamplesBarcode")
    '        mi.Invoke(eidssStat, parArr)
    '    End If

    'End Sub

    'Private Sub MenuItem1_Popup(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If SamplesGridView.RowCount > 0 Then
    '        'MenuItem1.Enabled = True
    '    Else
    '        'MenuItem1.Enabled = False
    '    End If
    'End Sub

    Private Sub cbSpecimenType_CloseUp(ByVal sender As Object, ByVal e As CloseUpEventArgs) _
        Handles cbSpecimenType.CloseUp
        '?  CType(cbSpecimenType.DataSource, DataView).RowFilter = ""
    End Sub

    Protected Overridable Function ShowEditor(ByVal row As DataRow) As Boolean
        'Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
        If row Is Nothing Then
            Return True
        End If
        If (row.RowState = DataRowState.Added) Then Return True
        If Utils.Str(row("Used")) = "1" Then Return False
        Return True
    End Function

    Private Sub SamplesGridView_ShowingEditor(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles SamplesGridView.ShowingEditor
        Dim row As DataRow = SamplesGridView.GetFocusedDataRow()
        Dim rdonly As Boolean = Not ShowEditor(row)
        If Not SamplesGridView.FocusedColumn Is colSampleCondition Then
            e.Cancel = rdonly
        Else
            colSampleCondition.OptionsColumn.ReadOnly = rdonly
            memoEdit.ReadOnly = rdonly
            e.Cancel = row Is Nothing OrElse
                       (rdonly AndAlso (Utils.Str(row("Used")) <> "1" OrElse Utils.Str(row("strCondition")).Trim = ""))
        End If
    End Sub

    Public Function ValidateSamplesData(ByVal ShowError As Boolean) As Boolean
        If Me.SamplesGridView.FocusedRowHandle >= 0 Then
            'Dim r As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
            If Not IsCurrentSpecimenRowValid(SamplesGridView.FocusedRowHandle, ShowError) Then
                If ShowError Then Me.SamplesGrid.Select()
                Return False
            End If
        End If
        If MyBase.ValidateData = False Then
            Return False
        End If
        Return True
    End Function

    Public Overrides Function ValidateData() As Boolean
        Return ValidateSamplesData(True)
    End Function

    'Protected Sub DateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtCollectionDate.EditValueChanged, cbAccessionDate.EditValueChanged
    '    'RaiseEvent evDateChanged(sender, e)
    '    SamplesGridView.PostEditor()
    '    IsCurrentSpecimenRowValid(-1, True)
    'End Sub
    'Private m_EventPcessing As Boolean
    'Protected Sub DateLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtCollectionDate.Leave, cbAccessionDate.Leave
    '    If m_EventPcessing Then Return
    '    m_EventPcessing = True
    '    RaiseEvent evDateChanged(sender, e)
    '    m_EventPcessing = False
    'End Sub
    Protected Shared Sub SetLookupReadOnly(ByVal ctl As LookUpEdit, ByVal read As Boolean)
        ctl.Properties.ReadOnly = Not read
        ctl.Enabled = read
        For Each btn As EditorButton In ctl.Properties.Buttons
            btn.Enabled = read
        Next
    End Sub

    '<Browsable(False)> _
    'Public ReadOnly Property dtCollectionDate() As RepositoryItemDateEdit
    '    Get
    '        Return Me.m_dtCollectionDate
    '    End Get
    'End Property

    Private Sub SamplesGridView_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) _
        Handles SamplesGridView.CellValueChanged
        UpdateButtons()
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property SamplesView() As GridView
        Get
            Return Me.SamplesGridView
        End Get
    End Property

    Private Sub cbSpecimenType_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles cbSpecimenType.QueryPopUp
        Dim row As DataRow = SamplesGridView.GetFocusedDataRow()
        If Not row Is Nothing Then
            UpdateSampleTypeDataSource(row("idfParty"))
        End If
    End Sub

    Private Sub cbSpecimenType_QueryCloseUp(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles cbSpecimenType.QueryCloseUp
        If (TypeOf (Me.cbSpecimenType.DataSource) Is DataView) Then
            CType(Me.cbSpecimenType.DataSource, DataView).RowFilter = ""
        End If
    End Sub

    Private Sub cbCollectedByOfficer_SetFilter(sender As Object, e As EventArgs)
        Dim i As Integer = Me.SamplesGridView.FocusedRowHandle
        Dim row As DataRow = SamplesGridView.GetDataRow(i)
        If (Not row Is Nothing) Then
            LookupBinder.SetPersonFilter(row, "idfFieldCollectedByOffice", CType(sender, LookUpEdit))
        End If
    End Sub

    Private Sub cbCollectedByOfficer_QueryPopUp(sender As Object, e As CancelEventArgs)
        Dim row As DataRow = SamplesGridView.GetFocusedDataRow()
        If Not row Is Nothing Then
            LookupBinder.SetPersonFilter(row, "idfFieldCollectedByOffice", CType(sender, LookUpEdit))
        End If
    End Sub

    Private Sub SamplesGridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) _
        Handles SamplesGridView.InitNewRow
        Dim row As DataRow = SamplesGridView.GetDataRow(e.RowHandle)
        CaseSamplesDbService.InitNewRow(row, DefaultPartyID, GetLastRow())
        ShowSampleDetails(e.RowHandle)
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property Grid As GridControl
        Get
            Return SamplesGrid
        End Get
    End Property

    Public ReadOnly Property CollectionDateCaption As String
        Get
            Return colCollectionDate.Caption
        End Get
    End Property

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CollectionDateValidator As DateChainValidator

    Protected Overrides Sub RegisterValidators()
        CollectionDateValidator = New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples,
                                                         "datFieldCollectionDate", colCollectionDate.Caption, , , , True,
                                                         , AddressOf UpdateButtons)
    End Sub

#Region "Samples Filtration"

    Public cbFilteredSampleTypeEditor As RepositoryItemLookUpEdit = New RepositoryItemLookUpEdit

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FilterSamplesByDiagnosis As Boolean

    Private m_DiagnosesList() As Long

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public WriteOnly Property DiagnosisList() As Long()
        Set(ByVal Value As Long())
            m_DiagnosesList = Value
            CaseSamples_Db.PrepareFilteredSamples(m_DiagnosesList, baseDataSet,
                                                  CType(cbSpecimenType.DataSource, DataView))
        End Set
    End Property

    Private Sub SamplesGridView_CustomRowCellEditForEditing(ByVal sender As Object,
                                                            ByVal e As CustomRowCellEditEventArgs)
        RaiseEvent evGridViewCustomRowCellEditForEditing(sender, e)
        If Not (e.Column Is colSpecimenType) Then Exit Sub
        If FilterSamplesBydiagnosis = False Then Exit Sub
        If baseDataSet.Tables.Contains(CaseSamples_Db.TableFiltered) Then
            cbFilteredSampleTypeEditor.DataSource = baseDataSet.Tables(CaseSamples_Db.TableFiltered)
        Else
            cbFilteredSampleTypeEditor.DataSource = cbSpecimenType.DataSource
        End If
        e.RepositoryItem = cbFilteredSampleTypeEditor
    End Sub

#End Region
End Class


