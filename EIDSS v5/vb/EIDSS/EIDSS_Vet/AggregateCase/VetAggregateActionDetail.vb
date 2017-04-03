Imports System.Collections.Generic
Imports System.Globalization
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports EIDSS.model.Reports

Public Class VetAggregateActionDetail
    Inherits BaseDetailForm

    ReadOnly m_AggregateCaseDbService As VetAggregateAction_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        m_AggregateCaseDbService = New VetAggregateAction_DB

        DbService = m_AggregateCaseDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoAggregateVetAction, AuditTable.tlbAggrCase)

        PermissionObject = EIDSSPermissionObject.VetCase
        AggregateHeader1.UseParentDataset = True
        RegisterChildObject(AggregateHeader1, RelatedPostOrder.SkipPost)

        RegisterChildObject(fgDiagnosticAction, RelatedPostOrder.PostLast)
        RegisterChildObject(fgProphylacticAction, RelatedPostOrder.PostLast)
        RegisterChildObject(fgSanitaryAction, RelatedPostOrder.PostLast)
        fgDiagnosticAction.SectionTableCaptionsIsVisible = False
        fgProphylacticAction.SectionTableCaptionsIsVisible = False
        fgSanitaryAction.SectionTableCaptionsIsVisible = False
    End Sub

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal parentControl As Windows.Forms.Control)
        m_Parent = parentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewVetAggregateAction", 440)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.VetAggregateAction
        ma.Name = "btnNewVetAggregateAction"
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.VetCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New VetAggregateActionDetail, Nothing)
        'BaseForm.ShowModal(New VetAggregateActionDetail)
    End Sub
#End Region


    Private Function ShowDiagnosticActions() As Boolean
        Dim result As Boolean
        result = AggregateHeader1.ShowFlexibleForm(fgDiagnosticAction, FFType.VetEpizooticActionDiagnosisInv, Nothing, Nothing)
        fgDiagnosticAction.Visible = result
        lbNoDiagnosticActionMatrix.Visible = Not result
        cbDiagnosticMatrixVersion.Visible = result
        lbDiagnosticMatrixVersion.Visible = result
        lbDiagnosticFormTemplate.Visible = result
        cbDiagnosticFormTemplate.Visible = result

        If result Then
            Core.LookupBinder.BindAggregateMatrixVersionLookup(cbDiagnosticMatrixVersion, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfDiagnosticVersion", AggregateCaseSection.DiagnosticAction, True)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfDiagnosticVersion", AddressOf MatrixDiagnosticVersionChanged)
            Core.LookupBinder.BindFFTemplatesLookup(cbDiagnosticFormTemplate, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfsDiagnosticObservationFormTemplate", FFType.VetEpizooticActionDiagnosisInv)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsDiagnosticObservationFormTemplate", AddressOf DiagnosticFormTemplateChanged)
            AggregateHeader1.AttachCellChangingHandler(fgDiagnosticAction)
        End If
        Return result
    End Function

    Private Sub DiagnosticFormTemplateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgDiagnosticAction, FFType.VetEpizooticActionDiagnosisInv, CType(e.Value, Nullable(Of Long)), Nothing)
    End Sub
    Private Sub MatrixDiagnosticVersionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgDiagnosticAction, FFType.VetEpizooticActionDiagnosisInv, Nothing, Utils.ToNullableLong(e.Value))
    End Sub

    Private Function ShowProphylacticActions() As Boolean
        Dim result As Boolean
        result = AggregateHeader1.ShowFlexibleForm(fgProphylacticAction, FFType.VetEpizooticActionTreatment, Nothing, Nothing)
        fgProphylacticAction.Visible = result
        lbNoProphylacticActionMatrix.Visible = Not result
        cbProphylacticMatrixVersion.Visible = result
        lbProphylacticMatrixVersion.Visible = result
        lbProphylacticFormTemplate.Visible = result
        cbProphylacticFormTemplate.Visible = result
        If result Then
            Core.LookupBinder.BindAggregateMatrixVersionLookup(cbProphylacticMatrixVersion, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfProphylacticVersion", AggregateCaseSection.ProphylacticAction, True)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfProphylacticVersion", AddressOf MatrixProphylacticVersionChanged)
            Core.LookupBinder.BindFFTemplatesLookup(cbProphylacticFormTemplate, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfsProphylacticObservationFormTemplate", FFType.VetEpizooticActionTreatment)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsProphylacticObservationFormTemplate", AddressOf ProphylacticFormTemplateChanged)
            AggregateHeader1.AttachCellChangingHandler(fgProphylacticAction)
        End If
        Return result
    End Function

    Private Sub ProphylacticFormTemplateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgProphylacticAction, FFType.VetEpizooticActionTreatment, CType(e.Value, Nullable(Of Long)), Nothing)
    End Sub
    Private Sub MatrixProphylacticVersionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgProphylacticAction, FFType.VetEpizooticActionTreatment, Nothing, Utils.ToNullableLong(e.Value))
    End Sub

    Private Function ShowSanitaryActions() As Boolean
        Dim result As Boolean
        result = AggregateHeader1.ShowFlexibleForm(fgSanitaryAction, FFType.VetEpizooticAction, Nothing, Nothing)
        fgSanitaryAction.Visible = result
        lbNoSanitaryActionMatrix.Visible = Not result
        cbSanitaryMatrixVersion.Visible = result
        lbSanitaryMatrixVersion.Visible = result
        lbSanitaryFormTemplate.Visible = result
        cbSanitaryFormTemplate.Visible = result
        If result Then
            Core.LookupBinder.BindAggregateMatrixVersionLookup(cbSanitaryMatrixVersion, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfSanitaryVersion", AggregateCaseSection.SanitaryAction, True)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfSanitaryVersion", AddressOf MatrixSanitaryVersionChanged)
            Core.LookupBinder.BindFFTemplatesLookup(cbSanitaryFormTemplate, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfsSanitaryObservationFormTemplate", FFType.VetEpizooticAction)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsSanitaryObservationFormTemplate", AddressOf SanitaryFormTemplateChanged)
            AggregateHeader1.AttachCellChangingHandler(fgSanitaryAction)
        End If
        Return result
    End Function

    Private Sub SanitaryFormTemplateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgSanitaryAction, FFType.VetEpizooticAction, CType(e.Value, Nullable(Of Long)), Nothing)
    End Sub
    Private Sub MatrixSanitaryVersionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgSanitaryAction, FFType.VetEpizooticAction, Nothing, Utils.ToNullableLong(e.Value))
    End Sub

    Protected Overrides Sub AfterLoad()
        lbNoDiagnosticActionMatrix.Text = EidssMessages.Get("errNoDiagnosticActionMatrix")
        lbNoProphylacticActionMatrix.Text = EidssMessages.Get("errNoProphylacticActionMatrix")
        lbNoSanitaryActionMatrix.Text = EidssMessages.Get("errNoSanitaryActionMatrix")
        Dim diagnosticActionOk As Boolean = ShowDiagnosticActions()
        Dim prophylacticActionOk As Boolean = ShowProphylacticActions()
        Dim sanitaryActionOk As Boolean = ShowSanitaryActions()
        If Not (diagnosticActionOk OrElse prophylacticActionOk OrElse sanitaryActionOk) Then
            Me.ReadOnly = True
        End If
    End Sub


