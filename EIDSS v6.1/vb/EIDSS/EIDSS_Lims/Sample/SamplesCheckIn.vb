Imports bv.winclient.Core
Imports bv.winclient.BasePanel
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.model.Enums
Imports bv.common.Enums


Public Class SamplesCheckIn
    Inherits BaseDetailForm

    Private m_SessionType As SessionType = SessionType.None
    Friend WithEvents PopUpButton2 As PopUpButton
    Friend WithEvents cmAccessionIN As Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As Windows.Forms.MenuItem
    Friend WithEvents SessionInfoPanel As SessionInfo
    Friend WithEvents CaseInfoPanel As CaseInfo
    Friend WithEvents CheckInPanel1 As CheckInPanel

#Region " Windows Form Designer generated code "

    <CLSCompliantAttribute(False)>
    Public Sub New(ByVal code As HACode, ByVal sessionType As SessionType)
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
    Public Sub Init(ByVal code As HACode, ByVal sessionType As SessionType)
        Me.DbService = New SamplesCheckIn_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoCheckIn, AuditTable.tlbMaterial)
        'Me.PermissionObject = eidss.EIDSSPermissionObject.AccessionIn1
        Me.CheckInPanel1.HACode = code
        m_SessionType = sessionType
        Me.CheckInPanel1.SessionType = sessionType

        Me.RegisterChildObject(Me.CheckInPanel1, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.CaseInfoPanel, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.SessionInfoPanel, RelatedPostOrder.SkipPost)



        CaseInfoPanel.Visible = sessionType = sessionType.None
        Me.SessionInfoPanel.Visible = sessionType <> sessionType.None

        CaseInfoPanel.ShowPanel(code)
        SessionInfoPanel.ShowPanel(code)
        ReflectLayout()

        AddHandler CaseInfoPanel.txtCaseID.ButtonClick, AddressOf txtCaseID_ButtonClick
        AddHandler SessionInfoPanel.txtCaseID.ButtonClick, AddressOf txtCaseID_ButtonClick
        'CaseInfoPanel.HumanCaseInfo.Visible = (code And EIDSS.HACode.Human) <> 0
        'CaseInfoPanel.VetCaseInfo.Visible = (code And EIDSS.HACode.Animal) <> 0

        AddHandler Me.CheckInPanel1.BarcodeButton1.ButtonPressed, AddressOf BarcodePressed


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
        Me.PopUpButton2 = New bv.winclient.Core.PopUpButton()
        Me.cmAccessionIN = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.CheckInPanel1 = New EIDSS.CheckInPanel()
        Me.SessionInfoPanel = New EIDSS.SessionInfo()
        Me.CaseInfoPanel = New EIDSS.CaseInfo()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SamplesCheckIn), resources)
        'Form Is Localizable: True
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
        Me.PopUpButton2.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
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
        Me.CheckInPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.CheckInPanel1, "CheckInPanel1")
        Me.CheckInPanel1.FormID = Nothing
        Me.CheckInPanel1.HelpTopicID = Nothing
        Me.CheckInPanel1.KeyFieldName = "idfMaterial"
        Me.CheckInPanel1.MultiSelect = False
        Me.CheckInPanel1.Name = "CheckInPanel1"
        Me.CheckInPanel1.ObjectName = "CaseSamples"
        Me.CheckInPanel1.TableName = "Material"
        Me.CheckInPanel1.UseParentDataset = True
        '
        'SessionInfoPanel
        '
        resources.ApplyResources(Me.SessionInfoPanel, "SessionInfoPanel")
        Me.SessionInfoPanel.FormID = Nothing
        Me.SessionInfoPanel.HelpTopicID = Nothing
        Me.SessionInfoPanel.KeyFieldName = Nothing
        Me.SessionInfoPanel.MultiSelect = False
        Me.SessionInfoPanel.Name = "SessionInfoPanel"
        Me.SessionInfoPanel.ObjectName = Nothing
        Me.SessionInfoPanel.TableName = Nothing
        Me.SessionInfoPanel.UseParentDataset = True
        '
        'CaseInfoPanel
        '
        resources.ApplyResources(Me.CaseInfoPanel, "CaseInfoPanel")
        Me.CaseInfoPanel.FormID = Nothing
        Me.CaseInfoPanel.HelpTopicID = Nothing
        Me.CaseInfoPanel.KeyFieldName = Nothing
        Me.CaseInfoPanel.MultiSelect = False
        Me.CaseInfoPanel.Name = "CaseInfoPanel"
        Me.CaseInfoPanel.ObjectName = Nothing
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
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L05"
        Me.HelpTopicID = "accession_in"
        Me.KeyFieldName = "idfMaterial"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SamplesCheckIn"
        Me.ObjectName = "CaseSamples"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Material"
        Me.Controls.SetChildIndex(Me.CaseInfoPanel, 0)
        Me.Controls.SetChildIndex(Me.SessionInfoPanel, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton2, 0)
        Me.Controls.SetChildIndex(Me.CheckInPanel1, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()

        If DesignMode OrElse baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then Return
        If m_SessionType = SessionType.VsSession Then
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strSessionID")
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtSessionStatus, baseDataSet, CaseSamples_Db.TableCaseActivity + ".SessionStatus")
        ElseIf m_SessionType = SessionType.AsSession Then
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strMonitoringSessionID")
            Core.LookupBinder.BindTextEdit(SessionInfoPanel.txtSessionStatus, baseDataSet, CaseSamples_Db.TableCaseActivity + ".SessionStatus")
        Else
            Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtCaseID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strCaseID")
            If (CheckInPanel1.HACode And HACode.Human) <> 0 Then
                Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtFieldID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strLocalIdentifier")
            Else
                Core.LookupBinder.BindTextEdit(CaseInfoPanel.txtFieldID, baseDataSet, CaseSamples_Db.TableCaseActivity + ".strFieldAccessionID")
            End If
        End If
        CheckInPanel1.ReadOnly = [ReadOnly]
        MenuItem2.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimAccessionIn")

    End Sub


    'Public Event OnDeleteSample As RowCollectionChangedHandler




    Public Function HasSamples() As Boolean
        Return baseDataSet.Tables(CaseSamples_Db.TableSamples).Rows.Count > 0
    End Function


    Private Sub MenuItem1_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles cmSamplesBarcodes.Popup
        If CheckInPanel1.SamplesDataView.Count > 0 Then
            MenuItem1.Enabled = True
        Else
            MenuItem1.Enabled = False
        End If
    End Sub

    Public Sub txtCaseID_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim caseForm As IBaseListPanel
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            If (DbService.ID Is Nothing) Then Exit Sub
            Dim mode As Long
            If m_SessionType = SessionType.None Then
                If CheckInPanel1.HACode = HACode.Human Then
                    mode = CaseType.Human
                ElseIf (CheckInPanel1.HACode And HACode.Avian) <> 0 Then
                    mode = CaseType.Avian
                ElseIf (CheckInPanel1.HACode And HACode.Livestock) <> 0 Then
                    mode = CaseType.Livestock
                Else
                    Throw New Exception("Invalid case type")
                End If
            End If
            If LabUtils.ShowCase(FindForm(), DbService.ID, mode, m_SessionType) Then
                LoadData(DbService.ID)
            End If
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            If m_SessionType = SessionType.AsSession Then
                caseForm = CType(ClassLoader.LoadClass("AsSessionListPanel"), IBaseListPanel)
            ElseIf m_SessionType = SessionType.VsSession Then
                caseForm = CType(ClassLoader.LoadClass("VsSessionListPanel"), IBaseListPanel)
            Else
                If CheckInPanel1.HACode = HACode.Human Then
                    caseForm = CType(ClassLoader.LoadClass("HumanCaseListPanel"), IBaseListPanel)
                Else
                    caseForm = CType(ClassLoader.LoadClass("VetCaseListPanel"), IBaseListPanel)
                End If
            End If
            Dim r As IObject = BaseFormManager.ShowForSelection(caseForm, FindForm, , 1024, 800)
            If r Is Nothing Then Exit Sub

            Dim caseid As Object = r.Key
            Dim action As DialogResult = CheckCase(caseid)
            If action = DialogResult.Yes Then

                CheckInPanel1.Enabled = True
                LoadData(caseid)
                CheckInPanel1.DbService.ID = caseid
            End If
        End If
    End Sub





    Private Function CheckCase(ByRef caseid As Object) As DialogResult
        Dim cmd As IDbCommand = DbService.CreateSPCommand("spLabSampleReceive_CheckCase")
        BaseDbService.AddParam(cmd, "@idfCase", caseid)
        Using ds As New DataSet
            BaseDbService.FillDataset(cmd, ds, Nothing)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                Dim collected As Object = row("idfsYNSpecimenCollected")
                If Not Utils.IsEmpty(collected) AndAlso CType(collected, Long) = YesNoUnknownValues.No Then
                    Dim message As String = EidssMessages.Get("mbSamplesNotCollected", "Samples not collected for this Case. Reason is: {0}. Are you sure that you want to use this Case?")
                    message = String.Format(message, LookupCache.GetLookupValue(row("idfsNotCollectedReason"), db.BaseReferenceType.rftNotCollectedReason, "name"))
                    Return MessageForm.Show(message, Caption, MessageBoxButtons.YesNoCancel)
                End If
            End If
            DbDisposeHelper.ClearDataset(ds)
        End Using
        Return DialogResult.Yes
    End Function

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem2.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimAccessionIn(CType(DbService.ID, Long))
        End If
    End Sub


    Private Sub PopUpButton2_BeforePopup(ByVal sender As Object, ByVal e As EventArgs) Handles PopUpButton2.BeforePopup
        If Not DbService.ID Is Nothing Then
            MenuItem2.Enabled = True
        Else
            MenuItem2.Enabled = False
        End If
    End Sub


    Public Overrides Function ValidateData() As Boolean
        Dim res As Boolean = MyBase.ValidateData()
        If res = False Then Return False
        Return CheckInPanel1.ValidateData()
    End Function

    Protected Sub ReflectLayout()
        SuspendLayout()
        Dim diff As Integer = 10 - CheckInPanel1.Top
        If m_SessionType <> SessionType.None Then
            diff += SessionInfoPanel.Bottom
        Else
            diff += CaseInfoPanel.Bottom
        End If
        CheckInPanel1.Top += diff
        CheckInPanel1.Height -= diff
        ResumeLayout()
    End Sub
    Public Sub BarcodePressed()
        m_ClosingMode = ClosingMode.None
        '  Barcode printing  for sample
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow = CheckInPanel1.SamplesView.GetDataRow(CheckInPanel1.SamplesView.FocusedRowHandle) 'GetCurrentRow()

            Const typeId As Long = CType(NumberingObject.Sample, Long)
            Dim objectId As Long = CType(row("idfMaterial"), Long)
            EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)
        End If

    End Sub


    Private Sub Load_Page(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim editButton As EditorButton = SessionInfoPanel.txtCaseID.Properties.Buttons(0)
        SessionInfoPanel.txtCaseID.PerformClick(editButton)
    End Sub

    Public Overrides Sub ShowHelp()
        If m_SessionType = SessionType.VsSession Then
            ShowHelp("accession_in_for_vs_session")
        ElseIf m_SessionType = SessionType.AsSession Then
            ShowHelp("accession_in_for_as_session")
        Else
            If (CheckInPanel1.HACode And HACode.Human) <> 0 Then
                ShowHelp("accession_in_for_human_case")
            Else
                ShowHelp("accession_in_for_vet_case")
            End If
        End If
    End Sub
End Class
