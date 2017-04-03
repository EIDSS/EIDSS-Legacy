Imports bv.common.Resources

Namespace Validators

    Public Class DateChainValidator
        Inherits ChainValidator(Of DateTime)
        Public Property CompareWithCurrentDate As Boolean
        Public Sub New(aOwner As BaseForm, aControl As Control, aTableName As String, aFieldName As String, aCaption As String, Optional aFilter As String = Nothing, Optional aStrict As Boolean = False, Optional aParentFilterTemplate As String = Nothing, Optional aCompareWithCurrentDate As Boolean = False, Optional aParentFilterKeyField As String = Nothing, Optional onAfterFieldChangeValidate As Action = Nothing)
            MyBase.New(aOwner, aControl, aTableName, aFieldName, aCaption, aFilter, aParentFilterTemplate, aStrict, aParentFilterKeyField, onAfterFieldChangeValidate)
            CompareWithCurrentDate = aCompareWithCurrentDate
        End Sub
        Protected Overrides Function ValidateMe(aRow As DataRow, showError As Boolean) As Boolean
            Dim result As Boolean = True
            If CompareWithCurrentDate Then
                If (Not aRow Is Nothing) Then
                    If (Not aRow(FieldName) Is DBNull.Value) Then
                        result = ValidateAgainstCurrentDate(aRow)
                    End If
                Else
                    For i As Integer = 0 To Count - 1
                        If (Row(i)(FieldName) Is DBNull.Value) Then
                            Continue For
                        End If
                        result = ValidateAgainstCurrentDate(Row(i))
                        If result = False Then
                            Exit For
                        End If
                    Next
                End If
                If Not result Then
                    DisplayError(showError)
                End If
            End If
            Return result
        End Function
        Private Function ValidateAgainstCurrentDate(aRow As DataRow) As Boolean

            Dim result As Boolean = Compare(DirectCast(aRow(FieldName), DateTime), Caption, Date.Today, BvMessages.Get("CurrentDate"), False)
            m_ErrorItem1 = Me
            'If result = False Then
            '    If aRow.HasVersion(DataRowVersion.Original) Then
            '        aRow(FieldName) = aRow(FieldName, DataRowVersion.Original)
            '    Else
            '        aRow(FieldName) = DBNull.Value
            '    End If
            '    aRow.EndEdit()
            'End If
            Return result
        End Function

        Protected Overrides Function Compare(x As DateTime, y As DateTime) As Boolean
            Return x.Date <= y.Date
        End Function
        Protected Overrides Function CompareStrict(x As DateTime, y As DateTime) As Boolean
            Return x.Date < y.Date
        End Function
        Protected Overrides Function Message(Optional aStrict As Boolean = False) As String
            If (aStrict) Then
                Return Messages.GetString("ErrStrictChainDate")
            Else
                Return Messages.GetString("ErrUnstrictChainDate")
            End If
        End Function

    End Class
End Namespace