Imports System.IO
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports bv.winclient.Localization


Public Class WinUtils

    Public Shared Function AppPath() As String
        Return Path.GetDirectoryName(Application.ExecutablePath)
    End Function

    Public Shared Function ConfirmMessage(ByVal msg As String, ByVal caption As String) As Boolean
        If MessageForm.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function ConfirmDelete() As Boolean
        Return ConfirmMessage(StringsStorage.Get("msgDeleteRecordPrompt", "The record will be deleted. Delete record?"), StringsStorage.Get("Delete Record"))
    End Function


    Public Shared Sub SwitchInputLanguage()
        For Each lang As InputLanguage In InputLanguage.InstalledInputLanguages
            If lang.Culture.TwoLetterISOLanguageName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName Then
                InputLanguage.CurrentInputLanguage = lang
                Return
            End If
        Next
    End Sub

    Private Shared ControlLanguageRegExp As New System.Text.RegularExpressions.Regex("\[(?<lng>.*)\]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Public Shared Sub SetControlLanguage(ByVal c As Control, ByRef LastInputLanguage As String)
        LastInputLanguage = GlobalSettings.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture)
        If Not c Is Nothing AndAlso TypeOf (c.Tag) Is String Then
            Dim m As System.Text.RegularExpressions.Match = ControlLanguageRegExp.Match(CType(c.Tag, String))
            If m.Success Then
                Dim s As String = m.Result("${lng}")
                SystemLanguages.SwitchInputLanguage(s)
            End If
        End If
    End Sub

    Public Shared Function HasControlAssignedLanguage(ByVal c As Control) As Boolean
        If Not c.Tag Is Nothing Then
            Dim m As System.Text.RegularExpressions.Match = ControlLanguageRegExp.Match(CType(c.Tag, String))
            Return m.Success
        End If
        Return False
    End Function
    Public Shared Sub AddClearButton(ByVal ctl As DevExpress.XtraEditors.ButtonEdit)
        For Each button As DevExpress.XtraEditors.Controls.EditorButton In ctl.Properties.Buttons
            If button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then Exit Sub
        Next
        AddHandler ctl.ButtonClick, AddressOf ClearButtonClick
        Dim btn As New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, StringsStorage.Get("btnClear", "Clear the field contents"))

        ctl.Properties.Buttons.Add(btn)
    End Sub

    Public Shared Sub AddClearButtons(ByVal container As Control)
        For Each ctl As Control In container.Controls
            If TypeOf (ctl) Is DevExpress.XtraEditors.ButtonEdit Then
                AddClearButton(CType(ctl, DevExpress.XtraEditors.ButtonEdit))
            End If
        Next
    End Sub
    Private Shared Sub ClearButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            CType(sender, DevExpress.XtraEditors.BaseEdit).EditValue = Nothing
        End If
    End Sub


    ''' <summary>
    ''' Stack frame number for search begins
    ''' </summary>
    ''' <remarks>Greater number increase speed, but decrease reliability.</remarks>
    Private Const START_FRAME As Integer = 4

    ''' <summary>
    ''' Check is component in design mode.</summary>
    ''' <param name="component">Component.</param>
    ''' <returns>true, if component open in designer.</returns>
    ''' <remarks>Lookup in stack trace</remarks>
    Public Shared Function IsComponentInDesignMode(ByVal component As IComponent) As Boolean

        '' if all is simple
        If Not (component.Site Is Nothing) Then
            Return component.Site.DesignMode
        End If

        '' not so simple...
        Dim sm_Interface_Match As Type
        sm_Interface_Match = GetType(IDesignerHost)

        Dim stack As StackTrace = New StackTrace()
        Dim frameCount As Integer = stack.FrameCount - 1
        '' look up in stack trace for type that implements interface IDesignerHost

        For frame As Integer = START_FRAME To frameCount
            Dim typeFromStack As Type
            typeFromStack = stack.GetFrame(frame).GetMethod().DeclaringType
            If sm_Interface_Match.IsAssignableFrom(typeFromStack) Then
                Return True
            End If
        Next

        '' small stack trace or IDesignerHost absence is not characteristic of designers
        Return False
    End Function

End Class
