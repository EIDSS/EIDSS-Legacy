Imports System.ComponentModel
Imports System.Reflection
Imports System.Collections.Generic
Imports eidss.model.Core
Imports eidss.model.Resources
Imports bv.winclient.BasePanel
Imports eidss.winclient.Vet
Imports bv.model.Model.Core
Imports eidss.winclient.Human
Imports bv.common.Resources
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports eidss.model.Enums

Public Class FarmPanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "

    Public FarmDbService As FarmPanel_DB
    Public Sub New()
        MyBase.New()
        Try
            InitializeComponent()
            'Add any initialization after the InitializeComponent() call
            FarmDbService = New FarmPanel_DB
            DbService = FarmDbService
            pnFarmLocation.Visible = True
            pnFarmLocation.Enabled = Not [ReadOnly]
            AddressPanel.Visible = True
            AddressPanel.Enabled = Not [ReadOnly]
            RegisterChildObject(pnFarmLocation, RelatedPostOrder.PostFirst)
            RegisterChildObject(AddressPanel, RelatedPostOrder.PostFirst)
        Catch ex As Exception
            MessageForm.Show(ex.ToString)
        End Try
        'This call is required by the Windows Form Designer.
    End Sub

    Public Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomMandatoryField(txtFarm, CustomMandatoryField.VetCase_Farm_FarmName)
        MandatoryFieldHelper.SetCustomMandatoryField(txtFarmOwnerFirst, CustomMandatoryField.VetCase_Farm_FarmOwnerFirstName)
        MandatoryFieldHelper.SetCustomMandatoryField(txtFarmOwnerLast, CustomMandatoryField.VetCase_Farm_FarmOwnerLastName)
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
    Friend WithEvents txtFarm As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNatName As DevExpress.XtraEditors.TextEdit
    '<System.Diagnostics.DebuggerStepThrough()> 
    Friend WithEvents txtFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbFax As System.Windows.Forms.Label
    Friend WithEvents lbFarmID As System.Windows.Forms.Label
    Friend WithEvents lbFarmName As System.Windows.Forms.Label
    Friend WithEvents lbPhone As System.Windows.Forms.Label
    Friend WithEvents lbFarmOwner As System.Windows.Forms.Label
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbEmail As System.Windows.Forms.Label
    Friend WithEvents pnFarmLocation As eidss.ExactLocationPanel
    Friend WithEvents txtFarmOwner As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtFarmOwnerLast As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFarmOwnerFirst As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFarmOwnerMiddle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents AddressPanel As eidss.AddressLookup
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FarmPanel))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtFarm = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.lbFarmName = New System.Windows.Forms.Label()
        Me.txtNatName = New DevExpress.XtraEditors.TextEdit()
        Me.lbPhone = New System.Windows.Forms.Label()
        Me.lbFarmID = New System.Windows.Forms.Label()
        Me.lbFarmOwner = New System.Windows.Forms.Label()
        Me.txtFax = New DevExpress.XtraEditors.TextEdit()
        Me.lbFax = New System.Windows.Forms.Label()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.lbEmail = New System.Windows.Forms.Label()
        Me.pnFarmLocation = New EIDSS.ExactLocationPanel()
        Me.AddressPanel = New EIDSS.AddressLookup()
        Me.txtFarmOwner = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtFarmOwnerLast = New DevExpress.XtraEditors.TextEdit()
        Me.txtFarmOwnerFirst = New DevExpress.XtraEditors.TextEdit()
        Me.txtFarmOwnerMiddle = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.txtFarm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNatName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmOwner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmOwnerLast.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmOwnerFirst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmOwnerMiddle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFarm
        '
        resources.ApplyResources(Me.txtFarm, "txtFarm")
        Me.txtFarm.Name = "txtFarm"
        Me.txtFarm.Properties.Appearance.Font = CType(resources.GetObject("txtFarm.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtFarm.Properties.Appearance.Options.UseFont = True
        Me.txtFarm.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtFarm.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtFarm.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFarm.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtFarm.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtFarm.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFarm.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtFarm.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtFarm.Properties.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject2, "SerializableAppearanceObject2")
        SerializableAppearanceObject2.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject3, "SerializableAppearanceObject3")
        SerializableAppearanceObject3.Options.UseFont = True
        Me.txtFarm.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarm.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarm.Properties.Buttons1"), CType(resources.GetObject("txtFarm.Properties.Buttons2"), Integer), CType(resources.GetObject("txtFarm.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarm.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtFarm.Properties.Buttons8"), CType(resources.GetObject("txtFarm.Properties.Buttons9"), Object), CType(resources.GetObject("txtFarm.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarm.Properties.Buttons11"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarm.Properties.Buttons12"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarm.Properties.Buttons13"), CType(resources.GetObject("txtFarm.Properties.Buttons14"), Integer), CType(resources.GetObject("txtFarm.Properties.Buttons15"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons16"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons17"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons18"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarm.Properties.Buttons19"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtFarm.Properties.Buttons20"), CType(resources.GetObject("txtFarm.Properties.Buttons21"), Object), CType(resources.GetObject("txtFarm.Properties.Buttons22"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarm.Properties.Buttons23"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarm.Properties.Buttons24"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarm.Properties.Buttons25"), CType(resources.GetObject("txtFarm.Properties.Buttons26"), Integer), CType(resources.GetObject("txtFarm.Properties.Buttons27"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons28"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons29"), Boolean), CType(resources.GetObject("txtFarm.Properties.Buttons30"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarm.Properties.Buttons31"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("txtFarm.Properties.Buttons32"), CType(resources.GetObject("txtFarm.Properties.Buttons33"), Object), CType(resources.GetObject("txtFarm.Properties.Buttons34"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarm.Properties.Buttons35"), Boolean))})
        Me.txtFarm.Tag = "{K}[en]"
        '
        'txtPhone
        '
        resources.ApplyResources(Me.txtPhone, "txtPhone")
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Properties.Appearance.Font = CType(resources.GetObject("txtPhone.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.Appearance.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'lbFarmName
        '
        resources.ApplyResources(Me.lbFarmName, "lbFarmName")
        Me.lbFarmName.Name = "lbFarmName"
        '
        'txtNatName
        '
        resources.ApplyResources(Me.txtNatName, "txtNatName")
        Me.txtNatName.Name = "txtNatName"
        Me.txtNatName.Properties.Appearance.Font = CType(resources.GetObject("txtNatName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtNatName.Properties.Appearance.Options.UseFont = True
        Me.txtNatName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtNatName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtNatName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNatName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtNatName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtNatName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNatName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtNatName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtNatName.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'lbPhone
        '
        resources.ApplyResources(Me.lbPhone, "lbPhone")
        Me.lbPhone.Name = "lbPhone"
        '
        'lbFarmID
        '
        resources.ApplyResources(Me.lbFarmID, "lbFarmID")
        Me.lbFarmID.Name = "lbFarmID"
        '
        'lbFarmOwner
        '
        resources.ApplyResources(Me.lbFarmOwner, "lbFarmOwner")
        Me.lbFarmOwner.Name = "lbFarmOwner"
        '
        'txtFax
        '
        resources.ApplyResources(Me.txtFax, "txtFax")
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.Appearance.Font = CType(resources.GetObject("txtFax.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtFax.Properties.Appearance.Options.UseFont = True
        Me.txtFax.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtFax.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtFax.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFax.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtFax.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtFax.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFax.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtFax.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtFax.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'lbFax
        '
        resources.ApplyResources(Me.lbFax, "lbFax")
        Me.lbFax.Name = "lbFax"
        '
        'txtEmail
        '
        resources.ApplyResources(Me.txtEmail, "txtEmail")
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.Appearance.Font = CType(resources.GetObject("txtEmail.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtEmail.Properties.Appearance.Options.UseFont = True
        Me.txtEmail.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtEmail.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmail.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtEmail.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtEmail.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEmail.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtEmail.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtEmail.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'lbEmail
        '
        resources.ApplyResources(Me.lbEmail, "lbEmail")
        Me.lbEmail.Name = "lbEmail"
        '
        'pnFarmLocation
        '
        Me.pnFarmLocation.Appearance.Font = CType(resources.GetObject("pnFarmLocation.Appearance.Font"), System.Drawing.Font)
        Me.pnFarmLocation.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.pnFarmLocation, "pnFarmLocation")
        Me.pnFarmLocation.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.pnFarmLocation.FormID = Nothing
        Me.pnFarmLocation.HelpTopicID = Nothing
        Me.pnFarmLocation.IsStatusReadOnly = False
        Me.pnFarmLocation.KeyFieldName = Nothing
        Me.pnFarmLocation.MultiSelect = False
        Me.pnFarmLocation.Name = "pnFarmLocation"
        Me.pnFarmLocation.ObjectName = Nothing
        Me.pnFarmLocation.PersonalDataTypes = Nothing
        Me.pnFarmLocation.Status = bv.common.win.FormStatus.Draft
        Me.pnFarmLocation.TableName = Nothing
        '
        'AddressPanel
        '
        resources.ApplyResources(Me.AddressPanel, "AddressPanel")
        Me.AddressPanel.Appearance.BackColor = CType(resources.GetObject("AddressPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.AddressPanel.Appearance.Font = CType(resources.GetObject("AddressPanel.Appearance.Font"), System.Drawing.Font)
        Me.AddressPanel.Appearance.Options.UseBackColor = True
        Me.AddressPanel.Appearance.Options.UseFont = True
        Me.AddressPanel.CanExpand = True
        Me.AddressPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.AddressPanel.FormID = Nothing
        Me.AddressPanel.HelpTopicID = Nothing
        Me.AddressPanel.IsStatusReadOnly = False
        Me.AddressPanel.KeyFieldName = "idfGeoLocation"
        Me.AddressPanel.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AddressPanel.MandatoryFields = EIDSS.AddressMandatoryFieldsType.Rayon
        Me.AddressPanel.MultiSelect = False
        Me.AddressPanel.Name = "AddressPanel"
        Me.AddressPanel.ObjectName = "Address"
        Me.AddressPanel.PopupEditHeight = 200
        Me.AddressPanel.ShowResidenceType = False
        Me.AddressPanel.Status = bv.common.win.FormStatus.Draft
        Me.AddressPanel.TableName = "Address"
        Me.AddressPanel.UseParentBackColor = True
        '
        'txtFarmOwner
        '
        resources.ApplyResources(Me.txtFarmOwner, "txtFarmOwner")
        Me.txtFarmOwner.Name = "txtFarmOwner"
        resources.ApplyResources(SerializableAppearanceObject4, "SerializableAppearanceObject4")
        SerializableAppearanceObject4.Options.UseFont = True
        Me.txtFarmOwner.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmOwner.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtFarmOwner.Properties.Buttons1"), CType(resources.GetObject("txtFarmOwner.Properties.Buttons2"), Integer), CType(resources.GetObject("txtFarmOwner.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtFarmOwner.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtFarmOwner.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtFarmOwner.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtFarmOwner.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("txtFarmOwner.Properties.Buttons8"), CType(resources.GetObject("txtFarmOwner.Properties.Buttons9"), Object), CType(resources.GetObject("txtFarmOwner.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtFarmOwner.Properties.Buttons11"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtFarmOwner.Properties.Buttons12"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtFarmOwner.TabStop = False
        '
        'txtFarmOwnerLast
        '
        resources.ApplyResources(Me.txtFarmOwnerLast, "txtFarmOwnerLast")
        Me.txtFarmOwnerLast.Name = "txtFarmOwnerLast"
        Me.txtFarmOwnerLast.Properties.AutoHeight = CType(resources.GetObject("txtFarmOwnerLast.Properties.AutoHeight"), Boolean)
        Me.txtFarmOwnerLast.Properties.NullText = resources.GetString("txtFarmOwnerLast.Properties.NullText")
        '
        'txtFarmOwnerFirst
        '
        resources.ApplyResources(Me.txtFarmOwnerFirst, "txtFarmOwnerFirst")
        Me.txtFarmOwnerFirst.Name = "txtFarmOwnerFirst"
        Me.txtFarmOwnerFirst.Properties.AutoHeight = CType(resources.GetObject("txtFarmOwnerFirst.Properties.AutoHeight"), Boolean)
        Me.txtFarmOwnerFirst.Properties.NullText = resources.GetString("txtFarmOwnerFirst.Properties.NullText")
        '
        'txtFarmOwnerMiddle
        '
        resources.ApplyResources(Me.txtFarmOwnerMiddle, "txtFarmOwnerMiddle")
        Me.txtFarmOwnerMiddle.Name = "txtFarmOwnerMiddle"
        Me.txtFarmOwnerMiddle.Properties.AutoHeight = CType(resources.GetObject("txtFarmOwnerMiddle.Properties.AutoHeight"), Boolean)
        Me.txtFarmOwnerMiddle.Properties.NullText = resources.GetString("txtFarmOwnerMiddle.Properties.NullText")
        '
        'PanelControl1
        '
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.txtFarmOwnerLast)
        Me.PanelControl1.Controls.Add(Me.txtFarmOwnerMiddle)
        Me.PanelControl1.Controls.Add(Me.txtFarmOwnerFirst)
        Me.PanelControl1.Name = "PanelControl1"
        '
        'FarmPanel
        '
        Me.Appearance.Font = CType(resources.GetObject("FarmPanel.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.txtFarmOwner)
        Me.Controls.Add(Me.pnFarmLocation)
        Me.Controls.Add(Me.AddressPanel)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lbEmail)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.lbFax)
        Me.Controls.Add(Me.txtFarm)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.lbFarmName)
        Me.Controls.Add(Me.txtNatName)
        Me.Controls.Add(Me.lbFarmID)
        Me.Controls.Add(Me.lbFarmOwner)
        Me.Controls.Add(Me.lbPhone)
        Me.KeyFieldName = "idfFarm"
        Me.Name = "FarmPanel"
        Me.ObjectName = "Farm"
        Me.TableName = "Farm"
        CType(Me.txtFarm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNatName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmOwner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmOwnerLast.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmOwnerFirst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmOwnerMiddle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    <Browsable(False), DefaultValue(PersonalDataGroup.None), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property HidePersonalData As Boolean

    Protected Overrides Sub DefineBinding()
        If IsDesignMode() Then Return
        'Farm binding
        Dim group As PersonalDataGroup = PersonalDataGroup.None
        If HidePersonalData Then
            If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details) Then
                group = PersonalDataGroup.Vet_Farm_Details
            ElseIf EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement) Then
                group = PersonalDataGroup.Vet_Farm_Settlement
            End If
        End If

        eventManager.RemoveDataHandler(Farm_DB.TableFarm + ".strFarmCode")
        Core.LookupBinder.BindPersonalDataTextEdit(txtFarm, baseDataSet, Farm_DB.TableFarm + ".strFarmCode", group, False)
        If (Not ParentObject Is Nothing And TypeOf (ParentObject) Is FarmDetail) Then
            txtFarm.Properties.Buttons.Clear()
        End If
        AddHandler baseDataSet.Tables(Farm_DB.TableFarm).ColumnChanging, AddressOf DataChanging
        AddHandler baseDataSet.Tables(Farm_DB.TableFarm).ColumnChanged, AddressOf DataChanged
        Core.LookupBinder.BindPersonalDataTextEdit(txtNatName, baseDataSet, Farm_DB.TableFarm + ".strNationalName", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtEmail, baseDataSet, Farm_DB.TableFarm + ".strEmail", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtFax, baseDataSet, Farm_DB.TableFarm + ".strFax", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtPhone, baseDataSet, Farm_DB.TableFarm + ".strContactPhone", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtFarmOwner, baseDataSet, Farm_DB.TableFarm + ".strFullName", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtFarmOwnerFirst, baseDataSet, Farm_DB.TableFarm + ".strOwnerFirstName", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtFarmOwnerMiddle, baseDataSet, Farm_DB.TableFarm + ".strOwnerMiddleName", group, False)
        Core.LookupBinder.BindPersonalDataTextEdit(txtFarmOwnerLast, baseDataSet, Farm_DB.TableFarm + ".strOwnerLastName", group, False)
        pnFarmLocation.DataBindings.Add("ID", baseDataSet, Farm_DB.TableFarm + ".idfFarmLocation")
        pnFarmLocation.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Vet_Farm_Coordinates}
        pnFarmLocation.IgnorePersonalData = Not HidePersonalData
        AddressPanel.DataBindings.Add("ID", baseDataSet, Farm_DB.TableFarm + ".idfFarmAddress")
        AddressPanel.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Vet_Farm_Details, PersonalDataGroup.Vet_Farm_Settlement}
        AddressPanel.IgnorePersonalData = Not HidePersonalData
        eventManager.AttachDataHandler(Farm_DB.TableFarm + ".strFarmCode", AddressOf FarmIDChanged)
        pnFarmLocation.RelatedAddress = AddressPanel
        If [ReadOnly] Then
            For Each btn As DevExpress.XtraEditors.Controls.EditorButton In Me.txtFarm.Properties.Buttons
                btn.Enabled = False
                btn.Visible = False
            Next
        End If
        If [ReadOnly] Then
            For Each btn As DevExpress.XtraEditors.Controls.EditorButton In Me.txtFarmOwner.Properties.Buttons
                btn.Enabled = False
                btn.Visible = False
            Next
        End If

    End Sub
    Private Sub FarmPanel_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterLoadData
        If (CType(ParentObject, BaseForm).State And BusinessObjectState.NewObject) <> 0 AndAlso Not CType(ParentObject, BaseForm).StartUpParameters Is Nothing Then
            Dim params As Dictionary(Of String, Object) = CType(ParentObject, BaseForm).StartUpParameters
            If params.ContainsKey("idfsCounty") Then
                AddressPanel.CountryID = params("idfsCounty")
            End If
            If params.ContainsKey("idfsRegion") Then
                AddressPanel.RegionID = params("idfsRegion")
            End If
            If params.ContainsKey("idfsRayon") Then
                AddressPanel.RayonID = params("idfsRayon")
            End If
            If params.ContainsKey("idfsSettlement") Then
                AddressPanel.SettlementID = params("idfsSettlement")
            End If
        End If
    End Sub

    Private Sub DataChanging(ByVal Sender As Object, ByVal e As DataColumnChangeEventArgs)
        If e.Column.ColumnName = "idfFarmAddress" AndAlso Not e.ProposedValue.Equals(e.Row("idfFarmAddress")) Then
            Dbg.Debug("address ID is changing from {0} to {1}", e.Row("idfFarmAddress"), e.ProposedValue)
            Dbg.Debug("address panel ID : {0}", AddressPanel.ID)
            Dbg.Debug("stack:{0}", New StackTrace().ToString)
        End If
    End Sub
    Private Sub DataChanged(ByVal Sender As Object, ByVal e As DataColumnChangeEventArgs)
        If e.Column.ColumnName = "idfFarmAddress" AndAlso Not e.ProposedValue.Equals(e.Row("idfFarmAddress")) Then
            Dbg.Debug("address ID is changed from {0} to {1}", e.Row("idfFarmAddress"), e.ProposedValue)
            Dbg.Debug("address panel ID : {0}", AddressPanel.ID)
            Dbg.Debug("stack:{0}", New StackTrace().ToString)
        End If
    End Sub

#Region "Farm Management"
    Public Sub FarmIDChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not m_FreezeFarmIDChanged Then
            RaiseFarmIDCodeChangedEvent(e.Value)
        End If
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public ReadOnly Property FarmID() As Object
        Get
            Return GetKey(FarmPanel_DB.TableFarm)
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property RootFarmID() As Object
        Get
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                Return row("idfRootFarm")
            End If
            Return DBNull.Value
        End Get
        Set(ByVal Value As Object)
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                row("idfRootFarm") = Value
            End If
        End Set
    End Property
    '1 -livestock, 2 - avian
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Private m_FarmKind As Integer = 0 '1 -livestock, 2 - avian
    Public Property FarmKind() As Integer
        Get
            Return m_FarmKind
        End Get
        Set(ByVal Value As Integer)
            m_FarmKind = Value
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                If (Value And 1) > 0 Then
                    row("blnIsLivestock") = 1
                    row("blnIsAvian") = DBNull.Value
                End If
                If (Value And 2) > 0 Then
                    row("blnIsAvian") = 1
                    row("blnIsLivestock") = DBNull.Value
                End If
            End If
        End Set
    End Property

    Private m_FreezeFarmIDChanged As Boolean = False
    Private Sub PopulateFarmInfo(ByVal aFarmID As Object)
        m_FreezeFarmIDChanged = True
        Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
        Dim idfFarm As Object = row("idfFarm")
        Dim idfFarmLocation As Object = row("idfFarmLocation")
        Dim idfFarmAddress As Object = row("idfFarmAddress")
        Dim blnRootFarm As Object = row("blnRootFarm")
        Dim oldRowState As DataRowState = row.RowState
        LoadData(aFarmID)

        For Each child As IRelatedObject In ParentObject.Children
            If TypeOf child Is AvianFarmDetail Then
                child.LoadData(aFarmID)
                row = CType(child, BaseForm).GetCurrentRow(AvianFarmDetail_DB.TableFarm)
                If Not row Is Nothing Then
                    row("idfFarm") = idfFarm
                End If
            End If
        Next

        FarmKind = m_FarmKind
        row = GetCurrentRow(Farm_DB.TableFarm)
        row("idfFarm") = idfFarm
        row("idfFarmLocation") = idfFarmLocation
        row("idfFarmAddress") = idfFarmAddress
        row("blnRootFarm") = blnRootFarm
        row.AcceptChanges()
        If oldRowState = DataRowState.Added Then
            row.SetAdded()
        Else
            row.SetModified()
        End If
        AddressPanel.baseDataSet.Tables("Address").Rows(0)("idfGeoLocation") = idfFarmAddress
        pnFarmLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfGeoLocation") = idfFarmLocation
        If Utils.IsEmpty(CaseID) Then
            RootFarmID = DBNull.Value
        Else
            row("idfCase") = CaseID
            RootFarmID = aFarmID
        End If
        RaiseFarmChangedEvent(aFarmID)
        m_FreezeFarmIDChanged = False
    End Sub

    Private Sub EditFarm()
        Dim m_FarmID As Object = FarmID
        If Not (m_FarmID Is Nothing) Then
            If Post(PostType.IntermediatePosting) = False Then
                Return
            End If
            If BaseFormManager.ShowModal(New FarmDetail, FindForm, m_FarmID, Nothing, Nothing) = True Then
                PopulateFarmInfo(m_FarmID)
            End If
        End If
    End Sub

    Private Sub SelectFarm()
        Dim oldFarmID As Object = FarmID

        Dim r As IObject = BaseFormManager.ShowForSelection(New FarmListPanel, FindForm, , 1024, 800)
        If Not r Is Nothing Then
            Dim newFarmID As Object = r.Key
            If (RaiseFarmChangingEvent(newFarmID, oldFarmID) = True) Then
                PopulateFarmInfo(newFarmID)
            End If
        End If

    End Sub

    Public Sub NewFarm()
        Dim oldFarmID As Object = FarmID
        Dim ID As Object = Nothing
        Dim f As New FarmDetail
        f.IsRootFarm = True
        If BaseFormManager.ShowModal(f, FindForm, ID, Nothing, Nothing) = True Then
            If (RaiseFarmChangingEvent(ID, oldFarmID) = True) Then
                PopulateFarmInfo(ID)
            End If
        End If
    End Sub

    Private Sub DeleteFarm()
        If (RaiseFarmChangingEvent(Nothing, FarmID) = True) Then
            baseDataSet.Clear()
            baseDataSet.AcceptChanges()
        End If
    End Sub
    Private Sub RebindFarmLocation()
        pnFarmLocation.DataBindings.Clear()
        pnFarmLocation.DataBindings.Add("ID", baseDataSet, "FarmLoc.idfGeoLocation")
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public ReadOnly Property FarmName() As String
        Get
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                Return Utils.Str(row("strNationalName"))
            End If
            Return Nothing
        End Get
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public ReadOnly Property FarmCode() As String
        Get
            If txtFarm.DataBindings.Count = 0 Then
                Return "*"
            End If
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                Return Utils.Str(row("strFarmCode"))
            End If
            Return Nothing
        End Get
    End Property

#End Region

#Region "Farm Owner Management"
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    ReadOnly Property FarmOwnerID() As Object
        Get
            If baseDataSet.Tables(Farm_DB.TableFarm).Rows.Count = 0 Then
                Return Nothing
            Else
                Return baseDataSet.Tables(Farm_DB.TableFarm).Rows(0)("idfOwner")
            End If
        End Get
    End Property
    Function GetOwnerName(ByVal owner As IObject) As String
        Dim name As String = ""
        If Not Utils.IsEmpty(owner.GetValue("strLastName")) Then
            name += Utils.Str(owner.GetValue("strLastName")) + " "
        End If
        If Not Utils.IsEmpty(owner.GetValue("strFirstName")) Then
            name += Utils.Str(owner.GetValue("strFirstName")) + " "
        End If
        If Not Utils.IsEmpty(owner.GetValue("strSecondName")) Then
            name += Utils.Str(owner.GetValue("strSecondName"))
        End If
        Return name.Trim
    End Function
    Function GetOwnerName(ByVal patientInfo As ArrayList) As String
        Dim name As String = ""
        If patientInfo Is Nothing OrElse patientInfo.Count <> 3 Then Return ""
        If Not Utils.IsEmpty(patientInfo(2)) Then
            name += Utils.Str(patientInfo(2)) + " "
        End If
        If Not Utils.IsEmpty(patientInfo(0)) Then
            name += Utils.Str(patientInfo(0)) + " "
        End If
        If Not Utils.IsEmpty(patientInfo(1)) Then
            name += Utils.Str(patientInfo(1))
        End If
        Return name.Trim
    End Function
    Private Sub PopulateFarmOwnerInfo(ByVal sourceOwner As IObject)
        If sourceOwner Is Nothing Then
            FarmDbService.DeleteFarmOwnerLink(baseDataSet)
        Else
            FarmDbService.SetOwner(baseDataSet, sourceOwner.Key, GetOwnerName(sourceOwner), CStr(sourceOwner.GetValue("strFirstName")), CStr(sourceOwner.GetValue("strSecondName")), CStr(sourceOwner.GetValue("strLastName")))
        End If
    End Sub
    Private Sub PopulateFarmOwnerInfo(ByVal patientForm As BaseForm)
        Dim mi As MethodInfo = patientForm.GetType().GetMethod("GetPatientInfo")
        If Not mi Is Nothing Then
            Dim patientInfo As ArrayList
            patientInfo = CType(mi.Invoke(patientForm, Nothing), ArrayList)
            FarmDbService.SetOwner(baseDataSet, patientForm.GetKey(), GetOwnerName(patientInfo), Utils.Str(patientInfo(0)), Utils.Str(patientInfo(1)), Utils.Str(patientInfo(2)))
        End If
    End Sub

    Private Sub EditOwner()
        If Not Utils.IsEmpty(FarmOwnerID) Then
            Dim PatientDetailForm As BaseForm = CType(ClassLoader.LoadClass("PatientDetail"), BaseForm)
            If BaseFormManager.ShowModal(PatientDetailForm, FindForm, FarmOwnerID, Nothing, Nothing) = True Then
                PopulateFarmOwnerInfo(PatientDetailForm)
            End If
        Else
            NewOwner()
        End If
    End Sub

    Private Sub SelectOwner()

        Dim r As IObject = BaseFormManager.ShowForSelection(New PatientListPanel, FindForm, , 1024, 800)
        If Not r Is Nothing Then
            PopulateFarmOwnerInfo(r)
        End If

    End Sub

    Public Sub NewOwner()
        Dim ID As Object = Nothing
        Dim PatientDetailForm As BaseForm = CType(ClassLoader.LoadClass("PatientDetail"), BaseForm)
        If BaseFormManager.ShowModal(PatientDetailForm, FindForm, ID, FarmID, Nothing) = True Then
            PopulateFarmOwnerInfo(PatientDetailForm)
        End If
    End Sub

    Private Sub DeleteOwner()
        If Not WinUtils.ConfirmLookupClear() Then
            Return
        End If
        FarmDbService.DeleteFarmOwnerLink(baseDataSet)
    End Sub
#End Region

    Private Sub txtFarm_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFarm.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            EditFarm()
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            SelectFarm()
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
            NewFarm()
        End If

    End Sub

    Private Sub txtFarmOwner_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFarmOwner.Properties.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            EditOwner()
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            SelectOwner()
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
            NewOwner()
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            DeleteOwner()
        End If
    End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is pnFarmLocation Then
            Return GetKey(Farm_DB.TableFarm, "idfFarmLocation")
        ElseIf child Is AddressPanel Then
            Return GetKey(Farm_DB.TableFarm, "idfFarmAddress")
        Else
            Return MyBase.GetChildKey(child)
        End If

    End Function
    'Function SetFarmLocationLink(ByVal ID As Object) As Boolean
    '    Me.FarmDbService.SetFarmLocationLink(baseDataSet, ID, FarmID)
    'End Function

    'Function SetFarmAddressLink(ByVal ID As Object) As Boolean
    '    Me.FarmDbService.SetFarmAddressLink(baseDataSet, ID, FarmID)
    'End Function
    Private Function RaiseFarmChangingEvent(ByVal newFarmID As Object, ByVal OldFarmID As Object) As Boolean
        Dim Cancel As Boolean
        RaiseEvent OnFarmChanging(newFarmID, OldFarmID, Cancel)
        Return Not Cancel
    End Function
    Private Function RaiseFarmChangedEvent(ByVal newFarmID As Object) As Boolean
        RaiseEvent OnFarmChanged(newFarmID)
    End Function
    Private Function RaiseFarmIDCodeChangedEvent(ByVal newFarmIDCode As Object) As Boolean
        RaiseEvent OnFarmCodeChanged(newFarmIDCode)
    End Function
    Public Event OnFarmChanging As ValueChanging
    Public Event OnFarmChanged As ValueChanged
    Public Event OnFarmCodeChanged As ValueChanged

    <Browsable(True), Localizable(True)> _
    Public Property ShowSelectButton() As Boolean
        Get
            Return txtFarm.Properties.Buttons(0).Visible
        End Get
        Set(ByVal Value As Boolean)
            txtFarm.Properties.Buttons(0).Visible = Value
        End Set
    End Property
    Public Overrides Function ValidateData() As Boolean
        Dim row As DataRow = baseDataSet.Tables(FarmPanel_DB.TableFarm).Rows(0)
        If Not row.HasVersion(DataRowVersion.Original) _
            OrElse Utils.Str(row("strOwnerFirstName")) <> Utils.Str(row("strOwnerFirstName", DataRowVersion.Original)) _
            OrElse Utils.Str(row("strOwnerMiddleName")) <> Utils.Str(row("strOwnerMiddleName", DataRowVersion.Original)) _
            OrElse Utils.Str(row("strOwnerLastName")) <> Utils.Str(row("strOwnerLastName", DataRowVersion.Original)) Then
            'Dim sep() As Char = {" "c}
            'Dim s() As String = Utils.Str(row("strFullName")).Split(sep, StringSplitOptions.RemoveEmptyEntries)
            'Dim fieldNames() As String = {"strOwnerLastName", "strOwnerFirstName", "strOwnerMiddleName"}
            'If s.Length > 3 Then
            '    BringUpCurrentTab(Me)
            '    Me.txtFarmOwner.Select()
            '    ErrorForm.ShowError("errInvaildFarmOwnerName", "Invalid farm owner name: farm owner name can contain Last, First and Middle name delimeted by space")
            '    Return False
            'End If
            'For i As Integer = 0 To 2
            '    If i < s.Length Then
            '        If (fieldNames(i).Length > 200) Then
            '            BringUpCurrentTab(Me)
            '            Me.txtFarmOwner.Select()
            '            ErrorForm.ShowError("errFarmOwnerNameTooLong", "Invalid farm owner name: farm owner name is too long.")
            '            Return False
            '        End If
            '        row(fieldNames(i)) = s(i)
            '    Else
            '        row(fieldNames(i)) = DBNull.Value
            '    End If
            'Next
            'If s.Length > 0 Then
            If Utils.Str(row("strOwnerFirstName")).Length > 0 OrElse Utils.Str(row("strOwnerMiddleName")).Length > 0 OrElse Utils.Str(row("strOwnerLastName")).Length > 0 Then
                If IsDBNull(row("idfOwner")) Then
                    row("idfOwner") = BaseDbService.NewIntID
                End If
            End If
        End If
        Return MyBase.ValidateData()
    End Function
    Private m_CaseID As Object
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property CaseID() As Object
        Get
            Return m_CaseID
        End Get
        Set(ByVal Value As Object)
            m_CaseID = Value
            Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            If Not row Is Nothing Then
                row("idfCase") = Value
            End If

        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Property IsRootFarm() As Boolean
        Get
            Return FarmDbService.IsRootFarm
        End Get
        Set(ByVal Value As Boolean)
            FarmDbService.IsRootFarm = Value
            'Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
            'If Not row Is Nothing Then
            '    row("blnRootFarm") = Value
            'End If

        End Set
    End Property
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.[ReadOnly]
        End Get
        Set(ByVal value As Boolean)
            MyBase.[ReadOnly] = value
            DxControlsHelper.EnableButtons(txtFarmOwner, Not value)
            DxControlsHelper.EnableButtons(txtFarm, Not value)
            txtFarmOwner.Visible = Not value
            DxControlsHelper.SetButtonsVisibility(txtFarm, Not value)

        End Set
    End Property
    Public Overrides Function HasChanges() As Boolean
        If m_WasSaved Then Return True
        If baseDataSet Is Nothing Then
            Return False
        End If
        If baseDataSet.HasChanges Then
            If WasChanged() Then
                Return True
            End If
        End If
        For Each child As IRelatedObject In m_ChildForms
            If child.HasChanges() Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function WasChanged() As Boolean
        Dim row As DataRow = GetCurrentRow(Farm_DB.TableFarm)
        If m_ChangesDataset Is Nothing Then
            If row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Deleted Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Row was {2} in the table {3}", ObjectName, Me.GetType, row.RowState.ToString, Farm_DB.TableFarm)
                Return True
            End If
            If row.RowState = DataRowState.Modified Then
                For Each col As DataColumn In row.Table.Columns
                    If col.ColumnName = "idfCase" OrElse col.ColumnName = "idfMonitoringSession" Then
                        Continue For
                    End If
                    If col.ColumnName = "blnIsLivestock" OrElse col.ColumnName = "blnIsAvian" Then
                        If Not row("idfCase") Is DBNull.Value OrElse Not row("idfMonitoringSession") Is DBNull.Value Then
                            Continue For
                        End If
                    End If
                    If Not AreEquals(row(col), row(col, DataRowVersion.Original)) Then
                        Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}", ObjectName, Me.GetType, col.ColumnName, Farm_DB.TableFarm, row(col, DataRowVersion.Original).ToString, row(col).ToString)
                        Return True
                    End If
                Next
            End If
            Return False
        End If
        Dim currentChanges As DataSet = baseDataSet.GetChanges
        If m_ChangesDataset.Tables.Contains(Farm_DB.TableFarm) = False Then
            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Table {2} is added", ObjectName, Me.GetType, Farm_DB.TableFarm)
            Return True
        End If
        If row.RowState = DataRowState.Deleted Then
            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Row was deleted in the table {2}", ObjectName, Me.GetType, Farm_DB.TableFarm)
            Return True
        End If
        Dim originalRow As DataRow = m_ChangesDataset.Tables(Farm_DB.TableFarm).Rows(0)
        If originalRow Is Nothing Then
            Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Original row for table {2} is not found in changed dataset ", ObjectName, Me.GetType, Farm_DB.TableFarm)
            Return True
        End If
        For Each col As DataColumn In row.Table.Columns
            If col.ColumnName = "idfCase" OrElse col.ColumnName = "idfMonitoringSession" Then
                Continue For
            End If
            If col.ColumnName = "blnIsLivestock" OrElse col.ColumnName = "blnIsAvian" Then
                If Not row("idfCase") Is DBNull.Value OrElse Not row("idfMonitoringSession") Is DBNull.Value Then
                    Continue For
                End If
            End If
            If Not m_ChangesDataset.Tables(Farm_DB.TableFarm).Columns.Contains(col.ColumnName) Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} was added to the table {3}", ObjectName, Me.GetType, col.ColumnName, Farm_DB.TableFarm)
                Return True
            End If
            If Not AreEquals(originalRow(col.ColumnName), row(col)) Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Middle, "object {0}(class {1}) is modified. Column {2} in table {3} was changed:original - {4}, modified - {5}", ObjectName, Me.GetType, col.ColumnName, Farm_DB.TableFarm, originalRow(col.ColumnName), row(col))
                Return True
            End If
        Next
        DbDisposeHelper.DisposeDataset(currentChanges)

    End Function

    Private Sub TextEditOwner_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFarmOwnerFirst.EditValueChanged, txtFarmOwnerMiddle.EditValueChanged, txtFarmOwnerLast.EditValueChanged
        Dim edit As DevExpress.XtraEditors.TextEdit = CType(sender, DevExpress.XtraEditors.TextEdit)
        If edit.EditValue Is DBNull.Value Then
            edit.Properties.Appearance.Font = New System.Drawing.Font(DevExpress.Utils.AppearanceObject.DefaultFont, System.Drawing.FontStyle.Italic)
            edit.Properties.Appearance.ForeColor = Drawing.Color.Gray
        Else
            edit.Properties.Appearance.Reset()
        End If
    End Sub

    Private Sub OwnerNamePanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelControl1.Resize
        txtFarmOwnerLast.Left = 0
        txtFarmOwnerLast.Width = PanelControl1.Width \ 3
        txtFarmOwnerFirst.Width = PanelControl1.Width \ 3
        txtFarmOwnerFirst.Left = txtFarmOwnerLast.Width
        txtFarmOwnerMiddle.Left = txtFarmOwnerFirst.Left + txtFarmOwnerFirst.Width
        txtFarmOwnerMiddle.Width = PanelControl1.ClientSize.Width - txtFarmOwnerMiddle.Left
    End Sub
End Class
