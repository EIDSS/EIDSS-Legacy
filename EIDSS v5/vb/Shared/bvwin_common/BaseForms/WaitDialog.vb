Imports DevExpress.Utils
Imports bv.common.Resources
Imports System.Web

Public Class WaitDialog
    Implements IDisposable

    Private ReadOnly m_DialogForm As WaitDialogForm
    Private ReadOnly m_Title As String
    Private m_Caption As String

    Public Sub New()
        m_Title = BvMessages.Get("msgWaitFormCaption", "Please wait")
        m_Caption = BvMessages.Get("msgWaitFormLoading", "The form is loading")
        m_DialogForm = Nothing
        If (HttpContext.Current Is Nothing) AndAlso (Not Utils.IsCalledFromUnitTest()) Then
            m_DialogForm = New WaitDialogForm(Caption, Title)
        End If
    End Sub

    Public Sub New(ByVal caption As String, ByVal title As String)
        m_Title = title
        m_Caption = caption
        m_DialogForm = Nothing
        If (HttpContext.Current Is Nothing) AndAlso (Not Utils.IsCalledFromUnitTest()) Then
            m_DialogForm = New WaitDialogForm(caption, title)
        End If
    End Sub

    Public ReadOnly Property Title() As String
        Get
            Return m_Title
        End Get
    End Property


    Public Property Caption() As String
        Get
            Return m_Caption
        End Get
        Set(ByVal value As String)
            m_Caption = value

            If Not m_DialogForm Is Nothing Then
                m_DialogForm.SetCaption(value)
            End If
        End Set
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        If Not m_DialogForm Is Nothing Then
            m_DialogForm.Close()
        End If
    End Sub
End Class
