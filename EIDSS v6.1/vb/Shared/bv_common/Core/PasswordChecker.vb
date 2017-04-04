Imports System.Security.Cryptography
Imports System.Text
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Namespace Core
    Public Class PasswordChecker
        Public Sub New(ByVal minLength As Integer, ByVal requiredParts As String())
            m_MinPasswordLength = minLength
            If Not requiredParts Is Nothing Then
                For Each part As String In requiredParts
                    AddRequiredPart(part)
                Next
            End If
        End Sub
        Public Sub New()
            m_MinPasswordLength = 5
            AddRequiredPart("[a-z]")
            AddRequiredPart("[A-Z]")
            AddRequiredPart("[0-9]")
            AddRequiredPart("[!@#$%^&*()]")
        End Sub
        Public Shared Function GetPasswordHash(ByVal password As String, ByVal additionalKey As String) As String
            Dim hashProvider As New MD5CryptoServiceProvider
            Dim passwordBytes As Byte() = Encoding.Unicode.GetBytes(password + additionalKey)
            passwordBytes = hashProvider.ComputeHash(passwordBytes)
            Return Bytes2HexString(passwordBytes)
        End Function

        Private Shared Function Bytes2HexString(ByVal byteArray As Byte()) As String
            Dim builder As New StringBuilder
            builder.Append("0x")
            For Each b As Byte In byteArray
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString
        End Function

        Private m_MinPasswordLength As Integer = 5

        Public Property MinPasswordLength() As Integer
            Get
                Return m_MinPasswordLength
            End Get
            Set(ByVal Value As Integer)
                m_MinPasswordLength = Value
            End Set
        End Property

        Private m_RequiredParts As New List(Of String)

        Public ReadOnly Property RequiredParts() As List(Of String)
            Get
                Return m_RequiredParts
            End Get
        End Property

        Public Sub ClearRequiredParts()
            m_RequiredParts.Clear()
        End Sub

        Public Sub AddRequiredPart(ByVal part As String)
            m_RequiredParts.Add(part)
        End Sub

        Public Function ValidatePassword(ByVal password As String) As Integer
            If Utils.Str(password).Length < m_MinPasswordLength Then
                Return 1
            End If
            If m_RequiredParts.Count > 0 Then
                For Each part As String In m_RequiredParts
                    If Not Regex.IsMatch(password, part) Then
                        Return 2
                    End If
                Next
            End If
            Return 0
        End Function
    End Class
End Namespace