Imports System.Xml.Serialization
Imports System.Data
Namespace Objects
    Public Class ParameterInfo
        Private m_Name As String
        Private m_Field As String
        Private m_Table As String
        Private m_Value As Object
        Private m_Type As SqlDbType
        Private m_Direction As ParameterDirection

        Public Sub New()
            m_Name = ""
            m_Field = ""
            m_Table = ""
            m_Value = ""
            m_Type = SqlDbType.NVarChar
            m_Direction = ParameterDirection.Input
        End Sub

        Public Sub New(ByVal Name As String, ByVal value As Object, Optional ByVal Direction As ParameterDirection = ParameterDirection.Input)
            m_Name = Name
            m_Field = ""
            m_Table = ""
            m_Value = value
            m_Type = SqlDbType.NVarChar
            m_Direction = Direction
        End Sub

        Public Sub New(ByVal Name As String, ByVal table As String, ByVal field As String, Optional ByVal dbtype As SqlDbType = SqlDbType.NVarChar)
            m_Name = Name
            m_Field = field
            m_Table = table
            m_Value = Value
            m_Type = dbtype
            m_Direction = Direction
        End Sub

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Public Property Type() As SqlDbType
            Get
                Return m_Type
            End Get
            Set(ByVal value As SqlDbType)
                m_Type = value
            End Set
        End Property

        Public Property SourceTable() As String
            Get
                Return m_Table
            End Get
            Set(ByVal value As String)
                m_Table = value
            End Set
        End Property

        Public Property SourceField() As String
            Get
                Return m_Field
            End Get
            Set(ByVal value As String)
                m_Field = value
            End Set
        End Property

        Public Property Value() As Object
            Get
                Return m_Value
            End Get
            Set(ByVal value As Object)
                m_Value = value
            End Set
        End Property


        Public Property Direction() As ParameterDirection
            Get
                Return m_Direction
            End Get
            Set(ByVal value As ParameterDirection)
                m_Direction = value
            End Set
        End Property

    End Class
End Namespace

