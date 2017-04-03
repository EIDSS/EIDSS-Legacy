Imports System.Data
Imports System.Data.Common

Public Class Settlement_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "Settlement"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand

            cmd = CreateSPCommand("spSettlement_SelectDetail")
            AddParam(cmd, "@idfsSettlement", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)


            Dim SettlementDetailAdapter As DbDataAdapter = CreateAdapter(cmd)
            'Fill the main object table
            SettlementDetailAdapter.Fill(ds, "Settlement")
            'Fill other object tables here
            ClearColumnsAttibutes(ds)
            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("Settlement").NewRow()
                ID = NewIntID()
                r("idfsSettlement") = ID
                r("blnIsCustomSettlement") = 1
                ds.EnforceConstraints = False
                ds.Tables("Settlement").Rows.Add(r)
                m_IsNewObject = True
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Private m_GenerateSettlementChangedEvent As Boolean
    Private m_RefreshCache As Boolean = False

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            m_GenerateSettlementChangedEvent = False
            Dim row As DataRow = ds.Tables("Settlement").Rows(0)
            m_RefreshCache = False
            If m_IsNewObject OrElse _
                Not row.HasVersion(DataRowVersion.Original) OrElse _
                Not row("dblLongitude").Equals(row("dblLongitude", DataRowVersion.Original)) OrElse _
                Not row("dblLatitude").Equals(row("dblLatitude", DataRowVersion.Original)) Then
                m_GenerateSettlementChangedEvent = True
                'AddEvent(EventType.SettlementChanged)
            End If
            If m_IsNewObject OrElse _
                Not row.HasVersion(DataRowVersion.Original) OrElse _
                Not row("strEnglishName").Equals(row("strEnglishName", DataRowVersion.Original)) OrElse _
                Not row("strNationalName").Equals(row("strNationalName", DataRowVersion.Original)) Then
                m_RefreshCache = True
                'AddEvent(EventType.SettlementChanged)
            End If
            BaseDbService.ExecPostProcedure("spSettlement_Post", ds.Tables("Settlement"), Connection, transaction)
            If RefreshCache Then
                bv.common.db.Core.LookupCache.NotifyChange("Settlement", transaction, ID)
                'EIDSS.GISControl.Common.TranslationCache.ClearCache()
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public ReadOnly Property RefreshCache() As Boolean
        Get
            Return m_RefreshCache
        End Get
    End Property
    Private Sub Settlement_DB_OnBeforeAcceptChanges(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnBeforeAcceptChanges
        If m_GenerateSettlementChangedEvent = True Then
            EIDSS_EventLog.Instance.CreateEvent(EventType.SettlementChanged, m_ID, EIDSS.model.Core.EidssUserContext.User.ID)
            m_GenerateSettlementChangedEvent = False
        End If

    End Sub

    Public Function FindDuplicate(ByVal row As DataRow) As Integer
        If row Is Nothing Then Return -2
        Return FindDuplicate(Utils.Str(row("idfsRayon")), Utils.Str(row("idfsSettlement")), Utils.Str(row("strEnglishName")), Utils.Str(row("strNationalName")), Utils.Str(row("strSettlementCode")), bv.model.Model.Core.ModelUserContext.CurrentLanguage, CLng(row("idfsSettlementType")))
    End Function

    Public Function FindDuplicate(ByVal idfsRayon As String, ByVal idfsSettlement As String, ByVal enName As String, ByVal natName As String, ByVal uniqueCode As String, ByVal lng As String, ByVal settlementType As Long) As Integer
        Dim cmd As IDbCommand = CreateSPCommand("spSettlement_Validate")
        AddParam(cmd, "@idfsRayon", idfsRayon)
        AddParam(cmd, "@idfsSettlement", idfsSettlement)
        AddParam(cmd, "@strDefaultName", enName)
        AddParam(cmd, "@strNationalName", natName)
        AddParam(cmd, "@strSettlementCode", uniqueCode)
        AddParam(cmd, "@idfsSettlementType", settlementType)
        AddParam(cmd, "@LangID", lng)
        AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If Not m_Error Is Nothing Then
            Return -1
        End If
        Dim Result As Object = GetParamValue(cmd, "@Result")
        If Not Utils.IsEmpty(Result) Then
            Return CInt(Result)
        Else
            Return -2
        End If

    End Function

End Class
