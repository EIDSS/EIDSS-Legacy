Public Class VetCaseInfo
    Inherits bv.common.win.BaseDetailPanel

    Friend WithEvents txtInitialDiagnosis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFarmOwner As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFarmName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFarmAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Public Sub New()
        InitializeComponent()
        UseParentDataset = True
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseInfo))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInitialDiagnosis = New DevExpress.XtraEditors.TextEdit()
        Me.txtFarmOwner = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFarmName = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFarmAddress = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtInitialDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmOwner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFarmAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetCaseInfo), resources)
        'Form Is Localizable: True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtInitialDiagnosis
        '
        resources.ApplyResources(Me.txtInitialDiagnosis, "txtInitialDiagnosis")
        Me.txtInitialDiagnosis.Name = "txtInitialDiagnosis"
        Me.txtInitialDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.txtInitialDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtInitialDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtInitialDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtInitialDiagnosis.Tag = "{R}"
        '
        'txtFarmOwner
        '
        resources.ApplyResources(Me.txtFarmOwner, "txtFarmOwner")
        Me.txtFarmOwner.Name = "txtFarmOwner"
        Me.txtFarmOwner.Properties.Appearance.Options.UseFont = True
        Me.txtFarmOwner.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFarmOwner.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFarmOwner.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFarmOwner.Tag = "{R}"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtFarmName
        '
        resources.ApplyResources(Me.txtFarmName, "txtFarmName")
        Me.txtFarmName.Name = "txtFarmName"
        Me.txtFarmName.Properties.Appearance.Options.UseFont = True
        Me.txtFarmName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFarmName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFarmName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFarmName.Tag = "{R}"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtFarmAddress
        '
        resources.ApplyResources(Me.txtFarmAddress, "txtFarmAddress")
        Me.txtFarmAddress.Name = "txtFarmAddress"
        Me.txtFarmAddress.Properties.Appearance.Options.UseFont = True
        Me.txtFarmAddress.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFarmAddress.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFarmAddress.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFarmAddress.Tag = "{R}"
        '
        'VetCaseInfo
        '
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFarmOwner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInitialDiagnosis)
        Me.Controls.Add(Me.txtFarmName)
        Me.Controls.Add(Me.txtFarmAddress)
        Me.Name = "VetCaseInfo"
        resources.ApplyResources(Me, "$this")
        CType(Me.txtInitialDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmOwner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFarmAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Overrides Sub DefineBinding()
        If baseDataSet.Tables.Count = 0 Then Exit Sub
        Me.txtFarmAddress.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".FarmAddress")
        Me.txtFarmName.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".strNationalName")
        Me.txtFarmOwner.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".FarmOwner")
        Me.txtInitialDiagnosis.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".idfsInitialDiagnosis")
    End Sub

End Class
