Namespace SQLCheck
    Class WhereCondParser
        Inherits Parser

        Sub New(ByVal lexer As Lexer)
            MyBase.New(lexer)
        End Sub

        Protected Overrides Function ParseTopLevelExpression() As Boolean
            Return ParseCondExpression()
        End Function

        Private Function ParseCondExpression() As Boolean
            If Not ParseTerm() Then Return False

            Dim start As Token = Peek()
            While ParseBinaryLogOp()
                If ParseTerm() Then
                    start = Peek()
                Else
                    GoBack(start)
                    Exit While
                End If
            End While
            Return True
        End Function

        Private Function ParseBinaryLogOp() As Boolean
            Return Take(TokenType.And, TokenType.Or)
        End Function

        Private Function ParseTerm() As Boolean
            Dim start As Token = Peek()
            Take(TokenType.Not)
            Dim pointA As Token = Peek()

            If Take(TokenType.LeftParen) Then
                If Not ParseCondExpression() OrElse Not Take(TokenType.RightParen) Then
                    GoBack(pointA)
                Else
                    Return True
                End If
            End If

            If ParseFreetextExpression() Then
                Return True
            End If

            If Not ParseValueExpression() Then
                Return False
            End If

            If ParseLikeExpression() OrElse _
               ParseBetweenExpression() OrElse _
               ParseIsExpression() OrElse _
               ParseInExpression() Then
                Return True
            End If

            If Not ParseCmpOp() OrElse Not ParseValueExpression() Then
                GoBack(start)
                Return False
            End If
            Return True
        End Function

        Private Function ParseLikeExpression() As Boolean
            Dim start As Token = Peek()
            Take(TokenType.Not)
            If Not Take(TokenType.Like) OrElse Not Take(TokenType.TextString) Then
                GoBack(start)
                Return False
            End If

            Dim escPoint As Token = Peek()
            If escPoint.Type = TokenType.Escape Then
                Read()
                Dim strExpr As Token = Read()
                If strExpr.Type <> TokenType.TextString OrElse _
                   (strExpr.Value <> "''''" AndAlso strExpr.Value.Length <> 3) Then
                    GoBack(escPoint)
                End If
            End If

            Return True
        End Function

        Private Function ParseBetweenExpression() As Boolean
            Dim start As Token = Peek()
            Take(TokenType.Not)
            If Not Take(TokenType.Between) OrElse _
               Not ParseValueExpression() OrElse _
               Not Take(TokenType.And) OrElse _
               Not ParseValueExpression() Then
                GoBack(start)
                Return False
            End If

            Return True
        End Function

        Private Function ParseIsExpression() As Boolean
            Dim start As Token = Peek()
            If start.Type <> TokenType.Is Then
                Return False
            End If

            Read()
            Take(TokenType.Not)
            If Not Take(TokenType.Null) Then
                GoBack(start)
                Return False
            End If

            Return True
        End Function

        Private Function ParseFreetextExpression() As Boolean
            Dim start As Token = Peek()
            If Not start.Type = TokenType.FreeText Then
                Return False
            End If
            Read()
            If Not Take(TokenType.LeftParen) Then
                GoBack(start)
                Return False
            End If
            Dim colspec As Token = Read()
            If (colspec.Type <> TokenType.Identifier AndAlso _
                colspec.Type <> TokenType.Asterisk) OrElse _
               Not Take(TokenType.Comma) OrElse _
               Not Take(TokenType.TextString) OrElse _
               Not Take(TokenType.RightParen) Then
                GoBack(start)
                Return False
            End If

            Return True
        End Function

        Private Function ParseInExpression() As Boolean
            Dim start As Token = Peek()
            Take(TokenType.Not)
            If Not Take(TokenType.In) OrElse _
               Not Take(TokenType.LeftParen) OrElse _
               Not ParseValueExpression() Then
                GoBack(start)
                Return False
            End If

            While Take(TokenType.Comma)
                If Not ParseValueExpression() Then
                    GoBack(start)
                    Return False
                End If
            End While

            If Not Take(TokenType.RightParen) Then
                GoBack(start)
                Return False
            End If

            Return True
        End Function

        Private Function ParseCmpOp() As Boolean
            Return Take(TokenType.EQ, TokenType.NE, TokenType.LT, TokenType.GT, _
                        TokenType.LE, TokenType.GE)
        End Function

        Private Function ParseValueExpression() As Boolean
            If Not ParseValueTerm() Then Return False

            Dim start As Token = Peek()
            While ParseBinaryValueOp()
                If ParseValueTerm() Then
                    start = Peek()
                Else
                    GoBack(start)
                    Exit While
                End If
            End While
            Return True
        End Function

        Private Function ParseBinaryValueOp() As Boolean
            Return Take(TokenType.Plus, TokenType.Minus, TokenType.Asterisk, TokenType.Div)
        End Function

        Private Function ParseValueTerm() As Boolean
            Dim start As Token = Peek()
            Dim hasSign As Boolean = Take(TokenType.Minus, TokenType.Plus)

            Dim success As Boolean = False
            Select Case Read.Type()
                Case TokenType.LeftParen
                    success = (ParseValueExpression() AndAlso Take(TokenType.RightParen))
                Case TokenType.TextString
                    success = Not hasSign
                Case TokenType.Number, TokenType.Null
                    success = True
                Case TokenType.Identifier
                    If Peek().Type = TokenType.LeftParen Then
                        success = ParseFunctionArgs()
                    Else
                        success = True
                    End If
                Case TokenType.Abs, TokenType.Upper, TokenType.Lower
                    success = NBParseUnaryFunctionArgs()
                Case TokenType.IsNull
                    success = NBParseBinaryFunctionArgs()
                Case TokenType.DateDiff
                    success = NBParseTernaryFunctionArgs()
                Case TokenType.Cast
                    success = NBParseCastArgs()
                Case TokenType.Convert
                    success = NBParseConvertArgs()
            End Select

            If Not success Then
                GoBack(start)
                Return False
            End If

            Return True
        End Function

        ' note that NB* don't do backtracking
        Function NBParseUnaryFunctionArgs() As Boolean
            Return Take(TokenType.LeftParen) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.RightParen)
        End Function

        Function NBParseBinaryFunctionArgs() As Boolean
            Return Take(TokenType.LeftParen) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.Comma) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.RightParen)
        End Function

        Function NBParseTernaryFunctionArgs() As Boolean
            Return Take(TokenType.LeftParen) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.Comma) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.Comma) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.RightParen)
        End Function

        Function ParseFunctionArgs() As Boolean
            If Not Take(TokenType.LeftParen) Then
                Return False
            End If
            While (ParseValueExpression())
                If Not Take(TokenType.Comma) Then
                    If Take(TokenType.RightParen) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End While
            Return False
        End Function
        Function NBParseCastArgs() As Boolean
            Return Take(TokenType.LeftParen) AndAlso _
                   ParseValueExpression() AndAlso _
                   Take(TokenType.As) AndAlso _
                   NBParseTypeSpec() AndAlso _
                   Take(TokenType.RightParen)
        End Function

        Function NBParseConvertArgs() As Boolean
            Return Take(TokenType.LeftParen) AndAlso _
                    NBParseTypeSpec() AndAlso _
                    Take(TokenType.Comma) AndAlso _
                    ParseValueExpression() AndAlso _
                   (Not Take(TokenType.Comma) OrElse _
                    NBParseIntegerNumber()) AndAlso _
                   Take(TokenType.RightParen)
        End Function

        Function NBParseTypeSpec() As Boolean
            Return Take(TokenType.DataType) AndAlso _
                   (Not Take(TokenType.LeftParen) OrElse _
                    (NBParseIntegerNumber() AndAlso _
                    Take(TokenType.RightParen)))
        End Function

        Function NBParseIntegerNumber() As Boolean
            Dim token As token = Peek()
            If token.Type = TokenType.Number AndAlso IsInteger(token.Value) Then
                Read()
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
