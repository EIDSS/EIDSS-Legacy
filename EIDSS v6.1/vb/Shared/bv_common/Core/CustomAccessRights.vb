''' -----------------------------------------------------------------------------
''' <summary>
''' Defines the interface for retrieving user information including access permissions, 
''' system functions permissions and custom user properties.
''' </summary>
''' <remarks>
''' This interface is used by <i>MenuAction</i> class to hide/show system menu items. 
''' It hides menu item if current user have no rights to view specific menu item.
''' The implementation of this interface on the base level is <i>FullAccessRights</i> class that provides the full access rights to any system form/function.
''' Create your own implementation of this interface to provide the desired functionality. 
''' </remarks>
''' <history>
''' 	[Mike]	23.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Interface IUserInfo
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This method should compare the <i>IUserInfo</i> object passed as parameter 
    ''' with current object and return <b>True</b> if passed object includes all permissions defined in the current one.
    ''' </summary>
    ''' <param name="Rights">
    ''' <i>IUserInfo</i> object that defines permissions of the current system user
    ''' </param>
    ''' <returns>
    ''' <b>True</b> if passed <i>Rights</i> object includes all permissions defined in the current one.
    ''' </returns>
    ''' <remarks>
    ''' It is assumed that passed <i>Rights</i> object contains permissions of current system user, 
    ''' and the current object contains permissions required for execution of specific action.
    ''' Current <i>IUserInfo</i> object should be the part of the application UI element
    ''' (like menu item, button, form and so on) that requires 
    ''' access permission definition. UI element should use this method to define its appearance
    ''' through comparing with <i>IUserInfo</i> 
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function HasRight(ByVal Rights As IUserInfo) As Boolean
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Compares the set of permission functions of current object with the passed functions set 
    ''' and returns <b>True</b> if all passed functions are included to the current object.
    ''' </summary>
    ''' <param name="Functions">
    ''' The array of objects that describes the specific functions set.
    ''' </param>
    ''' <returns>
    ''' <b>True</b> if current object has sufficient rights to perform passed <i>Functions</i> set, <b>False</b> in other case.
    ''' </returns>
    ''' <remarks>
    ''' Passed <i>Functions</i> array is the abstract set of objects that describes the permissions required for execution of specific action,
    ''' current object should contain all permissions of current system user. The type of <i>Function</i> object depends on system requirements and should be implemented on the level of application, 
    ''' not on the level of base classes.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function HasFunctions(ByVal Functions As Object()) As Boolean
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns unique  identifier of <i>IUserInfo</i> object
    ''' </summary>
    ''' <remarks>
    ''' The interface doesn't define the type of the returned unique identifier, 
    ''' its type is defined by system requirements and <i>IUserInfo</i> implementation
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ReadOnly Property ID() As Object
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets custom property of current <i>IUserInfo</i> object defined by <i>PropertyName</i> parameter.
    ''' </summary>
    ''' <param name="PropertyName">
    ''' The custom property name
    ''' </param>
    ''' <remarks>
    ''' Use this property to retrieve the custom <i>IUserInfo</i> object property of arbitrary type. 
    ''' To retrieve string representation of custom property value use <i>TextProperty</i> property.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ReadOnly Property UserProperty(ByVal PropertyName As String) As Object
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gets string representation custom property of current <i>IUserInfo</i> object defined by <i>PropertyName</i> parameter.
    ''' </summary>
    ''' <param name="PropertyName">
    ''' The custom property name
    ''' </param>
    ''' <remarks>
    ''' Use this property to retrieve string representation of the custom <i>IUserInfo</i> object property. 
    ''' To retrieve native type of custom property value use <i>UserProperty</i> property.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ReadOnly Property TextProperty(ByVal PropertyName As String) As String

    Function HasOneOf(ByVal Functions As Object()) As Boolean

End Interface

''' -----------------------------------------------------------------------------
''' <summary>
''' The simplest implementation of <i>IUserInfo</i> interface that describes object 
''' with full access rights and contains no user information
''' </summary>
''' <remarks>
''' This object can be applied to UI elements that should be accessible for any user
''' in the application, for example to menu items like 'Exit'
''' </remarks>
''' <history>
''' 	[Mike]	23.03.2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class FullAccessRights
    Implements IUserInfo

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Dummy implementation of <i>UserProperty</i> property that always returns <b>Nothing</b>
    ''' </summary>
    ''' <param name="PropertyName">
    ''' The custom property name
    ''' </param>
    ''' <returns>
    ''' <b>Nothing</b>
    ''' </returns>
    ''' <remarks>
    ''' This property always returns <b>Nothing</b> and not supposed to be called.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property UserProperty(ByVal PropertyName As String) As Object Implements IUserInfo.UserProperty
        Get
            Return Nothing
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Dummy implementation of <i>UserProperty</i> property that always returns <b>Nothing</b>
    ''' </summary>
    ''' <param name="PropertyName">
    ''' The custom property name
    ''' </param>
    ''' <returns>
    ''' <b>Nothing</b>
    ''' </returns>
    ''' <remarks>
    ''' This property always returns <b>Nothing</b> and not supposed to be called for this implementation.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property TextProperty(ByVal PropertyName As String) As String Implements IUserInfo.TextProperty
        Get
            Return Nothing
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Always returns <b>True</b>.
    ''' </summary>
    ''' <param name="Rights">
    ''' <i>IUserInfo</i> object that defines permissions of the current system user
    ''' </param>
    ''' <returns>
    ''' Always returns <b>True</b> 
    ''' </returns>
    ''' <remarks>
    ''' Always returns <b>True</b>.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function HasRight(ByVal Rights As IUserInfo) As Boolean Implements IUserInfo.HasRight
        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Always returns <b>True</b>.
    ''' </summary>
    ''' <param name="Functions">
    ''' The array of objects that describes the specific functions set.
    ''' </param>
    ''' <returns>
    ''' Always returns <b>True</b> 
    ''' </returns>
    ''' <remarks>
    ''' Always returns <b>True</b>.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function HasFunctions(ByVal Functions As Object()) As Boolean Implements IUserInfo.HasFunctions
        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Dummy property implementation that always returns <b>Nothing</b>
    ''' </summary>
    ''' <returns>
    ''' <b>Nothing</b>
    ''' </returns>
    ''' <remarks>
    ''' This property always returns <b>Nothing</b> and not supposed to be called for this implementation.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	27.03.2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ID() As Object Implements IUserInfo.ID
        Get
            Return Nothing
        End Get
    End Property

    Public Function HasOneOf(ByVal Functions As Object()) As Boolean Implements IUserInfo.HasOneOf
        Return True
    End Function

End Class
