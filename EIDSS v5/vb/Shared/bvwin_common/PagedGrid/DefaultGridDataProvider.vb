Public Class DefaultGridDataProvider
    Implements IGridDataProvider

    Private m_form As BaseListForm = Nothing

    Public Sub New(ByVal ctl As Control)
        m_form = LocateIBase(ctl)
    End Sub

    Public Function GetDataView() As System.Data.DataView Implements IGridDataProvider.GetDataView
        If m_form.baseDataSet Is Nothing Then Return Nothing
        Dim dt As DataTable = GetBaseTable(m_form.baseDataSet)
        If Not dt Is Nothing Then Return dt.DefaultView
        Return Nothing
    End Function

    Public Sub Refresh() Implements IGridDataProvider.Refresh
        m_form.FillDataset(Nothing)
    End Sub

    Public Sub UpdateDetails() Implements IGridDataProvider.UpdateDetails
    End Sub

    Public Sub SetGrid(ByVal grid As BasePagedDataGrid) Implements IGridDataProvider.SetGrid
        ' NOOP
    End Sub

    Private Shared Function LocateIBase(ByVal ctl As Control) As BaseListForm
        If ctl Is Nothing Then
            Throw New SystemException("form containing PagedGrid should implement IBase interface")
        ElseIf TypeOf ctl Is BaseForm Then
            Return CType(ctl, BaseListForm)
        Else
            Return LocateIBase(ctl.Parent)
        End If
    End Function

    Private Function GetBaseTable(ByVal ds As DataSet) As DataTable
        ' fixme -- save data
        If ds.Tables.Count > 0 Then
            If Not m_form.ObjectName Is Nothing AndAlso m_form.ObjectName <> "" AndAlso ds.Tables.Contains(m_form.TableName) Then
                Return ds.Tables(m_form.ObjectName)
            End If
            Return ds.Tables(0)
        End If
        Return Nothing
    End Function
End Class
