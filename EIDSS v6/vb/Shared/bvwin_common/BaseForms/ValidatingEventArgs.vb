
Public Class ValidatingEventArgs
    Public Sub New(ByVal aObjectID As Object, ByVal aFieldName As String)
        m_ObjectID = aObjectID
        m_FieldName = aFieldName
    End Sub
    Private m_ObjectID As Object

    Public Property ObjectID() As Object
        Get
            Return m_ObjectID
        End Get
        Set(ByVal Value As Object)
            m_ObjectID = Value
        End Set
    End Property

    Private m_FieldName As String

    Public Property FieldName() As String
        Get
            Return m_FieldName
        End Get
        Set(ByVal Value As String)
            m_FieldName = Value
        End Set
    End Property

    Private m_Cancel As Boolean = False
    Public Property Cancel() As Boolean
        Get
            Return m_Cancel
        End Get
        Set(ByVal Value As Boolean)
            m_Cancel = Value
        End Set
    End Property

End Class

Public Delegate Sub ValidatingHandler(sender as Object , e as ValidatingEventArgs)