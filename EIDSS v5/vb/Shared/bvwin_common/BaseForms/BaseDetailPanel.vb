Public Class BaseDetailPanel
    Inherits common.win.BaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Visible = True
        Enabled = True
        Me.FormType = BaseFormType.DetailPanel

    End Sub

    Protected Overridable Sub BeforeDispose()

    End Sub


    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            BeforeDispose()
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseDetailPanel
        '
        Me.Name = "BaseDetailPanel"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        If DbService Is Nothing Then Return False
        If Me.DesignMode Then Return False
        Dim c As Boolean = baseDataSet.EnforceConstraints
        baseDataSet.EnforceConstraints = False
        baseDataSet.Clear()
        Dim ds As DataSet = DbService.LoadDetailData(ID)
        If Not ds Is Nothing Then
            Merge(ds)
            If Me.Visible = False Then
                DbService.IgnoreChanges = True
            End If
            DbDisposeHelper.DisposeDataset(ds)
            Return True
        Else
            ErrorForm.ShowError(DbService.LastError)
            Return False
        End If
    End Function
    Public Overrides Function GetBindingManager(Optional ByVal aTableName As String = Nothing) As BindingManagerBase
        If baseDataSet Is Nothing Then Return Nothing
        If baseDataSet.Tables.Count = 0 Then Return Nothing
        If aTableName Is Nothing OrElse aTableName = "" Then
            aTableName = ObjectName
        End If
        If aTableName Is Nothing OrElse aTableName = "" Then Return Nothing
        If baseDataSet.Tables.Contains(aTableName) Then
            Return BindingContext(baseDataSet.Tables(aTableName))
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If UseFormStatus = True AndAlso Status = FormStatus.Demo Then
            Return True
        End If
        If DbService Is Nothing Then Return True
        DataEventManager.Flush()
        If Not HasChanges() Then Return True
        RaiseBeforeValidatingEvent()
        If ValidateData() = False Then Return False
        If DbService Is Nothing Then
            Throw New Exception("Detail form DB service is not defined")
            Return False
        End If
        RaiseBeforePostEvent(Me)
        If DbService.Post(baseDataSet, PostType) = False Then '.GetChanges()
            ErrorForm.ShowError(DbService.LastError)
            Return False
        End If
        If (PostType And PostType.IntermediatePosting) <> 0 Then
            m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
            m_WasSaved = True
        End If
        If (PostType And PostType.FinalPosting) <> 0 Then
            m_State = BusinessObjectState.EditObject
            m_WasSaved = False
        End If
        Return True
    End Function

End Class
