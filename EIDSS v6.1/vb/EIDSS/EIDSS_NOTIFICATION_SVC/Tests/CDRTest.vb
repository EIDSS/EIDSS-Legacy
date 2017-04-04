Imports NUnit.Framework
Imports bv.common
Imports bv.common.db
Imports bv.common.Diagnostics
Imports EIDSS
Imports System.Data.SqlClient
Imports System.Windows.Forms
Namespace Tests
    <TestFixture()> _
    Public Class CDRTest
        Private m_Cdr As ServiceBase
        <SetUp()> _
        Public Sub Init()
            bv.common.Configuration.Config.FileName = "..\app2.config"
            GlobalSettings.CurrentLanguage = "en"
            ConfigWriter.Instance.Read("..\app2.config")
            InitEventTable()

            bv.common.db.Core.ConnectionManager.Create("..\app2.config")
            bv.common.AppStructure.Init("eidss*.dll", ".")
            GlobalSettings.CountryID = EIDSSSettings.CountryID
            StartService(m_Cdr, "..\app2.config")

        End Sub

        <TearDown()> _
        Public Sub TearDown()
            StopService(m_Cdr)
        End Sub
        <Test()> _
        Public Sub RaiseCaseChangedEventTest()
            Dim credentials As New bv.common.db.Core.ConnectionCredentials("..\app2.config")
            Dim m_NotificationManager As New NotificationManager(credentials, New ServiceConfiguration("..\app2.config"))
            m_NotificationManager.CreateNotification(NotificationType.notCaseStatusChanged, Guid.NewGuid, Nothing, Nothing)
            'EIDSS_EventLog.Instance.CreateEvent(EIDSS.EventType.evtCaseStatusChange, Guid.NewGuid)
            For i As Integer = 0 To 20
                Threading.Thread.Sleep(2000)
            Next
        End Sub
        Private Sub StartService(ByRef srv As ServiceBase, Optional ByVal configFile As String = Nothing)
            If srv Is Nothing Then
                srv = New ServiceBase
                srv.Start(1, configFile)
                srv.SkipExistingEvents()
                srv.OnEventOccured = AddressOf Me.EventOccured
                srv.OnNotificationReceived = AddressOf Me.NotificationReceived
            End If
        End Sub

        Private Sub StopService(ByRef srv As ServiceBase)
            If Not srv Is Nothing Then
                srv.Finish()
            End If
        End Sub
        Private Function WaitUntilEvent(ByVal evtTypes() As EventType, ByVal ObjectID As Object, ByVal serverName As String, ByVal timeout As Integer) As EventType
            DebugTimer.Start()
            Try
                While DebugTimer.Time < timeout
                    For Each evt As EventType In evtTypes
                        If Utils.IsEmpty(ObjectID) Then
                            If m_Events.Select(String.Format("EventType='{0}' and Server='{1}'", evt.ToString, serverName)).Length > 0 Then
                                Return evt
                            End If
                        Else
                            If m_Events.Select(String.Format("EventType='{0}' and ObjectID='{1}' and Server='{2}'", evt.ToString, ObjectID.ToString, serverName)).Length > 0 Then
                                Return evt
                            End If
                        End If
                    Next
                    System.Threading.Thread.Sleep(10)
                End While
            Finally
                DebugTimer.Stop()
            End Try
            Return EventType.evtDef
        End Function
        Private m_Events As DataTable
        Private Sub EventOccured(ByVal sender As Object, ByVal row As DataRow, ByVal ObjectID As Object)
            Dim eventRow As DataRow = m_Events.NewRow
            eventRow("ID") = row("idfEventID")
            eventRow("EventKind") = 0 ' event
            eventRow("EventType") = row("idfsEventTypeID")
            If ObjectID Is Nothing Then
                eventRow("ObjectID") = DBNull.Value
            Else
                eventRow("ObjectID") = ObjectID
            End If
            eventRow("EventDate") = row("datEventDatatime")
            eventRow("EventRegDate") = DateTime.Now
            eventRow("Server") = Utils.Str(sender)
            m_Events.Rows.Add(eventRow)
        End Sub
        Private Sub NotificationReceived(ByVal sender As Object, ByVal row As DataRow, ByVal ObjectID As Object)
            Dim eventRow As DataRow = m_Events.NewRow
            eventRow("ID") = row("idfNotification")
            eventRow("EventKind") = 1 ' notification
            eventRow("EventType") = row("idfsNotification_Type")
            If ObjectID Is Nothing Then
                eventRow("ObjectID") = DBNull.Value
            Else
                eventRow("ObjectID") = ObjectID
            End If
            eventRow("EventDate") = row("datCreationDate")
            eventRow("EventRegDate") = DateTime.Now
            eventRow("Server") = Utils.Str(sender)
            m_Events.Rows.Add(eventRow)
        End Sub
        Private Sub InitEventTable()
            m_Events = New DataTable
            m_Events.Columns.Add(New DataColumn("ID", GetType(Guid)))
            m_Events.Columns.Add(New DataColumn("EventKind", GetType(Integer)))
            m_Events.Columns.Add(New DataColumn("EventType", GetType(String)))
            m_Events.Columns.Add(New DataColumn("ObjectID", GetType(Guid)))
            m_Events.Columns.Add(New DataColumn("EventDate", GetType(DateTime)))
            m_Events.Columns.Add(New DataColumn("EventRegDate", GetType(DateTime)))
            m_Events.Columns.Add(New DataColumn("Server", GetType(String)))
            m_Events.PrimaryKey = New DataColumn() {m_Events.Columns(0)}
        End Sub
        Sub ValidateEventsOrder(ByVal serverName As String, ByVal events() As EventType)
            Dim rows() As DataRow = m_Events.Select(String.Format("Server='{0}'", serverName))
            For i As Integer = 0 To events.Length - 1
                Assert.AreEqual(Utils.Str(rows(i)("EventType")), events(i).ToString, "incorrect events order")
            Next
        End Sub
    End Class

End Namespace
