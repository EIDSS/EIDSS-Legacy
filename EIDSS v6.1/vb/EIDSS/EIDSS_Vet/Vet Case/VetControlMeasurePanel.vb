Imports System.ComponentModel
Imports bv.common.db
Public Class VetControlMeasurePanel
    Inherits BaseDetailPanel
    Dim ControlMeasureDbService As VetControlMeasures_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ControlMeasureDbService = New VetControlMeasures_DB
        DbService = ControlMeasureDbService
        RegisterChildObject(ffControlMeasures, RelatedPostOrder.PostLast)

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
    Friend WithEvents ffControlMeasures As EIDSS.FlexibleForms.FFPresenter

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContolMeasureGroup As DevExpress.XtraEditors.GroupControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetControlMeasurePanel))
        Me.ContolMeasureGroup = New DevExpress.XtraEditors.GroupControl()
        Me.ffControlMeasures = New EIDSS.FlexibleForms.FFPresenter()
        CType(Me.ContolMeasureGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContolMeasureGroup.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetControlMeasurePanel), resources)
        'Form Is Localizable: True
        '
        'ContolMeasureGroup
        '
        Me.ContolMeasureGroup.Appearance.BackColor = CType(resources.GetObject("ContolMeasureGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.ContolMeasureGroup.Appearance.Options.UseBackColor = True
        Me.ContolMeasureGroup.Appearance.Options.UseFont = True
        Me.ContolMeasureGroup.AppearanceCaption.Options.UseFont = True
        Me.ContolMeasureGroup.Controls.Add(Me.ffControlMeasures)
        resources.ApplyResources(Me.ContolMeasureGroup, "ContolMeasureGroup")
        Me.ContolMeasureGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.ContolMeasureGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ContolMeasureGroup.Name = "ContolMeasureGroup"
        Me.ContolMeasureGroup.TabStop = True
        '
        'ffControlMeasures
        '
        resources.ApplyResources(Me.ffControlMeasures, "ffControlMeasures")
        Me.ffControlMeasures.DCManager = Nothing
        Me.ffControlMeasures.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.ffControlMeasures.DelayedLoadingNeeded = False
        Me.ffControlMeasures.DynamicParameterEnabled = False
        Me.ffControlMeasures.FormID = Nothing
        Me.ffControlMeasures.HelpTopicID = Nothing
        Me.ffControlMeasures.KeyFieldName = Nothing
        Me.ffControlMeasures.MultiSelect = False
        Me.ffControlMeasures.Name = "ffControlMeasures"
        Me.ffControlMeasures.ObjectName = Nothing
        Me.ffControlMeasures.SectionTableCaptionsIsVisible = True
        Me.ffControlMeasures.Status = bv.common.win.FormStatus.Draft
        Me.ffControlMeasures.TableName = Nothing
        '
        'VetControlMeasurePanel
        '
        Me.Controls.Add(Me.ContolMeasureGroup)
        Me.KeyFieldName = "idfCase"
        Me.Name = "VetControlMeasurePanel"
        Me.ObjectName = "VetControlMeasures"
        resources.ApplyResources(Me, "$this")
        Me.TableName = "VetCase"
        CType(Me.ContolMeasureGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContolMeasureGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Flexible Form Support"
    Private m_DiagnosisID As Long = -1
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisID() As Long
        Set(ByVal Value As Long)
            If m_DiagnosisID <> Value Then
                m_DiagnosisID = Value
                'If Not CurrentRow Is Nothing AndAlso Not RootBaseForm.Loading Then
                '    CurrentRow("idfsFormTemplate") = DBNull.Value
                'End If
                'RefreshFlexibleForm()
            End If
        End Set
    End Property

    Private Sub RefreshFlexibleForm()
        If Loading Then Return
        Dim row As DataRow = Me.GetCurrentRow()
        If row Is Nothing Then
            SetFlexibleFormVisibility(False)
            Return
        End If
        SetFlexibleFormVisibility(True)
        ShowFlexibleForm(row)
    End Sub

    Private ReadOnly Property CurrentRow() As DataRow
        Get
            Return Me.GetCurrentRow()
        End Get
    End Property
    Private Sub ShowFlexibleForm(ByVal row As DataRow)
        If row("idfsFormTemplate") Is DBNull.Value Then
            ffControlMeasures.ShowFlexibleFormByDeterminant(-1, CLng(row("idfObservation")), FFType.LivestockControlMeasures) 'm_DiagnosisID
            If ffControlMeasures.TemplateID.HasValue AndAlso ffControlMeasures.TemplateID.Value > 0 Then
                row("idfsFormTemplate") = ffControlMeasures.TemplateID
            End If
        Else
            ffControlMeasures.ShowFlexibleForm(CLng(row("idfsFormTemplate")), CLng(row("idfObservation")), FFType.LivestockControlMeasures)
        End If

    End Sub

    Private Sub SetFlexibleFormVisibility(ByVal aVisible As Boolean)
        Me.ffControlMeasures.Visible = aVisible
    End Sub


    Protected Overrides Sub AfterLoad()
        RefreshFlexibleForm()
    End Sub

#End Region

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return Nothing
    End Function
End Class
