Imports System.Data
Imports System.Collections
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

''' -----------------------------------------------------------------------------
''' Project	 : bvdb_common
''' Class	 : common.db.Pager
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Provides the mechanism for returning dataset containing only requested page of records that matches 
''' requested filtering and sorting conditions.
''' </summary>
''' <remarks>
''' <i>Pager</i> class analyzes the SQL query passed as <b>SelectCommand</b> of <b>DbDataAdapter</b>, 
''' modifies it to the query that will return only data from the requested records range and returns 
''' this requested records range.
''' <para>
''' The task of entire recordset retrieving is very time consuming and has no big sense for end user, because
''' it is very difficult to find required record in big recordset. <b>Pager</b> is used to restrict the number 
''' of records in the returned recordset and provide convenient mechanism for record searching.
''' </para>
''' </remarks>
''' <history>
''' 	[Mike]	19.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Pager

#Region "Class declarations"
    Private mDataAdapter As DbDataAdapter
    Private t As Type = GetType(String)

    Private parser As SqlParser

    Private ChunkSize As Integer = 100
    Private m_VisiblePageCount As Integer = 10
    Private m_PageSize As Integer = 10
    Private m_CurPage As Integer
    Private Shared m_Session As Hashtable

    Private Chunks As ArrayList
    Dim m_RecordCount As Integer
    'Private map As ITableMapping

#End Region
#Region "Constructor"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Initializes the <i>Pager</i> class instance with <b>DbDataAdapter</b> containing <b>SelectCommand</b>
    ''' that should return entire recordset.
    ''' </summary>
    ''' <param name="adapter">
    ''' the <b>DbDataAdapter</b> containing <b>SelectCommand</b>
    ''' that should return the entire recordset
    ''' </param>
    ''' <remarks>
    ''' It is assumed the <b>DbDataAdapter.SelectCommand.CommandText</b> contains the sql query with <b>SELECT</b> statement.
    ''' <b>DbDataAdapter.SelectCommand</b> can't be the command that call the stored procedure.
    ''' The Exception is thrown if improper command is used for the pager initialization.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal adapter As DbDataAdapter)
        'map = adapter.TableMappings(0)
        mDataAdapter = adapter
        parser = New SqlParser

        Dim SQL As String = GetAdapterSelectCommand().CommandText
        parser.SQL = SQL
        If m_Session Is Nothing Then m_Session = New Hashtable

    End Sub
#End Region
#Region "Properties"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the maximum number of records that should be returned by <see cref="Pager.GetPage"/> method.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property PageSize() As Integer
        Get
            Return m_PageSize
        End Get

        Set(ByVal Value As Integer)
            m_PageSize = Value
            ChunkSize = m_PageSize * m_VisiblePageCount
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the number of pages that should be displayed by the pager control.
    ''' </summary>
    ''' <remarks>
    ''' If pager control that provides switching between different pages 
    ''' displays several page numbers, <i>Pager</i> should inform this control
    ''' how many records stating from first displayed page can be accessible. 
    ''' Grid pager control can use this information to calculate how many page links should be 
    ''' displayed. <i>PageSize * VisiblePageCount</i> is the maximum records count requested by <i>Pager</i>
    ''' from the database.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property VisiblePageCount() As Integer
        Get
            Return m_VisiblePageCount
        End Get

        Set(ByVal Value As Integer)
            m_VisiblePageCount = Value
            ChunkSize = m_PageSize * m_VisiblePageCount
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets SQL SELECT statement that will be used for records retrieving
    ''' </summary>
    ''' <remarks>
    ''' SELECT statement must list all fields explicitly and must list all fields included to the primary key
    ''' related with returned recordset.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property SelectSQL() As String
        Get
            Return parser.SQL
        End Get
        Set(ByVal Value As String)
            parser.SQL = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the list of fields returned by SELECT part of the SQL query used by <i>Pager</i> 
    ''' (i.e. the part of SELECT statement enclosed between SELECT and FROM clauses).
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property SelectPart() As String
        Get
            Return parser.SelectStr
        End Get
        Set(ByVal Value As String)
            parser.SelectStr = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the part of SELECT statement enclosed between FROM and the next SELECT clause used in the query.
    ''' </summary>
    ''' <remarks>
    ''' Use <i>From</i> property to filter the recordset returned by <i>Pager</i> through the joined table data.
    ''' </remarks>
    ''' <example>
    ''' Example demonstrates how to organize data filtering through the <i>Pager.From</i> property.
    ''' <code>
    ''' Dim pager As New Pager
    ''' pager.PageSize = 10
    ''' pager.VisiblePageCount= 10
    ''' pager.SelectSQL = "SELECT OrderID FROM Order"
    ''' Dim ds As New DataSet
    ''' 'Get the first page of the unfiltered recordeset
    ''' pager.GetPage(ds, "Order", 1)
    ''' pager.From = "INNER JOIN Customer ON Order.CustomerID=Customer.CustomerID"
    ''' pager.Where = "Customer.LastName &gt;= 'P' AND Customer.LastName &lt;= 'R'"
    ''' 'Get the first page of orders related with customers having LastName starting from <b>P</b> letter
    ''' pager.GetPage(ds, "Order", 1)
    ''' </code>
    ''' </example>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property From() As String
        Get
            Return parser.From
        End Get
        Set(ByVal Value As String)
            parser.From = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the part of SELECT statement enclosed between WHERE and the next SELECT clause used in the query.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Use <i>Where</i> property to filter the recordset returned by <i>Pager</i>.
    ''' </remarks>
    ''' <example>
    ''' Example demonstrates how to organize data filtering through the <i>Pager.Where</i> property.
    ''' <code>
    ''' Dim pager As New Pager
    ''' pager.PageSize = 10
    ''' pager.VisiblePageCount= 10
    ''' pager.SelectSQL = "SELECT OrderID FROM Order WHERE Order.Posted = 1"
    ''' Dim ds As New DataSet
    ''' 'Get the first page of the recordeset with default filtering
    ''' pager.GetPage(ds, "Order", 1)
    ''' 'Modify filter condition
    ''' pager.Where += " AND (Order.Date>'2005/01/01'"
    ''' 'Get the first page of posted orders created after 2005/01/01
    ''' pager.GetPage(ds, "Order", 1)
    ''' </code>
    ''' </example>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Where() As String
        Get
            Return parser.Where
        End Get
        Set(ByVal Value As String)
            If Not SkipValidation Then
                SQLCheck.SQLValidator.ValidateWhereCondition(Value)
            End If
            parser.Where = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the part of SELECT statement enclosed between ORDER BY and the next SELECT clause used in the query.
    ''' </summary>
    ''' <remarks>
    ''' Only single field ORDER BY clause is supported by <i>Pager</i> currently. Use <i>Order</i> property
    ''' to modify the sort order of the recordset returned by <i>Pager</i>.
    ''' </remarks>
    ''' <example>
    ''' Example demonstrates how to change default sort order of recordset returned by <i>Pager</i>.
    ''' <code>
    ''' Dim pager As New Pager
    ''' pager.PageSize = 10
    ''' pager.VisiblePageCount= 10
    ''' pager.SelectSQL = "SELECT OrderID, OrderType FROM Order WHERE Order.Posted = 1"
    ''' Dim ds As New DataSet
    ''' 'Get the first page of the recordeset with default sorting
    ''' pager.GetPage(ds, "Order", 1)
    ''' 'Modify sort condition
    ''' pager.Order += "OrderType DESC"
    ''' 'Get the first page of posted orders sorted by OrderType field in the descending order.
    ''' pager.GetPage(ds, "Order", 1)
    ''' </code>
    ''' </example>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Order() As String
        Get
            Return parser.Order
        End Get
        Set(ByVal Value As String)
            If String.IsNullOrEmpty(Value) Then
                Value = Nothing
            End If
            If Not SkipValidation Then
                SQLCheck.SQLValidator.ValidateOrderByCondition(Value)
            End If
            parser.Order = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the records count that contains the information what pages range should be displayed by external
    ''' pager control.
    ''' </summary>
    ''' <remarks>
    ''' <paramref name="ApproximateRecordCount"/> contains or real records count returned by the current pager query
    ''' or at least VisiblePageCount*PageSize+1.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ApproximateRecordCount() As Integer
        Get
            Return m_RecordCount
            'If Chunks.Count = 0 Then Return 0
            'Return (Chunks.Count - 1) * ChunkSize + ChunkInfo(Chunks.Count - 1).size - ChunkInfo(Chunks.Count - 1).start
        End Get
    End Property
#End Region

#Region "Public methods"

    Private Function FillPage(ByVal da As DbDataAdapter, ByVal Ds As DataSet, ByVal TableName As String) As Boolean
        Using dataSet As New DataSet
            SyncLock da.SelectCommand.Connection
                Dim result As Integer = da.Fill(dataSet, TableName)
                If da.SelectCommand.Connection.State <> ConnectionState.Closed Then
                    da.SelectCommand.Connection.Close()
                End If
            End SyncLock
            If dataSet.Tables.Count = 3 Then
                m_RecordCount = CInt(dataSet.Tables(1).Rows(0)(0))
                dataSet.Tables.RemoveAt(0)
                dataSet.Tables.RemoveAt(0)
                dataSet.Tables(0).TableName = TableName
                Ds.Merge(dataSet)
                Ds.AcceptChanges()
                DbDisposeHelper.ClearDataset(dataSet)
                Return True
            Else
                Dbg.Debug("spGetQueryPage returns no data")
                Return False
            End If
        End Using
    End Function

    Private Function FillPageSimple(ByVal da As DbDataAdapter, ByVal Ds As DataSet, ByVal TableName As String) As Boolean
        Using dataSet As New DataSet
            SyncLock da.SelectCommand.Connection
                da.Fill(dataSet, TableName)
                If da.SelectCommand.Connection.State <> ConnectionState.Closed Then
                    da.SelectCommand.Connection.Close()
                End If
            End SyncLock
            If dataSet.Tables.Count > 0 Then
                m_RecordCount = dataSet.Tables(0).Rows.Count
                dataSet.Tables(0).TableName = TableName
                dataSet.Tables(0).BeginLoadData()
                For i As Integer = m_RecordCount - 1 To PageSize Step -1
                    dataSet.Tables(0).Rows(i).Delete()
                Next
                dataSet.Tables(0).EndLoadData()
                Ds.Merge(dataSet)
                Ds.AcceptChanges()
                DbDisposeHelper.ClearDataset(dataSet)
                Return True
            Else
                Dbg.Debug("dataset is not filled during simple page filling for table {0}", TableName)
                Return False
            End If
        End Using
    End Function

    Public Shared Sub FillError(ByVal sender As Object, ByVal e As FillErrorEventArgs)
        If Not e.Errors Is Nothing Then
            Dbg.Debug("error during spGetQueryPage call:")
            Dbg.Debug(e.Errors.Message)
            Dbg.Debug(e.Errors.StackTrace)
            e.Continue = True
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fills the <b>DataTable</b> in the <b>DataSet</b> with records corresponded requested 
    ''' page of data taking into account <see cref="Pager.From"/>,  <see cref="Pager.Where"/> 
    ''' and  <see cref="Pager.Order"/> values.
    ''' </summary>
    ''' <param name="Ds">
    ''' <b>DataSet</b> to fill
    ''' </param>
    ''' <param name="TableName">
    ''' the name of <b>DataTable</b> in the <b>DataSet</b> to fill
    ''' </param>
    ''' <param name="page">
    ''' requested page of data
    ''' </param>
    ''' <returns>
    '''  Always returns <b>True</b>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <example>
    ''' Example demonstrates how get the requested page of data.
    ''' <code>
    ''' Dim da As New SqlDataAdapter("SELECT OrderID, OrderType FROM Order WHERE Order.Posted = 1", myConnection)
    ''' Dim pager As New Pager
    ''' pager.PageSize = 10
    ''' pager.VisiblePageCount= 10
    ''' Dim ds As New DataSet
    ''' 'Get the first page of the recordeset with default sorting
    ''' pager.GetPage(ds, "Order", 1)
    ''' 'Modify sort condition
    ''' pager.Order += "OrderType DESC"
    ''' 'Get the first page of posted orders sorted by OrderType field in the descending order.
    ''' pager.GetPage(ds, "Order", 1)
    ''' 'Get the second page of posted orders sorted by OrderType field in the descending order.
    ''' pager.GetPage(ds, "Order", 2)
    ''' </code>
    ''' </example>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetPage(ByVal Ds As DataSet, ByVal TableName As String, ByVal page As Integer) As Boolean
        If page < 0 Then
            mDataAdapter.Fill(Ds, TableName)
            m_RecordCount = Ds.Tables(TableName).Rows.Count
            Return True
        End If

        'parser.DefaultOrderField = GetDefaultOrderField(dt)
        If parser.Order Is Nothing OrElse parser.Order = "" Then parser.SetDefaultOrder()
        Dim p As New SqlParser
        p.SQL = parser.SQL
        Dim AdditionalParameters As New ArrayList

        Dim SelectCommand As IDbCommand = GetAdapterSelectCommand()
        If page = 0 Then
            parser.TopCount = ChunkSize + 1
        End If

        Dim s As String = parser.SQL
        If page = 0 Then
            Dim cmd As IDbCommand = BaseDbService.CreateCommand(s, SelectCommand.Connection, SelectCommand.Transaction)
            Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
            AddHandler da.FillError, AddressOf FillError
            da.MissingMappingAction = MissingMappingAction.Passthrough
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            FillPageSimple(da, Ds, TableName)
        Else
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spGetQueryPage", SelectCommand.Connection, SelectCommand.Transaction)
            BaseDbService.AddParam(cmd, "@queryText", s)
            BaseDbService.AddParam(cmd, "@firstRecordNum", page * PageSize + 1)
            BaseDbService.AddParam(cmd, "@maxRecordCount", PageSize)
            Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
            AddHandler da.FillError, AddressOf FillError
            da.MissingMappingAction = MissingMappingAction.Passthrough
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            If FillPage(da, Ds, TableName) = False Then
                ConnectionManager.CloseAllConnections()
                FillPage(da, Ds, TableName)
            End If
        End If
        RestoreCommand(SelectCommand, AdditionalParameters)
        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Safely adds additional part to the <see cref="Pager.Where"/> property. The additional filter condition 
    ''' is parsed before adding to existing <see cref="Pager.Where"/> property and <see cref="SQLCheck.SQLValidationException"/> 
    ''' is thrownif additional filter contains unsafe parts or improper format.
    ''' </summary>
    ''' <param name="cond">
    ''' additional filter that should be added to existing <see cref="Pager.Where"/> filter.
    ''' </param>
    ''' <remarks>
    ''' Use this property to avoid sql injection when construct the additional filters through the GUI.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AddWhereCondition(ByVal cond As String)
        If Not SkipValidation Then
            SQLCheck.SQLValidator.ValidateWhereCondition(cond)
        End If
        parser.Where = String.Format("({0}) AND ({1})", parser.Where, cond)
    End Sub
