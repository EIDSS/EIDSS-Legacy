Imports System.ComponentModel
Imports System.Collections.Generic

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
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoPatient, AuditTable.tlbParty)
        LookupTableNames = New String() {"Human"}
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Patient

        Me.RegisterChildObject(PatientInfo, RelatedPostOrder.PostFirst)

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
    Friend WithEvents PatientInfo As EIDSS.Patient_Info


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientDetail))
        Me.PatientInfo = New EIDSS.Patient_Info
        Me.SuspendLayout()
        '
        'PatientInfo
        '
        Me.PatientInfo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.PatientInfo.Appearance.Options.UseFont = True
        Me.PatientInfo.Caption = Nothing
        Me.PatientInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.PatientInfo.FormID = Nothing
        Me.PatientInfo.HelpTopicID = Nothing
        resources.ApplyResources(Me.PatientInfo, "PatientInfo")
        Me.PatientInfo.IsStatusReadOnly = False
        Me.PatientInfo.KeyFieldName = Nothing
        Me.PatientInfo.MultiSelect = False
        Me.PatientInfo.Name = "PatientInfo"
        Me.PatientInfo.ObjectName = "Patient"
        Me.PatientInfo.Status = bv.common.win.FormStatus.Draft
        Me.PatientInfo.TableName = "tlbHuman"
        '
        'PatientDetail
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.PatientInfo)
        Me.FormID = "H04"
        Me.HelpTopicID = "human_case_form"
        Me.KeyFieldName = "idfHuman"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Person__large_
        Me.Name = "PatientDetail"
        Me.ObjectName = "Patient"
        Me.TableName = "tlbHuman"
        Me.Controls.SetChildIndex(Me.PatientInfo, 0)
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
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public WriteOnly Property IsSharedAddress() As Boolean
        Set(ByVal Value As Boolean)
            PatientInfo.CurrentResidence_AddressLookup.IsSharedAddress = Value
            PatientInfo.Employer_AddressLookup.IsSharedAddress = Value
        End Set
    End Property

    Private m_HadChangesBeforePost As Boolean = False

    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        DataEventManager.Flush()
        m_HadChangesBeforePost = Me.HasChanges()
        Return MyBase.Post
    End Function

End Class
