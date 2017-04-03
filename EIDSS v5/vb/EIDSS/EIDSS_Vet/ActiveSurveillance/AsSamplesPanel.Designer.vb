Namespace ActiveSurveillance
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AsSamplesPanel
        Inherits CaseSamplesPanel

        'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsSamplesPanel))
        CType(Me.memoEdit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbCondition,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbAccessionDate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbAccessionDate.VistaTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grpSendToOffice,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpSendToOffice.SuspendLayout
        CType(Me.cbSendToOffice.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbCollectedByInstitution,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbCollectedByOfficer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbSentToOrganization,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CollectedByGroup,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CollectedByGroup.SuspendLayout
        CType(Me.cbCollectedByOrganization.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbCollectedByPerson.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbAnimalLookup,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbSpecimenType,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pnSpecimenDetail,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnSpecimenDetail.SuspendLayout
        CType(Me.NotesGroup,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SamplesGroup,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SamplesGroup.SuspendLayout
        CType(Me.cbSpecies,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbVectorID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cbVectorType,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtCollectionDate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtCollectionDate.VistaTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.Mask.EditMask = resources.GetString("cbAccessionDate.Mask.EditMask")
        Me.cbAccessionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'grpSendToOffice
        '
        Me.grpSendToOffice.AppearanceCaption.Options.UseFont = true
        '
        'cbSendToOffice
        '
        '
        'CollectedByGroup
        '
        Me.CollectedByGroup.AppearanceCaption.Font = CType(resources.GetObject("CollectedByGroup.AppearanceCaption.Font"),System.Drawing.Font)
        Me.CollectedByGroup.AppearanceCaption.Options.UseFont = true
        '
        'cbCollectedByOrganization
        '
        '
        'cbCollectedByPerson
        '
        '
        'btnDeleteSpecimen
        '
        Me.btnDeleteSpecimen.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btnDeleteSpecimen, "btnDeleteSpecimen")
        '
        'pnSpecimenDetail
        '
        Me.pnSpecimenDetail.Appearance.BackColor = CType(resources.GetObject("pnSpecimenDetail.Appearance.BackColor"),System.Drawing.Color)
        Me.pnSpecimenDetail.Appearance.Options.UseBackColor = true
        Me.pnSpecimenDetail.AppearanceCaption.Font = CType(resources.GetObject("pnSpecimenDetail.AppearanceCaption.Font"),System.Drawing.Font)
        Me.pnSpecimenDetail.AppearanceCaption.Options.UseFont = true
        resources.ApplyResources(Me.pnSpecimenDetail, "pnSpecimenDetail")
        Me.pnSpecimenDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnSpecimenDetail.LookAndFeel.UseDefaultLookAndFeel = false
        '
        'NotesGroup
        '
        Me.NotesGroup.Appearance.BackColor = CType(resources.GetObject("NotesGroup.Appearance.BackColor"),System.Drawing.Color)
        Me.NotesGroup.Appearance.Options.UseBackColor = true
        Me.NotesGroup.AppearanceCaption.Font = CType(resources.GetObject("NotesGroup.AppearanceCaption.Font"),System.Drawing.Font)
        Me.NotesGroup.AppearanceCaption.Options.UseFont = true
        resources.ApplyResources(Me.NotesGroup, "NotesGroup")
        Me.NotesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.NotesGroup.LookAndFeel.UseDefaultLookAndFeel = false
        '
        'SamplesGroup
        '
        resources.ApplyResources(Me.SamplesGroup, "SamplesGroup")
        Me.SamplesGroup.Appearance.BackColor = CType(resources.GetObject("SamplesGroup.Appearance.BackColor"),System.Drawing.Color)
        Me.SamplesGroup.Appearance.Options.UseBackColor = true
        Me.SamplesGroup.AppearanceCaption.Font = CType(resources.GetObject("SamplesGroup.AppearanceCaption.Font"),System.Drawing.Font)
        Me.SamplesGroup.AppearanceCaption.Options.UseFont = true
        Me.SamplesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.SamplesGroup.LookAndFeel.UseDefaultLookAndFeel = false
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'AsSamplesPanel
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "AsSamplesPanel"
        CType(Me.memoEdit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbCondition,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbAccessionDate.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbAccessionDate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grpSendToOffice,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpSendToOffice.ResumeLayout(false)
        Me.grpSendToOffice.PerformLayout
        CType(Me.cbSendToOffice.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbCollectedByInstitution,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbCollectedByOfficer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbSentToOrganization,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CollectedByGroup,System.ComponentModel.ISupportInitialize).EndInit
        Me.CollectedByGroup.ResumeLayout(false)
        Me.CollectedByGroup.PerformLayout
        CType(Me.cbCollectedByOrganization.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbCollectedByPerson.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbAnimalLookup,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbSpecimenType,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pnSpecimenDetail,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnSpecimenDetail.ResumeLayout(false)
        CType(Me.NotesGroup,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SamplesGroup,System.ComponentModel.ISupportInitialize).EndInit
        Me.SamplesGroup.ResumeLayout(false)
        CType(Me.cbSpecies,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbVectorID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cbVectorType,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtCollectionDate.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtCollectionDate,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    End Class
End Namespace