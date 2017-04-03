Imports eidss.model.Resources

Public Class SettlementDetail
    Inherits BaseDetailForm

    Protected SettlementDBSetvice As Settlement_DB
    Protected ID As Object
    Protected m_CountryID As Object
    Protected m_RegionID As Object
    Friend WithEvents bMap As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUniqueCode As DevExpress.XtraEditors.TextEdit
    Protected m_RayonID As Object

    Public Sub New(ByVal SettlementID As Object, Optional ByVal CountryID As Object = Nothing, Optional ByVal RegionID As Object = Nothing, Optional ByVal RayonID As Object = Nothing)
        Me.New()
        Me.ID = SettlementID
        Me.m_CountryID = CountryID
        Me.m_RegionID = RegionID
        Me.m_RayonID = RayonID
    End Sub

    Public ReadOnly Property CountryID() As Object
        Get
            Return Me.m_CountryID
        End Get
    End Property

    Public ReadOnly Property RegionID() As Object
        Get
            Return Me.m_RegionID
        End Get
    End Property

    Public ReadOnly Property RayonID() As Object
        Get
            Return Me.m_RayonID
        End Get
    End Property

#Region " Windows Form Designer generated code "



    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SettlementDBSetvice = New Settlement_DB
        DbService = SettlementDBSetvice
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoSettlement, AuditTable.gisBaseReference)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.GisReference
        'lbNationalName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        LookupTableNames = New String() {"Settlement"}


    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSettlementType As System.Windows.Forms.Label
    Friend WithEvents cbSettlementType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents seLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents seLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtSettlementNameDef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSettlementNameNat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grpSettlementName As System.Windows.Forms.GroupBox
    Friend WithEvents lnEnglishName As System.Windows.Forms.Label
    Friend WithEvents lbNationalName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettlementDetail))
        Me.lnEnglishName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSettlementNameDef = New DevExpress.XtraEditors.TextEdit()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSettlementType = New System.Windows.Forms.Label()
        Me.cbSettlementType = New DevExpress.XtraEditors.LookUpEdit()
        Me.seLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.seLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lbNationalName = New System.Windows.Forms.Label()
        Me.txtSettlementNameNat = New DevExpress.XtraEditors.TextEdit()
        Me.grpSettlementName = New System.Windows.Forms.GroupBox()
        Me.bMap = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUniqueCode = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtSettlementNameDef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlementType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSettlementNameNat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettlementName.SuspendLayout()
        CType(Me.txtUniqueCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnEnglishName
        '
        resources.ApplyResources(Me.lnEnglishName, "lnEnglishName")
        Me.lnEnglishName.Name = "lnEnglishName"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtSettlementNameDef
        '
        resources.ApplyResources(Me.txtSettlementNameDef, "txtSettlementNameDef")
        Me.txtSettlementNameDef.Name = "txtSettlementNameDef"
        Me.txtSettlementNameDef.Properties.MaxLength = 255
        Me.txtSettlementNameDef.Tag = "{M}[en]"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCountry.Properties.Columns"), resources.GetString("cbCountry.Properties.Columns1"))})
        Me.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText")
        Me.cbCountry.Tag = "{M}"
        '
        'cbRegion
        '
        resources.ApplyResources(Me.cbRegion, "cbRegion")
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"))})
        Me.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText")
        Me.cbRegion.Tag = "{M}"
        '
        'cbRayon
        '
        resources.ApplyResources(Me.cbRayon, "cbRayon")
        Me.cbRayon.Name = "cbRayon"
        Me.cbRayon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRayon.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRayon.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"))})
        Me.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText")
        Me.cbRayon.Tag = "{M}"
        '
        'lblSettlementType
        '
        resources.ApplyResources(Me.lblSettlementType, "lblSettlementType")
        Me.lblSettlementType.Name = "lblSettlementType"
        '
        'cbSettlementType
        '
        resources.ApplyResources(Me.cbSettlementType, "cbSettlementType")
        Me.cbSettlementType.Name = "cbSettlementType"
        Me.cbSettlementType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSettlementType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSettlementType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlementType.Properties.Columns"), resources.GetString("cbSettlementType.Properties.Columns1"))})
        Me.cbSettlementType.Properties.NullText = resources.GetString("cbSettlementType.Properties.NullText")
        Me.cbSettlementType.Tag = "{M}"
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
        Me.seLongitude.Tag = "{M}"
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'lblLatitude
        '
        resources.ApplyResources(Me.lblLatitude, "lblLatitude")
        Me.lblLatitude.Name = "lblLatitude"
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
        Me.seLatitude.Properties.MaxValue = New Decimal(New Integer() {90, 0, 0, 0})
        Me.seLatitude.Properties.MinValue = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.seLatitude.Tag = "{M}"
        '
        'lbNationalName
        '
        resources.ApplyResources(Me.lbNationalName, "lbNationalName")
        Me.lbNationalName.Name = "lbNationalName"
        '
        'txtSettlementNameNat
        '
        resources.ApplyResources(Me.txtSettlementNameNat, "txtSettlementNameNat")
        Me.txtSettlementNameNat.Name = "txtSettlementNameNat"
        Me.txtSettlementNameNat.Properties.MaxLength = 255
        '
        'grpSettlementName
        '
        resources.ApplyResources(Me.grpSettlementName, "grpSettlementName")
        Me.grpSettlementName.Controls.Add(Me.txtSettlementNameDef)
        Me.grpSettlementName.Controls.Add(Me.txtSettlementNameNat)
        Me.grpSettlementName.Controls.Add(Me.lbNationalName)
        Me.grpSettlementName.Controls.Add(Me.lnEnglishName)
        Me.grpSettlementName.Name = "grpSettlementName"
        Me.grpSettlementName.TabStop = False
        '
        'bMap
        '
        resources.ApplyResources(Me.bMap, "bMap")
        Me.bMap.Name = "bMap"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'txtUniqueCode
        '
        resources.ApplyResources(Me.txtUniqueCode, "txtUniqueCode")
        Me.txtUniqueCode.Name = "txtUniqueCode"
        '
        'SettlementDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtUniqueCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.bMap)
        Me.Controls.Add(Me.cbCountry)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.cbRayon)
        Me.Controls.Add(Me.grpSettlementName)
        Me.Controls.Add(Me.cbSettlementType)
        Me.Controls.Add(Me.seLongitude)
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.seLatitude)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSettlementType)
        Me.FormID = "C05"
        Me.HelpTopicID = "SettlementDetailForm"
        Me.KeyFieldName = "idfsSettlement"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Settlement_131_2_
        Me.Name = "SettlementDetail"
        Me.ObjectName = "Settlement"
        Me.TableName = "Settlement"
        Me.Controls.SetChildIndex(Me.lblSettlementType, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.seLatitude, 0)
        Me.Controls.SetChildIndex(Me.lblLatitude, 0)
        Me.Controls.SetChildIndex(Me.lblLongitude, 0)
        Me.Controls.SetChildIndex(Me.seLongitude, 0)
        Me.Controls.SetChildIndex(Me.cbSettlementType, 0)
        Me.Controls.SetChildIndex(Me.grpSettlementName, 0)
        Me.Controls.SetChildIndex(Me.cbRayon, 0)
        Me.Controls.SetChildIndex(Me.cbRegion, 0)
        Me.Controls.SetChildIndex(Me.cbCountry, 0)
        Me.Controls.SetChildIndex(Me.bMap, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.txtUniqueCode, 0)
        CType(Me.txtSettlementNameDef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlementType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSettlementNameNat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettlementName.ResumeLayout(False)
        CType(Me.txtUniqueCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private ReadOnly Property CurrentRow() As DataRow
        Get
            Return baseDataSet.Tables("Settlement").Rows(0)
        End Get
    End Property
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindStandardLookup(cbSettlementType, baseDataSet, "Settlement.idfsSettlementType", LookupTables.SettlementType, False)
        Core.LookupBinder.BindTextEdit(txtSettlementNameDef, baseDataSet, "Settlement.strEnglishName")
        Core.LookupBinder.BindTextEdit(txtSettlementNameNat, baseDataSet, "Settlement.strNationalName")
        Core.LookupBinder.BindTextEdit(txtUniqueCode, baseDataSet, "Settlement.strSettlementCode")

        seLatitude.DataBindings.Add("EditValue", baseDataSet, "Settlement.dblLatitude")
        seLongitude.DataBindings.Add("EditValue", baseDataSet, "Settlement.dblLongitude")


        Dim thRayon As TagHelper = New TagHelper(cbRayon)
        thRayon.Tag = cbRegion
        Dim thRegion As TagHelper = New TagHelper(cbRegion)
        thRegion.Tag = cbCountry

        Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "Settlement.idfsCountry")
        If Not Utils.IsEmpty(m_CountryID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsCountry") = m_CountryID
            'cbCountry.Enabled = False
        End If

        Core.LookupBinder.BindRegionLookup(cbRegion, baseDataSet, "Settlement.idfsRegion")
        Core.LookupBinder.FilterRegion(cbRegion, baseDataSet.Tables("Settlement").Rows(0)("idfsCountry"))
        If Not Utils.IsEmpty(m_RegionID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsRegion") = m_RegionID
            'cbRegion.Enabled = False
        End If

        Core.LookupBinder.BindRayonLookup(cbRayon, baseDataSet, "Settlement.idfsRayon")
        Core.LookupBinder.FilterRayon(cbRayon, baseDataSet.Tables("Settlement").Rows(0)("idfsRegion"))
        If Not Utils.IsEmpty(m_RayonID) Then
            baseDataSet.Tables("Settlement").Rows(0)("idfsRayon") = m_RayonID
            'cbRayon.Enabled = False
        End If
        eventManager.AttachDataHandler("Settlement.idfsCountry", AddressOf Country_Changed)
        eventManager.AttachDataHandler("Settlement.idfsRegion", AddressOf Region_Changed)
        eventManager.AttachDataHandler("Settlement.idfsRayon", AddressOf Rayon_Changed)
        eventManager.AttachDataHandler("Settlement.strEnglishName", AddressOf EnglishName_Changed)

        'refresh coords of settlement from GIS
        RefreshSettlementCoords()
        bMap.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.GIS))


    End Sub

    Private Sub Country_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_CountryID = e.Value
        baseDataSet.Tables("Settlement").Rows(0)("idfsRegion") = DBNull.Value
        baseDataSet.Tables("Settlement").Rows(0).EndEdit()
        eventManager.Cascade("Settlement.idfsRegion")
        Core.LookupBinder.FilterRegion(cbRegion, e.Value)
    End Sub
    Private Sub Region_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_RegionID = e.Value
        baseDataSet.Tables("Settlement").Rows(0)("idfsRayon") = DBNull.Value
        baseDataSet.Tables("Settlement").Rows(0).EndEdit()
        eventManager.Cascade("Settlement.idfsRayon")
        Core.LookupBinder.FilterRayon(cbRayon, e.Value)
    End Sub
    Private Sub Rayon_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_RayonID = e.Value
    End Sub
    Private Sub EnglishName_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
            CurrentRow("strNationalName") = e.Value
            CurrentRow.EndEdit()
        End If
    End Sub

    Private Sub RefreshSettlementCoords()
        Dim idfsSettlement As Object = CurrentRow("idfsSettlement")
        If Not (Utils.IsEmpty(idfsSettlement)) Then
            Dim x As Double, y As Double
            If (gis.GisInterface.GetSettlementCoordinates(CType(idfsSettlement, Long), x, y)) Then
                CurrentRow("dblLongitude") = x
                CurrentRow("dblLatitude") = y
                'seLongitude.Text = x.ToString()
                'seLatitude.Text = y.ToString()
            End If
        End If
    End Sub


    Public Overrides Function ValidateData() As Boolean
        If (Not MyBase.ValidateData()) Then
            Return False
        End If
        Dim settlement As String = txtSettlementNameDef.EditValue.ToString
        Dim regEx As Text.RegularExpressions.Regex = New Text.RegularExpressions.Regex("[a-zA-Z-_ 0-9]+")
        If regEx.IsMatch(settlement) = False Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgEnglishCharsEnabled", "International name can include only latin letters."))
            Return False
        End If
        Dim res As Integer = Me.SettlementDBSetvice.FindDuplicate(GetCurrentRow())
        If res = 1 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgEnSetlementExists", "The settlement with such English name exists already. Please enter other English settlement name"))
            Return False
        End If
        If res = 2 Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("msgNatSettlementExists", "The settlement with such national name exists already. Please enter other national settlement name"))
            Return False
        End If
        If res < 0 Then
            Dim err As ErrorMessage = SettlementDBSetvice.LastError
            If Not err Is Nothing Then
                ErrorForm.ShowError(err)
            Else
                ErrorForm.ShowWarningDirect(EidssMessages.Get("msgSettlementVaildationError", "The unknown error during settlement validation"))
            End If
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbRayon.Properties.Buttons.Count >= 2 Then
            cbRayon.Properties.Buttons(1).Enabled = (Not Utils.IsEmpty(cbCountry.EditValue)) AndAlso _
                                                    (Not Utils.IsEmpty(cbRegion.EditValue))
            Me.txtSettlementNameNat.Enabled = bv.model.Model.Core.ModelUserContext.CurrentLanguage <> Localizer.lngEn
        End If
    End Sub

    ''' <summary>
    ''' Click to "Map..." button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMap.Click
        Dim x As Decimal, y As Decimal
        Dim idfsCountry As Long, idfsRegion As Long, idfsRayon As Long, idfsSettlement As Long
        If Not (CurrentRow("idfsCountry") Is DBNull.Value) Then idfsCountry = CType(CurrentRow("idfsCountry"), Long)
        If Not (CurrentRow("idfsRegion") Is DBNull.Value) Then idfsRegion = CType(CurrentRow("idfsRegion"), Long)
        If Not (CurrentRow("idfsRayon") Is DBNull.Value) Then idfsRayon = CType(CurrentRow("idfsRayon"), Long)
        If Not (CurrentRow("idfsSettlement") Is DBNull.Value) Then idfsSettlement = CType(CurrentRow("idfsSettlement"), Long)

        gis.GisInterface.SetCaseLocation(idfsCountry, idfsRegion, idfsRayon, idfsSettlement, x, y, AddressOf GetCoordinates)
    End Sub

    Private Sub GetCoordinates(ByVal X As Nullable(Of Double), ByVal Y As Nullable(Of Double))
        If (CurrentRow Is Nothing) Then Return
        CurrentRow.BeginEdit()
        If (X.HasValue) Then
            CurrentRow("dblLongitude") = CType(X, Decimal)
        Else
            CurrentRow("dblLongitude") = 0
        End If
        If (Y.HasValue) Then
            CurrentRow("dblLatitude") = CType(Y, Decimal)
        Else
            CurrentRow("dblLatitude") = 0
        End If
        CurrentRow.EndEdit()
    End Sub

    Private Sub SettlementDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
        If Me.SettlementDBSetvice.RefreshCache Then
            eidss.gis.Utils.TranslationCache.ClearCache()
        End If
    End Sub
End Class
