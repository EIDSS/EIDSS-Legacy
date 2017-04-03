Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports EIDSS.model.Reports

Public Class AggregateCaseDetail
    Inherits BaseDetailForm

    Dim AggregateCaseDbService As AggregateCase_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AggregateCaseDbService = New AggregateCase_DB

        DbService = AggregateCaseDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoAgregateHumanCase, AuditTable.tlbAggrCase)

        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.HumanCase
        AggregateHeader1.UseParentDataset = True
        RegisterChildObject(AggregateHeader1, RelatedPostOrder.SkipPost)

        RegisterChildObject(fgAggrCase, RelatedPostOrder.PostLast)
        fgAggrCase.SectionTableCaptionsIsVisible = False
        m_RelatedLists = New String() {"HumanAggregateCaseListItem"}

    End Sub


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
    Friend WithEvents gbDiseaseList As System.Windows.Forms.GroupBox
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmMenuReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents AggregateHeader1 As EIDSS.AggregateHeader
    Friend WithEvents lbNoHumanMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbMatrixVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbMatrixVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents lbFormTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbFormTemplate As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents fgAggrCase As EIDSS.FlexibleForms.FFPresenter


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateCaseDetail))
        Me.gbDiseaseList = New System.Windows.Forms.GroupBox()
        Me.lbFormTemplate = New DevExpress.XtraEditors.LabelControl()
        Me.cbFormTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbMatrixVersion = New DevExpress.XtraEditors.LabelControl()
        Me.cbMatrixVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.fgAggrCase = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoHumanMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmMenuReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.AggregateHeader1 = New EIDSS.AggregateHeader()
        Me.gbDiseaseList.SuspendLayout()
        CType(Me.cbFormTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDiseaseList
        '
        Me.gbDiseaseList.Controls.Add(Me.lbFormTemplate)
        Me.gbDiseaseList.Controls.Add(Me.cbFormTemplate)
        Me.gbDiseaseList.Controls.Add(Me.lbMatrixVersion)
        Me.gbDiseaseList.Controls.Add(Me.cbMatrixVersion)
        Me.gbDiseaseList.Controls.Add(Me.fgAggrCase)
        Me.gbDiseaseList.Controls.Add(Me.lbNoHumanMatrix)
        resources.ApplyResources(Me.gbDiseaseList, "gbDiseaseList")
        Me.gbDiseaseList.Name = "gbDiseaseList"
        Me.gbDiseaseList.TabStop = False
        '
        'lbFormTemplate
        '
        resources.ApplyResources(Me.lbFormTemplate, "lbFormTemplate")
        Me.lbFormTemplate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbFormTemplate.Name = "lbFormTemplate"
        '
        'cbFormTemplate
        '
        resources.ApplyResources(Me.cbFormTemplate, "cbFormTemplate")
        Me.cbFormTemplate.Name = "cbFormTemplate"
        Me.cbFormTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFormTemplate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbMatrixVersion
        '
        resources.ApplyResources(Me.lbMatrixVersion, "lbMatrixVersion")
        Me.lbMatrixVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbMatrixVersion.Name = "lbMatrixVersion"
        '
        'cbMatrixVersion
        '
        resources.ApplyResources(Me.cbMatrixVersion, "cbMatrixVersion")
        Me.cbMatrixVersion.Name = "cbMatrixVersion"
        Me.cbMatrixVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbMatrixVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'fgAggrCase
        '
        resources.ApplyResources(Me.fgAggrCase, "fgAggrCase")
        Me.fgAggrCase.DelayedLoadingNeeded = False
        Me.fgAggrCase.DynamicParameterEnabled = False
        Me.fgAggrCase.FormID = Nothing
        Me.fgAggrCase.HelpTopicID = Nothing
        Me.fgAggrCase.IsStatusReadOnly = False
        Me.fgAggrCase.KeyFieldName = Nothing
        Me.fgAggrCase.MultiSelect = False
        Me.fgAggrCase.Name = "fgAggrCase"
        Me.fgAggrCase.ObjectName = Nothing
        Me.fgAggrCase.SectionTableCaptionsIsVisible = True
        Me.fgAggrCase.TableName = Nothing
        '
        'lbNoHumanMatrix
        '
        resources.ApplyResources(Me.lbNoHumanMatrix, "lbNoHumanMatrix")
        Me.lbNoHumanMatrix.Appearance.ForeColor = CType(resources.GetObject("lbNoHumanMatrix.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbNoHumanMatrix.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbNoHumanMatrix.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbNoHumanMatrix.Name = "lbNoHumanMatrix"
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.cmMenuReports
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmMenuReports
        '
        Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'AggregateHeader1
        '
        resources.ApplyResources(Me.AggregateHeader1, "AggregateHeader1")
        Me.AggregateHeader1.FormID = Nothing
        Me.AggregateHeader1.HelpTopicID = Nothing
        Me.AggregateHeader1.IsStatusReadOnly = False
        Me.AggregateHeader1.KeyFieldName = Nothing
        Me.AggregateHeader1.MultiSelect = False
        Me.AggregateHeader1.Name = "AggregateHeader1"
        Me.AggregateHeader1.ObjectName = Nothing
        Me.AggregateHeader1.TableName = Nothing
        '
        'AggregateCaseDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.AggregateHeader1)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.gbDiseaseList)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "H06"
        Me.HelpTopicID = "HumanAgregateCaseDetailForm"
        Me.KeyFieldName = "idfAggrCase"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.MinHeight = 600
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.MinWidth = 1000
        Me.Name = "AggregateCaseDetail"
        Me.ObjectName = "AggregateCase"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AggregateHeader"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.gbDiseaseList, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.AggregateHeader1, 0)
        Me.gbDiseaseList.ResumeLayout(False)
        CType(Me.cbFormTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewAggregateCase", 430)
        ma.ShowInToolbar = False
        ma.BeginGroup = True
        ma.SmallIconIndex = MenuIconsSmall.HumanAggregateCase
        ma.Name = "btnNewAggregateCase"
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)

    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateCaseDetail, Nothing)
    End Sub

#End Region

    Protected Overrides Sub AfterLoad()
        If Not AggregateHeader1.ShowFlexibleForm(fgAggrCase, FFType.HumanAggregateCase, Nothing, Nothing) Then
            fgAggrCase.Visible = False
            lbNoHumanMatrix.Visible = True
            lbNoHumanMatrix.Text = EidssMessages.Get("errNoHumanAggregateCaseMatrix")
            [ReadOnly] = True
            lbMatrixVersion.Visible = False
            cbMatrixVersion.Visible = False
            lbFormTemplate.Visible = False
            cbFormTemplate.Visible = False
        Else
            Core.LookupBinder.BindAggregateMatrixVersionLookup(cbMatrixVersion, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfVersion", AggregateCaseSection.HumanCase, True)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfVersion", AddressOf MatrixVersionChanged)
            Core.LookupBinder.BindFFTemplatesLookup(cbFormTemplate, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfsCaseObservationFormTemplate", FFType.HumanAggregateCase)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsCaseObservationFormTemplate", AddressOf FormTemplateChanged)
            AggregateHeader1.AttachCellChangingHandler(fgAggrCase)
        End If
    End Sub
    Private Sub FormTemplateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgAggrCase, FFType.HumanAggregateCase, CType(e.Value, Nullable(Of Long)), Nothing)
    End Sub

    Private Sub MatrixVersionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgAggrCase, FFType.HumanAggregateCase, Nothing, CType(e.Value, Nullable(Of Long)))
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing Or baseDataSet.Tables.Count = 0 Then
            Return
        End If

        If Post(PostType.FinalPosting) Then
            Dim id As Long = CLng(DbService.ID)
            Dim template As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfsCaseObservationFormTemplate"))
            Dim observation As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfCaseObservation"))
            EidssSiteContext.ReportFactory.HumAggregateCase(New AggregateReportParameters(id, template, observation))
            'DVDoc.Show_HUM_AggregateReport(bv.model.Model.Core.ModelUserContext.CurrentLanguage, DbService.ID.ToString, SelectTemplate())
        End If
    End Sub

End Class
