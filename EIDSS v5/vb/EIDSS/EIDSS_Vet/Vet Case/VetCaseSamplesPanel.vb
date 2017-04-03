Imports System.ComponentModel
Imports bv.winclient.Core

Public Class VetCaseSamplesPanel
    Inherits CaseSamplesPanel

    Public Const TableFiltered As String = "FilteredByDisease"
    'Private FilteredSampleTypes As DataView
    Dim cbSampleTypeEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected WithEvents colBirdStatus As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbBirdStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbBirdStatus})
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBirdStatus})
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
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub


    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetCaseSamplesPanel))
        Me.cbBirdStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.chkFilterSamples = New DevExpress.XtraEditors.CheckEdit()
        Me.colBirdStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSendToOffice.SuspendLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBirdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colBirdStatus
        '
        resources.ApplyResources(Me.colBirdStatus, "colBirdStatus")
        Me.colBirdStatus.ColumnEdit = Me.cbBirdStatus
        Me.colBirdStatus.FieldName = "idfsBirdStatus"
        '
        'cbBirdStatus
        '
        resources.ApplyResources(Me.cbBirdStatus, "cbBirdStatus")
        Me.cbBirdStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBirdStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbBirdStatus.Name = "cbBirdStatus"
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.DisplayFormat.FormatString = "d"
        Me.cbAccessionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbAccessionDate.EditFormat.FormatString = "d"
        Me.cbAccessionDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbAccessionDate.Mask.EditMask = resources.GetString("cbAccessionDate.Mask.EditMask")
        Me.cbAccessionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
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
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnDeleteSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.chkFilterSamples, 0)
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'chkFilterSamples
        '
        resources.ApplyResources(Me.chkFilterSamples, "chkFilterSamples")
        Me.chkFilterSamples.Name = "chkFilterSamples"
        Me.chkFilterSamples.Properties.Caption = resources.GetString("chkFilterSamples.Properties.Caption")
        '
        'VetCaseSamplesPanel
        '
        Me.Name = "VetCaseSamplesPanel"
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSendToOffice.ResumeLayout(False)
        Me.grpSendToOffice.PerformLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBirdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents chkFilterSamples As DevExpress.XtraEditors.CheckEdit

    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()
        'If Not CType(cbSpecimenType.DataSource, DataView).Table.Columns.Contains("blnDesease") Then
        'CType(cbSpecimenType.DataSource, DataView).Table.Columns.Add("blnDesease", GetType(Integer))
        'End If
        'FilteredSampleTypes = New DataView(baseDataSet.Tables(CaseSamplesDetail_Db.TableSamplesToCollect))
        'FilteredSampleTypes.Sort = "idfsSpecimenType"

        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".strFieldBarcode", AddressOf UpdatePartyInfo)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfsSpecimenType", AddressOf UpdatePartyInfo)
        eventManager.AttachDataHandler(CaseSamples_Db.TableSamples + ".idfParty", AddressOf UpdatePartyInfo)
        If (HACode And HACode.Avian) <> 0 Then
            Core.LookupBinder.BindBaseRepositoryLookup(cbBirdStatus, BaseReferenceType.rftAnimalCondition, HACode.Avian, False)
            colBirdStatus.Visible = True
            colBirdStatus.VisibleIndex = colCollectionDate.VisibleIndex
        Else
            colBirdStatus.Visible = False
            colBirdStatus.VisibleIndex = -1
        End If

        'Dim table As DataTable = CType(cbSpecimenType.DataSource, DataView).Table.Clone()
        'table.TableName = TableFiltered
        'Me.baseDataSet.Tables.Add(table)

        'Me.PrepareFilteredSamples()
        Me.cbSampleTypeEditor = CType(Me.cbSpecimenType.Clone(), DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        'Me.cbSampleTypeEditor.DataSource = New DataView(baseDataSet.Tables(CaseSamplesDetail_Db.TableSamplesToCollect))
        Try
            RemoveHandler SamplesGridView.CustomRowCellEditForEditing, AddressOf SamplesGridView_CustomRowCellEditForEditing
        Finally
            AddHandler SamplesGridView.CustomRowCellEditForEditing, AddressOf SamplesGridView_CustomRowCellEditForEditing
        End Try
    End Sub

    Public Event OnSampleChanged As DataFieldChangeHandler
    Protected Overrides Sub UpdatePartyInfo(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        MyBase.UpdatePartyInfo(sender, e)
        RaiseEvent OnSampleChanged(sender, e)
    End Sub

    Private m_DiagnosesList() As Long
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisList() As Long()
        Set(ByVal Value() As Long)
            m_DiagnosesList = Value
            Me.PrepareFilteredSamples()
            'Dim Filter As String = ""
            'For Each diag As Long In Me.m_DiagnosesList
            '    If Filter.Length > 0 Then Filter = Filter + " OR "
            '    Filter = Filter + "idfsDiagnosis=" + diag.ToString()
            'Next
            'FilteredSampleTypes.RowFilter = Filter
            'CType(Me.cbSampleTypeEditor.DataSource, DataView).RowFilter = Filter
            'If CaseSamplesDbService.PopulateSamplesToCollect(baseDataSet, m_DiagnosesList) = False Then
            '    ErrorForm.ShowError(CaseSamplesDbService.LastError)
            'End If
        End Set
    End Property

    'Private Sub cbSpecimenType_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpecimenType.QueryPopUp
    '    Dim sampleRow As DataRow = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)
    '    If sampleRow Is Nothing Then Return
    '    Dim SpecimenView As DataView = CType(cbSpecimenType.DataSource, DataView)
    '    If chkFilterSamples.Checked AndAlso Not m_DiagnosesList Is Nothing AndAlso m_DiagnosesList.Length > 0 Then
    '        'SpecimenView.RowFilter = ""
    '        For Each r As DataRow In SpecimenView.Table.Rows
    '            If FilteredSampleTypes.FindRows(r("idfsReference")).Length > 0 _
    '                OrElse Utils.Str(sampleRow("idfsSpecimenType")) = Utils.Str(r("idfsReference")) Then
    '                r("blnDesease") = 1
    '            Else
    '                r("blnDesease") = 0
    '            End If
    '        Next
    '        SpecimenView.Table.AcceptChanges()
    '        SpecimenView.RowFilter = "blnDesease=1"
    '    Else
    '        SpecimenView.RowFilter = ""
    '    End If
    'End Sub

    'Private Sub cbSpecimenType_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbSpecimenType.CloseUp
    '    CType(cbSpecimenType.DataSource, DataView).RowFilter = ""
    'End Sub

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

    Protected Sub PrepareFilteredSamples()

        If Me.m_DiagnosesList Is Nothing OrElse Me.m_DiagnosesList.Length = 0 Then
            If Me.baseDataSet.Tables.Contains(TableFiltered) Then
                Me.baseDataSet.Tables.Remove(TableFiltered)
            End If
            Exit Sub
        End If

        Dim ref As DataTable = CType(Me.cbSpecimenType.DataSource, DataView).Table
        Dim table As DataTable
        If Me.baseDataSet.Tables.Contains(TableFiltered) Then
            table = Me.baseDataSet.Tables(TableFiltered)
            table.Rows.Clear()
        Else
            table = ref.Clone()
            table.TableName = TableFiltered
            Me.baseDataSet.Tables.Add(table)
        End If

        Dim Filter As String = ""
        For Each diag As Long In Me.m_DiagnosesList
            If Filter.Length > 0 Then Filter = Filter + " OR "
            Filter = Filter + "idfsDiagnosis=" + diag.ToString()
        Next

        Dim view As DataView = New DataView(Me.baseDataSet.Tables(CaseSamples_Db.TableSamplesToCollect))
        view.RowFilter = Filter
        view.Sort = "idfsReference"

        For Each row As DataRow In ref.Rows
            If view.FindRows(row("idfsReference")).Length > 0 Then
                table.Rows.Add(row.ItemArray)
            End If
        Next
        table.AcceptChanges()
    End Sub

    Private Sub SamplesGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)

        If Not (e.Column Is Me.colSpecimenType) Then Exit Sub
        If Me.chkFilterSamples.Checked = False Then Exit Sub
        If Me.baseDataSet.Tables.Contains(TableFiltered) Then
            Me.cbSampleTypeEditor.DataSource = Me.baseDataSet.Tables(TableFiltered)
        Else
            Me.cbSampleTypeEditor.DataSource = Me.cbSpecimenType.DataSource
        End If
        e.RepositoryItem = Me.cbSampleTypeEditor
    End Sub

    Public Overrides Function IsCurrentSpecimenRowValid(Optional index As Integer = -1, Optional showError As Boolean = True) As Boolean
        SamplesGridView.PostEditor()
        If Not MyBase.IsCurrentSpecimenRowValid(index, showError) Then
            Return False
        End If
        If index = -1 Then index = SamplesGridView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = SamplesGridView.GetDataRow(index)
        If row Is Nothing Then Return True
        If Not Utils.IsEmpty(row("datFieldCollectionDate")) AndAlso CDate(row("datFieldCollectionDate")) > DateTime.Today Then
            ErrorForm.ShowWarning("datSampleCollectionDate_CurrentDate_msgId", "")
            Return False
        End If
        Return True
    End Function
    Protected Overrides Function ShowEditor(ByVal row As DataRow) As Boolean
        If (SamplesGridView.FocusedColumn.Name = Me.colSampleCondition.Name) Then
            Return False
        End If
        Return MyBase.ShowEditor(row)
    End Function

End Class
