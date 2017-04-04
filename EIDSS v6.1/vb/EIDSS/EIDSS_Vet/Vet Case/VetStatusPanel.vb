Imports EIDSS.model.Core
Imports EIDSS.Enums
Imports bv.winclient.Core
Imports System.Collections.Generic
Imports EIDSS.model.Resources
Imports bv.winclient.BasePanel
Imports EIDSS.winclient.Outbreaks
Imports bv.model.Model.Core
Imports EIDSS.ActiveSurveillance
Imports bv.common.Resources
Imports bv.winclient.Localization
Imports EIDSS.model.Enums
Imports bv.model.BLToolkit
Imports EIDSS.model.Schema
Imports DevExpress.XtraEditors.Controls

Public Class VetStatusPanel
    Inherits BaseDetailPanel
    Dim VetStatusDbService As VetCase_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitCustomMandatoryFields()
        VetStatusDbService = New VetCase_DB
        DbService = VetStatusDbService
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
    Friend WithEvents GeneralGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbOutBreak As System.Windows.Forms.Label
    Friend WithEvents lbCaseID As System.Windows.Forms.Label
    Friend WithEvents lbFieldAccessionID As System.Windows.Forms.Label
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbCaseClassification As System.Windows.Forms.Label
    Friend WithEvents lkpCaseClassification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtFieldAccessionID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbDiseaseName As System.Windows.Forms.Label
    Friend WithEvents txtDiseaseName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbCaseStatus As System.Windows.Forms.Label
    Friend WithEvents cbCaseStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSessionID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbSessionID As System.Windows.Forms.Label
    Friend WithEvents lbReportType As System.Windows.Forms.Label
    Friend WithEvents cbReportType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtTentativeDiagnoses As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbTentativeDiagnoses As System.Windows.Forms.Label
    Friend WithEvents txtOutbreakID As DevExpress.XtraEditors.ButtonEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetStatusPanel))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtDiseaseName = New DevExpress.XtraEditors.ButtonEdit()
        Me.GeneralGroup = New DevExpress.XtraEditors.GroupControl()
        Me.cbReportType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSessionID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbSessionID = New System.Windows.Forms.Label()
        Me.txtOutbreakID = New DevExpress.XtraEditors.ButtonEdit()
        Me.cbCaseStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbOutBreak = New System.Windows.Forms.Label()
        Me.txtCaseID = New DevExpress.XtraEditors.TextEdit()
        Me.lbCaseClassification = New System.Windows.Forms.Label()
        Me.lkpCaseClassification = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFieldAccessionID = New DevExpress.XtraEditors.TextEdit()
        Me.lbDiseaseName = New System.Windows.Forms.Label()
        Me.lbCaseStatus = New System.Windows.Forms.Label()
        Me.lbCaseID = New System.Windows.Forms.Label()
        Me.lbFieldAccessionID = New System.Windows.Forms.Label()
        Me.lbReportType = New System.Windows.Forms.Label()
        Me.txtTentativeDiagnoses = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbTentativeDiagnoses = New System.Windows.Forms.Label()
        CType(Me.txtDiseaseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GeneralGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GeneralGroup.SuspendLayout()
        CType(Me.cbReportType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkpCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFieldAccessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTentativeDiagnoses.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetStatusPanel), resources)
        'Form Is Localizable: True
        '
        'txtDiseaseName
        '
        resources.ApplyResources(Me.txtDiseaseName, "txtDiseaseName")
        Me.txtDiseaseName.Name = "txtDiseaseName"
        Me.txtDiseaseName.Properties.Appearance.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtDiseaseName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtDiseaseName.Properties.ReadOnly = True
        Me.txtDiseaseName.Tag = "{R}"
        '
        'GeneralGroup
        '
        Me.GeneralGroup.Appearance.BackColor = CType(resources.GetObject("GeneralGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.GeneralGroup.Appearance.BorderColor = CType(resources.GetObject("GeneralGroup.Appearance.BorderColor"), System.Drawing.Color)
        Me.GeneralGroup.Appearance.Options.UseBackColor = True
        Me.GeneralGroup.Appearance.Options.UseBorderColor = True
        Me.GeneralGroup.Appearance.Options.UseFont = True
        Me.GeneralGroup.AppearanceCaption.Options.UseFont = True
        Me.GeneralGroup.Controls.Add(Me.txtTentativeDiagnoses)
        Me.GeneralGroup.Controls.Add(Me.lbTentativeDiagnoses)
        Me.GeneralGroup.Controls.Add(Me.cbReportType)
        Me.GeneralGroup.Controls.Add(Me.txtSessionID)
        Me.GeneralGroup.Controls.Add(Me.lbSessionID)
        Me.GeneralGroup.Controls.Add(Me.txtOutbreakID)
        Me.GeneralGroup.Controls.Add(Me.cbCaseStatus)
        Me.GeneralGroup.Controls.Add(Me.lbOutBreak)
        Me.GeneralGroup.Controls.Add(Me.txtCaseID)
        Me.GeneralGroup.Controls.Add(Me.lbCaseClassification)
        Me.GeneralGroup.Controls.Add(Me.lkpCaseClassification)
        Me.GeneralGroup.Controls.Add(Me.txtDiseaseName)
        Me.GeneralGroup.Controls.Add(Me.txtFieldAccessionID)
        Me.GeneralGroup.Controls.Add(Me.lbDiseaseName)
        Me.GeneralGroup.Controls.Add(Me.lbCaseStatus)
        Me.GeneralGroup.Controls.Add(Me.lbCaseID)
        Me.GeneralGroup.Controls.Add(Me.lbFieldAccessionID)
        Me.GeneralGroup.Controls.Add(Me.lbReportType)
        resources.ApplyResources(Me.GeneralGroup, "GeneralGroup")
        Me.GeneralGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GeneralGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GeneralGroup.Name = "GeneralGroup"
        Me.GeneralGroup.TabStop = True
        '
        'cbReportType
        '
        resources.ApplyResources(Me.cbReportType, "cbReportType")
        Me.cbReportType.Name = "cbReportType"
        Me.cbReportType.Properties.Appearance.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbReportType.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbReportType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReportType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbReportType.Properties.Buttons1"), CType(resources.GetObject("cbReportType.Properties.Buttons2"), Integer), CType(resources.GetObject("cbReportType.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbReportType.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbReportType.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbReportType.Properties.Buttons8"), CType(resources.GetObject("cbReportType.Properties.Buttons9"), Object), CType(resources.GetObject("cbReportType.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbReportType.Properties.Buttons11"), Boolean))})
        Me.cbReportType.Properties.NullText = resources.GetString("cbReportType.Properties.NullText")
        Me.cbReportType.Tag = "{M}"
        '
        'txtSessionID
        '
        resources.ApplyResources(Me.txtSessionID, "txtSessionID")
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Properties.Appearance.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSessionID.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseFont = True
        Me.txtSessionID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtSessionID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtSessionID.Properties.Buttons1"), CType(resources.GetObject("txtSessionID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtSessionID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtSessionID.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtSessionID.Properties.Buttons8"), CType(resources.GetObject("txtSessionID.Properties.Buttons9"), Object), CType(resources.GetObject("txtSessionID.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtSessionID.Properties.Buttons11"), Boolean))})
        Me.txtSessionID.Properties.ReadOnly = True
        Me.txtSessionID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbSessionID
        '
        resources.ApplyResources(Me.lbSessionID, "lbSessionID")
        Me.lbSessionID.Name = "lbSessionID"
        '
        'txtOutbreakID
        '
        resources.ApplyResources(Me.txtOutbreakID, "txtOutbreakID")
        Me.txtOutbreakID.Name = "txtOutbreakID"
        Me.txtOutbreakID.Properties.Appearance.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtOutbreakID.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject3.Options.UseFont = True
        SerializableAppearanceObject4.Options.UseFont = True
        SerializableAppearanceObject5.Options.UseFont = True
        Me.txtOutbreakID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons1"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.EIDSS.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("txtOutbreakID.Properties.Buttons7"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons8"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons11"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons12"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons13"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons14"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons15"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons16"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons17"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtOutbreakID.Properties.Buttons18"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("txtOutbreakID.Properties.Buttons19"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons20"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons21"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons22"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtOutbreakID.Properties.Buttons23"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtOutbreakID.Properties.Buttons24"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons25"), Integer), CType(resources.GetObject("txtOutbreakID.Properties.Buttons26"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons27"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons28"), Boolean), CType(resources.GetObject("txtOutbreakID.Properties.Buttons29"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtOutbreakID.Properties.Buttons30"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("txtOutbreakID.Properties.Buttons31"), CType(resources.GetObject("txtOutbreakID.Properties.Buttons32"), Object), CType(resources.GetObject("txtOutbreakID.Properties.Buttons33"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtOutbreakID.Properties.Buttons34"), Boolean))})
        Me.txtOutbreakID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cbCaseStatus
        '
        resources.ApplyResources(Me.cbCaseStatus, "cbCaseStatus")
        Me.cbCaseStatus.Name = "cbCaseStatus"
        Me.cbCaseStatus.Properties.Appearance.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject6.Options.UseFont = True
        Me.cbCaseStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCaseStatus.Properties.Buttons1"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCaseStatus.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCaseStatus.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("cbCaseStatus.Properties.Buttons8"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons9"), Object), CType(resources.GetObject("cbCaseStatus.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCaseStatus.Properties.Buttons11"), Boolean))})
        Me.cbCaseStatus.Properties.NullText = resources.GetString("cbCaseStatus.Properties.NullText")
        Me.cbCaseStatus.Tag = "{statuscontrol}{M}"
        '
        'lbOutBreak
        '
        resources.ApplyResources(Me.lbOutBreak, "lbOutBreak")
        Me.lbOutBreak.Name = "lbOutBreak"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.Appearance.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseID.Tag = "{K}[en]"
        '
        'lbCaseClassification
        '
        resources.ApplyResources(Me.lbCaseClassification, "lbCaseClassification")
        Me.lbCaseClassification.Name = "lbCaseClassification"
        '
        'lkpCaseClassification
        '
        resources.ApplyResources(Me.lkpCaseClassification, "lkpCaseClassification")
        Me.lkpCaseClassification.Name = "lkpCaseClassification"
        Me.lkpCaseClassification.Properties.Appearance.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDisabled.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDropDown.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceFocused.Options.UseFont = True
        Me.lkpCaseClassification.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject7.Options.UseFont = True
        Me.lkpCaseClassification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lkpCaseClassification.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lkpCaseClassification.Properties.Buttons1"), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons2"), Integer), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons3"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons4"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons5"), Boolean), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, resources.GetString("lkpCaseClassification.Properties.Buttons8"), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons9"), Object), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lkpCaseClassification.Properties.Buttons11"), Boolean))})
        Me.lkpCaseClassification.Properties.NullText = resources.GetString("lkpCaseClassification.Properties.NullText")
        '
        'txtFieldAccessionID
        '
        resources.ApplyResources(Me.txtFieldAccessionID, "txtFieldAccessionID")
        Me.txtFieldAccessionID.Name = "txtFieldAccessionID"
        Me.txtFieldAccessionID.Properties.Appearance.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFieldAccessionID.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'lbDiseaseName
        '
        resources.ApplyResources(Me.lbDiseaseName, "lbDiseaseName")
        Me.lbDiseaseName.Name = "lbDiseaseName"
        '
        'lbCaseStatus
        '
        resources.ApplyResources(Me.lbCaseStatus, "lbCaseStatus")
        Me.lbCaseStatus.Name = "lbCaseStatus"
        '
        'lbCaseID
        '
        resources.ApplyResources(Me.lbCaseID, "lbCaseID")
        Me.lbCaseID.Name = "lbCaseID"
        '
        'lbFieldAccessionID
        '
        resources.ApplyResources(Me.lbFieldAccessionID, "lbFieldAccessionID")
        Me.lbFieldAccessionID.Name = "lbFieldAccessionID"
        '
        'lbReportType
        '
        resources.ApplyResources(Me.lbReportType, "lbReportType")
        Me.lbReportType.Name = "lbReportType"
        '
        'txtTentativeDiagnoses
        '
        resources.ApplyResources(Me.txtTentativeDiagnoses, "txtTentativeDiagnoses")
        Me.txtTentativeDiagnoses.Name = "txtTentativeDiagnoses"
        Me.txtTentativeDiagnoses.Properties.Appearance.Options.UseFont = True
        Me.txtTentativeDiagnoses.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtTentativeDiagnoses.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtTentativeDiagnoses.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtTentativeDiagnoses.Properties.ReadOnly = True
        Me.txtTentativeDiagnoses.Tag = "{R}"
        '
        'lbTentativeDiagnoses
        '
        resources.ApplyResources(Me.lbTentativeDiagnoses, "lbTentativeDiagnoses")
        Me.lbTentativeDiagnoses.Name = "lbTentativeDiagnoses"
        '
        'VetStatusPanel
        '
        Me.Controls.Add(Me.GeneralGroup)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.HelpTopicID = "VetStatusPanel"
        Me.KeyFieldName = "idfCase"
        Me.Name = "VetStatusPanel"
        Me.ObjectName = "VetStatus"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "VetCase"
        CType(Me.txtDiseaseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GeneralGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GeneralGroup.ResumeLayout(False)
        CType(Me.cbReportType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkpCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFieldAccessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTentativeDiagnoses.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomMandatoryField(lkpCaseClassification, CustomMandatoryField.VetCase_CaseClassification)
    End Sub

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindTextEdit(txtCaseID, baseDataSet, VetCase_DB.TableVetCase + ".strCaseID")
        Core.LookupBinder.BindTextEdit(txtFieldAccessionID, baseDataSet, VetCase_DB.TableVetCase + ".strFieldAccessionID")
        Core.LookupBinder.BindTextEdit(txtOutbreakID, baseDataSet, VetCase_DB.TableVetCase + ".strOutbreakID")
        Core.LookupBinder.BindTextEdit(txtSessionID, baseDataSet, VetCase_DB.TableVetCase + ".strMonitoringSessionID")
        Dim id As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strMonitoringSessionID")
        If Utils.IsEmpty(id) Then ShowSessionButtons(False)

        Core.LookupBinder.BindBaseLookup(lkpCaseClassification, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseClassification", db.BaseReferenceType.rftCaseClassification, HACode.Avian Or HACode.Livestock, False)
        'Core.LookupBinder.SetInitialCaseClassificationFilter(lkpCaseClassification)
        Core.LookupBinder.BindBaseLookup(cbCaseStatus, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseProgressStatus", db.BaseReferenceType.rftCaseProgressStatus, False, False)
        Core.LookupBinder.BindBaseLookup(cbReportType, baseDataSet, VetCase_DB.TableVetCase + ".idfsCaseReportType", db.BaseReferenceType.rftCaseReportType, False, False)
        CType(cbReportType.Properties.DataSource, DataView).RowFilter = String.Format("idfsReference <> {0} and idfsReference <> {1}", CType(CaseReportType.Both, Long), LookupCache.EmptyLineKey)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsCaseProgressStatus", AddressOf CaseStatusChanged)
        SetCaseStatusState()
        If baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseType").Equals(CLng(CaseType.Avian)) Then
            txtSessionID.Visible = False
            lbSessionID.Visible = False
            txtDiseaseName.Width = txtTentativeDiagnoses.Width
        End If
        SetReportTypeReadOnly()
    End Sub

    Private Sub SetCaseStatusState()
        If baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) Then
            If Not ParentObject.[ReadOnly] Then
                IsStatusReadOnly = True
                ParentObject.[ReadOnly] = True
            End If
            cbCaseStatus.Enabled = EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReopenClosedCase))
        End If
    End Sub
    Private Sub SetReportTypeReadOnly()
        If Not Utils.IsEmpty(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strMonitoringSessionID")) AndAlso Not Utils.IsEmpty(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfsCaseReportType")) Then
            SetControlReadOnly(cbReportType, True, False)
        End If
    End Sub

    Private Sub CaseStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value.Equals(CLng(CaseStatus.InProgress)) Then
            If ParentObject.[ReadOnly] Then
                IsStatusReadOnly = False
                ParentObject.[ReadOnly] = False
            End If
        End If
    End Sub

    Public Sub SetDisease(ByVal idfsDisease As Long, finalDiagnosis As String, ByVal tentativeDiagnoses As String)
        txtDiseaseName.Text = finalDiagnosis
        txtDiseaseName.ToolTip = finalDiagnosis

        txtTentativeDiagnoses.Text = tentativeDiagnoses
        txtTentativeDiagnoses.ToolTip = tentativeDiagnoses
        Dim row As DataRow = GetCurrentRow()
        If Not row Is Nothing Then
            If idfsDisease = -1 Then
                row("idfsShowDiagnosis") = DBNull.Value
            Else
                row("idfsShowDiagnosis") = idfsDisease
            End If
        End If

        'если диагнозов нет - запрещено св€зывать сессию с Outbreak-ом
        If idfsDisease = -1 Then
            DxControlsHelper.DisableButtonEditButton(txtOutbreakID, ButtonPredefines.Ellipsis)
            DxControlsHelper.DisableButtonEditButton(txtOutbreakID, ButtonPredefines.Glyph)
        Else
            DxControlsHelper.EnableButtonEditButton(txtOutbreakID, ButtonPredefines.Ellipsis)
            DxControlsHelper.EnableButtonEditButton(txtOutbreakID, ButtonPredefines.Glyph)
        End If
    End Sub


    Private Sub cbOutbreakID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOutbreakID.ButtonClick
        If (e Is Nothing) Then Return

        ' save form before choosing outbreak
        If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Or (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then
            If Not RootBaseForm.Post(bv.common.Enums.PostType.FinalPosting) Then Return
        End If

        If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Then
            'Glyph (Search) Button Shows Outbreak Search

            Dim outbreakForm As New OutbreakListPanel
            Dim r As IObject = BaseFormManager.ShowForSelection(outbreakForm, FindForm, , 1024, 800)
            If Not r Is Nothing Then
                SetOutbreak(r.Key, r.GetValue("strOutbreakID"), r.GetValue("idfsDiagnosisOrDiagnosisGroup"), r.GetValue("strDiagnosisOrDiagnosisGroup"), r.GetValue("idfsDiagnosisGroup"), r.GetValue("strDiagnosisGroup"))
            End If

        ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then
            ''Ellipsis Button Creates New Outbreak

            Dim outbreakID As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak")
            If outbreakID Is DBNull.Value Then
                outbreakID = Nothing
                If Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(model.Enums.EIDSSPermissionObject.Outbreak)) Then
                    MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"))
                    Return
                End If
            ElseIf Not model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(model.Enums.EIDSSPermissionObject.Outbreak)) Then
                MessageForm.Show(BvMessages.Get("msgNoSelectPermission", "You have no rights to view this form"))
                Return
            End If

            Dim dlgOutbreakDetail As OutbreakDetail = New OutbreakDetail
            Dim hTable As New Dictionary(Of String, Object)(2)
            hTable.Add("CanAddViewRemove", False)
            hTable.Add("idfVetCase", GetListItem())
            If (BaseFormManager.ShowModal(dlgOutbreakDetail, FindForm, outbreakID, Nothing, hTable) = True) _
                AndAlso (Not Utils.IsEmpty(dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID"))) Then

                Dim idfsDiagnosisOrDiagnosisGroup As Object = dlgOutbreakDetail.GetKey("Outbreak", "idfsDiagnosisOrDiagnosisGroup")
                Dim strDiagnosisOrDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisOrDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "Name")
                Dim idfsDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisOrDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "idfsDiagnosisGroup")
                Dim strDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "Name")

                SetOutbreak(dlgOutbreakDetail.GetKey(), _
                            dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID"), _
                            idfsDiagnosisOrDiagnosisGroup, _
                            strDiagnosisOrDiagnosisGroup, _
                            idfsDiagnosisGroup, _
                            strDiagnosisGroup)


            ElseIf Not outbreakID Is Nothing AndAlso (dlgOutbreakDetail.DbService.ID Is Nothing) Then
                'This is the case when Outbreak was deleted from outbreak detail form

                SetOutbreak(DBNull.Value, DBNull.Value)

            End If
        ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) Then
            If Not baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") Is DBNull.Value Then
                If WinUtils.ConfirmMessage(EidssMessages.Get("msgRemoveCaseFromOutbreak", "Remove case from outbreak?"), EidssMessages.Get("msgRemoveConfirmation", "Remove confirnmation?")) Then

                    SetOutbreak(DBNull.Value, DBNull.Value)

                End If
            End If
        End If
    End Sub

    Private Sub ShowOutbreakButtons(ByVal aVisible As Boolean)
        DxControlsHelper.SetButtonEditButtonVisibility(txtOutbreakID, ButtonPredefines.Delete, aVisible)
    End Sub

    Private Sub ShowSessionButtons(ByVal aVisible As Boolean)
        DxControlsHelper.SetButtonEditButtonVisibility(txtSessionID, ButtonPredefines.Ellipsis, aVisible)
    End Sub

    Function GetListItem() As IObject
        Dim filter As FilterParams = New FilterParams()
        filter.Add("idfCase", "=", baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfCase"))
        Dim oList As List(Of IObject)
        Using manager As DbManagerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance)
            Dim accessor As IObjectSelectList = ObjectAccessor.SelectListInterface(GetType(VetCaseListItem))
            oList = accessor.SelectList(manager, filter)
        End Using
        Return oList(0)
    End Function

    Private Sub SetOutbreak(ByVal idfOutbreak As Object, ByVal strOutbreakID As Object, _
                            Optional ByVal idfsDiagnosis As Object = -1, _
                            Optional ByVal strDiagnosisOrDiagnosisGroup As Object = "", _
                            Optional ByVal idfsDiagnosisGroup As Object = -1, _
                            Optional ByVal strDiagnosisGroup As Object = "")

        ' check diagnoses connection before
        If Not idfOutbreak Is DBNull.Value Then

            Dim idfsCaseDiagnosis As Long = VetStatusDbService.CheckOutbreakDiagnosis(baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfCase"), idfOutbreak)
            If idfsCaseDiagnosis = 0 Then
                MessageForm.Show(
                    String.Format(EidssMessages.Get("msgOutbreakDiagnosisErrorCases", "Case/session {0} cannot be added to the outbreak {1}. Diagnosis of the case/session must be the same as the diagnosis of the outbreak or be included to the diagnoses group of the outbreak. OutbreakТs diagnosis/diagnoses group is {2}."), baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strCaseID"), strOutbreakID, strDiagnosisOrDiagnosisGroup),
                    EidssMessages.Get("ErrErrorFormCaption"), MessageBoxButtons.OK)
                Return
            ElseIf (idfsCaseDiagnosis > 0) Then
                Dim diagName As String = LookupCache.GetLookupValue(idfsCaseDiagnosis, LookupTables.VetStandardDiagnosis.ToString, "Name")

                If Not WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("msgUpOutbreakDiagnosisToGroup", "Outbreak diagnosis {0} and diagnosis of the case/session {1} {2} are not equal, but are included to the same diagnoses group {3}. Do you want to enter {3} as outbreak diagnosis?"), strDiagnosisOrDiagnosisGroup, baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strCaseID"), diagName, strDiagnosisGroup)) Then Return
                VetStatusDbService.ChangeOutbreakDiagnosis(idfOutbreak, idfsDiagnosisGroup)
            End If
        End If

        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).BeginEdit()
        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfOutbreak") = idfOutbreak
        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID") = strOutbreakID
        baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0).EndEdit()


    End Sub


    Private Sub VetStatusPanel_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
        SetCaseStatusState()
    End Sub
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.[ReadOnly]
        End Get
        Set(ByVal value As Boolean)
            MyBase.[ReadOnly] = value
            If Not value Then
                SetReportTypeReadOnly()
            End If
            txtOutbreakID.EnableButtons(Not value)
        End Set
    End Property

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("strOutbreakID")

        If Utils.IsEmpty(id) Then
            ShowOutbreakButtons(False)
        Else
            ShowOutbreakButtons(True)
        End If
    End Sub

    Private Sub txtSessionID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtSessionID.ButtonClick
        If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then


            Dim sessionID As Object = baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)("idfParentMonitoringSession")
            If sessionID Is DBNull.Value Then
                Return
            End If
            Dim sessionForm As AsSessionDetail = New AsSessionDetail
            BaseFormManager.ShowNormal(sessionForm, sessionID, Nothing, Nothing)
        End If
    End Sub

End Class
