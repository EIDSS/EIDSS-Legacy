Imports System.Data
Imports System.Data.Common
Imports bv.common.Core

Public Class RootFarmTree_DB
    Inherits BaseFarmTree_DB
    Public Sub New()
        MyBase.New()
        SelectProcedureName = "spRootFarmTree_SelectDetail"
        PostProcedureName = "spRootFarmTree_Post"
        KeyFieldName = "idfFarm"
    End Sub
    Private m_IsRootFarm As Boolean = True

    Public Property IsRootFarm As Boolean
        Get
            Return m_IsRootFarm

        End Get
        Set(value As Boolean)
            m_IsRootFarm = value
            If m_IsRootFarm Then
                PostProcedureName = "spRootFarmTree_Post"
            Else
                PostProcedureName = "spVetFarmTree_Post"
            End If

        End Set
    End Property
    Public Overloads Sub ChangeFarm(ByVal ds As DataSet, ByVal idfFarm As Object, ByVal farmIdCode As String)
        If ds.Tables(TableFarmTree).Rows.Count = 0 Then
            Dim row As DataRow = ds.Tables(TableFarmTree).NewRow
            row("idfParty") = idfFarm
            row("strName") = FarmIdCode
            row("idfsPartyType") = CLng(PartyType.Farm)
            ds.Tables(TableFarmTree).Rows.Add(row)
            AddHerd(row)
            Return
        End If
        For i As Integer = ds.Tables(TableFarmTree).Rows.Count - 1 To 0 Step -1
            Dim row As DataRow = ds.Tables(TableFarmTree).Rows(i)
            If CLng(PartyType.Farm).Equals(row("idfsPartyType")) Then
                If Not idfFarm Is Nothing Then
                    row("idfParty") = idfFarm
                    row.AcceptChanges()
                End If
                row("strName") = FarmIdCode
            ElseIf CLng(PartyType.Herd).Equals(row("idfsPartyType")) AndAlso Not idfFarm Is Nothing Then
                row("idfParentParty") = idfFarm
            End If

        Next
    End Sub

End Class
