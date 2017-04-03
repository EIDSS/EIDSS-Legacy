Imports System.Collections.Generic
Namespace Objects
    Public Class GlobalPermissions
        Private Shared m_Permissions As New Dictionary(Of String, IPermissionObject)
        Public Sub Add(ByVal permission As IPermissionObject)
            If m_Permissions.ContainsKey(permission.Name) Then
                m_Permissions(permission.Name).Select = m_Permissions(permission.Name).Select Or permission.Select
                m_Permissions(permission.Name).Insert = m_Permissions(permission.Name).Insert Or permission.Insert
                m_Permissions(permission.Name).Update = m_Permissions(permission.Name).Update Or permission.Update
                m_Permissions(permission.Name).Delete = m_Permissions(permission.Name).Delete Or permission.Delete
                m_Permissions(permission.Name).Execute = m_Permissions(permission.Name).Execute Or permission.Execute
            Else
                m_Permissions.Add(permission.Name, permission)
            End If
        End Sub
        Public Sub Remove(ByVal permissionObjectName As String)
            If m_Permissions.ContainsKey(permissionObjectName) Then
                m_Permissions.Remove(permissionObjectName)
            End If
        End Sub
        Public Shared Sub Clear()
            m_Permissions.Clear()
        End Sub
        Public Shared ReadOnly Property Permissions() As IDictionary(Of String, IPermissionObject)
            Get
                Return m_Permissions
            End Get
        End Property

    End Class
End Namespace
