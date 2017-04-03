Imports eidss.model.Enums
Imports eidss.model.Core
Imports System.Collections.Generic

Public Class MandatoryFieldHelper
    <CLSCompliant(False)>
    Public Shared Sub SetCustomMandatoryField(ctl As Control, fieldAlias As CustomMandatoryField)
        If EidssSiteContext.Instance.CustomMandatoryFields.Contains(fieldAlias) Then
            If (ctl.Tag Is Nothing) Then
                ctl.Tag = "{M}"
            Else
                Dim tag As New TagHelper(ctl)
                tag.IsMandatory = True
            End If
        End If
    End Sub
    <CLSCompliant(False)>
    Public Shared Sub SetCustomManadatoryFields(fields As Dictionary(Of Control, CustomMandatoryField))
        For Each ctl As Control In fields.Keys
            SetCustomMandatoryField(ctl, fields(ctl))
        Next
    End Sub
    <CLSCompliant(False)>
    Public Shared Sub SetCustomAddressMandatoryField(ctl As AddressLookup, fieldAlias As CustomMandatoryField, addressMandatoryField As AddressMandatoryFieldsType)
        If EidssSiteContext.Instance.CustomMandatoryFields.Contains(fieldAlias) Then
            ctl.MandatoryFields = addressMandatoryField
        End If
    End Sub

End Class
