Namespace Objects
    Public Class BasePermissionObject
        Implements IPermissionObject
        Private m_permObject As [Enum]
        Public Sub New(ByVal aType As PermissionType, ByVal permObject As [Enum], ByVal [Select] As Boolean, ByVal Update As Boolean, ByVal Insert As Boolean, ByVal Delete As Boolean, ByVal Execute As Boolean)
            m_permObject = permObject
            m_Select = [Select]
            m_Delete = Delete
            m_Update = Update
            m_Insert = Insert
            m_Execute = Execute
            m_Type = aType
        End Sub
        Public Sub New(ByVal aType As PermissionType, ByVal permObject As [Enum])
            m_permObject = permObject
            m_Type = aType
            If aType = PermissionType.ObjectPermission Then
                m_Select = True
                m_Delete = True
                m_Update = True
                m_Insert = True
            ElseIf aType = PermissionType.ActionPermission Then
                m_Execute = True
            End If
        End Sub
        Public Sub New(ByVal permObject As [Enum])
            m_permObject = permObject
            m_Type = PermissionType.ObjectPermission
            m_Select = True
            m_Delete = True
            m_Update = True
            m_Insert = True
        End Sub

        Private m_Delete As Boolean = False
        Public Property Delete() As Boolean Implements IPermissionObject.Delete
            Get
                Return m_Delete
            End Get
            Set(ByVal value As Boolean)
                m_Delete = value
            End Set
        End Property

        Public ReadOnly Property DeletePermissionName() As String Implements IPermissionObject.DeletePermissionName
            Get
                Return m_permObject.ToString & "." & "Delete"
            End Get
        End Property

        Public Property Description() As String Implements IPermissionObject.Description
            Get
                Return ""
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Private m_Execute As Boolean = False
        Public Property Execute() As Boolean Implements IPermissionObject.Execute
            Get
                Return m_Execute
            End Get
            Set(ByVal value As Boolean)
                m_Execute = value
            End Set
        End Property

        Public ReadOnly Property ExecutePermissionName() As String Implements IPermissionObject.ExecutePermissionName
            Get
                Return m_permObject.ToString & "." & "Execute"
            End Get
        End Property

        Private m_Insert As Boolean = False
        Public Property Insert() As Boolean Implements IPermissionObject.Insert
            Get
                Return m_Insert
            End Get
            Set(ByVal value As Boolean)
                m_Insert = value
            End Set
        End Property

        Public ReadOnly Property InsertPermissionName() As String Implements IPermissionObject.InsertPermissionName
            Get
                Return m_permObject.ToString & "." & "Insert"
            End Get
        End Property

        Public Property Name() As String Implements IPermissionObject.Name
            Get
                Return m_permObject.ToString
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Public Sub Parse(ByVal permissionString As String) Implements IPermissionObject.Parse

        End Sub

        Private m_Select As Boolean = False
        Public Property [Select]() As Boolean Implements IPermissionObject.Select
            Get
                Return m_Select
            End Get
            Set(ByVal value As Boolean)
                m_Select = value
            End Set
        End Property

        Public ReadOnly Property SelectPermissionName() As String Implements IPermissionObject.SelectPermissionName
            Get
                Return m_permObject.ToString & "." & "Select"
            End Get
        End Property

        Private m_Type As PermissionType
        Public Property Type() As PermissionType Implements IPermissionObject.Type
            Get
                Return m_Type
            End Get
            Set(ByVal value As PermissionType)
                m_Type = value
            End Set
        End Property

        Private m_Update As Boolean = False
        Public Property Update() As Boolean Implements IPermissionObject.Update
            Get
                Return m_Update
            End Get
            Set(ByVal value As Boolean)
                m_Update = value
            End Set
        End Property

        Public ReadOnly Property UpdatePermissionName() As String Implements IPermissionObject.UpdatePermissionName
            Get
                Return m_permObject.ToString & "." & "Update"
            End Get
        End Property
    End Class

End Namespace
