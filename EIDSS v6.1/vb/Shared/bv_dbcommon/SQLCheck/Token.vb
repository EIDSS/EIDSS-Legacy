Option Strict On

Namespace SQLCheck

    Enum TokenType
        None
        LeftParen
        RightParen
        Comma
        Number
        EQ
        NE
        GT
        LT
        GE
        LE
        [Like]
        Plus
        Minus
        Asterisk
        Div
        [And]
        [Or]
        [Not]
        Identifier
        TextString
        Null
        Cast
        Convert
        [As]
        IsNull
        DateDiff
        Abs
        Upper
        Lower
        DataType
        FreeText
        Escape
        [In]
        [Is]
        Between
        Asc
        Desc
        Eof
        InvalidCharacter
        ReservedKeyword
        TooLong
    End Enum

    Class Token
        Private m_type As TokenType
        Private m_index As Integer
        Private m_pos As Integer
        Private m_value As String
        Private m_reached As Boolean

        Public Sub New(ByVal type As TokenType, ByVal index As Integer, _
                       ByVal position As Integer, Optional ByVal value As String = "")
            m_type = type
            m_index = index
            m_pos = position
            m_value = value
            m_reached = False
        End Sub

        Public ReadOnly Property Type() As TokenType
            Get
                Return m_type
            End Get
        End Property

        Public ReadOnly Property Index() As Integer
            Get
                Return m_index
            End Get
        End Property

        Public ReadOnly Property Position() As Integer
            Get
                Return m_pos
            End Get
        End Property

        Public ReadOnly Property Value() As String
            Get
                Return m_value
            End Get
        End Property

        Public Property Reached() As Boolean
            Get
                Return m_reached
            End Get
            Set(ByVal Value As Boolean)
                m_reached = Value
            End Set
        End Property
    End Class

End Namespace
