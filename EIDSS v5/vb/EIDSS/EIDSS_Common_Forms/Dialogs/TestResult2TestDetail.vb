Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.Collections.Generic

Public Class TestResult2TestDetail
    Inherits bv.common.win.BaseDetailList
    Private m_TestResultService As TestResult2Test_DB
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_TestResultService = New TestResult2Test_DB
        DbService = m_TestResultService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoTestResult2Test, AuditTable.trtBaseReference)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
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
    Friend WithEvents TestTypeGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cbTests As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lstTestResults As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lbTestResults2Test As System.Windows.Forms.Label
    Friend WithEvents lbTestName As System.Windows.Forms.Label
    Friend WithEvents rgTestKind As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents btnAddTestResult As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Test2TestResultGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Test2TestResultView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIndicative As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkIndicative As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TestResultsGroup As DevExpress.XtraEditors.GroupControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestResult2TestDetail))
        Me.TestTypeGroup = New DevExpress.XtraEditors.GroupControl()
        Me.Test2TestResultGrid = New DevExpress.XtraGrid.GridControl()
        Me.Test2TestResultView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIndicative = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkIndicative = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.rgTestKind = New DevExpress.XtraEditors.RadioGroup()
        Me.lbTestResults2Test = New System.Windows.Forms.Label()
        Me.lbTestName = New System.Windows.Forms.Label()
        Me.cbTests = New DevExpress.XtraEditors.LookUpEdit()
        Me.TestResultsGroup = New DevExpress.XtraEditors.GroupControl()
        Me.btnAddTestResult = New DevExpress.XtraEditors.SimpleButton()
        Me.lstTestResults = New DevExpress.XtraEditors.ListBoxControl()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TestTypeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TestTypeGroup.SuspendLayout()
        CType(Me.Test2TestResultGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Test2TestResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIndicative, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgTestKind.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTests.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestResultsGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TestResultsGroup.SuspendLayout()
        CType(Me.lstTestResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TestTypeGroup
        '
        resources.ApplyResources(Me.TestTypeGroup, "TestTypeGroup")
        Me.TestTypeGroup.Controls.Add(Me.Test2TestResultGrid)
        Me.TestTypeGroup.Controls.Add(Me.rgTestKind)
        Me.TestTypeGroup.Controls.Add(Me.lbTestResults2Test)
        Me.TestTypeGroup.Controls.Add(Me.lbTestName)
        Me.TestTypeGroup.Controls.Add(Me.cbTests)
        Me.TestTypeGroup.Name = "TestTypeGroup"
        '
        'Test2TestResultGrid
        '
        resources.ApplyResources(Me.Test2TestResultGrid, "Test2TestResultGrid")
        Me.Test2TestResultGrid.MainView = Me.Test2TestResultView
        Me.Test2TestResultGrid.Name = "Test2TestResultGrid"
        Me.Test2TestResultGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkIndicative})
        Me.Test2TestResultGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Test2TestResultView})
        '
        'Test2TestResultView
        '
        Me.Test2TestResultView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTestResult, Me.colIndicative})
        Me.Test2TestResultView.GridControl = Me.Test2TestResultGrid
        Me.Test2TestResultView.Name = "Test2TestResultView"
        Me.Test2TestResultView.OptionsCustomization.AllowFilter = False
        Me.Test2TestResultView.OptionsView.ShowGroupPanel = False
        '
        'colTestResult
        '
        resources.ApplyResources(Me.colTestResult, "colTestResult")
        Me.colTestResult.FieldName = "TestResultName"
        Me.colTestResult.Name = "colTestResult"
        '
        'colIndicative
        '
        resources.ApplyResources(Me.colIndicative, "colIndicative")
        Me.colIndicative.ColumnEdit = Me.chkIndicative
        Me.colIndicative.FieldName = "blnIndicative"
        Me.colIndicative.Name = "colIndicative"
        '
        'chkIndicative
        '
        resources.ApplyResources(Me.chkIndicative, "chkIndicative")
        Me.chkIndicative.Name = "chkIndicative"
        Me.chkIndicative.RadioGroupIndex = 0
        '
        'rgTestKind
        '
        resources.ApplyResources(Me.rgTestKind, "rgTestKind")
        Me.rgTestKind.Name = "rgTestKind"
        Me.rgTestKind.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(resources.GetObject("rgTestKind.Properties.Items"), Object), resources.GetString("rgTestKind.Properties.Items1")), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(resources.GetObject("rgTestKind.Properties.Items2"), Object), resources.GetString("rgTestKind.Properties.Items3"))})
        Me.rgTestKind.Tag = "{alwayseditable}"
        '
        'lbTestResults2Test
        '
        resources.ApplyResources(Me.lbTestResults2Test, "lbTestResults2Test")
        Me.lbTestResults2Test.Name = "lbTestResults2Test"
        '
        'lbTestName
        '
        resources.ApplyResources(Me.lbTestName, "lbTestName")
        Me.lbTestName.Name = "lbTestName"
        '
        'cbTests
        '
        resources.ApplyResources(Me.cbTests, "cbTests")
        Me.cbTests.Name = "cbTests"
        Me.cbTests.Properties.AutoHeight = CType(resources.GetObject("cbTests.Properties.AutoHeight"), Boolean)
        Me.cbTests.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTests.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTests.Properties.NullValuePrompt = resources.GetString("cbTests.Properties.NullValuePrompt")
        Me.cbTests.Tag = "{alwayseditable}"
        '
        'TestResultsGroup
        '
        resources.ApplyResources(Me.TestResultsGroup, "TestResultsGroup")
        Me.TestResultsGroup.Controls.Add(Me.btnAddTestResult)
        Me.TestResultsGroup.Controls.Add(Me.lstTestResults)
        Me.TestResultsGroup.Name = "TestResultsGroup"
        '
        'btnAddTestResult
        '
        Me.btnAddTestResult.Image = Global.eidss.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAddTestResult, "btnAddTestResult")
        Me.btnAddTestResult.Name = "btnAddTestResult"
        '
        'lstTestResults
        '
        resources.ApplyResources(Me.lstTestResults, "lstTestResults")
        Me.lstTestResults.Name = "lstTestResults"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.eidss.My.Resources.Resources.left
        Me.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'btnRemove
        '
        Me.btnRemove.Image = Global.eidss.My.Resources.Resources.Right
        Me.btnRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'TestResult2TestDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.TestResultsGroup)
        Me.Controls.Add(Me.TestTypeGroup)
        Me.FormID = "A30"
        Me.HelpTopicID = "TestResultsMatrixForm"
        Me.KeyFieldName = "idfsReference"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Reference_Matrix__large__46_
        Me.Name = "TestResult2TestDetail"
        Me.ObjectName = "Test"
        Me.ShowDeleteButton = False
        Me.TableName = "Test"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.TestTypeGroup, 0)
        Me.Controls.SetChildIndex(Me.TestResultsGroup, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnRemove, 0)
        CType(Me.TestTypeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TestTypeGroup.ResumeLayout(False)
        CType(Me.Test2TestResultGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Test2TestResultView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIndicative, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgTestKind.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTests.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestResultsGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TestResultsGroup.ResumeLayout(False)
        CType(Me.lstTestResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuTestResultMatrix", 980, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowModal(New TestResult2TestDetail, BaseFormManager.MainForm)
    End Sub
#End Region
    Private m_TestResult2TestView As DataView
    Private m_TestResultView As DataView

    Protected Overrides Sub DefineBinding()
        lstTestResults.DisplayMember = "name"
        lstTestResults.ValueMember = "idfsReference"
        Core.LookupBinder.BindBaseLookup(cbTests, baseDataSet, TestResult2Test_DB.TableTest + ".idfsReference", BaseReferenceType.rftTestType)
        m_TestResult2TestView = New DataView(baseDataSet.Tables(TestResult2Test_DB.TableTestResult2Test))
        Test2TestResultGrid.DataSource = m_TestResult2TestView
        eventManager.AttachDataHandler(TestResult2Test_DB.TableTest + ".idfsReference", AddressOf TestChanged)
        eventManager.AttachDataHandler(TestResult2Test_DB.TableTestResult2Test + ".blnIndicative", AddressOf IndicativeChanged)
        rgTestKind.EditValue = 0D
        Application.DoEvents()
    End Sub
    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables(TestResult2Test_DB.TableTestResult2Test).GetChanges() Is Nothing
    End Function

    Public Sub IndicativeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        'If e.Value.Equals(True) Then
        '    For Each row As DataRowView In m_TestResult2TestView
        '        If (Not row("idfsTestResult").Equals(e.Row("idfsTestResult")) AndAlso row("blnIndicative").Equals(True)) Then
        '            row("blnIndicative") = False
        '            row.EndEdit()
        '        End If
        '    Next
        'End If
        ExcludeTestResultsFromMainView()
    End Sub
    Public Sub TestChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value Is DBNull.Value Then
            m_TestResult2TestView.RowFilter = "idfsTestType=-1"
        Else
            m_TestResult2TestView.RowFilter = String.Format("idfsTestType={0}", e.Value)
        End If
        ExcludeTestResultsFromMainView()
    End Sub

    Private Sub ExcludeTestResultsFromMainView()
        Dim filter As String = LookupCache.EmptyLineKey.ToString()
        For Each row As DataRowView In m_TestResult2TestView
            If filter = "" Then
                filter = row("idfsTestResult").ToString
            Else
                filter += ", " + row("idfsTestResult").ToString
            End If
        Next
        If filter <> "" Then
            filter = " NOT idfsReference IN (" + filter + ")"
        End If
        m_TestResultView.RowFilter = filter
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        TestResult2Test_DB.AddTestResult2Test(baseDataSet, CLng(lstTestResults.SelectedValue), CType(lstTestResults.SelectedItem, DataRowView)("name").ToString, CInt(rgTestKind.EditValue))
        ExcludeTestResultsFromMainView()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim row As DataRow = Test2TestResultView.GetFocusedDataRow
        If Not row Is Nothing Then
            TestResult2Test_DB.RemoveTestResultFromTest(baseDataSet, row("idfsTestResult").ToString)

        End If
        ExcludeTestResultsFromMainView()

    End Sub

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAdd.Enabled = Not [ReadOnly] AndAlso (cbTests.ItemIndex >= 0) AndAlso lstTestResults.SelectedIndex >= 0
        btnRemove.Enabled = Not [ReadOnly] AndAlso Test2TestResultView.FocusedRowHandle >= 0
    End Sub

    Private Sub rgTestKind_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgTestKind.EditValueChanged
        If CInt(rgTestKind.EditValue) = 0 Then
            Core.LookupBinder.BindBaseLookup(cbTests, baseDataSet, TestResult2Test_DB.TableTest + ".idfsReference", BaseReferenceType.rftTestType)
            m_TestResultView = LookupCache.Get(BaseReferenceType.rftTestResult)
            'colIndicative.Visible = True
        Else
            Core.LookupBinder.BindBaseLookup(cbTests, baseDataSet, TestResult2Test_DB.TableTest + ".idfsReference", BaseReferenceType.rftPensideTestType)
            m_TestResultView = LookupCache.Get(BaseReferenceType.rftPensideTestResult)
            'colIndicative.Visible = False
        End If
        baseDataSet.Tables(TestResult2Test_DB.TableTest).Rows(0)("idfsReference") = -1
        lstTestResults.DataSource = Nothing
        lstTestResults.DataSource = m_TestResultView
        eventManager.Cascade(TestResult2Test_DB.TableTest + ".idfsReference")

    End Sub

    Private Sub btnAddTestResult_Click(sender As System.Object, e As System.EventArgs) Handles btnAddTestResult.Click
        Dim refType As BaseReferenceType
        If CInt(rgTestKind.EditValue) = 0 Then
            refType = BaseReferenceType.rftTestResult
        Else
            refType = BaseReferenceType.rftPensideTestResult
        End If
        Core.LookupBinder.ShowBaseReferenceEditor(Me, refType)
    End Sub

    Private Sub chkIndicative_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkIndicative.EditValueChanged
        Test2TestResultView.PostEditor()
    End Sub
End Class
