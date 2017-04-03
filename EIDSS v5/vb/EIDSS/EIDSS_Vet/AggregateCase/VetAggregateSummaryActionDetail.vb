Imports System.Collections.Generic
Imports System.Globalization
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports EIDSS.model.Reports

Public Class VetAggregateSummaryActionDetail
    Inherits BaseDetailForm

    Dim AggregateCaseDbService As VetAggregateSummaryAction_DB

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Search, "MenuViewVetAggregateSummaryAction", 260)
        ma.ShowInToolbar = False
        ma.BigIconIndex = MenuIcons.VetAggregateActionSummary
        ma.SmallIconIndex = MenuIconsSmall.VetAggregateActionSummary
        ma.Name = "btnViewVetAggregateSummaryAction"
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.VetCase)

        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarFindVetAggregateSummaryAction", 309)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.VetAggregateActionSummary
        ma.Name = "btnFindVetAggregateSummaryAction"
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.VetCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowClient(New VetAggregateSummaryActionDetail, m_Parent, Nothing)
    End Sub
#End Region

    Protected Overrides Sub AfterLoad()
        lbNoDiagnosticActionMatrix.Text = EidssMessages.Get("errNoDiagnosticActionMatrix")
        lbNoProphylacticActionMatrix.Text = EidssMessages.Get("errNoProphylacticActionMatrix")
        lbNoSanitaryActionMatrix.Text = EidssMessages.Get("errNoSanitaryActionMatrix")
        AggregateHelper.DisplayEmptySummary(fgDiagnosticAction, FFType.VetEpizooticActionDiagnosisInv, lbNoDiagnosticActionMatrix)
        AggregateHelper.DisplayEmptySummary(fgProphylacticAction, FFType.VetEpizooticActionTreatment, lbNoProphylacticActionMatrix)
        AggregateHelper.DisplayEmptySummary(fgSanitaryAction, FFType.VetEpizooticAction, lbNoSanitaryActionMatrix)
        fgDiagnosticAction.SectionTableCaptionsIsVisible = False
        fgProphylacticAction.SectionTableCaptionsIsVisible = False
        fgSanitaryAction.SectionTableCaptionsIsVisible = False
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        Return True
    End Function

#Region "Flexible Form Support"

    Private Sub FFClear()
        AggregateHelper.ClearFlexibleForm(fgDiagnosticAction)
        AggregateHelper.ClearFlexibleForm(fgProphylacticAction)
        AggregateHelper.ClearFlexibleForm(fgSanitaryAction)
    End Sub


    Private Sub ShowFFSummary()
        AggregateHelper.DisplaySummary(fgDiagnosticAction, FFType.VetEpizooticActionDiagnosisInv, AggregateSummaryHeader1.GetObservarionsList("idfDiagnosticObservation"), lbNoDiagnosticActionMatrix)
        AggregateHelper.DisplaySummary(fgProphylacticAction, FFType.VetEpizooticActionTreatment, AggregateSummaryHeader1.GetObservarionsList("idfProphylacticObservation"), lbNoProphylacticActionMatrix)
        AggregateHelper.DisplaySummary(fgSanitaryAction, FFType.VetEpizooticAction, AggregateSummaryHeader1.GetObservarionsList("idfSanitaryObservation"), lbNoSanitaryActionMatrix)
    End Sub
#End Region

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
        'AggregateSummaryHeader1.Reload()
        FFClear()
        ShowFFSummary()
    End Sub

    Public Overloads Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        'btnShowSummary.Enabled = AggregateSummaryHeader1.EnableReports
        'btnViewDetailForm.Enabled = AggregateSummaryHeader1.EnableDetailView
        PopUpButton1.Enabled = AggregateSummaryHeader1.EnableReports
    End Sub


    'Private Sub btnViewDetailForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewDetailForm.Click
    '    AggregateSummaryHeader1.ShowAggregateDetailForm(New VetAggregateActionDetail)
    'End Sub

    Private Sub btnShowSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowSummary.Click
        FFClear()
        ShowFFSummary()
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
            Dim diagnosticObservations As List(Of Long) = AggregateSummaryHeader1.GetObservarionsList("idfDiagnosticObservation")
            If (ReferenceEquals(diagnosticObservations, Nothing)) Then
                diagnosticObservations = New List(Of Long)
            End If

            Dim prophylacticObservation As List(Of Long) = AggregateSummaryHeader1.GetObservarionsList("idfProphylacticObservation")
            If (ReferenceEquals(prophylacticObservation, Nothing)) Then
                prophylacticObservation = New List(Of Long)
            End If
            Dim sanitaryObservations As List(Of Long) = AggregateSummaryHeader1.GetObservarionsList("idfSanitaryObservation")
            If (ReferenceEquals(sanitaryObservations, Nothing)) Then
                sanitaryObservations = New List(Of Long)
            End If


            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetAggregateSummaryActionDetail))
            Dim labels As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            For Each language As String In Localizer.SupportedLanguages.Keys
                Dim cultureInfo As CultureInfo = New CultureInfo(Localizer.SupportedLanguages(language))
                Dim key As String = language
                labels.Add("@diagnosticText" + key, resources.GetString("xtpDiagnosticAction.Text", cultureInfo))
                labels.Add("@prophylacticText" + key, resources.GetString("xtpProphilacticAction.Text", cultureInfo))
                labels.Add("@sanitaryText" + key, resources.GetString("xtpSanitaryAction.Text", cultureInfo))
            Next

            Dim aggrParams As AggregateActionsSummaryParameters =
                New AggregateActionsSummaryParameters(AggrXml, diagnosticObservations, prophylacticObservation, sanitaryObservations, labels)
            EidssSiteContext.ReportFactory.VetAggregateCaseActionsSummary(aggrParams)
        End If
    End Sub
#End Region


End Class
