Imports System.Runtime.Serialization
Imports System.Xml

<Serializable()> _
    Public Class ClassNotFoundException
    Inherits ApplicationException
    Private m_DetailMessage As String = ""

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub

    Public Sub New()
        ' NOOP
    End Sub

    Public Sub New(ByVal className As String)
        m_DetailMessage = String.Format("Class {0} is not found in registered assemblies", className)
    End Sub

    Public Overrides ReadOnly Property Message() As String
        Get
            Return m_DetailMessage
        End Get
    End Property

    Public Property DetailMessage() As String
        Get
            Return m_DetailMessage
        End Get
        Set(ByVal value As String)
            m_DetailMessage = value
        End Set
    End Property

End Class
