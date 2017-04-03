Public Class LabelControlPair
    Private m_Label As Control
    Private m_Controls() As Control
    Private m_YLabelShift As Integer
    Public Sub New(ByVal aLabel As Control, ByVal aControl As Control)
        m_Label = aLabel
        m_Controls = New Control() {aControl}
        m_YLabelShift = CInt((aControl.Height - m_Label.Height) / 2)
    End Sub
    Public Sub New(ByVal aLabel As Control, ByVal aControls() As Control)
        m_Label = aLabel
        m_Controls = aControls
        m_YLabelShift = CInt((aControls(0).Height - m_Label.Height) / 2)
    End Sub
    Public ReadOnly Property [Label] As Control
        Get
            Return m_Label
        End Get
    End Property
    Public ReadOnly Property Controls As Control()
        Get
            Return m_Controls
        End Get
    End Property
    Private m_Visible As Boolean = True
    Public Property Visible() As Boolean
        Get
            Return m_Visible
        End Get
        Set(ByVal Value As Boolean)
            m_Visible = Value
            m_Label.Visible = Value
            For Each ctl As Control In m_Controls
                ctl.Visible = Value
            Next
        End Set
    End Property

    Public ReadOnly Property CaptionWidth() As Integer
        Get
            Return m_Label.Width
        End Get
    End Property

    Public ReadOnly Property ControlWidth() As Integer
        Get
            If m_Controls.Length > 1 Then
                Return m_Controls(m_Controls.Length - 1).Width + m_Controls(m_Controls.Length - 1).Left - m_Controls(0).Left
            Else
                Return m_Controls(0).Width
            End If
        End Get
    End Property

    Public Shared XDistance As Integer = 8
    Public Sub Arrange(ByVal left As Integer, ByVal top As Integer, ByVal captionWidth As Integer, ByVal controlWidth As Integer)
        m_Label.Left = left
        m_Label.Top = top + m_YLabelShift
        m_Label.Width = captionWidth
        Dim fixedWidth As Integer = 0
        Dim fixedWidthCount As Integer = 0
        For i As Integer = 0 To m_Controls.Length - 1
            Dim ctl As Control = m_Controls(i)
            If ctl.Width = ctl.MaximumSize.Width Then
                fixedWidth += ctl.Width
                fixedWidthCount += 1
            End If
        Next
        Dim singleControlWidth As Integer = CInt((controlWidth - (m_Controls.Length - 1) * XDistance - fixedWidth) / (m_Controls.Length - fixedWidthCount))
        Dim x As Integer = left + m_Label.Width
        Dim ctlLeft As Integer = x
        For i As Integer = 0 To m_Controls.Length - 1
            Dim ctl As Control = m_Controls(i)
            ctl.Left = x
            Dim shift As Integer = 0
            shift = CInt((m_Controls(0).Height - ctl.Height) / 2)
            ctl.Top = top + shift
            If ctl.Width <> ctl.MaximumSize.Width Then
                If i = m_Controls.Length - 1 Then
                    ctl.Width = ctlLeft + controlWidth - ctl.Left
                Else
                    ctl.Width = singleControlWidth
                End If
            End If
            x += singleControlWidth + XDistance
        Next
    End Sub
End Class

