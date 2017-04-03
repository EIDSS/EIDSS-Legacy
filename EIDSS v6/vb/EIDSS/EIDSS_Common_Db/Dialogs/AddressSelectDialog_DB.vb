Imports System.Data
Imports System.Data.Common

Public Class AddressSelectDialog_DB
    Inherits BaseDbService

    Public Sub New()
        Me.ObjectName = "Address"
    End Sub
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        'm_ID = ID

        If ID Is Nothing Then
            MyBase.m_ID = BaseDbService.NewIntID()
        Else
            MyBase.m_ID = ID
        End If

        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal postType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
