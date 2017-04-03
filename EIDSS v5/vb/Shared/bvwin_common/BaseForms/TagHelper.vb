Imports bv.winclient.Localization

Public Class TagHelper
    'We assume that all controls have its its state written to the Tag property
    'in the format {MRK}
    'M - mandatory field, must be filled by user
    'R - ReadOnly field
    'K - key field - it is editble for new object and read-only in all other cases
    'B - barcode (special VK_ENTER procedure)
    Private Shared ControlStateRegExp As New System.Text.RegularExpressions.Regex("\{(?<state>[MRKB]*)\}", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Private Shared ControlLanguageRegExp As New System.Text.RegularExpressions.Regex("\[(?<lng>.*)\]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Public Sub New()

    End Sub
    Dim m_ctl As Control
    Private m_Form As BaseForm
    Public Shared Function Create(ByVal ctl As Control) As TagHelper
        If TypeOf (ctl.Tag) Is TagHelper Then
            Return CType(ctl.Tag, TagHelper)
        Else
            Return New TagHelper(ctl)
        End If
    End Function

    Public Sub New(ByVal ctl As Control)
        m_ctl = ctl
        If Not ctl Is Nothing Then
            If Not ctl.Tag Is Nothing Then
                If TypeOf (ctl.Tag) Is TagHelper Then
                    Copy(CType(ctl.Tag, TagHelper))
                ElseIf TypeOf (ctl.Tag) Is String Then
                    m_StringTag = CType(ctl.Tag, String)
                    ParseControlStateString(m_StringTag)
                ElseIf TypeOf (ctl.Tag) Is Integer Then
                    m_IntTag = CInt(ctl.Tag)
                Else
                    m_Tag = ctl.Tag
                End If
            End If
            ctl.Tag = Me
            Dim parent As Control = ctl.Parent
            While Not parent Is Nothing
                If TypeOf parent Is BaseForm Then
                    m_Form = CType(parent, BaseForm)
                    Exit While
                End If
                parent = parent.Parent
            End While
        End If
    End Sub
    Public Sub Copy(ByVal tag As TagHelper)
        m_ComboBoxBinder = tag.m_ComboBoxBinder
        m_ControlLanguage = tag.m_ControlLanguage
        m_ctl = tag.m_ctl
        m_Datasource = tag.m_Datasource
        m_Form = tag.m_Form
        m_IntTag = tag.m_IntTag
        m_KeyField = tag.m_KeyField
        m_LookupTableName = tag.m_LookupTableName
        m_Mandatory = tag.m_Mandatory
        m_Readonly = tag.m_Readonly
        m_StringTag = tag.m_StringTag
        m_Tag = tag.m_Tag
    End Sub
    Function ParseControlStateString(ByVal state As String) As Boolean
        If (Utils.IsEmpty(state)) Then
            Return False
        End If
        Dim m As Text.RegularExpressions.Match = ControlStateRegExp.Match(state)
        Dim res As Boolean = False
        If m.Success Then
            Dim s As String = m.Result("${state}")
            If s.IndexOf("R") >= 0 Then
                m_Readonly = True
                res = True
            End If
            If s.IndexOf("K") >= 0 Then
                m_KeyField = True
                res = True
            End If
            If s.IndexOf("M") >= 0 Then
                m_Mandatory = True
                res = True
            End If
            If s.IndexOf("B") >= 0 Then
                m_Barcode = True
                res = True
            End If
        End If
        m = ControlLanguageRegExp.Match(state)
        If m.Success Then
            m_ControlLanguage = m.Result("${lng}")
            res = True
        End If
        Return (res)
    End Function
    Private Sub ApplyState()
        If Not m_Form Is Nothing AndAlso TypeOf (m_ctl) Is DevExpress.XtraEditors.BaseEdit Then
            Dim state As ControlState = ControlState.Normal
            If m_Mandatory Then
                state = state Or ControlState.Mandatory
            End If
            If m_Readonly Then
                state = state Or ControlState.ReadOnly
            End If
            If m_KeyField Then
                state = state Or ControlState.KeyField
            End If
            If m_Barcode Then
                state = state Or ControlState.Barcode
            End If
            m_Form.ApplyControlState(CType(m_ctl, DevExpress.XtraEditors.BaseEdit), state)
        End If
    End Sub
    Dim m_Mandatory As Boolean = False
    Public Property IsMandatory() As Boolean
        Get
            Return m_Mandatory
        End Get
        Set(ByVal Value As Boolean)
            m_Mandatory = Value
            'ApplyState()
        End Set
    End Property
    Public Property MandatoryFieldName() As String

    Dim m_Readonly As Boolean = False
    Public Property IsReadOnly() As Boolean
        Get
            Return m_Readonly
        End Get
        Set(ByVal Value As Boolean)
            m_Readonly = Value
            ' ApplyState()
        End Set
    End Property
    Dim m_KeyField As Boolean = False
    Public Property IsKeyField() As Boolean
        Get
            Return m_KeyField
        End Get
        Set(ByVal Value As Boolean)
            m_KeyField = Value
            'ApplyState()
        End Set
    End Property
    Dim m_Barcode As Boolean = False
    Public Property IsBarcode() As Boolean
        Get
            Return m_Barcode
        End Get
        Set(ByVal Value As Boolean)
            m_Barcode = Value
            'ApplyState()
        End Set
    End Property
    Dim m_ControlLanguage As String = ""
    Public Property ControlLanguage() As String
        Get
            Return m_ControlLanguage
        End Get
        Set(ByVal Value As String)
            m_ControlLanguage = Value
        End Set
    End Property

    Dim m_StringTag As String = ""
    Public Property StringTag() As String
        Get
            Return m_StringTag
        End Get
        Set(ByVal Value As String)
            ParseControlStateString(Value)
            m_StringTag = Value
        End Set
    End Property
    Dim m_IntTag As Integer = -1
    Public Property IntTag() As Integer
        Get
            Return m_IntTag
        End Get
        Set(ByVal Value As Integer)
            m_IntTag = Value
        End Set
    End Property
    Dim m_LookupTableName As String
    Public Property LookupTableName() As String
        Get
            Return m_LookupTableName
        End Get
        Set(ByVal Value As String)
            m_LookupTableName = Value
        End Set
    End Property

    '--------------------Added by Olga 27.07.2007
    Dim m_HACodeName As String
    Public Property HACodeName() As String
        Get
            Return m_HACodeName
        End Get
        Set(ByVal Value As String)
            m_HACodeName = Value
        End Set
    End Property
    '--------------------Added by Olga 27.07.2007

    Dim m_Tag As Object
    Public Property Tag() As Object
        Get
            Return m_Tag
        End Get
        Set(ByVal Value As Object)

            m_Tag = Value
        End Set
    End Property
    Dim m_Datasource As Object
    Public Property Datasource() As Object
        Get
            Return m_Datasource
        End Get
        Set(ByVal Value As Object)

            m_Datasource = Value
        End Set
    End Property

    Dim m_ComboBoxBinder As Object
    Public Property Binder() As Object
        Get
            Return m_ComboBoxBinder
        End Get
        Set(ByVal Value As Object)

            m_ComboBoxBinder = Value
        End Set
    End Property

    Public Shared Sub SetControlLanguage(ByVal c As Control, ByRef LastInputLanguage As String, Optional ByVal ForceControlLang As Boolean = False)
        If Not c.Tag Is Nothing Then
            Dim th As TagHelper
            If Not TypeOf (c.Tag) Is TagHelper Then
                th = New TagHelper(c)
            Else
                th = CType(c.Tag, TagHelper)
            End If
            LastInputLanguage = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture)
            If th.ControlLanguage <> "" Then
                SystemLanguages.SwitchInputLanguage(th.ControlLanguage)
                If ForceControlLang OrElse th.ControlLanguage = "def" Then
                    th.ControlLanguage = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture)
                End If
            End If
        End If
    End Sub

    Public Shared Function GetControlLanguage(ByVal c As Control) As String
        If Not c.Tag Is Nothing Then
            Dim th As TagHelper
            If Not TypeOf (c.Tag) Is TagHelper Then
                th = New TagHelper(c)
            Else
                th = CType(c.Tag, TagHelper)
            End If
            Dim Res As String
            If th.ControlLanguage <> "" Then
                If th.ControlLanguage = "def" Then
                    Res = CType(Localizer.SupportedLanguages(BaseSettings.DefaultLanguage), String)
                Else

                    Res = CType(Localizer.SupportedLanguages(th.ControlLanguage), String)
                End If
                If Res <> "" Then
                    For Each lang As InputLanguage In InputLanguage.InstalledInputLanguages
                        If lang.Culture.Name = Res Then
                            Return lang.Culture.TwoLetterISOLanguageName
                        End If
                    Next
                End If
            End If
        End If
        Return InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName
    End Function
    Public Shared Function GetTagHelper(ByVal ctl As Control) As TagHelper
        If Not ctl.Tag Is Nothing AndAlso TypeOf (ctl.Tag) Is TagHelper Then
            Return CType(ctl.Tag, TagHelper)
        Else
            Return New TagHelper(ctl)
        End If
    End Function


End Class
