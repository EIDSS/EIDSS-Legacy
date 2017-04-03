Imports System.ComponentModel
Imports bv.common.db
Imports DevExpress.XtraTreeList.Nodes
Imports bv.winclient.Localization
Imports EIDSS.model.Resources
Imports bv.winclient.Core
Imports bv.common.Enums

Public Class BaseFarmTreePanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public FarmTreeDbService As BaseFarmTree_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents FarmTreeGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents colName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTotalAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSeekAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colNote As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents txtNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents btnNewSpecies As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNewHerd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colDeadAnimalQty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colAge As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colStartOfSigns As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents dtStartOfSigns As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents txtQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseFarmTreePanel))
        Me.FarmTreeGroup = New DevExpress.XtraEditors.GroupControl()
        Me.btnNewSpecies = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.FarmTree = New DevExpress.XtraTreeList.TreeList()
        Me.colName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTotalAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colDeadAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSeekAnimalQty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colAge = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colStartOfSigns = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.dtStartOfSigns = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colNote = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtNote = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.cbSpiecesList = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnNewHerd = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.FarmTreeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmTreeGroup.SuspendLayout()
        CType(Me.FarmTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartOfSigns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartOfSigns.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpiecesList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(BaseFarmTreePanel), resources)
        'Form Is Localizable: True
        '
        'FarmTreeGroup
        '
        Me.FarmTreeGroup.Appearance.BackColor = CType(resources.GetObject("FarmTreeGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmTreeGroup.Appearance.Options.UseBackColor = True
        Me.FarmTreeGroup.AppearanceCaption.Font = CType(resources.GetObject("FarmTreeGroup.AppearanceCaption.Font"), System.Drawing.Font)
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
        resources.ApplyResources(Me.btnNewSpecies, "btnNewSpecies")
        Me.btnNewSpecies.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnNewSpecies.Name = "btnNewSpecies"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
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
        Me.FarmTree.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSpiecesList, Me.txtNote, Me.txtQty, Me.dtStartOfSigns})
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
        Me.colTotalAnimalQty.ColumnEdit = Me.txtQty
        Me.colTotalAnimalQty.FieldName = "intTotalAnimalQty"
        Me.colTotalAnimalQty.Name = "colTotalAnimalQty"
        '
        'txtQty
        '
        resources.ApplyResources(Me.txtQty, "txtQty")
        Me.txtQty.IsFloatValue = False
        Me.txtQty.Mask.EditMask = resources.GetString("txtQty.Mask.EditMask")
        Me.txtQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtQty.Name = "txtQty"
        '
        'colDeadAnimalQty
        '
        resources.ApplyResources(Me.colDeadAnimalQty, "colDeadAnimalQty")
        Me.colDeadAnimalQty.ColumnEdit = Me.txtQty
        Me.colDeadAnimalQty.FieldName = "intDeadAnimalQty"
        Me.colDeadAnimalQty.Name = "colDeadAnimalQty"
        '
        'colSeekAnimalQty
        '
        resources.ApplyResources(Me.colSeekAnimalQty, "colSeekAnimalQty")
        Me.colSeekAnimalQty.ColumnEdit = Me.txtQty
        Me.colSeekAnimalQty.FieldName = "intSickAnimalQty"
        Me.colSeekAnimalQty.Name = "colSeekAnimalQty"
        '
        'colAge
        '
        resources.ApplyResources(Me.colAge, "colAge")
        Me.colAge.FieldName = "strAverageAge"
        Me.colAge.Name = "colAge"
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
        Me.dtStartOfSigns.Name = "dtStartOfSigns"
        Me.dtStartOfSigns.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
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
        resources.ApplyResources(Me.btnNewHerd, "btnNewHerd")
        Me.btnNewHerd.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnNewHerd.Name = "btnNewHerd"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'BaseFarmTreePanel
        '
        Me.Controls.Add(Me.FarmTreeGroup)
        Me.KeyFieldName = "idfParty"
        Me.Name = "BaseFarmTreePanel"
        Me.ObjectName = "FarmTree"
        resources.ApplyResources(Me, "$this")
        Me.TableName = "FarmTree"
        CType(Me.FarmTreeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmTreeGroup.ResumeLayout(False)
        CType(Me.FarmTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartOfSigns.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartOfSigns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpiecesList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public CanDeleteRow As CanDeleteRowHandler

    Protected Overrides Sub DefineBinding()
        FarmTree.DataSource = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
        FarmTree.KeyFieldName = "idfParty"
        FarmTree.ParentFieldName = "idfParentParty"
        If Me.CaseKind = CaseType.Avian Then
            Core.LookupBinder.BindBaseRepositoryLookup(Me.cbSpiecesList, _
                BaseReferenceType.rftSpeciesList, _
                HACode.Avian, AddressOf Core.LookupBinder.AddSpecies)
        Else
            Core.LookupBinder.BindBaseRepositoryLookup(Me.cbSpiecesList, _
                BaseReferenceType.rftSpeciesList, _
                HACode.Livestock, AddressOf Core.LookupBinder.AddSpecies)
        End If
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
            Case CaseType.Livestock
                colAge.Visible = False
                colDeadAnimalQty.Visible = False
                colStartOfSigns.Visible = False
                colNote.Visible = True
        End Select
        If m_ShowGeneralInfoOnly = True Then
            colAge.Visible = False
            colDeadAnimalQty.Visible = False
            colSeekAnimalQty.Visible = False
            colStartOfSigns.Visible = False
            colNote.Visible = False
        End If

        eventManager.AttachDataHandler(BaseFarmTree_DB.TableFarmTree + ".intTotalAnimalQty", AddressOf Qty_Changed)
        If m_ShowGeneralInfoOnly = False Then
            eventManager.AttachDataHandler(BaseFarmTree_DB.TableFarmTree + ".intSickAnimalQty", AddressOf Qty_Changed)
            eventManager.AttachDataHandler(BaseFarmTree_DB.TableFarmTree + ".intDeadAnimalQty", AddressOf Qty_Changed)
        End If
        If [ReadOnly] Then
            Me.FarmTree.OptionsBehavior.Editable = False
        End If
        If RecalcAllQty() Then 'Totals was updated, i.e. data in database doesn't real situation by some reason.
            Me.FarmTreeDbService.PostDetail(baseDataSet, PostType.FinalPosting) ' update totals in database
        End If

    End Sub
    Private Function RecalcQty(ByVal fieldName As String) As Boolean
        If Not baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Columns.Contains(fieldName) Then
            Return False
        End If
        Dim Ret As Boolean = False
        Dim qty As Object
        For Each row As DataRow In baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Rows
            If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                Continue For
            End If
            If CType(row("idfsPartyType"), PartyType).Equals(PartyType.Herd) Then
                qty = baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfParentParty={0}", row("idfParty")))
                If Not qty Is DBNull.Value Then
                    qty = Convert.ChangeType(qty, row.Table.Columns(fieldName).DataType)
                End If
                If Not row(fieldName).Equals(qty) Then
                    row(fieldName) = qty
                    Ret = True
                    row.EndEdit()
                End If
            End If
        Next
        Dim farmRow As DataRow = baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Rows.Find(GetKey())
        If Not farmRow Is Nothing Then
            qty = baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfsPartyType={0}", CLng(PartyType.Species)))
            If Not qty Is DBNull.Value AndAlso Not farmRow(fieldName) Is DBNull.Value Then
                qty = Convert.ChangeType(qty, farmRow(fieldName).GetType)
            End If
            If Not farmRow(fieldName).Equals(qty) Then
                farmRow(fieldName) = qty
                farmRow.EndEdit()
                Ret = True
            End If
        End If
        Return Ret
    End Function
    Private Function RecalcAllQty() As Boolean
        Dim ret As Boolean = False
        If m_ShowGeneralInfoOnly = False Then
            If CaseKind = CaseType.Avian Then
                ret = ret Or RecalcQty("intDeadAnimalQty")
            End If
            ret = ret Or RecalcQty("intSickAnimalQty")
        End If
        ret = ret Or RecalcQty("intTotalAnimalQty")
        Return ret
    End Function
    Private Sub Qty_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        RecalcQty(e.Column.ColumnName)
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
            If FarmTreeDbService.ValidateNewSpecies(rview.Row, Utils.Str(e.NewValue)) = False Then
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
                If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = "-1" Then
                    e.NewValue = DBNull.Value
                End If
                rview("strName") = e.NewValue
                rview.EndEdit()
            End If
        Else
            If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = "-1" Then
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
                newRow = FarmTreeDbService.AddHerd(row.Row)
            Case PartyType.Herd
                newRow = FarmTreeDbService.AddHerdSpieces(row.Row)
                m_ShowPopupImmediatly = True
            Case PartyType.Species
                row = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode.ParentNode), DataRowView)
                newRow = FarmTreeDbService.AddHerdSpieces(row.Row)
                m_ShowPopupImmediatly = True
        End Select
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = FarmTree.FindNodeByKeyID(newRow("idfParty"))
        If Not node Is Nothing Then
            node.ParentNode.ExpandAll()
            FarmTree.FocusedNode = node
            FarmTree.FocusedColumn = FarmTree.Columns(0)
        End If
        EndUpdate()
        FarmTree.ShowEditor()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If FarmTree.FocusedNode Is Nothing OrElse FarmTree.FocusedNode.Level = 0 Then
            Return
        End If
        Dim row As DataRowView = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
        If Not CanDeleteRow Is Nothing AndAlso CanDeleteRow(row.Row) = False Then

            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
            Dim CantDeleteMessage As String = ""
            Dim Caption As String = ""
            Select Case dtype
                Case PartyType.Farm
                    Return
                Case PartyType.Herd
                    If Me.CaseKind = CaseType.Livestock Then
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteHerd", "Can't delete herd. Delete all animals related with this herd before herd deletion.")
                    Else
                        CantDeleteMessage = EidssMessages.Get("msgCantDeletFlock", "Can't delete flock. Delete all registered samples/penside tests related with this flock before flock deletion.")
                    End If
                    Caption = String.Format(EidssMessages.Get("msgDeleteHerdCaption", "Delete {0}"), HerdCaption)
                Case PartyType.Species
                    If Me.CaseKind = CaseType.Livestock Then
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteLivestockSpecies", "Can't delete species. Delete all animals related with this species before species deletion.")
                    Else
                        CantDeleteMessage = EidssMessages.Get("msgCantDeleteAvianSpecies", "Can't delete species. Delete all registered samples/penside tests related with this species before species deletion.")
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
        RecalcAllQty()
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
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SamplesList() As DataView
        Get
            Return m_SamplesList
        End Get
        Set(ByVal value As DataView)
            m_SamplesList = value
        End Set
    End Property
    Private m_CaseKind As CaseType = CaseType.Livestock
    <Browsable(True), DefaultValue(CaseType.Livestock)> _
    Property CaseKind() As CaseType
        Get
            Return m_CaseKind
        End Get
        Set(ByVal Value As CaseType)
            m_CaseKind = Value
            If Value = CaseType.Livestock Then
                FarmTreeDbService.HACode = HACode.Livestock
            Else
                FarmTreeDbService.HACode = HACode.Avian
            End If
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property HerdCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strFlock")
                Case CaseType.Livestock : Return EidssMessages.Get("strHerd")
            End Select
            Return EidssMessages.Get("strHerd")
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property NewHerdCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strNewFlock")
                Case CaseType.Livestock : Return EidssMessages.Get("strNewHerd")
            End Select
            Return EidssMessages.Get("strNewHerd")
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property ColumnNameCaption() As String
        Get
            Select Case m_CaseKind
                Case CaseType.Avian : Return EidssMessages.Get("strAvianFarmTreeNode")
                Case CaseType.Livestock : Return EidssMessages.Get("strLivestockFarmTreeNode")
            End Select
            Return EidssMessages.Get("strLivestockFarmTreeNode")
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
        ElseIf (e.Column Is colStartOfSigns AndAlso e.Node.Level < 2) Then
            e.CellText = ""
            e.Handled = True
        End If
    End Sub
    Private Sub FarmTree_CustomNodeCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs) Handles FarmTree.CustomNodeCellEdit
        'If IsDesignMode() Then Return
        Dim rowObject As Object = FarmTree.GetDataRecordByNode(e.Node)
        If rowObject Is Nothing Then Return
        Dim row As DataRow = CType(rowObject, DataRowView).Row
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
            AnimalsList.RowFilter = String.Format("idfHerd = {0} AND idfSpecies={1}", Utils.Str(speciesRow("idfParentParty")), speciesRow("strName").ToString)
            Dim SpeciesAnimalsCount As Integer = AnimalsList.Count
            AnimalsList.RowFilter = ""
            If SpeciesAnimalsCount = 0 Then
                Return True
            End If
        Else
            If SamplesList Is Nothing OrElse SamplesList.Count = 0 Then
                Return True
            End If
            SamplesList.RowFilter = String.Format("idfParty = {0}", speciesRow("idfParty"))
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
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property HerdFilter() As String
        Get
            Return String.Format("idfsPartyType={0}", CLng(PartyType.Herd))
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property HerdsList() As DataView
        Get
            Dim dv As DataView = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
            dv.RowFilter = HerdFilter
            Return dv
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property SpeciesFilter() As String
        Get
            Return String.Format("idfsPartyType={0}", CLng(PartyType.Species))
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property HerdSpecies() As DataView
        Get
            Dim dv As DataView = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
            dv.RowFilter = SpeciesFilter
            Return dv
        End Get
    End Property

    Private m_ShowGeneralInfoOnly As Boolean = False

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ShowGeneralInfoOnly() As Boolean
        Get
            Return m_ShowGeneralInfoOnly
        End Get
        Set(ByVal Value As Boolean)
            m_ShowGeneralInfoOnly = Value
        End Set
    End Property
    Private Sub FarmTree_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles FarmTree.FocusedNodeChanged
        If Visible = False OrElse Loading OrElse Closing Then Return
        If ValidateTreeNode(e.OldNode) = False Then
            BeginUpdate()
            FarmTree.FocusedNode = e.OldNode
            EndUpdate()
            Return
        End If
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property ObjectRow() As DataRow
        Get
            If FarmTree.FocusedNode Is Nothing Then Return Nothing
            Return (CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView).Row)
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Protected ReadOnly Property ObjectRowView() As DataRowView
        Get
            If FarmTree.FocusedNode Is Nothing Then Return Nothing
            Return CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property FarmCode() As String
        Set(ByVal Value As String)
            If Not FarmTree Is Nothing AndAlso FarmTree.Nodes.Count > 0 Then
                FarmTree.BeginUpdate()
                Dim oldRowState As DataRowState = baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Rows(0).RowState
                Me.FarmTree.Nodes(0)("strName") = Value
                FarmTree.EndCurrentEdit()
                FarmTree.EndUpdate()
                If oldRowState = DataRowState.Unchanged Then
                    baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Rows(0).AcceptChanges()
                End If
            End If
        End Set
    End Property


    Public Function HasAnimalGroups() As Boolean
        Return baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree).Rows.Count > 0
    End Function
    Public Overridable Sub ChangeFarm(ByVal sourceFarmID As Object, ByVal targetFarmID As Object, ByVal farmIDCode As String)
        BeginUpdate()
        FarmTree.BeginUpdate()
        FarmTree.DataSource = Nothing
        FarmTreeDbService.ChangeFarm(baseDataSet, sourceFarmID, targetFarmID, farmIDCode)
        FarmTree.DataSource = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
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
        FarmTree.EndUpdate()
        EndUpdate()
    End Sub

    Private m_SelectNewSpiece As Boolean = True
    Protected Overrides Sub AfterLoad()
        If FarmTree.Nodes.Count > 0 Then
            FarmTree.FocusedNode = FarmTree.Nodes(0)
        End If
    End Sub
    Public Function GetHerdSpieciesFilter(ByVal HerdID As Object) As String
        Dim dv As DataView = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
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
            SpeciesLookupTable = LookupCache.Get(BaseReferenceType.rftSpeciesList).Table
        Else
            SpeciesLookupTable = CType(cbSpiecesList.DataSource, DataView).Table
        End If
        If m_SpiecesTable Is Nothing Then
            m_SpiecesTable = SpeciesLookupTable.Clone
            m_SpiecesTable.Columns.Add(New DataColumn("idfSpecies", GetType(Long)))
            m_SpiecesTable.Columns.Add(New DataColumn("idfHerd", GetType(Long)))
            m_SpiecesTable.Columns.Add(New DataColumn("strHerdCode", GetType(String)))
            m_SpiecesTable.Columns.Add(New DataColumn("HerdSpecies", GetType(String), "Name+' '+strHerdCode"))
            m_SpiecesTable.Columns.Add(New DataColumn("strSpecies", GetType(String), "Name"))
            m_SpiecesTable.PrimaryKey = New DataColumn() {m_SpiecesTable.Columns("idfSpecies")}
        End If
        m_SpiecesTable.BeginLoadData()
        m_SpiecesTable.Clear()
        If m_SpeciesView Is Nothing Then
            m_SpeciesView = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
            m_SpeciesView.RowFilter = SpeciesFilter
        End If
        If m_HerdView Is Nothing Then
            m_HerdView = New DataView(baseDataSet.Tables(BaseFarmTree_DB.TableFarmTree))
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
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
            If dtype = PartyType.Species AndAlso (row.Table.Select(String.Format("strName='{0}' and idfParentParty={1} and idfParty<>{2}", row("strName"), row("idfParentParty"), row("idfParty"))).Length > 0) Then
                ErrMsg = EidssMessages.Get("errDuplicateSpiecies", "The species type must be unique.")
                FarmTree.FocusedColumn = FarmTree.Columns(0)
                FarmTree.FocusedNode = node
                Return False

            End If

            Dim Total As Integer = 0
            Dim Seek As Integer = 0
            Dim Dead As Integer = 0
            Integer.TryParse(Utils.Str(node.GetValue(1)), Total)
            Integer.TryParse(Utils.Str(node.GetValue(2)), Dead)
            Integer.TryParse(Utils.Str(node.GetValue(3)), Seek)
            If Total < Dead Then
                ErrMsg = String.Format(EidssMessages.Get("errTotalVsDead"), Total, Dead)
                FarmTree.FocusedColumn = FarmTree.Columns(2)
                Return False
            End If
            If Total < Seek Then
                ErrMsg = String.Format(EidssMessages.Get("errTotalVsSeek"), Total, Seek)
                FarmTree.FocusedColumn = FarmTree.Columns(3)
                Return False
            End If
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
                'FarmTree.ShowEditor()
                Return False
            End If
        Finally
            m_validating = False
        End Try
        Return True
    End Function


    Public Overrides Function ValidateData() As Boolean
        If (Not FarmTree.FocusedNode Is Nothing) Then
            If Not ValidateTreeNode(FarmTree.FocusedNode) Then
                Return False
            End If
        End If
        For Each herdNode As TreeListNode In FarmTree.Nodes.Item(0).Nodes
            If Not ValidateTreeNode(herdNode) Then
                Return False
            End If
            For Each speciesNode As TreeListNode In herdNode.Nodes
                If Not ValidateTreeNode(speciesNode) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Sub FarmTree_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FarmTree.VisibleChanged
        If m_PopupSpeciesForNewFarm AndAlso m_SelectNewSpiece AndAlso Not Me.ParentObject Is Nothing AndAlso _
                (CType(Me.ParentObject, BaseForm).State And BusinessObjectState.NewObject) <> 0 _
                AndAlso FarmTree.Nodes.Count > 0 Then
            Timer1.Enabled = True
        End If
    End Sub

    Private m_PopupSpeciesForNewFarm As Boolean = True
    <Browsable(True), DefaultValue(True)> _
    Property PopupSpeciesForNewFarm() As Boolean
        Get
            Return m_PopupSpeciesForNewFarm
        End Get
        Set(ByVal Value As Boolean)
            m_PopupSpeciesForNewFarm = Value
        End Set
    End Property

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Not m_PopupSpeciesForNewFarm Then
        '    Timer1.Enabled = False
        '    Return
        'End If
        If FarmTree.Nodes.Count > 0 AndAlso Not [ReadOnly] Then
            m_ShowPopupImmediatly = True
            FarmTree.ShowEditor()
        End If
        Timer1.Enabled = False

    End Sub

End Class
