Imports System.ComponentModel
Imports System.Threading
Imports bv.winclient.Core
Imports EIDSS.model.Enums

Public Class StatisticDetail

    Inherits BaseDetailForm
    Dim StatisticDbService As Statistic_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        StatisticDbService = New Statistic_DB

        DbService = StatisticDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoStatistic, AuditTable.tlbStatistic)
        LookupTableNames = New String() {"Statistic"}
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Statistic

        Me.RegisterChildObject(AreaLookup1, RelatedPostOrder.PostFirst)

    End Sub

    'Form overrides dispose to clean up the component list.

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then

            If Not (components Is Nothing) Then

                components.Dispose()

            End If

        End If

        MyBase.Dispose(disposing)

    End Sub


    'Required by the Windows Form Designer

    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblStatistic_Data_Type As System.Windows.Forms.Label
    Friend WithEvents cbStatistic_Data_Type As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblStatistic_Period_Type As System.Windows.Forms.Label
    Friend WithEvents cbStatistic_Period_Type As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblStatistic_Area_Type As System.Windows.Forms.Label
    Friend WithEvents cbStatistic_Area_Type As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents txtValue As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblParameter As System.Windows.Forms.Label
    Friend WithEvents cbParameter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblParameterType As System.Windows.Forms.Label
    Friend WithEvents cbParameterType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents datStatisticStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbStatisticAgeGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbStatisticAgeGroup As System.Windows.Forms.Label
    Friend WithEvents AreaLookup1 As EIDSS.AreaLookup
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatisticDetail))
        Me.lblStatistic_Data_Type = New System.Windows.Forms.Label()
        Me.cbStatistic_Data_Type = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblStatistic_Period_Type = New System.Windows.Forms.Label()
        Me.cbStatistic_Period_Type = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblStatistic_Area_Type = New System.Windows.Forms.Label()
        Me.cbStatistic_Area_Type = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.txtValue = New DevExpress.XtraEditors.SpinEdit()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblParameter = New System.Windows.Forms.Label()
        Me.cbParameter = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbParameterType = New DevExpress.XtraEditors.TextEdit()
        Me.lblParameterType = New System.Windows.Forms.Label()
        Me.datStatisticStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.AreaLookup1 = New EIDSS.AreaLookup()
        Me.cbStatisticAgeGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbStatisticAgeGroup = New System.Windows.Forms.Label()
        CType(Me.cbStatistic_Data_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatistic_Period_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatistic_Area_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbParameter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbParameterType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStatisticStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStatisticStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatisticAgeGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(StatisticDetail), resources)
        'Form Is Localizable: True
        '
        'lblStatistic_Data_Type
        '
        resources.ApplyResources(Me.lblStatistic_Data_Type, "lblStatistic_Data_Type")
        Me.lblStatistic_Data_Type.Name = "lblStatistic_Data_Type"
        '
        'cbStatistic_Data_Type
        '
        resources.ApplyResources(Me.cbStatistic_Data_Type, "cbStatistic_Data_Type")
        Me.cbStatistic_Data_Type.Name = "cbStatistic_Data_Type"
        Me.cbStatistic_Data_Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatistic_Data_Type.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatistic_Data_Type.Properties.NullText = resources.GetString("cbStatistic_Data_Type.Properties.NullText")
        Me.cbStatistic_Data_Type.Tag = "{M}"
        '
        'lblStatistic_Period_Type
        '
        resources.ApplyResources(Me.lblStatistic_Period_Type, "lblStatistic_Period_Type")
        Me.lblStatistic_Period_Type.Name = "lblStatistic_Period_Type"
        '
        'cbStatistic_Period_Type
        '
        resources.ApplyResources(Me.cbStatistic_Period_Type, "cbStatistic_Period_Type")
        Me.cbStatistic_Period_Type.Name = "cbStatistic_Period_Type"
        Me.cbStatistic_Period_Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatistic_Period_Type.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatistic_Period_Type.Properties.NullText = resources.GetString("cbStatistic_Period_Type.Properties.NullText")
        Me.cbStatistic_Period_Type.TabStop = False
        Me.cbStatistic_Period_Type.Tag = "{R}"
        '
        'lblStatistic_Area_Type
        '
        resources.ApplyResources(Me.lblStatistic_Area_Type, "lblStatistic_Area_Type")
        Me.lblStatistic_Area_Type.Name = "lblStatistic_Area_Type"
        '
        'cbStatistic_Area_Type
        '
        resources.ApplyResources(Me.cbStatistic_Area_Type, "cbStatistic_Area_Type")
        Me.cbStatistic_Area_Type.Name = "cbStatistic_Area_Type"
        Me.cbStatistic_Area_Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatistic_Area_Type.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatistic_Area_Type.Properties.NullText = resources.GetString("cbStatistic_Area_Type.Properties.NullText")
        Me.cbStatistic_Area_Type.TabStop = False
        Me.cbStatistic_Area_Type.Tag = "{R}"
        '
        'lblStartDate
        '
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        '
        'lblArea
        '
        resources.ApplyResources(Me.lblArea, "lblArea")
        Me.lblArea.Name = "lblArea"
        '
        'txtValue
        '
        resources.ApplyResources(Me.txtValue, "txtValue")
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtValue.Properties.DisplayFormat.FormatString = "d"
        Me.txtValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtValue.Properties.EditFormat.FormatString = """d"""
        Me.txtValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtValue.Properties.IsFloatValue = False
        Me.txtValue.Properties.Mask.EditMask = resources.GetString("txtValue.Properties.Mask.EditMask")
        Me.txtValue.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtValue.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtValue.Tag = "{M}"
        '
        'lblValue
        '
        resources.ApplyResources(Me.lblValue, "lblValue")
        Me.lblValue.Name = "lblValue"
        '
        'lblParameter
        '
        resources.ApplyResources(Me.lblParameter, "lblParameter")
        Me.lblParameter.Name = "lblParameter"
        '
        'cbParameter
        '
        resources.ApplyResources(Me.cbParameter, "cbParameter")
        Me.cbParameter.Name = "cbParameter"
        Me.cbParameter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbParameter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbParameter.Properties.NullText = resources.GetString("cbParameter.Properties.NullText")
        Me.cbParameter.Tag = "{M}"
        '
        'cbParameterType
        '
        resources.ApplyResources(Me.cbParameterType, "cbParameterType")
        Me.cbParameterType.Name = "cbParameterType"
        Me.cbParameterType.TabStop = False
        Me.cbParameterType.Tag = "{R}"
        '
        'lblParameterType
        '
        resources.ApplyResources(Me.lblParameterType, "lblParameterType")
        Me.lblParameterType.Name = "lblParameterType"
        '
        'datStatisticStartDate
        '
        resources.ApplyResources(Me.datStatisticStartDate, "datStatisticStartDate")
        Me.datStatisticStartDate.Name = "datStatisticStartDate"
        Me.datStatisticStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datStatisticStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datStatisticStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datStatisticStartDate.Tag = "{M}"
        '
        'AreaLookup1
        '
        resources.ApplyResources(Me.AreaLookup1, "AreaLookup1")
        Me.AreaLookup1.Appearance.BackColor = CType(resources.GetObject("AreaLookup1.Appearance.BackColor"), System.Drawing.Color)
        Me.AreaLookup1.Appearance.Options.UseBackColor = True
        Me.AreaLookup1.CanExpand = True
        Me.AreaLookup1.FormID = Nothing
        Me.AreaLookup1.HelpTopicID = Nothing
        Me.AreaLookup1.KeyFieldName = Nothing
        Me.AreaLookup1.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AreaLookup1.MultiSelect = False
        Me.AreaLookup1.Name = "AreaLookup1"
        Me.AreaLookup1.ObjectName = Nothing
        Me.AreaLookup1.TableName = Nothing
        Me.AreaLookup1.Tag = "{M}"
        Me.AreaLookup1.UseParentBackColor = True
        '
        'cbStatisticAgeGroup
        '
        resources.ApplyResources(Me.cbStatisticAgeGroup, "cbStatisticAgeGroup")
        Me.cbStatisticAgeGroup.Name = "cbStatisticAgeGroup"
        Me.cbStatisticAgeGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatisticAgeGroup.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatisticAgeGroup.Properties.NullText = resources.GetString("cbStatisticAgeGroup.Properties.NullText")
        Me.cbStatisticAgeGroup.Tag = "{M}"
        '
        'lbStatisticAgeGroup
        '
        resources.ApplyResources(Me.lbStatisticAgeGroup, "lbStatisticAgeGroup")
        Me.lbStatisticAgeGroup.Name = "lbStatisticAgeGroup"
        '
        'StatisticDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.cbStatisticAgeGroup)
        Me.Controls.Add(Me.lbStatisticAgeGroup)
        Me.Controls.Add(Me.cbStatistic_Data_Type)
        Me.Controls.Add(Me.cbStatistic_Period_Type)
        Me.Controls.Add(Me.datStatisticStartDate)
        Me.Controls.Add(Me.cbStatistic_Area_Type)
        Me.Controls.Add(Me.AreaLookup1)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.cbParameterType)
        Me.Controls.Add(Me.cbParameter)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblStatistic_Data_Type)
        Me.Controls.Add(Me.lblStatistic_Area_Type)
        Me.Controls.Add(Me.lblStatistic_Period_Type)
        Me.Controls.Add(Me.lblParameter)
        Me.Controls.Add(Me.lblParameterType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "C13"
        Me.HelpTopicID = "Statistics"
        Me.KeyFieldName = "idfStatistic"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.StatDataDetai_132_
        Me.Name = "StatisticDetail"
        Me.ObjectName = "Statistic"
        Me.ShowDeleteButton = False
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Statistic"
        Me.Controls.SetChildIndex(Me.lblParameterType, 0)
        Me.Controls.SetChildIndex(Me.lblParameter, 0)
        Me.Controls.SetChildIndex(Me.lblStatistic_Period_Type, 0)
        Me.Controls.SetChildIndex(Me.lblStatistic_Area_Type, 0)
        Me.Controls.SetChildIndex(Me.lblStatistic_Data_Type, 0)
        Me.Controls.SetChildIndex(Me.lblStartDate, 0)
        Me.Controls.SetChildIndex(Me.lblArea, 0)
        Me.Controls.SetChildIndex(Me.lblValue, 0)
        Me.Controls.SetChildIndex(Me.cbParameter, 0)
        Me.Controls.SetChildIndex(Me.cbParameterType, 0)
        Me.Controls.SetChildIndex(Me.txtValue, 0)
        Me.Controls.SetChildIndex(Me.AreaLookup1, 0)
        Me.Controls.SetChildIndex(Me.cbStatistic_Area_Type, 0)
        Me.Controls.SetChildIndex(Me.datStatisticStartDate, 0)
        Me.Controls.SetChildIndex(Me.cbStatistic_Period_Type, 0)
        Me.Controls.SetChildIndex(Me.cbStatistic_Data_Type, 0)
        Me.Controls.SetChildIndex(Me.lbStatisticAgeGroup, 0)
        Me.Controls.SetChildIndex(Me.cbStatisticAgeGroup, 0)
        CType(Me.cbStatistic_Data_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatistic_Period_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatistic_Area_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbParameter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbParameterType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStatisticStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStatisticStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatisticAgeGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindSpinEdit(txtValue, baseDataSet, "Statistic.varValue")
        Core.LookupBinder.BindDateEdit(datStatisticStartDate, baseDataSet, "Statistic.datStatisticStartDate")
        Core.LookupBinder.BindBaseLookup(cbStatistic_Data_Type, baseDataSet, "Statistic.idfsStatisticDataType", db.BaseReferenceType.rftStatisticDataType, False)
        Core.LookupBinder.BindBaseLookup(cbStatistic_Period_Type, baseDataSet, "Statistic.idfsStatisticPeriodType", db.BaseReferenceType.rftStatisticPeriodType, False)
        Core.LookupBinder.BindBaseLookup(cbStatistic_Area_Type, baseDataSet, "Statistic.idfsStatisticAreaType", db.BaseReferenceType.rftStatisticAreaType, False)
        Core.LookupBinder.BindTextEdit(cbParameterType, baseDataSet, "Statistic.strParameterType")
        eventManager.AttachDataHandler("Statistic.datStatisticStartDate", AddressOf StartDate_Changed)
        eventManager.AttachDataHandler("Statistic.idfsStatisticPeriodType", AddressOf StatisticPeriodType_Changed)
        eventManager.AttachDataHandler("Statistic.idfsStatisticDataType", AddressOf StatisticDataType_Changed)
        eventManager.AttachDataHandler("Statistic.idfsStatisticAreaType", AddressOf StatisticAreaType_Changed)

    End Sub

    Private Sub StatisticAreaType_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        BindArea()
    End Sub

    Private Sub StatisticDataType_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If (Me.State And BusinessObjectState.NewObject) <> 0 AndAlso Not Utils.IsEmpty(e.Value) Then
            BindPeriodAreaParameter()
        End If
    End Sub

    <Browsable(False)> _
    Private ReadOnly Property StatisticRow() As DataRow
        Get
            Return baseDataSet.Tables("Statistic").Rows(0)
        End Get
    End Property

    Private Sub StartDate_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        CalcFinishDate(e.Row("datStatisticStartDate"), e.Row("idfsStatisticPeriodType"))
    End Sub
    Private Sub StatisticPeriodType_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        CalcFinishDate(e.Row("datStatisticStartDate"), e.Value)
    End Sub
    Private Sub BindPeriodAreaParameter()
        SetMandatoryFieldVisible(cbStatisticAgeGroup, False)
        lbStatisticAgeGroup.Visible = False
        lblParameterType.Visible = False
        SetMandatoryFieldVisible(cbParameterType, False)
        lblParameter.Visible = False
        SetMandatoryFieldVisible(cbParameter, False)
        Dim dataType As Object = StatisticRow("idfsStatisticDataType")
        If Not Utils.IsEmpty(dataType) Then
            If (Me.State And BusinessObjectState.NewObject) <> 0 OrElse StatisticRow("idfsStatisticAreaType") Is DBNull.Value Then ' new object editing
                EnableEditing(True)
                Dim row As DataRow = StatisticDbService.GetStatisticDataTypeRow(dataType)
                If Not row Is Nothing Then
                    StatisticRow("idfsStatisticPeriodType") = row("idfsStatisticPeriodType")
                    StatisticRow("idfsReferenceType") = row("idfsReferenceType")
                    StatisticRow("blnRelatedWithAgeGroup") = row("blnRelatedWithAgeGroup")
                    If (row("blnRelatedWithAgeGroup") Is DBNull.Value) Then
                        StatisticRow("idfsStatisticalAgeGroup") = DBNull.Value
                    End If
                    If Not row("idfsReferenceType") Is DBNull.Value Then
                        StatisticRow("strParameterType") = LookupCache.GetLookupValue(row("idfsReferenceType"), db.BaseReferenceType.rftReferenceTypeName, "Name")
                    End If
                    CalcFinishDate(StatisticRow("datStatisticStartDate"), StatisticRow("idfsStatisticPeriodType"))
                    If Not Utils.IsEmpty(row("idfsStatisticAreaType")) Then
                        StatisticRow("idfsStatisticAreaType") = row("idfsStatisticAreaType")
                    End If
                    BindArea()
                End If
            Else
                BindArea()
                EnableEditing(False)
            End If
            ArrangeAdditionalParameters()
            If Not Utils.IsEmpty(StatisticRow("idfsReferenceType")) Then
                lblParameterType.Visible = True
                SetMandatoryFieldVisible(cbParameterType, True)
                lblParameter.Visible = True
                SetMandatoryFieldVisible(cbParameter, True)
                'cbParameterType.EditValue = row("idfsReferenceType")
                cbParameterType.Properties.ReadOnly = True
                Dim TableId As db.BaseReferenceType = db.BaseReferenceType.rftNone
                Try
                    TableId = CType(StatisticRow("idfsReferenceType"), db.BaseReferenceType)
                Catch ex As Exception
                    TableId = db.BaseReferenceType.rftNone
                End Try
                Core.LookupBinder.BindBaseLookup(cbParameter, baseDataSet, "Statistic.idfsMainBaseReference", TableId, HACode.All, False)
            End If
            StatisticRow.EndEdit()
        Else
            AreaLookup1.IDType = StatisticAreaType.None
            EnableEditing(True)
        End If
    End Sub
    Private Sub ArrangeAdditionalParameters()
        If StatisticRow("blnRelatedWithAgeGroup").Equals(True) Then
            Core.LookupBinder.BindBaseLookup(cbStatisticAgeGroup, baseDataSet, "Statistic.idfsStatisticalAgeGroup", db.BaseReferenceType.rftStatisticalAgeGroup, False)
            SetMandatoryFieldVisible(cbStatisticAgeGroup, True)
            lbStatisticAgeGroup.Visible = True
            lblParameter.Top = lbStatisticAgeGroup.Top + 56
            lblParameterType.Top = lbStatisticAgeGroup.Top + 28
            cbParameter.Top = cbStatisticAgeGroup.Top + 56
            cbParameterType.Top = cbStatisticAgeGroup.Top + 28

        Else
            SetMandatoryFieldVisible(cbStatisticAgeGroup, False)
            lbStatisticAgeGroup.Visible = False
            lblParameter.Top = lbStatisticAgeGroup.Top + 28
            lblParameterType.Top = lbStatisticAgeGroup.Top
            cbParameter.Top = cbStatisticAgeGroup.Top + 28
            cbParameterType.Top = cbStatisticAgeGroup.Top
        End If
    End Sub
    Private Sub EnableEditing(ByVal Enabled As Boolean)
        datStatisticStartDate.Enabled = Enabled
        AreaLookup1.Enabled = Enabled
        cbStatistic_Data_Type.Enabled = Enabled
        txtValue.Enabled = Not [ReadOnly]

    End Sub
    Private Sub BindArea()
        Dim CurArea As Object = StatisticRow("idfsArea")
        If StatisticRow("idfsStatisticAreaType") Is DBNull.Value Then
            AreaLookup1.Enabled = False
        Else
            AreaLookup1.Enabled = True
            AreaLookup1.IDType = CType(StatisticRow("idfsStatisticAreaType"), StatisticAreaType)
        End If
        AreaLookup1.AreaValue = CurArea
    End Sub

    Private Sub CalcFinishDate(ByVal StartDate As Object, ByVal Period_Type As Object)
        If Not IsCreated() Then
            Return
        End If

        If (Not Utils.IsEmpty(StartDate)) AndAlso (Not Utils.IsEmpty(Period_Type)) Then
            StartDate = GetStartDate(StartDate)
            If Not StartDate.Equals(datStatisticStartDate.EditValue) Then
                datStatisticStartDate.EditValue = StartDate
            End If
            Dim FinishDate As Date = CType(StartDate, Date)
            Select Case CType(Period_Type, StatisticPeriodType)
                Case StatisticPeriodType.Month
                    FinishDate = FinishDate.AddMonths(1).AddDays(-1)
                    'Case StatisticPeriodType.Day
                    '    FinishDate = FinishDate.AddDays(1)
                Case StatisticPeriodType.Quarter
                    FinishDate = FinishDate.AddMonths(3).AddDays(-1)
                Case StatisticPeriodType.Week
                    FinishDate = FinishDate.AddDays(7).AddDays(-1)
                Case StatisticPeriodType.Year
                    FinishDate = FinishDate.AddYears(1).AddDays(-1)
                Case Else
                    'NOOP
            End Select
            StatisticRow("datStatisticFinishDate") = FinishDate
            StatisticRow("datStatisticStartDate") = StartDate
        Else
            StatisticRow("datStatisticFinishDate") = DBNull.Value
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim res As Boolean = True
        If Not Utils.IsEmpty(cbStatistic_Data_Type.EditValue) AndAlso _
                    Not Utils.IsEmpty(cbStatistic_Period_Type.EditValue) AndAlso _
                    Not Utils.IsEmpty(cbStatistic_Area_Type.EditValue) AndAlso _
                    Not Utils.IsEmpty(datStatisticStartDate.EditValue) AndAlso _
                    Utils.IsEmpty(AreaLookup1.GetAreaKey()) Then
            ErrorForm.ShowWarningFormat("ErrMandatoryFieldRequired", "The field '{0}' is mandatory. You must enter data to this field before form saving", lblArea.Text)
            If AreaLookup1.cbCountry.Visible Then
                AreaLookup1.cbCountry.Select()
            Else
                AreaLookup1.SelectPopupEdit()
            End If
            res = False
        End If
        If res Then
            res = MyBase.ValidateData()
        End If
        StatisticRow("idfsArea") = AreaLookup1.GetAreaKey()
        If res AndAlso StatisticDbService.StatisticExists(StatisticRow) Then
            ErrorForm.ShowWarning("errDoubleStatistic")
            res = False
        End If
        Return res
    End Function

    Private Function GetStartDate(ByVal value As Object) As Object
        If Utils.IsEmpty(value) OrElse StatisticRow("idfsStatisticPeriodType") Is DBNull.Value Then
            Return value
        End If
        Dim startDate As Date = CDate(value)
        Select Case CType(StatisticRow("idfsStatisticPeriodType"), StatisticPeriodType)
            Case StatisticPeriodType.Month
                Return New Date(startDate.Year, startDate.Month, 1)
            Case StatisticPeriodType.Week
                Return model.Core.DatePeriodHelper.GetStartOfWeek(startDate)
            Case StatisticPeriodType.Quarter
                Return New Date(startDate.Year, ((startDate.Month - 1) \ 3) * 3 + 1, 1)
            Case StatisticPeriodType.Year
                Return New Date(startDate.Year, 1, 1)
        End Select
        Return value
    End Function

    'Private Sub cbStatistic_Data_Type_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbStatistic_Data_Type.ButtonClick
    '    If CType(sender, DevExpress.XtraEditors.BaseEdit).Properties.ReadOnly = True Then Return
    '    If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
    '        Dim ID As Object = Nothing
    '        If BaseForm.ShowModal(New StatisticTypeDetail, FindForm, ID, , ) Then
    '            If TypeOf sender Is DevExpress.XtraEditors.LookUpEdit Then
    '                CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = ID
    '            End If
    '        End If
    '    End If
    'End Sub

    'Public Overrides Function Post(Optional ByVal PostType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
    '    DataEventManager.Flush()
    '    If (Not HasChanges()) Then
    '        Return True
    '    End If
    '    Dim bRet As Boolean = MyBase.Post(PostType)
    '    If bRet Then AreaLookup1.AreaChanged = False
    '    Return bRet
    'End Function

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If (Not baseDataSet Is Nothing) AndAlso baseDataSet.Tables.Contains("Statistic") AndAlso _
           (baseDataSet.Tables("Statistic").Rows.Count > 0) Then
            Return StatisticRow("idfsArea")
        Else
            Return DBNull.Value
        End If
    End Function

    Private Sub StatisticDetail_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterLoadData
        BindPeriodAreaParameter()
    End Sub

    Private Sub StatisticDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
        AreaLookup1.AreaChanged = False
    End Sub

    Private Sub StatisticDetail_OnBeforePost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnBeforePost
        StatisticRow("idfsArea") = AreaLookup1.GetAreaKey()
    End Sub


End Class
