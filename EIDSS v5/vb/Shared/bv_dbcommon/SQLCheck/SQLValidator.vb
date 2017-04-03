Option Strict On
Imports System.Text.RegularExpressions

Namespace SQLCheck

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Provides the set of shared methods that can be used to validate different parts of SQL statement
    ''' against correct syntax and SQL injection.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class SQLValidator
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Validates WHERE clause against correct syntax and SQL injection.
        ''' </summary>
        ''' <param name="whereCond">
        ''' the filter condition to validate
        ''' </param>
        ''' <remarks>
        ''' If passed <paramref name="whereCond"/> contains the errors, the <see cref="SQLCheck.SQLValidationException"/> is thrown.
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Sub ValidateWhereCondition(ByVal whereCond As String)
            If whereCond Is Nothing Then Return
            Dim parser As New WhereCondParser(MakeLexer(whereCond))
            Dim msg As String = parser.Parse()
            If Not msg Is Nothing Then
                Throw New SQLValidationException(msg)
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Validates ORDER BY clause against correct syntax and SQL injection.
        ''' </summary>
        ''' <param name="orderByCond">
        ''' the sorting expression to validate
        ''' </param>
        ''' <remarks>
        ''' If passed <paramref name="orderByCond"/> contains the errors, the <see cref="SQLCheck.SQLValidationException"/> is thrown.
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Sub ValidateOrderByCondition(ByVal orderByCond As String)
            If orderByCond Is Nothing Then Return
            Dim parser As New OrderByCondParser(MakeLexer(orderByCond))
            Dim msg As String = parser.Parse()
            If Not msg Is Nothing Then
                Throw New SQLValidationException(msg)
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Checks if SQL identifier matches SQL naming convention
        ''' </summary>
        ''' <param name="str">
        ''' SQL identifier to validate
        ''' </param>
        ''' <remarks>
        ''' If passed <paramref name="str"/> contains the errors, the <see cref="SQLCheck.SQLValidationException"/> is thrown.
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Sub ValidateSimpleIdentifier(ByVal str As String)
            Static idRx As New Regex("^\w+$")
            If Not idRx.IsMatch(str) Then
                Throw New SQLValidationException(String.Format("Invalid identifier: {0}", str))
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Escapes the passed string replacing all single quotes with double quotes to prevent SQL injection
        ''' </summary>
        ''' <param name="str">
        ''' string to escape
        ''' </param>
        ''' <param name="addQuotes">
        ''' indicates should the returned string enclosed with quotes or no.
        ''' </param>
        ''' <returns>
        ''' Returns escaped string
        ''' </returns>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function EscapeSQLString(ByVal str As String, Optional ByVal addQuotes As Boolean = True) As String
            str = str.Replace("'", "''")
            If addQuotes Then
                Return "'" + str + "'"
            Else
                Return str
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Encloses passed SQL identifier with <b>[]</b> brackets if needed.
        ''' </summary>
        ''' <param name="str">
        ''' SQL identifier to escape
        ''' </param>
        ''' <returns>
        ''' Returns escaped SQL identifier.
        ''' </returns>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function EscapeIdentifier(ByVal str As String) As String
            Static quotedIdRx As New Regex("^\[[^\]]+\]$")
            If quotedIdRx.IsMatch(str) Then Return str
            If str.IndexOfAny(New Char() {"["c, "]"c}) >= 0 Then
                Throw New SQLValidationException("Invalid (unquotable) identifier: '" & str + "'")
            End If
            Return String.Format("[{0}]", str)
        End Function

        Private Shared Function MakeLexer(ByVal str As String) As Lexer
            Dim source As New source(str)
            Return New Lexer(source)
        End Function
    End Class

    ''' -----------------------------------------------------------------------------
    ''' Project	 : bvdb_common
    ''' Class	 : common.db.SQLCheck.SQLValidationException
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The exception that is thrown when parsed SQL statement contains syntax errors
    ''' </summary>
    ''' <remarks>
    ''' <i>SQLValidationException</i> is trown by the <see cref="SQLValidator"/> class if parsed 
    ''' SQL clause contains the syntax errors.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	19.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class SQLValidationException
        Inherits Exception

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SQLValidationException"/> class.
        ''' </summary>
        ''' <param name="message">
        ''' the message that will describe the <see cref="SQLValidationException"/>
        ''' </param>
        ''' <history>
        ''' 	[Mike]	19.04.2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace
