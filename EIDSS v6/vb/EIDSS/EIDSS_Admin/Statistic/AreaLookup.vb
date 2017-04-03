Imports System.ComponentModel
Public Class AreaLookup
    Inherits BaseLookupForm

    Dim AreaDbService As Area_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        AreaDbService = New Area_DB
        DbService = AreaDbService

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblRayon As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbSettlement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSettlement As System.Windows.Forms.Label
    Friend WithEvents lblDefCountry As System.Windows.Forms.Label
    Friend WithEvents cbDefCountry As DevExpress.XtraEditors.LookUpEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AreaLookup))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblRayon = New System.Windows.Forms.Label()
        Me.lblSettlement = New System.Windows.Forms.Label()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSettlement = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblDefCountry = New System.Windows.Forms.Label()
        Me.cbDefCountry = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDefCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AreaLookup), resources)
        'Form Is Localizable: True
        '
        'lblCountry
        '
        resources.ApplyResources(Me.lblCountry, "lblCountry")
        Me.lblCountry.Name = "lblCountry"
        '
        'lblRegion
        '
        resources.ApplyResources(Me.lblRegion, "lblRegion")
        Me.lblRegion.Name = "lblRegion"
        '
        'lblRayon
        '
        resources.ApplyResources(Me.lblRayon, "lblRayon")
        Me.lblRayon.Name = "lblRayon"
        '
        'lblSettlement
        '
        resources.ApplyResources(Me.lblSettlement, "lblSettlement")
        Me.lblSettlement.Name = "lblSettlement"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.AccessibleDescription = resources.GetString("cbCountry.Properties.AccessibleDescription")
        Me.cbCountry.Properties.AccessibleName = resources.GetString("cbCountry.Properties.AccessibleName")
        Me.cbCountry.Properties.AutoHeight = CType(resources.GetObject("cbCountry.Properties.AutoHeight"), Boolean)
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCountry.Properties.Columns"), resources.GetString("cbCountry.Properties.Columns1"), CType(resources.GetObject("cbCountry.Properties.Columns2"), Integer), CType(resources.GetObject("cbCountry.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbCountry.Properties.Columns4"), CType(resources.GetObject("cbCountry.Properties.Columns5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Properties.NullValuePrompt = resources.GetString("cbCountry.Properties.NullValuePrompt")
        Me.cbCountry.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCountry.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbCountry.Tag = "{M}"
        '
        'cbRegion
        '
        resources.ApplyResources(Me.cbRegion, "cbRegion")
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Properties.AccessibleDescription = resources.GetString("cbRegion.Properties.AccessibleDescription")
        Me.cbRegion.Properties.AccessibleName = resources.GetString("cbRegion.Properties.AccessibleName")
        Me.cbRegion.Properties.AutoHeight = CType(resources.GetObject("cbRegion.Properties.AutoHeight"), Boolean)
        Me.cbRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"), CType(resources.GetObject("cbRegion.Properties.Columns2"), Integer), CType(resources.GetObject("cbRegion.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRegion.Properties.Columns4"), CType(resources.GetObject("cbRegion.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRegion.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText")
        Me.cbRegion.Properties.NullValuePrompt = resources.GetString("cbRegion.Properties.NullValuePrompt")
        Me.cbRegion.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRegion.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRegion.Tag = "{M}"
        '
        'cbRayon
        '
        resources.ApplyResources(Me.cbRayon, "cbRayon")
        Me.cbRayon.Name = "cbRayon"
        Me.cbRayon.Properties.AccessibleDescription = resources.GetString("cbRayon.Properties.AccessibleDescription")
        Me.cbRayon.Properties.AccessibleName = resources.GetString("cbRayon.Properties.AccessibleName")
        Me.cbRayon.Properties.AutoHeight = CType(resources.GetObject("cbRayon.Properties.AutoHeight"), Boolean)
        Me.cbRayon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRayon.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"), CType(resources.GetObject("cbRayon.Properties.Columns2"), Integer), CType(resources.GetObject("cbRayon.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRayon.Properties.Columns4"), CType(resources.GetObject("cbRayon.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRayon.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText")
        Me.cbRayon.Properties.NullValuePrompt = resources.GetString("cbRayon.Properties.NullValuePrompt")
        Me.cbRayon.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRayon.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRayon.Tag = "{M}"
        '
        'cbSettlement
        '
        resources.ApplyResources(Me.cbSettlement, "cbSettlement")
        Me.cbSettlement.Name = "cbSettlement"
        Me.cbSettlement.Properties.AccessibleDescription = resources.GetString("cbSettlement.Properties.AccessibleDescription")
        Me.cbSettlement.Properties.AccessibleName = resources.GetString("cbSettlement.Properties.AccessibleName")
        Me.cbSettlement.Properties.AutoHeight = CType(resources.GetObject("cbSettlement.Properties.AutoHeight"), Boolean)
        Me.cbSettlement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSettlement.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSettlement.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlement.Properties.Columns"), resources.GetString("cbSettlement.Properties.Columns1"), CType(resources.GetObject("cbSettlement.Properties.Columns2"), Integer), CType(resources.GetObject("cbSettlement.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbSettlement.Properties.Columns4"), CType(resources.GetObject("cbSettlement.Properties.Columns5"), Boolean), CType(resources.GetObject("cbSettlement.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText")
        Me.cbSettlement.Properties.NullValuePrompt = resources.GetString("cbSettlement.Properties.NullValuePrompt")
        Me.cbSettlement.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbSettlement.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbSettlement.Tag = "{M}"
        '
        'lblDefCountry
        '
        resources.ApplyResources(Me.lblDefCountry, "lblDefCountry")
        Me.lblDefCountry.Name = "lblDefCountry"
        '
        'cbDefCountry
        '
        resources.ApplyResources(Me.cbDefCountry, "cbDefCountry")
        Me.cbDefCountry.Name = "cbDefCountry"
        Me.cbDefCountry.Properties.AccessibleDescription = resources.GetString("cbDefCountry.Properties.AccessibleDescription")
        Me.cbDefCountry.Properties.AccessibleName = resources.GetString("cbDefCountry.Properties.AccessibleName")
        Me.cbDefCountry.Properties.AutoHeight = CType(resources.GetObject("cbDefCountry.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        Me.cbDefCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDefCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDefCountry.Properties.Buttons1"), CType(resources.GetObject("cbDefCountry.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDefCountry.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDefCountry.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDefCountry.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDefCountry.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDefCountry.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbDefCountry.Properties.Buttons8"), CType(resources.GetObject("cbDefCountry.Properties.Buttons9"), Object), CType(resources.GetObject("cbDefCountry.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDefCountry.Properties.Buttons11"), Boolean))})
        Me.cbDefCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbDefCountry.Properties.Columns"), resources.GetString("cbDefCountry.Properties.Columns1"), CType(resources.GetObject("cbDefCountry.Properties.Columns2"), Integer), CType(resources.GetObject("cbDefCountry.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbDefCountry.Properties.Columns4"), CType(resources.GetObject("cbDefCountry.Properties.Columns5"), Boolean), CType(resources.GetObject("cbDefCountry.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbDefCountry.Properties.NullText = resources.GetString("cbDefCountry.Properties.NullText")
        Me.cbDefCountry.Properties.NullValuePrompt = resources.GetString("cbDefCountry.Properties.NullValuePrompt")
        Me.cbDefCountry.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbDefCountry.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbDefCountry.Tag = "{R}"
        '
        'AreaLookup
        '
        resources.ApplyResources(Me, "$this")
        Me.Appearance.BackColor = CType(resources.GetObject("AreaLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.Appearance.FontSizeDelta = CType(resources.GetObject("AreaLookup.Appearance.FontSizeDelta"), Integer)
        Me.Appearance.FontStyleDelta = CType(resources.GetObject("AreaLookup.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.Appearance.GradientMode = CType(resources.GetObject("AreaLookup.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.Appearance.Image = CType(resources.GetObject("AreaLookup.Appearance.Image"), System.Drawing.Image)
        Me.Appearance.Options.UseBackColor = True
        Me.CanExpand = True
        Me.Controls.Add(Me.cbDefCountry)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.cbRayon)
        Me.Controls.Add(Me.cbSettlement)
        Me.Controls.Add(Me.cbCountry)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.lblDefCountry)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.lblRayon)
        Me.Controls.Add(Me.lblSettlement)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LookupLayout = bv.common.win.LookupFormLayout.DropDownList
        Me.Name = "AreaLookup"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.lblSettlement, 0)
        Me.Controls.SetChildIndex(Me.lblRayon, 0)
        Me.Controls.SetChildIndex(Me.lblRegion, 0)
        Me.Controls.SetChildIndex(Me.lblDefCountry, 0)
        Me.Controls.SetChildIndex(Me.lblCountry, 0)
        Me.Controls.SetChildIndex(Me.cbCountry, 0)
        Me.Controls.SetChildIndex(Me.cbSettlement, 0)
        Me.Controls.SetChildIndex(Me.cbRayon, 0)
        Me.Controls.SetChildIndex(Me.cbRegion, 0)
        Me.Controls.SetChildIndex(Me.cbDefCountry, 0)
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDefCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_displayText As String = ""
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "Area.idfsCountry")
        Core.LookupBinder.BindCountryLookup(cbDefCountry, baseDataSet, "Area.idfsCountry")
        Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, "Area.idfsRegion")
        Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, "Area.idfsRayon")
        Core.LookupBinder.BindSettlementLookup(cbSettlement, baseDataSet, "Area.idfsSettlement")
        eventManager.AttachDataHandler("Area.idfsCountry", AddressOf Country_Changed)
        eventManager.AttachDataHandler("Area.idfsRegion", AddressOf Region_Changed)
        eventManager.AttachDataHandler("Area.idfsRayon", AddressOf Rayon_Changed)
        eventManager.AttachDataHandler("Area.idfsSettlement", AddressOf Settlement_Changed)
    End Sub
    Private Sub Country_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not CountryID.Equals(e.Value) Then
            CountryID = e.Value
        End If
        AreaChanged = True
        If Not RegionID Is DBNull.Value AndAlso _
            (CountryID Is DBNull.Value OrElse _
            CType(cbRegion.Properties.DataSource, DataView).Table.Select(String.Format("idfsCountry = {0} and idfsRegion = {1}", Utils.Str(CountryID), Utils.Str(RegionID))).Length = 0) Then
            RegionID = DBNull.Value
            eventManager.Cascade("Area.idfsRegion")
        ElseIf m_FirstInitialization Then
            AreaChanged = False
        End If
        Core.LookupBinder.FilterRegion(cbRegion, e.Value)

    End Sub

    Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not RegionID.Equals(e.Value) Then
            RegionID = e.Value
        End If
        AreaChanged = True
        If Not RayonID Is DBNull.Value AndAlso _
            (RegionID Is DBNull.Value OrElse _
            CType(cbRayon.Properties.DataSource, DataView).Table.Select(String.Format("idfsRegion = {0} and idfsRayon = {1}", Utils.Str(RegionID), Utils.Str(RayonID))).Length = 0) Then
            RayonID = DBNull.Value
            eventManager.Cascade("Area.idfsRayon")
        ElseIf m_FirstInitialization Then
            AreaChanged = False
        End If
        Core.LookupBinder.FilterRayon(cbRayon, e.Value)
    End Sub

    Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not RayonID.Equals(e.Value) Then
            RayonID = e.Value
        End If
        AreaChanged = True
        If Not SettlementID Is DBNull.Value AndAlso _
            (RayonID Is DBNull.Value OrElse _
            CType(cbSettlement.Properties.DataSource, DataView).Table.Select(String.Format("idfsRayon = {0} and idfsSettlement = {1}", Utils.Str(RayonID), Utils.Str(SettlementID))).Length = 0) Then
            SettlementID = DBNull.Value
            eventManager.Cascade("Area.idfsSettlement")
        ElseIf m_FirstInitialization Then
            AreaChanged = False
        End If
        Core.LookupBinder.FilterSettlement(cbSettlement, e.Value)
    End Sub
    Private Sub Settlement_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not SettlementID.Equals(e.Value) Then
            SettlementID = e.Value
        End If
        If m_FirstInitialization Then
            AreaChanged = False
        Else
            AreaChanged = True
        End If
    End Sub


    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides ReadOnly Property DisplayText() As String
        Get
            If IsDesignMode() OrElse Created = False OrElse Closing Then Return ""
            If Not Utils.IsEmpty(m_displayText) AndAlso (Not m_Update) AndAlso Not (HasChanges()) AndAlso (Not m_Cancel) Then
                Return m_displayText
            End If
            m_Update = False
            m_Cancel = False
            Select Case m_IDType
                Case StatisticAreaType.Country
                    m_displayText = CountryText
                Case StatisticAreaType.Region
                    m_displayText = RegionText
                Case StatisticAreaType.Rayon
                    If Utils.IsEmpty(RayonID) Then
                        m_displayText = ""
                    Else
                        m_displayText = String.Format("{0}, {1}", RegionText, RayonText)
                    End If
                Case StatisticAreaType.Settlement
                    If Utils.IsEmpty(SettlementID) Then
                        m_displayText = ""
                    Else
                        m_displayText = String.Format("{0}, {1}, {2}", RegionText, RayonText, SettlementText)
                    End If
            End Select
            Return m_displayText
        End Get
    End Property

    Private m_IDType As StatisticAreaType = StatisticAreaType.Country
    <Browsable(False), DefaultValue(StatisticAreaType.Country), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IDType() As StatisticAreaType
        Get
            If m_IDType = Nothing Then
                m_IDType = StatisticAreaType.Country
            End If
            Return m_IDType
        End Get
        Set(ByVal Value As StatisticAreaType)
            If Value = Nothing Then
                Value = StatisticAreaType.Country
            End If
            m_IDType = Value
            UpdateLayout()
        End Set
    End Property

    Private m_AreaValue As Object = DBNull.Value
    Private m_FirstInitialization As Boolean = True
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property AreaValue() As Object
        Get
            Return m_AreaValue
        End Get
        Set(ByVal Value As Object)
            m_AreaValue = Value
            Dim m_Type As StatisticAreaType = StatisticAreaType.Country
            Dim country As Object = DBNull.Value
            Dim region As Object = DBNull.Value
            Dim rayon As Object = DBNull.Value
            Dim settlement As Object = DBNull.Value
            AreaDbService.GetAreaInfo(m_AreaValue, country, region, rayon, settlement, m_Type)
            CountryID = country
            RegionID = region
            RayonID = rayon
            SettlementID = settlement
            If m_IDType <> m_Type Then
                AreaChanged = True
                If m_IDType <> StatisticAreaType.Country Then
                    CountryID = EIDSS.model.Core.EidssSiteContext.Instance.CountryID
                Else
                    CountryID = DBNull.Value
                End If
            End If
            If m_FirstInitialization Then
                AreaChanged = False
            End If
            RefreshDisplayText()
        End Set
    End Property

    Dim m_Update As Boolean
    Const BottomMargin As Integer = 24
    Const RightMargin As Integer = 8
    Private Sub UpdateLayout()
        m_Update = True
        CanSetLayout = False
        If (Not Parent Is Nothing) AndAlso TypeOf (Parent) Is StatisticDetail Then
            Width = CType(Parent, StatisticDetail).cbStatistic_Area_Type.Width
        End If
        UseParentBackColor = False
        lblCountry.Visible = False
        cbCountry.Visible = True
        SetMandatoryFieldVisible(cbCountry, True)
        Select Case m_IDType
            Case StatisticAreaType.Country
                UseParentBackColor = True
                lblDefCountry.Visible = False
                cbDefCountry.Visible = False
                lblRegion.Visible = False
                SetMandatoryFieldVisible(cbRegion, False)
                lblRayon.Visible = False
                SetMandatoryFieldVisible(cbRayon, False)
                lblSettlement.Visible = False
                SetMandatoryFieldVisible(cbSettlement, False)
                CanSetLayout = True
                LookupLayout = LookupFormLayout.Group
                Height = cbCountry.Height
                If (Not Parent Is Nothing) AndAlso TypeOf (Parent) Is StatisticDetail Then
                    Width = CType(Parent, StatisticDetail).cbStatistic_Area_Type.Width
                End If
                cbCountry.Width = Width
            Case StatisticAreaType.Region
                lblCountry.Visible = False
                SetMandatoryFieldVisible(cbCountry, False)
                lblDefCountry.Visible = True
                cbDefCountry.Visible = True
                lblRegion.Visible = True
                SetMandatoryFieldVisible(cbRegion, True)
                lblRayon.Visible = False
                SetMandatoryFieldVisible(cbRayon, False)
                lblSettlement.Visible = False
                SetMandatoryFieldVisible(cbSettlement, False)
                LookupLayout = LookupFormLayout.DropDownList
                CanSetLayout = True
                PopupEditHeight = cbRegion.Top + cbRegion.Height + BottomMargin
                cbDefCountry.Width = Width - cbDefCountry.Left - RightMargin
                cbRegion.Width = Width - cbRegion.Left - RightMargin
            Case StatisticAreaType.Rayon
                lblCountry.Visible = False
                SetMandatoryFieldVisible(cbCountry, False)
                lblDefCountry.Visible = True
                cbDefCountry.Visible = True
                lblRegion.Visible = True
                SetMandatoryFieldVisible(cbRegion, True)
                lblRayon.Visible = True
                SetMandatoryFieldVisible(cbRayon, True)
                lblSettlement.Visible = False
                SetMandatoryFieldVisible(cbSettlement, False)
                LookupLayout = LookupFormLayout.DropDownList
                CanSetLayout = True
                PopupEditHeight = cbRayon.Top + cbRayon.Height + BottomMargin
                cbDefCountry.Width = Width - cbDefCountry.Left - RightMargin
                cbRegion.Width = Width - cbRegion.Left - RightMargin
                cbRayon.Width = Width - cbRayon.Left - RightMargin
            Case StatisticAreaType.Settlement
                lblCountry.Visible = False
                SetMandatoryFieldVisible(cbCountry, False)
                lblDefCountry.Visible = True
                cbDefCountry.Visible = True
                lblRegion.Visible = True
                SetMandatoryFieldVisible(cbRegion, True)
                lblRayon.Visible = True
                SetMandatoryFieldVisible(cbRayon, True)
                lblSettlement.Visible = True
                SetMandatoryFieldVisible(cbSettlement, True)
                LookupLayout = LookupFormLayout.DropDownList
                CanSetLayout = True
                PopupEditHeight = cbSettlement.Top + cbSettlement.Height + BottomMargin
                cbDefCountry.Width = Width - cbDefCountry.Left - RightMargin
                cbRegion.Width = Width - cbRegion.Left - RightMargin
                cbRayon.Width = Width - cbRayon.Left - RightMargin
                cbSettlement.Width = Width - cbSettlement.Left - RightMargin
        End Select
    End Sub





    Public AreaChanged As Boolean

    Public Overrides Function HasChanges() As Boolean
        Return AreaChanged
    End Function

    Public Function GetAreaKey() As Object
        Dim AreaKey As Object = DBNull.Value
        Select Case m_IDType
            Case StatisticAreaType.Country
                AreaKey = CountryID
            Case StatisticAreaType.Region
                AreaKey = RegionID
            Case StatisticAreaType.Rayon
                AreaKey = RayonID
            Case StatisticAreaType.Settlement
                AreaKey = SettlementID
        End Select
        Return AreaKey
    End Function

    Dim m_LastCountry As Object = DBNull.Value
    Dim m_LastRegion As Object = DBNull.Value
    Dim m_LastRayon As Object = DBNull.Value
    Dim m_LastSettlement As Object = DBNull.Value

    Dim m_Cancel As Boolean
    Public Overrides Sub CancelChanges()
        m_Cancel = True
        CountryID = m_LastCountry
        RegionID = m_LastRegion
        RayonID = m_LastRayon
        SettlementID = m_LastSettlement
        If Utils.Str(GetAreaKey) = Utils.Str(m_AreaValue) Then
            AreaChanged = False
        End If
        RefreshDisplayText()
    End Sub

    Public Overrides Sub BeforePopup()
        m_AreaValue = Utils.Str(GetAreaKey())
        m_LastCountry = CountryID
        m_LastRegion = RegionID
        m_LastRayon = RayonID
        m_LastSettlement = SettlementID
        m_FirstInitialization = False
    End Sub
    Private Function GetValue(ByVal filedName As String) As Object
        If Not baseDataSet Is Nothing AndAlso baseDataSet.Tables.Contains("Area") AndAlso baseDataSet.Tables("Area").Rows.Count > 0 Then
            Return baseDataSet.Tables("Area").Rows(0)(filedName)
        Else
            Return DBNull.Value
        End If
    End Function

    Private Sub SetValue(ByVal value As Object, ByVal filedName As String)
        If Not baseDataSet Is Nothing AndAlso baseDataSet.Tables.Contains("Area") AndAlso baseDataSet.Tables("Area").Rows.Count > 0 Then
            baseDataSet.Tables("Area").Rows(0)(filedName) = value
        End If
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private Property CountryID() As Object
        Get
            Return GetValue("idfsCountry")
        End Get
        Set(ByVal value As Object)
            SetValue(value, "idfsCountry")
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property CountryText() As String
        Get
            Return LookupCache.GetLookupValue(CountryID, LookupTables.Country, "strCountryName")
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private Property RayonID() As Object
        Get
            Return GetValue("idfsRayon")
        End Get
        Set(ByVal value As Object)
            SetValue(value, "idfsRayon")
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property RayonText() As String
        Get
            Return LookupCache.GetLookupValue(RayonID, LookupTables.Rayon, "strRayonName")
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private Property RegionID() As Object
        Get
            Return GetValue("idfsRegion")
        End Get
        Set(ByVal value As Object)
            SetValue(value, "idfsRegion")
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property RegionText() As String
        Get
            Return LookupCache.GetLookupValue(RegionID, LookupTables.Region, "strRegionName")
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private Property SettlementID() As Object
        Get
            Return GetValue("idfsSettlement")
        End Get
        Set(ByVal value As Object)
            SetValue(value, "idfsSettlement")
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property SettlementText() As String
        Get
            Return LookupCache.GetLookupValue(SettlementID, LookupTables.Settlement, "strSettlementName")
        End Get
    End Property
End Class


