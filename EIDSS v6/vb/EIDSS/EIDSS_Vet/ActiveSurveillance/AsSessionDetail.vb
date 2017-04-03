Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports eidss.model.Core
Imports DevExpress.XtraEditors.Controls
Imports bv.common
Imports DevExpress.XtraTreeList.Nodes
Imports System.Collections.Generic
Imports eidss.model.Resources
Imports eidss.model.Schema
Imports eidss.winclient.Vet
Imports bv.model.Model.Core
Imports eidss.model.Enums
Imports eidss.winclient.ActiveSurveillance
Imports bv.common.Configuration
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports bv.common.Resources
Imports bv.winclient.Localization
Imports System.Linq
Imports bv.common.Enums
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.common.win.Validators

Namespace ActiveSurveillance

    Public Class AsSessionDetail
        Inherits BaseDetailForm
        ReadOnly m_AsSessionDbService As ASSession_DB
        ReadOnly m_CanCreateCase As Boolean
        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            If WinUtils.IsComponentInDesignMode(Me) Then
                Return
            End If
            InitCustomMandatoryFields()

            ' Add any initialization after the InitializeComponent() call.
            m_AsSessionDbService = New ASSession_DB
            DbService = m_AsSessionDbService
            AuditObject = New AuditObject(EIDSSAuditObject.daoMonitoringSession, AuditTable.tlbMonitoringSession)
            PermissionObject = EIDSSPermissionObject.MonitoringSession
            RegisterChildObject(TableViewPanel, RelatedPostOrder.PostLast)
            RegisterChildObject(SamplesPanel, RelatedPostOrder.PostLast)
            RegisterChildObject(TestsPanel, RelatedPostOrder.PostLast)
            RegisterChildObject(SummaryPanel, RelatedPostOrder.PostLast)
            'TestsPanel.colFarmID.Visible = True
            m_CanCreateCase = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase))
            TestsPanel.ShowAsSessionColums()
            m_RelatedLists = New String() {"AsSessionListItem", "FarmListItem"}
        End Sub

        Private Sub InitCustomMandatoryFields()
            MandatoryFieldHelper.SetCustomMandatoryField(dtStartDate, CustomMandatoryField.ASSession_StartDate)
            MandatoryFieldHelper.SetCustomMandatoryField(dtEndDate, CustomMandatoryField.ASSession_EndDate)
            MandatoryFieldHelper.SetCustomMandatoryField(cbRayon, CustomMandatoryField.ASSession_Rayon)
        End Sub


#Region "Main form interface"

        Public Shared Sub Register(ByVal parentControl As Windows.Forms.Control)
            Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewASSession", 250)
            ma.ShowInToolbar = False
            ma.SmallIconIndex = MenuIconsSmall.ASSession
            ma.Name = "btnNewASSession"
            ma.Group = CInt(MenuGroup.CreateSession)
            ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.MonitoringSession)
            'Toolbar menu
            ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewASSession", 100136)
            ma.ShowInToolbar = True
            ma.ShowInMenu = False
            ma.BigIconIndex = MenuIcons.ASSession
            ma.Name = "btnNewASSession1"
            ma.Group = CInt(MenuGroup.ToolbarCreate)
            ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.MonitoringSession)
        End Sub

        Public Shared Sub ShowMe()
            BaseFormManager.ShowNormal(New AsSessionDetail, Nothing)
        End Sub
