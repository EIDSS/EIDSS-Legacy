Imports System.ComponentModel
Imports bv.winclient.Core
Imports bv.winclient.BasePanel
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports bv.model.Model.Core
Imports System.Reflection
Imports DevExpress.XtraEditors.Controls


Public Class SamplesCheckIn
    Inherits bv.common.win.BaseDetailForm

    Private m_SessionType As eidss.model.Enums.SessionType = eidss.model.Enums.SessionType.None
    'Dim cbAnimalSpeciesLookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    'Dim CaseInfo As DataRow
    '    Dim CaseSamplesDbService As CaseSamplesDetail_Db
    'Dim ContainersDataView As DataView
    'Dim CollectedByOrganizationDataView As DataView
    'Dim SampleData As DataSet = New DataSet
    'Dim CollectedByEmpoyeeDataView As DataView
    'Friend WithEvents dtExpectedDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents PopUpButton2 As bv.common.win.PopUpButton
    Friend WithEvents cmAccessionIN As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents SessionInfoPanel As eidss.SessionInfo
    Friend WithEvents CaseInfoPanel As eidss.CaseInfo
    Friend WithEvents CheckInPanel1 As eidss.CheckInPanel

#Region " Windows Form Designer generated code "

    <CLSCompliantAttribute(False)>
    Public Sub New(ByVal code As HACode, ByVal sessionType As eidss.model.Enums.SessionType)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Init(code, sessionType)

    End Sub
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    <CLSCompliantAttribute(False)>
    Public Sub Init(ByVal code As HACode, ByVal sessionType As EIDSS.model.Enums.SessionType)
        Me.DbService = New SamplesCheckIn_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoCheckIn, AuditTable.tlbAccessionIN)
        'Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.AccessionIn1
        Me.CheckInPanel1.HACode = code
        m_SessionType = sessionType
        Me.CheckInPanel1.SessionType = sessionType

        Me.RegisterChildObject(Me.CheckInPanel1, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.CaseInfoPanel, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.SessionInfoPanel, RelatedPostOrder.SkipPost)


        'Me.RegisterChildObject(Me.CheckInPanel1, RelatedPostOrder.PostLast)

        'cbAnimalSpeciesLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        '       For Each col As DevExpress.XtraEditors.Controls.LookUpColumnInfo In Me.cbAnimalLookup.Columns
        'cbAnimalSpeciesLookup.Columns.Add(col)
        'Next
        'cbAnimalSpeciesLookup.ValueMember = cbAnimalLookup.ValueMember
        'cbAnimalSpeciesLookup.DisplayMember = "strSpecies"
        'cbAnimalSpeciesLookup.NullText = cbAnimalLookup.NullText
        'cbAnimalSpeciesLookup = CType(cbAnimalLookup.Clone(), DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        'cbAnimalSpeciesLookup.ReadOnly = True
        'cbAnimalSpeciesLookup.DisplayMember = "strSpecies"
        'cbAnimalSpeciesLookup.Buttons.Clear()

        CaseInfoPanel.Visible = sessionType = eidss.model.Enums.SessionType.None
        Me.SessionInfoPanel.Visible = sessionType <> eidss.model.Enums.SessionType.None

        CaseInfoPanel.ShowPanel(code)
        SessionInfoPanel.ShowPanel(code)
        ReflectLayout()

        AddHandler CaseInfoPanel.txtCaseID.ButtonClick, AddressOf txtCaseID_ButtonClick
        AddHandler SessionInfoPanel.txtCaseID.ButtonClick, AddressOf txtCaseID_ButtonClick
        'CaseInfoPanel.HumanCaseInfo.Visible = (code And EIDSS.HACode.Human) <> 0
        'CaseInfoPanel.VetCaseInfo.Visible = (code And EIDSS.HACode.Animal) <> 0

        AddHandler Me.CheckInPanel1.BarcodeButton1.ButtonPressed, AddressOf BarcodePressed

        'If (HACode And EIDSS.HACode.Human) <> 0 Then
        'Me.colPartyID.Visible = False
        'Me.colSpecies.Visible = False
        'Else
        'Me.colSentDate.Visible = False
        'End If
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
    Friend WithEvents cmSamplesBarcodes As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SamplesCheckIn))
        Me.cmSamplesBarcodes = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.PopUpButton2 = New bv.common.win.PopUpButton()
        Me.cmAccessionIN = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.CheckInPanel1 = New eidss.CheckInPanel()
        Me.SessionInfoPanel = New eidss.SessionInfo() '.SessionInfo()
        Me.CaseInfoPanel = New eidss.CaseInfo()
        Me.SuspendLayout()
        '
        'cmSamplesBarcodes
        '
        Me.cmSamplesBarcodes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'PopUpButton2
        '
        resources.ApplyResources(Me.PopUpButton2, "PopUpButton2")
        Me.PopUpButton2.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton2.Name = "PopUpButton2"
        Me.PopUpButton2.PopUpMenu = Me.cmAccessionIN
        Me.PopUpButton2.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmAccessionIN
        '
        Me.cmAccessionIN.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        resources.ApplyResources(Me.MenuItem2, "MenuItem2")
        '
        'CheckInPanel1
        '
        resources.ApplyResources(Me.CheckInPanel1, "CheckInPanel1")
        Me.CheckInPanel1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.CheckInPanel1.FormID = Nothing
        Me.CheckInPanel1.HelpTopicID = Nothing
        Me.CheckInPanel1.IsStatusReadOnly = False
        Me.CheckInPanel1.KeyFieldName = "idfMaterial"
        Me.CheckInPanel1.MultiSelect = False
        Me.CheckInPanel1.Name = "CheckInPanel1"
        Me.CheckInPanel1.ObjectName = "CaseSamples"
        Me.CheckInPanel1.Status = bv.common.win.FormStatus.Draft
        Me.CheckInPanel1.TableName = "Material"
        Me.CheckInPanel1.UseParentDataset = True
        '
        'SessionInfoPanel
        '
        resources.ApplyResources(Me.SessionInfoPanel, "SessionInfoPanel")
        Me.SessionInfoPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.SessionInfoPanel.FormID = Nothing
        Me.SessionInfoPanel.HelpTopicID = Nothing
        Me.SessionInfoPanel.IsStatusReadOnly = False
        Me.SessionInfoPanel.KeyFieldName = Nothing
        Me.SessionInfoPanel.MultiSelect = False
        Me.SessionInfoPanel.Name = "SessionInfoPanel"
        Me.SessionInfoPanel.ObjectName = Nothing
        Me.SessionInfoPanel.Status = bv.common.win.FormStatus.Draft
        Me.SessionInfoPanel.TableName = Nothing
        Me.SessionInfoPanel.UseParentDataset = True
        '
        'CaseInfoPanel
        '
        resources.ApplyResources(Me.CaseInfoPanel, "CaseInfoPanel")
        Me.CaseInfoPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.CaseInfoPanel.FormID = Nothing
        Me.CaseInfoPanel.HelpTopicID = Nothing
        Me.CaseInfoPanel.IsStatusReadOnly = False
        Me.CaseInfoPanel.KeyFieldName = Nothing
        Me.CaseInfoPanel.MultiSelect = False
        Me.CaseInfoPanel.Name = "CaseInfoPanel"
        Me.CaseInfoPanel.ObjectName = Nothing
        Me.CaseInfoPanel.Status = bv.common.win.FormStatus.Draft
        Me.CaseInfoPanel.TableName = Nothing
        Me.CaseInfoPanel.UseParentDataset = True
        '
        'SamplesCheckIn
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CheckInPanel1)
        Me.Controls.Add(Me.PopUpButton2)
        Me.Controls.Add(Me.SessionInfoPanel)
        Me.Controls.Add(Me.CaseInfoPanel)
        Me.FormID = "L05"
        Me.HelpTopicID = "accession_in"
        Me.KeyFieldName = "idfMaterial"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SamplesCheckIn"
        Me.ObjectName = "CaseSamples"
        Me.ShowDeleteButton = False
        Me.TableName = "Material"
        Me.Controls.SetChildIndex(Me.CaseInfoPanel, 0)
        Me.Controls.SetChildIndex(Me.SessionInfoPanel, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton2, 0)
        Me.Controls.SetChildIndex(Me.CheckInPanel1, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()

        If Me.DesignMode OrElse baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then Return
        If Me.m_SessionType = model.Enums.SessionType.VsSession Then
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strSessionID")
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtSessionStatus, baseDataSet, CaseSamples_Db.TableCaseActivity + ".SessionStatus")
        ElseIf m_SessionType = model.Enums.SessionType.AsSession Then
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strMonitoringSessionID")
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtSessionStatus, baseDataSet, CaseSamples_Db.TableCaseActivity + ".SessionStatus")
        Else
            Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strCaseID")
            If (Me.CheckInPanel1.HACode And eidss.HACode.Human) <> 0 Then
                Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtFieldID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strLocalIdentifier")
            Else
                Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtFieldID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strFieldAccessionID")
            End If
        End If
        Me.CheckInPanel1.ReadOnly = [ReadOnly]


    End Sub
    'Public Property CasePartyList() As Object
    '    Get
    '        If (HACode And EIDSS.HACode.Livestock) <> 0 Then
    '            Return cbAnimalLookup.DataSource
    '        ElseIf (HACode And EIDSS.HACode.Avian) <> 0 Then
    '            Return cbSpeciesLookup.DataSource
    '        End If
    '        Return Nothing
    '    End Get
    '    Set(ByVal Value As Object)
    '        If (HACode And EIDSS.HACode.Livestock) <> 0 Then
    '            Dim view As DataView = CType(Value, DataView)
    '            view.RowFilter = "idfParty=idfAnimal"
    '            cbAnimalLookup.DataSource = view
    '            cbSpeciesLookup.DataSource = view
    '            'cbAnimalSpeciesLookup.DataSource = Value
    '        ElseIf (HACode And EIDSS.HACode.Avian) <> 0 Then
    '            cbSpeciesLookup.DataSource = Value
    '        End If
    '    End Set
    'End Property
    'Private m_DefaultPartyID As Object = DBNull.Value
    '<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public Property DefaultPartyID() As Object
    'Get
    'Return m_DefaultPartyID
    'End Get
    'Set(ByVal Value As Object)
    'm_DefaultPartyID = Value
    'End Set
    'End Property
    'Private m_HACode As HACode = HACode.Animal Or HACode.Livestock
    '<System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public Property HACode() As HACode
    '    Get
    '        Return CType(Me.DbService, SamplesCheckIn_DB).HACode
    '    End Get
    '    Set(ByVal Value As HACode)
    '        CType(Me.DbService, SamplesCheckIn_DB).HACode = Value
    '    End Set
    'End Property







    'Private Sub FindBindings(ByVal form As Control)
    '    Dim c As Control
    '    For Each c In form.Controls
    '        Dim b As Binding
    '        For Each b In c.DataBindings
    '            Dim s As String = b.ToString
    '        Next
    '        FindBindings(c)
    '    Next
    'End Sub

    Dim m_Updating As Boolean = False

    'Public Function LocateControlRow(ByVal ctl As Control, ByVal row As DataRow) As DataRow
    '    m_Locating = True
    '    Try
    '        Dim b As Binding = ctl.DataBindings(0)
    '        Dim t As DataTable = CType(b.DataSource, DataSet).Tables(b.BindingMemberInfo.BindingPath)

    '        For i As Integer = 0 To t.Rows.Count - 1
    '            If row Is t.Rows(i) Then
    '                b.BindingManagerBase.Position = i
    '                Exit For
    '            End If
    '        Next
    '    Finally
    '        m_Locating = False
    '    End Try
    '    Return row


    '    'Dim bindinds As New Hashtable
    '    'Try
    '    '    'Dim row As DataRow = FindRow(table, aKey, keyFieldName)
    '    '    Dim bm As BindingManagerBase = Nothing
    '    '    If ctl.DataBindings.Count > 0 Then
    '    '        bindinds(ctl) = ctl.DataBindings(0)
    '    '        bm = ctl.DataBindings(0).BindingManagerBase
    '    '    ElseIf bindinds.Contains(ctl) Then
    '    '        ctl.DataBindings.Add(CType(bindinds(ctl), Binding))
    '    '        bm = CType(bindinds(ctl), Binding).BindingManagerBase
    '    '        bm = ctl.DataBindings(0).BindingManagerBase
    '    '    End If
    '    '    If Not row Is Nothing Then
    '    '        If ctl.DataBindings.Count = 0 AndAlso bindinds.Contains(ctl) Then
    '    '            ctl.DataBindings.Add(CType(bindinds(ctl), Binding))
    '    '            bm = ctl.DataBindings(0).BindingManagerBase
    '    '        End If
    '    '        If Not bm Is Nothing Then
    '    '            For i As Integer = 0 To row.Table.Rows.Count - 1
    '    '                If row Is row.Table.Rows(i) Then
    '    '                    bm.Position = i
    '    '                    Return row
    '    '                End If
    '    '            Next
    '    '        End If
    '    '    End If
    '    '    ctl.DataBindings.Clear()
    '    '    CType(ctl, DevExpress.XtraEditors.BaseEdit).EditValue = DBNull.Value
    '    '    Return Nothing
    '    'Finally
    '    '    m_Locating = False
    '    'End Try
    'End Function

    Private m_Locating As Boolean = False


    'Private Sub cbRegisteredByOrganization_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.Created = False OrElse m_Locating Then
    '        Return
    '    End If
    '    'Lookup_Db.FillPersonLookup(baseDataSet, cbRegisteredByOrganization.EditValue, CaseSamplesDetail_Db.TableRegisteredByEmployeeLookup)
    'End Sub

    Public Event OnDeleteSample As RowCollectionChangedHandler



    'Private Sub btnSpecimenDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim MaterialID As Object = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)("idfMaterial")
    '    If MaterialID Is Nothing Then Return
    '    If ValidateData() = False Then
    '        Return
    '    End If
    '    Dim currentRowHandle As Integer = SamplesGridView.FocusedRowHandle
    '    Dim ReloadEntireForm As Boolean = False
    '    If (m_CurrentForm.State And BusinessObjectState.NewObject) = BusinessObjectState.NewObject OrElse IsNewAnimalLink() Then
    '        If m_CurrentForm.Post(PostType.IntermediatePosting) = False Then
    '            Return
    '        End If
    '        ReloadEntireForm = True
    '    Else
    '        If Post(PostType.IntermediatePosting) = False Then
    '            Return
    '        End If
    '    End If
    '    If BaseForm.ShowModal(CType(ClassLoader.LoadClass("SampleDetail"), bv.common.win.BaseForm), FindForm, MaterialID, GetKey) = True Then
    '        m_Updating = True
    '        If ReloadEntireForm Then
    '            m_CurrentForm.LoadData(Me.DbService.ID)
    '        Else
    '            LoadData(Me.DbService.ID)
    '        End If
    '        SamplesGridView.FocusedRowHandle = currentRowHandle
    '        m_Updating = False
    '        ShowSampleDetails(currentRowHandle)
    '    End If
    'End Sub

    'Private Sub cbAnimalLookup_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim MaterialID As Object = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)("idfMaterial")
    '    Dim partyRow As DataRow = FindRow(baseDataSet.Tables(CaseSamplesDetail_Db.TablePartyLink), MaterialID, "idfMaterial")
    '    If Not partyRow Is Nothing Then
    '        partyRow.BeginEdit()
    '        partyRow("idfParty") = SamplesGridView.EditingValue
    '        partyRow.EndEdit()
    '    End If
    'End Sub

    'Private CurrentMaterialID As Object

    'Sub ShowSampleDetails(ByVal SampleIndex As Integer)

    '    If SamplesGridView.RowCount = 0 Then
    '        pnSpecimenDetail.Enabled = False
    '        'CurrentMaterialID = Nothing
    '        Return

    '    End If
    '    'm_Locating = True

    '    'pnSpecimenDetail.Enabled = True

    '    'CurrentMaterialID = SamplesGridView.GetDataRow(SampleIndex)("idfMaterial")

    '    Dim row As DataRow = Me.SamplesGridView.GetDataRow(SampleIndex)
    '    If row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified Then
    '        SetLookupReadOnly(cbRegisteredByPerson, True)
    '    Else
    '        SetLookupReadOnly(cbRegisteredByPerson, False)
    '    End If
    '    Dim enable As Boolean = row.RowState = DataRowState.Added
    '    SetLookupReadOnly(Me.cbCollectedByPerson, enable)
    '    SetLookupReadOnly(Me.cbCollectedByOrganization, enable)

    '    LocateControlRow(cbRegisteredByPerson, row)

    '    ' Not Accessed In  yet
    '    If row.Item("strBarcode").ToString = "" Then
    '        Me.BarcodeButton1.Enabled = False
    '        'pbBarcodes.Enabled = False
    '    Else
    '        Me.BarcodeButton1.Enabled = True
    '        'pbBarcodes.Enabled = True
    '    End If

    'End Sub

    'Private Sub SamplesGridView_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If Not Me.CheckInPanel1.SamplesGridView.ActiveEditor Is Nothing Then
    '    'If Me.CheckInPanel1.SamplesGridView.FocusedColumn Is colSpecimenID Then
    '    'Utils.SwitchInputLanguage(Localizer.lngEn)
    '    'End If
    '    'End If
    'End Sub

    'Public Overrides Function ValidateData() As Boolean
    '    Return MyBase.ValidateData()
    '    'If m_firstLoad = False Then Return True
    '    'Return ValidateCurrentSpecimenRow()
    'End Function

    'Private Function ValidateCurrentSpecimenRow() As Boolean
    '    Return Me.CheckInPanel1.IsCurrentSpecimenRowValid()
    'End Function

    'Private Function ValidatePartyList(Optional ByVal showError As Boolean = True) As Boolean
    '    If (HACode And HACode.Animal) <> 0 AndAlso (CasePartyList Is Nothing OrElse CType(CasePartyList, DataView).Count = 0) Then
    '        If showError Then
    '            If (HACode And EIDSS.HACode.Livestock) <> 0 Then
    '                ErrorForm.ShowErrorDirect(EidssMessages.Get("ErrNoAnimalsForSample", "To add sample you should have at least one animal in the animals list."))
    '            ElseIf (HACode And EIDSS.HACode.Avian) <> 0 Then
    '                ErrorForm.ShowErrorDirect(EidssMessages.Get("ErrNoSpeciesForSample", "To add sample you should have at least one registered species."))
    '            End If
    '        End If
    '        Return False
    '    End If
    '    Return True
    'End Function







    'Private m_firstLoad As Boolean

    'Private Sub SamplesCheckIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    AddHandler BarcodeButton1.ButtonPressed, AddressOf BarcodePressed
    'End Sub

    Public Function HasSamples() As Boolean
        Return baseDataSet.Tables(CaseSamples_Db.TableSamples).Rows.Count > 0
    End Function

    ' Note [Ivan] Barcode: commented because usages not found
    ' Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
    'Dim r As DataRow = Me.SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) 'GetCurrentRow()
    'Dim stTop, stBottom As String

    'Dim stCaseID As String = baseDataSet.Tables("Case").Rows(0).Item("strActivityCode").ToString
    'Dim stPartyCode As String = r.Item("SpeciesCode").ToString
    'Dim stSpecimenCode As String = r.Item("SpecimenCode").ToString
    'Dim dtAccIn As Date = CType(r.Item("datCreationDate"), Date)

    'If Not r Is Nothing Then

    '    stTop = BarcodePrint.MakeTopString(stCaseID, stPartyCode, stSpecimenCode)
    '    stBottom = BarcodePrint.MakeBottomString(r.Item("strBarcode").ToString, dtAccIn, "")
    '    BarcodePrint.PrintBarcode(EIDSS.NumberingObject.Specimen, r.Item("strBarcode").ToString, stTop, stBottom)

    'End If

    ' End Sub

    Private Sub MenuItem1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmSamplesBarcodes.Popup
        If Me.CheckInPanel1.SamplesDataView.Count > 0 Then
            MenuItem1.Enabled = True
        Else
            MenuItem1.Enabled = False
        End If
    End Sub

    Public Sub txtCaseID_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim CaseForm As IBaseListPanel
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            'If baseDataSet.Tables.Contains(CaseSamples_Db.TableCaseActivity) = False OrElse baseDataSet.Tables(CaseSamples_Db.TableCaseActivity).Rows.Count = 0 Then
            'Return
            'End If
            If (Me.DbService.ID Is Nothing) Then Exit Sub
            Dim mode As Long
            If m_SessionType = EIDSS.model.Enums.SessionType.None Then
                If Me.CheckInPanel1.HACode = HACode.Human Then
                    mode = CaseType.Human
                    'CaseForm = CType(ClassLoader.LoadClass("HumanCase_New_1_Detail"), BaseForm)
                    'CaseForm.GetType.GetProperty("ShowNavigators").SetValue(CaseForm, False, Nothing)
                ElseIf (Me.CheckInPanel1.HACode And HACode.Avian) <> 0 Then
                    mode = CaseType.Avian
                    'CaseForm = CType(ClassLoader.LoadClass("VetCaseAvianDetail"), BaseForm)
                ElseIf (Me.CheckInPanel1.HACode And HACode.Livestock) <> 0 Then
                    mode = CaseType.Livestock
                    'CaseForm = CType(ClassLoader.LoadClass("VetCaseLiveStockDetail"), BaseForm)
                Else
                    Throw New Exception("Invalid case type")
                End If
            End If
            If LabUtils.ShowCase(Me.FindForm(), Me.DbService.ID, mode, m_SessionType) Then
                Me.LoadData(Me.DbService.ID)
            End If
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            '  While True
            If m_SessionType = eidss.model.Enums.SessionType.AsSession Then
                CaseForm = CType(ClassLoader.LoadClass("AsSessionListPanel"), IBaseListPanel)
            ElseIf m_SessionType = eidss.model.Enums.SessionType.VsSession Then
                CaseForm = CType(ClassLoader.LoadClass("VsSessionListPanel"), IBaseListPanel)
            Else
                If Me.CheckInPanel1.HACode = HACode.Human Then
                    CaseForm = CType(ClassLoader.LoadClass("HumanCaseListPanel"), IBaseListPanel)
                Else
                    CaseForm = CType(ClassLoader.LoadClass("VetCaseListPanel"), IBaseListPanel)
                End If
            End If
            Dim r As IObject = BaseFormManager.ShowForSelection(CaseForm, FindForm, , 1024, 800)
            If r Is Nothing Then Exit Sub

            Dim caseid As Object = r.Key
            Dim action As DialogResult = CheckCase(caseid)
            If action = DialogResult.Yes Then

                'Me.NotesGroup.Enabled = True
                'Me.pnSpecimenDetail.Enabled = True
                'Me.SamplesGroup.Enabled = True
                'Me.CheckInPanel1.ReadOnly = False
                Me.CheckInPanel1.Enabled = True
                Me.LoadData(caseid)
                CheckInPanel1.DbService.ID = caseid
                'Me.CheckInPanel1.LoadData(caseid)
                'Me.HumanCaseInfo1.baseDataSet = Me.CheckInPanel1.baseDataSet
                'Me.VetCaseInfo1.baseDataSet = Me.CheckInPanel1.baseDataSet
                'Me.HumanCaseInfo1.Bind()
                'Me.VetCaseInfo1.Bind()
            End If
            'If action <> DialogResult.No Then Exit Sub
            'End While
        End If
    End Sub




    'Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
    '    Return DbService.ID
    'End Function

    'Private Sub SamplesGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If Closing Then Return
    '    e.Cancel = True
    '    Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
    '    If row.RowState = DataRowState.Added Then
    '        e.Cancel = False
    '    End If
    '    If row.RowState = DataRowState.Modified Then
    '        If Me.SamplesGridView.FocusedColumn Is Me.colLocation Or Me.SamplesGridView.FocusedColumn Is Me.colComment Or Me.SamplesGridView.FocusedColumn Is Me.colSampleCondition Or Me.SamplesGridView.FocusedColumn Is Me.colContainerID Or Me.SamplesGridView.FocusedColumn Is Me.colAccessionedDate Or Me.SamplesGridView.FocusedColumn Is Me.colDepartmentName Then
    '            e.Cancel = False
    '        End If
    '    End If
    'End Sub

    'Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If (SamplesGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle) Then Exit Sub
    '    Dim dlg As SampleDetail = New SampleDetail
    '    BaseForm.ShowModal(dlg, FindForm, SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)("idfMaterial"))
    'End Sub



    Private Function CheckCase(ByRef caseid As Object) As DialogResult
        Dim cmd As IDbCommand = DbService.CreateSPCommand("spLabSampleReceive_CheckCase")
        BaseDbService.AddParam(cmd, "@idfCase", caseid)
        Using ds As New DataSet
            BaseDbService.CreateAdapter(cmd).Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                Dim collected As Object = row("idfsYNSpecimenCollected")
                If Not Utils.IsEmpty(collected) AndAlso CType(collected, Long) = YesNoUnknownValues.No Then
                    Dim message As String = EidssMessages.Get("mbSamplesNotCollected", "Samples not collected for this Case. Reason is: {0}. Are you sure that you want to use this Case?")
                    'Dim message As String = "Sample(s) not collected for this Case. Reason is: ""{0}""" + Environment.NewLine + "Are you sure that you want to use this Case?"
                    message = String.Format(message, LookupCache.GetLookupValue(row("idfsNotCollectedReason"), BaseReferenceType.rftNotCollectedReason, "name"))
                    Return MessageForm.Show(message, Me.Caption, MessageBoxButtons.YesNoCancel)
                End If
            End If
            DbDisposeHelper.ClearDataset(ds)
        End Using
        Return DialogResult.Yes
    End Function

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimAccessionIn(CType(Me.DbService.ID, Long))
            '    DVDoc.Show_LIM_AccessionIn(bv.model.Model.Core.ModelUserContext.CurrentLanguage, Me.DbService.ID.ToString())
        End If
    End Sub


    Private Sub PopUpButton2_BeforePopup(ByVal sender As Object, ByVal e As System.EventArgs) Handles PopUpButton2.BeforePopup
        If Not Me.DbService.ID Is Nothing Then
            MenuItem2.Enabled = True
        Else
            MenuItem2.Enabled = False
        End If
    End Sub


    Public Overrides Function ValidateData() As Boolean
        Dim res As Boolean = MyBase.ValidateData()
        If res = False Then Return False
        Return Me.CheckInPanel1.ValidateData()
    End Function

    Protected Sub ReflectLayout()
        Me.SuspendLayout()
        Dim diff As Integer = 10 - Me.CheckInPanel1.Top
        If Me.m_SessionType <> eidss.model.Enums.SessionType.None Then
            diff += Me.SessionInfoPanel.Bottom
        Else
            diff += Me.CaseInfoPanel.Bottom
        End If
        Me.CheckInPanel1.Top += diff
        Me.CheckInPanel1.Height -= diff
        Me.ResumeLayout()
    End Sub
    Public Sub BarcodePressed()
        m_ClosingMode = ClosingMode.None
        '  Barcode printing  for sample
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow = CheckInPanel1.SamplesView.GetDataRow(CheckInPanel1.SamplesView.FocusedRowHandle) 'GetCurrentRow()

            Dim typeId As Long = CType(NumberingObject.Specimen, Long)
            Dim objectId As Long = CType(row("idfMaterial"), Long)
            EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)
        End If


        'Dim r As DataRow = Me.SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) 'GetCurrentRow()
        'Dim stTop, stBottom As String

        'Dim stCaseID As String = baseDataSet.Tables("Case").Rows(0).Item("strActivityCode").ToString
        'Dim stPartyCode As String = r.Item("SpeciesCode").ToString
        'Dim stSpecimenCode As String = r.Item("SpecimenCode").ToString
        'Dim dtAccIn As Date = CType(r.Item("datCreationDate"), Date)

        'If Not r Is Nothing Then

        'stTop = BarcodePrint.MakeTopString(stCaseID, stPartyCode, stSpecimenCode)
        '    stBottom = BarcodePrint.MakeBottomString(r.Item("strBarcode").ToString, dtAccIn, "")
        '    BarcodePrint.PrintBarcode(EIDSS.NumberingObject.Specimen, r.Item("strBarcode").ToString, stTop, stBottom)

        'End If
    End Sub

    'Private Sub SetLookupReadOnly(ByVal ctl As DevExpress.XtraEditors.LookUpEdit, ByVal read As Boolean)
    '    ctl.Properties.ReadOnly = Not read
    '    For Each btn As DevExpress.XtraEditors.Controls.EditorButton In ctl.Properties.Buttons
    '        btn.Enabled = read
    '    Next
    'End Sub

    Private Sub Load_Page(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim editButton As EditorButton = SessionInfoPanel.txtCaseID.Properties.Buttons(0)

        SessionInfoPanel.txtCaseID.PerformClick(editButton)

    End Sub
End Class
