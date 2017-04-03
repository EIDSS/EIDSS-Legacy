Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
'This class is initialized by DataGrid and forces DataGrid columns 
'auto resizing. if GridColumnResizer.AutoSize property = true
'the grid columns widths are resized proportionally to fit grid client width
'The class affects to the grid appearing only if its TablesStyles property is defined
'and all grid columns are defined explicitly through TablesStyles(0)
'To cancel specific grid autosizing you can set its Tag="DontAutoSize"
'in this case GridColumnResizer will have AutoSize=false after initialization
Public Class GridColumnResizer
    Dim m_Columns As New ArrayList
    Dim m_BorderWidth As Integer = 0
    Dim m_Grid As DataGrid = Nothing
    'Constructor allows to initialize GridColumnResizer class with DataGrid
    Sub New(ByVal g As DataGrid)
        Grid = g
    End Sub

#Region "Public properties"
    'Grid property returns catched DataGrid or 
    'allows intialize GridColumnResizer
    Public Property Grid() As DataGrid
        Get
            Return m_Grid
        End Get
        Set(ByVal Value As DataGrid)
            m_Grid = Value
            If Not m_Grid.Tag Is Nothing AndAlso CType(m_Grid.Tag, String) = "DontAutoSize" Then
                m_AutoSize = False
            End If
            AddHandler m_Grid.Resize, AddressOf ResizeHandler
            ResetGrid()
        End Set
    End Property
    'AutoSize property manages grid columns appearing
    'If AutoSize = false, this class will not afect to grid resizing
    'If AutoSize =  true the grid columns widths are resized 
    'proportionally to fit grid client width
    Dim m_AutoSize As Boolean = True
    Public Property AutoSize() As Boolean
        Get
            Return m_AutoSize
        End Get
        Set(ByVal Value As Boolean)
            m_AutoSize = Value
            Resize()
        End Set
    End Property
#End Region

#Region "Private methods"

    Private Sub ResetGrid()
        m_Columns.Clear()
        If Not m_Grid.TableStyles Is Nothing AndAlso m_Grid.TableStyles.Count > 0 Then
            Dim s As DataGridTableStyle = m_Grid.TableStyles(0)
            For Each c As DataGridColumnStyle In s.GridColumnStyles
                AddHandler c.WidthChanged, AddressOf ResizeColumnHandler
                m_Columns.Add(New ColumnData(c))
            Next
        End If
        If Grid.BorderStyle = BorderStyle.Fixed3D Then
            m_BorderWidth = SystemInformation.Border3DSize.Width
        ElseIf Grid.BorderStyle = BorderStyle.FixedSingle Then
            m_BorderWidth = SystemInformation.BorderSize.Width
        ElseIf Grid.BorderStyle = BorderStyle.None Then
            m_BorderWidth = 0
        End If
        Resize()
    End Sub
