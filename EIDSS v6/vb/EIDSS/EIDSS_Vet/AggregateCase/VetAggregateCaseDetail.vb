Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports eidss.model.Enums
Imports EIDSS.model.Reports
Imports bv.common.Enums

Public Class VetAggregateCaseDetail
    Inherits BaseDetailForm

    Dim AggregateCaseDbService As VetAggregateCase_DB
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AggregateCaseDbService = New VetAggregateCase_DB

        DbService = AggregateCaseDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoAggregateVetCase, AuditTable.tlbAggrCase)

        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.AccessToVetAggregateCase
        AggregateHeader1.UseParentDataset = True
        RegisterChildObject(AggregateHeader1, RelatedPostOrder.SkipPost)
        RegisterChildObject(fgAggregateData, RelatedPostOrder.PostLast)
        fgAggregateData.SectionTableCaptionsIsVisible = False

    End Sub


#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If EidssSiteContext.Instance.CustomizationPackageID = CLng(CustomizationPackage.Azerbaijan) Then
            Exit Sub
        End If
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewVetAggregateCase", 230)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.VetAggregateCase
        ma.Name = "btnNewVetAggregateCase"
        ma.Group = CInt(MenuGroup.CreateAggregate)
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.AccessToVetAggregateCase)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New VetAggregateCaseDetail, Nothing)
        'BaseForm.ShowModal(New VetAggregateCaseDetail)
    End Sub
#End Region



    Protected Overrides Sub AfterLoad()
        lbNoVetCaseMatrix.Text = EidssMessages.Get("errNoVetAggregateCaseMatrix")
        If Not AggregateHeader1.ShowFlexibleForm(fgAggregateData, FFType.VetAggregateCase, Nothing, Nothing) Then
            fgAggregateData.Visible = False
            lbNoVetCaseMatrix.Visible = True
            [ReadOnly] = True
            lbMatrixVersion.Visible = False
            cbMatrixVersion.Visible = False
            lbFormTemplate.Visible = False
            cbFormTemplate.Visible = False
        Else
            Core.LookupBinder.BindAggregateMatrixVersionLookup(cbMatrixVersion, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfVersion", AggregateCaseSection.VetCase, True)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfVersion", AddressOf MatrixVersionChanged)
            Core.LookupBinder.BindFFTemplatesLookup(cbFormTemplate, baseDataSet, AggregateHeader_DB.TableAggregateHeader + ".idfsCaseObservationFormTemplate", FFType.VetAggregateCase)
            eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsCaseObservationFormTemplate", AddressOf FormTemplateChanged)
            AggregateHeader1.AttachCellChangingHandler(fgAggregateData)
        End If
    End Sub

    Private Sub FormTemplateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgAggregateData, FFType.VetAggregateCase, CType(e.Value, Nullable(Of Long)), Nothing)
    End Sub

    Private Sub MatrixVersionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        AggregateHeader1.ShowFlexibleForm(fgAggregateData, FFType.VetAggregateCase, Nothing, CType(e.Value, Nullable(Of Long)))
    End Sub


#Region "REPORTS SUPPORT"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 OrElse baseDataSet.Tables(0).Rows.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then

            Dim template As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfsCaseObservationFormTemplate"))
            Dim observastion As Long = Utils.ToLong(baseDataSet.Tables(0).Rows(0)("idfCaseObservation"))
            EidssSiteContext.ReportFactory.VetAggregateCase(New AggregateReportParameters(CLng(GetKey()), template, observastion))
        End If
    End Sub

#End Region


    Protected Overrides Sub RegisterValidators()
        MyBase.RegisterValidators()
        AggregateHeader1.DateValidator.RegisterValidator(Me, True)
    End Sub



End Class