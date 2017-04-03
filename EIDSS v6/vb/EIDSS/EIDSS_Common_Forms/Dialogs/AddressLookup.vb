Imports System.ComponentModel
Imports bv.winclient.Core
Imports eidss.Dialogs
Imports eidss.model.Core
Imports EIDSS.model.Enums
Imports DevExpress.Utils
Imports bv.winclient.Core.TranslationTool

Public Class AddressLookup
    Inherits BaseLookupForm
    Dim AddressDbService As Address_DB
    Friend WithEvents lbForeignAddress As System.Windows.Forms.Label
    Friend WithEvents txtForeignAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents seLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents btnMAP As DevExpress.XtraEditors.SimpleButton
    Dim ControlPairs As New bv.common.win.LabelControlList
    Private Const ForeignAddressPairIndex As Integer = 7
    Private Const CoordinatesPairIndex As Integer = 8
    Private Const CountryPairIndex As Integer = 0
    Public Event AddressChanged As EventHandler
    Private Sub RaiseAddressChangeEvent()
        If Me.ID Is Nothing Then
            Return
        End If
        m_AddressChanged = True
        baseDataSet.Tables(0).Rows(0).EndEdit()
        RaiseEvent AddressChanged(Me, EventArgs.Empty)
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        DebugTimer.Start("AddressLookup Constructor")

        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AddressDbService = New Address_DB
        'AddHandler AddressDbService.OnBeforePost, AddressOf BeforePost
        AddHandler AddressDbService.OnAcceptChanges, AddressOf AcceptChanges
        DbService = AddressDbService
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblCountry, Me.cbCountry))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblRegion, Me.cbRegion))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblRayon, Me.cbRayon))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblSettlment, Me.cbSettlement))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblStreet, Me.cbStreet))
        If (eidss.model.Core.EidssSiteContext.Instance.IsUsaAddressFormat) Then
            ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblHouse, New Control() {Me.txtBuilding, Me.txtHouse, Me.txtApartment}))
            txtBuilding.TabIndex = 70
            txtHouse.TabIndex = 80
        Else
            ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblHouse, New Control() {Me.txtHouse, Me.txtBuilding, Me.txtApartment}))
            txtBuilding.TabIndex = 80
            txtHouse.TabIndex = 70
        End If
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblPostalCode, Me.cbPostalCode))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lbForeignAddress, Me.txtForeignAddress))
        ControlPairs.Add(New bv.common.win.LabelControlPair(Me.lblLongitude, New Control() {Me.seLongitude, seLatitude, btnMAP}))
        ControlPairs.CaptionWidth = Me.CaptionWidth
        AddHandler Application.Idle, AddressOf Idle
        UpdateHouseView(lblHouse.Left, lblHouse.Width, txtHouse.Left, txtApartment.Left + txtApartment.Width - txtHouse.Left)
        ControlPairs.Item(CoordinatesPairIndex).Visible = False
        ControlPairs.Item(ForeignAddressPairIndex).Visible = False
        ControlPairs.ForceUpdate()
        PersonalDataString = "*"
        DebugTimer.Stop()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            RemoveHandler Application.Idle, AddressOf Idle
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
    Friend WithEvents txtApartment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbStreet As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblRayon As System.Windows.Forms.Label
    Friend WithEvents lblSettlment As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbSettlement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblHouse As System.Windows.Forms.Label
    Friend WithEvents txtBuilding As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHouse As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPostalCode As System.Windows.Forms.Label
    Friend WithEvents cbPostalCode As DevExpress.XtraEditors.ComboBoxEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressLookup))
        Me.txtApartment = New DevExpress.XtraEditors.TextEdit()
        Me.cbStreet = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblRayon = New System.Windows.Forms.Label()
        Me.lblSettlment = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSettlement = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblHouse = New System.Windows.Forms.Label()
        Me.txtBuilding = New DevExpress.XtraEditors.TextEdit()
        Me.txtHouse = New DevExpress.XtraEditors.TextEdit()
        Me.lblPostalCode = New System.Windows.Forms.Label()
        Me.cbPostalCode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbForeignAddress = New System.Windows.Forms.Label()
        Me.txtForeignAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.seLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.seLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.btnMAP = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtApartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStreet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuilding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPostalCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtForeignAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AddressLookup), resources)
        'Form Is Localizable: True
        '
        'txtApartment
        '
        resources.ApplyResources(Me.txtApartment, "txtApartment")
        Me.txtApartment.Name = "txtApartment"
        Me.txtApartment.Properties.MaxLength = 254
        '
        'cbStreet
        '
        resources.ApplyResources(Me.cbStreet, "cbStreet")
        Me.cbStreet.Name = "cbStreet"
        Me.cbStreet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStreet.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
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
        'lblSettlment
        '
        resources.ApplyResources(Me.lblSettlment, "lblSettlment")
        Me.lblSettlment.Name = "lblSettlment"
        '
        'lblStreet
        '
        resources.ApplyResources(Me.lblStreet, "lblStreet")
        Me.lblStreet.Name = "lblStreet"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCountry.Properties.Columns"), resources.GetString("cbCountry.Properties.Columns1"), CType(resources.GetObject("cbCountry.Properties.Columns2"), Integer), CType(resources.GetObject("cbCountry.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbCountry.Properties.Columns4"), CType(resources.GetObject("cbCountry.Properties.Columns5"), Boolean), CType(resources.GetObject("cbCountry.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Tag = ""
        '
        'cbRegion
        '
        resources.ApplyResources(Me.cbRegion, "cbRegion")
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"), CType(resources.GetObject("cbRegion.Properties.Columns2"), Integer), CType(resources.GetObject("cbRegion.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRegion.Properties.Columns4"), CType(resources.GetObject("cbRegion.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRegion.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText")
        Me.cbRegion.Tag = ""
        '
        'cbRayon
        '
        resources.ApplyResources(Me.cbRayon, "cbRayon")
        Me.cbRayon.Name = "cbRayon"
        Me.cbRayon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRayon.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"), CType(resources.GetObject("cbRayon.Properties.Columns2"), Integer), CType(resources.GetObject("cbRayon.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbRayon.Properties.Columns4"), CType(resources.GetObject("cbRayon.Properties.Columns5"), Boolean), CType(resources.GetObject("cbRayon.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText")
        Me.cbRayon.Tag = ""
        '
        'cbSettlement
        '
        resources.ApplyResources(Me.cbSettlement, "cbSettlement")
        Me.cbSettlement.Name = "cbSettlement"
        Me.cbSettlement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSettlement.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSettlement.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlement.Properties.Columns"), resources.GetString("cbSettlement.Properties.Columns1"), CType(resources.GetObject("cbSettlement.Properties.Columns2"), Integer), CType(resources.GetObject("cbSettlement.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cbSettlement.Properties.Columns4"), CType(resources.GetObject("cbSettlement.Properties.Columns5"), Boolean), CType(resources.GetObject("cbSettlement.Properties.Columns6"), DevExpress.Utils.HorzAlignment))})
        Me.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText")
        Me.cbSettlement.Tag = ""
        '
        'lblHouse
        '
        resources.ApplyResources(Me.lblHouse, "lblHouse")
        Me.lblHouse.Name = "lblHouse"
        '
        'txtBuilding
        '
        resources.ApplyResources(Me.txtBuilding, "txtBuilding")
        Me.txtBuilding.Name = "txtBuilding"
        Me.txtBuilding.Properties.MaxLength = 254
        '
        'txtHouse
        '
        resources.ApplyResources(Me.txtHouse, "txtHouse")
        Me.txtHouse.Name = "txtHouse"
        Me.txtHouse.Properties.MaxLength = 254
        Me.txtHouse.Tag = ""
        '
        'lblPostalCode
        '
        resources.ApplyResources(Me.lblPostalCode, "lblPostalCode")
        Me.lblPostalCode.Name = "lblPostalCode"
        '
        'cbPostalCode
        '
        resources.ApplyResources(Me.cbPostalCode, "cbPostalCode")
        Me.cbPostalCode.Name = "cbPostalCode"
        Me.cbPostalCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPostalCode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbForeignAddress
        '
        resources.ApplyResources(Me.lbForeignAddress, "lbForeignAddress")
        Me.lbForeignAddress.Name = "lbForeignAddress"
        '
        'txtForeignAddress
        '
        resources.ApplyResources(Me.txtForeignAddress, "txtForeignAddress")
        Me.txtForeignAddress.Name = "txtForeignAddress"
        Me.txtForeignAddress.Properties.Appearance.Options.UseTextOptions = True
        Me.txtForeignAddress.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.txtForeignAddress.Properties.MaxLength = 200
        Me.txtForeignAddress.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtForeignAddress.UseOptimizedRendering = True
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'seLongitude
        '
        resources.ApplyResources(Me.seLongitude, "seLongitude")
        Me.seLongitude.Name = "seLongitude"
        Me.seLongitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLongitude.Properties.Mask.EditMask = resources.GetString("seLongitude.Properties.Mask.EditMask")
        Me.seLongitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLongitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLongitude.Properties.MaxValue = New Decimal(New Integer() {180, 0, 0, 0})
        Me.seLongitude.Properties.MinValue = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.seLongitude.Properties.ValidateOnEnterKey = True
        '
        'seLatitude
        '
        resources.ApplyResources(Me.seLatitude, "seLatitude")
        Me.seLatitude.Name = "seLatitude"
        Me.seLatitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLatitude.Properties.Mask.EditMask = resources.GetString("seLatitude.Properties.Mask.EditMask")
        Me.seLatitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLatitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLatitude.Properties.MaxValue = New Decimal(New Integer() {89, 0, 0, 0})
        Me.seLatitude.Properties.MinValue = New Decimal(New Integer() {89, 0, 0, -2147483648})
        '
        'btnMAP
        '
        resources.ApplyResources(Me.btnMAP, "btnMAP")
        Me.btnMAP.Image = CType(resources.GetObject("btnMAP.Image"), System.Drawing.Image)
        Me.btnMAP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMAP.Name = "btnMAP"
        '
        'AddressLookup
        '
        Me.Appearance.BackColor = CType(resources.GetObject("AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.Appearance.Options.UseBackColor = True
        Me.CanExpand = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.seLongitude)
        Me.Controls.Add(Me.seLatitude)
        Me.Controls.Add(Me.btnMAP)
        Me.Controls.Add(Me.txtForeignAddress)
        Me.Controls.Add(Me.lbForeignAddress)
        Me.Controls.Add(Me.lblPostalCode)
        Me.Controls.Add(Me.txtApartment)
        Me.Controls.Add(Me.cbStreet)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.lblRayon)
        Me.Controls.Add(Me.lblSettlment)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.cbCountry)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.cbRayon)
        Me.Controls.Add(Me.cbSettlement)
        Me.Controls.Add(Me.lblHouse)
        Me.Controls.Add(Me.txtBuilding)
        Me.Controls.Add(Me.txtHouse)
        Me.Controls.Add(Me.cbPostalCode)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.KeyFieldName = "idfGeoLocation"
        Me.LookupLayout = bv.common.win.LookupFormLayout.DropDownList
        Me.Name = "AddressLookup"
        Me.ObjectName = "Address"
        Me.PopupEditHeight = 200
        Me.PopupEditMinWidth = 400
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Address"
        Me.Controls.SetChildIndex(Me.cbPostalCode, 0)
        Me.Controls.SetChildIndex(Me.txtHouse, 0)
        Me.Controls.SetChildIndex(Me.txtBuilding, 0)
        Me.Controls.SetChildIndex(Me.lblHouse, 0)
        Me.Controls.SetChildIndex(Me.cbSettlement, 0)
        Me.Controls.SetChildIndex(Me.cbRayon, 0)
        Me.Controls.SetChildIndex(Me.cbRegion, 0)
        Me.Controls.SetChildIndex(Me.cbCountry, 0)
        Me.Controls.SetChildIndex(Me.lblStreet, 0)
        Me.Controls.SetChildIndex(Me.lblSettlment, 0)
        Me.Controls.SetChildIndex(Me.lblRayon, 0)
        Me.Controls.SetChildIndex(Me.lblRegion, 0)
        Me.Controls.SetChildIndex(Me.lblCountry, 0)
        Me.Controls.SetChildIndex(Me.cbStreet, 0)
        Me.Controls.SetChildIndex(Me.txtApartment, 0)
        Me.Controls.SetChildIndex(Me.lblPostalCode, 0)
        Me.Controls.SetChildIndex(Me.lbForeignAddress, 0)
        Me.Controls.SetChildIndex(Me.txtForeignAddress, 0)
        Me.Controls.SetChildIndex(Me.btnMAP, 0)
        Me.Controls.SetChildIndex(Me.seLatitude, 0)
        Me.Controls.SetChildIndex(Me.seLongitude, 0)
        Me.Controls.SetChildIndex(Me.lblLongitude, 0)
        CType(Me.txtApartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStreet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuilding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPostalCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtForeignAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub AppendString(ByVal sb As System.Text.StringBuilder, ByVal prefix As String, ByVal ParamArray txt() As Object)
        Dim text As String = ""
        For i As Integer = 0 To txt.Length - 1
            If Not txt(i) Is Nothing Then
                If text = "" Then
                    text = txt(i).ToString()
                Else
                    text += " " + txt(i).ToString()
                End If
            End If
        Next
        If text <> "" Then
            If sb.Length = 0 Then
                sb.Append(text)
            Else
                sb.Append(prefix)
                sb.Append("")
                sb.Append(text)
            End If
        End If
    End Sub

    Private m_displayText As String = ""
    Public Overrides ReadOnly Property DisplayText() As String
        Get
            If IsDesignMode() OrElse Created = False OrElse Closing Then Return ""
            If Not Utils.IsEmpty(m_displayText) AndAlso baseDataSet.Tables.Contains("Address") AndAlso baseDataSet.Tables("Address").GetChanges Is Nothing Then
                Return m_displayText
            End If
            Dim Country As String = ""
            Dim Region As String = ""
            Dim Rayon As String = ""
            Dim Settlement As String = ""
            Dim SettlementType As String = ""
            Dim ResidenceType As String = ""
            If baseDataSet.Tables.Contains("Address") AndAlso baseDataSet.Tables("Address").Rows.Count > 0 Then
                If (m_IsSettlementPrivate OrElse m_IsAddressPrivate) AndAlso Utils.IsEmpty(PersonalDataString) Then
                    m_displayText = ""
                    Return m_displayText
                End If
                Dim row As DataRow = baseDataSet.Tables("Address").Rows(0)
                If ShowContry Then
                    Country = LookupCache.GetLookupValue(row("idfsCountry"), LookupTables.Country.ToString(), "strCountryName")
                Else
                    Country = EIDSS.model.Core.EidssSiteContext.Instance.CountryName
                End If
                Region = LookupCache.GetLookupValue(row("idfsRegion"), LookupTables.Region.ToString(), "strRegionName")
                Rayon = LookupCache.GetLookupValue(row("idfsRayon"), LookupTables.Rayon.ToString(), "strRayonName")
                SettlementType = LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement.ToString(), "strSettlementType")
                If m_IsSettlementPrivate Then
                    Settlement = PersonalDataString
                Else
                    Settlement = LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement.ToString(), "strSettlementName")
                End If
                m_displayText = EIDSS_DbUtils.GetAddressString(Country, _
                    Region, _
                    Rayon, _
                     IIf(m_IsAddressPrivate OrElse m_IsSettlementPrivate, "", Utils.Str(row("strPostCode"))).ToString(), _
                    "", _
                    Settlement, _
                    IIf(m_IsAddressPrivate, IIf(m_IsSettlementPrivate, "", PersonalDataString).ToString(), Utils.Str(row("strStreetName"))).ToString(), _
                    IIf(m_IsAddressPrivate, "", Utils.Str(row("strHouse"))).ToString(), _
                    IIf(m_IsAddressPrivate, "", Utils.Str(row("strBuilding"))).ToString(), _
                    IIf(m_IsAddressPrivate, "", Utils.Str(row("strApartment"))).ToString(), ForeignAddressMode, Utils.Str("strForeignAddress"))
            End If
            Return m_displayText
        End Get
    End Property

    Dim OkToChangeAddress As Boolean = True

    Public Sub BindAddress()
        BeginUpdate()
        DefineBinding()
        EndUpdate()
    End Sub

    Private ReadOnly Property IsSearchMode() As Boolean
        Get
            Return ((Not Me.AddressDbService Is Nothing) AndAlso _
                    Utils.SEARCH_MODE_ID.Equals(Me.AddressDbService.ID)) OrElse _
                   Utils.SEARCH_MODE_ID.Equals(Me.ID)
        End Get
    End Property
    Private m_IsAddressPrivate As Boolean
    Private m_IsSettlementPrivate As Boolean

    <Browsable(False), DefaultValue(PersonalDataGroup.None), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IgnorePersonalData As Boolean
    Private m_HideMapButton As Boolean
    Protected Overrides Sub DefineBinding()
        OkToChangeAddress = True
        If Loading = False AndAlso (IsDesignMode() OrElse Created = False) Then Return
        BeginUpdate()
        Try
            If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
                ID = Nothing 'Load data for the new record
                Return
            End If
            Dim addressGroup As PersonalDataGroup = CalcAddressPersonalDataType()
            If addressGroup <> PersonalDataGroup.None Then
                Me.ReadOnly = True
            End If
            Core.LookupBinder.BindPersonalDataTextEdit(txtBuilding, baseDataSet, "Address.strBuilding", addressGroup, IgnorePersonalData, PersonalDataString)
            m_IsAddressPrivate = (txtBuilding.DataBindings.Count = 0)
            Core.LookupBinder.BindPersonalDataTextEdit(txtHouse, baseDataSet, "Address.strHouse", addressGroup, IgnorePersonalData, PersonalDataString)
            Core.LookupBinder.BindPersonalDataTextEdit(txtApartment, baseDataSet, "Address.strApartment", addressGroup, IgnorePersonalData, PersonalDataString)
            Core.LookupBinder.BindPersonalDataTextEdit(txtForeignAddress, baseDataSet, "Address.strForeignAddress", CalcForeignAddressPersonalDataType(), IgnorePersonalData, PersonalDataString)
            If baseDataSet.Tables("Address").Rows(0)("idfsCountry") Is DBNull.Value Then
                baseDataSet.Tables("Address").Rows(0)("idfsCountry") = EIDSS.model.Core.EidssSiteContext.Instance.CountryID
            End If
            If ShowContry Then
                Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "Address.idfsCountry", Not m_MandatoryFields >= AddressMandatoryFieldsType.Country)
            End If
            Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, "Address.idfsRegion")
            Core.LookupBinder.FilterRegion(cbRegion, baseDataSet.Tables("Address").Rows(0)("idfsCountry"))

            Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, "Address.idfsRayon")
            Dim currentRegionID As Object = baseDataSet.Tables("Address").Rows(0)("idfsRegion")
            If currentRegionID Is DBNull.Value Then
                cbRayon.Enabled = False
            Else
                cbRayon.Enabled = True
                Core.LookupBinder.FilterRayon(cbRayon, currentRegionID)
            End If

            Core.LookupBinder.BindPersonalDataSettlementLookup(cbSettlement, baseDataSet, CalcSettlementPersonalDataType(), IgnorePersonalData, "Address.idfsSettlement", PersonalDataString)
            m_IsSettlementPrivate = (cbSettlement.DataBindings.Count = 0)
            Dim currentRayonID As Object = baseDataSet.Tables("Address").Rows(0)("idfsRayon")
            If currentRayonID Is DBNull.Value Then
                cbSettlement.Enabled = False
            Else
                cbSettlement.Enabled = True
                Core.LookupBinder.FilterSettlement(cbSettlement, currentRayonID)
            End If
            btnMAP.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.GIS))
            Dim coordinatesGroup As PersonalDataGroup = CalcCordinatesPersonalDataType()
            Core.LookupBinder.BindPersonalDataSpinEdit(seLongitude, baseDataSet, "Address.dblLongitude", coordinatesGroup, IgnorePersonalData, -180, +180, True, , PersonalDataString)
            Core.LookupBinder.BindPersonalDataSpinEdit(seLatitude, baseDataSet, "Address.dblLatitude", coordinatesGroup, IgnorePersonalData, -89, +89, True, , PersonalDataString)
            If (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(coordinatesGroup)) Then
                btnMAP.Visible = False
                m_HideMapButton = True
            End If


            eventManager.AttachDataHandler("Address.idfsCountry", AddressOf Country_Changed)
            eventManager.AttachDataHandler("Address.idfsRegion", AddressOf Region_Changed)
            eventManager.AttachDataHandler("Address.idfsRayon", AddressOf Rayon_Changed)
            eventManager.AttachDataHandler("Address.idfsSettlement", AddressOf Settlement_Changed)
            m_displayText = ""
            eventManager.AttachDataHandler("Address.strBuilding", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.strHouse", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.strApartment", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.strStreetName", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.strPostCode", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.dblLongitude", AddressOf Address_Changed)
            eventManager.AttachDataHandler("Address.dblLatitude", AddressOf Address_Changed)
            eventManager.Cascade("Address.idfsSettlement")
            If ForeignAddressMode Then
                ForeignAddressMode = True 'explicitly hide unused cntrols
            End If
        Catch ex As Exception
            Throw
        Finally
            EndUpdate()
        End Try

    End Sub

    Private Function IsAllMandatoryFieldsFilled() As Boolean
        If baseDataSet Is Nothing OrElse Not baseDataSet.Tables.Contains("Address") OrElse baseDataSet.Tables("Address").Rows.Count < 0 Then
            Return True
        End If
        Dim row As DataRow = baseDataSet.Tables("Address").Rows(0)
        If MandatoryFields = AddressMandatoryFieldsType.Country AndAlso ShowContry Then
            Return Not Utils.IsEmpty(row("idfsCountry"))
        End If
        If MandatoryFields = AddressMandatoryFieldsType.Region Then
            Return Not Utils.IsEmpty(row("idfsCountry")) AndAlso Not Utils.IsEmpty(row("idfsRegion"))
        ElseIf MandatoryFields = AddressMandatoryFieldsType.Rayon Then
            Return Not Utils.IsEmpty(row("idfsCountry")) AndAlso Not Utils.IsEmpty(row("idfsRegion")) AndAlso Not Utils.IsEmpty(row("idfsRayon"))
        ElseIf MandatoryFields = AddressMandatoryFieldsType.Settlement Then
            Return Not Utils.IsEmpty(row("idfsCountry")) AndAlso Not Utils.IsEmpty(row("idfsRegion")) AndAlso Not Utils.IsEmpty(row("idfsRayon")) AndAlso Not Utils.IsEmpty(row("idfsSettlement"))
        End If
        Return True
    End Function

    Private m_LocationHelper As LocationHelper
    Private ReadOnly Property LocationHelper As LocationHelper
        Get
            If (m_LocationHelper Is Nothing) Then
                m_LocationHelper = New LocationHelper(baseDataSet.Tables("Address"), eventManager, Me.cbCountry)
            End If
            Return m_LocationHelper
        End Get
    End Property

    Private Sub btnMAP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMAP.Click
        Try
            LocationHelper.SetCaseLocation(seLongitude.Value, seLatitude.Value)
        Catch ex As Exception
            ErrorForm.ShowError(ex)
        End Try
    End Sub
    Public Sub UpdateAddress()
        If IsSearchMode() OrElse (baseDataSet Is Nothing) Then Return
        OkToChangeAddress = False
        eventManager.Cascade("Address.idfsCountry")
        OkToChangeAddress = False
        eventManager.Cascade("Address.idfsRegion")
    End Sub

    Private Sub Address_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        RaiseAddressChangeEvent()
    End Sub

    Private m_Updating As Boolean = False
    Private Sub Country_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not Loading Then baseDataSet.Tables("Address").Rows(0)("idfsCountry") = e.Value
        Dim currentCountryID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
        Dim currentRegionID As Object = baseDataSet.Tables("Address").Rows(0)("idfsRegion")
        If Not currentRegionID Is DBNull.Value AndAlso _
            CType(cbRegion.Properties.DataSource, DataView).Table.Select("idfsCountry = " + Utils.Str(currentCountryID) + " and idfsRegion = " + Utils.Str(currentRegionID)).Length = 0 Then
            baseDataSet.Tables("Address").Rows(0)("idfsRegion") = DBNull.Value
            baseDataSet.Tables("Address").Rows(0).EndEdit()
            eventManager.Cascade("Address.idfsRegion")
        End If
        If Utils.Str(currentCountryID) = "-1" Or ForeignAddressMode Then
            cbRegion.Enabled = False
        Else
            cbRegion.Enabled = True
            Core.LookupBinder.FilterRegion(cbRegion, currentCountryID)
        End If
        If OkToChangeAddress Then
            RaiseAddressChangeEvent()
        Else
            OkToChangeAddress = True
        End If
    End Sub

    Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        baseDataSet.Tables("Address").Rows(0)("idfsRegion") = e.Value
        DebugTimer.Start("Filling Rayons")
        Dim currentRegionID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
        DebugTimer.Stop()
        Dim currentRayonID As Object = baseDataSet.Tables("Address").Rows(0)("idfsRayon")
        If Not currentRayonID Is DBNull.Value AndAlso _
            CType(cbRayon.Properties.DataSource, DataView).Table.Select("idfsRegion = " + Utils.Str(currentRegionID) + " and idfsRayon = " + Utils.Str(currentRayonID)).Length = 0 Then
            baseDataSet.Tables("Address").Rows(0)("idfsRayon") = DBNull.Value
        End If
        baseDataSet.Tables("Address").Rows(0).EndEdit()
        eventManager.Cascade("Address.idfsRayon")
        If Utils.Str(currentRegionID) = "-1" Then
            cbRayon.Enabled = False
        Else
            cbRayon.Enabled = True
            Core.LookupBinder.FilterRayon(cbRayon, currentRegionID)
        End If
        If OkToChangeAddress Then
            RaiseAddressChangeEvent()
        Else
            OkToChangeAddress = True
        End If
    End Sub

    Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        baseDataSet.Tables("Address").Rows(0)("idfsRayon") = e.Value
        DebugTimer.Start("Filling Settlements")
        Dim currentRayonID As Object = IIf(e.Value Is DBNull.Value, -1, e.Value)
        DebugTimer.Stop()
        Dim currentSettlementID As Object = baseDataSet.Tables("Address").Rows(0)("idfsSettlement")
        If Not currentSettlementID Is DBNull.Value AndAlso _
            CType(cbSettlement.Properties.DataSource, DataView).Table.Select("idfsRayon = " + Utils.Str(currentRayonID) + " and idfsSettlement = " + Utils.Str(currentSettlementID)).Length = 0 Then
            baseDataSet.Tables("Address").Rows(0)("idfsSettlement") = DBNull.Value
            baseDataSet.Tables("Address").Rows(0).EndEdit()
            eventManager.Cascade("Address.idfsSettlement")
        End If
        If Utils.Str(currentRayonID) = "-1" Then
            cbSettlement.Enabled = False
        Else
            cbSettlement.Enabled = True
            Core.LookupBinder.FilterSettlement(cbSettlement, currentRayonID)
        End If
        If OkToChangeAddress Then
            RaiseAddressChangeEvent()
        Else
            OkToChangeAddress = True
        End If
    End Sub
    Private m_StreetLookupView As DataView
    Private m_PostalCodeLookupView As DataView
    <Browsable(False)> _
    Private ReadOnly Property StreetLookupView() As DataView
        Get
            If m_StreetLookupView Is Nothing Then
                m_StreetLookupView = LookupCache.Get(LookupTables.Street)
                If Not m_StreetLookupView Is Nothing Then
                    m_StreetLookupView.Sort = "strStreetName"
                Else
                    'dummy
                    Dim i As Integer = 0
                End If
            End If
            Return m_StreetLookupView
        End Get
    End Property
    <Browsable(False)> _
    Private ReadOnly Property PostalCodeLookupView() As DataView
        Get
            If m_PostalCodeLookupView Is Nothing Then
                m_PostalCodeLookupView = LookupCache.Get(LookupTables.PostalCode)
                If (Not m_PostalCodeLookupView Is Nothing) Then
                    m_PostalCodeLookupView.Sort = "strPostCode"
                Else
                    'dummy
                    Dim i As Integer = 0
                End If
            End If
            Return m_PostalCodeLookupView
        End Get
    End Property
    Private Sub Settlement_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not e.Value Is DBNull.Value Then
            If Not StreetLookupView Is Nothing Then
                StreetLookupView.RowFilter = String.Format("idfsSettlement = {0}", e.Value)
            End If
            If Not PostalCodeLookupView Is Nothing Then
                PostalCodeLookupView.RowFilter = String.Format("idfsSettlement = {0}", e.Value)
            End If
        Else
            If Not StreetLookupView Is Nothing Then
                StreetLookupView.RowFilter = "idfsSettlement = -1"
            End If
            If Not PostalCodeLookupView Is Nothing Then
                PostalCodeLookupView.RowFilter = "idfsSettlement = -1"
            End If
        End If
        If m_DataLoaded Then
            If Not StreetLookupView Is Nothing AndAlso StreetLookupView.Find(e.Row("strStreetName")) < 0 Then
                e.Row("strStreetName") = DBNull.Value
            End If
            If Not PostalCodeLookupView Is Nothing AndAlso PostalCodeLookupView.Find(e.Row("strPostCode")) < 0 Then
                e.Row("strPostCode") = DBNull.Value
            End If
            e.Row("strBuilding") = DBNull.Value
            e.Row("strHouse") = DBNull.Value
            e.Row("strApartment") = DBNull.Value
        End If
        e.Row.EndEdit()
        BindStreetLookup()
        BindPostalCodeLookup()
        If OkToChangeAddress Then
            RaiseAddressChangeEvent()
        Else
            OkToChangeAddress = True
        End If
    End Sub


    Sub BindStreetLookup()
        cbStreet.Properties.Items.Clear()
        If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(CalcAddressPersonalDataType()) Then
            Core.LookupBinder.BindPersonalDataContol(cbStreet, PersonalDataString)
            Return
        End If

        If Not StreetLookupView Is Nothing Then
            For Each dr As DataRowView In StreetLookupView
                cbStreet.Properties.Items.Add(dr("strStreetName"))
            Next
        End If
        Core.LookupBinder.BindTextEdit(cbStreet, baseDataSet, "Address.strStreetName")
    End Sub

    Private Sub BindPostalCodeLookup()
        cbPostalCode.Properties.Items.Clear()
        If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(CalcAddressPersonalDataType()) Then
            Core.LookupBinder.BindPersonalDataContol(cbPostalCode, PersonalDataString)
            Return
        End If
        If Not PostalCodeLookupView Is Nothing Then
            For Each dr As DataRowView In PostalCodeLookupView
                cbPostalCode.Properties.Items.Add(dr("strPostCode"))
            Next
        End If

        Core.LookupBinder.BindTextEdit(cbPostalCode, baseDataSet, "Address.strPostCode")
    End Sub

    Function GetDbValue(ByVal val As Object) As Object
        If val Is Nothing Then Return DBNull.Value
        Return val
    End Function

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Me.ReadOnly Then
            If cbRayon.Properties.Buttons.Count >= 2 Then
                cbRayon.Properties.Buttons(1).Enabled = (cbRayon.Properties.Buttons(1).Kind <> _
                                                         DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) OrElse _
                                                        ((Not Utils.IsEmpty(cbCountry.EditValue)) AndAlso _
                                                         (Not Utils.IsEmpty(cbRegion.EditValue)))
            End If
            Me.cbStreet.Enabled = Not Utils.IsEmpty(cbSettlement.EditValue)
            Me.cbPostalCode.Enabled = Not Utils.IsEmpty(cbSettlement.EditValue)
            Me.txtHouse.Enabled = Not Utils.IsEmpty(cbSettlement.EditValue)
            Me.txtBuilding.Enabled = Not Utils.IsEmpty(cbSettlement.EditValue)
            Me.txtApartment.Enabled = Not Utils.IsEmpty(cbSettlement.EditValue)
        End If
    End Sub

    Private Const m_DefCaptionWidth As Integer = 160
    Private m_CaptionWidth As Integer = m_DefCaptionWidth
    <Browsable(True), DefaultValue(m_DefCaptionWidth), Localizable(False)> _
    Public Property CaptionWidth() As Integer
        Get
            If m_CaptionWidth = 0 Then
                m_CaptionWidth = m_DefCaptionWidth
            End If
            Return m_CaptionWidth
        End Get
        Set(ByVal Value As Integer)
            If m_CaptionWidth = 0 Then
                m_CaptionWidth = m_DefCaptionWidth
            End If
            If Value <= 0 Then
                Value = m_DefCaptionWidth
            End If
            m_CaptionWidth = Value
            ControlPairs.CaptionWidth = m_CaptionWidth
            RecalcControlWidth()
            If Me.IsDesignMode() Then 'AndAlso Created
                UpdateLayout()
            End If
        End Set
    End Property

    Private m_ColumnCount As Integer = 1
    <Browsable(True), DefaultValue(1), Localizable(False)> _
    Public Property ColumnCount() As Integer
        Get
            If m_ColumnCount <= 0 Then
                m_ColumnCount = 1
            End If
            Return m_ColumnCount
        End Get
        Set(ByVal Value As Integer)
            If m_ColumnCount <= 0 Then
                m_ColumnCount = 1
            End If
            If Value <= 0 Then
                Value = 1
            End If
            m_ColumnCount = Value
            ControlPairs.ColumnsCount = m_ColumnCount
            RecalcControlWidth()
            If Me.IsDesignMode() Then 'AndAlso Created
                UpdateLayout()
            End If
        End Set
    End Property

    Private m_ShowContry As Boolean = True
    <Browsable(True), DefaultValue(True), Localizable(False)> _
    Public Property ShowContry() As Boolean
        Get
            Return m_ShowContry OrElse ForeignAddressMode
        End Get
        Set(ByVal Value As Boolean)
            m_ShowContry = Value
            If (ControlPairs.Count > 0) Then
                ControlPairs.Item(CountryPairIndex).Visible = Value
                ControlPairs.ForceUpdate()
            End If
        End Set
    End Property
    Private m_ShowCoordinates As Boolean = False
    <Browsable(True), DefaultValue(False), Localizable(False)> _
    Public Property ShowCoordinates() As Boolean
        Get
            Return m_ShowCoordinates
        End Get
        Set(ByVal value As Boolean)
            m_ShowCoordinates = value
            SetCoordinatesVisibility(value)
        End Set
    End Property
    Private Sub SetCoordinatesVisibility(value As Boolean)
        If (ControlPairs.Count > 0) Then
            ControlPairs.Item(CoordinatesPairIndex).Visible = value
            ControlPairs.ForceUpdate()
        End If
    End Sub

    Private Sub UpdateLayout()
        If m_Resizable Then
            ControlPairs.UpdateLayout()
        End If
    End Sub


    Private Sub RecalcControlWidth()
        If (Me.Width < (CaptionWidth + 100) * ColumnCount) AndAlso (m_Resizable = True) Then Return
        ControlPairs.ControlWidth = CInt((Width - ColumnCount * CaptionWidth + ControlPairs.ColumnsDistance * (ColumnCount - 1)) / ColumnCount) - 16

    End Sub
    Private Sub AddressLookup_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        RecalcControlWidth()
        If Me.IsDesignMode() AndAlso Created Then
            UpdateLayout()
        End If

    End Sub

    Private Sub Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateLayout()
    End Sub

    Dim m_AddressChanged As Boolean = False

    Public Overrides Function HasChanges() As Boolean
        Return m_AddressChanged
    End Function
    Private Sub AcceptChanges(ByVal sender As Object, ByVal e As EventArgs)
        If DbService.IsNewObject OrElse Not IsAllMandatoryFieldsFilled() Then
            m_AddressChanged = True
        Else
            m_AddressChanged = False
        End If
    End Sub

    'Public Overrides Function Post(Optional ByVal PostType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
    '    If MyBase.Post(PostType) Then
    '        m_AddressChanged = False
    '        Return True
    '    End If
    '    Return False
    'End Function
    Dim m_SavedAddressChanged As Boolean = False
    Public Overrides Sub FixCurrentData()
        m_SavedAddressChanged = m_AddressChanged
        MyBase.FixCurrentData()
    End Sub
    Public Overrides Sub CancelChanges()
        m_AddressChanged = m_SavedAddressChanged
        MyBase.CancelChanges()
    End Sub

    Private Sub UpdateCountryView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblCountry.Left = LabelLeft
        lblCountry.Width = LabelWidth
        cbCountry.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbCountry.Left = CtrlLeft
        cbCountry.Width = CtrlWidth
    End Sub

    Private Sub UpdateRegionView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblRegion.Left = LabelLeft
        lblRegion.Width = LabelWidth
        cbRegion.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbRegion.Left = CtrlLeft
        cbRegion.Width = CtrlWidth
    End Sub

    Private Sub UpdateRayonView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblRayon.Left = LabelLeft
        lblRayon.Width = LabelWidth
        cbRayon.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbRayon.Left = CtrlLeft
        cbRayon.Width = CtrlWidth
    End Sub

    Private Sub UpdateSettlementView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblSettlment.Left = LabelLeft
        lblSettlment.Width = LabelWidth
        cbSettlement.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbSettlement.Left = CtrlLeft
        cbSettlement.Width = CtrlWidth
    End Sub

    Private Sub UpdateStreetView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblStreet.Left = LabelLeft
        lblStreet.Width = LabelWidth
        cbStreet.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbStreet.Left = CtrlLeft
        cbStreet.Width = CtrlWidth
    End Sub

    Private Sub UpdatePostalCodeView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblPostalCode.Left = LabelLeft
        lblPostalCode.Width = LabelWidth
        cbPostalCode.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        cbPostalCode.Left = CtrlLeft
        cbPostalCode.Width = CtrlWidth
    End Sub

    Private Sub UpdateHouseView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblHouse.Left = LabelLeft
        lblHouse.Width = LabelWidth
        Dim TabIndex1 As Integer = txtBuilding.TabIndex
        Dim TabIndex2 As Integer = txtHouse.TabIndex

        If (EidssSiteContext.Instance.IsUsaAddressFormat) Then
            txtBuilding.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            txtBuilding.Left = CtrlLeft
            txtBuilding.Width = CInt(Math.Ceiling((CtrlWidth - 16) / 3))
            txtBuilding.TabIndex = Math.Min(TabIndex1, TabIndex2)
            txtHouse.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            txtHouse.Left = CtrlLeft + CInt(Math.Ceiling((CtrlWidth - 16) / 3)) + 8
            txtHouse.Width = CInt(Math.Ceiling((CtrlWidth - 16) / 3))
            txtHouse.TabIndex = Math.Max(TabIndex1, TabIndex2)
        Else
            txtHouse.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            txtHouse.Left = CtrlLeft
            txtHouse.Width = CInt(Math.Ceiling((CtrlWidth - 16) / 3))
            txtHouse.TabIndex = Math.Min(TabIndex1, TabIndex2)
            txtBuilding.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            txtBuilding.Left = CtrlLeft + CInt(Math.Ceiling((CtrlWidth - 16) / 3)) + 8
            txtBuilding.Width = CInt(Math.Ceiling((CtrlWidth - 16) / 3))
            txtBuilding.TabIndex = Math.Max(TabIndex1, TabIndex2)
        End If
        txtApartment.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        txtApartment.Left = CtrlLeft + 2 * CInt(Math.Ceiling((CtrlWidth - 16) / 3)) + 16
        txtApartment.Width = CtrlWidth - (2 * CInt(Math.Ceiling((CtrlWidth - 16) / 3)) + 16)
    End Sub
    Private Sub UpdateCoordinatesView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lblLongitude.Left = LabelLeft
        lblLongitude.Width = LabelWidth
        btnMAP.Width = 29
        seLongitude.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        seLongitude.Left = CtrlLeft
        seLongitude.Width = CInt(Math.Ceiling((CtrlWidth - btnMAP.Width) / 2))
        seLatitude.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        seLatitude.Width = seLongitude.Width
        seLatitude.Left = CtrlLeft + seLongitude.Width
        btnMAP.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        btnMAP.Left = seLatitude.Left + seLatitude.Width
    End Sub

    Private Sub UpdateLabelView(ByVal LabelAlignment As System.Drawing.ContentAlignment)
        If (ShowContry = True) Then
            lblCountry.TextAlign = LabelAlignment
        End If
        lblRegion.TextAlign = LabelAlignment
        lblRayon.TextAlign = LabelAlignment
        lblSettlment.TextAlign = LabelAlignment
        lblStreet.TextAlign = LabelAlignment
        lblPostalCode.TextAlign = LabelAlignment
        lblHouse.TextAlign = LabelAlignment
    End Sub
    Private Sub UpdateForeignAddressView(ByVal LabelLeft As Integer, ByVal LabelWidth As Integer, ByVal CtrlLeft As Integer, ByVal CtrlWidth As Integer)
        lbForeignAddress.Left = LabelLeft
        lbForeignAddress.Width = LabelWidth
        txtForeignAddress.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        txtForeignAddress.Left = CtrlLeft
        txtForeignAddress.Width = CtrlWidth
    End Sub

    Private m_Resizable As Boolean = True

    Public Sub UpdateView(ByVal lpWidth As Integer, ByVal lpHeight As Integer, ByVal LabelColLeft As ArrayList, ByVal LabelColWidth As ArrayList, ByVal CtrlColLeft As ArrayList, ByVal CtrlColWidth As ArrayList, ByVal LabelAlignment As System.Drawing.ContentAlignment)
        If (ControlPairs.Count = 0) Then
            Return
        End If

        m_Resizable = True
        If (Not LabelColLeft Is Nothing) AndAlso (LabelColLeft.Count >= m_ColumnCount) AndAlso _
           (Not LabelColWidth Is Nothing) AndAlso (LabelColWidth.Count >= m_ColumnCount) AndAlso _
           (Not CtrlColLeft Is Nothing) AndAlso (CtrlColLeft.Count >= m_ColumnCount) AndAlso _
           (Not CtrlColWidth Is Nothing) AndAlso (CtrlColWidth.Count >= m_ColumnCount) Then
            UpdateLayout()

            Dim i As Integer = 0
            While (i < m_ColumnCount) AndAlso _
                  (TypeOf (LabelColLeft(i)) Is Integer) AndAlso _
                  (TypeOf (LabelColWidth(i)) Is Integer) AndAlso _
                  (TypeOf (CtrlColLeft(i)) Is Integer) AndAlso _
                  (TypeOf (CtrlColWidth(i)) Is Integer)
                i = i + 1
            End While
            If (i = m_ColumnCount) Then
                m_Resizable = False
                Me.Width = lpWidth
                Me.Height = lpHeight
                UpdateLabelView(LabelAlignment)

                Dim LabelLeft As Integer = CInt(LabelColLeft(0))
                Dim LabelWidth As Integer = CInt(LabelColWidth(0))
                Dim CtrlLeft As Integer = CInt(CtrlColLeft(0))
                Dim CtrlWidth As Integer = CInt(CtrlColWidth(0))
                If Not bv.winclient.Core.WinUtils.IsComponentInDesignMode(Me) Then
                    If (ForeignAddressMode) Then
                        UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        lblCountry.Top = ControlPairs.Item(0).Label.Top
                        cbCountry.Top = ControlPairs.Item(0).Controls(0).Top
                        If ColumnCount > 1 Then
                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColLeft(ColumnCount - 1)) + CInt(CtrlColWidth(ColumnCount - 1)) - CInt(CtrlColLeft(1))
                            lbForeignAddress.Top = ControlPairs.Item(0).Label.Top
                            txtForeignAddress.Top = ControlPairs.Item(0).Controls(0).Top
                        Else
                            lbForeignAddress.Top = ControlPairs.Item(CountryPairIndex).Label.Top
                            txtForeignAddress.Top = ControlPairs.Item(CountryPairIndex).Controls(0).Top
                        End If
                        UpdateForeignAddressView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Return
                    End If
                Else
                End If
                If (ShowContry = True) Then
                    Select Case m_ColumnCount
                        Case 1
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                        Case 2
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                        Case 3
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case 4
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                        Case 5
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(4))
                            LabelWidth = CInt(LabelColWidth(4))
                            CtrlLeft = CInt(CtrlColLeft(4))
                            CtrlWidth = CInt(CtrlColWidth(4))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case 6
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(4))
                            LabelWidth = CInt(LabelColWidth(4))
                            CtrlLeft = CInt(CtrlColLeft(4))
                            CtrlWidth = CInt(CtrlColWidth(4))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(5))
                            LabelWidth = CInt(LabelColWidth(5))
                            CtrlLeft = CInt(CtrlColLeft(5))
                            CtrlWidth = CInt(CtrlColWidth(5))
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case Else
                            UpdateCountryView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(4))
                            LabelWidth = CInt(LabelColWidth(4))
                            CtrlLeft = CInt(CtrlColLeft(4))
                            CtrlWidth = CInt(CtrlColWidth(4))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(5))
                            LabelWidth = CInt(LabelColWidth(5))
                            CtrlLeft = CInt(CtrlColLeft(5))
                            CtrlWidth = CInt(CtrlColWidth(5))
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(6))
                            LabelWidth = CInt(LabelColWidth(6))
                            CtrlLeft = CInt(CtrlColLeft(6))
                            CtrlWidth = CInt(CtrlColWidth(6))
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            LabelLeft = CInt(LabelColLeft(7))
                            LabelWidth = CInt(LabelColWidth(7))
                            CtrlLeft = CInt(CtrlColLeft(7))
                            CtrlWidth = CInt(CtrlColWidth(7))
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                    End Select
                ElseIf (ShowContry = False) Then
                    Select Case m_ColumnCount
                        Case 1
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                        Case 2
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case 3
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                        Case 4
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case 5
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(4))
                            LabelWidth = CInt(LabelColWidth(4))
                            CtrlLeft = CInt(CtrlColLeft(4))
                            CtrlWidth = CInt(CtrlColWidth(4))
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                        Case Else
                            UpdateRegionView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(1))
                            LabelWidth = CInt(LabelColWidth(1))
                            CtrlLeft = CInt(CtrlColLeft(1))
                            CtrlWidth = CInt(CtrlColWidth(1))
                            UpdateRayonView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(2))
                            LabelWidth = CInt(LabelColWidth(2))
                            CtrlLeft = CInt(CtrlColLeft(2))
                            CtrlWidth = CInt(CtrlColWidth(2))
                            UpdateSettlementView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(3))
                            LabelWidth = CInt(LabelColWidth(3))
                            CtrlLeft = CInt(CtrlColLeft(3))
                            CtrlWidth = CInt(CtrlColWidth(3))
                            UpdateStreetView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(4))
                            LabelWidth = CInt(LabelColWidth(4))
                            CtrlLeft = CInt(CtrlColLeft(4))
                            CtrlWidth = CInt(CtrlColWidth(4))
                            UpdateHouseView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)

                            LabelLeft = CInt(LabelColLeft(5))
                            LabelWidth = CInt(LabelColWidth(5))
                            CtrlLeft = CInt(CtrlColLeft(5))
                            CtrlWidth = CInt(CtrlColWidth(5))
                            UpdatePostalCodeView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            LabelLeft = CInt(LabelColLeft(6))
                            LabelWidth = CInt(LabelColWidth(6))
                            CtrlLeft = CInt(CtrlColLeft(6))
                            CtrlWidth = CInt(CtrlColWidth(6))
                            If ShowCoordinates Then
                                UpdateCoordinatesView(LabelLeft, LabelWidth, CtrlLeft, CtrlWidth)
                            End If
                    End Select
                End If
            End If
        End If
    End Sub

    Private Function IsCorrectValue(ByVal val As Object) As Boolean
        Return (val Is DBNull.Value) OrElse (TypeOf (val) Is Long)
    End Function

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property AddressRow() As DataRow
        Get
            If Not baseDataSet.Tables Is Nothing AndAlso baseDataSet.Tables.Contains("Address") AndAlso baseDataSet.Tables("Address").Rows.Count > 0 Then
                Return baseDataSet.Tables("Address").Rows(0)
            End If
            Return Nothing
        End Get
    End Property

    Private Sub AssignValue(ByVal fieldName As String, ByVal value As Object)
        If IsCorrectValue(value) AndAlso Not AddressRow Is Nothing Then
            AddressRow(fieldName) = value
            eventManager.Cascade("Address." + fieldName)
        End If

    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property CountryID() As Object
        Get
            If ShowContry AndAlso (Not cbCountry Is Nothing) Then Return cbCountry.EditValue
            If IsDesignMode() Or Created = False OrElse Closing Then _
                Return DBNull.Value
            Return EIDSS.model.Core.EidssSiteContext.Instance.CountryID
        End Get
        Set(ByVal value As Object)
            If ShowContry Then
                AssignValue("idfsCountry", value)
            End If
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ForeignAddress() As Object
        Get
            If IsDesignMode() Or Created = False OrElse Closing Then _
                Return DBNull.Value
            If ForeignAddressMode AndAlso Not txtForeignAddress Is Nothing Then Return txtForeignAddress.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If ForeignAddressMode Then
                AssignValue("txtForeignAddress", value)
            End If
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property RegionID() As Object
        Get
            If (Not cbRegion Is Nothing) Then Return cbRegion.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            AssignValue("idfsRegion", value)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property RayonID() As Object
        Get
            If (Not cbRayon Is Nothing) Then Return cbRayon.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            AssignValue("idfsRayon", value)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SettlementID() As Object
        Get
            If (Not cbSettlement Is Nothing) Then Return cbSettlement.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            AssignValue("idfsSettlement", value)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Street() As Object
        Get
            If (Not cbStreet Is Nothing) Then Return cbStreet.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If IsCorrectValue(value) AndAlso (Not cbStreet Is Nothing) Then cbStreet.EditValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property PostalCode() As Object
        Get
            If (Not cbPostalCode Is Nothing) Then Return cbPostalCode.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If IsCorrectValue(value) AndAlso (Not cbPostalCode Is Nothing) Then cbPostalCode.EditValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property House() As Object
        Get
            If (Not txtHouse Is Nothing) Then Return txtHouse.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If IsCorrectValue(value) AndAlso (Not txtHouse Is Nothing) Then txtHouse.EditValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Building() As Object
        Get
            If (Not txtBuilding Is Nothing) Then Return txtBuilding.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If IsCorrectValue(value) AndAlso (Not txtBuilding Is Nothing) Then txtBuilding.EditValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Apartment() As Object
        Get
            If (Not txtApartment Is Nothing) Then Return txtApartment.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If IsCorrectValue(value) AndAlso (Not txtApartment Is Nothing) Then txtApartment.EditValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Longitude() As Object
        Get
            If (Not seLongitude Is Nothing) Then Return seLongitude.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If (Not seLongitude Is Nothing) Then seLongitude.EditValue = value
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Latitude() As Object
        Get
            If (Not seLatitude Is Nothing) Then Return seLatitude.EditValue
            Return DBNull.Value
        End Get
        Set(ByVal value As Object)
            If (Not seLatitude Is Nothing) Then seLatitude.EditValue = value
        End Set
    End Property
    Private m_MandatoryFields As AddressMandatoryFieldsType = AddressMandatoryFieldsType.None
    <Browsable(True), DefaultValue(AddressMandatoryFieldsType.None)> _
    Public Property MandatoryFields() As AddressMandatoryFieldsType
        Get
            Return m_MandatoryFields
        End Get
        Set(ByVal value As AddressMandatoryFieldsType)
            m_MandatoryFields = value
            cbCountry.Tag = Nothing
            cbRegion.Tag = Nothing
            cbRayon.Tag = Nothing
            cbSettlement.Tag = Nothing
            If m_MandatoryFields >= AddressMandatoryFieldsType.Country Then
                If ShowContry Then
                    cbCountry.Tag = "{M}"
                    ApplyControlState(cbCountry, ControlState.Mandatory)
                    If (Not cbCountry.Properties.DataSource Is Nothing) Then
                        Core.LookupBinder.RemoveEmptyRow(CType(cbCountry.Properties.DataSource, DataView))
                    End If
                    'Me.ApplyStyle(cbCountry)
                End If
            End If
            If m_MandatoryFields >= AddressMandatoryFieldsType.Region Then
                cbRegion.Tag = "{M}"
                ApplyControlState(cbRegion, ControlState.Mandatory)
                'Me.ApplyStyle(cbRegion)
            End If
            If m_MandatoryFields >= AddressMandatoryFieldsType.Rayon Then
                cbRayon.Tag = "{M}"
                ApplyControlState(cbRayon, ControlState.Mandatory)
                'Me.ApplyStyle(cbRayon)
            End If
            If m_MandatoryFields >= AddressMandatoryFieldsType.Settlement Then
                cbSettlement.Tag = "{M}"
                ApplyControlState(cbSettlement, ControlState.Mandatory)
                'Me.ApplyStyle(cbSettlement)
            End If
            m_AddressChanged = DbService.IsNewObject OrElse Not IsAllMandatoryFieldsFilled()
        End Set
    End Property
    Private m_IsSharedAddress As Boolean = False
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IsSharedAddress As Boolean
        Get
            Return m_IsSharedAddress
        End Get
        Set(ByVal value As Boolean)
            m_IsSharedAddress = value
            AddressDbService.IsSharedAddress = value
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ForeignAddressMode As Boolean
        Get
            If Not AddressRow Is Nothing Then
                If AddressRow("blnForeignAddress") Is DBNull.Value Then
                    Return False
                End If
                Return CBool(AddressRow("blnForeignAddress"))
            End If
            Return False
        End Get
        Set(ByVal value As Boolean)
            If Not AddressRow Is Nothing AndAlso Not value.Equals(AddressRow("blnForeignAddress")) Then
                AddressRow("blnForeignAddress") = value
                RaiseAddressChangeEvent()
            End If
            If Not value Then
                lblCountry.Visible = ShowContry
                cbCountry.Visible = ShowContry
                If Not AddressRow Is Nothing AndAlso Not AddressRow("idfsCountry").Equals(EidssSiteContext.Instance.CountryID) Then
                    AddressRow("idfsCountry") = EidssSiteContext.Instance.CountryID
                End If
            Else
                lblCountry.Visible = True
                cbCountry.Visible = True
                If (AddressRow("idfsCountry").Equals(EidssSiteContext.Instance.CountryID)) Then
                    AddressRow("idfsCountry") = DBNull.Value
                End If
                Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "Address.idfsCountry", Not AddressRow("idfsCountry") Is DBNull.Value AndAlso Not m_MandatoryFields >= AddressMandatoryFieldsType.Country)
            End If
            For i As Integer = 0 To ControlPairs.Count - 1
                If (i = ForeignAddressPairIndex) Then
                    ControlPairs.Item(i).Visible = value
                ElseIf i = CountryPairIndex Then
                    ControlPairs.Item(i).Visible = value Or ShowContry
                ElseIf i = CoordinatesPairIndex Then
                    SetCoordinatesVisibility((Not value) AndAlso ShowCoordinates)
                Else
                    ControlPairs.Item(i).Visible = Not value
                End If
            Next
            lbForeignAddress.Visible = value
            txtForeignAddress.Visible = value

            lblHouse.Visible = Not value
            txtApartment.Visible = Not value
            txtBuilding.Visible = Not value
            txtHouse.Visible = Not value

            lblPostalCode.Visible = Not value
            cbPostalCode.Visible = Not value
            lblRayon.Visible = Not value
            cbRayon.Visible = Not value
            lblRegion.Visible = Not value
            cbRegion.Visible = Not value
            lblSettlment.Visible = Not value
            cbSettlement.Visible = Not value
            lblStreet.Visible = Not value
            cbStreet.Visible = Not value
            UpdateLayout()
            If (MultilineAddress) Then
                txtForeignAddress.Height = Height - txtForeignAddress.Top - 4
            Else
                txtForeignAddress.Height = txtApartment.Height
            End If
            If Not AddressRow Is Nothing Then
                eventManager.Cascade("Address.idfsCountry")
            End If
            'lblLongitude.Visible = Not value
            'lblLongitude.Visible = Not value
            'btnMAP.Visible = Not value
            'seLongitude.Visible = Not value
            'seLatitude.Visible = Not value

        End Set
    End Property
    Private m_MultilineAddress As Boolean = False
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(False)> _
    Public Property MultilineAddress As Boolean
        Get
            Return m_MultilineAddress
        End Get
        Set(value As Boolean)
            m_MultilineAddress = value
            If value Then
                txtForeignAddress.Properties.Appearance.TextOptions.WordWrap = WordWrap.Wrap
            Else
                txtForeignAddress.Properties.Appearance.TextOptions.WordWrap = WordWrap.NoWrap
            End If
        End Set
    End Property



    Public Overrides Function ValidateData() As Boolean
        If Not m_AddressChanged Then
            Return True
        End If
        If Not MyBase.ValidateData() Then
            Return False
        End If
        If ShowCoordinates AndAlso Not AddressRow Is Nothing AndAlso Not LocationHelper.ValidateAddressCoordinates(AddressRow("dblLatitude"), AddressRow("dblLongitude")) Then
            If Utils.IsEmpty(AddressRow("dblLatitude")) Then
                FocusOnField(seLatitude)
            Else
                FocusOnField(seLongitude)
            End If
            Return False
        End If
        Return True
    End Function
    Public Overrides Property [ReadOnly] As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(value As Boolean)
            MyBase.ReadOnly = value
            If value = True OrElse m_HideMapButton Then
                btnMAP.Visible = False
            Else
                btnMAP.Visible = ShowCoordinates AndAlso Not ForeignAddressMode
            End If
        End Set
    End Property


    <Browsable(False), DefaultValue(PersonalDataGroup.None), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), CLSCompliant(False)> _
    Public Property PersonalDataTypes As PersonalDataGroup()
    <Browsable(False), DefaultValue("*"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property PersonalDataString As String

    Private Function CalcAddressPersonalDataType() As PersonalDataGroup
        If (PersonalDataTypes Is Nothing OrElse IgnorePersonalData) Then Return PersonalDataGroup.None
        For Each group As PersonalDataGroup In PersonalDataTypes
            If (group = PersonalDataGroup.Human_CurrentResidence_Settlement _
               OrElse group = PersonalDataGroup.Human_CurrentResidence_Details _
               OrElse group = PersonalDataGroup.Human_PermanentResidence_Details _
               OrElse group = PersonalDataGroup.Human_PermanentResidence_Settlement _
               OrElse group = PersonalDataGroup.Human_Employer_Details _
               OrElse group = PersonalDataGroup.Human_Employer_Settlement _
               OrElse group = PersonalDataGroup.Vet_Farm_Details _
               OrElse group = PersonalDataGroup.Vet_Farm_Settlement _
               ) Then
                If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                    Return group
                End If
            End If
        Next
        Return PersonalDataGroup.None
    End Function
    Private Function CalcSettlementPersonalDataType() As PersonalDataGroup
        If (PersonalDataTypes Is Nothing OrElse IgnorePersonalData) Then Return PersonalDataGroup.None
        For Each group As PersonalDataGroup In PersonalDataTypes
            If (group = PersonalDataGroup.Human_CurrentResidence_Settlement _
               OrElse group = PersonalDataGroup.Human_PermanentResidence_Settlement _
               OrElse group = PersonalDataGroup.Human_Employer_Settlement _
               OrElse group = PersonalDataGroup.Vet_Farm_Settlement _
               ) Then
                If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                    Return group
                End If
            End If
        Next
        Return PersonalDataGroup.None
    End Function
    Private Function CalcForeignAddressPersonalDataType() As PersonalDataGroup
        If (PersonalDataTypes Is Nothing OrElse IgnorePersonalData) Then Return PersonalDataGroup.None
        For Each group As PersonalDataGroup In PersonalDataTypes
            If (group = PersonalDataGroup.Human_PermanentResidence_Details _
               OrElse group = PersonalDataGroup.Human_PermanentResidence_Settlement _
               ) Then
                If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                    Return group
                End If
            End If
        Next
        Return PersonalDataGroup.None
    End Function

    Private Function CalcCordinatesPersonalDataType() As PersonalDataGroup
        If (PersonalDataTypes Is Nothing OrElse IgnorePersonalData) Then Return PersonalDataGroup.None
        For Each group As PersonalDataGroup In PersonalDataTypes
            If (group = PersonalDataGroup.Human_PermanentResidence_Coordinates _
               OrElse group = PersonalDataGroup.Human_CurrentResidence_Coordinates _
               ) Then
                If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                    Return group
                End If
            End If
        Next
        Return PersonalDataGroup.None
    End Function

    Private Function CopyValue(source As DataRow, dest As DataRow, fieldName As String) As Boolean
        If (Not source(fieldName).Equals(dest(fieldName))) Then
            dest(fieldName) = source(fieldName)
            Return True
        End If
        Return False
    End Function
    Public Sub Clear()
        Dim row As DataRow = AddressRow
        If row Is Nothing Then
            Return
        End If
        row("idfsRegion") = DBNull.Value
        row("idfsRayon") = DBNull.Value
        row("idfsSettlement") = DBNull.Value
        row("strStreetName") = DBNull.Value
        row("strPostCode") = DBNull.Value
        row("strApartment") = DBNull.Value
        row("strBuilding") = DBNull.Value
        row("strHouse") = DBNull.Value
        row("strAddressStringTranslate") = DBNull.Value
        row("strAddressDefaultString") = DBNull.Value
        row("dblLatitude") = DBNull.Value
        row("dblLongitude") = DBNull.Value
        row("blnForeignAddress") = DBNull.Value
        row("strForeignAddress") = DBNull.Value
        row("strAddressStringTranslate") = DBNull.Value
        row("strAddressDefaultString") = DBNull.Value
        row.EndEdit()
        If (LookupLayout = LookupFormLayout.DropDownList) Then
            RefreshDisplayText()
        End If
    End Sub
    Public Function CopyAddress(sourceAddress As AddressLookup) As Boolean
        Dim source As DataRow = sourceAddress.AddressRow
        Dim dest As DataRow = AddressRow
        If Not m_DataLoaded OrElse Loading OrElse source Is Nothing OrElse dest Is Nothing Then
            Return False
        End If
        m_DataLoaded = False
        dest.BeginEdit()
        Dim result As Boolean = False
        result = result Or CopyValue(source, dest, "idfsCountry")
        result = result Or CopyValue(source, dest, "idfsRegion")
        result = result Or CopyValue(source, dest, "idfsRayon")
        result = result Or CopyValue(source, dest, "idfsSettlement")
        result = result Or CopyValue(source, dest, "strStreetName")
        result = result Or CopyValue(source, dest, "strPostCode")
        result = result Or CopyValue(source, dest, "strApartment")
        result = result Or CopyValue(source, dest, "strBuilding")
        result = result Or CopyValue(source, dest, "strHouse")
        result = result Or CopyValue(source, dest, "strAddressStringTranslate")
        result = result Or CopyValue(source, dest, "strAddressDefaultString")
        result = result Or CopyValue(source, dest, "dblLatitude")
        result = result Or CopyValue(source, dest, "dblLongitude")
        dest.EndEdit()
        If result Then
            DataEventManager.Flush()
            eventManager.Cascade("Address.idfsSettlement")
        End If
        If (LookupLayout = LookupFormLayout.DropDownList) Then
            RefreshDisplayText()
        End If
        m_DataLoaded = True
        Return result
    End Function
    Public Overrides Function GetDesignTypeForComponent(component As Component) As DesignElement
        Dim de As DesignElement = MyBase.GetDesignTypeForComponent(component)
        If (de And DesignElement.Caption) <> 0 Then
            Return DesignElement.Caption
        End If
        Return DesignElement.None
    End Function

End Class
