Imports eidss.model.Resources
Imports bv.common.Enums

Public Class EIDSSErrorMessage
    Inherits ErrorMessage
    Public Sub New(ByVal errMsg As String)
        MyBase.New(errMsg)
    End Sub
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String)
        MyBase.New(errResourceName, errMsg)
    End Sub
    Public Sub New(ByVal errType As StandardError, Optional ByVal ex As Exception = Nothing)
        MyBase.New(errType, ex)
    End Sub
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String, ByVal ex As Exception)
        MyBase.New(errResourceName, errMsg, ex)
    End Sub
    Public Sub New(ByVal errMsg As String, ByVal ex As Exception)
        MyBase.New(errMsg, ex)
    End Sub
    Public Sub New(ByVal ex As Exception)
        MyBase.New(ex)
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String, ex As Exception, ByVal ParamArray args As Object())
        MyBase.New(errResourceName, errMsg, ex, args)
    End Sub

    Protected Overrides Function GetErrorText() As String
        If m_formatArgs Is Nothing Then
            Return EidssMessages.Get(m_FriendlyErrorResourceName, m_FriendlyError)
        Else
            Return String.Format(EidssMessages.Get(m_FriendlyErrorResourceName, m_FriendlyError), m_formatArgs)
        End If
    End Function

End Class
