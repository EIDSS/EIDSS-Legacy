Namespace Objects
    Public Class RelationInfo
        Private m_MasterTableName As String
        Private m_DetailTableName As String
        Private m_MasterFieldName As String
        Private m_DetailFieldName As String

        Public Sub New(ByVal masterName As String, ByVal masterField As String, ByVal detailTable As String, ByVal detailField As String)
            m_MasterTableName = masterName
            m_MasterFieldName = masterField
            m_DetailTableName = detailTable
            m_DetailFieldName = detailField
        End Sub
        Public Property MasterTableName() As String
            Get
                Return m_MasterTableName
            End Get
            Set(ByVal value As String)
                m_MasterTableName = value
            End Set
        End Property

        Public Property MasterFieldName() As String
            Get
                Return m_MasterFieldName
            End Get
            Set(ByVal value As String)
                m_MasterFieldName = value
            End Set
        End Property

        Public Property DetailTableName() As String
            Get
                Return m_DetailTableName
            End Get
            Set(ByVal value As String)
                m_DetailTableName = value
            End Set
        End Property

        Public Property DetailFieldName() As String
            Get
                Return m_DetailFieldName
            End Get
            Set(ByVal value As String)
                m_DetailFieldName = value
            End Set
        End Property
    End Class

End Namespace
