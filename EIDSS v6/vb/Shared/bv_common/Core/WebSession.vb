Imports System.Web
Imports System.Security.Principal

Public Class WebSession

    Public Shared Property CurrentLanguage() As String
        Get
            Dim ret As Object = PropertyValue("CurrentLanguage")
            If ret Is Nothing Then Return Nothing
            Return ret.ToString()
        End Get
        Set(ByVal value As String)
            PropertyValue("CurrentLanguage") = value
        End Set
    End Property

    Public Shared ReadOnly Property ClientID() As String
        Get
            If HttpContext.Current Is Nothing OrElse HttpContext.Current.Session Is Nothing Then Return Nothing
            Return HttpContext.Current.Session.SessionID
            'Dim ret As Object = PropertyValue("ClientID")
            'If ret Is Nothing Then Return Nothing
            'Return ret.ToString()
        End Get
        'Set(ByVal value As String)
        'PropertyValue("ClientID") = value
        'End Set
    End Property

    Public Shared Property Current() As EIDSSUser
        Get
            'If HttpContext.Current Is Nothing OrElse HttpContext.Current.User.Identity.IsAuthenticated = False Then Return Nothing
            'Return CType(HttpContext.Current.User.Identity, EIDSSUser)
            If HttpContext.Current Is Nothing Then Return Nothing
            Dim value As Object = PropertyValue("CurrentUser")
            Dim user As EIDSSUser = Nothing
            'If Not (value Is Nothing) AndAlso TypeOf (value) Is EIDSSUser Then
            If TypeOf (value) Is EIDSSUser Then
                user = CType(value, EIDSSUser)
            Else
                user = New EIDSSUser()
                PropertyValue("CurrentUser") = user
            End If
            'HttpContext.Current.User = New GenericPrincipal(user, Nothing)
            Return user
        End Get
        Set(ByVal value As EIDSSUser)
            PropertyValue("CurrentUser") = value
        End Set
    End Property


    Protected Shared Property PropertyValue(ByVal name As String) As Object
        Get
            If HttpContext.Current Is Nothing OrElse HttpContext.Current.Session Is Nothing Then Return Nothing
            Return HttpContext.Current.Session(name)
        End Get
        Set(ByVal value As Object)
            If HttpContext.Current Is Nothing OrElse HttpContext.Current.Session Is Nothing Then Return
            HttpContext.Current.Session(name) = value
        End Set
    End Property

End Class