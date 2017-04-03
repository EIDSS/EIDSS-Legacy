Option Strict On

Namespace SQLCheck

    Class ReservedKeywords
        Private Shared s_keywordsSrc() As String = { _
            "ADD", "ALL", "ALTER", "AND", "ANY", "AS", _
            "ASC", "AUTHORIZATION", "BACKUP", "BEGIN", "BETWEEN", "BREAK", _
            "BROWSE", "BULK", "BY", "CASCADE", "CASE", "CHECK", _
            "CHECKPOINT", "CLOSE", "CLUSTERED", "COALESCE", "COLLATE", "COLUMN", _
            "COMMIT", "COMPUTE", "CONSTRAINT", "CONTAINS", "CONTAINSTABLE", "CONTINUE", _
            "CONVERT", "CREATE", "CROSS", "CURRENT", "CURRENT_DATE", "CURRENT_TIME", _
            "CURRENT_TIMESTAMP", "CURRENT_USER", "CURSOR", "DATABASE", "DBCC", "DEALLOCATE", _
            "DECLARE", "DEFAULT", "DELETE", "DENY", "DESC", "DISK", _
            "DISTINCT", "DISTRIBUTED", "DOUBLE", "DROP", "DUMMY", "DUMP", _
            "ELSE", "END", "ERRLVL", "ESCAPE", "EXCEPT", "EXEC", _
            "EXECUTE", "EXISTS", "EXIT", "FETCH", "FILE", "FILLFACTOR", _
            "FOR", "FOREIGN", "FREETEXT", "FREETEXTTABLE", "FROM", "FULL", _
            "FUNCTION", "GOTO", "GRANT", "GROUP", "HAVING", "HOLDLOCK", _
            "IDENTITY", "IDENTITYCOL", "IDENTITY_INSERT", "IF", "IN", "INDEX", _
            "INNER", "INSERT", "INTERSECT", "INTO", "IS", "JOIN", _
            "KEY", "KILL", "LEFT", "LIKE", "LINENO", "LOAD", _
            "NATIONAL", "NOCHECK", "NONCLUSTERED", "NOT", "NULL", "NULLIF", _
            "OF", "OFF", "OFFSETS", "ON", "OPEN", "OPENDATASOURCE", _
            "OPENQUERY", "OPENROWSET", "OPENXML", "OPTION", "OR", "ORDER", _
            "OUTER", "OVER", "PERCENT", "PLAN", "PRECISION", "PRIMARY", _
            "PRINT", "PROC", "PROCEDURE", "PUBLIC", "RAISERROR", "READ", _
            "READTEXT", "RECONFIGURE", "REFERENCES", "REPLICATION", "RESTORE", "RESTRICT", _
            "RETURN", "REVOKE", "RIGHT", "ROLLBACK", "ROWCOUNT", "ROWGUIDCOL", _
            "RULE", "SAVE", "SCHEMA", "SELECT", "SESSION_USER", "SET", _
            "SETUSER", "SHUTDOWN", "SOME", "STATISTICS", "SYSTEM_USER", "TABLE", _
            "TEXTSIZE", "THEN", "TO", "TOP", "TRAN", "TRANSACTION", _
            "TRIGGER", "TRUNCATE", "TSEQUAL", "UNION", "UNIQUE", "UPDATE", _
            "UPDATETEXT", "USE", "USER", "VALUES", "VARYING", "VIEW", _
            "WAITFOR", "WHEN", "WHERE", "WHILE", "WITH", "WRITETEXT" _
        }

        Private Shared s_dataTypesSrc() As String = { _
            "BIGINT", "BINARY", "BIT", "CHAR", "DATETIME", "DECIMAL", _
            "FLOAT", "IMAGE", "INT", "MONEY", "NCHAR", "NTEXT", _
            "NUMERIC", "NVARCHAR", "REAL", "SMALLDATETIME", "SMALLINT", "SMALLMONEY", _
            "SQL_VARIANT", "SYSNAME", "TEXT", "TIMESTAMP", "TINYINT", "UNIQUEIDENTIFIER", _
            "VARBINARY", "VARCHAR" _
        }

        Private Shared s_keywords As Hashtable = Nothing
        Private Shared s_dataTypes As Hashtable = Nothing

        Private Shared Function PrepareTable(ByVal src() As String) As Hashtable
            Dim table As New Hashtable
            Dim word As String
            For Each word In src
                table.Add(word, True)
            Next
            Return table
        End Function

        Private Shared Sub PrepareTables()
            s_keywords = PrepareTable(s_keywordsSrc)
            s_dataTypes = PrepareTable(s_dataTypesSrc)
        End Sub

        Public Shared Function IsReserved(ByVal word As String) As Boolean
            If s_keywords Is Nothing Then
                PrepareTables()
            End If

            Return Not s_keywords(word.ToUpper(Globalization.CultureInfo.InvariantCulture)) Is Nothing
        End Function

        Public Shared Function IsDataType(ByVal word As String) As Boolean
            If s_dataTypes Is Nothing Then
                PrepareTables()
            End If

            Return Not s_dataTypes(word.ToUpper(Globalization.CultureInfo.InvariantCulture)) Is Nothing
        End Function
    End Class

End Namespace
