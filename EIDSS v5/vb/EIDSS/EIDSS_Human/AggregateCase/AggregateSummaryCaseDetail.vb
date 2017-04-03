Imports bv.winclient.BasePanel
Imports bv.common.db
Imports System.Collections.Generic
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports EIDSS.model.Reports

Public Class AggregateSummaryCaseDetail
    Inherits BaseDetailForm

    Dim AggregateCaseDbService As AggregateSummaryCase_DB

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search, "MenuViewAggregateSummaryCase", 240)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.HumanAggregateCaseSummary
        ma.BeginGroup = True
        ma.Name = "btnViewAggregateSummaryCase"
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarFindAggregateSummaryCase", 307)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.HumanAggregateSummary
        ma.Name = "btnFindAggregateSummaryCase"
        ma.BeginGroup = True
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowClient(New AggregateSummaryCaseDetail, m_Parent, Nothing)
    End Sub
#End Region




    Dim m_Updating As Boolean = False

    Protected Overrides Sub AfterLoad()
        lbNoHumanMatrix.Text = EidssMessages.Get("errNoHumanAggregateCaseMatrix")
        AggregateHelper.DisplayEmptySummary(fgAggrCase, FFType.HumanAggregateCase, lbNoHumanMatrix)
        fgAggrCase.SectionTableCaptionsIsVisible = False
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If LockHandler() Then
            Try
                Me.cmdClose_Click()
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        '''AggregateSummaryHeader1.Reload()
        AggregateHelper.ClearFlexibleForm(fgAggrCase)
        AggregateHelper.DisplaySummary(fgAggrCase, FFType.HumanAggregateCase, AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation"), lbNoHumanMatrix)
    End Sub

    Public Overloads Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        'btnShowSummary.Enabled = AggregateSummaryHeader1.EnableReports
        '''btnViewDetailForm.Enabled = AggregateSummaryHeader1.EnableDetailView
        PopUpButton1.Enabled = AggregateSummaryHeader1.EnableReports
    End Sub


    Private Sub btnViewDetailForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewDetailForm.Click
        '''AggregateSummaryHeader1.ShowAggregateDetailForm(New AggregateCaseDetail)
    End Sub

    Private Sub btnShowSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowSummary.Click
        btnShowSummary.Enabled = False
        btnRefresh.Enabled = False
        AggregateHelper.ClearFlexibleForm(fgAggrCase)
        AggregateHelper.DisplaySummary(fgAggrCase, FFType.HumanAggregateCase, AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation"), lbNoHumanMatrix)
        btnShowSummary.Enabled = True
        btnRefresh.Enabled = True
    End Sub

    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

#Region "REPORTS SUPPORT"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        Dim AggrXml As String = AggregateSummaryHeader1.GetCurrentParametersXML()
        If (Not Utils.IsEmpty(AggrXml)) Then
            Dim observations As List(Of Long) = AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation") 'AggregateSummary_DB.GetObservationsList(AggrXml, FFType.HumanAggregateCase)
            If (Not (ReferenceEquals(observations, Nothing))) Then
                EidssSiteContext.ReportFactory.HumAggregateCaseSummary(New AggregateSummaryReportParameters(AggrXml, observations))
                'DVDoc.Show_HUM_AggregateSummaryReport(bv.model.Model.Core.ModelUserContext.CurrentLanguage, AggrXml, SelectTemplate())
            End If
        End If
    End Sub

#End Region

End Class