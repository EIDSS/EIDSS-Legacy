Imports bv.common.Core
Imports bv.common.Diagnostics

Namespace Core
    Public Class WinIdleManager
        Implements IIdleManager

        Shared Sub New()
            Dbg.Debug("init")
            AddHandler Application.Idle, AddressOf HandleGlobalIdle
        End Sub

        Private Shared Event InternalIdle As EventHandler

        Public Shared Event AfterIdle As EventHandler

        Public Custom Event Idle As EventHandler Implements IIdleManager.Idle
            AddHandler(ByVal handler As EventHandler)
                AddHandler InternalIdle, handler
            End AddHandler
            RemoveHandler(ByVal handler As EventHandler)
                RemoveHandler InternalIdle, handler
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                RaiseEvent InternalIdle(sender, e)
            End RaiseEvent
        End Event

        Private Shared Sub HandleGlobalIdle(ByVal sender As Object, ByVal ev As EventArgs)
            Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "global idle")
            RaiseEvent InternalIdle(sender, ev)
            RaiseEvent AfterIdle(sender, ev)
        End Sub

        Public Shared Sub SignalIdleState()
            HandleGlobalIdle(Nothing, EventArgs.Empty) ' FIXME
        End Sub
    End Class
End Namespace
