Public Class HorizCoordComparer
    Implements IComparer

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Compares <b>Left</b> coordinates of 2 controls
    ''' </summary>
    ''' <param name="x">
    ''' the first control to compare
    ''' </param>
    ''' <param name="y">
    ''' the second control to compare
    ''' </param>
    ''' <returns>
    ''' Returns A signed number indicating the relative values of controls <b>Left</b> coordinates.
    '''<list type="table">
    '''  <listheader>
    '''     <term>Return Value</term>
    '''     <description>Meaning</description>
    '''  </listheader>
    '''<item>
    '''<term>Less than zero</term>
    '''<description><b>x.Left</b> is less than <b>y.Left</b></description>
    '''</item>
    '''<item>
    '''<term>Zero</term>
    '''<description><b>x.Left</b> and <b>y.Left</b> are equal</description>
    '''</item>
    '''<item>
    '''<term>Greater than zero</term>
    '''<description><b>x.Left</b> is greater than <b>y.Left</b></description>
    '''</item>
    ''' </list>
    ''' </returns>
    ''' <history>
    ''' 	[Mike]	04.05.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
               Implements IComparer.Compare
        If TypeOf (x) Is Control AndAlso TypeOf (y) Is Control Then
            Dim LeftX As Integer
            If Not m_StoredLeftControlEdge.ContainsKey(CType(x, Control)) Then
                LeftX = CType(x, Control).Left
                m_StoredLeftControlEdge(CType(x, Control)) = LeftX
            Else
                LeftX = m_StoredLeftControlEdge(CType(x, Control))
            End If
            Dim LeftY As Integer
            If Not m_StoredLeftControlEdge.ContainsKey(CType(y, Control)) Then
                LeftY = CType(y, Control).Left
                m_StoredLeftControlEdge(CType(y, Control)) = LeftY
            Else
                LeftY = m_StoredLeftControlEdge(CType(y, Control))
            End If
            Return LeftY - LeftX
        End If
        Throw New ArgumentException("object is not a Control")
    End Function 'IComparer.Compare
    'This list stores left edge positions of controls that should be aligned horizontally
    'used for controls sorting by its left position
    Private m_StoredLeftControlEdge As New Collections.Generic.Dictionary(Of Control, Integer)
    Public Sub Clear()
        m_StoredLeftControlEdge.Clear()
    End Sub


End Class
