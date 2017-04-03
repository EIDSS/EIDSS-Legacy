Imports System.ComponentModel
Imports System.Collections.Generic

Public Class FarmDetail

    Inherits BaseDetailForm

    Dim FarmDbService As Farm_DB
    Friend WithEvents tcFarm As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpLivestockTree As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LiveStockTree As EIDSS.RootFarmTree
    Dim baseHeight As Integer
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        FarmDbService = New Farm_DB

        DbService = FarmDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoFarm, AuditTable.tlbParty)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.VetCase

        RegisterChildObject(Me.FarmPanel, RelatedPostOrder.PostFirst)
        RegisterChildObject(Me.LivestockFarmProductionControl1)
        RegisterChildObject(Me.LiveStockTree)
        LiveStockTree.PopupSpeciesForNewFarm = True
        baseHeight = Me.Height - tcFarm.Height

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
        Me.FarmPanel = New eidss.FarmPanel()
        Me.tcFarm = New DevExpress.XtraTab.XtraTabControl()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.tpLivestockTree = New DevExpress.XtraTab.XtraTabPage()
        Me.LiveStockTree = New eidss.RootFarmTree()
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmGroup.SuspendLayout()
        CType(Me.tcFarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcFarm.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tpLivestockTree.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Appearance.Font = CType(resources.GetObject("cmdOk.Appearance.Font"), System.Drawing.Font)
        Me.cmdOk.Appearance.Options.UseFont = True
        '
        'LivestockFarmProductionControl1
        '
        Me.LivestockFarmProductionControl1.Appearance.Font = CType(resources.GetObject("LivestockFarmProductionControl1.Appearance.Font"), System.Drawing.Font)
        Me.LivestockFarmProductionControl1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.LivestockFarmProductionControl1, "LivestockFarmProductionControl1")
        Me.LivestockFarmProductionControl1.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LivestockFarmProductionControl1.FormID = Nothing
        Me.LivestockFarmProductionControl1.HelpTopicID = Nothing
        Me.LivestockFarmProductionControl1.IsStatusReadOnly = False
        Me.LivestockFarmProductionControl1.KeyFieldName = Nothing
        Me.LivestockFarmProductionControl1.MultiSelect = False
        Me.LivestockFarmProductionControl1.Name = "LivestockFarmProductionControl1"
        Me.LivestockFarmProductionControl1.ObjectName = Nothing
        Me.LivestockFarmProductionControl1.Status = bv.common.win.FormStatus.Draft
        Me.LivestockFarmProductionControl1.TableName = Nothing
        '
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
        Me.FarmPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FarmPanel.FarmKind = 0
        Me.FarmPanel.FormID = Nothing
        Me.FarmPanel.HelpTopicID = Nothing
        Me.FarmPanel.IsStatusReadOnly = False
        Me.FarmPanel.KeyFieldName = "idfFarm"
        Me.FarmPanel.MultiSelect = False
        Me.FarmPanel.Name = "FarmPanel"
        Me.FarmPanel.ObjectName = "Farm"
        Me.FarmPanel.Status = bv.common.win.FormStatus.Draft
        Me.FarmPanel.TableName = "Farm"
        Me.FarmPanel.UseParentBackColor = True
        '
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
        Me.LiveStockTree.CaseKind = eidss.CaseType.Livestock
        Me.LiveStockTree.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LiveStockTree.FormID = Nothing
        Me.LiveStockTree.HelpTopicID = Nothing
        Me.LiveStockTree.IsStatusReadOnly = False
        Me.LiveStockTree.KeyFieldName = "idfParty"
        Me.LiveStockTree.MultiSelect = False
        Me.LiveStockTree.Name = "LiveStockTree"
        Me.LiveStockTree.ObjectName = "FarmTree"
        Me.LiveStockTree.Status = bv.common.win.FormStatus.Draft
        Me.LiveStockTree.TableName = "FarmTree"
        '
        'FarmDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("FarmDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.tcFarm)
        Me.FormID = "V06"
        Me.HelpTopicID = "farm"
        Me.KeyFieldName = "idfFarm"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Farm__large_
        Me.Name = "FarmDetail"
        Me.ObjectName = "Farm"
        Me.TableName = "Farm"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.tcFarm, 0)
        CType(Me.FarmGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmGroup.ResumeLayout(False)
        CType(Me.tcFarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcFarm.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpLivestockTree.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


#End Region





    Protected Overrides Sub DefineBinding()
        eventManager.AttachDataHandler(Farm_DB.TableFarm + ".blnIsLivestock", AddressOf FarmKind_Changed)
        AddHandler FarmPanel.OnFarmCodeChanged, AddressOf OnFarmCodeChanged
    End Sub

    Private Sub FarmKind_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim panelsHeight As Integer = FarmGroup.Top + FarmGroup.Height + 28
        Dim row As DataRow = e.Row
        FarmPanel.FarmKind = 1
        panelsHeight = LivestockFarmProductionControl1.Top + LivestockFarmProductionControl1.Height + 28

        tcFarm.TabPages.Insert(1, tpLivestockTree)
        RegisterChildObject(Me.LiveStockTree)
        If LiveStockTree.baseDataSet.Tables.Count = 0 Then
            LiveStockTree.LoadData(GetKey)
        End If
        LivestockFarmProductionControl1.Visible = True
        tcFarm.ClientSize = New Drawing.Size(tcFarm.Width, panelsHeight)
        Me.ClientSize = New Drawing.Size(Me.Width, baseHeight + tcFarm.Height)
        If Not Me.FindForm Is Nothing Then
            Me.FindForm.ClientSize = New Drawing.Size(Me.Width, baseHeight + tcFarm.Height)
        End If
    End Sub

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
    End Sub
End Class
