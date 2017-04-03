Imports EIDSS.model.Resources
Imports bv.winclient.Core
Imports bv.common.Resources

Public Class MinMaxDate
    Public Sub New(ByVal aMinDate As Date, ByVal aMaxDate As Date)
        Me.m_MinDate = aMinDate
        Me.m_MaxDate = aMaxDate
        Me.m_MinDateName = ""
        Me.m_MaxDateName = ""
        Me.m_AllowBeEqual = True
    End Sub

    Public Sub New(ByVal aMinDate As Date, ByVal aMaxDate As Date, ByVal aMinDateName As String, _
                    ByVal aMaxDateName As String)
        Me.m_MinDate = aMinDate
        Me.m_MaxDate = aMaxDate
        Me.m_MinDateName = aMinDateName
        Me.m_MaxDateName = aMaxDateName
        Me.m_AllowBeEqual = True
    End Sub

    Public Sub New(ByVal aMinDate As Date, ByVal aMaxDate As Date, ByVal aMinDateName As String, _
                    ByVal aMaxDateName As String, ByVal aAllowBeEqual As Boolean)
        Me.m_MinDate = aMinDate
        Me.m_MaxDate = aMaxDate
        Me.m_MinDateName = aMinDateName
        Me.m_MaxDateName = aMaxDateName
        Me.m_AllowBeEqual = aAllowBeEqual
    End Sub

    Public m_MinDate As Date

    Public Property MinDate() As Date
        Get
            Return m_MinDate
        End Get
        Set(ByVal Value As Date)
            m_MinDate = Value
        End Set
    End Property

    Public m_MaxDate As Date

    Public Property MaxDate() As Date
        Get
            Return m_MaxDate
        End Get
        Set(ByVal Value As Date)
            m_MaxDate = Value
        End Set
    End Property

    Public m_MinDateName As String

    Public Property MinDateName() As String
        Get
            Return m_MinDateName
        End Get
        Set(ByVal Value As String)
            m_MinDateName = Value
        End Set
    End Property

    Public m_MaxDateName As String

    Public Property MaxDateName() As String
        Get
            Return m_MaxDateName
        End Get
        Set(ByVal Value As String)
            m_MaxDateName = Value
        End Set
    End Property

    Public m_AllowBeEqual As Boolean

    Public Property AllowBeEqual() As Boolean
        Get
            Return m_AllowBeEqual
        End Get
        Set(ByVal Value As Boolean)
            m_AllowBeEqual = Value
        End Set
    End Property

    Public ReadOnly Property MinMaxOk() As Boolean
        Get
            Dim res As Boolean = True
            If (MinDate.CompareTo(MaxDate) > 0) OrElse (MinDate.CompareTo(MaxDate) = 0 AndAlso Not AllowBeEqual) Then
                res = False
            End If
            Return res
        End Get
    End Property

    Public Sub CheckMinMax()
        If Not MinMaxOk Then
            Dim s As String = "earlier than"
            If AllowBeEqual Then s = "earlier than or same as"
            MessageForm.Show( _
                             EidssMessages.Get(String.Format("{0}_{1}", MinDateName, MaxDateName), _
                                                String.Format("{0} must be {1} {2}.", MinDateName, s, MaxDateName)), BvMessages.Get("Warning"))
        End If
    End Sub

    Public ReadOnly Property ErrorText() As String
        Get
            Dim Err As String = ""
            If Not MinMaxOk Then
                Dim s As String = "earlier than"
                If AllowBeEqual Then s = "earlier than or same as"
                Err = _
                    EidssMessages.Get(String.Format("{0}_{1}", MinDateName, MaxDateName), _
                                       String.Format("{0} must be {1} {2}.", MinDateName, s, MaxDateName))
            End If
            Return Err
        End Get
    End Property
End Class
