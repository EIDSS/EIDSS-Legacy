Imports System.ComponentModel
Public Class LivestockFarmProductionControl
    Inherits BaseDetailPanel
    Dim ProductionDbService As LivestockFarmProduction_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ProductionDbService = New LivestockFarmProduction_DB
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
    Friend WithEvents OwnershipStructureGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rgOwnerhipStructure As DevExpress.XtraEditors.RadioGroup
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LivestockFarmProductionControl))
        Me.OwnershipStructureGroup = New DevExpress.XtraEditors.GroupControl()
        Me.rgOwnerhipStructure = New DevExpress.XtraEditors.RadioGroup()
        CType(Me.OwnershipStructureGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OwnershipStructureGroup.SuspendLayout()
        CType(Me.rgOwnerhipStructure.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(LivestockFarmProductionControl), resources)
        'Form Is Localizable: True
        '
        'OwnershipStructureGroup
        '
        Me.OwnershipStructureGroup.Appearance.BackColor = CType(resources.GetObject("OwnershipStructureGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.OwnershipStructureGroup.Appearance.BorderColor = CType(resources.GetObject("OwnershipStructureGroup.Appearance.BorderColor"), System.Drawing.Color)
        Me.OwnershipStructureGroup.Appearance.Options.UseBackColor = True
        Me.OwnershipStructureGroup.Appearance.Options.UseBorderColor = True
        Me.OwnershipStructureGroup.AppearanceCaption.Options.UseFont = True
        Me.OwnershipStructureGroup.Controls.Add(Me.rgOwnerhipStructure)
        resources.ApplyResources(Me.OwnershipStructureGroup, "OwnershipStructureGroup")
        Me.OwnershipStructureGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.OwnershipStructureGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.OwnershipStructureGroup.Name = "OwnershipStructureGroup"
        '
        'rgOwnerhipStructure
        '
        resources.ApplyResources(Me.rgOwnerhipStructure, "rgOwnerhipStructure")
        Me.rgOwnerhipStructure.Name = "rgOwnerhipStructure"
        Me.rgOwnerhipStructure.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.rgOwnerhipStructure.Properties.EnableFocusRect = True
        '
        'LivestockFarmProductionControl
        '
        Me.Controls.Add(Me.OwnershipStructureGroup)
        Me.KeyFieldName = "idfFarm"
        Me.Name = "LivestockFarmProductionControl"
        Me.ObjectName = "LivestockFarmProduction"
        resources.ApplyResources(Me, "$this")
        Me.TableName = "Farm"
        CType(Me.OwnershipStructureGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OwnershipStructureGroup.ResumeLayout(False)
        CType(Me.rgOwnerhipStructure.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()
        Core.LookupBinder.BindBaseLookup(Me.rgOwnerhipStructure, baseDataSet, LivestockFarmProduction_DB.TableFarm + ".idfsOwnershipStructure", BaseReferenceType.rftOwnershipType)
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property RootFarmID() As Object
        Get
            Dim row As DataRow = GetCurrentRow(LivestockFarmProduction_DB.TableFarm)
            If Not row Is Nothing Then
                Return row("idfRootFarm")
            End If
            Return DBNull.Value
        End Get
        Set(ByVal Value As Object)
            Dim row As DataRow = GetCurrentRow(LivestockFarmProduction_DB.TableFarm)
            If Not row Is Nothing Then
                row("idfRootFarm") = Value
            End If
        End Set
    End Property

End Class
