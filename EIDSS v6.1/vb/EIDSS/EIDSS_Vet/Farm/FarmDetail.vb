Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.model.Core
Imports EIDSS.model.Enums

Public Class FarmDetail

    Inherits BaseDetailForm

    Dim FarmDbService As Farm_DB
    Friend WithEvents tcFarm As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpLivestockTree As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LiveStockTree As eidss.RootFarmTree
    Friend WithEvents dtModificationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbModificationDate As System.Windows.Forms.Label
    Friend WithEvents lbFarmType As System.Windows.Forms.Label
    Friend WithEvents cbHaCode As DevExpress.XtraEditors.PopupContainerEdit
    Dim baseHeight As Integer
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        If IsDesignMode() Then
            Return
        End If
        FarmDbService = New Farm_DB

        DbService = FarmDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoFarm, AuditTable.tlbFarm)
        'Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.AccessToFarmData

        RegisterChildObject(Me.FarmPanel, RelatedPostOrder.PostFirst)
        RegisterChildObject(Me.LivestockFarmProductionControl1)
        RegisterChildObject(Me.LiveStockTree)
        LiveStockTree.CaseKind = CaseType.Livestock
        baseHeight = Me.Height - tcFarm.Height
        ValidationProcedureName = "spFarm_Validate"
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
    Friend WithEvents LivestockFarmProductionControl1 As EIDSS.LivestockFarmProductionControl
    Friend WithEvents FarmGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents FarmPanel As EIDSS.FarmPanel



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FarmDetail))
        Me.LivestockFarmProductionControl1 = New EIDSS.LivestockFarmProductionControl()
        Me.FarmGroup = New DevExpress.XtraEditors.GroupControl()
        Me.FarmPanel = New EIDSS.FarmPanel()
        Me.tcFarm = New DevExpress.XtraTab.XtraTabControl()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.tpLivestockTree = New DevExpress.XtraTab.XtraTabPage()
        Me.LiveStockTree = New EIDSS.RootFarmTree()
        Me.dtModificationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbModificationDate = New System.Windows.Forms.Label()
        Me.lbFarmType = New System.Windows.Forms.Label()
        Me.cbHaCode = New DevExpress.XtraEditors.PopupContainerEdit()
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmGroup.SuspendLayout()
        CType(Me.tcFarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcFarm.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tpLivestockTree.SuspendLayout()
        CType(Me.dtModificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtModificationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbHaCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(FarmDetail), resources)
        'Form Is Localizable: True
        '
        'LivestockFarmProductionControl1
        '
        Me.LivestockFarmProductionControl1.Appearance.Font = CType(resources.GetObject("LivestockFarmProductionControl1.Appearance.Font"), System.Drawing.Font)
        Me.LivestockFarmProductionControl1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.LivestockFarmProductionControl1, "LivestockFarmProductionControl1")
        Me.LivestockFarmProductionControl1.FormID = Nothing
        Me.LivestockFarmProductionControl1.HelpTopicID = Nothing
        Me.LivestockFarmProductionControl1.KeyFieldName = Nothing
        Me.LivestockFarmProductionControl1.MultiSelect = False
        Me.LivestockFarmProductionControl1.Name = "LivestockFarmProductionControl1"
        Me.LivestockFarmProductionControl1.ObjectName = Nothing
        Me.LivestockFarmProductionControl1.TableName = Nothing
        '
        'FarmGroup
        '
        Me.FarmGroup.Appearance.BackColor = CType(resources.GetObject("FarmGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmGroup.Appearance.Font = CType(resources.GetObject("FarmGroup.Appearance.Font"), System.Drawing.Font)
        Me.FarmGroup.Appearance.Options.UseBackColor = True
        Me.FarmGroup.Appearance.Options.UseFont = True
        Me.FarmGroup.AppearanceCaption.Font = CType(resources.GetObject("FarmGroup.AppearanceCaption.Font"), System.Drawing.Font)
        Me.FarmGroup.AppearanceCaption.Options.UseFont = True
        Me.FarmGroup.Controls.Add(Me.FarmPanel)
        resources.ApplyResources(Me.FarmGroup, "FarmGroup")
        Me.FarmGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmGroup.Name = "FarmGroup"
        '
        'FarmPanel
        '
        Me.FarmPanel.Appearance.BackColor = CType(resources.GetObject("FarmPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmPanel.Appearance.Font = CType(resources.GetObject("FarmPanel.Appearance.Font"), System.Drawing.Font)
        Me.FarmPanel.Appearance.Options.UseBackColor = True
        Me.FarmPanel.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.FarmPanel, "FarmPanel")
        Me.FarmPanel.FarmKind = 0
        Me.FarmPanel.FormID = Nothing
        Me.FarmPanel.HelpTopicID = Nothing
        Me.FarmPanel.KeyFieldName = "idfFarm"
        Me.FarmPanel.MultiSelect = False
        Me.FarmPanel.Name = "FarmPanel"
        Me.FarmPanel.ObjectName = "Farm"
        Me.FarmPanel.TableName = "Farm"
        Me.FarmPanel.UseParentBackColor = True
        '
        'tcFarm
        '
        resources.ApplyResources(Me.tcFarm, "tcFarm")
        Me.tcFarm.Name = "tcFarm"
        Me.tcFarm.SelectedTabPage = Me.tpGeneral
        Me.tcFarm.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpGeneral, Me.tpLivestockTree})
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.FarmGroup)
        Me.tpGeneral.Controls.Add(Me.LivestockFarmProductionControl1)
        Me.tpGeneral.Name = "tpGeneral"
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
        '
        'tpLivestockTree
        '
        Me.tpLivestockTree.Controls.Add(Me.LiveStockTree)
        Me.tpLivestockTree.Name = "tpLivestockTree"
        resources.ApplyResources(Me.tpLivestockTree, "tpLivestockTree")
        '
        'LiveStockTree
        '
        resources.ApplyResources(Me.LiveStockTree, "LiveStockTree")
        Me.LiveStockTree.FormID = Nothing
        Me.LiveStockTree.HelpTopicID = Nothing
        Me.LiveStockTree.KeyFieldName = "idfParty"
        Me.LiveStockTree.MultiSelect = False
        Me.LiveStockTree.Name = "LiveStockTree"
        Me.LiveStockTree.ObjectName = "FarmTree"
        Me.LiveStockTree.TableName = "FarmTree"
        '
        'dtModificationDate
        '
        resources.ApplyResources(Me.dtModificationDate, "dtModificationDate")
        Me.dtModificationDate.Name = "dtModificationDate"
        Me.dtModificationDate.Properties.Appearance.Font = CType(resources.GetObject("dtModificationDate.Properties.Appearance.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.Appearance.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDisabled.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDown.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHighlight.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHighlight.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceFocused.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceWeekNumber.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceWeekNumber.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.Appearance.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.Appearance.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtModificationDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtModificationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtModificationDate.Properties.EditFormat.FormatString = "g"
        Me.dtModificationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtModificationDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.dtModificationDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtModificationDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtModificationDate.Properties.ReadOnly = True
        Me.dtModificationDate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.dtModificationDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtModificationDate.Tag = "{R}"
        '
        'lbModificationDate
        '
        resources.ApplyResources(Me.lbModificationDate, "lbModificationDate")
        Me.lbModificationDate.Name = "lbModificationDate"
        '
        'lbFarmType
        '
        resources.ApplyResources(Me.lbFarmType, "lbFarmType")
        Me.lbFarmType.Name = "lbFarmType"
        '
        'cbHaCode
        '
        resources.ApplyResources(Me.cbHaCode, "cbHaCode")
        Me.cbHaCode.Name = "cbHaCode"
        Me.cbHaCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbHaCode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbHaCode.Properties.PopupSizeable = False
        Me.cbHaCode.Properties.ShowPopupCloseButton = False
        Me.cbHaCode.Tag = "{R}"
        '
        'FarmDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("FarmDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.cbHaCode)
        Me.Controls.Add(Me.dtModificationDate)
        Me.Controls.Add(Me.lbModificationDate)
        Me.Controls.Add(Me.tcFarm)
        Me.Controls.Add(Me.lbFarmType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "V06"
        Me.HelpTopicID = "farm"
        Me.KeyFieldName = "idfFarm"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Farm__large_
        Me.Name = "FarmDetail"
        Me.ObjectName = "Farm"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Farm"
        Me.Controls.SetChildIndex(Me.lbFarmType, 0)
        Me.Controls.SetChildIndex(Me.tcFarm, 0)
        Me.Controls.SetChildIndex(Me.lbModificationDate, 0)
        Me.Controls.SetChildIndex(Me.dtModificationDate, 0)
        Me.Controls.SetChildIndex(Me.cbHaCode, 0)
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmGroup.ResumeLayout(False)
        CType(Me.tcFarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcFarm.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpLivestockTree.ResumeLayout(False)
        CType(Me.dtModificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtModificationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbHaCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region


    Public Property CanDeleteRow As CanDeleteRowHandler
    Public Property CanChangeSpecies As CanDeleteRowHandler

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindHACodeLookup(cbHaCode, baseDataSet, Farm_DB.TableFarm + ".intHACode", CInt(HACode.Avian Or HACode.Livestock))
        Core.LookupBinder.BindDateEdit(dtModificationDate, baseDataSet, Farm_DB.TableFarm + ".datModificationDate")
        'eventManager.AttachDataHandler(Farm_DB.TableFarm + ".intHACode", AddressOf FarmKind_Changed)
        If EidssSiteContext.Instance.IsGeorgiaCustomization Then
            LivestockFarmProductionControl1.Visible = False
        End If
        AddHandler FarmPanel.OnFarmCodeChanged, AddressOf OnFarmCodeChanged
        LiveStockTree.CanDeleteRow = CanDeleteRow
        LiveStockTree.CanChangeSpecies = CanChangeSpecies
    End Sub


    Private Sub FarmPanel_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterLoadData
        If Not StartUpParameters Is Nothing Then
            If (StartUpParameters.ContainsKey("AsSession")) Then
                GetCurrentRow()("intHACode") = HACode.Livestock
            End If
            If (StartUpParameters.ContainsKey("DefaultSpeciesType")) Then
                LiveStockTree.DefaultSpecies = StartUpParameters("DefaultSpeciesType")
            End If
            If (StartUpParameters.ContainsKey("SpeciesTypeFilter")) Then
                LiveStockTree.SpeciesTypeFilter = Utils.Str(StartUpParameters("SpeciesTypeFilter"))
            End If
        End If
    End Sub

    'Private Sub FarmKind_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
    '    Dim panelsHeight As Integer = FarmGroup.Top + FarmGroup.Height + 28
    '    Dim row As DataRow = e.Row
    '    FarmPanel.FarmKind = 1
    '    panelsHeight = LivestockFarmProductionControl1.Top + LivestockFarmProductionControl1.Height + 28

    '    tcFarm.TabPages.Insert(1, tpLivestockTree)
    '    RegisterChildObject(Me.LiveStockTree)
    '    If LiveStockTree.baseDataSet.Tables.Count = 0 Then
    '        LiveStockTree.LoadData(GetKey)
    '    End If
    '    LivestockFarmProductionControl1.Visible = True
    '    tcFarm.ClientSize = New Drawing.Size(tcFarm.Width, panelsHeight)
    '    Me.ClientSize = New Drawing.Size(Me.Width, baseHeight + tcFarm.Height)
    '    If Not Me.FindForm Is Nothing Then
    '        Me.FindForm.ClientSize = New Drawing.Size(Me.Width, baseHeight + tcFarm.Height)
    '    End If
    'End Sub

    Private Sub OnFarmCodeChanged(ByVal newValue As Object)
        Me.LiveStockTree.FarmCode = Utils.Str(newValue)
    End Sub

    Private Sub FarmDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnAfterPost
        'AfterLoad()
        If sender Is Me Then
            LiveStockTree.FarmCode = FarmPanel.FarmCode
        End If
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property IsRootFarm() As Boolean
        Get
            Return FarmPanel.IsRootFarm
        End Get
        Set(ByVal Value As Boolean)
            FarmPanel.IsRootFarm = Value
        End Set
    End Property

    Private Sub FarmDetail_OnBeforePost(sender As Object, e As System.EventArgs) Handles Me.OnBeforePost
        If sender Is Me Then
            LivestockFarmProductionControl1.RootFarmID = FarmPanel.RootFarmID
            CType(LiveStockTree.FarmTreeDbService, RootFarmTree_DB).IsRootFarm = IsRootFarm
        End If

    End Sub

    Private Sub FarmDetail_AfterLoadData(sender As System.Object, e As System.EventArgs) Handles MyBase.AfterLoadData
        Dim params As Dictionary(Of String, Object) = StartUpParameters
        If (Not params Is Nothing) AndAlso (params.ContainsKey("ShowHerdsTab")) Then
            Dim ShowHerdsTab As Boolean = CBool(params("ShowHerdsTab"))
            If ShowHerdsTab = True Then
                tcFarm.TabPages.TabControl.SelectedTabPage = tpLivestockTree
            End If
        End If
        SetFarmPermissions()
    End Sub
    Private Sub SetFarmPermissions()
        Dim disableEditing As Boolean = (Not EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AccessToFarmData)) AndAlso Not DbService.IsNewObject) _
            OrElse (Not EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToFarmData)) AndAlso DbService.IsNewObject)
        If (disableEditing) Then
            SetControlReadOnly(cbHaCode, True, False)
        End If
    End Sub

End Class
