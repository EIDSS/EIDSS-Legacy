Imports System.Text
Imports System.Collections.Generic
Imports bv.common.Core

Namespace Objects
    Public Class AuditObject
        Public Sub New(ByVal aName As Long, ByVal aTableName As Long)
            m_Name = aName
            m_Table = aTableName
        End Sub
        Private m_Name As Long = Nothing
        Public Property Name() As Long
            Get
                Return m_Name
            End Get
            Set(ByVal value As Long)
                m_Name = value
            End Set
        End Property
        Private m_Table As Long
        Public Property AuditTable() As Long
            Get
                Return m_Table
            End Get
            Set(ByVal value As Long)
                m_Table = value
            End Set
        End Property
        Public Overridable ReadOnly Property AuditTableName() As String
            Get
                Return ""
            End Get
        End Property

        Private m_Key As Object = DBNull.Value
        Public Property Key() As Object
            Get
                Return m_Key
            End Get
            Set(ByVal value As Object)
                m_Key = value
            End Set
        End Property

        Private m_EventType As AuditEventType = AuditEventType.daeFreeDataUpdate
        Public Property EventType() As AuditEventType
            Get
                Return m_EventType
            End Get
            Set(ByVal value As AuditEventType)
                m_EventType = value
            End Set
        End Property

        Private m_Reason As String = Nothing
        Public Property Reason() As String
            Get
                Return Me.m_Reason
            End Get
            Set(ByVal value As String)

                If (Not (value Is Nothing) And (Utils.IsEmpty(value) = False)) Then Me.m_Reason = value

            End Set
        End Property
        Private m_LastAuditEventID As Object = Nothing
        Public Property LastAuditEventID() As Object
            Get
                Return m_LastAuditEventID
            End Get
            Set(ByVal value As Object)
                m_LastAuditEventID = value
            End Set
        End Property
        Private m_EventLog As IEventLog
        Public Property EventLog() As IEventLog
            Get
                Return m_EventLog
            End Get
            Set(ByVal value As IEventLog)
                m_EventLog = value
            End Set
        End Property
        'Private m_EventLogTypes As List(Of Core.EventInfo)
        'Public Property EventLogTypes() As List(Of Core.EventInfo)
        '    Get
        '        Return m_EventLogTypes
        '    End Get
        '    Set(ByVal value As List(Of Core.EventInfo))
        '        m_EventLogTypes = value
        '    End Set
        'End Property
        'Public Sub MarkEventsAsProcessed()
        '    SyncLock m_EventLogTypes
        '        For Each evt As Core.EventInfo In m_EventLogTypes
        '            evt.Processed = 1
        '        Next
        '    End SyncLock

        'End Sub
    End Class

End Namespace
