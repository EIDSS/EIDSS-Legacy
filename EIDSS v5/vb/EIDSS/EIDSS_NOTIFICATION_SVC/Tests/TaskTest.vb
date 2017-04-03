Imports bv.common.Diagnostics
Imports bv.common
Imports bv.common.db.Core
Imports TaskScheduler

Imports NUnit.Framework
Imports System.Threading

Namespace Tests
    <TestFixture()> _
    Public Class TaskTest
        Private Shared Function RunTask(ByVal taskName As String) As UInteger
            Dim task As Task = task.Get(taskName)
            task.Run()
            DebugTimer.Start("task '{0}'is started", taskName)
            'Thread.Sleep(400)
            While task.IsRunning
                Dbg.Dbg("task '{0}' is running", taskName)
                Thread.Sleep(500)
            End While
            DebugTimer.Stop()
            Dim err As UInteger = task.GetLastError
            Dbg.Dbg("task '{0}' last error: {1}", taskName, err)
            Return err
        End Function
        <SetUp()> _
        Public Sub Init()
            Dim Dir As New IO.DirectoryInfo(Environment.CurrentDirectory)
            Dir = New IO.DirectoryInfo(Dir.Parent.FullName + "\tests\tasks")
            Task.Create("dummyTask", "DummyJob.cmd", Nothing, Dir.FullName, DateTime.Now, 24)
            Task.Create("dummyFailedTask", "DummyFailedJob.cmd", Nothing, Dir.FullName, DateTime.Now, 24)
            Task.Create("NotificationReplication", "wscript", "/b invis.vbs notification_repl.cmd", Dir.FullName, DateTime.Now, 4)
            Task.Create("ReferenceReplication", "wscript", "/b invis.vbs reference_repl.cmd", Dir.FullName, DateTime.Now, 4)
            Task.Create("MainReplication", "wscript", "/b invis.vbs main_repl.cmd", Dir.FullName, DateTime.Now, 4)
        End Sub
        <TearDown()> _
        Public Sub Deinit()
            Task.Delete("dummyTask")
            Task.Delete("dummyFailedTask")
            Task.Delete("NotificationReplication")
            Task.Delete("ReferenceReplication")
            Task.Delete("MainReplication")
        End Sub

        <Test()> _
        Public Sub RunDummyTask()
            For i As Integer = 0 To 10
                Dim err As UInteger = RunTask("dummyTask")
                Assert.AreEqual(0, err, " incorrect return code")
                err = RunTask("dummyFailedTask")
                Assert.AreNotEqual(0, err, " incorrect return code")
            Next
        End Sub

        <Test()> _
        Public Sub RunNotificationJobTask()
            Dim err As UInteger = RunTask("NotificationReplication")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub
        <Test()> _
        Public Sub RunMainJobTask()
            Dim err As UInteger = RunTask("MainReplication")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub
        <Test()> _
        Public Sub RunReferenceJobTask()
            Dim err As UInteger = RunTask("ReferenceReplication")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub

        <Test()> _
        Public Sub RunNotificationUsingTaskAccessor()
            Dim cn As ConnectionManager = ConnectionManager.Create("..\sqlExpress.config")
            Dim accessor As New JobAccessor(cn.SQLServer, cn.SQLUser, cn.SQLPassword)
            Assert.IsInstanceOfType(GetType(TaskProvider), accessor.JobProvider)
            Dim err As Integer = accessor.RunJob("NotificationReplication")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub
        <Test()> _
        Public Sub RunNotificationUsingSqlClientJobAccessor()
            Dim cn As ConnectionManager = ConnectionManager.Create("..\sqlServer.config")
            Dim accessor As New JobAccessor(cn.SQLServer, cn.SQLUser, cn.SQLPassword)
            Assert.IsInstanceOfType(GetType(SqlClentAgentJobProvider), accessor.JobProvider)
            Dim err As Integer = accessor.RunJob("pacsstandalone-Z-ZNotification-MIKE\SQL2005-EIDSS_test- 0")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub
        <Test()> _
        Public Sub RunReferenceUsingSqlClientJobAccessor()
            Dim cn As ConnectionManager = ConnectionManager.Create("..\sqlServer.config")
            Dim accessor As New JobAccessor(cn.SQLServer, cn.SQLUser, cn.SQLPassword)
            Assert.IsInstanceOfType(GetType(SqlClentAgentJobProvider), accessor.JobProvider)
            Dim err As Integer = accessor.RunJob("pacsstandalone-Z-ZReference-MIKE\SQL2005-EIDSS_test- 0")
            Assert.AreEqual(0, err, "unexpected return code")
        End Sub
        <Test()> _
        Public Sub StartCompleteReplication()
            Dim err As UInteger = 0
            Dim i As Integer = 3
            err = RunTask("ReferenceReplication")
            Thread.Sleep(1000)
            Assert.AreEqual(0, err, "unexpected return code")
            If err <> 0 Then
                If i <= 0 Then
                    Dbg.Dbg("Reference replication retry count is exceeded, last error - {0}", err)
                Else
                    Dbg.Dbg("Reference replication failed with result {0}", err)
                End If
                Return
            End If
            err = RunTask("MainReplication")
            Assert.AreEqual(0, err, "unexpected return code")
            Thread.Sleep(1000)
            If err = 0 Then
                err = RunTask("NotificationReplication")
                Assert.AreEqual(0, err, "unexpected return code")
            ElseIf err <> 0 Then
                Dbg.Dbg("Complete replication failed with result {0}", err)
            End If
        End Sub
        <Test()> _
        Public Sub RunService()
            Dim srv As New ServiceBase()
            bv.common.AppStructure.Init("eidss_common.dll", Environment.CurrentDirectory)
            bv.common.AppStructure.Init("eidss_db.dll", Environment.CurrentDirectory)
            srv.Start(1, "..\sqlExpress.config")
            While True
                Thread.Sleep(500)
            End While
        End Sub

    End Class
End Namespace