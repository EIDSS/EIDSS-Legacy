<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateHeader
    Inherits bv.common.win.BaseDetailPanel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateHeader))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.cbYear = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbQuarter = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbMonth = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbWeek = New DevExpress.XtraEditors.LookUpEdit()
        Me.datDay = New DevExpress.XtraEditors.DateEdit()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRegion = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRayon = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSettlement = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCaseID = New DevExpress.XtraEditors.TextEdit()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblQuarter = New System.Windows.Forms.Label()
        Me.lblSettlement = New System.Windows.Forms.Label()
        Me.lblRayon = New System.Windows.Forms.Label()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblCaseID = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblWeek = New System.Windows.Forms.Label()
        Me.gbEntered = New System.Windows.Forms.GroupBox()
        Me.cbEnteredInstitution = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbEntOfficer = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtEnteringDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblEnteringDate = New System.Windows.Forms.Label()
        Me.lblEnteredByInstitution = New System.Windows.Forms.Label()
        Me.lblEnteredByOfficer = New System.Windows.Forms.Label()
        Me.gbReported = New System.Windows.Forms.GroupBox()
        Me.cbRepSource = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbRepBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtReportingDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblSendingDate = New System.Windows.Forms.Label()
        Me.lblSentByOfficer = New System.Windows.Forms.Label()
        Me.lblSentByInstitution = New System.Windows.Forms.Label()
        Me.gbReceived = New System.Windows.Forms.GroupBox()
        Me.cbReceivedInst = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbReceivedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtReceivedDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblReceivedByInstitution = New System.Windows.Forms.Label()
        Me.lblReceivedByOfficer = New System.Windows.Forms.Label()
        Me.lblReceivingDate = New System.Windows.Forms.Label()
        Me.gbGeneral.SuspendLayout()
        CType(Me.cbYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbQuarter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbWeek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEntered.SuspendLayout()
        CType(Me.cbEnteredInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEntOfficer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteringDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteringDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReported.SuspendLayout()
        CType(Me.cbRepSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRepBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReceived.SuspendLayout()
        CType(Me.cbReceivedInst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReceivedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReceivedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReceivedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AggregateHeader), resources)
        'Form Is Localizable: True
        '
        'gbGeneral
        '
        resources.ApplyResources(Me.gbGeneral, "gbGeneral")
        Me.gbGeneral.Controls.Add(Me.cbYear)
        Me.gbGeneral.Controls.Add(Me.cbQuarter)
        Me.gbGeneral.Controls.Add(Me.cbMonth)
        Me.gbGeneral.Controls.Add(Me.cbWeek)
        Me.gbGeneral.Controls.Add(Me.datDay)
        Me.gbGeneral.Controls.Add(Me.cbCountry)
        Me.gbGeneral.Controls.Add(Me.cbRegion)
        Me.gbGeneral.Controls.Add(Me.cbRayon)
        Me.gbGeneral.Controls.Add(Me.cbSettlement)
        Me.gbGeneral.Controls.Add(Me.txtCaseID)
        Me.gbGeneral.Controls.Add(Me.lblMonth)
        Me.gbGeneral.Controls.Add(Me.lblQuarter)
        Me.gbGeneral.Controls.Add(Me.lblSettlement)
        Me.gbGeneral.Controls.Add(Me.lblRayon)
        Me.gbGeneral.Controls.Add(Me.lblRegion)
        Me.gbGeneral.Controls.Add(Me.lblYear)
        Me.gbGeneral.Controls.Add(Me.lblCountry)
        Me.gbGeneral.Controls.Add(Me.lblCaseID)
        Me.gbGeneral.Controls.Add(Me.lblDay)
        Me.gbGeneral.Controls.Add(Me.lblWeek)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.TabStop = False
        '
        'cbYear
        '
        resources.ApplyResources(Me.cbYear, "cbYear")
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Properties.AccessibleDescription = resources.GetString("cbYear.Properties.AccessibleDescription")
        Me.cbYear.Properties.AccessibleName = resources.GetString("cbYear.Properties.AccessibleName")
        Me.cbYear.Properties.AutoHeight = CType(resources.GetObject("cbYear.Properties.AutoHeight"), Boolean)
        Me.cbYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbYear.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbYear.Properties.NullValuePrompt = resources.GetString("cbYear.Properties.NullValuePrompt")
        Me.cbYear.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbYear.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbYear.Tag = "{M}"
        '
        'cbQuarter
        '
        resources.ApplyResources(Me.cbQuarter, "cbQuarter")
        Me.cbQuarter.Name = "cbQuarter"
        Me.cbQuarter.Properties.AccessibleDescription = resources.GetString("cbQuarter.Properties.AccessibleDescription")
        Me.cbQuarter.Properties.AccessibleName = resources.GetString("cbQuarter.Properties.AccessibleName")
        Me.cbQuarter.Properties.AutoHeight = CType(resources.GetObject("cbQuarter.Properties.AutoHeight"), Boolean)
        Me.cbQuarter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbQuarter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbQuarter.Properties.NullText = resources.GetString("cbQuarter.Properties.NullText")
        Me.cbQuarter.Properties.NullValuePrompt = resources.GetString("cbQuarter.Properties.NullValuePrompt")
        Me.cbQuarter.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbQuarter.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbQuarter.Tag = "{M}"
        '
        'cbMonth
        '
        resources.ApplyResources(Me.cbMonth, "cbMonth")
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Properties.AccessibleDescription = resources.GetString("cbMonth.Properties.AccessibleDescription")
        Me.cbMonth.Properties.AccessibleName = resources.GetString("cbMonth.Properties.AccessibleName")
        Me.cbMonth.Properties.AutoHeight = CType(resources.GetObject("cbMonth.Properties.AutoHeight"), Boolean)
        Me.cbMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbMonth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbMonth.Properties.NullText = resources.GetString("cbMonth.Properties.NullText")
        Me.cbMonth.Properties.NullValuePrompt = resources.GetString("cbMonth.Properties.NullValuePrompt")
        Me.cbMonth.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbMonth.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbMonth.Tag = "{M}"
        '
        'cbWeek
        '
        resources.ApplyResources(Me.cbWeek, "cbWeek")
        Me.cbWeek.Name = "cbWeek"
        Me.cbWeek.Properties.AccessibleDescription = resources.GetString("cbWeek.Properties.AccessibleDescription")
        Me.cbWeek.Properties.AccessibleName = resources.GetString("cbWeek.Properties.AccessibleName")
        Me.cbWeek.Properties.AutoHeight = CType(resources.GetObject("cbWeek.Properties.AutoHeight"), Boolean)
        Me.cbWeek.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbWeek.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbWeek.Properties.NullText = resources.GetString("cbWeek.Properties.NullText")
        Me.cbWeek.Properties.NullValuePrompt = resources.GetString("cbWeek.Properties.NullValuePrompt")
        Me.cbWeek.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbWeek.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbWeek.Tag = "{M}"
        '
        'datDay
        '
        resources.ApplyResources(Me.datDay, "datDay")
        Me.datDay.Name = "datDay"
        Me.datDay.Properties.AccessibleDescription = resources.GetString("datDay.Properties.AccessibleDescription")
        Me.datDay.Properties.AccessibleName = resources.GetString("datDay.Properties.AccessibleName")
        Me.datDay.Properties.AutoHeight = CType(resources.GetObject("datDay.Properties.AutoHeight"), Boolean)
        Me.datDay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datDay.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datDay.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("datDay.Properties.CalendarTimeProperties.AccessibleDescription")
        Me.datDay.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("datDay.Properties.CalendarTimeProperties.AccessibleName")
        Me.datDay.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDay.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datDay.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("datDay.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.datDay.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datDay.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
        Me.datDay.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datDay.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("datDay.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.datDay.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datDay.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.datDay.Properties.Mask.AutoComplete = CType(resources.GetObject("datDay.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datDay.Properties.Mask.BeepOnError = CType(resources.GetObject("datDay.Properties.Mask.BeepOnError"), Boolean)
        Me.datDay.Properties.Mask.EditMask = resources.GetString("datDay.Properties.Mask.EditMask")
        Me.datDay.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datDay.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datDay.Properties.Mask.MaskType = CType(resources.GetObject("datDay.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datDay.Properties.Mask.PlaceHolder = CType(resources.GetObject("datDay.Properties.Mask.PlaceHolder"), Char)
        Me.datDay.Properties.Mask.SaveLiteral = CType(resources.GetObject("datDay.Properties.Mask.SaveLiteral"), Boolean)
        Me.datDay.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("datDay.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.datDay.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datDay.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datDay.Properties.NullValuePrompt = resources.GetString("datDay.Properties.NullValuePrompt")
        Me.datDay.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datDay.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.datDay.Tag = "{M}"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.AccessibleDescription = resources.GetString("cbCountry.Properties.AccessibleDescription")
        Me.cbCountry.Properties.AccessibleName = resources.GetString("cbCountry.Properties.AccessibleName")
        Me.cbCountry.Properties.AutoHeight = CType(resources.GetObject("cbCountry.Properties.AutoHeight"), Boolean)
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
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
        Me.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText")
        Me.cbSettlement.Properties.NullValuePrompt = resources.GetString("cbSettlement.Properties.NullValuePrompt")
        Me.cbSettlement.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbSettlement.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbSettlement.Tag = "{M}"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AccessibleDescription = resources.GetString("txtCaseID.Properties.AccessibleDescription")
        Me.txtCaseID.Properties.AccessibleName = resources.GetString("txtCaseID.Properties.AccessibleName")
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCaseID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCaseID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCaseID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.MaskType = CType(resources.GetObject("txtCaseID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCaseID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCaseID.Properties.Mask.PlaceHolder"), Char)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCaseID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCaseID.Properties.NullValuePrompt = resources.GetString("txtCaseID.Properties.NullValuePrompt")
        Me.txtCaseID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCaseID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtCaseID.Tag = "{R}[en]"
        '
        'lblMonth
        '
        resources.ApplyResources(Me.lblMonth, "lblMonth")
        Me.lblMonth.Name = "lblMonth"
        '
        'lblQuarter
        '
        resources.ApplyResources(Me.lblQuarter, "lblQuarter")
        Me.lblQuarter.Name = "lblQuarter"
        '
        'lblSettlement
        '
        resources.ApplyResources(Me.lblSettlement, "lblSettlement")
        Me.lblSettlement.Name = "lblSettlement"
        '
        'lblRayon
        '
        resources.ApplyResources(Me.lblRayon, "lblRayon")
        Me.lblRayon.Name = "lblRayon"
        '
        'lblRegion
        '
        resources.ApplyResources(Me.lblRegion, "lblRegion")
        Me.lblRegion.Name = "lblRegion"
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.Name = "lblYear"
        '
        'lblCountry
        '
        resources.ApplyResources(Me.lblCountry, "lblCountry")
        Me.lblCountry.Name = "lblCountry"
        '
        'lblCaseID
        '
        resources.ApplyResources(Me.lblCaseID, "lblCaseID")
        Me.lblCaseID.Name = "lblCaseID"
        '
        'lblDay
        '
        resources.ApplyResources(Me.lblDay, "lblDay")
        Me.lblDay.Name = "lblDay"
        '
        'lblWeek
        '
        resources.ApplyResources(Me.lblWeek, "lblWeek")
        Me.lblWeek.Name = "lblWeek"
        '
        'gbEntered
        '
        resources.ApplyResources(Me.gbEntered, "gbEntered")
        Me.gbEntered.Controls.Add(Me.cbEnteredInstitution)
        Me.gbEntered.Controls.Add(Me.cbEntOfficer)
        Me.gbEntered.Controls.Add(Me.dtEnteringDate)
        Me.gbEntered.Controls.Add(Me.lblEnteringDate)
        Me.gbEntered.Controls.Add(Me.lblEnteredByInstitution)
        Me.gbEntered.Controls.Add(Me.lblEnteredByOfficer)
        Me.gbEntered.Name = "gbEntered"
        Me.gbEntered.TabStop = False
        '
        'cbEnteredInstitution
        '
        resources.ApplyResources(Me.cbEnteredInstitution, "cbEnteredInstitution")
        Me.cbEnteredInstitution.Name = "cbEnteredInstitution"
        Me.cbEnteredInstitution.Properties.AccessibleDescription = resources.GetString("cbEnteredInstitution.Properties.AccessibleDescription")
        Me.cbEnteredInstitution.Properties.AccessibleName = resources.GetString("cbEnteredInstitution.Properties.AccessibleName")
        Me.cbEnteredInstitution.Properties.AutoHeight = CType(resources.GetObject("cbEnteredInstitution.Properties.AutoHeight"), Boolean)
        Me.cbEnteredInstitution.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEnteredInstitution.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbEnteredInstitution.Properties.NullText = resources.GetString("cbEnteredInstitution.Properties.NullText")
        Me.cbEnteredInstitution.Properties.NullValuePrompt = resources.GetString("cbEnteredInstitution.Properties.NullValuePrompt")
        Me.cbEnteredInstitution.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbEnteredInstitution.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbEnteredInstitution.Tag = "{R}"
        '
        'cbEntOfficer
        '
        resources.ApplyResources(Me.cbEntOfficer, "cbEntOfficer")
        Me.cbEntOfficer.Name = "cbEntOfficer"
        Me.cbEntOfficer.Properties.AccessibleDescription = resources.GetString("cbEntOfficer.Properties.AccessibleDescription")
        Me.cbEntOfficer.Properties.AccessibleName = resources.GetString("cbEntOfficer.Properties.AccessibleName")
        Me.cbEntOfficer.Properties.AutoHeight = CType(resources.GetObject("cbEntOfficer.Properties.AutoHeight"), Boolean)
        Me.cbEntOfficer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEntOfficer.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbEntOfficer.Properties.NullText = resources.GetString("cbEntOfficer.Properties.NullText")
        Me.cbEntOfficer.Properties.NullValuePrompt = resources.GetString("cbEntOfficer.Properties.NullValuePrompt")
        Me.cbEntOfficer.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbEntOfficer.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbEntOfficer.Tag = "{R}"
        '
        'dtEnteringDate
        '
        resources.ApplyResources(Me.dtEnteringDate, "dtEnteringDate")
        Me.dtEnteringDate.Name = "dtEnteringDate"
        Me.dtEnteringDate.Properties.AccessibleDescription = resources.GetString("dtEnteringDate.Properties.AccessibleDescription")
        Me.dtEnteringDate.Properties.AccessibleName = resources.GetString("dtEnteringDate.Properties.AccessibleName")
        Me.dtEnteringDate.Properties.AutoHeight = CType(resources.GetObject("dtEnteringDate.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        Me.dtEnteringDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtEnteringDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtEnteringDate.Properties.Buttons1"), CType(resources.GetObject("dtEnteringDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtEnteringDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtEnteringDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("dtEnteringDate.Properties.Buttons8"), CType(resources.GetObject("dtEnteringDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtEnteringDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtEnteringDate.Properties.Buttons11"), Boolean))})
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.AccessibleDescription")
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.AccessibleName")
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtEnteringDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue" & _
        ""), Boolean)
        Me.dtEnteringDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtEnteringDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteringDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtEnteringDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtEnteringDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtEnteringDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtEnteringDate.Properties.Mask.EditMask = resources.GetString("dtEnteringDate.Properties.Mask.EditMask")
        Me.dtEnteringDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteringDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteringDate.Properties.Mask.MaskType = CType(resources.GetObject("dtEnteringDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteringDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtEnteringDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtEnteringDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteringDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteringDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteringDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteringDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtEnteringDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtEnteringDate.Properties.NullValuePrompt = resources.GetString("dtEnteringDate.Properties.NullValuePrompt")
        Me.dtEnteringDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtEnteringDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtEnteringDate.Tag = "{R}"
        '
        'lblEnteringDate
        '
        resources.ApplyResources(Me.lblEnteringDate, "lblEnteringDate")
        Me.lblEnteringDate.Name = "lblEnteringDate"
        '
        'lblEnteredByInstitution
        '
        resources.ApplyResources(Me.lblEnteredByInstitution, "lblEnteredByInstitution")
        Me.lblEnteredByInstitution.Name = "lblEnteredByInstitution"
        '
        'lblEnteredByOfficer
        '
        resources.ApplyResources(Me.lblEnteredByOfficer, "lblEnteredByOfficer")
        Me.lblEnteredByOfficer.Name = "lblEnteredByOfficer"
        '
        'gbReported
        '
        resources.ApplyResources(Me.gbReported, "gbReported")
        Me.gbReported.Controls.Add(Me.cbRepSource)
        Me.gbReported.Controls.Add(Me.cbRepBy)
        Me.gbReported.Controls.Add(Me.dtReportingDate)
        Me.gbReported.Controls.Add(Me.lblSendingDate)
        Me.gbReported.Controls.Add(Me.lblSentByOfficer)
        Me.gbReported.Controls.Add(Me.lblSentByInstitution)
        Me.gbReported.Name = "gbReported"
        Me.gbReported.TabStop = False
        '
        'cbRepSource
        '
        resources.ApplyResources(Me.cbRepSource, "cbRepSource")
        Me.cbRepSource.Name = "cbRepSource"
        Me.cbRepSource.Properties.AccessibleDescription = resources.GetString("cbRepSource.Properties.AccessibleDescription")
        Me.cbRepSource.Properties.AccessibleName = resources.GetString("cbRepSource.Properties.AccessibleName")
        Me.cbRepSource.Properties.AutoHeight = CType(resources.GetObject("cbRepSource.Properties.AutoHeight"), Boolean)
        Me.cbRepSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRepSource.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRepSource.Properties.NullText = resources.GetString("cbRepSource.Properties.NullText")
        Me.cbRepSource.Properties.NullValuePrompt = resources.GetString("cbRepSource.Properties.NullValuePrompt")
        Me.cbRepSource.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRepSource.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRepSource.Tag = "{M}"
        '
        'cbRepBy
        '
        resources.ApplyResources(Me.cbRepBy, "cbRepBy")
        Me.cbRepBy.Name = "cbRepBy"
        Me.cbRepBy.Properties.AccessibleDescription = resources.GetString("cbRepBy.Properties.AccessibleDescription")
        Me.cbRepBy.Properties.AccessibleName = resources.GetString("cbRepBy.Properties.AccessibleName")
        Me.cbRepBy.Properties.AutoHeight = CType(resources.GetObject("cbRepBy.Properties.AutoHeight"), Boolean)
        Me.cbRepBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRepBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRepBy.Properties.NullText = resources.GetString("cbRepBy.Properties.NullText")
        Me.cbRepBy.Properties.NullValuePrompt = resources.GetString("cbRepBy.Properties.NullValuePrompt")
        Me.cbRepBy.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbRepBy.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbRepBy.Tag = "{M}"
        '
        'dtReportingDate
        '
        resources.ApplyResources(Me.dtReportingDate, "dtReportingDate")
        Me.dtReportingDate.Name = "dtReportingDate"
        Me.dtReportingDate.Properties.AccessibleDescription = resources.GetString("dtReportingDate.Properties.AccessibleDescription")
        Me.dtReportingDate.Properties.AccessibleName = resources.GetString("dtReportingDate.Properties.AccessibleName")
        Me.dtReportingDate.Properties.AutoHeight = CType(resources.GetObject("dtReportingDate.Properties.AutoHeight"), Boolean)
        Me.dtReportingDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtReportingDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtReportingDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.AccessibleDescription")
        Me.dtReportingDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.AccessibleName")
        Me.dtReportingDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtReportingDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValu" & _
        "e"), Boolean)
        Me.dtReportingDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtReportingDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReportingDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtReportingDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtReportingDate.Properties.Mask.EditMask = resources.GetString("dtReportingDate.Properties.Mask.EditMask")
        Me.dtReportingDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportingDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportingDate.Properties.Mask.MaskType = CType(resources.GetObject("dtReportingDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportingDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtReportingDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtReportingDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtReportingDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtReportingDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportingDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportingDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReportingDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReportingDate.Properties.NullValuePrompt = resources.GetString("dtReportingDate.Properties.NullValuePrompt")
        Me.dtReportingDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReportingDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtReportingDate.Tag = "{M}"
        '
        'lblSendingDate
        '
        resources.ApplyResources(Me.lblSendingDate, "lblSendingDate")
        Me.lblSendingDate.Name = "lblSendingDate"
        '
        'lblSentByOfficer
        '
        resources.ApplyResources(Me.lblSentByOfficer, "lblSentByOfficer")
        Me.lblSentByOfficer.Name = "lblSentByOfficer"
        '
        'lblSentByInstitution
        '
        resources.ApplyResources(Me.lblSentByInstitution, "lblSentByInstitution")
        Me.lblSentByInstitution.Name = "lblSentByInstitution"
        '
        'gbReceived
        '
        resources.ApplyResources(Me.gbReceived, "gbReceived")
        Me.gbReceived.Controls.Add(Me.cbReceivedInst)
        Me.gbReceived.Controls.Add(Me.cbReceivedBy)
        Me.gbReceived.Controls.Add(Me.dtReceivedDate)
        Me.gbReceived.Controls.Add(Me.lblReceivedByInstitution)
        Me.gbReceived.Controls.Add(Me.lblReceivedByOfficer)
        Me.gbReceived.Controls.Add(Me.lblReceivingDate)
        Me.gbReceived.Name = "gbReceived"
        Me.gbReceived.TabStop = False
        '
        'cbReceivedInst
        '
        resources.ApplyResources(Me.cbReceivedInst, "cbReceivedInst")
        Me.cbReceivedInst.Name = "cbReceivedInst"
        Me.cbReceivedInst.Properties.AccessibleDescription = resources.GetString("cbReceivedInst.Properties.AccessibleDescription")
        Me.cbReceivedInst.Properties.AccessibleName = resources.GetString("cbReceivedInst.Properties.AccessibleName")
        Me.cbReceivedInst.Properties.AutoHeight = CType(resources.GetObject("cbReceivedInst.Properties.AutoHeight"), Boolean)
        Me.cbReceivedInst.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedInst.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReceivedInst.Properties.NullText = resources.GetString("cbReceivedInst.Properties.NullText")
        Me.cbReceivedInst.Properties.NullValuePrompt = resources.GetString("cbReceivedInst.Properties.NullValuePrompt")
        Me.cbReceivedInst.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbReceivedInst.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbReceivedInst.Tag = ""
        '
        'cbReceivedBy
        '
        resources.ApplyResources(Me.cbReceivedBy, "cbReceivedBy")
        Me.cbReceivedBy.Name = "cbReceivedBy"
        Me.cbReceivedBy.Properties.AccessibleDescription = resources.GetString("cbReceivedBy.Properties.AccessibleDescription")
        Me.cbReceivedBy.Properties.AccessibleName = resources.GetString("cbReceivedBy.Properties.AccessibleName")
        Me.cbReceivedBy.Properties.AutoHeight = CType(resources.GetObject("cbReceivedBy.Properties.AutoHeight"), Boolean)
        Me.cbReceivedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReceivedBy.Properties.NullText = resources.GetString("cbReceivedBy.Properties.NullText")
        Me.cbReceivedBy.Properties.NullValuePrompt = resources.GetString("cbReceivedBy.Properties.NullValuePrompt")
        Me.cbReceivedBy.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbReceivedBy.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbReceivedBy.Tag = ""
        '
        'dtReceivedDate
        '
        resources.ApplyResources(Me.dtReceivedDate, "dtReceivedDate")
        Me.dtReceivedDate.Name = "dtReceivedDate"
        Me.dtReceivedDate.Properties.AccessibleDescription = resources.GetString("dtReceivedDate.Properties.AccessibleDescription")
        Me.dtReceivedDate.Properties.AccessibleName = resources.GetString("dtReceivedDate.Properties.AccessibleName")
        Me.dtReceivedDate.Properties.AutoHeight = CType(resources.GetObject("dtReceivedDate.Properties.AutoHeight"), Boolean)
        Me.dtReceivedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtReceivedDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtReceivedDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtReceivedDate.Properties.CalendarTimeProperties.AccessibleDescription")
        Me.dtReceivedDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtReceivedDate.Properties.CalendarTimeProperties.AccessibleName")
        Me.dtReceivedDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtReceivedDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReceivedDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtReceivedDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtReceivedDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReceivedDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue" & _
        ""), Boolean)
        Me.dtReceivedDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtReceivedDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtReceivedDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtReceivedDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtReceivedDate.Properties.Mask.EditMask = resources.GetString("dtReceivedDate.Properties.Mask.EditMask")
        Me.dtReceivedDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReceivedDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReceivedDate.Properties.Mask.MaskType = CType(resources.GetObject("dtReceivedDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReceivedDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtReceivedDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtReceivedDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtReceivedDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtReceivedDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReceivedDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReceivedDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtReceivedDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtReceivedDate.Properties.NullValuePrompt = resources.GetString("dtReceivedDate.Properties.NullValuePrompt")
        Me.dtReceivedDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtReceivedDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtReceivedDate.Tag = ""
        '
        'lblReceivedByInstitution
        '
        resources.ApplyResources(Me.lblReceivedByInstitution, "lblReceivedByInstitution")
        Me.lblReceivedByInstitution.Name = "lblReceivedByInstitution"
        '
        'lblReceivedByOfficer
        '
        resources.ApplyResources(Me.lblReceivedByOfficer, "lblReceivedByOfficer")
        Me.lblReceivedByOfficer.Name = "lblReceivedByOfficer"
        '
        'lblReceivingDate
        '
        resources.ApplyResources(Me.lblReceivingDate, "lblReceivingDate")
        Me.lblReceivingDate.Name = "lblReceivingDate"
        '
        'AggregateHeader
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.gbReported)
        Me.Controls.Add(Me.gbReceived)
        Me.Controls.Add(Me.gbEntered)
        Me.Controls.Add(Me.gbGeneral)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "AggregateHeader"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.gbGeneral.ResumeLayout(False)
        CType(Me.cbYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbQuarter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbWeek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEntered.ResumeLayout(False)
        CType(Me.cbEnteredInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEntOfficer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteringDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteringDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReported.ResumeLayout(False)
        CType(Me.cbRepSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRepBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReceived.ResumeLayout(False)
        CType(Me.cbReceivedInst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReceivedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReceivedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReceivedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cbYear As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbSettlement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSettlement As System.Windows.Forms.Label
    Friend WithEvents cbRayon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblRayon As System.Windows.Forms.Label
    Friend WithEvents cbRegion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents datDay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblCaseID As System.Windows.Forms.Label
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents cbMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbQuarter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblQuarter As System.Windows.Forms.Label
    Friend WithEvents lblWeek As System.Windows.Forms.Label
    Friend WithEvents cbWeek As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gbEntered As System.Windows.Forms.GroupBox
    Friend WithEvents gbReported As System.Windows.Forms.GroupBox
    Friend WithEvents gbReceived As System.Windows.Forms.GroupBox
    Friend WithEvents lblSendingDate As System.Windows.Forms.Label
    Friend WithEvents cbRepSource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbRepBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSentByOfficer As System.Windows.Forms.Label
    Friend WithEvents lblSentByInstitution As System.Windows.Forms.Label
    Friend WithEvents dtReportingDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblReceivedByInstitution As System.Windows.Forms.Label
    Friend WithEvents lblReceivedByOfficer As System.Windows.Forms.Label
    Friend WithEvents cbReceivedInst As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbReceivedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtReceivedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblReceivingDate As System.Windows.Forms.Label
    Friend WithEvents cbEnteredInstitution As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEnteringDate As System.Windows.Forms.Label
    Friend WithEvents lblEnteredByInstitution As System.Windows.Forms.Label
    Friend WithEvents lblEnteredByOfficer As System.Windows.Forms.Label
    Friend WithEvents cbEntOfficer As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtEnteringDate As DevExpress.XtraEditors.DateEdit

End Class
