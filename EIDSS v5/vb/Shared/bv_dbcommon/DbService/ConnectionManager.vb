Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports bv.common.Configuration
Imports bv.common.Diagnostics
Imports System.Text.RegularExpressions
Imports bv.common.Objects.DBService
Imports bv.common.Core
Imports bv.model.Model.Core

Namespace Core

    Public Class ConnectionManager
        Inherits ConnectionCredentials
        Private Shared ReadOnly m_SConnectionSlots As ArrayList = New ArrayList()
        Private Shared ReadOnly m_SConnections As List(Of ConnectionManager) = New List(Of ConnectionManager)

        Protected m_Connection As SqlConnection = Nothing
        Protected m_AsyncConnection As SqlConnection = Nothing

        Protected Sub New(Optional ByVal configFileName As String = Nothing)
            MyBase.New(configFileName)
        End Sub

        'Protected Sub New _
        '    ( _
        '        ByVal server As String, _
        '        ByVal database As String, _
        '        Optional ByVal user As String = Nothing, _
        '        Optional ByVal password As String = Nothing, _
        '        Optional ByVal connectionString As String = Nothing _
        '    )
        '    MyBase.New(server, database, user, password, connectionString)
        'End Sub

        Public Shared Function Create() As ConnectionManager
            Return (DefaultInstance)
        End Function

        Public Shared Function Create(ByVal configFileName As String) As ConnectionManager
            Dim manager As New ConnectionManager(configFileName)
            Dim found As ConnectionManager = Nothing
            For Each entry As ConnectionManager In m_SConnectionSlots
                If (entry.CompareTo(manager) = 0) Then
                    found = entry
                    Exit For
                End If
            Next
            If (found Is Nothing) Then
                m_SConnectionSlots.Add(manager)
                m_SConnections.Add(manager)
            Else
                manager = found
            End If
            Return (manager)
        End Function

        Public Shared Function Create _
            ( _
                ByVal server As String, _
                ByVal database As String, _
                Optional ByVal user As String = Nothing, _
                Optional ByVal password As String = Nothing, _
                Optional ByVal connectionString As String = Nothing _
            ) As ConnectionManager
            Dim manager As ConnectionManager = New ConnectionManager()
            Dim found As ConnectionManager = Nothing
            manager.SetCredentials(connectionString, server, database, user, password)
            For Each entry As ConnectionManager In m_SConnectionSlots
                If (entry.CompareTo(manager) = 0) Then
                    found = entry
                    Exit For
                End If
            Next
            If (found Is Nothing) Then
                m_SConnectionSlots.Add(manager)
                m_SConnections.Add(manager)
            Else
                manager = found
            End If
            Return (manager)
        End Function

        Public Shared Function CreateNew() As ConnectionManager
            Dim manager As ConnectionManager = New ConnectionManager()
            m_SConnections.Add(manager)
            Return (manager)
        End Function

        Public Shared Function CreateNew(ByVal useAsyncConnection As Boolean) As ConnectionManager
            Dim manager As ConnectionManager = New ConnectionManager()
            m_SConnections.Add(manager)
            manager.UseAsyncConnection = useAsyncConnection
            Return (manager)
        End Function

        Public Shared Function CreateNew _
            ( _
                ByVal server As String, _
                ByVal database As String, _
                Optional ByVal user As String = Nothing, _
                Optional ByVal password As String = Nothing, _
                Optional ByVal connectionString As String = Nothing _
            ) As ConnectionManager
            Dim manager As ConnectionManager = New ConnectionManager()
            manager.SetCredentials(connectionString, server, database, user, password)
            m_SConnections.Add(manager)
            Return (manager)
        End Function

        Public Overrides Property UseAsyncConnection() As Boolean
            Get
                Return MyBase.UseAsyncConnection
            End Get
            Set(ByVal value As Boolean)
                If value <> MyBase.UseAsyncConnection Then
                    MyBase.UseAsyncConnection = value
                    CloseConnection()
                    m_ConnectionStringFinal = Nothing
                    Connection.ConnectionString = CreateConnectionString()
                End If
            End Set
        End Property

        Public Shared Property DefaultInstance() As ConnectionManager
            Get
                Dim anvil As ConnectionManager
                If m_SConnectionSlots.Count = 0 Then
                    anvil = New ConnectionManager()
                    'anvil.Owner = "Default"
                    m_SConnectionSlots.Add(anvil)
                    m_SConnections.Add(anvil)
                End If
                anvil = CType(m_SConnectionSlots.Item(0), ConnectionManager)
                Return anvil
            End Get
            Set(ByVal value As ConnectionManager)
                m_SConnectionSlots.Insert(0, value)
                m_SConnections.Insert(0, value)
            End Set
        End Property

        Public ReadOnly Property Connection() As IDbConnection
            Get
                'Dim id As Integer = Threading.Thread.CurrentThread.ManagedThreadId
                'Debug.Assert(id = 1)
                If (m_Connection Is Nothing) Then
                    m_Connection = New SqlConnection(ConnectionString)
                    AddHandler m_Connection.StateChange, AddressOf OnStateChange
                    AttachInfoMessageHandler(m_Connection)
                End If
                Return (m_Connection)
            End Get
        End Property

        Public Sub OpenConnection()
            If (Connection.State <> ConnectionState.Open) Then
                Connection.Open()
            End If
        End Sub

        Public Sub CloseConnection()
            If ((Not (m_Connection Is Nothing)) AndAlso (Connection.State <> ConnectionState.Closed)) Then
                Connection.Close()
            End If
        End Sub

        Public Sub ClearPool()
            CloseConnection()
            If Not m_Connection Is Nothing Then
                SqlConnection.ClearPool(m_Connection)
            End If

        End Sub

        Public Sub ReleaseConnection()
            CloseConnection()
            If Not m_Connection Is Nothing Then
                SyncLock m_Connection
                    Dbg.Debug("disposing connection {0}", m_Connection.GetHashCode)
                    m_Connection.Dispose()
                End SyncLock
                m_Connection = Nothing
            End If
        End Sub
        Public Shared Sub CloseAllConnections()
            For Each manager As ConnectionManager In m_SConnections
                manager.CloseConnection()
            Next
        End Sub

        Public Shared Sub ReleaseAllConnections()
            While m_SConnections.Count > 0
                m_SConnections(0).ReleaseConnection()
                m_SConnections.RemoveAt(0)
            End While
            While m_SConnectionSlots.Count > 0
                m_SConnectionSlots.RemoveAt(0)
            End While
        End Sub

        Private Shared m_OpenConnectionsCount As Integer = 0


        Private m_UseContext As Boolean = True

        Public Property UseContext() As Boolean
            Get
                Return m_UseContext
            End Get
            Set(ByVal value As Boolean)
                m_UseContext = value
            End Set
        End Property

        Protected Sub OnStateChange(ByVal sender As Object, ByVal args As StateChangeEventArgs)
            If ((args.CurrentState = ConnectionState.Open) And UseContext) Then
                Dim command As IDbCommand = BaseDbService.CreateSPCommand("spSetContext", CType(sender, IDbConnection))
                BaseDbService.AddParam(command, "@ContextString", ModelUserContext.ClientID)
                BaseDbService.ExecCommand(command, CType(sender, IDbConnection))
                Threading.Interlocked.Increment(m_OpenConnectionsCount)
                'Debug.Assert(m_OpenConnectionsCount <= 1 And m_OpenConnectionsCount >= 0)
                Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "connection is opened. {0} connections is currently open", m_OpenConnectionsCount)
            ElseIf args.CurrentState = ConnectionState.Closed Then
                Threading.Interlocked.Decrement(m_OpenConnectionsCount)
                Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "connection is closed. {0} connections is currently open", m_OpenConnectionsCount)
            Else
                Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "connection is state is changed. Current connection state is {0}", args.CurrentState.ToString)
            End If
        End Sub
        Private Shared Sub AttachInfoMessageHandler(ByVal cn As IDbConnection)
            AddHandler CType(cn, SqlConnection).InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
        End Sub

        Private Shared Sub OnInfoMessage(ByVal sender As Object, ByVal args As SqlInfoMessageEventArgs)
            Dim err As SqlError
            For Each err In args.Errors
                Dim errorLevel As Integer
                If CInt(err.Class) <= 10 Then
                    errorLevel = DebugDetalizationLevel.EventDebug
                ElseIf CInt(err.Class) < 17 Then 'user defined errors
                    errorLevel = DebugDetalizationLevel.Low
                Else
                    errorLevel = 0
                End If
                Dbg.ConditionalDebug(errorLevel, "The {0} has received a severity {1}, state {2} error number {3}" & vbCrLf & _
                                  "on line {4} of procedure {5} on server {6}:" & vbCrLf & "{7}", _
                                  err.Source, err.Class.ToString, err.State.ToString, err.Number.ToString, err.LineNumber.ToString, _
                                  err.Procedure, err.Server, err.Message)
                If err.Class = 16 Then
                    Throw New StoredProcException(err.Message)
                End If
            Next
        End Sub
        Public Overrides Sub SetCredentials(Optional ByVal aConnectionString As String = Nothing, Optional ByVal server As String = Nothing, Optional ByVal database As String = Nothing, Optional ByVal user As String = Nothing, Optional ByVal password As String = Nothing, Optional prefix As String = "SQL")
            MyBase.SetCredentials(aConnectionString, server, database, user, password, prefix)
            ReleaseConnection()
        End Sub

        Public Enum ConnectionStringPart
            Provider
            DataSource
            Database
            Password
            UserID
            MARS
            Async
            IntegratedSecurity
            ConnectionTimeOut
        End Enum


        Public Class ConnectionStringParser
            Private m_ConnectionString As String
            Public Sub New(ByVal aConnectionString As String)
                m_ConnectionString = aConnectionString
            End Sub
            Public Property ConnectionString() As String
                Get
                    Return m_ConnectionString
                End Get
                Set(ByVal value As String)
                    m_ConnectionString = value
                End Set
            End Property
            Private Structure ConnectionStringItem
                Public Property Name As String
                Public Property Mask As String
                Public Sub New(ByVal aName As String, ByVal aMask As String)
                    Name = aName
                    Mask = aMask
                End Sub
            End Structure
            Private Shared ReadOnly m_Parts As New Dictionary(Of ConnectionStringPart, ConnectionStringItem)
            Private Shared m_Initiated As Boolean
            Private Shared Sub Init()
                If m_Initiated Then
                    Return
                End If
                m_Initiated = True
                m_Parts.Add(ConnectionStringPart.Async, New ConnectionStringItem("Asynchronous Processing", "Asynchronous\sProcessing|async"))
                m_Parts.Add(ConnectionStringPart.DataSource, New ConnectionStringItem("Data Source", "Data\sSource"))
                m_Parts.Add(ConnectionStringPart.Database, New ConnectionStringItem("Initial Catalog", "Initial\sCatalog"))
                m_Parts.Add(ConnectionStringPart.MARS, New ConnectionStringItem("MultipleActiveResultSets", "MultipleActiveResultSets"))
                m_Parts.Add(ConnectionStringPart.Password, New ConnectionStringItem("Password", "Password|pwd"))
                m_Parts.Add(ConnectionStringPart.Provider, New ConnectionStringItem("Provider", "Provider"))
                m_Parts.Add(ConnectionStringPart.UserID, New ConnectionStringItem("Initial Catalog", "Initial\sCatalog"))
                m_Parts.Add(ConnectionStringPart.IntegratedSecurity, New ConnectionStringItem("Integrated Security", "Integrated\sSecurity"))
                m_Parts.Add(ConnectionStringPart.ConnectionTimeOut, New ConnectionStringItem("Connection TimeOut", "Connection\sTimeOut"))
            End Sub

            Private Const RegExpTemplate As String = "(?:({0})[\s]*=[\s]*""??(?<{1}>[^;\n]+)""??[;\n""]??)"
            Public Property Item(ByVal index As ConnectionStringPart) As String
                Get
                    Init()
                    If Utils.IsEmpty(m_ConnectionString) Then
                        Return ""
                    End If
                    Dim rExp As Regex = GetRegEx(index)
                    Dim m As Match = rExp.Match(m_ConnectionString)
                    If m.Success Then
                        Return m.Value
                    Else
                        Return ""
                    End If
                End Get
                Set(ByVal value As String)
                    Init()
                    If Utils.IsEmpty(m_ConnectionString) Then
                        Return
                    End If
                    Dim rExp As Regex = GetRegEx(index)
                    Dim m As Match = rExp.Match(m_ConnectionString)
                    If m.Success Then
                        m_ConnectionString = rExp.Replace(m_ConnectionString, String.Format("{0}={1}", m_Parts(index).Name, value))
                    Else
                        If Not m_ConnectionString.Trim().EndsWith(";") Then
                            m_ConnectionString += ";"
                        End If
                        m_ConnectionString += String.Format("{0}={1};", m_Parts(index).Name, value)
                    End If
                End Set
            End Property
            Private Function GetRegEx(ByVal index As ConnectionStringPart) As Regex
                Return New Regex(String.Format(RegExpTemplate, m_Parts(index).Mask, index.ToString))
            End Function

        End Class
    End Class
End Namespace