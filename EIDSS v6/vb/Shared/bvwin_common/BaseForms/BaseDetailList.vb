Imports System.ComponentModel
Imports bv.winclient.BasePanel

Public Class BaseDetailList

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FormType = BaseFormType.DetailList
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
    Public Overrides ReadOnly Property IsSingleTone() As Boolean
        Get
            Return True
        End Get
    End Property
End Class
