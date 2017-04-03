Imports bv.common.Objects

Namespace Core
    Public Class EIDSSAuditObject
        Inherits AuditObject
        Public Sub New(ByVal aName As Long, ByVal aTableName As Long)
            MyBase.New(aName, aTableName)
        End Sub

        Public Overrides ReadOnly Property AuditTableName() As String
            Get
                Return CType(AuditTable, AuditTable).ToString
            End Get
        End Property
    End Class
End Namespace