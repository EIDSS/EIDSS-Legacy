Imports bv.common.Diagnostics
Imports NUnit.Framework
Imports Microsoft.SqlServer.Management
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Smo.Agent


Namespace Tests
    <TestFixture()> _
    Public Class JobTest
        Dim server As Smo.Server = Nothing
        Dim database As Smo.Database = Nothing
        Dim m_credentials As bv.common.db.Core.ConnectionCredentials
        Private m_SqlClientAgentAccessor As JobAccessor
        Private m_TaskAccessor As JobAccessor

        Private Function GetSqlServerConnection() As SqlClient.SqlConnection
            m_credentials = New bv.common.db.Core.ConnectionCredentials("..\sqlServer.config")
            'm_credentials.SetCredentials _
            '( _
            '    Nothing, _
            '    Nothing, _
            '    Nothing, _
            '    "super", _
            '    "super" _
            ')
            Return New System.Data.SqlClient.SqlConnection(m_credentials.CreateConnectionString)
        End Function
        Private Function GetSqlExpressConnection() As SqlClient.SqlConnection
            m_credentials = New bv.common.db.Core.ConnectionCredentials("..\sqlExpress.config")
            'm_credentials.SetCredentials _
            '( _
            '    Nothing, _
            '    Nothing, _
            '    Nothing, _
            '    "super", _
            '    "super" _
            ')
            Return New System.Data.SqlClient.SqlConnection(m_credentials.CreateConnectionString)
        End Function
        Private Function CreateTestJob(ByVal jobName As String, ByVal sqlScript As String) As Job
            Dim job As Job = Nothing
            If server Is Nothing Then
                Dim sqlConn As System.Data.SqlClient.SqlConnection = GetSqlServerConnection()
                sqlConn.Open()
                Dim mainConnection As New Microsoft.SqlServer.Management.Common.ServerConnection(sqlConn)
                server = New Server(mainConnection)
            End If
            DropJob(jobName)
            job = New Job(server.JobServer, jobName)
            job.Create()
            Dim jobStep As JobStep = New JobStep(job, jobName)
            jobStep.SubSystem = AgentSubSystem.TransactSql
            jobStep.Command = sqlScript
            jobStep.CommandExecutionSuccessCode = 201
            jobStep.DatabaseName = m_credentials.SQLDatabase
            jobStep.OnSuccessAction = StepCompletionAction.QuitWithSuccess
            jobStep.OnSuccessStep = 0
            jobStep.OnFailAction = StepCompletionAction.QuitWithFailure
            jobStep.OnFailStep = 0
            jobStep.Create()
            job.ApplyToTargetServer(m_credentials.SQLServer)
            job.Refresh()
            Return job
        End Function

        Private Sub DropJob(ByVal jobName As String)
            For Each _job As Job In server.JobServer.Jobs
                If _job.Name = jobName Then
                    server.JobServer.RemoveJobByID(_job.JobID)
                    Exit For
                End If
            Next
        End Sub
        <SetUp()> _
        Public Sub Init()
            m_credentials = New bv.common.db.Core.ConnectionCredentials("..\sqlServer.config")
            m_SqlClientAgentAccessor = New JobAccessor(m_credentials.SQLServer, m_credentials.SQLUser, m_credentials.SQLPassword)
            m_credentials = New bv.common.db.Core.ConnectionCredentials("..\sqlExpress.config")
            m_TaskAccessor = New JobAccessor(m_credentials.SQLServer, m_credentials.SQLUser, m_credentials.SQLPassword)
        End Sub

        <Test()> _
        Public Sub SusccessfullJobTest()
            Dim job As Job = CreateTestJob("TestJob", "Print 'Test job'")
            If m_SqlClientAgentAccessor.RunJob(job.Name) <> 0 Then
                Assert.IsTrue(False, "Job is failed,  sqlJob.LastRunOutcome={0} ", job.LastRunOutcome)
            End If
            DropJob(job.Name)
        End Sub
        <Test()> _
        Public Sub StartedJobTest()
            Dim job As Job = CreateTestJob("TestJob", "DECLARE @I INT; SET @I=0; WHILE (@I<1000000) SET @I=@I+1;")
            Dim sqlJob As Job = Nothing
            For Each jb As Job In server.JobServer.Jobs
                If jb.Name = "TestJob" Then
                    sqlJob = jb
                    Exit For
                End If
            Next
            For j As Integer = 0 To job.JobSteps.Count - 1
                Dim [step] As JobStep = job.JobSteps.Item(j)
                [step].RetryAttempts = 1
            Next
            sqlJob.Start()
            If m_SqlClientAgentAccessor.RunJob(job.Name) <> 0 Then
                Assert.IsTrue(False, "Job is failed,  sqlJob.LastRunOutcome={0} ", job.LastRunOutcome)
            End If
            DropJob(job.Name)
        End Sub
        <Test()> _
        Public Sub FailedJobTest()
            Dim job As Job = CreateTestJob("TestJob", "exec dbo.spRaiseErrorTest")
            If m_SqlClientAgentAccessor.RunJob(job.Name) = 0 Then
                Assert.IsTrue(False, "Job is NOT failed,  sqlJob.LastRunOutcome={0} ", job.LastRunOutcome)
            End If
            DropJob(job.Name)
        End Sub
        <Test()> _
        Public Sub ClentAgentExistenceTest()
            Assert.IsTrue(TypeOf (m_SqlClientAgentAccessor.JobProvider) Is SqlClentAgentJobProvider, "sql agent should not exist for server {0}", m_SqlClientAgentAccessor.ServerName)
            Assert.IsTrue(TypeOf (m_TaskAccessor.JobProvider) Is TaskProvider, "sql agent should not exist for server {0}", m_TaskAccessor.ServerName)
        End Sub
    End Class
End Namespace