#End Region
#Region "Binding"
        Private Sub SetFarmPermissions()
            'For Each btn As EditorButton In txtFarmCode.Buttons
            '    If (btn.Kind = ButtonPredefines.Ellipsis) Then
            '        btn.Visible = EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AccessToFarmData))
            '    ElseIf (btn.Kind = ButtonPredefines.Glyph) Then
            '        btn.Visible = EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData))
            '    End If
            'Next
            btnNewFarm.Visible = EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToFarmData))
            btnSelect.Visible = EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData))
            'btnEditFarm.Visible = EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AccessToFarmData))
            ArrangeButtons(btnSelect.Parent, btnSelect.Top, "")
        End Sub
        Protected Overrides Sub DefineBinding()
            Core.LookupBinder.BindTextEdit(cbCampaignID, baseDataSet, ASSession_DB.TableSession + ".strCampaignID")

            Core.LookupBinder.BindTextEdit(txtCampaignName, baseDataSet, ASSession_DB.TableSession + ".strCampaignName")
            Core.LookupBinder.BindBaseLookup(cbCampaignType, baseDataSet, ASSession_DB.TableSession + ".idfsCampaignType", db.BaseReferenceType.rftCampaignType)
            cbCampaignType.Properties.Buttons.Clear()
            Core.LookupBinder.BindTextEdit(txtSessionID, baseDataSet, ASSession_DB.TableSession + ".strMonitoringSessionID")

            Core.LookupBinder.BindBaseLookup(cbSessionStatus, baseDataSet, ASSession_DB.TableSession + ".idfsMonitoringSessionStatus", db.BaseReferenceType.rftMonitoringSessionStatus, False, False)
            If AsSessionRow("idfsMonitoringSessionStatus").Equals(CLng(ASSessionStatus.Closed)) Then
                If Not [ReadOnly] Then
                    [ReadOnly] = True
                End If
            End If
            eventManager.AttachDataHandler(ASSession_DB.TableSession + ".idfsMonitoringSessionStatus", AddressOf Status_Changed)

            Core.LookupBinder.BindSiteLookup(txtSite, baseDataSet, ASSession_DB.TableSession + ".idfsSite")
            Core.LookupBinder.BindTextEdit(dtEnteredDate, baseDataSet, ASSession_DB.TableSession + ".datEnteredDate")
            Core.LookupBinder.BindPersonLookup(txtEnteredBy, baseDataSet, ASSession_DB.TableSession + ".idfPersonEnteredBy")
            Core.LookupBinder.BindDateEdit(dtEndDate, baseDataSet, ASSession_DB.TableSession + ".datEndDate")
            Core.LookupBinder.BindDateEdit(dtStartDate, baseDataSet, ASSession_DB.TableSession + ".datStartDate")

            DiseasesGrid.DataSource = baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView
            Try
                RemoveHandler baseDataSet.Tables(ASSession_DB.TableDiagnosis).RowChanged, AddressOf DiseaseChanged
                RemoveHandler baseDataSet.Tables(ASSession_DB.TableDiagnosis).RowDeleted, AddressOf DiseaseChanged
            Finally
                AddHandler baseDataSet.Tables(ASSession_DB.TableDiagnosis).RowChanged, AddressOf DiseaseChanged
                AddHandler baseDataSet.Tables(ASSession_DB.TableDiagnosis).RowDeleted, AddressOf DiseaseChanged
            End Try
            eventManager.AttachDataHandler(ASSession_DB.TableDiagnosis + ".idfsDiagnosis", AddressOf DiagnosisChanged)
            eventManager.AttachDataHandler(ASSession_DB.TableDiagnosis + ".idfsSpeciesType", AddressOf DiseaseSpeciesTypeChanged)


            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.LivestockStandardDiagnosis, False, False)
            Core.LookupBinder.BindBaseRepositoryLookup(cbSpeciesType, db.BaseReferenceType.rftSpeciesList, HACode.Livestock, AddressOf Core.LookupBinder.AddSpecies)
            Core.LookupBinder.AddClearButton(cbSpeciesType, True)
            Core.LookupBinder.RemoveDefaultFilterHandlers(cbSpeciesType)

            baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView.Sort = "intOrder"

            FarmsGrid.DataSource = baseDataSet.Tables(ASSession_DB.TableFarms).DefaultView
            Core.LookupBinder.BindBaseRepositoryLookup(cbOwnershipStructure, db.BaseReferenceType.rftOwnershipType, False)

            Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, ASSession_DB.TableSession + ".idfsCountry", False)
            Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, ASSession_DB.TableSession + ".idfsRegion")
            Core.LookupBinder.FilterRegion(cbRegion, baseDataSet.Tables(ASSession_DB.TableSession + "").Rows(0)("idfsCountry"))

            Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, ASSession_DB.TableSession + ".idfsRayon")
            Core.LookupBinder.FilterRayon(cbRayon, baseDataSet.Tables(ASSession_DB.TableSession + "").Rows(0)("idfsRegion"))

            Core.LookupBinder.BindSettlementLookup(cbSettlement, baseDataSet, ASSession_DB.TableSession + ".idfsSettlement")
            Core.LookupBinder.FilterSettlement(cbSettlement, baseDataSet.Tables(ASSession_DB.TableSession + "").Rows(0)("idfsRayon"))

            eventManager.AttachDataHandler(ASSession_DB.TableSession + ".idfsCountry", AddressOf Country_Changed)
            eventManager.AttachDataHandler(ASSession_DB.TableSession + ".idfsRegion", AddressOf Region_Changed)
            eventManager.AttachDataHandler(ASSession_DB.TableSession + ".idfsRayon", AddressOf Rayon_Changed)
            CasesGrid.DataSource = New DataView(baseDataSet.Tables(ASSession_DB.TableCases))
            BindFarmTree()
            If FarmsGridView.RowCount > 0 Then
                FarmsGridView.FocusedRowHandle = 0
                FarmsGridView_FocusedRowChanged(FarmsGridView, New DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0))
            End If

            eventManager.AttachDataHandler(ASSession_DB.TableAnimals + ".idfAnimal", AddressOf Animal_Changed)
            eventManager.AttachDataHandler(ASSession_DB.TableAnimals + ".idfSpecies", AddressOf Animal_Changed)
            eventManager.AttachDataHandler(ASSession_DB.TableAnimals + ".strAnimalCode", AddressOf Animal_Changed)

            BindAnimals()
            BindActions()
            SamplesPanel.CasePartyList = New DataView(baseDataSet.Tables(ASSession_DB.TableAnimals))
            InitCampaignDiagnosisFilter()
            SetTableViewMode(BaseSettings.AsSessionTableView)
            TableViewPanel.SpeciesList = SpeciesList
            SummaryPanel.SpeciesList = SpeciesList
            SetFarmPermissions()
        End Sub

        Private Sub Animal_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If (Not chkTableView.Checked) Then
                SamplesPanel.UpdatePartyInfo(e.Row("idfAnimal"))
            End If
        End Sub

        Private Sub DiseaseSpeciesTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            SetFarmTreeFilter(CurrentFarmID)
        End Sub

        Private Sub DiagnosisChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            AddSummaryDiagnosis(CLng(e.Row("idfsDiagnosis")))
            UpdateDiseaseList()
        End Sub


        Private ReadOnly Property FarmTreeDataView As DataView
            Get
                If FarmTree.DataSource Is Nothing Then
                    Return Nothing
                End If
                Return CType(FarmTree.DataSource, DataView)
            End Get
        End Property

        Private Sub SetFarmTreeFilter(ByVal farmID As Long)
            If Not FarmTree.DataSource Is Nothing Then

                Dim speciesFilter As String = GetSpeciesFilter(True, "strName", True)
                If Not Utils.IsEmpty(speciesFilter) Then
                    FarmTreeDataView.RowFilter = String.Format("idfFarm = {2} and (idfsPartyType <> {0} or (idfsPartyType = {0} and ({1} or strName is null)))", CLng(PartyType.Species), speciesFilter, farmID)
                Else
                    FarmTreeDataView.RowFilter = String.Format("idfFarm = {0}", farmID)
                End If
                FarmTree.ExpandAll()
            End If
        End Sub
        Private Sub BindFarmTree()
            FarmTree.DataSource = New DataView(baseDataSet.Tables(ASSession_DB.TableFarmsTree))
            FarmTree.KeyFieldName = "idfParty"
            FarmTree.ParentFieldName = "idfParentParty"
            SetFarmTreeFilter(-1)

            Core.LookupBinder.BindBaseRepositoryLookup(cbSpiecesList, db.BaseReferenceType.rftSpeciesList, _
                                                       HACode.Livestock, AddressOf Core.LookupBinder.AddSpecies)
            Core.LookupBinder.RemoveDefaultFilterHandlers(cbSpiecesList)
            Dim speciesLookupTable As DataTable = CType(cbSpiecesList.DataSource, DataView).Table
            If Not speciesLookupTable.Columns.Contains("strReference") Then
                speciesLookupTable.Columns.Add(New DataColumn("strReference", GetType(String), "Convert(idfsReference, 'System.String')"))
            End If
            cbSpiecesList.ValueMember = "strReference"
            FarmTree.ExpandAll()
            eventManager.AttachDataHandler(ASSession_DB.TableFarmsTree + ".intTotalAnimalQty", AddressOf Total_Changed)
            eventManager.AttachDataHandler(ASSession_DB.TableFarmsTree + ".strName", AddressOf HerdSpecies_Changed)
            If [ReadOnly] Then
                FarmTree.OptionsBehavior.Editable = False
            End If

        End Sub
        Private Sub BindActions()
            ActionGrid.DataSource = baseDataSet.Tables(ASSession_DB.TableActions)
            Core.LookupBinder.BindPersonRepositoryLookup(cbEnteredBy)
            Core.LookupBinder.BindBaseRepositoryLookup(cbActionType, db.BaseReferenceType.rftMonitoringSessionActionType, True)
            Dim logStatusView As DataView = LookupCache.Get(db.BaseReferenceType.rftMonitoringSessionActionStatus)
            rgStatus.Items.Clear()
            For Each row As DataRowView In logStatusView
                rgStatus.Items.Add(New RadioGroupItem(row("idfsReference"), row("Name").ToString))
            Next
            UpdateActionsButtons()
        End Sub


        Private Sub HerdSpecies_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If e.Row.RowState = DataRowState.Detached OrElse e.Row.RowState = DataRowState.Deleted Then
                Return
            End If
            Dim dtype As PartyType = CType(e.Row("idfsPartyType"), PartyType)
            If dtype = PartyType.Species Then
                For Each row As DataRowView In CType(AnimalsGrid.DataSource, DataView)
                    row("idfsSpeciesType") = CLng(e.Row("strName"))
                    If Not row("idfsAnimalAge") Is DBNull.Value AndAlso _
                       (CType(cbAnimalAge.DataSource, DataView)).Table.Select( _
                                                                              String.Format("idfsSpeciesType = {0} and idfsReference = {1}", row("idfsSpeciesType"), row("idfsAnimalAge")) _
                                                                              ).Length = 0 Then
                        row("idfsAnimalAge") = DBNull.Value
                        row.EndEdit()
                    End If
                Next
                UpdateSpeciesList(e.Row)
            End If
        End Sub

        Private Sub cbSpiecesList_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbSpiecesList.EditValueChanging
            Dim rview As DataRowView = ObjectRowView
            If CLng(PartyType.Species).Equals(rview("idfsPartyType")) Then
                If Utils.IsEmpty(e.NewValue) Then
                    e.Cancel = True
                ElseIf m_AsSessionDbService.ValidateNewSpecies(rview.Row, Utils.Str(e.NewValue)) = False Then
                    e.Cancel = True
                    MessageForm.Show(String.Format(EidssMessages.Get("strSpeciesExist", "Such species exists in the {0} already. Select other species."), HerdCaption))
                ElseIf CanChangeSpecies(rview.Row) = False Then
                    e.Cancel = True
                    MessageForm.Show(String.Format(EidssMessages.Get("msgCantChangeASLivestockSpecies", "Can't change species. There are the animals with accessioned samples that belongs to this species.")))
                Else
                    If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = "-1" Then
                        e.NewValue = DBNull.Value
                    End If
                    rview("strName") = e.NewValue
                    rview.EndEdit()
                End If
            Else
                If TypeOf (e.NewValue) Is String AndAlso CType(e.NewValue, String) = "-1" Then
                    e.NewValue = DBNull.Value
                End If
            End If

        End Sub

        Private Sub UpdateSpeciesList(ByVal speciesRow As DataRow)
            Dim r As DataRow = SpeciesList.Table.Rows.Find(speciesRow("idfParty"))
            If Not r Is Nothing Then
                r("idfsReference") = CLng(speciesRow("strName"))
                r("name") = LookupCache.GetLookupValue(r("idfsReference"), BaseReferenceType.rftSpeciesList, "name")
                r.EndEdit()
            Else
                Dim row As DataRowView = SpeciesList.AddNew
                row("idfSpecies") = speciesRow("idfParty")
                row("idfFarm") = speciesRow("idfFarm")
                row("idfsReference") = CLng(speciesRow("strName"))
                row("name") = LookupCache.GetLookupValue(row("idfsReference"), BaseReferenceType.rftSpeciesList, "name")
                row.EndEdit()
            End If

        End Sub
        Private ReadOnly Property HerdCaption() As String
            Get
                'Select Case m_CaseKind
                '    Case CaseType.Avian : Return EidssMessages.Get("strFlock")
                '    Case CaseType.Livestock : Return EidssMessages.Get("strHerd")
                'End Select
                Return EidssMessages.Get("strHerd")
            End Get
        End Property

        Private Function CanChangeSpecies(ByVal speciesRow As DataRow) As Boolean
            If Utils.Str(speciesRow("strName")) = "" Then
                Return True
            End If
            Dim summary As DataRow() = SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(String.Format("idfSpecies={0}", speciesRow("idfParty")))
            If summary.Length > 0 Then
                Return False
            End If
            Dim samples As DataRow() = SamplesPanel.SamplesDataView.Table.Select("Used=1")
            If samples.Any(Function(samplesRow) baseDataSet.Tables(ASSession_DB.TableAnimals).Select(String.Format("idfSpecies = {0} and idfAnimal= {1}", speciesRow("idfParty"), samplesRow("idfParty"))).Length > 0) Then
                Return False
            End If
            If Not CaseSamples_Db.CheckAccessionForSpecies(CLng(speciesRow("idfParty"))) Then
                Return False
            End If
            Return True
        End Function


        Protected Sub BindAnimals()
            AnimalsGrid.DataSource = New DataView(baseDataSet.Tables(ASSession_DB.TableAnimals))
            Core.LookupBinder.BindAnimalAgeRepositoryLookup(cbAnimalAge, False)
            Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalGender, bv.common.db.BaseReferenceType.rftAnimalSex, HACode.Livestock, False)
            'Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalSpecies, BaseReferenceType.rftSpeciesList, False)
            'Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalStatus, BaseReferenceType.rftAnimalCondition, False)
            'BindSpeciesLookup()
            'BindHerdsLookup()
            'eventManager.AttachDataHandler(ASSession_DB.TableVetCaseAnimals + ".idfSpecies", AddressOf Species_Changed)
            'eventManager.AttachDataHandler(ASSession_DB.TableVetCaseAnimals + ".idfHerd", AddressOf Herd_Changed)

            If [ReadOnly] Then
                btnDeleteAnimal.Enabled = False
                btnNewAnimal.Enabled = False
                AnimalView.OptionsBehavior.Editable = False
            End If

        End Sub
        'I assume that HerdsList contains  DataView with fields idfParty and strName
        'HerdsList should be inititialized in the parent form
        'Right for now it is assumed that this is filtered view that is taken from the FarmTreePanel.baseDataset
        'Private Sub BindHerdsLookup()
        '    cbHerds.Columns.Clear()
        '    cbHerds.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        '        New DevExpress.XtraEditors.Controls.LookUpColumnInfo("strName", EidssMessages.Get("strHerd"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        '    )
        '    Dim dv As DataView = New DataView(baseDataSet.Tables(ASSession_DB.TableFarmsTree))
        '    dv.RowFilter = String.Format("idfsPartyType={0} and idfFarm = {1} ", CLng(PartyType.strHerd), CurrentFarmID)

        '    cbHerds.PopupWidth = 400
        '    cbHerds.DataSource = dv
        '    cbHerds.DisplayMember = "strName"
        '    cbHerds.ValueMember = "idfParty"
        '    cbHerds.NullText = ""
        '    Core.LookupBinder.AddLookupClosedHandler(cbHerds)
        'End Sub

        'Dim m_HerdsList As DataView

        ''I assume that SpeciesList contains  DataView with fields idfSpecies, idfHerd and Name
        ''HerdsList should be inititialized in the parent form
        ''Right for now it is assumed that this is filtered view that is taken from the FarmTreePanel.baseDataset
        'Private Sub BindSpeciesLookup()
        '    cbAnimalSpecies.Columns.Clear()
        '    cbAnimalSpecies.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        '        New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        '    )
        '    Dim dv As DataView = New DataView(baseDataSet.Tables(ASSession_DB.TableFarmsTree))
        '    dv.RowFilter = String.Format("idfsPartyType={0} and idfParentParty = {1} ", CLng(PartyType.Species), CurrentHerdID)
        '    cbAnimalSpecies.PopupWidth = 200
        '    cbAnimalSpecies.DataSource = SpeciesList
        '    cbAnimalSpecies.DisplayMember = "Name"
        '    cbAnimalSpecies.ValueMember = "idfSpecies"
        '    cbAnimalSpecies.NullText = ""
        '    Core.LookupBinder.AddLookupClosedHandler(cbAnimalSpecies)

        'End Sub

        Protected ReadOnly Property CurrentHerdID() As Long
            Get
                Dim row As DataRowView = ObjectRowView
                Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
                Select Case dtype
                    Case PartyType.Farm
                        Return 0
                    Case PartyType.Herd
                        Return CLng(row("idfParty"))
                    Case PartyType.Species
                        Return CLng(row("idfParentParty"))
                End Select
            End Get
        End Property

#End Region

#Region "Campaign"

        Private Sub cbCampaignID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbCampaignID.ButtonClick
            If CampaignReadonly Then Return

            Select Case e.Button.Kind
                Case DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                    AssociateWithCampaign()
                Case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
                    EditCampaign()
                Case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                    ClearCampaign()
            End Select

        End Sub

        Public Sub AssociateWithCampaign()
            Dim campaign As IObject = BaseFormManager.ShowForSelection(New AsCampaignListPanel, FindForm)
            If campaign Is Nothing Then
                Return
            End If
            Dim ds As DataSet = m_AsSessionDbService.PopulateCampaignData(campaign.GetValue("idfCampaign"))
            If ds Is Nothing Then
                Dim err As ErrorMessage = m_AsSessionDbService.LastError
                ErrorForm.ShowErrorDirect(err.Text, err.Exception)
                Return
            End If
            If CType(ds.Tables(0).Rows(0)("idfsCampaignStatus"), ASCampaignStatus) <> ASCampaignStatus.Open Then
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignIsNotOpen", "The status of selected campaign is not Open. The requested association can only be established with an Open Campaign. The campaign administrator must change the campaign status to Open for this association."))
                Return
            End If
            Dim campaignRow As DataRow = ds.Tables(0).Rows(0)
            If Not ValidateCampaignDates(campaignRow("datCampaignDateStart"), campaignRow("datCampaignDateEnd")) Then
                Return
            End If
            PopulateCampaignData(campaign.GetValue("idfCampaign"), ds, True)

        End Sub
        Private Sub EditCampaign()
            Dim sessionRow As DataRow = AsSessionRow
            Dim campaignID As Object = sessionRow("idfCampaign")
            If Utils.IsEmpty(campaignID) Then
                Return
            End If
            If BaseFormManager.ShowModal(New AsCampaignDetail, FindForm, campaignID, Nothing, Nothing) Then
                Dim ds As DataSet = m_AsSessionDbService.PopulateCampaignData(campaignID)
                If Not ds Is Nothing Then
                    PopulateCampaignData(campaignID, ds, False)
                End If
            End If
        End Sub

        Private Sub ClearCampaign()
            Dim sessionRow As DataRow = AsSessionRow
            Dim campaignID As Object = sessionRow("idfCampaign")
            If Utils.IsEmpty(campaignID) Then
                Return
            End If
            sessionRow("idfCampaign") = DBNull.Value
            sessionRow("strCampaignName") = DBNull.Value
            sessionRow("strCampaignID") = DBNull.Value
            sessionRow("idfsCampaignType") = DBNull.Value
            sessionRow.EndEdit()
            baseDataSet.Tables(ASSession_DB.TableCampaignDiagnosis).Clear()
            InitCampaignDiagnosisFilter()
            SetFarmTreeFilter(CurrentFarmID)
        End Sub
        Private m_CampaignDiagnosisFilter As String = ""
        Private Sub InitCampaignDiagnosisFilter()
            m_CampaignDiagnosisFilter = ""
            For Each row As DataRow In baseDataSet.Tables(ASSession_DB.TableCampaignDiagnosis).Rows
                If (m_CampaignDiagnosisFilter = "") Then
                    m_CampaignDiagnosisFilter = row("idfsDiagnosis").ToString()
                ElseIf Not m_CampaignDiagnosisFilter.Contains(row("idfsDiagnosis").ToString()) Then
                    m_CampaignDiagnosisFilter += String.Format(", {0}", row("idfsDiagnosis").ToString())
                End If
            Next
        End Sub
        Private Function HasDiagnosisSpecies(ByVal ds As DataSet, ByVal row As DataRow, Optional ByVal speciesTypeFieldName As String = "idfsSpeciesType") As Boolean
            If row.RowState = DataRowState.Deleted Then
                Return True
            End If
            Dim filter As String
            If row(speciesTypeFieldName) Is DBNull.Value Then
                filter = String.Format("idfsDiagnosis={0} and idfsSpeciesType is Null", row("idfsDiagnosis"))
            Else
                filter = String.Format("idfsDiagnosis={0} and idfsSpeciesType = {1}", row("idfsDiagnosis"), row(speciesTypeFieldName))
            End If
            Dim rows As DataRow() = ds.Tables(1).Select(filter)
            Return rows.Length > 0
        End Function
        Private Function GetDistinctValues(ByVal table As DataTable, ByVal fieldName As String) As DataTable
            Dim view As DataView = New DataView(table)
            Return view.ToTable(True, fieldName)
        End Function

        Private Function GetUsedSpeciesTypes() As DataTable
            Dim summarySpecies As DataTable = GetDistinctValues(SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummary), "idfsSpeciesType")
            Dim detailTable As DataTable
            If chkTableView.Checked Then
                detailTable = GetDistinctValues(TableViewPanel.baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView), "idfsSpeciesType")
            Else
                detailTable = GetDistinctValues(baseDataSet.Tables(ASSession_DB.TableAnimals), "idfsSpeciesType")
            End If
            detailTable.Merge(summarySpecies)
            Return detailTable
        End Function
        Private Sub PopulateCampaignData(ByVal campaignID As Object, ByVal ds As DataSet, ByVal checkDiagnosis As Boolean)
            Dim sessionRow As DataRow = AsSessionRow
            Dim row As DataRow
            Dim countNonDeletedRows As Integer = 0
            Dim populateCompanyDiagnosis As Boolean = False
            If checkDiagnosis Then
                'check that any existing animal/summary record belongs to species deifined in campaign
                If ds.Tables(1).Select("not idfsSpeciesType is null").Length > 0 Then
                    Using speciesTypes As DataTable = GetUsedSpeciesTypes()
                        For Each row In speciesTypes.Rows
                            If Not Utils.IsEmpty(row("idfsSpeciesType")) AndAlso _
                                ds.Tables(1).Select(String.Format("idfsSpeciesType = {0}", row("idfsSpeciesType"))).Length = 0 Then 'campaign doesn't contain speciesType
                                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignDoesntContainDiagnosis", "Can't associate current Monitoring Session with selected Campaign. Monitoring Session contains some diseases/species that are absent in selected Campaign. Please remove Monitoring diseases/species that are not included to campaign or select other campaign."))
                                Return
                            End If
                        Next
                    End Using
                End If
                'check that any diagnosis/species defined in session diagnosis list belongs to campaign
                'or that diagnosis/species can be deleted after restricting session diagnosis list
                For i As Integer = baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows.Count - 1 To 0 Step -1
                    row = baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows(i)
                    If row.RowState = DataRowState.Deleted Then
                        Continue For
                    End If
                    If Not HasDiagnosisSpecies(ds, row) AndAlso Not CanDeleteDisease(CLng(row("idfsDiagnosis")), False) AndAlso Not CanDeleteDiseaseSpecies(ds.Tables(1), row) Then
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignDoesntContainDiagnosis", "Can't associate current Monitoring Session with selected Campaign. Monitoring Session contains some diseases/species that are absent in selected Campaign. Please remove Monitoring diseases/species that are not included to campaign or select other campaign."))
                        Return
                    End If
                Next
                'now we checked that extra rows can be deleted session diagnosis list
                'We ask user about extra rows deleting and if he agreed - delete these rows
                For i As Integer = baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows.Count - 1 To 0 Step -1
                    row = baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows(i)
                    If row.RowState = DataRowState.Deleted Then
                        Continue For
                    End If
                    countNonDeletedRows = countNonDeletedRows + 1
                    If Not HasDiagnosisSpecies(ds, row) Then
                        If populateCompanyDiagnosis = False AndAlso MessageForm.Show(EidssMessages.Get("AsSession_WrongCampaignAssignment"), BvMessages.Get("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                            Return
                        Else
                            populateCompanyDiagnosis = True
                        End If
                        DeleteDieseaseRow(row, False)
                        'win.ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCampaignDoesntContainDiagnosis", "Can't associate current Monitoring Session with selected Campaign. Monitoring Session contains some diseases/species that are absent in selected Campaign. Please remove Monitoring diseases/species that are not included to campaign or select other campaign."))
                        'Return
                    End If
                Next
                baseDataSet.Tables(ASSession_DB.TableCampaignDiagnosis).Clear()
                baseDataSet.Tables(ASSession_DB.TableCampaignDiagnosis).Merge(ds.Tables(1))
                InitCampaignDiagnosisFilter()
                'If countNonDeletedRows = 0 Then
                For Each row In ds.Tables(1).Rows
                    Dim filter As String
                    If row("idfsSpeciesType") Is DBNull.Value Then
                        filter = String.Format("idfsDiagnosis={0} and idfsSpeciesType is Null", row("idfsDiagnosis"))
                    Else
                        filter = String.Format("idfsDiagnosis={0} and idfsSpeciesType = {1}", row("idfsDiagnosis"), row("idfsSpeciesType"))
                    End If
                    If baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select(filter).Length = 0 Then
                        Dim newRow As DataRow = baseDataSet.Tables(ASSession_DB.TableDiagnosis).NewRow
                        newRow("idfMonitoringSession") = GetKey()
                        newRow("idfsDiagnosis") = row("idfsDiagnosis")
                        newRow("idfsSpeciesType") = row("idfsSpeciesType")
                        baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows.Add(newRow)
                    End If
                Next

                'End If
            End If
            sessionRow("idfCampaign") = campaignID
            If (ds.Tables(0).Rows.Count > 0) Then
                row = ds.Tables(0).Rows(0)
                sessionRow("strCampaignName") = row("strCampaignName")
                sessionRow("strCampaignID") = row("strCampaignID")
                sessionRow("idfsCampaignType") = row("idfsCampaignType")
                sessionRow("datCampaignDateStart") = row("datCampaignDateStart")
                sessionRow("datCampaignDateEnd") = row("datCampaignDateEnd")
            End If
            sessionRow.EndEdit()
            DbDisposeHelper.DisposeDataset(ds)
            SetFarmTreeFilter(CurrentFarmID)

        End Sub


#End Region

#Region "Address group"


        Private Sub Country_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            If Not Loading Then AsSessionRow("idfsCountry") = e.Value
            DebugTimer.Start("Filling Regions")
            Dim currentCountryID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
            DebugTimer.Stop()
            Dim currentRegionID As Object = AsSessionRow("idfsRegion")
            If Not currentRegionID Is DBNull.Value AndAlso _
               CType(cbRegion.Properties.DataSource, DataView).Table.Select("idfsCountry = " + Utils.Str(currentCountryID) + " and idfsRegion = " + Utils.Str(currentRegionID)).Length = 0 Then
                AsSessionRow("idfsRegion") = DBNull.Value
                AsSessionRow.EndEdit()
                eventManager.Cascade(ASSession_DB.TableSession + ".idfsRegion")
            End If
            Core.LookupBinder.FilterRegion(cbRegion, currentCountryID)
        End Sub

        Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            AsSessionRow("idfsRegion") = e.Value
            DebugTimer.Start("Filling Rayons")
            Dim currentRegionID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
            DebugTimer.Stop()
            Dim currentRayonID As Object = AsSessionRow("idfsRayon")
            If Not currentRayonID Is DBNull.Value AndAlso _
               CType(cbRayon.Properties.DataSource, DataView).Table.Select("idfsRegion = " + Utils.Str(currentRegionID) + " and idfsRayon = " + Utils.Str(currentRayonID)).Length = 0 Then
                AsSessionRow("idfsRayon") = DBNull.Value
            End If
            AsSessionRow.EndEdit()
            eventManager.Cascade(ASSession_DB.TableSession + ".idfsRayon")
            Core.LookupBinder.FilterRayon(cbRayon, currentRegionID)
        End Sub

        Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            AsSessionRow("idfsRayon") = e.Value
            Dim currentRayonID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
            Dim currentSettlementID As Object = AsSessionRow("idfsSettlement")
            If Not currentSettlementID Is DBNull.Value AndAlso _
               CType(cbSettlement.Properties.DataSource, DataView).Table.Select("idfsRayon = " + Utils.Str(currentRayonID) + " and idfsSettlement = " + Utils.Str(currentSettlementID)).Length = 0 Then
                AsSessionRow("idfsSettlement") = DBNull.Value
                AsSessionRow.EndEdit()
            End If
            Core.LookupBinder.FilterSettlement(cbSettlement, currentRayonID)
        End Sub

#End Region

#Region "Diseases"
        Private Function CanDeleteDisease(ByVal idfsDiagnosis As Long, Optional ByVal showMessage As Boolean = True) As Boolean
            If SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format("idfsDiagnosis = {0} and blnChecked = 1", idfsDiagnosis), Nothing, DataViewRowState.CurrentRows).Length > 0 Then
                If showMessage Then
                    MessageForm.Show(EidssMessages.Get("CantDeleteASDiagnosis", "Can't delete this disease because it is used in some summary records"))
                End If
                Return False
            End If
            Return True
        End Function
        Private Sub DeleteSummaryDiagnosis(ByVal idfsDiagnosis As Long)
            For i As Integer = SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Rows.Count - 1 To 0 Step -1
                Dim row As DataRow = SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Rows(i)
                If row("idfsDiagnosis").Equals(idfsDiagnosis) Then
                    row.Delete()
                    row.AcceptChanges()
                End If
            Next
        End Sub
        Private Sub AddSummaryDiagnosis(ByVal idfsDiagnosis As Long)
            For Each row As DataRow In SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummary).Rows
                If row.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                If SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select( _
                    String.Format("idfsDiagnosis = {0} and idfMonitoringSessionSummary = {1}", idfsDiagnosis, row("idfMonitoringSessionSummary"))).Length = 0 Then
                    Dim newRow As DataRow = SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).NewRow
                    newRow("id") = String.Format("{0}.{1}", idfsDiagnosis, row("idfMonitoringSessionSummary"))
                    newRow("idfsDiagnosis") = idfsDiagnosis
                    newRow("name") = LookupCache.GetLookupValue(idfsDiagnosis, LookupTables.LivestockStandardDiagnosis, "name")

                    newRow("idfMonitoringSessionSummary") = row("idfMonitoringSessionSummary")
                    SummaryPanel.baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Rows.Add(newRow)
                    newRow.AcceptChanges()
                End If
            Next
        End Sub

        Private Sub DiseaseChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            If e.Action = DataRowAction.Add OrElse e.Action = DataRowAction.Change Then
                AddSummaryDiagnosis(CLng(e.Row("idfsDiagnosis")))
            End If
            UpdateDiseaseList()
        End Sub

        Private Sub DeleteDieseaseRow(ByVal r As DataRow, validateRow As Boolean)
            If Not r Is Nothing Then
                If validateRow Then
                    If Not (CanDeleteDisease(CLng(r("idfsDiagnosis"))) AndAlso CanDeleteDiseaseSpecies(r, True) AndAlso WinUtils.ConfirmDelete) Then
                        Return
                    End If
                End If
                DeleteSummaryDiagnosis(CLng(r("idfsDiagnosis")))
                r.Delete()
                UpdateDiseaseList()
            End If
        End Sub
        Private Sub btnDeleteDisease_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDeleteDisease.Click
            Dim r As DataRow = DiseasesView.GetFocusedDataRow()
            DeleteDieseaseRow(r, True)
        End Sub

        Private Function CanDeleteDiseaseSpecies(ByVal diseaseRow As DataRow, checkForDeletion As Boolean) As Boolean
            Dim speciesType As Object = diseaseRow("idfsSpeciesType")
            If Utils.IsEmpty(speciesType) Then
                Return True
            End If
            'diseases list contains this this species in other row
            If baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select(String.Format("idfsSpeciesType={0} and idfMonitoringSessionToDiagnosis<>{1}", speciesType, diseaseRow("idfMonitoringSessionToDiagnosis"))).Length > 0 Then
                Return True
            End If
            'we can enable row deleting if other diagnosis rows contains no species links
            If checkForDeletion AndAlso baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select(String.Format("not idfsSpeciesType is null and idfMonitoringSessionToDiagnosis<>{0}", diseaseRow("idfMonitoringSessionToDiagnosis"))).Length = 0 Then
                Return True
            End If
            If IsSpeciesTypeReferenced(CLng(speciesType)) Then
                If checkForDeletion Then
                    MessageForm.Show(EidssMessages.Get("msgCantDeleteDiagnosisSpecies", "Can't delete this record because animals list contains animals with such Species Type."))
                Else
                    MessageForm.Show(EidssMessages.Get("msgCantChangeDiagnosisSpecies", "Can't change Species Type  because animals list contains animals with such Species Type."))
                End If
                Return False
            End If

            Return True
        End Function
        Private Function CanDeleteDiseaseSpecies(ByVal campainDiseaseTable As DataTable, ByVal sessionDiseaseRow As DataRow) As Boolean
            Dim speciesType As Object = sessionDiseaseRow("idfsSpeciesType")
            If Utils.IsEmpty(speciesType) Then
                Return True
            End If
            'Campaign diagnosis list contains this specieType, so it will be added later and we can delete this session diagnosis row
            If campainDiseaseTable.Select(String.Format("idfsSpeciesType = {0}", speciesType)).Length > 0 Then
                Return True
            End If
            'Species type is references by some animal or summary record
            If IsSpeciesTypeReferenced(CLng(speciesType)) Then
                Return False
            End If
            Return True
        End Function
        Private Function AnimalsContainsSpeciesType(ByVal speciesType As Long) As Boolean
            Return baseDataSet.Tables(ASSession_DB.TableAnimals).Select(String.Format("idfsSpeciesType={0}", speciesType)).Length > 0
        End Function
        Private Function IsSpeciesTypeReferenced(ByVal speciesType As Long) As Boolean
            If chkTableView.Checked Then
                Return TableViewPanel.ContainsSpeciesType(CLng(speciesType)) OrElse SummaryPanel.ContainsSpeciesType(CLng(speciesType))
            Else
                Return AnimalsContainsSpeciesType(CLng(speciesType)) OrElse SummaryPanel.ContainsSpeciesType(CLng(speciesType))
            End If
        End Function
        Private Sub UpdateDiseaseList()
            Dim diseaseList As New List(Of Long)
            For Each row As DataRow In baseDataSet.Tables(ASSession_DB.TableDiagnosis).Rows
                If (row.RowState = DataRowState.Deleted) Then
                    Continue For
                End If

                If diseaseList.IndexOf(CLng(row("idfsDiagnosis"))) < 0 Then
                    diseaseList.Add(CLng(row("idfsDiagnosis")))
                End If
            Next
            Dim diagnosisList() As Long = diseaseList.ToArray()
            TestsPanel.DiagnosisList = diagnosisList
            SamplesPanel.DiagnosisList = diagnosisList
            TableViewPanel.FilteredSamplesDataset = SamplesPanel.baseDataSet
            SetFarmTreeFilter(CurrentFarmID)

        End Sub

        Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDown.Click
            Dim rowHandle As Integer = DiseasesView.FocusedRowHandle
            If DiseasesView.RowCount < 2 OrElse rowHandle < 0 OrElse rowHandle > DiseasesView.RowCount - 2 Then
                Return
            End If
            Dim row As DataRow = DiseasesView.GetDataRow(rowHandle)
            Dim nextRow As DataRow = DiseasesView.GetDataRow(rowHandle + 1)
            swapOrder(row, nextRow)
        End Sub

        Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUp.Click
            Dim rowHandle As Integer = DiseasesView.FocusedRowHandle
            If DiseasesView.RowCount < 2 OrElse rowHandle <= 0 Then
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

        Private Sub DiseasesView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DiseasesView.ShowingEditor
            If DiseasesView.FocusedColumn Is colSpecies Then
                Dim row As DataRow = DiseasesView.GetFocusedDataRow
                e.Cancel = row Is Nothing OrElse Utils.IsEmpty(row("idfsDiagnosis"))
            End If

        End Sub


        Private Sub DiseasesView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DiseasesView.ValidateRow
            Dim row As DataRowView = CType(e.Row, DataRowView)
            If (Utils.IsEmpty(row("idfsDiagnosis"))) Then
                e.Valid = False
                e.ErrorText = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving"), colDiagnosis.Caption)
                Return
            End If


            Dim filter As String = String.Format("idfMonitoringSession={0} and idfsDiagnosis={1}", row("idfMonitoringSession"), row("idfsDiagnosis"))
            If (Not Utils.IsEmpty(row("idfMonitoringSessionToDiagnosis"))) Then
                filter += String.Format(" and idfMonitoringSessionToDiagnosis<>{0}", row("idfMonitoringSessionToDiagnosis").ToString)
            End If
            If (Not Utils.IsEmpty(row("idfsSpeciesType"))) Then
                filter += String.Format(" and idfsSpeciesType={0}", row("idfsSpeciesType"))
            End If
            If baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select(filter).Length > 0 Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("errNotUniqueDisease", "There cannot be more than one record for the same diagnosis and species.")
            End If
        End Sub
        Private Sub cbDiagnosis_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbDiagnosis.EditValueChanging
            Try
                Dim res As Boolean = m_AsSessionDbService.IsCampaignContainsDiagnosis(e.NewValue, AsSessionRow("idfCampaign"))
                If res = False Then
                    e.Cancel = True
                    Dim row As DataRow = DiseasesView.GetFocusedDataRow()
                    Dim diagnosis As String = LookupCache.GetLookupValue(e.NewValue, LookupTables.VetStandardDiagnosis, "name")
                    Dim species As String = String.Empty
                    If Not row Is Nothing AndAlso Not row("idfsSpecies") Is DBNull.Value Then
                        species = String.Format(": {0}", LookupCache.GetLookupValue(row("idfsSpecies"), BaseReferenceType.rftSpeciesList, "name"))
                    End If
                    If DiseasesView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                        ErrorForm.ShowMessageDirect(String.Format(EidssMessages.Get("msgCantAddSessionDiagnosis"), diagnosis, species))
                    Else
                        ErrorForm.ShowMessageDirect(String.Format(EidssMessages.Get("msgCantSetSessionDiagnosis"), diagnosis, species))
                    End If
                End If
                If Not Utils.IsEmpty(e.OldValue) AndAlso Not CanDeleteDisease(CLng(e.OldValue)) Then
                    e.Cancel = True
                End If
            Catch ex As Exception
                e.Cancel = True
                ErrorForm.ShowError(StandardError.StoredProcedureError, ex)
            End Try
        End Sub
        Private Sub cbDiagnosis_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryPopUp
            If Not Utils.IsEmpty(m_CampaignDiagnosisFilter) Then
                CType(cbDiagnosis.DataSource, DataView).RowFilter = String.Format("idfsDiagnosis in ({0})", m_CampaignDiagnosisFilter)
            End If
        End Sub

        Private Sub cbDiagnosis_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryCloseUp
            CType(cbDiagnosis.DataSource, DataView).RowFilter = ""
        End Sub
        Public Function GetSpeciesFilter(ByVal allSpecies As Boolean, Optional ByVal filterFieldName As String = "idfsReference", Optional ByVal useQuotes As Boolean = False, Optional useIntRowStatus As Boolean = False) As String
            Dim row As DataRow = DiseasesView.GetFocusedDataRow()
            Dim species As String = ""
            If Not row Is Nothing Then
                Dim diagnosisRows As DataRow()
                If allSpecies Then
                    diagnosisRows = baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select("")
                Else
                    diagnosisRows = baseDataSet.Tables(ASSession_DB.TableCampaignDiagnosis).Select(String.Format("idfsDiagnosis={0}", row("idfsDiagnosis")))
                End If
                Dim listedSpecies As New List(Of String)
                For Each cr As DataRow In diagnosisRows
                    If (cr("idfsSpeciesType") Is DBNull.Value) Then
                        Continue For
                    End If
                    Dim speciesType As String = cr("idfsSpeciesType").ToString
                    If species = "" Then
                        If useQuotes Then
                            species = String.Format("'{0}'", speciesType)
                        Else
                            species = speciesType
                        End If
                        listedSpecies.Add(speciesType)
                    ElseIf Not listedSpecies.Contains(speciesType) Then
                        If useQuotes Then
                            species += String.Format(", '{0}'", speciesType)
                        Else
                            species += String.Format(", {0}", speciesType)
                        End If
                        listedSpecies.Add(speciesType)
                    End If
                Next
            End If
            If (useIntRowStatus) Then
                If species <> "" Then
                    Return String.Format("intRowStatus = 0 and {0} in ({1})", filterFieldName, species)
                End If
                Return "intRowStatus = 0"
            Else
                If species <> "" Then
                    Return String.Format("{0} in ({1})", filterFieldName, species)
                End If
                Return ""
            End If
        End Function

        Private Sub cbSpeciesType_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbSpeciesType.EditValueChanging
            Dim diseaseRow As DataRow = DiseasesView.GetFocusedDataRow()
            If Not Utils.IsEmpty(e.OldValue) AndAlso Not CanDeleteDiseaseSpecies(diseaseRow, False) Then
                e.Cancel = True
            End If
        End Sub
        Private Sub cbSpeciesType_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpeciesType.QueryPopUp
            CType(cbSpeciesType.DataSource, DataView).RowFilter = GetSpeciesFilter(False, , , True)
        End Sub
        Private Sub cbSpeciesType_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpeciesType.QueryCloseUp
            CType(cbSpeciesType.DataSource, DataView).RowFilter = ""
        End Sub

