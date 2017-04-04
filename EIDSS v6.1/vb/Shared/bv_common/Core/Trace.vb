Imports System
Imports bv.common.Core
Imports bv.common.Diagnostics
Imports bv.common.Configuration

''' -----------------------------------------------------------------------------
''' <summary>
''' Writes trace/debug information to the application log file.
''' </summary>
''' <remarks>
''' The log file is placed in the same directory as application executable file and has the same name with '.log' extension.
''' </remarks>
''' <history>
''' 	[Mike]	03.04.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Trace
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Defines the type of the message displayed by the <i>Trace</i> class
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum Kind
        Undefine
        [Error]
        Warning
        Info
    End Enum

    'Public Shared logFile As StreamWriter = Nothing
    Public Shared MAX_LOG_SIZE As Integer = 1000000

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates new <i>Trace</i> instance
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Shared Sub New()
        Trace.Init()
    End Sub
    Private Shared m_output As DebugFileOutput
    Private Shared Sub Init()
        Dim message As String
        Try
            If (Not Dbg.OutputMethod Is Nothing AndAlso TypeOf (Dbg.OutputMethod) Is DebugFileOutput) Then
                m_output = CType(Dbg.OutputMethod, DebugFileOutput)
                Return
            End If

            m_output = Dbg.CreateDebugFileOutput(LogFileName)

            'Trace.logFile = Nothing
            'Trace.logFile = New StreamWriter(File.Open(LogFileName, FileMode.Append, FileAccess.Write, FileShare.Read), System.Text.Encoding.Unicode)
        Catch exception As Exception
            message = String.Format("Cannot open log file. {0}", exception.Message)
            System.Diagnostics.Trace.WriteLine(message)
            m_output = Nothing
        End Try
    End Sub
    Private Shared ReadOnly Property LogFileName() As String
        Get
            If BaseSettings.DebugLogFile <> "" Then
                Return BaseSettings.DebugLogFile
            End If
            Dim fname As String = Utils.GetExecutingAssembly
            If (Not fname Is Nothing) Then
                fname = fname.ToLowerInvariant()
                If fname.EndsWith(".exe") Then
                    Return fname.Replace(".exe", ".log")
                ElseIf fname.EndsWith(".dll") Then
                    Return fname.Replace(".dll", ".log")
                Else
                    Return fname + ".log"
                End If
            End If
            Return Nothing
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Writes the exception to the log file
    ''' </summary>
    ''' <param name="exception">
    ''' Exception that should be written to the log file
    ''' </param>
    ''' <remarks>
    ''' The full exception information included to the stack trace is written to the log file
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub WriteLine(ByVal exception As Exception)
        Trace.WriteLine(Kind.Error, exception.ToString())
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Writes the custom prefix followed by the exception to the log file
    ''' </summary>
    ''' <param name="prefix">
    ''' the text that will be inserted at the log record start
    ''' </param>
    ''' <param name="exception">
    ''' Exception that should be written to the log file
    ''' </param>
    ''' <remarks>
    ''' The full exception information included to the stack trace is written to the log file
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub WriteLine(ByVal prefix As String, ByVal exception As Exception)
        Trace.WriteLine(Kind.Error, prefix, exception)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Writes the custom prefix followed by the exception to the log file. The trace record will have the specific <i>Kind</i>.
    ''' </summary>
    ''' <param name="kind">
    '''  the trace <i>Kind</i>
    ''' </param>
    ''' <param name="prefix">
    ''' the text that will be inserted at the log record start
    ''' </param>
    ''' <param name="exception">
    ''' Exception that should be written to the log file
    ''' </param>
    ''' <remarks>
    ''' The full exception information included to the stack trace is written to the log file
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub WriteLine(ByVal kind As Kind, ByVal prefix As String, ByVal exception As Exception)
        Trace.WriteLine(kind, String.Format("{0} {1}", prefix, exception.ToString()))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Writes the custom formatted string to the log file
    ''' </summary>
    ''' <param name="kind">
    '''  the trace <i>Kind</i>
    ''' </param>
    ''' <param name="format">
    ''' the custom format string that should be written to the log file
    ''' </param>
    ''' <param name="Args">
    ''' optional format parameters that should be applied to the  <i>format</i> string
    ''' </param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub WriteLine(ByVal kind As Kind, ByVal format As String, ByVal ParamArray Args() As String)
        Dim Message As String
        Message = String.Format(format, Args)
        Trace.Write(kind, Message + vbCrLf)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Writes the custom message to the log file
    ''' </summary>
    ''' <param name="kind">
    '''  the trace <i>Kind</i>
    ''' </param>
    ''' <param name="message">
    ''' the custom string that should be written to the log file
    ''' </param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	03.04.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub WriteLine(ByVal kind As Kind, ByVal message As String)
        Trace.Write(kind, message + vbCrLf)
    End Sub

    Private Shared Sub Write(ByVal kind As Kind, ByVal message As String)
        Dim logMessage As String

        ' Open log file
        Try
            ' Prepare message
            logMessage = String.Format("[{0}] {1} {2}", DateTime.Now.ToString("d/M/yy H:mm:ss.fff"), kind.ToString(), message)
            ' Write to the standart trace output
            System.Diagnostics.Trace.WriteLine(logMessage)
            System.Diagnostics.Trace.Flush()
            If Not m_output Is Nothing Then
                m_output.WriteLine(logMessage)
            End If
            ' Write to log file
            '    If (Not Trace.logFile Is Nothing) Then
            '        System.Diagnostics.Trace.WriteLine("Trace_SyncLock_Start")
            '        SyncLock Diagnostics.DebugFileOutput.LogFileSyncObject
            '            If Trace.logFile.BaseStream.Length > MAX_LOG_SIZE Then
            '                Try
            '                    Trace.logFile.Close()
            '                    IO.File.Delete(LogFileName)
            '                Finally
            '                    Init()
            '                End Try
            '            End If

            '            Trace.logFile.Write(logMessage)
            '            Trace.logFile.Flush()
            '        End SyncLock
            '        System.Diagnostics.Trace.WriteLine("Trace_SyncLock_End")
            '    End If
        Catch exception As Exception
            logMessage = String.Format("Cannot write message" + vbCrLf + """{0}""" + vbCrLf + "to the log file. {1}", message.Replace(vbCrLf, ""), exception.Message)
            System.Diagnostics.Trace.WriteLine(logMessage)
            'MessageBox.Show(logMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Overloads Shared Function Equals(ByVal objA As Object, ByVal objB As Object) As Boolean
    End Function

    Private Overloads Shared Function ReferenceEquals(ByVal objA As Object, ByVal objB As Object) As Boolean
    End Function

End Class