Public Class LabelControlList
    Private m_List As New ArrayList
    Public ReadOnly Property Count As Integer
        Get
            Return m_List.Count
        End Get
    End Property
    Public Sub Add(ByVal pair As LabelControlPair)
        m_List.Add(pair)
        If m_CaptionWidth < pair.CaptionWidth Then
            m_CaptionWidth = pair.CaptionWidth
        End If
        If m_ControlWidth < pair.ControlWidth Then
            m_ControlWidth = pair.ControlWidth
        End If
        m_LayoutUpdated = False
    End Sub
    Public Sub Remove(ByVal index As Integer)
        If index >= 0 AndAlso index < m_List.Count Then
            m_List.RemoveAt(index)
            m_LayoutUpdated = False
        End If
    End Sub
    Public Sub Clear()
        m_List.Clear()
        m_LayoutUpdated = False
    End Sub
    Public Sub ForceUpdate()
        m_LayoutUpdated = False
    End Sub
    Public ReadOnly Property Item(ByVal Index As Integer) As LabelControlPair
        Get
            Return CType(m_List(Index), LabelControlPair)
        End Get
    End Property
    Private m_CaptionWidth As Integer = 0

    Public Property CaptionWidth() As Integer
        Get
            Return m_CaptionWidth
        End Get
        Set(ByVal Value As Integer)
            m_CaptionWidth = Value
            m_LayoutUpdated = False
        End Set
    End Property

    Private m_ControlWidth As Integer = 0
    Public Property ControlWidth() As Integer
        Get
            Return m_ControlWidth
        End Get
        Set(ByVal Value As Integer)
            m_ControlWidth = Value
            m_LayoutUpdated = False
        End Set
    End Property
    Private m_ColumnsCount As Integer = 1
    Public Property ColumnsCount() As Integer
        Get
            Return m_ColumnsCount
        End Get
        Set(ByVal Value As Integer)
            m_ColumnsCount = Value
            m_LayoutUpdated = False
        End Set
    End Property
    Private m_LineHeight As Integer = 24
    Public Property LineHeight() As Integer
        Get
            Return m_LineHeight
        End Get
        Set(ByVal Value As Integer)
            m_LineHeight = Value
            m_LayoutUpdated = False
        End Set
    End Property

    Private m_ColumnsDistance As Integer = 8
    Public Property ColumnsDistance() As Integer
        Get
            Return m_ColumnsDistance
        End Get
        Set(ByVal Value As Integer)
            m_ColumnsDistance = Value
            m_LayoutUpdated = False
        End Set
    End Property
    Private m_ControlCount As Integer
    Private Sub CalcVisibleControlsCont()
        m_ControlCount = 0
        For Each pair As LabelControlPair In m_List
            If pair.Visible Then
                m_ControlCount += 1
            End If
        Next
    End Sub
    Private m_LayoutUpdated As Boolean = False
    Sub UpdateLayout1()
        If m_LayoutUpdated Then Return
        m_LayoutUpdated = True
        CalcVisibleControlsCont()
        Dim ctlInColumnQty As Integer = CInt(Math.Ceiling(m_ControlCount / m_ColumnsCount))
        LabelControlPair.XDistance = ColumnsDistance
        Dim yQty As Integer = 0
        Dim x As Integer = 8
        Dim y As Integer = 8
        For i As Integer = 0 To m_List.Count - 1
            y = 8
            Dim j As Integer = 0
            Dim updated As Boolean = False
            While (j < ctlInColumnQty AndAlso i < m_List.Count)
                If Item(i).Visible Then
                    Item(i).Arrange(x, y, CaptionWidth, ControlWidth)
                    y += m_LineHeight
                    j += 1
                End If
                updated = True
                i += 1
            End While
            If updated Then
                i -= 1
            End If
            x += CaptionWidth + ControlWidth + ColumnsDistance
        Next
    End Sub
    Sub UpdateLayout()
        If m_LayoutUpdated Then Return
        m_LayoutUpdated = True
        CalcVisibleControlsCont()
        Dim ctlInColumnQty As Integer = CInt(Math.Ceiling(m_ControlCount / m_ColumnsCount))
        LabelControlPair.XDistance = ColumnsDistance
        'Dim yQty As Integer = 0
        Dim x As Integer = 8
        Dim y As Integer = 8
        Dim i As Integer = 0
        For j As Integer = 0 To ctlInColumnQty - 1
            x = 8
            Dim q As Integer = 0
            While ((i < m_List.Count) AndAlso (q < m_ColumnsCount))
                If Item(i).Visible Then
                    Item(i).Arrange(x, y, CaptionWidth, ControlWidth)
                    x += CaptionWidth + ControlWidth + ColumnsDistance
                    q += 1
                End If
                i += 1
            End While
            y += m_LineHeight
        Next
    End Sub
    Private Sub Control_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        m_LayoutUpdated = False
    End Sub

End Class