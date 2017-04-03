<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataAuditDetail
    Inherits bv.common.win.BaseDetailForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataAuditDetail))
        Me.txtObjectType = New DevExpress.XtraEditors.TextEdit()
        Me.lbObjectType = New System.Windows.Forms.Label()
        Me.txtActionType = New DevExpress.XtraEditors.TextEdit()
        Me.lbActionType = New System.Windows.Forms.Label()
        Me.txtTableName = New DevExpress.XtraEditors.TextEdit()
        Me.lbTableName = New System.Windows.Forms.Label()
        Me.txtObjectID = New DevExpress.XtraEditors.TextEdit()
        Me.lbObjectID = New System.Windows.Forms.Label()
        Me.txtSiteID = New DevExpress.XtraEditors.TextEdit()
        Me.lbSiteID = New System.Windows.Forms.Label()
        Me.txtDate = New DevExpress.XtraEditors.TextEdit()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.txtServerName = New DevExpress.XtraEditors.TextEdit()
        Me.lbHostName = New System.Windows.Forms.Label()
        Me.DataAuditGrid = New DevExpress.XtraGrid.GridControl()
        Me.AuditDetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTableName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colObjectValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSecondObjectValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOldValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNewValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtUser = New DevExpress.XtraEditors.TextEdit()
        Me.lbUser = New System.Windows.Forms.Label()
        Me.btnRestore = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtObjectType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTableName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObjectID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataAuditGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuditDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(DataAuditDetail), resources)
        'Form Is Localizable: True
        '
        'txtObjectType
        '
        resources.ApplyResources(Me.txtObjectType, "txtObjectType")
        Me.txtObjectType.Name = "txtObjectType"
        Me.txtObjectType.Properties.AutoHeight = CType(resources.GetObject("txtObjectType.Properties.AutoHeight"), Boolean)
        Me.txtObjectType.Properties.Mask.EditMask = resources.GetString("txtObjectType.Properties.Mask.EditMask")
        Me.txtObjectType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtObjectType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtObjectType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtObjectType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtObjectType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtObjectType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtObjectType.Properties.ReadOnly = True
        Me.txtObjectType.Tag = ""
        '
        'lbObjectType
        '
        resources.ApplyResources(Me.lbObjectType, "lbObjectType")
        Me.lbObjectType.Name = "lbObjectType"
        '
        'txtActionType
        '
        resources.ApplyResources(Me.txtActionType, "txtActionType")
        Me.txtActionType.Name = "txtActionType"
        Me.txtActionType.Properties.AutoHeight = CType(resources.GetObject("txtActionType.Properties.AutoHeight"), Boolean)
        Me.txtActionType.Properties.Mask.EditMask = resources.GetString("txtActionType.Properties.Mask.EditMask")
        Me.txtActionType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtActionType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtActionType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtActionType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtActionType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtActionType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtActionType.Properties.ReadOnly = True
        Me.txtActionType.Tag = ""
        '
        'lbActionType
        '
        resources.ApplyResources(Me.lbActionType, "lbActionType")
        Me.lbActionType.Name = "lbActionType"
        '
        'txtTableName
        '
        resources.ApplyResources(Me.txtTableName, "txtTableName")
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Properties.AutoHeight = CType(resources.GetObject("txtTableName.Properties.AutoHeight"), Boolean)
        Me.txtTableName.Properties.Mask.EditMask = resources.GetString("txtTableName.Properties.Mask.EditMask")
        Me.txtTableName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtTableName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtTableName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtTableName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtTableName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtTableName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtTableName.Properties.ReadOnly = True
        Me.txtTableName.Tag = ""
        '
        'lbTableName
        '
        resources.ApplyResources(Me.lbTableName, "lbTableName")
        Me.lbTableName.Name = "lbTableName"
        '
        'txtObjectID
        '
        resources.ApplyResources(Me.txtObjectID, "txtObjectID")
        Me.txtObjectID.Name = "txtObjectID"
        Me.txtObjectID.Properties.AutoHeight = CType(resources.GetObject("txtObjectID.Properties.AutoHeight"), Boolean)
        Me.txtObjectID.Properties.Mask.EditMask = resources.GetString("txtObjectID.Properties.Mask.EditMask")
        Me.txtObjectID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtObjectID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtObjectID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtObjectID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtObjectID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtObjectID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtObjectID.Properties.ReadOnly = True
        Me.txtObjectID.Tag = ""
        '
        'lbObjectID
        '
        resources.ApplyResources(Me.lbObjectID, "lbObjectID")
        Me.lbObjectID.Name = "lbObjectID"
        '
        'txtSiteID
        '
        resources.ApplyResources(Me.txtSiteID, "txtSiteID")
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Properties.AutoHeight = CType(resources.GetObject("txtSiteID.Properties.AutoHeight"), Boolean)
        Me.txtSiteID.Properties.Mask.EditMask = resources.GetString("txtSiteID.Properties.Mask.EditMask")
        Me.txtSiteID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSiteID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSiteID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSiteID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSiteID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSiteID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSiteID.Properties.ReadOnly = True
        Me.txtSiteID.Tag = ""
        '
        'lbSiteID
        '
        resources.ApplyResources(Me.lbSiteID, "lbSiteID")
        Me.lbSiteID.Name = "lbSiteID"
        '
        'txtDate
        '
        resources.ApplyResources(Me.txtDate, "txtDate")
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.AutoHeight = CType(resources.GetObject("txtDate.Properties.AutoHeight"), Boolean)
        Me.txtDate.Properties.DisplayFormat.FormatString = "G"
        Me.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDate.Properties.Mask.EditMask = resources.GetString("txtDate.Properties.Mask.EditMask")
        Me.txtDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtDate.Properties.ReadOnly = True
        Me.txtDate.Tag = ""
        '
        'lbDate
        '
        resources.ApplyResources(Me.lbDate, "lbDate")
        Me.lbDate.Name = "lbDate"
        '
        'txtServerName
        '
        resources.ApplyResources(Me.txtServerName, "txtServerName")
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Properties.AutoHeight = CType(resources.GetObject("txtServerName.Properties.AutoHeight"), Boolean)
        Me.txtServerName.Properties.DisplayFormat.FormatString = "G"
        Me.txtServerName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtServerName.Properties.Mask.EditMask = resources.GetString("txtServerName.Properties.Mask.EditMask")
        Me.txtServerName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtServerName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtServerName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtServerName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtServerName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtServerName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtServerName.Properties.ReadOnly = True
        Me.txtServerName.Tag = ""
        '
        'lbHostName
        '
        resources.ApplyResources(Me.lbHostName, "lbHostName")
        Me.lbHostName.Name = "lbHostName"
        '
        'DataAuditGrid
        '
        resources.ApplyResources(Me.DataAuditGrid, "DataAuditGrid")
        Me.DataAuditGrid.MainView = Me.AuditDetailView
        Me.DataAuditGrid.Name = "DataAuditGrid"
        Me.DataAuditGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AuditDetailView})
        '
        'AuditDetailView
        '
        Me.AuditDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTableName, Me.colObjectValue, Me.colSecondObjectValue, Me.colColumnName, Me.colOldValue, Me.colNewValue, Me.colAction})
        Me.AuditDetailView.GridControl = Me.DataAuditGrid
        Me.AuditDetailView.Name = "AuditDetailView"
        Me.AuditDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AuditDetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AuditDetailView.OptionsBehavior.Editable = False
        Me.AuditDetailView.OptionsView.ShowGroupPanel = False
        '
        'colTableName
        '
        resources.ApplyResources(Me.colTableName, "colTableName")
        Me.colTableName.FieldName = "strTableName"
        Me.colTableName.Name = "colTableName"
        '
        'colObjectValue
        '
        resources.ApplyResources(Me.colObjectValue, "colObjectValue")
        Me.colObjectValue.FieldName = "idfObject"
        Me.colObjectValue.Name = "colObjectValue"
        '
        'colSecondObjectValue
        '
        resources.ApplyResources(Me.colSecondObjectValue, "colSecondObjectValue")
        Me.colSecondObjectValue.FieldName = "idfObjectDetail"
        Me.colSecondObjectValue.Name = "colSecondObjectValue"
        '
        'colColumnName
        '
        resources.ApplyResources(Me.colColumnName, "colColumnName")
        Me.colColumnName.FieldName = "strColumnName"
        Me.colColumnName.Name = "colColumnName"
        '
        'colOldValue
        '
        resources.ApplyResources(Me.colOldValue, "colOldValue")
        Me.colOldValue.FieldName = "strOldValue"
        Me.colOldValue.Name = "colOldValue"
        '
        'colNewValue
        '
        resources.ApplyResources(Me.colNewValue, "colNewValue")
        Me.colNewValue.FieldName = "strNewValue"
        Me.colNewValue.Name = "colNewValue"
        '
        'colAction
        '
        resources.ApplyResources(Me.colAction, "colAction")
        Me.colAction.FieldName = "strActionType"
        Me.colAction.Name = "colAction"
        '
        'txtUser
        '
        resources.ApplyResources(Me.txtUser, "txtUser")
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Properties.AutoHeight = CType(resources.GetObject("txtUser.Properties.AutoHeight"), Boolean)
        Me.txtUser.Properties.Mask.EditMask = resources.GetString("txtUser.Properties.Mask.EditMask")
        Me.txtUser.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtUser.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtUser.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtUser.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtUser.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtUser.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtUser.Properties.ReadOnly = True
        Me.txtUser.Tag = ""
        '
        'lbUser
        '
        resources.ApplyResources(Me.lbUser, "lbUser")
        Me.lbUser.Name = "lbUser"
        '
        'btnRestore
        '
        resources.ApplyResources(Me.btnRestore, "btnRestore")
        Me.btnRestore.Name = "btnRestore"
        '
        'DataAuditDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.lbUser)
        Me.Controls.Add(Me.DataAuditGrid)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.lbHostName)
        Me.Controls.Add(Me.txtSiteID)
        Me.Controls.Add(Me.lbSiteID)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.lbDate)
        Me.Controls.Add(Me.txtObjectID)
        Me.Controls.Add(Me.lbObjectID)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.lbTableName)
        Me.Controls.Add(Me.txtActionType)
        Me.Controls.Add(Me.lbActionType)
        Me.Controls.Add(Me.txtObjectType)
        Me.Controls.Add(Me.lbObjectType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A25"
        Me.HelpTopicID = "Data_Audit_Management"
        Me.IgnoreAudit = True
        Me.KeyFieldName = "idfDataAuditEvent"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.DataAuditTransaction_136_
        Me.Name = "DataAuditDetail"
        Me.ObjectName = "DataAudit"
        Me.ShowCancelButton = False
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "DataAudit"
        Me.Controls.SetChildIndex(Me.lbObjectType, 0)
        Me.Controls.SetChildIndex(Me.txtObjectType, 0)
        Me.Controls.SetChildIndex(Me.lbActionType, 0)
        Me.Controls.SetChildIndex(Me.txtActionType, 0)
        Me.Controls.SetChildIndex(Me.lbTableName, 0)
        Me.Controls.SetChildIndex(Me.txtTableName, 0)
        Me.Controls.SetChildIndex(Me.lbObjectID, 0)
        Me.Controls.SetChildIndex(Me.txtObjectID, 0)
        Me.Controls.SetChildIndex(Me.lbDate, 0)
        Me.Controls.SetChildIndex(Me.txtDate, 0)
        Me.Controls.SetChildIndex(Me.lbSiteID, 0)
        Me.Controls.SetChildIndex(Me.txtSiteID, 0)
        Me.Controls.SetChildIndex(Me.lbHostName, 0)
        Me.Controls.SetChildIndex(Me.txtServerName, 0)
        Me.Controls.SetChildIndex(Me.DataAuditGrid, 0)
        Me.Controls.SetChildIndex(Me.lbUser, 0)
        Me.Controls.SetChildIndex(Me.txtUser, 0)
        Me.Controls.SetChildIndex(Me.btnRestore, 0)
        CType(Me.txtObjectType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTableName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObjectID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataAuditGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuditDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtObjectType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbObjectType As System.Windows.Forms.Label
    Friend WithEvents txtActionType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbActionType As System.Windows.Forms.Label
    Friend WithEvents txtTableName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbTableName As System.Windows.Forms.Label
    Friend WithEvents txtObjectID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbObjectID As System.Windows.Forms.Label
    Friend WithEvents txtSiteID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbSiteID As System.Windows.Forms.Label
    Friend WithEvents txtDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbDate As System.Windows.Forms.Label
    Friend WithEvents txtServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbHostName As System.Windows.Forms.Label
    Friend WithEvents DataAuditGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AuditDetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTableName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObjectValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSecondObjectValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOldValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNewValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbUser As System.Windows.Forms.Label
    Friend WithEvents btnRestore As DevExpress.XtraEditors.SimpleButton

End Class
