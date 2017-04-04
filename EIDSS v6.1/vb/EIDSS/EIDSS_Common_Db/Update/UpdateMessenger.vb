'Public Class UpdateMessenger
'    Private m_ConnectionManager As ConnectionManager
'    Public Sub New(ByVal serverName As String)
'        WasConnected = False
'        Try
'            If (Not ConnectionManager.DefaultInstance Is Nothing) Then
'                m_ConnectionManager = ConnectionManager.CreateNew(ConnectionManager.DefaultInstance.SQLServer, _
'                                                                       ConnectionManager.DefaultInstance.SQLDatabase, _
'                                                                       ConnectionManager.DefaultInstance.SQLUser, _
'                                                                       ConnectionManager.DefaultInstance.SQLPassword,
'                                                                       ConnectionManager.DefaultInstance.SQLConnectionString)

'            Else
'                m_ConnectionManager = ConnectionManager.CreateNew()
'            End If

'            WasConnected = TestConnection()
'        Catch exc As Exception
'            Dbg.Debug("UpdateMessenger constructor error: {0}", exc.Message)
'        End Try
'    End Sub
'    Private ReadOnly Property Connection() As IDbConnection
'        Get
'            Return m_ConnectionManager.Connection
'        End Get
'    End Property
'    Private Function TestConnection() As Boolean
'        Dim result As Boolean
'        result = False
'        Try
'            Connection.Open()
'            Connection.Close()
'            result = True
'        Catch exc As Exception
'            Dbg.Debug("UpdateMessenger Test connection error: {0} {1}", Connection.ConnectionString, exc.Message)
'        End Try
'        Return result
'    End Function

'    Private m_wasConnected As Boolean

'    Public Property WasConnected() As Boolean
'        Set(ByVal value As Boolean)
'            m_wasConnected = value
'        End Set
'        Get
'            Return m_wasConnected
'        End Get
'    End Property


'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="clientID"></param>
'    ''' <param name="application"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function CanRunApplication(ByVal clientID As String, ByVal application As String) As Boolean
'        Dim result As Boolean

'        result = True 'if we can't connect to EIDSS than we can run App anyway

'        If (WasConnected) Then
'            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_CanRunApplication", Connection)
'            BaseDbService.AddParam(cmd, "@ClientID", clientID)
'            BaseDbService.AddParam(cmd, "@Application", application)
'            BaseDbService.AddTypedParam(cmd, "@Result", SqlDbType.Bit, ParameterDirection.InputOutput)
'            Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)

'            If (errorMessage Is Nothing) Then
'                result = CType(BaseDbService.GetParamValue(cmd, "@Result"), Boolean)
'            Else
'                Dbg.Debug("UpdateMessenger CanRunApplication error: {0}", errorMessage.DetailError)
'                'result = False
'            End If
'        End If
'        Return result
'    End Function
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function CanUpdateBlock() As Boolean
'        Dim result As Boolean
'        If (WasConnected) Then
'            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_CanUpdateBlock", Connection)
'            BaseDbService.AddTypedParam(cmd, "@Result", SqlDbType.Bit, ParameterDirection.InputOutput)
'            Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)

'            If (errorMessage Is Nothing) Then
'                result = CType(BaseDbService.GetParamValue(cmd, "@Result"), Boolean)
'            Else
'                Dbg.Debug("UpdateMessenger CanUpdateBlock error: {0}", errorMessage.DetailError)
'                result = False
'            End If
'        End If
'        Return result
'    End Function
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="clientID"></param>
'    ''' <param name="application"></param>
'    ''' <remarks></remarks>
'    Public Sub CreateRunningApps(ByVal clientID As String, ByVal application As String)
'        If Not (WasConnected) Then Return
'        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_CreateRunningApps", Connection)
'        BaseDbService.AddParam(cmd, "@ClientID", clientID)
'        BaseDbService.AddParam(cmd, "@Application", application)
'        Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)
'        If Not (errorMessage Is Nothing) Then
'            Dbg.Debug("UpdateMessenger CreateRunningApps error: {0}", errorMessage.DetailError)
'        End If

'    End Sub
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="clientID"></param>
'    ''' <remarks></remarks>
'    Public Sub CreateUpdateBlock(ByVal clientID As String, ByVal application As String)
'        If Not (WasConnected) Then Return
'        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_CreateUpdateBlock", Connection)
'        BaseDbService.AddParam(cmd, "@ClientID", clientID)
'        BaseDbService.AddParam(cmd, "@Application", application)
'        Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)
'        If Not (errorMessage Is Nothing) Then
'            Dbg.Debug("UpdateMessenger CreateUpdateBlock error: {0}", errorMessage.DetailError)
'        End If
'    End Sub
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="clientID"></param>
'    ''' <param name="application"></param>
'    ''' <remarks></remarks>
'    Public Sub DeleteRunningApps(ByVal clientID As String, ByVal application As String)
'        If Not (WasConnected) Then Return
'        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_DeleteRunningApps", Connection)
'        BaseDbService.AddParam(cmd, "@ClientID", clientID)
'        BaseDbService.AddParam(cmd, "@Application", application)
'        Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)
'        If Not (errorMessage Is Nothing) Then
'            Dbg.Debug("UpdateMessenger DeleteRunningApps error: {0}", errorMessage.DetailError)
'        End If
'    End Sub
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Sub DeleteUpdateBlock()
'        If Not (WasConnected) Then Return
'        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEIDSSUpdate_DeleteUpdateBlock", Connection)
'        Dim errorMessage As ErrorMessage = BaseDbService.ExecCommand(cmd, Connection)
'        If Not (errorMessage Is Nothing) Then
'            Dbg.Debug("UpdateMessenger DeleteUpdateBlock error: {0}", errorMessage.DetailError)
'        End If
'    End Sub

'End Class
