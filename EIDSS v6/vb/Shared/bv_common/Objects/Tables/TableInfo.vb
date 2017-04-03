Imports bv.common.Core
Imports bv.common.Meta
Imports System.Collections.Generic
Namespace Objects
    Public Class TableInfo
        Private m_Name As String 'table name in the dataset. must be unique for the business object
        Private m_SqlName As String ' related table name in the database
        Private m_Type As TableType
        Private m_LookupTableID As String ' id of the lookup table. Must unique identify lookup table
        Private m_LoadMethod As String
        'Private m_Relations As RelationInfo()
        Private m_Keys As String
        Private m_KeyFields As String()

        'Public Sub New(ByVal sTable As SourceTable)
        '    m_Name = sTable.Name
        '    m_SqlName = sTable.SqlName
        '    m_Type = sTable.Type
        '    m_LoadMethod = sTable.LoadMethod
        '    'm_Relations = BuildRelations(sTable)
        '    m_KeyFields = sTable.KeyFields

        'End Sub

        Public Sub New(ByVal tableName As String, ByVal sqlName As String, ByVal tableType As TableType)
            m_Name = tableName
            If sqlName Is Nothing Then
                m_SqlName = tableName
            Else
                m_SqlName = sqlName
            End If
            m_Type = tableType
        End Sub
        Public Sub New(ByVal tableName As String)
            Me.New(tableName, tableName, TableType.Child)
        End Sub
        Public Sub New(ByVal tableName As String, ByVal sqlName As String)
            Me.New(tableName, sqlName, TableType.Child)
        End Sub

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Public Property SqlName() As String
            Get
                Return m_SqlName
            End Get
            Set(ByVal value As String)
                m_SqlName = value
            End Set
        End Property

        Public Property Type() As TableType
            Get
                Return m_Type
            End Get
            Set(ByVal value As TableType)
                m_Type = value
            End Set
        End Property

        Public Property Keys() As String
            Get
                Return m_Keys
            End Get
            Set(ByVal value As String)
                m_Keys = value
                m_KeyFields = m_Keys.Split(","c)
            End Set
        End Property

        Public Property LoadMethod() As String
            Get
                Return m_LoadMethod
            End Get
            Set(ByVal value As String)
                m_LoadMethod = value
            End Set
        End Property


        'Public Property Relations() As RelationInfo()
        '    Get
        '        Return m_Relations
        '    End Get
        '    Set(ByVal value As RelationInfo())
        '        m_Relations = value
        '    End Set
        'End Property
        Public Property KeyFields() As String()
            Get
                Return m_KeyFields
            End Get
            Set(ByVal value As String())
                m_KeyFields = value
            End Set
        End Property

        'Private Sub BuildRelations(ByVal sTable As SourceTable)

        'End Sub

        Private m_Filters As Dictionary(Of String, Object)
        Public ReadOnly Property StaticFilters() As Dictionary(Of String, Object)
            Get
                If m_Filters Is Nothing Then
                    m_Filters = New Dictionary(Of String, Object)
                End If
                Return m_Filters
            End Get
        End Property
        Public Sub AddStaticFilter(ByVal key As String, ByVal val As Object)
            StaticFilters(key) = val
        End Sub
        Private m_HACode As Integer = 0
        Public Property HACode() As Integer
            Get
                Return m_HACode
            End Get
            Set(ByVal value As Integer)
                m_HACode = value
            End Set
        End Property
    End Class 'TableInfo
End Namespace

