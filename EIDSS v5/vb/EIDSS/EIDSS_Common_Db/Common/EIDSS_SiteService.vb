Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports bv.model.Model.Core

Public Class EIDSS_SiteService
    Inherits BaseDbService
    Private m_SiteData As DataTable
    Private m_SiteConnection As IDbConnection
    Public Property SiteConnection() As IDbConnection
        Get
            Return m_SiteConnection
        End Get
        Set(ByVal value As IDbConnection)
            m_SiteConnection = value
            If Not m_SiteData Is Nothing Then
                m_SiteData.Clear()
            End If
            GetSiteInfo()
        End Set
    End Property
    Public Sub Clear()
        If Not m_SiteData Is Nothing Then
            m_SiteData.Clear()
        End If
    End Sub
    Public Function GetSiteType() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strSiteTypeName"))
    End Function
    Public Function GetSiteTypeEnum() As SiteType
        GetSiteInfo()
        Return CType(m_SiteData.Rows(0)("idfsSiteType"), SiteType)
    End Function
    Public Function GetSiteCode() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strSiteID"))
    End Function
    Public Function GetSiteName() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strSiteName"))
    End Function
    Public Function GetSiteHASCCode() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strHASCsiteID"))
    End Function
    Public Function GetSiteID() As Long
        GetSiteInfo()
        Return CLng(m_SiteData.Rows(0)("idfsSite"))
    End Function
    Public Function GetCountryID() As Long
        GetSiteInfo()
        Return CLng(m_SiteData.Rows(0)("idfsCountry"))
    End Function
    Public Function GetRegionID() As Long
        GetSiteInfo()
        Return CLng(m_SiteData.Rows(0)("idfsRegion"))
    End Function
    Public Function GetCountryName() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strCountryName"))
    End Function
    Public Function GetOrganizationName() As String
        GetSiteInfo()
        Return Utils.Str(m_SiteData.Rows(0)("strOrganizationName"))
    End Function
    Public Function GetOrganizationID() As Long
        GetSiteInfo()
        Return CLng(m_SiteData.Rows(0)("idfOffice"))
    End Function

    Public Function GetSiteInfo() As DataTable
        If (m_SiteData Is Nothing) Then
            m_SiteData = New DataTable
        End If
        If (m_SiteData.Rows.Count = 0 OrElse Utils.Str(m_SiteData.Rows(0)("idfsSite")) = "0") Then
            Dim attemptsCount As Integer = 0
            While (m_SiteData.Rows.Count = 0 OrElse Utils.Str(m_SiteData.Rows(0)("idfsSite")) = "0") AndAlso attemptsCount < 3
                Try
                    Clear()
                    Dim cmd As IDbCommand
                    If SiteConnection Is Nothing Then
                        cmd = CreateSPCommand("spGetSiteInfo", Connection)
                    Else
                        cmd = CreateSPCommand("spGetSiteInfo", SiteConnection)
                    End If
                    AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
                    Dim da As DbDataAdapter = CreateAdapter(cmd)
                    SyncLock (cmd.Connection)
                        da.Fill(m_SiteData)
                    End SyncLock
                Catch ex As Exception
                    Dbg.Debug("error during site info receiving (attempt {0}): {1}", attemptsCount, ex)
                End Try
                attemptsCount += 1
            End While

            If m_SiteData.Columns.Count = 0 Then
                m_SiteData.Columns.Add("idfsCountry", GetType(Long))
                m_SiteData.Columns.Add("strCountryName", GetType(String))
                m_SiteData.Columns.Add("idfsSite", GetType(Long))
                m_SiteData.Columns.Add("strHASCsiteID", GetType(String))
                m_SiteData.Columns.Add("strSiteID", GetType(String))
                m_SiteData.Columns.Add("strSiteName", GetType(String))
                m_SiteData.Columns.Add("idfsSiteType", GetType(Long))
                m_SiteData.Columns.Add("strSiteTypeName", GetType(String))
                m_SiteData.Columns.Add("strOrganizationName", GetType(String))
                m_SiteData.Columns.Add("idfOffice", GetType(Long))
                m_SiteData.Columns.Add("idfsRegion", GetType(Long))
            End If
            If m_SiteData.Rows.Count = 0 Then
                Dim dr As DataRow = m_SiteData.NewRow
                dr("idfsCountry") = 780000000 'Georgia
                dr("strCountryName") = "Georgia"
                dr("idfsSite") = 0
                dr("strSiteID") = ""
                dr("strHASCsiteID") = ""
                dr("idfsSiteType") = SiteType.CDR
                dr("strSiteTypeName") = "CDR"
                dr("strOrganizationName") = ""
                dr("idfOffice") = 0
                dr("idfsRegion") = 0
                m_SiteData.Rows.Add(dr)
            End If
        End If
        Return m_SiteData
    End Function


    'Public Function ValidateSiteSerialNumber(ByVal SiteID As String, ByVal Serial As String) As Boolean

    'End Function

    'Public Function CreateActivationCode(ByVal SiteID As String, ByVal ClientID As String, ByVal ExpirationDate As DateTime) As String

    'End Function

    'Public Function CreateActivationCodeRequest(ByVal SiteID As String, ByVal ClientID As String, ByVal ExpirationDate As DateTime) As String

    'End Function

    'Public Function ValidateActivatonCode(ByVal SiteID As String, ByVal ClientID As String, ByVal ActivationCode As String) As Boolean

    'End Function

    'Function SendActivationRequest(ByVal SiteID As String, ByVal ClientID As String, ByVal ActivationCode As String) As Boolean

    'End Function

    'Public Function Activate(ByVal SiteID As String, ByVal ClientID As String, ByVal ActivationCode As String) As Boolean

    'End Function

End Class
