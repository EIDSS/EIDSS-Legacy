<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleGroupCheckInShortList
    Inherits bv.common.win.BaseDetailForm

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Protected WithEvents SamplesGrid As DevExpress.XtraGrid.GridControl
    Protected WithEvents SamplesGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Protected WithEvents colCaseID As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colSpecimenType As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colCollectionDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCaseID As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

    ''NOTE: The following procedure is required by the Windows Form Designer
    ''It can be modified using the Windows Form Designer.  
    ''Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    components = New System.ComponentModel.Container()
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    'End Sub

End Class
