Imports System.Drawing
Imports System.ComponentModel
Imports bv.winclient.BasePanel
Imports bv.common.Resources
Imports bv.winclient.Layout
Imports System.Data.SqlClient
Imports bv.model.Model.Core

Public Class ErrorForm
    Inherits DevExpress.XtraEditors.XtraForm

    Public Enum FormType
        [Error]
        Message
        Warning
    End Enum
    Dim m_ShowDetail As Boolean = True
    Dim m_Error As ErrorMessage = Nothing
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Type = FormType.Error
        bv.winclient.Core.Splash.HideSplash()
        LayoutCorrector.ApplySystemFont(Me)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnBottom As System.Windows.Forms.Panel
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnTop As System.Windows.Forms.Panel
    Friend WithEvents lbErrorText As System.Windows.Forms.Label
    Friend WithEvents pnDetails As System.Windows.Forms.Panel
    Friend WithEvents txtFullErrorText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbErrorText = New System.Windows.Forms.Label()
        Me.pnBottom = New System.Windows.Forms.Panel()
        Me.cmdSend = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.pnTop = New System.Windows.Forms.Panel()
        Me.pnDetails = New System.Windows.Forms.Panel()
        Me.txtFullErrorText = New DevExpress.XtraEditors.MemoEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBottom.SuspendLayout()
        Me.pnTop.SuspendLayout()
        Me.pnDetails.SuspendLayout()
        CType(Me.txtFullErrorText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'lbErrorText
        '
        resources.ApplyResources(Me.lbErrorText, "lbErrorText")
        Me.lbErrorText.Name = "lbErrorText"
        '
        'pnBottom
        '
        Me.pnBottom.Controls.Add(Me.cmdSend)
        Me.pnBottom.Controls.Add(Me.cmdDetail)
        Me.pnBottom.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnBottom, "pnBottom")
        Me.pnBottom.Name = "pnBottom"
        '
        'cmdSend
        '
        resources.ApplyResources(Me.cmdSend, "cmdSend")
        Me.cmdSend.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSend.Name = "cmdSend"
        '
        'cmdDetail
        '
        resources.ApplyResources(Me.cmdDetail, "cmdDetail")
        Me.cmdDetail.Name = "cmdDetail"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'pnTop
        '
        Me.pnTop.Controls.Add(Me.PictureBox1)
        Me.pnTop.Controls.Add(Me.lbErrorText)
        resources.ApplyResources(Me.pnTop, "pnTop")
        Me.pnTop.Name = "pnTop"
        '
        'pnDetails
        '
        Me.pnDetails.Controls.Add(Me.txtFullErrorText)
        Me.pnDetails.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.pnDetails, "pnDetails")
        Me.pnDetails.Name = "pnDetails"
        '
        'txtFullErrorText
        '
        resources.ApplyResources(Me.txtFullErrorText, "txtFullErrorText")
        Me.txtFullErrorText.Name = "txtFullErrorText"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ErrorForm
        '
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.cmdOk
        Me.Controls.Add(Me.pnDetails)
        Me.Controls.Add(Me.pnTop)
        Me.Controls.Add(Me.pnBottom)
        Me.MinimizeBox = False
        Me.Name = "ErrorForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBottom.ResumeLayout(False)
        Me.pnTop.ResumeLayout(False)
        Me.pnTop.PerformLayout()
        Me.pnDetails.ResumeLayout(False)
        CType(Me.txtFullErrorText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Properties"
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property [Error]() As ErrorMessage
        Get
            Return m_Error
        End Get
        Set(ByVal value As ErrorMessage)
            Dim handledSqlException As Boolean = False
            If Not value.Exception Is Nothing Then
                If TypeOf value.Exception Is SqlException Then
                    Dim msgId As String = SqlExceptionMessage.Get(CType(value.Exception, SqlException))
                    If (Not String.IsNullOrEmpty(msgId)) Then
                        value = New ErrorMessage(msgId)
                        handledSqlException = True
                    End If
                ElseIf TypeOf value.Exception Is InvalidOperationException Then
                    If value.Exception.Message = "Invalid operation. The connection is closed." Then
                        value = New ErrorMessage("errGeneralNetworkError", "Can't establish connection to the SQL Server. Please check that network connection is established and try to open this form again.", value.Exception)
                        handledSqlException = True
                    End If
                End If
            End If
            m_Error = value
            If Not value Is Nothing Then
                lbErrorText.Text = value.Text
                txtFullErrorText.Text = value.DetailError
                cmdDetail.Visible = txtFullErrorText.Text <> ""
                cmdSend.Visible = value.IsCriticalError
            End If
            If value.Exception Is Nothing AndAlso Not handledSqlException Then
                Type = FormType.Warning
            End If
        End Set
    End Property
    Private m_FormType As FormType
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property [Type]() As FormType
        Get
            Return m_FormType
        End Get
        Set(ByVal Value As FormType)
            m_FormType = Value
            Me.Text = BvMessages.Get(m_FormType.ToString())
            If Value <> FormType.Error Then
                ShowDetail = False
                cmdDetail.Visible = False
                cmdSend.Visible = False
            Else
                ShowDetail = False
                cmdDetail.Visible = Not Me.Error Is Nothing AndAlso Not Me.Error.Exception Is Nothing
                cmdSend.Visible = False
            End If
        End Set
    End Property
#End Region

#Region "Shared methods"

    Public Shared Sub ShowMessage(ByVal str As String, Optional ByVal DefaultStr As String = Nothing)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(str, DefaultStr)
        f.Type = FormType.Message
        ShowForm(f)
    End Sub

    Public Shared Sub ShowMessageDirect(ByVal msg As String)
        Dim f As ErrorForm = New ErrorForm
        f.lbErrorText.Text = msg
        f.txtFullErrorText.Text = ""
        f.Type = FormType.Message
        ShowForm(f)
    End Sub

    Public Shared Sub ShowWarning(ByVal str As String, Optional ByVal defaultStr As String = Nothing)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(str, defaultStr)
        f.Type = FormType.Warning
        ShowForm(f)
    End Sub
    Public Shared Sub ShowWarning(ByVal str As String, ByVal defaultStr As String, ByVal ParamArray args() As String)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(str, defaultStr, Nothing, args)
        f.Type = FormType.Warning
        ShowForm(f)
    End Sub

    Public Shared Sub ShowWarningDirect(ByVal str As String)
        Dim f As ErrorForm = New ErrorForm
        f.lbErrorText.Text = str
        f.txtFullErrorText.Text = ""
        f.Type = FormType.Warning
        ShowForm(f)
    End Sub
    Private Shared Function GetInnerException(ex As Exception) As Exception

        While (Not ex Is Nothing AndAlso Not ex.InnerException Is Nothing)
            Return GetInnerException(ex.InnerException)
        End While
        Return ex
    End Function

    Private Shared Function HandleError(ex As Exception) As Boolean
        If (ex Is Nothing) Then
            Return False
        End If
        ex = GetInnerException(ex)
        If (TypeOf (ex) Is SqlException) Then
            Dim msgId As String = SqlExceptionMessage.Get(CType(ex, SqlException))
            If (Not String.IsNullOrEmpty(msgId)) Then
                ShowError(msgId)
                Return True
            End If
        End If
        Return False
    End Function
    Public Shared Sub ShowError(ByVal ex As Exception)
        Trace.WriteLine(ex)
        If Utils.IsCalledFromUnitTest AndAlso ShowMode <> ErrorFormShowMode.ShowInUnitTest Then
            Throw New Exception(ex.Message, ex)
        End If
        If (HandleError(ex)) Then
            Return
        End If
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(ex)
        ShowForm(f)
    End Sub

    Public Shared Sub ShowError(ByVal errType As StandardError, ByVal ex As Exception)
        Trace.WriteLine(ex)
        If Utils.IsCalledFromUnitTest AndAlso ShowMode <> ErrorFormShowMode.ShowInUnitTest Then
            Throw New Exception(ex.Message, ex)
        End If
        If (HandleError(ex)) Then
            Return
        End If

        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(errType, ex)
        ShowForm(f)
    End Sub

    Public Shared Sub ShowError(ByVal Err As ErrorMessage, ByVal aType As FormType)
        If Err Is Nothing Then Return
        If Not Err.Exception Is Nothing Then
            Trace.WriteLine(Err.Exception)
        End If
        If Utils.IsCalledFromUnitTest AndAlso ShowMode <> ErrorFormShowMode.ShowInUnitTest Then
            If Not Err.Exception Is Nothing Then
                Throw New Exception(Err.Exception.Message, Err.Exception)
            End If
        End If
        Dim f As ErrorForm = New ErrorForm
        f.Type = aType
        f.Error = Err
        ShowForm(f)
    End Sub

    Public Shared Sub ShowError(ByVal Err As ErrorMessage)
        If Err Is Nothing Then Return
        If Not Err.Exception Is Nothing Then
            Dbg.WriteLine("User error exception {0}", Err.Exception)
        End If

        If Utils.IsCalledFromUnitTest AndAlso ShowMode <> ErrorFormShowMode.ShowInUnitTest Then
            If Not Err.Exception Is Nothing Then
                Throw New Exception(Err.Exception.Message, Err.Exception)
            End If
        End If

        Dim f As ErrorForm = New ErrorForm
        f.Error = Err
        ShowForm(f)
    End Sub

    Public Shared Sub ShowError(ByVal errMsg As String)

        Trace.WriteLine(Trace.Kind.Error, errMsg)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(errMsg)
        f.TopMost = True
        ShowForm(f)
    End Sub

    Public Shared Sub ShowError(ByVal errResourceName As String, ByVal errMsg As String)
        Trace.WriteLine(Trace.Kind.Error, errMsg)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(errResourceName, errMsg)
        ShowForm(f)
    End Sub
    Public Shared Sub ShowError(ByVal errResourceName As String, ByVal errMsg As String, ByVal ParamArray args() As String)
        Trace.WriteLine(Trace.Kind.Error, errMsg)
        Dim f As ErrorForm = New ErrorForm
        f.Error = New ErrorMessage(errResourceName, errMsg, Nothing, args)
        ShowForm(f)
    End Sub
    Public Shared Sub ShowErrorDirect(ByVal errMsg As String, ByVal ParamArray args() As String)
        If errMsg Is Nothing Then Return
        Dim f As ErrorForm = New ErrorForm
        If (Not args Is Nothing) Then
            errMsg = String.Format(errMsg, args)
        End If
        f.lbErrorText.Text = errMsg
        f.txtFullErrorText.Text = ""
        ShowForm(f)
    End Sub
    Public Shared Sub ShowErrorDirect(ByVal Owner As Form, ByVal ErrMsg As String, ByVal ParamArray Args() As String)
        If ErrMsg Is Nothing Then Return
        Dim f As ErrorForm = New ErrorForm
        If (Not Args Is Nothing) Then
            ErrMsg = String.Format(ErrMsg, Args)
        End If
        f.lbErrorText.Text = ErrMsg
        f.txtFullErrorText.Text = ""
        ShowForm(f, Owner)
    End Sub

    Private Delegate Sub ExceptionDelegate(ByVal ex As Exception)

    Public Shared Sub ShowErrorThreadSafe(ByVal ex As Exception)
        Dim o As ExceptionDelegate
        o = New ExceptionDelegate(AddressOf ShowError)

        If (BaseFormManager.MainForm Is Nothing) Then Throw ex
        BaseFormManager.MainForm.BeginInvoke(o, ex)
    End Sub

#End Region

#Region "Private methods"
    Private Sub cmdDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetail.Click
        ShowDetail = Not ShowDetail
    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private Property ShowDetail() As Boolean
        Get
            Return m_ShowDetail
        End Get
        Set(ByVal value As Boolean)
            Me.SuspendLayout()
            If value Then
                cmdDetail.Text = BvMessages.Get("btnHideErrDetail", "Hide Details")
                Me.ClientSize = New Size(Me.ClientSize.Width, pnTop.Height + pnDetails.Height + pnBottom.Height)
            Else
                cmdDetail.Text = BvMessages.Get("btnShowErrDetail", "Show Details")
                Me.ClientSize = New Size(Me.ClientSize.Width, pnTop.Height + pnBottom.Height)
            End If
            m_ShowDetail = value
            pnDetails.Visible = value
            Me.ResumeLayout()
        End Set
    End Property
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        If Not m_Error Is Nothing Then
            'm_Error.SendMessageToDevelopers()
        End If
    End Sub
#End Region

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.PerformLayout()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ' Save showed error to the log
        If (Not Me.m_Error Is Nothing) Then
            Trace.WriteLine(Trace.Kind.Error, Me.m_Error.DetailError())
        End If
    End Sub
    Private Shared m_ShowMode As ErrorFormShowMode = ErrorFormShowMode.Modal
    Public Shared Property ShowMode() As ErrorFormShowMode
        Get
            Return m_ShowMode
        End Get
        Set(ByVal value As ErrorFormShowMode)
            m_ShowMode = value
        End Set
    End Property
    Private Shared Sub ShowForm(ByVal frm As ErrorForm, ByVal owner As Form)
        frm.TopMost = True
        If (owner Is Nothing) Then
            owner = Form.ActiveForm
        End If
        Select Case m_ShowMode
            Case ErrorFormShowMode.Modal, ErrorFormShowMode.ShowInUnitTest
                If owner Is Nothing Then
                    frm.ShowDialog()
                Else
                    frm.ShowDialog(owner)
                End If
            Case ErrorFormShowMode.Normal
                frm.Show()
            Case ErrorFormShowMode.SkipInUnitTest
                If Not Utils.IsCalledFromUnitTest Then
                    If owner Is Nothing Then
                        frm.ShowDialog()
                    Else
                        frm.ShowDialog(owner)
                    End If
                End If
        End Select
    End Sub
    Private Shared Sub ShowForm(ByVal frm As ErrorForm)
        ShowForm(frm, Nothing)
    End Sub

End Class