#End Region


#Region "Farm"
        Private Sub cbSpiecesList_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpiecesList.QueryCloseUp
            CType(cbSpiecesList.DataSource, DataView).RowFilter = ""

        End Sub

        Private Sub cbSpiecesList_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpiecesList.QueryPopUp
            CType(cbSpiecesList.DataSource, DataView).RowFilter = GetSpeciesFilter(True, , , True)
        End Sub
        Private Function FindFarmByCode(ByVal recordId As Object, ByVal farmCode As String) As Long
            If chkTableView.Checked Then
                Return TableViewPanel.FindFarmByCode(recordId, farmCode)
            End If
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("strFarmCode = '{0}'", farmCode)
            Else
                filter = String.Format("strFarmCode = '{0}' and idfFarm <> {1}", farmCode, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(ASSession_DB.TableFarms).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Private Function FindFarmById(ByVal recordId As Object, ByVal farmId As Long) As Long
            If chkTableView.Checked Then
                Return TableViewPanel.FindFarmById(recordId, farmId)
            Else
                Dim filter As String
                filter = String.Format("idfFarm = {0}", farmId)
                Dim rows As DataRow() = baseDataSet.Tables(ASSession_DB.TableFarms).Select(filter)
                If rows.Length > 0 Then
                    Return CLng(rows(0)("idfFarm"))
                End If
            End If
            Return 0
        End Function
        Public Function FindFarm(ByVal recordId As Object, ByVal farmCode As String) As Long
            Dim id As Long = FindFarmByCode(recordId, farmCode)
            If id <= 0 Then
                id = SummaryPanel.FindFarmByCode(recordId, farmCode)
            End If
            Return id
        End Function
        Public Function FindFarm(ByVal recordId As Object, ByVal farmId As Long) As Long
            Dim id As Long = FindFarmById(recordId, farmId)
            If id <= 0 Then
                id = SummaryPanel.FindFarmById(recordId, farmId)
            End If
            Return id
        End Function
        'this method is called in the next cases:
        '1. Selection new root farm from the farms list
        '2. New Farm creation
        Private Sub PopulateFarmTreeData(ByVal dt As DataTable, ByVal farmID As Object, ByVal isNewFarmCopy As Boolean)

            If Not dt Is Nothing Then
                Dim acceptChanges As Boolean = False

                If dt.Rows.Count > 0 AndAlso Not isNewFarmCopy Then
                    acceptChanges = True
                End If
                'baseDataSet.Tables(ASSession_DB.TableFarmsTree).Clear()
                For Each sourceRow As DataRow In dt.Rows
                    Dim targetFarmRow As DataRow = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows.Find(sourceRow("idfParty"))
                    If targetFarmRow Is Nothing Then
                        targetFarmRow = baseDataSet.Tables(ASSession_DB.TableFarmsTree).NewRow
                    End If
                    For Each col As DataColumn In dt.Columns
                        If baseDataSet.Tables(ASSession_DB.TableFarmsTree).Columns.Contains(col.ColumnName) Then
                            targetFarmRow(col.ColumnName) = sourceRow(col)
                        End If
                    Next
                    targetFarmRow("idfMonitoringSession") = GetKey()
                    targetFarmRow("idfFarm") = farmID
                    If targetFarmRow.RowState = DataRowState.Detached Then
                        baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows.Add(targetFarmRow)
                    End If
                    If acceptChanges Then
                        targetFarmRow.AcceptChanges()
                    End If
                Next
            End If
        End Sub
        Public Function CreateStartupParameters() As Dictionary(Of String, Object)
            Dim params As New Dictionary(Of String, Object)
            params("AsSession") = "1"
            If Not AsSessionRow("idfsCountry") Is DBNull.Value Then
                params("idfsCountry") = AsSessionRow("idfsCountry")
            End If
            If Not AsSessionRow("idfsRegion") Is DBNull.Value Then
                params("idfsRegion") = AsSessionRow("idfsRegion")
            End If
            If Not AsSessionRow("idfsRayon") Is DBNull.Value Then
                params("idfsRayon") = AsSessionRow("idfsRayon")
            End If
            If Not AsSessionRow("idfsSettlement") Is DBNull.Value Then
                params("idfsSettlement") = AsSessionRow("idfsSettlement")
            End If
            If params.Count > 0 Then
                Return params
            End If
            Return Nothing
        End Function
        Private Function AddASFarm(ByVal sourceFarm As FarmListItem, ByVal newRecordId As Object) As DataRow
            Dim newRow As DataRow = baseDataSet.Tables(ASSession_DB.TableFarms).NewRow
            If Not Utils.IsEmpty(newRecordId) AndAlso CLng(newRecordId) > 0 Then
                newRow("idfFarm") = newRecordId
            Else
                newRow("idfFarm") = BaseDbService.NewIntID
            End If
            newRow("idfRootFarm") = sourceFarm.idfFarm
            newRow("strFarmCode") = Utils.ToDbValue(sourceFarm.strFarmCode)
            newRow("strNationalName") = Utils.ToDbValue(sourceFarm.strNationalName)
            newRow("strOwnerName") = Utils.Join(" ", New Object() {sourceFarm.strLastName, sourceFarm.strFirstName, sourceFarm.strSecondName})
            newRow("idfsOwnershipStructure") = Utils.ToDbValue(sourceFarm.idfsOwnershipStructure)
            newRow("idfsLivestockProductionType") = Utils.ToDbValue(sourceFarm.idfsLivestockProductionType)
            newRow("idfMonitoringSession") = GetKey()
            newRow("blnNewFarm") = True
            baseDataSet.Tables(ASSession_DB.TableFarms).Rows.Add(newRow)
            Return newRow
        End Function

        <CLSCompliant(False)> _
        Public Function CreateFarmSelectionForm() As IBaseListPanel
            Dim farmList As New FarmListPanel
            Dim filter As New FilterParams
            If Not Utils.IsEmpty(AsSessionRow("idfsRegion")) Then
                filter.Add("idfsRegion", "=", AsSessionRow("idfsRegion"))
                If Not Utils.IsEmpty(AsSessionRow("idfsRayon")) Then
                    filter.Add("idfsRayon", "=", AsSessionRow("idfsRayon"))
                End If
            End If
            farmList.InitialSearchFilter = filter
            Return farmList
        End Function

        Private ReadOnly Property AsSessionRow As DataRow
            Get
                Return baseDataSet.Tables(ASSession_DB.TableSession).Rows(0)
            End Get
        End Property
        <CLSCompliant(False)> _
        Public Function ValidateAddress(farm As FarmListItem) As Boolean
            If Not AsSessionRow("idfsSettlement") Is DBNull.Value AndAlso Not AsSessionRow("idfsSettlement").Equals(farm.idfsSettlement) Then
                Return False
            End If
            If Not AsSessionRow("idfsRayon") Is DBNull.Value AndAlso Not AsSessionRow("idfsRayon").Equals(farm.idfsRayon) Then
                Return False
            End If
            If Not AsSessionRow("idfsRegion") Is DBNull.Value AndAlso Not AsSessionRow("idfsRegion").Equals(farm.idfsRegion) Then
                Return False
            End If
            If Not AsSessionRow("idfsCountry") Is DBNull.Value AndAlso Not AsSessionRow("idfsCountry").Equals(farm.idfsCountry) Then
                Return False
            End If
            Return True
        End Function


        Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSelect.Click
SelectFarm:
            Dim farmList As IBaseListPanel = CreateFarmSelectionForm()
            Dim farms As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(farmList, FindForm, CreateStartupParameters, 1000, 600)
            If Not farms Is Nothing AndAlso farms.Count > 0 Then
                For Each farm As FarmListItem In farms
                    If baseDataSet.Tables(ASSession_DB.TableFarms).Select(String.Format("idfRootFarm = {0}", farm.idfFarm)).Length > 0 Then
                        Continue For
                    Else
                        If (ValidateAddress(farm) = False) Then
                            If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgAddressIsOutOfBoundaries"))) Then
                                GoTo SelectFarm
                            Else
                                Exit For
                            End If

                        End If
                    End If
                Next
                For Each farm As FarmListItem In farms
                    If baseDataSet.Tables(ASSession_DB.TableFarms).Select(String.Format("idfRootFarm = {0}", farm.idfFarm)).Length > 0 Then
                        Continue For
                    Else
                        Dim id As Object = FindFarm(Nothing, farm.strFarmCode)
                        ' Add row to table
                        Dim newRow As DataRow = AddASFarm(farm, id)
                        Using dt As DataTable = m_AsSessionDbService.PopulateFarmTreeData(farm.idfFarm, newRow("idfFarm"))
                            PopulateFarmTreeData(dt, newRow("idfFarm"), True)
                        End Using
                    End If

                Next
            End If
        End Sub

        Shared m_Enter As Boolean = False
        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewFarm.Click
            If Not m_Enter Then
                m_Enter = True
                Dim farmID As Object = Nothing
                Dim f As New FarmDetail
                f.IsRootFarm = False
                If BaseFormManager.ShowModal(f, FindForm, farmID, Nothing, CreateStartupParameters) Then

                    Using dt As DataTable = m_AsSessionDbService.PopulateFarmData(farmID)
                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                            Dim row As DataRow = dt.Rows(0)
                            Dim newRow As DataRow = m_AsSessionDbService.AddASFarm(row, baseDataSet)
                            newRow("blnNewFarm") = False
                            Using dt1 As DataTable = m_AsSessionDbService.PopulateFarmTreeData(row("idfFarm"), newRow("idfFarm"))
                                PopulateFarmTreeData(dt1, newRow("idfFarm"), False)
                            End Using
                        End If
                    End Using
                End If
                m_Enter = False
            End If
        End Sub

        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveFarm.Click
            Dim row As DataRow = FarmsGridView.GetDataRow(FarmsGridView.FocusedRowHandle)
            If Not row Is Nothing Then
                Dim farmID As Object = row("idfFarm")
                Dim r As DataRow = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows.Find(farmID)
                If CanDeleteFarm(r) = False Then
                    MessageForm.Show(EidssMessages.Get("msgCantDeleteASFarm", "Can't delete farm.  There are the animals with accessioned samples that belongs to this farm."))
                    Return
                End If
                If DeletePromptDialog() = DialogResult.Yes Then
                    If SummaryPanel.FindFarmById(Nothing, CLng(farmID)) <= 0 Then
                        If Not m_AsSessionDbService.FarmsToDelete.Contains(CLng(farmID)) Then
                            m_AsSessionDbService.FarmsToDelete.Add(CLng(farmID))
                        End If
                    End If
                    Dim farmTreeRows As DataRow() = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Select(String.Format("idfFarm = {0}", farmID))
                    For Each r In farmTreeRows
                        r.Delete()
                    Next
                    row.Delete()
                End If
            End If
        End Sub

        Private Sub btnEditFarm_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditFarm.Click
            EditFarm()
        End Sub

        Private Sub FarmsGrid_DoubleClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles FarmsGrid.DoubleClick
            EditFarm()
        End Sub

        Private Sub EditFarm()
            If LockHandler() Then
                Try
                    Dim farmRow As DataRow = CurrentFarmRow
                    If farmRow Is Nothing Then
                        Return
                    End If
                    Dim farmID As Object
                    'If CBool(farmRow("blnNewFarm")) = True Then
                    '    FarmID = farmRow("idfRootFarm")
                    'Else
                    farmID = farmRow("idfFarm")
                    If (m_AsSessionDbService.PostFarmTree(baseDataSet, farmID) = False) Then
                        'Dbg.Debug("can't post session farm tree: {0}", ASSessionDbService.LastError.DetailError)
                    End If

                    'End If
                    If BaseFormManager.ShowModal(New FarmDetail, FindForm, farmID, Nothing, CreateStartupParameters) Then
                        Using dt As DataTable = m_AsSessionDbService.PopulateFarmData(farmID)
                            m_AsSessionDbService.MergeFarmData(farmRow, dt)
                        End Using
                        Using dt As DataTable = m_AsSessionDbService.PopulateFarmTreeData(farmID, farmID)
                            PopulateFarmTreeData(dt, farmID, False)
                        End Using
                    End If
                Catch ex As Exception
                    Throw
                Finally
                    UnlockHandler()
                End Try

            End If

        End Sub

        Private Sub btnCreateCase_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCreateCase.Click
            Dim farmId As Long
            If chkTableView.Checked Then
                farmId = CLng(TableViewPanel.TableView.GetFocusedDataRow()("idfFarm"))
            Else
                farmId = CurrentFarmID
            End If
            If farmId > 0 Then
                If Post(PostType.FinalPosting) = False Then
                    Return
                End If
                Dim result As Integer
                Dim casesID As Long() = m_AsSessionDbService.CreateCase(farmId, result)
                If casesID Is Nothing Then

                End If
                If result = 1 Then
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("msgFarmDoesntExist", "Couldn't find the farm for which you want to create the case. Check that monitoring session is saved and farm is not deleted by other user during monitoring session editing."))
                End If
                If result = 3 Then
                    ErrorForm.ShowMessageDirect(EidssMessages.Get("msgFarmHasNoTestResults", "Couldn't create the case. There are no new positive tests related with this farm."))
                End If
                If Not casesID Is Nothing Then
                    If casesID.Length = 1 Then
                        Dim showCase As Boolean = True
                        If result = 2 AndAlso WinUtils.ConfirmMessage(EidssMessages.Get("msgASCaseIsCreatedAlready", "Case is created for this farm already. Open the existing case?"), EidssMessages.Get("msgASCaseIsCreatedAlreadyCaption", "Case Exists")) = False Then
                            showCase = False
                        End If
                        If showCase Then
                            Dim id As Object = casesID(0)
                            BaseFormManager.ShowNormal(New VetCaseLiveStockDetail, id)
                        End If
                    ElseIf casesID.Length > 1 Then
                        Dim caseListForm As Object = ClassLoader.LoadClass("VetCaseListPanel")
                        If caseListForm Is Nothing Then
                            Return
                        End If
                        Dim filter As New FilterParams
                        For Each caseID As Long In casesID
                            filter.Add("idfCase", "=", caseID, True)
                        Next

                        ReflectionHelper.SetProperty(caseListForm, "StaticFilter", filter)
                        ReflectionHelper.SetProperty(caseListForm, "SearchPanelVisible", False)
                        'caseListForm.DbService.ListFilterCondition = String.Format("idfCase in ({0})", Utils.Join(",", casesID))
                        Dim id As Object = Nothing
                        BaseFormManager.ShowModal_ReadOnly(CType(caseListForm, IApplicationForm), FindForm, id, Nothing, Nothing, 1000, 500)
                    End If
                    m_AsSessionDbService.RefreshCaseInfo(baseDataSet)
                    Return
                End If
                Dim err As ErrorMessage = m_AsSessionDbService.LastError
                If Not err Is Nothing Then
                    ErrorForm.ShowErrorDirect(err.Text, err.Exception)
                End If
            End If
        End Sub
        Private m_FarmNodeChaging As Boolean = False
        Private Sub FarmsGridView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles FarmsGridView.FocusedRowChanged
            Try
                If m_FarmNodeChaging Then
                    Return
                End If
                m_FarmNodeChaging = True
                If FarmTree.DataSource Is Nothing Then
                    Return
                End If
                If Not ValidateTreeNode(FarmTree.FocusedNode) Then ' OrElse Not SamplesPanel.ValidateData()
                    FarmsGridView.FocusedRowHandle = e.PrevFocusedRowHandle
                End If
                SetFarmTreeFilter(CurrentFarmID)
                FarmTree.ExpandAll()
            Finally
                m_FarmNodeChaging = False
            End Try

        End Sub

        Public ReadOnly Property CurrentFarmID() As Long
            Get
                If FarmsGridView.FocusedRowHandle >= 0 Then
                    Return CLng(FarmsGridView.GetDataRow(FarmsGridView.FocusedRowHandle)("idfFarm"))
                Else
                    Return 0
                End If
            End Get
        End Property
        Public ReadOnly Property CurrentFarmRow() As DataRow
            Get
                If FarmsGridView.FocusedRowHandle >= 0 Then
                    Return FarmsGridView.GetDataRow(FarmsGridView.FocusedRowHandle)
                Else
                    Return Nothing
                End If
            End Get
        End Property
