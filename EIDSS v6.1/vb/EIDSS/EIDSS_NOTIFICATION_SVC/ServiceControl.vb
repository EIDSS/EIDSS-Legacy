Imports System.ServiceProcess
Imports System.Collections.Generic


Public Class ServiceControl
    Inherits System.ServiceProcess.ServiceBase

    Private m_ServiceList As New List(Of ServiceBase)

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
        'bv.common.AppStructure.Init("eidss*.dll")
    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Try
            For Each argument As String In My.Application.CommandLineArgs
                If argument.ToLowerInvariant().Substring(1) = "dbg" Then
                    Dim srv As New ServiceControl
                    srv.OnStart(Nothing)
                    Return
                End If
            Next
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase

            ' More than one NT Service may run within the same process. To add
            ' another service to this process, change the following line to
            ' create a second service object. For example,
            '
            '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
            '
            ServicesToRun = New System.ServiceProcess.ServiceBase() {New ServiceControl}

            System.ServiceProcess.ServiceBase.Run(ServicesToRun)


        Catch ex As Exception
            bv.common.Diagnostics.Dbg.Debug(ex.ToString)
        End Try

        'Dim q As New ServiceControl
        'q.OnStart(Nothing)

        'System.Console.ReadLine()

        'q.OnStop()

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'ServiceControl
        '
        Me.ServiceName = "EIDSS60_Ntfy"

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        bv.common.Core.ClassLoader.Init("bv.common.dll", Nothing)
        bv.common.Core.ClassLoader.Init("bv_common.dll", Nothing)
        bv.common.Core.ClassLoader.Init("bvdb_common.dll", Nothing)
        bv.common.Core.ClassLoader.Init("eidss_common.dll", Nothing)
        bv.common.Core.ClassLoader.Init("eidss_db.dll", Nothing)
        model.Core.EidssUserContext.Init()
        model.Core.EidssUserContext.User.LoginName = "ntfy"
        Dim dir As String = bv.common.Core.Utils.GetExecutingPath()
        Dim file As String
        For Each file In IO.Directory.GetFiles(dir, "EIDSS60_Ntfy*.config")
            Dim service As New ServiceBase
            If Not (service.Start(0, file)) Then Me.Stop()
            m_ServiceList.Add(service)
        Next

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        For Each service As ServiceBase In m_ServiceList
            service.Finish()
        Next
    End Sub

End Class
