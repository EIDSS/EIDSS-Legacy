Imports bv.common.Objects
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading
Imports bv.common.Core
Imports bv.model.Model.Core
Imports eidss.model.Enums

Namespace Core
    Public Class LookupCache
        Private Shared m_Dataset As New DataSet
        Private Shared s_Connection As SqlConnection
        Private Shared m_AsyncConnectionManager As ConnectionManager
        Private Const stFilling As String = "Filling"
        Private Const CONNECTIONS_COUNT As Integer = 1
        Private Shared IDLE_TIMER_INTERVAL As Integer = 500
        Private Shared TIMER_INTERVAL As Integer = 500
        Private Shared m_ReferenceTables As Dictionary(Of String, String)
        Private Shared m_AsyncQueue As New Queue(Of LookupTableInfo)
        Private Shared m_ReferenceChangedRequests As New Dictionary(Of String, DateTime)
        Private Shared m_queueTimer As Threading.Timer
        Private Shared m_Initialized As Boolean
        Private Shared m_SyncObject As New Object
        Private Shared m_SyncDataObject As New Object
        Public Shared EmptyLineKey As Long = -101L

        Private Shared ReadOnly Property AsyncConnection() As SqlConnection
            Get
                If s_Connection Is Nothing Then
                    If (Not ConnectionManager.DefaultInstance Is Nothing) Then
                        m_AsyncConnectionManager = ConnectionManager.CreateNew(ConnectionManager.DefaultInstance.SQLServer, _
                                                                               ConnectionManager.DefaultInstance.SQLDatabase, _
                                                                               ConnectionManager.DefaultInstance.SQLUser, _
                                                                               ConnectionManager.DefaultInstance.SQLPassword,
                                                                               ConnectionManager.DefaultInstance.SQLConnectionString)
                        m_AsyncConnectionManager.UseAsyncConnection = True

                    Else
                        m_AsyncConnectionManager = ConnectionManager.CreateNew(True)
                    End If
                    'm_AsyncConnectionManager.Owner = "Lookup cache"
                    s_Connection = CType(m_AsyncConnectionManager.Connection, SqlConnection)
                End If
                    Return s_Connection
            End Get
        End Property
        'Private Shared m_UseSingleConnection As Boolean = True
        'Public Shared Property UseSingleConnection() As Boolean
        '    Get
        '        Return m_UseSingleConnection
        '    End Get
        '    Set(ByVal value As Boolean)
        '        m_UseSingleConnection = value
        '    End Set
        'End Property

        Private Shared m_WebClientMode As Boolean = False

        Public Shared Property WebClientMode() As Boolean
            Get
                Return m_WebClientMode
            End Get
            Set(ByVal Value As Boolean)
                m_WebClientMode = Value
            End Set
        End Property
        Private Shared Sub CheckTableSqlName(ByVal table As LookupTableInfo)
            If Not IsBaseReference(table.Name) Then
                Return
            End If
            If table.SqlName Is Nothing OrElse table.SqlName = table.Name Then
                table.SqlName = GetBaseReferenceName(table) 'm_ReferenceTables(GetBaseReferenceName(table))
            End If
        End Sub

        Public Shared Sub Init(Optional ByVal forceRefill As Boolean = True, Optional ByVal UseCacheListener As Boolean = True)
            Try
                If m_Initialized Then Return
                Dbg.Debug("lookup cache initialization is started for language '{0}'", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                IDLE_TIMER_INTERVAL = bv.common.Configuration.BaseSettings.LookupCacheIdleRefreshInterval
                TIMER_INTERVAL = bv.common.Configuration.BaseSettings.LookupCacheRefreshInterval

                For Each table As LookupTableInfo In m_LookupTables.Values
                    'If table.FillAsync Then
                    CreateParameters(table)
                    'End If
                Next

                If UseCacheListener AndAlso WebClientMode = False Then
                    LookupCacheListener.CleanUp()
                    LookupCacheListener.Listen()
                End If
                m_Language = bv.model.Model.Core.ModelUserContext.CurrentLanguage
                If Not WebClientMode Then
                    m_queueTimer = New Threading.Timer(AddressOf QueueWorkerProc, Nothing, 0, Timeout.Infinite)
                    For Each table As LookupTableInfo In m_LookupTables.Values
                        If table.FillAsync Then
                            FillAsync(table, forceRefill)
                        End If
                    Next
                End If
                m_Initialized = True
            Catch ex As Exception
                Dbg.Debug("error during lookup cache initialization:{0}", ex.Message)
            End Try
        End Sub
        Private Shared m_Language As String
        Public Shared ReadOnly Property Language() As String
            Get
                Return m_Language
            End Get
        End Property

        Public Shared Sub DeInit()
            Try
                LookupCacheListener.Stop()
                LookupCacheListener.CleanUp()
            Catch ex As Exception
                Dbg.Debug("error during lookup cache deinit: {0}", ex)
            End Try
            'DbDisposeHelper.DisposeDataset(m_Dataset)
        End Sub
        Private Shared m_Reloading As Integer
        Private Const TIME_OUT As Integer = 100
        Public Shared Sub Reload()
            Interlocked.Exchange(m_Reloading, 1)
            Dbg.Debug("**********************")
            Dbg.Debug("reloading lookup cache")
            Dbg.Debug("**********************")
            If WebClientMode = False Then
                LookupCacheListener.Stop()
            End If
            SyncLock m_AsyncQueue
                Dbg.Debug("{0} lookup tables are currently in queue for loading", m_AsyncQueue.Count)
                m_AsyncQueue.Clear()
                Dbg.Debug("lookup tables queue is cleared")
            End SyncLock
            Dim time As DateTime = DateTime.Now
            While Not Interlocked.Equals(s_ExecutingCount, 0)
                Dbg.Debug("waiting pending asynchronous lookup table fill: {0} tables are in the filling process", s_ExecutingCount)
                Thread.Sleep(500)
                If DateTime.Now.Subtract(time).TotalSeconds > TIME_OUT Then
                    Dbg.Debug("break pending asynchronous lookup table fill by timeout")
                    Interlocked.Exchange(s_ExecutingCount, 0)
                End If
            End While
            If Not m_queueTimer Is Nothing Then
                m_queueTimer.Change(Timeout.Infinite, Timeout.Infinite)
            End If
            SyncLock m_SyncDataObject
                Dbg.Debug("clearing lookup tables dataset")
                m_Dataset.Clear()
                m_Dataset.Tables.Clear()
                Dbg.Debug("lookup tables dataset is cleared")
            End SyncLock
            m_Initialized = False
            Interlocked.Exchange(m_Reloading, 0)
            Init()
        End Sub

        Public Shared Sub Clear()
            SyncLock m_SyncDataObject
                LookupTables.Clear()
                m_Dataset.Tables.Clear()
            End SyncLock
        End Sub
        Private Shared m_LookupTables As New Dictionary(Of String, LookupTableInfo)
        Public Shared Property LookupTables() As Dictionary(Of String, LookupTableInfo)
            Get
                Return m_LookupTables
            End Get
            Set(ByVal value As Dictionary(Of String, LookupTableInfo))
                Dbg.Assert(m_Initialized, "Lookup tables lict can be set when LookupCash is not initialized")
                SyncLock m_LookupTables
                    m_LookupTables = value
                End SyncLock
            End Set
        End Property
        Private Shared Sub InitLookupTables()
            If m_LookupTables Is Nothing Then
                SyncLock m_LookupTables
                    If m_LookupTables Is Nothing Then
                        m_LookupTables = New Dictionary(Of String, LookupTableInfo)
                    End If
                End SyncLock
            End If
        End Sub
        Private Shared Function GetLookupTableInfo(ByRef tableID As String, Optional ByVal HACode As Integer = 0, Optional ByVal AddAbsentTable As Boolean = True) As LookupTableInfo
            SyncLock m_LookupTables
                Dim key As String = tableID
                If HACode > 0 Then
                    key += CInt(HACode).ToString()
                End If

                If m_LookupTables.ContainsKey(key) Then
                    Return m_LookupTables(key)
                ElseIf AddAbsentTable Then
                    Dim lookupTable As New LookupTableInfo(key, , tableID, LookupTableInfo.GetDefaultProcedureName(tableID))
                    If HACode > 0 Then
                        lookupTable.HACode = CInt(HACode)
                        tableID = key
                    End If
                    m_LookupTables.Add(key, lookupTable)
                    Return lookupTable
                End If
            End SyncLock
            Return Nothing
        End Function
        Private Shared Function GetLookupTableInfo(ByVal table As LookupTableInfo) As LookupTableInfo
            SyncLock m_LookupTables
                If m_LookupTables.ContainsKey(table.Name) Then
                    Return m_LookupTables(table.Name)
                Else
                    m_LookupTables.Add(table.Name, table)
                    Return table
                End If
            End SyncLock
        End Function

        Private Shared Function GetTableHashCode(ByVal table As LookupTableInfo) As String
            'TODO: add static view filters as part of code
            Dim filters As String = ""
            For Each key As String In table.StaticFilters.Keys
                filters += String.Format("{0}={1};", key, Utils.Str(table.StaticFilters(key)))
            Next
            Return String.Format("{0}{1}{2}", table.Name, bv.model.Model.Core.ModelUserContext.CurrentLanguage, filters)
        End Function
        Public Shared Function [Get](ByVal tableID As [Enum]) As DataView
            Return [Get](tableID.ToString)
        End Function
        Public Shared Function [Get](ByVal tableID As [Enum], ByVal HACode As Integer) As DataView
            Return [Get](tableID.ToString, HACode, Nothing)
        End Function
        Public Shared Function [Get](ByVal tableID As [Enum], ByVal HACode As Integer, ByVal params As Dictionary(Of String, Object)) As DataView
            Return [Get](tableID.ToString, HACode, params)
        End Function
        Public Shared Function [Get](ByVal tableID As String) As DataView
            Return [Get](tableID, 0, Nothing)
        End Function
        Public Shared Function [Get](ByVal tableID As String, ByVal HACode As Integer) As DataView
            Return [Get](tableID, HACode, Nothing)
        End Function

        Private Shared Function CopyDictionary(ByVal params As Dictionary(Of String, Object)) As Dictionary(Of String, Object)
            If params Is Nothing Then
                Return Nothing
            End If
            Dim paramsCopy As New Dictionary(Of String, Object)
            For Each key As String In params.Keys
                paramsCopy(key) = params(key)
            Next
            Return paramsCopy
        End Function


        Public Shared Function [Get](ByVal tableID As String, ByVal HACode As Integer, ByVal params As Dictionary(Of String, Object)) As DataView
            InitLookupTables()
            Dim lookupTable As LookupTableInfo = GetLookupTableInfo(tableID, HACode)
            Dim forceRefill As Boolean = False
            If params IsNot Nothing Then
                If lookupTable.Parameters IsNot Nothing Then
                    If lookupTable.Parameters.Count <> params.Count Then
                        forceRefill = True
                        lookupTable.Parameters = CopyDictionary(params)
                    Else
                        For Each key As String In lookupTable.Parameters.Keys
                            If Not params.ContainsKey(key) OrElse Not lookupTable.Parameters(key).Equals(params(key)) Then
                                forceRefill = True
                                lookupTable.Parameters = CopyDictionary(params)
                                Exit For
                            End If
                        Next
                    End If
                Else
                    forceRefill = True
                    lookupTable.Parameters = CopyDictionary(params)
                End If
            End If
            Dim dt As DataTable = LookupCache.Fill(lookupTable, forceRefill, Nothing)
            If Not dt Is Nothing Then
                SyncLock m_SyncDataObject
                    Return New LookupCacheDataView(dt)
                End SyncLock
            Else
                Dbg.Debug("lookup table {0} is not filled", tableID)
                Return Nothing
            End If
        End Function
        Public Shared Function [Get](ByVal table As LookupTableInfo) As DataView
            Dbg.Assert(table IsNot Nothing, "LookupTableID property of lookup table is not defined")
            Dbg.Assert(Utils.Str(table.Name) <> "", "LookupTableID property of lookup table is not defined")
            InitLookupTables()
            table = GetLookupTableInfo(table)
            Dim dt As DataTable = LookupCache.Fill(table)
            If Not dt Is Nothing Then
                SyncLock m_SyncDataObject
                    Return New LookupCacheDataView(dt)
                End SyncLock
            Else
                Dbg.Debug("lookup table {0} is not filled", table.Name)
                Return Nothing
            End If
        End Function

        Public Shared Sub Refresh(ByVal table As LookupTableInfo)
            FillAsync(table, True)
        End Sub
        Public Shared Sub Refresh(ByVal SqlTableName As String, Optional ByVal aFillAsync As Boolean = True, Optional ByVal transaction As IDbTransaction = Nothing, Optional ByVal ID As Object = Nothing)
            InitLookupTables()

            bv.model.BLToolkit.LookupManager.ClearByTable(SqlTableName)

            Dim lookupTablesCopy As New List(Of LookupTableInfo)
            SyncLock m_LookupTables
                For Each table As LookupTableInfo In m_LookupTables.Values
                    If table.SqlName = SqlTableName Then
                        lookupTablesCopy.Add(table)
                    End If
                Next
            End SyncLock
            For Each table As LookupTableInfo In lookupTablesCopy
                table.RefreshObjectID = ID
                If aFillAsync Then
                    FillAsync(table, True, transaction)
                Else
                    Fill(table, True, transaction)
                End If
                table.RefreshObjectID = Nothing
                If Not table.RelatedSqlTables Is Nothing AndAlso table.RelatedSqlTables.Contains(SqlTableName) Then
                    SyncLock m_ReferenceChangedRequests
                        m_ReferenceChangedRequests(SqlTableName) = DateTime.Now()
                    End SyncLock
                End If
            Next
        End Sub
        Public Shared Sub Refresh(ByVal LookupTableID As [Enum], Optional ByVal aFillAsync As Boolean = True, Optional ByVal transaction As IDbTransaction = Nothing)
            InitLookupTables()
            Dim lookupTable As LookupTableInfo = GetLookupTableInfo(LookupTableID.ToString, 0, False)

            If lookupTable IsNot Nothing Then
                If aFillAsync Then
                    FillAsync(lookupTable, True, transaction)
                Else
                    Fill(lookupTable, True, transaction)
                End If
            End If
        End Sub
        Public Shared Sub Refresh(ByVal LookupTableID As [Enum], ByVal HACode As Integer, Optional ByVal aFillAsync As Boolean = True, Optional ByVal transaction As IDbTransaction = Nothing)
            InitLookupTables()
            Dim tableID As String = LookupTableID.ToString
            Dim lookupTable As LookupTableInfo = GetLookupTableInfo(tableID, HACode, False)

            If lookupTable IsNot Nothing Then
                If aFillAsync Then
                    FillAsync(lookupTable, True, transaction)
                Else
                    Fill(lookupTable, True, transaction)
                End If
            End If
        End Sub
        Private Shared Function GetLookupTable(ByVal tableName As String) As DataTable
            SyncLock m_Dataset
                If m_Dataset.Tables.Contains(tableName) Then
                    Return m_Dataset.Tables(tableName)
                Else
                    Return Nothing
                End If
            End SyncLock
        End Function

        Public Shared Function Fill(ByVal table As LookupTableInfo, Optional ByVal ForceRefill As Boolean = False, Optional ByVal transaction As IDbTransaction = Nothing) As DataTable
            Dim hashCode As String = GetTableHashCode(table)
            Dim t As DataTable = Nothing
            If ForceRefill = False AndAlso m_WebClientMode = False Then
                t = GetLookupTable(hashCode)
                If Not t Is Nothing AndAlso t.Rows.Count > 0 Then
                    Return t
                End If
            End If
            SyncLock m_AsyncQueue
                If m_AsyncQueue.Contains(table) Then
                    RemoveFromQueue(table)
                End If
            End SyncLock
            Try
                CheckTableSqlName(table)
                If IsBaseReference(table.Name) Then
                    FillBaseReferenceLookup(table, hashCode, , transaction)
                Else
                    FillLookupTable(table, hashCode, , transaction)
                End If
                t = GetLookupTable(hashCode)
                Dbg.Assert(Not t Is Nothing, "lookuptable {0} is not filled", table.Name)

            Catch ex As Exception
                If Not table Is Nothing Then
                    Dbg.Debug("error during lookup cache refreshing for table {0} :{1}", Utils.Str(table.Name), ex.ToString)
                Else
                    Dbg.Debug("error during lookup cache refreshing for unknown table :{0}", ex.ToString)
                End If

            End Try
            Return t
        End Function

        Private Shared Sub CreateParameters(ByVal table As LookupTableInfo)
            'retrieve parameters for stored procedure in the main thread
            If Not StoredProcParamsCache.Contains(table.ProcedureName) Then
                Dim cmd As IDbCommand = BaseDbService.CreateSPCommand(table.ProcedureName, ConnectionManager.DefaultInstance.Connection)
                StoredProcParamsCache.CreateParameters(cmd)
            End If
        End Sub


        Public Shared Sub FillAsync(ByVal table As LookupTableInfo, Optional ByVal ForceRefill As Boolean = False, Optional ByVal transaction As IDbTransaction = Nothing)
            Dim hashCode As String = GetTableHashCode(table)
            If ForceRefill = False AndAlso GetLookupTable(hashCode) IsNot Nothing Then
                Return
            End If
            CheckTableSqlName(table)
            SyncLock m_AsyncQueue
                If m_AsyncQueue.Contains(table) Then
                    Exit Sub
                End If
            End SyncLock
            If Not StoredProcParamsCache.Contains(table.ProcedureName) Then
                Dbg.Assert(False, "stored procedure cache does not contain {0}", table.ProcedureName)
            End If
            SyncLock m_AsyncQueue
                m_AsyncQueue.Enqueue(table)
            End SyncLock
        End Sub

        Private Shared ReadOnly Property IsBaseReference(ByVal tableName As String) As Boolean
            Get
                Return tableName.StartsWith("rft")
            End Get
        End Property

        Private Shared Function GetBaseReferenceName(ByVal table As LookupTableInfo) As String
            If table.HACode > 0 AndAlso table.Name.EndsWith(table.HACode.ToString) Then
                Return table.Name.Substring(0, table.Name.Length - table.HACode.ToString.Length)
            Else
                Return table.Name
            End If
        End Function
        Private Shared Function GetBaseReferenceCode(ByVal table As LookupTableInfo) As Long
            Dim tableName As String = GetBaseReferenceName(table)
            Return CType([Enum].Parse(GetType(BaseReferenceType), tableName), BaseReferenceType)
        End Function
        Private Shared Sub FillBaseReferenceLookup(ByVal table As LookupTableInfo, ByVal tableHashCode As String, Optional ByVal FillAsync As Boolean = False, Optional ByVal transaction As IDbTransaction = Nothing)
            DebugTimer.Start(String.Format("{0} base lookup fill", table.Name))
            Try
                Dim tableType As Long = GetBaseReferenceCode(table)

                Dim conn As IDbConnection = Nothing
                If FillAsync AndAlso Not m_WebClientMode Then
                    conn = AsyncConnection
                Else
                    conn = ConnectionManager.DefaultInstance.Connection
                End If

                Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spReference_SelectLookup", conn, transaction)
                StoredProcParamsCache.CreateParameters(cmd)
                'BaseDbService.SetParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
                BaseDbService.SetParam(cmd, "@type", tableType)
                BaseDbService.SetParam(cmd, "@HACode", table.HACode)
                If Not table.RefreshObjectID Is Nothing Then
                    BaseDbService.SetParam(cmd, "@id", table.RefreshObjectID)
                End If
                If FillAsync AndAlso Not m_WebClientMode Then
                    ExecuteCommandAsync(CType(cmd, SqlCommand), tableHashCode, table.AddEmptyString, table.PrimaryKey)
                Else
                    ExecuteCommand(cmd, tableHashCode, table.AddEmptyString, table.RefreshObjectID, table.PrimaryKey)
                End If
            Catch ex As Exception
                Throw
            Finally
                DebugTimer.Stop()
            End Try
        End Sub
        Private Shared Function FillLookupTable(ByVal table As LookupTableInfo, ByVal tableHashCode As String, Optional ByVal FillAsync As Boolean = False, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
            DebugTimer.Start(String.Format("{0} lookup filling", tableHashCode))
            Try
                Dim conn As IDbConnection = Nothing
                If FillAsync AndAlso Not m_WebClientMode Then
                    conn = AsyncConnection
                Else
                    conn = ConnectionManager.DefaultInstance.Connection
                End If

                Dim cmd As IDbCommand = BaseDbService.CreateSPCommand(table.ProcedureName, conn, transaction)
                StoredProcParamsCache.CreateParameters(cmd)
                If cmd.Parameters.Contains("@languageid") = True Then
                    CType(cmd.Parameters("@languageid"), IDbDataParameter).Value = bv.model.Model.Core.ModelUserContext.CurrentLanguage
                End If
                If cmd.Parameters.Contains("@LangID") = True Then
                    CType(cmd.Parameters("@LangID"), IDbDataParameter).Value = bv.model.Model.Core.ModelUserContext.CurrentLanguage
                End If
                If table.HACode > 0 AndAlso cmd.Parameters.Contains("@HACode") Then
                    CType(cmd.Parameters("@HACode"), IDbDataParameter).Value = table.HACode
                End If
                If table.HACode > 0 AndAlso cmd.Parameters.Contains("@intHACode") Then
                    CType(cmd.Parameters("@intHACode"), IDbDataParameter).Value = table.HACode
                End If
                If Not table.RefreshObjectID Is Nothing AndAlso cmd.Parameters.Contains("@id") Then
                    CType(cmd.Parameters("@id"), IDbDataParameter).Value = table.RefreshObjectID
                End If
                For Each key As String In table.Parameters.Keys
                    Dbg.Assert(cmd.Parameters.Contains(key), "procedure <{0}> doesn't contain parameter <{1}>", table.ProcedureName, key)
                    Dim val As Object = table.Parameters(key)
                    If Not val Is Nothing AndAlso Not val Is DBNull.Value Then
                        CType(cmd.Parameters(key), IDbDataParameter).Value = val
                    End If
                Next
                If FillAsync AndAlso Not m_WebClientMode Then
                    ExecuteCommandAsync(CType(cmd, SqlCommand), tableHashCode, table.AddEmptyString, table.PrimaryKey)
                Else
                    ExecuteCommand(cmd, tableHashCode, table.AddEmptyString, table.RefreshObjectID, table.PrimaryKey)
                End If
            Catch ex As Exception
                Throw
            Finally
                DebugTimer.Stop()
            End Try
            Return True
        End Function

        Private Shared Sub FinalizeTableFilling(ByVal dt As DataTable, ByVal AddEmptyString As Boolean)
            If dt Is Nothing Then
                Return
            End If
            If (dt.PrimaryKey Is Nothing) OrElse (dt.PrimaryKey.Length = 0) Then
                'For i As Integer = 0 To dt.Columns.Count - 1
                '    If dt.Columns(i).AllowDBNull = False Then
                '        dt.PrimaryKey = New DataColumn() {dt.Columns(i)}
                '        Dbg.ConditionalDebug(DebugDetalizationLevel.High, "primary key for lookup table {0} is set to column {1}-{2}", dt.TableName, i, dt.Columns(i).ColumnName)
                '        Exit For
                '    End If
                'Next
                'If (dt.PrimaryKey Is Nothing) OrElse (dt.PrimaryKey.Length = 0) Then
                dt.PrimaryKey = New DataColumn() {dt.Columns(0)}
                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "primary key for lookup table {0} is set first to column {1}", dt.TableName, dt.Columns(0).ColumnName)
                'End If
            Else
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "primary key for lookup table {0} is set during filling to column {1}", dt.TableName, dt.PrimaryKey(0).ColumnName)
            End If

            If (AddEmptyString) Then
                InsertEmptyLine(dt)
            End If

        End Sub
        Public Shared Sub InsertEmptyLine(dt As DataTable)
            If Not dt.PrimaryKey.Length > 0 AndAlso dt.Rows.Find(EmptyLineKey) Is Nothing Then
                Return
            End If
            If dt.PrimaryKey.Length = 0 AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0)(0).Equals(EmptyLineKey) Then
                Return
            End If
            Dim r As DataRow = dt.NewRow
            For Each key As DataColumn In dt.Columns 'dt.PrimaryKey
                If key.ColumnName = "intRowStatus" Then
                    r(key) = 0
                Else
                    If key.AllowDBNull = False Then
                        Select Case key.DataType.Name
                            Case "String"
                                r(key) = EmptyLineKey.ToString()
                                'Case "Guid"
                                '    r(key) = Guid.NewGuid
                            Case "Int32", "Int16", "Int64", "Decimal", "Double", "Single"
                                r(key) = EmptyLineKey
                            Case "Boolean"
                                r(key) = False
                            Case Else
                                Exit Sub
                        End Select
                    End If
                End If
            Next
            dt.Rows.InsertAt(r, 0)
        End Sub
        Public Shared Function InsertEmptyLine(view As LookupCacheDataView) As LookupCacheDataView
            Dim t As DataTable = view.Table.Copy
            InsertEmptyLine(t)
            Dim result As LookupCacheDataView = New LookupCacheDataView(t)
            result.DefaultFilter = view.DefaultFilter
            result.ClonedView = view.ClonedView
            Return result
        End Function
        Private Shared s_ExecutingCount As Integer
        Private Delegate Sub FillTableDelegate(ByVal reader As SqlDataReader)
        Private Class AsyncCommand
            Public Sub New(ByVal cmd As SqlCommand, ByVal t As DataTable, ByVal emptyString As Boolean)
                Command = cmd
                Table = t
                AddEmptyString = emptyString
            End Sub
            Public Command As SqlCommand
            Public Table As DataTable
            Public AddEmptyString As Boolean
        End Class
        'if ID is passed, we assume that the specific record in the lookup table is refreshed only
        'this situation occurs when we refresh cache after editing lookup table in the current client app.
        Private Shared Function ExecuteCommand(ByVal cmd As IDbCommand, ByVal tableHashCode As String, ByVal AddEmptyString As Boolean, ByVal ID As Object, ByVal primaryKey As String) As Integer
            SyncLock cmd.Connection
                Dim Adapter As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
                Dim t As DataTable = GetLookupTable(tableHashCode)

                If t IsNot Nothing Then
                    SyncLock m_SyncDataObject
                        t.BeginLoadData()
                        If ID Is Nothing Then
                            t.Clear()
                        End If
                    End SyncLock
                Else
                    ID = Nothing
                End If
                If ID Is Nothing Then
                    t = CheckTableExistence(t, tableHashCode, Adapter, primaryKey)
                    SyncLock m_SyncDataObject
                        'Adapter.FillSchema(m_Dataset, SchemaType.Source, tableHashCode)
                        Adapter.Fill(m_Dataset, tableHashCode)
                    End SyncLock
                Else
                    Dim dt As DataTable
                    SyncLock m_SyncDataObject
                        dt = t.Clone
                    End SyncLock
                    Adapter.Fill(dt)
                    SyncLock m_SyncDataObject
                        m_Dataset.Merge(dt)
                    End SyncLock
                End If

                If t IsNot Nothing Then
                    SyncLock m_SyncDataObject
                        If ID Is Nothing Then
                            FinalizeTableFilling(t, AddEmptyString)
                        End If
                        t.EndLoadData()
                    End SyncLock
                End If
            End SyncLock
        End Function
        Private Shared Function CheckTableExistence(ByVal t As DataTable, ByVal tableHashCode As String, ByVal adapter As DbDataAdapter, ByVal primaryKey As String) As DataTable
            If t Is Nothing Then
                SyncLock m_SyncDataObject
                    If adapter.SelectCommand.Connection.State <> ConnectionState.Open Then
                        adapter.SelectCommand.Connection.Open()
                    End If
                    Dim tables() As DataTable = adapter.FillSchema(m_Dataset, SchemaType.Source, tableHashCode)
                    If tables.Length > 0 Then
                        t = tables(0)
                        t.TableName = tableHashCode
                        If Not Utils.IsEmpty(primaryKey) Then
                            Dbg.Assert(t.Columns.Contains(primaryKey), "lookup table {0} doesn't contain field {1}", t.TableName, primaryKey)
                            t.PrimaryKey = New DataColumn() {t.Columns(primaryKey)}
                        End If
                    End If
                End SyncLock
            End If
            Return t
        End Function
        Private Shared Function ExecuteCommandAsync(ByVal cmd As SqlCommand, ByVal tableHashCode As String, ByVal AddEmptyString As Boolean, ByVal primaryKey As String) As Integer
            Dbg.Assert(WebClientMode = False, "async connection is not allowed in WebClientMode")
            SyncLock m_SyncObject
                Dim t As DataTable = GetLookupTable(tableHashCode)
                If Not t Is Nothing Then
                    SyncLock t
                        If t IsNot Nothing AndAlso t.ExtendedProperties.ContainsKey(stFilling) AndAlso _
                                CType(t.ExtendedProperties(stFilling), Boolean) = True Then
                            Return 0
                        End If
                    End SyncLock
                End If
                If Not cmd.Transaction Is Nothing AndAlso Not cmd.Transaction.Connection Is cmd.Connection Then
                    cmd.Transaction = Nothing
                End If
                'If UseSingleConnection Then
                cmd.Connection = AsyncConnection
                'Else
                'cmd.Connection = CType(ConnectionManager.CreateNew(True).Connection, SqlConnection)
                'End If
                Dbg.Debug("async fill of lookup table with hashcode {0} is started", tableHashCode)
                SyncLock cmd.Connection
                    Try
                        ' To emulate a long-running query, wait for 
                        ' a few seconds before retrieving the real data.
                        If (cmd.Connection.State = ConnectionState.Closed) Then
                            cmd.Connection.Open()
                            Dbg.Debug("async connection with hashcode {0} for table {1} is opened", cmd.Connection.GetHashCode, tableHashCode)
                        End If
                        ' Although it is not required that you pass the 
                        ' SqlCommand object as the second parameter in the 
                        ' BeginExecuteReader call, doing so makes it easier
                        ' to call EndExecuteReader in the callback procedure.
                        If t Is Nothing Then
                            Dim adapter As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
                            t = CheckTableExistence(t, tableHashCode, adapter, primaryKey)
                        End If
                        SyncLock t
                            t.ExtendedProperties(stFilling) = True
                        End SyncLock
                        Dim callback As New AsyncCallback(AddressOf HandleCallback)
                        Interlocked.Increment(s_ExecutingCount)
                        cmd.BeginExecuteReader(callback, New AsyncCommand(cmd, t, AddEmptyString))
                        Return 1
                    Catch ex As Exception
                        t = GetLookupTable(tableHashCode)

                        If t IsNot Nothing Then
                            SyncLock t
                                t.ExtendedProperties.Remove(stFilling)
                            End SyncLock
                        End If
                        Dbg.Debug("error during async lookup fill: {0}", ex.Message)
                        Dbg.Debug("->Stack trace: {0}", ex.StackTrace.ToString)
                        Dbg.Trace()
                        Return -1
                    End Try
                End SyncLock
            End SyncLock
        End Function

        Private Shared Sub HandleCallback(ByVal result As IAsyncResult)
            Dbg.Assert(WebClientMode = False, "async connection is not allowed in WebClientMode")
            SyncLock m_SyncObject
                Dim cmd As AsyncCommand = CType(result.AsyncState, AsyncCommand)
                SyncLock cmd.Command.Connection
                    Try
                        If Interlocked.Equals(m_Reloading, 1) Then
                            Dbg.Debug("break asyncronous table fill during cache reloading")
                            Return
                        End If
                        ' Retrieve the original command object, passed
                        ' to this procedure in the AsyncState property
                        ' of the IAsyncResult parameter.
                        Dbg.Debug("lookup table with hashcode {0} is finishing asyncronically, open connections - {1}", cmd.Table.TableName, s_ExecutingCount)
                        If (cmd.Command.Connection.State <> ConnectionState.Open) Then
                            Dbg.Debug("async connection with hashcode {0} for table {1} is closed unexpectedlly", cmd.Command.Connection.GetHashCode, cmd.Table.TableName)
                        End If
                        Dim reader As SqlDataReader = cmd.Command.EndExecuteReader(result)
                        SyncLock m_SyncDataObject
                            cmd.Table.BeginLoadData()
                            cmd.Table.Clear()
                            cmd.Table.Load(reader)
                            FinalizeTableFilling(cmd.Table, cmd.AddEmptyString)
                            cmd.Table.EndLoadData()
                        End SyncLock


                        Dbg.Debug("Thread handle:{0}; hashcode: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode())
                        Dbg.Debug("lookup table with hashcode {0} is filled asyncronically, open connections - {1}; Records Count {2}", cmd.Table.TableName, s_ExecutingCount, cmd.Table.Rows.Count)
                        If Not reader Is Nothing Then
                            reader.Close()
                        End If
                        ' You may not interact with the form and its contents
                        ' from a different thread, and this callback procedure
                        ' is all but guaranteed to be running from a different thread
                        ' than the form. Therefore you cannot simply call code that 
                        ' fills the grid, like this:
                        ' FillGrid(reader)

                        ' Instead, you must call the procedure from the form's thread.
                        ' One simple way to accomplish this is to call the Invoke
                        ' method of the form, which calls the delegate you supply
                        ' from the form's thread. 
                        'Dim del As New FillTableDelegate(AddressOf FillDataTable)
                        'Thread.CurrentThread..Invoke(del, reader)
                        ' Do not close the reader here, because it is being used in 
                        ' a separate thread. Instead, have the procedure you have
                        ' called close the reader once it is done with it.

                    Catch ex As Exception
                        ' Because you are now running code in a separate thread, 
                        ' if you do not handle the exception here, none of your other
                        ' code catches the exception. Because there is none of 
                        ' your code on the call stack in this thread, there is nothing
                        ' higher up the stack to catch the exception if you do not 
                        ' handle it here. You can either log the exception or 
                        ' invoke a delegate (as in the non-error case in this 
                        ' example) to display the error on the form. In no case
                        ' can you simply display the error without executing a delegate
                        ' as in the Try block here. 

                        ' You can create the delegate instance as you 
                        ' invoke it, like this:
                        DataDiag.PrintDataSetConstraintDiagnostics(m_Dataset)
                        Dbg.Debug("lookup table with hashcode {0}; Records Count {1}", cmd.Table.TableName, cmd.Table.Rows.Count)
                        Dbg.Debug("error during async connection closing: {0}", ex.Message)
                        Dbg.Debug("-> table{0}", cmd.Table.TableName)
                        Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
                        Dbg.Trace()
                    Finally
                        If cmd.Command.Connection.State = ConnectionState.Open AndAlso Interlocked.Equals(s_ExecutingCount, 1) Then 'UseSingleConnection = False AndAlso AndAlso s_ExecutingCount > 0 
                            cmd.Command.Connection.Close()
                            Dbg.Debug("async connection with hashcode {0} for table {1} is closed", cmd.Command.Connection.GetHashCode, cmd.Table.TableName)
                        End If
                        If Not Interlocked.Equals(s_ExecutingCount, 0) Then
                            Interlocked.Decrement(s_ExecutingCount)
                        End If
                        Dbg.Debug("finalizing async callback processing for table {0}, openConnections: {1}", cmd.Table.TableName, s_ExecutingCount)
                        cmd.Table.ExtendedProperties(stFilling) = False
                    End Try

                End SyncLock
            End SyncLock

        End Sub
        Public Shared ReadOnly Property Filled(ByVal table As LookupTableInfo) As Boolean
            Get
                Dim tableHashCode As String = GetTableHashCode(table)
                Dim t As DataTable = GetLookupTable(tableHashCode)
                If t IsNot Nothing Then
                    SyncLock t
                        Return t.ExtendedProperties.ContainsKey(stFilling) AndAlso CType(t.ExtendedProperties(stFilling), Boolean) = False
                    End SyncLock
                End If
                Return False
            End Get
        End Property

        Public Shared ReadOnly Property Filling(ByVal table As LookupTableInfo) As Boolean
            Get
                Dim tableHashCode As String = GetTableHashCode(table)
                Dim t As DataTable = GetLookupTable(tableHashCode)
                If t IsNot Nothing Then
                    SyncLock t
                        Return t.ExtendedProperties.ContainsKey(stFilling) AndAlso CType(t.ExtendedProperties(stFilling), Boolean) = True
                    End SyncLock
                End If
                Return False
            End Get
        End Property

        Public Shared Function GetLookupValue(ByVal KeyFieldValue As Object, ByVal LookupTableID As [Enum], ByVal FieldName As String) As String
            Return GetLookupValue(KeyFieldValue, LookupTableID.ToString, FieldName)
        End Function

        Public Shared Function GetLookupValue(ByVal KeyFieldValue As Object, ByVal LookupTableID As String, ByVal FieldName As String) As String
            Dim row As DataRow = GetLookupRow(KeyFieldValue, LookupTableID)
            If Not row Is Nothing Then
                Return Utils.Str(row(FieldName))
            End If
            Return ""
        End Function
        Public Shared Function GetLookupRow(ByVal KeyFieldValue As Object, ByVal LookupTableID As String) As DataRow
            Dim tableHashCode As String = ""
            Dim tableInfo As LookupTableInfo = GetLookupTableInfo(LookupTableID)
            If tableInfo Is Nothing Then
                [Get](LookupTableID)
                tableInfo = GetLookupTableInfo(LookupTableID)
            End If
            tableHashCode = GetTableHashCode(m_LookupTables(LookupTableID))
            Dim t As DataTable = GetLookupTable(tableHashCode)
            Dim RefillNeeded As Boolean
            If t Is Nothing Then
                RefillNeeded = True
            Else
                SyncLock t
                    If t.Rows.Count = 0 Then
                        RefillNeeded = True
                    End If
                End SyncLock
            End If
            If RefillNeeded Then
                Fill(tableInfo, True)
            End If
            t = GetLookupTable(tableHashCode)
            If t Is Nothing Then Return Nothing
            If TypeOf (KeyFieldValue) Is Array Then
                Dim key(CType(KeyFieldValue, Array).Length - 1) As Object
                For i As Integer = 0 To key.Length - 1
                    key(i) = CType(KeyFieldValue, Array).GetValue(i)
                Next
                SyncLock t
                    Return t.Rows.Find(key)
                End SyncLock
            End If
            SyncLock t
                Return t.Rows.Find(KeyFieldValue)
            End SyncLock
        End Function
        Public Shared Sub NotifyChange(ByVal SqlTableName As String, Optional ByVal transaction As IDbTransaction = Nothing, Optional ByVal ID As Object = Nothing)
            If Not m_Initialized Then Return
            Refresh(SqlTableName, False, transaction, ID)
            SyncLock m_ReferenceChangedRequests
                m_ReferenceChangedRequests(SqlTableName) = DateTime.Now()
            End SyncLock
            'CreateLookupChangedEvent(SqlTableName, transaction)
        End Sub
        Public Shared Sub NotifyDelete(ByVal SqlTableName As String, Optional ByVal transaction As IDbTransaction = Nothing, Optional ByVal ID As Object = Nothing)
            If Not m_Initialized Then Return
            Dim SqlTableNameWithoutPrefix As String = ""
            For i As Integer = 0 To SqlTableName.Length - 1
                If Char.IsUpper(SqlTableName(i)) Then
                    SqlTableNameWithoutPrefix = SqlTableName.Substring(i)
                    Exit For
                End If
            Next
            If Not ID Is Nothing Then
                Dim lookupTablesCopy As New List(Of LookupTableInfo)
                SyncLock m_LookupTables
                    For Each table As LookupTableInfo In m_LookupTables.Values
                        If table.SqlName = SqlTableName OrElse table.SqlName = SqlTableNameWithoutPrefix Then
                            lookupTablesCopy.Add(table)
                        End If
                    Next
                End SyncLock

                For Each table As LookupTableInfo In lookupTablesCopy
                    Dim tableHashCode As String = GetTableHashCode(table)
                    Dim t As DataTable = GetLookupTable(tableHashCode)
                    If t Is Nothing Then Return
                    SyncLock m_SyncDataObject
                        Dim row As DataRow = t.Rows.Find(ID)
                        If Not row Is Nothing Then
                            row.Delete()
                            t.AcceptChanges()
                        End If
                    End SyncLock
                Next
                Refresh(SqlTableName, True, transaction)
            Else
                Refresh(SqlTableName, False, transaction)
            End If
            SyncLock m_ReferenceChangedRequests
                m_ReferenceChangedRequests(SqlTableName) = DateTime.Now()
            End SyncLock
            'CreateLookupChangedEvent(SqlTableName, transaction)
        End Sub

        Public Shared Sub CreateLookupChangedEvent(ByVal SqlTableName As String, Optional ByVal transaction As IDbTransaction = Nothing, Optional ByVal ClientID As String = Nothing)
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEventLog_CreateNewEvent", AsyncConnection, transaction)
            If ClientID Is Nothing Then
                ClientID = ModelUserContext.ClientID
            End If
            If SqlTableName.StartsWith("rft") Then
                SqlTableName = SqlTableName.Substring(3)
            End If
            BaseDbService.AddParam(cmd, "@idfsEventTypeID", CLng(EventType.RaiseReferenceCacheChange)) '"evtLookupTableChanged"
            BaseDbService.AddTypedParam(cmd, "@idfObjectID", SqlDbType.BigInt)
            BaseDbService.AddParam(cmd, "@strInformationString", SqlTableName.ToString)
            BaseDbService.AddParam(cmd, "@strNote", "")
            BaseDbService.AddParam(cmd, "@ClientID", ClientID)
            BaseDbService.AddParam(cmd, "@intProcessed", 0)
            BaseDbService.AddParam(cmd, "@idfUserID", EIDSS.model.Core.EidssUserContext.User.ID)
            BaseDbService.AddTypedParam(cmd, "@EventID", SqlDbType.BigInt, ParameterDirection.InputOutput)
            BaseDbService.AddParam(cmd, "@idfsSite", eidss.model.Core.EidssSiteContext.Instance.SiteID)
            BaseDbService.AddTypedParam(cmd, "@idfsDiagnosis", SqlDbType.BigInt)
            BaseDbService.ExecCommand(cmd, AsyncConnection, transaction, True)
            Dbg.Debug("Lookup table changed (clientID {0}): {1}", ClientID, SqlTableName)
        End Sub
        Private Shared Sub QueueWorkerProc(ByVal state As Object)
            Dbg.Assert(WebClientMode = False, "async connection is not allowed in WebClientMode")
            'SyncLock m_SyncObject
            If m_queueTimer Is Nothing Then
                Exit Sub
            End If
            Dim table As LookupTableInfo = Nothing
            Try
                m_queueTimer.Change(Timeout.Infinite, Timeout.Infinite)

                If s_ExecutingCount >= CONNECTIONS_COUNT Then
                    Dbg.Debug("skip async queue step, previous lookup table is pending")
                    Exit Sub
                End If
                If Interlocked.Equals(m_AsyncQueue.Count, 0) AndAlso Interlocked.Equals(m_ReferenceChangedRequests.Count, 0) Then
                    Exit Sub
                End If

                SyncLock m_AsyncQueue
                    If Not Interlocked.Equals(m_AsyncQueue.Count, 0) Then
                        table = m_AsyncQueue.Dequeue()
                    End If
                End SyncLock

                If Not table Is Nothing Then
                    Dim hashCode As String = GetTableHashCode(table)
                    If IsBaseReference(table.Name) Then
                        FillBaseReferenceLookup(table, hashCode, True)
                    Else
                        FillLookupTable(table, hashCode, True)
                    End If
                End If
                If Not Interlocked.Equals(m_ReferenceChangedRequests.Count, 0) Then
                    Dim now As DateTime = DateTime.Now
                    Dim tablesToProcess As New List(Of String)
                    SyncLock m_ReferenceChangedRequests
                        For Each name As String In m_ReferenceChangedRequests.Keys()
                            If now.Subtract(m_ReferenceChangedRequests(name)).Ticks > 500 Then
                                tablesToProcess.Add(name)
                            End If
                        Next
                    End SyncLock
                    For Each name As String In tablesToProcess
                        CreateLookupChangedEvent(name, Nothing)
                    Next
                    SyncLock m_ReferenceChangedRequests
                        For Each name As String In tablesToProcess
                            m_ReferenceChangedRequests.Remove(name)
                        Next
                    End SyncLock
                End If
            Catch ex As Exception
                If Not table Is Nothing Then
                    Dbg.Debug("error during lookup cache refreshing for table {0} :{1}", Utils.Str(table.Name), ex.ToString)
                Else
                    Dbg.Debug("error during lookup cache refreshing for unknown table :{0}", ex.ToString)
                End If

            Finally
                SyncLock m_AsyncQueue
                    If m_AsyncQueue.Count > 0 Then
                        m_queueTimer.Change(TIMER_INTERVAL, Timeout.Infinite)
                    Else
                        m_queueTimer.Change(IDLE_TIMER_INTERVAL, Timeout.Infinite)
                    End If
                End SyncLock
            End Try
            'End SyncLock
        End Sub
        Public Shared ReadOnly Property Filled() As Boolean
            Get
                SyncLock m_AsyncQueue
                    Return (m_AsyncQueue.Count = 0 AndAlso Interlocked.Equals(s_ExecutingCount, 0))
                End SyncLock
            End Get
        End Property
        Private Shared Sub RemoveFromQueue(ByVal table As LookupTableInfo)
            SyncLock m_AsyncQueue
                Dim ar As Array = m_AsyncQueue.ToArray
                m_AsyncQueue.Clear()
                For Each t As LookupTableInfo In ar
                    If t.Name <> table.Name Then
                        m_AsyncQueue.Enqueue(t)
                    End If
                Next
            End SyncLock
        End Sub
    End Class
End Namespace

