Imports System.ComponentModel
Public Class AvianFarmProductionControl
    Inherits BV.common.win.BaseDetailPanel
    Dim ProductionDbService As AvianFarmProduction_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ProductionDbService = New AvianFarmProduction_DB
        DbService = ProductionDbService

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
    Friend WithEvents FarmTypeGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rgAvianFarmType As DevExpress.XtraEditors.RadioGroup
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AvianFarmProductionControl))
        Me.FarmTypeGroup = New DevExpress.XtraEditors.GroupControl()
        Me.rgAvianFarmType = New DevExpress.XtraEditors.RadioGroup()
        CType(Me.FarmTypeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FarmTypeGroup.SuspendLayout()
        CType(Me.rgAvianFarmType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FarmTypeGroup
        '
        Me.FarmTypeGroup.Appearance.BackColor = CType(resources.GetObject("FarmTypeGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.FarmTypeGroup.Appearance.BorderColor = CType(resources.GetObject("FarmTypeGroup.Appearance.BorderColor"), System.Drawing.Color)
        Me.FarmTypeGroup.Appearance.Options.UseBackColor = True
        Me.FarmTypeGroup.Appearance.Options.UseBorderColor = True
        Me.FarmTypeGroup.AppearanceCaption.Options.UseFont = True
        Me.FarmTypeGroup.Controls.Add(Me.rgAvianFarmType)
        resources.ApplyResources(Me.FarmTypeGroup, "FarmTypeGroup")
        Me.FarmTypeGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.FarmTypeGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.FarmTypeGroup.Name = "FarmTypeGroup"
        '
        'rgAvianFarmType
        '
        resources.ApplyResources(Me.rgAvianFarmType, "rgAvianFarmType")
        Me.rgAvianFarmType.Name = "rgAvianFarmType"
        Me.rgAvianFarmType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.rgAvianFarmType.Properties.EnableFocusRect = True
        '
        'AvianFarmProductionControl
        '
        Me.Controls.Add(Me.FarmTypeGroup)
        Me.KeyFieldName = "idfFarm"
        Me.Name = "AvianFarmProductionControl"
        Me.ObjectName = "AvianFarmProduction"
        resources.ApplyResources(Me, "$this")
        Me.TableName = "Farm"
        CType(Me.FarmTypeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FarmTypeGroup.ResumeLayout(False)
        CType(Me.rgAvianFarmType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindBaseLookup(Me.rgAvianFarmType, baseDataSet, AvianFarmProduction_DB.TableFarm + ".idfsAvianFarmType", BaseReferenceType.rftAvianFarmType)
        'Core.LookupBinder.BindBaseLookup(Me.rgAvianProductionType, baseDataSet, AvianFarmProduction_DB.TableFarm + ".idfsAvianProductionType", BaseReferenceType.rftAvianProductionType)
        'Core.LookupBinder.BindBaseLookup(Me.rgIntendedUse, baseDataSet, AvianFarmProduction_DB.TableFarm + ".idfsIntendedUse", BaseReferenceType.rftFarmIntendedUse)
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property RootFarmID() As Object
        Get
            Dim row As DataRow = GetCurrentRow(AvianFarmProduction_DB.TableFarm)
            If Not row Is Nothing Then
                Return row("idfRootFarm")
            End If
            Return DBNull.Value
        End Get
        Set(ByVal Value As Object)
            Dim row As DataRow = GetCurrentRow(AvianFarmProduction_DB.TableFarm)
            If Not row Is Nothing Then
                row("idfRootFarm") = Value
            End If
        End Set
    End Property

 
 End Class