#End Region


#Region "Farm Tree"
        Private Sub btnNewHerd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewHerd.Click

            If FarmTree.Nodes.Count > 0 Then
                BeginUpdate()
                FarmTree.FocusedNode = FarmTree.Nodes(0)
                EndUpdate()
                NewFarmObject()
            End If
        End Sub

        Private Sub btnNewSpecies_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewSpecies.Click
            If FarmTree.FocusedNode Is Nothing OrElse FarmTree.FocusedNode.ParentNode Is Nothing Then
                Return
            End If
            NewFarmObject()
        End Sub
        Private Sub NewFarmObject()
            If ValidateTreeNode(FarmTree.FocusedNode) = False Then
                Return
            End If
            BeginUpdate()
            Dim row As DataRowView = ObjectRowView
            Dim newRow As DataRow = Nothing
            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
            Select Case dtype
                Case PartyType.Farm
                    newRow = m_AsSessionDbService.AddHerd(row.Row)
                Case PartyType.Herd
                    newRow = m_AsSessionDbService.AddHerdSpieces(row.Row)
                    'm_ShowPopupImmediatly = True
                Case PartyType.Species
                    row = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode.ParentNode), DataRowView)
                    newRow = m_AsSessionDbService.AddHerdSpieces(row.Row)
                    'm_ShowPopupImmediatly = True
            End Select
            Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = FarmTree.FindNodeByKeyID(newRow("idfParty"))
            If Not node Is Nothing Then
                node.ParentNode.ExpandAll()
                FarmTree.FocusedNode = node
                FarmTree.FocusedColumn = FarmTree.Columns(0)

            End If
            EndUpdate()
            FarmTree.ShowEditor()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteTreeNode.Click
            If FarmTree.FocusedNode Is Nothing OrElse FarmTree.FocusedNode.Level = 0 Then
                Return
            End If
            Dim row As DataRowView = CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
            If CanDeleteRow(row.Row) = False Then

                Dim cantDeleteMessage As String = ""
                Dim Caption As String = ""
                Select Case dtype
                    Case PartyType.Farm
                        Return
                    Case PartyType.Herd
                        'If CaseKind = CaseType.Livestock Then
                        cantDeleteMessage = EidssMessages.Get("msgCantASDeleteHerd")
                        'Else
                        'CantDeleteMessage = EidssMessages.Get("msgCantDeletFlock", "Can't delete flock. Delete all registered samples/penside tests related with this flock before flock deletion.")
                        'End If
                        Caption = String.Format(EidssMessages.Get("msgDeleteHerdCaption", "Delete {0}"), EidssMessages.Get("strHerd"))
                    Case PartyType.Species
                        'If CaseKind = CaseType.Livestock Then
                        cantDeleteMessage = EidssMessages.Get("msgCantDeleteASLivestockSpecies")
                        'Else
                        'CantDeleteMessage = EidssMessages.Get("msgCantDeleteAvianSpecies", "Can't delete species. Delete all registered samples/penside tests related with this species before species deletion.")
                        'End If
                        Caption = EidssMessages.Get("msgDeleteSpeciesCaption", "Delete species")
                End Select
                MessageForm.Show(cantDeleteMessage, Caption, MessageBoxButtons.OK)
                Return
            Else
                If DeletePromptDialog() <> DialogResult.Yes Then
                    Return
                End If
                Select Case dtype
                    Case PartyType.Farm
                        Return
                    Case PartyType.Herd
                        DeleteHerdSpecies(row.Row)
                    Case PartyType.Species
                        DeleteSpeciesAnimals(row.Row)
                End Select
            End If
            BeginUpdate()
            FarmTree.DeleteNode(FarmTree.FocusedNode)
            EndUpdate()
            RecalcQty("intTotalAnimalQty", New DataFieldChangeEventArgs(Nothing, Nothing, Nothing, Nothing))

        End Sub
        Private Sub RecalcQty(ByVal fieldName As String, ByVal e As DataFieldChangeEventArgs)
            For Each row As DataRow In baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows
                If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                    Continue For
                End If
                If CType(row("idfsPartyType"), PartyType).Equals(PartyType.Herd) Then
                    row(fieldName) = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfParentParty={0}", row("idfParty")))
                    row.EndEdit()
                ElseIf CType(row("idfsPartyType"), PartyType).Equals(PartyType.Farm) Then
                    row(fieldName) = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfsPartyType={0} and idfFarm ={1}", CLng(PartyType.Species), row("idfParty")))
                    row.EndEdit()
                End If
            Next
            'Dim farmRow As DataRow = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows.Find(GetKey())
            'If Not farmRow Is Nothing Then
            '    farmRow(fieldName) = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Compute(String.Format("sum({0})", fieldName), String.Format("idfsPartyType={0}", CLng(PartyType.Species)))
            '    farmRow.EndEdit()
            'End If

        End Sub

        Private Sub Total_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            RecalcQty("intTotalAnimalQty", e)
        End Sub

        Private Function CanDeleteRow(ByVal row As DataRow) As Boolean
            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
            Select Case dtype
                Case PartyType.Farm
                    Return False
                Case PartyType.Herd
                    Return CanDeleteHerd(row)
                Case PartyType.Species
                    Return CanDeleteSpecies(row)
            End Select
            Return False
        End Function
        Private Function CanDeleteAnimal(ByVal row As DataRow) As Boolean
            If SamplesPanel.baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfParty={0} and Used = 1", row("idfAnimal"))).Length > 0 Then
                Return False
            End If
            For Each r As DataRow In SamplesPanel.baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfParty={0} and Used = 0", row("idfAnimal")))
                If r.RowState = DataRowState.Added OrElse r.RowState = DataRowState.Deleted _
                   OrElse r.RowState = DataRowState.Detached _
                   OrElse Utils.IsEmpty(r("idfMaterial")) Then
                    Continue For
                End If
                If CaseSamples_Db.CheckAccessIn(CLng(r("idfMaterial"))) = False Then
                    Return False
                End If
            Next
            Return True
        End Function

        Private Function CanDeleteSpecies(ByVal row As DataRow) As Boolean
            For Each r As DataRow In baseDataSet.Tables(ASSession_DB.TableAnimals).Select(String.Format("idfSpecies={0}", row("idfParty")))
                If CanDeleteAnimal(r) = False Then
                    Return False
                End If
            Next
            If Not CaseSamples_Db.CheckAccessionForSpecies(CLng(row("idfParty"))) Then
                Return False
            End If
            Return True
        End Function
        Private Function CanDeleteFarm(ByVal row As DataRow) As Boolean
            For Each r As DataRow In baseDataSet.Tables(ASSession_DB.TableFarmsTree).Select(String.Format("idfParentParty={0}", row("idfParty")))
                If CanDeleteHerd(r) = False Then
                    Return False
                End If
            Next
            Return True
        End Function
        Private Function CanDeleteHerd(ByVal row As DataRow) As Boolean
            For Each r As DataRow In baseDataSet.Tables(ASSession_DB.TableFarmsTree).Select(String.Format("idfParentParty={0}", row("idfParty")))
                If CanDeleteSpecies(r) = False Then
                    Return False
                End If
            Next
            Return True
        End Function

        Private Function DeleteAnimal(ByVal row As DataRow) As Boolean
            SamplesPanel.DeletePartySamples(row("idfAnimal"))
            row.Delete()
            Return True
        End Function

        Private Function DeleteSpeciesAnimals(ByVal row As DataRow) As Boolean
            Return baseDataSet.Tables(ASSession_DB.TableAnimals).Select(String.Format("idfSpecies={0}", row("idfParty"))).All(Function(r) DeleteAnimal(r) <> False)
        End Function
        Private Function DeleteHerdSpecies(ByVal row As DataRow) As Boolean
            For Each r As DataRow In baseDataSet.Tables(ASSession_DB.TableFarmsTree).Select(String.Format("idfParentParty={0}", row("idfParty")))
                If DeleteSpeciesAnimals(r) = False Then
                    Return False
                End If
            Next
            Return True
        End Function
        Private Function ValidateTreeNode(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode, ByRef ErrMsg As String) As Boolean
            If node Is Nothing OrElse Closing Then Return True
            If CType(FarmTree.GetDataRecordByNode(node), DataRowView) Is Nothing Then
                Return True
            End If
            Dim row As DataRow = CType(FarmTree.GetDataRecordByNode(node), DataRowView).Row
            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)

            If dtype = PartyType.Species Then
                If Utils.Str(node.GetValue(0)) = "" Then
                    ErrMsg = String.Format(EidssMessages.Get("ErrMandatoryFieldRequired"), EidssFields.Get("idfsSpeciesType"))
                    Return False
                End If
                Dim speciesType As Object = row("strName")
                If baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select("not idfsSpeciesType is null").Length > 0 AndAlso _
                    baseDataSet.Tables(ASSession_DB.TableDiagnosis).Select(String.Format("idfsSpeciesType = {0}", speciesType)).Length = 0 Then
                    ErrMsg = EidssMessages.Get("AsSession.DetailsTableView.SpeciesIsNotInTheList")
                    Return False
                End If
            End If
            Return True
        End Function

        Dim m_validating As Boolean = False
        Private Function ValidateTreeNode(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode) As Boolean
            If m_validating Then
                Return True
            End If
            Dim errMsg As String = Nothing
            m_validating = True
            Try
                If ValidateTreeNode(node, errMsg) = False Then
                    MessageForm.Show(errMsg)
                    If Not FarmTree.FocusedNode Is node Then
                        FarmTree.FocusedNode = node
                    End If
                    FarmTree.ShowEditor()
                    Return False
                End If
            Finally
                m_validating = False
            End Try
            Return True
        End Function

        Private ReadOnly Property ObjectRow() As DataRow
            Get
                If FarmTree.FocusedNode Is Nothing Then Return Nothing
                Return (CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView).Row)
            End Get
        End Property
        Private ReadOnly Property ObjectRowView() As DataRowView
            Get
                If FarmTree.FocusedNode Is Nothing Then Return Nothing
                Return CType(FarmTree.GetDataRecordByNode(FarmTree.FocusedNode), DataRowView)
            End Get
        End Property
        Private Sub FarmTree_CustomDrawNodeCell(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs) Handles FarmTree.CustomDrawNodeCell
            If e.Node.Level = 0 AndAlso Not (e.Column Is colName OrElse e.Column Is colTotalAnimalQty) Then
                e.CellText = ""
                e.Handled = True
            ElseIf (e.Node.Level = 1 AndAlso e.Column Is colNote) Then
                e.CellText = ""
                e.Handled = True
            End If
        End Sub
        Private Sub FarmTree_CustomNodeCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs) Handles FarmTree.CustomNodeCellEdit
            'If IsDesignMode() Then Return
            Dim row As Object = FarmTree.GetDataRecordByNode(e.Node)
            If row Is Nothing Then
                Return
            End If
            Dim dtype As PartyType = CType(CType(row, DataRowView).Row("idfsPartyType"), PartyType)
            Select Case dtype
                Case PartyType.Species
                    If e.Column.FieldName = "strName" Then
                        e.RepositoryItem = cbSpiecesList
                    Else
                        e.RepositoryItem = Nothing
                    End If
                Case Else
                    e.RepositoryItem = Nothing
            End Select
        End Sub
        Private m_FarmTreeNodeChanging As Boolean = False
        Private Sub FarmTree_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles FarmTree.FocusedNodeChanged
            Try
                If m_FarmTreeNodeChanging Then Return
                m_FarmTreeNodeChanging = True
                If m_DataLoaded AndAlso (ValidateTreeNode(e.OldNode) = False OrElse Not SamplesPanel.IsCurrentSpecimenRowValid()) Then
                    BeginUpdate()
                    FarmTree.FocusedNode = e.OldNode
                    EndUpdate()
                    Return
                End If
                If AnimalsGrid.DataSource Is Nothing Then
                    Return
                End If
                Dim filter As String = "idfSpecies = -1"
                If Not e.Node Is Nothing Then
                    Dim row As DataRow = CType(FarmTree.GetDataRecordByNode(e.Node), DataRowView).Row
                    Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
                    If dtype = PartyType.Species Then
                        filter = String.Format("idfSpecies = {0}", row("idfParty"))
                    End If
                End If
                CType(AnimalsGrid.DataSource, DataView).RowFilter = filter
                AnimalView_FocusedRowChanged(AnimalView, New DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(DevExpress.XtraGrid.GridControl.InvalidRowHandle, AnimalView.FocusedRowHandle))
            Finally
                m_FarmTreeNodeChanging = False
            End Try
        End Sub

        Private Sub FarmTree_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FarmTree.ShowingEditor
            If Closing Then Return
            'If IsDesignMode() Then Return
            If [ReadOnly] Then
                e.Cancel = True
                Return
            End If
            If Not Visible Then
                e.Cancel = True
                Return
            End If
            Dim row As DataRow = ObjectRow
            Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
            Dim col As DevExpress.XtraTreeList.Columns.TreeListColumn = FarmTree.FocusedColumn
            Select Case dtype
                Case PartyType.Farm
                    'If col.FieldName <> "intTotalAnimalQty" Then
                    e.Cancel = True
                    'End If
                Case PartyType.Herd
                    'If col.FieldName = "strName" _
                    '                                OrElse col.FieldName = "strAverageAge" _
                    '                                OrElse col.FieldName = "datStartOfSignsDate" Then 'OrElse col.FieldName = "intDeadAnimalQty"
                    e.Cancel = True
                    'End If
            End Select

        End Sub

