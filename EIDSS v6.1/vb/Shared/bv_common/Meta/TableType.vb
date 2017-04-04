Imports System.Xml.Serialization

Namespace Meta
    Public Enum TableType
        <XmlEnum("root")> Root
        <XmlEnum("sibling")> Sibling
        <XmlEnum("child")> Child
        <XmlEnum("lookup")> Lookup
        <XmlEnum("link")> Link
        <XmlEnum("intermediate")> Intermediate
    End Enum
End Namespace