Imports EIDSS.model.Resources

Public Class DataAuditDetail
    Dim DataAuditDbService As DataAudit_DB

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataAuditDbService = New DataAudit_DB
        DbService = DataAuditDbService
        'TODO:[Mike] create special permission object for DataAudit
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.AccessToDataAudit
        Me.IgnoreAudit = True
    End Sub
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindTextEdit(txtActionType, baseDataSet, "DataAudit.strActionName")
        Core.LookupBinder.BindTextEdit(txtDate, baseDataSet, "DataAudit.datEnteringDate")
        Core.LookupBinder.BindTextEdit(txtObjectID, baseDataSet, "DataAudit.idfMainObject")
        Core.LookupBinder.BindTextEdit(txtObjectType, baseDataSet, "DataAudit.strObjectType")
        Core.LookupBinder.BindTextEdit(txtServerName, baseDataSet, "DataAudit.strHostname")
        Core.LookupBinder.BindTextEdit(txtSiteID, baseDataSet, "DataAudit.strSiteID")
        Core.LookupBinder.BindTextEdit(txtTableName, baseDataSet, "DataAudit.strTableName")
        Core.LookupBinder.BindTextEdit(txtUser, baseDataSet, "DataAudit.strPersonName")
        DataAuditGrid.DataSource = baseDataSet.Tables("DataAuditDetail")
        btnRestore.Visible = baseDataSet.Tables("DataAudit").Rows(0)("idfsDataAuditEventType").Equals(CLng(AuditEventType.daeDelete)) 'Delete
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As System.EventArgs) Handles btnRestore.Click
        If Not DataAuditDbService.CanRestore(GetKey()) Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("errCantRestoreRecord", "This object can't be restored"))
            Return
        End If

        If (DataAuditDbService.Restore(GetKey())) Then
            bv.winclient.Core.MessageForm.Show(EidssMessages.Get("msgObjectIsRestored", "Objects are successfully restored"))
            EventLog.CreateEvent(EventType.ObjectRestoring, baseDataSet.Tables("DataAudit").Rows(0)("strObjectType"))

            DoClose()
        End If

    End Sub
End Class
