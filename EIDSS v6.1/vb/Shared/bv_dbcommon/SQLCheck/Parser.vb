Option Strict On
Imports System.Text.RegularExpressions

Namespace SQLCheck

    MustInherit Class Parser
        Private m_lexer As Lexer

        Protected Sub New(ByVal lexer As Lexer)
            m_lexer = lexer
        End Sub

        Public Function Parse() As String
            If Not ParseTopLevelExpression() OrElse Peek().Type <> TokenType.Eof Then
                Return BuildErrorMessage()
            End If
            ' parsing successful
            Return Nothing
        End Function

        Private Function BuildErrorMessage() As String
            Dim tokenDesc As String
            Dim lastToken As Token = m_lexer.GetLastReachedToken()
            If lastToken.Value <> "" Then
                tokenDesc = String.Format("{0} '{1}'", lastToken.Type.ToString(), lastToken.Value)
            Else
                tokenDesc = lastToken.Type.ToString()
            End If

            Return "Parse error at " & tokenDesc & vbCrLf & _
                   m_lexer.Source.ToString() & vbCrLf & _
                   New String(" "c, lastToken.Position) & "^"
        End Function

        Protected Function Peek() As Token
            Return m_lexer.Peek()
        End Function

        Protected Function Read() As Token
            Return m_lexer.Read()
        End Function

        Protected Sub GoBack(ByVal token As Token)
            m_lexer.GoBack(token)
        End Sub

        Protected Shared Function IsInteger(ByVal str As String) As Boolean
            Static rx As New Regex("^\d+$")
            Return rx.IsMatch(str)
        End Function

        Protected Function Take(ByVal ParamArray ttypes() As TokenType) As Boolean
            Dim ptype As TokenType = Peek().Type
            Dim ttype As TokenType
            For Each ttype In ttypes
                If ttype = ptype Then
                    Read()
                    Return True
                End If
            Next

            Return False
        End Function

        Protected MustOverride Function ParseTopLevelExpression() As Boolean
    End Class

End Namespace
