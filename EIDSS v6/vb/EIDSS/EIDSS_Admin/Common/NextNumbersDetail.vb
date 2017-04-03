Imports bv.common.Core
Imports EIDSS.model.Enums

Public Class NextNumbersDetail

    Inherits BaseDetailForm

    Dim NextNumbersDbService As NextNumbers_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        NextNumbersDbService = New NextNumbers_DB

        DbService = NextNumbersDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoDocumentNumbering, AuditTable.tstNextNumbers)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.DocumentNumbering

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
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbPreview As System.Windows.Forms.Label
    Friend WithEvents txtDocumentName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMinNumberLength As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtNationalDocumentName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbNationalName As System.Windows.Forms.Label
    Friend WithEvents lbEnglishName As System.Windows.Forms.Label
    Friend WithEvents txtNextNumberValue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNextNumberValue As System.Windows.Forms.Label
    Friend WithEvents lblMinNumberLength As System.Windows.Forms.Label
    Friend WithEvents lblNumberFormatPreviewCaption As System.Windows.Forms.Label
    Friend WithEvents chPrefix As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chSiteID As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chYear As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chAlphaNumeric As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chNumeric As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents gcSiteIDFormat As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chHASCSiteIdentifier As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chDefSiteIdentifier As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSiteID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNumberFormat As System.Windows.Forms.Label
    Friend WithEvents lblNumericPartProperties As System.Windows.Forms.Label
    Friend WithEvents lblSiteIDFormat As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NextNumbersDetail))
        Me.txtDocumentName = New DevExpress.XtraEditors.TextEdit()
        Me.lbEnglishName = New System.Windows.Forms.Label()
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblNextNumberValue = New System.Windows.Forms.Label()
        Me.lblMinNumberLength = New System.Windows.Forms.Label()
        Me.lblNumberFormatPreviewCaption = New System.Windows.Forms.Label()
        Me.lbPreview = New System.Windows.Forms.Label()
        Me.txtMinNumberLength = New DevExpress.XtraEditors.SpinEdit()
        Me.txtNationalDocumentName = New DevExpress.XtraEditors.TextEdit()
        Me.lbNationalName = New System.Windows.Forms.Label()
        Me.txtNextNumberValue = New DevExpress.XtraEditors.TextEdit()
        Me.chPrefix = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSiteID = New DevExpress.XtraEditors.TextEdit()
        Me.chSiteID = New DevExpress.XtraEditors.CheckEdit()
        Me.txtYear = New DevExpress.XtraEditors.TextEdit()
        Me.chYear = New DevExpress.XtraEditors.CheckEdit()
        Me.chAlphaNumeric = New DevExpress.XtraEditors.CheckEdit()
        Me.chNumeric = New DevExpress.XtraEditors.CheckEdit()
        Me.gcSiteIDFormat = New DevExpress.XtraEditors.GroupControl()
        Me.chHASCSiteIdentifier = New DevExpress.XtraEditors.CheckEdit()
        Me.chDefSiteIdentifier = New DevExpress.XtraEditors.CheckEdit()
        Me.lblNumberFormat = New System.Windows.Forms.Label()
        Me.lblNumericPartProperties = New System.Windows.Forms.Label()
        Me.lblSiteIDFormat = New System.Windows.Forms.Label()
        CType(Me.txtDocumentName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinNumberLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationalDocumentName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNextNumberValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chSiteID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAlphaNumeric.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chNumeric.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcSiteIDFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chHASCSiteIdentifier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chDefSiteIdentifier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(NextNumbersDetail), resources)
        'Form Is Localizable: True
        '
        'txtDocumentName
        '
        resources.ApplyResources(Me.txtDocumentName, "txtDocumentName")
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.TabStop = False
        Me.txtDocumentName.Tag = "{R}"
        '
        'lbEnglishName
        '
        resources.ApplyResources(Me.lbEnglishName, "lbEnglishName")
        Me.lbEnglishName.Name = "lbEnglishName"
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Tag = ""
        '
        'lblNextNumberValue
        '
        Me.lblNextNumberValue.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblNextNumberValue, "lblNextNumberValue")
        Me.lblNextNumberValue.Name = "lblNextNumberValue"
        '
        'lblMinNumberLength
        '
        Me.lblMinNumberLength.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblMinNumberLength, "lblMinNumberLength")
        Me.lblMinNumberLength.Name = "lblMinNumberLength"
        '
        'lblNumberFormatPreviewCaption
        '
        Me.lblNumberFormatPreviewCaption.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblNumberFormatPreviewCaption, "lblNumberFormatPreviewCaption")
        Me.lblNumberFormatPreviewCaption.Name = "lblNumberFormatPreviewCaption"
        '
        'lbPreview
        '
        resources.ApplyResources(Me.lbPreview, "lbPreview")
        Me.lbPreview.BackColor = System.Drawing.SystemColors.Info
        Me.lbPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbPreview.Name = "lbPreview"
        '
        'txtMinNumberLength
        '
        resources.ApplyResources(Me.txtMinNumberLength, "txtMinNumberLength")
        Me.txtMinNumberLength.Name = "txtMinNumberLength"
        Me.txtMinNumberLength.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMinNumberLength.Properties.IsFloatValue = False
        Me.txtMinNumberLength.Properties.Mask.EditMask = resources.GetString("txtMinNumberLength.Properties.Mask.EditMask")
        Me.txtMinNumberLength.Properties.MaxValue = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'txtNationalDocumentName
        '
        resources.ApplyResources(Me.txtNationalDocumentName, "txtNationalDocumentName")
        Me.txtNationalDocumentName.Name = "txtNationalDocumentName"
        Me.txtNationalDocumentName.Tag = ""
        '
        'lbNationalName
        '
        resources.ApplyResources(Me.lbNationalName, "lbNationalName")
        Me.lbNationalName.Name = "lbNationalName"
        '
        'txtNextNumberValue
        '
        resources.ApplyResources(Me.txtNextNumberValue, "txtNextNumberValue")
        Me.txtNextNumberValue.Name = "txtNextNumberValue"
        Me.txtNextNumberValue.Tag = ""
        '
        'chPrefix
        '
        resources.ApplyResources(Me.chPrefix, "chPrefix")
        Me.chPrefix.Name = "chPrefix"
        Me.chPrefix.Properties.Appearance.Font = CType(resources.GetObject("chPrefix.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chPrefix.Properties.Appearance.Options.UseFont = True
        Me.chPrefix.Properties.Caption = resources.GetString("chPrefix.Properties.Caption")
        Me.chPrefix.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chPrefix.Properties.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtSiteID
        '
        resources.ApplyResources(Me.txtSiteID, "txtSiteID")
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Properties.ReadOnly = True
        Me.txtSiteID.TabStop = False
        Me.txtSiteID.Tag = ""
        '
        'chSiteID
        '
        resources.ApplyResources(Me.chSiteID, "chSiteID")
        Me.chSiteID.Name = "chSiteID"
        Me.chSiteID.Properties.Appearance.Font = CType(resources.GetObject("chSiteID.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chSiteID.Properties.Appearance.Options.UseFont = True
        Me.chSiteID.Properties.Caption = resources.GetString("chSiteID.Properties.Caption")
        Me.chSiteID.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chSiteID.Properties.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtYear
        '
        resources.ApplyResources(Me.txtYear, "txtYear")
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Properties.ReadOnly = True
        Me.txtYear.TabStop = False
        Me.txtYear.Tag = ""
        '
        'chYear
        '
        resources.ApplyResources(Me.chYear, "chYear")
        Me.chYear.Name = "chYear"
        Me.chYear.Properties.Appearance.Font = CType(resources.GetObject("chYear.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chYear.Properties.Appearance.Options.UseFont = True
        Me.chYear.Properties.Caption = resources.GetString("chYear.Properties.Caption")
        Me.chYear.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chYear.Properties.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chAlphaNumeric
        '
        resources.ApplyResources(Me.chAlphaNumeric, "chAlphaNumeric")
        Me.chAlphaNumeric.Name = "chAlphaNumeric"
        Me.chAlphaNumeric.Properties.Caption = resources.GetString("chAlphaNumeric.Properties.Caption")
        Me.chAlphaNumeric.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chAlphaNumeric.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chAlphaNumeric.Properties.RadioGroupIndex = 0
        Me.chAlphaNumeric.Properties.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.chAlphaNumeric.TabStop = False
        '
        'chNumeric
        '
        resources.ApplyResources(Me.chNumeric, "chNumeric")
        Me.chNumeric.Name = "chNumeric"
        Me.chNumeric.Properties.Caption = resources.GetString("chNumeric.Properties.Caption")
        Me.chNumeric.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chNumeric.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chNumeric.Properties.RadioGroupIndex = 0
        Me.chNumeric.Properties.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.chNumeric.TabStop = False
        '
        'gcSiteIDFormat
        '
        resources.ApplyResources(Me.gcSiteIDFormat, "gcSiteIDFormat")
        Me.gcSiteIDFormat.Name = "gcSiteIDFormat"
        '
        'chHASCSiteIdentifier
        '
        resources.ApplyResources(Me.chHASCSiteIdentifier, "chHASCSiteIdentifier")
        Me.chHASCSiteIdentifier.Name = "chHASCSiteIdentifier"
        Me.chHASCSiteIdentifier.Properties.Caption = resources.GetString("chHASCSiteIdentifier.Properties.Caption")
        Me.chHASCSiteIdentifier.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chHASCSiteIdentifier.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chHASCSiteIdentifier.Properties.RadioGroupIndex = 1
        Me.chHASCSiteIdentifier.Properties.ValueChecked = 1
        Me.chHASCSiteIdentifier.TabStop = False
        '
        'chDefSiteIdentifier
        '
        resources.ApplyResources(Me.chDefSiteIdentifier, "chDefSiteIdentifier")
        Me.chDefSiteIdentifier.Name = "chDefSiteIdentifier"
        Me.chDefSiteIdentifier.Properties.Caption = resources.GetString("chDefSiteIdentifier.Properties.Caption")
        Me.chDefSiteIdentifier.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chDefSiteIdentifier.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chDefSiteIdentifier.Properties.RadioGroupIndex = 1
        Me.chDefSiteIdentifier.Properties.ValueChecked = 1
        Me.chDefSiteIdentifier.TabStop = False
        '
        'lblNumberFormat
        '
        resources.ApplyResources(Me.lblNumberFormat, "lblNumberFormat")
        Me.lblNumberFormat.Name = "lblNumberFormat"
        '
        'lblNumericPartProperties
        '
        resources.ApplyResources(Me.lblNumericPartProperties, "lblNumericPartProperties")
        Me.lblNumericPartProperties.Name = "lblNumericPartProperties"
        '
        'lblSiteIDFormat
        '
        resources.ApplyResources(Me.lblSiteIDFormat, "lblSiteIDFormat")
        Me.lblSiteIDFormat.Name = "lblSiteIDFormat"
        '
        'NextNumbersDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblSiteIDFormat)
        Me.Controls.Add(Me.lblNumericPartProperties)
        Me.Controls.Add(Me.lblNumberFormat)
        Me.Controls.Add(Me.gcSiteIDFormat)
        Me.Controls.Add(Me.txtNationalDocumentName)
        Me.Controls.Add(Me.lbNationalName)
        Me.Controls.Add(Me.txtDocumentName)
        Me.Controls.Add(Me.lbEnglishName)
        Me.Controls.Add(Me.txtNextNumberValue)
        Me.Controls.Add(Me.chPrefix)
        Me.Controls.Add(Me.txtSiteID)
        Me.Controls.Add(Me.chSiteID)
        Me.Controls.Add(Me.lblNextNumberValue)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.chYear)
        Me.Controls.Add(Me.lblNumberFormatPreviewCaption)
        Me.Controls.Add(Me.lbPreview)
        Me.Controls.Add(Me.lblMinNumberLength)
        Me.Controls.Add(Me.chAlphaNumeric)
        Me.Controls.Add(Me.chNumeric)
        Me.Controls.Add(Me.txtMinNumberLength)
        Me.Controls.Add(Me.chHASCSiteIdentifier)
        Me.Controls.Add(Me.chDefSiteIdentifier)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "C08"
        Me.HelpTopicID = "Unique_Numbering_Schema"
        Me.KeyFieldName = "idfsNumberName"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.UniqueNumberingSchemeDetail_103_
        Me.Name = "NextNumbersDetail"
        Me.ObjectName = "NextNumbers"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "NextNumbers"
        Me.Controls.SetChildIndex(Me.chDefSiteIdentifier, 0)
        Me.Controls.SetChildIndex(Me.chHASCSiteIdentifier, 0)
        Me.Controls.SetChildIndex(Me.txtMinNumberLength, 0)
        Me.Controls.SetChildIndex(Me.chNumeric, 0)
        Me.Controls.SetChildIndex(Me.chAlphaNumeric, 0)
        Me.Controls.SetChildIndex(Me.lblMinNumberLength, 0)
        Me.Controls.SetChildIndex(Me.lbPreview, 0)
        Me.Controls.SetChildIndex(Me.lblNumberFormatPreviewCaption, 0)
        Me.Controls.SetChildIndex(Me.chYear, 0)
        Me.Controls.SetChildIndex(Me.txtYear, 0)
        Me.Controls.SetChildIndex(Me.txtPrefix, 0)
        Me.Controls.SetChildIndex(Me.lblNextNumberValue, 0)
        Me.Controls.SetChildIndex(Me.chSiteID, 0)
        Me.Controls.SetChildIndex(Me.txtSiteID, 0)
        Me.Controls.SetChildIndex(Me.chPrefix, 0)
        Me.Controls.SetChildIndex(Me.txtNextNumberValue, 0)
        Me.Controls.SetChildIndex(Me.lbEnglishName, 0)
        Me.Controls.SetChildIndex(Me.txtDocumentName, 0)
        Me.Controls.SetChildIndex(Me.lbNationalName, 0)
        Me.Controls.SetChildIndex(Me.txtNationalDocumentName, 0)
        Me.Controls.SetChildIndex(Me.gcSiteIDFormat, 0)
        Me.Controls.SetChildIndex(Me.lblNumberFormat, 0)
        Me.Controls.SetChildIndex(Me.lblNumericPartProperties, 0)
        Me.Controls.SetChildIndex(Me.lblSiteIDFormat, 0)
        CType(Me.txtDocumentName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinNumberLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNationalDocumentName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNextNumberValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chSiteID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAlphaNumeric.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chNumeric.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcSiteIDFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chHASCSiteIdentifier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chDefSiteIdentifier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region



    Private Sub InitCheckEdit()
        Dim ValChecked As Byte = 1
        Dim ValUnchecked As Byte = 0
        Me.chAlphaNumeric.Properties.ValueChecked = ValChecked

        Me.chDefSiteIdentifier.Properties.ValueChecked = ValChecked
        Me.chHASCSiteIdentifier.Properties.ValueChecked = ValChecked
        Me.chNumeric.Properties.ValueChecked = ValChecked
        Me.chPrefix.Properties.ValueChecked = ValChecked

        Me.chSiteID.Properties.ValueChecked = ValChecked

        Me.chYear.Properties.ValueChecked = ValChecked

        Me.chAlphaNumeric.Properties.ValueUnchecked = ValUnchecked

        Me.chDefSiteIdentifier.Properties.ValueUnchecked = ValUnchecked
        Me.chHASCSiteIdentifier.Properties.ValueUnchecked = ValUnchecked
        Me.chNumeric.Properties.ValueUnchecked = ValUnchecked
        Me.chPrefix.Properties.ValueUnchecked = ValUnchecked

        Me.chSiteID.Properties.ValueUnchecked = ValUnchecked

        Me.chYear.Properties.ValueUnchecked = ValUnchecked
    End Sub


    'Define the visible state of each the control using its Tag property
    'Write the control state in the format {MRK}
    'Where
    'M - mandatory field, must be filled by user
    'R - ReadOnly field
    'K - key field - it is editble for new object and read-only in all other cases
    'Empty tag means usual editable field
    Protected Overrides Sub DefineBinding()
        Try
            'NextNumbers binding

            'TextBox binding template
            ShowPreview = True
            InitCheckEdit()

            txtMinNumberLength.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("intMinNumberLength")
            Core.LookupBinder.BindTextEdit(txtNationalDocumentName, baseDataSet, "NextNumbers.strObjectName")
            Core.LookupBinder.BindTextEdit(txtDocumentName, baseDataSet, "NextNumbers.strEnglishName")
            txtNextNumberValue.EditValue = GetNumberValue()
            'txtSuffix.DataBindings.Clear()
            'txtSuffix.DataBindings.Add("EditValue", baseDataSet, "NextNumbers.strSuffix")
            txtPrefix.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("strPrefix")
            chPrefix.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("blnUsePrefix")
            chSiteID.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("blnUseSiteID")
            chYear.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("blnUseYear")
            chAlphaNumeric.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("blnUseAlphaNumericValue")
            If Utils.IsEmpty(chAlphaNumeric.EditValue) OrElse Not chAlphaNumeric.Checked Then chNumeric.Checked = True
            chHASCSiteIdentifier.EditValue = baseDataSet.Tables("NextNumbers").Rows(0)("blnUseHACSCodeSite")
            If Utils.IsEmpty(chHASCSiteIdentifier.EditValue) OrElse Not chHASCSiteIdentifier.Checked Then chDefSiteIdentifier.Checked = True
            txtSiteID.EditValue = GetSite()
            txtYear.EditValue = GetYear()
            If Not Utils.IsEmpty(txtYear.EditValue) Then
                baseDataSet.Tables("NextNumbers").Rows(0)("intYear") = Now.Year
            Else
                baseDataSet.Tables("NextNumbers").Rows(0)("intYear") = DBNull.Value
            End If
            'Event processing template
            eventManager.AttachDataHandler("NextNumbers.strPrefix", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.intNumberValue", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.strSuffix", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.intMinNumberLength", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.blnUsePrefix", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.blnUseSiteID", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.blnUseYear", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.blnUseAlphaNumericValue", AddressOf Field_Changed)
            eventManager.AttachDataHandler("NextNumbers.blnUseHACSCodeSite", AddressOf Field_Changed)


            lbPreview.Text = GetPreview()

            'lbNationalName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
            If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
                'txtDocumentName.Visible = False
                'lbEnglishName.Visible = False
                txtNationalDocumentName.Visible = False
                lbNationalName.Visible = False
            Else
                txtNationalDocumentName.Visible = True
                lbNationalName.Visible = True
            End If
        Catch e As Exception

        End Try

    End Sub

    'Event handler template for processing events inside 
    Private Sub Field_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If ShowPreview Then lbPreview.Text = GetPreview()
    End Sub

    Private Function GetSite() As String
        Dim row As DataRow = Me.GetCurrentRow()
        Dim strsite As String = ""
        If (Not row("blnUseSiteID") Is DBNull.Value) AndAlso CBool(row("blnUseSiteID")) Then
            If (Not row("blnUseHACSCodeSite") Is DBNull.Value) AndAlso CBool(row("blnUseHACSCodeSite")) Then
                strsite = EIDSS.model.Core.EidssSiteContext.Instance.SiteHASCCode
            Else
                strsite = EIDSS.model.Core.EidssSiteContext.Instance.SiteCode
            End If
        End If
        Return strsite
    End Function

    Private Function GetYear() As String
        Dim row As DataRow = Me.GetCurrentRow()
        Dim year As String = ""
        If (Not row("blnUseYear") Is DBNull.Value) AndAlso CBool(row("blnUseYear")) Then
            year = DateTime.Now.Year.ToString
            year = year.Substring(year.Length - 2, 2)
        End If
        Return year
    End Function

    Dim ShowPreview As Boolean = True

    Private Function GetNumberValue() As String
        Dim row As DataRow = Me.GetCurrentRow()
        Dim numval As String = "0"
        Dim minLen As Integer = 4
        If Not row("intMinNumberLength") Is DBNull.Value Then
            minLen = CInt(row("intMinNumberLength"))
        End If
        If Not row("intNumberValue") Is DBNull.Value Then
            If (Not row("blnUseAlphaNumericValue") Is DBNull.Value) AndAlso CBool(row("blnUseAlphaNumericValue")) Then
                numval = BarcodeHelper.NumericToAlpha(CLng(row("intNumberValue")), minLen)
            Else
                numval = row("intNumberValue").ToString()
            End If
        End If
        If minLen > 0 Then
            If numval.Length > minLen Then
                numval = "0"
                ShowPreview = False
                row("intNumberValue") = 0
                ShowPreview = True
            End If
            numval = numval.PadLeft(minLen, "0"c)
        End If
        Return numval
    End Function

    Private Function GetPreview() As String
        Dim row As DataRow = Me.GetCurrentRow()
        Dim n As String = GetNumberValue()
        Dim prefix As String = ""
        If (Not row("blnUsePrefix") Is DBNull.Value) AndAlso CBool(row("blnUsePrefix")) AndAlso (Not row("strPrefix") Is DBNull.Value) Then
            prefix = row("strPrefix").ToString()
        End If
        Dim strsite As String = GetSite()
        Dim year As String = GetYear()
        Dim suffix As String = ""
        If Not row("strSuffix") Is DBNull.Value Then
            suffix = row("strSuffix").ToString()
        End If

        Return String.Format("{0}{1}{2}{3}{4}", prefix, strsite, year, n, suffix)
    End Function




    Public Overrides Function ValidateData() As Boolean
        Return True
    End Function

    Private Sub txtPrefix_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtPrefix.EditValueChanging
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            If (Utils.Str(e.NewValue).Length > 1) Then e.Cancel = True
        End If
    End Sub

    Private Sub txtPrefix_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrefix.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then baseDataSet.Tables("NextNumbers").Rows(0)("strPrefix") = txtPrefix.EditValue
    End Sub

    Private Sub chPrefix_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chPrefix.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then baseDataSet.Tables("NextNumbers").Rows(0)("blnUsePrefix") = chPrefix.EditValue
    End Sub

    Private Sub chSiteID_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chSiteID.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            baseDataSet.Tables("NextNumbers").Rows(0)("blnUseSiteID") = chSiteID.EditValue
            txtSiteID.EditValue = GetSite()
        End If
    End Sub

    Private Sub chYear_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chYear.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            baseDataSet.Tables("NextNumbers").Rows(0)("blnUseYear") = chYear.EditValue
            txtYear.EditValue = GetYear()
            If Not Utils.IsEmpty(txtYear.EditValue) Then
                baseDataSet.Tables("NextNumbers").Rows(0)("intYear") = Now.Year
            Else
                baseDataSet.Tables("NextNumbers").Rows(0)("intYear") = DBNull.Value
            End If
        End If
    End Sub

    Private Sub chHASCSiteIdentifier_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chHASCSiteIdentifier.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            baseDataSet.Tables("NextNumbers").Rows(0)("blnUseHACSCodeSite") = chHASCSiteIdentifier.EditValue
            txtSiteID.EditValue = GetSite()
        End If
    End Sub



    Private Sub chAlphaNumeric_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chAlphaNumeric.EditValueChanged
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            baseDataSet.Tables("NextNumbers").Rows(0)("blnUseAlphaNumericValue") = chAlphaNumeric.EditValue
            txtNextNumberValue.EditValue = GetNumberValue()
        End If
    End Sub

    Private Sub txtNextNumberValue_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtNextNumberValue.EditValueChanging
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            Dim MaxLength As Integer = 9
            If (Not Utils.IsEmpty(txtMinNumberLength.EditValue)) AndAlso CInt(txtMinNumberLength.EditValue) > 0 Then MaxLength = CInt(txtMinNumberLength.EditValue)
            If Utils.Str(e.NewValue).Length > MaxLength Then e.Cancel = True
        End If
    End Sub

    Private Sub SetNumberValue()
        Dim CurVal As String = txtNextNumberValue.Text
        Dim NumVal As Int64 = 0
        If chAlphaNumeric.Checked Then
            Dim bAlphaNumeric As Boolean = True
            If bAlphaNumeric Then
                baseDataSet.Tables("NextNumbers").Rows(0)("intNumberValue") = BarcodeHelper.AlphaToNumeric(CurVal)
            Else
                txtNextNumberValue.EditValue = GetNumberValue()
            End If
        Else
            Try
                NumVal = CLng(txtNextNumberValue.Text)
                If NumVal < 0 Then
                    txtNextNumberValue.EditValue = GetNumberValue()
                Else
                    baseDataSet.Tables("NextNumbers").Rows(0)("intNumberValue") = NumVal
                End If
            Catch ex As Exception
                txtNextNumberValue.EditValue = GetNumberValue()
            End Try
        End If
    End Sub

    Private Sub txtNextNumberValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNextNumberValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
                SetNumberValue()
            End If
        End If
    End Sub

    Private Sub txtNextNumberValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNextNumberValue.Leave
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            SetNumberValue()
        End If
    End Sub

    Private Sub txtMinNumberLength_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMinNumberLength.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
                baseDataSet.Tables("NextNumbers").Rows(0)("intMinNumberLength") = txtMinNumberLength.EditValue
                Dim MaxLength As Integer = 9
                If (Not Utils.IsEmpty(txtMinNumberLength.EditValue)) AndAlso CInt(txtMinNumberLength.EditValue) > 0 Then MaxLength = CInt(txtMinNumberLength.EditValue)
                If txtNextNumberValue.Text.Length > MaxLength Then
                    txtNextNumberValue.EditValue = GetNumberValue()
                End If
            End If
        End If
    End Sub

    Private Sub txtMinNumberLength_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinNumberLength.Leave
        If (Not Loading) AndAlso baseDataSet.Tables.Contains("NextNumbers") Then
            baseDataSet.Tables("NextNumbers").Rows(0)("intMinNumberLength") = txtMinNumberLength.EditValue
            Dim MaxLength As Integer = 9
            If (Not Utils.IsEmpty(txtMinNumberLength.EditValue)) AndAlso CInt(txtMinNumberLength.EditValue) > 0 Then MaxLength = CInt(txtMinNumberLength.EditValue)
            If txtNextNumberValue.Text.Length > MaxLength Then
                txtNextNumberValue.EditValue = GetNumberValue()
            End If
        End If
    End Sub

    Private Sub NextNumbersDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
