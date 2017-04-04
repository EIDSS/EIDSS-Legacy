Imports System.Reflection
Imports bv.common.Core


Public Class EIDSSSettings
    Public Shared Function GetHelpFileNameSpace() As String
        If bv.common.GlobalSettings.HelpNames.ContainsKey(bv.common.GlobalSettings.CurrentLanguage) Then
            Return bv.common.GlobalSettings.HelpNames(bv.common.GlobalSettings.CurrentLanguage).ToString
        End If
        Return "ms-help://BV.EIDSS.3.0.EN"
    End Function
    Private Shared DbService As Object
    Public Shared Sub Clear()
        If Not m_SiteService Is Nothing Then
            m_SiteService.GetType.GetMethod("Clear").Invoke(m_SiteService, Nothing)
        End If
    End Sub
    Private Shared Function GetSettingsProperty() As PropertyInfo
        If DbService Is Nothing Then
            DbService = ClassLoader.LoadClass("EIDSS_SettingsService")
        End If
        If Not DbService Is Nothing Then
            Dim myTypeArray(0) As Type
            myTypeArray.SetValue(GetType(String), 0)
            Dim pi As PropertyInfo = DbService.GetType().GetProperty("Item")
            Return pi
        End If
        Return Nothing
    End Function


    Public Shared Property Item(ByVal name As String, Optional ByVal cn As IDbConnection = Nothing) As String
        Get
            Dim pi As PropertyInfo = GetSettingsProperty()
            If Not pi Is Nothing Then
                Return CType(pi.GetValue(DbService, New Object() {name, cn}), String)
            End If
            Return Nothing
        End Get
        Set(ByVal Value As String)
            Dim pi As PropertyInfo = GetSettingsProperty()
            If Not pi Is Nothing Then
                pi.SetValue(DbService, Value, New Object() {name, Nothing})
            End If
        End Set
    End Property


    Public Shared ReadOnly Property IsReadOnlySite() As Boolean
        Get
            If m_SiteType = SiteType.Undefined Then
                Return False
            End If
            'TODO:[Mike] Get requirement for readonly site definition
            'Return (m_SiteType = SiteType.CDR AndAlso SiteCode <> "001") OrElse (SiteCode >= "002" AndAlso SiteCode <= "009") '
            Return False
        End Get
    End Property

    Public Shared Property ModuleType() As String
        Get
            Return Item("ModuleType")
        End Get
        Set(ByVal Value As String)
            Item("ModuleType") = Value
        End Set
    End Property
    Private Shared m_SiteService As Object
    Private Shared Function InvokeSiteMethodReturningString(ByVal methodName As String) As String
        If m_SiteService Is Nothing Then
            m_SiteService = ClassLoader.LoadClass("EIDSS_SiteService")
        End If
        Return m_SiteService.GetType.GetMethod(methodName).Invoke(m_SiteService, Nothing).ToString
    End Function
    Private Shared Function InvokeSiteMethodReturningID(ByVal methodName As String) As Long
        If m_SiteService Is Nothing Then
            m_SiteService = ClassLoader.LoadClass("EIDSS_SiteService")
        End If
        Return CLng(m_SiteService.GetType.GetMethod(methodName).Invoke(m_SiteService, Nothing))
    End Function
    Public Shared ReadOnly Property CountryID() As Long
        Get
            Return InvokeSiteMethodReturningID("GetCountryID")
        End Get
    End Property

    Public Shared ReadOnly Property CountryName() As String
        Get
            Return InvokeSiteMethodReturningString("GetCountryName")
        End Get
    End Property
    Public Shared ReadOnly Property OrganizationName() As String
        Get
            Return InvokeSiteMethodReturningString("GetOrganizationName")
        End Get
    End Property
    Public Shared ReadOnly Property OrganizationID() As Long
        Get
            Return InvokeSiteMethodReturningID("GetOrganizationID")
        End Get
    End Property

    Public Shared ReadOnly Property SiteABR() As String
        Get
            Return InvokeSiteMethodReturningString("GetSiteName")
        End Get
    End Property

    Public Shared ReadOnly Property SiteHASCCode() As String
        Get
            Return InvokeSiteMethodReturningString("GetSiteHASCCode")
        End Get
    End Property
    Private Shared m_SiteID As Long = 0
    Public Shared ReadOnly Property SiteID() As Long
        Get
            If m_SiteID = 0 Then
                m_SiteID = InvokeSiteMethodReturningID("GetSiteID")
            End If
            Return m_SiteID
        End Get
    End Property
    Private Shared m_SiteCode As String
    Public Shared ReadOnly Property SiteCode() As String
        Get
            If m_SiteCode Is Nothing Then
                m_SiteCode = InvokeSiteMethodReturningString("GetSiteCode")
            End If
            Return m_SiteCode
        End Get
    End Property

    Private Shared m_SiteType As SiteType = SiteType.Undefined
    Public Shared ReadOnly Property SiteType() As SiteType
        Get
            If m_SiteType = EIDSS.SiteType.Undefined Then
                m_SiteType = CType(InvokeSiteMethodReturningID("GetSiteTypeEnum"), SiteType)
            End If
            Return m_SiteType
        End Get
    End Property

    Public Shared ReadOnly Property ClientID() As String
        Get
            Return GlobalSettings.ClientID
        End Get
    End Property

    Public Shared ReadOnly Property SiteRegionID() As Object
        Get
            Return InvokeSiteMethodReturningID("GetRegionID")
        End Get
    End Property


    Public Shared Sub Save()
        If Not DbService Is Nothing Then
            Dim mi As MethodInfo = DbService.GetType().GetMethod("Save")
            If Not mi Is Nothing Then
                mi.Invoke(DbService, Nothing)
            End If
        End If

    End Sub
    Public Shared Sub Deinit()
        If DbService IsNot Nothing Then
            CType(DbService, IDisposable).Dispose()
            DbService = Nothing
        End If
    End Sub

End Class