#End Region
    Private ReadOnly Property Column(ByVal index As Integer) As ColumnData
        Get
            Return CType(m_Columns(index), ColumnData)
        End Get
    End Property
    'Method that force proportional columns resizing
    Sub Resize_Internal()
        Grid.SuspendLayout()
        'Recalculate grid client width and resizable column width
        'taking into account grid borders and scroll bars
        RecalcColumnWidth()
        Dim RealWidth As Integer = 0
        Dim i As Integer = 0
        'Resize all columns ecxept last one propeorioanlly
        'The original column width is stored in the m_Columns(i).Width variables 
        For i = 0 To m_Columns.Count - 2
            Dim ProportionalWidth As Double = Column(i).Width * m_ClientWidth / m_SizedWidth
            Column(i).Column.Width = CInt(ProportionalWidth)
            RealWidth += CInt(ProportionalWidth)
        Next
        'Set the width of last column to fit grid width
        Column(i).Column.Width = m_ClientWidth - RealWidth
        Grid.ResumeLayout()
    End Sub

    Dim m_Resizing As Boolean = False
    'The main method that resizes grid columns proportionally
    'It is called from after grid or grid column resizing
    Sub Resize()
        If Grid Is Nothing OrElse m_AutoSize = False _
            OrElse m_Resizing OrElse m_Columns.Count = 0 Then Exit Sub
        'm_SizedWidth defines the common width of all resizable columns
        If (m_SizedWidth = 0) Then
            ResetColumnWidth()
        End If
        m_Resizing = True
        Try
            'Resize grid column widths
            Resize_Internal()
            'Here we process the next special sitation:
            'If the common rows height is slightly less then grid client height
            'and grid width is reduces the grid horizontal scrollbar will appear
            'and force appearing of verical scrollbar
            'So Resize_Internal() will take into account the width of vertical scrollbar
            'during columns resizing and empty grid background 
            'will be visible at the left of grid because both scrollbars
            'disapper after column resizing
            'To fix this artefact we check if this empty grid background is visible
            'using HitTest method and call Resize_Internal() again
            'if comlumns width don't fit grid width
            Dim w As Integer = GetScrollBarWidth()
            If Grid.Visible And w = 0 Then
                Dim hti As DataGrid.HitTestInfo = Grid.HitTest(Grid.Width - m_BorderWidth - 1, m_BorderWidth - 1)
                If hti.Type = DataGrid.HitTestType.None Then
                    Resize_Internal()
                End If
            End If
        Catch ex As Exception
            Trace.WriteLine(ex)
        Finally
            m_Resizing = False
        End Try

    End Sub
    'The handler for processing grid resizing
    Private Sub ResizeHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Resize()
    End Sub

    'The handler for processing grid columns resizing
    Private Sub ResizeColumnHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_Resizing Then Exit Sub
        'Reset original column widths taking into account the width of resized column
        ResetColumnWidth()
        'then resize grid
        Resize()
    End Sub


    Dim m_SizedWidth As Integer 'The common width of sizable grid columns
    Dim m_FixedWidth As Integer 'The common width of grid columns with fixed width
    Dim m_ClientWidth As Integer 'client grid width takes into account grid border and vertical scrollbar
    'Recalculates different grid parameters befor columns resizing
    Function RecalcColumnWidth() As Double
        Dim ScrollBarWidth As Integer = GetScrollBarWidth()

        m_FixedWidth = Grid.RowHeaderWidth + ScrollBarWidth
        If (m_Grid.TableStyles.Count > 0 AndAlso m_Grid.TableStyles(0).RowHeadersVisible = False) OrElse m_Grid.RowHeadersVisible = False Then
            m_FixedWidth = ScrollBarWidth
        End If
        m_ClientWidth = Grid.Width - m_FixedWidth - 2 * m_BorderWidth
        Return m_ClientWidth
    End Function
    'Returns grid vertical scrollbar width
    Function GetScrollBarWidth() As Integer
        'DataGrid uses scroll bar controls for scrolling
        'It's VertScrollBar is protected and we can't get access to it directly
        'and we use reflection to retrieve pointer to grid vertical scrollbar
        Dim pi As PropertyInfo = Grid.GetType.GetProperty("VertScrollBar", BindingFlags.NonPublic Or BindingFlags.Instance)
        If Not pi Is Nothing Then
            Dim sb As ScrollBar = CType(pi.GetValue(Grid, Nothing), ScrollBar)
            If Not sb Is Nothing Then
                If sb.Visible Then Return sb.Width
                Return 0
            End If
        End If
        Return 0
    End Function
    'This method stores original grid columns widths in the m_Columns array
    Sub ResetColumnWidth()
        If m_Resizing Then Exit Sub
        m_SizedWidth = 0
        For Each c As ColumnData In m_Columns
            m_SizedWidth += c.Column.Width
            c.Width = c.Column.Width
        Next

    End Sub
End Class

'Helper class that is used to store original grid columns widths
Class ColumnData
    Sub New(ByVal c As DataGridColumnStyle)
        Column = c
        Width = c.Width
    End Sub
    Dim m_Column As DataGridColumnStyle
    Public Property Column() As DataGridColumnStyle
        Get
            Return m_Column
        End Get
        Set(ByVal Value As DataGridColumnStyle)
            m_Column = Value
        End Set
    End Property
    Public Width As Double
End Class
