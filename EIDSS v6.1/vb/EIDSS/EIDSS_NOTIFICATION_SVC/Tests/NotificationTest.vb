Imports NUnit.Framework
Imports bv.common
Imports bv.common.db
Imports bv.common.Diagnostics
Imports EIDSS
Imports System.Data.SqlClient
Imports System.Windows.Forms
Namespace Tests
    <TestFixture()> _
    Public Class NotificationTest
        Private m_ServerCount As Integer
        Public Function CreateVetCase(ByVal serverIndex As Integer) As Guid
            bv.common.db.Core.LookupCache.UseSingleConnection = True
            EIDSS_LookupCacheHelper.Init()
            While Not bv.common.db.Core.LookupCache.Filled
                System.Threading.Thread.Sleep(1000)
                Dbg.Dbg("waiting for async lookup table filling")
            End While

            Dim caseForm As New VetCaseAvianDetail
            SyncLock ConfigWriter.Instance
                ConfigWriter.Instance.Read("..\app" & serverIndex & ".config")
                caseForm.DbService.CreateConnection(ConfigWriter.Instance.Item("SQLServer"), ConfigWriter.Instance.Item("SQLDatabase"), ServiceConfiguration.UserName, ServiceConfiguration.Password)
            End SyncLock
            caseForm.LoadData(Nothing)
            caseForm.ChangeStatus()
            If Not m_Events Is Nothing Then
                m_Events.Clear()
            End If
            If caseForm.Post() = False Then
                Assert.Fail("vet case post is failed")
            End If
            Return CType(caseForm.GetKey(), Guid)
        End Function

        <Test()> _
        Public Sub SendNotificationTest()
            Dim CaseID As Guid = CreateVetCase(0)
            Dim evt As EventType = WaitUntilEvent(New EventType() {EventType.evtReplicationSucceeded, EventType.evtReplicationFailed}, ReplicationController.CompleteReplicationGuid, m_Srv(0).ServerName, 300)
            If evt = EventType.evtDef Then
                Assert.Fail("timeout for replication to EMS level")
            ElseIf evt = EventType.evtReplicationFailed Then
                Assert.Fail("replication to EMS is failed")
            Else
                ValidateEventsOrder(m_Srv(0).ServerName, New EventType() {EventType.evtNewVetCase, EventType.evtCaseStatusChange, EventType.evtReplicationRequestedByUser, EventType.evtReplicationStarted, EventType.evtReplicationSucceeded})
                Threading.Thread.Sleep(10000)
                If m_ServerCount > 1 Then
                    Dim cmd As New SqlCommand(String.Format("Select idfActivity from Activity where idfActivity = '{0}'", CaseID), CType(m_Srv(1).Connection, SqlConnection))
                    Dim errMsg As ErrorMessage = Nothing
                    If BaseDbService.ExecScalar(cmd, cmd.Connection, errMsg) Is Nothing Then
                        If Not errMsg Is Nothing Then
                            Dbg.Dbg("error during ems case retrieving: {0}", errMsg.DetailError)
                        End If
                        Assert.Fail("case is not transferred to EMS level")
                    End If

                    'wait while notification will be processd on the server 1
                    cmd.CommandText = "Select idfNotification from Notification where Cast(strPayload as VARCHAR(36)) = @strPayload"
                    cmd.Parameters.AddWithValue("@strPayload", CaseID.ToString)
                    Dim ntfyID As Object = BaseDbService.ExecScalar(cmd, cmd.Connection, errMsg)
                    If ntfyID Is Nothing Then
                        If Not errMsg Is Nothing Then
                            Dbg.Dbg("error during ems notification retrieving: {0}", errMsg.DetailError)
                        End If
                        Assert.Fail("notification is not transferred to EMS level")
                    End If

                    cmd.CommandText = "Select idfNotification from Notification_Status where idfNotification = @idfNotification and intProcessed = 1"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@idfNotification", SqlDbType.UniqueIdentifier))
                    cmd.Parameters(0).Value = ntfyID
                    Dim Delay As Integer = 50000
                    For i As Integer = 0 To Delay
                        If Not BaseDbService.ExecScalar(cmd, cmd.Connection, errMsg) Is Nothing Then
                            Exit For
                        End If
                        If i = Delay Then
                            If Not errMsg Is Nothing Then
                                Dbg.Dbg("error during ems case retrieving: {0}", errMsg.DetailError)
                            End If
                            Assert.Fail("notification is not processed on EMS level")
                        End If
                        Application.DoEvents()
                    Next

                    If m_ServerCount > 2 Then
                        evt = WaitUntilEvent(New EventType() {EventType.evtReplicationSucceeded, EventType.evtReplicationFailed}, Nothing, m_Srv(1).ServerName, 300)
                        If evt = EventType.evtDef Then
                            Assert.Fail("timeout for replication to CDR level")
                        ElseIf evt = EventType.evtReplicationFailed Then
                            Assert.Fail("replication to CDR is failed")
                        End If
                        cmd = New SqlCommand(String.Format("Select idfActivity from Activity where idfActivity = '{0}'", CaseID), CType(m_Srv(2).Connection, SqlConnection))
                        If BaseDbService.ExecScalar(cmd, cmd.Connection, errMsg, , True) Is Nothing Then
                            Assert.Fail("case is not transferred to CDR level")
                        End If
                    End If
                End If
                End If
        End Sub

        <Test(), Ignore("not implemented")> _
        Public Sub LookupChangeTest()

        End Sub

        Private m_Srv(3) As ServiceBase

        <SetUp()> _
        Public Sub Init()
            GlobalSettings.CurrentLanguage = "en"
            ConfigWriter.Instance.Read("..\app.config")
            InitEventTable()

            bv.common.db.Core.ConnectionManager.Create("..\app.config")
            bv.common.AppStructure.Init("eidss*.dll", ".")
            bv.common.db.Core.AuditManager.EventLog = EIDSS.EIDSS_EventLog.Instance
            GlobalSettings.CountryID = EIDSSSettings.CountryID
            m_ServerCount = CInt(ConfigWriter.Instance.Item("ServerCount"))
            'For i As Integer = 0 To m_ServerCount - 1
            'StartService(m_Srv(i), i, "..\app" & i & ".config")
            'Next
            StartService(m_Srv(0), "..\app0.config")
            'StartService(m_Srv(1), "..\app1.config")

        End Sub

        <TearDown()> _
        Public Sub TearDown()
            For i As Integer = 0 To m_ServerCount - 1
                StopService(m_Srv(i))
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

