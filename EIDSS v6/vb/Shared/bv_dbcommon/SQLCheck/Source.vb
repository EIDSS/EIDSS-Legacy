Option Strict On
Imports System.Text.RegularExpressions

Namespace SQLCheck

    Class Source
        Private m_pos As Integer
        Private m_data As String

        Public Sub New(ByVal data As String)
            m_data = data
            m_pos = 0
        End Sub

        Public Function CheckRegex(ByVal rx As Regex, ByRef match As Match) As Boolean
            If m_pos >= m_data.Length Then Return False
            match = rx.Match(m_data, m_pos)
            If match.Success Then
                m_pos += match.Length
                Return True
            Else
                Return False
            End If
        End Function

        Public Function CheckString(ByVal str As String, Optional ByVal ignoreCase As Boolean = True) As Boolean
            Dim len As Integer = str.Length
            If m_pos + len > m_data.Length Then Return False
            Dim substr As String = m_data.Substring(m_pos, len)
            If String.Compare(substr, str, ignoreCase) = 0 Then
                m_pos += len
                Return True
            End If
            Return False
        End Function

        Public Overrides Function ToString() As String
            Return m_data
        End Function

        Public Sub SkipWhiteSpace()
            While m_pos < m_data.Length AndAlso Char.IsWhiteSpace(m_data, m_pos)
                m_pos += 1
            End While
        End Sub

        Public ReadOnly Property AtEof() As Boolean
            Get
                Return m_pos >= m_data.Length
            End Get
        End Property

        Public ReadOnly Property Position() As Integer
            Get
                Return m_pos
            End Get
        End Property
    End Class

End Namespace