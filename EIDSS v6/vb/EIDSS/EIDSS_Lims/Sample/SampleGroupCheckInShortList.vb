Imports System.Linq
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.common.Resources
Imports bv.common.Enums

Public Class SampleGroupCheckInShortList
    Inherits BaseDetailForm

#Region " Windows Form Designer generated code "

    Dim SamplesGroupCheckInDbService As SamplesGroupCheckIn_DB
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        OkButton.Text = BvMessages.Get("btnSelect")
        SamplesGroupCheckInDbService = New SamplesGroupCheckIn_DB
        DbService = SamplesGroupCheckInDbService
        ForcePost = True
        AddHandler cbCaseID.ButtonPressed, AddressOf ButtonPressed
    End Sub

    Friend WithEvents lblHistory As DevExpress.XtraEditors.LabelControl

    'Private Property DbService As Object

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleGroupCheckInShortList))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lblHistory = New DevExpress.XtraEditors.LabelControl()
        Me.SamplesGrid = New DevExpress.XtraGrid.GridControl()
        Me.SamplesGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSpecimenType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCollectionDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaseID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCaseID = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SampleGroupCheckInShortList), resources)
        'Form Is Localizable: True
        '
        'lblHistory
        '
        resources.ApplyResources(Me.lblHistory, "lblHistory")
        Me.lblHistory.Name = "lblHistory"
        '
        'SamplesGrid
        '
        resources.ApplyResources(Me.SamplesGrid, "SamplesGrid")
        Me.SamplesGrid.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.SamplesGrid.MainView = Me.SamplesGridView
        Me.SamplesGrid.Name = "SamplesGrid"
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbCaseID})
        Me.SamplesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SamplesGridView})
        '
        'SamplesGridView
        '
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSpecimenType, Me.colCollectionDate, Me.colCaseID})
        Me.SamplesGridView.GridControl = Me.SamplesGrid
        resources.ApplyResources(Me.SamplesGridView, "SamplesGridView")
        Me.SamplesGridView.Name = "SamplesGridView"
        Me.SamplesGridView.OptionsBehavior.AutoPopulateColumns = False
        Me.SamplesGridView.OptionsCustomization.AllowFilter = False
        Me.SamplesGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.SamplesGridView.OptionsView.RowAutoHeight = True
        Me.SamplesGridView.OptionsView.ShowGroupPanel = False
        '
        'colSpecimenType
        '
        Me.colSpecimenType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colSpecimenType, "colSpecimenType")
        Me.colSpecimenType.FieldName = "strSampleName"
        Me.colSpecimenType.Name = "colSpecimenType"
        Me.colSpecimenType.OptionsColumn.AllowEdit = False
        Me.colSpecimenType.OptionsColumn.ReadOnly = True
        '
        'colCollectionDate
        '
        Me.colCollectionDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colCollectionDate, "colCollectionDate")
        Me.colCollectionDate.FieldName = "datFieldCollectionDate"
        Me.colCollectionDate.Name = "colCollectionDate"
        Me.colCollectionDate.OptionsColumn.AllowEdit = False
        Me.colCollectionDate.OptionsColumn.ReadOnly = True
        '
        'colCaseID
        '
        Me.colCaseID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colCaseID, "colCaseID")
        Me.colCaseID.ColumnEdit = Me.cbCaseID
        Me.colCaseID.FieldName = "strCase"
        Me.colCaseID.Name = "colCaseID"
        Me.colCaseID.OptionsColumn.ReadOnly = True
        Me.colCaseID.Tag = "[en]"
        '
        'cbCaseID
        '
        Me.cbCaseID.Appearance.Options.UseFont = True
        Me.cbCaseID.AppearanceDisabled.Options.UseFont = True
        Me.cbCaseID.AppearanceFocused.Options.UseFont = True
        Me.cbCaseID.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.cbCaseID, "cbCaseID")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbCaseID.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseID.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCaseID.Buttons1"), CType(resources.GetObject("cbCaseID.Buttons2"), Integer), CType(resources.GetObject("cbCaseID.Buttons3"), Boolean), CType(resources.GetObject("cbCaseID.Buttons4"), Boolean), CType(resources.GetObject("cbCaseID.Buttons5"), Boolean), CType(resources.GetObject("cbCaseID.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCaseID.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbCaseID.Buttons8"), CType(resources.GetObject("cbCaseID.Buttons9"), Object), CType(resources.GetObject("cbCaseID.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCaseID.Buttons11"), Boolean))})
        Me.cbCaseID.Name = "cbCaseID"
        Me.cbCaseID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'SampleGroupCheckInShortList
        '
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.SamplesGrid)
        Me.Controls.Add(Me.lblHistory)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L27"
        Me.HelpTopicID = "lab_access_group"
        Me.MinHeight = 200
        Me.MinWidth = 400
        Me.Name = "SampleGroupCheckInShortList"
        Me.ObjectName = "SelectSample"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.lblHistory, 0)
        Me.Controls.SetChildIndex(Me.SamplesGrid, 0)
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Overrides"

    Public Overrides Function GetSelectedRows() As DataRow()
        Dim selRowIndex As Integer() = SamplesGridView.GetSelectedRows()
        Dim selectedRows As List(Of DataRow) = (From a In selRowIndex Select SamplesGridView.GetDataRow(a)).ToList()
        Return selectedRows.ToArray
    End Function

    Protected Overrides Sub DefineBinding()

        If StartUpParameters.Count > 0 Then
            SamplesGridView.GetSelectedRows()
            Dim ds As DataTable = CType(StartUpParameters("datasource"), DataTable)
            SamplesGrid.DataSource = ds
            If baseDataSet.Tables.Count <= 0 Then
                baseDataSet.Merge(ds)
            End If
        End If
        'SamplesGridView.OptionsBehavior.Editable = True
        SamplesGridView.OptionsBehavior.ReadOnly = False
        SamplesGridView.OptionsSelection.MultiSelect = True
        SamplesGridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        'Editable = True
        '[ReadOnly] = False

    End Sub

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        Return True
    End Function

#End Region


    Protected Sub ButtonPressed(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        If LockHandler() Then
            Try
                If e.Button.Kind = ButtonPredefines.Ellipsis Then
                    Dim row As DataRow = SamplesGridView.GetFocusedDataRow()
                    LabUtils.ShowCase(FindForm, row, False)
                End If
            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If
    End Sub

    Private Sub SamplesGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SamplesGridView.DoubleClick
        DoOk()
    End Sub
End Class

