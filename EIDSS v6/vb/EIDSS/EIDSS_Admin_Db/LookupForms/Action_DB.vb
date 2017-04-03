Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class Action_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "ActionReference"
    End Sub

    Dim ReferenceDetail_Adapter As DbDataAdapter
    Dim ReferenceType_Adapter As DbDataAdapter

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spMeasureReference_SelectDetail")
            StoredProcParamsCache.CreateParameters(cmd)
            'SetParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Dim ReferenceDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            ReferenceDetail_Adapter.Fill(ds)
            CorrectTable(ds.Tables(0), "BaseReference")
            CorrectTable(ds.Tables(1), "ReferenceType")
            CorrectTable(ds.Tables(2), "HACodes")
            CorrectTable(ds.Tables(3), "MasterReferenceType")
            ds.Tables("MasterReferenceType").Columns(0).ReadOnly = False
            ClearColumnsAttibutes(ds)
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrement = True
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementSeed = -1
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementStep = -1
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim prophilacticActionChanged As Boolean = ds.Tables("BaseReference").Select(String.Format("idfsReferenceType={0}", CLng(BaseReferenceType.rftProphilacticActionList)), Nothing, DataViewRowState.Added Or DataViewRowState.Deleted Or DataViewRowState.ModifiedCurrent).Length > 0
            Dim sanitaryActionChanged As Boolean = ds.Tables("BaseReference").Select(String.Format("idfsReferenceType={0}", CLng(BaseReferenceType.rftSanitaryActionList)), Nothing, DataViewRowState.Added Or DataViewRowState.Deleted Or DataViewRowState.ModifiedCurrent).Length > 0
            ExecPostProcedure("spMeasureReference_Post", ds.Tables("BaseReference"), Connection, transaction)
            LookupCache.NotifyChange("ProphilacticAction", transaction)
            LookupCache.NotifyChange("SanitaryAction", transaction)
            If (prophilacticActionChanged) Then
                AddEvent(EventType.ReferenceTableChanged, String.Format("ActionDetail:{0}", CLng(BaseReferenceType.rftProphilacticActionList)), False)
            ElseIf sanitaryActionChanged Then
                AddEvent(EventType.ReferenceTableChanged, String.Format("ActionDetail:{0}", CLng(BaseReferenceType.rftSanitaryActionList)), False)
            End If

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
