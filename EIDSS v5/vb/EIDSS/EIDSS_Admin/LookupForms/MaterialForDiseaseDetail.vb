Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.Core

Public Class MaterialForDiseaseDetail

    Inherits BaseDetailList

    Dim MaterialForDiseaseDbService As MaterialForDiseaseDB
    Private m_Helper As ReferenceEditorHelper
    Friend WithEvents RefView As DataView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        MaterialForDiseaseDbService = New MaterialForDiseaseDB

        DbService = MaterialForDiseaseDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoMaterialDiseaseMatrix, AuditTable.trtMaterialForDisease)
        m_Helper = New ReferenceEditorHelper(gcMaterialForDisease, Nothing, "idfsSpecimenType", "idfsSpecimenType")
        m_Helper.ReferenceTable = "MaterialForDisease"
        m_Helper.KeyField = "idfMaterialForDisease"
        m_Helper.MasterTable = "MasterDiagnosis"
        m_Helper.MasterKeyField = "idfsDiagnosis"
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.Reference
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        MaterialForDiseaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost


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
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gcMaterialForDisease As DevExpress.XtraGrid.GridControl
    Friend WithEvents MaterialForDiseaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSpecimen_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSpecimen_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolRecomQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SpinEditQuantity As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialForDiseaseDetail))
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.cbDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.gcMaterialForDisease = New DevExpress.XtraGrid.GridControl()
        Me.MaterialForDiseaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSpecimen_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecimen_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolRecomQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SpinEditQuantity = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.gcolSite = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcMaterialForDisease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaterialForDiseaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimen_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinEditQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.TabStop = False
        '
        'lblDiagnosis
        '
        resources.ApplyResources(Me.lblDiagnosis, "lblDiagnosis")
        Me.lblDiagnosis.Name = "lblDiagnosis"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Properties.NullText = resources.GetString("cbDiagnosis.Properties.NullText")
        Me.cbDiagnosis.Tag = "{AlwaysEditable}"
        '
        'gcMaterialForDisease
        '
        resources.ApplyResources(Me.gcMaterialForDisease, "gcMaterialForDisease")
        Me.gcMaterialForDisease.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.gcMaterialForDisease.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcMaterialForDisease.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcMaterialForDisease.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcMaterialForDisease.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcMaterialForDisease.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcMaterialForDisease.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.gcMaterialForDisease.MainView = Me.MaterialForDiseaseView
        Me.gcMaterialForDisease.Name = "gcMaterialForDisease"
        Me.gcMaterialForDisease.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSpecimen_Type, Me.SpinEditQuantity})
        Me.gcMaterialForDisease.TabStop = False
        Me.gcMaterialForDisease.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MaterialForDiseaseView})
        '
        'MaterialForDiseaseView
        '
        Me.MaterialForDiseaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolID, Me.gcolSpecimen_Type, Me.gcolDiagnosis, Me.gcolRecomQty, Me.gcolSite})
        Me.MaterialForDiseaseView.GridControl = Me.gcMaterialForDisease
        Me.MaterialForDiseaseView.Name = "MaterialForDiseaseView"
        Me.MaterialForDiseaseView.OptionsCustomization.AllowFilter = False
        Me.MaterialForDiseaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.MaterialForDiseaseView.OptionsView.ShowGroupPanel = False
        '
        'gcolID
        '
        resources.ApplyResources(Me.gcolID, "gcolID")
        Me.gcolID.FieldName = "idfMaterialForDisease"
        Me.gcolID.Name = "gcolID"
        '
        'gcolSpecimen_Type
        '
        Me.gcolSpecimen_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSpecimen_Type, "gcolSpecimen_Type")
        Me.gcolSpecimen_Type.ColumnEdit = Me.cbSpecimen_Type
        Me.gcolSpecimen_Type.FieldName = "idfsSpecimenType"
        Me.gcolSpecimen_Type.Name = "gcolSpecimen_Type"
        '
        'cbSpecimen_Type
        '
        resources.ApplyResources(Me.cbSpecimen_Type, "cbSpecimen_Type")
        Me.cbSpecimen_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecimen_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecimen_Type.Name = "cbSpecimen_Type"
        '
        'gcolDiagnosis
        '
        resources.ApplyResources(Me.gcolDiagnosis, "gcolDiagnosis")
        Me.gcolDiagnosis.FieldName = "idfsDiagnosis"
        Me.gcolDiagnosis.Name = "gcolDiagnosis"
        '
        'gcolRecomQty
        '
        Me.gcolRecomQty.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolRecomQty, "gcolRecomQty")
        Me.gcolRecomQty.ColumnEdit = Me.SpinEditQuantity
        Me.gcolRecomQty.FieldName = "intRecommendedQty"
        Me.gcolRecomQty.Name = "gcolRecomQty"
        Me.gcolRecomQty.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'SpinEditQuantity
        '
        resources.ApplyResources(Me.SpinEditQuantity, "SpinEditQuantity")
        Me.SpinEditQuantity.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SpinEditQuantity.Name = "SpinEditQuantity"
        '
        'gcolSite
        '
        resources.ApplyResources(Me.gcolSite, "gcolSite")
        Me.gcolSite.FieldName = "idfsSite"
        Me.gcolSite.Name = "gcolSite"
        '
        'MaterialForDiseaseDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gcMaterialForDisease)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.cbDiagnosis)
        Me.FormID = "A03"
        Me.HelpTopicID = "diagnosis_sample_type_matrix"
        Me.KeyFieldName = "idfMaterialForDisease"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Book__large__41_
        Me.Name = "MaterialForDiseaseDetail"
        Me.ObjectName = "MaterialForDisease"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.TableName = "MaterialForDisease"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.cbDiagnosis, 0)
        Me.Controls.SetChildIndex(Me.lblDiagnosis, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.gcMaterialForDisease, 0)
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcMaterialForDisease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaterialForDiseaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimen_Type, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinEditQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuMaterialForDisease", 973, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnMaterialForDisease"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New MaterialForDiseaseDetail, Nothing)
        'BaseForm.ShowModal(New MaterialForDiseaseDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()

        m_DoDeleteAfterNo = False
        RefView = m_Helper.BindView(baseDataSet, True)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.StandardDiagnosis, "MasterDiagnosis.idfsDiagnosis", True)
        eventManager.AttachDataHandler("MasterDiagnosis.idfsDiagnosis", AddressOf m_Helper.RefType_Changed)

        Core.LookupBinder.BindSampleRepositoryLookup(cbSpecimen_Type, HACode.All, True, False)
        eventManager.Cascade("MasterDiagnosis.idfsDiagnosis")

    End Sub
    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("MaterialForDisease").GetChanges() Is Nothing
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MaterialForDiseaseView.ValidateRow
        m_Helper.ValidateRow(e)
    End Sub
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                btnDelete.Visible = False
            Else
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    btnDelete.Visible = True
                    btnDelete.Enabled = False
                End If
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowNew = False
                End If
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowEdit = False
                End If
            End If
        End Set
    End Property
End Class
