Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports EIDSS.model.Enums

Public Class TestForDiseaseDetail

    Inherits BaseDetailList

    ReadOnly m_TestForDiseaseDbService As TestForDisease_DB
    Private ReadOnly m_Helper As ReferenceEditorHelper
    Friend WithEvents m_RefView As DataView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        m_TestForDiseaseDbService = New TestForDisease_DB

        DbService = m_TestForDiseaseDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoTestDiseaseMatrix, AuditTable.trtTestForDisease)
        m_Helper = New ReferenceEditorHelper(gcTest_For_Disease, Nothing, "idfsTestName", "idfsTestName")
        m_Helper.ReferenceTable = "TestForDisease"
        m_Helper.KeyField = "idfTestForDisease"
        m_Helper.MasterTable = "MasterDiagnosis"
        m_Helper.MasterKeyField = "idfsDiagnosis"
        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        Test_For_DiseaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost

        'If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
        '                                        EIDSSPermissionObject.Reference)) Then
        ' tnNew.Enabled = False
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
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents gcTest_For_Disease As DevExpress.XtraGrid.GridControl
    Friend WithEvents Test_For_DiseaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTest_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents redLookUpTest_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolRecomQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTForDType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents redLookUpTForDType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolSpecimen_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents redLookUpSpecimen_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SpinEditQuantity As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents gcolTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents redLookUpTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestForDiseaseDetail))
        Me.gcTest_For_Disease = New DevExpress.XtraGrid.GridControl()
        Me.Test_For_DiseaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTest_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.redLookUpTest_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolRecomQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SpinEditQuantity = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.gcolDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.redLookUpTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolTForDType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.redLookUpTForDType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolSpecimen_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.redLookUpSpecimen_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gcTest_For_Disease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Test_For_DiseaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookUpTest_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinEditQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookUpTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookUpTForDType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookUpSpecimen_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(TestForDiseaseDetail), resources)
        'Form Is Localizable: True
        '
        'gcTest_For_Disease
        '
        resources.ApplyResources(Me.gcTest_For_Disease, "gcTest_For_Disease")
        Me.gcTest_For_Disease.MainView = Me.Test_For_DiseaseView
        Me.gcTest_For_Disease.Name = "gcTest_For_Disease"
        Me.gcTest_For_Disease.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.redLookUpTest_Type, Me.redLookUpTForDType, Me.redLookUpSpecimen_Type, Me.SpinEditQuantity, Me.redLookUpTestResult})
        Me.gcTest_For_Disease.TabStop = False
        Me.gcTest_For_Disease.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Test_For_DiseaseView})
        '
        'Test_For_DiseaseView
        '
        Me.Test_For_DiseaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolID, Me.gcolTest_Type, Me.gcolRecomQty, Me.gcolDiagnosis, Me.gcolTestResult, Me.gcolTForDType, Me.gcolSpecimen_Type})
        Me.Test_For_DiseaseView.GridControl = Me.gcTest_For_Disease
        resources.ApplyResources(Me.Test_For_DiseaseView, "Test_For_DiseaseView")
        Me.Test_For_DiseaseView.Name = "Test_For_DiseaseView"
        Me.Test_For_DiseaseView.OptionsCustomization.AllowFilter = False
        Me.Test_For_DiseaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.Test_For_DiseaseView.OptionsView.ShowGroupPanel = False
        '
        'gcolID
        '
        resources.ApplyResources(Me.gcolID, "gcolID")
        Me.gcolID.FieldName = "idfTestForDisease"
        Me.gcolID.Name = "gcolID"
        '
        'gcolTest_Type
        '
        Me.gcolTest_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolTest_Type, "gcolTest_Type")
        Me.gcolTest_Type.ColumnEdit = Me.redLookUpTest_Type
        Me.gcolTest_Type.FieldName = "idfsTestName"
        Me.gcolTest_Type.Name = "gcolTest_Type"
        '
        'redLookUpTest_Type
        '
        resources.ApplyResources(Me.redLookUpTest_Type, "redLookUpTest_Type")
        Me.redLookUpTest_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookUpTest_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.redLookUpTest_Type.Name = "redLookUpTest_Type"
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
        'gcolDiagnosis
        '
        resources.ApplyResources(Me.gcolDiagnosis, "gcolDiagnosis")
        Me.gcolDiagnosis.FieldName = "idfsDiagnosis"
        Me.gcolDiagnosis.Name = "gcolDiagnosis"
        '
        'gcolTestResult
        '
        Me.gcolTestResult.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolTestResult, "gcolTestResult")
        Me.gcolTestResult.ColumnEdit = Me.redLookUpTestResult
        Me.gcolTestResult.FieldName = "idfsTestResult"
        Me.gcolTestResult.Name = "gcolTestResult"
        '
        'redLookUpTestResult
        '
        resources.ApplyResources(Me.redLookUpTestResult, "redLookUpTestResult")
        Me.redLookUpTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookUpTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.redLookUpTestResult.Name = "redLookUpTestResult"
        '
        'gcolTForDType
        '
        Me.gcolTForDType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolTForDType, "gcolTForDType")
        Me.gcolTForDType.ColumnEdit = Me.redLookUpTForDType
        Me.gcolTForDType.FieldName = "idfsTestCategory"
        Me.gcolTForDType.Name = "gcolTForDType"
        '
        'redLookUpTForDType
        '
        resources.ApplyResources(Me.redLookUpTForDType, "redLookUpTForDType")
        Me.redLookUpTForDType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookUpTForDType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.redLookUpTForDType.Name = "redLookUpTForDType"
        '
        'gcolSpecimen_Type
        '
        Me.gcolSpecimen_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSpecimen_Type, "gcolSpecimen_Type")
        Me.gcolSpecimen_Type.ColumnEdit = Me.redLookUpSpecimen_Type
        Me.gcolSpecimen_Type.FieldName = "idfsSampleType"
        Me.gcolSpecimen_Type.Name = "gcolSpecimen_Type"
        '
        'redLookUpSpecimen_Type
        '
        resources.ApplyResources(Me.redLookUpSpecimen_Type, "redLookUpSpecimen_Type")
        Me.redLookUpSpecimen_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookUpSpecimen_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.redLookUpSpecimen_Type.Name = "redLookUpSpecimen_Type"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Properties.NullText = resources.GetString("cbDiagnosis.Properties.NullText")
        Me.cbDiagnosis.Tag = "{AlwaysEditable}"
        '
        'lblDiagnosis
        '
        resources.ApplyResources(Me.lblDiagnosis, "lblDiagnosis")
        Me.lblDiagnosis.Name = "lblDiagnosis"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Image = Global.EIDSS.My.Resources.Resources.Save
        Me.btnSave.Name = "btnSave"
        '
        'TestForDiseaseDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.cbDiagnosis)
        Me.Controls.Add(Me.gcTest_For_Disease)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A04"
        Me.HelpTopicID = "Diagnosis-Lab_Tests_Matrix"
        Me.KeyFieldName = "idfTestForDisease"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Matrix__large__46_
        Me.MinHeight = 400
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.MinWidth = 800
        Me.Name = "TestForDiseaseDetail"
        Me.ObjectName = "TestForDisease"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "TestForDisease"
        Me.Controls.SetChildIndex(Me.gcTest_For_Disease, 0)
        Me.Controls.SetChildIndex(Me.cbDiagnosis, 0)
        Me.Controls.SetChildIndex(Me.lblDiagnosis, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        CType(Me.gcTest_For_Disease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Test_For_DiseaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookUpTest_Type, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinEditQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookUpTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookUpTForDType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookUpSpecimen_Type, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal parentControl As Control)
        m_Parent = parentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuTest_For_Disease", 974, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnTest_For_Disease"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New TestForDiseaseDetail, Nothing)
        'BaseForm.ShowModal(New Test_For_DiseaseDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        m_RefView = m_Helper.BindView(baseDataSet, True)

        Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.StandardDiagnosis, "MasterDiagnosis.idfsDiagnosis", True, False, True)
        eventManager.AttachDataHandler("MasterDiagnosis.idfsDiagnosis", AddressOf m_Helper.RefType_Changed)

        Core.LookupBinder.BindBaseRepositoryLookup(redLookUpTest_Type, _
                                              db.BaseReferenceType.rftTestName, True)

        Core.LookupBinder.BindBaseRepositoryLookup(redLookUpTForDType, _
                                              db.BaseReferenceType.rftTestCategory, False)

        eventManager.Cascade("MasterDiagnosis.idfsDiagnosis")

    End Sub
    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("TestForDisease").GetChanges() Is Nothing
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub Test_For_DiseaseView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles Test_For_DiseaseView.ValidateRow
        m_Helper.ValidateRow(e)
    End Sub
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                btnDelete.Visible = False
            Else
                If Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        model.Enums.EIDSSPermissionObject.Reference)) Then
                    btnDelete.Visible = True
                    btnDelete.Enabled = False
                End If
                If Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                        model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not m_RefView Is Nothing Then m_RefView.AllowNew = False
                End If
                If Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                        model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not m_RefView Is Nothing Then m_RefView.AllowEdit = False
                End If
            End If
        End Set
    End Property

End Class
