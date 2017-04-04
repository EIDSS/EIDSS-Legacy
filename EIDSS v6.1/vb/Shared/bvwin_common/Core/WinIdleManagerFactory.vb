Imports bv.common.Core

Namespace Core
    Public Class WinIdleManagerFactory
        Implements IIdleManagerFactory

        Public Sub New()
            ' NOOP
        End Sub

        Public Function CreateIdleManager() As IIdleManager Implements IIdleManagerFactory.CreateIdleManager
            Return New WinIdleManager()
        End Function
    End Class
End Namespace
