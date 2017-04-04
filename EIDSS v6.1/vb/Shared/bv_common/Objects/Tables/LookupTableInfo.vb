Imports bv.common.Core
Imports bv.common.Meta
Imports System.Collections.Generic
Namespace Objects
    Public Class LookupTableInfo
        Inherits TableInfo
        'TableName - unique identifier of lookup table. 
        'If TableName starts from rft prefix, it is assumed that data is read from using spBaseRefernce_SelectLookup
        'procedure and LookupTableID defines the reference type
        'In other case it is assumed that LookupTableID identifies the stored procedure that should be used for data read.
        'This stored procedure should be sp[TableName]_SelectLookup
        'For exlusion from this rule you can additionally set ProcedureName property
        'SqlName deines the name of related lookup table in the database. This name is used by LookupCache for notifcations 
        'about lookup tables update and automatical tables refresh
        Public Sub New(ByVal aTableName As String, Optional ByVal aFillAsync As Boolean = False, Optional ByVal sqlName As String = Nothing, Optional ByVal aPocedureName As String = Nothing, Optional ByVal aPrimaryKey As String = Nothing, Optional ByVal aRelatedTables As List(Of String) = Nothing, Optional ByVal aAddEmptyString As Boolean = True)

            MyBase.New(aTableName, sqlName, TableType.Lookup)
            FillAsync = aFillAsync
            m_ProcedureName = aPocedureName
            m_RelatedSqlTables = aRelatedTables
            m_PrimaryKey = aPrimaryKey
            AddEmptyString = aAddEmptyString
        End Sub

        Public Sub New(ByVal aTableName As [Enum], Optional ByVal aFillAsync As Boolean = False, Optional ByVal sqlName As String = Nothing, Optional ByVal aPocedureName As String = Nothing, Optional ByVal aPrimaryKey As String = Nothing, Optional ByVal aRelatedTables As List(Of String) = Nothing, Optional ByVal aAddEmptyString As Boolean = True)
            MyBase.New(aTableName.ToString, sqlName, TableType.Lookup)
            FillAsync = aFillAsync
            m_ProcedureName = aPocedureName
            m_RelatedSqlTables = aRelatedTables
            m_PrimaryKey = aPrimaryKey
            AddEmptyString = aAddEmptyString
        End Sub
        Public Shared Function GetDefaultProcedureName(baseName As String) As String
            Return String.Format("sp{0}_SelectLookup", baseName)
        End Function
        Public Property AddEmptyString() As Boolean = True
        Private m_ProcedureName As String = Nothing
        Public Property ProcedureName() As String
            Get
                If m_ProcedureName Is Nothing Then
                    Return GetDefaultProcedureName(Name)
                Else
                    Return m_ProcedureName
                End If
            End Get
            Set(ByVal value As String)
                m_ProcedureName = value
            End Set
        End Property
        Private m_FillAsync As Boolean = False
        Public Property FillAsync() As Boolean
            Get
                Return m_FillAsync
            End Get
            Set(ByVal value As Boolean)
                m_FillAsync = value
            End Set
        End Property
        Private m_Parameters As Dictionary(Of String, Object)
        Public Property Parameters() As Dictionary(Of String, Object)
            Get
                If m_Parameters Is Nothing Then
                    m_Parameters = New Dictionary(Of String, Object)
                End If
                Return m_Parameters
            End Get
            Set(ByVal value As Dictionary(Of String, Object))
                m_Parameters = value
            End Set
        End Property
        Private m_RefreshObjectID As Object
        Public Property RefreshObjectID() As Object
            Get
                Return m_RefreshObjectID
            End Get
            Set(ByVal value As Object)
                m_RefreshObjectID = value
            End Set
        End Property
        Private m_RelatedSqlTables As List(Of String)
        Public Property RelatedSqlTables() As List(Of String)
            Get
                Return m_RelatedSqlTables
            End Get
            Set(ByVal value As List(Of String))
                m_RelatedSqlTables = value
            End Set
        End Property

        Private m_PrimaryKey As String

        Public Property PrimaryKey() As String
            Get
                Return m_PrimaryKey
            End Get
            Set(ByVal Value As String)
                m_PrimaryKey = Value
            End Set
        End Property
    End Class
End Namespace

