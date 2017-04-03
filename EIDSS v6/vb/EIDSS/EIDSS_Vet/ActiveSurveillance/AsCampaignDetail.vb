Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Resources
Imports eidss.model.Enums
Imports bv.common.Resources
Imports bv.model.Model.Core
Imports EIDSS.winclient.ActiveSurveillance
Imports DevExpress.Charts.Native
Imports System.Collections.Generic
Imports bv.common.Enums
Imports bv.common.win.Validators

Namespace ActiveSurveillance

    Public Class AsCampaignDetail
        Dim ASCampaignDbService As ASCampaign_DB
        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            InitCustomMandatoryFields()
            ASCampaignDbService = New ASCampaign_DB
            DbService = ASCampaignDbService
            AuditObject = New AuditObject(EIDSSAuditObject.daoCampaign, AuditTable.tlbCampaign)
            Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.Campaign

            If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                                                                          eidss.model.Enums.EIDSSPermissionObject.Campaign)) Then
                Me.cbCampaignStatus.Tag = Me.cbCampaignStatus.Tag.ToString().Replace("{alwayseditable}", "")
            End If
            m_RelatedLists = New String() {"AsCampaignListItem"}

        End Sub
#Region "Main form interface"
        Private Shared m_Parent As Control
        Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
            m_Parent = ParentControl
            Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewASCampaign", 245)
            ma.ShowInToolbar = False
            ma.SmallIconIndex = MenuIconsSmall.ASCampaign
            ma.Name = "btnNewASCampaign"
            ma.Group = CInt(MenuGroup.CreateSession)
            ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.Campaign)
            'Toolbar menu
            ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewASCampaign", 100135)
            ma.ShowInToolbar = True
            ma.ShowInMenu = False
            ma.BigIconIndex = MenuIcons.ASCampaign
            ma.Name = "btnNewASCampaign1"
            ma.Group = CInt(MenuGroup.ToolbarCreate)
            ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.Campaign)
        End Sub

        Public Shared Sub ShowMe()
            BaseFormManager.ShowNormal(New AsCampaignDetail, Nothing)
        End Sub

#End Region
        Private Sub InitCustomMandatoryFields()
            MandatoryFieldHelper.SetCustomMandatoryField(dtCampaignStartDate, CustomMandatoryField.ASCampaign_StartDate)
            MandatoryFieldHelper.SetCustomMandatoryField(dtCampaignEndDate, CustomMandatoryField.ASCampaign_EndDate)
        End Sub
        Protected Overrides Sub DefineBinding()
            Core.LookupBinder.BindTextEdit(txtCampaignAdministrator, baseDataSet, ASCampaign_DB.TableCampaign + ".strCampaignAdministrator")
            Core.LookupBinder.BindTextEdit(txtCampaignID, baseDataSet, ASCampaign_DB.TableCampaign + ".strCampaignID")
            Core.LookupBinder.BindTextEdit(txtCampaignName, baseDataSet, ASCampaign_DB.TableCampaign + ".strCampaignName")
            Core.LookupBinder.BindTextEdit(txtComments, baseDataSet, ASCampaign_DB.TableCampaign + ".strComments")
            Core.LookupBinder.BindTextEdit(txtConclusion, baseDataSet, ASCampaign_DB.TableCampaign + ".strConclusion")
            Core.LookupBinder.BindDateEdit(dtCampaignEndDate, baseDataSet, ASCampaign_DB.TableCampaign + ".datCampaignDateEnd")
            Core.LookupBinder.BindDateEdit(dtCampaignStartDate, baseDataSet, ASCampaign_DB.TableCampaign + ".datCampaignDateStart")
            Core.LookupBinder.BindBaseLookup(cbCampaignStatus, baseDataSet, ASCampaign_DB.TableCampaign + ".idfsCampaignStatus", bv.common.db.BaseReferenceType.rftCampaignStatus, False, False)
            Core.LookupBinder.BindBaseRepositoryLookup(cbSpecies, bv.common.db.BaseReferenceType.rftSpeciesList, HACode.Livestock, AddressOf Core.LookupBinder.AddSpecies)
            Core.LookupBinder.AddClearButton(cbSpecies, True)
            If baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)("idfsCampaignStatus").Equals(CLng(ASCampaignStatus.Closed)) Then
                If Not [ReadOnly] Then
                    [ReadOnly] = True
                End If
            End If
            eventManager.AttachDataHandler(ASCampaign_DB.TableCampaign + ".idfsCampaignStatus", AddressOf Status_Changed)


            Core.LookupBinder.BindBaseLookup(cbCampaignType, baseDataSet, ASCampaign_DB.TableCampaign + ".idfsCampaignType", bv.common.db.BaseReferenceType.rftCampaignType, False, False)
            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.LivestockStandardDiagnosis, False, False)
            baseDataSet.Tables(ASCampaign_DB.TableDiagnosis).DefaultView.Sort = "intOrder"
            Me.DiseasesGrid.DataSource = baseDataSet.Tables(ASCampaign_DB.TableDiagnosis).DefaultView
            Me.SessionsGrid.DataSource = baseDataSet.Tables(ASCampaign_DB.TableSessions).DefaultView
        End Sub