#End Region

#Region "Animals"
        Private ReadOnly Property AnimalRow() As DataRow
            Get
                If AnimalView.FocusedRowHandle < 0 Then Return Nothing
                Return AnimalView.GetDataRow(AnimalView.FocusedRowHandle)
            End Get
        End Property


        'Private Sub Herd_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        '    If Not cbAnimalSpecies.DataSource Is Nothing Then
        '        If e.Value Is DBNull.Value Then
        '            e.Row("idfSpecies") = DBNull.Value
        '            e.Row.EndEdit()
        '            Return
        '        End If
        '        If (Not e.Row("idfSpecies") Is DBNull.Value) Then
        '            Dim rows As DataRow() = CType(cbAnimalSpecies.DataSource, DataView).Table.Select(String.Format("idfHerd = {0} and idfsReference={1}", e.Value, e.Row("idfsSpeciesType")))
        '            If rows.Length = 0 Then
        '                e.Row("idfSpecies") = DBNull.Value
        '            Else
        '                e.Row("idfSpecies") = rows(0)("idfSpecies")
        '            End If
        '            e.Row.EndEdit()
        '        End If
        '    End If
        'End Sub

        'Private Sub Species_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        '    If Not m_SpeciesList Is Nothing Then
        '        m_SpeciesList.Sort = "idfSpecies"
        '        Dim i As Integer = m_SpeciesList.Find(e.Value)
        '        If i >= 0 Then
        '            e.Row("idfsSpeciesType") = m_SpeciesList(i)("idfsReference")
        '            If Not e.Row("idfsAnimalAge") Is DBNull.Value AndAlso _
        '                (CType(cbAnimalAge.DataSource, DataView)).Table.Select( _
        '                String.Format("idfsSpeciesType = {0} and idfsReference = {1}", e.Row("idfsSpeciesType"), e.Row("idfsAnimalAge")) _
        '                ).Length = 0 Then
        '                e.Row("idfsAnimalAge") = DBNull.Value
        '            End If
        '        End If
        '    End If
        'End Sub
        Private m_FreezeEvents As Boolean = False
        Private Sub cmdNewAnimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewAnimal.Click
            m_FreezeEvents = True
            Try
                Dim speciesRow As DataRow = ObjectRow
                Dim dtype As PartyType = CType(speciesRow("idfsPartyType"), PartyType)
                If dtype <> PartyType.Species Then
                    Return
                End If
                Dim farmRows As DataRow() = baseDataSet.Tables(ASSession_DB.TableFarms).Select(String.Format("idfFarm = {0}", speciesRow("idfFarm")))
                Dim farmCode As Object = Nothing
                If (farmRows.Length > 0) Then
                    farmCode = Utils.Str(farmRows(0)("strFarmCode"))
                End If
                Dim row As DataRow = m_AsSessionDbService.AddAnimal(speciesRow, , , , farmCode)
                DxControlsHelper.SetRowHandleForDataRow(AnimalView, row, "idfAnimal")
            Finally
                m_FreezeEvents = False
            End Try
        End Sub

        Public Event AnimalStateChanged As DataRowChangeEventHandler
        Public Event OnDeleteAnimal As RowCollectionChangedHandler
        Private Sub cmdDeleteAnimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAnimal.Click
            If AnimalView.FocusedRowHandle < 0 Then Return
            Dim row As DataRow = AnimalView.GetDataRow(AnimalView.FocusedRowHandle)
            If row Is Nothing Then Return
            Dim args As New DataRowEventArgs(row)
            Dim AnimalID As Object = row("idfAnimal")
            If Not SamplesPanel.CanDeleteParty(AnimalID) Then
                ErrorForm.ShowMessageDirect(EidssMessages.Get("msgCantDeleteASAnimal", "This animal can't be deleted."))
                Return
            End If
            If MessageForm.Show(EidssMessages.Get("msgConfermCaseAnimalDelete", "The animal, all samples and tests related with this animal will be deleted. Delete animal?"), EidssMessages.Get("titleDeleteAnimal", "Delete Animal"), MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Return
            End If
            DeleteAnimal(row)
        End Sub
        Private m_AnimalrowChanging As Boolean = False
        Private Sub AnimalView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AnimalView.FocusedRowChanged
            Try
                If m_AnimalrowChanging Then
                    Return
                End If
                m_AnimalrowChanging = True
                Dim party As Object = Nothing
                If m_DataLoaded AndAlso Not SamplesPanel.IsCurrentSpecimenRowValid() Then
                    AnimalView.FocusedRowHandle = e.PrevFocusedRowHandle
                    Return
                End If
                If AnimalView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                    party = AnimalView.GetDataRow(AnimalView.FocusedRowHandle)("idfAnimal")
                End If
                If Not (SamplesPanel.SamplesDataView Is Nothing) Then
                    SamplesPanel.SamplesDataView.RowFilter = "idfParty=" + Utils.Str(party, "-1")
                End If
                If Not (SamplesPanel.CasePartyList Is Nothing) Then
                    CType(SamplesPanel.CasePartyList, DataView).RowFilter = CType(AnimalsGrid.DataSource, DataView).RowFilter
                End If

                SamplesPanel.DefaultPartyID = party

            Finally
                m_AnimalrowChanging = False

            End Try
        End Sub

#End Region
#Region "Actions"
        Private Sub cmdNewAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim row As DataRow = m_AsSessionDbService.AddActionRecord(baseDataSet)
            DxControlsHelper.SetRowHandleForDataRow(ActionView, row, "idfMonitoringSessionAction")
            ActionView.FocusedColumn = colActionType
            ActionGrid.Select()
            Application.DoEvents()
            ActionView.ShowEditor()

        End Sub
        Private Sub cmdDeleteAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAction.Click
            Dim Row As DataRow = ActionView.GetDataRow(ActionView.FocusedRowHandle)
            If Row Is Nothing Then Return
            If WinUtils.ConfirmDelete Then
                Row.Delete()
            End If
        End Sub

#End Region


        Private Sub Status_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If e.Value.Equals(CLng(ASSessionStatus.Open)) Then
                If [ReadOnly] Then
                    [ReadOnly] = False
                End If
            End If
        End Sub

        Private Sub SetClosedCaseReadOnly()
            If (AsSessionRow("idfsMonitoringSessionStatus").Equals(CLng(ASSessionStatus.Closed)) AndAlso _
                (Not [ReadOnly])) Then
                [ReadOnly] = True
            End If
        End Sub

        Protected m_CampaignReadonly As Boolean = False
        Public Property CampaignReadonly() As Boolean
            Get
                Return m_CampaignReadonly
            End Get
            Set(ByVal Value As Boolean)
                m_CampaignReadonly = Value
            End Set
        End Property

        Private Sub AsSessionDetail_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterLoadData
            If chkTableView.Checked Then
                TestsPanel.SamplesView = TableViewPanel.SamplesList
            Else
                TestsPanel.SamplesView = SamplesPanel.SamplesList
            End If
            UpdateDiseaseList()
            AddHandler SamplesPanel.OnDeleteSample, AddressOf OnSampleDelete

            ' setting StartUpParameters
            Dim params As Dictionary(Of String, Object) = StartUpParameters
            If (Not params Is Nothing) AndAlso (params.ContainsKey("CampaignReadOnly")) Then
                CampaignReadonly = CBool(params("CampaignReadOnly"))
                cbCampaignID.Enabled = Not CampaignReadonly
            End If
            If (Not params Is Nothing) AndAlso (params.ContainsKey("idfCampaign")) Then
                Dim campaignID As Object = CLng(params("idfCampaign"))

                Dim ds As DataSet = m_AsSessionDbService.PopulateCampaignData(campaignID)
                If ds Is Nothing Then
                    Return
                End If
                PopulateCampaignData(campaignID, ds, True)

                cbCampaignID.Enabled = False
            End If
        End Sub
        Public Function CanDeleteSample(ByVal sampleID As Object) As Boolean
            Return TestsPanel.CanDeleteSample(sampleID)
        End Function
        Public Sub OnSampleDelete(ByVal sender As Object, ByVal e As DataRowEventArgs)
            Dim sampleID As Object = e.Row("idfMaterial")
            e.Cancel = Not CanDeleteSample(sampleID)
        End Sub
        Private Sub ASSessionDetail_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
            If Not sender Is Me Then
                Return
            End If
            SetClosedCaseReadOnly()
            For Each row As DataRow In baseDataSet.Tables(ASSession_DB.TableFarms).Rows
                row("blnNewFarm") = False
                row.AcceptChanges()
            Next
        End Sub

        Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
            btnCreateCase.Enabled = Not [ReadOnly] AndAlso m_CanCreateCase AndAlso ((chkTableView.Checked AndAlso TableViewPanel.TableView.FocusedRowHandle >= 0) _
                                                            OrElse (Not chkTableView.Checked AndAlso FarmsGridView.FocusedRowHandle >= 0)) _
                                                    AndAlso tpDetailedInfo.PageVisible AndAlso tpFarms.PageVisible
            btnRemoveFarm.Enabled = Not [ReadOnly] AndAlso FarmsGridView.FocusedRowHandle >= 0
            btnEditFarm.Enabled = Not [ReadOnly] AndAlso FarmsGridView.FocusedRowHandle >= 0
            btnDeleteTreeNode.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level > 0
            btnNewHerd.Enabled = Not [ReadOnly] AndAlso FarmTree.Nodes.Count > 0
            btnNewSpecies.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level > 0
            btnNewAnimal.Enabled = Not [ReadOnly] AndAlso Not FarmTree.FocusedNode Is Nothing AndAlso FarmTree.FocusedNode.Level = 2 AndAlso Not ObjectRow Is Nothing AndAlso Not Utils.IsEmpty(ObjectRow("strName"))
            btnDeleteAnimal.Enabled = Not [ReadOnly] AndAlso AnimalView.FocusedRowHandle >= 0
            btnDeleteDisease.Enabled = Not [ReadOnly] AndAlso DiseasesView.FocusedRowHandle >= 0

        End Sub

        Private Sub btnCopyAnimal_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCopyAnimal.Click
            If Not AnimalRow Is Nothing Then
                m_AsSessionDbService.CreateAnimalCopy(AnimalRow, SamplesPanel.SamplesDataView, CInt(txtAnimalCopyCount.EditValue))

            End If
        End Sub



        Private Sub miSessionReport_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles miSessionReport.Click
            If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
                Return
            End If
            If Post(PostType.FinalPosting) Then
                Dim id As Long = CType(GetKey(), Long)
                EidssSiteContext.ReportFactory.VetActiveSurveillanceSampleCollected(id)
            End If
        End Sub

        Public Overrides Function ValidateData() As Boolean
            SamplesPanel.InvalidSample = Nothing
            If Not MyBase.ValidateData Then
                If Not SamplesPanel.InvalidSample Is Nothing Then
                    ShowInvalidSample()
                End If
                Return False
            End If

            'Dates
            Dim row As DataRow = AsSessionRow

            If Not Utils.IsEmpty(row("idfCampaign")) AndAlso Not ValidateCampaignDates(row("datCampaignDateStart"), row("datCampaignDateEnd")) Then
                Return False
            End If

            'Diseases
            If (ASSession_DB.ValidateDiagnosis(baseDataSet.Tables(ASSession_DB.TableDiagnosis), row("idfCampaign"))) = False Then
                DiseasesGrid.Focus()
                ErrorForm.ShowMessageDirect(EidssMessages.Get("errNotMatchSessionDiagnosis"))
                Return False
            End If
            If FarmTree.Nodes.Count > 0 Then
                For Each herdNode As TreeListNode In FarmTree.Nodes.Item(0).Nodes
                    For Each speciesNode As TreeListNode In herdNode.Nodes
                        If Not ValidateTreeNode(speciesNode) Then
                            tcASCampaign.SelectedTabPage = tpFarms
                            Return False
                        End If
                    Next
                Next
            End If

            For Each row In baseDataSet.Tables(ASSession_DB.TableActions).Rows
                If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                    Continue For
                End If
                If Not IsRowValid(ActionView.GetRowHandle(row.Table.Rows.IndexOf(row)), True) Then
                    Return False
                End If
                'If (row("idfsMonitoringSessionActionType") Is DBNull.Value) Then
                '    tcASCampaign.SelectedTabPage = tpActions
                '    ErrorForm.ShowMessageDirect(String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving"), colActionType.Caption))
                '    Return False
                'End If
            Next
            Return True
        End Function
        Private Function ValidateCampaignDates(campaignStartDate As Object, campaignEndDate As Object) As Boolean
            Dim sessionRow As DataRow = AsSessionRow
            If Not WinUtils.ValidateDateInRange(sessionRow("datStartDate"), campaignStartDate, campaignEndDate) OrElse _
                Not WinUtils.ValidateDateInRange(sessionRow("datEndDate"), campaignStartDate, campaignEndDate) Then

                ErrorForm.ShowMessageDirect(String.Format(EidssMessages.Get("msgCampaignSessionDatesConflict"), Utils.SafeDate(sessionRow("datStartDate")), Utils.SafeDate(sessionRow("datEndDate")), Utils.SafeDate(campaignStartDate), Utils.SafeDate(campaignEndDate)))
                Return False
            End If
            Return True
        End Function
        Private Sub ShowInvalidSample()
            Dim sample As DataRow = SamplesPanel.InvalidSample
            Dim animalId As Object = sample("idfParty")
            Dim animalRow As DataRow = baseDataSet.Tables(ASSession_DB.TableAnimals).Rows.Find(animalId)
            Dim speciesRow As DataRow = baseDataSet.Tables(ASSession_DB.TableFarmsTree).Rows.Find(animalRow("idfSpecies"))
            Dim farmRow As DataRow = baseDataSet.Tables(ASSession_DB.TableFarms).Rows.Find(speciesRow("idfFarm"))
            DxControlsHelper.SetRowHandleForDataRow(FarmsGridView, farmRow, "idfFarm")
            DxControlsHelper.SetRowHandleForDataRow(FarmTree, Nothing, speciesRow, "idfParty")
            DxControlsHelper.SetRowHandleForDataRow(AnimalView, animalRow, "idfAnimal")
            SamplesPanel.SupressRowValidation = True
            DxControlsHelper.SetRowHandleForDataRow(SamplesPanel.SamplesView, sample, "idfMaterial")


        End Sub

        Private Sub cbSessionStatus_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbSessionStatus.EditValueChanging
            If CLng(ASSessionStatus.Open).Equals(e.NewValue) AndAlso Not AsSessionRow("idfCampaign") Is DBNull.Value Then
                Dim ds As DataSet = m_AsSessionDbService.PopulateCampaignData(AsSessionRow("idfCampaign"))
                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("idfsCampaignStatus").Equals(CLng(ASCampaignStatus.Closed)) Then
                        e.Cancel = True
                        ErrorForm.ShowWarning("msgCantOpenSession", "Can't change session status to 'Open' because associated Campaign is closed.")
                    End If
                End If
                DbDisposeHelper.DisposeDataset(ds)
            End If
        End Sub

        Private m_UpdateTableView As Boolean
        Private Function SetTableViewMode(ByVal tableView As Boolean) As Boolean
            If m_UpdateTableView Then
                Return True
            End If
            m_UpdateTableView = True
            Try
                chkTableView.Checked = tableView
                If (m_BindingDefined) Then
                    m_ClosingMode = ClosingMode.None
                    If Not Post(PostType.FinalPosting) Then
                        Return False
                    End If
                    LoadData(GetKey())
                End If
                TableViewPanel.Visible = tableView
                FarmsGrid.Visible = Not tableView
                FarmTree.Visible = Not tableView
                AnimalsGrid.Visible = Not tableView
                SamplesPanel.Visible = Not tableView
                If (BaseSettings.AsSessionTableView <> tableView) Then
                    UserConfigWriter.Instance.SetItem("AsSessionTableView", tableView.ToString)
                    UserConfigWriter.Instance.Save()
                    Config.ReloadSettings()
                End If
                If tableView Then
                    TestsPanel.SamplesView = TableViewPanel.SamplesList
                Else
                    TestsPanel.SamplesView = SamplesPanel.SamplesList
                End If
                Return True
            Finally
                m_UpdateTableView = False
            End Try
        End Function

        Private Sub chkTableView_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTableView.CheckedChanged
            If Not SetTableViewMode(chkTableView.Checked) Then
                m_UpdateTableView = True
                chkTableView.Checked = TableViewPanel.Visible
                m_UpdateTableView = False
            End If
        End Sub

        Public ReadOnly Property SpeciesList As DataView
            Get
                Return baseDataSet.Tables(ASSession_DB.TableSpecies).DefaultView
            End Get
        End Property

        Private Sub btnViewCaseDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewCaseDetails.Click
            If BindingContext(baseDataSet, ASSession_DB.TableCases).Count > 0 Then
                Enabled = False
                Dim row As DataRow = CasesView.GetFocusedDataRow()
                Dim caseID As Object = row("idfCase")
                ShowCaseDetail(caseID)
                Enabled = True
            End If

        End Sub

        Private Sub ShowCaseDetail(ByVal caseID As Object)
            'Dim refreshCaseInfo As Boolean = False
            Dim row As DataRow = baseDataSet.Tables(ASSession_DB.TableCases).Rows.Find(caseID)
            If row Is Nothing Then
                Return
            End If
            Select Case CType(row("idfsCaseType"), CaseType)
                Case CaseType.Livestock
                    BaseFormManager.ShowNormal(CType(ClassLoader.LoadClass("VetCaseLiveStockDetail"), BaseForm), caseID, Nothing, Nothing)
                Case CaseType.Avian
                    BaseFormManager.ShowNormal(CType(ClassLoader.LoadClass("VetCaseAvianDetail"), BaseForm), caseID, Nothing, Nothing)
            End Select
            'If refreshCaseInfo Then
            '    m_AsSessionDbService.RefreshCaseInfo(baseDataSet)
            'End If

        End Sub
        Private Sub CasesView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles CasesView.DoubleClick
            If IsRowClicked(m_LastX, m_LastY) Then
                btnViewCaseDetails_Click(sender, e)
            End If

        End Sub
        Protected Function IsRowClicked(ByVal x As Integer, ByVal y As Integer) As Boolean
            Dim chi As GridHitInfo
            chi = CasesView.CalcHitInfo(New System.Drawing.Point(x, y))
            Return chi.InRow
        End Function

        Private m_LastX As Integer = -1
        Private m_LastY As Integer = -1
        Private Sub CasesView_MouseUp(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles CasesView.MouseUp
            m_LastX = e.Location.X
            m_LastY = e.Location.Y
        End Sub
        Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs)
            If ActiveControl Is CasesGrid AndAlso CasesView.FocusedRowHandle >= 0 Then
                If e.KeyCode = Keys.Enter Then
                    e.Handled = True
                    btnViewCaseDetails_Click(CasesView, EventArgs.Empty)
                    Return
                End If

            ElseIf ActiveControl.Parent Is txtSearchBySampleID Then
                If e.KeyCode = Keys.Enter Then
                    e.Handled = True
                    TestsPanel.CreateTestForSample(txtSearchBySampleID.Text)
                    Return
                End If

            End If
            MyBase.BaseForm_KeyDown(sender, e)
        End Sub

        Private Sub txtSearchBySampleID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtSearchBySampleID.ButtonClick
            TestsPanel.CreateTestForSample(txtSearchBySampleID.Text)
        End Sub


        Public Function ValidateCollectionDate(collectionDate As Object, ByRef errMsg As String, Optional showError As Boolean = False) As Boolean
            Dim startDate As Object = AsSessionRow("datStartDate")
            Dim endDate As Object = AsSessionRow("datEndDate")
            If Not WinUtils.ValidateDateInRange(collectionDate, startDate, endDate) Then
                errMsg = String.Format(EidssMessages.Get("AsSession.SummaryItem.datCollectionDate_msgId"), collectionDate, Utils.SafeDate(startDate), Utils.SafeDate(endDate))
                If (showError) Then
                    ErrorForm.ShowWarningDirect(errMsg)
                End If
                Return False
            End If
            Return True
        End Function

        Protected Overrides Sub RegisterValidators()
            Validators.Clear()
            Dim validator As DateChainValidator
            validator = New DateChainValidator(Me, dtStartDate, ASSession_DB.TableSession, "datStartDate", lbStartDate.Text)
            validator.AddChild(New DateChainValidator(Me, dtEndDate, ASSession_DB.TableSession, "datEndDate", lbEndDate.Text))
            validator.AddChild(New DateChainValidator(Me, ActionGrid, ASSession_DB.TableActions, "datActionDate", EidssFields.Get("datActionDate"), , , , True, , AddressOf UpdateActionsButtons))
            validator.RegisterValidator(Me, True)
            If (chkTableView.Checked) Then
                validator = TableViewPanel.CollectionDateValidator
            Else
                validator = SamplesPanel.CollectionDateValidator
            End If
            validator.AddChild(TestsPanel.DateValidator)
            validator.RegisterValidator(Me, False)
            SummaryPanel.CollectionDateValidator.RegisterValidator(Me, False)
        End Sub

        Private Sub dtStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtStartDate.EditValueChanged, dtEndDate.EditValueChanged
            If Not m_BindingDefined OrElse Not m_DataLoaded Then
                Return
            End If
            If Not baseDataSet Is Nothing AndAlso baseDataSet.Tables.Contains(ASSession_DB.TableSession) AndAlso baseDataSet.Tables(ASSession_DB.TableSession).Rows.Count > 0 Then
                Dim row As DataRow = AsSessionRow
                If Not Utils.IsEmpty(row("idfCampaign")) Then
                    If Not ValidateCampaignDates(row("datCampaignDateStart"), row("datCampaignDateEnd")) Then
                        Return
                    End If
                End If
            End If
        End Sub
        Dim m_Updating As Boolean

        Private Sub ActionView_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles ActionView.CellValueChanged
            UpdateActionsButtons()
        End Sub

        Private Sub ActionView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ActionView.FocusedRowChanged
            If Loading OrElse m_Updating Then Return
            m_Updating = True
            Try
                If e.PrevFocusedRowHandle >= 0 AndAlso IsRowValid(e.PrevFocusedRowHandle) = False Then
                    ActionView.FocusedRowHandle = e.PrevFocusedRowHandle
                    Return
                End If
            Finally
                UpdateActionsButtons()
                m_Updating = False
            End Try

        End Sub
        Private Sub CaseLogView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ActionView.InitNewRow
            Dim row As DataRow = ActionView.GetDataRow(e.RowHandle)
            m_AsSessionDbService.InitActionRow(row)
        End Sub

        Public Sub UpdateActionsButtons()
            Dim rowSelected As Boolean = ActionView.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso Not ActionView.GetFocusedDataRow() Is Nothing
            btnDeleteAction.Enabled = Not [ReadOnly] AndAlso rowSelected
            ActionView.OptionsBehavior.Editable = Not [ReadOnly]
            EnableRowAdding((Not [ReadOnly] AndAlso IsRowValid(, False)))
        End Sub


        Private Function IsRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
            If index = -1 Then index = ActionView.FocusedRowHandle
            Dim row As DataRow = ActionView.GetDataRow(index)

            If row Is Nothing Then Return True
            If row("idfsMonitoringSessionActionType") Is DBNull.Value Then
                If showError Then
                    tcASCampaign.SelectedTabPage = tpActions
                    ActionView.FocusedColumn = Me.colActionType
                    ActionView.FocusedRowHandle = index
                    ErrorForm.ShowWarningDirect(String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving"), colActionType.Caption))
                End If
                Return False
            End If
            If CType(row("datActionDate"), DateTime).Date > DateTime.Today Then
                If showError Then
                    Dim msg As String = String.Format(EidssMessages.Get("ErrUnstrictChainDate"), ActionView.Columns("colActionDate").Caption, CType(row("datActionDate"), Date), BvMessages.Get("CurrentDate"), DateTime.Today)
                    tcASCampaign.SelectedTabPage = tpActions
                    ActionView.FocusedColumn = Me.colActionDate
                    ActionView.FocusedRowHandle = index
                    ErrorForm.ShowWarningDirect(msg)
                End If
                Return False
            End If

            Return True
        End Function

        Public Sub EnableRowAdding(enable As Boolean)
            If (ActionView.FocusedRowHandle = GridControl.NewItemRowHandle) Then
                Return
            End If
            If (Not enable) Then
                ActionView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Else
                ActionView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            End If
        End Sub
        <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property [ReadOnly]() As Boolean
            Get
                Return MyBase.ReadOnly
            End Get
            Set(ByVal Value As Boolean)
                MyBase.ReadOnly = Value
                UpdateActionsButtons()
            End Set
        End Property

        Private Sub chkFilterSamples_CheckedChanged(sender As Object, e As EventArgs) Handles chkFilterSamples.CheckedChanged
            SamplesPanel.FilterSamplesByDiagnosis = chkFilterSamples.Checked
            TableViewPanel.FilterSamplesBydiagnosis = chkFilterSamples.Checked
        End Sub
    End Class

End Namespace
