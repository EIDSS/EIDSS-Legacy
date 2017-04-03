Imports bv.common.Resources
Imports System.ComponentModel
Imports bv.common.Core
Imports System.Data.SqlClient
Imports bv.common.Diagnostics
Imports bv.common.Enums

''' -----------------------------------------------------------------------------
''' <summary>
''' Lists the often occurred errors with predefined user friendly error text
''' </summary>
''' <remarks>
''' This enumeration is used by ErrorMessage and ErrorForm classes to identify often occurred standard errors
''' </remarks>
''' <history>
''' 	[Mike]	28.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
'Public Enum StandardError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during command parameter creation'. Should be used for processing errors that occur during IDbCommand Parameter object creation
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    CreateParameterError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during database operation'. Should be used for common database errors.
'    ''' </summary>
'    ''' <remarks>
'    ''' </remarks>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    DatabaseError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Some field contains invalid data'. Should be used for common displaying data validation errors.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    DataValidationError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during retrieving data from dataset'. Should be used when error occurs during retrieving data from database and filling form <b>DataSet</b> with this data.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    FillDatasetError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Invalid login name/password'. Should be used when user tried to login with invalid credentials.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    InvalidLogin
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Old (current) password incorrect for user. The password was not changed'. Should be used when user tried to change password and without valid old password.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    InvalidOldPassword
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Invalid value passed to the sql command parameter'. Should be used when invalid value is used as parameter for the sql command.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    InvalidParameter
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Multi-Language resource is not found'. Should be used when resource file containing requested resource is not found.
'    ''' </summary>
'    ''' <remarks>
'    ''' </remarks>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    MissingResource
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during saving data to database'. Should be used when errors occur during saving data to database.
'    ''' </summary>
'    ''' <remarks>
'    ''' </remarks>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    PostError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during executing sql query'. Should be used when sql error occurs other then <i>FillDatasetError</i>, <i>PostError</i> or <i>StoredProcedureError</i>.
'    ''' </summary>
'    ''' <remarks>
'    ''' </remarks>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    SqlQueryError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Error during executing sql stored procedure'. Should be used when error during stored procedure execution occurs.
'    ''' </summary>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    StoredProcedureError
'    ''' -----------------------------------------------------------------------------
'    ''' <summary>
'    ''' Displays the text 'Some error occurs in the application. Please send information about this error to developers team.'. Should be used when unprocessed error occur in application.
'    ''' </summary>
'    ''' <remarks>
'    ''' </remarks>
'    ''' <history>
'    ''' 	[Mike]	28.03.2006	Created
'    ''' </history>
'    ''' -----------------------------------------------------------------------------
'    UnprocessedError
'End Enum
''' -----------------------------------------------------------------------------
''' <summary>
''' Defines the dangerous level of <i>ErrorMessage</i> object.
''' </summary>
''' <history>
''' 	[Mike]	28.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Flags()> _
Public Enum ErrorKind
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Assigned to <i>ErrorMessage</i> object created for processed errors.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	28.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    NotificationError = 1
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Assigned to <i>ErrorMessage</i> object created for unprocessed errors that don't crush the application.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	28.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    UnprocessedError = 2
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Assigned to <i>ErrorMessage</i> object created for fatal errors that require application restarting.
    ''' </summary>
    ''' <history>
    ''' 	[Mike]	28.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    FatalError = 4
End Enum

''' -----------------------------------------------------------------------------
''' Project	 : bv_common
''' Class	 : common.ErrorMessage
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' This class is used as wrapper for all error messages that should be displayed for end users. 
''' It contains built in translation mechanism and allow displaying the error messages translated to native language.
''' </summary>
''' <remarks>
''' This class is assumed to be used as error wrapper everywhere in the application where the translated user friendly error message should be displayed for end user.
''' It contains several levels of error details and allows showing for end user as translated user friendly part of the error 
''' as detailed error information needed for developers. 
''' Internally it uses <i>BvMessages</i> class to translate error text and put it automatically to resource file during application development.
''' Use <i>ErrorForm</i> class to display error wrapped by <i>ErrorMessage</i> for end user.
''' </remarks>
''' <history>
''' 	[Mike]	28.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ErrorMessage

    Protected m_FriendlyErrorResourceName As String
    Protected m_FriendlyError As String
    Protected m_FullError As String
    Private m_ErrorKind As ErrorKind = ErrorKind.NotificationError
    Public [Exception] As Exception


#Region "Constructor"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the empty <i>ErrorMessage</i> class without any error information
    ''' </summary>
    ''' <remarks>
    ''' This is default constructor that can be used when you want to define error information directly through the <i>ErrorMessage</i> properties.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        m_FriendlyErrorResourceName = ""
        m_FriendlyError = ""
        m_FullError = Nothing
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new  <i>ErrorMessage</i> object initialized only by message that should be displayed for end user.
    ''' </summary>
    ''' <param name="errMsg">
    ''' the text that should be displayed for end user
    ''' </param>
    ''' <remarks>
    '''  <i>ErrorMessage</i> contains no detail error information in this case. 
    ''' If the passed error text is not contained in the resource file 
    ''' associated with <i>ErrorMessage</i> class, it
    ''' is added there using <i>errMsg</i> parameter as resource key name.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal errMsg As String)
        m_FriendlyErrorResourceName = errMsg
        m_FriendlyError = errMsg
        m_FullError = Nothing
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new  <i>ErrorMessage</i> object initialized only by message that should be displayed for end user.
    ''' </summary>
    ''' <param name="errResourceName">
    ''' the key name of the resource string in the related resource file
    ''' </param>
    ''' <param name="errMsg">
    ''' the text that should be displayed for end user
    ''' </param>
    ''' <remarks>
    ''' <i>ErrorMessage</i> contains no detail error information in this case. 
    ''' If the passed error text is not contained in the resource file 
    ''' associated with <i>ErrorMessage</i> class, it
    ''' is added there using <i>errResourceName</i> parameter as resource key name and <i>errMsg</i> as resource value.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String)
        m_FriendlyErrorResourceName = errResourceName
        m_FriendlyError = errMsg
        m_FullError = Nothing
    End Sub

    Protected m_formatArgs() As Object = Nothing
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String, ByVal ex As Exception, ByVal ParamArray args() As Object)
        If (HandleSqlError(ex)) Then
            Return
        End If
        m_FriendlyErrorResourceName = errResourceName
        m_FriendlyError = errMsg
        m_formatArgs = args
        If Not ex Is Nothing Then
            m_FullError = GetFullErrorText(ex, Nothing, True)
            Exception = ex
        Else
            m_FullError = Nothing
        End If
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new  <i>ErrorMessage</i> object initialized using standard error text and <b>Exception</b> object that caused this error.
    ''' </summary>
    ''' <param name="errType">
    '''     <i>StandardError</i> enumeration member that defines the standard user friendly error message.
    ''' </param>
    ''' <param name="ex">
    ''' <b>Exception</b> object that caused this error
    ''' </param>
    ''' <remarks>
    ''' <i>ErrorMessage</i> contains the detail error information in this case. 
    ''' If the text associated with <i>errType</i> is not contained in the <i>ErrorMessage</i> related resource file 
    ''' it is added there.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal errType As StandardError, Optional ByVal ex As Exception = Nothing)
        Dim ErrKind As ErrorKind
        If (HandleSqlError(ex)) Then
            Return
        End If
        SetStdErrorText(errType, ErrKind)
        If Not ex Is Nothing Then
            m_FullError = GetFullErrorText(ex, Nothing, (ErrKind And (Not ErrorKind.NotificationError)) <> 0)
            Exception = ex
        Else
            m_FullError = Nothing
        End If

    End Sub

    Private Function HandleSqlError(ex As Exception) As Boolean
        If ex Is Nothing Then
            Return False
        End If
        If (Not ex.InnerException Is Nothing AndAlso TypeOf (ex) Is SqlException) Then
            ex = ex.InnerException
        End If
        If (TypeOf (ex) Is SqlException) Then
            Dim msgId As String = SqlExceptionMessage.Get(CType(ex, SqlException))
            If (Not msgId Is Nothing) Then
                m_FriendlyErrorResourceName = msgId
                m_FullError = Nothing
                Exception = ex
                Dbg.Debug("Standard Sql Error: {0}", ex)
                Return True
            End If
        End If
        Return False
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new <i>ErrorMessage</i> object initialized by message that should be displayed 
    ''' for end user and by <b>Exception</b> object that caused this error.
    ''' </summary>
    ''' <param name="errResourceName">
    ''' the key name of the resource string in the related resource file
    ''' </param>
    ''' <param name="errMsg">
    ''' the text that should be displayed for end user
    ''' </param>
    ''' <param name="ex">
    ''' <b>Exception</b> object that caused this error
    ''' </param>
    ''' <remarks>
    ''' <i>ErrorMessage</i> contains detail error information in this case. 
    ''' If the passed error text is not contained in the resource file 
    ''' associated with <i>ErrorMessage</i> class, it
    ''' is added there using <i>errResourceName</i> parameter as resource key name and <i>errMsg</i> as resource value.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal errResourceName As String, ByVal errMsg As String, ByVal ex As Exception)
        If (HandleSqlError(ex)) Then
            Return
        End If
        m_FriendlyErrorResourceName = errResourceName
        m_FriendlyError = errMsg
        m_FullError = GetFullErrorText(ex, Nothing, False)
        Exception = ex
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new <i>ErrorMessage</i> object initialized by message that should be displayed 
    ''' for end user and by <b>Exception</b> object that caused this error.
    ''' </summary>
    ''' <param name="errMsg">
    ''' the text that should be displayed for end user
    ''' </param>
    ''' <param name="ex">
    ''' <b>Exception</b> object that caused this error
    ''' </param>
    ''' <remarks>
    ''' <i>ErrorMessage</i> contains the detail error information in this case. 
    ''' If the passed error text is not contained in the resource file 
    ''' associated with <i>ErrorMessage</i> class, it
    ''' is added there using <i>errMsg</i> parameter as resource key name.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal errMsg As String, ByVal ex As Exception)
        m_FriendlyErrorResourceName = errMsg
        m_FriendlyError = errMsg
        m_FullError = GetFullErrorText(ex, Nothing, False)
        Exception = ex
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Creates the new <i>ErrorMessage</i> object initialized by <b>Exception</b> object that caused this error.
    ''' </summary>
    ''' <param name="ex">
    ''' <b>Exception</b> object that caused this error
    ''' </param>
    ''' <remarks>
    ''' <i>ErrorMessage</i> contains the detail error information in this case. 
    ''' The message related with <i>StandardError.UnknownError</i> is used as user friendly error message in this case
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal ex As Exception)
        m_FriendlyErrorResourceName = "errUnknownError"
        m_FriendlyError = "Some error occurred in application"
        m_FullError = GetFullErrorText(ex, Nothing, True)
        Exception = ex
    End Sub


