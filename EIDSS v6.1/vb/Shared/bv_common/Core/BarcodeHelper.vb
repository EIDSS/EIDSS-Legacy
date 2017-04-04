Imports bv.common.Diagnostics
Namespace Core
    Public Class BarcodeHelper
        Public Shared Function AlphaToNumeric(ByVal alphaNum As String) As Long
            Dim result As Long = 0
            Dim firstCharFound As Boolean = False
            Dim i As Integer = 0
            Dim size As Integer = alphaNum.Length
            For i = 0 To alphaNum.Length - 1
                If alphaNum.Chars(i) <> "0"c Then
                    alphaNum = alphaNum.Remove(0, i)
                    Exit For
                End If
            Next
            If Utils.IsEmpty(alphaNum) Then
                Return 0
            End If
            Dim intRes As Integer = 0
            If Integer.TryParse(alphaNum, intRes) Then
                Return intRes
            End If
            Dim order As Long = 1
            Dim max As Long = 0
            For i = alphaNum.Length - 1 To 0 Step -1
                If i = 0 Then
                    Dbg.Assert(alphaNum.Chars(i) >= "A"c AndAlso alphaNum.Chars(i) <= "Z"c, "invalid barcode format")
                    result += (Asc(alphaNum.Chars(i)) - Asc("A"c)) * order + max
                ElseIf alphaNum.Chars(i) >= "A"c Then
                    Dbg.Assert(alphaNum.Chars(i) <= "Z"c, "invalid barcode format")
                    result += (Asc(alphaNum.Chars(i)) - Asc("A"c) + 10) * order
                Else
                    Dbg.Assert(alphaNum.Chars(i) >= "0"c AndAlso alphaNum.Chars(i) <= "9"c, "invalid barcode format")
                    result += (Asc(alphaNum.Chars(i)) - Asc("0"c)) * order
                End If
                max += 26 * order
                order *= 36
            Next
            result = GetMaxNumeric(size) + result + 1
            Return result
        End Function

        Public Shared Function NumericToAlpha(ByVal num As Long, ByVal size As Integer) As String
            Dim maxNumeric As Integer = GetMaxNumeric(size)
            If num <= maxNumeric Then
                Return num.ToString.PadLeft(size, "0"c)
            End If
            Dim reminder As Long = 0
            Dim result As String = ""
            num -= maxNumeric + 1
            While num >= 0
                If num < 26 Then
                    reminder = num Mod 26
                    result = Chr(Asc("A"c) + CInt(reminder)) + result
                    Exit While
                Else
                    reminder = (num - 26) Mod 36
                    num = (num - 26) \ 36
                    If reminder < 10 Then
                        result = Chr(Asc("0"c) + CInt(reminder)) + result
                    Else
                        result = Chr(Asc("A"c) + CInt(reminder) - 10) + result
                    End If
                End If
            End While
            Return result.PadLeft(size, "0"c)
        End Function
        Private Shared Function GetMaxNumeric(ByVal size As Integer) As Integer
            Dbg.Assert(size > 0, "barcode size must be > 0.")
            Return CInt("".PadLeft(size, "9"c))
        End Function

    End Class

End Namespace
