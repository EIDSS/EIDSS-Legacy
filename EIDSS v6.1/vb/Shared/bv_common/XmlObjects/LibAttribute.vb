Namespace XmlObjects
    <AttributeUsage(AttributeTargets.Class)> _
    Public Class XmlObjectAttribute
        Inherits Attribute
        Implements IXmlObjectAttribute
        Private m_Category As String = Nothing
        Private m_Name As String = Nothing

        Public Sub New(ByVal category As String, ByVal name As String)
            m_Category = category
            m_Name = name
        End Sub

#Region "ILibAttribute Members"

        Public Property Category() As String Implements IXmlObjectAttribute.Category
            Get
                Return m_Category
            End Get
            Set(ByVal value As String)
                m_Category = value
            End Set
        End Property

        Public Property Name() As String Implements IXmlObjectAttribute.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

#End Region
    End Class
End Namespace