#End Region

#Region "Public properties"
    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shared Property Messages As BaseStringsStorage

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the text that should be displayed for end user
    ''' </summary>
    ''' <remarks>
    ''' The text retrieved using this property is translated using current application language.
    ''' The text passed to Set method is used as key for further translation
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Text() As String
        Get
            Return GetErrorText()
        End Get
        Set(ByVal Value As String)
            m_FriendlyErrorResourceName = Value
            m_FriendlyError = Value
        End Set
    End Property
    Private Shared Function GetMessage(resourceKey As String, Optional resourceValue As String = Nothing) As String
        Dim s As String = BvMessages.Get(resourceKey, resourceValue)
        If (BvMessages.Instance.IsValueExists) Then
            Return s
        End If
        If (Not Messages Is Nothing) Then
            s = Messages.GetString(resourceKey, resourceValue)
            Return s
        End If
        Return ""
    End Function
    Protected Overridable Function GetErrorText() As String
        If m_formatArgs Is Nothing Then
            Return GetMessage(m_FriendlyErrorResourceName, m_FriendlyError)
        Else
            Return String.Format(GetMessage(m_FriendlyErrorResourceName, m_FriendlyError), m_formatArgs)
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets not translated detailed error information including error stack trace
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property DetailError() As String
        Get
            Return m_FullError
        End Get
        Set(ByVal Value As String)
            m_FullError = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets or sets the <i>ErrorKind</i> of the <i>ErrorMessage</i> object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Property Kind() As ErrorKind
        Get
            Return m_ErrorKind
        End Get
        Set(ByVal Value As ErrorKind)
            m_ErrorKind = Value
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns the <b>True</b> for critical errors with <i>UnprocessedError</i> or <i>FatalError</i> <i>ErrorKind</i>
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	30.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property IsCriticalError() As Boolean
        Get
            Return m_ErrorKind > ErrorKind.NotificationError
        End Get
    End Property

    'Public Function SendMessageToDevelopers() As Boolean
    '    Return False
    'End Function
