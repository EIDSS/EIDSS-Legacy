Imports System.ComponentModel
Imports bv.winclient.Core
Imports bv.common.Configuration
Imports bv.winclient.Localization

Public Class VetCaseSamplesPanel
    Inherits CaseSamplesPanel

    Protected WithEvents colBirdStatus As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbBirdStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        CType(SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {cbBirdStatus})
        SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {colBirdStatus})
        If (HACode And HACode.Avian) <> 0 Then
            colBirdStatus.Visible = True
            colBirdStatus.VisibleIndex = colCollectionDate.VisibleIndex
        Else
            colBirdStatus.Visible = False
            colBirdStatus.VisibleIndex = -1
        End If
        colCollectedByInstitution.Visible = True
        colCollectedByInstitution.VisibleIndex = colSampleCondition.VisibleIndex + 5
        colCollectedByOfficer.Visible = True
        colCollectedByOfficer.VisibleIndex = colSampleCondition.VisibleIndex + 6
        colSentToOrganization.Visible = True
        colSentToOrganization.VisibleIndex = colSampleCondition.VisibleIndex + 7
        pnSpecimenDetail.Visible = False
        NotesGroup.Left = SamplesGroup.Left
        NotesGroup.Width = SamplesGroup.Width
        CType(SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseSamplesPanel))
        Me.cbBirdStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.chkFilterSamples = New DevExpress.XtraEditors.CheckEdit()
        Me.colBirdStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSendToOffice.SuspendLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollectedByGroup.SuspendLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSpecimenDetail.SuspendLayout()
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesGroup.SuspendLayout()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFilteredSampleTypeEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBirdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cbAccessionDate.Mask.EditMask = resources.GetString("cbAccessionDate.Mask.EditMask")
        '
        'grpSendToOffice
        '
        Me.grpSendToOffice.AppearanceCaption.Options.UseFont = True
        '
        'cbSendToOffice
        '
        '
        'CollectedByGroup
        '
        Me.CollectedByGroup.AppearanceCaption.Options.UseFont = True
        '
        'cbCollectedByOrganization
        '
        '
        'cbCollectedByPerson
        '
        '
        'pnSpecimenDetail
        '
        Me.pnSpecimenDetail.Appearance.BackColor = CType(resources.GetObject("pnSpecimenDetail.Appearance.BackColor"), System.Drawing.Color)
        Me.pnSpecimenDetail.Appearance.Options.UseBackColor = True
        Me.pnSpecimenDetail.AppearanceCaption.Options.UseFont = True
        Me.pnSpecimenDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnSpecimenDetail.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'NotesGroup
        '
        Me.NotesGroup.Appearance.BackColor = CType(resources.GetObject("NotesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.NotesGroup.Appearance.Options.UseBackColor = True
        Me.NotesGroup.AppearanceCaption.Options.UseFont = True
        Me.NotesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.NotesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'SamplesGroup
        '
        Me.SamplesGroup.Appearance.BackColor = CType(resources.GetObject("SamplesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.SamplesGroup.Appearance.Options.UseBackColor = True
        Me.SamplesGroup.AppearanceCaption.Options.UseFont = True
        Me.SamplesGroup.Controls.Add(Me.chkFilterSamples)
        Me.SamplesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.SamplesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnNewSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnDeleteSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.chkFilterSamples, 0)
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetCaseSamplesPanel), resources)
        'Form Is Localizable: True
        '
        'cbBirdStatus
        '
        Me.cbBirdStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBirdStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbBirdStatus.Name = "cbBirdStatus"
        '
        'chkFilterSamples
        '
        resources.ApplyResources(Me.chkFilterSamples, "chkFilterSamples")
        Me.chkFilterSamples.Name = "chkFilterSamples"
        Me.chkFilterSamples.Properties.Caption = resources.GetString("chkFilterSamples.Properties.Caption")
        '
        'colBirdStatus
        '
        resources.ApplyResources(Me.colBirdStatus, "colBirdStatus")
        Me.colBirdStatus.ColumnEdit = Me.cbBirdStatus
        Me.colBirdStatus.FieldName = "idfsBirdStatus"
        Me.colBirdStatus.Name = "colBirdStatus"
        '
        'VetCaseSamplesPanel
        '
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "VetCaseSamplesPanel"
        Me.Status = bv.common.win.FormStatus.Draft
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSendToOffice.ResumeLayout(False)
        Me.grpSendToOffice.PerformLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollectedByGroup.ResumeLayout(False)
        Me.CollectedByGroup.PerformLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSpecimenDetail.ResumeLayout(False)
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SamplesGroup.ResumeLayout(False)
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFilteredSampleTypeEditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBirdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents chkFilterSamples As DevExpress.XtraEditors.CheckEdit

    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()

        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".strFieldBarcode", AddressOf UpdatePartyInfo)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfsSampleType", AddressOf UpdatePartyInfo)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfParty", AddressOf UpdatePartyInfo)
        If (HACode And HACode.Avian) <> 0 Then
            Core.LookupBinder.BindBaseRepositoryLookup(cbBirdStatus, BaseReferenceType.rftAnimalCondition, HACode.Avian, False)
            colBirdStatus.Visible = True
            colBirdStatus.VisibleIndex = colCollectionDate.VisibleIndex
        Else
            colBirdStatus.Visible = False
            colBirdStatus.VisibleIndex = -1
        End If
        chkFilterSamples.Checked = BaseSettings.FilterSamplesByDiagnosis
        chkFilterSamples_CheckedChanged(chkFilterSamples, EventArgs.Empty)

    End Sub

    Public Event OnSampleChanged As DataFieldChangeHandler
    Protected Overrides Sub UpdatePartyInfo(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        MyBase.UpdatePartyInfo(sender, e)
        RaiseEvent OnSampleChanged(sender, e)
    End Sub



    Public Function CanDeleteFarmTreeNode(ByVal row As DataRow) As Boolean
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Farm
                Return False
            Case PartyType.Herd
                Dim speciesView As DataView = New DataView(row.Table)
                speciesView.RowFilter = String.Format("idfParentParty = {0}", row("idfParty").ToString)
                For Each speciesRow As DataRowView In speciesView
                    If Not CanDeleteFarmTreeNode(speciesRow.Row) Then
                        Return False
                    End If
                Next
            Case PartyType.Species
                Return CanDeleteParty(row("idfParty"))
        End Select
        Return True
    End Function

    Public Function CanDeleteParty(ByVal partyID As Object) As Boolean
        If Utils.IsEmpty(partyID) Then
            Return True
        End If
        If baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfParty = {0} ", partyID.ToString)).Length > 0 Then 'and Used = 1
            Return False
        End If
        Return True
    End Function


    Public Overrides Function IsCurrentSpecimenRowValid(Optional index As Integer = -1, Optional showError As Boolean = True) As Boolean
        SamplesGridView.PostEditor()
        Return MyBase.IsCurrentSpecimenRowValid(index, showError) 'lower is an old code

        'If index = -1 Then index = SamplesGridView.FocusedRowHandle
        'If index < 0 Then Return True
        'Dim row As DataRow = SamplesGridView.GetDataRow(index)
        'If row Is Nothing Then Return True
        'If Not Utils.IsEmpty(row("datFieldCollectionDate")) AndAlso CDate(row("datFieldCollectionDate")) > DateTime.Today Then
        '    ErrorForm.ShowWarning("datSampleCollectionDate_CurrentDate_msgId", "")
        '    Return False
        'End If
        'Return True
    End Function
    Protected Overrides Function ShowEditor(ByVal row As DataRow) As Boolean
        If (SamplesGridView.FocusedColumn.Name = colSampleCondition.Name) Then
            Return False
        End If
        Return MyBase.ShowEditor(row)
    End Function

    Private Sub chkFilterSamples_CheckedChanged(sender As Object, e As EventArgs) Handles chkFilterSamples.CheckedChanged
        FilterSamplesByDiagnosis = chkFilterSamples.Checked
    End Sub
    Private ReadOnly Property GridLayoutName As String
        Get
            If (HACode And HACode.Livestock) > 0 Then
                Return "LivestockCase_Samples"
            Else
                Return "AvianCase_Samples"

            End If
        End Get
    End Property
    Protected Overrides Sub SaveGridLayouts()
        SamplesGridView.SaveGridLayout(GridLayoutName)
    End Sub
    Protected Overrides Sub LoadGridLayouts()
        If (HACode And HACode.Livestock) > 0 Then
            SamplesGridView.InitXtraGridCustomization(New String() {"idfsSampleType", "strFieldBarcode", "strAnimalCode", "datFieldCollectionDate", "idfSendToOffice"})
        Else
            SamplesGridView.InitXtraGridCustomization(New String() {"idfsSampleType", "strFieldBarcode", "idfParty", "datFieldCollectionDate", "idfSendToOffice"})
        End If
        SamplesGridView.LoadGridLayout(GridLayoutName)
    End Sub
End Class
