Imports System
Imports System.Data
Imports System.Text.RegularExpressions

''' -----------------------------------------------------------------------------
''' <summary>
''' Enumerates SQL dialects that can be used with <see cref="SqlParser"/> class.
''' </summary>
''' <history>
''' 	[Mike]	19.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum SqlDialect
    Access
    SqlServer
    Oracle
End Enum

''' -----------------------------------------------------------------------------
''' Project	 : bvdb_common
''' Class	 : common.db.SqlParser
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Parses the SELECT SQL statement, splits it to the compound parts, and allows these compound parts modification and creating
''' new SQL statement based on the SQL statement compound parts.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	19.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class SqlParser
#Region "Class declarations"
    Private m_SelectSql As String = Nothing
    Private m_SelectStr As String = Nothing
    Private m_Distinct As Boolean = False
    Private m_FromStr As String = Nothing
    Private m_WhereStr As String = Nothing
    Private m_GroupByStr As String = Nothing
    Private m_OrderField As String = Nothing
    Private m_OrderCondition As String = Nothing
    Private m_OrderOperation As String = Nothing
    Private m_TopCount As Integer = -1
    Private Shared m_Dialect As SqlDialect = SqlDialect.SqlServer
    Private m_DefaultOrderField As String = "ID"
#End Region

#Region "Constructor"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Initializes a new instance of the <see cref="SqlParser"/> class.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
    End Sub

#End Region