#End Region
    Private m_SkipValidation As Boolean
    Public Property SkipValidation() As Boolean
        Get
            Return m_SkipValidation
        End Get
        Set(ByVal value As Boolean)
            m_SkipValidation = value
        End Set
    End Property
#Region "Private methods"

    Sub RestoreCommand(ByVal command As IDbCommand, ByVal AdditionalParameters As ArrayList)
        If TypeOf mDataAdapter Is SqlDataAdapter Then
            RestoreCommand(CType(command, SqlCommand), AdditionalParameters)
        End If
    End Sub

    Sub RestoreCommand(ByVal command As SqlCommand, ByVal AdditionalParameters As ArrayList)
        command.CommandText = parser.OriginalSql
        Dim ParamName As String
        For Each ParamName In AdditionalParameters
            command.Parameters.RemoveAt(ParamName)
        Next
    End Sub

    Function GetAdapterSelectCommand() As IDbCommand
        If TypeOf mDataAdapter Is SqlDataAdapter Then
            If (CType(mDataAdapter, SqlDataAdapter)).SelectCommand.CommandType <> CommandType.Text Then
                Throw New Exception("Improper SelectCommand.CommandType is used. Pager class requires the SelectCommand.CommandType = Text.")
            End If
            Return (CType(mDataAdapter, SqlDataAdapter)).SelectCommand
        End If
        Return Nothing
    End Function

    Private Shared Function FixParameterName(ByVal paramName As String) As String
        Static rx As New Regex("[^a-zA-Z0-9_]")
        paramName = rx.Replace(paramName, "")
        If Char.IsDigit(paramName.Chars(0)) Then
            paramName = String.Format("a{0}", paramName)
        End If
        Return paramName
    End Function
#End Region

End Class


