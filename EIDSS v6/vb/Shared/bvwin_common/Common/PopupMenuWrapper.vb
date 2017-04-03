Imports System.ComponentModel
Imports DevExpress.XtraBars
Imports bv.winclient.BasePanel

Public Class PopupMenuWrapper
    Implements IDisposable
    Private m_PopupMenu As PopupMenu
    Private Sub Init(ByVal menu As ContextMenu, ByVal BeforePopup As CancelEventHandler)
        If m_PopupMenu Is Nothing Then
            m_PopupMenu = New PopupMenu
            m_PopupMenu.Manager = BaseFormManager.MainBarManager
            AddHandler m_PopupMenu.CloseUp, AddressOf DisposeMenu
            If Not BeforePopup Is Nothing Then
                AddHandler m_PopupMenu.BeforePopup, BeforePopup
            End If

            For Each item As MenuItem In menu.MenuItems
                If Not item.Visible Then
                    Continue For
                End If
                Dim barButton As BarButtonItem = New BarButtonItem(m_PopupMenu.Manager, item.Text)
                barButton.Tag = item
                barButton.Enabled = item.Enabled
                AddHandler barButton.ItemClick, AddressOf BarButtonClick
                m_PopupMenu.AddItem(barButton)
            Next
        End If

    End Sub
    Public Sub New(ByVal menu As ContextMenu)
        Init(menu, Nothing)
    End Sub
    Public Sub New(ByVal menu As ContextMenu, ByVal BeforePopup As CancelEventHandler)
        Init(menu, BeforePopup)
    End Sub


    Private Sub DisposeMenu(ByVal sender As Object, ByVal e As EventArgs)
        Me.Dispose()
    End Sub

    Public Sub ShowPopup(ByVal p As System.Drawing.Point)
        If Not m_PopupMenu Is Nothing Then
            m_PopupMenu.ShowPopup(p)
        End If
    End Sub
    Private Sub BarButtonClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        CType(e.Item.Tag, MenuItem).PerformClick()
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not m_PopupMenu Is Nothing Then
                    m_PopupMenu.Dispose()
                    m_PopupMenu = Nothing
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
