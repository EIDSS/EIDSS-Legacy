Imports System.ComponentModel
Imports System.Collections.Generic
Imports EIDSS.model.Enums

Public Class PatientDetail

    Inherits BaseDetailForm

    Dim PatientDbService As PatientDetail_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        PatientDbService = New PatientDetail_DB

        DbService = PatientDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoPatient, AuditTable.tlbHuman)
        LookupTableNames = New String() {"Human"}
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Patient
        PatientInfo.IsRootPatient = True
        Me.RegisterChildObject(PatientInfo, RelatedPostOrder.PostFirst)
        ValidationProcedureName = "spPatient_Validate"
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
    Friend WithEvents dtEnteredDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbEnteredDate As System.Windows.Forms.Label
    Friend WithEvents dtModificationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbModificationDate As System.Windows.Forms.Label
    Friend WithEvents PatientInfo As EIDSS.Patient_Info


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientDetail))
        Me.PatientInfo = New EIDSS.Patient_Info()
        Me.dtEnteredDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbEnteredDate = New System.Windows.Forms.Label()
        Me.dtModificationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbModificationDate = New System.Windows.Forms.Label()
        CType(Me.dtEnteredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteredDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtModificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtModificationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(PatientDetail), resources)
        'Form Is Localizable: True
        '
        'PatientInfo
        '
        Me.PatientInfo.Appearance.Font = CType(resources.GetObject("PatientInfo.Appearance.Font"), System.Drawing.Font)
        Me.PatientInfo.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.PatientInfo, "PatientInfo")
        Me.PatientInfo.FormID = Nothing
        Me.PatientInfo.HelpTopicID = Nothing
        Me.PatientInfo.KeyFieldName = Nothing
        Me.PatientInfo.MaxAge = 0
        Me.PatientInfo.MultiSelect = False
        Me.PatientInfo.Name = "PatientInfo"
        Me.PatientInfo.ObjectName = "Patient"
        Me.PatientInfo.TableName = "tlbHuman"
        '
        'dtEnteredDate
        '
        resources.ApplyResources(Me.dtEnteredDate, "dtEnteredDate")
        Me.dtEnteredDate.Name = "dtEnteredDate"
        Me.dtEnteredDate.Properties.Appearance.Font = CType(resources.GetObject("dtEnteredDate.Properties.Appearance.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.Appearance.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceDisabled.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceDropDown.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceDropDownHeaderHighlight.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceDropDownHeaderHighlight.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceDropDownHighlight.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceDropDownHighlight.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceFocused.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtEnteredDate.Properties.AppearanceWeekNumber.Font = CType(resources.GetObject("dtEnteredDate.Properties.AppearanceWeekNumber.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtEnteredDate.Properties.CalendarTimeProperties.Appearance.Font = CType(resources.GetObject("dtEnteredDate.Properties.CalendarTimeProperties.Appearance.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font = CType(resources.GetObject("dtEnteredDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceFocused.Font = CType(resources.GetObject("dtEnteredDate.Properties.CalendarTimeProperties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font = CType(resources.GetObject("dtEnteredDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtEnteredDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtEnteredDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtEnteredDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteredDate.Properties.EditFormat.FormatString = "g"
        Me.dtEnteredDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteredDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.dtEnteredDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtEnteredDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtEnteredDate.Properties.ReadOnly = True
        Me.dtEnteredDate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.dtEnteredDate.Tag = "{R}"
        '
        'lbEnteredDate
        '
        resources.ApplyResources(Me.lbEnteredDate, "lbEnteredDate")
        Me.lbEnteredDate.Name = "lbEnteredDate"
        '
        'dtModificationDate
        '
        resources.ApplyResources(Me.dtModificationDate, "dtModificationDate")
        Me.dtModificationDate.Name = "dtModificationDate"
        Me.dtModificationDate.Properties.Appearance.Font = CType(resources.GetObject("dtModificationDate.Properties.Appearance.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.Appearance.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDisabled.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDown.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceDropDownHighlight.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceDropDownHighlight.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceFocused.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtModificationDate.Properties.AppearanceWeekNumber.Font = CType(resources.GetObject("dtModificationDate.Properties.AppearanceWeekNumber.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.Appearance.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.Appearance.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font = CType(resources.GetObject("dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.dtModificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtModificationDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtModificationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtModificationDate.Properties.EditFormat.FormatString = "g"
        Me.dtModificationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtModificationDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.dtModificationDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtModificationDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtModificationDate.Properties.ReadOnly = True
        Me.dtModificationDate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.dtModificationDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtModificationDate.Tag = "{R}"
        '
        'lbModificationDate
        '
        resources.ApplyResources(Me.lbModificationDate, "lbModificationDate")
        Me.lbModificationDate.Name = "lbModificationDate"
        '
        'PatientDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("PatientDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.dtModificationDate)
        Me.Controls.Add(Me.lbModificationDate)
        Me.Controls.Add(Me.dtEnteredDate)
        Me.Controls.Add(Me.lbEnteredDate)
        Me.Controls.Add(Me.PatientInfo)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "H04"
        Me.HelpTopicID = "HC_H04"
        Me.KeyFieldName = "idfHuman"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Person__large_
        Me.Name = "PatientDetail"
        Me.ObjectName = "Patient"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "tlbHuman"
        Me.Controls.SetChildIndex(Me.PatientInfo, 0)
        Me.Controls.SetChildIndex(Me.lbEnteredDate, 0)
        Me.Controls.SetChildIndex(Me.dtEnteredDate, 0)
        Me.Controls.SetChildIndex(Me.lbModificationDate, 0)
        Me.Controls.SetChildIndex(Me.dtModificationDate, 0)
        CType(Me.dtEnteredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteredDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtModificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtModificationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Sub Merge(ByVal ds As DataSet)
        baseDataSet.Merge(ds)
    End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return GetKey(Patient_DB.tlbHuman, "idfHuman")
    End Function

    Protected Overrides Sub DefineBinding()
        Try
            Me.PatientInfo.StartUpParameters = Me.StartUpParameters
            m_HadChangesBeforePost = False
            MyBase.DefineBinding()
        Catch e As Exception
        End Try
    End Sub

    Public Function HadChangesBeforePost() As Boolean
        If PatientInfo Is Nothing Then Return False
        Return (m_HadChangesBeforePost OrElse PatientInfo.HasChanges())
    End Function

    Private Sub PatientInfo_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatientInfo.AfterLoadData
        Dim params As Dictionary(Of String, Object) = StartUpParameters
        If (Not params Is Nothing) AndAlso (params.ContainsKey("ReadOnly")) AndAlso (TypeOf (params("ReadOnly")) Is Boolean) AndAlso (Me.ReadOnly <> CBool(params("ReadOnly"))) Then
            Me.ReadOnly = CBool(params("ReadOnly"))
        End If
        Core.LookupBinder.BindDateEdit(dtEnteredDate, PatientInfo.baseDataSet, Patient_DB.tlbHuman + ".datEnteredDate")
        Core.LookupBinder.BindDateEdit(dtModificationDate, PatientInfo.baseDataSet, Patient_DB.tlbHuman + ".datModificationDate")
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public WriteOnly Property IsSharedAddress() As Boolean
        Set(ByVal Value As Boolean)
            PatientInfo.CurrentResidence_AddressLookup.IsSharedAddress = Value
            PatientInfo.Employer_AddressLookup.IsSharedAddress = Value
        End Set
    End Property

    Private m_HadChangesBeforePost As Boolean = False

    Public Overrides Function Post(Optional ByVal postType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
        DataEventManager.Flush()
        m_HadChangesBeforePost = Me.HasChanges()
        Return MyBase.Post
    End Function

End Class
