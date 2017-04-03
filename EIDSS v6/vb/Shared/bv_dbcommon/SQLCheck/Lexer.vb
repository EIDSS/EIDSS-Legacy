Option Strict On
Imports System.Text.RegularExpressions

Namespace SQLCheck

    Class Lexer
        Private Const MaxTokenLength As Integer = 1024
        Private Shared quotedFieldIdRx As New Regex("\G\[[^\]]+\](?:\.(?:\[[^\]]+\]|\w+))*")
        Private Shared fieldIdRx As New Regex("\G(?:@\w+|\w+(?:\.(?:\[[^\]]+\]|\w+))+)")
        Private Shared wordRx As New Regex("\G?\w+")
        Private Shared stringRx As New Regex("\G[Nn]?'[^']*(''[^']*)*'")
        Private Shared numberRx As New Regex("\G(\d*\.)?\d+([Ee][-+]?\d+)?")

        Private m_idx As Integer
        Private m_tokens() As Token
        Private m_source As Source

        Public Sub New(ByVal source As Source)
            m_source = source
            m_tokens = Nothing
        End Sub

        Public ReadOnly Property Source() As Source
            Get
                Return m_source
            End Get
        End Property

        Public Function Peek() As Token
            If m_tokens Is Nothing Then LexSource()
            Debug.Assert(m_idx <= m_tokens.Length, "token index")
            Dim token As token = m_tokens(m_idx)
            token.Reached = True
            Return token
        End Function

        Public Function Read() As Token
            Dim token As token = Peek()
            If m_idx + 1 < m_tokens.Length Then
                m_idx += 1
            End If
            Return token
        End Function

        Public Sub GoBack(ByVal token As Token)
            Dim index As Integer = token.Index
            Debug.Assert(index >= 0 AndAlso index < m_tokens.Length AndAlso index <= m_idx, _
                "lexer internal error: GoBack: invalid token index")
            m_idx = index
        End Sub

        Public Function GetLastReachedToken() As Token
            If m_tokens Is Nothing Then Return Nothing
            Debug.Assert(m_tokens.Length > 0 AndAlso m_tokens(0).Reached, "token list")
            Dim I As Integer = 0
            While True
                If I = m_tokens.Length - 1 OrElse Not m_tokens(I + 1).Reached Then
                    Exit While
                End If
                I += 1
            End While
            Return m_tokens(I)
        End Function

        Private Sub LexSource()
            Dim token As token
            Dim tokens As New ArrayList
            Dim index As Integer = 0
            Do
                m_source.SkipWhiteSpace()
                token = LexNext(index)
                tokens.Add(token)
                index += 1
            Loop Until token.Type = TokenType.Eof OrElse _
                       token.Type = TokenType.InvalidCharacter OrElse _
                       token.Type = TokenType.ReservedKeyword
            m_idx = 0
            m_tokens = CType(tokens.ToArray(GetType(token)), token())
        End Sub

        Private Function LexNext(ByVal index As Integer) As Token
            Dim pos As Integer = m_source.Position
            If m_source.AtEof Then Return New Token(TokenType.Eof, index, pos)

            Dim match As Match = Nothing
            Dim simpleTokenValue As String = Nothing
            Dim ttype As TokenType = CheckSimpleTokens(simpleTokenValue)
            If ttype <> TokenType.None Then
                If simpleTokenValue.Length > MaxTokenLength Then
                    Return New Token(TokenType.TooLong, index, pos, "")
                End If
                Return New Token(ttype, index, pos, simpleTokenValue)
            Else
                If m_source.CheckRegex(stringRx, match) Then
                    ttype = TokenType.TextString
                ElseIf m_source.CheckRegex(numberRx, match) Then
                    ttype = TokenType.Number
                ElseIf m_source.CheckRegex(quotedFieldIdRx, match) OrElse _
                        m_source.CheckRegex(fieldIdRx, match) Then
                    ttype = TokenType.Identifier
                ElseIf m_source.CheckRegex(wordRx, match) Then
                    ttype = CheckWordTokens(match.Value)
                    If ttype = TokenType.None Then
                        If ReservedKeywords.IsDataType(match.Value) Then
                            ttype = TokenType.DataType
                        ElseIf ReservedKeywords.IsReserved(match.Value) Then
                            ttype = TokenType.ReservedKeyword
                        Else
                            ttype = TokenType.Identifier
                        End If
                    End If
                Else
                    Return New Token(TokenType.InvalidCharacter, index, pos, "")
                End If
            End If

            If match.Value.Length > MaxTokenLength Then
                Return New Token(TokenType.TooLong, index, pos, "")
            End If

            Debug.Assert(ttype = TokenType.InvalidCharacter OrElse _
                         (Not match Is Nothing AndAlso match.Success), "match success")
            Return New Token(ttype, index, pos, match.Value)
        End Function

        Private Function CheckSimpleTokens(ByRef value As String) As TokenType
            Static corr(,) As Object = { _
                {"(", TokenType.LeftParen}, _
                {")", TokenType.RightParen}, _
                {",", TokenType.Comma}, _
                {"=", TokenType.EQ}, _
                {"+", TokenType.Plus}, _
                {"-", TokenType.Minus}, _
                {"*", TokenType.Asterisk}, _
                {"/", TokenType.Div}, _
                {New Regex("\G<\s*>"), TokenType.NE}, _
                {New Regex("\G!\s*="), TokenType.NE}, _
                {New Regex("\G>\s*="), TokenType.GE}, _
                {New Regex("\G!\s*<"), TokenType.GE}, _
                {New Regex("\G<\s*="), TokenType.LE}, _
                {New Regex("\G!\s*>"), TokenType.LE}, _
                {">", TokenType.GT}, _
                {"<", TokenType.LE} _
            }

            Dim I As Integer
            For I = 0 To corr.GetLength(0) - 1
                Dim o As Object = corr(I, 0)
                If TypeOf o Is String Then
                    Dim str As String = CType(o, String)
                    If m_source.CheckString(str) Then
                        value = str
                        Return CType(corr(I, 1), TokenType)
                    End If
                Else
                    Debug.Assert(TypeOf o Is Regex, "simple token")
                    Dim match As Match = Nothing
                    If m_source.CheckRegex(CType(o, Regex), match) Then
                        value = match.Value
                        Return CType(corr(I, 1), TokenType)
                    End If
                End If
            Next
            Return TokenType.None
        End Function

        Private Function CheckWordTokens(ByVal word As String) As TokenType
            Select Case word.ToUpper(Globalization.CultureInfo.InvariantCulture)
                Case "AND"
                    Return TokenType.And
                Case "OR"
                    Return TokenType.Or
                Case "NOT"
                    Return TokenType.Not
                Case "LIKE"
                    Return TokenType.Like
                Case "ISNULL"
                    Return TokenType.IsNull
                Case "CAST"
                    Return TokenType.Cast
                Case "CONVERT"
                    Return TokenType.Convert
                Case "AS"
                    Return TokenType.As
                Case "DATEDIFF"
                    Return TokenType.DateDiff
                Case "ABS"
                    Return TokenType.Abs
                Case "UPPER"
                    Return TokenType.Upper
                Case "LOWER"
                    Return TokenType.Lower
                Case "NULL"
                    Return TokenType.Null
                Case "FREETEXT"
                    Return TokenType.FreeText
                Case "ESCAPE"
                    Return TokenType.Escape
                Case "IN"
                    Return TokenType.In
                Case "IS"
                    Return TokenType.Is
                Case "BETWEEN"
                    Return TokenType.Between
                Case "ASC"
                    Return TokenType.Asc
                Case "DESC"
                    Return TokenType.Desc
                Case Else
                    Return TokenType.None
            End Select
        End Function
    End Class

End Namespace