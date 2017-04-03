Imports bv.common.db
Imports bv.common.Core

Public Enum SearchCriteria
    IsEqualTo
    IsGraterThan
    IsLessThan
    IsNotEqualTo
    IsGraterThanOrEqualTo
    IsLessThanOrEqualTo
    IsLikeTo
    IsIn
    IsNotIn
    IsBetween
End Enum

Public Class FieldValue

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
        Me.m_LookupTable = BaseReferenceType.rftNone
        Me.m_IsId = False
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
        Me.m_LookupTable = BaseReferenceType.rftNone
        Me.m_IsId = False
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
        Me.m_LookupTable = BaseReferenceType.rftNone
        Me.m_IsId = False
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
        Me.m_LookupTable = BaseReferenceType.rftNone
        Me.m_IsId = False
    End Sub

    Public Sub New(ByVal aName As String, ByVal aCaption As String, ByVal aType As Type, ByVal aPrefix As String, ByVal aIsId As Boolean)
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
        Me.m_LookupTable = BaseReferenceType.rftNone
        Me.m_IsId = False
        If (m_FieldType Is GetType(String)) OrElse _
           (m_FieldType Is GetType(Guid)) OrElse _
           (m_FieldType Is GetType(Integer)) OrElse _
           (m_FieldType Is GetType(Int64)) Then
            m_IsId = aIsId
        End If
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
        Me.m_LookupTable = BaseReferenceType.rftNone
        If aTable >= 0 Then
            Me.m_LookupTable = aTable
        End If
        Me.m_IsId = False
    End Sub

    Private m_Name As String = ""
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            If Utils.IsEmpty(value) Then m_Name = "" Else m_Name = value
        End Set
    End Property

    Private m_Caption As String = ""
    Public Property Caption() As String
        Get
            Return m_Caption
        End Get
        Set(ByVal value As String)
            If Utils.IsEmpty(value) Then m_Caption = "" Else m_Caption = value
        End Set
    End Property

    Private m_FieldType As Type = GetType(String)
    Public Property FieldType() As Type
        Get
            Return m_FieldType
        End Get
        Set(ByVal value As Type)
            If value Is Nothing Then m_FieldType = GetType(String) Else m_FieldType = value
            If Not ((m_FieldType Is GetType(String)) OrElse _
                    (m_FieldType Is GetType(Guid)) OrElse _
                    (m_FieldType Is GetType(Integer)) OrElse _
                    (m_FieldType Is GetType(Int64))) Then
                m_IsId = False
            End If
        End Set
    End Property

    Private m_Prefix As String = ""
    Public Property Prefix() As String
        Get
            Return m_Prefix
        End Get
        Set(ByVal value As String)
            If Utils.IsEmpty(value) Then m_Prefix = "" Else m_Prefix = value
        End Set
    End Property

    Private m_LookupTable As BaseReferenceType = BaseReferenceType.rftNone
    Public Property LookupTable() As BaseReferenceType
        Get
            Return m_LookupTable
        End Get
        Set(ByVal value As BaseReferenceType)
            If value < 0 Then m_LookupTable = BaseReferenceType.rftNone Else m_LookupTable = value
        End Set
    End Property

    Private m_IsId As Boolean = False
    Public Property IsId() As Boolean
        Get
            Return m_IsId
        End Get
        Set(ByVal value As Boolean)
            If (m_FieldType Is GetType(String)) OrElse _
               (m_FieldType Is GetType(Guid)) OrElse _
               (m_FieldType Is GetType(Integer)) OrElse _
               (m_FieldType Is GetType(Int64)) Then
                m_IsId = value
            ElseIf m_IsId Then
                m_IsId = False
            End If
        End Set
    End Property

    Private m_FValue As Object = Nothing
    Public Property FValue() As Object
        Get
            Return m_FValue
        End Get
        Set(ByVal value As Object)
            If Utils.IsEmpty(value) Then m_FValue = Nothing Else m_FValue = value
        End Set
    End Property

    Private m_Criteria As SearchCriteria = SearchCriteria.IsEqualTo
    Public Property Criteria() As SearchCriteria
        Get
            Return m_Criteria
        End Get
        Set(ByVal value As SearchCriteria)
            If value < 0 Then m_Criteria = SearchCriteria.IsEqualTo Else m_Criteria = value
        End Set
    End Property

    Public ReadOnly Property FullName() As String
        Get
            If Utils.IsEmpty(m_Prefix) Then Return m_Name
            Return (m_Prefix + "." + m_Name)
        End Get
    End Property

    Public Function GetSearchCriteria(ByVal criteria As SearchCriteria) As String
        Select Case criteria
            Case SearchCriteria.IsEqualTo
                Return "="
            Case SearchCriteria.IsGraterThan
                Return ">"
            Case SearchCriteria.IsGraterThanOrEqualTo
                Return ">="
            Case SearchCriteria.IsLessThan
                Return "<"
            Case SearchCriteria.IsLessThanOrEqualTo
                Return "<="
            Case SearchCriteria.IsLikeTo
                Return "like"
            Case SearchCriteria.IsNotEqualTo
                Return "<>"
            Case SearchCriteria.IsIn
                Return "in"
            Case SearchCriteria.IsNotIn
                Return "not in"
            Case SearchCriteria.IsBetween
                Return "between"
        End Select
        Return "="
    End Function

    Public ReadOnly Property DefaultCriteria() As String
        Get
            If (m_FieldType Is GetType(String)) AndAlso (Not m_IsId) Then Return GetSearchCriteria(SearchCriteria.IsLikeTo)
            Return GetSearchCriteria(SearchCriteria.IsEqualTo)
        End Get
    End Property

    Public ReadOnly Property DefaultCondition() As String
        Get
            If Utils.IsEmpty(Me.FullName()) OrElse Utils.IsEmpty(m_FValue) Then Return ""
            If (m_FieldType.Name = "Boolean") Then
                Return "(" + bv.common.db.SqlParser.CreateCondition(String.Format("IsNull({0}, 0)", Me.FullName()), m_FieldType, Me.DefaultCriteria(), m_FValue) + ") "
            End If
            Return "(" + bv.common.db.SqlParser.CreateCondition(Me.FullName(), m_FieldType, Me.DefaultCriteria(), m_FValue) + ") "
        End Get
    End Property

    Public ReadOnly Property Condition() As String
        Get
            If Utils.IsEmpty(Me.FullName()) OrElse Utils.IsEmpty(m_FValue) Then Return ""
            Return "(" + bv.common.db.SqlParser.CreateCondition(Me.FullName(), m_FieldType, GetSearchCriteria(m_Criteria), m_FValue) + ") "
        End Get
    End Property

    Public Shared Function CreateLikeCondition(ByVal fieldName As String, ByVal val As String, ByVal dataType As System.Type) As String
        Return bv.common.db.SqlParser.CreateLikeCondition(fieldName, dataType, val)
    End Function

    Public Shared Function CorrectLikeValue(ByVal val As String, ByVal dataType As System.Type) As String
        Return bv.common.db.SqlParser.CorrectLikeValue(dataType, val)
    End Function

End Class
