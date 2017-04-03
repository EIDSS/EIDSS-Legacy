Imports System.ComponentModel
Imports bv.model.BLToolkit
Imports bv.common.db
Imports bv.common.Configuration
Imports eidss.model.Core
Imports eidss.Core
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports bv.winclient.Localization
Imports bv.winclient.Core
Imports eidss.model.Resources
Imports eidss.model.Enums
Imports bv.common.win.Validators

Public Class FarmTreePanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public VetFarmTreeDbService As VetFarmTree_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        VetFarmTreeDbService = New VetFarmTree_DB
        DbService = VetFarmTreeDbService
        ' Dim dbl As New FlexibleForm_DB(ffObjectDetails)
        RegisterChildObject(ffObjectDetails, RelatedPostOrder.PostLast)
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
    Friend WithEvents FarmTree As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbSpiecesList As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ffObjectDetails As eidss.FlexibleForms.FFPresenter
    Friend WithEvents FarmTreeGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents colName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTotalAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSeekAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colNote As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents InvestigationGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbObjectType As System.Windows.Forms.Label
    Friend WithEvents btnPaste As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents btnNewSpecies As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNewHerd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colDeadAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colAge As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colStartOfSigns As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents dtStartOfSigns As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents txtDeadQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents txtSickQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents txtAvgAge As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents txtTotalQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FarmTreePanel))
        Me.FarmTreeGroup = New DevExpress.XtraEditors.GroupControl()
        Me.btnNewSpecies = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.FarmTree = New DevExpress.XtraTreeList.TreeList()
        Me.colName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTotalAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtTotalQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colDeadAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtDeadQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colSeekAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtSickQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colAge = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtAvgAge = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colStartOfSigns = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.dtStartOfSigns = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colNote = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtNote = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.cbSpiecesList = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnNewHerd = New DevExpress.XtraEditors.SimpleButton()
        Me.InvestigationGroup = New DevExpress.XtraEditors.GroupControl()
        Me.btnPaste = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.lbObjectType = New System.Windows.Forms.Label()
        Me.ffObjectDetails = New eidss.FlexibleForms.FFPresenter()
        Me.Timer1 = New System.Windows.Forms.Timer()
        CType(Me.FarmTreeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmTreeGroup.SuspendLayout()
        CType(Me.FarmTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeadQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSickQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvgAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartOfSigns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartOfSigns.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpiecesList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvestigationGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InvestigationGroup.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(FarmTreePanel), resources)
        'Form Is Localizable: True
        '
        'FarmTreeGroup
        '
        Me.FarmTreeGroup.Appearance.BackColor = CType(resources.GetObject("FarmTreeGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmTreeGroup.Appearance.Options.UseBackColor = True
        Me.FarmTreeGroup.AppearanceCaption.Options.UseFont = True
        Me.FarmTreeGroup.Controls.Add(Me.btnNewSpecies)
        Me.FarmTreeGroup.Controls.Add(Me.btnDelete)
        Me.FarmTreeGroup.Controls.Add(Me.FarmTree)
        Me.FarmTreeGroup.Controls.Add(Me.btnNewHerd)
        resources.ApplyResources(Me.FarmTreeGroup, "FarmTreeGroup")
        Me.FarmTreeGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmTreeGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmTreeGroup.Name = "FarmTreeGroup"
        '
        'btnNewSpecies
        '
        Me.btnNewSpecies.Image = Global.eidss.My.Resources.Resources.add
        resources.ApplyResources(Me.btnNewSpecies, "btnNewSpecies")
        Me.btnNewSpecies.Name = "btnNewSpecies"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        '
        'FarmTree
        '
        resources.ApplyResources(Me.FarmTree, "FarmTree")
        Me.FarmTree.Appearance.Empty.Options.UseFont = True
        Me.FarmTree.Appearance.EvenRow.Options.UseFont = True
        Me.FarmTree.Appearance.FixedLine.Options.UseFont = True
        Me.FarmTree.Appearance.FocusedCell.Options.UseFont = True
        Me.FarmTree.Appearance.FocusedRow.Options.UseFont = True
        Me.FarmTree.Appearance.FooterPanel.Options.UseFont = True
        Me.FarmTree.Appearance.GroupButton.Options.UseFont = True
        Me.FarmTree.Appearance.GroupFooter.Options.UseFont = True
        Me.FarmTree.Appearance.HeaderPanel.Options.UseFont = True
        Me.FarmTree.Appearance.HideSelectionRow.Options.UseFont = True
        Me.FarmTree.Appearance.HorzLine.Options.UseFont = True
        Me.FarmTree.Appearance.OddRow.Options.UseFont = True
        Me.FarmTree.Appearance.Preview.Options.UseFont = True
        Me.FarmTree.Appearance.Row.Options.UseFont = True
        Me.FarmTree.Appearance.SelectedRow.Options.UseFont = True
        Me.FarmTree.Appearance.TreeLine.Options.UseFont = True
        Me.FarmTree.Appearance.VertLine.Options.UseFont = True
        Me.FarmTree.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colName, Me.colTotalAnimalQty, Me.colDeadAnimalQty, Me.colSeekAnimalQty, Me.colAge, Me.colStartOfSigns, Me.colNote})
        Me.FarmTree.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmTree.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmTree.Name = "FarmTree"
        Me.FarmTree.OptionsBehavior.PopulateServiceColumns = True
        Me.FarmTree.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSpiecesList, Me.txtNote, Me.txtTotalQty, Me.dtStartOfSigns, Me.txtDeadQty, Me.txtSickQty, Me.txtAvgAge})
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        Me.colName.FieldName = "strName"
        Me.colName.Name = "colName"
        Me.colName.Tag = "[en]"
        '
        'colTotalAnimalQty
        '
        resources.ApplyResources(Me.colTotalAnimalQty, "colTotalAnimalQty")
        Me.colTotalAnimalQty.ColumnEdit = Me.txtTotalQty
        Me.colTotalAnimalQty.FieldName = "intTotalAnimalQty"
        Me.colTotalAnimalQty.Name = "colTotalAnimalQty"
        '
        'txtTotalQty
        '
        resources.ApplyResources(Me.txtTotalQty, "txtTotalQty")
        Me.txtTotalQty.IsFloatValue = False
        Me.txtTotalQty.Mask.EditMask = resources.GetString("txtTotalQty.Mask.EditMask")
        Me.txtTotalQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtTotalQty.Name = "txtTotalQty"
        '
        'colDeadAnimalQty
        '
        resources.ApplyResources(Me.colDeadAnimalQty, "colDeadAnimalQty")
        Me.colDeadAnimalQty.ColumnEdit = Me.txtDeadQty
        Me.colDeadAnimalQty.FieldName = "intDeadAnimalQty"
        Me.colDeadAnimalQty.Name = "colDeadAnimalQty"
        '
        'txtDeadQty
        '
        resources.ApplyResources(Me.txtDeadQty, "txtDeadQty")
        Me.txtDeadQty.IsFloatValue = False
        Me.txtDeadQty.Mask.EditMask = resources.GetString("txtDeadQty.Mask.EditMask")
        Me.txtDeadQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtDeadQty.Name = "txtDeadQty"
        '
        'colSeekAnimalQty
        '
        resources.ApplyResources(Me.colSeekAnimalQty, "colSeekAnimalQty")
        Me.colSeekAnimalQty.ColumnEdit = Me.txtSickQty
        Me.colSeekAnimalQty.FieldName = "intSickAnimalQty"
        Me.colSeekAnimalQty.Name = "colSeekAnimalQty"
        '
        'txtSickQty
        '
        resources.ApplyResources(Me.txtSickQty, "txtSickQty")
        Me.txtSickQty.IsFloatValue = False
        Me.txtSickQty.Mask.EditMask = resources.GetString("txtSickQty.Mask.EditMask")
        Me.txtSickQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtSickQty.Name = "txtSickQty"
        '
        'colAge
        '
        resources.ApplyResources(Me.colAge, "colAge")
        Me.colAge.ColumnEdit = Me.txtAvgAge
        Me.colAge.FieldName = "strAverageAge"
        Me.colAge.Name = "colAge"
        '
        'txtAvgAge
        '
        resources.ApplyResources(Me.txtAvgAge, "txtAvgAge")
        Me.txtAvgAge.Mask.EditMask = resources.GetString("txtAvgAge.Mask.EditMask")
        Me.txtAvgAge.Name = "txtAvgAge"
        '
        'colStartOfSigns
        '
        resources.ApplyResources(Me.colStartOfSigns, "colStartOfSigns")
        Me.colStartOfSigns.ColumnEdit = Me.dtStartOfSigns
        Me.colStartOfSigns.FieldName = "datStartOfSignsDate"
        Me.colStartOfSigns.Name = "colStartOfSigns"
        '
        'dtStartOfSigns
        '
        resources.ApplyResources(Me.dtStartOfSigns, "dtStartOfSigns")
        Me.dtStartOfSigns.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtStartOfSigns.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtStartOfSigns.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtStartOfSigns.Name = "dtStartOfSigns"
        '
        'colNote
        '
        resources.ApplyResources(Me.colNote, "colNote")
        Me.colNote.ColumnEdit = Me.txtNote
        Me.colNote.FieldName = "strNote"
        Me.colNote.Name = "colNote"
        '
        'txtNote
        '
        Me.txtNote.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtNote.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ShowIcon = False
        '
        'cbSpiecesList
        '
        resources.ApplyResources(Me.cbSpiecesList, "cbSpiecesList")
        Me.cbSpiecesList.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpiecesList.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpiecesList.Name = "cbSpiecesList"
        '
        'btnNewHerd
        '
        Me.btnNewHerd.Image = Global.eidss.My.Resources.Resources.add
        resources.ApplyResources(Me.btnNewHerd, "btnNewHerd")
        Me.btnNewHerd.Name = "btnNewHerd"
        '
        'InvestigationGroup
        '
        resources.ApplyResources(Me.InvestigationGroup, "InvestigationGroup")
        Me.InvestigationGroup.Appearance.BackColor = CType(resources.GetObject("InvestigationGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.InvestigationGroup.Appearance.Options.UseBackColor = True
        Me.InvestigationGroup.AppearanceCaption.Options.UseFont = True
        Me.InvestigationGroup.Controls.Add(Me.btnPaste)
        Me.InvestigationGroup.Controls.Add(Me.btnCopy)
        Me.InvestigationGroup.Controls.Add(Me.btnClear)
        Me.InvestigationGroup.Controls.Add(Me.lbObjectType)
        Me.InvestigationGroup.Controls.Add(Me.ffObjectDetails)
        Me.InvestigationGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.InvestigationGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.InvestigationGroup.Name = "InvestigationGroup"
        Me.InvestigationGroup.TabStop = True
        '
        'btnPaste
        '
        Me.btnPaste.Image = Global.eidss.My.Resources.Resources.paste
        resources.ApplyResources(Me.btnPaste, "btnPaste")
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.TabStop = False
        '
        'btnCopy
        '
        Me.btnCopy.Image = Global.eidss.My.Resources.Resources.copy
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Image = Global.eidss.My.Resources.Resources.Clear_Cancel_Changes1
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabStop = False
        '
        'lbObjectType
        '
        resources.ApplyResources(Me.lbObjectType, "lbObjectType")
        Me.lbObjectType.Name = "lbObjectType"
        '
        'ffObjectDetails
        '
        resources.ApplyResources(Me.ffObjectDetails, "ffObjectDetails")
        Me.ffObjectDetails.Appearance.BackColor = CType(resources.GetObject("ffObjectDetails.Appearance.BackColor"), System.Drawing.Color)
        Me.ffObjectDetails.Appearance.Options.UseBackColor = True
        Me.ffObjectDetails.DelayedLoadingNeeded = False
        Me.ffObjectDetails.DynamicParameterEnabled = False
        Me.ffObjectDetails.FormID = Nothing
        Me.ffObjectDetails.HelpTopicID = Nothing
        Me.ffObjectDetails.KeyFieldName = Nothing
        Me.ffObjectDetails.MultiSelect = False
        Me.ffObjectDetails.Name = "ffObjectDetails"
        Me.ffObjectDetails.ObjectName = Nothing
        Me.ffObjectDetails.SectionTableCaptionsIsVisible = True
        Me.ffObjectDetails.TableName = Nothing
        Me.ffObjectDetails.UseParentBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'FarmTreePanel
        '
        Me.Controls.Add(Me.InvestigationGroup)
        Me.Controls.Add(Me.FarmTreeGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.KeyFieldName = "idfParty"
        Me.Name = "FarmTreePanel"
        Me.ObjectName = "VetFarmTree"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "VetFarmTree"
        CType(Me.FarmTreeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmTreeGroup.ResumeLayout(False)
        CType(Me.FarmTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeadQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSickQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvgAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartOfSigns.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartOfSigns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpiecesList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvestigationGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InvestigationGroup.ResumeLayout(False)
        Me.InvestigationGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Flex Form Support"

    Private Sub RefreshFlexibleForm()
        If Loading Then Return
        m_Loading += 1
        Try
            Dim rview As DataRowView = ObjectRowView
            If rview Is Nothing Then
                SetFlexibleFormVisibility(False)
                Return
            End If
            Dim formType As FFType = FFType.None
            Select Case CType(rview.Row("idfsPartyType"), PartyType)
                Case PartyType.Farm
                    If m_CaseKind = CaseType.Avian Then
                        formType = FFType.AvianFarmEPI
                        InvestigationGroup.Text = EidssMessages.Get("sectionTitleAvianEpiInfo", "Epi Information")
                    Else
                        formType = FFType.LivestockFarmEPI
                        InvestigationGroup.Text = EidssMessages.Get("sectionTitleEpiInfo", "Epi Information")
                    End If

                    If rview("idfObservation") Is DBNull.Value Then
                        rview("idfObservation") = BaseDbService.NewIntID
                    End If
                Case PartyType.Herd
                    SetFlexibleFormVisibility(False)
                    Return
                Case PartyType.Species
                    If m_CaseKind = CaseType.Avian Then
                        formType = FFType.AvianSpeciesCS
                        InvestigationGroup.Text = EidssMessages.Get("lblClinicalSignsAvian", "Clinical Signs")
                    Else
                        formType = FFType.LivestockSpeciesCS
                        InvestigationGroup.Text = EidssMessages.Get("lblClinicalSigns", "Clinical Signs")
                    End If
                    If rview("idfObservation") Is DBNull.Value Then
                        rview("idfObservation") = BaseDbService.NewIntID
                    End If
            End Select

            SetFlexibleFormVisibility(True)
            ShowFlexibleForm(rview.Row, formType)
        Finally
            m_Loading -= 1

        End Try

    End Sub

    Dim m_CurrentFlexibleFormID As Long = -1
    Private Sub ShowFlexibleForm(ByVal row As DataRow, ByVal formType As FFType)
        Dim objectId As Long = CLng(row("idfObservation"))

        If CLng(m_CurrentFlexibleFormID) = objectId Then
            Return
        End If
        If row("idfsFormTemplate") Is DBNull.Value Then
            ffObjectDetails.ShowFlexibleFormByDeterminant(-1L, objectId, formType) 'm_DiagnosisID
            If ffObjectDetails.TemplateID.HasValue AndAlso ffObjectDetails.TemplateID.Value > 0 Then
                row("idfsFormTemplate") = ffObjectDetails.TemplateID.Value
            End If
        Else
            ffObjectDetails.ShowFlexibleFormByDeterminant(-1L, objectId, formType) 'm_DiagnosisID
            If ffObjectDetails.TemplateID.HasValue AndAlso Not row("idfsFormTemplate").Equals(ffObjectDetails.TemplateID.Value) Then
                row("idfsFormTemplate") = ffObjectDetails.TemplateID.Value
            End If
        End If
        RefreshObjectLabel(row)
        ffObjectDetails.ReadOnly = Me.ReadOnly
        m_CurrentFlexibleFormID = objectId
    End Sub

#End Region

    Public CanDeleteRow As CanDeleteRowHandler
    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is ffObjectDetails Then
            Return Nothing
        End If
        If Not Me.ParentObject Is Nothing Then
            Return CType(ParentObject, BaseForm).GetKey()
        End If
        Return GetKey()
    End Function
    Public Property HidePersonalData As Boolean


    Protected Overrides Sub DefineBinding()
        Dim group As PersonalDataGroup = PersonalDataGroup.None
        FarmTree.DataSource = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
        FarmTree.KeyFieldName = "idfParty"
        FarmTree.ParentFieldName = "idfParentParty"
        If HidePersonalData Then
            If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details) Then
                group = PersonalDataGroup.Vet_Farm_Details
            ElseIf EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement) Then
                group = PersonalDataGroup.Vet_Farm_Settlement
            End If
        End If
        If (group <> PersonalDataGroup.None) Then
            FarmCode = "*"
        End If
        If Me.CaseKind = CaseType.Avian Then
            Core.LookupBinder.BindBaseRepositoryLookup(Me.cbSpiecesList, _
                db.BaseReferenceType.rftSpeciesList, _
                HACode.Avian, AddressOf LookupBinder.AddSpecies)
        Else
            Core.LookupBinder.BindBaseRepositoryLookup(Me.cbSpiecesList, _
                db.BaseReferenceType.rftSpeciesList, _
                HACode.Livestock, AddressOf LookupBinder.AddSpecies)
        End If
        Core.LookupBinder.RemoveEmptyRow(CType(cbSpiecesList.DataSource, DataView))
        Dim SpeciesLookupTable As DataTable = CType(cbSpiecesList.DataSource, DataView).Table
        If Not SpeciesLookupTable.Columns.Contains("strReference") Then
            SpeciesLookupTable.Columns.Add(New DataColumn("strReference", GetType(String), "Convert(idfsReference, 'System.String')"))
        End If
        Me.cbSpiecesList.ValueMember = "strReference"
        FarmTree.ExpandAll()
        btnNewHerd.Text = NewHerdCaption
        colName.Caption = ColumnNameCaption
        FarmTreeGroup.Text = FarmTreeGroupCaption
        Select Case m_CaseKind
            Case CaseType.Avian
                colAge.Visible = True
                colDeadAnimalQty.Visible = True
                colStartOfSigns.Visible = True
                colNote.Visible = False
                FarmTreeGroup.Height = InvestigationGroup.Height
            Case CaseType.Livestock
                colAge.Visible = False
                colDeadAnimalQty.Visible = True
                colStartOfSigns.Visible = True
                colNote.Visible = True
        End Select

        eventManager.AttachDataHandler(VetFarmTree_DB.TableFarmTree + ".intTotalAnimalQty", AddressOf Total_Changed)
        eventManager.AttachDataHandler(VetFarmTree_DB.TableFarmTree + ".intSickAnimalQty", AddressOf Sick_Changed)
        eventManager.AttachDataHandler(VetFarmTree_DB.TableFarmTree + ".intDeadAnimalQty", AddressOf Dead_Changed)
        If [ReadOnly] Then
            Me.FarmTree.OptionsBehavior.Editable = False
        End If
    End Sub
    Private Sub RecalcQty(ByVal fieldName As String, ByVal e As DataFieldChangeEventArgs)
        If baseDataSet Is Nothing Then
            Return
        End If
        For Each row As DataRow In baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows
            If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                Continue For
            End If
            If CType(row("idfsPartyType"), PartyType).Equals(PartyType.Herd) Then
                row(fieldName) = baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfParentParty={0}", row("idfParty")))
                row.EndEdit()
            End If
        Next
        Dim farmRow As DataRow = baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows.Find(GetKey())
        If Not farmRow Is Nothing Then
            farmRow(fieldName) = baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfsPartyType={0}", CLng(PartyType.Species)))
            farmRow.EndEdit()
        End If
    End Sub
    Private Sub Dead_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        RecalcQty("intDeadAnimalQty", e)
    End Sub

    Private Sub Sick_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        RecalcQty("intSickAnimalQty", e)
    End Sub

    Private Sub Total_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        RecalcQty("intTotalAnimalQty", e)
    End Sub

    Private Sub cbSpiecesList_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSpiecesList.EditValueChanged
        Dim rview As DataRowView = ObjectRowView
        If CLng(PartyType.Species).Equals(rview("idfsPartyType")) Then
            RefreshSpiecesList()
        End If
    End Sub
    Private Sub cbSpiecesList_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbSpiecesList.EditValueChanging
        Dim rview As DataRowView = ObjectRowView
        If CLng(PartyType.Species).Equals(rview("idfsPartyType")) Then
            If VetFarmTreeDbService.ValidateNewSpecies(rview.Row, Utils.Str(e.NewValue)) = False Then
                e.Cancel = True
                MessageForm.Show(String.Format(EidssMessages.Get("strSpeciesExist", "Such species exists in the {0} already. Select other species."), HerdCaption))
            ElseIf CanChangeSpecies(rview.Row) = False Then
                e.Cancel = True
                If Me.CaseKind = CaseType.Livestock Then
                    MessageForm.Show(String.Format(EidssMessages.Get("strCantChangeLivestockSpecies", "There are animals that refer this species. You should delete these animals before species change")))
                Else
                    MessageForm.Show(String.Format(EidssMessages.Get("strCantChangeAvianSpecies", "There are samples that refer this species. You should delete these samples before species change")))
                End If
            Else
                If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = LookupCache.EmptyLineKey.ToString() Then
                    e.NewValue = DBNull.Value
                End If
                rview("strName") = e.NewValue
                rview.EndEdit()
            End If
        Else
            If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = LookupCache.EmptyLineKey.ToString() Then
                e.NewValue = DBNull.Value
            End If
        End If

    End Sub

    Private Sub Name_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
    End Sub

    Private Sub btnNewHerd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewHerd.Click

        If FarmTree.Nodes.Count > 0 Then
            BeginUpdate()
            FarmTree.FocusedNode = FarmTree.Nodes(0)
            EndUpdate()
        Else
            Return
        End If
        NewFarmObject()
    End Sub

    Private Sub btnNewSpecies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSpecies.Click
        If FarmTree.FocusedNode Is Nothing OrElse FarmTree.FocusedNode Is FarmTree.Nodes(0) Then
            Return
        End If
        NewFarmObject()
    End Sub

    Private Sub NewFarmObject()
        If ValidateTreeNode(FarmTree.FocusedNode) = False Then
            Return
        End If
        BeginUpdate()
        Dim row As DataRowView = ObjectRowView
        Dim newRow As DataRow = Nothing
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Farm
                newRow = VetFarmTreeDbService.AddHerd(row.Row)
            Case PartyType.Herd
                newRow = VetFarmTreeDbService.AddHerdSpieces(row.Row)
                m_ShowPopupImmediatly = True
            Case PartyType.Species
                row = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode.ParentNode), DataRowView)
                newRow = VetFarmTreeDbService.AddHerdSpieces(row.Row)
                m_ShowPopupImmediatly = True
        End Select
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = FarmTree.FindNodeByKeyID(newRow("idfParty"))
        If Not node Is Nothing Then
            node.ParentNode.ExpandAll()
            FarmTree.FocusedNode = node
            FarmTree.FocusedColumn = FarmTree.Columns(0)

        End If
        EndUpdate()
        RefreshFlexibleForm()
        FarmTree.ShowEditor()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If FarmTree.FocusedNode Is Nothing OrElse FarmTree.FocusedNode.Level = 0 Then
            Return
        End If
        Dim row As DataRowView = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        If Not CanDeleteRow Is Nothing AndAlso CanDeleteRow(row.Row) = False Then

            Dim CantDeleteMessage As String = ""
            Dim Caption As String = ""
            Select Case dtype
                Case PartyType.Farm
                    Return
                Case PartyType.Herd
                    If Me.CaseKind = CaseType.Livestock Then
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteHerd", "Can't delete herd. Delete all animals related with this herd before herd deletion.")
                    Else
                        CantDeleteMessage = EidssMessages.Get("msgCantDeletFlock", "Can't delete flock. Delete all registered samples/vaccitations/penside tests related with this flock before flock deletion.")
                    End If
                    Caption = String.Format(EidssMessages.Get("msgDeleteHerdCaption", "Delete {0}"), HerdCaption)
                Case PartyType.Species
                    If Me.CaseKind = CaseType.Livestock Then
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteLivestockSpecies", "Can't delete species. Delete all animals/vaccitations related with this species before species deletion.")
                    Else
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteAvianSpecies", "Can't delete species. Delete all registered samples/vaccitations/penside tests related with this species before species deletion.")
                    End If
                    Caption = EidssMessages.Get("msgDeleteSpeciesCaption", "Delete species")
            End Select
            MessageForm.Show(CantDeleteMessage, Caption, MessageBoxButtons.OK)
            Return
        Else
            If DeletePromptDialog() <> DialogResult.Yes Then
                Return
            End If
        End If
        BeginUpdate()
        FarmTree.DeleteNode(FarmTree.FocusedNode)
        EndUpdate()
        If dtype = PartyType.Species Then
            RefreshSpiecesList()
        End If
        RefreshFlexibleForm()
        RecalcQty("intDeadAnimalQty", New DataFieldChangeEventArgs(Nothing, Nothing, Nothing, Nothing))
        RecalcQty("intSickAnimalQty", New DataFieldChangeEventArgs(Nothing, Nothing, Nothing, Nothing))
        RecalcQty("intTotalAnimalQty", New DataFieldChangeEventArgs(Nothing, Nothing, Nothing, Nothing))

    End Sub
    Private m_AnimalsList As DataView = Nothing
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property AnimalsList() As DataView
        Get
            Return m_AnimalsList
        End Get
        Set(ByVal value As DataView)
            m_AnimalsList = value
        End Set
    End Property
    Private m_SamplesList As DataView = Nothing
    Public Property SamplesList() As DataView
        Get
            Return m_SamplesList
        End Get
        Set(ByVal value As DataView)
            m_SamplesList = value
        End Set
    End Property
    Private m_CaseKind As CaseType = CaseType.Livestock
    Property CaseKind() As CaseType
        Get
            Return m_CaseKind
        End Get
        Set(ByVal Value As CaseType)
            m_CaseKind = Value
            If Value = CaseType.Livestock Then
                Me.FarmTreeGroup.Height = 273 - Me.FarmTreeGroup.Top - 8
                Me.VetFarmTreeDbService.HACode = HACode.Livestock
            Else
                Me.FarmTreeGroup.Height = Me.InvestigationGroup.Height
                Me.VetFarmTreeDbService.HACode = HACode.Avian
            End If
        End Set
    End Property

    Private ReadOnly Property HerdCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strFlock")
                Case CaseType.Livestock : Return EidssMessages.Get("strHerd")
            End Select
            Return EidssMessages.Get("strHerd")
        End Get
    End Property
    Private ReadOnly Property NewHerdCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strNewFlock")
                Case CaseType.Livestock : Return EidssMessages.Get("strNewHerd")
            End Select
            Return EidssMessages.Get("strNewHerd")
        End Get
    End Property
    Private ReadOnly Property ColumnNameCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strAvianFarmTreeNode")
                Case CaseType.Livestock : Return EidssMessages.Get("strLivestockFarmTreeNode")
            End Select
            Return EidssMessages.Get("strLivestockFarmTreeNode")
        End Get
    End Property
    Private ReadOnly Property FarmTreeGroupCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strFlockSpeciesInfo")
                Case CaseType.Livestock : Return EidssMessages.Get("strHerdSpeciesInfo")
            End Select
            Return EidssMessages.Get("strHerdSpeciesInfo")
        End Get
    End Property

    Private Sub FarmTree_CustomDrawNodeCell(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs) Handles FarmTree.CustomDrawNodeCell
        If e.Node.Level = 0 AndAlso Not (e.Column Is colName OrElse e.Column Is colTotalAnimalQty OrElse e.Column Is colDeadAnimalQty OrElse e.Column Is colSeekAnimalQty) Then
            e.CellText = ""
            e.Handled = True
        ElseIf (e.Node.Level = 1 AndAlso e.Column Is colNote) Then
            e.CellText = ""
            e.Handled = True
        ElseIf (e.Column Is colStartOfSigns AndAlso e.Node.Level < 2) Then
            e.CellText = ""
            e.Handled = True
        End If
    End Sub
    Private Sub FarmTree_CustomNodeCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs) Handles FarmTree.CustomNodeCellEdit
        'If IsDesignMode() Then Return
        If FarmTree.GetDataRecordByNode(e.Node) Is Nothing Then
            Return
        End If
        Dim row As DataRow = CType(FarmTree.GetDataRecordByNode(e.Node), DataRowView).Row
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Species
                If e.Column.FieldName = "strName" Then
                    e.RepositoryItem = Me.cbSpiecesList
                Else
                    e.RepositoryItem = Nothing
                End If
            Case Else
                e.RepositoryItem = Nothing
        End Select
    End Sub

    Private Sub FarmTree_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FarmTree.ShowingEditor
        If Closing Then Return
        'If IsDesignMode() Then Return
        If [ReadOnly] Then
            e.Cancel = True
            Return
        End If
        If Not Me.Visible Then
            e.Cancel = True
            Return
        End If
        Dim row As DataRow = ObjectRow
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Dim col As DevExpress.XtraTreeList.Columns.TreeListColumn = FarmTree.FocusedColumn
        Select Case dtype
            Case PartyType.Farm
                'If col.FieldName <> "intTotalAnimalQty" Then
                e.Cancel = True
                'End If
            Case PartyType.Herd
                'If col.FieldName = "strName" _
                '                                OrElse col.FieldName = "strAverageAge" _
                '                                OrElse col.FieldName = "datStartOfSignsDate" Then 'OrElse col.FieldName = "intDeadAnimalQty"
                e.Cancel = True
                'End If
        End Select

    End Sub

    Private Function CanChangeSpecies(ByVal speciesRow As DataRow) As Boolean
        If Utils.Str(speciesRow("strName")) = "" Then
            Return True
        End If
        If CaseKind = CaseType.Livestock Then
            If AnimalsList Is Nothing OrElse AnimalsList.Count = 0 Then
                Return True
            End If
            AnimalsList.RowFilter = String.Format("idfHerd = {0} AND idfsSpeciesType={1}", Utils.Str(speciesRow("idfParentParty")), speciesRow("strName").ToString)
            Dim SpeciesAnimalsCount As Integer = AnimalsList.Count
            AnimalsList.RowFilter = ""
            If SpeciesAnimalsCount = 0 Then
                Return True
            End If
        Else
            If SamplesList Is Nothing OrElse SamplesList.Count = 0 Then
                Return True
            End If
            SamplesList.RowFilter = String.Format("idfParty = {0}", speciesRow("idfParty")) 'and Used = 1
            Dim SamplesCount As Integer = SamplesList.Count
            SamplesList.RowFilter = ""
            If SamplesCount = 0 Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDesignMode() Then Return
        btnDelete.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level > 0
        btnNewHerd.Enabled = Not [ReadOnly] AndAlso FarmTree.Nodes.Count > 0
        btnNewSpecies.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level > 0
        Dim row As DataRow = ObjectRow
        If row Is Nothing Then
            btnCopy.Enabled = False
            btnPaste.Enabled = False
            btnClear.Enabled = False
            Return
        End If
        Dim observationId As Object = row("idfObservation")
        Dim dataExists As Boolean = False
        If Not observationId Is DBNull.Value _
                AndAlso Not ffObjectDetails Is Nothing _
                AndAlso Not ffObjectDetails.MainDbService Is Nothing _
                AndAlso Not ffObjectDetails.MainDbService.MainDataSet Is Nothing _
                AndAlso Not ffObjectDetails.MainDbService.MainDataSet.ActivityParameters Is Nothing _
                AndAlso ffObjectDetails.MainDbService.MainDataSet.ActivityParameters.Select(String.Format("idfObservation = {0}", observationId)).Length > 0 Then
            dataExists = True
        End If
        btnClear.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level >= 0 AndAlso dataExists
        btnCopy.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level > 1 AndAlso dataExists
        btnPaste.Enabled = ffObjectDetails.CanPaste
    End Sub

    Private ReadOnly Property HerdFilter() As String
        Get
            Return String.Format("idfsPartyType={0}", CLng(PartyType.Herd))
        End Get
    End Property
    Public ReadOnly Property HerdsList() As DataView
        Get
            Dim dv As DataView = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
            dv.RowFilter = HerdFilter
            Return dv
        End Get
    End Property
    Private ReadOnly Property SpeciesFilter() As String
        Get
            Return String.Format("idfsPartyType={0}", CLng(PartyType.Species))
        End Get
    End Property
    Public ReadOnly Property HerdSpecies() As DataView
        Get
            Dim dv As DataView = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
            dv.RowFilter = SpeciesFilter
            Return dv
        End Get
    End Property

    Private Sub FarmTree_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles FarmTree.FocusedNodeChanged
        If Visible = False OrElse Loading OrElse Closing Then Return
        If ValidateTreeNode(e.OldNode) = False Then
            BeginUpdate()
            FarmTree.FocusedNode = e.OldNode
            EndUpdate()
            Return
        End If
        RefreshFlexibleForm()
    End Sub
    Private Sub SetFlexibleFormVisibility(ByVal aVisible As Boolean)
        Me.ffObjectDetails.Visible = aVisible
        'pnObjectInfo.Visible = aVisible
        btnClear.Visible = aVisible
        btnCopy.Visible = aVisible
        btnPaste.Visible = aVisible
        InvestigationGroup.Visible = aVisible
    End Sub
    Private ReadOnly Property ObjectRow() As DataRow
        Get
            If FarmTree.FocusedNode Is Nothing Then Return Nothing
            Return (CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView).Row)
        End Get
    End Property
    Private ReadOnly Property ObjectRowView() As DataRowView
        Get
            If FarmTree.FocusedNode Is Nothing Then Return Nothing
            Return CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
        End Get
    End Property

    Private m_DiagnosisID As Long = -1
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisID() As Long
        Set(ByVal Value As Long)
            If m_DiagnosisID <> Value Then
                m_DiagnosisID = Value
                UpdateFFTemplates()
                'RefreshFlexibleForm()
            End If
        End Set
    End Property

    Private Sub UpdateFFTemplates()
        If Not RootBaseForm.Loading Then

            Dim templateID As Nullable(Of Long)
            For Each row As DataRow In baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows
                If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                    Continue For
                End If
                Select Case CType(row("idfsPartyType"), PartyType)
                    Case PartyType.Farm
                        If m_CaseKind = CaseType.Avian Then
                            templateID = ffObjectDetails.GetActualTemplate(m_DiagnosisID, FFType.AvianFarmEPI)
                        Else
                            templateID = ffObjectDetails.GetActualTemplate(m_DiagnosisID, FFType.LivestockFarmEPI)
                        End If
                        If Not row("idfsFormTemplate").Equals(templateID) Then
                            row("idfsFormTemplate") = templateID
                        End If
                    Case PartyType.Species
                        If m_CaseKind = CaseType.Avian Then
                            templateID = ffObjectDetails.GetActualTemplate(m_DiagnosisID, FFType.AvianSpeciesCS)
                        Else
                            templateID = ffObjectDetails.GetActualTemplate(m_DiagnosisID, FFType.LivestockSpeciesCS)
                        End If
                        If Not row("idfsFormTemplate").Equals(templateID) Then
                            row("idfsFormTemplate") = templateID
                        End If
                End Select
            Next
        End If
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property FarmCode() As String
        Set(ByVal Value As String)
            If Not FarmTree Is Nothing AndAlso FarmTree.Nodes.Count > 0 AndAlso Not "*".Equals(FarmTree.Nodes(0)("strName")) Then
                FarmTree.BeginUpdate()
                Dim oldRowState As DataRowState = baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows(0).RowState
                Me.FarmTree.Nodes(0)("strName") = Value
                FarmTree.EndCurrentEdit()
                FarmTree.EndUpdate()
                If oldRowState = DataRowState.Unchanged Then
                    baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows(0).AcceptChanges()
                End If
            End If
        End Set
    End Property

    Private Sub rgFlexFormType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshFlexibleForm()
    End Sub

    Public Function HasAnimalGroups() As Boolean 'OrElse (Me.State And BusinessObjectState.NewObject) = 0 _
        Return baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows.Count > 3 _
                OrElse (baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows.Count = 3 AndAlso CType(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows(2)("idfsPartyType"), PartyType) = PartyType.Species _
                AndAlso Utils.Str(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree).Rows(2)("strName")) <> "")
    End Function
    Public Sub ChangeFarm(ByVal sourceFarmID As Object, ByVal targetFarmID As Object, ByVal farmIDCode As String)
        If FarmTree.Nodes.Count = 0 Then
            BeginUpdate()
            FarmTree.BeginUpdate()
            Me.VetFarmTreeDbService.ChangeFarm(baseDataSet, sourceFarmID, targetFarmID, farmIDCode)
            FarmTree.DataSource = Nothing
            FarmTree.Nodes.Clear()
            FarmTree.DataSource = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
            Try
                FarmTree.ExpandAll()
            Catch ex As Exception
            End Try
            If Not Me.ParentObject Is Nothing AndAlso _
                (CType(Me.ParentObject, BaseForm).State And BusinessObjectState.NewObject) <> 0 _
                AndAlso FarmTree.Nodes.Count > 0 AndAlso m_SelectNewSpiece Then
                Dim node As TreeListNode = FarmTree.Nodes(0)
                While Not node.FirstNode Is Nothing
                    node = node.FirstNode
                End While
                FarmTree.FocusedNode = node
                FarmTree.FocusedColumn = FarmTree.Columns(0)
            End If
            UpdateFFTemplates()
            FarmTree.EndUpdate()
            EndUpdate()
            RefreshFlexibleForm()
        Else
            FarmCode = farmIDCode
        End If
    End Sub

    Private m_SelectNewSpiece As Boolean = True
    Protected Overrides Sub AfterLoad()
        If FarmTree.Nodes.Count > 0 Then
            FarmTree.FocusedNode = FarmTree.Nodes(0)
        End If
        RefreshFlexibleForm()
    End Sub
    Public Function GetHerdSpieciesFilter(ByVal HerdID As Object) As String
        Dim dv As DataView = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
        dv.RowFilter = String.Format("idfParentParty={0}", HerdID)
        Dim species As String = ""
        For Each row As DataRowView In dv
            If Utils.Str(row("strName")) <> "" Then
                If species = "" Then
                    species = row("strName").ToString
                Else
                    species += "," + row("strName").ToString
                End If
            End If
        Next
        If species <> "" Then
            species = "idfsReference in (" + species + ")"
        Else
            species = "idfsReference is NULL"
        End If
        Return species

    End Function
    Dim m_SpiecesTable As DataTable
    Private m_SpeciesView As DataView
    Private m_HerdView As DataView
    Private Sub RefreshSpiecesList()
        Dim SpeciesLookupTable As DataTable = Nothing
        If cbSpiecesList.DataSource Is Nothing Then
            SpeciesLookupTable = LookupCache.Get(db.BaseReferenceType.rftSpeciesList).Table
        Else
            SpeciesLookupTable = CType(cbSpiecesList.DataSource, DataView).Table
        End If
        If m_SpiecesTable Is Nothing Then
            m_SpiecesTable = SpeciesLookupTable.Clone
            m_SpiecesTable.Columns.Add(New DataColumn("idfSpecies", GetType(Long)))
            m_SpiecesTable.Columns.Add(New DataColumn("idfHerd", GetType(Long)))
            m_SpiecesTable.Columns.Add(New DataColumn("strHerdCode", GetType(String)))
            m_SpiecesTable.Columns.Add(New DataColumn("HerdSpecies", GetType(String), "name+' '+strHerdCode"))
            m_SpiecesTable.Columns.Add(New DataColumn("strSpecies", GetType(String), "name"))
            m_SpiecesTable.PrimaryKey = New DataColumn() {m_SpiecesTable.Columns("idfSpecies")}
        End If
        m_SpiecesTable.BeginLoadData()
        m_SpiecesTable.Clear()
        If m_SpeciesView Is Nothing Then
            m_SpeciesView = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
            m_SpeciesView.RowFilter = SpeciesFilter
        End If
        If m_HerdView Is Nothing Then
            m_HerdView = New DataView(baseDataSet.Tables(VetFarmTree_DB.TableFarmTree))
            m_HerdView.RowFilter = HerdFilter
            m_HerdView.Sort = "idfParty"
        End If
        For Each row As DataRowView In m_SpeciesView
            Dim r0 As DataRow = SpeciesLookupTable.Rows.Find(row("strName"))
            If Not r0 Is Nothing Then
                Dim r As DataRow = m_SpiecesTable.NewRow
                r("idfSpecies") = row("idfParty")
                For Each col As DataColumn In r0.Table.Columns
                    r(col.ColumnName) = r0(col.ColumnName)
                Next
                r("idfHerd") = row("idfParentParty")
                Dim index As Integer = m_HerdView.Find(row("idfParentParty"))
                If index >= 0 Then
                    r("strHerdCode") = m_HerdView(index)("strName")
                End If
                m_SpiecesTable.Rows.Add(r)

            End If
        Next
        m_SpiecesTable.EndLoadData()
    End Sub
    Public ReadOnly Property SpieciesList() As DataView
        Get
            RefreshSpiecesList()
            Return New DataView(m_SpiecesTable)
        End Get
    End Property

    Dim m_ShowPopupImmediatly As Boolean = False
    Private Sub FarmTree_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles FarmTree.ShownEditor
        If Not FarmTree.ActiveEditor Is Nothing Then
            If TypeOf (FarmTree.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit AndAlso m_ShowPopupImmediatly Then
                CType(FarmTree.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).ShowPopup()
                m_ShowPopupImmediatly = False
                m_SelectNewSpiece = False
            Else
                Dim row As DataRow = ObjectRow
                Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
                Dim col As DevExpress.XtraTreeList.Columns.TreeListColumn = FarmTree.FocusedColumn
                Select Case dtype
                    Case PartyType.Herd
                        If col.FieldName = "strName" Then
                            SystemLanguages.SwitchInputLanguage(Localizer.lngEn)
                        End If
                        'Case PartyType.Species
                        '    If col.FieldName = "strName" AndAlso (CType(FarmTree.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).EditValue Is Nothing OrElse Not CType(FarmTree.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).Equals(row("strName"))) Then
                        '        CType(FarmTree.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).EditValue = row("strName")
                        '    End If
                End Select

            End If
        End If
    End Sub

    Private Function ValidateTotals(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal Total As Integer, ByVal Seek As Integer, ByVal Dead As Integer, ByRef ErrMsg As String) As Boolean
        If node Is Nothing OrElse Closing Then Return True
        Dim row As DataRow = CType(FarmTree.GetDataRecordByNode(node), DataRowView).Row
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        If dtype = PartyType.Species OrElse dtype = PartyType.Herd Then
            If Total < Dead Then
                ErrMsg = String.Format(EidssMessages.Get("errTotalVsDead"), Total, Dead)
                Return False
            End If
            If Total < Seek Then
                ErrMsg = String.Format(EidssMessages.Get("errTotalVsSeek"), Total, Seek)
                Return False
            End If
            If Total < Seek + Dead Then
                ErrMsg = String.Format(EidssMessages.Get("errTotalVsSeekAndDead"), Seek, Dead, Total)
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ValidateTreeNode(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode, ByRef ErrMsg As String) As Boolean
        If node Is Nothing OrElse Closing Then Return True
        Dim row As DataRow = CType(FarmTree.GetDataRecordByNode(node), DataRowView).Row
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        If dtype = PartyType.Species OrElse dtype = PartyType.Herd Then
            If dtype = PartyType.Species AndAlso Utils.Str(node.GetValue(0)) = "" Then
                ErrMsg = String.Format(EidssMessages.Get("ErrMandatoryFieldRequired"), EidssFields.Get("idfsSpeciesType"))
                FarmTree.FocusedColumn = FarmTree.Columns(0)
                FarmTree.FocusedNode = node
                Return False
            End If

            If dtype = PartyType.Species AndAlso Not DateValidator.Validate(row, False) Then
                ErrMsg = DateValidator.ErrorMessage
                FarmTree.FocusedColumn = FarmTree.Columns(5)
                FarmTree.FocusedNode = node
                Return False
            End If

            If dtype = PartyType.Species AndAlso (row.Table.Select(String.Format("strName='{0}' and idfParentParty={1} and idfParty<>{2}", row("strName"), row("idfParentParty"), row("idfParty"))).Length > 0) Then
                ErrMsg = EidssMessages.Get("errDuplicateSpiecies", "The species type must be unique.")
                FarmTree.FocusedColumn = FarmTree.Columns(0)
                FarmTree.FocusedNode = node
                Return False

            End If
            Dim Total As Integer = 0
            Dim Seek As Integer = 0
            Dim Dead As Integer = 0
            ParseInt(Utils.Str(node.GetValue(1)), Total)
            ParseInt(Utils.Str(node.GetValue(2)), Dead)
            ParseInt(Utils.Str(node.GetValue(3)), Seek)
            Return ValidateTotals(node, Total, Seek, Dead, ErrMsg)
        End If
        Return True
    End Function


    Dim m_validating As Boolean = False
    Private Function ValidateTreeNode(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode) As Boolean
        If m_validating Then
            Return True
        End If
        Dim errMsg As String = Nothing
        m_validating = True
        Try
            If ValidateTreeNode(node, errMsg) = False Then
                MessageForm.Show(errMsg)
                If Not FarmTree.FocusedNode Is node Then
                    FarmTree.FocusedNode = node
                End If
                Timer1.Enabled = True
                'm_ShowPopupImmediatly = True
                'FarmTree.ShowEditor()
                Return False
            End If
        Finally
            m_validating = False
        End Try
        Return True
    End Function

    Private Sub FarmTreePanel_OnAfterPost(sender As Object, e As System.EventArgs) Handles Me.OnAfterPost
        RefreshObjectLabel(Nothing)
    End Sub

    Private Sub FarmTreePanel_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Visible = True Then
            RefreshFlexibleForm()
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        If (Not FarmTree.FocusedNode Is Nothing) Then
            If Not ValidateTreeNode(FarmTree.FocusedNode) Then
                Return False
            End If
        End If
        For Each herdNode As TreeListNode In FarmTree.Nodes.Item(0).Nodes
            For Each speciesNode As TreeListNode In herdNode.Nodes
                If Not ValidateTreeNode(speciesNode) Then
                    Return False
                End If
            Next
        Next
        Return MyBase.ValidateData()
    End Function

    Private Sub FarmTree_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles FarmTree.CellValueChanged
        If (e.Column.AbsoluteIndex) = 0 Then
            RefreshObjectLabel()
        End If
    End Sub
    Private Sub RefreshObjectLabel(Optional ByVal row As DataRow = Nothing)
        If (BaseSettings.ScanFormsMode = True) Then
            lbObjectType.Text = EidssMessages.Get("Farm")
            lbObjectType.Text = EidssMessages.Get("Species")
            Return
        End If
        If row Is Nothing Then
            row = ObjectRow
        End If
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Farm
                lbObjectType.Text = String.Format("{0}:  {1}", EidssMessages.Get("Farm"), Utils.Str(row("strName")))
            Case PartyType.Herd
                lbObjectType.Text = String.Format("{0}:{1}", HerdCaption, Utils.Str(row("strName")))
            Case PartyType.Species
                lbObjectType.Text = String.Format("{0}:  {1}/{2}", EidssMessages.Get("Species"), FarmTree.FocusedNode.ParentNode.GetDisplayText(0), FarmTree.FocusedNode.GetDisplayText(0))
            Case Else
                lbObjectType.Text = ""
        End Select
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (WinUtils.ConfirmMessage(EidssMessages.Get("msgClearFF", "Panel content will be cleared. Clear it?"), EidssMessages.Get("msgClearFFCaption", "Clear panel"))) Then
            ffObjectDetails.Clear()
        End If

    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        ffObjectDetails.Copy()
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        ffObjectDetails.Paste()
    End Sub

    Private Sub FarmTree_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FarmTree.VisibleChanged
        If m_SelectNewSpiece AndAlso Not Me.ParentObject Is Nothing AndAlso _
                (CType(Me.ParentObject, BaseForm).State And BusinessObjectState.NewObject) <> 0 _
                AndAlso FarmTree.Nodes.Count > 0 Then
            Timer1.Enabled = True
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If FarmTree.Nodes.Count > 0 AndAlso Not [ReadOnly] Then
            m_ShowPopupImmediatly = True
            If Me.FindForm Is Form.ActiveForm Then 'this is done to avoid popup if + button is pressed and other form is opened before dropdown popup
                FarmTree.ShowEditor()
            End If
            Timer1.Enabled = False
        End If

    End Sub
    Private Sub ParseInt(ByVal strNumber As String, ByRef intValue As Integer)
        Integer.TryParse(strNumber, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, intValue)
    End Sub


    Private Sub FarmTree_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles FarmTree.ValidatingEditor
        Dim Total As Integer = 0
        Dim Seek As Integer = 0
        Dim Dead As Integer = 0
        Dim node As TreeListNode = FarmTree.FocusedNode
        If (FarmTree.FocusedColumn Is colTotalAnimalQty) Then
            Total = CInt(e.Value)
        Else
            ParseInt(Utils.Str(node.GetValue(1)), Total)
        End If
        If (FarmTree.FocusedColumn Is colDeadAnimalQty) Then
            Dead = CInt(e.Value)
        Else
            ParseInt(Utils.Str(node.GetValue(2)), Dead)
        End If
        If (FarmTree.FocusedColumn Is colSeekAnimalQty) Then
            Seek = CInt(e.Value)
        Else
            ParseInt(Utils.Str(node.GetValue(3)), Seek)
        End If

        Dim errMsg As String = Nothing
        If ValidateTotals(node, Total, Seek, Dead, errMsg) = False Then
            If (FarmTree.FocusedColumn Is colTotalAnimalQty) Then

                e.Value = node.GetValue(1)
            ElseIf (FarmTree.FocusedColumn Is colDeadAnimalQty) Then
                e.Value = node.GetValue(2)
            ElseIf (FarmTree.FocusedColumn Is colSeekAnimalQty) Then
                e.Value = node.GetValue(3)
            End If
            MessageForm.Show(errMsg)

        End If

    End Sub
    Public DateValidator As DateChainValidator
    Protected Overrides Sub RegisterValidators()
        DateValidator = New DateChainValidator(Me, FarmTree, VetFarmTree_DB.TableFarmTree, "datStartOfSignsDate", colStartOfSigns.Caption, , , , True)
        DateValidator.RegisterValidator(Me, True)
    End Sub


End Class
