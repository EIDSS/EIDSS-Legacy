Public Interface IValidator
    Sub RegisterValidator(ByVal baseForm As BaseForm, Optional ByVal validateOnFieldChange As Boolean = False)
    Function Validate(rowToValidate As DataRow, ByVal showError As Boolean) As Boolean
    Property Active As Boolean
End Interface