#Region "DiseasesActions"
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim r As DataRow = DiseasesView.GetFocusedDataRow()
            If Not r Is Nothing AndAlso CanDelete(r) AndAlso WinUtils.ConfirmDelete Then
                r.Delete()
            End If

        End Sub

        Private Function CanDelete(ByVal row As DataRow) As Boolean
            If ASCampaignDbService.CanDeleteDiagnosis(CLng(row("idfsDiagnosis"))) Then
                Return True
            Else
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantDeleteCampaignDisease", "Couldn't delete disease. There are monitoring sessions associated with this campaign that contain this disease."))
                Return False
            End If
        End Function

        Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
            Dim rowHandle As Integer = DiseasesView.FocusedRowHandle
            If DiseasesView.RowCount < 2 OrElse rowHandle < 0 OrElse rowHandle > DiseasesView.RowCount - 2 Then
                Return
            End If
            Dim row As DataRow = DiseasesView.GetDataRow(rowHandle)
            Dim nextRow As DataRow = DiseasesView.GetDataRow(rowHandle + 1)
            swapOrder(row, nextRow)
        End Sub

        Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
            Dim rowHandle As Integer = DiseasesView.FocusedRowHandle
            If DiseasesView.RowCount < 2 Or rowHandle <= 0 Then
                Return
            End If
            Dim row As DataRow = DiseasesView.GetDataRow(rowHandle)
            Dim prevRow As DataRow = DiseasesView.GetDataRow(rowHandle - 1)
            swapOrder(row, prevRow)
        End Sub

        Private Sub swapOrder(ByVal row1 As DataRow, ByVal row2 As DataRow)
            If row1 Is Nothing OrElse row2 Is Nothing Then Return
            Dim order As Object = row1("intOrder")
            row1("intOrder") = row2("intOrder")
            row2("intorder") = order
            row1.EndEdit()
            row2.EndEdit()
        End Sub

        Private Sub DiseasesView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DiseasesView.InitNewRow
            Dim row As DataRow = DiseasesView.GetDataRow(e.RowHandle)
            row("idfCampaignToDiagnosis") = BaseDbService.NewIntID()
        End Sub

        Private Sub DiseasesView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DiseasesView.ShowingEditor
            If DiseasesView.FocusedColumn Is colSpecies OrElse DiseasesView.FocusedColumn Is colPlannedQty Then
                Dim row As DataRow = DiseasesView.GetFocusedDataRow
                e.Cancel = row Is Nothing OrElse Utils.IsEmpty(row("idfsDiagnosis"))
            End If

        End Sub

        Private Sub DiseasesView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DiseasesView.ValidateRow
            Dim row As DataRowView = CType(e.Row, DataRowView)
            Dim filter As String
            If (row("idfsDiagnosis") Is DBNull.Value) Then
                e.Valid = False
                e.ErrorText = String.Format(BvMessages.Get("ErrMandatoryFieldRequired"), colDiagnosis.Caption)
                Return
            ElseIf row("idfsSpeciesType") Is DBNull.Value Then
                filter = String.Format("idfCampaign={0} and idfsDiagnosis={1} and idfCampaignToDiagnosis<>{2} and idfsSpeciesType is null ", row("idfCampaign"), row("idfsDiagnosis"), row("idfCampaignToDiagnosis").ToString)

            Else
                filter = String.Format("idfCampaign={0} and idfsDiagnosis={1} and idfsSpeciesType = {2} and idfCampaignToDiagnosis<>{3}", row("idfCampaign"), row("idfsDiagnosis"), row("idfsSpeciesType"), row("idfCampaignToDiagnosis").ToString)

            End If

            If baseDataSet.Tables(ASCampaign_DB.TableDiagnosis).Select(filter).Length > 0 Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("errNotUniqueDisease", "There cannot be more than one record for the same diagnosis and species.")
            End If
        End Sub
