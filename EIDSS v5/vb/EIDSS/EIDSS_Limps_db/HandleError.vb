Public Class HandleError

    Public Shared Function ErrorMessage(ByVal err As Exception, Optional ByVal barCode As String = "") As ErrorMessage
        Dim space As System.Data.SqlClient.SqlException = TryCast(err, System.Data.SqlClient.SqlException)
        If space Is Nothing Then Return New ErrorMessage(err)
        If space.Number = 50000 And space.Class = 16 Then
            Dim strings As String() = space.Message.Split(" "c)
            Dim copy As String() = New String() {}
            Array.Resize(copy, strings.Length - 1)
            'Dim copy As String() = Array.CreateInstance(GetType(String), strings.Length - 1)
            'Array.Copy(strings, 1, copy, 0, strings.Length - 1)
            'Dim copy As System.Array = Array.CreateInstance(GetType(String), strings.Length - 1)
            'Array.Copy(strings, 1, copy, 0, strings.Length - 1)
            Array.Copy(strings, 1, copy, 0, strings.Length - 1)
            Dim errid As String = strings(0)

            Return New ErrorMessage(errid, errid, Nothing, copy)
        ElseIf space.Number = 2601 Then
            If space.Procedure = "spLabSampleReceive_PostDetail" AndAlso space.Message.Contains("strBarcode") Then 'This is unworking now because material.strBarcode ahs no unique index 
                Return New ErrorMessage("ErrExistingBarcode", "Sample with Lab Sample ID '{0}' already exists in the system. Please enter unique Lab Sample ID value.", Nothing, barCode)
            ElseIf space.Message.Contains("IX_tlbTransferOUT_strBarcode_Unique") Then
                Return New ErrorMessage("errNonUniqueSampleTransferID", "Sample with Sample Transfer ID '{0}' already exists in the system. Please enter unique Sample Transfer ID value.", Nothing, barCode)
            End If
        End If

        Return New ErrorMessage(err)
    End Function

End Class