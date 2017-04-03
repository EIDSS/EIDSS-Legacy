Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports bv.common.Enums
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid

Public Class DiagnosisReferenceDetail

    Inherits BaseDetailList

    Dim ReferenceDbService As Diagnosis_DB
    Friend WithEvents cbHACode As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents RefView As DataView
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtOrder As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colZoonotic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkZoonotic As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private m_Helper As ReferenceEditorHelper


#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        ReferenceDbService = New Diagnosis_DB

        DbService = ReferenceDbService
        m_Helper = New ReferenceEditorHelper(gcReference, colNationalName, "strDefault,name,idfsUsingType", Nothing) '"strDefault,Name"
        m_Helper.CanDeleteProc = "spDiagnosis_CanDelete"
        colEnglishName.ColumnEdit = ReferenceEditorHelper.EnglishValueEditor

        AuditObject = New AuditObject(EIDSSAuditObject.daoDiagnosis, AuditTable.trtBaseReference)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            SaveButton.Enabled = False
        End If
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.DataAccess)) Then
            cmdPermissions.Enabled = False
        End If
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
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colEnglishName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNationalName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcReference As DevExpress.XtraGrid.GridControl
    Friend WithEvents strIDC10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolUsingType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDiagnosisUsingType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolHA_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdPermissions As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolOIECode As DevExpress.XtraGrid.Columns.GridColumn

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiagnosisReferenceDetail))
        Me.gcReference = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEnglishName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNationalName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.strIDC10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolOIECode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolUsingType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiagnosisUsingType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolHA_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbHACode = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.colZoonotic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkZoonotic = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gcolOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtOrder = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.cmdPermissions = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosisUsingType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbHACode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkZoonotic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(DiagnosisReferenceDetail), resources)
        'Form Is Localizable: True
        '
        'gcReference
        '
        resources.ApplyResources(Me.gcReference, "gcReference")
        Me.gcReference.MainView = Me.GridView1
        Me.gcReference.Name = "gcReference"
        Me.gcReference.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDiagnosisUsingType, Me.cbHACode, Me.txtOrder, Me.chkZoonotic})
        Me.gcReference.TabStop = False
        Me.gcReference.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEnglishName, Me.colNationalName, Me.strIDC10, Me.gcolOIECode, Me.gcolUsingType, Me.gcolHA_Code, Me.colZoonotic, Me.gcolOrder})
        Me.GridView1.GridControl = Me.gcReference
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEnglishName
        '
        Me.colEnglishName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colEnglishName, "colEnglishName")
        Me.colEnglishName.FieldName = "strDefault"
        Me.colEnglishName.Name = "colEnglishName"
        '
        'colNationalName
        '
        Me.colNationalName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colNationalName, "colNationalName")
        Me.colNationalName.FieldName = "name"
        Me.colNationalName.Name = "colNationalName"
        '
        'strIDC10
        '
        Me.strIDC10.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.strIDC10, "strIDC10")
        Me.strIDC10.FieldName = "strIDC10"
        Me.strIDC10.Name = "strIDC10"
        '
        'gcolOIECode
        '
        Me.gcolOIECode.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolOIECode, "gcolOIECode")
        Me.gcolOIECode.FieldName = "strOIECode"
        Me.gcolOIECode.Name = "gcolOIECode"
        '
        'gcolUsingType
        '
        Me.gcolUsingType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolUsingType, "gcolUsingType")
        Me.gcolUsingType.ColumnEdit = Me.cbDiagnosisUsingType
        Me.gcolUsingType.FieldName = "idfsUsingType"
        Me.gcolUsingType.Name = "gcolUsingType"
        '
        'cbDiagnosisUsingType
        '
        resources.ApplyResources(Me.cbDiagnosisUsingType, "cbDiagnosisUsingType")
        Me.cbDiagnosisUsingType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosisUsingType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosisUsingType.Name = "cbDiagnosisUsingType"
        '
        'gcolHA_Code
        '
        Me.gcolHA_Code.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolHA_Code, "gcolHA_Code")
        Me.gcolHA_Code.ColumnEdit = Me.cbHACode
        Me.gcolHA_Code.FieldName = "intHACode"
        Me.gcolHA_Code.Name = "gcolHA_Code"
        '
        'cbHACode
        '
        resources.ApplyResources(Me.cbHACode, "cbHACode")
        Me.cbHACode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbHACode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbHACode.Name = "cbHACode"
        '
        'colZoonotic
        '
        resources.ApplyResources(Me.colZoonotic, "colZoonotic")
        Me.colZoonotic.ColumnEdit = Me.chkZoonotic
        Me.colZoonotic.FieldName = "blnZoonotic"
        Me.colZoonotic.Name = "colZoonotic"
        '
        'chkZoonotic
        '
        resources.ApplyResources(Me.chkZoonotic, "chkZoonotic")
        Me.chkZoonotic.Name = "chkZoonotic"
        Me.chkZoonotic.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gcolOrder
        '
        resources.ApplyResources(Me.gcolOrder, "gcolOrder")
        Me.gcolOrder.ColumnEdit = Me.txtOrder
        Me.gcolOrder.FieldName = "intOrder"
        Me.gcolOrder.Name = "gcolOrder"
        '
        'txtOrder
        '
        resources.ApplyResources(Me.txtOrder, "txtOrder")
        Me.txtOrder.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtOrder.DisplayFormat.FormatString = "n0"
        Me.txtOrder.Mask.BeepOnError = CType(resources.GetObject("txtOrder.Mask.BeepOnError"), Boolean)
        Me.txtOrder.Mask.EditMask = resources.GetString("txtOrder.Mask.EditMask")
        Me.txtOrder.MaxValue = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtOrder.Name = "txtOrder"
        '
        'cmdPermissions
        '
        resources.ApplyResources(Me.cmdPermissions, "cmdPermissions")
        Me.cmdPermissions.Name = "cmdPermissions"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'DiagnosisReferenceDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.gcReference)
        Me.Controls.Add(Me.cmdPermissions)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A02"
        Me.HelpTopicID = "Clinical_Diagnosis_Editor"
        Me.KeyFieldName = "idfsBaseReference"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Reference_Book__large__41_
        Me.Name = "DiagnosisReferenceDetail"
        Me.ObjectName = "Reference"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "BaseReference"
        Me.Controls.SetChildIndex(Me.cmdPermissions, 0)
        Me.Controls.SetChildIndex(Me.gcReference, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosisUsingType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbHACode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkZoonotic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 955)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuDiagnosisEditor", 910, False, model.Enums.MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnDiagnosisEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New DiagnosisReferenceDetail, Nothing)
        'BaseForm.ShowModal(New DiagnosisReferenceDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        Core.LookupBinder.BindBaseRepositoryLookup(cbDiagnosisUsingType, db.BaseReferenceType.rftDiagnosisUsingType, False)
        Core.LookupBinder.BindReprositoryHACodeLookup(cbHACode, baseDataSet.Tables("HACodes").DefaultView, GridView1, HACode.Avian Or HACode.Human Or HACode.Livestock Or HACode.Vector)
        gcolHA_Code.SortMode = ColumnSortMode.DisplayText
        RefView = m_Helper.BindView(baseDataSet, False)
        gcReference.Select()
        RefView.AllowEdit = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference))
        If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            RefView.AllowNew = True
            RefView.AllowEdit = True
        Else
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            RefView.AllowNew = False
        End If
        RefView.AllowDelete = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference))

    End Sub

    Private Sub DiagnosisType_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not e.Value Is DBNull.Value AndAlso e.Row.RowState <> DataRowState.Added AndAlso CLng(e.Value) = 10020001 Then 'StandardCase - case type is changed from standard

        End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    'Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Post(PostType.FinalPosting)
    'End Sub


    Private Sub cmdPermissions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPermissions.Click
        If GridView1.FocusedRowHandle < 0 Then Return
        Dim row As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        If row Is Nothing Then Return
        Dim ID As Object = row("idfsBaseReference")
        Dim dlg As BaseDetailForm = Nothing
        Dim dummy As Object = ClassLoader.LoadClass("ObjectAccessDetail")
        If (Not dummy Is Nothing) Then
            dlg = CType(dummy, BaseDetailForm)
        End If
        'Set required property "ObjectType"
        If Not dlg Is Nothing Then
            Dim pi As System.Reflection.PropertyInfo
            pi = dlg.GetType().GetProperty("ObjectType")
            pi.SetValue(dlg, ObjectType.Diagnosis, Nothing)
            BaseFormManager.ShowModal(dlg, FindForm, ID, Nothing, Nothing)
        End If
    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
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
                SaveButton.Visible = False
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
                    SaveButton.Visible = True
                    SaveButton.Enabled = False
                Else
                    SaveButton.Visible = True
                    SaveButton.Enabled = True
                End If
            End If
        End Set
    End Property
    Public Overrides Function ValidateData() As Boolean
        If m_Helper.FindDuplicates() Then
            Return False
        End If
        Return True
        'Dim dt As DataTable = baseDataSet.Tables("BaseReference").GetChanges(DataRowState.Deleted)
        'For Each Row As DataRow In dt.Rows

        'Next
    End Function

    Private Sub cbDiagnosisUsingType_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbDiagnosisUsingType.EditValueChanging
        If Utils.IsEmpty(e.NewValue) Then
            e.Cancel = True
        ElseIf Not Utils.IsEmpty(e.OldValue) Then
            Dim row As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If row Is Nothing Then Return
            e.Cancel = Not m_Helper.CanDeleteRow(row, EidssMessages.Get("msgCantChangeDiagnosisUsingType"))
        End If
    End Sub

    Private Sub cbHACode_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbHACode.EditValueChanging
        If Utils.IsEmpty(e.NewValue) OrElse GridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Return
        End If
        Dim errOccured As Boolean = False
        Try
            Dim row As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If row Is Nothing Then Return
            e.Cancel = False
            If Not Utils.IsEmpty(e.OldValue) AndAlso (CInt(e.OldValue) And CInt(HACode.Human)) <> 0 AndAlso (Utils.IsEmpty(e.NewValue) OrElse (CInt(e.NewValue) And CInt(HACode.Human)) = 0) Then
                e.Cancel = Not ReferenceDbService.CanClearHACode(row, HACode.Human)
                If e.Cancel Then Return
            End If
            If Not Utils.IsEmpty(e.OldValue) AndAlso (CInt(e.OldValue) And CInt(HACode.Avian)) <> 0 AndAlso (Utils.IsEmpty(e.NewValue) OrElse (CInt(e.NewValue) And CInt(HACode.Avian)) = 0) Then
                e.Cancel = Not ReferenceDbService.CanClearHACode(row, HACode.Avian)
                If e.Cancel Then Return
            End If
            If Not Utils.IsEmpty(e.OldValue) AndAlso (CInt(e.OldValue) And CInt(HACode.Livestock)) <> 0 AndAlso (Utils.IsEmpty(e.NewValue) OrElse (CInt(e.NewValue) And CInt(HACode.Livestock)) = 0) Then
                e.Cancel = Not ReferenceDbService.CanClearHACode(row, HACode.Livestock)
                If e.Cancel Then Return
            End If
        Catch ex As Exception
            ErrorForm.ShowError(StandardError.StoredProcedureError, ex)
            e.Cancel = True
            errOccured = True

        Finally
            If e.Cancel AndAlso Not errOccured Then
                If WinUtils.ConfirmMessage(EidssMessages.Get("msgConfirmHACodeChangedForDiagnosis"), BvMessages.Get("Confirmation")) Then
                    e.Cancel = False
                End If
            End If
        End Try
    End Sub
End Class