#End Region

        Private Sub cbCampaignStatus_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbCampaignStatus.EditValueChanging
            If (m_State And BusinessObjectState.NewObject) <> 0 Then
                btnNewSession.Enabled = False
                btnSelectSession.Enabled = False
                btnRemoveSession.Enabled = False
                btnViewDetails.Enabled = False
            Else
                If e.NewValue.Equals(CLng(ASCampaignStatus.[New])) Then
                    If ASCampaignDbService.HasMonitoringSession() Then
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantMakeCampaignNew", "Active Surveillance Campaign Status can't be set to [New]. There are monitoring sessions assosiated with this campaign."))
                        e.Cancel = True
                    End If
                    btnNewSession.Enabled = False
                    btnSelectSession.Enabled = False
                Else
                    SetViewRemoveButtons()
                    If e.NewValue.Equals(CLng(ASCampaignStatus.Closed)) Then
                        If Not ASCampaignDbService.CanCloseCampaign() Then
                            ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantCloseCampaign", "Active Surveillance Campaign can't be closed. Close all monitoring sessions related with this campaign before campaign closing."))
                            e.Cancel = True
                        End If
                        btnNewSession.Enabled = False
                        btnSelectSession.Enabled = False
                        btnRemoveSession.Enabled = False
                    Else
                        btnNewSession.Enabled = True
                        btnSelectSession.Enabled = True
                    End If
                End If
            End If
        End Sub


        Private Sub Status_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If Not e.Value.Equals(CLng(ASCampaignStatus.Closed)) Then
                If [ReadOnly] Then
                    [ReadOnly] = False
                End If
            End If
            EnableButtonsForCampaignState()
        End Sub
        Private Sub EnableButtonsForCampaignState()
            If (baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)("idfsCampaignStatus").Equals(CLng(ASCampaignStatus.Closed))) Then
                btnNewSession.Enabled = False
                btnRemoveSession.Enabled = False
                btnSelectSession.Enabled = False
            Else
                If baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)("idfsCampaignStatus").Equals(CLng(ASCampaignStatus.[New])) Then
                    btnNewSession.Enabled = False
                    btnSelectSession.Enabled = False
                Else
                    btnNewSession.Enabled = True
                    btnSelectSession.Enabled = True
                End If
                SetViewRemoveButtons()
            End If

        End Sub
        Private Sub SetClosedCaseReadOnly()
            If (baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)("idfsCampaignStatus").Equals(CLng(ASCampaignStatus.Closed))) Then
                If (Not Me.ReadOnly) Then
                    Me.ReadOnly = True
                End If
            End If
            EnableButtonsForCampaignState()
        End Sub

        Private Sub ASCampaignDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
            If Not sender Is Me Then
                Return
            End If
            SetClosedCaseReadOnly()
        End Sub

        Public Overrides Function ValidateData() As Boolean
            If Not MyBase.ValidateData() Then
                Return False
            End If
            Dim campaignRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)
            'Validate if compaign data is compatible with all notdeleted sessions
            For Each sessionRow As DataRow In baseDataSet.Tables(ASCampaign_DB.TableSessions).Rows
                If sessionRow.RowState <> DataRowState.Deleted Then
                    'Dates
                    If Not ValidateSessionDates(campaignRow("datCampaignDateStart"), campaignRow("datCampaignDateEnd"), sessionRow("datStartDate"), sessionRow("datEndDate")) Then Return False

                    'Diseases
                    If Not ValidateSessionDiagnosis(baseDataSet.Tables(ASCampaign_DB.TableDiagnosis), sessionRow("idfMonitoringSession")) Then Return False
                End If
            Next

            Return True
        End Function

