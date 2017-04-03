Imports System.Data
Imports System.Data.Common

Public Class LocationSelectDialog_DB
    Inherits BaseDbService

    Public Sub New()
        Me.ObjectName = "GeoLocation"
    End Sub
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        'm_ID = ID

        If ID Is Nothing Then
            MyBase.m_ID = NewIntID()
            m_IsNewObject = True
        Else
            MyBase.m_ID = ID
        End If

        Return ds
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
