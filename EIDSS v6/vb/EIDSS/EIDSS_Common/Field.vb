Imports bv.common.db
Public Class Field

    Public Sub New(ByVal aName As String)
        If Not aName Is Nothing Then
            Me.m_Name = aName
            Me.m_Caption = aName
        Else
            Me.m_Name = ""
            Me.m_Caption = ""
        End If
        Me.m_FieldType = GetType(String)
        Me.m_Prefix = ""
        Me.m_LookupTable = Nothing
    End Sub

    Public Sub New(ByVal aName As String, ByVal aCaption As String)
        If Not aName Is Nothing Then
            Me.m_Name = aName
            Me.m_Caption = aName
        Else
            Me.m_Name = ""
            Me.m_Caption = ""
        End If
        If Not aCaption Is Nothing Then
            Me.m_Caption = aCaption
        End If
        Me.m_FieldType = GetType(String)
        Me.m_Prefix = ""
        Me.m_LookupTable = Nothing
    End Sub

    Public Sub New(ByVal aName As String, ByVal aCaption As String, ByVal aType As Type)
        If Not aName Is Nothing Then
            Me.m_Name = aName
            Me.m_Caption = aName
        Else
            Me.m_Name = ""
            Me.m_Caption = ""
        End If
        If Not aCaption Is Nothing Then
            Me.m_Caption = aCaption
        End If
        Me.m_FieldType = GetType(String)
        If Not aType Is Nothing Then
            Me.m_FieldType = aType
        End If
        Me.m_Prefix = ""
        Me.m_LookupTable = Nothing
    End Sub

    Public Sub New(ByVal aName As String, ByVal aCaption As String, ByVal aType As Type, ByVal aPrefix As String)
        If Not aName Is Nothing Then
            Me.m_Name = aName
            Me.m_Caption = aName
        Else
            Me.m_Name = ""
            Me.m_Caption = ""
        End If
        If Not aCaption Is Nothing Then
            Me.m_Caption = aCaption
        End If
        Me.m_FieldType = GetType(String)
        If Not aType Is Nothing Then
            Me.m_FieldType = aType
        End If
        Me.m_Prefix = ""
        If Not aPrefix Is Nothing Then
            Me.m_Prefix = aPrefix
        End If
        Me.m_LookupTable = Nothing
    End Sub

    Public Sub New(ByVal aName As String, ByVal aCaption As String, ByVal aType As Type, ByVal aPrefix As String, ByVal aTable As BaseReferenceType)
        If Not aName Is Nothing Then
            Me.m_Name = aName
            Me.m_Caption = aName
        Else
            Me.m_Name = ""
            Me.m_Caption = ""
        End If
        If Not aCaption Is Nothing Then
            Me.m_Caption = aCaption
        End If
        Me.m_FieldType = GetType(String)
        If Not aType Is Nothing Then
            Me.m_FieldType = aType
        End If
        Me.m_Prefix = ""
        If Not aPrefix Is Nothing Then
            Me.m_Prefix = aPrefix
        End If
        Me.m_LookupTable = Nothing
        If aTable >= 0 Then
            Me.m_LookupTable = aTable
        End If
    End Sub

    Public m_Name As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
        End Set
    End Property

    Public m_Caption As String
    Public Property Caption() As String
        Get
            Return m_Caption
        End Get
        Set(ByVal Value As String)
            m_Caption = Value
        End Set
    End Property

    Public m_FieldType As Type
    Public Property FieldType() As Type
        Get
            Return m_FieldType
        End Get
        Set(ByVal Value As Type)
            m_FieldType = Value
        End Set
    End Property

    Public m_Prefix As String
    Public Property Prefix() As String
        Get
            Return m_Prefix
        End Get
        Set(ByVal Value As String)
            m_Prefix = Value
        End Set
    End Property

    Public m_LookupTable As BaseReferenceType
    Public Property LookupTable() As BaseReferenceType
        Get
            Return m_LookupTable
        End Get
        Set(ByVal Value As BaseReferenceType)
            m_LookupTable = Value
        End Set
    End Property

    Public ReadOnly Property FullName() As String
        Get
            Return (m_Prefix + "." + m_Name)
        End Get
    End Property

End Class
