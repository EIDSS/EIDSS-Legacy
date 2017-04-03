<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenericReferenceDetail
    Inherits BV.common.win.BaseDetailList

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericReferenceDetail))
        Me.gcReference = New DevExpress.XtraGrid.GridControl()
        Me.gvReference = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolEnglishValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTranslatedValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolHACode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pceHACode = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.gcolOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.spinOrder = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pceHACode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcReference
        '
        resources.ApplyResources(Me.gcReference, "gcReference")
        Me.gcReference.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("gcReference.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.gcReference.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcReference.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcReference.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcReference.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcReference.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcReference.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcReference.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcReference.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcReference.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcReference.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.gcReference.MainView = Me.gvReference
        Me.gcReference.Name = "gcReference"
        Me.gcReference.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.pceHACode, Me.spinOrder})
        Me.gcReference.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvReference})
        '
        'gvReference
        '
        Me.gvReference.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolEnglishValue, Me.gcolTranslatedValue, Me.gcolCode, Me.gcolHACode, Me.gcolOrder})
        Me.gvReference.GridControl = Me.gcReference
        resources.ApplyResources(Me.gvReference, "gvReference")
        Me.gvReference.Name = "gvReference"
        Me.gvReference.OptionsCustomization.AllowFilter = False
        Me.gvReference.OptionsNavigation.AutoFocusNewRow = True
        Me.gvReference.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.gvReference.OptionsView.ShowGroupPanel = False
        '
        'gcolEnglishValue
        '
        Me.gcolEnglishValue.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolEnglishValue, "gcolEnglishValue")
        Me.gcolEnglishValue.FieldName = "strDefault"
        Me.gcolEnglishValue.Name = "gcolEnglishValue"
        '
        'gcolTranslatedValue
        '
        Me.gcolTranslatedValue.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolTranslatedValue, "gcolTranslatedValue")
        Me.gcolTranslatedValue.FieldName = "name"
        Me.gcolTranslatedValue.Name = "gcolTranslatedValue"
        '
        'gcolCode
        '
        resources.ApplyResources(Me.gcolCode, "gcolCode")
        Me.gcolCode.Name = "gcolCode"
        '
        'gcolHACode
        '
        Me.gcolHACode.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolHACode, "gcolHACode")
        Me.gcolHACode.ColumnEdit = Me.pceHACode
        Me.gcolHACode.FieldName = "intHACode"
        Me.gcolHACode.Name = "gcolHACode"
        '
        'pceHACode
        '
        Me.pceHACode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("pceHACode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.pceHACode.Mask.EditMask = resources.GetString("pceHACode.Mask.EditMask")
        Me.pceHACode.Mask.IgnoreMaskBlank = CType(resources.GetObject("pceHACode.Mask.IgnoreMaskBlank"), Boolean)
        Me.pceHACode.Mask.SaveLiteral = CType(resources.GetObject("pceHACode.Mask.SaveLiteral"), Boolean)
        Me.pceHACode.Mask.ShowPlaceHolders = CType(resources.GetObject("pceHACode.Mask.ShowPlaceHolders"), Boolean)
        Me.pceHACode.Name = "pceHACode"
        '
        'gcolOrder
        '
        resources.ApplyResources(Me.gcolOrder, "gcolOrder")
        Me.gcolOrder.ColumnEdit = Me.spinOrder
        Me.gcolOrder.FieldName = "intOrder"
        Me.gcolOrder.Name = "gcolOrder"
        Me.gcolOrder.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'spinOrder
        '
        resources.ApplyResources(Me.spinOrder, "spinOrder")
        Me.spinOrder.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.spinOrder.Mask.EditMask = resources.GetString("spinOrder.Mask.EditMask")
        Me.spinOrder.Mask.IgnoreMaskBlank = CType(resources.GetObject("spinOrder.Mask.IgnoreMaskBlank"), Boolean)
        Me.spinOrder.Mask.MaskType = CType(resources.GetObject("spinOrder.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.spinOrder.Mask.SaveLiteral = CType(resources.GetObject("spinOrder.Mask.SaveLiteral"), Boolean)
        Me.spinOrder.Mask.ShowPlaceHolders = CType(resources.GetObject("spinOrder.Mask.ShowPlaceHolders"), Boolean)
        Me.spinOrder.Name = "spinOrder"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'GenericReferenceDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gcReference)
        Me.Controls.Add(Me.btnDelete)
        Me.HelpTopicID = ""
        Me.KeyFieldName = "idfsBaseReference"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Book__large__41_
        Me.Name = "GenericReferenceDetail"
        Me.ObjectName = "Reference"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.TableName = "BaseReference"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.gcReference, 0)
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pceHACode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcReference As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvReference As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolEnglishValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTranslatedValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolHACode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pceHACode As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents gcolOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents spinOrder As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolCode As DevExpress.XtraGrid.Columns.GridColumn

End Class
