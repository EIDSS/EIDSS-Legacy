Public Class SystemPermissions_DB
    Inherits bv.common.db.BaseDbService

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        Dim appName As String = "smdEIDSS"
        Dim ds As System.Data.DataSet
        ds = New DataSet()

        Dim text As String
        text = "Select * from fn_SystemFunction_SelectList(@LangID,@ModuleName)"
        Dim command As IDbCommand
        command = Me.CreateCommand(text)
        BaseDbService.AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        BaseDbService.AddTypedParam(command, "@ModuleName", SqlDbType.VarChar)
        Dim adapter As System.Data.Common.DbDataAdapter
        adapter = CreateAdapter(command)
        adapter.Fill(ds, "Functions")
        m_IsNewObject = False
        Return ds
    End Function

End Class
