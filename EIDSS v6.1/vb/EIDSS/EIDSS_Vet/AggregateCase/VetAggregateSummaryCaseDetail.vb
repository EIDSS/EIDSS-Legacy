Imports System.Collections.Generic
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports eidss.model.Enums
Imports eidss.model.Reports
Imports bv.common.Enums

Public Class VetAggregateSummaryCaseDetail
    Inherits BaseDetailForm

    Dim AggregateCaseDbService As VetAggregateSummaryCase_DB

#Region "Main form interface"

    Private Shared m_Parent As Control

    Public Shared Sub Register(ByVal ParentControl As Control)
        If EidssSiteContext.Instance.IsAzerbaijanCustomization Then
            Exit Sub
        End If

        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search, "MenuViewVetAggregateSummaryCase", 250)
        ma.ShowInToolbar = False
        ma.BigIconIndex = MenuIcons.VetAggregateSummary
        ma.SmallIconIndex = MenuIconsSmall.VetAggregateCaseSummary
        ma.Name = "btnViewVetAggregateSummaryCase"
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.AccessToVetAggregateCase)

        'Toolbar menu
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "MenuViewVetAggregateSummaryCase", 100210)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.VetAggregateSummary
        ma.Name = "btnFindVetAggregateSummaryCase"
        ma.Group = CInt(MenuGroup.ToolbarAggregate)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.AccessToVetAggregateCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowClient(New VetAggregateSummaryCaseDetail, m_Parent, Nothing)
    End Sub

#End Region

    Dim m_Updating As Boolean = False

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return MyBase.GetChildKey(child)
    End Function

    Protected Overrides Sub AfterLoad()
        lbNoVetCaseMatrix.Text = EidssMessages.Get("errNoVetAggregateCaseMatrix")
        AggregateHelper.DisplayEmptySummary(fgAggrCase, FFType.VetAggregateCase, lbNoVetCaseMatrix)
        fgAggrCase.SectionTableCaptionsIsVisible = False

    End Sub

    Public Overrides Function Post(Optional ByVal postType As PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        If LockHandler() Then
            Try
                Me.cmdClose_Click()
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        'AggregateSummaryHeader1.Reload()
        AggregateHelper.ClearFlexibleForm(fgAggrCase)
        AggregateHelper.DisplaySummary(fgAggrCase, FFType.VetAggregateCase, AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation"), lbNoVetCaseMatrix)
    End Sub

    Public Overloads Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        btnShowSummary.Enabled = AggregateSummaryHeader1.SummaryParamsDefined
        'btnViewDetailForm.Enabled = AggregateSummaryHeader1.EnableDetailView
        PopUpButton1.Enabled = AggregateSummaryHeader1.EnableReports
    End Sub

    'Private Sub btnViewDetailForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewDetailForm.Click
    '    AggregateSummaryHeader1.ShowAggregateDetailForm(New VetAggregateCaseDetail)
    'End Sub

    Private Sub btnShowSummary_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowSummary.Click
        AggregateHelper.ClearFlexibleForm(fgAggrCase)
        AggregateHelper.DisplaySummary(fgAggrCase, FFType.VetAggregateCase, AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation"), lbNoVetCaseMatrix)
    End Sub

    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

#Region "REPORTS SUPPORT"

    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        Dim AggrXml As String = AggregateSummaryHeader1.GetCurrentParametersXML()

        If (Not Utils.IsEmpty(AggrXml)) Then
            Dim observations As List(Of Long) = AggregateSummaryHeader1.GetObservarionsList("idfCaseObservation") 'AggregateSummary_DB.GetObservationsList(AggrXml, FFType.HumanAggregateCase)
            If (ReferenceEquals(observations, Nothing)) Then
                observations = New List(Of Long)
            End If

            EidssSiteContext.ReportFactory.VetAggregateCaseSummary(New AggregateSummaryReportParameters(AggrXml, observations))
        End If
    End Sub

#End Region
End Class