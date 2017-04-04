Imports bv.common.Enums
Imports bv.winclient.Core

Public Class BaseDetailPanel
    Inherits BaseForm

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
        Try
            If disposing Then
                BeforeDispose()
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If

        Finally
            MyBase.Dispose(disposing)

        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        'Form Is Localizable: False
        '
        'BaseDetailPanel
        '
        Me.Name = "BaseDetailPanel"
        Me.ResumeLayout(False)
    End Sub

#End Region

    Public Overrides Function FillDataset(Optional ByVal ID As Object = Nothing) As Boolean
        If DbService Is Nothing Then Return False
        If DesignMode Then Return False
        baseDataSet.EnforceConstraints = False
        baseDataSet.Clear()
        Dim ds As DataSet = DbService.LoadDetailData(ID)
        If Not ds Is Nothing Then
            Merge(ds)
            If Visible = False Then
                DbService.IgnoreChanges = True
            End If
            DbDisposeHelper.DisposeDataset(ds)
            Return True
        Else
            Dim err As ErrorMessage = DbService.LastError
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw New Exception(err.DetailError)
            End If
            ErrorForm.ShowErrorDirect(err.Text, err.Exception)
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
        If Not Utils.IsCalledFromUnitTest() AndAlso FindForm() Is Nothing Then Return True
        DataEventManager.Flush()
        If Not HasChanges() Then Return True
        RaiseBeforeValidatingEvent()
        If ValidateData() = False Then Return False
        If DbService Is Nothing Then
            Throw New Exception("Detail form DB service is not defined")
        End If
        RaiseBeforePostEvent(Me)
        If DbService.Post(baseDataSet, postType) = False Then '.GetChanges()
            Dim err As ErrorMessage = DbService.LastError
            If (BaseSettings.ThrowExceptionOnError) Then
                Throw New Exception(err.DetailError)
            End If
            ErrorForm.ShowErrorDirect(err.Text, err.Exception)
            Return False
        End If
        If (postType And postType.IntermediatePosting) <> 0 Then
            m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
            m_WasSaved = True
        End If
        If (postType And postType.FinalPosting) <> 0 Then
            m_State = BusinessObjectState.EditObject
            m_WasSaved = False
        End If
        Return True
    End Function
End Class