#Region "REPORTS SUPPORT"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            Dim id As Long = CType(DbService.ID, Long)
            Dim diagnosticObservation As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfDiagnosticObservation"))
            Dim prophylacticObservation As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfProphylacticObservation"))
            Dim sanitaryObservation As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfSanitaryObservation"))

            Dim diagnosticTemplate As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfsDiagnosticObservationFormTemplate"))
            Dim prophylacticTemplate As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfsProphylacticObservationFormTemplate"))
            Dim sanitaryTemplate As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfsSanitaryObservationFormTemplate"))


            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetAggregateSummaryActionDetail))
            Dim labels As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            For Each language As String In Localizer.SupportedLanguages.Keys
                Dim cultureInfo As CultureInfo = New CultureInfo(Localizer.SupportedLanguages(language))
                Dim lang As String = language
                labels.Add("@diagnosticText" + lang, resources.GetString("xtpDiagnosticAction.Text", cultureInfo))
                labels.Add("@prophylacticText" + lang, resources.GetString("xtpProphilacticAction.Text", cultureInfo))
                labels.Add("@sanitaryText" + lang, resources.GetString("xtpSanitaryAction.Text", cultureInfo))
            Next

            Dim aggrParams As AggregateActionsParameters =
                    New AggregateActionsParameters(id,
                                                   diagnosticTemplate,diagnosticObservation,
                                                   prophylacticTemplate,prophylacticObservation,
                                                   sanitaryTemplate,sanitaryObservation,
                                                   labels)
            EidssSiteContext.ReportFactory.VetAggregateCaseActions(aggrParams)
        End If
    End Sub

#End Region



End Class
