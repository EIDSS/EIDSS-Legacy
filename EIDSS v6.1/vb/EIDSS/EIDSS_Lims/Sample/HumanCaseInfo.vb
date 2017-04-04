Public Class HumanCaseInfo
    Inherits bv.common.win.BaseDetailPanel

    Friend WithEvents txtDiagnosis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtOnset As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAntybiotic As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtAge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPatient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtResidence As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Public Sub New()
        InitializeComponent()
        UseParentDataset = True
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseInfo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPatient = New DevExpress.XtraEditors.TextEdit()
        Me.txtAge = New DevExpress.XtraEditors.TextEdit()
        Me.txtOnset = New DevExpress.XtraEditors.TextEdit()
        Me.txtDiagnosis = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAntybiotic = New DevExpress.XtraEditors.MemoEdit()
        Me.txtResidence = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOnset.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAntybiotic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResidence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(HumanCaseInfo), resources)
        'Form Is Localizable: True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
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
        'txtPatient
        '
        resources.ApplyResources(Me.txtPatient, "txtPatient")
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Properties.Appearance.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPatient.Tag = "{R}"
        '
        'txtAge
        '
        resources.ApplyResources(Me.txtAge, "txtAge")
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.Appearance.Options.UseFont = True
        Me.txtAge.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtAge.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtAge.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtAge.Tag = "{R}"
        '
        'txtOnset
        '
        resources.ApplyResources(Me.txtOnset, "txtOnset")
        Me.txtOnset.Name = "txtOnset"
        Me.txtOnset.Properties.Appearance.Options.UseFont = True
        Me.txtOnset.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtOnset.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtOnset.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtOnset.Properties.DisplayFormat.FormatString = "d"
        Me.txtOnset.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtOnset.Properties.EditFormat.FormatString = "d"
        Me.txtOnset.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtOnset.Tag = "{R}"
        '
        'txtDiagnosis
        '
        resources.ApplyResources(Me.txtDiagnosis, "txtDiagnosis")
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.txtDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtDiagnosis.Tag = "{R}"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtAntybiotic
        '
        resources.ApplyResources(Me.txtAntybiotic, "txtAntybiotic")
        Me.txtAntybiotic.Name = "txtAntybiotic"
        Me.txtAntybiotic.Tag = "{R}"
        '
        'txtResidence
        '
        resources.ApplyResources(Me.txtResidence, "txtResidence")
        Me.txtResidence.Name = "txtResidence"
        Me.txtResidence.Properties.Appearance.Options.UseFont = True
        Me.txtResidence.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtResidence.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtResidence.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtResidence.Tag = "{R}"
        '
        'HumanCaseInfo
        '
        Me.Controls.Add(Me.txtAntybiotic)
        Me.Controls.Add(Me.txtDiagnosis)
        Me.Controls.Add(Me.txtOnset)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtPatient)
        Me.Controls.Add(Me.txtResidence)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "HumanCaseInfo"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOnset.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAntybiotic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResidence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub DefineBinding()
        If baseDataSet.Tables.Count = 0 Then Exit Sub
        Me.txtPatient.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".PatientName")
        Me.txtAge.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".Age")
        Me.txtDiagnosis.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".idfsInitialDiagnosis")
        Me.txtResidence.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".CurrentResidence")
        Me.txtOnset.DataBindings.Add("EditValue", baseDataSet, CaseSamples_Db.TableCaseActivity + ".datOnSetDate")
        Dim anti As String = ""
        For Each row As DataRow In baseDataSet.Tables("Antibiotics").Rows
            Utils.AppendLine(anti, row("strAntimicrobialTherapyName"), ",")
        Next
        Me.txtAntybiotic.EditValue = anti
    End Sub

End Class