#Region "Properties"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the original SELECT SQL Statement that was initialized through the <see cref="SqlParser.SQL"/> property.
    ''' </summary>
    ''' <remarks>
    ''' Use this property to restore original SQL statement that was set before any modifications of compound SQL parts.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property OriginalSql() As String
        Get
            Return m_SelectSql
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the current SQL statement processed by the <i>SqlParser</i> class.
    ''' </summary>
    ''' <remarks>
    ''' This property returns the SQL statement constructed from current SQL compound parts provided by <i>SqlParser</i> properties.
    ''' When you set <i>SQL</i> property, the <see cref="SqlParser.OriginalSql"/> is initialized and SQL statement is parsed 
    ''' to the default compound parts
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property SQL() As String
        Get
            Return BuildSql()
        End Get

        Set(ByVal Value As String)
            m_SelectSql = Value
            ParseSQL()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the SELECT part of the SQL statement
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property SelectStr() As String
        Get
            Return m_SelectStr
        End Get

        Set(ByVal Value As String)
            m_SelectStr = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Get or sets boolean value indicating whether DISTINCT clause is used inside SELECT statement
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Distinct() As Boolean
        Get
            Return m_Distinct
        End Get
        Set(ByVal Value As Boolean)
            m_Distinct = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets FROM clause of SELECT SQL statement
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property From() As String
        Get
            Return m_FromStr
        End Get

        Set(ByVal Value As String)
            m_FromStr = Value
        End Set
    End Property
    Private m_TableName As String
    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal Value As String)
            m_TableName = Value
        End Set
    End Property

    Private m_AliasTableName As String
    Public Property AliasTableName() As String
        Get
            Return m_AliasTableName
        End Get
        Set(ByVal Value As String)
            m_AliasTableName = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets WHERE clause of SELECT SQL statement
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Where() As String
        Get
            Return m_WhereStr
        End Get

        Set(ByVal Value As String)
            m_WhereStr = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets GROUP BY clause of SELECT SQL statement
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Group() As String
        Get
            Return m_GroupByStr
        End Get

        Set(ByVal Value As String)
            m_GroupByStr = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets ORDER BY clause of SELECT SQL statement
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Order() As String
        Get
            Return m_OrderCondition
        End Get

        Set(ByVal Value As String)
            m_OrderCondition = Value
            ParseOrder()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the ORDER BY clause direction. Possible values are "&lt;" and "&gt;" 
    ''' that correspond DESC and ASC keywords correspondently.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property OrderOperation() As String
        Get
            Return m_OrderOperation
        End Get

        Set(ByVal Value As String)
            If Not Value Is Nothing AndAlso Value <> "" AndAlso Value <> "<" AndAlso Value <> ">" Then
                Throw New Exception("invalid ORDER BY direction")
            End If
            m_OrderOperation = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the name of the first field used in the ORDER BY clause 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property OrderField() As String
        Get
            Return m_OrderField
        End Get

        Set(ByVal Value As String)
            m_OrderField = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets maximum records count that should be returned by the SELECT statement (corresponds
    ''' to the N value in the TOP N keyword used in the SELECT statement)
    ''' </summary>
    ''' <remarks>
    ''' If <c>TopCount&lt;=0</c> it is ignored during SQL statement constructing
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property TopCount() As Integer
        Get
            Return m_TopCount
        End Get

        Set(ByVal Value As Integer)
            m_TopCount = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets SQL dialect used in the processed SQL statement.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property Dialect() As SqlDialect
        Get
            Return m_Dialect
        End Get

        Set(ByVal Value As SqlDialect)
            m_Dialect = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the filed name that should be used for sorting if ORDER BY clause of parsed SQL statement is empty.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property DefaultOrderField() As String
        Get
            Return m_DefaultOrderField
        End Get

        Set(ByVal Value As String)
            m_DefaultOrderField = Value
        End Set
    End Property

#End Region

#Region "Public methods"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines the default sorting order of the current SQL statement.
    ''' If ORDER BY clause is not defined the <see cref="DefaultOrderField"/> and ASC order direction is used
    ''' to construct ORDER BY clause. In other case existing ORDER BY clause is not modified.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetDefaultOrder()
        If m_OrderField Is Nothing Or m_OrderField = "" Then
            m_OrderField = DefaultOrderField
            m_OrderOperation = ">"
        End If
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns the string representation of the <paramref name="val"/> parameter that can be used 
    ''' in the WHERE clause formatted in the correspondence with the current <see cref="SqlParser.Dialect"/>.
    ''' </summary>
    ''' <param name="type">
    ''' the <b>System.Type</b> of the object that should be formatted
    ''' </param>
    ''' <param name="val">
    ''' the object to format
    ''' </param>
    ''' <returns>
    ''' Returns the string representation of the <paramref name="val"/> parameter that can be used 
    ''' in the WHERE clause formatted in the correspondence with the current <see cref="SqlParser.Dialect"/>.
    ''' </returns>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GetFormattedValue(ByVal type As Type, ByVal val As Object, Optional ByVal useUnicodePrefix As Boolean = True) As String
        Select Case (type.Name)
            Case "DateTime"
                If Dialect = SqlDialect.Access Then
                    Return String.Format("#{0:MM'/'dd'/'yyyy}#", CType(val, DateTime))
                Else
                    Return String.Format("'{0:yyyyMMdd}'", CType(val, DateTime)) 'MM'/'dd'/'yyyy
                End If
            Case "Boolean"
                Return String.Format("{0}", IIf(CBool(val), 1, 0))
            Case Else
                If IsNeedQuote(type) Then
                    If type Is GetType(String) AndAlso useUnicodePrefix Then
                        Return String.Format("N'{0}'", GetSafeSqlString(val.ToString()))
                    Else
                        Return String.Format("'{0}'", GetSafeSqlString(val.ToString()))
                    End If
                Else
                    Return String.Format("{0}", val.ToString())
                End If
        End Select
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns the string representation of the <paramref name="val"/> parameter that can be used 
    ''' in the WHERE clause formatted in the correspondence with the current <see cref="SqlParser.Dialect"/>.
    ''' </summary>
    ''' <param name="val">
    ''' the object to format
    ''' </param>
    ''' <returns>
    ''' Returns the string representation of the <paramref name="val"/> parameter that can be used 
    ''' in the WHERE clause formatted in the correspondence with the current <see cref="SqlParser.Dialect"/>.
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GetFormattedValue(ByVal val As Object) As String
        Return GetFormattedValue(val.GetType(), val)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Restores and parses the original SQL statement.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub Reset()
        SQL = OriginalSql
    End Sub
    Public Shared Function GetSafeSqlString(ByVal text As String) As String
        If text Is Nothing Then
            Return ""
        End If
        Return text.Replace("'", "''")
    End Function
    Public Shared Function CreateCondition(ByVal FieldName As String, ByVal dataType As Type, ByVal operation As String, ByVal value As Object) As String
        Dim text As String = value.ToString.Trim().Replace("%", "[%]").Replace("_", "[_]").Replace("*", "%").Replace("?", "_")
        If text = "" Then Return Nothing
        Dim kind As String = operation.Trim.ToUpperInvariant
        'text = text.Replace("'", "''")
        If kind = "LIKE" Then
            Return CreateLikeCondition(FieldName, dataType, text)
        ElseIf kind = "HARDLIKE" Then
            Return CreateHardLikeCondition(FieldName, dataType, text)
        ElseIf kind = "BETWEEN" Then
            Return CreateBetweenCondition(FieldName, dataType, value)
        Else
            text = bv.common.db.SqlParser.GetFormattedValue(dataType, text)
            FieldName = GetConditionFieldName(FieldName, dataType)
            Return String.Format("{0} {1} {2}", FieldName, kind, text)
        End If
    End Function

    Private Shared Function CreateBetweenCondition(ByVal fieldName As String, ByVal dataType As Type, ByVal value As Object) As String
        If (Not IsNumeric(value)) Then
            Return ""
        End If
        Dim low As Decimal = CType(value, Decimal)
        Dim x As New SqlTypes.SqlDecimal(low)
        Dim upper As Double = Decimal.ToDouble(low) + Math.Pow(10, -x.Scale)
        Return String.Format("{0} >= {1} AND {0} <= {2}", fieldName, low, upper)
    End Function

    Private Shared Function GetConditionFieldName(ByVal fieldName As String, ByVal dataType As Type) As String
        If dataType Is GetType(DateTime) Then
            Return String.Format("CONVERT(NVARCHAR(200), {0}, 112)", fieldName)
        ElseIf dataType Is GetType(String) Then
            Return String.Format("ISNULL({0},N'')", fieldName)
        Else
            Return fieldName
        End If
    End Function

    Private Shared rexLike As New Regex("(?<prefix>^[\%\*])?((?<exp>.*)(?<suffix>[\%\*]$)|(?<exp>.*))")
    Public Shared Function CorrectLikeValue(ByVal dataType As Type, ByVal value As String) As String
        Dim likePrefix As String = ""
        Dim likeSuffix As String = ""
        Dim text As String = ""
        'value = GetSafeSqlString(value)
        Dim m As Match = rexLike.Match(value)

        If m.Success Then
            likePrefix = m.Result("${prefix}")
            likeSuffix = m.Result("${suffix}")
            text = m.Result("${exp}")
        Else
            text = value
        End If
        If likePrefix <> "" Then
            likePrefix = "%"
        End If
        If likeSuffix <> "" Then
            likeSuffix = "%"
        End If

        If likeSuffix = "" AndAlso likePrefix = "" Then
            likeSuffix = "%"
        End If
        text = FixLikeTextForDates(text, dataType)
        Dim fullText As String = String.Format("{0}{1}{2}", likePrefix, text, likeSuffix)
        Return bv.common.db.SqlParser.GetFormattedValue(GetType(String), fullText)
    End Function
    Public Shared Function CreateLikeCondition(ByVal FieldName As String, ByVal dataType As Type, ByVal value As String) As String
        FieldName = GetConditionFieldName(FieldName, dataType)
        Dim likeValue As String = CorrectLikeValue(dataType, value)
        Return String.Format("{0} LIKE {1}", FieldName, likeValue)
    End Function

    Public Shared Function CreateHardLikeCondition(ByVal FieldName As String, ByVal dataType As Type, ByVal value As String) As String
        FieldName = GetConditionFieldName(FieldName, dataType)
        Dim likeValue As String = CorrectLikeValue(dataType, value)
        Return String.Format("{0} LIKE {1}", FieldName, likeValue)

    End Function

    Private Shared Function FixLikeTextForDates(ByVal text As String, ByVal datatype As Type) As String

        If datatype Is GetType(DateTime) Then
            Dim dt As Date
            If DateTime.TryParse(text, dt) Then
                Return dt.ToString("yyyyMMdd")
            End If

            Dim dateSeparator As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
            Dim format As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Dim formatParts() As String = format.Split(dateSeparator.ToCharArray())
            Dim dateParts() As String = text.Split(dateSeparator.ToCharArray())
            Dim yearPart As String = ""
            Dim monthPart As String = ""
            Dim dayPart As String = ""
            For i As Integer = 0 To dateParts.Length - 1
                Select Case formatParts(i).ToLowerInvariant().Chars(0)
                    Case "y"c
                        yearPart = dateParts(i)
                    Case "m"c
                        monthPart = dateParts(i)
                    Case "d"c
                        dayPart = dateParts(i)
                End Select
            Next
            Return String.Format("{0}{1}{2}", yearPart, monthPart, dayPart)
        Else
            Return text '.Replace("%", "[%]")
        End If
    End Function

#End Region

#Region "SQL parsing"

    Private Function SkipWord(ByVal str As String) As Integer
        Dim i As Integer = 0
        Do While i < str.Length And Mid(str, i + 1, 1) <= " "
            i = i + 1
        Loop
        Do While i < str.Length And Mid(str, i + 1, 1) > " "
            i = i + 1
        Loop
        Do While i < str.Length And Mid(str, i + 1, 1) <= " "
            i = i + 1
        Loop
        Return i
    End Function

    Private Sub ParseOrder()
        m_OrderField = m_OrderCondition
        If m_OrderCondition Is Nothing Then Return
        Dim tmp As String = m_OrderCondition.ToLower(Globalization.CultureInfo.InvariantCulture)
        Dim start As Integer = SkipWord(tmp)
        Dim pos As Integer = tmp.IndexOf("asc", start)
        If pos >= 0 Then
            m_OrderField = m_OrderField.Remove(pos, 3)
            tmp = tmp.Remove(pos, 3)
        End If

        pos = tmp.IndexOf("desc", start)
        If pos >= 0 Then
            m_OrderField = m_OrderField.Remove(pos, 4)
            m_OrderOperation = "<"
        Else
            m_OrderOperation = ">"
        End If
        m_OrderField = m_OrderField.Trim()
    End Sub

    Private Function BuildSql() As String
        Dim s As String = CType(IIf(m_Distinct, "SELECT DISTINCT", "SELECT"), String)
        If TopCount > 0 Then s = s + " TOP " + TopCount.ToString()
        s = s + " " + m_SelectStr + " FROM " + m_FromStr + " "

        If Not m_WhereStr Is Nothing And m_WhereStr <> "" Then s = s + " WHERE " + m_WhereStr
        If Not m_GroupByStr Is Nothing And m_GroupByStr <> "" Then s = s + " GROUP BY " + m_GroupByStr
        If Not m_OrderCondition Is Nothing And m_OrderCondition <> "" Then s = s + " ORDER BY " + m_OrderCondition

        Return s
    End Function

    Private Function IsNeedQuote(ByVal t As DbType) As Boolean
        Select Case t
            Case DbType.AnsiString, _
                    DbType.AnsiStringFixedLength, _
                    DbType.Date, _
                    DbType.DateTime, _
                    DbType.Guid, _
                    DbType.String, _
                    DbType.StringFixedLength, _
                    DbType.Time
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Shared Function IsNeedQuote(ByVal t As Type) As Boolean
        Select Case t.Name
            Case "String", _
                    "DateTime", _
                    "Guid"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private ptr As Integer
    Private m_End As Integer
    Private Function ParseSQL() As Boolean
        ptr = 0
        If find("select") < 0 Then Return False
        Dim start As Integer = ptr
        If find("from") < 0 Then Return False
        m_SelectStr = m_SelectSql.Substring(start, m_End - start).Trim()
        If m_SelectStr.Length >= 8 AndAlso m_SelectStr.Substring(0, 8).ToLower(Globalization.CultureInfo.InvariantCulture) = "distinct" Then
            m_SelectStr = m_SelectStr.Substring(8).TrimStart()
            m_Distinct = True
        Else
            m_Distinct = False
        End If
        Return ParseWhere(m_FromStr)
    End Function

    Private Function ParseWhere(ByRef par As String) As Boolean
        Dim start As Integer = ptr
        If find("where") < 0 Then
            ptr = start
            Return ParseGroup(par)
        End If

        par = m_SelectSql.Substring(start, m_End - start).Trim()
        Return ParseGroup(m_WhereStr)
    End Function

    Private Function ParseGroup(ByRef par As String) As Boolean
        Dim start As Integer = ptr
        If find("group by") < 0 Then
            ptr = start
            Return ParseOrder(par)
        End If
        par = m_SelectSql.Substring(start, m_End - start).Trim()
        Return ParseOrder(m_GroupByStr)
    End Function

    Private Function ParseOrder(ByRef par As String) As Boolean
        Dim start As Integer = ptr
        If find("order by") < 0 Then
            par = m_SelectSql.Substring(start, m_End - start).Trim()
            Return True
        End If
        par = m_SelectSql.Substring(start, m_End - start).Trim()
        Order = m_SelectSql.Substring(ptr, m_SelectSql.Length - ptr).Trim()
        Return True
    End Function

    Private Function find(ByVal ParamArray findstring() As String) As Integer
        While (True)
            Dim flag As Boolean = False
            Dim i As Integer
            For i = 0 To findstring.Length - 1
                If (m_SelectSql.Length - ptr >= findstring(i).Length) Then
                    flag = True
                    Dim s As String = m_SelectSql.Substring(ptr, findstring(i).Length).ToLower(Globalization.CultureInfo.InvariantCulture)
                    If (s.CompareTo(findstring(i)) = 0) Then
                        m_End = ptr
                        ptr = ptr + s.Length
                        Return i
                    End If
                End If
            Next
            If Not flag Then
                m_End = m_SelectSql.Length
                Return -1
            End If
            ptr = ptr + 1
        End While
    End Function
#End Region

End Class
