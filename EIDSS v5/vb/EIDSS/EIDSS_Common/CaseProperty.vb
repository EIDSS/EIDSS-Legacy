Imports System.Data
Imports System.Data.Common
Imports bv.common.Core

Public Class CaseProperty

    Public Enum CasePropertyKind
        None
        idfCase
        CaseID
        LocalID
        Diagnosis
        DiagnosisDate
        idfHuman
        LastName
        FirstName
        SecondName
        DOB
        Age
        AgeUnits
        Sex
        idfCurrentResidenceAddress
        RegionHome
        RayonHome
        SettlementHome
        StreetHome
        PostalCodeHome
        HouseHome
        BuildingHome
        AptmHome
        PhoneNumber
        Nationality
        EmployerName
        GeoLocationEmployer
        OnsetDate
        FinalState
        ChangedDiagnosis
        ChangedDiagnosisDate
        PatientLocationStatus
        PatientLocationName
        AddCaseInfo
        HumanObsID
        EpiObsID
    End Enum

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal ds As DataSet)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        SetAllValues(ds)
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal aParentKind As CasePropertyKind)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        If aParentKind >= 0 Then
            Me.m_ParentKind = aParentKind
        End If
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal aParentKind As CasePropertyKind, ByVal ds As DataSet)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        If aParentKind >= 0 Then
            Me.m_ParentKind = aParentKind
        End If
        SetAllValues(ds)
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aName As String, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aName Is Nothing Then
            Me.m_Name = aName
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aName As String, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal ds As DataSet)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aName Is Nothing Then
            Me.m_Name = aName
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        SetAllValues(ds)
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aName As String, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal aParentKind As CasePropertyKind)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aName Is Nothing Then
            Me.m_Name = aName
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        If aParentKind >= 0 Then
            Me.m_ParentKind = aParentKind
        End If
    End Sub

    Public Sub New(ByVal aKind As CasePropertyKind, ByVal aName As String, ByVal aTableName As String, ByVal aID_FieldName As String, ByVal aText_FieldName As String, ByVal aParentKind As CasePropertyKind, ByVal ds As DataSet)
        Me.m_Kind = Nothing
        Me.m_Name = ""
        Me.m_TableName = ""
        Me.m_ID_FieldName = ""
        Me.m_Text_FieldName = ""
        Me.m_ParentKind = CasePropertyKind.None
        Me.m_IsSurvivorValuePrimary = True
        If aKind >= 0 Then
            Me.m_Kind = aKind
            Me.m_Name = aKind.ToString()
        End If
        If Not aName Is Nothing Then
            Me.m_Name = aName
        End If
        If Not aTableName Is Nothing Then
            Me.m_TableName = aTableName
        End If
        If Not aID_FieldName Is Nothing Then
            Me.m_ID_FieldName = aID_FieldName
        End If
        If Not aText_FieldName Is Nothing Then
            Me.m_Text_FieldName = aText_FieldName
        End If
        If aParentKind >= 0 Then
            Me.m_ParentKind = aParentKind
        End If
        SetAllValues(ds)
    End Sub

    Private m_Kind As CasePropertyKind
    Public Property Kind() As CasePropertyKind
        Get
            Return m_Kind
        End Get
        Set(ByVal Value As CasePropertyKind)
            m_Kind = Value
        End Set
    End Property

    Private m_ParentKind As CasePropertyKind
    Public Property ParentKind() As CasePropertyKind
        Get
            Return m_ParentKind
        End Get
        Set(ByVal Value As CasePropertyKind)
            m_ParentKind = Value
        End Set
    End Property

    Private m_Name As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
        End Set
    End Property

    Private m_TableName As String
    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal Value As String)
            m_TableName = Value
        End Set
    End Property

    Private m_Text_FieldName As String
    Public Property Text_FieldName() As String
        Get
            Return m_Text_FieldName
        End Get
        Set(ByVal Value As String)
            m_Text_FieldName = Value
        End Set
    End Property

    Private m_ID_FieldName As String
    Public Property ID_FieldName() As String
        Get
            Return m_ID_FieldName
        End Get
        Set(ByVal Value As String)
            m_ID_FieldName = Value
        End Set
    End Property

    Public ReadOnly Property DataMember_ID() As String
        Get
            If Not (Utils.IsEmpty(m_TableName) OrElse Utils.IsEmpty(m_ID_FieldName)) Then
                Return (m_TableName + "." + m_ID_FieldName)
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property DataMember_Text() As String
        Get
            If Not (Utils.IsEmpty(m_TableName) OrElse Utils.IsEmpty(m_Text_FieldName)) Then
                Return (m_TableName + "." + m_Text_FieldName)
            End If
            Return ""
        End Get
    End Property

    Private m_SurvivorValueID As Object
    Public Property SurvivorValueID() As Object
        Get
            Return m_SurvivorValueID
        End Get
        Set(ByVal value As Object)
            m_SurvivorValueID = value
        End Set
    End Property

    Private m_SupersededValueID As Object
    Public Property SupersededValueID() As Object
        Get
            Return m_SupersededValueID
        End Get
        Set(ByVal value As Object)
            m_SupersededValueID = value
        End Set
    End Property

    Private m_SurvivorValueText As Object
    Public Property SurvivorValueText() As Object
        Get
            Return m_SurvivorValueText
        End Get
        Set(ByVal value As Object)
            m_SurvivorValueText = value
        End Set
    End Property

    Private m_SupersededValueText As Object
    Public Property SupersededValueText() As Object
        Get
            Return m_SupersededValueText
        End Get
        Set(ByVal value As Object)
            m_SupersededValueText = value
        End Set
    End Property

    Private m_IsSurvivorValuePrimary As Boolean
    Public Property IsSurvivorValuePrimary() As Boolean
        Get
            Return m_IsSurvivorValuePrimary
        End Get
        Set(ByVal value As Boolean)
            m_IsSurvivorValuePrimary = value
        End Set
    End Property

    Public Sub ChangeRoles()
        Dim m_Primary As Object = m_SurvivorValueID
        m_SurvivorValueID = m_SupersededValueID
        m_SupersededValueID = m_Primary

        m_Primary = m_SurvivorValueText
        m_SurvivorValueText = m_SupersededValueText
        m_SupersededValueText = m_Primary

        '(only for non-simple version of de-duplication)
        'm_IsSurvivorValuePrimary = Not m_IsSurvivorValuePrimary
    End Sub

    Public Sub SetValue(ByVal ds As DataSet, ByVal rowType As String)
        If (Not Utils.IsEmpty(rowType)) AndAlso (Not Utils.IsEmpty(m_TableName)) AndAlso (Not ds Is Nothing) Then
            Dim tables() As String = m_TableName.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer = 0
            While (i < tables.Length) AndAlso _
                  (((rowType = "Survivor") AndAlso Utils.IsEmpty(m_SurvivorValueID)) OrElse _
                   ((rowType = "Superseded") AndAlso Utils.IsEmpty(m_SupersededValueID)))
                If (ds.Tables.Contains(tables(i)) AndAlso (ds.Tables(tables(i)).Rows.Count > 0)) Then
                    Dim r As DataRow = ds.Tables(tables(i)).Rows.Find(rowType)
                    If (Not r Is Nothing) Then
                        If (Not Utils.IsEmpty(m_ID_FieldName)) Then
                            If (rowType = "Survivor") Then
                                m_SurvivorValueID = r(m_ID_FieldName)
                            End If
                            If (rowType = "Superseded") Then
                                m_SupersededValueID = r(m_ID_FieldName)
                            End If
                        End If
                        If (Not Utils.IsEmpty(m_Text_FieldName)) Then
                            Dim TextValue As Object = r(m_Text_FieldName)
                            If (TypeOf (TextValue) Is DateTime) Then
                                TextValue = CDate(TextValue).Date
                            End If
                            If (rowType = "Survivor") Then
                                m_SurvivorValueText = TextValue
                            End If
                            If (rowType = "Superseded") Then
                                m_SupersededValueText = TextValue
                            End If
                        End If
                    End If
                End If
                i = i + 1
            End While
        End If
    End Sub

    Public Sub SetAllValues(ByVal ds As DataSet)
        SetValue(ds, "Survivor")
        SetValue(ds, "Superseded")
    End Sub
End Class