#Region "SessionsActions"
        Private Sub btnNewSession_Click(sender As System.Object, e As System.EventArgs) Handles btnNewSession.Click
            Dim campaignRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)
            If campaignRow Is Nothing Then
                Return
            End If
            Dim campaignID As Object = campaignRow("idfCampaign")
            If Utils.IsEmpty(campaignID) Then
                Return
            End If
            If (State And BusinessObjectState.NewObject) > 0 Then
                Post(PostType.IntermediatePosting)
            End If
            Dim startUpParams As New Dictionary(Of String, Object)
            startUpParams("idfCampaign") = campaignID
            Dim f As New AsSessionDetail
            If BaseFormManager.ShowModal(f, FindForm(), Nothing, Nothing, startUpParams) Then
                ASCampaignDbService.RefreshSessionInfo(baseDataSet)
                SetViewRemoveButtons()
            End If

        End Sub
        Private Sub btnSelectSession_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectSession.Click
            'campaign not saved yet
            Dim campaignRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)
            Dim campaignID As Object = campaignRow("idfCampaign")
            If Utils.IsEmpty(campaignID) Then
                Return
            End If

            SelectSession()
        End Sub

        Private Sub btnRemoveSession_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveSession.Click
            Dim r As DataRow = SessionsView.GetFocusedDataRow()
            If Not r Is Nothing AndAlso WinUtils.ConfirmMessage(BvMessages.Get("msgRemoveSessionLinkPrompt"), BvMessages.Get("Delete Record")) Then
                r.Delete()
                SetViewRemoveButtons()
            End If
        End Sub

        Private Sub btnViewDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnViewDetails.Click
            EditSession()
        End Sub

        Private Sub SessionsGrid_DoubleClick(sender As System.Object, e As System.EventArgs) Handles SessionsGrid.DoubleClick
            EditSession()
        End Sub

        Private Sub EditSession()
            Dim sessionRow As DataRow = SessionsView.GetFocusedDataRow()
            If sessionRow Is Nothing Then
                Return
            End If
            Dim sessionID As Object = sessionRow("idfMonitoringSession")
            If Utils.IsEmpty(sessionID) Then
                Return
            End If
            Dim startUpParams As New Dictionary(Of String, Object)
            startUpParams("CampaignReadOnly") = True
            Dim f As New AsSessionDetail
            If BaseFormManager.ShowModal(f, FindForm(), sessionID, Nothing, startUpParams) Then
                ASCampaignDbService.RefreshSessionInfo(baseDataSet)
            End If
        End Sub

        Private Sub SelectSession()
            Dim f As New AsSessionListPanel
            f.DisableDelayedDisposing = True
            SelectSession(f)
            f.DisableDelayedDisposing = False
        End Sub
        Private Sub SelectSession(frm As AsSessionListPanel)
            Dim session As IObject = BaseFormManager.ShowForSelection(frm, FindForm)
            If Not session Is Nothing Then
                If ValidateSession(session) Then
                    AddSessionToTable(session)
                Else
                    'session is not validated - open select session once more
                    SelectSession(frm)
                End If
            End If

        End Sub


        Private Sub AddSessionToTable(session As IObject)
            Dim campaignRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)
            Dim campaignID As Object = campaignRow("idfCampaign")

            Dim sessionRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableSessions).NewRow()
            For Each col As DataColumn In baseDataSet.Tables(ASCampaign_DB.TableSessions).Columns
                If col.ColumnName = "idfCampaign" Then
                    sessionRow(col.ColumnName) = campaignID
                Else
                    If Not session.GetValue(col.ColumnName) Is Nothing Then
                        sessionRow(col.ColumnName) = session.GetValue(col.ColumnName)
                    End If
                End If
            Next
            baseDataSet.Tables(ASCampaign_DB.TableSessions).Rows.Add(sessionRow)
            SetViewRemoveButtons()
        End Sub

        Private Function ValidateSession(session As IObject) As Boolean
            Dim campaignRow As DataRow = baseDataSet.Tables(ASCampaign_DB.TableCampaign).Rows(0)
            Dim campaignID As Object = campaignRow("idfCampaign")
            Dim strcampaignID As Object = campaignRow("strCampaignID")

            'Link to the same campaign
            If Not Utils.IsEmpty(baseDataSet.Tables(ASCampaign_DB.TableSessions).Rows.Find(session.GetValue("idfMonitoringSession"))) Then
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignSessionLinkDublicate"))
                Return False
            End If
            If Not Utils.IsEmpty(session.GetValue("strCampaignID")) Then
                'Link to the same campaign
                If CStr(session.GetValue("strCampaignID")) = CStr(strcampaignID) Then ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignSessionLinkDublicate"))
                'Link to another campaign
                If CStr(session.GetValue("strCampaignID")) <> CStr(strcampaignID) Then ErrorForm.ShowMessageDirect(EidssMessages.Get("msgASSessionAlreadyBelongsToCampaign"))
                Return False
            End If

            'Dates
            If Not ValidateSessionDates(campaignRow("datCampaignDateStart"), campaignRow("datCampaignDateEnd"), session.GetValue("datStartDate"), session.GetValue("datEndDate")) Then Return False

            'Diseases
            If Not ValidateSessionDiagnosis(baseDataSet.Tables(ASCampaign_DB.TableDiagnosis), session.GetValue("idfMonitoringSession")) Then Return False

            Return True
        End Function

        Private Function ValidateSessionDates(campaignStartDate As Object, campaignEndDate As Object, sessStartDate As Object, sessEndDate As Object) As Boolean
            If Not WinUtils.ValidateDateInRange(sessStartDate, campaignStartDate, campaignEndDate) OrElse _
                Not WinUtils.ValidateDateInRange(sessEndDate, campaignStartDate, campaignEndDate) Then
                ErrorForm.ShowMessageDirect(String.Format(EidssMessages.Get("msgCampaignSessionDatesConflict"), Utils.SafeDate(sessStartDate), Utils.SafeDate(sessEndDate), Utils.SafeDate(campaignStartDate), Utils.SafeDate(campaignEndDate)))
                Return False
            End If
            Return True
        End Function

        Private Function ValidateSessionDiagnosis(campaignDiagnosis As DataTable, monitoringSession As Object) As Boolean
            If (ASSession_DB.ValidateDiagnosis(CLng(monitoringSession), campaignDiagnosis)) = False Then
                ErrorForm.ShowMessageDirect(EidssMessages.Get("errNotMatchSessionDiagnosis"))
                Return False
            End If
            Return True
        End Function
#End Region

        Private Sub AsCampaignDetail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            SetClosedCaseReadOnly()
        End Sub

        Private Sub SetViewRemoveButtons()
            If (SessionsView.SelectedRowsCount > 0) Then
                btnViewDetails.Enabled = True
                btnRemoveSession.Enabled = True
            Else
                btnViewDetails.Enabled = False
                btnRemoveSession.Enabled = False
            End If
        End Sub
        Protected Overrides Sub RegisterValidators()
            Validators.Clear()
            Dim validator As DateChainValidator
            validator = New DateChainValidator(Me, dtCampaignStartDate, ASCampaign_DB.TableCampaign, "datCampaignDateStart", lbCampaignStartDate.Text)
            validator.AddChild(New DateChainValidator(Me, dtCampaignEndDate, ASCampaign_DB.TableCampaign, "datCampaignDateEnd", lbCampaignEndDate.Text))
            validator.RegisterValidator(Me, True)
        End Sub

    End Class
End Namespace
