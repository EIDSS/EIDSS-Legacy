Imports System.Xml

Namespace ErrorHandling
    Public Interface IServerException
        Function ToXml(ByVal doc As XmlDocument) As XmlElement
    End Interface
End Namespace