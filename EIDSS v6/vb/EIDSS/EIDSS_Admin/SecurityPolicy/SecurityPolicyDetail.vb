Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.Drawing
Imports EIDSS.model.Enums

Public Class SecurityPolicyDetail

    Public Sub New()

        InitializeComponent()
        Me.DbService = New SecurityPolicy_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoSystemFunction, AuditTable.tstGlobalSiteOptions)
        PermissionObject = eidss.model.Enums.EIDSSPermissionObject.SecurityPolicy

    End Sub

    Shared m_Parent As Control

    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If (BaseFormManager.ArchiveMode) Then
            Return
        End If
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security, "MenuSecurityPolicy", 1005, False, model.Enums.MenuIconsSmall.SecurityPolicy, -1)
        ma.ShowInToolbar = False
        ma.Name = "btnSecurityPolicy"
        ma.BeginGroup = True
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.SecurityPolicy)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New SecurityPolicyDetail, Nothing)
    End Sub

    Protected Overrides Sub DefineBinding()

        MyBase.DefineBinding()
        Dim table As DataTable = Me.baseDataSet.Tables(0)
        'Dim a1 As DataView = New DataView(table, "strName='PasswordHistoryLength'", Nothing, DataViewRowState.CurrentRows)
        'Dim a2 As DataView = New DataView(table, "strName='PasswordMinimalLength'", Nothing, DataViewRowState.CurrentRows)
        'Dim a3 As DataView = New DataView(table, "strName='AccountLockTimeout'", Nothing, DataViewRowState.CurrentRows)
        'Dim a4 As DataView = New DataView(table, "strName='AccountTryCount'", Nothing, DataViewRowState.CurrentRows)
        'Dim a5 As DataView = New DataView(table, "strName='PasswordAge'", Nothing, DataViewRowState.CurrentRows)
        'Dim a6 As DataView = New DataView(table, "strName='ForcePasswordComplexity'", Nothing, DataViewRowState.CurrentRows)
        'Dim a7 As DataView = New DataView(table, "strName='InactivityTimeout'", Nothing, DataViewRowState.CurrentRows)

        Me.txtPasswordHistory.DataBindings.Add("EditValue", table, "intPasswordHistoryLength")
        Me.txtMinimumLength.DataBindings.Add("EditValue", table, "intPasswordMinimalLength")
        Me.txtLockoutPeriod.DataBindings.Add("EditValue", table, "intAccountLockTimeout")
        Me.txtLockThreshold.DataBindings.Add("EditValue", table, "intAccountTryCount")
        Me.txtPasswordAge.DataBindings.Add("EditValue", table, "intPasswordAge")
        Me.chkPasswordComplexity.DataBindings.Add("EditValue", table, "intForcePasswordComplexity")
        Me.txtInactivityTimeout.DataBindings.Add("EditValue", table, "intInactivityTimeout")

        Me.chkPasswordComplexity.Enabled = SecurityPolicy_DB.PasswordExpression(baseDataSet).Length > 0

    End Sub
    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return Nothing
    End Function

    Private Sub SecurityPolicyDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim delta As Integer = (Me.txtDescription.Top + Me.txtDescription.Height + 8) - GroupControl2.ClientSize.Height
        Me.GroupControl2.ClientSize = New Size(GroupControl2.ClientSize.Width, Me.txtDescription.Top + Me.txtDescription.Height + 8)
        Me.GroupControl1.Top += delta
        Me.Height += delta
    End Sub

End Class