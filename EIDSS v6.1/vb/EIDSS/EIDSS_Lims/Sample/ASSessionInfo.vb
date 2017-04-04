Public Class ASSessionInfo

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.UseParentDataset = True

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Public Sub Bind(ByVal ds As DataSet)
    Protected Overrides Sub DefineBinding()
        If baseDataSet.Tables.Count = 0 Then Exit Sub
        'Me.txtCaseID.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".strMonitoringSessionID")
        Me.txtCampaignID.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".strCampaignID")
        Me.txtCampaignName.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".strCampaignName")
        Me.txtCampaignType.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".CampaignType")
        'Me.txtSessionStatus.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".SessionStatus")
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCampaignID.Click

    End Sub
End Class