Namespace SQLCheck
    Class OrderByCondParser
        Inherits Parser

        Sub New(ByVal lexer As Lexer)
            MyBase.New(lexer)
        End Sub

        Protected Overrides Function ParseTopLevelExpression() As Boolean
            Return ParseOrderByExpression()
        End Function

        Private Function ParseOrderByExpression() As Boolean
            Dim start As Token = Peek()
            If Not ParseColSpec() Then Return False
            Dim pointA As Token = Peek()
            While Take(TokenType.Comma)
                If Not ParseColSpec() Then
                    GoBack(pointA)
                    Return True
                End If
                pointA = Peek()
            End While

            Return True
        End Function

        Private Function ParseColSpec() As Boolean
            If Not Peek().Type = TokenType.Identifier Then
                Return False
            End If

            Read()
            Take(TokenType.Asc, TokenType.Desc)
            Return True
        End Function
    End Class
End Namespace
