Imports EIDSS.model.Enums

Public Class DepartmentDetail

    Inherits BaseDetailForm

    Dim DepartmentDbService As Department_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        DepartmentDbService = New Department_DB
        DbService = DepartmentDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoDepartment, AuditTable.tlbOffice)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Organization

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNationalDepartmentName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEnglishName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNationalName As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepartmentDetail))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNationalDepartmentName = New DevExpress.XtraEditors.TextEdit()
        Me.txtEnglishName = New DevExpress.XtraEditors.TextEdit()
        Me.cbOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNationalName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.txtNationalDepartmentName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(DepartmentDetail), resources)
        'Form Is Localizable: True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtNationalDepartmentName
        '
        resources.ApplyResources(Me.txtNationalDepartmentName, "txtNationalDepartmentName")
        Me.txtNationalDepartmentName.Name = "txtNationalDepartmentName"
        Me.txtNationalDepartmentName.Properties.AutoHeight = CType(resources.GetObject("txtNationalDepartmentName.Properties.AutoHeight"), Boolean)
        Me.txtNationalDepartmentName.Properties.Mask.EditMask = resources.GetString("txtNationalDepartmentName.Properties.Mask.EditMask")
        Me.txtNationalDepartmentName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtNationalDepartmentName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtNationalDepartmentName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtNationalDepartmentName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtNationalDepartmentName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtNationalDepartmentName.Properties.Mask.ShowPlaceHolders"), Boolean)
        '
        'txtEnglishName
        '
        resources.ApplyResources(Me.txtEnglishName, "txtEnglishName")
        Me.txtEnglishName.Name = "txtEnglishName"
        Me.txtEnglishName.Properties.AutoHeight = CType(resources.GetObject("txtEnglishName.Properties.AutoHeight"), Boolean)
        Me.txtEnglishName.Properties.Mask.EditMask = resources.GetString("txtEnglishName.Properties.Mask.EditMask")
        Me.txtEnglishName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtEnglishName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtEnglishName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtEnglishName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtEnglishName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtEnglishName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtEnglishName.Tag = "{M}[en]"
        '
        'cbOrganization
        '
        resources.ApplyResources(Me.cbOrganization, "cbOrganization")
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Properties.AutoHeight = CType(resources.GetObject("cbOrganization.Properties.AutoHeight"), Boolean)
        Me.cbOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbOrganization.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbOrganization.Properties.Columns"), CType(resources.GetObject("cbOrganization.Properties.Columns1"), Integer), resources.GetString("cbOrganization.Properties.Columns2")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbOrganization.Properties.Columns3"), CType(resources.GetObject("cbOrganization.Properties.Columns4"), Integer), resources.GetString("cbOrganization.Properties.Columns5"))})
        Me.cbOrganization.Properties.NullText = resources.GetString("cbOrganization.Properties.NullText")
        Me.cbOrganization.Tag = "{M}"
        '
        'lblNationalName
        '
        resources.ApplyResources(Me.lblNationalName, "lblNationalName")
        Me.lblNationalName.Name = "lblNationalName"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'DepartmentDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.cbOrganization)
        Me.Controls.Add(Me.txtEnglishName)
        Me.Controls.Add(Me.txtNationalDepartmentName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNationalName)
        Me.Controls.Add(Me.Label1)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A21"
        Me.HelpTopicID = "Organisations"
        Me.KeyFieldName = "idfDepartment"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Department_137_
        Me.Name = "DepartmentDetail"
        Me.ObjectName = "Department"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Department"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblNationalName, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNationalDepartmentName, 0)
        Me.Controls.SetChildIndex(Me.txtEnglishName, 0)
        Me.Controls.SetChildIndex(Me.cbOrganization, 0)
        CType(Me.txtNationalDepartmentName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region
    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindTextEdit(txtNationalDepartmentName, baseDataSet, "Department.Name")
        Core.LookupBinder.BindTextEdit(txtEnglishName, baseDataSet, "Department.DefaultName")
        Core.LookupBinder.BindOrganizationLookup(Me.cbOrganization, baseDataSet, "Department.idfOrganization", HACode.None)
        If Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("OrganizationID") Then
            baseDataSet.Tables("Department").Rows(0)("idfOrganization") = StartUpParameters("OrganizationID")
            txtEnglishName.Select()
        End If

        If (bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn) Then
            Me.txtNationalDepartmentName.Visible = False
            Me.lblNationalName.Visible = False
        End If

    End Sub

End Class
