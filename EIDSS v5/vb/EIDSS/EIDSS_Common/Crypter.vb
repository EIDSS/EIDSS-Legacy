Imports System.Security.Cryptography
Imports System.Text
Public Enum CryptoMethod
    Simple
    Rijndael
End Enum
Public Class Crypter
    Const charset As String = "0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ"
    Const AllowedSymbols As String = "^M=UPW03EN9IR~T6DVFQ5YAS8*7BOG4HJKLZ2XC(./\1-)"
    Const Method As CryptoMethod = CryptoMethod.Simple
    Shared Function DecToNewBase(ByVal dec As Integer, ByVal base As Integer) As String
        If dec = 0 Then Return charset.Chars(0)
        Dim res As String = ""
        Dim rest As Integer
        While dec > 0
            rest = dec Mod base
            dec = (dec - rest) \ base
            res = charset.Chars(rest) + res
            If (dec > 1 AndAlso dec < base) Then
                res = charset.Chars(dec) + res
                Exit While
            End If
        End While
        Return res
    End Function
    Shared Function BaseStringToInt(ByVal baseStr As String, ByVal base As Integer) As Integer
        Dim k As Integer = 0
        Dim res As Integer = 0
        Dim order As Long = 1
        For i As Integer = baseStr.Length - 1 To 0 Step -1
            res += CInt(order) * charset.IndexOf(baseStr.Chars(i))
            order = order * base
        Next
        Return res
    End Function

    Public Shared Function ConvertStringToByteArray(ByVal s As [String]) As [Byte]()
        Return (New ASCIIEncoding).GetBytes(s)
    End Function 'ConvertStringToByteArray

    Public Shared Function Encode(ByVal s As String) As String
        Select Case Method
            Case CryptoMethod.Simple
                Dim ds As String = Encode2(s)
                If Decode2(ds).ToUpper(Globalization.CultureInfo.InvariantCulture) <> s.ToUpper(Globalization.CultureInfo.InvariantCulture) Then
                    Throw New Exception("Data encoding error: data lost during decoding")
                End If
                Return ds
        End Select
        Return ""
    End Function

    Public Shared Function Decode(ByVal s As String) As String
        Select Case Method
            Case CryptoMethod.Simple
                Return Decode2(s)
        End Select
        Return ""
    End Function
    Const MaxCodeGroupCount As Integer = 10
    Shared Function Encode2(ByVal s As String) As String
        Dim Signature As Integer = 0
        Dim Signature1 As Integer = 0
        Dim k(MaxCodeGroupCount) As Integer
        s = s.ToUpper(Globalization.CultureInfo.InvariantCulture)
        Dim res As String = ""
        Dim idx As Integer
        For j As Integer = 0 To MaxCodeGroupCount
            For i As Integer = 0 To 4
                idx = 5 * j + i
                If idx >= s.Length Then Exit For
                Dim n As Integer = AllowedSymbols.IndexOf(s.Chars(idx))
                k(j) += n << 6 * i
            Next
            res += DecToNewBase(k(j), charset.Length).PadLeft(6, charset.Chars(0))
            If idx >= s.Length Then Exit For
        Next
        Return res
    End Function

    Shared Function Decode2(ByVal s As String) As String
        Dim res As String = ""
        For i As Integer = 0 To MaxCodeGroupCount
            If i * 6 >= s.Length Then Exit For
            Dim s1 As String = s.Substring(i * 6, 6).TrimStart(charset.Chars(0))
            Dim n As Integer
            n = BaseStringToInt(s1, charset.Length)
            For j As Integer = 0 To 4
                Dim k As Integer = (n >> (6 * j)) And 63
                If k > 0 Then
                    res += AllowedSymbols.Chars(k)
                End If
            Next
        Next
        Return res
    End Function

End Class
