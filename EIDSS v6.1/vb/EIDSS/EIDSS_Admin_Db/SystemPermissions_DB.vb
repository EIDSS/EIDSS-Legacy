Public Class SystemPermissions_DB
    Inherits BaseDbService

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        Dim ds As DataSet = New DataSet()

        Dim text As String
        text = "Select * from fn_SystemFunction_SelectList(@LangID,@ModuleName)"
        Dim command As IDbCommand
        command = CreateCommand(text)
        AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        AddTypedParam(command, "@ModuleName", SqlDbType.VarChar)
        FillDataset(command, ds, "Functions")
        m_IsNewObject = False
        Return ds
    End Function

End Class