#End Region

#Region "Shared methods"
    Private Shared Sub PrintString(ByVal writer As System.IO.StringWriter, ByVal title As String, ByVal value As Object)
        If Not value Is Nothing AndAlso value.ToString.Trim() <> "" Then
            writer.WriteLine("{0,-30}{1}", title & ":", value.ToString)
        End If
    End Sub

    Private Shared Function GetFullErrorText(ByVal e As Exception, Optional ByVal msg As String = Nothing, Optional ByVal ShowStackTrace As Boolean = False) As String
        'Shared method that builds error message text from an exception or web service error text/
        'Override this method if you need display error in some other manner
        Dim errorMsg As System.IO.StringWriter = New System.IO.StringWriter
        If e Is Nothing Then
            errorMsg.WriteLine(msg)
        Else
            errorMsg.WriteLine(e.Message)
        End If

        ' add stack trace to the report
        If e Is Nothing Then
            Dim trace As New System.Diagnostics.StackTrace
            errorMsg.WriteLine(vbCrLf & "Local Stack Trace:")
            errorMsg.WriteLine(trace.ToString())
        Else
            errorMsg.WriteLine(vbCrLf & "Stack Trace:")
            errorMsg.WriteLine(vbCrLf & e.StackTrace)
            ' show inner exception if necessary
            If Not e.InnerException Is Nothing Then
                errorMsg.WriteLine(vbCrLf & "Inner Exception:")
                errorMsg.WriteLine(vbCrLf & e.InnerException.Message)
                If Not e.InnerException.InnerException Is Nothing Then
                    errorMsg.WriteLine(vbCrLf & "Inner Exception:")
                    errorMsg.WriteLine(vbCrLf & e.InnerException.InnerException.Message)
                End If
            End If
        End If

        Return errorMsg.ToString()
    End Function

    Private Function SetStdErrorText(ByVal se As StandardError, Optional ByRef errKind As ErrorKind = ErrorKind.UnprocessedError) As String
        Select Case se
            Case StandardError.CreateParameterError
                m_FriendlyErrorResourceName = "ErrCreateParameter"
                m_FriendlyError = "Error during command parameter creation."
            Case StandardError.DatabaseError
                m_FriendlyErrorResourceName = "ErrDatabase"
                m_FriendlyError = "Error during database operation."
            Case StandardError.DataValidationError
                m_FriendlyErrorResourceName = "ErrDataValidation"
                m_FriendlyError = "Some field contains invalid data."
            Case StandardError.FillDatasetError
                m_FriendlyErrorResourceName = "ErrFillDataset"
                m_FriendlyError = "Error during retrieving data from database."
            Case StandardError.InvalidLogin
                m_FriendlyErrorResourceName = "ErrInvalidLogin"
                m_FriendlyError = "Invalid login name/password."
                m_FullError = ""
            Case StandardError.InvalidOldPassword
                m_FriendlyErrorResourceName = "ErrOldPassword"
                m_FriendlyError = "	Old (current) password incorrect for user. The password was not changed."
                m_FullError = ""
            Case StandardError.InvalidParameter
                m_FriendlyErrorResourceName = "ErrInvalidParameter"
                m_FriendlyError = "Invalid value passed to the sql command parameter."
            Case StandardError.PostError
                m_FriendlyErrorResourceName = "ErrPost"
                m_FriendlyError = "Error during saving data to database."
            Case StandardError.SqlQueryError
                m_FriendlyErrorResourceName = "ErrSqlQuery"
                m_FriendlyError = "Error during executing sql query."
            Case StandardError.StoredProcedureError
                m_FriendlyErrorResourceName = "ErrStoredProcedure"
                m_FriendlyError = "Error during executing sql stored procedure."
            Case StandardError.UnprocessedError
                m_FriendlyErrorResourceName = "ErrUnprocessedError"
                m_FriendlyError = "Some error occurs in the application. Please send information about this error to developers team."
            Case Else
                m_FriendlyErrorResourceName = "ErrUndefinedStdError"
                m_FriendlyError = "Some error occurs in the application. Please send information about this error to developers team."
        End Select
        Return m_FriendlyError
    End Function


#End Region


End Class
